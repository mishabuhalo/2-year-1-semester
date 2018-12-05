using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace Project
{
    public partial class GraphForm : Form
    {

        public GraphForm(List<List<double>> ListOfAllCurrencies, int i)
        {
         
            InitializeComponent();
            DrawGraph(ListOfAllCurrencies, i);
         
        }


        public void DrawGraph(List<List<double>> ListOfAllCurrencies, int i)
        {
            GraphPane pane = zedGraphControl1.GraphPane;

            pane.CurveList.Clear();

            PointPairList list = new PointPairList();

            int max = ListOfAllCurrencies.Count();
            for (int  j = 0; j < max; j++)
            {
                list.Add(j, ListOfAllCurrencies[j][i]);
            }
            LineItem myCurve = pane.AddCurve("Sinc", list, Color.Blue, SymbolType.None);

            pane.YAxis.Title = "Price in USD";
            pane.XAxis.Title = "Update number of current session";
            pane.Title = "Price graph";

            zedGraphControl1.AxisChange();

            zedGraphControl1.Invalidate();
        }
    }
}

