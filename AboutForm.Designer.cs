namespace Project
{
    partial class AboutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.O_Neillo_screenshot;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(603, 420);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            textBox1.Location = new Point(609, 0);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(254, 45);
            textBox1.TabIndex = 0;
            textBox1.Text = "O'Neillo v1.0";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(609, 84);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(254, 219);
            textBox2.TabIndex = 1;
            textBox2.Text = "The \"O'Neillo v1.0\" application was developed by Sayanthan Raveendran of Sheffield Hallan University, for his level 4 module, \"Programming Fundamentals.\" \r\n";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Highlight;
            button1.Location = new Point(678, 324);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(864, 421);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(pictureBox1);
            Name = "AboutForm";
            Text = "AboutForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
    }
}