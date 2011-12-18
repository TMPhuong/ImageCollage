using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace ImageCollage
{
    public struct ImgRectangle
    {
        private Rectangle rect;
        private string imagePath;

        public Rectangle Rect 
        {
            get { return rect; }
            set { rect = value; }
        }   

        public string ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; }
        }

        public int X
        {
            get { return rect.X; }
            set { rect.X = value; }
        }

        public int Y
        {
            get { return rect.Y; }
            set { rect.Y = value; }
        }

        public int Width
        {
            get { return rect.Width; }
            set { rect.Width = value; }
        }

        public int Height
        {
            get { return rect.Height; }
            set { rect.Height = value; }
        }

        public double Ratio
        {
            get
            {
                return (double)rect.Width / (double)rect.Height;
            }
        }

        public int Bottom { get { return rect.Bottom; } }
        public int Top { get { return rect.Top; } }
        public int Right { get { return rect.Right; } }
        public int Left { get { return rect.Left; } }
        public int Area { get { return rect.Width * rect.Height; } }
        



        public ImgRectangle(int x, int y, int width, int height, string imagePath)  
        {
            this.rect = new Rectangle(x, y, width, height);
            this.imagePath = imagePath;             
        }

        public Boolean IntersectsWith(Rectangle rect) 
        { 
            return this.rect.IntersectsWith(rect); 
        } 
    }
}
