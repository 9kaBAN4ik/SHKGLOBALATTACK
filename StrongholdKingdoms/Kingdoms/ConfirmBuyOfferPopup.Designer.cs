namespace Kingdoms
{
	// Token: 0x02000135 RID: 309
	public partial class ConfirmBuyOfferPopup : global::System.Windows.Forms.Form
	{
		// Token: 0x06000B78 RID: 2936 RVA: 0x0000E80D File Offset: 0x0000CA0D
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000B79 RID: 2937 RVA: 0x000E4374 File Offset: 0x000E2574
		private void InitializeComponent()
		{
			this.confirmPanel = new global::Kingdoms.ConfirmBuyOfferPanel();
			base.SuspendLayout();
			this.confirmPanel.ClickThru = false;
			this.confirmPanel.Location = new global::System.Drawing.Point(0, 0);
			this.confirmPanel.Name = "confirmPanel";
			this.confirmPanel.PanelActive = true;
			this.confirmPanel.Size = new global::System.Drawing.Size(400, 280);
			this.confirmPanel.StoredGraphics = null;
			this.confirmPanel.TabIndex = 0;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = this.confirmPanel.Size;
			base.ControlBox = false;
			base.Controls.Add(this.confirmPanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ConfirmBuyOfferPopup";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "ConfirmPlayCardPopup";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.ConfirmPlayCardPopup_FormClosing);
			base.ResumeLayout(false);
		}

		// Token: 0x04000F8C RID: 3980
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000F8D RID: 3981
		private global::Kingdoms.ConfirmBuyOfferPanel confirmPanel;
	}
}
