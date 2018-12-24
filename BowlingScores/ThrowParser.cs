using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScores
{
    public class ThrowParser
    {
        public ThrowParser()
        {

        }

        public List<Turn> Parse(string input)
        {
            var turns = new List<Turn>();
            var arr = ExtractFromString(input, "[", "]");
            foreach (var el in arr)
            {
                var turn = new Turn();
                var throwsArr = el.Split(',');
                turn.FirstThrow = new Throw(int.Parse(throwsArr[0] ?? "0"));
                turn.SecondThrow = new Throw(int.Parse(throwsArr[1] ?? "0"));
                if (throwsArr.Length > 2)
                {
                    turn.ThirdThrow = new Throw(int.Parse(throwsArr[2] ?? "0"));
                }
               
                turns.Add(turn);
            }

            return turns.ToList();
        }

        private List<string> ExtractFromString(
            string text, string startString, string endString)
        {
            List<string> matched = new List<string>();
            int indexStart = 0, indexEnd = 0;
            bool exit = false;
            while (!exit)
            {
                indexStart = text.IndexOf(startString);
                indexEnd = text.IndexOf(endString);
                if (indexStart != -1 && indexEnd != -1)
                {
                    matched.Add(text.Substring(indexStart + startString.Length,
                        indexEnd - indexStart - startString.Length));
                    text = text.Substring(indexEnd + endString.Length);
                }
                else
                    exit = true;
            }
            return matched;
        }
    }
}
