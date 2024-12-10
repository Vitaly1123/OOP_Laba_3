using System.Drawing;
using System.Windows.Forms;

namespace OOP_Laba_3_2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            button1 = new Button();
            listBox1 = new ListBox();
            pictureBox1 = new PictureBox();
            listBox2 = new ListBox();
            pictureBox2 = new PictureBox();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(76, 571);
            button1.Name = "button1";
            button1.Size = new Size(214, 36);
            button1.TabIndex = 0;
            button1.Text = "Переглянути зображення";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.HorizontalScrollbar = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(40, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(301, 184);
            listBox1.TabIndex = 1;
            listBox1.Visible = false;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(40, 215);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(326, 306);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Visible = false;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.HorizontalScrollbar = true;
            listBox2.ItemHeight = 20;
            listBox2.Location = new Point(547, 12);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(302, 184);
            listBox2.TabIndex = 3;
            listBox2.Visible = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(547, 215);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(302, 262);
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            pictureBox2.Visible = false;
            // 
            // button2
            // 
            button2.Location = new Point(607, 571);
            button2.Name = "button2";
            button2.Size = new Size(214, 36);
            button2.TabIndex = 5;
            button2.Text = "Відзеркалити\r\n\r\n";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 1055);
            Controls.Add(button2);
            Controls.Add(pictureBox2);
            Controls.Add(listBox2);
            Controls.Add(pictureBox1);
            Controls.Add(listBox1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Symmetry";
            SizeChanged += Form1_SizeChanged;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ListBox listBox1;
        private PictureBox pictureBox1;
        private ListBox listBox2;
        private PictureBox pictureBox2;
        private Button button2;
    }
}