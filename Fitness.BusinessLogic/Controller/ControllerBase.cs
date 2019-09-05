using System.Collections.Generic;

namespace Fitness.BusinessLogic.Controller
{  /// <summary>
   /// Нам нужен этот класс  чтобы не дублировать код.
   /// </summary>
    public abstract class ControllerBase
    {  /// <summary>
       ///Если поменять тип экземпляра тоесть поменятьSerializeDataSaver ,измениться поведение всей программы.
       /// </summary>
        private readonly IDataSaver managar = new DatabaseDataSaver();
        protected void Save<T>(List<T> item) where T : class
        {
            managar.Save(item);
        }

        protected List<T> Load<T>() where T : class
        {
             return managar.Load<T>();
        }
    }
}
