namespace Kingdoms
{
	// Token: 0x020001EE RID: 494
	public partial class GreyOutWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x060013AF RID: 5039 RVA: 0x00015653 File Offset: 0x00013853
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060013B0 RID: 5040 RVA: 0x0014F9B8 File Offset: 0x0014DBB8
		private void InitializeComponent()
		{
			this.greyOutPanel = new global::Kingdoms.GreyOutPanel();
			base.SuspendLayout();
			this.greyOutPanel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.greyOutPanel.Location = new global::System.Drawing.Point(0, 0);
			this.greyOutPanel.Name = "greyOutPanel";
			this.greyOutPanel.Size = new global::System.Drawing.Size(292, 266);
			this.greyOutPanel.TabIndex = 0;
			this.greyOutPanel.Visible = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Black;
			base.ClientSize = new global::System.Drawing.Size(292, 266);
			base.ControlBox = false;
			base.Controls.Add(this.greyOutPanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "GreyOutWindow";
			base.Opacity = 0.4;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "GreyOutWindow";
			base.ResumeLayout(false);
		}

		// Token: 0x040024C8 RID: 9416
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040024C9 RID: 9417
		private global::Kingdoms.GreyOutPanel greyOutPanel;
	}
}
