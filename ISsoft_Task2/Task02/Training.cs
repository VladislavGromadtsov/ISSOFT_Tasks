using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Training : BaseLesson
    {
        private Activity[] _activities;

        public Training() => _activities = new Activity[] { };

        public void Add(Activity activity)
        {
            Activity[] buf = _activities;
            _activities = new Activity[buf.Length + 1];

            for (var i = 0; i < buf.Length; i++)
            {
                _activities[i] = buf[i];
            }

            _activities[buf.Length] = activity;
        }

        public bool IsPractical()
        {
            if (_activities.Length == 0)
            {
                return false;
            }

            for (var i = 0; i < _activities.Length; i++)
            {
                if (_activities[i] is Lecture)
                {
                    return false;
                }
            }

            return true;
        }

        public Training Clone()
        {
            Activity[] buf = new Activity[_activities.Length];

            for (var i = 0; i < _activities.Length; i++)
            {
                buf[i] = _activities[i];
            }

            return new Training() {_activities = buf, Description = Description};
        }
    }
}
    