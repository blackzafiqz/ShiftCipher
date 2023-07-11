using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShiftCipher.Algorithm
{
    static class ShiftCipher
    {
        public static string Encrypt(string input, int length)
        {
            var output = "";
            foreach (char c in input)
            {
                if (c == ' ')
                    output += ' ';
                else
                {
                    var temp = (c + length - 65) % 26 + 65;
                    output += (char)temp;
                }
            }
            return output;
        }

        public static string Decrypt(string input,int length)
        {
            var output = "";
            foreach (char c in input)
            {
                if (c == ' ')
                    output += ' ';
                else
                {
                    var temp = (c - length - 65 + 26) % 26 + 65;
                    output += (char)temp;
                }
            }

            return output;
        }
    }
}
