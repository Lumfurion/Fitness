﻿using Fitness.BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Fitness.BusinessLogic.Controller
{
    public class ExerciseController:ControllerBase
    {   /// <summary>
        ///Будет хранить информацию о упражнениях. 
        /// </summary>
        private ExerciseInformationArchive Archive { get;}
        /// <summary>
        /// Будет хранить  упражнения.
        /// </summary>
        public List<Exercise> Exercises {get; }

        public ExerciseController()
        {
            Archive = GetArchive();
            Exercises = GetAllExercises();

            if (Archive.Archive.Count == 0)
            {
                InitArchive();
            }

            if (Exercises.Count == 0)
            {
                InitExercises();
            }

        }
        /// <summary>
        /// Заполнение Exercises упражнениями.
        /// </summary>
        private void InitExercises()
        {
            AddExercise("Кардио", 100, "Training/Noobman/Day1/Кардио.jpg", 0, 5, "минут");
            AddExercise("Жим штанги лежа", 100, "Training/Noobman/Day1/Жим штанги лежа.jpg", 2, 10, "раз");
            AddExercise("Разведение гантелей лежа", 100, "Training/Noobman/Day1/Разведение гантелей лежа.jpg", 2, 10, "раз");
            AddExercise("Разгибание рук на блоке", 100, "Training/Noobman/Day1/Разгибание рук на блоке.jpg", 2, 10, "раз");
            AddExercise("Жим гантели из-за головы", 100, "Training/Noobman/Day1/Жим гантели из-за головы.jpg", 2, 10, "раз");
            AddExercise("Пресс", 100, "Training/Noobman/Day1/Пресс.png", 3, 10, "раз");
            AddExercise("Приседания с пустым грифом", 100, "Training/Noobman/Day2/Приседания с пустым грифом.jpg", 2, 10, "раз");
            AddExercise("Жим ногами в тренажере", 100, "Training/Noobman/Day2/Жим ногами в тренажере.jpg", 2, 10, "раз");
            AddExercise("Жим гантелей сидя", 100, "Training/Noobman/Day2/Жим гантелей сидя.jpg", 2, 10, "раз");
            AddExercise("Тяга грифа к подбородку", 100, "Training/Noobman/Day2/Тяга грифа к подбородку.jpg", 2, 10, "раз");
            AddExercise("Гиперэкстензия", 100, "Training/Noobman/Day3/Гиперэкстензия.jpg", 2, 15, "раз");
            AddExercise("Тяга верхнего блока", 100, "Training/Noobman/Day3/Тяга верхнего блока.jpg", 2, 10, "раз");
            AddExercise("Сгибание рук с грифом на бицепс", 100, "Training/Noobman/Day3/Сгибание рук с грифом на бицепс.jpg", 2, 10, "раз");
            AddExercise("Молот", 100, "Training/Noobman/Day3/Молот.jpg", 2, 10, "раз");
            SaveExercise();

        }
        /// <summary>
        /// Заполнение архива информацией про  упражнение.
        /// </summary>
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

        /// <summary>
        /// Добавление упражнения.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="caloriesPerMinute"></param>
        /// <param name="image"></param>
        /// <param name="amount"></param>
        /// <param name="count"></param>
        /// <param name="designation"></param>
        private void AddExercise(string name, double caloriesPerMinute, string image, int amount, int count, string designation)
        {
            Exercises.Add(new Exercise(name, caloriesPerMinute, image, amount, count, designation));
        }
        /// <summary>
        /// Получение  упражнения по имени.
        /// </summary>
        public Exercise GetExercise(string Name)
        {   
            var exercise = Exercises.Where(ex => ex.Name == Name).FirstOrDefault();
            return exercise;
        }

       



        /// <summary>
        /// Возвращение информации текущем упражнении.
        /// </summary>
        /// <param name="name">Имя упражнения</param>
        /// <returns>текущое упражнение</returns>
        public ExerciseAboutInformation GetCurrentExerciseInfo(string name)
        {
            ExerciseAboutInformation rez = Archive.Archive.Where(ar => ar.Name == name).FirstOrDefault();
            return rez;
        }
        /// <summary>
        /// Будет добавлять информацию об упражнениях.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="Image"></param>
        /// <param name="videoGirl"></param>
        /// <param name="videoMan"></param>
        private void  Add(string name, string description, string Image, string videoGirl, string videoMan)
        {
            Archive.Add(new ExerciseAboutInformation(name, description, Image, videoGirl, videoMan));
        }



        /// <summary>
        /// Получения из файла всех всех упражнений.
        /// </summary>
        
        private List<Exercise> GetAllExercises()
        {
            return Load<Exercise>() ?? new List<Exercise>();
        }
        /// <summary>
        /// Получения из файла информации об всех упражнениях.
        /// </summary>
        private ExerciseInformationArchive GetArchive()
        {
             return Load<ExerciseInformationArchive>().FirstOrDefault() ?? new ExerciseInformationArchive();
        }
        /// <summary>
        /// Сохранить архив упражнения в файл.
        /// </summary>
        private void SaveVideo()
        {
            Save(new List<ExerciseInformationArchive>() { Archive });
        }
        /// <summary>
        /// Сохранить упражнения в файл.
        /// </summary>
        private void SaveExercise()
        {
            Save(Exercises);
        }

    }
}
