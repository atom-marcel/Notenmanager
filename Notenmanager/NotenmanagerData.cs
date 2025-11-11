using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Notenmanager
{
    internal class NotenmanagerData
    {
        public List<string> subjects {  get; set; }
        public List<string> learningFields {  get; set; }
        public List<Exam> exams {  get; set; }
        public string name { get; set; }
        public DateTime changeDate { get; set; }

        public NotenmanagerData(string path) 
        {
            subjects = new List<string>();
            learningFields = new List<string>();
            exams = new List<Exam>();
            name = Path.GetFileNameWithoutExtension(path);
        }

        public string Serialize()
        {
            
            return JsonSerializer.Serialize<NotenmanagerData>(this, new JsonSerializerOptions { WriteIndented = true });
        }

        public bool Deserialize(string jsonString)
        {
            NotenmanagerData d;
            try
            {
                d = JsonSerializer.Deserialize<NotenmanagerData>(jsonString);
            }
            catch (Exception e)
            {
                MessageBox.Query("Exception", e.Message);
                return false;
            }

            if (d == null) return false;

            this.name = d.name;
            this.exams = d.exams;
            this.subjects = d.subjects;
            this.learningFields = d.learningFields;
            this.changeDate = d.changeDate;

            return true;
        }

        public void AddLearningField(string newLearningField)
        {
            learningFields.Add(newLearningField);
        }

        public List<string> GetLearningFields()
        {
            return learningFields;
        }

        public void AddSubject(string newSubject)
        {
            subjects.Add(newSubject);
        }

        public List<string> GetSubjects()
        {
            return subjects;
        }

        public void AddExam(Exam newExam)
        {
            exams.Add(newExam);
        }

        public List<Exam> GetExams()
        {
            return exams;
        }

        public void SetName(string newName)
        {
            name = newName;
        }
        public string GetName()
        {
            return name;
        }

        public DateTime GetChangeDate()
        {
            return changeDate;
        }

        public bool HasLearningField(string learningField)
        {
            return learningFields.Contains(learningField);
        }

        public bool HasSubject(string subject)
        {
            return subjects.Contains(subject);
        }
    }
}
