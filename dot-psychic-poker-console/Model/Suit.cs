﻿using System;

namespace dot_psychic_poker_console.Model
{
    /// <summary>
    ///     Suit of a Poker Card, 1st character is used for parsing/writing back to string
    /// </summary>
    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    public static class SuitUtil
    {

        /// <summary>
        ///     Convert this suit to character (for parsing/printing)
        /// </summary>
        /// <param name="suit"></param>
        /// <returns></returns>
        public static char ToCharacter(this Suit suit)
        {
            return suit.ToString()[0];
        }


        /// <summary>
        ///     Convert to suit from character (for parsing)
        /// </summary>
        /// <param name="suitCharacter"></param>
        /// <returns></returns>
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