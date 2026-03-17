namespace Kingdoms
{
	// Token: 0x020001DE RID: 478
	public partial class FreeCardsPopup : global::System.Windows.Forms.Form
	{
		// Token: 0x0600122B RID: 4651 RVA: 0x00013B6B File Offset: 0x00011D6B
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600122C RID: 4652 RVA: 0x001330E4 File Offset: 0x001312E4
		private void InitializeComponent()
		{
			new global::System.ComponentModel.ComponentResourceManager(typeof(global::Kingdoms.FreeCardsPopup));
			this.freeCardsPanel = new global::Kingdoms.FreeCardsPanel();
			base.SuspendLayout();
			this.freeCardsPanel.Location = new global::System.Drawing.Point(0, 0);
			this.freeCardsPanel.Name = "freeCardsPanel";
			this.freeCardsPanel.PanelActive = true;
			this.freeCardsPanel.Size = new global::System.Drawing.Size(1000, 600);
			this.freeCardsPanel.StoredGraphics = null;
			this.freeCardsPanel.TabIndex = 0;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(1000, 600);
			base.ControlBox = false;
			base.Controls.Add(this.freeCardsPanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			base.MaximizeBox = false;
			this.MaximumSize = new global::System.Drawing.Size(1000, 600);
			base.MinimizeBox = false;
			this.MinimumSize = new global::System.Drawing.Size(1000, 600);
			base.Name = "FreeCardsPopup";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Free Cards";
			base.TransparencyKey = global::ARGBColors.Fuchsia;
			base.ResumeLayout(false);
		}

		// Token: 0x040018A5 RID: 6309
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040018A6 RID: 6310
		private global::Kingdoms.FreeCardsPanel freeCardsPanel;
	}
}
