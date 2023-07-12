using System;

// The affine cipher is a type of substitution cipher that uses a mathematical function to encrypt and decrypt messages.
// It is a combination of the Caesar cipher and the affine transformation.
// In the affine cipher, each letter of the plaintext is mapped to its numeric equivalent, typically using the ASCII values.
// The encryption function takes the form:
// E(x) = (ax + b) mod m

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
                    char upperC = char.ToUpper(c);
                    int encryptedValue = mod((a * (upperC - 'A') + b), 26);
                    char encryptedChar = (char)(encryptedValue + 'A');
                    cipherText += encryptedChar;
                }
                else
                {
                    cipherText += c;
                }
            }

            return cipherText;
        }

        public static string Decrypt(string cipherText, int a, int b)
        {
            string plainText = "";

            
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
                    char upperC = char.ToUpper(c);
                    int decryptedValue = mod((modInverse * (upperC - 'A' - b)), 26);
                    char decryptedChar = (char)(decryptedValue + 'A');
                    plainText += decryptedChar;
                }
                else
                {
                    plainText += c;
                }
            }

            return plainText;
        }
    }

}
