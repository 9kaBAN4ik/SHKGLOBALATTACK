namespace Kingdoms
{
	// Token: 0x0200024A RID: 586
	public partial class MyMessageBox : global::System.Windows.Forms.Form
	{
		// Token: 0x060019F5 RID: 6645 RVA: 0x0001A168 File Offset: 0x00018368
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060019F6 RID: 6646 RVA: 0x0019B428 File Offset: 0x00199628
		private void InitializeComponent()
		{
			new global::System.ComponentModel.ComponentResourceManager(typeof(global::Kingdoms.MyMessageBox));
			this.btnCancel = new global::Kingdoms.BitmapButton();
			this.lblTimer = new global::System.Windows.Forms.Label();
			this.btnOK = new global::Kingdoms.BitmapButton();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.lblMessage = new global::System.Windows.Forms.Label();
			this.lblTitle = new global::System.Windows.Forms.Label();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			base.SuspendLayout();
			this.btnCancel.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnCancel.BackColor = global::System.Drawing.Color.FromArgb(203, 215, 223);
			this.btnCancel.Location = new global::System.Drawing.Point(184, 112);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(74, 25);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = false;
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.lblTimer.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.lblTimer.AutoSize = true;
			this.lblTimer.BackColor = global::ARGBColors.Transparent;
			this.lblTimer.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblTimer.Location = new global::System.Drawing.Point(9, 120);
			this.lblTimer.Name = "lblTimer";
			this.lblTimer.Size = new global::System.Drawing.Size(0, 16);
			this.lblTimer.TabIndex = 4;
			this.btnOK.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnOK.BackColor = global::System.Drawing.Color.FromArgb(203, 215, 223);
			this.btnOK.Location = new global::System.Drawing.Point(104, 112);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new global::System.Drawing.Size(74, 25);
			this.btnOK.TabIndex = 5;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = false;
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			this.panel1.AutoScroll = true;
			this.panel1.BackColor = global::ARGBColors.Transparent;
			this.panel1.Controls.Add(this.lblMessage);
			this.panel1.Location = new global::System.Drawing.Point(13, 41);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(335, 58);
			this.panel1.TabIndex = 6;
			this.lblMessage.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblMessage.Location = new global::System.Drawing.Point(0, 0);
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.Size = new global::System.Drawing.Size(335, 58);
			this.lblMessage.TabIndex = 0;
			this.lblMessage.Text = "Testing text";
			this.lblMessage.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.lblTitle.AutoSize = true;
			this.lblTitle.BackColor = global::ARGBColors.Transparent;
			this.lblTitle.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblTitle.ForeColor = global::ARGBColors.White;
			this.lblTitle.Location = new global::System.Drawing.Point(10, 8);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new global::System.Drawing.Size(0, 16);
			this.lblTitle.TabIndex = 8;
			this.lblTitle.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseDown);
			this.panel2.Controls.Add(this.lblTitle);
			this.panel2.Location = new global::System.Drawing.Point(1, 1);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(359, 30);
			this.panel2.TabIndex = 9;
			this.panel2.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::System.Drawing.Color.FromArgb(159, 180, 193);
			base.ClientSize = new global::System.Drawing.Size(361, 144);
			base.ControlBox = false;
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.lblTimer);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			base.Name = "MyMessageBox";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "MyMessageBox";
			base.Load += new global::System.EventHandler(this.MyMessageBox_Load);
			base.Paint += new global::System.Windows.Forms.PaintEventHandler(this.MyMessageBox_Paint);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04002A6A RID: 10858
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04002A6B RID: 10859
		private global::Kingdoms.BitmapButton btnCancel;

		// Token: 0x04002A6C RID: 10860
		private global::System.Windows.Forms.Label lblTimer;

		// Token: 0x04002A6D RID: 10861
		private global::Kingdoms.BitmapButton btnOK;

		// Token: 0x04002A6E RID: 10862
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04002A6F RID: 10863
		private global::System.Windows.Forms.Label lblMessage;

		// Token: 0x04002A70 RID: 10864
		private global::System.Windows.Forms.Label lblTitle;

		// Token: 0x04002A71 RID: 10865
		private global::System.Windows.Forms.Panel panel2;
	}
}
