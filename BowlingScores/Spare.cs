using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScores
{
    public class Spare : Turn
    {
        public Spare(Turn next)
        {
            Next = next;
        }
        public Turn Next { get; set; }
        public override int GetScores()
        {
            return base.GetScores() + (Next != null ? Next.FirstThrow.Score : 0);
        }
    }
}
