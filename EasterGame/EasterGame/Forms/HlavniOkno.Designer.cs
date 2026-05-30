namespace EasterGame
{
    partial class HlavniOkno
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
            this.SuspendLayout();
            // 
            // HlavniOkno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Yellow;
            this.BackgroundImage = global::EasterGame.Properties.Resources.spodniMenu;
            this.ClientSize = new System.Drawing.Size(800, 562);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "HlavniOkno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EasterGame";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.HlavniOkno_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HlavniOkno_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

