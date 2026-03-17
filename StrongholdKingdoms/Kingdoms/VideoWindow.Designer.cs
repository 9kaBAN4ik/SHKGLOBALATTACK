namespace Kingdoms
{
	// Token: 0x020004C5 RID: 1221
	public partial class VideoWindow : global::Kingdoms.MyFormBase
	{
		// Token: 0x06002D3D RID: 11581 RVA: 0x0002143F File Offset: 0x0001F63F
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002D3E RID: 11582 RVA: 0x0023F680 File Offset: 0x0023D880
		private void InitializeComponent()
		{
			this.videoPane = new global::Kingdoms.WebHelpPanel();
			base.SuspendLayout();
			this.videoPane.Location = new global::System.Drawing.Point(2, 32);
			this.videoPane.Name = "videoPane";
			this.videoPane.Size = new global::System.Drawing.Size(640, 360);
			this.videoPane.TabIndex = 0;
			this.videoPane.Visible = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Black;
			base.ClientSize = new global::System.Drawing.Size(644, 394);
			base.Controls.Add(this.videoPane);
			base.Name = "VideoWindow";
			base.ShowClose = true;
			this.Text = "VideoWindow";
			base.Load += new global::System.EventHandler(this.VideoWindow_Load);
			base.Controls.SetChildIndex(this.videoPane, 0);
			base.ResumeLayout(false);
		}

		// Token: 0x04003837 RID: 14391
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04003838 RID: 14392
		protected global::Kingdoms.WebHelpPanel videoPane;
	}
}
