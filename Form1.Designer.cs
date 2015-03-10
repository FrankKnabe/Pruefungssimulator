namespace PrüfungsSimulator
{
    partial class Form1
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
            this.cmdBegin = new System.Windows.Forms.Button();
            this.cmdEnd2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdBegin
            // 
            this.cmdBegin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBegin.AutoSize = true;
            this.cmdBegin.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBegin.Location = new System.Drawing.Point(566, 344);
            this.cmdBegin.Name = "cmdBegin";
            this.cmdBegin.Size = new System.Drawing.Size(110, 37);
            this.cmdBegin.TabIndex = 0;
            this.cmdBegin.Text = "Start";
            this.cmdBegin.UseVisualStyleBackColor = true;
            this.cmdBegin.Click += new System.EventHandler(this.cmdBegin_Click);
            // 
            // cmdEnd2
            // 
            this.cmdEnd2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdEnd2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEnd2.Location = new System.Drawing.Point(566, 272);
            this.cmdEnd2.Name = "cmdEnd2";
            this.cmdEnd2.Size = new System.Drawing.Size(115, 47);
            this.cmdEnd2.TabIndex = 4;
            this.cmdEnd2.Text = "Beenden";
            this.cmdEnd2.UseVisualStyleBackColor = true;
            this.cmdEnd2.Click += new System.EventHandler(this.cmdEnd2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 433);
            this.Controls.Add(this.cmdEnd2);
            this.Controls.Add(this.cmdBegin);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Startbildschirm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdBegin;
        private System.Windows.Forms.Button cmdEnd2;
    }
}

