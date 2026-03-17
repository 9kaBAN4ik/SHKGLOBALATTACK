namespace Kingdoms
{
	// Token: 0x020004BD RID: 1213
	public partial class VacationCancelPopupWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x06002CCE RID: 11470 RVA: 0x00020DD9 File Offset: 0x0001EFD9
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002CCF RID: 11471 RVA: 0x0023B254 File Offset: 0x00239454
		private void InitializeComponent()
		{
			this.createPopupPanel = new global::Kingdoms.VacationCancelPopupPanel();
			base.SuspendLayout();
			this.createPopupPanel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.createPopupPanel.ClickThru = false;
			this.createPopupPanel.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			this.createPopupPanel.Location = new global::System.Drawing.Point(0, 0);
			this.createPopupPanel.Name = "createPopupPanel";
			this.createPopupPanel.PanelActive = true;
			this.createPopupPanel.Size = new global::System.Drawing.Size(615, 347);
			this.createPopupPanel.StoredGraphics = null;
			this.createPopupPanel.TabIndex = 0;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(615, 347);
			base.ControlBox = false;
			base.Controls.Add(this.createPopupPanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			this.MaximumSize = new global::System.Drawing.Size(615, 347);
			this.MinimumSize = new global::System.Drawing.Size(615, 347);
			base.Name = "VacationCancelPopupWindow";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "ScoutPopupWindow";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.CreatePopupPanel_FormClosing);
			base.ResumeLayout(false);
		}

		// Token: 0x040037D6 RID: 14294
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040037D7 RID: 14295
		private global::Kingdoms.VacationCancelPopupPanel createPopupPanel;
	}
}
