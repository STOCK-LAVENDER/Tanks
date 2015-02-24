namespace UltimateTankClash.MenuItems
{
    using System.ComponentModel;
    using System.Windows.Forms;

    public partial class MainMenu
    {
        private Button startGame;
        private Label gameName;
        private Button multiPlayerStart;
        private Button options;
        private Button instructions;
        private Button about;
        private Button exitButton;

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
            this.startGame = new System.Windows.Forms.Button();
            this.gameName = new System.Windows.Forms.Label();
            this.multiPlayerStart = new System.Windows.Forms.Button();
            this.options = new System.Windows.Forms.Button();
            this.instructions = new System.Windows.Forms.Button();
            this.about = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
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
            this.startGame.Click += new System.EventHandler(this.StartGameOnClick);
            // 
            // gameName
            // 
            this.gameName.AutoSize = true;
            this.gameName.BackColor = System.Drawing.Color.Transparent;
            this.gameName.Font = new System.Drawing.Font("Impact", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(11)))));
            this.gameName.Location = new System.Drawing.Point(40, 9);
            this.gameName.Name = "gameName";
            this.gameName.Size = new System.Drawing.Size(550, 80);
            this.gameName.TabIndex = 0;
            this.gameName.Text = "Ultimate Tank Clash";
            this.gameName.Click += new System.EventHandler(this.gameName_Click);
            // 
            // multiPlayerStart
            // 
            this.multiPlayerStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.multiPlayerStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.multiPlayerStart.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.multiPlayerStart.ForeColor = System.Drawing.Color.LightGray;
            this.multiPlayerStart.Location = new System.Drawing.Point(265, 169);
            this.multiPlayerStart.Name = "multiPlayerStart";
            this.multiPlayerStart.Size = new System.Drawing.Size(107, 30);
            this.multiPlayerStart.TabIndex = 2;
            this.multiPlayerStart.Text = "Multiplayer";
            this.multiPlayerStart.UseVisualStyleBackColor = false;
            // 
            // options
            // 
            this.options.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.options.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.options.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.options.ForeColor = System.Drawing.Color.LightGray;
            this.options.Location = new System.Drawing.Point(265, 205);
            this.options.Name = "options";
            this.options.Size = new System.Drawing.Size(107, 30);
            this.options.TabIndex = 3;
            this.options.Text = "options";
            this.options.UseVisualStyleBackColor = false;
            this.options.Click += new System.EventHandler(this.Options_Click);
            // 
            // instructions
            // 
            this.instructions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.instructions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.instructions.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructions.ForeColor = System.Drawing.Color.LightGray;
            this.instructions.Location = new System.Drawing.Point(265, 241);
            this.instructions.Name = "instructions";
            this.instructions.Size = new System.Drawing.Size(107, 30);
            this.instructions.TabIndex = 4;
            this.instructions.Text = "instructions";
            this.instructions.UseVisualStyleBackColor = false;
            this.instructions.Click += new System.EventHandler(this.Instructions_Click);
            // 
            // about
            // 
            this.about.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.about.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.about.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.about.ForeColor = System.Drawing.Color.LightGray;
            this.about.Location = new System.Drawing.Point(265, 279);
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(107, 30);
            this.about.TabIndex = 5;
            this.about.Text = "about";
            this.about.UseVisualStyleBackColor = false;
            this.about.Click += new System.EventHandler(this.About_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.Color.LightGray;
            this.exitButton.Location = new System.Drawing.Point(265, 315);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(107, 30);
            this.exitButton.TabIndex = 6;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.about);
            this.Controls.Add(this.instructions);
            this.Controls.Add(this.options);
            this.Controls.Add(this.multiPlayerStart);
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
    }
}