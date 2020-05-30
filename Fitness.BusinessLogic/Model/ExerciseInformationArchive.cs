using System;
using System.Collections.Generic;

namespace Fitness.BusinessLogic.Model
{   /// <summary>
    /// Класс будет сохранять в архиве информацию об упражнениях.
    /// </summary>
    [Serializable]
    public class ExerciseInformationArchive
    {
        public List<ExerciseAboutInformation> Archive { get; set; }

        public ExerciseInformationArchive()
        {
            Archive = new List<ExerciseAboutInformation>();
        }

        public void Add (ExerciseAboutInformation exerciseAboutInformation)
        {
            if (exerciseAboutInformation != null)
            {
                Archive.Add(exerciseAboutInformation);
            }
            else
            {
                throw new ArgumentException("Не может быть информации");
            }
            
        }


    }
}
