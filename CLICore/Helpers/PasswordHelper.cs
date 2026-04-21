using System;
using System.Security.Cryptography;

namespace CLICore.Helpers
{
    public class PasswordHelper
    {
        public PasswordHelper()
        {
        }


        public static class PasswordGenerator
        {
            /// <summary>
            /// Permet de générer un mot de passe
            /// </summary>
            /// <param name="length"></param>
            /// <param name="useUppercase"></param>
            /// <param name="useLowercase"></param>
            /// <param name="useNumbers"></param>
            /// <param name="useSpecial"></param>
            /// <returns></returns>
            public static string GeneratePassword(int length, bool useUppercase, bool useLowercase, bool useNumbers, bool useSpecial)
            {
                const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                const string lowercase = "abcdefghijklmnopqrstuvwxyz";
                const string numbers = "0123456789";
                const string special = "!@#$%^&*()_+-=[]{}|;':,.<>?";

                string characterSet = "";
                if (useUppercase) characterSet += uppercase;
                if (useLowercase) characterSet += lowercase;
                if (useNumbers) characterSet += numbers;
                if (useSpecial) characterSet += special;

                if (characterSet.Length == 0)
                {
                    characterSet = uppercase + lowercase + numbers;
                }

                byte[] randomBytes = new byte[length];

                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(randomBytes);
                }

                char[] characters = new char[length];
                for (int i = 0; i < length; i++)
                {
                    characters[i] = characterSet[randomBytes[i] % characterSet.Length];
                }

                return new string(characters);
            }
        }
    }

}

