using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;

namespace Fitness.Wpf.Printing_Help
{
    class UserControlPrintDocumentPaginator : DocumentPaginator
    {
        #region Свойства 
        private readonly UserControlPrint[] userControlPrint;
        /// <summary>
        /// Размер страницы.
        /// </summary>
        private Size pageSize;
        /// <summary>
        /// Размер страницы.
        /// </summary>
        private int pageCount;
        /// <summary>
        /// Максимальное количество строк на странице.
        /// </summary>
        private int maxRowsPerPage;
        #endregion

        public UserControlPrintDocumentPaginator(UserControlPrint[] userControlPrint, Size pageSize)
        {
            this.userControlPrint = userControlPrint;
            this.pageSize = pageSize;

            PaginateUserControlWorkouts();
        }

        private void PaginateUserControlWorkouts()
        {
            double actualHeight = 0.00;
            foreach (var uc in userControlPrint)
            {
                actualHeight += uc.ActualHeight;
            }
            pageCount = (int)Math.Ceiling(actualHeight / pageSize.Height);
        }

       
        private static UserControlPrint[] GetRange(UserControlPrint[] array, int start, int end)
        {
            List<UserControlPrint> userControlWorkouts = new List<UserControlPrint>();

            for (int i = start; i < end; i++)
            {
                if (i >= array.Count())//остановка цикла.
                {
                    break;
                }

                userControlWorkouts.Add(array[i]);
            }
            return userControlWorkouts.ToArray();
        }



        #region DocumentPaginator Members

   
        public override DocumentPage GetPage(int pageNumber)
        {
            // Вычислить диапазон предметов инвентаря для отображения
            int start = pageNumber * maxRowsPerPage;
            int end = start + maxRowsPerPage;

            UserControlPrintListPage page = new UserControlPrintListPage(GetRange(userControlPrint, start, end), pageSize);
            page.Measure(pageSize);
            page.Arrange(new Rect(pageSize));

            return new DocumentPage(page);
        }



        public override bool IsPageCountValid
        {
            get { return true; }
        }

       
        public override int PageCount
        {
            get { return pageCount; }
        }

        
        public override Size PageSize
        {

            get
            {
                return pageSize;
            }
            set
            {
                if (pageSize.Equals(value) != true)
                {
                    pageSize = value;
                    PaginateUserControlWorkouts();
                }
            }

        }

        public override IDocumentPaginatorSource Source
        {
            get { return null; }
        }
        #endregion




    }
}
