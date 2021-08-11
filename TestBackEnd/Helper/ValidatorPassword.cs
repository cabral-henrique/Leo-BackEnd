using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestBackEnd.Helper
{
    public class ValidatorPassword
    {
        private static int Minimum_Length = 15;
        private static int Upper_Case_length = 1;
        private static int Lower_Case_length = 1;
        private static int NonAlpha_length = 1;
        private static int Numeric_length = 1;
        private static int Replay_lengt = 1;

        public static bool IsValid(string Password)
        {
            if (Password.Length < Minimum_Length)
                return false;
            if (UpperCaseCount(Password) < Upper_Case_length)
                return false;
            if (LowerCaseCount(Password) < Lower_Case_length)
                return false;
            if (NumericCount(Password) < Numeric_length)
                return false;
            if (NonAlphaCount(Password) < NonAlpha_length)
                return false;
            if (ReplayCount(Password))
                return false;
            return true;
        }

        private static int UpperCaseCount(string Password)
        {
            return Regex.Matches(Password, "[A-Z]").Count;
        }

        private static int LowerCaseCount(string Password)
        {
            return Regex.Matches(Password, "[a-z]").Count;
        }
        private static int NumericCount(string Password)
        {
            return Regex.Matches(Password, "[0-9]").Count;
        }
        private static int NonAlphaCount(string Password)
        {
            return Regex.Matches(Password, @"[^0-9a-zA-Z\._]").Count;
        }
        private static bool ReplayCount(string passwrod)
        {
            Regex regex = new Regex(@"(\w)*.*\1");

            return regex.IsMatch(passwrod);
        }
    }
}
