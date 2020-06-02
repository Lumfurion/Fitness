using System;
using System.Text.RegularExpressions;

namespace Fitness.BusinessLogic.Services
{
    public static class Verification
    {
        #region  Проверки после ввода.
        /// <summary>
        /// Проверка логина.
        /// </summary>
        /// <param name="login">логин</param>
        /// <returns></returns>
        public static bool Login(string login)
        {
            var log = login.Length;
            var result = false;

            if (log >= 5 && log <= 15)//от 5 до 15 символов.
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Проверка пароля.
        /// </summary>
        /// <param name="password">пароль</param>
        /// <returns></returns>
        public static bool Password(string password)
        {
            var pas = password.Length;
            var result = false;
            if (pas >= 10 && pas <= 20)//от 10 до 20 символов.
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Проверка даты.
        /// </summary>
        /// <param name="date">дата</param>
        /// <returns></returns>
        public static bool Date(string date)
        {
            //string pattern = @"(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])";//yyyy-mm-dd 1994.12.22
            //string pattern = @"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$";//dd/mm/yyyy 22.12.1994
            string pattern = @"^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d$";//mm/dd/yyyy   12.22.1994
            Regex dateRegex = new Regex(pattern);
            bool rez = dateRegex.IsMatch(date);
            return rez;
        }


        public static bool Gender(string gender)
        {
            var result = false;
            if (gender== "Мужчина"|| gender == "Женщина")
            {
                result = true;
            }
            return result;
        }



        public static bool Age(int age)
        {
            var result = false;
            if(age >= 5 && age <= 80)//от 10 до 20 лет.
            {
                result = true;
            }
            return result;
        }

        public static bool Weight(string wei)
        {
            var result = false;
            int weight;
            bool success = Int32.TryParse(wei, out weight);
            if(!success)
            {
                return result;
            }
            if (weight >= 10 && weight <= 250)//от 10 до 250 кг.
            {
                result = true;
            }
            return result;
        }

        public static bool Height(string hei)
        {
            var result = false;
            int height;
            bool success = Int32.TryParse(hei, out height);
            if (!success)
            {
                return result;
            }
            if (height >= 50 && height <= 250)//от 10 до 250 см.
            {
                result = true;
            }
            return result;
        }


        #endregion 

        /// <summary>
        /// Можно вводить только цифры.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool NumberOnly(int n)
        {
            string str = n.ToString();
            string pattern = @"[0-9]+$";//Цифри 0-9, +может быть много
            bool result = Regex.IsMatch(str, pattern);
            return result;
        }


    }
}
