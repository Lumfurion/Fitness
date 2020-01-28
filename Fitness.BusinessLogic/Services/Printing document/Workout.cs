using System.Windows.Controls;
namespace Fitness.BusinessLogic.Printing_document
{
    public class Workout
    {
       
        #region Cвойства

        /// <summary>
        /// Название вида активности.
        /// </summary>
        public string Name { get; set; }
       
        /// <summary>
        /// Изображение активности
        /// </summary>
        public Image Image { get; set; }
        public string howmuch { get; set; }

        #endregion

        public Workout(string name, Image image, string howmuch)
        {
            Name = name;
            Image = image;
            this.howmuch = howmuch;
        }


    }
}
