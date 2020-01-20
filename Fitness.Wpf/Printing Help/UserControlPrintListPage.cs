using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Fitness.Wpf.Printing_Help
{
    public  class UserControlPrintListPage : UserControl
    {
        private readonly UserControlPrint[] userControlPrint;
        /// <summary>
        /// Размер страницы.
        /// </summary>
        private readonly Size pageSize;

        public UserControlPrintListPage(UserControlPrint[] userControlPrint, Size pageSize)
        {
            this.userControlPrint = userControlPrint;
            this.pageSize = pageSize;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            Point point = new Point(0,0);

            foreach (var item in userControlPrint)
            {
                point.X = 0;
                var ImageSource = ControlToImage.CopyControlToImageSource(item);
                //drawingContext.DrawImage(ImageSource, point);
                point.Y += ImageSource.Height;
            }
        }


    }
}
