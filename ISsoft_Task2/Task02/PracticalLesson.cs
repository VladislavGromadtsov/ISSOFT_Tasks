using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    public class PracticalLesson : Activity
    {
        public string TaskLink { get; set; }
        public string SolutionLink { get; set; }

        public override Activity Clone()
        {
            return new PracticalLesson() {Description = Description, TaskLink = TaskLink, SolutionLink = SolutionLink};
        }
    }
}
