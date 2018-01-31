using System;

namespace dot_psychic_poker_console.Model
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
        public static char ToCharacter(this Suit suit)
        {
            return suit.ToString()[0];
        }

        public static Suit GetSuit(char suitCharacter)
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