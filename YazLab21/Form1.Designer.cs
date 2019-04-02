namespace YazLab21
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.kapat = new System.Windows.Forms.Button();
            this.Open_File = new System.Windows.Forms.Button();
            this.groupBoxPuzzle = new System.Windows.Forms.GroupBox();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.high_score = new System.Windows.Forms.Label();
            this.shuffle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // kapat
            // 
            this.kapat.BackColor = System.Drawing.Color.DarkViolet;
            this.kapat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kapat.FlatAppearance.BorderSize = 0;
            this.kapat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kapat.Image = ((System.Drawing.Image)(resources.GetObject("kapat.Image")));
            this.kapat.Location = new System.Drawing.Point(764, 0);
            this.kapat.Name = "kapat";
            this.kapat.Size = new System.Drawing.Size(36, 43);
            this.kapat.TabIndex = 0;
            this.kapat.UseVisualStyleBackColor = false;
            this.kapat.Click += new System.EventHandler(this.kapat_Click);
            // 
            // Open_File
            // 
            this.Open_File.Image = ((System.Drawing.Image)(resources.GetObject("Open_File.Image")));
            this.Open_File.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Open_File.Location = new System.Drawing.Point(686, 408);
            this.Open_File.Name = "Open_File";
            this.Open_File.Size = new System.Drawing.Size(102, 30);
            this.Open_File.TabIndex = 1;
            this.Open_File.Text = "Dosya Aç";
            this.Open_File.UseVisualStyleBackColor = true;
            this.Open_File.Click += new System.EventHandler(this.Open_File_Click);
            // 
            // groupBoxPuzzle
            // 
            this.groupBoxPuzzle.Location = new System.Drawing.Point(12, 24);
            this.groupBoxPuzzle.Name = "groupBoxPuzzle";
            this.groupBoxPuzzle.Size = new System.Drawing.Size(540, 414);
            this.groupBoxPuzzle.TabIndex = 2;
            this.groupBoxPuzzle.TabStop = false;
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(558, 379);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(230, 23);
            this.progress.TabIndex = 3;
            this.progress.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.Location = new System.Drawing.Point(624, 359);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 4;
            this.label1.Visible = false;
            // 
            // high_score
            // 
            this.high_score.AutoSize = true;
            this.high_score.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.high_score.Location = new System.Drawing.Point(624, 58);
            this.high_score.Name = "high_score";
            this.high_score.Size = new System.Drawing.Size(0, 17);
            this.high_score.TabIndex = 5;
            // 
            // shuffle
            // 
            this.shuffle.Location = new System.Drawing.Point(686, 310);
            this.shuffle.Name = "shuffle";
            this.shuffle.Size = new System.Drawing.Size(102, 23);
            this.shuffle.TabIndex = 6;
            this.shuffle.Text = "Karıştır";
            this.shuffle.UseVisualStyleBackColor = true;
            this.shuffle.Click += new System.EventHandler(this.shuffle_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkViolet;
            this.ClientSize = new System.Drawing.Size(800, 461);
            this.ControlBox = false;
            this.Controls.Add(this.shuffle);
            this.Controls.Add(this.high_score);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.groupBoxPuzzle);
            this.Controls.Add(this.Open_File);
            this.Controls.Add(this.kapat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button kapat;
        private System.Windows.Forms.Button Open_File;
        private System.Windows.Forms.GroupBox groupBoxPuzzle;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label high_score;
        private System.Windows.Forms.Button shuffle;
    }
}

