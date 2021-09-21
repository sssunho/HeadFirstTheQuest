
namespace TheQuest
{
    partial class TheQuest
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TheQuest));
            this.BackGround = new System.Windows.Forms.PictureBox();
            this.Ground = new DoubleBufferPanel();
            ((System.ComponentModel.ISupportInitialize)(this.BackGround)).BeginInit();
            this.SuspendLayout();
            // 
            // BackGround
            // 
            this.BackGround.Image = ((System.Drawing.Image)(resources.GetObject("BackGround.Image")));
            this.BackGround.Location = new System.Drawing.Point(-5, -2);
            this.BackGround.Margin = new System.Windows.Forms.Padding(0);
            this.BackGround.Name = "BackGround";
            this.BackGround.Size = new System.Drawing.Size(600, 400);
            this.BackGround.TabIndex = 0;
            this.BackGround.TabStop = false;
            // 
            // Ground
            // 
            this.Ground.Location = new System.Drawing.Point(73, 55);
            this.Ground.Margin = new System.Windows.Forms.Padding(0);
            this.Ground.Name = "Ground";
            this.Ground.Size = new System.Drawing.Size(444, 185);
            this.Ground.TabIndex = 1;
            // 
            // TheQuest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 397);
            this.Controls.Add(this.Ground);
            this.Controls.Add(this.BackGround);
            this.Name = "TheQuest";
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            ((System.ComponentModel.ISupportInitialize)(this.BackGround)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox BackGround;
        private DoubleBufferPanel Ground;
    }
}
