namespace Kingdoms
{
	// Token: 0x020000B9 RID: 185
	public partial class AdvancedCastleOptionsPopup : global::System.Windows.Forms.Form
	{
		// Token: 0x0600051E RID: 1310 RVA: 0x0000AB8F File Offset: 0x00008D8F
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600051F RID: 1311 RVA: 0x00062BE0 File Offset: 0x00060DE0
		private void InitializeComponent()
		{
			this.advancedCastleOptionsPanel = new global::Kingdoms.AdvancedCastleOptionsPanel();
			base.SuspendLayout();
			this.advancedCastleOptionsPanel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.advancedCastleOptionsPanel.BackColor = global::ARGBColors.Fuchsia;
			this.advancedCastleOptionsPanel.Location = new global::System.Drawing.Point(0, 0);
			this.advancedCastleOptionsPanel.Name = "advancedCastleOptionsPanel";
			this.advancedCastleOptionsPanel.Size = new global::System.Drawing.Size(292, 266);
			this.advancedCastleOptionsPanel.StoredGraphics = null;
			this.advancedCastleOptionsPanel.TabIndex = 0;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::ARGBColors.White;
			base.ClientSize = new global::System.Drawing.Size(292 * global::Kingdoms.InterfaceMgr.UIScale, 266 * global::Kingdoms.InterfaceMgr.UIScale);
			base.ControlBox = false;
			base.Controls.Add(this.advancedCastleOptionsPanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "AdvancedCastleOptionsPopup";
			base.Opacity = 0.95;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Report Capture";
			base.TransparencyKey = global::ARGBColors.Fuchsia;
			base.ResumeLayout(false);
		}

		// Token: 0x040005EF RID: 1519
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040005F0 RID: 1520
		private global::Kingdoms.AdvancedCastleOptionsPanel advancedCastleOptionsPanel;
	}
}
