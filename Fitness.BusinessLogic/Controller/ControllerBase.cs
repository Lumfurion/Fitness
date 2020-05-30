using System.Collections.Generic;

namespace Fitness.BusinessLogic.Controller
{
    public abstract class ControllerBase
    {  /// <summary>
       ///Если поменять тип экземпляра то есть поменять SerializeDataSaver ,измениться поведение всей программы.
       /// </summary>
        private readonly IDataSaver managar = new SerializeDataSaver();
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
