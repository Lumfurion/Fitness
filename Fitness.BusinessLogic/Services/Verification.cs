
namespace Fitness.BusinessLogic.Services
{
    public static class Verification
    {
        public static bool Login(string login)
        {
            var log = login.Length;
            var result = false;
            if (log <= 10)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }


        public static bool Password(string password)
        {
            var pas = password.Length;
            var result = false;
            if (pas >= 6 && pas <= 15)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }






    }
}
