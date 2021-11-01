
namespace Laba_n2
{
    partial class FormDepo
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
            this.pictureBoxDepo = new System.Windows.Forms.PictureBox();
            this.buttonSetLokomotiv = new System.Windows.Forms.Button();
            this.buttonSetMonoRels = new System.Windows.Forms.Button();
            this.groupBoxTake = new System.Windows.Forms.GroupBox();
            this.buttonTake = new System.Windows.Forms.Button();
            this.maskedTextBoxTake = new System.Windows.Forms.MaskedTextBox();
            this.labelNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDepo)).BeginInit();
            this.groupBoxTake.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxDepo
            // 
            this.pictureBoxDepo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxDepo.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxDepo.Name = "pictureBoxDepo";
            this.pictureBoxDepo.Size = new System.Drawing.Size(675, 450);
            this.pictureBoxDepo.TabIndex = 0;
            this.pictureBoxDepo.TabStop = false;
            // 
            // buttonSetLokomotiv
            // 
            this.buttonSetLokomotiv.Location = new System.Drawing.Point(700, 12);
            this.buttonSetLokomotiv.Name = "buttonSetLokomotiv";
            this.buttonSetLokomotiv.Size = new System.Drawing.Size(88, 56);
            this.buttonSetLokomotiv.TabIndex = 1;
            this.buttonSetLokomotiv.Text = "Припарковать локомотив";
            this.buttonSetLokomotiv.UseVisualStyleBackColor = true;
            this.buttonSetLokomotiv.Click += new System.EventHandler(this.buttonSetLokomotiv_Click);
            // 
            // buttonSetMonoRels
            // 
            this.buttonSetMonoRels.Location = new System.Drawing.Point(700, 74);
            this.buttonSetMonoRels.Name = "buttonSetMonoRels";
            this.buttonSetMonoRels.Size = new System.Drawing.Size(88, 57);
            this.buttonSetMonoRels.TabIndex = 2;
            this.buttonSetMonoRels.Text = "Припарковать монорельс";
            this.buttonSetMonoRels.UseVisualStyleBackColor = true;
            this.buttonSetMonoRels.Click += new System.EventHandler(this.buttonSetMonoRels_Click);
            // 
            // groupBoxTake
            // 
            this.groupBoxTake.Controls.Add(this.buttonTake);
            this.groupBoxTake.Controls.Add(this.maskedTextBoxTake);
            this.groupBoxTake.Controls.Add(this.labelNumber);
            this.groupBoxTake.Location = new System.Drawing.Point(690, 148);
            this.groupBoxTake.Name = "groupBoxTake";
            this.groupBoxTake.Size = new System.Drawing.Size(108, 100);
            this.groupBoxTake.TabIndex = 3;
            this.groupBoxTake.TabStop = false;
            this.groupBoxTake.Text = "Забрать т/с";
            // 
            // buttonTake
            // 
            this.buttonTake.Location = new System.Drawing.Point(13, 71);
            this.buttonTake.Name = "buttonTake";
            this.buttonTake.Size = new System.Drawing.Size(75, 23);
            this.buttonTake.TabIndex = 2;
            this.buttonTake.Text = "Забрать";
            this.buttonTake.UseVisualStyleBackColor = true;
            this.buttonTake.Click += new System.EventHandler(this.buttonTake_Click);
            // 
            // maskedTextBoxTake
            // 
            this.maskedTextBoxTake.Location = new System.Drawing.Point(70, 31);
            this.maskedTextBoxTake.Mask = "00000";
            this.maskedTextBoxTake.Name = "maskedTextBoxTake";
            this.maskedTextBoxTake.Size = new System.Drawing.Size(31, 20);
            this.maskedTextBoxTake.TabIndex = 1;
            this.maskedTextBoxTake.ValidatingType = typeof(int);
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Location = new System.Drawing.Point(6, 31);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(42, 13);
            this.labelNumber.TabIndex = 0;
            this.labelNumber.Text = "Место:";
            // 
            // FromDepo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxTake);
            this.Controls.Add(this.buttonSetMonoRels);
            this.Controls.Add(this.buttonSetLokomotiv);
            this.Controls.Add(this.pictureBoxDepo);
            this.Name = "FromDepo";
            this.Text = "Депо";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDepo)).EndInit();
            this.groupBoxTake.ResumeLayout(false);
            this.groupBoxTake.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxDepo;
        private System.Windows.Forms.Button buttonSetLokomotiv;
        private System.Windows.Forms.Button buttonSetMonoRels;
        private System.Windows.Forms.GroupBox groupBoxTake;
        private System.Windows.Forms.Button buttonTake;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTake;
        private System.Windows.Forms.Label labelNumber;
    }
}