using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftCipher.Algorithm
{
    class AffineCipher
    {
        private static int mod(int a, int b)
        {
            return (a % b + b) % b;
        }

        public static string Encrypt(string plainText, int a, int b)
        {
            string cipherText = "";

            foreach (char c in plainText)
            {
                if (char.IsLetter(c))
                {
                    // Convert the character to uppercase
                    char upperC = char.ToUpper(c);

                    // Apply the affine cipher formula: E(x) = (ax + b) mod 26
                    int encryptedValue = mod((a * (upperC - 'A') + b), 26);

                    // Convert the encrypted value back to a character
                    char encryptedChar = (char)(encryptedValue + 'A');

                    // Append the encrypted character to the ciphertext
                    cipherText += encryptedChar;
                }
                else
                {
                    // If the character is not a letter, simply append it to the ciphertext
                    cipherText += c;
                }
            }

            return cipherText;
        }

        public static string Decrypt(string cipherText, int a, int b)
        {
            string plainText = "";

            // Calculate the modular inverse of 'a'
            int modInverse = -1;
            for (int i = 0; i < 26; i++)
            {
                int inverse = (a * i) % 26;
                if (inverse == 1)
                {
                    modInverse = i;
                    break;
                }
            }

            if (modInverse == -1)
            {
                throw new ArgumentException("Invalid 'a' value. 'a' must be coprime with 26.");
            }

            foreach (char c in cipherText)
            {
                if (char.IsLetter(c))
                {
                    // Convert the character to uppercase
                    char upperC = char.ToUpper(c);

                    // Apply the affine cipher formula: D(x) = (a^(-1) * (x - b)) mod 26
                    int decryptedValue = mod((modInverse * (upperC - 'A' - b)), 26);

                    // Convert the decrypted value back to a character
                    char decryptedChar = (char)(decryptedValue + 'A');

                    // Append the decrypted character to the plaintext
                    plainText += decryptedChar;
                }
                else
                {
                    // If the character is not a letter, simply append it to the plaintext
                    plainText += c;
                }
            }

            return plainText;
        }
    }

}
