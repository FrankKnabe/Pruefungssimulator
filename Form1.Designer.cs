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
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrueflingsID = new System.Windows.Forms.TextBox();
            this.cmdAnmeldung = new System.Windows.Forms.Button();
            this.lblGreetings = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
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
            this.cmdBegin.Visible = false;
            this.cmdBegin.Click += new System.EventHandler(this.cmdBegin_Click);
            // 
            // cmdEnd2
            // 
            this.cmdEnd2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdEnd2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEnd2.Location = new System.Drawing.Point(566, 272);
            this.cmdEnd2.Name = "cmdEnd2";
            this.cmdEnd2.Size = new System.Drawing.Size(115, 47);
            this.cmdEnd2.TabIndex = 5;
            this.cmdEnd2.Text = "Beenden";
            this.cmdEnd2.UseVisualStyleBackColor = true;
            this.cmdEnd2.Click += new System.EventHandler(this.cmdEnd2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Vorname";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(89, 89);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(175, 20);
            this.txtName.TabIndex = 1;
            this.txtName.Text = "Prometheus";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Prüflings-ID";
            // 
            // txtPrueflingsID
            // 
            this.txtPrueflingsID.Location = new System.Drawing.Point(89, 121);
            this.txtPrueflingsID.Name = "txtPrueflingsID";
            this.txtPrueflingsID.Size = new System.Drawing.Size(175, 20);
            this.txtPrueflingsID.TabIndex = 3;
            this.txtPrueflingsID.Text = "10001";
            // 
            // cmdAnmeldung
            // 
            this.cmdAnmeldung.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAnmeldung.Location = new System.Drawing.Point(89, 160);
            this.cmdAnmeldung.Name = "cmdAnmeldung";
            this.cmdAnmeldung.Size = new System.Drawing.Size(116, 42);
            this.cmdAnmeldung.TabIndex = 4;
            this.cmdAnmeldung.Text = "Anmeldung";
            this.cmdAnmeldung.UseVisualStyleBackColor = true;
            this.cmdAnmeldung.Click += new System.EventHandler(this.cmdAnmeldung_Click);
            // 
            // lblGreetings
            // 
            this.lblGreetings.AutoSize = true;
            this.lblGreetings.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGreetings.Location = new System.Drawing.Point(41, 249);
            this.lblGreetings.Name = "lblGreetings";
            this.lblGreetings.Size = new System.Drawing.Size(0, 20);
            this.lblGreetings.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(271, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Nachname";
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(336, 89);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(175, 20);
            this.txtSurname.TabIndex = 2;
            this.txtSurname.Text = "First";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 433);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblGreetings);
            this.Controls.Add(this.cmdAnmeldung);
            this.Controls.Add(this.txtPrueflingsID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
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

        private System.Windows.Forms.Button cmdEnd2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrueflingsID;
        private System.Windows.Forms.Button cmdAnmeldung;
        private System.Windows.Forms.Label lblGreetings;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.Button cmdBegin;
    }
}

