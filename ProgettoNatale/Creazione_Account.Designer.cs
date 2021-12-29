namespace ProgettoNatale
{
    partial class Creazione_Account
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.radioElfo = new System.Windows.Forms.RadioButton();
            this.radioBabbo = new System.Windows.Forms.RadioButton();
            this.Crea_Account = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Password:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(14, 113);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(338, 20);
            this.textBox2.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Username:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(14, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(338, 20);
            this.textBox1.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "Tipo di Account:";
            // 
            // radioElfo
            // 
            this.radioElfo.AutoSize = true;
            this.radioElfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioElfo.Location = new System.Drawing.Point(16, 218);
            this.radioElfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioElfo.Name = "radioElfo";
            this.radioElfo.Size = new System.Drawing.Size(73, 24);
            this.radioElfo.TabIndex = 17;
            this.radioElfo.TabStop = true;
            this.radioElfo.Text = "ELFO";
            this.radioElfo.UseVisualStyleBackColor = true;
            this.radioElfo.CheckedChanged += new System.EventHandler(this.radioBabbo_CheckedChanged);
            // 
            // radioBabbo
            // 
            this.radioBabbo.AutoSize = true;
            this.radioBabbo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBabbo.Location = new System.Drawing.Point(16, 189);
            this.radioBabbo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioBabbo.Name = "radioBabbo";
            this.radioBabbo.Size = new System.Drawing.Size(161, 24);
            this.radioBabbo.TabIndex = 18;
            this.radioBabbo.TabStop = true;
            this.radioBabbo.Text = "BABBO NATALE";
            this.radioBabbo.UseVisualStyleBackColor = true;
            this.radioBabbo.CheckedChanged += new System.EventHandler(this.radioBabbo_CheckedChanged);
            // 
            // Crea_Account
            // 
            this.Crea_Account.BackColor = System.Drawing.Color.White;
            this.Crea_Account.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Crea_Account.Location = new System.Drawing.Point(14, 275);
            this.Crea_Account.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Crea_Account.Name = "Crea_Account";
            this.Crea_Account.Size = new System.Drawing.Size(242, 65);
            this.Crea_Account.TabIndex = 19;
            this.Crea_Account.Text = "CREA ACCOUNT";
            this.Crea_Account.UseVisualStyleBackColor = false;
            this.Crea_Account.Click += new System.EventHandler(this.Crea_Account_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::ProgettoNatale.Properties.Resources.animated_santa_claus;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(502, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(271, 99);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // Creazione_Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(10)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(782, 366);
            this.Controls.Add(this.Crea_Account);
            this.Controls.Add(this.radioBabbo);
            this.Controls.Add(this.radioElfo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Creazione_Account";
            this.Text = "Creazione_Account";
            this.Load += new System.EventHandler(this.Creazione_Account_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioElfo;
        private System.Windows.Forms.RadioButton radioBabbo;
        private System.Windows.Forms.Button Crea_Account;
    }
}