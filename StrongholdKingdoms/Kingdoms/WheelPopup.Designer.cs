namespace Kingdoms
{
	// Token: 0x020004F7 RID: 1271
	public partial class WheelPopup : global::System.Windows.Forms.Form
	{
		// Token: 0x0600304C RID: 12364 RVA: 0x00023236 File Offset: 0x00021436
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600304D RID: 12365 RVA: 0x0027C6CC File Offset: 0x0027A8CC
		private void InitializeComponent()
		{
			new global::System.ComponentModel.ComponentResourceManager(typeof(global::Kingdoms.WheelPopup));
			this.wheelPanel = new global::Kingdoms.WheelPanel();
			base.SuspendLayout();
			this.wheelPanel.Location = new global::System.Drawing.Point(0, 0);
			this.wheelPanel.Name = "wheelPanel";
			this.wheelPanel.PanelActive = true;
			this.wheelPanel.Size = new global::System.Drawing.Size(1000, 600);
			this.wheelPanel.StoredGraphics = null;
			this.wheelPanel.TabIndex = 0;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(1000, 600);
			base.ControlBox = false;
			base.Controls.Add(this.wheelPanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			base.MaximizeBox = false;
			this.MaximumSize = new global::System.Drawing.Size(1000, 600);
			base.MinimizeBox = false;
			this.MinimumSize = new global::System.Drawing.Size(1000, 600);
			base.Name = "WheelPopup";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Free Cards";
			base.TransparencyKey = global::ARGBColors.Fuchsia;
			base.ResumeLayout(false);
		}

		// Token: 0x04003CC0 RID: 15552
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04003CC1 RID: 15553
		internal global::Kingdoms.WheelPanel wheelPanel;
	}
}
