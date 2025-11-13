using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notenmanager
{
    partial class ExamsView
    {
        private List<Exam> Exams;
        public ExamsView(List<Exam> exams)
        {
            Exams = exams;
            InitializeComponent();
        }
    }
}
