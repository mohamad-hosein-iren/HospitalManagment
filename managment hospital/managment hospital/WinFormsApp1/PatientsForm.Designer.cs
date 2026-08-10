namespace WinFormsApp1
{
    partial class PatientsForm
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
            label1 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            textBox7 = new TextBox();
            textBox8 = new TextBox();
            textBox13 = new TextBox();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            numericUpDown1 = new NumericUpDown();
            label14 = new Label();
            label15 = new Label();
            numericUpDown2 = new NumericUpDown();
            textBox9 = new TextBox();
            label16 = new Label();
            button5 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label17 = new Label();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.Silver;
            label1.Location = new Point(-5, -2);
            label1.Name = "label1";
            label1.Size = new Size(1780, 445);
            label1.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(47, 123);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(402, 27);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(46, 46);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(402, 27);
            textBox2.TabIndex = 2;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(489, 47);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(402, 27);
            textBox3.TabIndex = 3;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(47, 204);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(402, 27);
            textBox4.TabIndex = 4;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(46, 284);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(402, 27);
            textBox5.TabIndex = 5;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(489, 123);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(402, 27);
            textBox6.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Silver;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(46, 89);
            label2.Name = "label2";
            label2.Size = new Size(126, 31);
            label2.TabIndex = 7;
            label2.Text = "Last Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Silver;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(41, 9);
            label3.Name = "label3";
            label3.Size = new Size(130, 31);
            label3.TabIndex = 8;
            label3.Text = "First Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Silver;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(944, 9);
            label4.Name = "label4";
            label4.Size = new Size(203, 31);
            label4.TabIndex = 9;
            label4.Text = "Attending Doctor";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Silver;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(489, 250);
            label5.Name = "label5";
            label5.Size = new Size(211, 31);
            label5.TabIndex = 10;
            label5.Text = "Insurance Number";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Silver;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(486, 170);
            label6.Name = "label6";
            label6.Size = new Size(176, 31);
            label6.TabIndex = 11;
            label6.Text = "Phone Number";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Silver;
            label7.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(486, 89);
            label7.Name = "label7";
            label7.Size = new Size(170, 31);
            label7.TabIndex = 12;
            label7.Text = "Home Address";
            label7.Click += label7_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Silver;
            label8.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(489, 9);
            label8.Name = "label8";
            label8.Size = new Size(167, 31);
            label8.TabIndex = 13;
            label8.Text = "National Code";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Silver;
            label9.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(47, 250);
            label9.Name = "label9";
            label9.Size = new Size(120, 31);
            label9.TabIndex = 14;
            label9.Text = "Patient ID";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Silver;
            label10.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(47, 170);
            label10.Name = "label10";
            label10.Size = new Size(125, 31);
            label10.TabIndex = 15;
            label10.Text = "Birth Date";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(489, 204);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(408, 27);
            textBox7.TabIndex = 16;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(489, 284);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(408, 27);
            textBox8.TabIndex = 17;
            // 
            // textBox13
            // 
            textBox13.Location = new Point(944, 47);
            textBox13.Name = "textBox13";
            textBox13.Size = new Size(400, 27);
            textBox13.TabIndex = 22;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Silver;
            label11.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(944, 248);
            label11.Name = "label11";
            label11.Size = new Size(170, 31);
            label11.TabIndex = 23;
            label11.Text = "DischargeDate";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Silver;
            label12.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(944, 170);
            label12.Name = "label12";
            label12.Size = new Size(162, 31);
            label12.TabIndex = 24;
            label12.Text = "Patient Status";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Silver;
            label13.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(944, 89);
            label13.Name = "label13";
            label13.Size = new Size(146, 31);
            label13.TabIndex = 25;
            label13.Text = "Patient Type";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Outpatient", "Inpatient" });
            comboBox1.Location = new Point(944, 123);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(217, 28);
            comboBox1.TabIndex = 26;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(944, 203);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(217, 28);
            comboBox2.TabIndex = 27;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(944, 282);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(278, 27);
            dateTimePicker1.TabIndex = 29;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(1205, 123);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(91, 27);
            numericUpDown1.TabIndex = 30;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Silver;
            label14.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(1182, 90);
            label14.Name = "label14";
            label14.Size = new Size(171, 31);
            label14.TabIndex = 31;
            label14.Text = "Room Number";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Silver;
            label15.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.Location = new Point(1182, 170);
            label15.Name = "label15";
            label15.Size = new Size(149, 31);
            label15.TabIndex = 32;
            label15.Text = "Bed Number";
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(1205, 203);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(91, 27);
            numericUpDown2.TabIndex = 33;
            // 
            // textBox9
            // 
            textBox9.Location = new Point(1430, 46);
            textBox9.Multiline = true;
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(277, 184);
            textBox9.TabIndex = 34;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.Silver;
            label16.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.Location = new Point(1430, 9);
            label16.Name = "label16";
            label16.Size = new Size(261, 31);
            label16.TabIndex = 35;
            label16.Text = "Diseases(Each line one)";
            // 
            // button5
            // 
            button5.BackColor = Color.Red;
            button5.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.Location = new Point(1195, 345);
            button5.Name = "button5";
            button5.Size = new Size(202, 68);
            button5.TabIndex = 40;
            button5.Text = "Delete Patient";
            button5.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(0, 192, 0);
            button2.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(1430, 345);
            button2.Name = "button2";
            button2.Size = new Size(202, 67);
            button2.TabIndex = 41;
            button2.Text = "Add Patient";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(192, 192, 0);
            button3.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(959, 345);
            button3.Name = "button3";
            button3.Padding = new Padding(0, 5, 0, 0);
            button3.Size = new Size(202, 68);
            button3.TabIndex = 42;
            button3.Text = "Update Doctor";
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.DimGray;
            button4.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.Location = new Point(729, 345);
            button4.Name = "button4";
            button4.Size = new Size(202, 68);
            button4.TabIndex = 43;
            button4.Text = "Reset";
            button4.UseVisualStyleBackColor = false;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.BackColor = Color.Silver;
            label17.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.Location = new Point(47, 345);
            label17.Name = "label17";
            label17.Size = new Size(91, 31);
            label17.TabIndex = 44;
            label17.Text = "Gender";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.BackColor = Color.Transparent;
            radioButton1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            radioButton1.Location = new Point(139, 381);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(95, 32);
            radioButton1.TabIndex = 45;
            radioButton1.TabStop = true;
            radioButton1.Text = "Female";
            radioButton1.UseVisualStyleBackColor = false;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.BackColor = Color.Transparent;
            radioButton2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            radioButton2.Location = new Point(47, 381);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(76, 32);
            radioButton2.TabIndex = 46;
            radioButton2.TabStop = true;
            radioButton2.Text = "Male";
            radioButton2.UseVisualStyleBackColor = false;
            // 
            // PatientsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1774, 679);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(label17);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button5);
            Controls.Add(label16);
            Controls.Add(textBox9);
            Controls.Add(numericUpDown2);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(numericUpDown1);
            Controls.Add(dateTimePicker1);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(textBox13);
            Controls.Add(textBox8);
            Controls.Add(textBox7);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "PatientsForm";
            Text = "PatientsForm";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox textBox13;
        private Label label11;
        private Label label12;
        private Label label13;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private DateTimePicker dateTimePicker1;
        private NumericUpDown numericUpDown1;
        private Label label14;
        private Label label15;
        private NumericUpDown numericUpDown2;
        private TextBox textBox9;
        private Label label16;
        private Button button5;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label17;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
    }
}