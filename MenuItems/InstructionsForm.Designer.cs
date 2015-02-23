namespace UltimateTankClash.MenuItems
{
    partial class InstructionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstructionsForm));
            this.BackButton = new System.Windows.Forms.Button();
            this.ControlsImage = new System.Windows.Forms.PictureBox();
            this.ControlsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ControlsImage)).BeginInit();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackButton.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.ForeColor = System.Drawing.Color.LightGray;
            this.BackButton.Location = new System.Drawing.Point(12, 400);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(107, 30);
            this.BackButton.TabIndex = 6;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // ControlsImage
            // 
            this.ControlsImage.BackColor = System.Drawing.Color.Transparent;
            this.ControlsImage.ErrorImage = null;
            this.ControlsImage.Image = ((System.Drawing.Image)(resources.GetObject("ControlsImage.Image")));
            this.ControlsImage.InitialImage = ((System.Drawing.Image)(resources.GetObject("ControlsImage.InitialImage")));
            this.ControlsImage.Location = new System.Drawing.Point(36, 122);
            this.ControlsImage.Name = "ControlsImage";
            this.ControlsImage.Size = new System.Drawing.Size(164, 163);
            this.ControlsImage.TabIndex = 7;
            this.ControlsImage.TabStop = false;
            // 
            // ControlsLabel
            // 
            this.ControlsLabel.AutoSize = true;
            this.ControlsLabel.BackColor = System.Drawing.Color.Transparent;
            this.ControlsLabel.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ControlsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(11)))));
            this.ControlsLabel.Location = new System.Drawing.Point(38, 65);
            this.ControlsLabel.Name = "ControlsLabel";
            this.ControlsLabel.Size = new System.Drawing.Size(162, 29);
            this.ControlsLabel.TabIndex = 8;
            this.ControlsLabel.Text = "Player Controls";
            // 
            // InstructionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.ControlsLabel);
            this.Controls.Add(this.ControlsImage);
            this.Controls.Add(this.BackButton);
            this.Name = "InstructionsForm";
            this.Text = "InstructionsForm";
            ((System.ComponentModel.ISupportInitialize)(this.ControlsImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.PictureBox ControlsImage;
        private System.Windows.Forms.Label ControlsLabel;

    }
}