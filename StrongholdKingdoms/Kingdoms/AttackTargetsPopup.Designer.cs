namespace Kingdoms
{
	// Token: 0x020000D5 RID: 213
	public partial class AttackTargetsPopup : global::Kingdoms.MyFormBase
	{
		// Token: 0x06000618 RID: 1560 RVA: 0x0000B409 File Offset: 0x00009609
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000619 RID: 1561 RVA: 0x00079FF0 File Offset: 0x000781F0
		private void InitializeComponent()
		{
			this.customPanel = new global::Kingdoms.AttackTargetsPanel();
			base.SuspendLayout();
			this.customPanel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.customPanel.ClickThru = false;
			this.customPanel.Location = new global::System.Drawing.Point(0, 34);
			this.customPanel.Name = "customPanel";
			this.customPanel.PanelActive = true;
			this.customPanel.Size = base.Size;
			this.customPanel.StoredGraphics = null;
			this.customPanel.TabIndex = 99;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(700 * global::Kingdoms.InterfaceMgr.UIScale, 450 * global::Kingdoms.InterfaceMgr.UIScale);
			base.Controls.Add(this.customPanel);
			this.DoubleBuffered = true;
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.AttackTargetsPoup_FormClosing);
			base.Name = "AttackTargetsPopup";
			base.ShowClose = true;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Manage Formations";
			base.TransparencyKey = global::ARGBColors.Fuchsia;
			base.Controls.SetChildIndex(this.customPanel, 0);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040007BB RID: 1979
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040007BC RID: 1980
		private global::Kingdoms.AttackTargetsPanel customPanel;
	}
}
