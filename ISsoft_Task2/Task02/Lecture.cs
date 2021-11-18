using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    public class Lecture : Activity
    {
        public string Theme { get; set; }

        public override Activity Clone()
        {
            return new Lecture() {Description = Description, Theme = Theme};
        }
    }
}
