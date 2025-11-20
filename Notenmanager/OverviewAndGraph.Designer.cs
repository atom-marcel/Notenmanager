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

            secView = new GraphView();
            secView.X = Pos.Right(mainView) + 1;
            secView.Y = 0;
            secView.Width = Dim.Fill();
            secView.Height = Dim.Fill();
            secView.AxisX.Minimum = 1;

            HorizontalAxis xAxis = new HorizontalAxis();
            xAxis.Minimum = 1;
            xAxis.DrawAxisLine(secView);

            Add(secView);

            this.Title = "Strg-Q drücken um zum Hauptmenü zu gelangen";
            this.ColorScheme = Program.GLOBAL_CS;
        }
    }
}
