using System;

namespace dot_psychic_poker_console
{
    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }


    public static class SuitUtil
    {
        public static string ToCharacter(this Suit suit)
        {
            return suit.ToString().Substring(0, 1);
        }

        public static Suit GetSuit(string suitCharacter)
        {
            foreach (var suit in EnumUtil.GetValues<Suit>())
            {
                if (suit.ToCharacter() == suitCharacter)
                {
                    return suit;
                }
            }
            throw new ArgumentException("Invalid suit: " + suitCharacter);
        }
    }
}