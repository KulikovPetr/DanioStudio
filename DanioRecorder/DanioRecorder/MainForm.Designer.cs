namespace DanioRecorder
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.txtSet = new System.Windows.Forms.TextBox();
            this.btnSet = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnForcedStart = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.btnPause = new System.Windows.Forms.Button();
            this.btnResume = new System.Windows.Forms.Button();
            this.ChooseFolderButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox0 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Relay_1_on_txtbox = new System.Windows.Forms.TextBox();
            this.Relay_2_on_txtbox = new System.Windows.Forms.TextBox();
            this.Relay_1_off_txtbox = new System.Windows.Forms.TextBox();
            this.Relay_2_off_txtbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.Relay_checkbox = new System.Windows.Forms.CheckBox();
            this.Relay_path_textbox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(43, 26);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(318, 20);
            this.txtTime.TabIndex = 0;
            // 
            // txtSet
            // 
            this.txtSet.Location = new System.Drawing.Point(43, 80);
            this.txtSet.Name = "txtSet";
            this.txtSet.Size = new System.Drawing.Size(318, 20);
            this.txtSet.TabIndex = 1;
            this.txtSet.Text = "9:00 21:00 8 900 840";
            // 
            // btnSet
            // 
            this.btnSet.Enabled = false;
            this.btnSet.Location = new System.Drawing.Point(43, 152);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.TabIndex = 2;
            this.btnSet.Text = "Set";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(124, 152);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnForcedStart
            // 
            this.btnForcedStart.Location = new System.Drawing.Point(205, 152);
            this.btnForcedStart.Name = "btnForcedStart";
            this.btnForcedStart.Size = new System.Drawing.Size(75, 23);
            this.btnForcedStart.TabIndex = 4;
            this.btnForcedStart.Text = "Forced Start";
            this.btnForcedStart.UseVisualStyleBackColor = true;
            this.btnForcedStart.Click += new System.EventHandler(this.btnForcedStart_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(286, 152);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 5;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // mainTimer
            // 
            this.mainTimer.Interval = 1000;
            this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(124, 113);
            this.btnPause.Margin = new System.Windows.Forms.Padding(2);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 6;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnResume
            // 
            this.btnResume.Location = new System.Drawing.Point(205, 113);
            this.btnResume.Margin = new System.Windows.Forms.Padding(2);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(75, 23);
            this.btnResume.TabIndex = 7;
            this.btnResume.Text = "Resume";
            this.btnResume.UseVisualStyleBackColor = true;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // ChooseFolderButton
            // 
            this.ChooseFolderButton.Location = new System.Drawing.Point(124, 187);
            this.ChooseFolderButton.Name = "ChooseFolderButton";
            this.ChooseFolderButton.Size = new System.Drawing.Size(75, 23);
            this.ChooseFolderButton.TabIndex = 8;
            this.ChooseFolderButton.Text = "Folder";
            this.ChooseFolderButton.UseVisualStyleBackColor = true;
            this.ChooseFolderButton.Click += new System.EventHandler(this.ChooseFolderButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.InfoText;
            this.pictureBox1.Location = new System.Drawing.Point(438, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(358, 255);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // textBox0
            // 
            this.textBox0.Location = new System.Drawing.Point(524, 275);
            this.textBox0.Name = "textBox0";
            this.textBox0.Size = new System.Drawing.Size(19, 20);
            this.textBox0.TabIndex = 10;
            this.textBox0.Click += new System.EventHandler(this.Textbox_0_click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(549, 275);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(19, 20);
            this.textBox1.TabIndex = 11;
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(574, 275);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(19, 20);
            this.textBox2.TabIndex = 12;
            this.textBox2.Click += new System.EventHandler(this.textBox2_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(599, 275);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(19, 20);
            this.textBox3.TabIndex = 13;
            this.textBox3.Click += new System.EventHandler(this.textBox3_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(624, 275);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(19, 20);
            this.textBox4.TabIndex = 14;
            this.textBox4.Click += new System.EventHandler(this.textBox4_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(649, 275);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(19, 20);
            this.textBox5.TabIndex = 15;
            this.textBox5.Click += new System.EventHandler(this.textBox5_Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(674, 275);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(19, 20);
            this.textBox6.TabIndex = 16;
            this.textBox6.Click += new System.EventHandler(this.textBox6_Click);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(699, 275);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(19, 20);
            this.textBox7.TabIndex = 17;
            this.textBox7.Click += new System.EventHandler(this.textBox7_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(394, 278);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "введите номера камер";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(721, 272);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(56, 265);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "Relay 1 ON";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(137, 265);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 21;
            this.button3.Text = "Relay 1 OFF";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Relay_1_on_txtbox
            // 
            this.Relay_1_on_txtbox.Location = new System.Drawing.Point(124, 216);
            this.Relay_1_on_txtbox.Name = "Relay_1_on_txtbox";
            this.Relay_1_on_txtbox.Size = new System.Drawing.Size(75, 20);
            this.Relay_1_on_txtbox.TabIndex = 22;
            this.Relay_1_on_txtbox.Text = "8:59:55";
            // 
            // Relay_2_on_txtbox
            // 
            this.Relay_2_on_txtbox.Location = new System.Drawing.Point(124, 242);
            this.Relay_2_on_txtbox.Name = "Relay_2_on_txtbox";
            this.Relay_2_on_txtbox.Size = new System.Drawing.Size(75, 20);
            this.Relay_2_on_txtbox.TabIndex = 23;
            this.Relay_2_on_txtbox.Text = "8:59:55";
            // 
            // Relay_1_off_txtbox
            // 
            this.Relay_1_off_txtbox.Location = new System.Drawing.Point(286, 216);
            this.Relay_1_off_txtbox.Name = "Relay_1_off_txtbox";
            this.Relay_1_off_txtbox.Size = new System.Drawing.Size(75, 20);
            this.Relay_1_off_txtbox.TabIndex = 24;
            this.Relay_1_off_txtbox.Text = "21:00:05";
            // 
            // Relay_2_off_txtbox
            // 
            this.Relay_2_off_txtbox.Location = new System.Drawing.Point(286, 242);
            this.Relay_2_off_txtbox.Name = "Relay_2_off_txtbox";
            this.Relay_2_off_txtbox.Size = new System.Drawing.Size(75, 20);
            this.Relay_2_off_txtbox.TabIndex = 25;
            this.Relay_2_off_txtbox.Text = "21:00:05";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Relay 1 ON:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Relay 2 ON:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(250, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "OFF:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(250, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "OFF:";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(299, 265);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 31;
            this.button4.Text = "Relay 2 OFF";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(218, 265);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 30;
            this.button5.Text = "Relay 2 ON";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Relay_checkbox
            // 
            this.Relay_checkbox.AutoSize = true;
            this.Relay_checkbox.Checked = true;
            this.Relay_checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Relay_checkbox.Location = new System.Drawing.Point(48, 294);
            this.Relay_checkbox.Name = "Relay_checkbox";
            this.Relay_checkbox.Size = new System.Drawing.Size(70, 17);
            this.Relay_checkbox.TabIndex = 32;
            this.Relay_checkbox.Text = "Use relay";
            this.Relay_checkbox.UseVisualStyleBackColor = true;
            // 
            // Relay_path_textbox
            // 
            this.Relay_path_textbox.Location = new System.Drawing.Point(124, 294);
            this.Relay_path_textbox.Name = "Relay_path_textbox";
            this.Relay_path_textbox.Size = new System.Drawing.Size(250, 20);
            this.Relay_path_textbox.TabIndex = 33;
            this.Relay_path_textbox.Text = "D:\\ProjectExes v1.2.1\\";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 318);
            this.Controls.Add(this.Relay_path_textbox);
            this.Controls.Add(this.Relay_checkbox);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Relay_2_off_txtbox);
            this.Controls.Add(this.Relay_1_off_txtbox);
            this.Controls.Add(this.Relay_2_on_txtbox);
            this.Controls.Add(this.Relay_1_on_txtbox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox0);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ChooseFolderButton);
            this.Controls.Add(this.btnResume);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnForcedStart);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.txtSet);
            this.Controls.Add(this.txtTime);
            this.Name = "MainForm";
            this.Text = "DanioRecorder";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.TextBox txtSet;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnForcedStart;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Timer mainTimer;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.Button ChooseFolderButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        public System.Windows.Forms.TextBox textBox0;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox Relay_1_on_txtbox;
        private System.Windows.Forms.TextBox Relay_2_on_txtbox;
        private System.Windows.Forms.TextBox Relay_1_off_txtbox;
        private System.Windows.Forms.TextBox Relay_2_off_txtbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox Relay_checkbox;
        private System.Windows.Forms.TextBox Relay_path_textbox;
    }
}

