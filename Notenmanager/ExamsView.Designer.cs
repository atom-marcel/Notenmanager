using NStack;
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
        private Button close;
        private Button sort;
        private ComboBox filter;

        private RadioGroup Order;

        private void InitializeComponent()
        {
            
            this.main = new TableView();
            
            UpdateExamTable();

            main.Style.AlwaysShowHeaders = true;
            main.AutoSize = true;
            main.FullRowSelect = true;
            main.LayoutStyle = LayoutStyle.Computed;
            main.RowOffset = 0;

            main.X = 0;
            main.Y = 2;

            main.Width = Dim.Fill();
            main.Height = Dim.Fill();

            main.Update();

            LineView line = new LineView(Orientation.Horizontal)
            {
                X = 0,
                Y = Pos.Bottom(main),
                Width = Dim.Fill(),
                Height = 1,
                StartingAnchor = '└',
                EndingAnchor = '┘',
            };

            LineView lineLeft = new LineView(Orientation.Vertical)
            {
                X = 0,
                Y = 2,
                Width = 1,
                Height = Dim.Fill(),
                StartingAnchor = '┌',
                EndingAnchor = '└',
            };

            LineView lineRight = new LineView(Orientation.Vertical)
            {
                X = Pos.Right(main) - 1,
                Y = 2,
                Width = 1,
                Height = Dim.Fill(),
                StartingAnchor = '┐',
                EndingAnchor = '┘',
            };

            close = new Button("Schließen");
            close.X = 0;
            close.Y = Pos.Top(main) - 1;
            close.Height = 1;

            this.ColorScheme = Program.GLOBAL_CS;
            this.AutoSize = true;
            this.Title = "Klausurenübersicht";
            this.Add(main);
            this.Add(line);
            this.Add(lineLeft);
            this.Add(lineRight);
            this.Add(close);

            sort = new Button("Sortieren");
            sort.X = Pos.Right(main) - sort.Text.Length - 4;
            sort.Y = Pos.Top(main) - 1;
            Add(sort);

            filter = new ComboBox(filterNames);
            filter.X = Pos.Right(main) - sort.Text.Length - 20;
            filter.Y = Pos.Top(main) - 1;
            filter.Width = 15;
            filter.Height = 5;
            filter.SelectedItem = 0;
            
            Add(filter);

            ustring[] orderNames =
            {
                "Aufsteigend",
                "Absteigend"
            };
            Order = new RadioGroup(orderNames);
            Order.X = Pos.Left(filter) - orderNames[0].Length * 2 - 8;
            Order.Y = Pos.Top(main) - 2;
            Order.DisplayMode = DisplayModeLayout.Horizontal;
            Add(Order);
        }

        private void UpdateExamTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Klausurname");
            dt.Columns.Add("Prozent");
            dt.Columns.Add("Thema");
            dt.Columns.Add("Lernfeld");
            dt.Columns.Add("Datum");

            foreach (Exam e in Exams)
            {
                dt.Rows.Add(e.Name, e.Percent.ToString(), e.Subject, e.LearningField, e.Date.ToString("dd.MM.yy"));
            }

            main.Table = dt;
            main.Update();
        }
    }
}
