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
            StartBtn = new Button();
            DelayTb = new TextBox();
            label1 = new Label();
            LivePercentTb = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)GridCanvas).BeginInit();
            SuspendLayout();
            // 
            // GridCanvas
            // 
            GridCanvas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GridCanvas.BackColor = Color.White;
            GridCanvas.Location = new Point(12, 74);
            GridCanvas.Name = "GridCanvas";
            GridCanvas.Size = new Size(926, 809);
            GridCanvas.TabIndex = 0;
            GridCanvas.TabStop = false;
            GridCanvas.Paint += GridCanvas_Paint;
            GridCanvas.Resize += GridCanvas_Resize;
            // 
            // StartBtn
            // 
            StartBtn.Location = new Point(12, 12);
            StartBtn.Name = "StartBtn";
            StartBtn.Size = new Size(82, 29);
            StartBtn.TabIndex = 1;
            StartBtn.Text = "Start";
            StartBtn.UseVisualStyleBackColor = true;
            StartBtn.Click += StartBtn_Click;
            // 
            // DelayTb
            // 
            DelayTb.Location = new Point(107, 12);
            DelayTb.Name = "DelayTb";
            DelayTb.Size = new Size(59, 29);
            DelayTb.TabIndex = 3;
            DelayTb.Text = "500";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(172, 16);
            label1.Name = "label1";
            label1.Size = new Size(133, 21);
            label1.TabIndex = 4;
            label1.Text = "Refresh Rate (ms)";
            // 
            // LivePercentTb
            // 
            LivePercentTb.Location = new Point(317, 13);
            LivePercentTb.Name = "LivePercentTb";
            LivePercentTb.Size = new Size(62, 29);
            LivePercentTb.TabIndex = 5;
            LivePercentTb.Text = "10";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(385, 16);
            label2.Name = "label2";
            label2.Size = new Size(172, 21);
            label2.TabIndex = 6;
            label2.Text = "Initial Live Cells Percent";
            // 
            // Conway
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(950, 895);
            Controls.Add(label2);
            Controls.Add(LivePercentTb);
            Controls.Add(label1);
            Controls.Add(DelayTb);
            Controls.Add(StartBtn);
            Controls.Add(GridCanvas);
            Name = "Conway";
            Text = "Conway";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)GridCanvas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox GridCanvas;
        private Button StartBtn;
        private TextBox DelayTb;
        private Label label1;
        private TextBox LivePercentTb;
        private Label label2;
    }
}
