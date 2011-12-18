using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ImageCollage
{
    public partial class Collage : Form
    {
        //private double[] ratioArray;
        public Rectangle frame;
        public ImgRectangle[] rects;
        public MainMenu menuForm;

        


        public Collage()
        {
            InitializeComponent();
        }

        public Collage(MainMenu menuForm)
        {
            InitializeComponent();
            this.menuForm = menuForm;
            //this.ratioArray = menuForm.ratioArray;
            this.rects = menuForm.imgRectList.ToArray();
            this.frame = menuForm.frame;

            this.bgWorkerCollage.RunWorkerAsync();
        }

        private void PrepareImage(ImgRectangle[] rects, Rectangle frame)
        {
            double areaForeachRec = (double)((frame.Height * frame.Width) / rects.Length);
            for (int i = 0; i < rects.Length; i++)
            {
                int width = (int)(Math.Sqrt((double)(areaForeachRec * rects[i].Ratio)));
                int height = (int)(width / rects[i].Ratio);
                rects[i].Rect = new Rectangle(0, 0, width, height);
            }
        }

        void Result_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            
            //this.menuForm.Enabled = true;
        }

        void bgWorkerCollage_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            double goodFillArea = this.menuForm.requiredFillRatio;
            double goodRatio = this.menuForm.requiredOrientRatio;
            
            //this.bgWorkerCollage.ReportProgress(20);
            double ratio = (double)frame.Width / (double)frame.Height;
            double testRatio, tempRatio;
            int bestWidth = this.frame.Width, max_x, max_y, testWidth;
            Boolean isSatisfied = false;


            for (int i = 0; i < 1; i++)
            {
                
                testWidth = (int)((double)this.frame.Width * (1 - 0.02 * i));                
                for (int j = 0; j < 100; j++)
                {
                    this.bgWorkerCollage.ReportProgress(j);
                    if (this.bgWorkerCollage.CancellationPending)
                    {
                        break;
                    }
                    int tempWidth = (int)((double)frame.Width * (1 - 0.01 * j));
                    int tempHeight = (int)((double)tempWidth / ratio);
                    Rectangle tempRect = new Rectangle(0, 0, tempWidth, tempHeight);
                    PrepareImage(rects, tempRect);
                    AlgFillByStripes(testWidth, rects);

                    // Get the largest X value used.
                    max_x = 0;
                    for (int z = 0; z <= rects.Length - 1; z++)
                    {
                        if (max_x < rects[z].Right) max_x = rects[z].Right;
                    }

                    // Get the largest Y value used.
                    max_y = 0;
                    for (int z = 0; z <= rects.Length - 1; z++)
                    {
                        if (max_y < rects[z].Bottom) max_y = rects[z].Bottom;
                    }

                    testRatio = (double)max_x / (double)max_y;
                    
                    tempRatio = ratio / testRatio;

                    if (tempRatio > 1) continue;
                    if (tempRatio < goodRatio) break;
                   
                    int filledArea = 0;

                    //Find area
                    for (int z = 0; z < rects.Length; z++)
                    {
                        filledArea += rects[z].Area;
                    }

                    int boundArea = (int)((double)max_x * (double)max_x / ratio);
                    double tempFillRatio = (double)filledArea / (double)boundArea;
                    if (tempFillRatio >= goodFillArea)
                    {
                        isSatisfied = true;
                        break;
                    }                    

                }

                if (this.bgWorkerCollage.CancellationPending)
                {
                    break;
                }

                if (isSatisfied) break;
            }

            
                        

            if (!isSatisfied)
            {
                MessageBox.Show("Can't find any satified combination");
                e.Result = false;
            }
            else
            {
                max_x = 0;
                for (int i = 0; i <= rects.Length - 1; i++)
                {
                    if (max_x < rects[i].Right) max_x = rects[i].Right;
                }

                //Resize rectangles to fit with outside frame
                double zoomRatio = (double)this.frame.Width / (double)max_x;
                int fillArea = 0;
                for (int i = 0; i < rects.Length; i++)
                {
                    rects[i].Width = (int)((double)rects[i].Width * zoomRatio);
                    rects[i].Height = (int)((double)rects[i].Width / rects[i].Ratio); 
                    rects[i].X = (int)((double)rects[i].X * zoomRatio);
                    rects[i].Y = (int)((double)rects[i].Y * zoomRatio);
                    //fillArea += rects[i].Area;
                }

                e.Result = true;


                /*
                #region Fill in blank space
                //Fill in blank space
                for (int i = 0; i < rects.Length; i++)
                {
                    int topMin = rects[i].Top;
                    int bottomMin = frame.Height - rects[i].Bottom;
                    int leftMin = rects[i].Left;
                    int rightMin = frame.Width - rects[i].Right;
                    for (int j = 0; j < rects.Length; j++)
                    {                    
                        if (j == i) continue;
                        int topDistance = rects[i].Top - rects[j].Bottom;
                        if (topDistance >= 0 && topDistance < topMin) topMin = topDistance;
                        int bottomDistance = rects[j].Top - rects[i].Bottom;
                        if (bottomDistance >= 0 && bottomDistance < bottomMin) bottomMin = bottomDistance;
                        int leftDistance = rects[i].Left - rects[j].Right;
                        if (leftDistance >= 0 && leftDistance < leftMin) leftMin = leftDistance;
                        int rightDistance = rects[j].Left - rects[i].Right;
                        if (rightDistance >= 0 && rightDistance < rightMin) rightMin = rightDistance;
                    }
                    int minDistance = Math.Min(topMin, Math.Min(bottomMin, Math.Min(rightMin, leftMin)));

                    rects[i].X -= minDistance;
                    rects[i].Y -= minDistance;
                    rects[i].Width += 2*minDistance;
                    rects[i].Height += 2*minDistance;
                    fillArea += rects[i].Width * rects[i].Height;
                }

                fillRatio = (double)fillArea / (double)frameArea;
                #endregion 
                */
            }
            this.bgWorkerCollage.ReportProgress(100);
                        
        }


        void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.bgWorkerCollage.CancelAsync();
        }

        

        void bgWorkerCollage_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            pgBarCollage.Value = e.ProgressPercentage;
        }

        void bgWorkerCollage_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if ((Boolean)e.Result)
            {
                Result resultForm = new Result(this);
                this.Close();
                resultForm.Show();
            }
            else
            {
                this.menuForm.Enabled = true;
                this.Close();
            }
        }

    }
}
