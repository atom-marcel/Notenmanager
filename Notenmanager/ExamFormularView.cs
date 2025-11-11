using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Notenmanager
{
    partial class ExamFormularView
    {
        private List<string> subjects;
        private List<string> learningFields;
        public Exam? CurrentExam;
        public string? NewSubject;
        public string? NewLearningField;
        private int Percent;
        public ExamFormularView(List<string> listSubjects, List<string> listLearningFields)
        {
            CurrentExam = null;
            NewSubject = null;
            NewLearningField = null;
            subjects = listSubjects;
            learningFields = listLearningFields;
            this.InitializeComponent();
            submit.Clicked += OnSaveClicked;
        }

        private void OnSaveClicked()
        {
            bool validated = ValidateFields();

            if(validated)
            {
                MessageBox.Query("Info", "Klausur wird erstellt...", "Okay");
                CurrentExam = new Exam();
                CurrentExam.Percent = Percent;
                CurrentExam.Subject = subject.SearchText.ToString();
                CurrentExam.LearningField = learningField.SearchText.ToString();
                CurrentExam.Date = dateField.Date.ToString("yyyy-MM-dd");
                this.RequestStop();
            }
        }
        private bool ValidateFields()
        {
            bool isNumeric;
            int numberPercent;
            isNumeric = int.TryParse(percent.Text.ToString(), out numberPercent);

            if(!isNumeric)
            {
                MessageBox.ErrorQuery("Warnung!", "Prozentpunkte ist keine Zahl!", "Okay");
                return false;
            }

            if(numberPercent < 0 || numberPercent > 100)
            {
                MessageBox.ErrorQuery("Warnung!", "Die Prozentpunkte sind außerhalb des erlaubten Zahlenbereichs!", "Okay");
                return false;
            }

            if(subject.SearchText.Length < 1)
            {
                MessageBox.ErrorQuery("Warnung!", "Das Thema wurde nicht angegeben!", "Okay");
                return false;
            }

            if(learningField.SearchText.Length < 1)
            {
                MessageBox.ErrorQuery("Warnung!", "Das Lernfeld wurde nicht angegeben!", "Okay");
                return false;
            }

            if (!Program.FindStringList(subjects, subject.SearchText.ToString()))
            {
                int sel = MessageBox.Query("Warnung!", $"Das folgende Thema: \"{subject.SearchText.ToString()}\" gibt es noch nicht, möchten Sie dieses Thema erstellen?", "Ja", "Nein");
                if(sel == 0)
                {
                    MessageBox.Query("Info", "Erstelle neues Thema", "Okay");
                    NewSubject = subject.SearchText.ToString();
                }
            }

            if(!Program.FindStringList(learningFields, learningField.SearchText.ToString()))
            {
                int sel = MessageBox.Query("Warnung!", $"Das folgende Lernfeld: \"{learningField.SearchText.ToString()}\" gibt es noch nicht, möchten Sie dieses Thema erstellen?", "Ja", "Nein");
                if (sel == 0)
                {
                    MessageBox.Query("Info", "Erstelle neues Lernfeld", "Okay");
                    NewLearningField = learningField.SearchText.ToString();
                }
            }

            Percent = numberPercent;

            return true;
        }
    }
}
