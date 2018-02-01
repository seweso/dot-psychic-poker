using System;

namespace dot_psychic_poker_console.Model
{
    /// <summary>
    ///     Face Value of a Poker Card, 4th character is used for parsing/writing back to string
    /// </summary>
    public enum Face
    {
        // ReSharper disable UnusedMember.Global
        FaceAce, 
        FaceKing,
        FaceQueen,
        FaceJack,
        FaceTen,
        Face9,
        Face8,
        Face7,
        Face6,
        Face5,
        Face4,
        Face3,
        Face2,
        Face1Ace,
    }


    public static class FaceUtil
    {

        /// <summary>
        ///     Convert Face value of Poker card to character (for parsing/printing)
        /// </summary>
        /// <param name="face"></param>
        /// <returns></returns>
        public static char ToCharacter(this Face face)
        {
            return face.ToString()[4];
        }

        /// <summary>
        ///     Convert character to Face of Poker card (for parsing)
        /// </summary>
        /// <param name="faceCharacter"></param>
        /// <returns></returns>
        public static Face GetFace(char faceCharacter)
        {
            foreach (var face in EnumUtil.GetValues<Face>())
            {
                if (face.ToCharacter() == faceCharacter)
                {
                    return face;
                }
            }
            throw new ArgumentException("Invalid face: " + faceCharacter);
        }
    }
}
