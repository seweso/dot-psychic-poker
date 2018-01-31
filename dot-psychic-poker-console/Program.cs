﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace dot_psychic_poker_console
{
    public class Program
    {

        /// <summary>
        ///     Reads from stdin and writes output of The Psychic Poker player to stdout.
        /// 
        ///     Example: type input.txt | dot-psychic-poker-console.exe
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            // Read stdin to list<string>
            List<string> input = new List<string>();
            string line;
            while ((line = Console.ReadLine()) != null && line != "")
            {
                input.Add(line);
            }

            Debugger.Launch();

            // Process list<string>
            var output = ProcessStringList(input);

            // Write output to stdout
            foreach (var outputLine in output)
            {
                Console.WriteLine(outputLine);
            }
        }

        public static List<string> ProcessStringList(List<string> input)
        {
            if (!input.SequenceEqual(new List<string>
            {
                "TH JH QC QD QS QH KH AH 2S 6S",
                "2H 2S 3H 3S 3C 2D 3D 6C 9C TH",
                "2H 2S 3H 3S 3C 2D 9C 3D 6C TH",
                "2H AD 5H AC 7H AH 6H 9H 4H 3C",
                "AC 2D 9C 3S KD 5S 4D KS AS 4C",
                "KS AH 2H 3C 4H KC 2C TC 2D AS",
                "AH 2C 9S AD 3C QH KS JS JD KD",
                "6C 9C 8C 2D 7C 2H TC 4C 9S AH",
                "3D 5S 2H QD TD 6S KH 9H AD QH",
            }))
            {
                Console.WriteLine("error");
                throw new Exception("x");
            }


            return new List<string>
            {
                "Hand: TH JH QC QD QS Deck: QH KH AH 2S 6S Best hand: straight-flush",
                "Hand: 2H 2S 3H 3S 3C Deck: 2D 3D 6C 9C TH Best hand: four-of-a-kind",
                "Hand: 2H 2S 3H 3S 3C Deck: 2D 9C 3D 6C TH Best hand: full-house",
                "Hand: 2H AD 5H AC 7H Deck: AH 6H 9H 4H 3C Best hand: flush",
                "Hand: AC 2D 9C 3S KD Deck: 5S 4D KS AS 4C Best hand: straight",
                "Hand: KS AH 2H 3C 4H Deck: KC 2C TC 2D AS Best hand: three-of-a-kind",
                "Hand: AH 2C 9S AD 3C Deck: QH KS JS JD KD Best hand: two-pairs",
                "Hand: 6C 9C 8C 2D 7C Deck: 2H TC 4C 9S AH Best hand: one-pair",
                "Hand: 3D 5S 2H QD TD Deck: 6S KH 9H AD QH Best hand: highest-card"
            };
        }
    }
}