namespace Kingdoms
{
	// Token: 0x02000248 RID: 584
	[global::System.Security.Permissions.PermissionSet(global::System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
	public partial class MyFormBase : global::System.Windows.Forms.Form
	{
		// Token: 0x060019EF RID: 6639 RVA: 0x0001A149 File Offset: 0x00018349
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060019F0 RID: 6640 RVA: 0x0019AE9C File Offset: 0x0019909C
		private void InitializeComponent()
		{
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.panel2 = new global::Kingdoms.MFBTitlePanel();
			this.label3 = new global::System.Windows.Forms.Label();
			this.lblTitle = new global::System.Windows.Forms.Label();
			this.panel2.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.panel1.BackColor = global::ARGBColors.Black;
			this.panel1.Location = new global::System.Drawing.Point(331, 9);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(18, 18);
			this.panel1.TabIndex = 10;
			this.panel1.Visible = false;
			this.panel1.MouseLeave += new global::System.EventHandler(this.panel1_MouseLeave);
			this.panel1.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
			this.panel1.MouseEnter += new global::System.EventHandler(this.panel1_MouseEnter);
			this.panel3.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.panel3.BackColor = global::ARGBColors.Black;
			this.panel3.Location = new global::System.Drawing.Point(307, 9);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(18, 18);
			this.panel3.TabIndex = 11;
			this.panel3.Visible = false;
			this.panel3.MouseLeave += new global::System.EventHandler(this.panel3_MouseLeave);
			this.panel3.Click += new global::System.EventHandler(this.panel3_Click);
			this.panel3.MouseEnter += new global::System.EventHandler(this.panel3_MouseEnter);
			this.panel4.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.panel4.BackColor = global::ARGBColors.Black;
			this.panel4.Location = new global::System.Drawing.Point(283, 9);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(18, 18);
			this.panel4.TabIndex = 11;
			this.panel4.Visible = false;
			this.panel4.MouseLeave += new global::System.EventHandler(this.panel4_MouseLeave);
			this.panel4.Click += new global::System.EventHandler(this.panel4_Click);
			this.panel4.MouseEnter += new global::System.EventHandler(this.panel4_MouseEnter);
			this.panel2.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.panel2.ClickThru = false;
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.lblTitle);
			this.panel2.Location = new global::System.Drawing.Point(1, 1);
			this.panel2.Name = "panel2";
			this.panel2.PanelActive = true;
			this.panel2.Size = new global::System.Drawing.Size(359, 30);
			this.panel2.StoredGraphics = null;
			this.panel2.TabIndex = 12;
			this.panel2.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
			this.panel2.SizeChanged += new global::System.EventHandler(this.panel2_SizeChanged);
			this.label3.AutoSize = true;
			this.label3.BackColor = global::ARGBColors.Transparent;
			this.label3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::ARGBColors.White;
			this.label3.Location = new global::System.Drawing.Point(179, 7);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(0, 16);
			this.label3.TabIndex = 9;
			this.lblTitle.AutoSize = true;
			this.lblTitle.BackColor = global::ARGBColors.Transparent;
			this.lblTitle.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblTitle.ForeColor = global::ARGBColors.White;
			this.lblTitle.Location = new global::System.Drawing.Point(10, 8);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new global::System.Drawing.Size(33, 16);
			this.lblTitle.TabIndex = 8;
			this.lblTitle.Text = "title";
			this.lblTitle.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseDown);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::System.Drawing.Color.FromArgb(159, 180, 193);
			base.ClientSize = new global::System.Drawing.Size(361, 123);
			base.ControlBox = false;
			base.Controls.Add(this.panel4);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel2);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.ShowInTaskbar = false;
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			base.Name = "MyFormBase";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Rename Village";
			base.Paint += new global::System.Windows.Forms.PaintEventHandler(this.MyFormBase_Paint);
			base.SizeChanged += new global::System.EventHandler(this.MyFormBase_SizeChanged);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04002A61 RID: 10849
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04002A62 RID: 10850
		private global::Kingdoms.MFBTitlePanel panel2;

		// Token: 0x04002A63 RID: 10851
		private global::System.Windows.Forms.Label lblTitle;

		// Token: 0x04002A64 RID: 10852
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04002A65 RID: 10853
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04002A66 RID: 10854
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04002A67 RID: 10855
		private global::System.Windows.Forms.Panel panel4;
	}
}
