using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageCollage
{
    public partial class Result : Form
    {
        private Collage collageForm;
        private ImgRectangle[] imgRectArray;

        public Result()
        {
            InitializeComponent();
        }

        public Result(Collage collageForm)
        {
            InitializeComponent();

            this.collageForm = collageForm;
            this.imgRectArray = collageForm.rects;
            this.Width = this.collageForm.frame.Width + 30;
            this.Height = this.collageForm.frame.Height + 30;
            DisplayResults(this.collageForm.frame.Width, this.collageForm.frame.Height);
        }        


        // Display the results.
        internal void DisplayResults(int frameWidth, int frameHeight)
        {
            picResult.Width = frameWidth + 20;
            picResult.Height = (int)((frameHeight + 20));

            Bitmap bm = new Bitmap(picResult.Width, picResult.Height);
            Graphics gr = Graphics.FromImage(bm);
            gr.Clear(picResult.BackColor);

            int temp = 0;

            for (int i = 0; i < imgRectArray.Length; i++)
            {
                Image image = Image.FromFile(imgRectArray[i].ImagePath);
                Rectangle rect = imgRectArray[i].Rect;
                gr.DrawImage(image, rect);
                temp++;
            }

            picResult.Image = bm;

            



            #region Display in form of rectangle
            //// Display the results graphically.
            //const int SCALE = 1;
            //picResult.Width = bin_wid * SCALE + 20;
            //picResult.Height = (int)((max_y + 1.5) * SCALE);
            //Bitmap bm = new Bitmap(picResult.Width, picResult.Height);
            //Graphics gr = Graphics.FromImage(bm);
            //gr.Clear(picResult.BackColor);
            //gr.ScaleTransform(SCALE, SCALE);

            ////this.ClientSize = new Size(
            ////    picResult.Right + 8,
            ////    Math.Max(picResult.Bottom + 8, btnExhaustive.Bottom + 8));

            //// Draw a unit grid.
            //float hgt = picResult.Height / SCALE;
            //Pen white_pen = new Pen(Color.White, 0);
            //for (int i = 1; i <= bin_wid; i++)
            //{
            //    gr.DrawLine(white_pen, i, 0, i, hgt);
            //}
            //for (int i = 1; i <= hgt; i++)
            //{
            //    gr.DrawLine(white_pen, 0, i, bin_wid, i);
            //}
            //white_pen.Dispose();

            //// Draw the boxes.
            //Pen the_pen = new Pen(Color.Blue, 0);
            //for (int i = 0; i <= rects.Length - 1; i++)
            //{
            //    gr.DrawRectangle(the_pen, rects[i]);
            //    gr.DrawLine(the_pen, rects[i].Left, rects[i].Top, rects[i].Right, rects[i].Bottom);
            //    gr.DrawLine(the_pen, rects[i].Right, rects[i].Top, rects[i].Left, rects[i].Bottom);
            //}

            //// Draw center line and max Y.
            //the_pen = new Pen(Color.Gray, 0);
            //gr.DrawLine(the_pen,
            //    (float)(bin_wid / 2), 0,
            //    (float)(bin_wid / 2), max_y);
            //the_pen = new Pen(Color.Red, 0);
            //gr.DrawLine(the_pen, 0, max_y, bin_wid, max_y);

            //// Draw some text.
            //gr.ResetTransform();
            //gr.DrawString(max_y.ToString(), this.Font,
            //    Brushes.Red, 0, max_y * SCALE);
            //for (int i = 0; i <= rects.Length - 1; i++)
            //{
            //    gr.DrawString(
            //        rects[i].Width + "x" + rects[i].Height,
            //        this.Font, Brushes.Blue,
            //        SCALE * rects[i].Left, SCALE * rects[i].Top);
            //}

            //picResult.Image = bm;
            //the_pen.Dispose();
            //gr.Dispose();
            #endregion

        }

        void Result_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            collageForm.menuForm.Enabled = true;
            Application.OpenForms["MainMenu"].BringToFront();
        }
    }
}
