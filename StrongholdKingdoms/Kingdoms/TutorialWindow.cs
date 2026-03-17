using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x020004A9 RID: 1193
	public partial class TutorialWindow : Form
	{
		// Token: 0x1700023A RID: 570
		// (get) Token: 0x06002BA3 RID: 11171 RVA: 0x0000A849 File Offset: 0x00008A49
		protected override bool ShowWithoutActivation
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06002BA6 RID: 11174 RVA: 0x000200E0 File Offset: 0x0001E2E0
		public TutorialWindow()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x06002BA7 RID: 11175 RVA: 0x00020103 File Offset: 0x0001E303
		public void setText(int tutorialID, bool force)
		{
			this.customPanel.setText(tutorialID, this, force);
		}

		// Token: 0x06002BA8 RID: 11176 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void hidingTooltip()
		{
		}

		// Token: 0x06002BA9 RID: 11177 RVA: 0x00020113 File Offset: 0x0001E313
		public void closing()
		{
			this.customPanel.closing();
		}

		// Token: 0x06002BAA RID: 11178 RVA: 0x00020120 File Offset: 0x0001E320
		public void showTutorialWindow(bool doShow, Form parentWindow)
		{
			base.ResumeLayout(false);
			base.PerformLayout();
			InterfaceMgr.Instance.setCurrentTutorialWindow(this);
			if (parentWindow == null)
			{
				parentWindow = InterfaceMgr.Instance.ParentForm;
			}
			if (doShow)
			{
				base.Show(parentWindow);
			}
		}

		// Token: 0x06002BAB RID: 11179 RVA: 0x00020153 File Offset: 0x0001E353
		public void update()
		{
			if (base.Visible && base.Created)
			{
				this.customPanel.update();
				return;
			}
			this.customPanel.invisiUpdate();
		}

		// Token: 0x06002BAC RID: 11180 RVA: 0x00227058 File Offset: 0x00225258
		public void updateLocation(int tutorialID, Form parentWindow)
		{
			if (!base.IsDisposed)
			{
				Point location = parentWindow.Location;
				location.X += 4;
				location.Y += parentWindow.Height - base.Size.Height - 4;
				base.Location = location;
			}
		}

		// Token: 0x06002BAD RID: 11181 RVA: 0x002270B0 File Offset: 0x002252B0
		public static void CreateTutorialWindow(int tutorialID, Form parentWindow)
		{
			bool flag = false;
			TutorialWindow tutorialWindow = InterfaceMgr.Instance.getTutorialWindow();
			if (tutorialWindow == null)
			{
				tutorialWindow = new TutorialWindow();
				flag = true;
			}
			else
			{
				if (parentWindow != TutorialWindow.lastParent)
				{
					tutorialWindow.Close();
					tutorialWindow = new TutorialWindow();
					flag = true;
				}
				if (!tutorialWindow.Created || !tutorialWindow.Visible)
				{
					flag = true;
				}
			}
			if (tutorialWindow != null)
			{
				TutorialWindow.lastParent = parentWindow;
				tutorialWindow.setText(tutorialID, flag);
				tutorialWindow.updateLocation(tutorialID, parentWindow);
				tutorialWindow.showTutorialWindow(flag, parentWindow);
			}
		}

		// Token: 0x06002BAE RID: 11182 RVA: 0x00227120 File Offset: 0x00225320
		public static void runTutorial()
		{
			if (GameEngine.Instance.World.numVillagesOwned() == 0 || GameEngine.Instance.World.WorldEnded)
			{
				return;
			}
			bool flag = true;
			if (InterfaceMgr.Instance.isTutorialWindowOpen() && !flag)
			{
				InterfaceMgr.Instance.closeTutorialWindow();
			}
			if (flag && GameEngine.Instance.World.isNewTutorialAvailable() && !GameEngine.Instance.isSelectNewVillageVisible())
			{
				int tutorialStage = GameEngine.Instance.World.getTutorialStage();
				switch (tutorialStage)
				{
				case -3:
				case -1:
					InterfaceMgr.Instance.closeTutorialWindow();
					InterfaceMgr.Instance.ParentForm.TopMost = true;
					InterfaceMgr.Instance.ParentForm.TopMost = false;
					InterfaceMgr.Instance.closeTutorialArrowWindow();
					goto IL_EF;
				case 0:
					GameEngine.Instance.World.advanceTutorial();
					goto IL_EF;
				}
				TutorialWindow.CreateTutorialWindow(tutorialStage, InterfaceMgr.Instance.ParentForm);
				TutorialWindow.tutorialWindowOverForm = 0;
				IL_EF:
				GameEngine.Instance.World.tutorialPopupShown();
			}
		}

		// Token: 0x06002BAF RID: 11183 RVA: 0x0022722C File Offset: 0x0022542C
		public static void tooltip(Point dxMousePos)
		{
			TutorialWindow.overIcon = false;
			if ((GameEngine.Instance.World.isTutorialActive() || Program.mySettings.showGameFeaturesScreenIcon) && dxMousePos.X < 64 && dxMousePos.Y > GameEngine.Instance.GFX.viewHeight() - 64)
			{
				TutorialWindow.overIcon = true;
				if (GameEngine.Instance.World.isTutorialActive())
				{
					CustomTooltipManager.MouseEnterTooltipArea(1600);
					return;
				}
				if (Program.mySettings.showGameFeaturesScreenIcon)
				{
					CustomTooltipManager.MouseEnterTooltipArea(1601);
				}
			}
		}

		// Token: 0x0400363B RID: 13883
		private static Form lastParent;

		// Token: 0x0400363C RID: 13884
		public static int tutorialWindowOverForm;

		// Token: 0x0400363D RID: 13885
		public static bool overIcon;
	}
}
