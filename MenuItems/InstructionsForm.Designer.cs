namespace UltimateTankClash.MenuItems
{
    using System.ComponentModel;
    using System.Windows.Forms;

    public partial class InstructionsForm
    {
        private Button backButton;
        private PictureBox controlsImage;
        private Label controlsLabel;
        private Label extraPacksLbl;
        private PictureBox pauseBtn;
        private PictureBox muteBtn;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstructionsForm));
            this.backButton = new System.Windows.Forms.Button();
            this.controlsImage = new System.Windows.Forms.PictureBox();
            this.controlsLabel = new System.Windows.Forms.Label();
            this.extraPacksLbl = new System.Windows.Forms.Label();
            this.pauseBtn = new System.Windows.Forms.PictureBox();
            this.muteBtn = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.EnemiesLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.controlsImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pauseBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.muteBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.ForeColor = System.Drawing.Color.LightGray;
            this.backButton.Location = new System.Drawing.Point(12, 400);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(107, 30);
            this.backButton.TabIndex = 6;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // controlsImage
            // 
            this.controlsImage.BackColor = System.Drawing.Color.Transparent;
            this.controlsImage.ErrorImage = null;
            this.controlsImage.Image = ((System.Drawing.Image)(resources.GetObject("controlsImage.Image")));
            this.controlsImage.InitialImage = ((System.Drawing.Image)(resources.GetObject("controlsImage.InitialImage")));
            this.controlsImage.Location = new System.Drawing.Point(12, 122);
            this.controlsImage.Name = "controlsImage";
            this.controlsImage.Size = new System.Drawing.Size(164, 163);
            this.controlsImage.TabIndex = 7;
            this.controlsImage.TabStop = false;
            // 
            // controlsLabel
            // 
            this.controlsLabel.AutoSize = true;
            this.controlsLabel.BackColor = System.Drawing.Color.Transparent;
            this.controlsLabel.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(11)))));
            this.controlsLabel.Location = new System.Drawing.Point(5, 65);
            this.controlsLabel.Name = "controlsLabel";
            this.controlsLabel.Size = new System.Drawing.Size(162, 29);
            this.controlsLabel.TabIndex = 8;
            this.controlsLabel.Text = "Player Controls";
            // 
            // extraPacksLbl
            // 
            this.extraPacksLbl.AutoSize = true;
            this.extraPacksLbl.BackColor = System.Drawing.Color.Transparent;
            this.extraPacksLbl.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extraPacksLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(11)))));
            this.extraPacksLbl.Location = new System.Drawing.Point(177, 65);
            this.extraPacksLbl.Name = "extraPacksLbl";
            this.extraPacksLbl.Size = new System.Drawing.Size(127, 29);
            this.extraPacksLbl.TabIndex = 10;
            this.extraPacksLbl.Text = "Extra Packs:";
            // 
            // pauseBtn
            // 
            this.pauseBtn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pauseBtn.Image = global::UltimateTankClash.Properties.Resources.pause;
            this.pauseBtn.Location = new System.Drawing.Point(10, 300);
            this.pauseBtn.Name = "pauseBtn";
            this.pauseBtn.Size = new System.Drawing.Size(60, 60);
            this.pauseBtn.TabIndex = 11;
            this.pauseBtn.TabStop = false;
            // 
            // muteBtn
            // 
            this.muteBtn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.muteBtn.Image = global::UltimateTankClash.Properties.Resources.mute;
            this.muteBtn.Location = new System.Drawing.Point(114, 300);
            this.muteBtn.Name = "muteBtn";
            this.muteBtn.Size = new System.Drawing.Size(60, 60);
            this.muteBtn.TabIndex = 12;
            this.muteBtn.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = global::UltimateTankClash.Properties.Resources.consumables;
            this.pictureBox1.Location = new System.Drawing.Point(182, 122);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(206, 272);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pictureBox2.Image = global::UltimateTankClash.Properties.Resources.tanks;
            this.pictureBox2.Location = new System.Drawing.Point(401, 122);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(211, 272);
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // EnemiesLbl
            // 
            this.EnemiesLbl.AutoSize = true;
            this.EnemiesLbl.BackColor = System.Drawing.Color.Transparent;
            this.EnemiesLbl.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnemiesLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(11)))));
            this.EnemiesLbl.Location = new System.Drawing.Point(396, 65);
            this.EnemiesLbl.Name = "EnemiesLbl";
            this.EnemiesLbl.Size = new System.Drawing.Size(101, 29);
            this.EnemiesLbl.TabIndex = 15;
            this.EnemiesLbl.Text = "Enemies:";
            // 
            // InstructionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.EnemiesLbl);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.muteBtn);
            this.Controls.Add(this.pauseBtn);
            this.Controls.Add(this.extraPacksLbl);
            this.Controls.Add(this.controlsLabel);
            this.Controls.Add(this.controlsImage);
            this.Controls.Add(this.backButton);
            this.Name = "InstructionsForm";
            this.Text = "InstructionsForm";
            ((System.ComponentModel.ISupportInitialize)(this.controlsImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pauseBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.muteBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label EnemiesLbl;
    }
}