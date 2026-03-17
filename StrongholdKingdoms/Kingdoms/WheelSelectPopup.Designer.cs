namespace Kingdoms
{
	// Token: 0x020004F9 RID: 1273
	public partial class WheelSelectPopup : global::System.Windows.Forms.Form
	{
		// Token: 0x0600305B RID: 12379 RVA: 0x0002330C File Offset: 0x0002150C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600305C RID: 12380 RVA: 0x0027D934 File Offset: 0x0027BB34
		private void InitializeComponent()
		{
			this.wheelSelectPanel = new global::Kingdoms.WheelSelectPanel();
			base.SuspendLayout();
			this.wheelSelectPanel.ClickThru = false;
			this.wheelSelectPanel.Location = new global::System.Drawing.Point(0, 0);
			this.wheelSelectPanel.Name = "wheelSelectPanel";
			this.wheelSelectPanel.NoDrawBackground = false;
			this.wheelSelectPanel.PanelActive = true;
			this.wheelSelectPanel.SelfDrawBackground = false;
			this.wheelSelectPanel.Size = new global::System.Drawing.Size(700, 420);
			this.wheelSelectPanel.StoredGraphics = null;
			this.wheelSelectPanel.TabIndex = 0;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(700, 420);
			base.ControlBox = false;
			base.Controls.Add(this.wheelSelectPanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			base.MaximizeBox = false;
			this.MaximumSize = new global::System.Drawing.Size(700, 420);
			base.MinimizeBox = false;
			this.MinimumSize = new global::System.Drawing.Size(700, 420);
			base.Name = "WheelSelectPopup";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Free Cards";
			base.TransparencyKey = global::System.Drawing.Color.FromArgb(255, 0, 255);
			base.ResumeLayout(false);
		}

		// Token: 0x04003CD5 RID: 15573
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04003CD6 RID: 15574
		private global::Kingdoms.WheelSelectPanel wheelSelectPanel;
	}
}
