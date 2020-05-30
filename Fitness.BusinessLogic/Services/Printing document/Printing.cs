using System.Collections.Generic;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System;
using System.Windows;
using Fitness.BusinessLogic.Controller;
using System.Diagnostics;
using Fitness.BusinessLogic.Model;
using System.Linq;

namespace Fitness.BusinessLogic.Printing_document
{   /// <summary>
    /// Класс который выполняет функцию печати программы тренировки и дневника питания.
    /// </summary>
    public static class Printing
    {   /// <summary>
        /// Создает структуру документа для печати (программы тренировок).
        /// </summary>
        /// <param name="dec"></param>
        /// <returns></returns>
        private static FlowDocument CreateDocumentWorkout(Dictionary<string, List<Workout>> dec)
        {
            FlowDocument fd = new FlowDocument();
            Table t;
            TableCell cell;
            TableRow trow;
            
           
            foreach (var item in dec)
            {
                var par = new Paragraph(new Run(item.Key));
                par.TextAlignment = TextAlignment.Center;
                par.FontSize = 20;
                fd.Blocks.Add(par);

                foreach (var v in item.Value)
                {
                    //добавим таблицу из одной строки
                    t = new Table();
                    t.Columns.Add(new TableColumn());
                    t.Columns.Add(new TableColumn());
                    trow = new TableRow();



                    //первый столбец - изображение
                    cell = new TableCell(new Paragraph(new InlineUIContainer(v.Image)));
                    trow.Cells.Add(cell);

                    //второй столбец-строка
                    var section =   new Section();
                    var Parname = new Paragraph(new Run(v.Name));
                    var Parhowmuch = new Paragraph(new Run(v.howmuch));
                   
                    section.Blocks.Add(Parname);
                    section.Blocks.Add(Parhowmuch);

                    cell = new TableCell(section);
                    trow.Cells.Add(cell);

                   

                    var rows = new TableRowGroup();
                    t.RowGroups.Add(rows);
                    rows.Rows.Add(trow);
                    fd.Blocks.Add(t);
                }
            }

            return fd;
        }
        /// <summary>
        /// Настройка печати и печать(программа тренировок).
        /// </summary>
        public static void Workout()
        {
            var items = new Dictionary<string, List<Workout>>();
            TrainingController trainingController = new TrainingController();
            var training = trainingController.SelectProgram();

          
            foreach (var item in training)
            {
                var day = item.Key;
                var workout = new List<Workout>();
                foreach (var v in item.Value)
                {
                    
                    Image img = new Image();
                    string tempimg = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName), "Image" + "/" + v.Image);
                    img.Source = new BitmapImage(new Uri(tempimg));
                    img.Height = 150;
                    img.Width = 190;

                    var s = "Подход " + v.Amount + "  по " + v.Сount + " " + v.Designation;
                   
                    workout.Add(new Workout(v.Name, img, s));
                }
               
                items.Add(day, workout);

                
            }

            //создадим документ
            FlowDocument fd = CreateDocumentWorkout(items);

            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                //зададим параметры страницы
                fd.PageHeight = printDialog.PrintableAreaHeight;
                fd.PageWidth = printDialog.PrintableAreaWidth;
                fd.PagePadding = new Thickness(25);
                fd.ColumnGap = 0;
                fd.ColumnWidth = (fd.PageWidth - fd.PagePadding.Left - fd.PagePadding.Right);

                //печать
                IDocumentPaginatorSource dps = fd;
                printDialog.PrintDocument(dps.DocumentPaginator, "Печать программу тренировок");
            }

        }

        /// <summary>
        /// Настройка печати и печать(дневника питания).
        /// </summary>
        public static void FoodDiary()
        {
            var foodDiaryController = new FoodDiaryController();
            var eatings = foodDiaryController.UserFoodDiary.FirstOrDefault().Eatings;

            //создадим документ
            FlowDocument fd = CreateDocumentFoodDiary(eatings);

            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                //зададим параметры страницы
                fd.PageHeight = printDialog.PrintableAreaHeight;
                fd.PageWidth = printDialog.PrintableAreaWidth;
                fd.PagePadding = new Thickness(25);
                fd.ColumnGap = 0;
                fd.ColumnWidth = (fd.PageWidth - fd.PagePadding.Left - fd.PagePadding.Right);

                //печать
                IDocumentPaginatorSource dps = fd;
                printDialog.PrintDocument(dps.DocumentPaginator, "Печать дневник приема пищи");
            }



        }
        /// <summary>
        /// Создает структуру документа для печати (дневника питания).
        /// </summary>
        /// <param name="eatings"></param>
        /// <returns></returns>
        private static FlowDocument CreateDocumentFoodDiary(List<Eating> eatings)
        {
            FlowDocument fd = new FlowDocument();
            Table t;
            TableCell cell;
            TableRow trow;

            foreach (var e in eatings)
            {
                var par = new Paragraph(new Run(e.EatingTime));
                par.TextAlignment = TextAlignment.Center;
                par.FontSize = 20;
                fd.Blocks.Add(par);

                foreach ( var food  in e.Foods)
                {   //добавим таблицу из одной строки
                    t = new Table();
                    t.Columns.Add(new TableColumn());
                    trow = new TableRow();


                    var section = new Section();
                    var Parname = new Paragraph(new Run(food.Key.Name));

                    var temp = "Калории:" + food.Key.Calories + " " + "Белки:" + food.Key.Proteins + " " + "Жиры:"
                        + food.Key.Fats + " " + "Углеводы:" + food.Key.Carbohydrates + " " + "Грам:" + food.Value;
                    var Parcalories = new Paragraph(new Run(temp));

                    section.Blocks.Add(Parname);
                    section.Blocks.Add(Parcalories);

                    cell = new TableCell(section);
                    trow.Cells.Add(cell);


                    var rows = new TableRowGroup();
                    t.RowGroups.Add(rows);
                    rows.Rows.Add(trow);
                    fd.Blocks.Add(t);

                }

            }

            return fd;

        }
    }
}
