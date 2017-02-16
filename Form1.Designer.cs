namespace Bezier
{
	partial class Form1
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
			this.pB = new System.Windows.Forms.PictureBox();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pB)).BeginInit();
			this.SuspendLayout();
			// 
			// pB
			// 
			this.pB.Location = new System.Drawing.Point(12, 12);
			this.pB.Name = "pB";
			this.pB.Size = new System.Drawing.Size(751, 368);
			this.pB.TabIndex = 0;
			this.pB.TabStop = false;
			this.pB.Paint += new System.Windows.Forms.PaintEventHandler(this.pB_Paint);
			this.pB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pB_MouseDown);
			this.pB.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pB_MouseMove);
			this.pB.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pB_MouseUp);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(769, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(118, 40);
			this.button1.TabIndex = 1;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(899, 392);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.pB);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.pB)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pB;
		private System.Windows.Forms.Button button1;
	}
}

