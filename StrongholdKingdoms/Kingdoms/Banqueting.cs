using System;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020000DC RID: 220
	public class Banqueting
	{
		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000662 RID: 1634 RVA: 0x0000B5F4 File Offset: 0x000097F4
		public int researchLevel
		{
			get
			{
				return (int)GameEngine.Instance.World.UserResearchData.Research_Craftsmanship;
			}
		}

		// Token: 0x06000663 RID: 1635 RVA: 0x0000B60A File Offset: 0x0000980A
		public Banqueting(VillageMap village)
		{
			this.m_village = village;
		}

		// Token: 0x06000664 RID: 1636 RVA: 0x00083FF4 File Offset: 0x000821F4
		public void updateLevels(bool force)
		{
			VillageMap.TownHallLevels townHallLevels = new VillageMap.TownHallLevels();
			this.m_village.getTownHallLevels(townHallLevels);
			if (force || this.oldLevels == null)
			{
				this.oldLevels = townHallLevels;
			}
			else
			{
				bool flag = false;
				if (townHallLevels.venisonLevel != this.oldLevels.venisonLevel)
				{
					flag = true;
				}
				if (townHallLevels.furnitureLevel != this.oldLevels.furnitureLevel)
				{
					flag = true;
				}
				if (townHallLevels.metalwareLevel != this.oldLevels.metalwareLevel)
				{
					flag = true;
				}
				if (townHallLevels.clothesLevel != this.oldLevels.clothesLevel)
				{
					flag = true;
				}
				if (townHallLevels.wineLevel != this.oldLevels.wineLevel)
				{
					flag = true;
				}
				if (townHallLevels.saltLevel != this.oldLevels.saltLevel)
				{
					flag = true;
				}
				if (townHallLevels.spicesLevel != this.oldLevels.spicesLevel)
				{
					flag = true;
				}
				if (townHallLevels.silkLevel != this.oldLevels.silkLevel)
				{
					flag = true;
				}
				if (!flag)
				{
					return;
				}
				this.oldLevels = townHallLevels;
			}
			this.resourceLevels[0] = (int)townHallLevels.venisonLevel;
			this.resourceLevels[1] = (int)townHallLevels.furnitureLevel;
			this.resourceLevels[2] = (int)townHallLevels.metalwareLevel;
			this.resourceLevels[3] = (int)townHallLevels.clothesLevel;
			this.resourceLevels[4] = (int)townHallLevels.wineLevel;
			this.resourceLevels[5] = (int)townHallLevels.saltLevel;
			this.resourceLevels[6] = (int)townHallLevels.spicesLevel;
			this.resourceLevels[7] = (int)townHallLevels.silkLevel;
			for (int i = this.researchLevel; i < 8; i++)
			{
				this.resourceLevels[i] = 0;
			}
			int[] array = new int[8];
			for (int j = 0; j < 8; j++)
			{
				array[j] = this.resourceLevels[j];
				for (int k = 0; k < 8; k++)
				{
					this.banquetLevels[k, j] = 0;
				}
			}
			for (int l = 0; l < 8; l++)
			{
				int num = 2000000000;
				for (int m = 0; m < 8; m++)
				{
					if (array[m] > 0 && array[m] < num)
					{
						num = array[m];
					}
				}
				if (num == 2000000000)
				{
					break;
				}
				int num2 = 0;
				int[] array2 = new int[8];
				for (int n = 0; n < 8; n++)
				{
					array2[n] = 0;
					if (array[n] >= num)
					{
						num2++;
						array[n] -= num;
						array2[n] = num;
					}
				}
				for (int num3 = 0; num3 < 8; num3++)
				{
					this.banquetLevels[num2 - 1, num3] = array2[num3];
				}
			}
		}

		// Token: 0x06000665 RID: 1637 RVA: 0x0008426C File Offset: 0x0008246C
		public int getBanquetSize(Banqueting.Level level)
		{
			int num = 0;
			for (int i = 0; i < 8; i++)
			{
				if (this.banquetLevels[(int)level, i] > num)
				{
					num = this.banquetLevels[(int)level, i];
				}
			}
			return num;
		}

		// Token: 0x06000666 RID: 1638 RVA: 0x000842A8 File Offset: 0x000824A8
		public static string getBanquetName(Banqueting.Level banquetLevel)
		{
			switch (banquetLevel)
			{
			case Banqueting.Level.HUMBLE:
				return SK.Text("BanquetScreen_Size_1", "Humble");
			case Banqueting.Level.MODEST:
				return SK.Text("BanquetScreen_Size_2", "Modest");
			case Banqueting.Level.FINE:
				return SK.Text("BanquetScreen_Size_3", "Fine");
			case Banqueting.Level.IMPRESSIVE:
				return SK.Text("BanquetScreen_Size_4", "Impressive");
			case Banqueting.Level.GRAND:
				return SK.Text("BanquetScreen_Size_5", "Grand");
			case Banqueting.Level.MAGNIFICENT:
				return SK.Text("BanquetScreen_Size_6", "Magnificent");
			case Banqueting.Level.MAJESTIC:
				return SK.Text("BanquetScreen_Size_7", "Majestic");
			case Banqueting.Level.EXQUISITE:
				return SK.Text("BanquetScreen_Size_8", "Exquisite");
			default:
				throw new ArgumentException("Invalid banquet type");
			}
		}

		// Token: 0x06000667 RID: 1639 RVA: 0x0000B632 File Offset: 0x00009832
		public int getBanquetHonour(Banqueting.Level level)
		{
			return CardTypes.getBanquetHonourValue(this.getBanquetSize(level) * Banqueting.getHonourMultiplier(level), GameEngine.Instance.cardsManager.UserCardData);
		}

		// Token: 0x06000668 RID: 1640 RVA: 0x0008436C File Offset: 0x0008256C
		public static int getHonourMultiplier(Banqueting.Level level)
		{
			int num = 1;
			switch (level)
			{
			case Banqueting.Level.HUMBLE:
				num = 1;
				break;
			case Banqueting.Level.MODEST:
				num = 4;
				break;
			case Banqueting.Level.FINE:
				num = 9;
				break;
			case Banqueting.Level.IMPRESSIVE:
				num = 16;
				break;
			case Banqueting.Level.GRAND:
				num = 35;
				break;
			case Banqueting.Level.MAGNIFICENT:
				num = 60;
				break;
			case Banqueting.Level.MAJESTIC:
				num = 98;
				break;
			case Banqueting.Level.EXQUISITE:
				num = 160;
				break;
			}
			if (GameEngine.Instance.World.ThirdAgeWorld)
			{
				num *= 10;
			}
			else if (GameEngine.Instance.LocalWorldData.Alternate_Ruleset == 1)
			{
				num *= 2;
			}
			return num;
		}

		// Token: 0x06000669 RID: 1641 RVA: 0x000843FC File Offset: 0x000825FC
		public bool holdBanquet(int mode)
		{
			bool flag = false;
			for (int i = 0; i < 8; i++)
			{
				if (this.banquetLevels[mode, i] > 0)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				VillageMap village = GameEngine.Instance.Village;
				if (village != null)
				{
					RemoteServices.Instance.VillageHoldBanquet(village.VillageID, this.banquetLevels[mode, 0], this.banquetLevels[mode, 1], this.banquetLevels[mode, 2], this.banquetLevels[mode, 3], this.banquetLevels[mode, 4], this.banquetLevels[mode, 5], this.banquetLevels[mode, 6], this.banquetLevels[mode, 7]);
				}
			}
			return flag;
		}

		// Token: 0x0600066A RID: 1642 RVA: 0x000844B8 File Offset: 0x000826B8
		public int getTotalAvailableHonour()
		{
			int num = 0;
			for (int i = 0; i < 7; i++)
			{
				num += this.getBanquetHonour((Banqueting.Level)i);
			}
			return num;
		}

		// Token: 0x0600066B RID: 1643 RVA: 0x0000B656 File Offset: 0x00009856
		public void banquetCallback(VillageHoldBanquet_ReturnType returnData)
		{
			if (HoldBanquetPanel.Instance != null)
			{
				HoldBanquetPanel.Instance.updateLevels(true);
			}
		}

		// Token: 0x0600066C RID: 1644 RVA: 0x000844E0 File Offset: 0x000826E0
		public bool HoldBanquet(int mode, VillageMap village)
		{
			bool flag = false;
			for (int i = 0; i < 8; i++)
			{
				if (this.banquetLevels[mode, i] > 0)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				RemoteServices.Instance.set_VillageHoldBanquet_UserCallBack(new RemoteServices.VillageHoldBanquet_UserCallBack(village.holdBanquetCallback));
				RemoteServices.Instance.VillageHoldBanquet(village.VillageID, this.banquetLevels[mode, 0], this.banquetLevels[mode, 1], this.banquetLevels[mode, 2], this.banquetLevels[mode, 3], this.banquetLevels[mode, 4], this.banquetLevels[mode, 5], this.banquetLevels[mode, 6], this.banquetLevels[mode, 7]);
			}
			return flag;
		}

		// Token: 0x0600066D RID: 1645 RVA: 0x000845A4 File Offset: 0x000827A4
		public int GetHighestAvailableBanquet(VillageMap village)
		{
			int result = 0;
			for (int i = 7; i > -1; i--)
			{
				for (int j = 0; j < 8; j++)
				{
					if (this.banquetLevels[i, j] > 0)
					{
						return i + 1;
					}
				}
			}
			return result;
		}

		// Token: 0x04000859 RID: 2137
		public VillageMap m_village;

		// Token: 0x0400085A RID: 2138
		private VillageMap.TownHallLevels oldLevels;

		// Token: 0x0400085B RID: 2139
		public int[] resourceLevels = new int[8];

		// Token: 0x0400085C RID: 2140
		public int[,] banquetLevels = new int[8, 8];

		// Token: 0x020000DD RID: 221
		public enum Level
		{
			// Token: 0x0400085E RID: 2142
			HUMBLE,
			// Token: 0x0400085F RID: 2143
			MODEST,
			// Token: 0x04000860 RID: 2144
			FINE,
			// Token: 0x04000861 RID: 2145
			IMPRESSIVE,
			// Token: 0x04000862 RID: 2146
			GRAND,
			// Token: 0x04000863 RID: 2147
			MAGNIFICENT,
			// Token: 0x04000864 RID: 2148
			MAJESTIC,
			// Token: 0x04000865 RID: 2149
			EXQUISITE
		}
	}
}
