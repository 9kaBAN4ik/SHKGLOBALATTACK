using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x0200047F RID: 1151
	public partial class SearchForVillagePopup : MyFormBase
	{
		// Token: 0x060029D5 RID: 10709 RVA: 0x00205B34 File Offset: 0x00203D34
		public SearchForVillagePopup()
		{
			this.InitializeComponent();
			this.lblSearchByID.Text = SK.Text("SearchForVillagePopup_search_by_ID", "Search By Village ID");
			this.lblSearchByName.Text = SK.Text("SearchForVillagePopup_search_by_Name", "Search By Village Name");
			this.btnCancel.Text = SK.Text("GENERIC_Close", "Close");
			this.Text = (base.Title = SK.Text("SearchForVillagePopup_for_village", "Search For Village"));
			this.btnSearchByID.Text = SK.Text("MailUserPopup_Search", "Search");
			this.btnSearchByName.Text = SK.Text("MailUserPopup_Search", "Search");
			if (!Program.mySettings.viewVillageIDs)
			{
				this.lblSearchByID.Visible = false;
				this.btnSearchByID.Visible = false;
				this.tbVillageID.Visible = false;
			}
			this.btnSearchByName.Enabled = false;
			this.btnSearchByID.Enabled = false;
		}

		// Token: 0x060029D6 RID: 10710 RVA: 0x0001E230 File Offset: 0x0001C430
		private void btnCancel_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("RenameVillagePopup_cancel");
			base.Close();
		}

		// Token: 0x060029D7 RID: 10711 RVA: 0x0001EC34 File Offset: 0x0001CE34
		private void tbNewName_TextChanged(object sender, EventArgs e)
		{
			if (this.tbSearchName.Text.Length > 0)
			{
				this.btnSearchByName.Enabled = true;
				return;
			}
			this.btnSearchByName.Enabled = false;
		}

		// Token: 0x060029D8 RID: 10712 RVA: 0x00205C38 File Offset: 0x00203E38
		private void btnSearchByName_Click(object sender, EventArgs e)
		{
			if (this.tbSearchName.Text.Length > 0)
			{
				List<int> list = GameEngine.Instance.World.searchVillageNames(this.tbSearchName.Text);
				this.listBoxVillages.Items.Clear();
				foreach (int villageID in list)
				{
					SearchForVillagePopup.VillageItem villageItem = new SearchForVillagePopup.VillageItem();
					villageItem.villageID = villageID;
					this.listBoxVillages.Items.Add(villageItem);
				}
			}
		}

		// Token: 0x060029D9 RID: 10713 RVA: 0x00205CDC File Offset: 0x00203EDC
		private void btnSearchByID_Click(object sender, EventArgs e)
		{
			int int32FromString = SearchForVillagePopup.getInt32FromString(this.tbVillageID.Text);
			if (int32FromString >= 0)
			{
				this.listBoxVillages.Items.Clear();
				if ((!GameEngine.Instance.World.isCapital(int32FromString) || Program.mySettings.viewCapitalIDs) && (!GameEngine.Instance.World.isSpecial(int32FromString) || this.aiWorldSpecial(int32FromString) || SpecialVillageTypes.IS_ROYAL_TOWER(GameEngine.Instance.World.getSpecial(int32FromString))) && GameEngine.Instance.World.isVillageVisible(int32FromString))
				{
					SearchForVillagePopup.VillageItem villageItem = new SearchForVillagePopup.VillageItem();
					villageItem.villageID = int32FromString;
					this.listBoxVillages.Items.Add(villageItem);
				}
			}
		}

		// Token: 0x060029DA RID: 10714 RVA: 0x00205D94 File Offset: 0x00203F94
		private bool aiWorldSpecial(int villageID)
		{
			if (!GameEngine.Instance.LocalWorldData.AIWorld)
			{
				return false;
			}
			if (GameEngine.Instance.World.isSpecial(villageID))
			{
				switch (GameEngine.Instance.World.getSpecial(villageID))
				{
				case 7:
				case 9:
				case 11:
				case 13:
					return true;
				}
				return false;
			}
			return false;
		}

		// Token: 0x060029DB RID: 10715 RVA: 0x0001EC62 File Offset: 0x0001CE62
		private void tbVillageID_TextChanged(object sender, EventArgs e)
		{
			if (SearchForVillagePopup.getInt32FromString(this.tbVillageID.Text) >= 0)
			{
				this.btnSearchByID.Enabled = true;
				return;
			}
			this.btnSearchByID.Enabled = false;
		}

		// Token: 0x060029DC RID: 10716 RVA: 0x00205E04 File Offset: 0x00204004
		public static int getInt32FromString(string text)
		{
			if (text.Length == 0)
			{
				return -1;
			}
			try
			{
				return Convert.ToInt32(text);
			}
			catch (Exception)
			{
			}
			return -1;
		}

		// Token: 0x060029DD RID: 10717 RVA: 0x00205E3C File Offset: 0x0020403C
		private void listBoxVillages_DoubleClick(object sender, EventArgs e)
		{
			if (this.listBoxVillages.SelectedIndex >= 0)
			{
				SearchForVillagePopup.VillageItem villageItem = (SearchForVillagePopup.VillageItem)this.listBoxVillages.SelectedItem;
				if (villageItem != null)
				{
					GameEngine.Instance.World.zoomToVillage(villageItem.villageID);
					base.Close();
				}
			}
		}

		// Token: 0x060029DE RID: 10718 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void tbSearchName_KeyUp(object sender, KeyEventArgs e)
		{
		}

		// Token: 0x060029DF RID: 10719 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void tbVillageID_KeyUp(object sender, KeyEventArgs e)
		{
		}

		// Token: 0x060029E0 RID: 10720 RVA: 0x0001EC90 File Offset: 0x0001CE90
		private void tbSearchName_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				this.btnSearchByName_Click(sender, e);
				e.Handled = true;
			}
		}

		// Token: 0x060029E1 RID: 10721 RVA: 0x0001ECAB File Offset: 0x0001CEAB
		private void tbVillageID_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				this.btnSearchByID_Click(sender, e);
				e.Handled = true;
			}
		}

		// Token: 0x02000480 RID: 1152
		private class VillageItem
		{
			// Token: 0x060029E4 RID: 10724 RVA: 0x0001ECE5 File Offset: 0x0001CEE5
			public override string ToString()
			{
				return GameEngine.Instance.World.getVillageNameOrType(this.villageID);
			}

			// Token: 0x04003381 RID: 13185
			public int villageID = -1;
		}
	}
}
