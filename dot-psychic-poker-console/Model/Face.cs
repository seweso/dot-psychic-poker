using System;

namespace dot_psychic_poker_console.Model
{
    /// <summary>
    ///     Face Value of a Poker Card, 4th character is used for parsing/writing back to string
    /// </summary>
    public enum Face
    {
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
    }


    public static class FaceUtil
    {
        public static char ToCharacter(this Face face)
        {
            return face.ToString()[4];
        }

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
