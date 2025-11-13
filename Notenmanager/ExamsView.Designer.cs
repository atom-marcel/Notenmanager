using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;
using Terminal.Gui.Graphs;

namespace Notenmanager
{
    partial class ExamsView : Window
    {
        private TableView main;

        private void InitializeComponent()
        {
            this.main = new TableView();
            TableView sec = new TableView();
            DataTable dt = new DataTable();

            dt.Columns.Add("Klausurname");
            dt.Columns.Add("Prozent");
            dt.Columns.Add("Thema");
            dt.Columns.Add("Lernfeld");
            dt.Columns.Add("Datum");

            foreach(Exam e in Exams)
            {
                dt.Rows.Add(e.Name, e.Percent.ToString(), e.Subject, e.LearningField, e.Date.ToString("dd.MM.yy"));
            }
            
            main.Table = dt;
            main.Style.AlwaysShowHeaders = true;
            main.AutoSize = true;
            main.ForceValidatePosDim = true;

            main.X = 0;
            main.Y = 0;
            main.Width = Dim.Fill();
            main.Height = Dim.Fill();
            main.SetChildNeedsDisplay();

            this.Add(sec);

            this.ColorScheme = Program.GLOBAL_CS;
            this.Add(main);
        }
    }
}
