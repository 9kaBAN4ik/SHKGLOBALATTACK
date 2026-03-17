namespace Kingdoms
{
	// Token: 0x02000524 RID: 1316
	public partial class WorldSelectPopupWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x060033C9 RID: 13257 RVA: 0x00025154 File Offset: 0x00023354
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060033CA RID: 13258 RVA: 0x002ABB1C File Offset: 0x002A9D1C
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Kingdoms.WorldSelectPopupWindow));
			this.createPopupPanel = new global::Kingdoms.WorldSelectPopupPanel();
			base.SuspendLayout();
			this.createPopupPanel.ClickThru = false;
			this.createPopupPanel.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			this.createPopupPanel.Location = new global::System.Drawing.Point(0, 0);
			this.createPopupPanel.Name = "createPopupPanel";
			this.createPopupPanel.NoDrawBackground = false;
			this.createPopupPanel.PanelActive = true;
			this.createPopupPanel.SelfDrawBackground = false;
			this.createPopupPanel.Size = new global::System.Drawing.Size(824, 605);
			this.createPopupPanel.StoredGraphics = null;
			this.createPopupPanel.TabIndex = 0;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(824, 605);
			base.ControlBox = false;
			base.Controls.Add(this.createPopupPanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			this.MaximumSize = new global::System.Drawing.Size(824, 605);
			this.MinimumSize = new global::System.Drawing.Size(824, 605);
			base.Name = "WorldSelectPopupWindow";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "WorldSelect";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.CreatePopupPanel_FormClosing);
			base.ResumeLayout(false);
		}

		// Token: 0x040040BD RID: 16573
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040040BE RID: 16574
		private global::Kingdoms.WorldSelectPopupPanel createPopupPanel;
	}
}
