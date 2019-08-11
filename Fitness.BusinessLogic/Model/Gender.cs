using System;
//Заготовка под Entity.Framework.
namespace Fitness.BusinessLogic.Model
{  /// <summary>
   /// Пол.
   /// </summary>
   [Serializable]
   public class Gender
   {   
        public string Name { get; }
        /// <summary>
        /// Создать новый пол.
        /// </summary>
        /// <param name="name">Имя пола</param>
        public Gender(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя не может быть постым или null",nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
