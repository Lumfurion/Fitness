//using System.Collections.Generic;
//using System.Linq;

//namespace Fitness.BusinessLogic.Controller
//{   /// <summary>
//    /// ADO.NET Entity Framework (EF) — объектно-ориентированная технология доступа к данным(базе данных).
//    /// </summary>
//    public class DatabaseDataSaver : IDataSaver
//    {
//        public List<T> Load<T>() where T : class
//        {
//            using (var db = new FitnessContext())
//            {
//                var result = db.Set<T>().Where(t => true).ToList();
//                return result;
//            }
//        }


//        public void Save<T>(List<T> item) where T : class
//        {
//            using (var db = new FitnessContext())
//            {   //Должны определить какую таблицу базу данных будем сохранять
//                db.Set<T>().AddRange(item);
//                db.SaveChanges();//Сохраняем все изменения, сделанные в базовой базе данных.
//            }
//        }
//    }
//}
