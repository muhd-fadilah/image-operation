using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageOperation
{
    public partial class FormPointAndAreaBasedOperation : Form
    {
        Bitmap bmpOriginal;
        Bitmap bmpResult;

        public FormPointAndAreaBasedOperation()
        {
            InitializeComponent();
        }

        public static bool IsNullOrEmpty(PictureBox pb)
        {
            return pb == null || pb.Image == null;
        }

        public class Operator
        {
            public int TopLeft = 0, TopMid = 0, TopRight = 0;
            public int MidLeft = 0, Pixel = 0, MidRight = 0;
            public int BottomLeft = 0, BottomMid = 0, BottomRight = 0;
            public int Factor = 1;
            public int Offset = 0;
            public void SetAll(int nVal)
            {
                TopLeft = TopMid = TopRight = MidLeft = Pixel = MidRight = BottomLeft = BottomMid = BottomRight;
            }
        }

        public static Bitmap Convolution(Bitmap b, Operator m)
        {
            Bitmap image = new Bitmap(b);
            Bitmap bSrc = new Bitmap(b);
            
            if (m.Factor == 0) return image;
            
            BitmapData bmData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            
            int stride = bmData.Stride;
            int stride2 = stride * 2;
            
            IntPtr Scan0 = bmData.Scan0;
            IntPtr SrcScan0 = bmSrc.Scan0;
            
            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                byte* pSrc = (byte*)(void*)SrcScan0;
                int nOffset = stride + 6 - image.Width * 3;
                int nWidth = image.Width - 2;
                int nHeight = image.Height - 2;
                int nPixel;
                for (int y = 0; y < nHeight; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        nPixel = ((((pSrc[2] * m.TopLeft) + (pSrc[5] * m.TopMid) + (pSrc[8] * m.TopRight) + (pSrc[2 + stride] * m.MidLeft) + (pSrc[5 + stride] * m.Pixel) + (pSrc[8 + stride] * m.MidRight) + (pSrc[2 + stride2] * m.BottomLeft) + (pSrc[5 + stride2] * m.BottomMid) + (pSrc[8 + stride2] * m.BottomRight)) / m.Factor) + m.Offset);
                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;
                        p[5 + stride] = (byte)nPixel;
                        nPixel = ((((pSrc[1] * m.TopLeft) + (pSrc[4] * m.TopMid) + (pSrc[7] * m.TopRight) + (pSrc[1 + stride] * m.MidLeft) + (pSrc[4 + stride] * m.Pixel) + (pSrc[7 + stride] * m.MidRight) + (pSrc[1 + stride2] * m.BottomLeft) + (pSrc[4 + stride2] * m.BottomMid) + (pSrc[7 + stride2] * m.BottomRight)) / m.Factor) + m.Offset);
                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;
                        p[4 + stride] = (byte)nPixel;
                        nPixel = ((((pSrc[0] * m.TopLeft) + (pSrc[3] * m.TopMid) + (pSrc[6] * m.TopRight) + (pSrc[0 + stride] * m.MidLeft) + (pSrc[3 + stride] * m.Pixel) + (pSrc[6 + stride] * m.MidRight) + (pSrc[0 + stride2] * m.BottomLeft) + (pSrc[3 + stride2] * m.BottomMid) + (pSrc[6 + stride2] * m.BottomRight)) / m.Factor) + m.Offset);
                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;
                        p[3 + stride] = (byte)nPixel;
                        p += 3;
                        pSrc += 3;
                    }
                    p += nOffset;
                    pSrc += nOffset;
                }
            }

            image.UnlockBits(bmData);
            bSrc.UnlockBits(bmSrc);
            return image;
        }

        public static Bitmap MinimumFiltering(Bitmap image, int matrixSize)
        {
            int w = image.Width;
            int h = image.Height;

            BitmapData image_data = image.LockBits(
                new Rectangle(0, 0, w, h),
                ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);

            int bytes = image_data.Stride * image_data.Height;
            byte[] buffer = new byte[bytes];

            Marshal.Copy(image_data.Scan0, buffer, 0, bytes);
            image.UnlockBits(image_data);

            int r = (matrixSize - 1) / 2;

            int wres = w - 2 * r;
            int hres = h - 2 * r;

            Bitmap result_image = new Bitmap(wres, hres);
            BitmapData result_data = result_image.LockBits(
                new Rectangle(0, 0, wres, hres),
                ImageLockMode.WriteOnly,
                PixelFormat.Format24bppRgb);
            int res_bytes = result_data.Stride * result_data.Height;
            byte[] result = new byte[res_bytes];

            for (int x = r; x < w - r; x++)
            {
                for (int y = r; y < h - r; y++)
                {

                    int pixel_location = x * 3 + y * image_data.Stride;
                    int res_pixel_loc = (x - r) * 3 + (y - r) * result_data.Stride;
                    double[] median = new double[3];
                    byte[][] neighborhood = new byte[3][];

                    for (int c = 0; c < 3; c++)
                    {
                        neighborhood[c] = new byte[(int)Math.Pow(2 * r + 1, 2)];
                        int added = 0;
                        for (int kx = -r; kx <= r; kx++)
                        {
                            for (int ky = -r; ky <= r; ky++)
                            {
                                int kernel_pixel = pixel_location + kx * 3 + ky * image_data.Stride;
                                neighborhood[c][added] = buffer[kernel_pixel + c];
                                added++;
                            }
                        }
                    }

                    for (int c = 0; c < 3; c++)
                    {
                        result[res_pixel_loc + c] = (byte)(neighborhood[c].Min());
                    }
                }
            }

            Marshal.Copy(result, 0, result_data.Scan0, res_bytes);
            result_image.UnlockBits(result_data);

            return result_image;
        }

        public static Bitmap MedianFiltering(Bitmap sourceBitmap, int matrixSize, bool grayscale = false)
        {
            BitmapData sourceData =
                       sourceBitmap.LockBits(new Rectangle(0, 0,
                       sourceBitmap.Width, sourceBitmap.Height),
                       ImageLockMode.ReadOnly,
                       PixelFormat.Format32bppArgb);


            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];

            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);

            sourceBitmap.UnlockBits(sourceData);


            if (grayscale == true)
            {
                float rgb = 0;


                for (int k = 0; k < pixelBuffer.Length; k += 4)
                {
                    rgb = pixelBuffer[k] * 0.11f;
                    rgb += pixelBuffer[k + 1] * 0.59f;
                    rgb += pixelBuffer[k + 2] * 0.3f;

                    pixelBuffer[k] = (byte)rgb;
                    pixelBuffer[k + 1] = pixelBuffer[k];
                    pixelBuffer[k + 2] = pixelBuffer[k];
                    pixelBuffer[k + 3] = 255;
                }
            }


            int filterOffset = (matrixSize - 1) / 2;
            int calcOffset = 0;

            int byteOffset = 0;

            List<int> neighbourPixels = new List<int>();
            byte[] middlePixel;

            for (int offsetY = filterOffset; offsetY <
                sourceBitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <
                    sourceBitmap.Width - filterOffset; offsetX++)
                {
                    byteOffset = offsetY *
                                 sourceData.Stride +
                                 offsetX * 4;

                    neighbourPixels.Clear();

                    for (int filterY = -filterOffset;
                        filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                            filterX <= filterOffset; filterX++)
                        {


                            calcOffset = byteOffset +
                                         (filterX * 4) +
                                (filterY * sourceData.Stride);


                            neighbourPixels.Add(BitConverter.ToInt32(
                                             pixelBuffer, calcOffset));
                        }
                    }


                    neighbourPixels.Sort();

                    middlePixel = BitConverter.GetBytes(neighbourPixels[filterOffset]);

                    resultBuffer[byteOffset] = middlePixel[0];
                    resultBuffer[byteOffset + 1] = middlePixel[1];
                    resultBuffer[byteOffset + 2] = middlePixel[2];
                    resultBuffer[byteOffset + 3] = middlePixel[3];
                }
            }


            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            BitmapData resultData =
                       resultBitmap.LockBits(new Rectangle(0, 0,
                       resultBitmap.Width, resultBitmap.Height),
                       ImageLockMode.WriteOnly,
                       PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);

            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

        public static Bitmap MaximumFiltering(Bitmap image, int matrixSize)
        {
            int w = image.Width;
            int h = image.Height;

            BitmapData image_data = image.LockBits(
                new Rectangle(0, 0, w, h),
                ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);

            int bytes = image_data.Stride * image_data.Height;
            byte[] buffer = new byte[bytes];

            Marshal.Copy(image_data.Scan0, buffer, 0, bytes);
            image.UnlockBits(image_data);

            int r = (matrixSize - 1) / 2;

            int wres = w - 2 * r;
            int hres = h - 2 * r;

            Bitmap result_image = new Bitmap(wres, hres);
            BitmapData result_data = result_image.LockBits(
                new Rectangle(0, 0, wres, hres),
                ImageLockMode.WriteOnly,
                PixelFormat.Format24bppRgb);
            int res_bytes = result_data.Stride * result_data.Height;
            byte[] result = new byte[res_bytes];

            for (int x = r; x < w - r; x++)
            {
                for (int y = r; y < h - r; y++)
                {

                    int pixel_location = x * 3 + y * image_data.Stride;
                    int res_pixel_loc = (x - r) * 3 + (y - r) * result_data.Stride;
                    double[] median = new double[3];
                    byte[][] neighborhood = new byte[3][];

                    for (int c = 0; c < 3; c++)
                    {
                        neighborhood[c] = new byte[(int)Math.Pow(2 * r + 1, 2)];
                        int added = 0;
                        for (int kx = -r; kx <= r; kx++)
                        {
                            for (int ky = -r; ky <= r; ky++)
                            {
                                int kernel_pixel = pixel_location + kx * 3 + ky * image_data.Stride;
                                neighborhood[c][added] = buffer[kernel_pixel + c];
                                added++;
                            }
                        }
                    }

                    for (int c = 0; c < 3; c++)
                    {
                        result[res_pixel_loc + c] = (byte)(neighborhood[c].Max());
                    }
                }
            }

            Marshal.Copy(result, 0, result_data.Scan0, res_bytes);
            result_image.UnlockBits(result_data);

            return result_image;
        }


        public byte[,] plusX5 = new byte[5, 5] {
        {0,0,1,0,0},
        {0,0,1,0,0},
        {1,1,1,1,1},
        {0,0,1,0,0},
        {0,0,1,0,0}
        };

        public byte[,] squareX5 = new byte[5, 5] {
        {1,1,1,1,1},
        {1,1,1,1,1},
        {1,1,1,1,1},
        {1,1,1,1,1},
        {1,1,1,1,1}
        };

        public byte[,] crossX5 = new byte[5, 5] {
        {1,0,0,0,1},
        {0,1,0,1,0},
        {0,0,1,0,0},
        {0,1,0,1,0},
        {1,0,0,0,1}
        };

        public byte[,] boxX5 = new byte[5, 5] {
        {1,1,1,1,1},
        {1,0,0,0,1},
        {1,0,0,0,1},
        {1,0,0,0,1},
        {1,1,1,1,1}
        };

        public byte[,] plusX3 = new byte[3, 3] {
        {0,1,0},
        {1,1,1},
        {0,1,0}
        };

        public byte[,] squareX3 = new byte[3, 3] {
        {1,1,1},
        {1,1,1},
        {1,1,1}
        };

        public byte[,] crossX3 = new byte[3, 3] {
        {1,0,1},
        {0,1,0},
        {1,0,1}
        };

        public byte[,] boxX3 = new byte[3, 3] {
        {1,1,1},
        {1,0,1},
        {1,1,1}
        };

        public Bitmap Dilation(Bitmap Image, byte[,] sElement, int size)
        {
            Bitmap tBitmap = Image;
            Bitmap nBitmap = new Bitmap(tBitmap.Width, tBitmap.Height);
            Graphics nGraphics = Graphics.FromImage(nBitmap);
            nGraphics.DrawImage(tBitmap, new Rectangle(0, 0, tBitmap.Width, tBitmap.Height), new Rectangle(0, 0, tBitmap.Width, tBitmap.Height), GraphicsUnit.Pixel);
            nGraphics.Dispose();

            for (int x = 0; x < nBitmap.Width; ++x)
            {
                for (int y = 0; y < nBitmap.Height; ++y)
                {
                    int redValue = 0;
                    int greenValue = 0;
                    int blueValue = 0;
                    for (int x2 = 0; x2 < size; ++x2)
                    {
                        int tempX = x + x2;
                        if (tempX >= 0 && tempX < nBitmap.Width)
                        {
                            for (int y2 = 0; y2 < size; ++y2)
                            {
                                int TempY = y + y2;
                                int check = sElement[x2, y2];
                                if (TempY >= 0 && TempY < nBitmap.Height && check == 1)
                                {
                                    Color TempColor = tBitmap.GetPixel(tempX, TempY);
                                    if (TempColor.R > redValue)
                                        redValue = TempColor.R;
                                    if (TempColor.G > greenValue)
                                        greenValue = TempColor.G;
                                    if (TempColor.B > blueValue)
                                        blueValue = TempColor.B;
                                }
                            }
                        }
                    }
                    Color TempPixel = Color.FromArgb(redValue, greenValue, blueValue);
                    nBitmap.SetPixel(x, y, TempPixel);
                }
            }
            return nBitmap;
        }

        public Bitmap Erosion(Bitmap Image, byte[,] sElement, int size)
        {
            Bitmap tBitmap = Image;
            Bitmap nBitmap = new Bitmap(tBitmap.Width, tBitmap.Height);
            Graphics nGraphics = Graphics.FromImage(nBitmap);
            nGraphics.DrawImage(tBitmap, new Rectangle(0, 0, tBitmap.Width, tBitmap.Height), new Rectangle(0, 0, tBitmap.Width, tBitmap.Height), GraphicsUnit.Pixel);
            nGraphics.Dispose();

            for (int x = 0; x < nBitmap.Width; ++x)
            {
                for (int y = 0; y < nBitmap.Height; ++y)
                {
                    int redValue = 255;
                    int greenValue = 255;
                    int blueValue = 255;
                    for (int x2 = 0; x2 < size; ++x2)
                    {
                        int tempX = x + x2;
                        if (tempX >= 0 && tempX < nBitmap.Width)
                        {
                            for (int y2 = 0; y2 < size; ++y2)
                            {
                                int TempY = y + y2;
                                int check = sElement[x2, y2];
                                if (TempY >= 0 && TempY < nBitmap.Height && check == 1)
                                {
                                    Color TempColor = tBitmap.GetPixel(tempX, TempY);
                                    if (TempColor.R < redValue)
                                        redValue = TempColor.R;
                                    if (TempColor.G < greenValue)
                                        greenValue = TempColor.G;
                                    if (TempColor.B < blueValue)
                                        blueValue = TempColor.B;
                                }
                            }
                        }
                    }
                    Color TempPixel = Color.FromArgb(redValue, greenValue, blueValue);
                    nBitmap.SetPixel(x, y, TempPixel);
                }
            }
            return nBitmap;
        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.png; *.bmp) | *.jpg; *.png; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                bmpOriginal = new Bitmap(open.FileName);
                pictureBoxOriginal.Image = new Bitmap(bmpOriginal, new Size(300, 300));
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
                        bmpResult.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case 2:
                        bmpResult.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
                        break;

                    case 3:
                        bmpResult.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                }

                fs.Close();
            }
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

        private void buttonBrightness_Click(object sender, EventArgs e)
        {
            if (IsNullOrEmpty(pictureBoxOriginal))
            {
                MessageBox.Show("Please open an image file first!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            string temp = valueInput("Value", "Brightness Value");
            
            if (temp == "")
            {
                return;
            }

            if (int.TryParse(temp, out _) == false)
            {
                MessageBox.Show("Please input an integer value!",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            labelTime.Text = "Processing...";
            labelTime.Refresh();

            Stopwatch sw = Stopwatch.StartNew();

            int nBrightness = Convert.ToInt16(temp);
            int nVal;

            Bitmap image = new Bitmap(bmpOriginal);

            BitmapData data = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                ImageLockMode.ReadWrite,
                PixelFormat.Format24bppRgb);

            int nOffset = data.Stride - data.Width * 3;
            int nWidth = data.Width * 3;

            unsafe
            {
                byte* ptr = (byte*)(data.Scan0);
                for (int x = 0; x < data.Height; ++x)
                {
                    for (int y = 0; y < nWidth; ++y)
                    {
                        nVal = (int)(ptr[0] + nBrightness);
                        if (nVal < 0) nVal = 0;
                        if (nVal > 255) nVal = 255;
                        ptr[0] = (byte)nVal;
                        ++ptr;
                    }
                    ptr += nOffset;
                }
            }

            image.UnlockBits(data);
            pictureBoxResult.Image = new Bitmap(image, new Size(300, 300));
            bmpResult = new Bitmap(image);

            sw.Stop();
            TimeSpan ts = TimeSpan.FromTicks(sw.ElapsedTicks);
            double secondsFromTs = ts.TotalSeconds;

            labelTime.Text = secondsFromTs.ToString() + " seconds";
        }

        public static string selectKernelSize(string text, string caption)
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
            ComboBox comboBox = new ComboBox() { Left = 100, Top = 20, Width = 50 };
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.Items.Add(3);
            comboBox.Items.Add(5);
            comboBox.Items.Add(7);
            comboBox.Items.Add(9);
            comboBox.Items.Add(13);
            Button confirmation = new Button() { Text = "Ok", Left = 100, Width = 50, Top = 75, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(comboBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? comboBox.Text : "";
        }

        public static string selectStructuringElement(string text, string caption)
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
            ComboBox comboBox = new ComboBox() { Left = 100, Top = 20, Width = 100 };
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.Items.Add("Plus (5x5)");
            comboBox.Items.Add("Square (5x5)");
            comboBox.Items.Add("Box (5x5)");
            comboBox.Items.Add("Cross (5x5)");
            comboBox.Items.Add("Plus (3x3)");
            comboBox.Items.Add("Square (3x3)");
            comboBox.Items.Add("Box (3x3)");
            comboBox.Items.Add("Cross (3x3)");
            Button confirmation = new Button() { Text = "Ok", Left = 100, Width = 50, Top = 75, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(comboBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? comboBox.Text : "";
        }

        private void buttonGrayscaleAverage_Click(object sender, EventArgs e)
        {
            if (IsNullOrEmpty(pictureBoxOriginal))
            {
                MessageBox.Show("Please open an image file first!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            labelTime.Text = "Processing...";
            labelTime.Refresh();

            Stopwatch sw = Stopwatch.StartNew();
            Bitmap image = new Bitmap(bmpOriginal);
            int nVal;

            BitmapData data = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                ImageLockMode.ReadWrite,
                PixelFormat.Format32bppRgb);

            unsafe
            {
                byte* p = (byte*)(void*)(data.Scan0.ToPointer());
                int stopAddress = (int)p + data.Stride * data.Height;

                while ((int)p != stopAddress)
                {
                    nVal = (int)((p[2] + p[1] + p[0]) / 3);
                    p[0] = (byte)nVal;
                    p[1] = p[0];
                    p[2] = p[0];

                    p += 4;
                }
            }

            image.UnlockBits(data);
            pictureBoxResult.Image = new Bitmap(image, new Size(300, 300));
            bmpResult = new Bitmap(image);

            sw.Stop();
            TimeSpan ts = TimeSpan.FromTicks(sw.ElapsedTicks);
            double secondsFromTs = ts.TotalSeconds;

            labelTime.Text = secondsFromTs.ToString() + " seconds";
        }

        private void buttonGrayscaleWeight_Click(object sender, EventArgs e)
        {
            if (IsNullOrEmpty(pictureBoxOriginal))
            {
                MessageBox.Show("Please open an image file first!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            labelTime.Text = "Processing...";
            labelTime.Refresh();

            Stopwatch sw = Stopwatch.StartNew();
            Bitmap image = new Bitmap(bmpOriginal);
            int nVal;

            BitmapData data = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                ImageLockMode.ReadWrite,
                PixelFormat.Format32bppRgb);

            unsafe
            {
                byte* p = (byte*)(void*)(data.Scan0.ToPointer());
                int stopAddress = (int)p + data.Stride * data.Height;

                while ((int)p != stopAddress)
                {
                    nVal = (int)(.299 * p[2] + .587 * p[1] + .114 * p[0]);
                    p[0] = (byte)nVal;
                    p[1] = p[0];
                    p[2] = p[0];

                    p += 4;
                }
            }

            image.UnlockBits(data);
            pictureBoxResult.Image = new Bitmap(image, new Size(300, 300));
            bmpResult = new Bitmap(image);

            sw.Stop();
            TimeSpan ts = TimeSpan.FromTicks(sw.ElapsedTicks);
            double secondsFromTs = ts.TotalSeconds;

            labelTime.Text = secondsFromTs.ToString() + " seconds";
        }

        private void buttonThreshold_Click(object sender, EventArgs e)
        {
            if (IsNullOrEmpty(pictureBoxOriginal))
            {
                MessageBox.Show("Please open an image file first!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            string temp = valueInput("Value", "Threshold Value");

            if (temp == "")
            {
                return;
            }

            if (int.TryParse(temp, out _) == false)
            {
                MessageBox.Show("Please input an integer value!",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            labelTime.Text = "Processing...";
            labelTime.Refresh();

            Stopwatch sw = Stopwatch.StartNew();

            Bitmap image = new Bitmap(bmpOriginal);
            int nVal;
            int threshold = Convert.ToInt16(temp);

            BitmapData data = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                ImageLockMode.ReadWrite,
                PixelFormat.Format32bppRgb);

            unsafe
            {
                byte* p = (byte*)(void*)(data.Scan0.ToPointer());
                int stopAddress = (int)p + data.Stride * data.Height;

                while ((int)p != stopAddress)
                {
                    nVal = (int)(.299 * p[2] + .587 * p[1] + .114 * p[0]);
                    p[0] = (byte)nVal;
                    p[1] = p[0];
                    p[2] = p[0];

                    if (p[0] >= threshold) p[0] = 255;
                    else p[0] = 0;

                    if (p[1] >= threshold) p[1] = 255;
                    else p[1] = 0;

                    if (p[2] >= threshold) p[2] = 255;
                    else p[2] = 0;

                    p += 4;
                }
            }

            image.UnlockBits(data);
            pictureBoxResult.Image = new Bitmap(image, new Size(300, 300));
            bmpResult = new Bitmap(image);

            sw.Stop();
            TimeSpan ts = TimeSpan.FromTicks(sw.ElapsedTicks);
            double secondsFromTs = ts.TotalSeconds;

            labelTime.Text = secondsFromTs.ToString() + " seconds";
        }

        private void buttonInvert_Click(object sender, EventArgs e)
        {
            if (IsNullOrEmpty(pictureBoxOriginal))
            {
                MessageBox.Show("Please open an image file first!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            labelTime.Text = "Processing...";
            labelTime.Refresh();

            Stopwatch sw = Stopwatch.StartNew();
            int nVal;
            Bitmap image = new Bitmap(bmpOriginal);

            BitmapData data = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                ImageLockMode.ReadWrite,
                PixelFormat.Format24bppRgb);

            int nOffset = data.Stride - data.Width * 3;
            int nWidth = data.Width * 3;

            unsafe
            {
                byte* ptr = (byte*)(data.Scan0);
                for (int x = 0; x < data.Height; ++x)
                {
                    for (int y = 0; y < nWidth; ++y)
                    {
                        nVal = (int)(255 - ptr[0]);
                        if (nVal < 0) nVal = 0;
                        if (nVal > 255) nVal = 255;
                        ptr[0] = (byte)nVal;
                        ++ptr;
                    }
                    ptr += nOffset;
                }
            }

            image.UnlockBits(data);
            pictureBoxResult.Image = new Bitmap(image, new Size(300, 300));
            bmpResult = new Bitmap(image);

            sw.Stop();
            TimeSpan ts = TimeSpan.FromTicks(sw.ElapsedTicks);
            double secondsFromTs = ts.TotalSeconds;

            labelTime.Text = secondsFromTs.ToString() + " seconds";
        }

        private void buttonBlurring_Click(object sender, EventArgs e)
        {
            if (IsNullOrEmpty(pictureBoxOriginal))
            {
                MessageBox.Show("Please open an image file first!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            labelTime.Text = "Processing...";
            labelTime.Refresh();

            Stopwatch sw = Stopwatch.StartNew();
            Operator Filter = new Operator();
            Filter.TopLeft = 1;
            Filter.TopMid = 2;
            Filter.TopRight = 1;
            Filter.MidLeft = 2;
            Filter.Pixel = 4;
            Filter.MidRight = 2;
            Filter.BottomLeft = 1;
            Filter.BottomMid = 2;
            Filter.BottomRight = 1;
            Filter.Factor = 16;
            Filter.Offset = 0;
            bmpResult = (Bitmap)Convolution((Bitmap)bmpOriginal, Filter);
            pictureBoxResult.Image = new Bitmap(bmpResult, new Size(300, 300));

            sw.Stop();
            TimeSpan ts = TimeSpan.FromTicks(sw.ElapsedTicks);
            double secondsFromTs = ts.TotalSeconds;

            labelTime.Text = secondsFromTs.ToString() + " seconds";
        }

        private void buttonSharpening_Click(object sender, EventArgs e)
        {
            if (IsNullOrEmpty(pictureBoxOriginal))
            {
                MessageBox.Show("Please open an image file first!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            labelTime.Text = "Processing...";
            labelTime.Refresh();

            Stopwatch sw = Stopwatch.StartNew();
            Operator Filter = new Operator();

            Filter.TopLeft = 0;
            Filter.TopMid = -2;
            Filter.TopRight = 0;
            Filter.MidLeft = -2;
            Filter.Pixel = 11;
            Filter.MidRight = -2;
            Filter.BottomLeft = 0;
            Filter.BottomMid = -2;
            Filter.BottomRight = 0;
            Filter.Factor = 3;
            Filter.Offset = 0;
            
            bmpResult = (Bitmap)Convolution((Bitmap)bmpOriginal, Filter);
            pictureBoxResult.Image = new Bitmap(bmpResult, new Size(300, 300));

            sw.Stop();
            TimeSpan ts = TimeSpan.FromTicks(sw.ElapsedTicks);
            double secondsFromTs = ts.TotalSeconds;

            labelTime.Text = secondsFromTs.ToString() + " seconds";
        }

        private void buttonEmbossing_Click(object sender, EventArgs e)
        {
            if (IsNullOrEmpty(pictureBoxOriginal))
            {
                MessageBox.Show("Please open an image file first!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            labelTime.Text = "Processing...";
            labelTime.Refresh();

            Stopwatch sw = Stopwatch.StartNew();
            Operator Filter = new Operator();

            Filter.TopLeft = -1;
            Filter.TopMid = 0;
            Filter.TopRight = -1;
            Filter.MidLeft = 0;
            Filter.Pixel = 4;
            Filter.MidRight = 0;
            Filter.BottomLeft = -1;
            Filter.BottomMid = 0;
            Filter.BottomRight = -1;
            Filter.Factor = 1;
            Filter.Offset = 127;

            bmpResult = (Bitmap)Convolution((Bitmap)bmpOriginal, Filter);
            pictureBoxResult.Image = new Bitmap(bmpResult, new Size(300, 300));

            sw.Stop();
            TimeSpan ts = TimeSpan.FromTicks(sw.ElapsedTicks);
            double secondsFromTs = ts.TotalSeconds;

            labelTime.Text = secondsFromTs.ToString() + " seconds";
        }

        private void buttonEdging_Click(object sender, EventArgs e)
        {
            if (IsNullOrEmpty(pictureBoxOriginal))
            {
                MessageBox.Show("Please open an image file first!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            labelTime.Text = "Processing...";
            labelTime.Refresh();

            Stopwatch sw = Stopwatch.StartNew();
            Operator Filter = new Operator();
            Filter.TopLeft = -1;
            Filter.TopMid = -1;
            Filter.TopRight = -1;
            Filter.MidLeft = 0;
            Filter.Pixel = 0;
            Filter.MidRight = 0;
            Filter.BottomLeft = 1;
            Filter.BottomMid = 1;
            Filter.BottomRight = 1;
            Filter.Factor = 1;
            Filter.Offset = 127;

            bmpResult = (Bitmap)Convolution((Bitmap)bmpOriginal, Filter);
            pictureBoxResult.Image = new Bitmap(bmpResult, new Size(300, 300));

            sw.Stop();
            TimeSpan ts = TimeSpan.FromTicks(sw.ElapsedTicks);
            double secondsFromTs = ts.TotalSeconds;

            labelTime.Text = secondsFromTs.ToString() + " seconds";
        }

        private void buttonMedianFiltering_Click(object sender, EventArgs e)
        {
            if (IsNullOrEmpty(pictureBoxOriginal))
            {
                MessageBox.Show("Please open an image file first!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            string temp = selectKernelSize("Value", "Kernel Size");

            if (temp == "")
            {
                return;
            }

            if (int.TryParse(temp, out _) == false)
            {
                MessageBox.Show("Input is empty!",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            int size = Convert.ToInt16(temp);

            labelTime.Text = "Processing...";
            labelTime.Refresh();

            Stopwatch sw = Stopwatch.StartNew();
            Bitmap image = new Bitmap(bmpOriginal);
            
            bmpResult = new Bitmap(MedianFiltering(image, size));
            pictureBoxResult.Image = new Bitmap(bmpResult, new Size(300, 300));

            sw.Stop();
            TimeSpan ts = TimeSpan.FromTicks(sw.ElapsedTicks);
            double secondsFromTs = ts.TotalSeconds;

            labelTime.Text = secondsFromTs.ToString() + " seconds";
        }

        private void buttonMinimumFiltering_Click(object sender, EventArgs e)
        {
            if (IsNullOrEmpty(pictureBoxOriginal))
            {
                MessageBox.Show("Please open an image file first!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            string temp = selectKernelSize("Value", "Kernel Size");

            if(temp == "")
            {
                return;
            }

            if (int.TryParse(temp, out _) == false)
            {
                MessageBox.Show("Input is empty!",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            int size = Convert.ToInt16(temp);

            labelTime.Text = "Processing...";
            labelTime.Refresh();

            Stopwatch sw = Stopwatch.StartNew();
            Bitmap image = new Bitmap(bmpOriginal);
            bmpResult = new Bitmap(MinimumFiltering(image, size));
            pictureBoxResult.Image = new Bitmap(bmpResult, new Size(300, 300));

            sw.Stop();
            TimeSpan ts = TimeSpan.FromTicks(sw.ElapsedTicks);
            double secondsFromTs = ts.TotalSeconds;

            labelTime.Text = secondsFromTs.ToString() + " seconds";
        }

        private void buttonMaximumFiltering_Click(object sender, EventArgs e)
        {
            if (IsNullOrEmpty(pictureBoxOriginal))
            {
                MessageBox.Show("Please open an image file first!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            string temp = selectKernelSize("Value", "Kernel Size");

            if (temp == "")
            {
                return;
            }

            if (int.TryParse(temp, out _) == false)
            {
                MessageBox.Show("Input is empty!",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            int size = Convert.ToInt16(temp);

            labelTime.Text = "Processing...";
            labelTime.Refresh();

            Stopwatch sw = Stopwatch.StartNew();
            Bitmap image = new Bitmap(bmpOriginal);
            bmpResult = new Bitmap(MaximumFiltering(image, size));
            pictureBoxResult.Image = new Bitmap(bmpResult, new Size(300, 300));

            sw.Stop();
            TimeSpan ts = TimeSpan.FromTicks(sw.ElapsedTicks);
            double secondsFromTs = ts.TotalSeconds;

            labelTime.Text = secondsFromTs.ToString() + " seconds";
        }

        private void buttonDilation_Click(object sender, EventArgs e)
        {
            if (IsNullOrEmpty(pictureBoxOriginal))
            {
                MessageBox.Show("Please open an image file first!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            string temp = selectStructuringElement("Shape", "Structuring Element");
            byte[,] sElement = new byte[,] { };
            int size = 0;

            switch (temp)
            {
                case "Plus (5x5)":
                    sElement = plusX5;
                    size = 5;
                    break;

                case "Square (5x5)":
                    sElement = squareX5;
                    size = 5;
                    break;

                case "Cross (5x5)":
                    sElement = crossX5;
                    size = 5;
                    break;

                case "Box (5x5)":
                    sElement = boxX5;
                    size = 5;
                    break;

                case "Plus (3x3)":
                    sElement = plusX3;
                    size = 3;
                    break;

                case "Square (3x3)":
                    sElement = squareX3;
                    size = 3;
                    break;

                case "Cross (3x3)":
                    sElement = crossX3;
                    size = 3;
                    break;

                case "Box (3x3)":
                    sElement = boxX3;
                    size = 3;
                    break;

                default:
                    return;
            }

            labelTime.Text = "Processing...";
            labelTime.Refresh();

            Stopwatch sw = Stopwatch.StartNew();

            Bitmap image = new Bitmap(bmpOriginal);
            bmpResult = new Bitmap(Dilation(image, sElement, size));

            pictureBoxResult.Image = new Bitmap(bmpResult, new Size(300, 300));

            sw.Stop();
            TimeSpan ts = TimeSpan.FromTicks(sw.ElapsedTicks);
            double secondsFromTs = ts.TotalSeconds;

            labelTime.Text = secondsFromTs.ToString() + " seconds";
        }

        private void buttonErosion_Click(object sender, EventArgs e)
        {
            if (IsNullOrEmpty(pictureBoxOriginal))
            {
                MessageBox.Show("Please open an image file first!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            string temp = selectStructuringElement("Shape", "Structuring Element");
            byte[,] sElement = new byte[,] { };
            int size = 0;

            switch (temp)
            {
                case "Plus (5x5)":
                    sElement = plusX5;
                    size = 5;
                    break;

                case "Square (5x5)":
                    sElement = squareX5;
                    size = 5;
                    break;

                case "Cross (5x5)":
                    sElement = crossX5;
                    size = 5;
                    break;

                case "Box (5x5)":
                    sElement = boxX5;
                    size = 5;
                    break;

                case "Plus (3x3)":
                    sElement = plusX5;
                    size = 3;
                    break;

                case "Square (3x3)":
                    sElement = squareX5;
                    size = 3;
                    break;

                case "Cross (3x3)":
                    sElement = crossX5;
                    size = 3;
                    break;

                case "Box (3x3)":
                    sElement = boxX5;
                    size = 3;
                    break;

                default:
                    return;
            }


            labelTime.Text = "Processing...";
            labelTime.Refresh();

            Stopwatch sw = Stopwatch.StartNew();

            Bitmap image = new Bitmap(bmpOriginal);
            bmpResult = new Bitmap(Erosion(image, sElement, size));

            pictureBoxResult.Image = new Bitmap(bmpResult, new Size(300, 300));

            sw.Stop();
            TimeSpan ts = TimeSpan.FromTicks(sw.ElapsedTicks);
            double secondsFromTs = ts.TotalSeconds;

            labelTime.Text = secondsFromTs.ToString() + " seconds";
        }

        private void frameBasedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormFrameBasedOperation f = new FormFrameBasedOperation();
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

            bmpOriginal = new Bitmap(bmpResult);
            pictureBoxOriginal.Image = new Bitmap(bmpOriginal, 300, 300);
            pictureBoxResult.Image = null;
        }
    }
}
