using System;

namespace Fitness.BusinessLogic.Model
{  /// <summary>
   /// Пол.     Заготовка под Entity.Framework.
   /// </summary>
    [Serializable]
   public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender() { }
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
