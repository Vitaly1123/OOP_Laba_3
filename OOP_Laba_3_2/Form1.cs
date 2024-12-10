using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System;

namespace OOP_Laba_3_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.DarkMagenta;

            // ������������ ������� ��� �������� �����
            Color buttonBackground = Color.DimGray;
            Color buttonTextColor = Color.Black;

            Color listBoxBackground = Color.Salmon;
            Color listBoxTextColor = Color.AliceBlue;

            button1.BackColor = buttonBackground;
            button1.ForeColor = buttonTextColor;

            listBox1.BackColor = listBoxBackground;
            listBox1.ForeColor = listBoxTextColor;
            listBox1.BorderStyle = BorderStyle.FixedSingle;

            listBox2.BackColor = listBoxBackground;
            listBox2.ForeColor = listBoxTextColor;
            listBox2.BorderStyle = BorderStyle.FixedSingle;

            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;

            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;

            button2.BackColor = buttonBackground;
            button2.ForeColor = buttonTextColor;
        }

        private List<string> filePaths = new List<string>();

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Text = "Images";
            listBox1.Visible = true;
            this.Controls.Add(listBox1);
            listBox1.Items.Clear();
            listBox1.BeginUpdate();
            string[] files = Directory.GetFiles("C:\\��-231\\2 ����\\���\\OOP_Laba_3\\OOP_Laba_3_2\\Images");

            // ���������� ����� ����� � ������������ ���������
            Regex regexExtForImage = new Regex("^.((bmp)|(gif)|(tiff?)|(jpe?g)|(png))$", RegexOptions.IgnoreCase);

            foreach (var image in files)
            {
                if (regexExtForImage.IsMatch(Path.GetExtension(image)))
                {
                    listBox1.Items.Add(Path.GetFileName(image));
                    filePaths.Add(image);
                }
            }
            listBox1.EndUpdate();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            // �������� PictureBox ���� ������
            pictureBox1.Location = new Point(listBox1.Location.X, listBox1.Location.Y + listBox1.Height + 20);
            pictureBox1.Size = new Size(listBox1.Width, listBox1.Height);
        }

        private void DisplaySelectedImage(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Visible = true;
                string selectedFilePath = filePaths[listBox1.SelectedIndex];
                pictureBox1.Load(selectedFilePath);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Text = "New images";
            listBox2.Visible = true;
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("���� �����, ������ ���� � ������.");
                return;
            }

            string selectedFilePath = filePaths[listBox1.SelectedIndex];
            string targetDirectory = "C:\\��-231\\2 ����\\���\\OOP_Laba_3\\OOP_Laba_3_2\\New_images";

            try
            {
                Bitmap bitmap = new Bitmap(selectedFilePath);
                bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);

                // �������� ���������� � ������ GIF
                string fileName = Path.GetFileNameWithoutExtension(selectedFilePath);
                string newFileName = fileName + ".gif";
                string filePathInDirectory = Path.Combine(targetDirectory, newFileName);
                bitmap.Save(filePathInDirectory, ImageFormat.Gif);

                listBox2.Items.Add(newFileName);
                pictureBox2.Visible = true;
                pictureBox2.Load(filePathInDirectory);
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.Size = new System.Drawing.Size(225, 200);

                MessageBox.Show($"���� ������ ��������� �� {newFileName}.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������� ��� ������� �����: {ex.Message}");
            }
        }
    }
}
