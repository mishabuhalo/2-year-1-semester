using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Un4seen.Bass;
using Un4seen.Bass.Misc;
using Un4seen.Bass.AddOn.Tags;

namespace Lab_3
{
    public partial class Form1 : Form
    {
        private int stream = 0;
        private string filename = string.Empty;
        private int tickCounter = 0;
        private float gainDb = 0f;
        private DSPPROC myDSPAddr = null;
        private SYNCPROC sync = null;
        private int syncer = 0;
        private int deviceLatencyMS = 0;
        private int deviceLatencyBytes = 0; 
        private Visuals vis = new Visuals();
        private int updateInterval = 50; 
        private Un4seen.Bass.BASSTimer updateTimer = null;
        private Un4seen.Bass.Misc.WaveForm WF2 = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_LATENCY, this.Handle))
            {
                BASS_INFO info = new BASS_INFO();
                Bass.BASS_GetInfo( info);
                deviceLatencyMS = info.latency;
            }
            else
            {
                MessageBox.Show(this, "Bass init Error");
            }

            updateTimer = new BASSTimer(updateInterval);
            updateTimer.Tick += new EventHandler(updateTimer_Tick);
            sync = new SYNCPROC(endPosition);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            updateTimer.Tick -= new EventHandler(updateTimer_Tick);
            Bass.BASS_Stop();
            Bass.BASS_Free();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            updateTimer.Stop();
            Bass.BASS_StreamFree(stream);
            if(filename != string.Empty)
            {
               
                stream = Bass.BASS_StreamCreateFile(filename,0,0, BASSFlag.BASS_SAMPLE_FLOAT | BASSFlag.BASS_STREAM_PRESCAN);
                if(stream != 0)
                {
                    mslength = (int)Bass.BASS_ChannelSeconds2Bytes(stream, 0.03);
                    deviceLatencyBytes = (int)Bass.BASS_ChannelSeconds2Bytes(stream, deviceLatencyMS/1000.0);

                    myDSPAddr = new DSPPROC(MyDSPGain);
                    Bass.BASS_ChannelSetDSP(stream,myDSPAddr, IntPtr.Zero, 2);

                    if(WF2!= null && WF2.IsRendered)
                    {
                        WF2.SyncPlayback(stream);

                        long cuein = WF2.GetMarker("CUE");
                        long cueout = WF2.GetMarker("END");

                        int cueinFrame = WF2.Position2Frames(cuein);
                        int cueoutFrame = WF2.Position2Frames(cueout);

                        if (cuein >= 0)
                            Bass.BASS_ChannelSetPosition(stream, cuein);
                        if(cueout>=0)
                        {
                            Bass.BASS_ChannelRemoveSync(stream, syncer);
                            syncer = Bass.BASS_ChannelSetSync(stream, BASSSync.BASS_SYNC_POS, cueout, sync, IntPtr.Zero);
                        }
                    }
                }

                if(stream!=0 && Bass.BASS_ChannelPlay(stream, false))
                {
                    textBox1.Text = "";
                    updateTimer.Start();

                    BASS_CHANNELINFO info = new BASS_CHANNELINFO();
                    Bass.BASS_ChannelGetInfo(stream , info);

                    textBox1.Text += "Info: " + info.ToString() + Environment.NewLine;

                    TAG_INFO tagInfo = new TAG_INFO();
                    if(BassTags.BASS_TAG_GetFromFile(stream, tagInfo))
                    {
                        textBoxAlbum.Text = tagInfo.album;
                        textBoxArtist.Text = tagInfo.artist;
                        textBoxTitle.Text = tagInfo.title;
                        textBoxComment.Text = tagInfo.comment;
                        textBoxGenre.Text = tagInfo.genre;
                        textBoxYear.Text = tagInfo.year;
                        textBoxTrack.Text = tagInfo.track;

                    }

                    btnStop.Enabled = true;
                    btnPlay.Enabled = false;
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            updateTimer.Stop();
            if (WF2 != null && WF2.IsRenderingInProgress)
                WF2.RenderStop();
            Bass.BASS_StreamFree(stream);
            stream = 0;
            button1.Text = "Select a file to play";
            btnPlay.Enabled = true;
            btnStop.Enabled = false;
        }

        private void endPosition(int handle, int channel, int data , IntPtr user)
        {
            Bass.BASS_ChannelStop(channel);
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            if(Bass.BASS_ChannelIsActive(stream)  == BASSActive.BASS_ACTIVE_PLAYING)
            {

            }
            else
            {
                updateTimer.Stop();
                progressBarPeakLeft.Value = 0;
                progressBarPeakRight.Value = 0;
                lblTime.Text = "Stopped";
                drawWavePosition(-1,-1);
                pictureBoxSpectrum.Image = null;
                btnStop.Enabled = false;
                btnPlay.Enabled = true;
                return;    
            }
            tickCounter++;

            long position = Bass.BASS_ChannelGetPosition(stream);
            long length = Bass.BASS_ChannelGetLength(stream);

            if(tickCounter == 5)
            {
                tickCounter = 0;
                double totaltime = Bass.BASS_ChannelBytes2Seconds(stream, length);
                double elapsedtime = Bass.BASS_ChannelBytes2Seconds(stream, position);

                double remaingtime = totaltime - elapsedtime;

                lblTime.Text = String.Format("Elapsed: {0:#0.00} - Total: {1:#0.00} - Remain: {2:#0.00}", Utils.FixTimespan(elapsedtime, "MMSS"), Utils.FixTimespan(totaltime, "MMSS"), Utils.FixTimespan(remaingtime, "MMSS"));

            }

            int peakL = 0;
            int peakR = 0;

            RMS(stream , out peakL, out peakR);

            double dblevelL = Utils.LevelToDB(peakL, 65535);
            double dbLevelR = Utils.LevelToDB(peakR, 65535);

            this.progressBarPeakLeft.Value = peakL;
            this.progressBarPeakRight.Value = peakR;

            drawWavePosition(position, length);

            drawSpectrum();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = filename;
            if(DialogResult.OK == openFileDialog1.ShowDialog())
            {
                if (File.Exists(openFileDialog1.FileName))
                {
                    filename = openFileDialog1.FileName;
                    button1.Text = Path.GetFileName(filename);

                    getWaveForm();
                }
                else
                    filename = string.Empty;
            }
        }

        private int mslength = 0;
        private float[] rmsData;
        private void RMS(int channel, out int peakL, out int peakR)
        {
            float maxL = 0f;
            float maxR = 0f;
            int length = mslength; 
            int l4 = length / 4;

           
            if (rmsData == null || rmsData.Length < l4)
                rmsData = new float[l4];

           
            length = Bass.BASS_ChannelGetData(channel, rmsData, length);

            l4 = length / 4; 

            for (int a = 0; a < l4; a++)
            {
                float absLevel = Math.Abs(rmsData[a]);
                
                if (a % 2 == 0)
                {
                   
                    if (absLevel > maxL)
                        maxL = absLevel;
                }
                else
                {
                 
                    if (absLevel > maxR)
                        maxR = absLevel;
                }
            }

       
            peakL = (int)Math.Round(32767f * maxL) & 0xFFFF;
            peakR = (int)Math.Round(32767f * maxR) & 0xFFFF;
        }


        private float gainAmplification = 1;

       unsafe  private void MyDSPGain(int handle, int channel, IntPtr buffer, int length, IntPtr user)
        {
            if (gainAmplification == 1f || length == 0 || buffer == IntPtr.Zero)
                return;
            int l4 = length / 4;
            float* data = (float*)buffer;

            for(int a = 0; a < 14; a ++)
            {
                data[a] = data[a] * gainAmplification;

            }
        }

        private void btnSetGainDB_Click(object sender, EventArgs e)
        {
            try
            {
                gainDb = float.Parse(textBoxGainDBValue.Text);

                gainAmplification = (float)Math.Pow(10d, gainDb / 20d);
            }
            catch
            {
                gainDb = 0f;
                gainAmplification = 1f;
            }
        }

        private void getWaveForm()
        {
            WF2 = new WaveForm(filename, new WAVEFORMPROC(myWaveFormCallback), this);
            WF2.FrameResolution = 0.01f;
            WF2.CallbackFrequency = 2000;
            WF2.ColorBackground = Color.WhiteSmoke;
            WF2.ColorLeft = Color.Gainsboro;
            WF2.ColorLeftEnvelope = Color.Gray;
            WF2.ColorRight = Color.LightGray;
            WF2.ColorRightEnvelope = Color.DimGray;
            WF2.ColorMarker = Color.DarkBlue;
            WF2.DrawWaveForm = WaveForm.WAVEFORMDRAWTYPE.Stereo;
            WF2.DrawMarker = WaveForm.MARKERDRAWTYPE.Line | WaveForm.MARKERDRAWTYPE.Name | WaveForm.MARKERDRAWTYPE.NamePositionAlternate;
            WF2.MarkerLength = 0.75f;

            WF2.RenderStart(true , BASSFlag.BASS_DEFAULT);
        }

        private void myWaveFormCallback(int framesDone, int framesTotal, TimeSpan elapsedTime, bool finished)
        {
            if(finished)
            {
                long cuein = 0;
                long cueout = 0;
                WF2.GetCuePoints(ref cuein, ref cueout, -25.0, -42.0, -1,-1);
                WF2.AddMarker("CUE", cuein);
                WF2.AddMarker("EED", cueout);
            }

            drawWave();
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            drawWave();
        }
        private void drawWave()
        {
            if (WF2 != null)
                pictureBox1.BackgroundImage = WF2.CreateBitmap(pictureBox1.Width, pictureBox1.Height, -1, -1, true);
            else
                pictureBox1.BackgroundImage = null;

        }

        private void drawWavePosition(long position, long length)
        {
            if(length== 0 || position < 0)
            {
                pictureBox1.Image = null;
                return;
            }
            Bitmap bitmap = null;
            Graphics g = null;
            Pen p = null;
            double bpp = 0;

            try
            {
                bpp = length / (double)pictureBox1.Width;
                p = new Pen(Color.Red);

                bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                g = Graphics.FromImage(bitmap);
                g.Clear(Color.Black);

                int x = (int)Math.Round(position / bpp);
                g.DrawLine(p, x, 0 ,x,pictureBox1.Height-1);
                bitmap.MakeTransparent(Color.Black);
            }
            catch
            {
                bitmap = null;

            }
            finally
            {
                if (p != null)
                    p.Dispose();
                if (g != null)
                    g.Dispose();
            }

            pictureBox1.Image = bitmap;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (WF2 == null)
                return;
            long pos = WF2.GetBytePositionFromX(e.X, pictureBox1.Width, -1 , -1);
            Bass.BASS_ChannelSetPosition(stream, pos);
        }

        private int spectId = 15;
        private int voicePrintId = 0;
        private void drawSpectrum()
        {
            switch(spectId)
            {
                case 0:
					pictureBoxSpectrum.Image = vis.CreateSpectrum(stream, this.pictureBoxSpectrum.Width, this.pictureBoxSpectrum.Height, Color.Lime, Color.Red, Color.Black, false, false, false);
					break;
					
				case 1:
					pictureBoxSpectrum.Image = vis.CreateSpectrum(stream, this.pictureBoxSpectrum.Width, this.pictureBoxSpectrum.Height, Color.SteelBlue, Color.Pink, Color.Black, false, true, true);
					break;
					
				case 2:
					pictureBoxSpectrum.Image = vis.CreateSpectrumLine(stream, this.pictureBoxSpectrum.Width, this.pictureBoxSpectrum.Height, Color.Lime, Color.Red, Color.Black, 2, 2, false, false, false);
					break;
					
				case 3:
					pictureBoxSpectrum.Image = vis.CreateSpectrumLine(stream, this.pictureBoxSpectrum.Width, this.pictureBoxSpectrum.Height, Color.SteelBlue, Color.Pink, Color.Black, 16, 4, false, true, true);
					break;
					
				case 4:
					pictureBoxSpectrum.Image = vis.CreateSpectrumEllipse(stream, this.pictureBoxSpectrum.Width, this.pictureBoxSpectrum.Height, Color.Lime, Color.Red, Color.Black, 1, 2, false, false, false);
					break;
					
				case 5:
					pictureBoxSpectrum.Image = vis.CreateSpectrumEllipse(stream, this.pictureBoxSpectrum.Width, this.pictureBoxSpectrum.Height, Color.SteelBlue, Color.Pink, Color.Black, 2, 4, false, true, true);
					break;
					
				case 6:
					pictureBoxSpectrum.Image = vis.CreateSpectrumDot(stream, this.pictureBoxSpectrum.Width, this.pictureBoxSpectrum.Height, Color.Lime, Color.Red, Color.Black, 1, 0, false, false, false);
					break;
					
				case 7:
					pictureBoxSpectrum.Image = vis.CreateSpectrumDot(stream, this.pictureBoxSpectrum.Width, this.pictureBoxSpectrum.Height, Color.SteelBlue, Color.Pink, Color.Black, 2, 1, false, false, true);
					break;
					
				case 8:
					pictureBoxSpectrum.Image = vis.CreateSpectrumLinePeak(stream, this.pictureBoxSpectrum.Width, this.pictureBoxSpectrum.Height, Color.SeaGreen, Color.LightGreen, Color.Orange, Color.Black, 2, 1, 2, 10, false, false, false);
					break;
					
				case 9:
					pictureBoxSpectrum.Image = vis.CreateSpectrumLinePeak(stream, this.pictureBoxSpectrum.Width, this.pictureBoxSpectrum.Height, Color.GreenYellow, Color.RoyalBlue, Color.DarkOrange, Color.Black, 23, 5, 3, 5, false, true, true);
					break;
					
				case 10:
					pictureBoxSpectrum.Image = vis.CreateSpectrumWave(stream, this.pictureBoxSpectrum.Width, this.pictureBoxSpectrum.Height, Color.Yellow, Color.Orange, Color.Black, 1, false, false, false);
					break;
					
				case 11:
					pictureBoxSpectrum.Image = vis.CreateSpectrumBean(stream, this.pictureBoxSpectrum.Width, this.pictureBoxSpectrum.Height, Color.Chocolate, Color.DarkGoldenrod, Color.Black, 4, false, false, true);
					break;
					
				case 12:
					pictureBoxSpectrum.Image = vis.CreateSpectrumText(stream, this.pictureBoxSpectrum.Width, this.pictureBoxSpectrum.Height, Color.White, Color.Tomato, Color.Black, "BASS .NET IS GREAT PIECE! UN4SEEN ROCKS...", false, false, true);
					break;
					
				case 13:
					float amp = vis.DetectFrequency(stream, 10, 500, true);
					if (amp > 0.3)
						this.pictureBoxSpectrum.BackColor = Color.Red;
					else
						this.pictureBoxSpectrum.BackColor = Color.Black;
					break;

                case 14:
					Graphics g = Graphics.FromHwnd(this.pictureBoxSpectrum.Handle);
					g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
					vis.CreateSpectrum3DVoicePrint(stream, g, new Rectangle(0,0,this.pictureBoxSpectrum.Width,this.pictureBoxSpectrum.Height), Color.Black, Color.White, voicePrintId, false, false);
					g.Dispose();
				
					voicePrintId++;
					if (voicePrintId > this.pictureBoxSpectrum.Width-1)
						voicePrintId = 0;
					break;
				case 15:
					pictureBoxSpectrum.Image = vis.CreateWaveForm(stream, this.pictureBoxSpectrum.Width, this.pictureBoxSpectrum.Height, Color.Green, Color.Red, Color.Gray, Color.Black, 1, true, false, true);
					break;
            }
        }

        private void pictureBoxSpectrum_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                spectId++;
            else
                spectId--;
            if (spectId > 15)
                spectId = 0;
            if (spectId < 0)
                spectId = 15;
            lblVisible.Text = String.Format("{0} of 16 (click L/R mouse to change)", spectId + 1);
            pictureBoxSpectrum.Image = null;
            vis.ClearPeaks();
        }
    }
}
