using System;
using System.Collections.Generic;
using System.Xml;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000126 RID: 294
	public class CastleMapPreset
	{
		// Token: 0x06000AE1 RID: 2785 RVA: 0x0000E2DE File Offset: 0x0000C4DE
		public CastleMapPreset()
		{
		}

		// Token: 0x06000AE2 RID: 2786 RVA: 0x000D9BF8 File Offset: 0x000D7DF8
		public CastleMapPreset(string name, DateTime time, PresetType type, int count)
		{
			this.Name = name;
			this.ModifiedDate = time;
			this.Type = type;
			this.ElementCount = count;
		}

		// Token: 0x06000AE3 RID: 2787 RVA: 0x000D9C4C File Offset: 0x000D7E4C
		public XmlElement GenerateXML(XmlDocument doc)
		{
			if (this.Type == PresetType.NONE)
			{
				return null;
			}
			string name = "";
			switch (this.Type)
			{
			case PresetType.TROOP_ATTACK:
				name = "attack";
				break;
			case PresetType.TROOP_DEFEND:
				name = "troops";
				break;
			case PresetType.INFRASTRUCTURE:
				name = "infrastructure";
				break;
			}
			XmlElement xmlElement = doc.CreateElement(name);
			XmlAttribute xmlAttribute = doc.CreateAttribute("name");
			if (this.Name.Trim().Length == 0 && this.ElementCount > 0)
			{
				this.Name = "(" + this.SlotID.ToString() + ")";
			}
			xmlAttribute.Value = this.Name;
			xmlElement.Attributes.Append(xmlAttribute);
			XmlAttribute xmlAttribute2 = doc.CreateAttribute("last_modified");
			xmlAttribute2.Value = this.ModifiedDate.Ticks.ToString();
			xmlElement.Attributes.Append(xmlAttribute2);
			XmlAttribute xmlAttribute3 = doc.CreateAttribute("count");
			xmlAttribute3.Value = this.ElementCount.ToString();
			xmlElement.Attributes.Append(xmlAttribute3);
			XmlAttribute xmlAttribute4 = doc.CreateAttribute("slot");
			xmlAttribute4.Value = this.SlotID.ToString();
			xmlElement.Attributes.Append(xmlAttribute4);
			if (this.Data != null)
			{
				xmlElement.InnerText = this.Data;
			}
			return xmlElement;
		}

		// Token: 0x06000AE4 RID: 2788 RVA: 0x000D9DA8 File Offset: 0x000D7FA8
		public void ParseXML(XmlElement element)
		{
			string name = element.Name;
			if (name != null)
			{
				if (!(name == "attack"))
				{
					if (!(name == "troops"))
					{
						if (name == "infrastructure")
						{
							this.Type = PresetType.INFRASTRUCTURE;
						}
					}
					else
					{
						this.Type = PresetType.TROOP_DEFEND;
					}
				}
				else
				{
					this.Type = PresetType.TROOP_ATTACK;
				}
			}
			this.Name = element.Attributes["name"].Value;
			long ticks = Convert.ToInt64(element.Attributes["last_modified"].Value);
			this.ModifiedDate = new DateTime(ticks);
			this.ElementCount = Convert.ToInt32(element.Attributes["count"].Value);
			this.SlotID = Convert.ToInt32(element.Attributes["slot"].Value);
			this.Data = element.InnerText;
			CastleMap.PopulateBasicInfo(this);
		}

		// Token: 0x06000AE5 RID: 2789 RVA: 0x0000E307 File Offset: 0x0000C507
		public int GetElementTotal(byte elementType)
		{
			return this.GetElementTotal(elementType, false);
		}

		// Token: 0x06000AE6 RID: 2790 RVA: 0x000D9E98 File Offset: 0x000D8098
		public int GetElementTotal(byte elementType, bool reinforcement)
		{
			int num = 0;
			foreach (CastleMapPreset.CastleElementInfo castleElementInfo in this.BasicData)
			{
				if (castleElementInfo.elementType == elementType && reinforcement == castleElementInfo.reinforcement)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000AE7 RID: 2791 RVA: 0x0000E311 File Offset: 0x0000C511
		public int GetRangeTotal(byte minType, byte maxType)
		{
			return this.GetRangeTotal(minType, maxType, false);
		}

		// Token: 0x06000AE8 RID: 2792 RVA: 0x000D9F00 File Offset: 0x000D8100
		public int GetRangeTotal(byte minType, byte maxType, bool reinforcement)
		{
			int num = 0;
			foreach (CastleMapPreset.CastleElementInfo castleElementInfo in this.BasicData)
			{
				if (castleElementInfo.elementType >= minType && castleElementInfo.elementType <= maxType && reinforcement == castleElementInfo.reinforcement)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000AE9 RID: 2793 RVA: 0x0000E31C File Offset: 0x0000C51C
		public void CopyData(CastleMapPreset otherPreset)
		{
			this.Data = otherPreset.Data;
			this.ElementCount = otherPreset.ElementCount;
			CastleMap.PopulateBasicInfo(this);
		}

		// Token: 0x06000AEA RID: 2794 RVA: 0x000D9F70 File Offset: 0x000D8170
		public bool CanDeploy()
		{
			PresetType type = this.Type;
			return type != PresetType.INFRASTRUCTURE || this.ResearchRequirementsMet();
		}

		// Token: 0x06000AEB RID: 2795 RVA: 0x000D9F90 File Offset: 0x000D8190
		public bool ResearchRequirementsMet()
		{
			PresetType type = this.Type;
			if (type == PresetType.INFRASTRUCTURE)
			{
				ResearchData researchDataForCurrentVillage = GameEngine.Instance.World.GetResearchDataForCurrentVillage();
				int fortificationResearchLevel = this.GetFortificationResearchLevel();
				int defenceResearchLevel = this.GetDefenceResearchLevel();
				return fortificationResearchLevel <= (int)researchDataForCurrentVillage.Research_Fortification && defenceResearchLevel <= (int)researchDataForCurrentVillage.Research_Defences;
			}
			return true;
		}

		// Token: 0x06000AEC RID: 2796 RVA: 0x000D9FE0 File Offset: 0x000D81E0
		public bool ResourceRequirementsMet()
		{
			if (this.Type != PresetType.INFRASTRUCTURE)
			{
				return true;
			}
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			bool flag = GameEngine.Instance.World.isCapital(InterfaceMgr.Instance.getSelectedMenuVillage());
			new CardData();
			if (!flag)
			{
				CardData userCardData = GameEngine.Instance.cardsManager.UserCardData;
			}
			foreach (CastleMapPreset.CastleElementInfo castleElementInfo in this.BasicData)
			{
				if (castleElementInfo.elementType <= 69 && castleElementInfo.elementType != 43)
				{
					int num6 = (int)castleElementInfo.elementType;
					if (num6 == 65)
					{
						num6 = 34;
					}
					if (num6 == 66)
					{
						num6 = 33;
					}
					int num7 = 0;
					int num8 = 0;
					int num9 = 0;
					int num10 = 0;
					int num11 = 0;
					CastlesCommon.getConstrCost(GameEngine.Instance.LocalWorldData, num6, ref num7, ref num8, ref num11, ref num10, ref num9);
					num += num7;
					num2 += num8;
					num3 += num9;
					num4 += num10;
					num5 += num11;
				}
			}
			VillageMap.StockpileLevels stockpileLevels = new VillageMap.StockpileLevels();
			GameEngine.Instance.Village.getStockpileLevels(stockpileLevels);
			if (stockpileLevels.woodLevel < (double)num)
			{
				return false;
			}
			if (stockpileLevels.stoneLevel < (double)num2)
			{
				return false;
			}
			if (stockpileLevels.ironLevel < (double)num3)
			{
				return false;
			}
			if (stockpileLevels.pitchLevel < (double)num4)
			{
				return false;
			}
			if (flag)
			{
				return (double)num5 <= GameEngine.Instance.Village.m_capitalGold;
			}
			return (double)num5 <= GameEngine.Instance.World.getCurrentGold();
		}

		// Token: 0x06000AED RID: 2797 RVA: 0x000DA178 File Offset: 0x000D8378
		public bool ParishRequirementsMet()
		{
			if (!this.RequiresParishBuilding())
			{
				return true;
			}
			foreach (CastleMapPreset.CastleElementInfo castleElementInfo in this.BasicData)
			{
				if (castleElementInfo.elementType == 43)
				{
					if (GameEngine.Instance.Village.m_parishCapitalResearchData.Research_CAP_Tunnellors > 0)
					{
						break;
					}
					return false;
				}
			}
			int num = GameEngine.Instance.Castle.countBombards();
			int num2 = GameEngine.Instance.Castle.countTurrets();
			int num3 = GameEngine.Instance.Castle.countBallistas();
			foreach (CastleMapPreset.CastleElementInfo castleElementInfo2 in this.BasicData)
			{
				switch (castleElementInfo2.elementType)
				{
				case 41:
					num2++;
					break;
				case 42:
					num3++;
					break;
				case 44:
					num++;
					break;
				}
			}
			return num2 < (int)GameEngine.Instance.Village.m_parishCapitalResearchData.Research_CAP_Turrets && num3 < (int)GameEngine.Instance.Village.m_parishCapitalResearchData.Research_CAP_Ballista && num < (int)GameEngine.Instance.Village.m_parishCapitalResearchData.Research_Leadership;
		}

		// Token: 0x06000AEE RID: 2798 RVA: 0x000DA2EC File Offset: 0x000D84EC
		public bool RequiresParishBuilding()
		{
			if (this.Type != PresetType.INFRASTRUCTURE)
			{
				return false;
			}
			foreach (CastleMapPreset.CastleElementInfo castleElementInfo in this.BasicData)
			{
				byte elementType = castleElementInfo.elementType;
				if (elementType - 41 <= 3)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000AEF RID: 2799 RVA: 0x000DA358 File Offset: 0x000D8558
		public int GetFortificationResearchLevel()
		{
			if (this.Type != PresetType.INFRASTRUCTURE)
			{
				return 0;
			}
			int num = 0;
			foreach (CastleMapPreset.CastleElementInfo castleElementInfo in this.BasicData)
			{
				byte elementType = castleElementInfo.elementType;
				switch (elementType)
				{
				case 11:
					num = Math.Max(4, num);
					break;
				case 12:
					num = Math.Max(5, num);
					break;
				case 13:
					num = Math.Max(7, num);
					break;
				case 14:
					num = Math.Max(8, num);
					break;
				default:
					if (elementType != 21)
					{
						switch (elementType)
						{
						case 33:
						case 39:
						case 40:
							num = Math.Max(1, num);
							break;
						case 34:
							num = Math.Max(3, num);
							break;
						case 37:
						case 38:
							num = Math.Max(6, num);
							break;
						}
					}
					else
					{
						num = Math.Max(2, num);
					}
					break;
				}
			}
			return num;
		}

		// Token: 0x06000AF0 RID: 2800 RVA: 0x000DA458 File Offset: 0x000D8658
		public int GetDefenceResearchLevel()
		{
			if (this.Type != PresetType.INFRASTRUCTURE)
			{
				return 0;
			}
			int num = 0;
			foreach (CastleMapPreset.CastleElementInfo castleElementInfo in this.BasicData)
			{
				byte elementType = castleElementInfo.elementType;
				switch (elementType)
				{
				case 31:
					num = Math.Max(1, num);
					continue;
				case 32:
					break;
				case 33:
				case 34:
					continue;
				case 35:
					num = Math.Max(7, num);
					continue;
				case 36:
					num = Math.Max(2, num);
					continue;
				default:
					if (elementType != 75)
					{
						continue;
					}
					break;
				}
				num = Math.Max(5, num);
			}
			return num;
		}

		// Token: 0x04000EF3 RID: 3827
		public string Name = "";

		// Token: 0x04000EF4 RID: 3828
		public DateTime ModifiedDate = DateTime.Now;

		// Token: 0x04000EF5 RID: 3829
		public PresetType Type;

		// Token: 0x04000EF6 RID: 3830
		public int ElementCount;

		// Token: 0x04000EF7 RID: 3831
		public int SlotID;

		// Token: 0x04000EF8 RID: 3832
		public string Data;

		// Token: 0x04000EF9 RID: 3833
		public List<CastleMapPreset.CastleElementInfo> BasicData = new List<CastleMapPreset.CastleElementInfo>();

		// Token: 0x02000127 RID: 295
		public class CastleElementInfo
		{
			// Token: 0x04000EFA RID: 3834
			public byte xPos;

			// Token: 0x04000EFB RID: 3835
			public byte yPos;

			// Token: 0x04000EFC RID: 3836
			public byte elementType;

			// Token: 0x04000EFD RID: 3837
			public bool reinforcement;
		}
	}
}
