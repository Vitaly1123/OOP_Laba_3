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

            // Налаштування кольорів для елементів форми
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
            string[] files = Directory.GetFiles("C:\\КС-231\\2 Курс\\ООП\\OOP_Laba_3\\OOP_Laba_3_2\\Images");

            // Перевіряємо тільки файли з розширеннями зображень
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

    }
}
