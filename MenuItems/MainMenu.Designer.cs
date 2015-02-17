namespace UltimateTankClash.MenuItems
{
    partial class MainMenu
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
            this.startGame = new System.Windows.Forms.Button();
            this.gameName = new System.Windows.Forms.Label();
            this.MultiPlayerStart = new System.Windows.Forms.Button();
            this.Options = new System.Windows.Forms.Button();
            this.Instructions = new System.Windows.Forms.Button();
            this.About = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startGame
            // 
            this.startGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.startGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startGame.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startGame.ForeColor = System.Drawing.Color.LightGray;
            this.startGame.Location = new System.Drawing.Point(265, 131);
            this.startGame.Name = "startGame";
            this.startGame.Size = new System.Drawing.Size(107, 32);
            this.startGame.TabIndex = 1;
            this.startGame.Text = "Single Player";
            this.startGame.UseVisualStyleBackColor = false;
            this.startGame.Click += new System.EventHandler(this.startGame_Click);
            // 
            // gameName
            // 
            this.gameName.AutoSize = true;
            this.gameName.BackColor = System.Drawing.Color.Transparent;
            this.gameName.Font = new System.Drawing.Font("Impact", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(11)))));
            this.gameName.Location = new System.Drawing.Point(40, 9);
            this.gameName.Name = "gameName";
            this.gameName.Size = new System.Drawing.Size(553, 80);
            this.gameName.TabIndex = 0;
            this.gameName.Text = "Ultimate Tank Clash";
            // 
            // MultiPlayerStart
            // 
            this.MultiPlayerStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.MultiPlayerStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MultiPlayerStart.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MultiPlayerStart.ForeColor = System.Drawing.Color.LightGray;
            this.MultiPlayerStart.Location = new System.Drawing.Point(265, 169);
            this.MultiPlayerStart.Name = "MultiPlayerStart";
            this.MultiPlayerStart.Size = new System.Drawing.Size(107, 30);
            this.MultiPlayerStart.TabIndex = 2;
            this.MultiPlayerStart.Text = "Multiplayer";
            this.MultiPlayerStart.UseVisualStyleBackColor = false;
            // 
            // Options
            // 
            this.Options.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Options.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Options.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Options.ForeColor = System.Drawing.Color.LightGray;
            this.Options.Location = new System.Drawing.Point(265, 205);
            this.Options.Name = "Options";
            this.Options.Size = new System.Drawing.Size(107, 30);
            this.Options.TabIndex = 3;
            this.Options.Text = "Options";
            this.Options.UseVisualStyleBackColor = false;
            this.Options.Click += new System.EventHandler(this.Options_Click);
            // 
            // Instructions
            // 
            this.Instructions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Instructions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Instructions.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Instructions.ForeColor = System.Drawing.Color.LightGray;
            this.Instructions.Location = new System.Drawing.Point(265, 241);
            this.Instructions.Name = "Instructions";
            this.Instructions.Size = new System.Drawing.Size(107, 30);
            this.Instructions.TabIndex = 4;
            this.Instructions.Text = "Instructions";
            this.Instructions.UseVisualStyleBackColor = false;
            this.Instructions.Click += new System.EventHandler(this.Instructions_Click);
            // 
            // About
            // 
            this.About.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.About.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.About.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.About.ForeColor = System.Drawing.Color.LightGray;
            this.About.Location = new System.Drawing.Point(265, 279);
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(107, 30);
            this.About.TabIndex = 5;
            this.About.Text = "About";
            this.About.UseVisualStyleBackColor = false;
            this.About.Click += new System.EventHandler(this.About_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.ForeColor = System.Drawing.Color.LightGray;
            this.ExitButton.Location = new System.Drawing.Point(265, 315);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(107, 30);
            this.ExitButton.TabIndex = 6;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.About);
            this.Controls.Add(this.Instructions);
            this.Controls.Add(this.Options);
            this.Controls.Add(this.MultiPlayerStart);
            this.Controls.Add(this.gameName);
            this.Controls.Add(this.startGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MainMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startGame;
        private System.Windows.Forms.Label gameName;
        private System.Windows.Forms.Button MultiPlayerStart;
        private System.Windows.Forms.Button Options;
        private System.Windows.Forms.Button Instructions;
        private System.Windows.Forms.Button About;
        private System.Windows.Forms.Button ExitButton;
    }
}