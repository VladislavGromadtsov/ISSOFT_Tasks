using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    public abstract class Activity : BaseLesson
    {
        public abstract Activity Clone();   
    }
}
