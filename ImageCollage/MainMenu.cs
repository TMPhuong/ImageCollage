using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security;
using System.IO;

namespace ImageCollage
{
    public partial class MainMenu : Form
    {
        
        public Rectangle frame;
        public List<Image> imageList = new List<Image>();
        public List<String> imagePathList = new List<String>();
        public List<ImgRectangle> imgRectList = new List<ImgRectangle>();
        public double[] ratioArray;
        public Boolean portrait = false;
        public double requiredFillRatio;
        public double requiredOrientRatio;


        public MainMenu()
        {
            InitializeComponent();
            this.rBtnLandscape.Checked = true;
        }


        void browseBtn_Click(object sender, System.EventArgs e)
        {
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                StringBuilder temp = new StringBuilder();
                //int i = 1;
                int tmp = 1;

                //Read files and check image errors
                foreach (String file in openFileDialog1.FileNames)
                {                                    
                    try
                    {
                        Image loadedImage = Image.FromFile(file);
                        int width = loadedImage.Width;
                        int height = loadedImage.Height;                        
                        ImgRectangle imgRect = new ImgRectangle(0, 0, width, height, file);
                        imgRectList.Add(imgRect);
                        //imageList.Add(loadedImage);
                        //imagePathList.Add(file);
                        //ratioList.Add(((double)pb.Width / (double)pb.Height));
                        //flowLayoutPanel1.Controls.Add(pb);

                        //Display image's details
                        temp.Append(String.Format("Image {0}: {1}", tmp++, file));
                        temp.AppendLine();

                        //temp = new StringBuilder();                        
                    }
                    catch (SecurityException ex)
                    {
                        // The user lacks appropriate permissions to read files, discover paths, etc.
                        MessageBox.Show("Security error. Please contact your administrator for details.\n\n" +
                            "Error message: " + ex.Message + "\n\n" +
                            "Details (send to Support):\n\n" + ex.StackTrace
                        );
                    }
                    catch (Exception ex)
                    {
                        // Could not load the image - probably related to Windows file system permissions.
                        MessageBox.Show("Cannot display the image: " + file.Substring(file.LastIndexOf('\\'))
                            + ". You may not have permission to read the file, or " +
                            "it may be corrupt.\n\nReported error: " + ex.Message);
                    }
                }
                
                imageTxtBox.Text = temp.ToString();
                Image[] imagesArray = imageList.ToArray();
                ratioArray = new double[imagesArray.Length];
                for (int i = 0; i < imagesArray.Length; i++)
                {
                    ratioArray[i] = (double)imagesArray[i].Width / (double)imagesArray[i].Height;
                }
                imageList = imagesArray.ToList();
            }
        }

        void MainMenu_Load(object sender, System.EventArgs e)
        {
            // Set the file dialog to filter for graphics files.
            this.openFileDialog1.Filter =
                "Images (*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|" +
                "All files (*.*)|*.*";

            // Allow the user to select multiple images.
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "My Image Browser";
        }

        void collageBtn_Click(object sender, System.EventArgs e)
        {
            this.requiredFillRatio = (double)fillRatio.Value / 100; 
            this.requiredOrientRatio = (double)orientRatio.Value / 100;
            Collage resultForm = new Collage(this);
            this.Enabled = false;
            resultForm.Show();
        }

        void rBtnPortrait_CheckedChanged(object sender, System.EventArgs e)
        {
            this.frame = new Rectangle(0, 0, 500, 700);
        }

        void rBtnLandscape_CheckedChanged(object sender, System.EventArgs e)
        {
            this.frame = new Rectangle(0, 0, 700, 500);
        }

    }
}
