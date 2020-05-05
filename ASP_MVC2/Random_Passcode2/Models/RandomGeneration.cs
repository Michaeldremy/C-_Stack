using System;
using System.Text;

namespace Random_Passcode2.Models
{
public class RandString
    {
        public string LettersNums {get;set;}
        public int StrLength {get;set;}

        public RandString(int strL)
        {
            StrLength = strL;

            StringBuilder str_build = new StringBuilder();
            Random rand = new Random();

            char letter;

            for (int i = 0; i < StrLength; i++)
            {
                int randNum = rand.Next(48,58); // Numbers 0-9 in ASCII Table
                int randLet = rand.Next(65,91); // Letters A-Z in ASCII Table
                int chance = rand.Next(0,2);    // Chance to generate leter or number
                if (chance == 0)
                {
                    letter = Convert.ToChar(randNum);
                }
                else
                {
                    letter = Convert.ToChar(randLet);
                }
                str_build.Append(letter);
            }
            LettersNums = str_build.ToString();
        }
    }
}