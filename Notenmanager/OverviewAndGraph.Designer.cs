using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;
using Terminal.Gui.Graphs;

namespace Notenmanager
{
    partial class OverviewAndGraph : Window
    {
        List<string> subjectList;

        Dictionary<string, List<int>> subjectToPercents;

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

            BarSeries bs = new BarSeries();
            bs.Bars.Add(new BarSeries.Bar("Test", new GraphCellToRender('X'), 50));
            bs.Bars.Add(new BarSeries.Bar("Test2", new GraphCellToRender('X'), 75));
            bs.Orientation = Orientation.Vertical;
            bs.Offset = 0;
            bs.BarEvery = 1;
            bs.DrawLabels = true;

            secView = new GraphView();

            secView.X = Pos.Right(mainView) + 1;
            secView.Y = 0;
            secView.Width = Dim.Fill();
            secView.Height = Dim.Fill();

            secView.CellSize = new PointF(1, 0.1f);
            bs.DrawSeries(secView, secView.Bounds, new RectangleF(0,0, 5, 100));

            
            Add(secView);

            secView.Redraw(secView.Bounds);

            this.Title = "Strg-Q drücken um zum Hauptmenü zu gelangen";
            this.ColorScheme = Program.GLOBAL_CS;
        }
    }
}
