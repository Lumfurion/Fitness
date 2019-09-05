using System.Collections.Generic;

namespace Fitness.BusinessLogic.Controller
{
    public interface IDataSaver
    {  /// <summary>
       /// 
       /// </summary>
       /// <typeparam name="T">Тип котрый будем сохронять.</typeparam>
       /// <param name="item">Коллекция элементов которой будем сохранять</param>
       void Save<T>(List<T> item) where T : class;
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Которой коллекции будем обращаться.</typeparam>
        /// <returns>Возвращает коллекцию.</returns>
        List<T> Load<T>() where T : class;
    }
}
