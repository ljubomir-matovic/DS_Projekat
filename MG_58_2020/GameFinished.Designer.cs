namespace MG_58_2020
{
    partial class GameFinished
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
            this.label1 = new System.Windows.Forms.Label();
            this.scoreGridView = new System.Windows.Forms.DataGridView();
            this.Mesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vreme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrojPoteza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.scoreGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(309, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 58);
            this.label1.TabIndex = 0;
            this.label1.Text = "Score";
            // 
            // scoreGridView
            // 
            this.scoreGridView.AllowUserToAddRows = false;
            this.scoreGridView.AllowUserToDeleteRows = false;
            this.scoreGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.scoreGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.scoreGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Mesto,
            this.Ime,
            this.Vreme,
            this.BrojPoteza});
            this.scoreGridView.Location = new System.Drawing.Point(33, 102);
            this.scoreGridView.MultiSelect = false;
            this.scoreGridView.Name = "scoreGridView";
            this.scoreGridView.ReadOnly = true;
            this.scoreGridView.RowHeadersWidth = 51;
            this.scoreGridView.RowTemplate.Height = 24;
            this.scoreGridView.RowTemplate.ReadOnly = true;
            this.scoreGridView.Size = new System.Drawing.Size(755, 311);
            this.scoreGridView.TabIndex = 1;
            // 
            // Mesto
            // 
            this.Mesto.HeaderText = "Mesto";
            this.Mesto.MinimumWidth = 6;
            this.Mesto.Name = "Mesto";
            this.Mesto.ReadOnly = true;
            // 
            // Ime
            // 
            this.Ime.HeaderText = "Ime";
            this.Ime.MinimumWidth = 6;
            this.Ime.Name = "Ime";
            this.Ime.ReadOnly = true;
            // 
            // Vreme
            // 
            this.Vreme.HeaderText = "Vreme";
            this.Vreme.MinimumWidth = 6;
            this.Vreme.Name = "Vreme";
            this.Vreme.ReadOnly = true;
            // 
            // BrojPoteza
            // 
            this.BrojPoteza.HeaderText = "Broj poteza";
            this.BrojPoteza.MinimumWidth = 6;
            this.BrojPoteza.Name = "BrojPoteza";
            this.BrojPoteza.ReadOnly = true;
            // 
            // GameFinished
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.scoreGridView);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameFinished";
            this.Text = "Score";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.onClose);
            ((System.ComponentModel.ISupportInitialize)(this.scoreGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView scoreGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vreme;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrojPoteza;
    }
}