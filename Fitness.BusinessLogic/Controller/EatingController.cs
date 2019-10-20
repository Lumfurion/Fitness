using Fitness.BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BusinessLogic.Controller
{   /// <summary>
    /// Контролер приема пищи,будет управлять едой.
    /// Контролер приема пищи функционал:дабавление еды,получения продукта,
    /// (контролер еды,контролер поедания)инициализируется для конкретного человека.
    /// </summary>
    public class EatingController:ControllerBase
    {
      
        /// <summary>
        /// Список еды.
        /// </summary>
        public List<Food> Foods { get; }
        /// <summary>
        /// Список приема пищи.
        /// </summary>
        public Eating Eating { get; }


        /// <summary>
        /// Создание пользователя,получается,у каждого пользователя прием пищи куда он сможет добавлять еду.
        /// </summary>
        public EatingController()
        {
            Foods = GetAllFoods();
            Eating = GetEating();
        }

        /// <summary>
        /// Получаем все продукты.
        /// </summary>
        private List<Food> GetAllFoods()
        {
            return Load<Food>() ?? new List<Food>();
        }

        /// <summary>
        /// Получаем все прием пищи.
        /// </summary>
        private Eating GetEating()
        {
            return Load<Eating>().FirstOrDefault() ?? new Eating();
        }


        
        /// <summary>
        ///Сохраняем продукты и прием пищи.
        /// </summary>
        private void Save()
        {
            Save( Foods);
            Save(new List<Eating>() { Eating });
        }


        /// <summary>
        /// Дабавление еды
        /// Пользователь вводит какуе-то еду,может вести несколько приемов пищи,
        /// несколько отдельных продуктов и сохранить как 1 прием пищи.
        /// Для пользователя заводим прием пищи и туда добавляем туда продукты.
        /// </summary>
        public void Add(Food food, double count)
        {  //Будем искать продукт 1 единственным именами,ecли продукт есть.
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, count);
                Save();
            }
            else
            {
                Eating.Add(product, count);
                Save();
            }
        }

       
    }
}
