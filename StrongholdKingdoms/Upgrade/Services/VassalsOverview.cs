using System;
using System.Collections.Generic;
using CommonTypes;
using Kingdoms;

namespace Upgrade.Services
{
	// Token: 0x020000A1 RID: 161
	internal class VassalsOverview
	{
		// Token: 0x06000431 RID: 1073 RVA: 0x0005B6A0 File Offset: 0x000598A0
		internal static void QuickLoadVassal(AllVassalsPanel.ArmyLine panel, int villageID)
		{
			DX.ControlForm.Log(string.Format("{0} {1}", LNG.Print("Checking vassal"), villageID), ControlForm.Tab.TroopsRecruiting, false);
			VassalsOverview.AllVassalsPanel = panel;
			RemoteServices.Instance.set_GetVassalArmyInfo_UserCallBack(new RemoteServices.GetVassalArmyInfo_UserCallBack(VassalsOverview.getVassalArmyQuickInfoCallback));
			RemoteServices.Instance.GetVassalArmyInfo(villageID, 0, -1);
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x0005B700 File Offset: 0x00059900
		private static void getVassalArmyQuickInfoCallback(GetVassalArmyInfo_ReturnType returnData)
		{
			if (returnData != null && returnData.Success)
			{
				VassalsOverview.AddVassalToCache(returnData);
				int numPeasants = returnData.numStationedTroops_Peasants + returnData.numAttackingTroops_Peasants + returnData.numEnrouteTroops_Peasants;
				int numArchers = returnData.numStationedTroops_Archers + returnData.numAttackingTroops_Archers + returnData.numEnrouteTroops_Archers;
				int numPikemen = returnData.numStationedTroops_Pikemen + returnData.numAttackingTroops_Pikemen + returnData.numEnrouteTroops_Pikemen;
				int numSwordsmen = returnData.numStationedTroops_Swordsmen + returnData.numAttackingTroops_Swordsmen + returnData.numEnrouteTroops_Swordsmen;
				int numCatapults = returnData.numStationedTroops_Catapults + returnData.numAttackingTroops_Catapults + returnData.numEnrouteTroops_Catapults;
				AllVassalsPanel.ArmyLine allVassalsPanel = VassalsOverview.AllVassalsPanel;
				if (allVassalsPanel == null)
				{
					return;
				}
				allVassalsPanel.update(numPeasants, numArchers, numPikemen, numSwordsmen, numCatapults);
				return;
			}
			else
			{
				ControlForm controlForm = DX.ControlForm;
				if (controlForm == null)
				{
					return;
				}
				controlForm.Log(string.Concat(new string[]
				{
					ErrorCodes.getErrorString(returnData.m_errorCode, returnData.m_errorID),
					". Liege Lord Village ",
					GameEngine.Instance.World.getVillageName(returnData.liegeLordVillageID),
					" Vassal Village ",
					GameEngine.Instance.World.getVillageName(returnData.vassalVillageID),
					" "
				}), ControlForm.Tab.Main, true);
				return;
			}
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x00009F9C File Offset: 0x0000819C
		internal static void AddVassalToCache(GetVassalArmyInfo_ReturnType data)
		{
			if (VassalsOverview.VassalsCache.ContainsKey(data.vassalVillageID))
			{
				VassalsOverview.VassalsCache[data.vassalVillageID] = data;
				return;
			}
			VassalsOverview.VassalsCache.Add(data.vassalVillageID, data);
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x00009FD3 File Offset: 0x000081D3
		internal static GetVassalArmyInfo_ReturnType GetVassalCacheInfo(int villageID)
		{
			if (VassalsOverview.VassalsCache.ContainsKey(villageID))
			{
				return VassalsOverview.VassalsCache[villageID];
			}
			return null;
		}

		// Token: 0x04000562 RID: 1378
		private static AllVassalsPanel.ArmyLine AllVassalsPanel;

		// Token: 0x04000563 RID: 1379
		internal static Dictionary<int, GetVassalArmyInfo_ReturnType> VassalsCache = new Dictionary<int, GetVassalArmyInfo_ReturnType>();
	}
}
