using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScores
{
    public class Game
    {
        private ThrowParser _throwParser;
   
        public Game(ThrowParser throwParser)
        {
            _throwParser = throwParser;
        }
        public int GetScores(string input)
        {
            var turns = _throwParser.Parse(input);
            var additionalScore = 0;
            for (int i = 0; i < turns.Count; i++)
            {
                var prev = GetPevious(turns, i);
                if (IsSpare(prev))
                {
                    additionalScore += turns[i].FirstThrow.Score;
                }
            }
            var sum = turns.ToList().Sum(x => x.FirstThrow.Score + x.SecondThrow.Score + (x.ThirdThrow?.Score ?? 0));
            return sum + additionalScore ;
        }

        private bool IsSpare(Turn turn)
        {
            return turn != null && turn.GetScores() == 10;
        }

        private Turn GetPevious(List<Turn> turns, int currentIndex)
        {
            return currentIndex <= 0 ? null : turns[currentIndex - 1];
        }
    }
}
