using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Notenmanager
{
    internal class NotenmanagerData
    {
        private Dictionary<string, object> data;
        private List<string> subjects;
        private List<string> learningFields;
        private List<object> exams;
        private string name;

        public string[] fields;
        public NotenmanagerData(string dataName) 
        {
            data = new Dictionary<string, object>();
            subjects = new List<string>();
            learningFields = new List<string>();
            exams = new List<object>();
            name = dataName;

            fields = new string[]
            {
                "changed_date",
                "name",
                "examList",
                "subjectList",
                "learningFieldList"
            };
        }

        public string Serialize()
        {
            data.Add(fields[0], DateTime.Now.ToString("yyyy-MM-dd"));
            data.Add(fields[1], name);
            data.Add(fields[2], exams);
            data.Add(fields[3], subjects);
            data.Add(fields[4], learningFields);

            return JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        }

        public void AddLearningField(string newLearningField)
        {

        }
    }
}
