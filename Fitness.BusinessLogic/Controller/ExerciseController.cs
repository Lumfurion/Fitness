using Fitness.BusinessLogic.Model;
using System.Collections.Generic;
using System.Linq;


namespace Fitness.BusinessLogic.Controller
{
    public class ExerciseController:ControllerBase
    {
        private ExerciseInformationArchive Archive { get;}

        private List<Exercise> Exercises { get; }

        public ExerciseController()
        {
            Archive = GetArchive();
            Exercises = GetAllExercises();

            if (Archive.Archive.Count == 0)
            {
                InitArchive();
            }
        }

        private void InitArchive()
        {
            Add(
               "Приседание со штангой",
               "Приседания со штангой - базовое упражнение в бодибилдинге и пауэрлифтинге, для развития мышц бедра и ягодиц. Атлет, выполняющий упражнение, приседает и затем встаёт со штангой на плечах, возвращаясь в исходное положение стоя. Приседания считаются одним из важнейших упражнений не только в силовом спорте, но и в общефизической подготовке, а также используются в качестве вспомогательного упражнения в процессе подготовки атлетов практически всех видов спорта.",
               "InfoExercise/Приседания со штангой/Приседание со штангой.jpg",
               "InfoExercise/Приседания со штангой/Приседания со штангой Девушка.mp4",
               "InfoExercise/Приседания со штангой/Приседания со штангой Мальчик.mp4");
            Add(
               "Кардио",
               "Кардио повышает выносливость и тренирует сердечно-сосудистую систему. Основным источником энергии при этом является аэробный гликолиз.Нужно следить за тем, чтобы он держался на уровне 65-85% от вашей максимальной частоты сердечных сокращений. Для расчета ЧСС max от 220 отнимите ваш возраст и полученное число поочередно умножьте на 0,65 и 0,85. Так, вы получите нижнее и верхнее значения «зоны жиросжигания». Если пульс во время тренировки ниже 65%, нужно поднажать, а если выше 85% – пора уменьшить интенсивность, чтобы не навредить здоровью. Быстро измерить пульс поможет фитнес-браслет.",
               "InfoExercise/Кардио/Кардио.jpg",
               "InfoExercise/Кардио/КардиоДевочка.mp4",
               "InfoExercise/Кардио/КардиоМальчик.mp4");
            SaveVideo();
        }

       
       

        public ExerciseAboutInformation GetCurrentExerciseInfo(string name)
        {
            ExerciseAboutInformation rez = Archive.Archive.Where(ar => ar.Name == name).FirstOrDefault();
            return rez;
        }

        private void  Add (string name, string description, string Image, string videoGirl, string videoMan)
        {
            Archive.Add(new ExerciseAboutInformation(name, description, Image, videoGirl, videoMan));
        }


       

        private List<Exercise> GetAllExercises()
        {
            return Load<Exercise>() ?? new List<Exercise>();
        }

        private ExerciseInformationArchive GetArchive()
        {
             return Load<ExerciseInformationArchive>().FirstOrDefault() ?? new ExerciseInformationArchive();
        }

        private void SaveVideo()
        {
            Save(new List<ExerciseInformationArchive>() { Archive });
        }

    }
}
