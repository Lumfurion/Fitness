using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Fitness.Wpf.Printing_Help
{
    public class ControlToImage
    {
        /// <summary>
        /// Gets an image "screenshot" of the specified UIElement
        /// </summary>
        /// <param name="source">UIElement to screenshot</param>
        /// <param name="scale" value="1">Scale to render the screenshot</param>
        /// <returns>Byte array of BMP data</returns>
        private static byte[] GetUIElementSnapshot(UIElement source, double scale = 1)
        {
            double actualHeight = source.RenderSize.Height;
            double actualWidth = source.RenderSize.Width;

            double renderHeight = actualHeight * scale;
            double renderWidth = actualWidth * scale;

            RenderTargetBitmap renderTarget = new RenderTargetBitmap((int)renderWidth, (int)renderHeight, 96, 96, PixelFormats.Pbgra32);
            VisualBrush sourceBrush = new VisualBrush(source);

            DrawingVisual drawingVisual = new DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();

            using (drawingContext)
            {
                drawingContext.PushTransform(new ScaleTransform(scale, scale));
                drawingContext.DrawRectangle(sourceBrush, null, new Rect(new System.Windows.Point(0, 0), new System.Windows.Point(actualWidth, actualHeight)));
            }
            renderTarget.Render(drawingVisual);

            Byte[] _imageArray = null;

            BmpBitmapEncoder bmpEncoder = new BmpBitmapEncoder();
            bmpEncoder.Frames.Add(BitmapFrame.Create(renderTarget));

            using (MemoryStream outputStream = new MemoryStream())
            {
                bmpEncoder.Save(outputStream);
                _imageArray = outputStream.ToArray();
            }

            return _imageArray;
        }

        public static BitmapImage CopyControlToImageSource(UIElement UserControl)
        {
            ImageConverter ic = new ImageConverter();
            Image img = (Image)ic.ConvertFrom(GetUIElementSnapshot(UserControl));
            MemoryStream ms = new MemoryStream();
            img.Save(ms, ImageFormat.Bmp);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();
            return image;
        }
    }
}
