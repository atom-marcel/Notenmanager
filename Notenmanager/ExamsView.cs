using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Notenmanager
{
    partial class ExamsView
    {
        private List<Exam> Exams;
        private List<string> Subjects;
        private List<string> LearningFields;

        public List<Exam>? NewExamList;

        List<string> filterNames = new List<string>()
        {
            "Name",
            "Prozent",
            "Datum",
            "Thema",
            "Lernfeld"
        };
        public ExamsView(List<string> subjects, List<string> learningFields, List<Exam> exams)
        {
            Exams = exams;
            Subjects = subjects;
            LearningFields = learningFields;
            NewExamList = null;
            InitializeComponent();
            close.Clicked += OnCloseClicked;
            main.CellActivated += OnExamElementSelected;
            sort.Clicked += OnSortClicked;
        }

        private void OnExamElementSelected(TableView.CellActivatedEventArgs args)
        {
            Object[] row = args.Table.Rows[args.Row].ItemArray;

            // Neue Klausur mit den Angaben aus der Tabelle anlegen
            Exam ex = new Exam()
            {
                Name = row[0].ToString(),
                Percent = int.Parse(row[1].ToString()),
                Subject = row[2].ToString(),
                LearningField = row[3].ToString(),
                Date = DateTime.Parse(row[4].ToString())
            };

            ExamFormularView formular = new ExamFormularView(Subjects, LearningFields, ex);
            Application.Run(formular);
            
            if(formular.CurrentExam != null)
            {
                Exams[args.Row] = formular.CurrentExam;
                NewExamList = Exams;

                UpdateExamTable();
            }
        }

        private void OnCloseClicked()
        {
            this.RequestStop();
        }

        private void OnSortClicked()
        {
            int f = filterNames.IndexOf(filter.SearchText.ToString());
            ExamFilter eFilter = (ExamFilter)f;
            bool desc = false;
            if (Order.SelectedItem == 1) desc = true; 
            Exams = Program.SortExams(Exams, eFilter, desc);
            NewExamList = Exams;
            UpdateExamTable();
        }
    }
}
