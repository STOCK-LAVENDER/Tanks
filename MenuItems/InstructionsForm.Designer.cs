namespace UltimateTankClash.MenuItems
{
    using System.ComponentModel;
    using System.Windows.Forms;

    public partial class InstructionsForm
    {
        private Button backButton;
        private PictureBox controlsImage;
        private Label controlsLabel;

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
            ((System.ComponentModel.ISupportInitialize)(this.controlsImage)).BeginInit();
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
            this.controlsImage.Location = new System.Drawing.Point(36, 122);
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
            this.controlsLabel.Location = new System.Drawing.Point(38, 65);
            this.controlsLabel.Name = "controlsLabel";
            this.controlsLabel.Size = new System.Drawing.Size(162, 29);
            this.controlsLabel.TabIndex = 8;
            this.controlsLabel.Text = "Player Controls";
            // 
            // InstructionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.controlsLabel);
            this.Controls.Add(this.controlsImage);
            this.Controls.Add(this.backButton);
            this.Name = "InstructionsForm";
            this.Text = "InstructionsForm";
            ((System.ComponentModel.ISupportInitialize)(this.controlsImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}