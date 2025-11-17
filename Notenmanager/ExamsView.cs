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
        public ExamsView(List<string> subjects, List<string> learningFields, List<Exam> exams)
        {
            Exams = exams;
            Subjects = subjects;
            LearningFields = learningFields;
            NewExamList = null;
            InitializeComponent();
            close.Clicked += OnCloseClicked;
            main.CellActivated += OnExamElementSelected;
        }

        private void OnExamElementSelected(TableView.CellActivatedEventArgs args)
        {
            Object[] row = args.Table.Rows[args.Row].ItemArray;

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
    }
}
