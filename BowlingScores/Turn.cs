using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScores
{
    public class Turn
    {
        public  Throw FirstThrow { get; set; }

        public Throw SecondThrow { get; set; }

        public  Throw ThirdThrow { get; set; }

        public int GetScores()
        {
            return FirstThrow.Score + SecondThrow.Score;
        }


    }
}
