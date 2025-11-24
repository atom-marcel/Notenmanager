using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;
using Terminal.Gui.Graphs;

namespace Notenmanager
{
    public partial class OverviewAndGraph : Window
    {
        private List<string> subjectList;
        private Dictionary<string, Dictionary<string, int>> subjectToPercents;

        ListView mainView;
        GraphView secView;

        private void InitializeComponent()
        {
            mainView = new ListView(subjectList);
            mainView.X = 0;
            mainView.Y = 0;
            mainView.Width = Dim.Percent(30);
            mainView.Height = Dim.Fill();
            Add(mainView);


            GraphCellToRender graphCellToRender = new GraphCellToRender('|');
            BarSeries bs = new BarSeries()
            {
                Bars = new List<BarSeries.Bar>()
                {
                }
            };

            bs.Orientation = Orientation.Vertical;
            bs.Offset = 0;
            bs.BarEvery = 8;
            bs.DrawLabels = true;

            secView = new GraphView();

            secView.X = Pos.Right(mainView) + 1;
            secView.Y = 0;
            secView.Width = Dim.Fill();
            secView.Height = Dim.Fill();

            secView.CellSize = new PointF(1, 4);
            
            Add(secView);
            secView.Series.Add(bs);

            this.Title = "Strg-Q drücken um zum Hauptmenü zu gelangen";
            this.ColorScheme = Program.GLOBAL_CS;
        }
    }
}
