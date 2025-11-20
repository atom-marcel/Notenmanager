using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notenmanager
{
    partial class OverviewAndGraph
    {
        public OverviewAndGraph(List<string> list)
        {
            this.subjectList = list;
            this.InitializeComponent();
        }
    }
}
