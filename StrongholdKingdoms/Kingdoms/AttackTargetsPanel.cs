using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020000D3 RID: 211
	public class AttackTargetsPanel : CustomSelfDrawPanel
	{
		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060005FB RID: 1531 RVA: 0x0000B2B8 File Offset: 0x000094B8
		public static List<WorldMap.VillageNameItem> VillageHistory
		{
			get
			{
				return AttackTargetsPanel.villageHistory;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060005FC RID: 1532 RVA: 0x0000B2BF File Offset: 0x000094BF
		public static List<WorldMap.VillageNameItem> VillageFavourites
		{
			get
			{
				return AttackTargetsPanel.villageFavourites;
			}
		}

		// Token: 0x060005FD RID: 1533 RVA: 0x0007935C File Offset: 0x0007755C
		public static void addHistory(List<GenericVillageHistoryData> newData)
		{
			AttackTargetsPanel.villageHistory.Clear();
			if (newData != null)
			{
				foreach (GenericVillageHistoryData genericVillageHistoryData in newData)
				{
					WorldMap.VillageNameItem villageNameItem = new WorldMap.VillageNameItem();
					villageNameItem.villageID = genericVillageHistoryData.villageID;
					AttackTargetsPanel.villageHistory.Add(villageNameItem);
				}
			}
		}

		// Token: 0x060005FE RID: 1534 RVA: 0x000793D0 File Offset: 0x000775D0
		public static void addFavourites(List<GenericVillageHistoryData> newData)
		{
			AttackTargetsPanel.villageFavourites.Clear();
			if (newData != null)
			{
				foreach (GenericVillageHistoryData genericVillageHistoryData in newData)
				{
					WorldMap.VillageNameItem villageNameItem = new WorldMap.VillageNameItem();
					villageNameItem.villageID = genericVillageHistoryData.villageID;
					AttackTargetsPanel.villageFavourites.Add(villageNameItem);
				}
			}
		}

		// Token: 0x060005FF RID: 1535 RVA: 0x00079444 File Offset: 0x00077644
		public static void addRecent(int villageID)
		{
			WorldMap.VillageNameItem villageNameItem = new WorldMap.VillageNameItem();
			villageNameItem.villageID = villageID;
			AttackTargetsPanel.villageHistory.Add(villageNameItem);
		}

		// Token: 0x06000600 RID: 1536 RVA: 0x0007946C File Offset: 0x0007766C
		public static void addFavourite(int villageID)
		{
			if (!AttackTargetsPanel.isFavourite(villageID))
			{
				WorldMap.VillageNameItem villageNameItem = new WorldMap.VillageNameItem();
				villageNameItem.villageID = villageID;
				AttackTargetsPanel.villageFavourites.Add(villageNameItem);
				RemoteServices.Instance.UpdateVillageFavourites(4, villageID);
			}
		}

		// Token: 0x06000601 RID: 1537 RVA: 0x000794A8 File Offset: 0x000776A8
		public static void removeFavourite(int villageID)
		{
			if (AttackTargetsPanel.isFavourite(villageID))
			{
				foreach (WorldMap.VillageNameItem villageNameItem in AttackTargetsPanel.villageFavourites)
				{
					if (villageNameItem.villageID == villageID)
					{
						AttackTargetsPanel.villageFavourites.Remove(villageNameItem);
						RemoteServices.Instance.UpdateVillageFavourites(5, villageID);
						break;
					}
				}
			}
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x00079520 File Offset: 0x00077720
		public static bool isFavourite(int villageID)
		{
			foreach (WorldMap.VillageNameItem villageNameItem in AttackTargetsPanel.villageFavourites)
			{
				if (villageNameItem.villageID == villageID)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000603 RID: 1539 RVA: 0x0007957C File Offset: 0x0007777C
		public AttackTargetsPanel()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06000604 RID: 1540 RVA: 0x000795FC File Offset: 0x000777FC
		public void init(AttackTargetsPopup parent)
		{
			this.m_parent = parent;
			base.Size = this.m_parent.Size;
			this.BackColor = global::ARGBColors.Transparent;
			CustomSelfDrawPanel.CSDImage csdimage = new CustomSelfDrawPanel.CSDImage();
			csdimage.Alpha = 0.1f;
			csdimage.Image = GFXLibrary.formations_img;
			csdimage.Scale = 5.0;
			csdimage.Position = new Point(0, 0);
			csdimage.Size = base.Size;
			base.addControl(csdimage);
			this.favouritesHeader.Text = SK.Text("Attack_Targets_Favourites", "Favourite Targets");
			this.favouritesHeader.Color = global::ARGBColors.White;
			this.favouritesHeader.Position = new Point(30, 0);
			this.favouritesHeader.Size = new Size(300, 30);
			this.favouritesHeader.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.favouritesHeader.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			csdimage.addControl(this.favouritesHeader);
			this.recentHeader.Text = SK.Text("Attack_Targets_Recent", "Recent Targets");
			this.recentHeader.Color = global::ARGBColors.White;
			this.recentHeader.Position = new Point(370, 0);
			this.recentHeader.Size = new Size(300, 30);
			this.recentHeader.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.recentHeader.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			csdimage.addControl(this.recentHeader);
			this.favouritesList.Size = new Size(300, 342);
			this.favouritesList.Position = new Point(30, 30);
			csdimage.addControl(this.favouritesList);
			this.favouritesList.Create(19, 18);
			this.favouritesList.setLineClickedDelegate(new CustomSelfDrawPanel.CSDListBox.CSD_LineClickedDelegate(this.favouriteClick));
			this.favouritesList.setDoubleClickedDelegate(new CustomSelfDrawPanel.CSDListBox.CSD_LineClickedDelegate(this.favouriteDoubleClick));
			this.recentList.Size = new Size(300, 342);
			this.recentList.Position = new Point(370, 30);
			csdimage.addControl(this.recentList);
			this.recentList.Create(19, 18);
			this.recentList.setLineClickedDelegate(new CustomSelfDrawPanel.CSDListBox.CSD_LineClickedDelegate(this.recentClick));
			this.recentList.setDoubleClickedDelegate(new CustomSelfDrawPanel.CSDListBox.CSD_LineClickedDelegate(this.recentDoubleClick));
			this.closeButton.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
			this.closeButton.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
			this.closeButton.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
			this.closeButton.Position = new Point(540, base.Height - 70);
			this.closeButton.Text.Text = SK.Text("GENERIC_Close", "Close");
			this.closeButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.closeButton.TextYOffset = -3;
			this.closeButton.Text.Color = global::ARGBColors.Black;
			this.closeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick));
			csdimage.addControl(this.closeButton);
			this.attackButton.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
			this.attackButton.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
			this.attackButton.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
			this.attackButton.Position = new Point(380, base.Height - 70);
			this.attackButton.Text.Text = SK.Text("GENERIC_Attack", "Attack");
			this.attackButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.attackButton.TextYOffset = -3;
			this.attackButton.Text.Color = global::ARGBColors.Black;
			this.attackButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.attackClicked));
			this.attackButton.Enabled = false;
			csdimage.addControl(this.attackButton);
			this.scoutButton.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
			this.scoutButton.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
			this.scoutButton.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
			this.scoutButton.Position = new Point(220, base.Height - 70);
			this.scoutButton.Text.Text = SK.Text("GENERIC_Scout", "Scout");
			this.scoutButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.scoutButton.TextYOffset = -3;
			this.scoutButton.Text.Color = global::ARGBColors.Black;
			this.scoutButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.scoutClicked));
			this.scoutButton.Enabled = false;
			csdimage.addControl(this.scoutButton);
			this.removeButton.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
			this.removeButton.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
			this.removeButton.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
			this.removeButton.Position = new Point(30, base.Height - 70);
			this.removeButton.Text.Text = SK.Text("MailScreen_Remove", "Remove");
			this.removeButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.removeButton.TextYOffset = -3;
			this.removeButton.Text.Color = global::ARGBColors.Black;
			this.removeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.removeClicked));
			this.removeButton.Visible = false;
			csdimage.addControl(this.removeButton);
			this.fillBoxes();
		}

		// Token: 0x06000605 RID: 1541 RVA: 0x00079C2C File Offset: 0x00077E2C
		private void fillBoxes()
		{
			List<CustomSelfDrawPanel.CSDListItem> list = new List<CustomSelfDrawPanel.CSDListItem>();
			foreach (WorldMap.VillageNameItem villageNameItem in AttackTargetsPanel.villageFavourites)
			{
				if (GameEngine.Instance.World.isVillageVisible(villageNameItem.villageID))
				{
					list.Add(new CustomSelfDrawPanel.CSDListItem
					{
						Text = GameEngine.Instance.World.getVillageNameOrType(villageNameItem.villageID),
						Data = villageNameItem.villageID
					});
				}
			}
			list.Sort((CustomSelfDrawPanel.CSDListItem first, CustomSelfDrawPanel.CSDListItem next) => first.Text.CompareTo(next.Text));
			this.favouritesList.populate(list);
			List<CustomSelfDrawPanel.CSDListItem> list2 = new List<CustomSelfDrawPanel.CSDListItem>();
			foreach (WorldMap.VillageNameItem villageNameItem2 in AttackTargetsPanel.villageHistory)
			{
				if (GameEngine.Instance.World.isVillageVisible(villageNameItem2.villageID))
				{
					list2.Add(new CustomSelfDrawPanel.CSDListItem
					{
						Text = GameEngine.Instance.World.getVillageNameOrType(villageNameItem2.villageID),
						Data = villageNameItem2.villageID
					});
				}
			}
			list2.Sort((CustomSelfDrawPanel.CSDListItem first, CustomSelfDrawPanel.CSDListItem next) => first.Text.CompareTo(next.Text));
			this.recentList.populate(list2);
		}

		// Token: 0x06000606 RID: 1542 RVA: 0x0000B2C6 File Offset: 0x000094C6
		private void closeClick()
		{
			InterfaceMgr.Instance.closeAttackTargetsPopup();
		}

		// Token: 0x06000607 RID: 1543 RVA: 0x0000B2D2 File Offset: 0x000094D2
		private void favouriteClick(CustomSelfDrawPanel.CSDListItem item)
		{
			if (item != null)
			{
				this.recentList.clearSelectedItem();
				if (item.Data >= 0)
				{
					this.m_selectedVillageID = item.Data;
					this.removeButton.Visible = true;
					this.updateButtons();
				}
			}
		}

		// Token: 0x06000608 RID: 1544 RVA: 0x00079DC4 File Offset: 0x00077FC4
		private void favouriteDoubleClick(CustomSelfDrawPanel.CSDListItem item)
		{
			if (item != null)
			{
				this.recentList.clearSelectedItem();
				if (item.Data >= 0)
				{
					this.m_selectedVillageID = item.Data;
					GameEngine.Instance.World.zoomToVillage(item.Data);
					InterfaceMgr.Instance.displaySelectedVillagePanel(item.Data, false, true, false, false);
					this.removeButton.Visible = true;
					this.updateButtons();
				}
			}
		}

		// Token: 0x06000609 RID: 1545 RVA: 0x0000B309 File Offset: 0x00009509
		private void recentClick(CustomSelfDrawPanel.CSDListItem item)
		{
			if (item != null)
			{
				this.favouritesList.clearSelectedItem();
				if (item.Data >= 0)
				{
					this.m_selectedVillageID = item.Data;
					this.removeButton.Visible = false;
					this.updateButtons();
				}
			}
		}

		// Token: 0x0600060A RID: 1546 RVA: 0x00079E30 File Offset: 0x00078030
		private void recentDoubleClick(CustomSelfDrawPanel.CSDListItem item)
		{
			if (item != null)
			{
				this.favouritesList.clearSelectedItem();
				if (item.Data >= 0)
				{
					this.m_selectedVillageID = item.Data;
					GameEngine.Instance.World.zoomToVillage(item.Data);
					InterfaceMgr.Instance.displaySelectedVillagePanel(item.Data, false, true, false, false);
					this.removeButton.Visible = false;
					this.updateButtons();
				}
			}
		}

		// Token: 0x0600060B RID: 1547 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void listDoubleClick(CustomSelfDrawPanel.CSDListItem item)
		{
		}

		// Token: 0x0600060C RID: 1548 RVA: 0x00079E9C File Offset: 0x0007809C
		private void updateButtons()
		{
			if (this.m_selectedVillageID < 0)
			{
				this.attackButton.Enabled = false;
				this.scoutButton.Enabled = false;
				return;
			}
			if (GameEngine.Instance.World.getSpecial(this.m_selectedVillageID) != 0)
			{
				this.attackButton.Enabled = GameEngine.Instance.World.isAttackableSpecial(this.m_selectedVillageID);
				this.scoutButton.Enabled = (GameEngine.Instance.World.isScoutableSpecial(this.m_selectedVillageID) && !GameEngine.Instance.World.isCapital(InterfaceMgr.Instance.OwnSelectedVillage));
				return;
			}
			if (!GameEngine.Instance.World.isCapital(InterfaceMgr.Instance.OwnSelectedVillage))
			{
				this.scoutButton.Enabled = true;
				this.attackButton.Enabled = true;
				return;
			}
			this.scoutButton.Enabled = false;
			if (!GameEngine.Instance.World.isUserVillage(InterfaceMgr.Instance.getSelectedMenuVillage()))
			{
				this.attackButton.Enabled = false;
				return;
			}
			this.attackButton.Enabled = true;
		}

		// Token: 0x0600060D RID: 1549 RVA: 0x0000B340 File Offset: 0x00009540
		private void attackClicked()
		{
			this.closeClick();
			GameEngine.Instance.preAttackSetup(InterfaceMgr.Instance.OwnSelectedVillage, InterfaceMgr.Instance.OwnSelectedVillage, this.m_selectedVillageID);
		}

		// Token: 0x0600060E RID: 1550 RVA: 0x0000B36C File Offset: 0x0000956C
		private void scoutClicked()
		{
			InterfaceMgr.Instance.openScoutPopupWindow(this.m_selectedVillageID, true);
			this.closeClick();
		}

		// Token: 0x0600060F RID: 1551 RVA: 0x0000B386 File Offset: 0x00009586
		private void removeClicked()
		{
			AttackTargetsPanel.removeFavourite(this.m_selectedVillageID);
			this.fillBoxes();
			this.removeButton.Visible = false;
		}

		// Token: 0x040007A9 RID: 1961
		private static List<WorldMap.VillageNameItem> villageHistory = new List<WorldMap.VillageNameItem>();

		// Token: 0x040007AA RID: 1962
		private static List<WorldMap.VillageNameItem> villageFavourites = new List<WorldMap.VillageNameItem>();

		// Token: 0x040007AB RID: 1963
		private int m_selectedVillageID = -1;

		// Token: 0x040007AC RID: 1964
		private AttackTargetsPopup m_parent;

		// Token: 0x040007AD RID: 1965
		private CustomSelfDrawPanel.CSDLabel favouritesHeader = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040007AE RID: 1966
		private CustomSelfDrawPanel.CSDLabel recentHeader = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040007AF RID: 1967
		private CustomSelfDrawPanel.CSDListBox favouritesList = new CustomSelfDrawPanel.CSDListBox();

		// Token: 0x040007B0 RID: 1968
		private CustomSelfDrawPanel.CSDListBox recentList = new CustomSelfDrawPanel.CSDListBox();

		// Token: 0x040007B1 RID: 1969
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040007B2 RID: 1970
		private CustomSelfDrawPanel.CSDButton attackButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040007B3 RID: 1971
		private CustomSelfDrawPanel.CSDButton scoutButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040007B4 RID: 1972
		private CustomSelfDrawPanel.CSDButton removeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040007B5 RID: 1973
		[CompilerGenerated]
		private static Comparison<CustomSelfDrawPanel.CSDListItem> _003C_003E9__CachedAnonymousMethodDelegate2;

		// Token: 0x040007B6 RID: 1974
		[CompilerGenerated]
		private static Comparison<CustomSelfDrawPanel.CSDListItem> _003C_003E9__CachedAnonymousMethodDelegate3;
	}
}
