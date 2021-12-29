
namespace ProgettoNatale
{
    partial class Azioni
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
            this.View_Kids = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.View_Gifts = new System.Windows.Forms.Button();
            this.See_Map = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // View_Kids
            // 
            this.View_Kids.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.View_Kids.Location = new System.Drawing.Point(32, 102);
            this.View_Kids.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.View_Kids.Name = "View_Kids";
            this.View_Kids.Size = new System.Drawing.Size(195, 93);
            this.View_Kids.TabIndex = 0;
            this.View_Kids.Text = "BAMBINI";
            this.View_Kids.UseVisualStyleBackColor = true;
            this.View_Kids.Click += new System.EventHandler(this.View_Kids_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(26, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(620, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "QUESTE SONO LE TUE AZIONI DISPONIBILI";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // View_Gifts
            // 
            this.View_Gifts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.View_Gifts.ForeColor = System.Drawing.SystemColors.ControlText;
            this.View_Gifts.Location = new System.Drawing.Point(214, 260);
            this.View_Gifts.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.View_Gifts.Name = "View_Gifts";
            this.View_Gifts.Size = new System.Drawing.Size(195, 93);
            this.View_Gifts.TabIndex = 3;
            this.View_Gifts.Text = "REGALI";
            this.View_Gifts.UseVisualStyleBackColor = true;
            this.View_Gifts.Click += new System.EventHandler(this.View_Gifts_Click);
            // 
            // See_Map
            // 
            this.See_Map.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.See_Map.Location = new System.Drawing.Point(397, 102);
            this.See_Map.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.See_Map.Name = "See_Map";
            this.See_Map.Size = new System.Drawing.Size(195, 93);
            this.See_Map.TabIndex = 4;
            this.See_Map.Text = "MAPPA";
            this.See_Map.UseVisualStyleBackColor = true;
            this.See_Map.Click += new System.EventHandler(this.button1_Click);
            // 
            // Azioni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProgettoNatale.Properties.Resources.Sfondo_Azioni;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(603, 375);
            this.Controls.Add(this.See_Map);
            this.Controls.Add(this.View_Gifts);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.View_Kids);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximumSize = new System.Drawing.Size(619, 414);
            this.MinimumSize = new System.Drawing.Size(619, 414);
            this.Name = "Azioni";
            this.Text = "Azioni";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button View_Kids;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button View_Gifts;
        private System.Windows.Forms.Button See_Map;
    }
}