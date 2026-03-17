using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x020004A3 RID: 1187
	public class TutorialArrowPanel : CustomSelfDrawPanel
	{
		// Token: 0x06002B76 RID: 11126 RVA: 0x0001FED9 File Offset: 0x0001E0D9
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002B77 RID: 11127 RVA: 0x00224184 File Offset: 0x00222384
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.None;
			base.Name = "TutorialArrowPanel";
			base.Size = new Size(600, 55);
			base.ResumeLayout(false);
		}

		// Token: 0x06002B78 RID: 11128 RVA: 0x0001FEF8 File Offset: 0x0001E0F8
		public TutorialArrowPanel()
		{
			this.InitializeComponent();
		}

		// Token: 0x06002B79 RID: 11129 RVA: 0x002241D8 File Offset: 0x002223D8
		public void show(bool upArrow, Form parent)
		{
			if (!this.created || upArrow != this.lastUpArrow)
			{
				this.created = true;
				this.lastUpArrow = upArrow;
				base.clearControls();
				this.transparentBackground.Size = base.Size;
				this.transparentBackground.FillColor = Color.FromArgb(255, 0, 255);
				base.addControl(this.transparentBackground);
				this.background.Position = new Point(0, 0);
				if (upArrow)
				{
					this.background.Image = GFXLibrary.tutorial_arrow_yellow[0];
				}
				else
				{
					this.background.Image = GFXLibrary.tutorial_arrow_yellow[1];
				}
				this.background.Size = new Size(this.background.Image.Width, this.background.Image.Height);
				base.addControl(this.background);
				base.Invalidate();
				if (parent != null)
				{
					parent.Invalidate();
				}
			}
		}

		// Token: 0x06002B7A RID: 11130 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void update()
		{
		}

		// Token: 0x06002B7B RID: 11131 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void closing()
		{
		}

		// Token: 0x04003611 RID: 13841
		private IContainer components;

		// Token: 0x04003612 RID: 13842
		private CustomSelfDrawPanel.CSDImage background = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003613 RID: 13843
		private CustomSelfDrawPanel.CSDFill transparentBackground = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x04003614 RID: 13844
		private bool created;

		// Token: 0x04003615 RID: 13845
		private bool lastUpArrow;
	}
}
