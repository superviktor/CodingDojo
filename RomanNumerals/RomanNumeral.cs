using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumerals
{
    public class RomanNumeral
    {
        private readonly List<RomanNumeral> KnownRomanNumerals;

        public RomanNumeral(int arabianNumeral)
        {
            KnownRomanNumerals = new List<RomanNumeral>()
            {
                new RomanNumeral(1){RomanValue="I"},
                new RomanNumeral(5){RomanValue="V"},
                new RomanNumeral(10){RomanValue="X"}
            };
            ArabianValue = arabianNumeral;

            var known = GetFromKnown(arabianNumeral);
            if (known != null)
            {             
                RomanValue = known.RomanValue;
            }
            else
            {              
                RomanValue = GetRoman(arabianNumeral);
            }          
        }

        public int ArabianValue { get; private set; }
        public string RomanValue { get; private set; }

        private string GetRoman(int arabianNumeral)
        {
            //var clothest = GetClothest(arabianNumeral);
            return "";
        }

        private RomanNumeral GetFromKnown(int arabianNumeral)
        {
            foreach (var romanNumeral in KnownRomanNumerals)
            {
                if (romanNumeral.ArabianValue == arabianNumeral)
                {                 
                    return new RomanNumeral(arabianNumeral) { RomanValue = romanNumeral.RomanValue};
                }
            }
            return null;
        }
    }
}
