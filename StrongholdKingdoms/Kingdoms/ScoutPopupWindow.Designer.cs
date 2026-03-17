namespace Kingdoms
{
	// Token: 0x0200047C RID: 1148
	public partial class ScoutPopupWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x060029BC RID: 10684 RVA: 0x0001EB37 File Offset: 0x0001CD37
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060029BD RID: 10685 RVA: 0x002043BC File Offset: 0x002025BC
		private void InitializeComponent()
		{
			this.scoutPopupPanel = new global::Kingdoms.ScoutPopupPanel();
			base.SuspendLayout();
			this.scoutPopupPanel.Location = new global::System.Drawing.Point(0, 0);
			this.scoutPopupPanel.Name = "scoutPopupPanel";
			this.scoutPopupPanel.PanelActive = true;
			this.scoutPopupPanel.Size = new global::System.Drawing.Size(700, 482);
			this.scoutPopupPanel.StoredGraphics = null;
			this.scoutPopupPanel.TabIndex = 0;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(700, 482);
			base.ControlBox = false;
			base.Controls.Add(this.scoutPopupPanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			this.MaximumSize = new global::System.Drawing.Size(700, 482);
			this.MinimumSize = new global::System.Drawing.Size(700, 482);
			base.Name = "ScoutPopupWindow";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "ScoutPopupWindow";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.ScoutPopupPanel_FormClosing);
			base.ResumeLayout(false);
		}

		// Token: 0x04003368 RID: 13160
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04003369 RID: 13161
		private global::Kingdoms.ScoutPopupPanel scoutPopupPanel;
	}
}
