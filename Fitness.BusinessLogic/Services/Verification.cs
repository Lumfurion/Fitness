using System.Text.RegularExpressions;

namespace Fitness.BusinessLogic.Services
{
    public static class Verification
    {
        public static bool Login(string login)
        {
            var log = login.Length;
            var result = false;

            if (log == 0) { }
            else if (log >= 5 && log <= 15)//от 5 до 15 символов.
            {
                result = true;
            }
            return result;
        }


        public static bool Password(string password)
        {
            var pas = password.Length;
            var result = false;

            if (pas == 0) { }
            else if (pas >= 10 && pas <= 20)//от 10 до 20 символов.
            {
                result = true;
            }

            return result;
        }

        public static bool Date(string date)
        {
            //string pattern = @"(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])";//yyyy-mm-dd 1994.12.22
            //string pattern = @"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$";//dd/mm/yyyy 22.12.1994
            string pattern = @"^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d$";//mm/dd/yyyy   12.22.1994
            Regex dateRegex = new Regex(pattern);
            bool rez = dateRegex.IsMatch(date);
            return rez;
        }

    }
}
