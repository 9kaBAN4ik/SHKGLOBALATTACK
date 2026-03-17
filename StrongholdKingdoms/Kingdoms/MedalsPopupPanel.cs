using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x0200023D RID: 573
	public class MedalsPopupPanel : CustomSelfDrawPanel
	{
		// Token: 0x0600197A RID: 6522 RVA: 0x00019BF6 File Offset: 0x00017DF6
		public MedalsPopupPanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x0600197B RID: 6523 RVA: 0x00198E94 File Offset: 0x00197094
		public void init(List<int> achievements, Form parent)
		{
			this.m_parent = parent;
			if (achievements == null)
			{
				achievements = new List<int>();
			}
			base.clearControls();
			this.mainBackgroundImage.Image = GFXLibrary.body_background_canvas;
			this.mainBackgroundImage.ClipRect = new Rectangle(default(Point), base.Size);
			this.mainBackgroundImage.Position = new Point(0, 0);
			this.mainBackgroundImage.Size = base.Size;
			this.mainBackgroundImage.Tile = true;
			base.addControl(this.mainBackgroundImage);
			this.closeButton.ImageNorm = GFXLibrary.int_button_close_normal;
			this.closeButton.ImageOver = GFXLibrary.int_button_close_over;
			this.closeButton.ImageClick = GFXLibrary.int_button_close_in;
			this.closeButton.Position = new Point(base.Width - 40, 0);
			this.closeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "MedalsPopupPanel_close");
			base.addControl(this.closeButton);
			CustomSelfDrawPanel.WikiLinkControl.init(this, 44, new Point(base.Width - 90, 0));
			this.medalWindow.Position = new Point(0, 0);
			this.medalWindow.init(achievements, false, true, 0);
			this.mainBackgroundImage.addControl(this.medalWindow);
		}

		// Token: 0x0600197C RID: 6524 RVA: 0x00019C31 File Offset: 0x00017E31
		private void closeClick()
		{
			this.m_parent.Close();
		}

		// Token: 0x0600197D RID: 6525 RVA: 0x00019C3E File Offset: 0x00017E3E
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600197E RID: 6526 RVA: 0x00019C5D File Offset: 0x00017E5D
		private void InitializeComponent()
		{
			this.components = new Container();
			base.AutoScaleMode = AutoScaleMode.None;
		}

		// Token: 0x04002A24 RID: 10788
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002A25 RID: 10789
		private CustomSelfDrawPanel.CSDImage mainBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002A26 RID: 10790
		private CustomSelfDrawPanel.MedalWindow medalWindow = new CustomSelfDrawPanel.MedalWindow();

		// Token: 0x04002A27 RID: 10791
		private Form m_parent;

		// Token: 0x04002A28 RID: 10792
		private IContainer components;
	}
}
