namespace Kingdoms
{
	// Token: 0x02000273 RID: 627
	public partial class PizzazzPopupWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x06001BEE RID: 7150 RVA: 0x0001BA48 File Offset: 0x00019C48
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001BEF RID: 7151 RVA: 0x001B35B8 File Offset: 0x001B17B8
		private void InitializeComponent()
		{
			this.pizzazzPopupPanel = new global::Kingdoms.PizzazzPopupPanel();
			base.SuspendLayout();
			this.pizzazzPopupPanel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.pizzazzPopupPanel.ClickThru = false;
			this.pizzazzPopupPanel.Location = new global::System.Drawing.Point(0, 0);
			this.pizzazzPopupPanel.Name = "pizzazzPopupPanel";
			this.pizzazzPopupPanel.PanelActive = true;
			this.pizzazzPopupPanel.Size = new global::System.Drawing.Size(638, 328);
			this.pizzazzPopupPanel.StoredGraphics = null;
			this.pizzazzPopupPanel.TabIndex = 0;
			this.pizzazzPopupPanel.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.pizzazzPopupPanel_MouseClick);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Fuchsia;
			base.ClientSize = new global::System.Drawing.Size(638, 328);
			base.ControlBox = false;
			base.Controls.Add(this.pizzazzPopupPanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			this.MaximumSize = new global::System.Drawing.Size(638, 328);
			this.MinimumSize = new global::System.Drawing.Size(638, 328);
			base.Name = "PizzazzPopupWindow";
			base.ShowInTaskbar = false;
			base.TransparencyKey = global::ARGBColors.Fuchsia;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "PizzazzPopupWindow";
			base.ResumeLayout(false);
		}

		// Token: 0x04002CD6 RID: 11478
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04002CD7 RID: 11479
		private global::Kingdoms.PizzazzPopupPanel pizzazzPopupPanel;
	}
}
