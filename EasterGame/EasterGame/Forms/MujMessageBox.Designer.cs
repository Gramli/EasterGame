namespace EasterGame.Forms
{
    partial class MujMessageBox
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUp = new System.Windows.Forms.Label();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnDalsiLevel = new System.Windows.Forms.Button();
            this.lblDown = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblDown);
            this.panel1.Controls.Add(this.lblUp);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(324, 74);
            this.panel1.TabIndex = 0;
            // 
            // lblUp
            // 
            this.lblUp.AutoSize = true;
            this.lblUp.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblUp.Location = new System.Drawing.Point(3, 9);
            this.lblUp.Name = "lblUp";
            this.lblUp.Size = new System.Drawing.Size(60, 25);
            this.lblUp.TabIndex = 0;
            this.lblUp.Text = "label1";
            // 
            // btnMenu
            // 
            this.btnMenu.BackgroundImage = global::EasterGame.Properties.Resources.mrtvePole;
            this.btnMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMenu.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnMenu.Location = new System.Drawing.Point(20, 80);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(90, 44);
            this.btnMenu.TabIndex = 1;
            this.btnMenu.Text = "Menu";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.BackgroundImage = global::EasterGame.Properties.Resources.teleport;
            this.btnRestart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRestart.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRestart.Location = new System.Drawing.Point(116, 80);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(90, 44);
            this.btnRestart.TabIndex = 1;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnDalsiLevel
            // 
            this.btnDalsiLevel.BackgroundImage = global::EasterGame.Properties.Resources.trava;
            this.btnDalsiLevel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDalsiLevel.Enabled = false;
            this.btnDalsiLevel.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnDalsiLevel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnDalsiLevel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btnDalsiLevel.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDalsiLevel.Location = new System.Drawing.Point(212, 80);
            this.btnDalsiLevel.Name = "btnDalsiLevel";
            this.btnDalsiLevel.Size = new System.Drawing.Size(90, 44);
            this.btnDalsiLevel.TabIndex = 1;
            this.btnDalsiLevel.Text = "Dalsi level";
            this.btnDalsiLevel.UseVisualStyleBackColor = true;
            this.btnDalsiLevel.Click += new System.EventHandler(this.btnDalsiLevel_Click);
            // 
            // lblDown
            // 
            this.lblDown.AutoSize = true;
            this.lblDown.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDown.Location = new System.Drawing.Point(3, 34);
            this.lblDown.Name = "lblDown";
            this.lblDown.Size = new System.Drawing.Size(60, 25);
            this.lblDown.TabIndex = 0;
            this.lblDown.Text = "label1";
            // 
            // MujMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::EasterGame.Properties.Resources.mrkev;
            this.ClientSize = new System.Drawing.Size(324, 136);
            this.Controls.Add(this.btnDalsiLevel);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MujMessageBox";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MessageBox";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblUp;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnDalsiLevel;
        private System.Windows.Forms.Label lblDown;
    }
}