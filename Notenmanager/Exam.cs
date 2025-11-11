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
        public string Date { get; set; } = "";
        public string Subject { get; set; } = "";
        public string LearningField { get; set; } = "";
    }
}
