namespace Kingdoms
{
	// Token: 0x02000211 RID: 529
	public partial class LoadingPanel : global::System.Windows.Forms.Form
	{
		// Token: 0x0600164C RID: 5708 RVA: 0x000179CE File Offset: 0x00015BCE
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600164D RID: 5709 RVA: 0x001602F8 File Offset: 0x0015E4F8
		private void InitializeComponent()
		{
			this.panel1 = new global::System.Windows.Forms.Panel();
			base.SuspendLayout();
			this.panel1.BackgroundImage = global::Kingdoms.Properties.Resources.splash_screen;
			this.panel1.Location = new global::System.Drawing.Point(1, 1);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(454, 212);
			this.panel1.TabIndex = 15;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Black;
			base.ClientSize = new global::System.Drawing.Size(456, 214);
			base.ControlBox = false;
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			base.Name = "LoadingPanel";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Loading Stronghold Kingdoms";
			base.Load += new global::System.EventHandler(this.LoadingPanel_Load);
			base.ResumeLayout(false);
		}

		// Token: 0x04002695 RID: 9877
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04002696 RID: 9878
		private global::System.Windows.Forms.Panel panel1;
	}
}
