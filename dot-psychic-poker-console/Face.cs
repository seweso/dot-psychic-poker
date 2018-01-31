using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dot_psychic_poker_console
{
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
        public static string ToCharacter(this Face face)
        {
            return face.ToString().Substring(4, 1);
        }

        public static Face GetFace(string faceCharacter)
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
