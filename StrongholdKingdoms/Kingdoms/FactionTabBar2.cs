using System;
using System.Drawing;
using DXGraphics;

namespace Kingdoms
{
	// Token: 0x020001D4 RID: 468
	public class FactionTabBar2 : CustomSelfDrawPanel.CSDControl
	{
		// Token: 0x060011B6 RID: 4534 RVA: 0x0012C084 File Offset: 0x0012A284
		public void init()
		{
			this.clearControls();
			this.tabControl1.Position = new Point(306, 3);
			base.addControl(this.tabControl1);
			this.initImages();
			int num = this.tabControl1.Create(4, this.images);
			this.tabControl1.setCallback(0, new CustomSelfDrawPanel.CSDTabControl.TabClickedCallback(this.tabPage1_Enter), 2300);
			this.tabControl1.setCallback(1, new CustomSelfDrawPanel.CSDTabControl.TabClickedCallback(this.tabPage2_Enter), 2301);
			this.tabControl1.setCallback(2, new CustomSelfDrawPanel.CSDTabControl.TabClickedCallback(this.tabPage3_Enter), 2302);
			this.tabControl1.setCallback(3, new CustomSelfDrawPanel.CSDTabControl.TabClickedCallback(this.tabPage4_Enter), 0);
			this.tabControl1.setSoundCallback(new CustomSelfDrawPanel.CSDTabControl.TabClickedCallback(this.tabControl1_Click));
			if (num > 0)
			{
				this.Size = new Size(num, this.images[0].Height);
				this.tabControl1.Size = new Size(num, this.images[0].Height);
			}
		}

		// Token: 0x060011B7 RID: 4535 RVA: 0x0012C194 File Offset: 0x0012A394
		public void initImages()
		{
			this.images = new BaseImage[8];
			this.images[0] = GFXLibrary.FactionTabBar_1_Normal;
			this.images[1] = GFXLibrary.FactionTabBar_1_Selected;
			this.images[2] = GFXLibrary.FactionTabBar_2_Normal;
			this.images[3] = GFXLibrary.FactionTabBar_2_Selected;
			this.images[4] = GFXLibrary.FactionTabBar_3_Normal;
			this.images[5] = GFXLibrary.FactionTabBar_3_Selected;
			this.images[6] = GFXLibrary.FactionTabBar_3_Normal;
			this.images[7] = GFXLibrary.FactionTabBar_3_Selected;
		}

		// Token: 0x060011B8 RID: 4536 RVA: 0x000134D3 File Offset: 0x000116D3
		public void registerTabChangeCallback(FactionTabBar2.TabChangeCallback newTabChangeCallback)
		{
			this.tabChangeCallback = newTabChangeCallback;
		}

		// Token: 0x060011B9 RID: 4537 RVA: 0x000134DC File Offset: 0x000116DC
		private void tabPage1_Enter()
		{
			if (this.lastTab != 0 && !this.ignore)
			{
				this.lastTab = 0;
				this.tabChangeCallback(0);
			}
		}

		// Token: 0x060011BA RID: 4538 RVA: 0x00013501 File Offset: 0x00011701
		private void tabPage2_Enter()
		{
			if (this.lastTab != 1 && !this.ignore)
			{
				this.lastTab = 1;
				this.tabChangeCallback(1);
			}
		}

		// Token: 0x060011BB RID: 4539 RVA: 0x00013527 File Offset: 0x00011727
		private void tabPage3_Enter()
		{
			if (this.lastTab != 2 && !this.ignore)
			{
				this.lastTab = 2;
				this.tabChangeCallback(2);
			}
		}

		// Token: 0x060011BC RID: 4540 RVA: 0x0001354D File Offset: 0x0001174D
		private void tabPage4_Enter()
		{
			if (this.lastTab != 3 && !this.ignore)
			{
				this.lastTab = 3;
			}
		}

		// Token: 0x060011BD RID: 4541 RVA: 0x00013567 File Offset: 0x00011767
		public void changeTab(int tabID)
		{
			UniversalDebugLog.Log("FactionTabBar2.changeTab " + tabID.ToString());
			this.lastSoundTab = tabID;
			this.updateShownTabs();
			this.tabControl1.SelectedIndex = tabID;
		}

		// Token: 0x060011BE RID: 4542 RVA: 0x00013598 File Offset: 0x00011798
		public void changeTabGfxOnly(int tabID)
		{
			this.lastSoundTab = tabID;
			this.ignore = true;
			this.lastTab = tabID;
			this.tabControl1.SelectedIndex = tabID;
			this.ignore = false;
		}

		// Token: 0x060011BF RID: 4543 RVA: 0x0012C218 File Offset: 0x0012A418
		public void forceChangeTab(int tabID)
		{
			this.lastSoundTab = tabID;
			this.updateShownTabs();
			this.tabControl1.SelectedIndex = 3;
			this.ignore = true;
			if (tabID != 0)
			{
				this.tabControl1.SelectedIndex = 0;
			}
			else
			{
				this.tabControl1.SelectedIndex = 1;
			}
			this.ignore = false;
			GameEngine.Instance.forceFactionTabChange();
			this.tabControl1.SelectedIndex = tabID;
		}

		// Token: 0x060011C0 RID: 4544 RVA: 0x000135C2 File Offset: 0x000117C2
		public int getCurrentTab()
		{
			return this.tabControl1.SelectedIndex;
		}

		// Token: 0x060011C1 RID: 4545 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void updateShownTabs()
		{
		}

		// Token: 0x060011C2 RID: 4546 RVA: 0x000135CF File Offset: 0x000117CF
		private void tabControl1_Click()
		{
			if (this.lastSoundTab != this.lastTab)
			{
				this.lastSoundTab = this.lastTab;
				GameEngine.Instance.playInterfaceSound("FactionScreen_faction_tabbar_item_clicked");
			}
		}

		// Token: 0x04001805 RID: 6149
		private FactionTabBar2.TabChangeCallback tabChangeCallback;

		// Token: 0x04001806 RID: 6150
		private BaseImage[] images;

		// Token: 0x04001807 RID: 6151
		private CustomSelfDrawPanel.CSDTabControl tabControl1 = new CustomSelfDrawPanel.CSDTabControl();

		// Token: 0x04001808 RID: 6152
		private bool ignore;

		// Token: 0x04001809 RID: 6153
		private int lastTab = -1;

		// Token: 0x0400180A RID: 6154
		public bool lastVillageCapital;

		// Token: 0x0400180B RID: 6155
		private int lastSoundTab = -2;

		// Token: 0x020001D5 RID: 469
		// (Invoke) Token: 0x060011C5 RID: 4549
		public delegate void TabChangeCallback(int tabID);
	}
}
