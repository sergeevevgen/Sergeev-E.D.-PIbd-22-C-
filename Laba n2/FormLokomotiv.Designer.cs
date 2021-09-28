
namespace Laba_n2
{
    partial class FormLokomotiv
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLokomotiv));
            this.pictureBoxLokomotiv = new System.Windows.Forms.PictureBox();
            this.buttonCreateLokomotiv = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonRight = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.buttonCreateMonoRels = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLokomotiv)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxLokomotiv
            // 
            this.pictureBoxLokomotiv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxLokomotiv.Location = new System.Drawing.Point(1, 0);
            this.pictureBoxLokomotiv.Name = "pictureBoxLokomotiv";
            this.pictureBoxLokomotiv.Size = new System.Drawing.Size(688, 450);
            this.pictureBoxLokomotiv.TabIndex = 1;
            this.pictureBoxLokomotiv.TabStop = false;
            // 
            // buttonCreateLokomotiv
            // 
            this.buttonCreateLokomotiv.Location = new System.Drawing.Point(759, 12);
            this.buttonCreateLokomotiv.Name = "buttonCreateLokomotiv";
            this.buttonCreateLokomotiv.Size = new System.Drawing.Size(75, 35);
            this.buttonCreateLokomotiv.TabIndex = 2;
            this.buttonCreateLokomotiv.Text = "Создать Локомотив";
            this.buttonCreateLokomotiv.UseVisualStyleBackColor = true;
            this.buttonCreateLokomotiv.Click += new System.EventHandler(this.buttonCreateLokomotiv_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonUp.BackgroundImage")));
            this.buttonUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonUp.Location = new System.Drawing.Point(768, 376);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(30, 30);
            this.buttonUp.TabIndex = 3;
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonRight
            // 
            this.buttonRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonRight.BackgroundImage")));
            this.buttonRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonRight.Location = new System.Drawing.Point(804, 412);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(30, 30);
            this.buttonRight.TabIndex = 6;
            this.buttonRight.UseVisualStyleBackColor = true;
            this.buttonRight.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonDown.BackgroundImage")));
            this.buttonDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonDown.Location = new System.Drawing.Point(768, 412);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(30, 30);
            this.buttonDown.TabIndex = 7;
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonLeft
            // 
            this.buttonLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonLeft.BackgroundImage")));
            this.buttonLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonLeft.Location = new System.Drawing.Point(732, 412);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(30, 30);
            this.buttonLeft.TabIndex = 8;
            this.buttonLeft.UseVisualStyleBackColor = true;
            this.buttonLeft.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonCreateMonoRels
            // 
            this.buttonCreateMonoRels.Location = new System.Drawing.Point(759, 64);
            this.buttonCreateMonoRels.Name = "buttonCreateMonoRels";
            this.buttonCreateMonoRels.Size = new System.Drawing.Size(75, 34);
            this.buttonCreateMonoRels.TabIndex = 9;
            this.buttonCreateMonoRels.Text = "Создать Монорельс";
            this.buttonCreateMonoRels.UseVisualStyleBackColor = true;
            this.buttonCreateMonoRels.Click += new System.EventHandler(this.buttonCreateMonoRels_Click);
            // 
            // FormLokomotiv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 450);
            this.Controls.Add(this.buttonCreateMonoRels);
            this.Controls.Add(this.buttonLeft);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.buttonRight);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.buttonCreateLokomotiv);
            this.Controls.Add(this.pictureBoxLokomotiv);
            this.Name = "FormLokomotiv";
            this.Text = "Локомотив и Монорельс";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLokomotiv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxLokomotiv;
        private System.Windows.Forms.Button buttonCreateLokomotiv;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonRight;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.Button buttonCreateMonoRels;
    }
}

