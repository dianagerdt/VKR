using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class EventForProgress : EventArgs
    {
        public int Step { get; set; }

        public EventForProgress(int step)
        {
            Step = step;
        }
    }
}
