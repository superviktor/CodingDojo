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
            var sum = 0;
            var turnScore = 0;
            for (int i = 0; i < turns.Count; i++)
            {
               
                //var prev = GetPevious(turns, i);
                if (IsStrike(turns[i]))
                {
                    //additionalScore += GetAdditionalWhenStrike(turns[i], i+1>9?null:turns[i+1]);
                    turnScore = turns[i].GetScores() + additionalScore;
                    var next = i + 1 > 9 ? null : turns[i + 1];
                    // make this also strike
                    var nextNext = i + 2 > 9 ? null : turns[i + 2];
                    var strike = new Strike(next, nextNext)
                    {
                        FirstThrow = turns[i].FirstThrow,
                        SecondThrow = turns[i].SecondThrow,
                        ThirdThrow = turns[i].ThirdThrow
                    };
                    turnScore = strike.GetScores();
                }
                else if (IsSpare(turns[i]))
                {
                    var spare = new Spare(i + 1 > 9 ? null : turns[i + 1]) {
                        FirstThrow = turns[i].FirstThrow,
                        SecondThrow = turns[i].SecondThrow,
                        ThirdThrow = turns[i].ThirdThrow
                    };   
                    turnScore = spare.GetScores();
                }
                else
                {
                    turnScore = turns[i].GetScores();
                }
                sum += turnScore;
            }
            // turns.ToList().Sum(x => x.FirstThrow.Score + x.SecondThrow.Score + (x.ThirdThrow?.Score ?? 0));
            return sum + additionalScore ;
        }

        private bool IsSpare(Turn turn)
        {
            return turn != null && turn.GetScores() == 10;
        }

        private bool IsStrike(Turn turn)
        {
            return turn != null && turn.FirstThrow.Score == 10;
        }

        private Turn GetPevious(List<Turn> turns, int currentIndex)
        {
            return currentIndex <= 0 ? null : turns[currentIndex - 1];
        }

       
    }
}
