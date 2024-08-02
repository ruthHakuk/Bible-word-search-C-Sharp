namespace BiblePL
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            textBox1 = new TextBox();
            listBox1 = new ListBox();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(210, 163);
            button1.Name = "button1";
            button1.Size = new Size(167, 85);
            button1.TabIndex = 0;
            button1.Text = "לחץ לחפוש אינדקס";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(471, 85);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(237, 27);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(328, 332);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(532, 164);
            listBox1.TabIndex = 2;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // button2
            // 
            button2.Location = new Point(491, 163);
            button2.Name = "button2";
            button2.Size = new Size(217, 85);
            button2.TabIndex = 3;
            button2.Text = "לחץ לחיפוש מיקום מדוייק";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(825, 145);
            button3.Name = "button3";
            button3.Size = new Size(192, 103);
            button3.TabIndex = 4;
            button3.Text = "לחץ לחפוש רשימת האנשים שאיתו דיבר\\ה הדמות";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.WindowText;
            label1.Location = new Point(544, 45);
            label1.Name = "label1";
            label1.Size = new Size(105, 18);
            label1.TabIndex = 5;
            label1.Text = "הכנס שם לחיפוש";
            label1.Click += label1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1146, 614);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(listBox1);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private ListBox listBox1;
        private Button button2;
        private Button button3;
        private Label label1;
    }
}