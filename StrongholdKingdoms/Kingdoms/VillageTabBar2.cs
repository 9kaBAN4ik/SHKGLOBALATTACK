using System;
using System.Drawing;
using DXGraphics;

namespace Kingdoms
{
	// Token: 0x020004EE RID: 1262
	public class VillageTabBar2 : CustomSelfDrawPanel.CSDControl
	{
		// Token: 0x06002FD4 RID: 12244 RVA: 0x00275A80 File Offset: 0x00273C80
		public void init()
		{
			this.clearControls();
			this.tabControl1.Position = new Point(51, 3);
			base.addControl(this.tabControl1);
			this.initImages();
			int num = this.tabControl1.Create(10, this.images);
			this.tabControl1.setCallback(0, new CustomSelfDrawPanel.CSDTabControl.TabClickedCallback(this.tabPage1_Enter), 40);
			this.tabControl1.setCallback(1, new CustomSelfDrawPanel.CSDTabControl.TabClickedCallback(this.tabPage2_Enter), 41);
			this.tabControl1.setCallback(2, new CustomSelfDrawPanel.CSDTabControl.TabClickedCallback(this.tabPage3_Enter), 42);
			this.tabControl1.setCallback(3, new CustomSelfDrawPanel.CSDTabControl.TabClickedCallback(this.tabPage4_Enter), 43);
			this.tabControl1.setCallback(4, new CustomSelfDrawPanel.CSDTabControl.TabClickedCallback(this.tabPage5_Enter), 44);
			this.tabControl1.setCallback(5, new CustomSelfDrawPanel.CSDTabControl.TabClickedCallback(this.tabPage6_Enter), 45);
			this.tabControl1.setCallback(6, new CustomSelfDrawPanel.CSDTabControl.TabClickedCallback(this.tabPage7_Enter), 47);
			this.tabControl1.setCallback(7, new CustomSelfDrawPanel.CSDTabControl.TabClickedCallback(this.tabPage8_Enter), 48);
			this.tabControl1.setCallback(8, new CustomSelfDrawPanel.CSDTabControl.TabClickedCallback(this.tabPage9_Enter), 0);
			this.tabControl1.setCallback(9, new CustomSelfDrawPanel.CSDTabControl.TabClickedCallback(this.tabPage10_Enter), 0);
			this.tabControl1.setSoundCallback(new CustomSelfDrawPanel.CSDTabControl.TabClickedCallback(this.tabControl1_Click));
			if (num > 0)
			{
				this.Size = new Size(num, this.images[0].Height);
				this.tabControl1.Size = new Size(num, this.images[0].Height);
			}
		}

		// Token: 0x06002FD5 RID: 12245 RVA: 0x00275C24 File Offset: 0x00273E24
		public void initImages()
		{
			if (this.images == null)
			{
				this.images = new BaseImage[18];
				this.images[0] = GFXLibrary.VillageTabBar_1_Normal;
				this.images[1] = GFXLibrary.VillageTabBar_1_Selected;
				this.images[2] = GFXLibrary.VillageTabBar_2_Normal;
				this.images[3] = GFXLibrary.VillageTabBar_2_Selected;
				this.images[4] = GFXLibrary.VillageTabBar_3_Normal;
				this.images[5] = GFXLibrary.VillageTabBar_3_Selected;
				this.images[6] = GFXLibrary.VillageTabBar_5_Normal;
				this.images[7] = GFXLibrary.VillageTabBar_5_Selected;
				this.images[8] = GFXLibrary.VillageTabBar_7_Normal;
				this.images[9] = GFXLibrary.VillageTabBar_7_Selected;
				this.images[10] = GFXLibrary.VillageTabBar_6_Normal;
				this.images[11] = GFXLibrary.VillageTabBar_6_Selected;
				this.images[12] = GFXLibrary.VillageTabBar_8_Normal;
				this.images[13] = GFXLibrary.VillageTabBar_8_Selected;
				this.images[14] = GFXLibrary.VillageTabBar_9_Normal;
				this.images[15] = GFXLibrary.VillageTabBar_9_Selected;
				this.images[16] = GFXLibrary.VillageTabBar_4_Normal;
				this.images[17] = GFXLibrary.VillageTabBar_4_Selected;
			}
		}

