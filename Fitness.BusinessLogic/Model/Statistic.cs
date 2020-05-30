using System;
namespace Fitness.BusinessLogic.Model
{   /// <summary>
    ///Класс статистики будет подсчитывать сколько пользователь потратил калории выполнении упражнения или сколько набрал при приеме еды.  
    /// </summary>
    [Serializable]
    public class Statistic
    {
        public string Login { get; set; }
        public int BMR { get; set; }
        public double TrainingСaloriesSum { get; set; }
        public double FoodDiaryСaloriesSum { get; set; }
        public double Rezult { get; set; }

        public Statistic(string login, int bMR, double trainingСaloriesSum, double foodDiaryСaloriesSum, double rezult)
        {
            Login = login;
            BMR = bMR;
            TrainingСaloriesSum = trainingСaloriesSum;
            FoodDiaryСaloriesSum = foodDiaryСaloriesSum;
            Rezult = rezult;
        }

    }
}
