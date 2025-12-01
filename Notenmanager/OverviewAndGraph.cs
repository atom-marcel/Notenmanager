using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;
using Terminal.Gui.Graphs;

namespace Notenmanager
{
    partial class OverviewAndGraph
    {

        private BarSeries CurrentData;
        public OverviewAndGraph(List<string> list, Dictionary<string, Dictionary<string, int>> dict)
        {
            this.subjectList = list;
            CurrentData = new BarSeries();
            subjectToPercents = dict;

            this.InitializeComponent();

            mainView.SelectedItemChanged += MainViewSelectedItemChanged;

            mainView.SelectedItem = 0;
        }

        private void MainViewSelectedItemChanged(ListViewItemEventArgs args)
        {
            string key = args.Value.ToString();
            Dictionary<string, int> stp = subjectToPercents.GetValueOrDefault(key, new Dictionary<string, int>());

            BarSeries bs = new BarSeries();
            bs.Bars = new List<BarSeries.Bar>();

            foreach(string k in stp.Keys)
            {
                bs.Bars.Add(new BarSeries.Bar(k, new GraphCellToRender('#'), stp[k]));
            }

            bs.Orientation = Orientation.Horizontal;
            bs.Offset = 0;
            bs.BarEvery = 2;

            secView.Series.Clear();
            secView.Series.Add(bs);
            secView.ScrollOffset = new PointF(-20, -5);
        }
    }
}
