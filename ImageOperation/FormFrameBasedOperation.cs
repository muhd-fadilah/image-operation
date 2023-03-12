using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageOperation
{
    public partial class FormFrameBasedOperation : Form
    {
        public FormFrameBasedOperation()
        {
            InitializeComponent();
        }

        public static bool IsNullOrEmpty(PictureBox pb)
        {
            return pb == null || pb.Image == null;
        }

        private void openFirstImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.png; *.bmp) | *.jpg; *.png; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                Bitmap image = new Bitmap(open.FileName);
                pictureBoxOriginal1.Image = new Bitmap(image, new Size(250, 250));
            }

            if (IsNullOrEmpty(pictureBoxResult) == false)
            {
                pictureBoxResult.Image = null;
                labelTime.Text = "0 seconds";
            }
        }

        private void openSecondImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.png; *.bmp) | *.jpg; *.png; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                Bitmap image = new Bitmap(open.FileName);
                pictureBoxOriginal2.Image = new Bitmap(image, new Size(250, 250));
            }

            if (IsNullOrEmpty(pictureBoxResult) == false)
            {
                pictureBoxResult.Image = null;
                labelTime.Text = "0 seconds";
            }
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
            Bitmap bmpResult = (Bitmap)pictureBoxResult.Image;

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

        public static string inputValue(string text, string caption)
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

        private void addPointer(Bitmap origin1, Bitmap origin2)
        {
            BitmapData bmpDataOrigin1 = origin1.LockBits(new Rectangle(0, 0, origin1.Width, origin1.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmpDataOrigin2 = origin2.LockBits(new Rectangle(0, 0, origin2.Width, origin2.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int width = bmpDataOrigin1.Width;
            int height = bmpDataOrigin1.Height;

            Bitmap result = new Bitmap(width, height);
            BitmapData bmpDataResult = result.LockBits(new Rectangle(0, 0, result.Width, result.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                int remain1 = bmpDataOrigin1.Stride - bmpDataOrigin1.Width * 3;
                int remain2 = bmpDataOrigin2.Stride - bmpDataOrigin2.Width * 3;
                int remain3 = bmpDataResult.Stride - bmpDataResult.Width * 3;

                byte* ptr1 = (byte*)bmpDataOrigin1.Scan0;
                byte* ptr2 = (byte*)bmpDataOrigin2.Scan0;
                byte* ptr3 = (byte*)bmpDataResult.Scan0;

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width * 3; j++)
                    {
                        ptr3[0] = (byte)Math.Min((ptr1[0] + ptr2[0]), 255);
                        ++ptr1;
                        ++ptr2;
                        ++ptr3;
                    }
                    ptr1 += remain1;
                    ptr2 += remain2;
                    ptr3 += remain3;
                }
            }

            origin1.UnlockBits(bmpDataOrigin1);
            origin2.UnlockBits(bmpDataOrigin2);
            result.UnlockBits(bmpDataResult);

            pictureBoxResult.Image = result;
        }

        private void addGDI(Bitmap origin1, Bitmap origin2)
        {
            int width = origin1.Width;
            int height = origin1.Height;
            int r, g, b;

            Bitmap result = new Bitmap(width, height);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    r = Math.Min(origin1.GetPixel(i, j).R + origin2.GetPixel(i, j).R, 255);
                    g = Math.Min(origin1.GetPixel(i, j).G + origin2.GetPixel(i, j).G, 255);
                    b = Math.Min(origin1.GetPixel(i, j).B + origin2.GetPixel(i, j).B, 255);
                    result.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }

            pictureBoxResult.Image = result;
        }

        private void substractPointer(Bitmap origin1, Bitmap origin2)
        {
            BitmapData bmpDataOrigin1 = origin1.LockBits(new Rectangle(0, 0, origin1.Width, origin1.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmpDataOrigin2 = origin2.LockBits(new Rectangle(0, 0, origin2.Width, origin2.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int width = bmpDataOrigin1.Width;
            int height = bmpDataOrigin1.Height;

            Bitmap result = new Bitmap(width, height);
            BitmapData bmpDataResult = result.LockBits(new Rectangle(0, 0, result.Width, result.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                int remain1 = bmpDataOrigin1.Stride - bmpDataOrigin1.Width * 3;
                int remain2 = bmpDataOrigin2.Stride - bmpDataOrigin2.Width * 3;
                int remain3 = bmpDataResult.Stride - bmpDataResult.Width * 3;

                byte* ptr1 = (byte*)bmpDataOrigin1.Scan0;
                byte* ptr2 = (byte*)bmpDataOrigin2.Scan0;
                byte* ptr3 = (byte*)bmpDataResult.Scan0;

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width * 3; j++)
                    {
                        ptr3[0] = (byte)Math.Max((ptr1[0] - ptr2[0]), 0);
                        ++ptr1;
                        ++ptr2;
                        ++ptr3;
                    }
                    ptr1 += remain1;
                    ptr2 += remain2;
                    ptr3 += remain3;
                }
            }

            origin1.UnlockBits(bmpDataOrigin1);
            origin2.UnlockBits(bmpDataOrigin2);
            result.UnlockBits(bmpDataResult);

            pictureBoxResult.Image = result;
        }

        private void substractGDI(Bitmap origin1, Bitmap origin2)
        {
            int width = origin1.Width;
            int height = origin1.Height;
            int r, g, b;

            Bitmap result = new Bitmap(width, height);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    r = Math.Max(origin1.GetPixel(i, j).R - origin2.GetPixel(i, j).R, 0);
                    g = Math.Max(origin1.GetPixel(i, j).G - origin2.GetPixel(i, j).G, 0);
                    b = Math.Max(origin1.GetPixel(i, j).B - origin2.GetPixel(i, j).B, 0);
                    result.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }

            pictureBoxResult.Image = result;
        }

        private void differencePointer(Bitmap origin1, Bitmap origin2)
        {
            BitmapData bmpDataOrigin1 = origin1.LockBits(new Rectangle(0, 0, origin1.Width, origin1.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmpDataOrigin2 = origin2.LockBits(new Rectangle(0, 0, origin2.Width, origin2.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int width = bmpDataOrigin1.Width;
            int height = bmpDataOrigin1.Height;

            Bitmap result = new Bitmap(width, height);
            BitmapData bmpDataResult = result.LockBits(new Rectangle(0, 0, result.Width, result.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                int remain1 = bmpDataOrigin1.Stride - bmpDataOrigin1.Width * 3;
                int remain2 = bmpDataOrigin2.Stride - bmpDataOrigin2.Width * 3;
                int remain3 = bmpDataResult.Stride - bmpDataResult.Width * 3;

                byte* ptr1 = (byte*)bmpDataOrigin1.Scan0;
                byte* ptr2 = (byte*)bmpDataOrigin2.Scan0;
                byte* ptr3 = (byte*)bmpDataResult.Scan0;

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width * 3; j++)
                    {
                        ptr3[0] = (byte)Math.Abs(ptr1[0] - ptr2[0]);
                        ++ptr1;
                        ++ptr2;
                        ++ptr3;
                    }
                    ptr1 += remain1;
                    ptr2 += remain2;
                    ptr3 += remain3;
                }
            }

            origin1.UnlockBits(bmpDataOrigin1);
            origin2.UnlockBits(bmpDataOrigin2);
            result.UnlockBits(bmpDataResult);

            pictureBoxResult.Image = result;
        }

        private void differenceGDI(Bitmap origin1, Bitmap origin2)
        {
            int width = origin1.Width;
            int height = origin1.Height;
            int r, g, b;

            Bitmap result = new Bitmap(width, height);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    r = Math.Abs(origin1.GetPixel(i, j).R - origin2.GetPixel(i, j).R);
                    g = Math.Abs(origin1.GetPixel(i, j).G - origin2.GetPixel(i, j).G);
                    b = Math.Abs(origin1.GetPixel(i, j).B - origin2.GetPixel(i, j).B);
                    result.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }

            pictureBoxResult.Image = result;
        }

        private void multiplyPointer(Bitmap origin1, Bitmap origin2)
        {
            BitmapData bmpDataOrigin1 = origin1.LockBits(new Rectangle(0, 0, origin1.Width, origin1.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmpDataOrigin2 = origin2.LockBits(new Rectangle(0, 0, origin2.Width, origin2.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int width = bmpDataOrigin1.Width;
            int height = bmpDataOrigin1.Height;

            Bitmap result = new Bitmap(width, height);
            BitmapData bmpDataResult = result.LockBits(new Rectangle(0, 0, result.Width, result.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                int remain1 = bmpDataOrigin1.Stride - bmpDataOrigin1.Width * 3;
                int remain2 = bmpDataOrigin2.Stride - bmpDataOrigin2.Width * 3;
                int remain3 = bmpDataResult.Stride - bmpDataResult.Width * 3;

                byte* ptr1 = (byte*)bmpDataOrigin1.Scan0;
                byte* ptr2 = (byte*)bmpDataOrigin2.Scan0;
                byte* ptr3 = (byte*)bmpDataResult.Scan0;

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width * 3; j++)
                    {
                        ptr3[0] = (byte)(int)(255 * (ptr1[0] / 255.0 * ptr2[0] / 255.0));
                        ++ptr1;
                        ++ptr2;
                        ++ptr3;
                    }
                    ptr1 += remain1;
                    ptr2 += remain2;
                    ptr3 += remain3;
                }
            }

            origin1.UnlockBits(bmpDataOrigin1);
            origin2.UnlockBits(bmpDataOrigin2);
            result.UnlockBits(bmpDataResult);

            pictureBoxResult.Image = result;
        }

        private void multiplyGDI(Bitmap origin1, Bitmap origin2)
        {
            int width = origin1.Width;
            int height = origin1.Height;
            int r, g, b;

            Bitmap result = new Bitmap(width, height);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    r = (int)(255 * (origin2.GetPixel(i, j).R / 255.0 * origin1.GetPixel(i, j).R / 255.0));
                    g = (int)(255 * (origin2.GetPixel(i, j).G / 255.0 * origin1.GetPixel(i, j).G / 255.0));
                    b = (int)(255 * (origin2.GetPixel(i, j).B / 255.0 * origin1.GetPixel(i, j).B / 255.0));
                    result.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }

            pictureBoxResult.Image = result;
        }

        private void averagePointer(Bitmap origin1, Bitmap origin2)
        {
            BitmapData bmpDataOrigin1 = origin1.LockBits(new Rectangle(0, 0, origin1.Width, origin1.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmpDataOrigin2 = origin2.LockBits(new Rectangle(0, 0, origin2.Width, origin2.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int width = bmpDataOrigin1.Width;
            int height = bmpDataOrigin1.Height;

            Bitmap result = new Bitmap(width, height);
            BitmapData bmpDataResult = result.LockBits(new Rectangle(0, 0, result.Width, result.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                int remain1 = bmpDataOrigin1.Stride - bmpDataOrigin1.Width * 3;
                int remain2 = bmpDataOrigin2.Stride - bmpDataOrigin2.Width * 3;
                int remain3 = bmpDataResult.Stride - bmpDataResult.Width * 3;

                byte* ptr1 = (byte*)bmpDataOrigin1.Scan0;
                byte* ptr2 = (byte*)bmpDataOrigin2.Scan0;
                byte* ptr3 = (byte*)bmpDataResult.Scan0;

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width * 3; j++)
                    {
                        ptr3[0] = (byte)((ptr1[0] + ptr2[0]) / 2);
                        ++ptr1;
                        ++ptr2;
                        ++ptr3;
                    }
                    ptr1 += remain1;
                    ptr2 += remain2;
                    ptr3 += remain3;
                }
            }

            origin1.UnlockBits(bmpDataOrigin1);
            origin2.UnlockBits(bmpDataOrigin2);
            result.UnlockBits(bmpDataResult);

            pictureBoxResult.Image = result;
        }

        private void averageGDI(Bitmap origin1, Bitmap origin2)
        {
            int width = origin1.Width;
            int height = origin1.Height;
            int r, g, b;

            Bitmap result = new Bitmap(width, height);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    r = (origin2.GetPixel(i, j).R + origin1.GetPixel(i, j).R) / 2;
                    g = (origin2.GetPixel(i, j).G + origin1.GetPixel(i, j).G) / 2;
                    b = (origin2.GetPixel(i, j).B + origin1.GetPixel(i, j).B) / 2;
                    result.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }

            pictureBoxResult.Image = result;
        }

        private void minPointer(Bitmap origin1, Bitmap origin2)
        {
            BitmapData bmpDataOrigin1 = origin1.LockBits(new Rectangle(0, 0, origin1.Width, origin1.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmpDataOrigin2 = origin2.LockBits(new Rectangle(0, 0, origin2.Width, origin2.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int width = bmpDataOrigin1.Width;
            int height = bmpDataOrigin1.Height;

            Bitmap result = new Bitmap(width, height);
            BitmapData bmpDataResult = result.LockBits(new Rectangle(0, 0, result.Width, result.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                int remain1 = bmpDataOrigin1.Stride - bmpDataOrigin1.Width * 3;
                int remain2 = bmpDataOrigin2.Stride - bmpDataOrigin2.Width * 3;
                int remain3 = bmpDataResult.Stride - bmpDataResult.Width * 3;

                byte* ptr1 = (byte*)bmpDataOrigin1.Scan0;
                byte* ptr2 = (byte*)bmpDataOrigin2.Scan0;
                byte* ptr3 = (byte*)bmpDataResult.Scan0;

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width * 3; j++)
                    {
                        ptr3[0] = (byte)Math.Min(ptr1[0], ptr2[0]);
                        ++ptr1;
                        ++ptr2;
                        ++ptr3;
                    }
                    ptr1 += remain1;
                    ptr2 += remain2;
                    ptr3 += remain3;
                }
            }

            origin1.UnlockBits(bmpDataOrigin1);
            origin2.UnlockBits(bmpDataOrigin2);
            result.UnlockBits(bmpDataResult);

            pictureBoxResult.Image = result;
        }

        private void minGDI(Bitmap origin1, Bitmap origin2)
        {
            int width = origin1.Width;
            int height = origin1.Height;
            int r, g, b;

            Bitmap result = new Bitmap(width, height);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    r = Math.Min(origin2.GetPixel(i, j).R, origin1.GetPixel(i, j).R);
                    g = Math.Min(origin2.GetPixel(i, j).G, origin1.GetPixel(i, j).G);
                    b = Math.Min(origin2.GetPixel(i, j).B, origin1.GetPixel(i, j).B);
                    result.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }

            pictureBoxResult.Image = result;
        }

        private void maxPointer(Bitmap origin1, Bitmap origin2)
        {
            BitmapData bmpDataOrigin1 = origin1.LockBits(new Rectangle(0, 0, origin1.Width, origin1.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmpDataOrigin2 = origin2.LockBits(new Rectangle(0, 0, origin2.Width, origin2.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int width = bmpDataOrigin1.Width;
            int height = bmpDataOrigin1.Height;

            Bitmap result = new Bitmap(width, height);
            BitmapData bmpDataResult = result.LockBits(new Rectangle(0, 0, result.Width, result.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                int remain1 = bmpDataOrigin1.Stride - bmpDataOrigin1.Width * 3;
                int remain2 = bmpDataOrigin2.Stride - bmpDataOrigin2.Width * 3;
                int remain3 = bmpDataResult.Stride - bmpDataResult.Width * 3;

                byte* ptr1 = (byte*)bmpDataOrigin1.Scan0;
                byte* ptr2 = (byte*)bmpDataOrigin2.Scan0;
                byte* ptr3 = (byte*)bmpDataResult.Scan0;

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width * 3; j++)
                    {
                        ptr3[0] = (byte)Math.Max(ptr1[0], ptr2[0]);
                        ++ptr1;
                        ++ptr2;
                        ++ptr3;
                    }
                    ptr1 += remain1;
                    ptr2 += remain2;
                    ptr3 += remain3;
                }
            }

            origin1.UnlockBits(bmpDataOrigin1);
            origin2.UnlockBits(bmpDataOrigin2);
            result.UnlockBits(bmpDataResult);

            pictureBoxResult.Image = result;
        }

        private void maxGDI(Bitmap origin1, Bitmap origin2)
        {
            int width = origin1.Width;
            int height = origin1.Height;
            int r, g, b;

            Bitmap result = new Bitmap(width, height);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    r = Math.Max(origin2.GetPixel(i, j).R, origin1.GetPixel(i, j).R);
                    g = Math.Max(origin2.GetPixel(i, j).G, origin1.GetPixel(i, j).G);
                    b = Math.Max(origin2.GetPixel(i, j).B, origin1.GetPixel(i, j).B);
                    result.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }

            pictureBoxResult.Image = result;
        }

        private void crossfadingPointer(Bitmap origin1, Bitmap origin2)
        {
            string temp = inputValue("Value", "Weight Value");
            if (float.TryParse(temp, out _) == false)
            {
                MessageBox.Show("Please input a valid value!",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            float weight = float.Parse(temp);

            if (weight > 1)
            {
                MessageBox.Show("Value can't be more than 1!",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            Stopwatch sw = Stopwatch.StartNew();

            BitmapData bmpDataOrigin1 = origin1.LockBits(new Rectangle(0, 0, origin1.Width, origin1.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmpDataOrigin2 = origin2.LockBits(new Rectangle(0, 0, origin2.Width, origin2.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int width = bmpDataOrigin1.Width;
            int height = bmpDataOrigin1.Height;

            Bitmap result = new Bitmap(width, height);
            BitmapData bmpDataResult = result.LockBits(new Rectangle(0, 0, result.Width, result.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                int remain1 = bmpDataOrigin1.Stride - bmpDataOrigin1.Width * 3;
                int remain2 = bmpDataOrigin2.Stride - bmpDataOrigin2.Width * 3;
                int remain3 = bmpDataResult.Stride - bmpDataResult.Width * 3;

                byte* ptr1 = (byte*)bmpDataOrigin1.Scan0;
                byte* ptr2 = (byte*)bmpDataOrigin2.Scan0;
                byte* ptr3 = (byte*)bmpDataResult.Scan0;

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width * 3; j++)
                    {
                        ptr3[0] = (byte)(int)(ptr1[0] * weight + ptr2[0] * (1 - weight));
                        ++ptr1;
                        ++ptr2;
                        ++ptr3;
                    }
                    ptr1 += remain1;
                    ptr2 += remain2;
                    ptr3 += remain3;
                }
            }

            origin1.UnlockBits(bmpDataOrigin1);
            origin2.UnlockBits(bmpDataOrigin2);
            result.UnlockBits(bmpDataResult);

            sw.Stop();
            TimeSpan ts = TimeSpan.FromTicks(sw.ElapsedTicks);
            double secondsFromTs = ts.TotalSeconds;

            labelTime.Text = secondsFromTs.ToString() + " seconds";

            pictureBoxResult.Image = result;
        }

        private void crossfadingGDI(Bitmap origin1, Bitmap origin2)
        {
            string temp = inputValue("Value", "Weight Value");
            if (float.TryParse(temp, out _) == false)
            {
                MessageBox.Show("Please input a valid value!",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            float weight = float.Parse(temp);

            if (weight > 1)
            {
                MessageBox.Show("Value can't be more than 1!",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            Stopwatch sw = Stopwatch.StartNew();

            int width = origin1.Width;
            int height = origin1.Height;
            int r, g, b;

            Bitmap result = new Bitmap(width, height);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    r = (int)(origin1.GetPixel(i, j).R * weight + origin2.GetPixel(i, j).R * (1 - weight));
                    g = (int)(origin1.GetPixel(i, j).G * weight + origin2.GetPixel(i, j).G * (1 - weight));
                    b = (int)(origin1.GetPixel(i, j).B * weight + origin2.GetPixel(i, j).B * (1 - weight));
                    result.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }

            sw.Stop();
            TimeSpan ts = TimeSpan.FromTicks(sw.ElapsedTicks);
            double secondsFromTs = ts.TotalSeconds;

            labelTime.Text = secondsFromTs.ToString() + " seconds";

            pictureBoxResult.Image = result;
        }

        private void amplitudePointer(Bitmap origin1, Bitmap origin2)
        {
            BitmapData bmpDataOrigin1 = origin1.LockBits(new Rectangle(0, 0, origin1.Width, origin1.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmpDataOrigin2 = origin2.LockBits(new Rectangle(0, 0, origin2.Width, origin2.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int width = bmpDataOrigin1.Width;
            int height = bmpDataOrigin1.Height;

            Bitmap result = new Bitmap(width, height);
            BitmapData bmpDataResult = result.LockBits(new Rectangle(0, 0, result.Width, result.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                int remain1 = bmpDataOrigin1.Stride - bmpDataOrigin1.Width * 3;
                int remain2 = bmpDataOrigin2.Stride - bmpDataOrigin2.Width * 3;
                int remain3 = bmpDataResult.Stride - bmpDataResult.Width * 3;

                byte* ptr1 = (byte*)bmpDataOrigin1.Scan0;
                byte* ptr2 = (byte*)bmpDataOrigin2.Scan0;
                byte* ptr3 = (byte*)bmpDataResult.Scan0;

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width * 3; j++)
                    {
                        ptr3[0] = (byte)(int)(Math.Sqrt((double)(ptr1[0] * ptr1[0] + ptr2[0] * ptr2[0])) / Math.Sqrt(2.0));
                        ++ptr1;
                        ++ptr2;
                        ++ptr3;
                    }
                    ptr1 += remain1;
                    ptr2 += remain2;
                    ptr3 += remain3;
                }
            }

            origin1.UnlockBits(bmpDataOrigin1);
            origin2.UnlockBits(bmpDataOrigin2);
            result.UnlockBits(bmpDataResult);

            pictureBoxResult.Image = result;
        }

        private void amplitudeGDI(Bitmap origin1, Bitmap origin2)
        {
            int width = origin1.Width;
            int height = origin1.Height;
            int r, g, b;

            Bitmap result = new Bitmap(width, height);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    r = (int)(Math.Sqrt((Double)(origin1.GetPixel(i, j).R * origin1.GetPixel(i, j).R + origin2.GetPixel(i, j).R * origin2.GetPixel(i, j).R)) / Math.Sqrt(2));
                    g = (int)(Math.Sqrt((Double)(origin1.GetPixel(i, j).G * origin1.GetPixel(i, j).G + origin2.GetPixel(i, j).G * origin2.GetPixel(i, j).G)) / Math.Sqrt(2));
                    b = (int)(Math.Sqrt((Double)(origin1.GetPixel(i, j).B * origin1.GetPixel(i, j).B + origin2.GetPixel(i, j).B * origin2.GetPixel(i, j).B)) / Math.Sqrt(2));
                    result.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }

            pictureBoxResult.Image = result;
        }

        private void andPointer(Bitmap origin1, Bitmap origin2)
        {
            BitmapData bmpDataOrigin1 = origin1.LockBits(new Rectangle(0, 0, origin1.Width, origin1.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmpDataOrigin2 = origin2.LockBits(new Rectangle(0, 0, origin2.Width, origin2.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int width = bmpDataOrigin1.Width;
            int height = bmpDataOrigin1.Height;

            Bitmap result = new Bitmap(width, height);
            BitmapData bmpDataResult = result.LockBits(new Rectangle(0, 0, result.Width, result.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                int remain1 = bmpDataOrigin1.Stride - bmpDataOrigin1.Width * 3;
                int remain2 = bmpDataOrigin2.Stride - bmpDataOrigin2.Width * 3;
                int remain3 = bmpDataResult.Stride - bmpDataResult.Width * 3;

                byte* ptr1 = (byte*)bmpDataOrigin1.Scan0;
                byte* ptr2 = (byte*)bmpDataOrigin2.Scan0;
                byte* ptr3 = (byte*)bmpDataResult.Scan0;

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width * 3; j++)
                    {
                        ptr3[0] = (byte)(ptr1[0] & ptr2[0]);
                        ++ptr1;
                        ++ptr2;
                        ++ptr3;
                    }
                    ptr1 += remain1;
                    ptr2 += remain2;
                    ptr3 += remain3;
                }
            }

            origin1.UnlockBits(bmpDataOrigin1);
            origin2.UnlockBits(bmpDataOrigin2);
            result.UnlockBits(bmpDataResult);

            pictureBoxResult.Image = result;
        }

        private void andGDI(Bitmap origin1, Bitmap origin2)
        {
            int width = origin1.Width;
            int height = origin1.Height;
            int r, g, b;

            Bitmap result = new Bitmap(width, height);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    r = (origin1.GetPixel(i, j).R & origin2.GetPixel(i, j).R);
                    g = (origin1.GetPixel(i, j).G & origin2.GetPixel(i, j).G);
                    b = (origin1.GetPixel(i, j).B & origin2.GetPixel(i, j).B);
                    result.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }

            pictureBoxResult.Image = result;
        }

        private void orPointer(Bitmap origin1, Bitmap origin2)
        {
            BitmapData bmpDataOrigin1 = origin1.LockBits(new Rectangle(0, 0, origin1.Width, origin1.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmpDataOrigin2 = origin2.LockBits(new Rectangle(0, 0, origin2.Width, origin2.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int width = bmpDataOrigin1.Width;
            int height = bmpDataOrigin1.Height;

            Bitmap result = new Bitmap(width, height);
            BitmapData bmpDataResult = result.LockBits(new Rectangle(0, 0, result.Width, result.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                int remain1 = bmpDataOrigin1.Stride - bmpDataOrigin1.Width * 3;
                int remain2 = bmpDataOrigin2.Stride - bmpDataOrigin2.Width * 3;
                int remain3 = bmpDataResult.Stride - bmpDataResult.Width * 3;

                byte* ptr1 = (byte*)bmpDataOrigin1.Scan0;
                byte* ptr2 = (byte*)bmpDataOrigin2.Scan0;
                byte* ptr3 = (byte*)bmpDataResult.Scan0;

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width * 3; j++)
                    {
                        ptr3[0] = (byte)(ptr1[0] | ptr2[0]);
                        ++ptr1;
                        ++ptr2;
                        ++ptr3;
                    }
                    ptr1 += remain1;
                    ptr2 += remain2;
                    ptr3 += remain3;
                }
            }

            origin1.UnlockBits(bmpDataOrigin1);
            origin2.UnlockBits(bmpDataOrigin2);
            result.UnlockBits(bmpDataResult);

            pictureBoxResult.Image = result;
        }

        private void orGDI(Bitmap origin1, Bitmap origin2)
        {
            int width = origin1.Width;
            int height = origin1.Height;
            int r, g, b;

            Bitmap result = new Bitmap(width, height);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    r = (origin1.GetPixel(i, j).R | origin2.GetPixel(i, j).R);
                    g = (origin1.GetPixel(i, j).G | origin2.GetPixel(i, j).G);
                    b = (origin1.GetPixel(i, j).B | origin2.GetPixel(i, j).B);
                    result.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }

            pictureBoxResult.Image = result;
        }

        private void xorPointer(Bitmap origin1, Bitmap origin2)
        {
            BitmapData bmpDataOrigin1 = origin1.LockBits(new Rectangle(0, 0, origin1.Width, origin1.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmpDataOrigin2 = origin2.LockBits(new Rectangle(0, 0, origin2.Width, origin2.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int width = bmpDataOrigin1.Width;
            int height = bmpDataOrigin1.Height;

            Bitmap result = new Bitmap(width, height);
            BitmapData bmpDataResult = result.LockBits(new Rectangle(0, 0, result.Width, result.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                int remain1 = bmpDataOrigin1.Stride - bmpDataOrigin1.Width * 3;
                int remain2 = bmpDataOrigin2.Stride - bmpDataOrigin2.Width * 3;
                int remain3 = bmpDataResult.Stride - bmpDataResult.Width * 3;

                byte* ptr1 = (byte*)bmpDataOrigin1.Scan0;
                byte* ptr2 = (byte*)bmpDataOrigin2.Scan0;
                byte* ptr3 = (byte*)bmpDataResult.Scan0;

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width * 3; j++)
                    {
                        ptr3[0] = (byte)(ptr1[0] ^ ptr2[0]);
                        ++ptr1;
                        ++ptr2;
                        ++ptr3;
                    }
                    ptr1 += remain1;
                    ptr2 += remain2;
                    ptr3 += remain3;
                }
            }

            origin1.UnlockBits(bmpDataOrigin1);
            origin2.UnlockBits(bmpDataOrigin2);
            result.UnlockBits(bmpDataResult);

            pictureBoxResult.Image = result;
        }

        private void xorGDI(Bitmap origin1, Bitmap origin2)
        {
            int width = origin1.Width;
            int height = origin1.Height;
            int r, g, b;

            Bitmap result = new Bitmap(width, height);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    r = (origin1.GetPixel(i, j).R ^ origin2.GetPixel(i, j).R);
                    g = (origin1.GetPixel(i, j).G ^ origin2.GetPixel(i, j).G);
                    b = (origin1.GetPixel(i, j).B ^ origin2.GetPixel(i, j).B);
                    result.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }

            pictureBoxResult.Image = result;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (IsNullOrEmpty(pictureBoxOriginal1) || IsNullOrEmpty(pictureBoxOriginal2))
            {
                MessageBox.Show("Please open image files first!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            Bitmap origin1 = new Bitmap(pictureBoxOriginal1.Image);
            Bitmap origin2 = new Bitmap(pictureBoxOriginal2.Image);

            Stopwatch sw = Stopwatch.StartNew();

            if (comboBoxMode.SelectedIndex == 0)
                addPointer(origin1, origin2);
            else if (comboBoxMode.SelectedIndex == 1)
                addGDI(origin1, origin2);
            
            sw.Stop();
            TimeSpan ts = TimeSpan.FromTicks(sw.ElapsedTicks);
            double secondsFromTs = ts.TotalSeconds;

            labelTime.Text = secondsFromTs.ToString() + " seconds";
        }

        private void buttonSubstract_Click(object sender, EventArgs e)
        {
            if (IsNullOrEmpty(pictureBoxOriginal1) || IsNullOrEmpty(pictureBoxOriginal2))
            {
                MessageBox.Show("Please open image files first!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            Bitmap origin1 = new Bitmap(pictureBoxOriginal1.Image);
            Bitmap origin2 = new Bitmap(pictureBoxOriginal2.Image);

            Stopwatch sw = Stopwatch.StartNew();

            if (comboBoxMode.SelectedIndex == 0)
                substractPointer(origin1, origin2);
            else if (comboBoxMode.SelectedIndex == 1)
                substractGDI(origin1, origin2);

            sw.Stop();
            TimeSpan ts = TimeSpan.FromTicks(sw.ElapsedTicks);
            double secondsFromTs = ts.TotalSeconds;

            labelTime.Text = secondsFromTs.ToString() + " seconds";
        }

        private void buttonDifference_Click(object sender, EventArgs e)
        {
            if (IsNullOrEmpty(pictureBoxOriginal1) || IsNullOrEmpty(pictureBoxOriginal2))
            {
                MessageBox.Show("Please open image files first!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            Bitmap origin1 = new Bitmap(pictureBoxOriginal1.Image);
            Bitmap origin2 = new Bitmap(pictureBoxOriginal2.Image);

            Stopwatch sw = Stopwatch.StartNew();

            if (comboBoxMode.SelectedIndex == 0)
                differencePointer(origin1, origin2);
            else if (comboBoxMode.SelectedIndex == 1)
                differenceGDI(origin1, origin2);

            sw.Stop();
            TimeSpan ts = TimeSpan.FromTicks(sw.ElapsedTicks);
            double secondsFromTs = ts.TotalSeconds;

            labelTime.Text = secondsFromTs.ToString() + " seconds";
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            if (IsNullOrEmpty(pictureBoxOriginal1) || IsNullOrEmpty(pictureBoxOriginal2))
            {
                MessageBox.Show("Please open image files first!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            Bitmap origin1 = new Bitmap(pictureBoxOriginal1.Image);
            Bitmap origin2 = new Bitmap(pictureBoxOriginal2.Image);

            Stopwatch sw = Stopwatch.StartNew();

            if (comboBoxMode.SelectedIndex == 0)
                multiplyPointer(origin1, origin2);
            else if (comboBoxMode.SelectedIndex == 1)
                multiplyGDI(origin1, origin2);

            sw.Stop();
            TimeSpan ts = TimeSpan.FromTicks(sw.ElapsedTicks);
            double secondsFromTs = ts.TotalSeconds;

            labelTime.Text = secondsFromTs.ToString() + " seconds";
        }

        private void buttonAverage_Click(object sender, EventArgs e)
        {
            if (IsNullOrEmpty(pictureBoxOriginal1) || IsNullOrEmpty(pictureBoxOriginal2))
            {
                MessageBox.Show("Please open image files first!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            Bitmap origin1 = new Bitmap(pictureBoxOriginal1.Image);
            Bitmap origin2 = new Bitmap(pictureBoxOriginal2.Image);

            Stopwatch sw = Stopwatch.StartNew();

            if (comboBoxMode.SelectedIndex == 0)
                averagePointer(origin1, origin2);
            else if (comboBoxMode.SelectedIndex == 1)
                averageGDI(origin1, origin2);

            sw.Stop();
            TimeSpan ts = TimeSpan.FromTicks(sw.ElapsedTicks);
            double secondsFromTs = ts.TotalSeconds;

            labelTime.Text = secondsFromTs.ToString() + " seconds";
        }

        private void buttonMin_Click(object sender, EventArgs e)
        {
            if (IsNullOrEmpty(pictureBoxOriginal1) || IsNullOrEmpty(pictureBoxOriginal2))
            {
                MessageBox.Show("Please open image files first!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            Bitmap origin1 = new Bitmap(pictureBoxOriginal1.Image);
            Bitmap origin2 = new Bitmap(pictureBoxOriginal2.Image);

            Stopwatch sw = Stopwatch.StartNew();

            if (comboBoxMode.SelectedIndex == 0)
                minPointer(origin1, origin2);
            else if (comboBoxMode.SelectedIndex == 1)
                minGDI(origin1, origin2);

            sw.Stop();
            TimeSpan ts = TimeSpan.FromTicks(sw.ElapsedTicks);
            double secondsFromTs = ts.TotalSeconds;

            labelTime.Text = secondsFromTs.ToString() + " seconds";
        }

        private void buttonMax_Click(object sender, EventArgs e)
        {
            if (IsNullOrEmpty(pictureBoxOriginal1) || IsNullOrEmpty(pictureBoxOriginal2))
            {
                MessageBox.Show("Please open image files first!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            Bitmap origin1 = new Bitmap(pictureBoxOriginal1.Image);
            Bitmap origin2 = new Bitmap(pictureBoxOriginal2.Image);

            Stopwatch sw = Stopwatch.StartNew();

            if (comboBoxMode.SelectedIndex == 0)
                maxPointer(origin1, origin2);
            else if (comboBoxMode.SelectedIndex == 1)
                maxGDI(origin1, origin2);

            sw.Stop();
            TimeSpan ts = TimeSpan.FromTicks(sw.ElapsedTicks);
            double secondsFromTs = ts.TotalSeconds;

            labelTime.Text = secondsFromTs.ToString() + " seconds";
        }

        private void buttonCrossFading_Click(object sender, EventArgs e)
        {
            if (IsNullOrEmpty(pictureBoxOriginal1) || IsNullOrEmpty(pictureBoxOriginal2))
            {
                MessageBox.Show("Please open image files first!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            Bitmap origin1 = new Bitmap(pictureBoxOriginal1.Image);
            Bitmap origin2 = new Bitmap(pictureBoxOriginal2.Image);

            if (comboBoxMode.SelectedIndex == 0)
                crossfadingPointer(origin1, origin2);
            else if (comboBoxMode.SelectedIndex == 1)
                crossfadingGDI(origin1, origin2);
        }

        private void buttonAmplitude_Click(object sender, EventArgs e)
        {
            if (IsNullOrEmpty(pictureBoxOriginal1) || IsNullOrEmpty(pictureBoxOriginal2))
            {
                MessageBox.Show("Please open image files first!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            Bitmap origin1 = new Bitmap(pictureBoxOriginal1.Image);
            Bitmap origin2 = new Bitmap(pictureBoxOriginal2.Image);

            Stopwatch sw = Stopwatch.StartNew();

            if (comboBoxMode.SelectedIndex == 0)
                amplitudePointer(origin1, origin2);
            else if (comboBoxMode.SelectedIndex == 1)
                amplitudeGDI(origin1, origin2);

            sw.Stop();
            TimeSpan ts = TimeSpan.FromTicks(sw.ElapsedTicks);
            double secondsFromTs = ts.TotalSeconds;

            labelTime.Text = secondsFromTs.ToString() + " seconds";
        }

        private void buttonAND_Click(object sender, EventArgs e)
        {
            if (IsNullOrEmpty(pictureBoxOriginal1) || IsNullOrEmpty(pictureBoxOriginal2))
            {
                MessageBox.Show("Please open image files first!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            Bitmap origin1 = new Bitmap(pictureBoxOriginal1.Image);
            Bitmap origin2 = new Bitmap(pictureBoxOriginal2.Image);

            Stopwatch sw = Stopwatch.StartNew();

            if (comboBoxMode.SelectedIndex == 0)
                andPointer(origin1, origin2);
            else if (comboBoxMode.SelectedIndex == 1)
                andGDI(origin1, origin2);

            sw.Stop();
            TimeSpan ts = TimeSpan.FromTicks(sw.ElapsedTicks);
            double secondsFromTs = ts.TotalSeconds;

            labelTime.Text = secondsFromTs.ToString() + " seconds";
        }

        private void buttonOR_Click(object sender, EventArgs e)
        {
            if (IsNullOrEmpty(pictureBoxOriginal1) || IsNullOrEmpty(pictureBoxOriginal2))
            {
                MessageBox.Show("Please open image files first!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            Bitmap origin1 = new Bitmap(pictureBoxOriginal1.Image);
            Bitmap origin2 = new Bitmap(pictureBoxOriginal2.Image);

            Stopwatch sw = Stopwatch.StartNew();

            if (comboBoxMode.SelectedIndex == 0)
                orPointer(origin1, origin2);
            else if (comboBoxMode.SelectedIndex == 1)
                orGDI(origin1, origin2);

            sw.Stop();
            TimeSpan ts = TimeSpan.FromTicks(sw.ElapsedTicks);
            double secondsFromTs = ts.TotalSeconds;

            labelTime.Text = secondsFromTs.ToString() + " seconds";
        }

        private void buttonXOR_Click(object sender, EventArgs e)
        {
            if (IsNullOrEmpty(pictureBoxOriginal1) || IsNullOrEmpty(pictureBoxOriginal2))
            {
                MessageBox.Show("Please open image files first!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            Bitmap origin1 = new Bitmap(pictureBoxOriginal1.Image);
            Bitmap origin2 = new Bitmap(pictureBoxOriginal2.Image);

            Stopwatch sw = Stopwatch.StartNew();

            if (comboBoxMode.SelectedIndex == 0)
                xorPointer(origin1, origin2);
            else if (comboBoxMode.SelectedIndex == 1)
                xorGDI(origin1, origin2);

            sw.Stop();
            TimeSpan ts = TimeSpan.FromTicks(sw.ElapsedTicks);
            double secondsFromTs = ts.TotalSeconds;

            labelTime.Text = secondsFromTs.ToString() + " seconds";
        }

        private void pointAndAreaBasedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormPointAndAreaBasedOperation f = new FormPointAndAreaBasedOperation();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void geometricTransformationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormGeometricTransformationsOperation f = new FormGeometricTransformationsOperation();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }
    }
}
