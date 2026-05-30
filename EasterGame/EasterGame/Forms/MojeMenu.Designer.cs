namespace EasterGame.Forms
{
    partial class MojeMenu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnNavod = new System.Windows.Forms.Button();
            this.btnCredits = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEnd
            // 
            this.btnEnd.BackColor = System.Drawing.Color.Lime;
            this.btnEnd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEnd.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEnd.Location = new System.Drawing.Point(190, 306);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(104, 62);
            this.btnEnd.TabIndex = 0;
            this.btnEnd.Text = "Konec";
            this.btnEnd.UseVisualStyleBackColor = false;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.LightCoral;
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStart.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStart.Location = new System.Drawing.Point(190, 170);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(104, 62);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            // 
            // btnNavod
            // 
            this.btnNavod.BackColor = System.Drawing.Color.Orange;
            this.btnNavod.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNavod.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnNavod.Location = new System.Drawing.Point(190, 238);
            this.btnNavod.Name = "btnNavod";
            this.btnNavod.Size = new System.Drawing.Size(104, 62);
            this.btnNavod.TabIndex = 0;
            this.btnNavod.Text = "Návod";
            this.btnNavod.UseVisualStyleBackColor = false;
            this.btnNavod.Click += new System.EventHandler(this.btnNavod_Click);
            // 
            // btnCredits
            // 
            this.btnCredits.BackColor = System.Drawing.Color.Red;
            this.btnCredits.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCredits.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCredits.Location = new System.Drawing.Point(80, 238);
            this.btnCredits.Name = "btnCredits";
            this.btnCredits.Size = new System.Drawing.Size(104, 62);
            this.btnCredits.TabIndex = 0;
            this.btnCredits.Text = "Credits";
            this.btnCredits.UseVisualStyleBackColor = false;
            this.btnCredits.Click += new System.EventHandler(this.btnCredits_Click);
            // 
            // MojeMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.BackgroundImage = global::EasterGame.Properties.Resources.pozadi;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnNavod);
            this.Controls.Add(this.btnCredits);
            this.Controls.Add(this.btnStart);
            this.DoubleBuffered = true;
            this.Name = "MojeMenu";
            this.Size = new System.Drawing.Size(450, 400);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Button btnNavod;
        public System.Windows.Forms.Button btnStart;
        public System.Windows.Forms.Button btnCredits;
    }
}
