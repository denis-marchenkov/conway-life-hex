namespace UI
{
    partial class Conway
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
            GridCanvas = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)GridCanvas).BeginInit();
            SuspendLayout();
            // 
            // GridCanvas
            // 
            GridCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            GridCanvas.BackColor = System.Drawing.Color.White;
            GridCanvas.Location = new Point(12, 115);
            GridCanvas.Name = "GridCanvas";
            GridCanvas.Size = new Size(732, 500);
            GridCanvas.TabIndex = 0;
            GridCanvas.TabStop = false;
            GridCanvas.Resize += new System.EventHandler(this.GridCanvas_Resize);
            GridCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.GridCanvas_Paint);
            // 
            // Conway
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(756, 627);
            Controls.Add(GridCanvas);
            Name = "Conway";
            Text = "Conway";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)GridCanvas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox GridCanvas;
    }
}