		// Token: 0x06002FD6 RID: 12246 RVA: 0x00022B6E File Offset: 0x00020D6E
		public void registerTabChangeCallback(VillageTabBar2.TabChangeCallback newTabChangeCallback)
		{
			this.tabChangeCallback = newTabChangeCallback;
		}

		// Token: 0x06002FD7 RID: 12247 RVA: 0x00022B77 File Offset: 0x00020D77
		private void tabPage1_Enter()
		{
			if (this.lastTab != 0 && !this.ignore)
			{
				this.lastTab = 0;
				this.viaTabClick = true;
				this.tabChangeCallback(0);
				this.viaTabClick = false;
			}
		}

		// Token: 0x06002FD8 RID: 12248 RVA: 0x00022BAA File Offset: 0x00020DAA
		private void tabPage2_Enter()
		{
			if (this.lastTab != 1 && !this.ignore)
			{
				this.lastTab = 1;
				this.viaTabClick = true;
				this.tabChangeCallback(1);
				this.viaTabClick = false;
			}
		}

		// Token: 0x06002FD9 RID: 12249 RVA: 0x00022BDE File Offset: 0x00020DDE
		private void tabPage3_Enter()
		{
			if (this.lastTab != 2 && !this.ignore)
			{
				this.lastTab = 2;
				this.viaTabClick = true;
				this.tabChangeCallback(2);
				this.viaTabClick = false;
			}
		}

		// Token: 0x06002FDA RID: 12250 RVA: 0x00022C12 File Offset: 0x00020E12
		private void tabPage4_Enter()
		{
			if (this.lastTab != 3 && !this.ignore)
			{
				this.lastTab = 3;
				this.viaTabClick = true;
				this.tabChangeCallback(3);
				this.viaTabClick = false;
			}
		}

		// Token: 0x06002FDB RID: 12251 RVA: 0x00022C46 File Offset: 0x00020E46
		private void tabPage5_Enter()
		{
			if (this.lastTab != 4 && !this.ignore)
			{
				this.lastTab = 4;
				this.viaTabClick = true;
				this.tabChangeCallback(4);
				this.viaTabClick = false;
			}
		}

		// Token: 0x06002FDC RID: 12252 RVA: 0x00022C7A File Offset: 0x00020E7A
		private void tabPage6_Enter()
		{
			if (this.lastTab != 5 && !this.ignore)
			{
				this.lastTab = 5;
				this.viaTabClick = true;
				this.tabChangeCallback(5);
				this.viaTabClick = false;
			}
		}

		// Token: 0x06002FDD RID: 12253 RVA: 0x00022CAE File Offset: 0x00020EAE
		private void tabPage7_Enter()
		{
			if (this.lastTab != 6 && !this.ignore)
			{
				this.lastTab = 6;
				this.viaTabClick = true;
				this.tabChangeCallback(6);
				this.viaTabClick = false;
			}
		}

		// Token: 0x06002FDE RID: 12254 RVA: 0x00022CE2 File Offset: 0x00020EE2
		private void tabPage8_Enter()
		{
			if (this.lastTab != 7 && !this.ignore)
			{
				this.lastTab = 7;
				this.viaTabClick = true;
				this.tabChangeCallback(7);
				this.viaTabClick = false;
			}
		}

		// Token: 0x06002FDF RID: 12255 RVA: 0x00022D16 File Offset: 0x00020F16
		private void tabPage9_Enter()
		{
			if (this.lastTab != 8 && !this.ignore)
			{
				this.lastTab = 8;
				this.viaTabClick = true;
				this.tabChangeCallback(8);
				this.viaTabClick = false;
			}
		}

		// Token: 0x06002FE0 RID: 12256 RVA: 0x00022D4A File Offset: 0x00020F4A
		private void tabPage10_Enter()
		{
			if (this.lastTab != 9 && !this.ignore)
			{
				this.lastTab = 9;
			}
		}

		// Token: 0x06002FE1 RID: 12257 RVA: 0x00022D66 File Offset: 0x00020F66
		public void changeTab(int tabID)
		{
			this.lastSoundTab = tabID;
			this.updateShownTabs();
			this.tabControl1.SelectedIndex = tabID;
		}

		// Token: 0x06002FE2 RID: 12258 RVA: 0x00022D81 File Offset: 0x00020F81
		public void changeTabGfxOnly(int tabID)
		{
			if (!this.viaTabClick)
			{
				this.lastSoundTab = tabID;
			}
			this.ignore = true;
			this.lastTab = tabID;
			this.tabControl1.SelectedIndex = tabID;
			this.ignore = false;
		}

