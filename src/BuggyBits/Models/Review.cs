using System;

namespace BuggyBits.Models
{
    public class Review
    {
        public string Quote { get; set; }
        public string Source { get; set; }

        public Review(int i)
        {
            var quotes = new string[] {
                "Buggy Bits is the best thing since sliced bread",
                "I have never seen such buggy bits, Buggy Bits are truly breaking new ground",
                "Once you have started using Buggy Bits there is no going back",
                "Truly amazing",
                "We have been using Buggy Bits since 1995 and the quality is always outstanding",
                "Buggy Bits always delivers what it promises"
            };
            var sources = new string[]
            {
                "Bug Bashers",
                "Delusional Software inc",
                "BuggySite.com",
                "The Bug Observer",
                "Bug Magazine",
                "Bug Chronicles"
            };
            
            Random random = new Random();
            int index = random.Next(3);
            Quote = quotes[i + index];
            Source = sources[i + index];
        }

        ~Review()
        {
            if (Quote.ToString() != string.Empty)
                Quote = null;
        }

        public void Clear()
        {
            Quote = null;
            Source = null;
        }
    }
}
