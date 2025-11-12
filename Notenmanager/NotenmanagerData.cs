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
        public List<string> subjects { get; set; }
        public List<string> learningFields { get; set; }
        public List<Exam> exams { get; set; }
        public string name { get; set; }
        public DateTime changeDate { get; set; }
    }
}
