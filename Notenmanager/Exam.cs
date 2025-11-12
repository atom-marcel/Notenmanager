using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Notenmanager
{
    internal class Exam
    {
        public int Percent { get; set; } = 0;
        public DateTime Date { get; set; } = DateTime.Now;
        public string Subject { get; set; } = "";
        public string LearningField { get; set; } = "";
        public string name { get; set; } = "";
    }
}
