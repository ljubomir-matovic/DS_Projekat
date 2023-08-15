namespace MG_58_2020
{
    partial class MemoryGameForm
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
            this.newGameButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton442 = new System.Windows.Forms.RadioButton();
            this.radioButton342 = new System.Windows.Forms.RadioButton();
            this.radioButton332 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonMojaSlika = new System.Windows.Forms.RadioButton();
            this.radioButtonIkonice = new System.Windows.Forms.RadioButton();
            this.timerLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.movesLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.loadImageButton = new System.Windows.Forms.Button();
            this.loadedImageLabel = new System.Windows.Forms.Label();
            this.finishGameButton = new System.Windows.Forms.Button();
            this.imeIgracaTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // newGameButton
            // 
            this.newGameButton.Image = global::MG_58_2020.Properties.Resources.newgame;
            this.newGameButton.Location = new System.Drawing.Point(1127, 75);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(115, 80);
            this.newGameButton.TabIndex = 0;
            this.newGameButton.UseVisualStyleBackColor = true;
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton442);
            this.groupBox1.Controls.Add(this.radioButton342);
            this.groupBox1.Controls.Add(this.radioButton332);
            this.groupBox1.Location = new System.Drawing.Point(1127, 265);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(111, 124);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dimenzije";
            // 
            // radioButton442
            // 
            this.radioButton442.AutoSize = true;
            this.radioButton442.Location = new System.Drawing.Point(6, 86);
            this.radioButton442.Name = "radioButton442";
            this.radioButton442.Size = new System.Drawing.Size(73, 20);
            this.radioButton442.TabIndex = 2;
            this.radioButton442.TabStop = true;
            this.radioButton442.Text = "4 x 4 x 2";
            this.radioButton442.UseVisualStyleBackColor = true;
            this.radioButton442.CheckedChanged += new System.EventHandler(this.radioButton442_CheckedChanged);
            // 
            // radioButton342
            // 
            this.radioButton342.AutoSize = true;
            this.radioButton342.Location = new System.Drawing.Point(6, 60);
            this.radioButton342.Name = "radioButton342";
            this.radioButton342.Size = new System.Drawing.Size(73, 20);
            this.radioButton342.TabIndex = 1;
            this.radioButton342.TabStop = true;
            this.radioButton342.Text = "3 x 4 x 2";
            this.radioButton342.UseVisualStyleBackColor = true;
            this.radioButton342.CheckedChanged += new System.EventHandler(this.radioButton342_CheckedChanged);
            // 
            // radioButton332
            // 
            this.radioButton332.AutoSize = true;
            this.radioButton332.Location = new System.Drawing.Point(6, 34);
            this.radioButton332.Name = "radioButton332";
            this.radioButton332.Size = new System.Drawing.Size(73, 20);
            this.radioButton332.TabIndex = 0;
            this.radioButton332.TabStop = true;
            this.radioButton332.Text = "3 x 3 x 2";
            this.radioButton332.UseVisualStyleBackColor = true;
            this.radioButton332.CheckedChanged += new System.EventHandler(this.radioButton332_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonMojaSlika);
            this.groupBox2.Controls.Add(this.radioButtonIkonice);
            this.groupBox2.Location = new System.Drawing.Point(1131, 408);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(106, 76);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Opcije";
            // 
            // radioButtonMojaSlika
            // 
            this.radioButtonMojaSlika.AutoSize = true;
            this.radioButtonMojaSlika.Location = new System.Drawing.Point(6, 47);
            this.radioButtonMojaSlika.Name = "radioButtonMojaSlika";
            this.radioButtonMojaSlika.Size = new System.Drawing.Size(89, 20);
            this.radioButtonMojaSlika.TabIndex = 1;
            this.radioButtonMojaSlika.TabStop = true;
            this.radioButtonMojaSlika.Text = "Moja slika";
            this.radioButtonMojaSlika.UseVisualStyleBackColor = true;
            this.radioButtonMojaSlika.CheckedChanged += new System.EventHandler(this.radioButtonMojaSlika_CheckedChanged);
            // 
            // radioButtonIkonice
            // 
            this.radioButtonIkonice.AutoSize = true;
            this.radioButtonIkonice.Location = new System.Drawing.Point(6, 21);
            this.radioButtonIkonice.Name = "radioButtonIkonice";
            this.radioButtonIkonice.Size = new System.Drawing.Size(71, 20);
            this.radioButtonIkonice.TabIndex = 0;
            this.radioButtonIkonice.TabStop = true;
            this.radioButtonIkonice.Text = "Ikonice";
            this.radioButtonIkonice.UseVisualStyleBackColor = true;
            this.radioButtonIkonice.CheckedChanged += new System.EventHandler(this.radioButtonIkonice_CheckedChanged);
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.timerLabel.Location = new System.Drawing.Point(1205, 175);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(51, 25);
            this.timerLabel.TabIndex = 3;
            this.timerLabel.Text = "0:00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(1114, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Broj poteza:";
            // 
            // movesLabel
            // 
            this.movesLabel.AutoSize = true;
            this.movesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.movesLabel.Location = new System.Drawing.Point(1224, 213);
            this.movesLabel.Name = "movesLabel";
            this.movesLabel.Size = new System.Drawing.Size(23, 25);
            this.movesLabel.TabIndex = 5;
            this.movesLabel.Text = "0";
            this.movesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(1124, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Vreme:";
            // 
            // loadImageButton
            // 
            this.loadImageButton.Location = new System.Drawing.Point(1133, 513);
            this.loadImageButton.Name = "loadImageButton";
            this.loadImageButton.Size = new System.Drawing.Size(109, 39);
            this.loadImageButton.TabIndex = 7;
            this.loadImageButton.Text = "Ucitaj sliku";
            this.loadImageButton.UseVisualStyleBackColor = true;
            this.loadImageButton.Click += new System.EventHandler(this.loadImageButton_Click);
            // 
            // loadedImageLabel
            // 
            this.loadedImageLabel.Location = new System.Drawing.Point(1102, 572);
            this.loadedImageLabel.Name = "loadedImageLabel";
            this.loadedImageLabel.Size = new System.Drawing.Size(145, 53);
            this.loadedImageLabel.TabIndex = 8;
            this.loadedImageLabel.Text = "Nema slike";
            // 
            // finishGameButton
            // 
            this.finishGameButton.Location = new System.Drawing.Point(1148, 679);
            this.finishGameButton.Name = "finishGameButton";
            this.finishGameButton.Size = new System.Drawing.Size(94, 34);
            this.finishGameButton.TabIndex = 9;
            this.finishGameButton.Text = "Prekini igru";
            this.finishGameButton.UseVisualStyleBackColor = true;
            this.finishGameButton.Click += new System.EventHandler(this.finishGameButton_Click);
            // 
            // imeIgracaTextBox
            // 
            this.imeIgracaTextBox.Location = new System.Drawing.Point(1118, 38);
            this.imeIgracaTextBox.Name = "imeIgracaTextBox";
            this.imeIgracaTextBox.Size = new System.Drawing.Size(152, 22);
            this.imeIgracaTextBox.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1118, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Ime igraca";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 753);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.imeIgracaTextBox);
            this.Controls.Add(this.finishGameButton);
            this.Controls.Add(this.loadedImageLabel);
            this.Controls.Add(this.loadImageButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.movesLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.newGameButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Memory game";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_click);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton332;
        private System.Windows.Forms.RadioButton radioButton442;
        private System.Windows.Forms.RadioButton radioButton342;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonMojaSlika;
        private System.Windows.Forms.RadioButton radioButtonIkonice;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label movesLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button loadImageButton;
        private System.Windows.Forms.Label loadedImageLabel;
        private System.Windows.Forms.Button finishGameButton;
        private System.Windows.Forms.TextBox imeIgracaTextBox;
        private System.Windows.Forms.Label label3;
    }
}

