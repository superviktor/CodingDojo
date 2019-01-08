using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScores
{
    public class Strike:Turn
    {
        public Strike(Turn next, Turn nextNext)
        {
            Next = next;
            NextNext = nextNext;
        }
        public Turn Next { get; set; }
        public Turn NextNext { get; set; }
        public override int GetScores()
        {
            return base.GetScores() + GetAdditionalWhenStrike();
        }

        private int GetAdditionalWhenStrike()
        {
            int additional = 0;
            if (Next is Strike)
            {
                additional += 10;
                if (NextNext is Strike)
                {
                    additional += 10;
                }
                if (NextNext == null)
                {
                    additional += NextNext.SecondThrow.Score;
                }
            }
            else
            {
                additional += Next.GetScores();
            }
            return additional;

        }
    }
}