		// Token: 0x06002FE3 RID: 12259 RVA: 0x00275D3C File Offset: 0x00273F3C
		public void forceChangeTab(int tabID)
		{
			this.lastSoundTab = tabID;
			this.updateShownTabs();
			this.tabControl1.SelectedIndex = 9;
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
			this.tabControl1.SelectedIndex = tabID;
		}

		// Token: 0x06002FE4 RID: 12260 RVA: 0x00022DB3 File Offset: 0x00020FB3
		public int getCurrentTab()
		{
			return this.tabControl1.SelectedIndex;
		}

		// Token: 0x06002FE5 RID: 12261 RVA: 0x00275D9C File Offset: 0x00273F9C
		public void updateShownTabs()
		{
			InterfaceMgr.Instance.updateVillageInfoBar();
			if (InterfaceMgr.Instance.isSelectedVillageACapital())
			{
				this.lastVillageCapital = true;
			}
			else
			{
				this.lastVillageCapital = false;
			}
			if (InterfaceMgr.Instance.isSelectedVillageACapital())
			{
				if (GameEngine.Instance.LocalWorldData.EraWorld)
				{
					this.tabControl1.Position = new Point(105, 3);
				}
				else
				{
					this.tabControl1.Position = new Point(51, 3);
				}
				this.images[10] = GFXLibrary.VillageTabBar_INFO_Normal;
				this.images[11] = GFXLibrary.VillageTabBar_INFO_Selected;
				this.images[12] = GFXLibrary.VillageTabBar_VOTE_Normal;
				this.images[13] = GFXLibrary.VillageTabBar_VOTE_Selected;
				this.images[14] = GFXLibrary.VillageTabBar_FORUM_Normal;
				this.images[15] = GFXLibrary.VillageTabBar_FORUM_Selected;
				this.tabControl1.setTooltip(5, 49);
				this.tabControl1.setTooltip(6, 50);
				this.tabControl1.setTooltip(7, 51);
			}
			else
			{
				this.tabControl1.Position = new Point(51, 3);
				this.images[10] = GFXLibrary.VillageTabBar_6_Normal;
				this.images[11] = GFXLibrary.VillageTabBar_6_Selected;
				this.images[12] = GFXLibrary.VillageTabBar_8_Normal;
				this.images[13] = GFXLibrary.VillageTabBar_8_Selected;
				this.images[14] = GFXLibrary.VillageTabBar_9_Normal;
				this.images[15] = GFXLibrary.VillageTabBar_9_Selected;
				this.tabControl1.setTooltip(5, 45);
				this.tabControl1.setTooltip(6, 47);
				this.tabControl1.setTooltip(7, 48);
			}
			this.tabControl1.updateImageArray(this.images);
		}

		// Token: 0x06002FE6 RID: 12262 RVA: 0x00022DC0 File Offset: 0x00020FC0
		private void tabControl1_Click()
		{
			if (this.lastSoundTab != this.lastTab)
			{
				this.lastSoundTab = this.lastTab;
				GameEngine.Instance.playInterfaceSound("VillageScreen_village_tabbar_item_clicked");
			}
		}

		// Token: 0x06002FE7 RID: 12263 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void updateAlert()
		{
		}

		// Token: 0x04003C49 RID: 15433
		private VillageTabBar2.TabChangeCallback tabChangeCallback;

		// Token: 0x04003C4A RID: 15434
		private BaseImage[] images;

		// Token: 0x04003C4B RID: 15435
		private CustomSelfDrawPanel.CSDTabControl tabControl1 = new CustomSelfDrawPanel.CSDTabControl();

		// Token: 0x04003C4C RID: 15436
		private bool ignore;

		// Token: 0x04003C4D RID: 15437
		private int lastTab = -1;

		// Token: 0x04003C4E RID: 15438
		private bool viaTabClick;

		// Token: 0x04003C4F RID: 15439
		public bool lastVillageCapital;

		// Token: 0x04003C50 RID: 15440
		private int lastSoundTab = -2;

		// Token: 0x020004EF RID: 1263
		// (Invoke) Token: 0x06002FEA RID: 12266
		public delegate void TabChangeCallback(int tabID);
	}
}
