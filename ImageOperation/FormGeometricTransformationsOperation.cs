using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageOperation
{
    public partial class FormGeometricTransformationsOperation : Form
    {
        public FormGeometricTransformationsOperation()
        {
            InitializeComponent();
        }

        public static bool IsNullOrEmpty(PictureBox pb)
        {
            return pb == null || pb.Image == null;
        }

        public static string valueInput(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 250,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 25, Text = text };
            TextBox textBox = new TextBox() { Left = 100, Top = 20, Width = 50 };
            Button confirmation = new Button() { Text = "Ok", Left = 100, Width = 50, Top = 75, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.png; *.bmp) | *.jpg; *.png; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                Bitmap image = new Bitmap(open.FileName);
                pictureBoxOriginal.Image = new Bitmap(image, new Size(300, 300));
            }

            if (IsNullOrEmpty(pictureBoxResult) == false)
            {
                pictureBoxResult.Image = null;
                labelTime.Text = "0 seconds";
            }
        }

 

        private void pointAndAreaBasedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormPointAndAreaBasedOperation f = new FormPointAndAreaBasedOperation();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void frameBasedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormFrameBasedOperation f = new FormFrameBasedOperation();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private static Bitmap translation(Image image, float x, float y)
        {
            Bitmap translatedBmp = new Bitmap(image.Width, image.Height);
            translatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            
            Graphics g = Graphics.FromImage(translatedBmp);
            g.TranslateTransform(x, y);
            g.DrawImage(image, new PointF(0, 0));
            
            return translatedBmp;
        }

        private static Bitmap rotation(Image image, PointF offset, float angle)
        {
            Bitmap rotatedBmp = new Bitmap(image.Width, image.Height);
            rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            
            Graphics g = Graphics.FromImage(rotatedBmp);
            g.TranslateTransform(offset.X, offset.Y);
            g.RotateTransform(angle);
            g.TranslateTransform(-offset.X, -offset.Y);
            g.DrawImage(image, new PointF(0, 0));
            
            return rotatedBmp;
        }

        private static Bitmap scaling(Image image, float x, float y)
        {
            Bitmap scaledBmp = new Bitmap(image.Width, image.Height);
            scaledBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            Graphics g = Graphics.FromImage(scaledBmp);
            g.ScaleTransform(x, y);
            g.DrawImage(image, new PointF(0, 0));
            return scaledBmp;
        }

        private static Bitmap shearing(Image image, float x, float y)
        {
            Bitmap shearedBmp = new Bitmap(image.Width, image.Height);
            shearedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            
            Graphics g = Graphics.FromImage(shearedBmp);
            Matrix matrix = new Matrix();
            matrix.Shear(x, y);
            g.Transform = matrix;
            g.DrawImage(image,
            new PointF(0, 0));
            
            return shearedBmp;
        }

        private void buttonTranslation_Click(object sender, EventArgs e)
        {
            if (IsNullOrEmpty(pictureBoxOriginal))
            {
                MessageBox.Show("Please open an image file first!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            string tempX = valueInput("X Axis", "Value");
            string tempY = valueInput("Y Axis", "Value");

            if (tempX == "" || tempY =="")
            {
                return;
            }

            if (float.TryParse(tempX, out _) == false || float.TryParse(tempY, out _) == false)
            {
                MessageBox.Show("Please input valid integer values!",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            float x = float.Parse(tempX);
            float y = float.Parse(tempY);

            Stopwatch sw = Stopwatch.StartNew();

            pictureBoxResult.Image = (Bitmap)translation((Bitmap)pictureBoxOriginal.Image, x, y);
            
            sw.Stop();
            TimeSpan ts = TimeSpan.FromTicks(sw.ElapsedTicks);
            double secondsFromTs = ts.TotalSeconds;

            labelTime.Text = secondsFromTs.ToString() + " seconds";

        }

        private void buttonRotation_Click(object sender, EventArgs e)
        {
            if (IsNullOrEmpty(pictureBoxOriginal))
            {
                MessageBox.Show("Please open an image file first!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            string tempX = valueInput("Degrees", "Value");

            if (tempX == "")
            {
                return;
            }

            if (float.TryParse(tempX, out _) == false)
            {
                MessageBox.Show("Please input valid integer values!",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            float x = float.Parse(tempX);

            Bitmap bmpOriginal = (Bitmap)pictureBoxOriginal.Image;
            float centerX = bmpOriginal.Width / 2;
            float centerY = bmpOriginal.Height / 2;
            PointF center = new PointF(centerX, centerY);

            Stopwatch sw = Stopwatch.StartNew();

            pictureBoxResult.Image = (Bitmap)rotation((Bitmap)pictureBoxOriginal.Image, center, x);

            sw.Stop();
            TimeSpan ts = TimeSpan.FromTicks(sw.ElapsedTicks);
            double secondsFromTs = ts.TotalSeconds;

            labelTime.Text = secondsFromTs.ToString() + " seconds";
        }

        private void buttonScaling_Click(object sender, EventArgs e)
        {
            if (IsNullOrEmpty(pictureBoxOriginal))
            {
                MessageBox.Show("Please open an image file first!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            string tempX = valueInput("X Axis", "Value");
            string tempY = valueInput("Y Axis", "Value");

            if (tempX == "" || tempY == "")
            {
                return;
            }

            if (float.TryParse(tempX, out _) == false || float.TryParse(tempY, out _) == false)
            {
                MessageBox.Show("Please input valid integer values!",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            float x = float.Parse(tempX);
            float y = float.Parse(tempY);

            Stopwatch sw = Stopwatch.StartNew();

            pictureBoxResult.Image = (Bitmap)scaling((Bitmap)pictureBoxOriginal.Image, x, y);

            sw.Stop();
            TimeSpan ts = TimeSpan.FromTicks(sw.ElapsedTicks);
            double secondsFromTs = ts.TotalSeconds;

            labelTime.Text = secondsFromTs.ToString() + " seconds";
        }

        private void buttonShearing_Click(object sender, EventArgs e)
        {
            if (IsNullOrEmpty(pictureBoxOriginal))
            {
                MessageBox.Show("Please open an image file first!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            string tempX = valueInput("X Axis", "Value");
            string tempY = valueInput("Y Axis", "Value");

            if (tempX == "" || tempY == "")
            {
                return;
            }

            if (float.TryParse(tempX, out _) == false || float.TryParse(tempY, out _) == false)
            {
                MessageBox.Show("Please input valid integer values!",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            float x = float.Parse(tempX);
            float y = float.Parse(tempY);

            Stopwatch sw = Stopwatch.StartNew();

            pictureBoxResult.Image = (Bitmap)shearing((Bitmap)pictureBoxOriginal.Image, x, y);

            sw.Stop();
            TimeSpan ts = TimeSpan.FromTicks(sw.ElapsedTicks);
            double secondsFromTs = ts.TotalSeconds;

            labelTime.Text = secondsFromTs.ToString() + " seconds";
        }

        private void buttonReflectionX_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();

            pictureBoxResult.Image = pictureBoxOriginal.Image;
            pictureBoxResult.Image.RotateFlip(RotateFlipType.Rotate180FlipX);
            pictureBoxResult.Refresh();

            sw.Stop();
            TimeSpan ts = TimeSpan.FromTicks(sw.ElapsedTicks);
            double secondsFromTs = ts.TotalSeconds;

            labelTime.Text = secondsFromTs.ToString() + " seconds";
        }

        private void buttonReflectionY_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();

            pictureBoxResult.Image = pictureBoxOriginal.Image;
            pictureBoxResult.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
            pictureBoxResult.Refresh();

            sw.Stop();
            TimeSpan ts = TimeSpan.FromTicks(sw.ElapsedTicks);
            double secondsFromTs = ts.TotalSeconds;

            labelTime.Text = secondsFromTs.ToString() + " seconds";
        }

        private void saveResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsNullOrEmpty(pictureBoxResult))
            {
                MessageBox.Show("Please do an operation first!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Jpeg Image|*.jpg|Png Image|*.png|Bmp Image|*.bmp";
            save.Title = "Save an image file";
            save.ShowDialog();

            if (save.FileName != "")
            {
                System.IO.FileStream fs =
                    (System.IO.FileStream)save.OpenFile();

                switch (save.FilterIndex)
                {
                    case 1:
                        pictureBoxResult.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case 2:
                        pictureBoxResult.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
                        break;

                    case 3:
                        pictureBoxResult.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                }

                fs.Close();
            }
        }

        private void buttonMoveResultToOriginal_Click(object sender, EventArgs e)
        {
            if (IsNullOrEmpty(pictureBoxOriginal) || IsNullOrEmpty(pictureBoxResult))
            {
                MessageBox.Show("Please do an operation first!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            pictureBoxOriginal.Image = new Bitmap(pictureBoxResult.Image, 300, 300);
            pictureBoxResult.Image = null;
        }
    }
}
