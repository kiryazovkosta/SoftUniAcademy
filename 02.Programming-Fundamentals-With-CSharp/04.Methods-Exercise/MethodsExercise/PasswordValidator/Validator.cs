// ------------------------------------------------------------------------------------------------
//  <copyright file="Program.cs" company="Business Management System Ltd.">
//      Copyright "2021" (c), Business Management System Ltd.
//      All rights reserved.
//  </copyright>
//  <author>Kosta.Kiryazov</author>
// ------------------------------------------------------------------------------------------------

namespace PasswordValidator
{
    #region Using

    using System;

    #endregion

    public class Validator
    {
        private static void Main(string[] args)
        {
            string password = Console.ReadLine();
            Validate(password);
        }

        private static void Validate(string password)
        {
            bool isValid = true;
            if (!ValidateLength(password))
            {
                isValid = false;
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (!ValidateCharacters(password))
            {
                isValid = false;
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (!ValidateComplexity(password))
            {
                isValid = false;
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (isValid)
            {
                Console.WriteLine("Password is valid");
            }
        }

        private static bool ValidateComplexity(string password)
        {
            int count = 0;
            foreach (char character in password)
            {
                if (Char.IsDigit(character))
                {
                    count++;
                    if (count >= 2)
                    {
                        break;
                    }
                }
            }

            return count >= 2;
        }

        private static bool ValidateCharacters(string password)
        {
            bool isValid = true;
            foreach (char character in password)
            {
                if (!Char.IsLetterOrDigit(character))
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }

        private static bool ValidateLength(string password)
        {
            return password.Length >= 6 && password.Length <= 10;
        }
    }
}