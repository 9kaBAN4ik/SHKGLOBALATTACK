using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x020004A4 RID: 1188
	public partial class TutorialArrowWindow : Form
	{
		// Token: 0x17000239 RID: 569
		// (get) Token: 0x06002B7C RID: 11132 RVA: 0x0000A849 File Offset: 0x00008A49
		protected override bool ShowWithoutActivation
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06002B7F RID: 11135 RVA: 0x0001FF3B File Offset: 0x0001E13B
		public TutorialArrowWindow()
		{
			this.InitializeComponent();
		}

		// Token: 0x06002B80 RID: 11136 RVA: 0x0001FF50 File Offset: 0x0001E150
		public void show(bool upArrow, Point offset, AnchorStyles anchor)
		{
			this.m_upArrow = upArrow;
			this.m_anchor = anchor;
			this.m_offset = offset;
			this.customPanel.show(upArrow, this);
		}

		// Token: 0x06002B81 RID: 11137 RVA: 0x0001FF74 File Offset: 0x0001E174
		public void showTutorialArrowWindow(bool doShow, Form parentWindow)
		{
			InterfaceMgr.Instance.setCurrentTutorialArrowWindow(this);
			if (parentWindow == null)
			{
				parentWindow = InterfaceMgr.Instance.ParentForm;
			}
			if (doShow)
			{
				base.Show(parentWindow);
			}
		}

		// Token: 0x06002B82 RID: 11138 RVA: 0x00224404 File Offset: 0x00222604
		public void update()
		{
			this.m_arrowAnimClock++;
			if (this.m_arrowAnimClock < 20)
			{
				this.m_arrowAnimOffset = this.m_arrowAnimClock / 2;
			}
			else if (this.m_arrowAnimClock >= 40)
			{
				this.m_arrowAnimOffset = 0;
				this.m_arrowAnimClock = 0;
			}
			else
			{
				this.m_arrowAnimOffset = 20 - this.m_arrowAnimClock / 2;
			}
			if (base.Visible && base.Created)
			{
				this.customPanel.update();
				if (this.m_arrowAnimOffset != this.m_animOffset)
				{
					this.m_animOffset = this.m_arrowAnimOffset;
					this.updateLocation(TutorialArrowWindow.lastParent);
				}
			}
		}

		// Token: 0x06002B83 RID: 11139 RVA: 0x0001FF9A File Offset: 0x0001E19A
		public void move()
		{
			if (base.Visible && base.Created)
			{
				this.updateLocation(TutorialArrowWindow.lastParent);
			}
		}

		// Token: 0x06002B84 RID: 11140 RVA: 0x002244A4 File Offset: 0x002226A4
		public void updateLocation(Form parentWindow)
		{
			if (base.IsDisposed)
			{
				return;
			}
			int num = (parentWindow.Width - parentWindow.ClientSize.Width) / 2;
			int num2 = parentWindow.Height - parentWindow.ClientSize.Height - 2 * num;
			Point location = parentWindow.ClientRectangle.Location;
			location.X += parentWindow.Location.X + num;
			location.Y += parentWindow.Location.Y + num + num2;
			Size size = parentWindow.ClientRectangle.Size;
			if (this.m_anchor == AnchorStyles.None)
			{
				Point villageReportBackgroundLocation = InterfaceMgr.Instance.getVillageReportBackgroundLocation();
				location.X += villageReportBackgroundLocation.X + this.m_offset.X;
				location.Y += villageReportBackgroundLocation.Y + this.m_offset.Y;
			}
			else
			{
				if ((this.m_anchor & AnchorStyles.Top) != AnchorStyles.None)
				{
					location.Y += this.m_offset.Y;
				}
				else
				{
					location.Y = location.Y + size.Height - this.m_offset.Y;
				}
				if ((this.m_anchor & AnchorStyles.Left) != AnchorStyles.None)
				{
					location.X += this.m_offset.X;
				}
				else
				{
					location.X = location.X + size.Width - this.m_offset.X;
				}
			}
			if (this.m_upArrow)
			{
				location.X -= 28;
				location.Y -= 8;
				location.Y += this.m_animOffset;
			}
			else
			{
				location.X -= 47;
				location.Y -= 36;
				location.X -= this.m_animOffset;
			}
			base.Location = location;
		}

		// Token: 0x06002B85 RID: 11141 RVA: 0x002246B0 File Offset: 0x002228B0
		public static void CreateTutorialArrowWindow(bool upArrow, Point offset, AnchorStyles anchor, Form parentWindow)
		{
			bool flag = false;
			TutorialArrowWindow tutorialArrowWindow = InterfaceMgr.Instance.getTutorialArrowWindow();
			if (tutorialArrowWindow == null)
			{
				tutorialArrowWindow = new TutorialArrowWindow();
				flag = true;
			}
			else
			{
				if (parentWindow != TutorialArrowWindow.lastParent)
				{
					tutorialArrowWindow.Close();
					tutorialArrowWindow = new TutorialArrowWindow();
					flag = true;
				}
				if (!tutorialArrowWindow.Created || !tutorialArrowWindow.Visible)
				{
					flag = true;
				}
			}
			if (tutorialArrowWindow != null && (flag || offset != tutorialArrowWindow.m_offset || anchor != tutorialArrowWindow.m_anchor))
			{
				TutorialArrowWindow.lastParent = parentWindow;
				tutorialArrowWindow.show(upArrow, offset, anchor);
				tutorialArrowWindow.updateLocation(parentWindow);
				tutorialArrowWindow.showTutorialArrowWindow(flag, parentWindow);
			}
		}

		// Token: 0x06002B86 RID: 11142 RVA: 0x0022473C File Offset: 0x0022293C
		public static void updateArrow()
		{
			TutorialArrowWindow tutorialArrowWindow = InterfaceMgr.Instance.getTutorialArrowWindow();
			if (tutorialArrowWindow != null && tutorialArrowWindow.Created && tutorialArrowWindow.Visible)
			{
				tutorialArrowWindow.update();
			}
		}

		// Token: 0x04003618 RID: 13848
		public Point m_offset;

		// Token: 0x04003619 RID: 13849
		public AnchorStyles m_anchor = AnchorStyles.Top | AnchorStyles.Left;

		// Token: 0x0400361A RID: 13850
		private bool m_upArrow;

		// Token: 0x0400361B RID: 13851
		public int m_animOffset;

		// Token: 0x0400361C RID: 13852
		private int m_arrowAnimOffset;

		// Token: 0x0400361D RID: 13853
		private int m_arrowAnimClock;

		// Token: 0x0400361E RID: 13854
		public static Form lastParent;
	}
}
