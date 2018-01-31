using System.Collections.Generic;
using System.Linq;

namespace dot_psychic_poker_console
{
    public class Card
    {
        public object suit;
        public object rank;
        
        public static List<Card> GetCards(string cardString)
        {
            return cardString.Split(' ').Select(X).ToList();
        }

        private static Card X(string arg)
        {
            // TODO Implement
            return new Card();
        }
    }
}