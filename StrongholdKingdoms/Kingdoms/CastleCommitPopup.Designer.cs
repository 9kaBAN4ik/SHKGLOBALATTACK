namespace Kingdoms
{
	// Token: 0x02000113 RID: 275
	public partial class CastleCommitPopup : global::Kingdoms.MyFormBase
	{
		// Token: 0x060008F0 RID: 2288 RVA: 0x0000D352 File Offset: 0x0000B552
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060008F1 RID: 2289 RVA: 0x000BA3A0 File Offset: 0x000B85A0
		private void InitializeComponent()
		{
			this.label1 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.label1.BackColor = global::ARGBColors.Transparent;
			this.label1.Location = new global::System.Drawing.Point(3, 36);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(268, 35);
			this.label1.TabIndex = 0;
			this.label1.Text = "Updating Castle, Please wait....";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(274, 79);
			base.Controls.Add(this.label1);
			base.Name = "CastleCommitPopup";
			base.ShowClose = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Updating Castle";
			base.TopMost = true;
			base.Load += new global::System.EventHandler(this.CastleCommitPopup_Load);
			base.Controls.SetChildIndex(this.label1, 0);
			base.ResumeLayout(false);
		}

		// Token: 0x04000C60 RID: 3168
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000C61 RID: 3169
		private global::System.Windows.Forms.Label label1;
	}
}
