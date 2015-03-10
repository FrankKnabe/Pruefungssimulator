namespace PrüfungsSimulator
{
    partial class Form2
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
            this.cmdWeiter = new System.Windows.Forms.Button();
            this.cmdZurueck = new System.Windows.Forms.Button();
            this.lblFrage = new System.Windows.Forms.Label();
            this.cmdEnd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.eHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdWeiter
            // 
            this.cmdWeiter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdWeiter.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdWeiter.Location = new System.Drawing.Point(546, 332);
            this.cmdWeiter.Name = "cmdWeiter";
            this.cmdWeiter.Size = new System.Drawing.Size(115, 47);
            this.cmdWeiter.TabIndex = 0;
            this.cmdWeiter.Text = "Weiter";
            this.cmdWeiter.UseVisualStyleBackColor = true;
            this.cmdWeiter.Click += new System.EventHandler(this.cmdWeiter_Click);
            // 
            // cmdZurueck
            // 
            this.cmdZurueck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdZurueck.Enabled = false;
            this.cmdZurueck.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdZurueck.Location = new System.Drawing.Point(12, 332);
            this.cmdZurueck.Name = "cmdZurueck";
            this.cmdZurueck.Size = new System.Drawing.Size(115, 47);
            this.cmdZurueck.TabIndex = 1;
            this.cmdZurueck.Text = "Zurück";
            this.cmdZurueck.UseVisualStyleBackColor = true;
            this.cmdZurueck.Click += new System.EventHandler(this.cmdZurueck_Click);
            // 
            // lblFrage
            // 
            this.lblFrage.AutoSize = true;
            this.lblFrage.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrage.Location = new System.Drawing.Point(12, 9);
            this.lblFrage.Name = "lblFrage";
            this.lblFrage.Size = new System.Drawing.Size(0, 20);
            this.lblFrage.TabIndex = 2;
            // 
            // cmdEnd
            // 
            this.cmdEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdEnd.Enabled = false;
            this.cmdEnd.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEnd.Location = new System.Drawing.Point(546, 235);
            this.cmdEnd.Name = "cmdEnd";
            this.cmdEnd.Size = new System.Drawing.Size(115, 47);
            this.cmdEnd.TabIndex = 3;
            this.cmdEnd.Text = "Beenden";
            this.cmdEnd.UseVisualStyleBackColor = true;
            this.cmdEnd.Click += new System.EventHandler(this.cmdEnd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.eHost1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 210);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Antwortmöglichkeiten";
            // 
            // eHost1
            // 
            this.eHost1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eHost1.AutoSize = true;
            this.eHost1.BackColor = System.Drawing.SystemColors.Control;
            this.eHost1.Location = new System.Drawing.Point(3, 24);
            this.eHost1.Name = "eHost1";
            this.eHost1.Size = new System.Drawing.Size(1, 1);
            this.eHost1.TabIndex = 0;
            this.eHost1.Child = null;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 444);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdEnd);
            this.Controls.Add(this.lblFrage);
            this.Controls.Add(this.cmdZurueck);
            this.Controls.Add(this.cmdWeiter);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.Text = "Prüfungsbildschirm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdWeiter;
        private System.Windows.Forms.Button cmdZurueck;
        private System.Windows.Forms.Label lblFrage;
        private System.Windows.Forms.Button cmdEnd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Integration.ElementHost eHost1;
    }
}