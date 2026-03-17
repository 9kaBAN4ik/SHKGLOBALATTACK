namespace Kingdoms
{
	// Token: 0x02000281 RID: 641
	public partial class PresetEditPopup : global::Kingdoms.MyFormBase
	{
		// Token: 0x06001CCA RID: 7370 RVA: 0x0001C34F File Offset: 0x0001A54F
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001CCB RID: 7371 RVA: 0x001C2D2C File Offset: 0x001C0F2C
		private void InitializeComponent()
		{
			this.customPanel = new global::Kingdoms.PresetEditPanel();
			this.tbInput = new global::System.Windows.Forms.TextBox();
			this.tbInput.SuspendLayout();
			base.SuspendLayout();
			base.ClientSize = new global::System.Drawing.Size(350 * global::Kingdoms.InterfaceMgr.UIScale, 180 * global::Kingdoms.InterfaceMgr.UIScale);
			this.tbInput.Multiline = false;
			this.tbInput.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbInput.Name = "tbMainText";
			this.tbInput.Size = new global::System.Drawing.Size(base.ClientSize.Width - 40, 28);
			this.tbInput.BackColor = global::ARGBColors.White;
			this.tbInput.Location = new global::System.Drawing.Point(base.ClientSize.Width / 2 - this.tbInput.Width / 2, base.ClientSize.Height / 2 - this.tbInput.Height / 2);
			this.tbInput.TextChanged += new global::System.EventHandler(this.tbInput_TextChanged);
			this.tbInput.TabIndex = 1;
			this.tbInput.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.tbInput_KeyPress);
			this.customPanel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.customPanel.ClickThru = false;
			this.customPanel.Location = new global::System.Drawing.Point(0, 34);
			this.customPanel.Name = "customPanel";
			this.customPanel.PanelActive = true;
			this.customPanel.Size = base.Size;
			this.customPanel.StoredGraphics = null;
			this.customPanel.TabIndex = 99;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.Controls.Add(this.tbInput);
			this.DoubleBuffered = true;
			base.Name = "PresetEditPopup";
			base.ShowClose = false;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			base.TransparencyKey = global::ARGBColors.Fuchsia;
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04002DB1 RID: 11697
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04002DB2 RID: 11698
		private global::Kingdoms.PresetEditPanel customPanel;

		// Token: 0x04002DB3 RID: 11699
		private global::System.Windows.Forms.TextBox tbInput;
	}
}
