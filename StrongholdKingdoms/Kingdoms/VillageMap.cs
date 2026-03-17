using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CommonTypes;
using DXGraphics;
using Kingdoms.GameWorld.CameraControllers;
using Upgrade;
using Upgrade.Services;

namespace Kingdoms
{
	// Token: 0x020004D5 RID: 1237
	public class VillageMap
	{
		// Token: 0x1700025A RID: 602
		// (get) Token: 0x06002D9F RID: 11679 RVA: 0x00021811 File Offset: 0x0001FA11
		// (set) Token: 0x06002DA0 RID: 11680 RVA: 0x00021818 File Offset: 0x0001FA18
		public static VillageLayoutNew[] villageLayout
		{
			get
			{
				return VillageMap.s_villageLayout;
			}
			set
			{
				VillageMap.s_villageLayout = value;
			}
		}

		// Token: 0x1700025B RID: 603
		// (get) Token: 0x06002DA1 RID: 11681 RVA: 0x00021820 File Offset: 0x0001FA20
		// (set) Token: 0x06002DA2 RID: 11682 RVA: 0x00021827 File Offset: 0x0001FA27
		public static VillageBuildingDataNew[] villageBuildingData
		{
			get
			{
				return VillageMap.s_villageBuildingData;
			}
			set
			{
				VillageMap.s_villageBuildingData = value;
				VillageMap.s_villageBuildingData[23].animArray = VillageMap.updatedSaltWorkerAnim;
				VillageMap.s_villageBuildingData[15].animArray = VillageMap.updatedVegWorkerAnim;
				VillageMap.s_villageBuildingData[21].animCount = 24;
			}
		}

		// Token: 0x1700025C RID: 604
		// (get) Token: 0x06002DA3 RID: 11683 RVA: 0x00021862 File Offset: 0x0001FA62
		public int VillageID
		{
			get
			{
				return this.m_villageID;
			}
		}

		// Token: 0x1700025D RID: 605
		// (get) Token: 0x06002DA4 RID: 11684 RVA: 0x0002186A File Offset: 0x0001FA6A
		public int VillageMapType
		{
			get
			{
				return this.m_villageMapType;
			}
		}

		// Token: 0x1700025E RID: 606
		// (get) Token: 0x06002DA5 RID: 11685 RVA: 0x00021872 File Offset: 0x0001FA72
		public List<VillageMapBuilding> Buildings
		{
			get
			{
				return this.localBuildings;
			}
		}

		// Token: 0x1700025F RID: 607
		// (get) Token: 0x06002DA6 RID: 11686 RVA: 0x0002187A File Offset: 0x0001FA7A
		public int CurrentPlacementType
		{
			get
			{
				return VillageMap.placementType;
			}
		}

		// Token: 0x17000260 RID: 608
		// (get) Token: 0x06002DA7 RID: 11687 RVA: 0x00021881 File Offset: 0x0001FA81
		public ICameraController Camera
		{
			get
			{
				return this.m_camera;
			}
		}

		// Token: 0x17000261 RID: 609
		// (get) Token: 0x06002DA8 RID: 11688 RVA: 0x00021889 File Offset: 0x0001FA89
		public string PlacementErrorString
		{
			get
			{
				return this.placementErrorString;
			}
		}

		// Token: 0x17000262 RID: 610
		// (get) Token: 0x06002DA9 RID: 11689 RVA: 0x00021891 File Offset: 0x0001FA91
		public bool isPlacementValid
		{
			get
			{
				return this.placementError == 0;
			}
		}

		// Token: 0x17000263 RID: 611
		// (get) Token: 0x06002DAA RID: 11690 RVA: 0x0002189C File Offset: 0x0001FA9C
		// (set) Token: 0x06002DAB RID: 11691 RVA: 0x000218A4 File Offset: 0x0001FAA4
		public bool ViewOnly
		{
			get
			{
				return this.viewOnly;
			}
			set
			{
				this.viewOnly = value;
				InterfaceMgr.Instance.SetVillageViewMode(this.viewOnly);
			}
		}

		// Token: 0x17000264 RID: 612
		// (get) Token: 0x06002DAC RID: 11692 RVA: 0x000218BD File Offset: 0x0001FABD
		// (set) Token: 0x06002DAD RID: 11693 RVA: 0x000218C5 File Offset: 0x0001FAC5
		public double ViewHonour
		{
			get
			{
				return this.viewHonour;
			}
			set
			{
				this.viewHonour = value;
			}
		}

		// Token: 0x17000265 RID: 613
		// (get) Token: 0x06002DAE RID: 11694 RVA: 0x000218CE File Offset: 0x0001FACE
		private GraphicsMgr GFX
		{
			get
			{
				return this.gfx;
			}
		}

		// Token: 0x17000266 RID: 614
		// (get) Token: 0x06002DAF RID: 11695 RVA: 0x000218D6 File Offset: 0x0001FAD6
		public int LocallyMade_Peasants
		{
			get
			{
				return this.localMadeTroops_Peasants + this.localMadeTroopsSent_Peasants;
			}
		}

		// Token: 0x17000267 RID: 615
		// (get) Token: 0x06002DB0 RID: 11696 RVA: 0x000218E5 File Offset: 0x0001FAE5
		public int LocallyMade_Archers
		{
			get
			{
				return this.localMadeTroops_Archers + this.localMadeTroopsSent_Archers;
			}
		}

		// Token: 0x17000268 RID: 616
		// (get) Token: 0x06002DB1 RID: 11697 RVA: 0x000218F4 File Offset: 0x0001FAF4
		public int LocallyMade_Pikemen
		{
			get
			{
				return this.localMadeTroops_Pikemen + this.localMadeTroopsSent_Pikemen;
			}
		}

		// Token: 0x17000269 RID: 617
		// (get) Token: 0x06002DB2 RID: 11698 RVA: 0x00021903 File Offset: 0x0001FB03
		public int LocallyMade_Swordsmen
		{
			get
			{
				return this.localMadeTroops_Swordsmen + this.localMadeTroopsSent_Swordsmen;
			}
		}

		// Token: 0x1700026A RID: 618
		// (get) Token: 0x06002DB3 RID: 11699 RVA: 0x00021912 File Offset: 0x0001FB12
		public int LocallyMade_Catapults
		{
			get
			{
				return this.localMadeTroops_Catapults + this.localMadeTroopsSent_Catapults;
			}
		}

		// Token: 0x1700026B RID: 619
		// (get) Token: 0x06002DB4 RID: 11700 RVA: 0x00021921 File Offset: 0x0001FB21
		public int LocallyMade_Captains
		{
			get
			{
				return this.localMadeTroops_Captains + this.localMadeTroopsSent_Captains;
			}
		}

		// Token: 0x1700026C RID: 620
		// (get) Token: 0x06002DB5 RID: 11701 RVA: 0x00021930 File Offset: 0x0001FB30
		public int LocallyMade_Scouts
		{
			get
			{
				return this.localMadeTroops_Scouts + this.localMadeTroopsSent_Scouts;
			}
		}

		// Token: 0x06002DB6 RID: 11702 RVA: 0x00244420 File Offset: 0x00242620
		public void initClickMask()
		{
			int width = this.layout.gridWidth * 32;
			int height = this.layout.gridHeight * 16;
			VillageMap.villageClickMask.init(width, height, this.gfx);
		}

		// Token: 0x06002DB7 RID: 11703 RVA: 0x0002193F File Offset: 0x0001FB3F
		public void forceDirtyMap()
		{
			VillageMap.villageClickMask.clearMap();
		}

		// Token: 0x06002DB8 RID: 11704 RVA: 0x00244460 File Offset: 0x00242660
		public static void loadVillageBuildingsGFX2()
		{
			if (VillageMap.GFXLoaded && VillageMap.s_villageBuildingData[0].baseGfxTexID >= 0)
			{
				return;
			}
			VillageMap.GFXLoaded = true;
			VillageBuildingDataNew[] array = VillageMap.s_villageBuildingData;
			foreach (VillageBuildingDataNew villageBuildingDataNew in array)
			{
				if (villageBuildingDataNew.baseGfxFile.Length > 0)
				{
					villageBuildingDataNew.baseGfxTexID = VillageMap.loadBuildingTexture(villageBuildingDataNew.baseGfxFile);
				}
				if (villageBuildingDataNew.baseOpenGfxFile.Length > 0)
				{
					villageBuildingDataNew.baseOpenGfxTexID = VillageMap.loadBuildingTexture(villageBuildingDataNew.baseOpenGfxFile);
				}
				if (villageBuildingDataNew.shadowGfxFile.Length > 0)
				{
					villageBuildingDataNew.shadowGfxTexID = VillageMap.loadBuildingTexture(villageBuildingDataNew.shadowGfxFile);
				}
				if (villageBuildingDataNew.shadowOpenGfxFile.Length > 0)
				{
					villageBuildingDataNew.shadowOpenGfxTexID = VillageMap.loadBuildingTexture(villageBuildingDataNew.shadowOpenGfxFile);
				}
				if (villageBuildingDataNew.animGfxFile.Length > 0)
				{
					villageBuildingDataNew.animGfxTexID = VillageMap.loadBuildingTexture(villageBuildingDataNew.animGfxFile);
				}
			}
		}

		// Token: 0x06002DB9 RID: 11705 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public static void loadVillageBuildingsGFX()
		{
		}

		// Token: 0x06002DBA RID: 11706 RVA: 0x0002194B File Offset: 0x0001FB4B
		private static int loadBuildingTexture(string filename)
		{
			return GFXLibrary.Instance.getVillageBuildingTexture(filename);
		}

		// Token: 0x06002DBB RID: 11707 RVA: 0x00021958 File Offset: 0x0001FB58
		public static void setServerTime(DateTime serverTime)
		{
			VillageMap.baseServerTime = serverTime;
			VillageMap.localBaseTime = DXTimer.GetCurrentMilliseconds();
		}

		// Token: 0x06002DBC RID: 11708 RVA: 0x00244548 File Offset: 0x00242748
		public static DateTime getCurrentServerTime()
		{
			double value = (DXTimer.GetCurrentMilliseconds() - VillageMap.localBaseTime) / 1000.0;
			return VillageMap.baseServerTime.AddSeconds(value);
		}

		// Token: 0x06002DBD RID: 11709 RVA: 0x00244578 File Offset: 0x00242778
		public static string createShortQuantityString(double quantity)
		{
			if (quantity == 0.0)
			{
				return "0";
			}
			if (quantity > 1000000000.0 || quantity < -1000000000.0)
			{
				return Math.Round(quantity / 1000000000.0, 0).ToString() + "B";
			}
			if (quantity > 10000000.0 || quantity < -10000000.0)
			{
				return Math.Round(quantity / 1000000.0, 0).ToString() + "M";
			}
			if (quantity > 1000000.0 || quantity < -1000000.0)
			{
				return Math.Round(quantity / 1000000.0, 1).ToString() + "M";
			}
			if (quantity > 10000.0 || quantity < -10000.0)
			{
				return Math.Round(quantity / 1000.0, 0).ToString() + "K";
			}
			if (quantity > 1000.0 || quantity < -1000.0)
			{
				return Math.Round(quantity / 1000.0, 1).ToString() + "K";
			}
			return ((int)quantity).ToString();
		}

		// Token: 0x06002DBE RID: 11710 RVA: 0x002446D0 File Offset: 0x002428D0
		public static string createShortTimeString(int secsLeft)
		{
			double num = (double)(secsLeft / 60);
			double num2 = (double)(secsLeft / 3600);
			double num3 = (double)(secsLeft / 86400);
			if (num3 > 0.0)
			{
				return Math.Round(num3, 2).ToString() + " " + SK.Text("MENU_days", "days");
			}
			if (num2 > 0.0)
			{
				return Math.Round(num2, 2).ToString() + " " + SK.Text("MENU_hours_short", "hrs");
			}
			if (num > 2.0)
			{
				return num.ToString() + " " + SK.Text("MENU_minutes_short", "mins");
			}
			return secsLeft.ToString() + SK.Text("VillageMap_Second_Abbrev", "s");
		}

		// Token: 0x06002DBF RID: 11711 RVA: 0x002447A8 File Offset: 0x002429A8
		public static string createVeryShortTimeString(int secsLeft)
		{
			double num = (double)(secsLeft / 60);
			double num2 = (double)(secsLeft / 3600);
			double num3 = (double)(secsLeft / 86400);
			if (num3 > 0.0)
			{
				return Math.Round(num3, 2).ToString() + SK.Text("VillageMap_Day_Abbrev", "d");
			}
			if (num2 > 0.0)
			{
				return Math.Round(num2, 2).ToString() + SK.Text("VillageMap_Hour_Abbrev", "h");
			}
			if (num > 2.0)
			{
				return num.ToString() + SK.Text("VillageMap_Minute_Abbrev", "m");
			}
			return secsLeft.ToString() + SK.Text("VillageMap_Second_Abbrev", "s");
		}

		// Token: 0x06002DC0 RID: 11712 RVA: 0x00244870 File Offset: 0x00242A70
		public static string createBuildTimeString(int secsLeft)
		{
			int num = secsLeft % 60;
			int num2 = secsLeft / 60 % 60;
			int num3 = secsLeft / 3600 % 24;
			int num4 = secsLeft / 86400;
			string str = "";
			if (num4 > 0)
			{
				str = str + num4.ToString() + SK.Text("VillageMap_Day_Abbrev", "d") + ":";
			}
			if (num3 > 0)
			{
				if (num3 < 10)
				{
					str += "0";
				}
				str = str + num3.ToString() + SK.Text("VillageMap_Hour_Abbrev", "h") + ":";
			}
			if (num2 > 0)
			{
				if (num2 < 10)
				{
					str += "0";
				}
				str = str + num2.ToString() + SK.Text("VillageMap_Minute_Abbrev", "m") + ":";
			}
			if (num < 10 && secsLeft >= 60)
			{
				str += "0";
			}
			return str + num.ToString() + SK.Text("VillageMap_Second_Abbrev", "s");
		}

		// Token: 0x06002DC1 RID: 11713 RVA: 0x00244978 File Offset: 0x00242B78
		public static string createBuildTimeStringFull(int secsLeft)
		{
			int num = secsLeft % 60;
			int num2 = secsLeft / 60 % 60;
			int num3 = secsLeft / 3600 % 24;
			int num4 = secsLeft / 86400;
			string text = "";
			if (num4 > 0)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					num4.ToString(),
					SK.Text("VillageMap_Day_Abbrev", "d"),
					'\u00a0'
				});
			}
			if (num3 > 0 || num4 > 0)
			{
				if (num3 < 10)
				{
					text += "0";
				}
				object obj2 = text;
				text = string.Concat(new object[]
				{
					obj2,
					num3.ToString(),
					SK.Text("VillageMap_Hour_Abbrev", "h"),
					'\u00a0'
				});
			}
			if (num2 > 0 || num3 > 0 || num4 > 0)
			{
				if (num2 < 10)
				{
					text += "0";
				}
				object obj3 = text;
				text = string.Concat(new object[]
				{
					obj3,
					num2.ToString(),
					SK.Text("VillageMap_Minute_Abbrev", "m"),
					'\u00a0'
				});
			}
			if (num < 10 && secsLeft >= 60)
			{
				text += "0";
			}
			return text + num.ToString() + SK.Text("VillageMap_Second_Abbrev", "s");
		}

		// Token: 0x06002DC2 RID: 11714 RVA: 0x00244ADC File Offset: 0x00242CDC
		public static string createBuildTimeVariable(int secsLeft)
		{
			int num = secsLeft % 60;
			int num2 = secsLeft / 60 % 60;
			int num3 = secsLeft / 3600 % 24;
			int num4 = secsLeft / 86400;
			string text = "";
			if (num4 > 0)
			{
				text = text + num4.ToString() + SK.Text("VillageMap_Day_Abbrev", "d") + ":";
			}
			if (num3 > 0)
			{
				if (num3 < 10)
				{
					text += "0";
				}
				text = text + num3.ToString() + SK.Text("VillageMap_Hour_Abbrev", "h") + ":";
			}
			if (num2 > 0 && num4 == 0)
			{
				if (num2 < 10)
				{
					text += "0";
				}
				text = text + num2.ToString() + SK.Text("VillageMap_Minute_Abbrev", "m") + ":";
			}
			if (num4 == 0 && num3 == 0)
			{
				if (num < 10 && secsLeft >= 60)
				{
					text += "0";
				}
				text = text + num.ToString() + SK.Text("VillageMap_Second_Abbrev", "s");
			}
			return text.TrimEnd(new char[]
			{
				':'
			});
		}

		// Token: 0x06002DC3 RID: 11715 RVA: 0x00244C00 File Offset: 0x00242E00
		public int updateConstructionDisplayTime(int secsLeft, DateTime completionTime, out int queuePosition)
		{
			this.ConstrTimeCompletionList.Clear();
			queuePosition = 0;
			foreach (VillageMapBuilding villageMapBuilding in this.localBuildings)
			{
				if (!villageMapBuilding.isComplete() && !villageMapBuilding.isDeleting())
				{
					this.ConstrTimeCompletionList.Add(villageMapBuilding.completionTime);
				}
			}
			if (this.ConstrTimeCompletionList.Count > 1)
			{
				queuePosition = 1;
				this.ConstrTimeCompletionList.Sort(this.buildingOrderComparer);
			}
			int i = 0;
			while (i < this.ConstrTimeCompletionList.Count)
			{
				if (this.ConstrTimeCompletionList[i] == completionTime)
				{
					queuePosition += i;
					if (i == 0)
					{
						return secsLeft;
					}
					return (int)(completionTime - this.ConstrTimeCompletionList[i - 1]).TotalSeconds;
				}
				else
				{
					i++;
				}
			}
			return secsLeft;
		}

		// Token: 0x06002DC4 RID: 11716 RVA: 0x0002196A File Offset: 0x0001FB6A
		public void leaveMap()
		{
			this.stopPlaceBuilding(true);
			Sound.stopVillageEnvironmentalExceptWorld();
		}

		// Token: 0x06002DC5 RID: 11717 RVA: 0x00021978 File Offset: 0x0001FB78
		public static bool isMovingBuilding()
		{
			return VillageMap.m_movingBuilding != null;
		}

		// Token: 0x06002DC6 RID: 11718 RVA: 0x00021982 File Offset: 0x0001FB82
		public PointF getBackgroundSpritePoint()
		{
			return new PointF(this.backgroundSprite.PosX, this.backgroundSprite.PosY);
		}

		// Token: 0x06002DC7 RID: 11719 RVA: 0x00244CF4 File Offset: 0x00242EF4
		public VillageMapBuilding getBuildingFromID(long buildingID)
		{
			VillageMapBuilding result = null;
			foreach (VillageMapBuilding villageMapBuilding in this.localBuildings)
			{
				if (villageMapBuilding.buildingID == buildingID)
				{
					return villageMapBuilding;
				}
			}
			return result;
		}

		// Token: 0x06002DC8 RID: 11720 RVA: 0x00244D54 File Offset: 0x00242F54
		public long getBuildingAtMapTile(Point mapTile)
		{
			int num = 5;
			long result = 0L;
			int num2 = 1000;
			Point point = default(Point);
			foreach (VillageMapBuilding villageMapBuilding in this.Buildings)
			{
				point.X = Math.Abs(villageMapBuilding.buildingLocation.X - mapTile.X);
				point.Y = Math.Abs(villageMapBuilding.buildingLocation.Y - mapTile.Y);
				if (point.X <= num && point.Y <= num && point.X + point.Y < num2)
				{
					result = villageMapBuilding.buildingID;
					num2 = point.X + point.Y;
				}
			}
			return result;
		}

		// Token: 0x06002DC9 RID: 11721 RVA: 0x00244E3C File Offset: 0x0024303C
		public long getBuildingAtPoint(Point loc)
		{
			long buildingIDFromWorldPos = VillageMap.villageClickMask.getBuildingIDFromWorldPos(loc);
			if (buildingIDFromWorldPos < 0L)
			{
				if (InterfaceMgr.Instance.isInBuildingPanelOpen())
				{
					if (!GameEngine.Instance.World.isCapital(this.VillageID))
					{
						GameEngine.Instance.playInterfaceSound("VillageMap_select_building_Close");
					}
					else
					{
						GameEngine.Instance.playInterfaceSound("VillageMap_select_capital_building_Close");
					}
				}
				InterfaceMgr.Instance.showInBuildingInfo(null);
			}
			return buildingIDFromWorldPos;
		}

		// Token: 0x06002DCA RID: 11722 RVA: 0x0002199F File Offset: 0x0001FB9F
		public VillageMapBuilding getSelectedBuilding()
		{
			return this.m_selectedBuilding;
		}

		// Token: 0x06002DCB RID: 11723 RVA: 0x000219A7 File Offset: 0x0001FBA7
		public void deselectBuilding()
		{
			this.m_selectedBuilding = null;
			this.clearColouredBuildings();
		}

		// Token: 0x06002DCC RID: 11724 RVA: 0x00244EAC File Offset: 0x002430AC
		public void selectBuilding(VillageMapBuilding building)
		{
			this.m_selectedBuilding = building;
			if (InterfaceMgr.Instance.isInBuildingPanelOpen())
			{
				if (!GameEngine.Instance.World.isCapital(this.VillageID))
				{
					GameEngine.Instance.playInterfaceSound("VillageMap_select_building_Already_Open");
				}
				else
				{
					GameEngine.Instance.playInterfaceSound("VillageMap_select_capital_building_Already_Open");
				}
			}
			else if (!GameEngine.Instance.World.isCapital(this.VillageID))
			{
				GameEngine.Instance.playInterfaceSound("VillageMap_select_building");
			}
			else
			{
				GameEngine.Instance.playInterfaceSound("VillageMap_select_capital_building");
			}
			string buildingNameLabel = VillageBuildingsData.getBuildingNameLabel(building.buildingType);
			if (buildingNameLabel.Length > 0 && (DateTime.Now - this.lastClickedSound).TotalSeconds > 2.0)
			{
				this.lastClickedSound = DateTime.Now;
				if (!GameEngine.Instance.AudioEngine.isSoundPlaying(buildingNameLabel))
				{
					GameEngine.Instance.playInterfaceSound(buildingNameLabel);
				}
			}
			InterfaceMgr.Instance.showInBuildingInfo(building);
		}

		// Token: 0x06002DCD RID: 11725 RVA: 0x00244FA8 File Offset: 0x002431A8
		public void mouseClicked(Point mousePos)
		{
			bool flag = true;
			if (!GameEngine.Instance.World.isCapital(this.m_villageID))
			{
				flag = false;
				if (InterfaceMgr.Instance.clickDXCardBar(mousePos))
				{
					return;
				}
				if (GameEngine.Instance.World.isTutorialActive() && mousePos.X < 64 && mousePos.Y >= this.gfx.ViewportHeight - 64)
				{
					GameEngine.Instance.World.forceTutorialToBeShown();
					return;
				}
			}
			if (mousePos.X > this.gfx.ViewportWidth - 32 && mousePos.Y < 32)
			{
				if (!flag)
				{
					CustomSelfDrawPanel.WikiLinkControl.openHelpLink(1);
					return;
				}
				CustomSelfDrawPanel.WikiLinkControl.openHelpLink(9);
				return;
			}
			else
			{
				if (VillageMap.placementSprite != null)
				{
					this.placeBuilding(mousePos);
					return;
				}
				this.clearColouredBuildings();
				Point point = this.Camera.ScreenToWorldSpace(mousePos);
				long buildingAtPoint = this.getBuildingAtPoint(point);
				VillageMapBuilding buildingFromID = this.getBuildingFromID(buildingAtPoint);
				if (buildingFromID == null)
				{
					return;
				}
				if (buildingFromID.goTransparent)
				{
					VillageMap.villageClickMask.mapDirty = true;
					VillageMap.villageClickMask.ignoredBuildingID = buildingAtPoint;
					long buildingIDFromWorldPos = VillageMap.villageClickMask.getBuildingIDFromWorldPos(point);
					if (buildingIDFromWorldPos < 0L)
					{
						return;
					}
					buildingFromID = this.getBuildingFromID(buildingIDFromWorldPos);
				}
				this.selectBuilding(buildingFromID);
				return;
			}
		}

		// Token: 0x06002DCE RID: 11726 RVA: 0x002450D0 File Offset: 0x002432D0
		public void highlightBuilding(VillageMapBuilding highlightBuilding)
		{
			foreach (VillageMapBuilding villageMapBuilding in this.localBuildings)
			{
				Color color = global::ARGBColors.White;
				if (villageMapBuilding != highlightBuilding)
				{
					color = Color.FromArgb(176, 176, 176);
					if (!villageMapBuilding.isComplete() || villageMapBuilding.isDeleting())
					{
						continue;
					}
				}
				villageMapBuilding.baseSprite.ColorToUse = color;
				if (villageMapBuilding.stockpileExtension != null)
				{
					villageMapBuilding.stockpileExtension.colorSprites(color);
				}
				if (villageMapBuilding.granaryExtension != null)
				{
					villageMapBuilding.granaryExtension.colorSprites(color);
				}
				if (villageMapBuilding.innExtension != null)
				{
					villageMapBuilding.innExtension.colorSprites(color);
				}
			}
			highlightBuilding.highlighted = true;
		}

		// Token: 0x06002DCF RID: 11727 RVA: 0x002451A0 File Offset: 0x002433A0
		public void tintBuilding(VillageMapBuilding building, Color col)
		{
			building.baseSprite.ColorToUse = col;
			if (building.stockpileExtension != null)
			{
				building.stockpileExtension.colorSprites(col);
			}
			if (building.granaryExtension != null)
			{
				building.granaryExtension.colorSprites(col);
			}
			if (building.innExtension != null)
			{
				building.innExtension.colorSprites(col);
			}
			if (building.shadowSprite != null)
			{
				building.shadowSprite.ColorToUse = col;
			}
		}

		// Token: 0x06002DD0 RID: 11728 RVA: 0x0024520C File Offset: 0x0024340C
		public void clearColouredBuildings()
		{
			foreach (VillageMapBuilding villageMapBuilding in this.localBuildings)
			{
				villageMapBuilding.highlighted = false;
				if (villageMapBuilding.isComplete() && !villageMapBuilding.isDeleting())
				{
					villageMapBuilding.baseSprite.ColorToUse = global::ARGBColors.White;
					if (villageMapBuilding.animSprite != null)
					{
						villageMapBuilding.animSprite.ColorToUse = global::ARGBColors.White;
					}
					if (villageMapBuilding.extraAnimSprite1 != null)
					{
						villageMapBuilding.extraAnimSprite1.ColorToUse = global::ARGBColors.White;
					}
					if (villageMapBuilding.extraAnimSprite2 != null)
					{
						villageMapBuilding.extraAnimSprite2.ColorToUse = global::ARGBColors.White;
					}
					if (villageMapBuilding.stockpileExtension != null)
					{
						villageMapBuilding.stockpileExtension.colorSprites(global::ARGBColors.White);
					}
					if (villageMapBuilding.granaryExtension != null)
					{
						villageMapBuilding.granaryExtension.colorSprites(global::ARGBColors.White);
					}
					if (villageMapBuilding.innExtension != null)
					{
						villageMapBuilding.innExtension.colorSprites(global::ARGBColors.White);
					}
				}
				else
				{
					villageMapBuilding.updateConstructionGFX(VillageMap.localBaseTime, VillageMap.baseServerTime, false, this);
				}
			}
		}

		// Token: 0x06002DD1 RID: 11729 RVA: 0x00245330 File Offset: 0x00243530
		public void startPlaceBuilding(int buildingType, bool moving)
		{
			this.stopPlaceBuilding(!moving);
			VillageMap.placingAsFree = moving;
			VillageMap.placementType = buildingType;
			VillageMap.placementSprite = new SpriteWrapper();
			InterfaceMgr.Instance.toggleDXCardBarActive(false);
			int num = GFXLibrary.Instance.VillageOverlaysAnimTexID;
			int num2 = 0;
			int num3 = 0;
			if (buildingType == 1)
			{
				switch (GameEngine.Instance.World.UserResearchData.Research_HousingCapacity)
				{
				case 2:
				case 3:
					buildingType = 39;
					break;
				case 4:
				case 5:
					buildingType = 40;
					break;
				case 6:
					buildingType = 76;
					break;
				case 7:
				case 8:
				case 9:
					buildingType = 77;
					break;
				}
				VillageMap.placementSprite.attachText("0", new Point(15, -90), global::ARGBColors.White, true, true);
				VillageMap.placementSprite_subSprite = new SpriteWrapper();
				VillageMap.placementSprite_subSprite.TextureID = GFXLibrary.Instance.VillageOverlaysAnimTexID;
				VillageMap.placementSprite_subSprite.Initialize(this.gfx);
				VillageMap.placementSprite_subSprite.SpriteNo = 16;
				VillageMap.placementSprite_subSprite.Center = new PointF(32f, 32f);
				VillageMap.placementSprite_subSprite.PosX = -15f;
				VillageMap.placementSprite_subSprite.PosY = -90f;
				VillageMap.placementSprite.DrawChildrenWithParent = true;
				VillageMap.placementSprite.AddChild(VillageMap.placementSprite_subSprite, 1);
			}
			else
			{
				int num4 = -1;
				switch (buildingType)
				{
				case 6:
					num4 = 27;
					num2 = 10;
					num3 = 0;
					break;
				case 7:
					num4 = 22;
					num2 = 30;
					num3 = -60;
					break;
				case 8:
					num4 = 12;
					num2 = 10;
					num3 = -20;
					break;
				case 9:
					num4 = 18;
					num2 = 20;
					num3 = 20;
					break;
				case 12:
					num4 = 0;
					num2 = 30;
					num3 = -50;
					break;
				case 13:
					num4 = 1;
					num2 = 30;
					num3 = -60;
					break;
				case 14:
					num4 = 4;
					num2 = 130;
					num3 = -60;
					break;
				case 15:
					num4 = 24;
					num2 = 30;
					num3 = -10;
					break;
				case 16:
					num4 = 13;
					num2 = 30;
					num3 = -20;
					break;
				case 17:
					num4 = 6;
					num2 = 30;
					num3 = -45;
					break;
				case 18:
					num4 = 8;
					num2 = 30;
					num3 = -20;
					break;
				case 19:
					num4 = 7;
					num2 = 10;
					num3 = -35;
					break;
				case 21:
					num4 = 10;
					num2 = 10;
					num3 = -50;
					break;
				case 22:
					num4 = 25;
					num2 = 15;
					num3 = 0;
					break;
				case 23:
					num4 = 19;
					num2 = 10;
					num3 = 0;
					break;
				case 24:
					num4 = 21;
					num2 = 10;
					num3 = -100;
					break;
				case 25:
					num4 = 20;
					num2 = 10;
					num3 = -100;
					break;
				case 26:
					num4 = 14;
					num2 = 25;
					num3 = -50;
					break;
				case 28:
					num4 = 17;
					num2 = 30;
					num3 = -20;
					break;
				case 29:
					num4 = 3;
					num2 = 30;
					num3 = -20;
					break;
				case 30:
					num4 = 23;
					num2 = 30;
					num3 = -30;
					break;
				case 31:
					num4 = 2;
					num2 = 30;
					num3 = -30;
					break;
				case 32:
					num4 = 5;
					num2 = 40;
					num3 = -40;
					break;
				case 33:
					num4 = 26;
					num2 = 30;
					num3 = -30;
					break;
				case 34:
					num4 = 30;
					num2 = 30;
					num3 = -50;
					break;
				case 36:
					num4 = 30;
					num2 = 30;
					num3 = -140;
					break;
				case 37:
					num4 = 30;
					num2 = 30;
					num3 = -230;
					break;
				case 38:
				case 41:
				case 42:
				case 43:
				case 44:
				case 45:
					num4 = 11;
					num2 = 10;
					num3 = 20;
					break;
				case 49:
				case 50:
				case 51:
					num4 = 11;
					num2 = 10;
					num3 = 20;
					break;
				case 54:
				case 55:
				case 56:
				case 57:
					num4 = 11;
					num2 = 10;
					num3 = -40;
					break;
				case 58:
				case 59:
					num4 = 11;
					num2 = 20;
					num3 = -80;
					break;
				case 60:
					num4 = 11;
					num2 = 30;
					num3 = -85;
					break;
				case 61:
					num4 = 11;
					num2 = 30;
					num3 = 20;
					break;
				case 62:
					num4 = 11;
					num2 = 10;
					num3 = -20;
					break;
				case 63:
					num4 = 11;
					num2 = 10;
					num3 = -35;
					break;
				case 64:
					num4 = 11;
					num2 = 30;
					num3 = 20;
					break;
				case 65:
					num2 = 30;
					num4 = 28;
					break;
				case 66:
					num2 = 24;
					num4 = 28;
					break;
				case 67:
					num2 = 30;
					num3 = -100;
					num4 = 28;
					break;
				case 68:
					num2 = 20;
					num4 = 28;
					break;
				case 69:
					num2 = 30;
					num3 = -30;
					num4 = 28;
					break;
				case 70:
				case 71:
				case 72:
				case 73:
					num4 = 30;
					num2 = 30;
					num3 = -20;
					break;
				case 74:
				case 75:
					num4 = 30;
					num2 = 30;
					num3 = -10;
					break;
				case 79:
					num4 = 50;
					num = GFXLibrary.Instance.TownBuildindsTexID;
					num2 = VillageMap.s_villageBuildingData[buildingType].animOffset.X;
					num3 = VillageMap.s_villageBuildingData[buildingType].animOffset.Y;
					break;
				case 80:
					num4 = 51;
					num = GFXLibrary.Instance.TownBuildindsTexID;
					num2 = VillageMap.s_villageBuildingData[buildingType].animOffset.X;
					num3 = VillageMap.s_villageBuildingData[buildingType].animOffset.Y;
					break;
				case 81:
					num4 = 52;
					num = GFXLibrary.Instance.TownBuildindsTexID;
					num2 = VillageMap.s_villageBuildingData[buildingType].animOffset.X;
					num3 = VillageMap.s_villageBuildingData[buildingType].animOffset.Y;
					break;
				case 82:
					num4 = 53;
					num = GFXLibrary.Instance.TownBuildindsTexID;
					num2 = VillageMap.s_villageBuildingData[buildingType].animOffset.X;
					num3 = VillageMap.s_villageBuildingData[buildingType].animOffset.Y;
					break;
				case 83:
					num4 = 54;
					num = GFXLibrary.Instance.TownBuildindsTexID;
					num2 = VillageMap.s_villageBuildingData[buildingType].animOffset.X;
					num3 = VillageMap.s_villageBuildingData[buildingType].animOffset.Y;
					break;
				case 84:
					num4 = 55;
					num = GFXLibrary.Instance.TownBuildindsTexID;
					num2 = VillageMap.s_villageBuildingData[buildingType].animOffset.X;
					num3 = VillageMap.s_villageBuildingData[buildingType].animOffset.Y;
					break;
				case 85:
					num4 = 56;
					num = GFXLibrary.Instance.TownBuildindsTexID;
					num2 = VillageMap.s_villageBuildingData[buildingType].animOffset.X;
					num3 = VillageMap.s_villageBuildingData[buildingType].animOffset.Y;
					break;
				case 86:
					num4 = 57;
					num = GFXLibrary.Instance.TownBuildindsTexID;
					num2 = VillageMap.s_villageBuildingData[buildingType].animOffset.X;
					num3 = VillageMap.s_villageBuildingData[buildingType].animOffset.Y;
					break;
				case 87:
					num4 = 58;
					num = GFXLibrary.Instance.TownBuildindsTexID;
					num2 = VillageMap.s_villageBuildingData[buildingType].animOffset.X;
					num3 = VillageMap.s_villageBuildingData[buildingType].animOffset.Y;
					break;
				case 88:
					num4 = 59;
					num = GFXLibrary.Instance.TownBuildindsTexID;
					num2 = VillageMap.s_villageBuildingData[buildingType].animOffset.X;
					num3 = VillageMap.s_villageBuildingData[buildingType].animOffset.Y;
					break;
				case 89:
					num4 = 60;
					num = GFXLibrary.Instance.TownBuildindsTexID;
					num2 = VillageMap.s_villageBuildingData[buildingType].animOffset.X;
					num3 = VillageMap.s_villageBuildingData[buildingType].animOffset.Y;
					break;
				case 90:
					num4 = 61;
					num = GFXLibrary.Instance.TownBuildindsTexID;
					num2 = VillageMap.s_villageBuildingData[buildingType].animOffset.X;
					num3 = VillageMap.s_villageBuildingData[buildingType].animOffset.Y;
					break;
				case 91:
					num4 = 62;
					num = GFXLibrary.Instance.TownBuildindsTexID;
					num2 = VillageMap.s_villageBuildingData[buildingType].animOffset.X;
					num3 = VillageMap.s_villageBuildingData[buildingType].animOffset.Y;
					break;
				case 92:
					num4 = 63;
					num = GFXLibrary.Instance.TownBuildindsTexID;
					num2 = VillageMap.s_villageBuildingData[buildingType].animOffset.X;
					num3 = VillageMap.s_villageBuildingData[buildingType].animOffset.Y;
					break;
				case 93:
					num4 = 64;
					num = GFXLibrary.Instance.TownBuildindsTexID;
					num2 = VillageMap.s_villageBuildingData[buildingType].animOffset.X;
					num3 = VillageMap.s_villageBuildingData[buildingType].animOffset.Y;
					break;
				case 94:
					num4 = 65;
					num = GFXLibrary.Instance.TownBuildindsTexID;
					num2 = VillageMap.s_villageBuildingData[buildingType].animOffset.X;
					num3 = VillageMap.s_villageBuildingData[buildingType].animOffset.Y;
					break;
				case 95:
					num4 = 66;
					num = GFXLibrary.Instance.TownBuildindsTexID;
					num2 = VillageMap.s_villageBuildingData[buildingType].animOffset.X;
					num3 = VillageMap.s_villageBuildingData[buildingType].animOffset.Y;
					break;
				case 96:
					num4 = 67;
					num = GFXLibrary.Instance.TownBuildindsTexID;
					num2 = VillageMap.s_villageBuildingData[buildingType].animOffset.X;
					num3 = VillageMap.s_villageBuildingData[buildingType].animOffset.Y;
					break;
				case 97:
					num4 = 68;
					num = GFXLibrary.Instance.TownBuildindsTexID;
					num2 = VillageMap.s_villageBuildingData[buildingType].animOffset.X;
					num3 = VillageMap.s_villageBuildingData[buildingType].animOffset.Y;
					break;
				case 98:
					num4 = 69;
					num = GFXLibrary.Instance.TownBuildindsTexID;
					num2 = VillageMap.s_villageBuildingData[buildingType].animOffset.X;
					num3 = VillageMap.s_villageBuildingData[buildingType].animOffset.Y;
					break;
				case 99:
					num4 = 70;
					num = GFXLibrary.Instance.TownBuildindsTexID;
					num2 = VillageMap.s_villageBuildingData[buildingType].animOffset.X;
					num3 = VillageMap.s_villageBuildingData[buildingType].animOffset.Y;
					break;
				case 100:
					num4 = 71;
					num = GFXLibrary.Instance.TownBuildindsTexID;
					num2 = VillageMap.s_villageBuildingData[buildingType].animOffset.X;
					num3 = VillageMap.s_villageBuildingData[buildingType].animOffset.Y;
					break;
				case 101:
					num4 = 72;
					num = GFXLibrary.Instance.TownBuildindsTexID;
					num2 = VillageMap.s_villageBuildingData[buildingType].animOffset.X;
					num3 = VillageMap.s_villageBuildingData[buildingType].animOffset.Y;
					break;
				case 102:
					num4 = 73;
					num = GFXLibrary.Instance.TownBuildindsTexID;
					num2 = VillageMap.s_villageBuildingData[buildingType].animOffset.X;
					num3 = VillageMap.s_villageBuildingData[buildingType].animOffset.Y;
					break;
				}
				if (num4 >= 0)
				{
					if (num == GFXLibrary.Instance.TownBuildindsTexID)
					{
						VillageMap.placementSprite_subSprite = new SpriteWrapper();
						VillageMap.placementSprite_subSprite.TextureID = num;
						VillageMap.placementSprite_subSprite.Initialize(this.gfx);
						VillageMap.placementSprite_subSprite.SpriteNo = num4;
						VillageMap.placementSprite_subSprite.PosX = 0f;
						VillageMap.placementSprite_subSprite.PosY = 0f;
						PointF center = default(PointF);
						center.X = (float)VillageMap.s_villageBuildingData[buildingType].animOffset.X;
						center.Y = (float)VillageMap.s_villageBuildingData[buildingType].animOffset.Y;
						VillageMap.placementSprite_subSprite.Center = center;
						VillageMap.placementSprite.DrawChildrenWithParent = true;
						VillageMap.placementSprite.AddChild(VillageMap.placementSprite_subSprite, 1);
					}
					else
					{
						VillageMap.placementSprite.attachText("0", new Point(num2, -90 + num3), global::ARGBColors.White, false, true);
						VillageMap.placementSprite_subSprite = new SpriteWrapper();
						VillageMap.placementSprite_subSprite.TextureID = num;
						VillageMap.placementSprite_subSprite.Initialize(this.gfx);
						VillageMap.placementSprite_subSprite.SpriteNo = num4;
						VillageMap.placementSprite_subSprite.Center = new PointF(32f, 32f);
						VillageMap.placementSprite_subSprite.PosX = (float)(-30 + num2);
						VillageMap.placementSprite_subSprite.PosY = (float)(-90 + num3);
						VillageMap.placementSprite.DrawChildrenWithParent = true;
						VillageMap.placementSprite.AddChild(VillageMap.placementSprite_subSprite, 1);
					}
				}
				else
				{
					VillageMap.placementSprite.attachText("", new Point(0, -90), global::ARGBColors.White, true, true);
				}
			}
			VillageMap.placementSprite.TextureID = VillageMap.s_villageBuildingData[buildingType].baseGfxTexID;
			VillageMap.placementSprite.Initialize(this.gfx);
			int baseGfxID = VillageMap.s_villageBuildingData[buildingType].baseGfxID;
			int num5 = 0;
			if (buildingType == 0)
			{
				int rank = GameEngine.Instance.World.getRank();
				if (rank >= 15)
				{
					num5 = 6;
				}
				else if (rank >= 10)
				{
					num5 = 3;
				}
			}
			VillageMap.placementSprite.SpriteNo = baseGfxID + num5;
			PointF center2 = default(PointF);
			center2.X = (float)VillageMap.s_villageBuildingData[buildingType].baseOffset.X;
			center2.Y = (float)VillageMap.s_villageBuildingData[buildingType].baseOffset.Y;
			VillageMap.placementSprite.Center = center2;
			this.backgroundSprite.AddChild(VillageMap.placementSprite, 10);
			VillageMap.placementSprite.PosX = -1000f;
			VillageMap.placementSprite.PosY = -1000f;
		}

		// Token: 0x06002DD2 RID: 11730 RVA: 0x0024603C File Offset: 0x0024423C
		public void centerPlacementSprite()
		{
			Point cameraCentre = this.Camera.getCameraCentre();
			Point mapTile = this.Camera.WorldSpaceToMapTile(cameraCentre);
			this.movePlacementBuildingToTile(mapTile);
		}

		// Token: 0x06002DD3 RID: 11731 RVA: 0x000219B6 File Offset: 0x0001FBB6
		public Point getPlacementScreenPosition()
		{
			if (VillageMap.placementSprite != null)
			{
				return this.Camera.MapTileToScreenSpace(this.lastPlaceBuildingLoc);
			}
			return Point.Empty;
		}

		// Token: 0x06002DD4 RID: 11732 RVA: 0x0024606C File Offset: 0x0024426C
		public void startPlaceBuilding_ShowPanel(int buildingType, string name, bool showHelp)
		{
			int woodCost = 0;
			int stoneCost = 0;
			int clayCost = 0;
			int goldCost = 0;
			int num = 0;
			VillageBuildingsData.calcBuildingCosts(GameEngine.Instance.LocalWorldData, buildingType, this.countBuildingType(buildingType), ref woodCost, ref stoneCost, ref clayCost, ref goldCost, (int)GameEngine.Instance.World.UserResearchData.Research_Tools, ref num);
			if (num > 0 && GameEngine.Instance.LocalWorldData.constrFlagCost[buildingType] > 0 && this.m_capitalBuildingsBuilt != null && this.m_capitalBuildingsBuilt.Contains(buildingType))
			{
				num = 0;
			}
			TimeSpan timeSpan = default(TimeSpan);
			double num2 = 0.0;
			timeSpan = (GameEngine.Instance.World.isCapital(this.m_villageID) ? this.capitalConstructionTime() : VillageBuildingsData.calcConstructionTime(GameEngine.Instance.LocalWorldData, buildingType, this.localBuildings.Count, (int)GameEngine.Instance.World.UserResearchData.Research_Architecture, GameEngine.Instance.cardsManager.UserCardData, ref num2));
			int realBuildingType = buildingType;
			if (!showHelp)
			{
				buildingType = -1;
			}
			int num3 = (int)timeSpan.TotalSeconds;
			int num4 = (int)num2;
			if (GameEngine.Instance.World.getTutorialStage() == 2 && num4 + 2 == 17)
			{
				num3 = 1;
			}
			if (GameEngine.Instance.World.getTutorialStage() == 3 && (num4 + 2 == 25 || num4 + 2 == 36))
			{
				num3 = 1;
			}
			InterfaceMgr.Instance.showVillageBuildingInfo(name, woodCost, stoneCost, clayCost, goldCost, num, VillageMap.createBuildTimeString(num3 + 2), buildingType, realBuildingType);
		}

		// Token: 0x06002DD5 RID: 11733 RVA: 0x002461D8 File Offset: 0x002443D8
		public TimeSpan capitalConstructionTime()
		{
			int count = this.localBuildings.Count;
			int num;
			switch (count)
			{
			case 0:
				num = 4;
				break;
			case 1:
				num = 6;
				break;
			case 2:
				num = 8;
				break;
			case 3:
				num = 10;
				break;
			case 4:
				num = 12;
				break;
			case 5:
				num = 14;
				break;
			case 6:
				num = 16;
				break;
			case 7:
				num = 18;
				break;
			case 8:
				num = 20;
				break;
			case 9:
				num = 22;
				break;
			case 10:
				num = 24;
				break;
			default:
				num = 24 + (count - 10);
				break;
			}
			int num2 = num * 60;
			num2 = (int)((double)num2 * ResearchData.ParishTownHallIncreases_Guilds[(int)this.m_parishCapitalResearchData.Research_Architecture]);
			return new TimeSpan(0, num2, 0);
		}

		// Token: 0x06002DD6 RID: 11734 RVA: 0x000219D6 File Offset: 0x0001FBD6
		public int numCapitalBuildings()
		{
			return this.localBuildings.Count;
		}

		// Token: 0x06002DD7 RID: 11735 RVA: 0x000219E3 File Offset: 0x0001FBE3
		public void releaseTouch()
		{
			this.m_leftMouseHeldDown = false;
			this.m_leftMouseGrabbed = false;
		}

		// Token: 0x06002DD8 RID: 11736 RVA: 0x000219F3 File Offset: 0x0001FBF3
		public void mouseNotClicked(Point mousePos)
		{
			if (this.m_leftMouseHeldDown)
			{
				if (!this.m_leftMouseGrabbed)
				{
					this.mouseClicked(mousePos);
				}
				this.m_leftMouseHeldDown = false;
				this.m_leftMouseGrabbed = false;
				CursorManager.SetCursor(CursorManager.CursorType.Default, InterfaceMgr.Instance.ParentForm);
			}
		}

		// Token: 0x06002DD9 RID: 11737 RVA: 0x00021A2A File Offset: 0x0001FC2A
		public bool holdingLeftMouse()
		{
			return this.m_leftMouseHeldDown;
		}

		// Token: 0x06002DDA RID: 11738 RVA: 0x00021A32 File Offset: 0x0001FC32
		public bool isPlacingBuilding()
		{
			return VillageMap.placementSprite != null;
		}

		// Token: 0x06002DDB RID: 11739 RVA: 0x00246288 File Offset: 0x00244488
		public void mouseMoveUpdate(Point mousePos, bool mouseDown)
		{
			if (this.backgroundSprite != null)
			{
				if (!GameEngine.Instance.World.isCapital(this.m_villageID))
				{
					InterfaceMgr.Instance.mouseMoveDXCardBar(mousePos);
				}
				this.m_previousMousePos = this.m_lastMousePos;
				this.m_lastMousePos = mousePos;
				Point loc = this.Camera.ScreenToWorldSpace(mousePos);
				if (mousePos.X > this.gfx.ViewportWidth - 32 && mousePos.Y < 32)
				{
					this.overWikiHelp = true;
					CustomTooltipManager.MouseEnterTooltipArea(4400, 1);
				}
				else
				{
					this.overWikiHelp = false;
				}
				if (mouseDown)
				{
					this.mouseDrag(mousePos);
				}
				this.mouseHoverOverPoint(loc);
				this.movePlacementBuildingToScreenPos(mousePos);
			}
		}

		// Token: 0x06002DDC RID: 11740 RVA: 0x00246338 File Offset: 0x00244538
		public void mouseDrag(Point mousePos)
		{
			if (!this.m_leftMouseHeldDown)
			{
				this.m_lastMousePressedTime = DXTimer.GetCurrentMilliseconds();
				this.m_baseMousePos = mousePos;
				this.m_leftMouseHeldDown = true;
				this.m_leftMouseGrabbed = false;
				this.m_previousMousePos = mousePos;
			}
			double currentMilliseconds = DXTimer.GetCurrentMilliseconds();
			if (currentMilliseconds - this.m_lastMousePressedTime > 250.0 || Math.Abs(this.m_baseMousePos.X - mousePos.X) > 3 || Math.Abs(this.m_baseMousePos.Y - mousePos.Y) > 3)
			{
				CursorManager.SetCursor(CursorManager.CursorType.Hand, InterfaceMgr.Instance.ParentForm);
				this.m_leftMouseGrabbed = true;
				int x = mousePos.X - this.m_previousMousePos.X;
				int y = mousePos.Y - this.m_previousMousePos.Y;
				this.Camera.Drag(new Point(x, y));
				this.m_previousMousePos = mousePos;
				if (GameEngine.Instance.World.getTutorialStage() == 105 && !GameEngine.Instance.World.TutorialIsAdvancing())
				{
					GameEngine.Instance.World.advanceTutorial();
				}
			}
		}

		// Token: 0x06002DDD RID: 11741 RVA: 0x00246454 File Offset: 0x00244654
		public void mouseHoverOverPoint(Point loc)
		{
			bool flag = false;
			VillageMapBuilding villageMapBuilding = null;
			long num = -1L;
			foreach (VillageMapBuilding villageMapBuilding2 in this.localBuildings)
			{
				if (villageMapBuilding2.goTransparent)
				{
					villageMapBuilding = villageMapBuilding2;
					break;
				}
			}
			long buildingIDFromWorldPos = VillageMap.villageClickMask.getBuildingIDFromWorldPos(loc);
			if (buildingIDFromWorldPos >= 0L)
			{
				VillageMapBuilding buildingFromID = this.getBuildingFromID(buildingIDFromWorldPos);
				if (buildingFromID != null)
				{
					if (buildingFromID.buildingType == 3 && !GameEngine.shiftPressed)
					{
						if (this.granaryOpenCount == 0)
						{
							buildingFromID.open = true;
							this.granaryOpenCount = 30;
							this.updateGFXState(buildingFromID);
							buildingFromID.updateGranary(this.gfx, this);
						}
						else
						{
							this.granaryOpenCount = 30;
						}
					}
					else if (!buildingFromID.complete)
					{
						buildingFromID.showFullConstructionText = true;
					}
					else if (GameEngine.shiftPressed)
					{
						num = buildingFromID.buildingID;
						buildingFromID.goTransparent = true;
						Color colorToUse = Color.FromArgb(96, 255, 255, 255);
						buildingFromID.baseSprite.ColorToUse = colorToUse;
						if (buildingFromID.animSprite != null)
						{
							buildingFromID.animSprite.ColorToUse = colorToUse;
						}
						if (buildingFromID.extraAnimSprite1 != null)
						{
							buildingFromID.extraAnimSprite1.ColorToUse = colorToUse;
						}
						if (buildingFromID.extraAnimSprite2 != null)
						{
							buildingFromID.extraAnimSprite2.ColorToUse = colorToUse;
						}
					}
					if (this.m_parishCapitalResearchData != null && GameEngine.Instance.World.isCapital(this.m_villageID))
					{
						bool flag2 = false;
						int capitalResourceFromBuildingType = this.m_parishCapitalResearchData.getCapitalResourceFromBuildingType(buildingFromID.buildingType);
						if (capitalResourceFromBuildingType < 0)
						{
							flag2 = true;
						}
						else
						{
							int requiredResourceType = VillageBuildingsData.getRequiredResourceType(buildingFromID.buildingType, 0);
							if (requiredResourceType >= 0 && buildingFromID.capitalResourceLevels.Length != 0)
							{
								int requiredResourceTypeLevel = VillageBuildingsData.getRequiredResourceTypeLevel(buildingFromID.buildingType, 0, capitalResourceFromBuildingType, GameEngine.Instance.World.ThirdAgeWorld, GameEngine.Instance.World.FourthAgeWorld, GameEngine.Instance.World.FifthAgeWorld, GameEngine.Instance.World.SeventhAgeWorld, GameEngine.Instance.LocalWorldData.EraWorld);
								if (requiredResourceTypeLevel <= 0)
								{
									flag2 = true;
								}
							}
						}
						if (flag2)
						{
							CustomTooltipManager.MouseEnterTooltipArea(150, buildingFromID.buildingType);
						}
						else
						{
							CustomTooltipManager.MouseEnterTooltipArea(151, buildingFromID.buildingType);
						}
						flag = true;
					}
				}
			}
			if (villageMapBuilding != null && num != villageMapBuilding.buildingID)
			{
				villageMapBuilding.goTransparent = false;
				Color white = global::ARGBColors.White;
				villageMapBuilding.baseSprite.ColorToUse = white;
				if (villageMapBuilding.animSprite != null)
				{
					villageMapBuilding.animSprite.ColorToUse = white;
				}
				if (villageMapBuilding.extraAnimSprite1 != null)
				{
					villageMapBuilding.extraAnimSprite1.ColorToUse = white;
				}
				if (villageMapBuilding.extraAnimSprite2 != null)
				{
					villageMapBuilding.extraAnimSprite2.ColorToUse = white;
				}
			}
			if (flag)
			{
				this.tooltipWasVisble = true;
				return;
			}
			if (this.tooltipWasVisble)
			{
				CustomTooltipManager.MouseLeaveTooltipArea();
			}
		}

		// Token: 0x06002DDE RID: 11742 RVA: 0x00246738 File Offset: 0x00244938
		public int getMaxBuildingQueueLength()
		{
			if (GameEngine.Instance.World.isCapital(this.m_villageID))
			{
				return GameEngine.Instance.LocalWorldData.capitalBuildingQueueMaxLength;
			}
			if (GameEngine.Instance.World.isAccountPremium())
			{
				return GameEngine.Instance.LocalWorldData.buildingQueueMaxLength;
			}
			return 1;
		}

		// Token: 0x06002DDF RID: 11743 RVA: 0x00246790 File Offset: 0x00244990
		public bool isMouseOverPlacementSprite(Point mousePos)
		{
			if ((VillageMap.isMovingBuilding() || this.isPlacingBuilding()) && this.backgroundSprite != null)
			{
				Point point = this.Camera.ScreenSpaceToMapTile(mousePos);
				int num = 8;
				int num2 = Math.Abs(point.X - this.lastPlaceBuildingLoc.X);
				int num3 = Math.Abs(point.Y - this.lastPlaceBuildingLoc.Y);
				if (num2 < num && num3 < num)
				{
					UniversalDebugLog.Log("clicked on placement building");
					return true;
				}
			}
			return false;
		}

		// Token: 0x06002DE0 RID: 11744 RVA: 0x0024680C File Offset: 0x00244A0C
		private Point getBuildingSpritePos(Point mapTile)
		{
			Point result = this.Camera.MapTileToWorldSpace(mapTile);
			result.X += 16;
			result.Y += 16;
			return result;
		}

		// Token: 0x06002DE1 RID: 11745 RVA: 0x00246848 File Offset: 0x00244A48
		public bool movePlacementBuildingToTile(Point mapTile)
		{
			bool flag = false;
			this.placementError = 0;
			if (VillageMap.placementSprite != null && this.backgroundSprite != null)
			{
				this.lastPlaceBuildingLoc = mapTile;
				if (mapTile.X >= 0 && mapTile.X < this.layout.gridWidth && mapTile.Y >= 0 && mapTile.Y < this.layout.gridHeight)
				{
					Point buildingSpritePos = this.getBuildingSpritePos(mapTile);
					VillageMap.placementSprite.PosX = (float)buildingSpritePos.X;
					VillageMap.placementSprite.PosY = (float)buildingSpritePos.Y;
					VillageLayoutNew villageLayoutNew = null;
					if (VillageMap.placingAsFree)
					{
						villageLayoutNew = this.buildMoveBuildingLayout();
					}
					if (villageLayoutNew == null)
					{
						villageLayoutNew = this.layout;
					}
					int[] buildingLayout = VillageBuildingsData.getBuildingLayout(VillageMap.s_villageBuildingData[VillageMap.placementType].size);
					ErrorCodes.ErrorCode errorCode = VillageLayoutNew.checkBuildingAgainstLandscape(villageLayoutNew.mapData, buildingLayout, mapTile, VillageMap.placementType, this.layout.gridWidth, this.layout.gridHeight);
					if (errorCode != ErrorCodes.ErrorCode.OK)
					{
						flag = true;
						this.placementError = 1;
						if (VillageLayoutNew.checkBuildingAgainstOtherBuildings(villageLayoutNew.mapData, buildingLayout, mapTile, VillageMap.placementType) == ErrorCodes.ErrorCode.OK)
						{
							if (VillageMap.placementType == 6 || VillageMap.placementType == 21)
							{
								this.placementError = 7;
							}
							else if (VillageMap.placementType == 7)
							{
								this.placementError = 8;
							}
							else if (VillageMap.placementType == 8 || VillageMap.placementType == 26)
							{
								this.placementError = 9;
							}
							else if (VillageMap.placementType == 9)
							{
								this.placementError = 10;
							}
							else if (VillageMap.placementType == 18)
							{
								this.placementError = 11;
							}
							else if (VillageMap.placementType == 23)
							{
								this.placementError = 12;
							}
							else if (VillageMap.placementType == 25 || VillageMap.placementType == 24)
							{
								this.placementError = 13;
							}
						}
					}
					else if (VillageLayoutNew.checkBuildingAgainstOtherBuildings(villageLayoutNew.mapData, buildingLayout, mapTile, VillageMap.placementType) != ErrorCodes.ErrorCode.OK)
					{
						flag = true;
						this.placementError = 1;
					}
					if (!VillageMap.placingAsFree && !this.genericBuildingValidation(mapTile, VillageMap.placementType))
					{
						flag = true;
						this.placementError = 2;
					}
				}
				else
				{
					flag = true;
				}
				if (!flag)
				{
					if (!VillageMap.placingAsFree)
					{
						int maxBuildingQueueLength = this.getMaxBuildingQueueLength();
						int num = this.countNumBuildingsConstructing();
						if (num >= maxBuildingQueueLength)
						{
							flag = true;
							this.placementError = 3;
							VillageMap.placementSprite.ColorToUse = global::ARGBColors.White;
						}
						else
						{
							int num2 = 0;
							int num3 = 0;
							int num4 = 0;
							int num5 = 0;
							int num6 = 0;
							int num7 = -1;
							if (!CardTypes.isFreeBuildingPlacement(GameEngine.Instance.cardsManager.UserCardData, VillageMap.placementType, ref num7))
							{
								VillageBuildingsData.calcBuildingCosts(GameEngine.Instance.LocalWorldData, VillageMap.placementType, this.countBuildingType(VillageMap.placementType), ref num2, ref num3, ref num4, ref num5, (int)GameEngine.Instance.World.UserResearchData.Research_Tools, ref num6);
							}
							if (num6 > 0 && GameEngine.Instance.LocalWorldData.constrFlagCost[VillageMap.placementType] > 0 && this.m_capitalBuildingsBuilt != null && this.m_capitalBuildingsBuilt.Contains(VillageMap.placementType))
							{
								num6 = 0;
							}
							VillageMap.StockpileLevels stockpileLevels = new VillageMap.StockpileLevels();
							this.getStockpileLevels(stockpileLevels);
							double num8 = GameEngine.Instance.World.isCapital(this.m_villageID) ? this.m_capitalGold : GameEngine.Instance.World.getCurrentGold();
							if ((num2 > 0 && (double)num2 > stockpileLevels.woodLevel) || (num3 > 0 && (double)num3 > stockpileLevels.stoneLevel) || (num5 > 0 && (double)num5 > num8) || (num6 > 0 && num6 > this.m_numParishFlags))
							{
								flag = true;
								if (num5 > 0 && (double)num5 > num8)
								{
									this.placementError = 4;
								}
								else if (num6 > 0 && num6 > this.m_numParishFlags)
								{
									this.placementError = 5;
								}
								else
								{
									this.placementError = 6;
								}
								VillageMap.placementSprite.ColorToUse = Color.FromArgb(128, 255, 255, 0);
							}
							else
							{
								VillageMap.placementSprite.ColorToUse = global::ARGBColors.White;
							}
						}
					}
					else
					{
						VillageMap.placementSprite.ColorToUse = global::ARGBColors.White;
					}
				}
				else
				{
					VillageMap.placementSprite.ColorToUse = Color.FromArgb(128, 255, 0, 0);
				}
				VillageMap.placementSprite.Visible = !this.m_leftMouseGrabbed;
			}
			return !flag;
		}

		// Token: 0x06002DE2 RID: 11746 RVA: 0x00246C70 File Offset: 0x00244E70
		public bool canAffordBuilding(int building_id)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			int num6 = -1;
			if (!CardTypes.isFreeBuildingPlacement(GameEngine.Instance.cardsManager.UserCardData, building_id, ref num6))
			{
				VillageBuildingsData.calcBuildingCosts(GameEngine.Instance.LocalWorldData, building_id, this.countBuildingType(building_id), ref num, ref num2, ref num3, ref num4, (int)GameEngine.Instance.World.UserResearchData.Research_Tools, ref num5);
			}
			if (num5 > 0 && GameEngine.Instance.LocalWorldData.constrFlagCost[building_id] > 0 && this.m_capitalBuildingsBuilt != null && this.m_capitalBuildingsBuilt.Contains(building_id))
			{
				num5 = 0;
			}
			VillageMap.StockpileLevels stockpileLevels = new VillageMap.StockpileLevels();
			this.getStockpileLevels(stockpileLevels);
			double num7 = GameEngine.Instance.World.isCapital(this.m_villageID) ? this.m_capitalGold : GameEngine.Instance.World.getCurrentGold();
			return (num <= 0 || (double)num <= stockpileLevels.woodLevel) && (num2 <= 0 || (double)num2 <= stockpileLevels.stoneLevel) && (num4 <= 0 || (double)num4 <= num7) && (num5 <= 0 || num5 <= this.m_numParishFlags);
		}

		// Token: 0x06002DE3 RID: 11747 RVA: 0x00246D90 File Offset: 0x00244F90
		public bool movePlacementBuildingToScreenPos(Point mousePos)
		{
			Point worldPos = this.Camera.ScreenToWorldSpace(mousePos);
			Point mapTile = this.Camera.WorldSpaceToMapTile(worldPos);
			return this.movePlacementBuildingToTile(mapTile);
		}

		// Token: 0x06002DE4 RID: 11748 RVA: 0x00246DC0 File Offset: 0x00244FC0
		public bool isNearPlacementBuilding(Point villagepos)
		{
			int num = 5;
			return Math.Abs(this.lastPlaceBuildingLoc.X - villagepos.X) <= num && Math.Abs(this.lastPlaceBuildingLoc.Y - villagepos.Y) <= num;
		}

		// Token: 0x06002DE5 RID: 11749 RVA: 0x00246E0C File Offset: 0x0024500C
		public void stopPlaceBuilding(bool closeInterface)
		{
			if (VillageMap.placementSprite != null)
			{
				InterfaceMgr.Instance.toggleDXCardBarActive(true);
				if (VillageMap.placementSprite_subSprite != null)
				{
					VillageMap.placementSprite.RemoveChild(VillageMap.placementSprite_subSprite);
					VillageMap.placementSprite_subSprite = null;
				}
				if (this.backgroundSprite != null)
				{
					this.backgroundSprite.RemoveChild(VillageMap.placementSprite);
				}
				VillageMap.placementSprite = null;
			}
			if (closeInterface)
			{
				InterfaceMgr.Instance.clearVillageBuildingInfo();
			}
			this.clearColouredBuildings();
			if (closeInterface)
			{
				InterfaceMgr.Instance.showInBuildingInfo(null);
			}
			VillageMap.placingAsFree = false;
			if (closeInterface && VillageMap.m_movingBuilding != null)
			{
				if (VillageMap.m_movingBuilding.shadowSprite != null)
				{
					VillageMap.m_movingBuilding.shadowSprite.Visible = true;
				}
				else if (VillageMap.m_movingBuilding.baseSprite != null)
				{
					VillageMap.m_movingBuilding.baseSprite.Visible = false;
				}
				VillageMap.m_movingBuilding = null;
			}
			this.placementError = 0;
		}

		// Token: 0x06002DE6 RID: 11750 RVA: 0x00246EE0 File Offset: 0x002450E0
		public void placeBuilding(Point mousePos)
		{
			if (this.movePlacementBuildingToScreenPos(mousePos))
			{
				Point point = this.Camera.ScreenSpaceToMapTile(mousePos);
				if (VillageMap.m_movingBuilding != null)
				{
					GameEngine.Instance.playInterfaceSound("VillageMap_move_building");
					RemoteServices.Instance.set_MoveVillageBuilding_UserCallBack(new RemoteServices.MoveVillageBuilding_UserCallBack(this.movePlacedCallback));
					RemoteServices.Instance.MoveVillageBuilding(this.m_villageID, VillageMap.m_movingBuilding.buildingID, point);
					ControlForm controlForm = DX.ControlForm;
					if (controlForm != null)
					{
						controlForm.GetService<VillagelayoutService>().MoveBuilding(this.VillageID, VillageMap.m_movingBuilding, point);
					}
					VillageMap.m_movingBuilding.buildingLocation = point;
					Point buildingSpritePos = this.getBuildingSpritePos(VillageMap.m_movingBuilding.buildingLocation);
					if (VillageMap.m_movingBuilding.shadowSprite != null)
					{
						VillageMap.m_movingBuilding.shadowSprite.PosX = (float)buildingSpritePos.X;
						VillageMap.m_movingBuilding.shadowSprite.PosY = (float)buildingSpritePos.Y;
					}
					else
					{
						VillageMap.m_movingBuilding.baseSprite.PosX = (float)buildingSpritePos.X;
						VillageMap.m_movingBuilding.baseSprite.PosY = (float)buildingSpritePos.Y;
					}
					this.stopPlaceBuilding(true);
					return;
				}
				if ((DateTime.Now - this.lastBuildingPlacement).TotalSeconds >= 45.0 || !this.inPlaceBuilding)
				{
					GameEngine.Instance.playInterfaceSound("VillageMap_place_building");
					this.lastBuildingPlacement = DateTime.Now;
					this.inPlaceBuilding = true;
					RemoteServices.Instance.set_PlaceVillageBuilding_UserCallBack(new RemoteServices.PlaceVillageBuilding_UserCallBack(this.buildingPlacedCallback));
					RemoteServices.Instance.PlaceVillageBuilding(this.m_villageID, VillageMap.placementType, point);
					Sound.playInterfaceSound(10001);
					VillageMapBuilding villageMapBuilding = new VillageMapBuilding();
					villageMapBuilding.buildingLocation = point;
					villageMapBuilding.buildingType = VillageMap.placementType;
					villageMapBuilding.buildingID = -1L;
					villageMapBuilding.complete = false;
					villageMapBuilding.completionTime = DateTime.Now.AddDays(1000.0);
					this.addBuildingToMap(villageMapBuilding, point, VillageMap.placementType);
					villageMapBuilding.updateConstructionGFX(VillageMap.localBaseTime, VillageMap.baseServerTime, true, this);
					this.startPlaceBuilding_ShowPanel(VillageMap.placementType, "", false);
					if (VillageMap.placementType == 2 || VillageMap.placementType >= 79)
					{
						InterfaceMgr.Instance.villageReshowAfterStockpilePlaced();
						return;
					}
				}
			}
			else
			{
				Point point2 = this.Camera.ScreenSpaceToMapTile(mousePos);
				VillagelayoutService service = DX.ControlForm.GetService<VillagelayoutService>();
				if (GameEngine.Instance.World.isCapital(this.m_villageID) || !service.BuildingsData.ContainsKey(this.m_villageID) || !this.allowedErrors.Contains(this.placementError))
				{
					return;
				}
				if (service.IsBuildingPresent(this.m_villageID, VillageMap.placementType, point2.X, point2.Y))
				{
					service.LLog(LNG.Print("Building already exists."), false);
					return;
				}
				List<int[]> list = service.BuildingsData[this.m_villageID];
				int[] buildingData = new int[]
				{
					VillageMap.placementType,
					point2.X,
					point2.Y,
					-1
				};
				list.Add(buildingData);
				if (this.m_villageID == service.SelectedLayout)
				{
					DX.ControlForm.dataGridViewVillageLayoutsEdit.Rows.Add(new object[]
					{
						buildingData[0],
						VillageBuildingsData.getBuildingName(VillageMap.placementType),
						list.Count((int[] b) => b[0] == buildingData[0]),
						service.GetErrorMessage(buildingData[3]),
						buildingData[1],
						buildingData[2]
					});
				}
				UniversalDebugLog.Log("placement failed");
			}
		}

		// Token: 0x06002DE7 RID: 11751 RVA: 0x002472A4 File Offset: 0x002454A4
		public void placeBuildingWhereItIs()
		{
			if (VillageMap.placementSprite != null)
			{
				Point mousePos = new Point((int)VillageMap.placementSprite.DrawPos.X - 16, (int)VillageMap.placementSprite.DrawPos.Y - 16);
				this.placeBuilding(mousePos);
			}
		}

		// Token: 0x06002DE8 RID: 11752 RVA: 0x002472F4 File Offset: 0x002454F4
		public bool genericBuildingValidation(Point location, int buildingType)
		{
			int num = this.countBuildingType(buildingType);
			int capitalType = GameEngine.Instance.World.getCapitalType(this.m_villageID);
			return num < GameEngine.Instance.LocalWorldData.getConstrMaxCount(buildingType, capitalType);
		}

		// Token: 0x06002DE9 RID: 11753 RVA: 0x00247338 File Offset: 0x00245538
		public void buildingPlacedCallback(PlaceVillageBuilding_ReturnType returnData)
		{
			this.inPlaceBuilding = false;
			VillageMap village = GameEngine.Instance.getVillage(returnData.villageID);
			if (village == null)
			{
				return;
			}
			if (returnData.Success)
			{
				village.removeBuildingFromMap(returnData.buildingLocation, returnData.buildingType, -1L);
				VillageMapBuilding villageMapBuilding = new VillageMapBuilding();
				villageMapBuilding.createFromReturnData(returnData.villageBuilding);
				village.addBuildingToMap(villageMapBuilding, returnData.buildingLocation, returnData.buildingType);
				villageMapBuilding.initStorageBuilding(this.gfx, this);
				VillageMap.setServerTime(returnData.currentTime);
				villageMapBuilding.updateConstructionGFX(VillageMap.localBaseTime, VillageMap.baseServerTime, true, this);
				villageMapBuilding.updateSymbolGFX();
				village.importResourcesAndStats(returnData.villageResourcesAndStats, returnData.currentTime);
				GameEngine.Instance.World.setGoldData(returnData.currentGoldLevel, returnData.currentGoldRate);
				GameEngine.Instance.World.setPoints(returnData.currentPoints);
				if (returnData.m_cardData != null)
				{
					GameEngine.Instance.cardsManager.UserCardData = returnData.m_cardData;
				}
				InterfaceMgr.Instance.updateSidepanelAfterBuildingPlaced();
				ControlForm controlForm = DX.ControlForm;
				if (controlForm != null)
				{
					controlForm.GetService<VillagelayoutService>().AddBuilding(this.VillageID, villageMapBuilding, default(Point));
				}
			}
			else
			{
				ControlForm controlForm2 = DX.ControlForm;
				if (controlForm2 != null)
				{
					controlForm2.Log(string.Concat(new string[]
					{
						ErrorCodes.getErrorString(returnData.m_errorCode, returnData.m_errorID),
						". Source Village ",
						GameEngine.Instance.World.getVillageName(returnData.villageID),
						" Building Type ",
						VillageBuildingsData.getBuildingName(returnData.buildingType),
						" "
					}), ControlForm.Tab.VillageLayouts, true);
				}
				village.removeBuildingFromMap(returnData.buildingLocation, returnData.buildingType, -1L);
				ErrorCodes.ErrorCode errorCode = returnData.m_errorCode;
				if (errorCode == ErrorCodes.ErrorCode.VILLAGE_BUILDINGS_NO_LONGER_OWNER)
				{
					GameEngine.Instance.displayedVillageLost(this.m_villageID, true);
				}
			}
			village.startPlaceBuilding_ShowPanel(returnData.buildingType, "", false);
		}

		// Token: 0x06002DEA RID: 11754 RVA: 0x00247530 File Offset: 0x00245730
		public void movePlacedCallback(MoveVillageBuilding_ReturnType returnData)
		{
			if (returnData.Success)
			{
				VillageMap village = GameEngine.Instance.getVillage(returnData.villageID);
				if (village != null)
				{
					village.importVillageBuildings(returnData.villageBuildings, true);
					village.importResourcesAndStats(returnData.villageResourcesAndStats, returnData.currentTime);
					VillageMap.setServerTime(returnData.currentTime);
					village.reAddBuildingsToMap();
				}
			}
		}

		// Token: 0x06002DEB RID: 11755 RVA: 0x0024758C File Offset: 0x0024578C
		public void villageBuildingCompleteDataRetrievalCallback(VillageBuildingCompleteDataRetrieval_ReturnType returnData)
		{
			if (returnData.Success)
			{
				VillageMap village = GameEngine.Instance.getVillage(returnData.villageID);
				if (village != null)
				{
					int num = -1;
					foreach (VillageMapBuilding villageMapBuilding in village.Buildings)
					{
						if (villageMapBuilding.buildingID == returnData.buildingID)
						{
							VillageMap.setServerTime(returnData.currentTime);
							if (returnData.villageBuilding != null)
							{
								villageMapBuilding.createFromReturnData(returnData.villageBuilding);
								villageMapBuilding.initStorageBuilding(this.gfx, this);
								villageMapBuilding.updateConstructionGFX(VillageMap.localBaseTime, VillageMap.baseServerTime, true, this);
								villageMapBuilding.updateSymbolGFX();
							}
							num = villageMapBuilding.buildingType;
							break;
						}
					}
					village.importResourcesAndStats(returnData.villageResourcesAndStats, returnData.currentTime);
					GameEngine.Instance.World.setHonourData(returnData.currentHonourLevel, returnData.currentHonourRate);
					GameEngine.Instance.World.setFaithPointsData(returnData.currentFaithPointsLevel, returnData.currentFaithPointsRate);
					GameEngine.Instance.World.setPoints(returnData.currentPoints);
					if (returnData.cards != null)
					{
						GameEngine.Instance.cardsManager.UserCardData = returnData.cards;
					}
					if (returnData.traders != null)
					{
						village.importTraders(returnData.traders, returnData.currentTime);
					}
					if (num - 2 <= 2 || num == 35)
					{
						RemoteServices.Instance.GetVillageBuildingsList(this.m_villageID, false, false);
						return;
					}
				}
			}
			else
			{
				ControlForm controlForm = DX.ControlForm;
				if (controlForm != null)
				{
					controlForm.Log(ErrorCodes.getErrorString(returnData.m_errorCode, returnData.m_errorID) + ". Source Village " + GameEngine.Instance.World.getVillageName(returnData.villageID), ControlForm.Tab.VillageLayouts, true);
				}
				ErrorCodes.ErrorCode errorCode = returnData.m_errorCode;
				if (errorCode == ErrorCodes.ErrorCode.VILLAGE_BUILDINGS_NO_LONGER_OWNER)
				{
					GameEngine.Instance.displayedVillageLost(this.m_villageID, true);
				}
			}
		}

		// Token: 0x06002DEC RID: 11756 RVA: 0x00021A3C File Offset: 0x0001FC3C
		public bool isValidBuilding(VillageMapBuilding building)
		{
			return this.localBuildings.Contains(building);
		}

		// Token: 0x06002DED RID: 11757 RVA: 0x0024776C File Offset: 0x0024596C
		public int getNumDeleting()
		{
			int num = 0;
			foreach (VillageMapBuilding villageMapBuilding in this.localBuildings)
			{
				if (villageMapBuilding.serverDeleting)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06002DEE RID: 11758 RVA: 0x002477C8 File Offset: 0x002459C8
		public void deleteBuilding(VillageMapBuilding building)
		{
			if (building == null)
			{
				VillageMap.villageClickMask.mapDirty = true;
				return;
			}
			if (building.isDeleting() || building.buildingType == 0)
			{
				return;
			}
			GameEngine.Instance.playInterfaceSound("Villagemap_Delete_building");
			RemoteServices.Instance.set_DeleteVillageBuilding_UserCallBack(new RemoteServices.DeleteVillageBuilding_UserCallBack(this.deleteBuildingCallback));
			RemoteServices.Instance.DeleteVillageBuilding(this.m_villageID, building.buildingID);
			ControlForm controlForm = DX.ControlForm;
			if (controlForm != null)
			{
				controlForm.GetService<VillagelayoutService>().DeleteBuilding(this.VillageID, building, true);
			}
			if (GameEngine.Instance.World.isCapital(this.m_villageID))
			{
				building.Visible = false;
				return;
			}
			if (!building.isComplete())
			{
				double localTimeLapsed = (DXTimer.GetCurrentMilliseconds() - VillageMap.localBaseTime) / 1000.0;
				switch (building.buildingType)
				{
				case 6:
					this.m_woodLevel += (double)this.calcResourceLevel(building, localTimeLapsed);
					break;
				case 7:
					this.m_stoneLevel += (double)this.calcResourceLevel(building, localTimeLapsed);
					break;
				case 8:
					this.m_ironLevel += (double)this.calcResourceLevel(building, localTimeLapsed);
					break;
				}
				building.Visible = false;
			}
		}

		// Token: 0x06002DEF RID: 11759 RVA: 0x002478F8 File Offset: 0x00245AF8
		public void cancelDeleteBuilding(VillageMapBuilding building)
		{
			if (GameEngine.Instance.World.isCapital(this.m_villageID))
			{
				return;
			}
			if (building == null)
			{
				VillageMap.villageClickMask.mapDirty = true;
				return;
			}
			if (building.isDeleting())
			{
				RemoteServices.Instance.set_CancelDeleteVillageBuilding_UserCallBack(new RemoteServices.CancelDeleteVillageBuilding_UserCallBack(this.cancelDeleteBuildingCallback));
				RemoteServices.Instance.CancelDeleteVillageBuilding(this.m_villageID, building.buildingID);
				ControlForm controlForm = DX.ControlForm;
				if (controlForm != null)
				{
					controlForm.GetService<VillagelayoutService>().AddBuilding(this.VillageID, building, default(Point));
				}
				building.serverDeleting = false;
				building.baseSprite.ColorToUse = global::ARGBColors.White;
				building.baseSprite.clearText();
				building.baseSprite.clearSecondText();
				if (building.animSprite != null)
				{
					building.animSprite.ColorToUse = global::ARGBColors.White;
				}
			}
		}

		// Token: 0x06002DF0 RID: 11760 RVA: 0x002479D0 File Offset: 0x00245BD0
		public void deleteBuildingCallback(DeleteVillageBuilding_ReturnType returnData)
		{
			VillageMap village = GameEngine.Instance.getVillage(returnData.villageID);
			if (village == null)
			{
				return;
			}
			if (returnData.Success)
			{
				bool flag = false;
				if (returnData.villageBuildingsChanged != null)
				{
					foreach (VillageBuildingReturnData villageBuildingReturnData in returnData.villageBuildingsChanged)
					{
						if (villageBuildingReturnData.buildingID == returnData.buildingID)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					village.removeBuildingFromMap(Point.Empty, returnData.buildingType, returnData.buildingID);
				}
				village.importResourcesAndStats(returnData.villageResourcesAndStats, returnData.currentTime);
				if (returnData.villageBuildingsChanged != null)
				{
					village.importVillageBuildings(returnData.villageBuildingsChanged, false);
				}
				int buildingType = returnData.buildingType;
				if (buildingType - 2 <= 2 || buildingType == 35)
				{
					RemoteServices.Instance.GetVillageBuildingsList(this.m_villageID, false, false);
				}
				GameEngine.Instance.World.setGoldData(returnData.currentGoldLevel, returnData.currentGoldRate);
				GameEngine.Instance.World.setHonourData(returnData.currentHonourLevel, returnData.currentHonourRate);
				GameEngine.Instance.World.setFaithPointsData(returnData.currentFaithPointsLevel, returnData.currentFaithPointsRate);
				GameEngine.Instance.World.setPoints(returnData.currentPoints);
				return;
			}
			VillageMapBuilding villageMapBuilding = village.findBuilding(returnData.buildingID);
			if (villageMapBuilding != null)
			{
				villageMapBuilding.Visible = true;
			}
			ErrorCodes.ErrorCode errorCode = returnData.m_errorCode;
			if (errorCode == ErrorCodes.ErrorCode.VILLAGE_BUILDINGS_NO_LONGER_OWNER)
			{
				GameEngine.Instance.displayedVillageLost(this.m_villageID, true);
			}
		}

		// Token: 0x06002DF1 RID: 11761 RVA: 0x00247B60 File Offset: 0x00245D60
		public void cancelDeleteBuildingCallback(CancelDeleteVillageBuilding_ReturnType returnData)
		{
			if (!returnData.Success)
			{
				return;
			}
			VillageMap village = GameEngine.Instance.getVillage(returnData.villageID);
			if (village != null)
			{
				village.importResourcesAndStats(returnData.villageResourcesAndStats, returnData.currentTime);
				if (returnData.villageBuildingsChanged != null)
				{
					village.importVillageBuildings(returnData.villageBuildingsChanged, false);
				}
			}
			GameEngine.Instance.World.setGoldData(returnData.currentGoldLevel, returnData.currentGoldRate);
			GameEngine.Instance.World.setHonourData(returnData.currentHonourLevel, returnData.currentHonourRate);
			GameEngine.Instance.World.setPoints(returnData.currentPoints);
		}

		// Token: 0x06002DF2 RID: 11762 RVA: 0x00247BFC File Offset: 0x00245DFC
		public void startMoveBuildings(VillageMapBuilding building)
		{
			if (building != null && VillageMap.m_movingBuilding == null)
			{
				VillageMap.m_movingBuilding = building;
				this.startPlaceBuilding(building.buildingType, true);
				if (VillageMap.m_movingBuilding.shadowSprite != null)
				{
					VillageMap.m_movingBuilding.shadowSprite.Visible = false;
					return;
				}
				if (VillageMap.m_movingBuilding.baseSprite != null)
				{
					VillageMap.m_movingBuilding.baseSprite.Visible = false;
				}
			}
		}

		// Token: 0x06002DF3 RID: 11763 RVA: 0x00247C60 File Offset: 0x00245E60
		public VillageLayoutNew buildMoveBuildingLayout()
		{
			if (VillageMap.m_movingBuilding == null)
			{
				return null;
			}
			VillageLayoutNew villageLayoutNew = null;
			villageLayoutNew = VillageMap.villageLayout[this.m_mapID].createClone();
			foreach (VillageMapBuilding villageMapBuilding in this.localBuildings)
			{
				if (VillageMap.m_movingBuilding.buildingID != villageMapBuilding.buildingID)
				{
					int[] buildingLayout = VillageBuildingsData.getBuildingLayout(VillageMap.s_villageBuildingData[villageMapBuilding.buildingType].size);
					for (int i = 0; i < buildingLayout.Length / 2; i++)
					{
						int num = villageMapBuilding.buildingLocation.X + buildingLayout[i * 2];
						int num2 = villageMapBuilding.buildingLocation.Y + buildingLayout[i * 2 + 1];
						if (num >= 0 && num2 >= 0 && num < 64 && num2 < 128)
						{
							villageLayoutNew.mapData[num2][num] |= 16384;
						}
					}
				}
			}
			return villageLayoutNew;
		}

		// Token: 0x06002DF4 RID: 11764 RVA: 0x00247D6C File Offset: 0x00245F6C
		public void changeBuildngActivity(VillageMapBuilding building, int mode)
		{
			if (!this.inSendBuildingActivity || (DateTime.Now - this.inSendBuildingActivityLastTime).TotalSeconds >= 15.0)
			{
				this.inSendBuildingActivity = true;
				this.inSendBuildingActivityLastTime = DateTime.Now;
				switch (mode)
				{
				case 0:
					RemoteServices.Instance.set_VillageBuildingSetActive_UserCallBack(new RemoteServices.VillageBuildingSetActive_UserCallBack(this.buildingActiveCallback));
					RemoteServices.Instance.VillageBuildingTypeSetActive(this.m_villageID, building.buildingType, false);
					using (List<VillageMapBuilding>.Enumerator enumerator = this.localBuildings.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							VillageMapBuilding villageMapBuilding = enumerator.Current;
							if (villageMapBuilding.buildingType == building.buildingType)
							{
								villageMapBuilding.buildingActive = false;
							}
						}
						return;
					}
					break;
				case 1:
					break;
				case 2:
					goto IL_14A;
				case 3:
					RemoteServices.Instance.set_VillageBuildingSetActive_UserCallBack(new RemoteServices.VillageBuildingSetActive_UserCallBack(this.buildingActiveCallback));
					RemoteServices.Instance.VillageBuildingSetActive(this.m_villageID, building.buildingID, true);
					building.buildingActive = true;
					return;
				case 4:
					RemoteServices.Instance.set_VillageBuildingSetActive_UserCallBack(new RemoteServices.VillageBuildingSetActive_UserCallBack(this.buildingActiveCallback));
					RemoteServices.Instance.VillageAllBuildingsSetActive(this.m_villageID, false);
					using (List<VillageMapBuilding>.Enumerator enumerator2 = this.localBuildings.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							VillageMapBuilding villageMapBuilding2 = enumerator2.Current;
							if (villageMapBuilding2.buildingType == building.buildingType)
							{
								villageMapBuilding2.buildingActive = false;
							}
						}
						return;
					}
					goto IL_223;
				case 5:
					goto IL_223;
				default:
					return;
				}
				RemoteServices.Instance.set_VillageBuildingSetActive_UserCallBack(new RemoteServices.VillageBuildingSetActive_UserCallBack(this.buildingActiveCallback));
				RemoteServices.Instance.VillageBuildingTypeSetActive(this.m_villageID, building.buildingType, true);
				using (List<VillageMapBuilding>.Enumerator enumerator3 = this.localBuildings.GetEnumerator())
				{
					while (enumerator3.MoveNext())
					{
						VillageMapBuilding villageMapBuilding3 = enumerator3.Current;
						if (villageMapBuilding3.buildingType == building.buildingType)
						{
							villageMapBuilding3.buildingActive = true;
						}
					}
					return;
				}
				IL_14A:
				RemoteServices.Instance.set_VillageBuildingSetActive_UserCallBack(new RemoteServices.VillageBuildingSetActive_UserCallBack(this.buildingActiveCallback));
				RemoteServices.Instance.VillageBuildingSetActive(this.m_villageID, building.buildingID, false);
				building.buildingActive = false;
				return;
				IL_223:
				RemoteServices.Instance.set_VillageBuildingSetActive_UserCallBack(new RemoteServices.VillageBuildingSetActive_UserCallBack(this.buildingActiveCallback));
				RemoteServices.Instance.VillageAllBuildingsSetActive(this.m_villageID, true);
				foreach (VillageMapBuilding villageMapBuilding4 in this.localBuildings)
				{
					if (villageMapBuilding4.buildingType == building.buildingType)
					{
						villageMapBuilding4.buildingActive = true;
					}
				}
			}
		}

		// Token: 0x06002DF5 RID: 11765 RVA: 0x00248040 File Offset: 0x00246240
		public void buildingActiveCallback(VillageBuildingSetActive_ReturnType returnData)
		{
			this.inSendBuildingActivity = false;
			InterfaceMgr.Instance.stopIndustryEnabled();
			if (!returnData.Success)
			{
				return;
			}
			VillageMap village = GameEngine.Instance.getVillage(returnData.villageID);
			if (village != null)
			{
				village.importResourcesAndStats(returnData.villageResourcesAndStats, returnData.currentTime);
				if (returnData.villageBuildingsChanged != null)
				{
					village.importVillageBuildings(returnData.villageBuildingsChanged, false);
				}
			}
			VillageMap.setServerTime(returnData.currentTime);
		}

		// Token: 0x06002DF6 RID: 11766 RVA: 0x002480B0 File Offset: 0x002462B0
		public VillageMap(int mapID, int mapVariant, int mapType, int villageID, GraphicsMgr mgr)
		{
			this.m_villageID = villageID;
			this.m_mapID = mapID;
			this.m_mapVariant = mapVariant;
			this.m_villageMapType = mapType;
			this.layout = VillageMap.villageLayout[mapID].createClone();
			this.gfx = mgr;
			this.banqueting = new Banqueting(this);
			this.loadBackgroundImage();
			this.initGFX(mgr);
			this.tutorialStage_AppleFarm_Activated = false;
			this.tutorialStage_Wood_Activated = false;
			if (!GameEngine.Instance.World.TutorialIsAdvancing() && GameEngine.Instance.World.getTutorialStage() == 103)
			{
				GameEngine.Instance.World.checkQuestObjectiveComplete(14);
			}
		}

		// Token: 0x06002DF7 RID: 11767 RVA: 0x00248434 File Offset: 0x00246634
		public void resetMapType(int mapID, int mapVariant, int mapType)
		{
			if (mapID != this.m_mapID || this.m_mapVariant != mapVariant || mapType != this.m_villageMapType)
			{
				this.m_mapID = mapID;
				this.m_mapVariant = mapVariant;
				this.m_villageMapType = mapType;
				this.layout = VillageMap.villageLayout[mapID].createClone();
				this.loadBackgroundImage();
				this.initGFX(this.gfx);
			}
		}

		// Token: 0x06002DF8 RID: 11768 RVA: 0x00248498 File Offset: 0x00246698
		public void loadBackgroundImage()
		{
			string text = this.layout.layoutFilename;
			if (text == "vm_05_lowland1.vmp")
			{
				if (this.m_mapVariant == 1)
				{
					text = "vm_06_lowland2.vmp";
				}
				else if (this.m_mapVariant == 2)
				{
					text = "vm_07_lowland3.vmp";
				}
			}
			string a = "assets\\" + text + ".png";
			if (a != VillageMap.lastBackgroundImageName)
			{
				VillageMap.lastBackgroundImageName = a;
				VillageMap.backgroundTexture = this.gfx.loadTexture(Application.StartupPath + "\\assets\\" + text + ".png", VillageMap.backgroundTexture);
			}
			this.createSurroundSprites();
			this.randomiseSounds();
		}

		// Token: 0x06002DF9 RID: 11769 RVA: 0x00248538 File Offset: 0x00246738
		public void initGFX(GraphicsMgr mgr)
		{
			this.gfx = mgr;
			this.backgroundSprite = new SpriteWrapper();
			this.backgroundSprite.TextureID = VillageMap.backgroundTexture;
			this.backgroundSprite.Initialize(this.gfx);
			this.backgroundSprite.PosX = 0f;
			this.backgroundSprite.PosY = 0f;
			this.backgroundSprite.Scale = 1f;
			this.m_camera = new VillageCameraWinforms(this.backgroundSprite);
			int num = this.layout.gridWidth * 32;
			int num2 = this.layout.gridHeight * 16;
			Rectangle sourceRectangle = new Rectangle(0, 0, num, num2);
			this.backgroundSprite.SourceRectangle = sourceRectangle;
			SizeF size = new SizeF((float)num, (float)num2);
			this.backgroundSprite.Size = size;
			this.backgroundSprite.PosX = (float)((int)(0f - (this.backgroundSprite.Width - (float)this.gfx.ViewportWidth) / 2f));
			this.backgroundSprite.PosY = (float)((int)(0f - (this.backgroundSprite.Height - (float)this.gfx.ViewportHeight) / 2f));
			this.createSurroundSprites();
			this.backgroundOverlaySprite = new SpriteWrapper();
			this.backgroundOverlaySprite.TextureID = VillageMap.backgroundTexture;
			this.backgroundOverlaySprite.Initialize(this.gfx);
			this.backgroundOverlaySprite.PosX = 0f;
			this.backgroundOverlaySprite.PosY = 474f;
			this.backgroundOverlaySprite.Scale = 1f;
			Rectangle sourceRectangle2 = new Rectangle(0, 1201, num, 800);
			this.backgroundOverlaySprite.SourceRectangle = sourceRectangle2;
			SizeF size2 = new SizeF((float)num, 800f);
			this.backgroundOverlaySprite.Size = size2;
		}

		// Token: 0x06002DFA RID: 11770 RVA: 0x00021A4F File Offset: 0x0001FC4F
		public void reInitGFX(GraphicsMgr mgr)
		{
			if (this.backgroundSprite == null)
			{
				this.initGFX(mgr);
			}
			RemoteServices.Instance.set_VillageProduceWeapons_UserCallBack(new RemoteServices.VillageProduceWeapons_UserCallBack(this.produceWeaponsCallback));
			RemoteServices.Instance.set_VillageHoldBanquet_UserCallBack(new RemoteServices.VillageHoldBanquet_UserCallBack(this.holdBanquetCallback));
		}

		// Token: 0x06002DFB RID: 11771 RVA: 0x00248704 File Offset: 0x00246904
		public void dispose()
		{
			foreach (VillageMapBuilding building in this.localBuildings)
			{
				this.removeAnimals(building);
			}
			this.localBuildings.Clear();
			if (this.backgroundSprite != null)
			{
				this.backgroundSprite.RemoveAllChildren();
				this.backgroundSprite = null;
			}
			VillageMap.villageClickMask.clearMap();
		}

		// Token: 0x06002DFC RID: 11772 RVA: 0x00248788 File Offset: 0x00246988
		public void updateConstructionOnCachedLoad()
		{
			foreach (VillageMapBuilding villageMapBuilding in this.localBuildings)
			{
				villageMapBuilding.updateConstructionGFX(VillageMap.localBaseTime, VillageMap.baseServerTime, true, this);
				if (villageMapBuilding.complete)
				{
					villageMapBuilding.baseSprite.clearText();
					villageMapBuilding.baseSprite.clearSecondText();
					if (!villageMapBuilding.localComplete && !villageMapBuilding.completeRequestSent && !this.ViewOnly)
					{
						if (!GameEngine.Instance.World.isCapital(this.m_villageID))
						{
							RemoteServices.Instance.set_VillageBuildingCompleteDataRetrieval_UserCallBack(new RemoteServices.VillageBuildingCompleteDataRetrieval_UserCallBack(this.villageBuildingCompleteDataRetrievalCallback));
							RemoteServices.Instance.VillageBuildingCompleteDataRetrieval(this.m_villageID, villageMapBuilding.buildingID);
							villageMapBuilding.completeRequestSent = true;
						}
						else
						{
							villageMapBuilding.complete = true;
							villageMapBuilding.localComplete = true;
						}
					}
				}
			}
		}

		// Token: 0x06002DFD RID: 11773 RVA: 0x00248880 File Offset: 0x00246A80
		public void importVillageBuildings(List<VillageBuildingReturnData> newBuildings, bool fullUpdate)
		{
			if (fullUpdate)
			{
				List<long> list = new List<long>();
				foreach (VillageMapBuilding villageMapBuilding in this.localBuildings)
				{
					list.Add(villageMapBuilding.buildingID);
				}
				this.localBuildings.Clear();
				VillageMap.villageClickMask.clearMap();
				this.backgroundSprite.RemoveAllChildren();
				if (this.m_villageMapType == 10 || this.m_villageMapType == 11 || this.m_villageMapType == 12 || this.m_villageMapType == 13)
				{
					if (this.m_villageMapType == 13)
					{
						this.backgroundOverlaySprite.PosY = 434f;
					}
					else
					{
						this.backgroundOverlaySprite.PosY = 474f;
					}
					this.backgroundSprite.AddChild(this.backgroundOverlaySprite, 19);
				}
				this.layout = VillageMap.villageLayout[this.m_mapID].createClone();
				if (newBuildings != null)
				{
					foreach (VillageBuildingReturnData villageBuildingReturnData in newBuildings)
					{
						VillageMapBuilding villageMapBuilding2 = new VillageMapBuilding();
						villageMapBuilding2.createFromReturnData(villageBuildingReturnData);
						this.addBuildingToMap(villageMapBuilding2, villageBuildingReturnData.buildingLocation, villageBuildingReturnData.buildingType);
						villageMapBuilding2.initStorageBuilding(this.gfx, this);
						villageMapBuilding2.calcRate = villageBuildingReturnData.calcRate;
						villageMapBuilding2.lastCalcTime = villageBuildingReturnData.lastCalcTime;
						villageMapBuilding2.storageLocation = villageBuildingReturnData.storageLocation;
						villageMapBuilding2.serverJourneyTime = villageBuildingReturnData.journeyTime;
						villageMapBuilding2.updateConstructionGFX(VillageMap.localBaseTime, VillageMap.baseServerTime, true, this);
						villageMapBuilding2.updateSymbolGFX();
						list.Remove(villageMapBuilding2.buildingID);
					}
				}
				foreach (long buildingID in list)
				{
					this.removeAnimals(buildingID);
				}
				if (InterfaceMgr.Instance.getSelectedMenuVillage() == this.m_villageID)
				{
					this.updateBuildingsOnImport();
				}
			}
			else
			{
				foreach (VillageBuildingReturnData villageBuildingReturnData2 in newBuildings)
				{
					foreach (VillageMapBuilding villageMapBuilding3 in this.localBuildings)
					{
						if (villageMapBuilding3.buildingID == villageBuildingReturnData2.buildingID)
						{
							villageMapBuilding3.createFromReturnData(villageBuildingReturnData2);
							villageMapBuilding3.initStorageBuilding(this.gfx, this);
							villageMapBuilding3.updateConstructionGFX(VillageMap.localBaseTime, VillageMap.baseServerTime, true, this);
							villageMapBuilding3.updateSymbolGFX();
							break;
						}
					}
				}
			}
			this.preCountHonourBuildings();
		}

		// Token: 0x06002DFE RID: 11774 RVA: 0x00248B88 File Offset: 0x00246D88
		public void FixEmptyStockpileBug()
		{
			foreach (VillageMapBuilding villageMapBuilding in this.localBuildings)
			{
				if (villageMapBuilding.complete)
				{
					villageMapBuilding.localComplete = true;
				}
				else if (villageMapBuilding.buildingType == 2 || villageMapBuilding.buildingType == 3)
				{
					villageMapBuilding.complete = true;
					villageMapBuilding.localComplete = true;
				}
				villageMapBuilding.initStorageBuilding(this.gfx, this);
				villageMapBuilding.updateConstructionGFX(VillageMap.localBaseTime, VillageMap.baseServerTime, true, this);
				villageMapBuilding.updateSymbolGFX();
			}
		}

		// Token: 0x06002DFF RID: 11775 RVA: 0x00248C2C File Offset: 0x00246E2C
		public void reAddBuildingsToMap()
		{
			VillageMap.villageClickMask.clearMapAndBuildings();
			foreach (VillageMapBuilding newBuilding in this.localBuildings)
			{
				this.reAddBuildingToMap(newBuilding);
			}
		}

		// Token: 0x06002E00 RID: 11776 RVA: 0x00248C8C File Offset: 0x00246E8C
		private void reAddBuildingToMap(VillageMapBuilding newBuilding)
		{
			int num = newBuilding.buildingType;
			int num2 = 0;
			if (num != 0)
			{
				if (num == 1)
				{
					switch (GameEngine.Instance.World.UserResearchData.Research_HousingCapacity)
					{
					case 2:
					case 3:
						num = 39;
						break;
					case 4:
					case 5:
						num = 40;
						break;
					case 6:
						num = 76;
						break;
					case 7:
					case 8:
					case 9:
						num = 77;
						break;
					}
				}
			}
			else
			{
				int rank = GameEngine.Instance.World.getRank();
				num2 = ((rank >= 10) ? ((rank >= 15) ? ((rank >= 21) ? 6 : 6) : 3) : 0);
			}
			if (VillageMap.s_villageBuildingData[num].baseGfxTexID >= 0)
			{
				PointF center = default(PointF);
				center.X = (float)VillageMap.s_villageBuildingData[num].baseOffset.X;
				center.Y = (float)VillageMap.s_villageBuildingData[num].baseOffset.Y;
				VillageMap.villageClickMask.addBuilding(newBuilding.buildingID, newBuilding.buildingLocation.X * 32, newBuilding.buildingLocation.Y * 16 + 8, VillageMap.s_villageBuildingData[num].baseGfxTexID, VillageMap.s_villageBuildingData[num].baseGfxID + num2, center);
			}
		}

		// Token: 0x06002E01 RID: 11777 RVA: 0x00248DBC File Offset: 0x00246FBC
		private void addBuildingToMap(VillageMapBuilding newBuilding, Point location, int buildingType)
		{
			try
			{
				int num = 0;
				if (buildingType != 0)
				{
					if (buildingType == 1)
					{
						switch (GameEngine.Instance.World.UserResearchData.Research_HousingCapacity)
						{
						case 2:
						case 3:
							buildingType = 39;
							break;
						case 4:
						case 5:
							buildingType = 40;
							break;
						case 6:
							buildingType = 76;
							break;
						case 7:
						case 8:
						case 9:
							buildingType = 77;
							break;
						}
					}
				}
				else
				{
					int rank = GameEngine.Instance.World.getRank();
					num = ((rank >= 10) ? ((rank >= 15) ? ((rank >= 21) ? 6 : 6) : 3) : 0);
				}
				int[] buildingLayout = VillageBuildingsData.getBuildingLayout(VillageMap.s_villageBuildingData[buildingType].size);
				for (int i = 0; i < buildingLayout.Length / 2; i++)
				{
					int num2 = location.X + buildingLayout[i * 2];
					int num3 = location.Y + buildingLayout[i * 2 + 1];
					if (num2 >= 0 && num3 >= 0 && num2 < 64 && num3 < 128)
					{
						this.layout.mapData[num3][num2] |= 16384;
					}
				}
				if (VillageMap.s_villageBuildingData[buildingType].baseGfxTexID >= 0)
				{
					PointF center = default(PointF);
					center.X = (float)VillageMap.s_villageBuildingData[buildingType].baseOffset.X;
					center.Y = (float)VillageMap.s_villageBuildingData[buildingType].baseOffset.Y;
					if (VillageMap.s_villageBuildingData[buildingType].shadowGfxTexID >= 0)
					{
						newBuilding.shadowSprite = new SpriteWrapper();
						newBuilding.shadowSprite.TextureID = VillageMap.s_villageBuildingData[buildingType].shadowGfxTexID;
						newBuilding.shadowSprite.Initialize(this.gfx);
						newBuilding.shadowSprite.PosX = (float)(newBuilding.buildingLocation.X * 32);
						newBuilding.shadowSprite.PosY = (float)(newBuilding.buildingLocation.Y * 16 + 8);
						newBuilding.shadowSprite.SpriteNo = VillageMap.s_villageBuildingData[buildingType].shadowGfxID + num;
						newBuilding.shadowSprite.Center = center;
						this.addChildSprite(newBuilding.shadowSprite);
					}
					VillageMap.villageClickMask.addBuilding(newBuilding.buildingID, newBuilding.buildingLocation.X * 32, newBuilding.buildingLocation.Y * 16 + 8, VillageMap.s_villageBuildingData[buildingType].baseGfxTexID, VillageMap.s_villageBuildingData[buildingType].baseGfxID + num, center);
					newBuilding.baseSprite = new SpriteWrapper();
					newBuilding.baseSprite.TextureID = VillageMap.s_villageBuildingData[buildingType].baseGfxTexID;
					newBuilding.baseSprite.Initialize(this.gfx);
					newBuilding.baseSprite.SpriteNo = VillageMap.s_villageBuildingData[buildingType].baseGfxID + num;
					newBuilding.baseSprite.ForceDrawChildrenWithParent = true;
					newBuilding.baseSprite.Center = center;
					if (newBuilding.shadowSprite != null)
					{
						newBuilding.baseSprite.PosX = 0f;
						newBuilding.baseSprite.PosY = 0f;
						newBuilding.shadowSprite.AddChild(newBuilding.baseSprite, 5);
					}
					else
					{
						newBuilding.baseSprite.PosX = (float)(newBuilding.buildingLocation.X * 32);
						newBuilding.baseSprite.PosY = (float)(newBuilding.buildingLocation.Y * 16 + 8);
						this.addChildSprite(newBuilding.baseSprite, 6);
					}
					if (VillageMap.s_villageBuildingData[buildingType].animGfxTexID >= 0 && VillageMap.s_villageBuildingData[buildingType].hasAnim)
					{
						newBuilding.animSprite = new SpriteWrapper();
						newBuilding.animSprite.TextureID = VillageMap.s_villageBuildingData[buildingType].animGfxTexID;
						newBuilding.animSprite.Initialize(this.gfx);
						newBuilding.animSprite.PosX = 0f;
						newBuilding.animSprite.PosY = 0f;
						if (VillageMap.s_villageBuildingData[buildingType].animArray == null)
						{
							newBuilding.animSprite.initAnim(VillageMap.s_villageBuildingData[buildingType].animGfxID, VillageMap.s_villageBuildingData[buildingType].animCount, VillageMap.s_villageBuildingData[buildingType].animStride, VillageMap.s_villageBuildingData[buildingType].animRate);
						}
						else
						{
							newBuilding.animSprite.initAnim(VillageMap.s_villageBuildingData[buildingType].animGfxID, VillageMap.s_villageBuildingData[buildingType].animArray, VillageMap.s_villageBuildingData[buildingType].animRate);
						}
						newBuilding.animSprite.randomizeAnimStart();
						PointF center2 = default(PointF);
						center2.X = (float)VillageMap.s_villageBuildingData[buildingType].animOffset.X;
						center2.Y = (float)VillageMap.s_villageBuildingData[buildingType].animOffset.Y;
						newBuilding.animSprite.Center = center2;
						newBuilding.baseSprite.AddChild(newBuilding.animSprite);
						if (VillageMap.s_villageBuildingData[buildingType].animOnOpenOnly)
						{
							newBuilding.animSprite.Visible = false;
						}
					}
					newBuilding.symbolSprite = new SpriteWrapper();
					newBuilding.symbolSprite.TextureID = GFXLibrary.Instance.Bld_Various_01TexID;
					newBuilding.symbolSprite.Initialize(this.gfx);
					newBuilding.symbolSprite.Visible = false;
					newBuilding.symbolSprite.SpriteNo = 58;
					newBuilding.updateSymbolGFX();
					newBuilding.symbolSprite.PosX = 0f;
					int buildingYSize = VillageBuildingsData.getBuildingYSize(VillageMap.s_villageBuildingData[buildingType].size);
					int buildingXSize = VillageBuildingsData.getBuildingXSize(VillageMap.s_villageBuildingData[buildingType].size);
					if ((buildingXSize & 1) == 1)
					{
						newBuilding.symbolSprite.PosX = 16f;
					}
					if (buildingType == 14)
					{
						newBuilding.symbolSprite.PosX += 7f;
					}
					newBuilding.symbolSprite.PosY = (float)(-(float)(buildingYSize * 16));
					newBuilding.symbolSprite.ForceDrawChildrenWithParent = true;
					newBuilding.symbolSprite.AutoCentre = true;
					newBuilding.baseSprite.AddChild(newBuilding.symbolSprite);
				}
				newBuilding.productionSprite = new SpriteWrapper();
				newBuilding.productionSprite.TextureID = GFXLibrary.Instance.WorldMapIconsTexID;
				newBuilding.productionSprite.Initialize(this.gfx);
				newBuilding.productionSprite.SpriteNo = 95;
				newBuilding.productionSprite.PosX = 0f;
				newBuilding.productionSprite.PosY = -50f;
				newBuilding.productionSprite.Visible = false;
				newBuilding.productionSprite.ForceDrawChildrenWithParent = true;
				newBuilding.productionSprite.AutoCentre = true;
				if (newBuilding.baseSprite != null && newBuilding.productionSprite != null)
				{
					newBuilding.baseSprite.AddChild(newBuilding.productionSprite);
				}
				if (buildingType == 14)
				{
					this.createWindmill(newBuilding);
				}
				if (buildingType == 3)
				{
					this.CreateAnimals(newBuilding);
				}
				this.localBuildings.Add(newBuilding);
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06002E02 RID: 11778 RVA: 0x00249444 File Offset: 0x00247644
		private void removeBuildingFromMap(Point location, int buildingType, long buildingID)
		{
			VillageMap.villageClickMask.removeBuilding(buildingID);
			this.removeAnimals(buildingID);
			if (GameEngine.Instance.World.isCapital(this.m_villageID) && buildingID >= 0L)
			{
				foreach (VillageMapBuilding villageMapBuilding in this.localBuildings)
				{
					if (villageMapBuilding.buildingID == buildingID)
					{
						buildingType = villageMapBuilding.buildingType;
						break;
					}
				}
			}
			foreach (VillageMapBuilding villageMapBuilding2 in this.localBuildings)
			{
				if ((villageMapBuilding2.buildingLocation == location || (villageMapBuilding2.buildingID == buildingID && location == Point.Empty)) && villageMapBuilding2.buildingType == buildingType && (buildingID == -1L || villageMapBuilding2.buildingID == buildingID || villageMapBuilding2.buildingID == -1L))
				{
					int[] buildingLayout = VillageBuildingsData.getBuildingLayout(VillageMap.s_villageBuildingData[buildingType].size);
					if (location == Point.Empty)
					{
						location = villageMapBuilding2.buildingLocation;
					}
					for (int i = 0; i < buildingLayout.Length / 2; i++)
					{
						int num = location.X + buildingLayout[i * 2];
						int num2 = location.Y + buildingLayout[i * 2 + 1];
						if (num >= 0 && num2 >= 0 && num < 64 && num2 < 128)
						{
							this.layout.mapData[num2][num] &= -16385;
						}
					}
					if (villageMapBuilding2.shadowSprite != null)
					{
						villageMapBuilding2.shadowSprite.RemoveAllChildren();
						this.backgroundSprite.RemoveChild(villageMapBuilding2.shadowSprite);
						villageMapBuilding2.shadowSprite = null;
					}
					if (villageMapBuilding2.baseSprite != null)
					{
						this.backgroundSprite.RemoveChild(villageMapBuilding2.baseSprite);
						villageMapBuilding2.baseSprite = null;
					}
					if (villageMapBuilding2.animSprite != null)
					{
						this.backgroundSprite.RemoveChild(villageMapBuilding2.animSprite);
						villageMapBuilding2.animSprite = null;
					}
					if (villageMapBuilding2.extraAnimSprite1 != null)
					{
						this.backgroundSprite.RemoveChild(villageMapBuilding2.extraAnimSprite1);
						villageMapBuilding2.extraAnimSprite1 = null;
					}
					if (villageMapBuilding2.extraAnimSprite2 != null)
					{
						this.backgroundSprite.RemoveChild(villageMapBuilding2.extraAnimSprite2);
						villageMapBuilding2.extraAnimSprite2 = null;
					}
					if (villageMapBuilding2.worker != null)
					{
						villageMapBuilding2.worker.dispose();
						villageMapBuilding2.worker = null;
					}
					if (villageMapBuilding2.stockpileExtension != null)
					{
						villageMapBuilding2.stockpileExtension.dispose();
						villageMapBuilding2.stockpileExtension = null;
					}
					if (villageMapBuilding2.granaryExtension != null)
					{
						villageMapBuilding2.granaryExtension.dispose();
						villageMapBuilding2.granaryExtension = null;
					}
					this.localBuildings.Remove(villageMapBuilding2);
					break;
				}
			}
		}

		// Token: 0x06002E03 RID: 11779 RVA: 0x0024971C File Offset: 0x0024791C
		public void createWindmill(VillageMapBuilding newBuilding)
		{
			newBuilding.extraAnimSprite2 = new SpriteWrapper();
			newBuilding.extraAnimSprite2.TextureID = GFXLibrary.Instance.BakerAnimTexID;
			newBuilding.extraAnimSprite2.Initialize(this.gfx);
			newBuilding.extraAnimSprite2.PosX = 0f;
			newBuilding.extraAnimSprite2.PosY = 0f;
			newBuilding.extraAnimSprite2.initAnim(356, 15, 1, 75);
			PointF center = default(PointF);
			center.X = 74f;
			center.Y = 318f;
			newBuilding.extraAnimSprite2.Center = center;
			newBuilding.baseSprite.AddChild(newBuilding.extraAnimSprite2);
			newBuilding.extraAnimSprite1 = new SpriteWrapper();
			newBuilding.extraAnimSprite1.TextureID = GFXLibrary.Instance.BakerAnimTexID;
			newBuilding.extraAnimSprite1.Initialize(this.gfx);
			newBuilding.extraAnimSprite1.PosX = 0f;
			newBuilding.extraAnimSprite1.PosY = 0f;
			newBuilding.extraAnimSprite1.initAnim(341, 15, 1, 75);
			PointF center2 = default(PointF);
			center2.X = 86f;
			center2.Y = 349f;
			newBuilding.extraAnimSprite1.Center = center2;
			newBuilding.baseSprite.AddChild(newBuilding.extraAnimSprite1);
		}

		// Token: 0x06002E04 RID: 11780 RVA: 0x00249870 File Offset: 0x00247A70
		private void updateGFXState(VillageMapBuilding building)
		{
			int num = building.buildingType;
			if (num == 1)
			{
				switch (GameEngine.Instance.World.UserResearchData.Research_HousingCapacity)
				{
				case 2:
				case 3:
					num = 39;
					break;
				case 4:
				case 5:
					num = 40;
					break;
				case 6:
					num = 76;
					break;
				case 7:
				case 8:
				case 9:
					num = 77;
					break;
				}
			}
			building.lastOpenState = building.open;
			if (VillageMap.s_villageBuildingData[num].hasOpen)
			{
				if (building.open)
				{
					if (building.shadowSprite != null && VillageMap.s_villageBuildingData[num].shadowOpenGfxTexID != -1)
					{
						building.shadowSprite.reInitialize(VillageMap.s_villageBuildingData[num].shadowOpenGfxTexID, VillageMap.s_villageBuildingData[num].shadowOpenGfxID);
					}
					if (building.shadowSprite != null && VillageMap.s_villageBuildingData[num].baseOpenGfxTexID != -1)
					{
						building.baseSprite.reInitialize(VillageMap.s_villageBuildingData[num].baseOpenGfxTexID, VillageMap.s_villageBuildingData[num].baseOpenGfxID);
					}
					if (building.animSprite != null)
					{
						building.animSprite.Visible = true;
					}
					return;
				}
				if (building.shadowSprite != null)
				{
					building.shadowSprite.reInitialize(VillageMap.s_villageBuildingData[num].shadowGfxTexID, VillageMap.s_villageBuildingData[num].shadowGfxID);
				}
				if (building.shadowSprite != null)
				{
					building.baseSprite.reInitialize(VillageMap.s_villageBuildingData[num].baseGfxTexID, VillageMap.s_villageBuildingData[num].baseGfxID);
				}
				if (building.animSprite != null)
				{
					if (VillageMap.s_villageBuildingData[num].animOnOpenOnly)
					{
						building.animSprite.Visible = false;
						return;
					}
					building.animSprite.Visible = true;
					return;
				}
			}
			else if (building.open)
			{
				if (building.animSprite != null)
				{
					building.animSprite.Visible = true;
					return;
				}
			}
			else if (building.animSprite != null)
			{
				if (VillageMap.s_villageBuildingData[num].animOnOpenOnly)
				{
					building.animSprite.Visible = false;
					return;
				}
				building.animSprite.Visible = true;
			}
		}

		// Token: 0x06002E05 RID: 11781 RVA: 0x00249A5C File Offset: 0x00247C5C
		public void playEnvironmentalSounds()
		{
			if (this.m_villageMapType < 10 || this.m_villageMapType > 13)
			{
				Sound.playVillageEnvironmental(this.m_villageMapType);
				return;
			}
			if (this.localBuildings.Count < 4)
			{
				Sound.playVillageEnvironmental(14);
				return;
			}
			if (this.localBuildings.Count < 10)
			{
				Sound.playVillageEnvironmental(15);
				return;
			}
			Sound.playVillageEnvironmental(16);
		}

		// Token: 0x06002E06 RID: 11782 RVA: 0x00249AC0 File Offset: 0x00247CC0
		public void createSurroundSprites()
		{
			if (this.backgroundSprite == null)
			{
				return;
			}
			int viewportWidth = this.gfx.ViewportWidth;
			int viewportHeight = this.gfx.ViewportHeight;
			int num = (int)this.backgroundSprite.Width;
			int num2 = (int)this.backgroundSprite.Height;
			VillageMap.tutorialOverlaySprite.Initialize(this.gfx, GFXLibrary.Instance.TutorialIconNormalID, 0);
			VillageMap.tutorialOverlaySprite.Layer = 19;
			VillageMap.tutorialOverlaySprite.Center = new PointF(0f, 0f);
			VillageMap.tutorialOverlaySprite.PosX = 0f;
			VillageMap.tutorialOverlaySprite.PosY = (float)(viewportHeight - 64);
			VillageMap.tutorialOverlaySprite.Update();
			VillageMap.wikiHelpSprite.Initialize(this.gfx, GFXLibrary.Instance.WikiHelpIconNormal, 0);
			VillageMap.wikiHelpSprite.Layer = 19;
			VillageMap.wikiHelpSprite.Center = new PointF(0f, 0f);
			VillageMap.wikiHelpSprite.PosX = (float)(viewportWidth - 31);
			VillageMap.wikiHelpSprite.PosY = 0f;
			VillageMap.wikiHelpSprite.Scale = 0.66f;
			VillageMap.wikiHelpSprite.Update();
			int num3 = 17;
			VillageMap.surroundsprites.Clear();
			if (num < viewportWidth && num2 < viewportHeight)
			{
				int num4 = (viewportHeight - num2) / 2;
				for (int i = num4; i > 0; i -= 512)
				{
					for (int j = 0; j < viewportWidth; j += 512)
					{
						SpriteWrapper spriteWrapper = new SpriteWrapper();
						spriteWrapper.TextureID = GFXLibrary.Instance.ImageSurroundTexID3;
						spriteWrapper.Initialize(this.gfx);
						spriteWrapper.Layer = num3;
						spriteWrapper.PosX = (float)j;
						spriteWrapper.PosY = (float)(i - 512);
						spriteWrapper.Update();
						VillageMap.surroundsprites.Add(spriteWrapper);
					}
				}
				for (int k = (viewportHeight - num2) / 2 + num2; k < viewportHeight; k += 512)
				{
					for (int l = 0; l < viewportWidth; l += 512)
					{
						SpriteWrapper spriteWrapper2 = new SpriteWrapper();
						spriteWrapper2.TextureID = GFXLibrary.Instance.ImageSurroundTexID3;
						spriteWrapper2.Initialize(this.gfx);
						spriteWrapper2.Layer = num3;
						spriteWrapper2.PosX = (float)l;
						spriteWrapper2.PosY = (float)k;
						spriteWrapper2.Update();
						VillageMap.surroundsprites.Add(spriteWrapper2);
					}
				}
				int num5 = (viewportWidth - num) / 2;
				for (int m = num5; m > 0; m -= 512)
				{
					for (int n = 0; n < viewportHeight; n += 512)
					{
						SpriteWrapper spriteWrapper3 = new SpriteWrapper();
						spriteWrapper3.TextureID = GFXLibrary.Instance.ImageSurroundTexID3;
						spriteWrapper3.Initialize(this.gfx);
						spriteWrapper3.Layer = num3;
						spriteWrapper3.PosX = (float)(m - 512);
						spriteWrapper3.PosY = (float)n;
						spriteWrapper3.Update();
						VillageMap.surroundsprites.Add(spriteWrapper3);
					}
				}
				for (int num6 = (viewportWidth - num) / 2 + num; num6 < viewportWidth; num6 += 512)
				{
					for (int num7 = 0; num7 < viewportHeight; num7 += 512)
					{
						SpriteWrapper spriteWrapper4 = new SpriteWrapper();
						spriteWrapper4.TextureID = GFXLibrary.Instance.ImageSurroundTexID3;
						spriteWrapper4.Initialize(this.gfx);
						spriteWrapper4.Layer = num3;
						spriteWrapper4.PosX = (float)num6;
						spriteWrapper4.PosY = (float)num7;
						spriteWrapper4.Update();
						VillageMap.surroundsprites.Add(spriteWrapper4);
					}
				}
				SpriteWrapper spriteWrapper5 = new SpriteWrapper();
				spriteWrapper5.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
				spriteWrapper5.Initialize(this.gfx);
				spriteWrapper5.Layer = num3 + 1;
				spriteWrapper5.PosX = (float)(num5 - 3);
				spriteWrapper5.PosY = (float)(num4 - 3);
				spriteWrapper5.Size = new Size(3, num2 + 6);
				spriteWrapper5.Update();
				VillageMap.surroundsprites.Add(spriteWrapper5);
				SpriteWrapper spriteWrapper6 = new SpriteWrapper();
				spriteWrapper6.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
				spriteWrapper6.Initialize(this.gfx);
				spriteWrapper6.Layer = num3 + 1;
				spriteWrapper6.PosX = (float)(num5 + num);
				spriteWrapper6.PosY = (float)num4;
				spriteWrapper6.Size = new Size(3, num2);
				spriteWrapper6.Update();
				VillageMap.surroundsprites.Add(spriteWrapper6);
				SpriteWrapper spriteWrapper7 = new SpriteWrapper();
				spriteWrapper7.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
				spriteWrapper7.Initialize(this.gfx);
				spriteWrapper7.Layer = num3 + 1;
				spriteWrapper7.PosX = (float)(num5 + num);
				spriteWrapper7.PosY = (float)(num4 + 3);
				spriteWrapper7.Size = new Size(6, num2);
				spriteWrapper7.Update();
				VillageMap.surroundsprites.Add(spriteWrapper7);
				SpriteWrapper spriteWrapper8 = new SpriteWrapper();
				spriteWrapper8.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
				spriteWrapper8.Initialize(this.gfx);
				spriteWrapper8.Layer = num3 + 1;
				spriteWrapper8.PosX = (float)(num5 + num);
				spriteWrapper8.PosY = (float)(num4 + 6);
				spriteWrapper8.Size = new Size(9, num2);
				spriteWrapper8.Update();
				VillageMap.surroundsprites.Add(spriteWrapper8);
				SpriteWrapper spriteWrapper9 = new SpriteWrapper();
				spriteWrapper9.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
				spriteWrapper9.Initialize(this.gfx);
				spriteWrapper9.Layer = num3 + 1;
				spriteWrapper9.PosX = (float)(num5 + num);
				spriteWrapper9.PosY = (float)(num4 + 9);
				spriteWrapper9.Size = new Size(14, num2);
				spriteWrapper9.Update();
				VillageMap.surroundsprites.Add(spriteWrapper9);
				SpriteWrapper spriteWrapper10 = new SpriteWrapper();
				spriteWrapper10.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
				spriteWrapper10.Initialize(this.gfx);
				spriteWrapper10.Layer = num3 + 1;
				spriteWrapper10.PosY = (float)(num4 - 3);
				spriteWrapper10.PosX = (float)num5;
				spriteWrapper10.Size = new Size(num, 3);
				spriteWrapper10.Update();
				VillageMap.surroundsprites.Add(spriteWrapper10);
				SpriteWrapper spriteWrapper11 = new SpriteWrapper();
				spriteWrapper11.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
				spriteWrapper11.Initialize(this.gfx);
				spriteWrapper11.Layer = num3 + 1;
				spriteWrapper11.PosY = (float)(num4 + num2);
				spriteWrapper11.PosX = (float)num5;
				spriteWrapper11.Size = new Size(num, 3);
				spriteWrapper11.Update();
				VillageMap.surroundsprites.Add(spriteWrapper11);
				SpriteWrapper spriteWrapper12 = new SpriteWrapper();
				spriteWrapper12.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
				spriteWrapper12.Initialize(this.gfx);
				spriteWrapper12.Layer = num3 + 1;
				spriteWrapper12.PosY = (float)(num4 + num2);
				spriteWrapper12.PosX = (float)(num5 + 3);
				spriteWrapper12.Size = new Size(num, 6);
				spriteWrapper12.Update();
				VillageMap.surroundsprites.Add(spriteWrapper12);
				SpriteWrapper spriteWrapper13 = new SpriteWrapper();
				spriteWrapper13.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
				spriteWrapper13.Initialize(this.gfx);
				spriteWrapper13.Layer = num3 + 1;
				spriteWrapper13.PosY = (float)(num4 + num2);
				spriteWrapper13.PosX = (float)(num5 + 6);
				spriteWrapper13.Size = new Size(num, 9);
				spriteWrapper13.Update();
				VillageMap.surroundsprites.Add(spriteWrapper13);
				SpriteWrapper spriteWrapper14 = new SpriteWrapper();
				spriteWrapper14.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
				spriteWrapper14.Initialize(this.gfx);
				spriteWrapper14.Layer = num3 + 1;
				spriteWrapper14.PosY = (float)(num4 + num2);
				spriteWrapper14.PosX = (float)(num5 + 9);
				spriteWrapper14.Size = new Size(num, 14);
				spriteWrapper14.Update();
				VillageMap.surroundsprites.Add(spriteWrapper14);
				return;
			}
			if (num < viewportWidth)
			{
				int num8 = (viewportWidth - num) / 2;
				int num9 = num8;
				while (num8 > 0)
				{
					for (int num10 = 0; num10 < viewportHeight; num10 += 512)
					{
						SpriteWrapper spriteWrapper15 = new SpriteWrapper();
						spriteWrapper15.TextureID = GFXLibrary.Instance.ImageSurroundTexID3;
						spriteWrapper15.Initialize(this.gfx);
						spriteWrapper15.Layer = num3;
						spriteWrapper15.PosX = (float)(num8 - 512);
						spriteWrapper15.PosY = (float)num10;
						spriteWrapper15.Update();
						VillageMap.surroundsprites.Add(spriteWrapper15);
					}
					num8 -= 512;
				}
				SpriteWrapper spriteWrapper16 = new SpriteWrapper();
				spriteWrapper16.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
				spriteWrapper16.Initialize(this.gfx);
				spriteWrapper16.Layer = num3 + 1;
				spriteWrapper16.PosX = (float)(num9 - 3);
				spriteWrapper16.PosY = 0f;
				spriteWrapper16.Size = new Size(3, num2);
				spriteWrapper16.Update();
				VillageMap.surroundsprites.Add(spriteWrapper16);
				for (num8 = (viewportWidth - num) / 2 + num; num8 < viewportWidth; num8 += 512)
				{
					for (int num11 = 0; num11 < viewportHeight; num11 += 512)
					{
						SpriteWrapper spriteWrapper17 = new SpriteWrapper();
						spriteWrapper17.TextureID = GFXLibrary.Instance.ImageSurroundTexID3;
						spriteWrapper17.Initialize(this.gfx);
						spriteWrapper17.Layer = num3;
						spriteWrapper17.PosX = (float)num8;
						spriteWrapper17.PosY = (float)num11;
						spriteWrapper17.Update();
						VillageMap.surroundsprites.Add(spriteWrapper17);
					}
				}
				SpriteWrapper spriteWrapper18 = new SpriteWrapper();
				spriteWrapper18.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
				spriteWrapper18.Initialize(this.gfx);
				spriteWrapper18.Layer = num3 + 1;
				spriteWrapper18.PosX = (float)(num9 + num);
				spriteWrapper18.PosY = 0f;
				spriteWrapper18.Size = new Size(3, num2);
				spriteWrapper18.Update();
				VillageMap.surroundsprites.Add(spriteWrapper18);
				SpriteWrapper spriteWrapper19 = new SpriteWrapper();
				spriteWrapper19.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
				spriteWrapper19.Initialize(this.gfx);
				spriteWrapper19.Layer = num3 + 1;
				spriteWrapper19.PosX = (float)(num9 + num);
				spriteWrapper19.PosY = 0f;
				spriteWrapper19.Size = new Size(6, num2);
				spriteWrapper19.Update();
				VillageMap.surroundsprites.Add(spriteWrapper19);
				SpriteWrapper spriteWrapper20 = new SpriteWrapper();
				spriteWrapper20.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
				spriteWrapper20.Initialize(this.gfx);
				spriteWrapper20.Layer = num3 + 1;
				spriteWrapper20.PosX = (float)(num9 + num);
				spriteWrapper20.PosY = 0f;
				spriteWrapper20.Size = new Size(9, num2);
				spriteWrapper20.Update();
				VillageMap.surroundsprites.Add(spriteWrapper20);
				SpriteWrapper spriteWrapper21 = new SpriteWrapper();
				spriteWrapper21.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
				spriteWrapper21.Initialize(this.gfx);
				spriteWrapper21.Layer = num3 + 1;
				spriteWrapper21.PosX = (float)(num9 + num);
				spriteWrapper21.PosY = 0f;
				spriteWrapper21.Size = new Size(14, num2);
				spriteWrapper21.Update();
				VillageMap.surroundsprites.Add(spriteWrapper21);
				return;
			}
			if (num2 >= viewportHeight)
			{
				return;
			}
			int num12 = (viewportHeight - num2) / 2;
			int num13 = num12;
			while (num12 > 0)
			{
				for (int num14 = 0; num14 < viewportWidth; num14 += 512)
				{
					SpriteWrapper spriteWrapper22 = new SpriteWrapper();
					spriteWrapper22.TextureID = GFXLibrary.Instance.ImageSurroundTexID3;
					spriteWrapper22.Initialize(this.gfx);
					spriteWrapper22.Layer = num3;
					spriteWrapper22.PosX = (float)num14;
					spriteWrapper22.PosY = (float)(num12 - 512);
					spriteWrapper22.Update();
					VillageMap.surroundsprites.Add(spriteWrapper22);
				}
				num12 -= 512;
			}
			SpriteWrapper spriteWrapper23 = new SpriteWrapper();
			spriteWrapper23.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
			spriteWrapper23.Initialize(this.gfx);
			spriteWrapper23.Layer = num3 + 1;
			spriteWrapper23.PosY = (float)(num13 - 3);
			spriteWrapper23.PosX = 0f;
			spriteWrapper23.Size = new Size(num, 3);
			spriteWrapper23.Update();
			VillageMap.surroundsprites.Add(spriteWrapper23);
			for (num12 = (viewportHeight - num2) / 2 + num2; num12 < viewportHeight; num12 += 512)
			{
				for (int num15 = 0; num15 < viewportWidth; num15 += 512)
				{
					SpriteWrapper spriteWrapper24 = new SpriteWrapper();
					spriteWrapper24.TextureID = GFXLibrary.Instance.ImageSurroundTexID3;
					spriteWrapper24.Initialize(this.gfx);
					spriteWrapper24.Layer = num3;
					spriteWrapper24.PosX = (float)num15;
					spriteWrapper24.PosY = (float)num12;
					spriteWrapper24.Update();
					VillageMap.surroundsprites.Add(spriteWrapper24);
				}
			}
			SpriteWrapper spriteWrapper25 = new SpriteWrapper();
			spriteWrapper25.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
			spriteWrapper25.Initialize(this.gfx);
			spriteWrapper25.Layer = num3 + 1;
			spriteWrapper25.PosY = (float)(num13 + num2);
			spriteWrapper25.PosX = 0f;
			spriteWrapper25.Size = new Size(num, 3);
			spriteWrapper25.Update();
			VillageMap.surroundsprites.Add(spriteWrapper25);
			SpriteWrapper spriteWrapper26 = new SpriteWrapper();
			spriteWrapper26.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
			spriteWrapper26.Initialize(this.gfx);
			spriteWrapper26.Layer = num3 + 1;
			spriteWrapper26.PosY = (float)(num13 + num2);
			spriteWrapper26.PosX = 0f;
			spriteWrapper26.Size = new Size(num, 6);
			spriteWrapper26.Update();
			VillageMap.surroundsprites.Add(spriteWrapper26);
			SpriteWrapper spriteWrapper27 = new SpriteWrapper();
			spriteWrapper27.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
			spriteWrapper27.Initialize(this.gfx);
			spriteWrapper27.Layer = num3 + 1;
			spriteWrapper27.PosY = (float)(num13 + num2);
			spriteWrapper27.PosX = 0f;
			spriteWrapper27.Size = new Size(num, 9);
			spriteWrapper27.Update();
			VillageMap.surroundsprites.Add(spriteWrapper27);
			SpriteWrapper spriteWrapper28 = new SpriteWrapper();
			spriteWrapper28.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
			spriteWrapper28.Initialize(this.gfx);
			spriteWrapper28.Layer = num3 + 1;
			spriteWrapper28.PosY = (float)(num13 + num2);
			spriteWrapper28.PosX = 0f;
			spriteWrapper28.Size = new Size(num, 14);
			spriteWrapper28.Update();
			VillageMap.surroundsprites.Add(spriteWrapper28);
		}

		// Token: 0x06002E07 RID: 11783 RVA: 0x0024A8E8 File Offset: 0x00248AE8
		private void drawSurroundSprites()
		{
			foreach (SpriteWrapper spriteWrapper in VillageMap.surroundsprites)
			{
				spriteWrapper.AddToRenderList();
			}
		}

		// Token: 0x06002E08 RID: 11784 RVA: 0x00021A8C File Offset: 0x0001FC8C
		public void justDrawSprites()
		{
			if (this.backgroundSprite != null && InterfaceMgr.Instance.updateVillageReports())
			{
				this.backgroundSprite.Update();
				this.backgroundSprite.AddToRenderList();
				this.drawSurroundSprites();
			}
		}

		// Token: 0x06002E09 RID: 11785 RVA: 0x0024A93C File Offset: 0x00248B3C
		public void drawProductionArrow()
		{
			if (this.productionArrowProductionBuilding.X != -1)
			{
				Point point = this.Camera.MapTileToScreenSpace(this.productionArrowProductionBuilding);
				Point point2 = this.Camera.MapTileToScreenSpace(this.productionArrowTargetBuilding);
				PointF point3 = new PointF((float)(point2.X - point.X), (float)(point2.Y - point.Y));
				float num = (float)Math.Sqrt((double)(point3.X * point3.X + point3.Y * point3.Y)) / 15f;
				point3.X /= num;
				point3.Y /= num;
				point3.X /= 2f;
				point3.Y /= 2f;
				PointF pointF = this.gfx.rotatePoint(point3, -90);
				PointF pointF2 = this.gfx.rotatePoint(point3, 90);
				pointF.X += (float)point.X;
				pointF.Y += (float)point.Y;
				pointF2.X += (float)point.X;
				pointF2.Y += (float)point.Y;
				Color color = Color.FromArgb(192, 128, 255, 128);
				if (num > 50f)
				{
					color = Color.FromArgb(192, 255, 192, 0);
				}
				else if (num >= 15f)
				{
					int num2 = ((int)num - 15) * 128 / 35;
					color = Color.FromArgb(192, 128 + num2, 255 - num2 / 4, 128 - num2);
				}
				int alpha = 255;
				this.gfx.startPoly();
				this.gfx.addTriangle(Color.FromArgb(alpha, color), Color.FromArgb(alpha, color), color, pointF.X, pointF.Y, pointF2.X, pointF2.Y, (float)point2.X - point3.X * 5f, (float)point2.Y - point3.Y * 5f);
				this.gfx.drawBufferedPolygons();
			}
		}

		// Token: 0x06002E0A RID: 11786 RVA: 0x00021ABE File Offset: 0x0001FCBE
		public string getPlacementBuildingString()
		{
			if (VillageMap.placementSprite == null)
			{
				return "";
			}
			return VillageMap.placementSprite.getText();
		}

		// Token: 0x06002E0B RID: 11787 RVA: 0x0024AB8C File Offset: 0x00248D8C
		private void updatePlacementText()
		{
			if (VillageMap.placementSprite == null)
			{
				return;
			}
			VillageMap.placementSprite.changeText("");
			if (VillageMap.placementSprite_subSprite == null)
			{
				return;
			}
			switch (VillageMap.placementType)
			{
			case 1:
			case 39:
			case 40:
			case 76:
			case 77:
			{
				int num = ResearchData.researchHousingLevels[(int)GameEngine.Instance.World.userResearchData.Research_HousingCapacity];
				VillageMapBuilding villageMapBuilding = this.findBuildingType(0);
				if (villageMapBuilding != null)
				{
					int mapDistance = VillageBuildingsData.getMapDistance(villageMapBuilding.buildingLocation, this.lastPlaceBuildingLoc);
					num += VillageBuildingsData.getHousingCapacityBasedOnDistance(GameEngine.Instance.LocalWorldData, mapDistance);
					VillageMap.placementSprite.changeText(num.ToString());
					this.productionArrowProductionBuilding = this.lastPlaceBuildingLoc;
					this.productionArrowTargetBuilding = villageMapBuilding.buildingLocation;
					return;
				}
				break;
			}
			case 2:
			case 3:
			case 4:
			case 5:
			case 10:
			case 11:
			case 20:
			case 27:
			case 35:
			case 46:
			case 47:
			case 48:
			case 52:
			case 53:
				break;
			case 6:
			case 7:
			case 8:
			case 9:
			{
				VillageMapBuilding villageMapBuilding2 = this.findBuildingType(2);
				if (villageMapBuilding2 == null)
				{
					VillageMap.placementSprite.changeText(0.ToString());
					return;
				}
				double totalSeconds = VillageBuildingsData.calcTravelTimeTiled(GameEngine.Instance.LocalWorldData, villageMapBuilding2.buildingLocation, this.lastPlaceBuildingLoc).TotalSeconds;
				double num2 = VillageBuildingsData.calcProductionTime(GameEngine.Instance.LocalWorldData, GameEngine.Instance.World.userResearchData, VillageMap.placementType, totalSeconds, 0.0, 1, this.m_villageMapType, this.m_parishCapitalResearchData, GameEngine.Instance.cardsManager.UserCardData);
				double num3 = CardTypes.adjustPayloadSize(GameEngine.Instance.cardsManager.UserCardData, GameEngine.Instance.LocalWorldData.getPayloadSize(VillageMap.placementType), VillageMap.placementType);
				double num4 = 86400.0 / num2 * num3;
				VillageMap.placementSprite.changeText(((int)num4).ToString());
				this.productionArrowProductionBuilding = this.lastPlaceBuildingLoc;
				this.productionArrowTargetBuilding = villageMapBuilding2.buildingLocation;
				return;
			}
			case 12:
			{
				VillageMapBuilding villageMapBuilding3 = this.findBuildingTypeIncludingConstructing(35);
				if (villageMapBuilding3 == null)
				{
					VillageMap.placementSprite.changeText(0.ToString());
					return;
				}
				double totalSeconds2 = VillageBuildingsData.calcTravelTimeTiled(GameEngine.Instance.LocalWorldData, villageMapBuilding3.buildingLocation, this.lastPlaceBuildingLoc).TotalSeconds;
				double num5 = VillageBuildingsData.calcProductionTime(GameEngine.Instance.LocalWorldData, GameEngine.Instance.World.userResearchData, VillageMap.placementType, totalSeconds2, 0.0, 1, this.m_villageMapType, this.m_parishCapitalResearchData, GameEngine.Instance.cardsManager.UserCardData);
				double num6 = CardTypes.adjustPayloadSize(GameEngine.Instance.cardsManager.UserCardData, GameEngine.Instance.LocalWorldData.getPayloadSize(VillageMap.placementType), VillageMap.placementType);
				double num7 = 86400.0 / num5 * num6;
				this.productionArrowProductionBuilding = this.lastPlaceBuildingLoc;
				this.productionArrowTargetBuilding = villageMapBuilding3.buildingLocation;
				VillageMap.placementSprite.changeText(((int)num7).ToString());
				return;
			}
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			{
				VillageMapBuilding villageMapBuilding4 = this.findBuildingTypeIncludingConstructing(3);
				if (villageMapBuilding4 == null)
				{
					VillageMap.placementSprite.changeText(0.ToString());
					return;
				}
				double totalSeconds3 = VillageBuildingsData.calcTravelTimeTiled(GameEngine.Instance.LocalWorldData, villageMapBuilding4.buildingLocation, this.lastPlaceBuildingLoc).TotalSeconds;
				double num8 = VillageBuildingsData.calcProductionTime(GameEngine.Instance.LocalWorldData, GameEngine.Instance.World.userResearchData, VillageMap.placementType, totalSeconds3, 0.0, 1, this.m_villageMapType, this.m_parishCapitalResearchData, GameEngine.Instance.cardsManager.UserCardData);
				double num9 = CardTypes.adjustPayloadSize(GameEngine.Instance.cardsManager.UserCardData, GameEngine.Instance.LocalWorldData.getPayloadSize(VillageMap.placementType), VillageMap.placementType);
				double num10 = 86400.0 / num8 * num9;
				VillageMap.placementSprite.changeText(((int)num10).ToString());
				this.productionArrowProductionBuilding = this.lastPlaceBuildingLoc;
				this.productionArrowTargetBuilding = villageMapBuilding4.buildingLocation;
				return;
			}
			case 19:
			case 21:
			case 22:
			case 23:
			case 24:
			case 25:
			case 26:
			case 33:
			{
				VillageMapBuilding villageMapBuilding5 = this.findBuildingType(0);
				if (villageMapBuilding5 == null)
				{
					VillageMap.placementSprite.changeText(0.ToString());
					return;
				}
				double totalSeconds4 = VillageBuildingsData.calcTravelTimeTiled(GameEngine.Instance.LocalWorldData, villageMapBuilding5.buildingLocation, this.lastPlaceBuildingLoc).TotalSeconds;
				double num11 = VillageBuildingsData.calcProductionTime(GameEngine.Instance.LocalWorldData, GameEngine.Instance.World.userResearchData, VillageMap.placementType, totalSeconds4, 0.0, 1, this.m_villageMapType, this.m_parishCapitalResearchData, GameEngine.Instance.cardsManager.UserCardData);
				double num12 = CardTypes.adjustPayloadSize(GameEngine.Instance.cardsManager.UserCardData, GameEngine.Instance.LocalWorldData.getPayloadSize(VillageMap.placementType), VillageMap.placementType);
				double num13 = 86400.0 / num11 * num12;
				this.productionArrowProductionBuilding = this.lastPlaceBuildingLoc;
				this.productionArrowTargetBuilding = villageMapBuilding5.buildingLocation;
				VillageMap.placementSprite.changeText(((int)num13).ToString());
				return;
			}
			case 28:
			case 29:
			case 30:
			case 31:
			{
				VillageMapBuilding villageMapBuilding6 = this.findBuildingType(4);
				VillageMapBuilding villageMapBuilding7 = this.findBuildingType(2);
				if (villageMapBuilding6 == null || villageMapBuilding7 == null)
				{
					VillageMap.placementSprite.changeText(0.ToString());
					return;
				}
				double travelTime = VillageBuildingsData.calcTravelTimeTiled(GameEngine.Instance.LocalWorldData, villageMapBuilding6.buildingLocation, this.lastPlaceBuildingLoc).TotalSeconds + GameEngine.Instance.LocalWorldData.WeaponProductionOffScreenTime / 2.0;
				double totalSeconds5 = VillageBuildingsData.calcTravelTimeTiled(GameEngine.Instance.LocalWorldData, villageMapBuilding7.buildingLocation, this.lastPlaceBuildingLoc).TotalSeconds;
				int trips = 1;
				switch (VillageMap.placementType)
				{
				case 28:
					trips = GameEngine.Instance.LocalWorldData.pikesBaseProductionTrips;
					break;
				case 29:
					trips = GameEngine.Instance.LocalWorldData.bowsBaseProductionTrips;
					break;
				case 30:
					trips = GameEngine.Instance.LocalWorldData.swordsBaseProductionTrips;
					break;
				case 31:
					trips = GameEngine.Instance.LocalWorldData.armourBaseProductionTrips;
					break;
				case 32:
					trips = GameEngine.Instance.LocalWorldData.catapultsBaseProductionTrips;
					break;
				}
				trips = CardTypes.cards_adjustWeaponProductionTrips(GameEngine.Instance.cardsManager.UserCardData, trips, VillageMap.placementType);
				double num14 = VillageBuildingsData.calcProductionTime(GameEngine.Instance.LocalWorldData, GameEngine.Instance.World.userResearchData, VillageMap.placementType, totalSeconds5, travelTime, trips, this.m_villageMapType, this.m_parishCapitalResearchData, GameEngine.Instance.cardsManager.UserCardData);
				double num15 = 86400.0 / num14 * GameEngine.Instance.LocalWorldData.getPayloadSize(VillageMap.placementType);
				this.productionArrowProductionBuilding = this.lastPlaceBuildingLoc;
				this.productionArrowTargetBuilding = villageMapBuilding7.buildingLocation;
				this.productionArrowTarget2Building = villageMapBuilding6.buildingLocation;
				VillageMap.placementSprite.changeText(((int)num15).ToString());
				return;
			}
			case 32:
			{
				VillageMapBuilding villageMapBuilding8 = this.findBuildingType(4);
				VillageMapBuilding villageMapBuilding9 = this.findBuildingType(2);
				if (villageMapBuilding8 == null || villageMapBuilding9 == null)
				{
					VillageMap.placementSprite.changeText(0.ToString());
					return;
				}
				double travelTime2 = VillageBuildingsData.calcTravelTimeTiled(GameEngine.Instance.LocalWorldData, villageMapBuilding8.buildingLocation, this.lastPlaceBuildingLoc).TotalSeconds + GameEngine.Instance.LocalWorldData.WeaponProductionOffScreenTime / 2.0;
				double totalSeconds6 = VillageBuildingsData.calcTravelTimeTiled(GameEngine.Instance.LocalWorldData, villageMapBuilding9.buildingLocation, this.lastPlaceBuildingLoc).TotalSeconds;
				int trips2 = 1;
				switch (VillageMap.placementType)
				{
				case 28:
					trips2 = GameEngine.Instance.LocalWorldData.pikesBaseProductionTrips;
					break;
				case 29:
					trips2 = GameEngine.Instance.LocalWorldData.bowsBaseProductionTrips;
					break;
				case 30:
					trips2 = GameEngine.Instance.LocalWorldData.swordsBaseProductionTrips;
					break;
				case 31:
					trips2 = GameEngine.Instance.LocalWorldData.armourBaseProductionTrips;
					break;
				case 32:
					trips2 = GameEngine.Instance.LocalWorldData.catapultsBaseProductionTrips;
					break;
				}
				trips2 = CardTypes.cards_adjustWeaponProductionTrips(GameEngine.Instance.cardsManager.UserCardData, trips2, VillageMap.placementType);
				double num16 = VillageBuildingsData.calcProductionTime(GameEngine.Instance.LocalWorldData, GameEngine.Instance.World.userResearchData, VillageMap.placementType, totalSeconds6, travelTime2, trips2, this.m_villageMapType, this.m_parishCapitalResearchData, GameEngine.Instance.cardsManager.UserCardData);
				double num17 = 86400.0 / num16 * GameEngine.Instance.LocalWorldData.getPayloadSize(VillageMap.placementType);
				VillageMap.placementSprite.changeText(num17.ToString("0.#"));
				break;
			}
			case 34:
				VillageMap.placementSprite.changeText(GameEngine.Instance.LocalWorldData.FaithPoints_Chapel.ToString());
				return;
			case 36:
				VillageMap.placementSprite.changeText(GameEngine.Instance.LocalWorldData.FaithPoints_Church.ToString());
				return;
			case 37:
				VillageMap.placementSprite.changeText(GameEngine.Instance.LocalWorldData.FaithPoints_Cathedral.ToString());
				return;
			case 38:
			case 41:
			case 42:
			case 43:
			case 44:
			case 45:
			{
				VillageMapBuilding villageMapBuilding10 = this.findBuildingType(0);
				if (villageMapBuilding10 != null)
				{
					double num18 = VillageBuildingsData.calcHonourRateBasedOnDistance(GameEngine.Instance.LocalWorldData.HonourBuilding_SmallGarden, villageMapBuilding10.buildingLocation, this.lastPlaceBuildingLoc);
					if (GameEngine.Instance.World.ThirdAgeWorld)
					{
						num18 *= 4.0;
					}
					VillageMap.placementSprite.changeText(num18.ToString());
					this.productionArrowProductionBuilding = this.lastPlaceBuildingLoc;
					this.productionArrowTargetBuilding = villageMapBuilding10.buildingLocation;
					return;
				}
				break;
			}
			case 49:
			case 50:
			case 51:
			{
				VillageMapBuilding villageMapBuilding11 = this.findBuildingType(0);
				if (villageMapBuilding11 != null)
				{
					double num19 = VillageBuildingsData.calcHonourRateBasedOnDistance(GameEngine.Instance.LocalWorldData.HonourBuilding_LargeGarden, villageMapBuilding11.buildingLocation, this.lastPlaceBuildingLoc);
					if (GameEngine.Instance.World.ThirdAgeWorld)
					{
						num19 *= 4.0;
					}
					VillageMap.placementSprite.changeText(num19.ToString());
					this.productionArrowProductionBuilding = this.lastPlaceBuildingLoc;
					this.productionArrowTargetBuilding = villageMapBuilding11.buildingLocation;
					return;
				}
				break;
			}
			case 54:
			case 55:
			case 56:
			case 57:
			{
				VillageMapBuilding villageMapBuilding12 = this.findBuildingType(0);
				if (villageMapBuilding12 != null)
				{
					double num20 = VillageBuildingsData.calcHonourRateBasedOnDistance(GameEngine.Instance.LocalWorldData.HonourBuilding_SmallStatue, villageMapBuilding12.buildingLocation, this.lastPlaceBuildingLoc);
					if (GameEngine.Instance.World.ThirdAgeWorld)
					{
						num20 *= 4.0;
					}
					VillageMap.placementSprite.changeText(num20.ToString());
					this.productionArrowProductionBuilding = this.lastPlaceBuildingLoc;
					this.productionArrowTargetBuilding = villageMapBuilding12.buildingLocation;
					return;
				}
				break;
			}
			case 58:
			case 59:
			{
				VillageMapBuilding villageMapBuilding13 = this.findBuildingType(0);
				if (villageMapBuilding13 != null)
				{
					double num21 = VillageBuildingsData.calcHonourRateBasedOnDistance(GameEngine.Instance.LocalWorldData.HonourBuilding_LargeStatue, villageMapBuilding13.buildingLocation, this.lastPlaceBuildingLoc);
					if (GameEngine.Instance.World.ThirdAgeWorld)
					{
						num21 *= 4.0;
					}
					VillageMap.placementSprite.changeText(num21.ToString());
					this.productionArrowProductionBuilding = this.lastPlaceBuildingLoc;
					this.productionArrowTargetBuilding = villageMapBuilding13.buildingLocation;
					return;
				}
				break;
			}
			case 60:
			{
				VillageMapBuilding villageMapBuilding14 = this.findBuildingType(0);
				if (villageMapBuilding14 != null)
				{
					double num22 = VillageBuildingsData.calcHonourRateBasedOnDistance(GameEngine.Instance.LocalWorldData.HonourBuilding_Dovecote, villageMapBuilding14.buildingLocation, this.lastPlaceBuildingLoc);
					if (GameEngine.Instance.World.ThirdAgeWorld)
					{
						num22 *= 4.0;
					}
					VillageMap.placementSprite.changeText(num22.ToString());
					this.productionArrowProductionBuilding = this.lastPlaceBuildingLoc;
					this.productionArrowTargetBuilding = villageMapBuilding14.buildingLocation;
					return;
				}
				break;
			}
			case 61:
			{
				VillageMapBuilding villageMapBuilding15 = this.findBuildingType(0);
				if (villageMapBuilding15 != null)
				{
					double num23 = VillageBuildingsData.calcHonourRateBasedOnDistance(GameEngine.Instance.LocalWorldData.HonourBuilding_Stocks, villageMapBuilding15.buildingLocation, this.lastPlaceBuildingLoc);
					if (GameEngine.Instance.World.ThirdAgeWorld)
					{
						num23 *= 4.0;
					}
					VillageMap.placementSprite.changeText(num23.ToString());
					this.productionArrowProductionBuilding = this.lastPlaceBuildingLoc;
					this.productionArrowTargetBuilding = villageMapBuilding15.buildingLocation;
					return;
				}
				break;
			}
			case 62:
			{
				VillageMapBuilding villageMapBuilding16 = this.findBuildingType(0);
				if (villageMapBuilding16 != null)
				{
					double num24 = VillageBuildingsData.calcHonourRateBasedOnDistance(GameEngine.Instance.LocalWorldData.HonourBuilding_BurningPost, villageMapBuilding16.buildingLocation, this.lastPlaceBuildingLoc);
					if (GameEngine.Instance.World.ThirdAgeWorld)
					{
						num24 *= 4.0;
					}
					VillageMap.placementSprite.changeText(num24.ToString());
					this.productionArrowProductionBuilding = this.lastPlaceBuildingLoc;
					this.productionArrowTargetBuilding = villageMapBuilding16.buildingLocation;
					return;
				}
				break;
			}
			case 63:
			{
				VillageMapBuilding villageMapBuilding17 = this.findBuildingType(0);
				if (villageMapBuilding17 != null)
				{
					double num25 = VillageBuildingsData.calcHonourRateBasedOnDistance(GameEngine.Instance.LocalWorldData.HonourBuilding_Gibbet, villageMapBuilding17.buildingLocation, this.lastPlaceBuildingLoc);
					if (GameEngine.Instance.World.ThirdAgeWorld)
					{
						num25 *= 4.0;
					}
					VillageMap.placementSprite.changeText(num25.ToString());
					this.productionArrowProductionBuilding = this.lastPlaceBuildingLoc;
					this.productionArrowTargetBuilding = villageMapBuilding17.buildingLocation;
					return;
				}
				break;
			}
			case 64:
			{
				VillageMapBuilding villageMapBuilding18 = this.findBuildingType(0);
				if (villageMapBuilding18 != null)
				{
					double num26 = VillageBuildingsData.calcHonourRateBasedOnDistance(GameEngine.Instance.LocalWorldData.HonourBuilding_Rack, villageMapBuilding18.buildingLocation, this.lastPlaceBuildingLoc);
					if (GameEngine.Instance.World.ThirdAgeWorld)
					{
						num26 *= 4.0;
					}
					VillageMap.placementSprite.changeText(num26.ToString());
					this.productionArrowProductionBuilding = this.lastPlaceBuildingLoc;
					this.productionArrowTargetBuilding = villageMapBuilding18.buildingLocation;
					return;
				}
				break;
			}
			case 65:
			case 66:
			case 67:
			case 68:
			case 69:
			{
				VillageMapBuilding villageMapBuilding19 = this.findBuildingType(0);
				if (villageMapBuilding19 != null)
				{
					int mapDistance2 = VillageBuildingsData.getMapDistance(villageMapBuilding19.buildingLocation, this.lastPlaceBuildingLoc);
					int buildingPopularityBasedOnDistance = VillageBuildingsData.getBuildingPopularityBasedOnDistance(GameEngine.Instance.LocalWorldData, mapDistance2);
					VillageMap.placementSprite.changeText(buildingPopularityBasedOnDistance.ToString());
					this.productionArrowProductionBuilding = this.lastPlaceBuildingLoc;
					this.productionArrowTargetBuilding = villageMapBuilding19.buildingLocation;
					return;
				}
				break;
			}
			case 70:
			case 71:
			case 72:
			case 73:
				VillageMap.placementSprite.changeText(GameEngine.Instance.LocalWorldData.FaithPoints_SmallShrine.ToString());
				return;
			case 74:
			case 75:
				VillageMap.placementSprite.changeText(GameEngine.Instance.LocalWorldData.FaithPoints_LargeShrine.ToString());
				return;
			default:
				return;
			}
		}

		// Token: 0x06002E0C RID: 11788 RVA: 0x0024BA88 File Offset: 0x00249C88
		public void Update(bool villageDisplayed)
		{
			if (this.backgroundSprite != null && villageDisplayed)
			{
				if (InterfaceMgr.Instance.updateVillageReports())
				{
					this.backgroundSprite.Update();
					this.backgroundSprite.AddToRenderList();
					this.drawSurroundSprites();
					if (GameEngine.Instance.World.isTutorialActive())
					{
						if (!TutorialWindow.overIcon)
						{
							VillageMap.tutorialOverlaySprite.TextureID = GFXLibrary.Instance.TutorialIconNormalID;
						}
						else
						{
							VillageMap.tutorialOverlaySprite.TextureID = GFXLibrary.Instance.TutorialIconOverID;
						}
						VillageMap.tutorialOverlaySprite.AddToRenderList();
					}
					if (!this.overWikiHelp)
					{
						VillageMap.wikiHelpSprite.TextureID = GFXLibrary.Instance.WikiHelpIconNormal;
					}
					else
					{
						VillageMap.wikiHelpSprite.TextureID = GFXLibrary.Instance.WikiHelpIconOver;
					}
					VillageMap.wikiHelpSprite.Scale = 0.66f;
					VillageMap.wikiHelpSprite.AddToRenderList();
				}
				if (InterfaceMgr.Instance.isDXVisible())
				{
					this.playEnvironmentalSounds();
				}
			}
			this.productionArrowProductionBuilding = new Point(-1, -1);
			this.productionArrowTargetBuilding = new Point(-1, -1);
			this.productionArrowTarget2Building = new Point(-1, -1);
			this.placementErrorString = "";
			if (this.placementError != 0 && VillageMap.placementSprite != null)
			{
				switch (this.placementError)
				{
				case 1:
					this.placementErrorString = SK.Text("VillageMap_Cannot_Be_Placed_Here", "Cannot be placed here");
					break;
				case 2:
					this.placementErrorString = SK.Text("VillageMap_Cannot_Place_Any_More", "You cannot place any more of this building type");
					break;
				case 3:
					if (GameEngine.Instance.World.isAccountPremium() || GameEngine.Instance.World.isCapital(this.m_villageID))
					{
						this.placementErrorString = SK.Text("VillageMap_Building_Queue_Full", "Building Queue Is Full");
					}
					else
					{
						this.placementErrorString = SK.Text("VillageMap_Play_Premium_For_Build_Queue", "Play a Premium Token for a Building Queue");
					}
					break;
				case 4:
					this.placementErrorString = SK.Text("VillageMap_Cannot_Afford_Building", "You cannot afford to place this building");
					break;
				case 5:
					this.placementErrorString = SK.Text("VillageMap_Not_Enough_Flags", "You do not have enough flags to place this building");
					break;
				case 6:
					this.placementErrorString = SK.Text("VillageMap_Not_Enough_Resources", "You do not have enough resources to place this building");
					break;
				case 7:
					this.placementErrorString = SK.Text("VillageMap_Near_Trees", "Place near Trees");
					break;
				case 8:
					this.placementErrorString = SK.Text("VillageMap_On_Stone", "Place on Stone");
					break;
				case 9:
					this.placementErrorString = SK.Text("VillageMap_On_Iron", "Place on Iron");
					break;
				case 10:
					this.placementErrorString = SK.Text("VillageMap_On_Marsh", "Place on Marsh");
					break;
				case 11:
					this.placementErrorString = SK.Text("VillageMap_On_Water", "Place on Water");
					break;
				case 12:
					this.placementErrorString = SK.Text("VillageMap_On_Salt_Flats", "Place on Salt Flats");
					break;
				case 13:
					this.placementErrorString = SK.Text("VillageMap_On_River_Edge", "Place near Water");
					break;
				}
				if (!GameEngine.Instance.World.isCapital(this.m_villageID) && this.allowedErrors.Contains(this.placementError))
				{
					this.updatePlacementText();
					VillageMap.placementSprite.changeText(string.Concat(new string[]
					{
						this.placementErrorString,
						Environment.NewLine,
						LNG.Print("This building will be added to the Bot queue. Production rate"),
						": ",
						VillageMap.placementSprite.getText()
					}));
				}
				else
				{
					VillageMap.placementSprite.changeText(this.placementErrorString);
				}
			}
			else
			{
				this.updatePlacementText();
			}
			if (this.granaryOpenCount > 0)
			{
				this.granaryOpenCount--;
			}
			List<VillageMapBuilding> list = new List<VillageMapBuilding>();
			try
			{
				foreach (VillageMapBuilding villageMapBuilding in this.localBuildings)
				{
					if (!villageMapBuilding.complete && !villageMapBuilding.serverDeleting)
					{
						if (villageMapBuilding.updateConstructionGFX(VillageMap.localBaseTime, VillageMap.baseServerTime, false, this) && !villageMapBuilding.completeRequestSent && !this.ViewOnly)
						{
							if (!GameEngine.Instance.World.isCapital(this.m_villageID))
							{
								GameEngine.Instance.playInterfaceSound("VillageMap_Building_Construction_Complete");
								RemoteServices.Instance.set_VillageBuildingCompleteDataRetrieval_UserCallBack(new RemoteServices.VillageBuildingCompleteDataRetrieval_UserCallBack(this.villageBuildingCompleteDataRetrievalCallback));
								RemoteServices.Instance.VillageBuildingCompleteDataRetrieval(this.m_villageID, villageMapBuilding.buildingID);
								villageMapBuilding.completeRequestSent = true;
							}
							else
							{
								villageMapBuilding.complete = true;
								villageMapBuilding.localComplete = true;
							}
						}
					}
					else if (villageMapBuilding.serverDeleting && villageMapBuilding.updateConstructionGFX(VillageMap.localBaseTime, VillageMap.baseServerTime, false, this) && !this.ViewOnly)
					{
						RemoteServices.Instance.set_VillageBuildingCompleteDataRetrieval_UserCallBack(new RemoteServices.VillageBuildingCompleteDataRetrieval_UserCallBack(this.villageBuildingCompleteDataRetrievalCallback));
						int buildingType = villageMapBuilding.buildingType;
						if (buildingType - 2 <= 2 || buildingType == 35)
						{
							RemoteServices.Instance.GetVillageBuildingsList(this.m_villageID, false, false);
						}
						else
						{
							RemoteServices.Instance.VillageBuildingDeleteDataRetrieval(this.m_villageID, villageMapBuilding.buildingID);
						}
						list.Add(villageMapBuilding);
						continue;
					}
					if (villageMapBuilding.lastOpenState != villageMapBuilding.open)
					{
						this.updateGFXState(villageMapBuilding);
					}
					this.runBuilding(villageMapBuilding);
				}
			}
			catch (InvalidOperationException)
			{
			}
			this.monitorWeaponProduction();
			if (!GameEngine.Instance.World.TutorialIsAdvancing())
			{
				int tutorialStage = GameEngine.Instance.World.getTutorialStage();
				if (tutorialStage != 2)
				{
					if (tutorialStage == 3)
					{
						VillageMapBuilding villageMapBuilding2 = this.findBuildingType(6);
						VillageMapBuilding villageMapBuilding3 = this.findBuildingType(7);
						if (villageMapBuilding2 != null && villageMapBuilding3 != null && !this.tutorialStage_Wood_Activated)
						{
							this.tutorialStage_Wood_Activated = true;
							GameEngine.Instance.World.forceTutorialToBeShown();
						}
					}
				}
				else
				{
					VillageMapBuilding villageMapBuilding4 = this.findBuildingType(13);
					if (villageMapBuilding4 != null && !this.tutorialStage_AppleFarm_Activated)
					{
						this.tutorialStage_AppleFarm_Activated = true;
						GameEngine.Instance.World.forceTutorialToBeShown();
					}
				}
			}
			if (list.Count > 0)
			{
				foreach (VillageMapBuilding villageMapBuilding5 in list)
				{
					VillageMap.villageClickMask.removeBuilding(villageMapBuilding5.buildingID);
					this.removeBuildingFromMap(Point.Empty, villageMapBuilding5.buildingType, villageMapBuilding5.buildingID);
					this.localBuildings.Remove(villageMapBuilding5);
				}
			}
			if (this.updateFilter % 10 == 0)
			{
				VillageMap.StockpileLevels stockpileLevels = new VillageMap.StockpileLevels();
				bool stockpileLevels2 = this.getStockpileLevels(stockpileLevels);
				VillageMap.GranaryLevels granaryLevels = new VillageMap.GranaryLevels();
				bool granaryLevels2 = this.getGranaryLevels(granaryLevels);
				int foodLevel = (int)granaryLevels.total;
				if (GameEngine.Instance.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_CASTLE)
				{
					int num = 0;
					GameEngine.Instance.Castle.adjustLevels(ref stockpileLevels, ref num);
				}
				InterfaceMgr.Instance.setVillageInfoData((int)stockpileLevels.woodLevel, 0, (int)stockpileLevels.stoneLevel, foodLevel, stockpileLevels2, granaryLevels2, this.m_totalPeople, this.m_housingCapacity, this.m_spareWorkers, (int)stockpileLevels.pitchLevel, this.ViewOnly, (int)stockpileLevels.ironLevel, (int)this.m_capitalGold, this.VillageID, this.m_numParishFlags);
				this.updateStats();
				this.manageBackgroundSounds();
			}
			this.updateTraders();
			this.updateFilter++;
			if (this.m_previousMousePos == this.m_lastMousePos)
			{
				if (this.m_lastOverBuildingID >= 0L || (DateTime.Now - this.m_lastMousePosChangeTime).TotalSeconds <= 1.0)
				{
					return;
				}
				Point worldPos = this.Camera.ScreenToWorldSpace(this.m_lastMousePos);
				long buildingIDFromWorldPos = VillageMap.villageClickMask.getBuildingIDFromWorldPos(worldPos);
				if (buildingIDFromWorldPos < 0L)
				{
					this.m_lastMousePosChangeTime = DateTime.MaxValue;
					return;
				}
				this.m_lastOverBuildingID = buildingIDFromWorldPos;
				VillageMapBuilding villageMapBuilding6 = this.findBuilding(buildingIDFromWorldPos);
				if (villageMapBuilding6 == null)
				{
					return;
				}
				bool flag = true;
				if (!villageMapBuilding6.complete)
				{
					flag = false;
				}
				else if (VillageBuildingsData.buildingRequiresWorker(villageMapBuilding6.buildingType) && (!villageMapBuilding6.buildingActive || !villageMapBuilding6.gotEmployee))
				{
					flag = false;
				}
				if (!flag)
				{
					this.m_lastMousePosChangeTime = DateTime.MaxValue;
					return;
				}
				int buildingType2 = villageMapBuilding6.buildingType;
				string buildingNameLabel = VillageBuildingsData.getBuildingNameLabel(buildingType2);
				if (buildingNameLabel.Length > 0 && !GameEngine.Instance.AudioEngine.isSoundPlaying(buildingNameLabel))
				{
					GameEngine.Instance.playInterfaceSound(buildingNameLabel);
					return;
				}
			}
			else
			{
				this.m_lastOverBuildingID = -1L;
				this.m_lastMousePosChangeTime = DateTime.Now;
			}
		}

		// Token: 0x06002E0D RID: 11789 RVA: 0x0024C314 File Offset: 0x0024A514
		public bool allowTutorialAdvance()
		{
			if (!GameEngine.Instance.World.TutorialIsAdvancing())
			{
				int tutorialStage = GameEngine.Instance.World.getTutorialStage();
				if (tutorialStage != 2)
				{
					if (tutorialStage == 3)
					{
						VillageMapBuilding villageMapBuilding = this.findBuildingType(6);
						VillageMapBuilding villageMapBuilding2 = this.findBuildingType(7);
						if (villageMapBuilding != null && villageMapBuilding2 != null)
						{
							return true;
						}
					}
				}
				else
				{
					VillageMapBuilding villageMapBuilding3 = this.findBuildingType(13);
					if (villageMapBuilding3 != null)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06002E0E RID: 11790 RVA: 0x0024C374 File Offset: 0x0024A574
		public void runBuilding(VillageMapBuilding building)
		{
			if (!building.isComplete())
			{
				return;
			}
			switch (building.buildingType)
			{
			case 2:
			case 35:
				building.initStorageBuilding(this.gfx, this);
				return;
			case 3:
				building.initStorageBuilding(this.gfx, this);
				this.runAnimals(building, this, 1);
				return;
			case 4:
			case 5:
			case 20:
			case 27:
			case 38:
			case 39:
			case 40:
			case 41:
			case 42:
			case 43:
			case 44:
			case 45:
			case 46:
			case 47:
			case 48:
			case 49:
			case 50:
			case 51:
			case 52:
			case 53:
			case 54:
			case 55:
			case 56:
			case 57:
			case 58:
			case 59:
			case 60:
			case 70:
			case 71:
			case 72:
			case 73:
			case 74:
			case 75:
			case 76:
			case 77:
				break;
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
				this.runPrimaryResourceBuilding(building, 2);
				return;
			case 12:
				this.runPrimaryResourceBuilding(building, 35);
				return;
			case 13:
			case 16:
			case 18:
				this.runPrimaryResourceBuilding(building, 3);
				this.runAnimals(building, this, 1);
				return;
			case 14:
				this.runPrimaryResourceBuilding(building, 3);
				if (building.open)
				{
					if (building.extraAnimSprite2 != null)
					{
						building.extraAnimSprite2.changeBaseFrame(371);
						return;
					}
				}
				else if (building.extraAnimSprite2 != null)
				{
					building.extraAnimSprite2.changeBaseFrame(356);
					return;
				}
				break;
			case 15:
				this.runPrimaryResourceBuilding(building, 3);
				return;
			case 17:
				this.runPrimaryResourceBuilding(building, 3);
				if (building.secondaryWorker != null && building.secondaryWorker.workerSprite != null)
				{
					if (building.worker != null && building.worker.workerSprite != null)
					{
						building.secondaryWorker.workerSprite.Visible = building.worker.workerSprite.Visible;
						return;
					}
					building.secondaryWorker.workerSprite.Visible = true;
					return;
				}
				break;
			case 19:
				this.runPrimaryResourceBuilding(building, 0);
				this.runAnimals(building, this, 1);
				return;
			case 21:
			case 22:
			case 23:
			case 24:
			case 25:
			case 26:
			case 33:
				this.runPrimaryResourceBuilding(building, 0);
				return;
			case 28:
			{
				double num = building.serverCalcRate;
				if (this.m_toBeMade_Pikes > 0.0 && num > 0.0)
				{
					double num2 = (DXTimer.GetCurrentMilliseconds() - VillageMap.localBaseTime) / 1000.0;
					DateTime t = VillageMap.baseServerTime + new TimeSpan(0, 0, (int)num2);
					if (t >= this.m_productionEnd_Pikes)
					{
						num = 0.0;
					}
				}
				else
				{
					num = 0.0;
				}
				this.runSecondaryResourceBuilding(building, 4, 2, num);
				return;
			}
			case 29:
			{
				double num3 = building.serverCalcRate;
				if (this.m_toBeMade_Bows > 0.0 && num3 > 0.0)
				{
					double num4 = (DXTimer.GetCurrentMilliseconds() - VillageMap.localBaseTime) / 1000.0;
					DateTime t2 = VillageMap.baseServerTime + new TimeSpan(0, 0, (int)num4);
					if (t2 >= this.m_productionEnd_Bows)
					{
						num3 = 0.0;
					}
				}
				else
				{
					num3 = 0.0;
				}
				this.runSecondaryResourceBuilding(building, 4, 2, num3);
				return;
			}
			case 30:
			{
				double num5 = building.serverCalcRate;
				if (this.m_toBeMade_Swords > 0.0 && num5 > 0.0)
				{
					double num6 = (DXTimer.GetCurrentMilliseconds() - VillageMap.localBaseTime) / 1000.0;
					DateTime t3 = VillageMap.baseServerTime + new TimeSpan(0, 0, (int)num6);
					if (t3 >= this.m_productionEnd_Swords)
					{
						num5 = 0.0;
					}
				}
				else
				{
					num5 = 0.0;
				}
				this.runSecondaryResourceBuilding(building, 4, 2, num5);
				return;
			}
			case 31:
			{
				double num7 = building.serverCalcRate;
				if (this.m_toBeMade_Armour > 0.0 && num7 > 0.0)
				{
					double num8 = (DXTimer.GetCurrentMilliseconds() - VillageMap.localBaseTime) / 1000.0;
					DateTime t4 = VillageMap.baseServerTime + new TimeSpan(0, 0, (int)num8);
					if (t4 >= this.m_productionEnd_Armour)
					{
						num7 = 0.0;
					}
				}
				else
				{
					num7 = 0.0;
				}
				this.runSecondaryResourceBuilding(building, 4, 2, num7);
				return;
			}
			case 32:
			{
				double num9 = building.serverCalcRate;
				if (this.m_toBeMade_Catapults > 0.0 && num9 > 0.0)
				{
					double num10 = (DXTimer.GetCurrentMilliseconds() - VillageMap.localBaseTime) / 1000.0;
					DateTime t5 = VillageMap.baseServerTime + new TimeSpan(0, 0, (int)num10);
					if (t5 >= this.m_productionEnd_Catapults)
					{
						num9 = 0.0;
					}
				}
				else
				{
					num9 = 0.0;
				}
				this.runSecondaryResourceBuilding(building, 4, 2, num9);
				return;
			}
			case 34:
			case 36:
			case 37:
				this.manageWorkingSounds(building);
				break;
			case 61:
			case 62:
			case 63:
			case 64:
			case 65:
			case 66:
			case 69:
				building.open = true;
				return;
			case 67:
				if (!building.open)
				{
					Random random = new Random();
					building.open = true;
					if (random.Next(100) < 50 && building.animSprite != null)
					{
						building.animSprite.changeBaseFrame(18);
						return;
					}
				}
				break;
			case 68:
				building.open = true;
				if (building.animSprite != null && building.animSprite.isAnimFinished())
				{
					int num11 = building.animSprite.SpriteNo;
					num11++;
					if (num11 >= 8)
					{
						num11 = 0;
					}
					building.animSprite.changeBaseFrame(num11);
					building.animSprite.restartAnim();
					return;
				}
				break;
			case 78:
				if (building.worker != null)
				{
					this.runMarketTrader(building);
					return;
				}
				break;
			default:
				return;
			}
		}

		// Token: 0x06002E0F RID: 11791 RVA: 0x0024C934 File Offset: 0x0024AB34
		public void updateBuildingsOnImport()
		{
			foreach (VillageMapBuilding building in this.localBuildings)
			{
				this.runBuilding(building);
			}
		}

		// Token: 0x06002E10 RID: 11792 RVA: 0x00021AD7 File Offset: 0x0001FCD7
		public void addChildSprite(SpriteWrapper sprite)
		{
			if (this.backgroundSprite != null)
			{
				this.removeChildSprite(sprite);
				this.backgroundSprite.AddChild(sprite);
			}
		}

		// Token: 0x06002E11 RID: 11793 RVA: 0x00021AF4 File Offset: 0x0001FCF4
		public void addChildSprite(SpriteWrapper sprite, int layerDiff)
		{
			if (this.backgroundSprite != null)
			{
				this.removeChildSprite(sprite);
				this.backgroundSprite.AddChild(sprite, layerDiff);
			}
		}

		// Token: 0x06002E12 RID: 11794 RVA: 0x00021B12 File Offset: 0x0001FD12
		public void removeChildSprite(SpriteWrapper sprite)
		{
			if (this.backgroundSprite != null)
			{
				this.backgroundSprite.RemoveChild(sprite);
			}
		}

		// Token: 0x06002E13 RID: 11795 RVA: 0x0024C988 File Offset: 0x0024AB88
		public VillageMapBuilding findBuildingType(int buildingType)
		{
			if (buildingType == 4)
			{
				this.fakeArmoury.buildingType = 4;
				this.fakeArmoury.buildingLocation = new Point(28, 0);
				return this.fakeArmoury;
			}
			foreach (VillageMapBuilding villageMapBuilding in this.localBuildings)
			{
				if (villageMapBuilding.buildingType == buildingType && villageMapBuilding.isComplete())
				{
					return villageMapBuilding;
				}
			}
			return null;
		}

		// Token: 0x06002E14 RID: 11796 RVA: 0x0024CA18 File Offset: 0x0024AC18
		public VillageMapBuilding findBuildingTypeIncludingConstructing(int buildingType)
		{
			foreach (VillageMapBuilding villageMapBuilding in this.localBuildings)
			{
				if (villageMapBuilding.buildingType == buildingType)
				{
					return villageMapBuilding;
				}
			}
			return null;
		}

		// Token: 0x06002E15 RID: 11797 RVA: 0x0024CA74 File Offset: 0x0024AC74
		public VillageMapBuilding findBuilding(long buildingID)
		{
			foreach (VillageMapBuilding villageMapBuilding in this.localBuildings)
			{
				if (villageMapBuilding.buildingID == buildingID)
				{
					return villageMapBuilding;
				}
			}
			return null;
		}

		// Token: 0x06002E16 RID: 11798 RVA: 0x0024CAD0 File Offset: 0x0024ACD0
		public VillageMapBuilding getNextBuilding(VillageMapBuilding building)
		{
			int i = 0;
			while (i < this.localBuildings.Count)
			{
				if (this.localBuildings[i] == building)
				{
					if (i + 1 >= this.localBuildings.Count)
					{
						return this.localBuildings[0];
					}
					return this.localBuildings[i + 1];
				}
				else
				{
					i++;
				}
			}
			if (this.localBuildings.Count > 0)
			{
				return this.localBuildings[0];
			}
			return null;
		}

		// Token: 0x06002E17 RID: 11799 RVA: 0x0024CB4C File Offset: 0x0024AD4C
		public VillageMapBuilding getPreviousBuilding(VillageMapBuilding building)
		{
			int i = 0;
			while (i < this.localBuildings.Count)
			{
				if (this.localBuildings[i] == building)
				{
					if (i - 1 < 0)
					{
						return this.localBuildings[this.localBuildings.Count - 1];
					}
					return this.localBuildings[i - 1];
				}
				else
				{
					i++;
				}
			}
			if (this.localBuildings.Count > 0)
			{
				return this.localBuildings[0];
			}
			return null;
		}

		// Token: 0x06002E18 RID: 11800 RVA: 0x0024CBC8 File Offset: 0x0024ADC8
		public int countNumBuildingsConstructing()
		{
			int num = 0;
			foreach (VillageMapBuilding villageMapBuilding in this.localBuildings)
			{
				if (!villageMapBuilding.isComplete() && !villageMapBuilding.isDeleting())
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06002E19 RID: 11801 RVA: 0x0024CC2C File Offset: 0x0024AE2C
		public int countWorkingMarkets()
		{
			int num = 0;
			foreach (VillageMapBuilding villageMapBuilding in this.localBuildings)
			{
				if (villageMapBuilding.buildingType == 78 && villageMapBuilding.isComplete())
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06002E1A RID: 11802 RVA: 0x000219D6 File Offset: 0x0001FBD6
		public int countBuildings()
		{
			return this.localBuildings.Count;
		}

		// Token: 0x06002E1B RID: 11803 RVA: 0x0024CC94 File Offset: 0x0024AE94
		public int countBuildingType(int buildingType)
		{
			int num = 0;
			foreach (VillageMapBuilding villageMapBuilding in this.localBuildings)
			{
				if (villageMapBuilding.buildingType == buildingType)
				{
					num++;
				}
				else
				{
					if (buildingType != 1)
					{
						switch (buildingType)
						{
						case 38:
						case 41:
						case 42:
						case 43:
						case 44:
						case 45:
						{
							int buildingType2 = villageMapBuilding.buildingType;
							if (buildingType2 == 38 || buildingType2 - 41 <= 4)
							{
								num++;
								continue;
							}
							continue;
						}
						case 39:
						case 40:
						case 76:
						case 77:
							break;
						case 46:
						case 47:
						case 48:
						{
							int buildingType3 = villageMapBuilding.buildingType;
							if (buildingType3 - 46 <= 2)
							{
								num++;
								continue;
							}
							continue;
						}
						case 49:
						case 50:
						case 51:
						{
							int buildingType4 = villageMapBuilding.buildingType;
							if (buildingType4 - 49 <= 2)
							{
								num++;
								continue;
							}
							continue;
						}
						case 52:
						case 53:
						case 60:
						case 61:
						case 62:
						case 63:
						case 64:
						case 65:
						case 66:
						case 67:
						case 68:
						case 69:
							continue;
						case 54:
						case 55:
						case 56:
						case 57:
						{
							int buildingType5 = villageMapBuilding.buildingType;
							if (buildingType5 - 54 <= 3)
							{
								num++;
								continue;
							}
							continue;
						}
						case 58:
						case 59:
						{
							int buildingType6 = villageMapBuilding.buildingType;
							if (buildingType6 - 58 <= 1)
							{
								num++;
								continue;
							}
							continue;
						}
						case 70:
						case 71:
						case 72:
						case 73:
						{
							int buildingType7 = villageMapBuilding.buildingType;
							if (buildingType7 - 70 <= 3)
							{
								num++;
								continue;
							}
							continue;
						}
						case 74:
						case 75:
						{
							int buildingType8 = villageMapBuilding.buildingType;
							if (buildingType8 - 74 <= 1)
							{
								num++;
								continue;
							}
							continue;
						}
						default:
							continue;
						}
					}
					int buildingType9 = villageMapBuilding.buildingType;
					if (buildingType9 == 1 || buildingType9 - 39 <= 1 || buildingType9 - 76 <= 1)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x06002E1C RID: 11804 RVA: 0x0024CE88 File Offset: 0x0024B088
		private void preCountHonourBuildings()
		{
			this.m_preCountedChurches = 0;
			this.m_preCountedChapels = 0;
			this.m_preCountedCathedrals = 0;
			this.m_preCountedSmallGardens = 0;
			this.m_preCountedLargeGardens = 0;
			this.m_preCountedSmallStatues = 0;
			this.m_preCountedLargeStatues = 0;
			this.m_preCountedDovecotes = 0;
			this.m_preCountedStocks = 0;
			this.m_preCountedBurningPosts = 0;
			this.m_preCountedGibbets = 0;
			this.m_preCountedRacks = 0;
			foreach (VillageMapBuilding villageMapBuilding in this.localBuildings)
			{
				if (villageMapBuilding.isComplete())
				{
					switch (villageMapBuilding.buildingType)
					{
					case 34:
						this.m_preCountedChapels++;
						break;
					case 36:
						this.m_preCountedChurches++;
						break;
					case 37:
						this.m_preCountedCathedrals++;
						break;
					case 38:
					case 41:
					case 42:
					case 43:
					case 44:
					case 45:
						this.m_preCountedSmallGardens++;
						break;
					case 49:
					case 50:
					case 51:
						this.m_preCountedLargeGardens++;
						break;
					case 54:
					case 55:
					case 56:
					case 57:
						this.m_preCountedSmallStatues++;
						break;
					case 58:
					case 59:
						this.m_preCountedLargeStatues++;
						break;
					case 60:
						this.m_preCountedDovecotes++;
						break;
					case 61:
						this.m_preCountedStocks++;
						break;
					case 62:
						this.m_preCountedBurningPosts++;
						break;
					case 63:
						this.m_preCountedGibbets++;
						break;
					case 64:
						this.m_preCountedRacks++;
						break;
					}
				}
			}
		}

		// Token: 0x06002E1D RID: 11805 RVA: 0x00021B28 File Offset: 0x0001FD28
		public bool capitalBuildingBuilt(int buildingType)
		{
			return this.m_capitalBuildingsBuilt != null && this.m_capitalBuildingsBuilt.Contains(buildingType);
		}

		// Token: 0x06002E1E RID: 11806 RVA: 0x0024D0A0 File Offset: 0x0024B2A0
		public void importResourcesAndStats(VillageResourceAndStatsReturnData resourceData, DateTime currentServerTime)
		{
			this.m_lastServerReply = currentServerTime;
			this.m_woodLevel = resourceData.woodLevel;
			this.m_stoneLevel = resourceData.stoneLevel;
			this.m_ironLevel = resourceData.ironLevel;
			this.m_pitchLevel = resourceData.pitchLevel;
			this.m_aleLevel = resourceData.aleLevel;
			this.m_applesLevel = resourceData.applesLevel;
			this.m_breadLevel = resourceData.breadLevel;
			this.m_cheeseLevel = resourceData.cheeseLevel;
			this.m_meatLevel = resourceData.meatLevel;
			this.m_vegLevel = resourceData.vegLevel;
			this.m_fishLevel = resourceData.fishLevel;
			this.m_saltLevel = resourceData.saltLevel;
			this.m_wineLevel = resourceData.wineLevel;
			this.m_venisonLevel = resourceData.venisonLevel;
			this.m_clothesLevel = resourceData.clothesLevel;
			this.m_furnitureLevel = resourceData.furnitureLevel;
			this.m_spicesLevel = resourceData.spicesLevel;
			this.m_silkLevel = resourceData.silkLevel;
			this.m_metalwareLevel = resourceData.metalwareLevel;
			this.m_bowsLevel = resourceData.bowsLevel;
			this.m_pikesLevel = resourceData.pikesLevel;
			this.m_swordsLevel = resourceData.swordsLevel;
			this.m_armourLevel = resourceData.armourLevel;
			this.m_catapultsLevel = resourceData.catapultLevel;
			this.m_taxLevelServer = resourceData.taxLevel;
			this.m_rationsLevelServer = resourceData.rationsLevel;
			this.m_aleRationsLevelServer = resourceData.aleRationsLevel;
			if (this.m_taxLevel == this.m_taxLevelSent)
			{
				this.m_taxLevel = (this.m_taxLevelSent = resourceData.taxLevel);
			}
			if (this.m_rationsLevel == this.m_rationsLevelSent)
			{
				this.m_rationsLevel = (this.m_rationsLevelSent = resourceData.rationsLevel);
			}
			if (this.m_aleRationsLevel == this.m_aleRationsLevelSent)
			{
				this.m_aleRationsLevel = (this.m_aleRationsLevelSent = resourceData.aleRationsLevel);
			}
			this.m_popularityLevel = resourceData.popularityLevel;
			this.m_housingCapacity = resourceData.housingCapacity;
			if (resourceData.totalPeople < 0)
			{
				resourceData.totalPeople = 0;
			}
			this.m_totalPeople = resourceData.totalPeople;
			this.m_spareWorkers = resourceData.sparePeople;
			this.m_immigrationNextChangeTime = resourceData.immigrationChangeTime;
			this.m_numPositiveBuildings = resourceData.numPositiveBuildings;
			this.m_numNegativeBuildings = resourceData.numNegativeBuildings;
			this.m_numPopularityBuildings = resourceData.numPopularityBuildings;
			this.m_applesConsumption = resourceData.applesConsumption;
			this.m_breadConsumption = resourceData.breadConsumption;
			this.m_cheeseConsumption = resourceData.cheeseConsumption;
			this.m_meatConsumption = resourceData.meatConsumption;
			this.m_vegConsumption = resourceData.vegConsumption;
			this.m_fishConsumption = resourceData.fishConsumption;
			this.m_consumptionLastTime = resourceData.consumptionLastTime;
			this.m_effectiveRationsLevel = resourceData.effectiveRationsLevel;
			this.m_showEffective = true;
			this.m_consumptionChangeTimeNeeded = resourceData.consumptionChangeTimeNeeded;
			if (resourceData.consumptionChangeTimeNeeded)
			{
				this.m_consumptionChangeTime = resourceData.consumptionChangeTime;
			}
			this.m_numFoodTypesEaten = resourceData.numFoodTypesEaten;
			this.m_aleConsumption = resourceData.aleConsumption;
			this.m_effectiveAleRationsLevel = resourceData.effectiveAleRationsLevel;
			this.m_showAleEffective = true;
			this.mergePopEvents(resourceData.popEventList);
			this.m_toBeMade_Bows = resourceData.toBeMade_Bows;
			this.m_toBeMade_Pikes = resourceData.toBeMade_Pikes;
			this.m_toBeMade_Swords = resourceData.toBeMade_Swords;
			this.m_toBeMade_Armour = resourceData.toBeMade_Armour;
			this.m_toBeMade_Catapults = resourceData.toBeMade_Catapults;
			this.m_productionStart_Bows = resourceData.productionStart_Bows;
			this.m_productionStart_Pikes = resourceData.productionStart_Pikes;
			this.m_productionStart_Swords = resourceData.productionStart_Swords;
			this.m_productionStart_Armour = resourceData.productionStart_Armour;
			this.m_productionStart_Catapults = resourceData.productionStart_Catapults;
			this.m_productionEnd_Bows = resourceData.productionEnd_Bows;
			this.m_productionEnd_Pikes = resourceData.productionEnd_Pikes;
			this.m_productionEnd_Swords = resourceData.productionEnd_Swords;
			this.m_productionEnd_Armour = resourceData.productionEnd_Armour;
			this.m_productionEnd_Catapults = resourceData.productionEnd_Catapults;
			this.m_productionRate_Bows = resourceData.productionRate_Bows;
			this.m_productionRate_Pikes = resourceData.productionRate_Pikes;
			this.m_productionRate_Swords = resourceData.productionRate_Swords;
			this.m_productionRate_Armour = resourceData.productionRate_Armour;
			this.m_productionRate_Catapults = resourceData.productionRate_Catapults;
			this.m_nextWeaponsCheck = resourceData.nextWeaponsCheck.AddSeconds(10.0);
			this.m_parishCapitalResearchData = resourceData.capitalResearchData;
			if (GameEngine.Instance.World.SeventhAgeWorld)
			{
				this.m_parishCapitalResearchData.seventhAge = true;
			}
			this.m_ownedDate = resourceData.ownedDate;
			this.m_numParishFlags = resourceData.numParishFlags;
			if (resourceData.capitalBuildingsBuilt == null)
			{
				this.m_capitalBuildingsBuilt = null;
			}
			else
			{
				this.m_capitalBuildingsBuilt = new List<int>();
				this.m_capitalBuildingsBuilt.AddRange(resourceData.capitalBuildingsBuilt);
			}
			this.m_numArchers = resourceData.numTroops_Archers;
			this.m_numPeasants = resourceData.numTroops_Peasants;
			this.m_numPikemen = resourceData.numTroops_Pikemen;
			this.m_numSwordsmen = resourceData.numTroops_Swordsmen;
			this.m_numCatapults = resourceData.numTroops_Catapults;
			this.m_numScouts = resourceData.numTroops_Scouts;
			this.m_numCaptains = resourceData.numTroops_Captains;
			this.m_creatingCaptain = resourceData.captainCreating;
			this.m_captainCreationTime = resourceData.captainCreationTime;
			this.m_lastBanquetStored = resourceData.lastBanquetStored;
			this.m_lastBanquetHonour = resourceData.lastBanquetHonour;
			this.m_lastBanquetDate = resourceData.lastBanquetDate;
			this.m_capitalGold = resourceData.capitalGold;
			this.m_capitalTaxRateServer = resourceData.capitalTaxRate;
			this.m_parentCapitalTaxRate = resourceData.parentCapitalTaxRate;
			this.m_lastCapitalTaxRate = resourceData.lastCapitalTaxRate;
			this.m_numOfActiveChildrenAreas = resourceData.numOfActiveChildrenAreas;
			if (this.m_capitalTaxRate == this.m_capitalTaxRateSent)
			{
				this.m_capitalTaxRate = (this.m_capitalTaxRateSent = resourceData.capitalTaxRate);
			}
			this.m_numStationedArchers = resourceData.numStationedTroops_Archers;
			this.m_numStationedPeasants = resourceData.numStationedTroops_Peasants;
			this.m_numStationedPikemen = resourceData.numStationedTroops_Pikemen;
			this.m_numStationedSwordsmen = resourceData.numStationedTroops_Swordsmen;
			this.m_numStationedCatapults = resourceData.numStationedTroops_Catapults;
			this.m_numTradersAtHome = resourceData.numTraders;
			this.m_nextMapTypeChange = resourceData.nextMapTypeChange;
			this.m_interdictionTime = resourceData.interdictProtectionEndTime;
			GameEngine.Instance.World.setInterdictTime(this.VillageID, resourceData.interdictProtectionEndTime);
			GameEngine.Instance.World.setPeaceTime(this.VillageID, resourceData.peaceTime);
			GameEngine.Instance.World.setExcommunicationTime(this.VillageID, resourceData.excommunicationEndTime);
			this.m_excommunicationTime = resourceData.excommunicationEndTime;
			this.m_castleEnclosed = resourceData.castleEnclosed;
			this.m_captialNextDelete = resourceData.nextCapitalDelete;
			if (resourceData.numMadeCaptains >= 0)
			{
				GameEngine.Instance.World.setNumMadeCaptains(resourceData.numMadeCaptains);
			}
			this.showStats();
			if (GameEngine.Instance.Castle != null)
			{
				GameEngine.Instance.Castle.updateAvailableTroops();
			}
		}

		// Token: 0x06002E1F RID: 11807 RVA: 0x0024D70C File Offset: 0x0024B90C
		private void mergePopEvents(PopEventData[] popEvents)
		{
			bool flag = false;
			foreach (PopEventData popEventData in popEvents)
			{
				if (popEventData.eventType == 1)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				if (popEvents.Length == 3)
				{
					if (popEvents[0].endTime < popEvents[1].endTime)
					{
						PopEventData popEventData2 = popEvents[0];
						popEvents[0] = popEvents[1];
						popEvents[1] = popEventData2;
					}
					if (popEvents[1].endTime < popEvents[2].endTime)
					{
						PopEventData popEventData3 = popEvents[1];
						popEvents[1] = popEvents[2];
						popEvents[2] = popEventData3;
					}
					if (popEvents[0].endTime < popEvents[1].endTime)
					{
						PopEventData popEventData4 = popEvents[0];
						popEvents[0] = popEvents[1];
						popEvents[1] = popEventData4;
					}
				}
				else if (popEvents.Length == 2 && popEvents[0].endTime < popEvents[1].endTime)
				{
					PopEventData popEventData5 = popEvents[0];
					popEvents[0] = popEvents[1];
					popEvents[1] = popEventData5;
				}
			}
			List<PopEventData> list = new List<PopEventData>();
			foreach (PopEventData popEventData6 in popEvents)
			{
				if (popEventData6.eventType == 11001)
				{
					bool flag2 = false;
					foreach (PopEventData popEventData7 in list)
					{
						if (popEventData7.eventType == 11001)
						{
							popEventData7.eventEffect += popEventData6.eventEffect;
							popEventData7.numIndividualEvents++;
							flag2 = true;
							break;
						}
					}
					if (!flag2)
					{
						list.Add(popEventData6);
					}
				}
				else if (popEventData6.eventType == 11002)
				{
					bool flag3 = false;
					foreach (PopEventData popEventData8 in list)
					{
						if (popEventData8.eventType == 11002)
						{
							popEventData8.eventEffect += popEventData6.eventEffect;
							popEventData8.numIndividualEvents++;
							flag3 = true;
							break;
						}
					}
					if (!flag3)
					{
						list.Add(popEventData6);
					}
				}
				else if (popEventData6.eventType == 11003)
				{
					bool flag4 = false;
					foreach (PopEventData popEventData9 in list)
					{
						if (popEventData9.eventType == 11003)
						{
							popEventData9.eventEffect += popEventData6.eventEffect;
							popEventData9.numIndividualEvents++;
							flag4 = true;
							break;
						}
					}
					if (!flag4)
					{
						list.Add(popEventData6);
					}
				}
				else if (popEventData6.eventType == 10101)
				{
					bool flag5 = false;
					foreach (PopEventData popEventData10 in list)
					{
						if (popEventData10.eventType == 10101)
						{
							if (popEventData6.endTime > popEventData10.endTime)
							{
								popEventData10.endTime = popEventData6.endTime;
							}
							popEventData10.eventEffect += popEventData6.eventEffect;
							if (popEventData10.eventEffect > 100)
							{
								popEventData10.eventEffect = 100;
							}
							popEventData10.numIndividualEvents++;
							flag5 = true;
							break;
						}
					}
					if (!flag5)
					{
						list.Add(popEventData6);
					}
				}
				else if (popEventData6.eventType == 10102)
				{
					bool flag6 = false;
					foreach (PopEventData popEventData11 in list)
					{
						if (popEventData11.eventType == 10102)
						{
							if (popEventData6.endTime > popEventData11.endTime)
							{
								popEventData11.endTime = popEventData6.endTime;
							}
							popEventData11.eventEffect += popEventData6.eventEffect;
							if (popEventData11.eventEffect < -100)
							{
								popEventData11.eventEffect = -100;
							}
							popEventData11.numIndividualEvents++;
							flag6 = true;
							break;
						}
					}
					if (!flag6)
					{
						list.Add(popEventData6);
					}
				}
				else
				{
					list.Add(popEventData6);
				}
			}
			CardData userCardData = GameEngine.Instance.cardsManager.UserCardData;
			for (int k = 0; k < userCardData.cards.Length; k++)
			{
				int card = userCardData.cards[k];
				int cardType = CardTypes.getCardType(card);
				if (cardType == 2831)
				{
					list.Add(new PopEventData
					{
						endTime = userCardData.cardsExpiry[k],
						eventEffect = (int)CardTypes.getCardEffectValue(2831),
						eventType = 20001,
						villageID = this.m_villageID
					});
				}
			}
			this.m_popEvents = list.ToArray();
		}

		// Token: 0x06002E20 RID: 11808 RVA: 0x00021B43 File Offset: 0x0001FD43
		public void getVillageTroops(ref int numAvailableDefenderPeasants, ref int numAvailableDefenderArchers, ref int numAvailableDefenderPikemen, ref int numAvailableDefenderSwordsmen, ref int numAvailableDefenderCaptains)
		{
			numAvailableDefenderPeasants = this.m_numPeasants;
			numAvailableDefenderArchers = this.m_numArchers;
			numAvailableDefenderPikemen = this.m_numPikemen;
			numAvailableDefenderSwordsmen = this.m_numSwordsmen;
			numAvailableDefenderCaptains = this.m_numCaptains;
		}

		// Token: 0x06002E21 RID: 11809 RVA: 0x00021B6F File Offset: 0x0001FD6F
		public void getVillageVassalTroops(ref int numAvailableVassalDefenderPeasants, ref int numAvailableVassalDefenderArchers, ref int numAvailableVassalDefenderPikemen, ref int numAvailableVassalDefenderSwordsmen)
		{
			numAvailableVassalDefenderPeasants = this.m_numStationedPeasants;
			numAvailableVassalDefenderArchers = this.m_numStationedArchers;
			numAvailableVassalDefenderPikemen = this.m_numStationedPikemen;
			numAvailableVassalDefenderSwordsmen = this.m_numStationedSwordsmen;
		}

		// Token: 0x06002E22 RID: 11810 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void importBuildingTypesActiveList(bool[] activeList)
		{
		}

		// Token: 0x06002E23 RID: 11811 RVA: 0x0024DC18 File Offset: 0x0024BE18
		public bool getStockpileLevels(VillageMap.StockpileLevels levels)
		{
			if (this.findBuildingType(2) == null && !GameEngine.Instance.World.isCapital(this.VillageID))
			{
				return false;
			}
			levels.woodLevel = this.m_woodLevel;
			levels.stoneLevel = this.m_stoneLevel;
			levels.ironLevel = this.m_ironLevel;
			levels.pitchLevel = this.m_pitchLevel;
			double localTimeLapsed = (DXTimer.GetCurrentMilliseconds() - VillageMap.localBaseTime) / 1000.0;
			foreach (VillageMapBuilding villageMapBuilding in this.localBuildings)
			{
				switch (villageMapBuilding.buildingType)
				{
				case 6:
					levels.woodLevel += (double)this.calcResourceLevel(villageMapBuilding, localTimeLapsed);
					break;
				case 7:
					levels.stoneLevel += (double)this.calcResourceLevel(villageMapBuilding, localTimeLapsed);
					break;
				case 8:
					levels.ironLevel += (double)this.calcResourceLevel(villageMapBuilding, localTimeLapsed);
					break;
				case 9:
					levels.pitchLevel += (double)this.calcResourceLevel(villageMapBuilding, localTimeLapsed);
					break;
				}
			}
			levels.woodLevel = this.capResource(6, levels.woodLevel);
			levels.stoneLevel = this.capResource(7, levels.stoneLevel);
			levels.ironLevel = this.capResource(8, levels.ironLevel);
			levels.pitchLevel = this.capResource(9, levels.pitchLevel);
			return true;
		}

		// Token: 0x06002E24 RID: 11812 RVA: 0x0024DDA0 File Offset: 0x0024BFA0
		public bool getGranaryLevels(VillageMap.GranaryLevels levels)
		{
			if (this.findBuildingType(3) == null)
			{
				return false;
			}
			levels.applesLevel = this.m_applesLevel;
			levels.breadLevel = this.m_breadLevel;
			levels.meatLevel = this.m_meatLevel;
			levels.cheeseLevel = this.m_cheeseLevel;
			levels.vegLevel = this.m_vegLevel;
			levels.fishLevel = this.m_fishLevel;
			double num = (DXTimer.GetCurrentMilliseconds() - VillageMap.localBaseTime) / 1000.0;
			foreach (VillageMapBuilding villageMapBuilding in this.localBuildings)
			{
				switch (villageMapBuilding.buildingType)
				{
				case 13:
					levels.applesLevel += (double)this.calcResourceLevel(villageMapBuilding, num);
					break;
				case 14:
					levels.breadLevel += (double)this.calcResourceLevel(villageMapBuilding, num);
					break;
				case 15:
					levels.vegLevel += (double)this.calcResourceLevel(villageMapBuilding, num);
					break;
				case 16:
					levels.meatLevel += (double)this.calcResourceLevel(villageMapBuilding, num);
					break;
				case 17:
					levels.cheeseLevel += (double)this.calcResourceLevel(villageMapBuilding, num);
					break;
				case 18:
					levels.fishLevel += (double)this.calcResourceLevel(villageMapBuilding, num);
					break;
				}
			}
			double num2 = num + (VillageMap.baseServerTime - this.m_consumptionLastTime).TotalSeconds;
			if (this.m_applesConsumption > 0.0)
			{
				levels.applesLevel -= 1.0 / this.m_applesConsumption * num2;
			}
			if (this.m_breadConsumption > 0.0)
			{
				levels.breadLevel -= 1.0 / this.m_breadConsumption * num2;
			}
			if (this.m_cheeseConsumption > 0.0)
			{
				levels.cheeseLevel -= 1.0 / this.m_cheeseConsumption * num2;
			}
			if (this.m_meatConsumption > 0.0)
			{
				levels.meatLevel -= 1.0 / this.m_meatConsumption * num2;
			}
			if (this.m_vegConsumption > 0.0)
			{
				levels.vegLevel -= 1.0 / this.m_vegConsumption * num2;
			}
			if (this.m_fishConsumption > 0.0)
			{
				levels.fishLevel -= 1.0 / this.m_fishConsumption * num2;
			}
			levels.applesLevel = Math.Floor(levels.applesLevel);
			levels.breadLevel = Math.Floor(levels.breadLevel);
			levels.cheeseLevel = Math.Floor(levels.cheeseLevel);
			levels.meatLevel = Math.Floor(levels.meatLevel);
			levels.vegLevel = Math.Floor(levels.vegLevel);
			levels.fishLevel = Math.Floor(levels.fishLevel);
			if (levels.applesLevel < 0.0)
			{
				levels.applesLevel = 0.0;
			}
			if (levels.breadLevel < 0.0)
			{
				levels.breadLevel = 0.0;
			}
			if (levels.cheeseLevel < 0.0)
			{
				levels.cheeseLevel = 0.0;
			}
			if (levels.meatLevel < 0.0)
			{
				levels.meatLevel = 0.0;
			}
			if (levels.vegLevel < 0.0)
			{
				levels.vegLevel = 0.0;
			}
			if (levels.fishLevel < 0.0)
			{
				levels.fishLevel = 0.0;
			}
			levels.applesLevel = this.capResource(13, levels.applesLevel);
			levels.breadLevel = this.capResource(14, levels.breadLevel);
			levels.meatLevel = this.capResource(16, levels.meatLevel);
			levels.cheeseLevel = this.capResource(17, levels.cheeseLevel);
			levels.vegLevel = this.capResource(15, levels.vegLevel);
			levels.fishLevel = this.capResource(18, levels.fishLevel);
			return true;
		}

		// Token: 0x06002E25 RID: 11813 RVA: 0x0024E1F4 File Offset: 0x0024C3F4
		public bool getInnLevels(VillageMap.InnLevels levels)
		{
			if (this.findBuildingType(35) == null)
			{
				return false;
			}
			levels.aleLevel = this.m_aleLevel;
			double num = (DXTimer.GetCurrentMilliseconds() - VillageMap.localBaseTime) / 1000.0;
			foreach (VillageMapBuilding villageMapBuilding in this.localBuildings)
			{
				int buildingType = villageMapBuilding.buildingType;
				if (buildingType == 12)
				{
					levels.aleLevel += (double)this.calcResourceLevel(villageMapBuilding, num);
				}
			}
			double num2 = num + (VillageMap.baseServerTime - this.m_consumptionLastTime).TotalSeconds;
			if (this.m_aleConsumption > 0.0)
			{
				levels.aleLevel -= 1.0 / this.m_aleConsumption * num2;
			}
			levels.aleLevel = Math.Floor(levels.aleLevel);
			if (levels.aleLevel < 0.0)
			{
				levels.aleLevel = 0.0;
			}
			levels.aleLevel = this.capResource(12, levels.aleLevel);
			return true;
		}

		// Token: 0x06002E26 RID: 11814 RVA: 0x0024E324 File Offset: 0x0024C524
		public bool getTownHallLevels(VillageMap.TownHallLevels levels)
		{
			if (this.findBuildingType(0) == null)
			{
				return false;
			}
			levels.clothesLevel = this.m_clothesLevel;
			levels.furnitureLevel = this.m_furnitureLevel;
			levels.spicesLevel = this.m_spicesLevel;
			levels.silkLevel = this.m_silkLevel;
			levels.metalwareLevel = this.m_metalwareLevel;
			levels.saltLevel = this.m_saltLevel;
			levels.venisonLevel = this.m_venisonLevel;
			levels.wineLevel = this.m_wineLevel;
			double localTimeLapsed = (DXTimer.GetCurrentMilliseconds() - VillageMap.localBaseTime) / 1000.0;
			foreach (VillageMapBuilding villageMapBuilding in this.localBuildings)
			{
				switch (villageMapBuilding.buildingType)
				{
				case 19:
					levels.clothesLevel += (double)this.calcResourceLevel(villageMapBuilding, localTimeLapsed);
					break;
				case 21:
					levels.furnitureLevel += (double)this.calcResourceLevel(villageMapBuilding, localTimeLapsed);
					break;
				case 22:
					levels.venisonLevel += (double)this.calcResourceLevel(villageMapBuilding, localTimeLapsed);
					break;
				case 23:
					levels.saltLevel += (double)this.calcResourceLevel(villageMapBuilding, localTimeLapsed);
					break;
				case 24:
					levels.spicesLevel += (double)this.calcResourceLevel(villageMapBuilding, localTimeLapsed);
					break;
				case 25:
					levels.silkLevel += (double)this.calcResourceLevel(villageMapBuilding, localTimeLapsed);
					break;
				case 26:
					levels.metalwareLevel += (double)this.calcResourceLevel(villageMapBuilding, localTimeLapsed);
					break;
				case 33:
					levels.wineLevel += (double)this.calcResourceLevel(villageMapBuilding, localTimeLapsed);
					break;
				}
			}
			levels.saltLevel = this.capResource(23, levels.saltLevel);
			levels.venisonLevel = this.capResource(22, levels.venisonLevel);
			levels.wineLevel = this.capResource(33, levels.wineLevel);
			levels.spicesLevel = this.capResource(24, levels.spicesLevel);
			levels.silkLevel = this.capResource(25, levels.silkLevel);
			levels.metalwareLevel = this.capResource(26, levels.metalwareLevel);
			levels.furnitureLevel = this.capResource(21, levels.furnitureLevel);
			levels.clothesLevel = this.capResource(19, levels.clothesLevel);
			return true;
		}

		// Token: 0x06002E27 RID: 11815 RVA: 0x0024E5BC File Offset: 0x0024C7BC
		public void monitorWeaponProduction()
		{
			if (GameEngine.Instance.World.isCapital(this.m_villageID))
			{
				return;
			}
			DateTime now = DateTime.Now;
			if ((now - this.weaponProductionLastTimeRequest).TotalMinutes < 5.0)
			{
				return;
			}
			bool flag = false;
			DateTime currentServerTime = VillageMap.getCurrentServerTime();
			if (this.m_toBeMade_Bows > 0.0 || this.m_toBeMade_Pikes > 0.0 || this.m_toBeMade_Swords > 0.0 || this.m_toBeMade_Armour > 0.0 || this.m_toBeMade_Catapults > 0.0)
			{
				if (this.m_toBeMade_Bows > 0.0 && this.m_productionRate_Bows > 0.0 && currentServerTime > this.m_productionEnd_Bows.AddSeconds(2.0))
				{
					this.m_bowsLevel += this.m_toBeMade_Bows;
					this.m_toBeMade_Bows = 0.0;
					flag = true;
				}
				if (this.m_toBeMade_Pikes > 0.0 && this.m_productionRate_Pikes > 0.0 && currentServerTime > this.m_productionEnd_Pikes.AddSeconds(2.0))
				{
					this.m_pikesLevel += this.m_toBeMade_Pikes;
					this.m_toBeMade_Pikes = 0.0;
					flag = true;
				}
				if (this.m_toBeMade_Swords > 0.0 && this.m_productionRate_Swords > 0.0 && currentServerTime > this.m_productionEnd_Swords.AddSeconds(2.0))
				{
					this.m_swordsLevel += this.m_toBeMade_Swords;
					this.m_toBeMade_Swords = 0.0;
					flag = true;
				}
				if (this.m_toBeMade_Armour > 0.0 && this.m_productionRate_Armour > 0.0 && currentServerTime > this.m_productionEnd_Armour.AddSeconds(2.0))
				{
					this.m_armourLevel += this.m_toBeMade_Armour;
					this.m_toBeMade_Armour = 0.0;
					flag = true;
				}
				if (this.m_toBeMade_Catapults > 0.0 && this.m_productionRate_Catapults > 0.0 && currentServerTime > this.m_productionEnd_Catapults.AddSeconds(2.0))
				{
					this.m_catapultsLevel += this.m_toBeMade_Catapults;
					this.m_toBeMade_Catapults = 0.0;
					flag = true;
				}
			}
			if (flag && !this.ViewOnly)
			{
				this.weaponProductionLastTimeRequest = now;
				RemoteServices.Instance.set_UpdateVillageResourcesInfo_UserCallBack(new RemoteServices.UpdateVillageResourcesInfo_UserCallBack(this.updateVillageResourcesInfoCallback));
				RemoteServices.Instance.UpdateVillageResourcesInfo(this.m_villageID);
			}
		}

		// Token: 0x06002E28 RID: 11816 RVA: 0x0024E88C File Offset: 0x0024CA8C
		public void updateVillageResourcesInfoCallback(UpdateVillageResourcesInfo_ReturnType returnData)
		{
			if (returnData.Success)
			{
				VillageMap village = GameEngine.Instance.getVillage(returnData.villageID);
				if (village != null)
				{
					village.importResourcesAndStats(returnData.villageResourcesAndStats, returnData.currentTime);
				}
				VillageMap.setServerTime(returnData.currentTime);
				GameEngine.Instance.World.setGoldData(returnData.currentGoldLevel, returnData.currentGoldRate);
				GameEngine.Instance.World.setHonourData(returnData.currentHonourLevel, returnData.currentHonourRate);
			}
		}

		// Token: 0x06002E29 RID: 11817 RVA: 0x0024E90C File Offset: 0x0024CB0C
		public bool getArmouryLevels(VillageMap.ArmouryLevels levels)
		{
			levels.bowsLevel = this.m_bowsLevel;
			levels.pikesLevel = this.m_pikesLevel;
			levels.swordsLevel = this.m_swordsLevel;
			levels.armourLevel = this.m_armourLevel;
			levels.catapultsLevel = this.m_catapultsLevel;
			if (this.m_toBeMade_Bows > 0.0 || this.m_toBeMade_Pikes > 0.0 || this.m_toBeMade_Swords > 0.0 || this.m_toBeMade_Armour > 0.0 || this.m_toBeMade_Catapults > 0.0)
			{
				double num = (DXTimer.GetCurrentMilliseconds() - VillageMap.localBaseTime) / 1000.0;
				DateTime t = VillageMap.baseServerTime + new TimeSpan(0, 0, (int)num);
				if (this.m_toBeMade_Bows > 0.0 && this.m_productionRate_Bows > 0.0)
				{
					if (t >= this.m_productionEnd_Bows)
					{
						levels.bowsLevel += this.m_toBeMade_Bows;
					}
					else
					{
						double num2 = (VillageMap.baseServerTime - this.m_productionStart_Bows).TotalSeconds + num;
						double num3 = this.m_productionRate_Bows * num2;
						levels.bowsLevel += num3;
						levels.bowsLevel = Math.Floor(levels.bowsLevel);
						levels.bowsLeftToMake = (int)(this.m_toBeMade_Bows - num3 + 0.999999);
					}
				}
				else
				{
					levels.bowsLeftToMake = (int)this.m_toBeMade_Bows;
				}
				if (this.m_toBeMade_Pikes > 0.0 && this.m_productionRate_Pikes > 0.0)
				{
					if (t >= this.m_productionEnd_Pikes)
					{
						levels.pikesLevel += this.m_toBeMade_Pikes;
					}
					else
					{
						double num4 = (VillageMap.baseServerTime - this.m_productionStart_Pikes).TotalSeconds + num;
						double num5 = this.m_productionRate_Pikes * num4;
						levels.pikesLevel += num5;
						levels.pikesLevel = Math.Floor(levels.pikesLevel);
						levels.pikesLeftToMake = (int)(this.m_toBeMade_Pikes - num5 + 0.999999);
					}
				}
				else
				{
					levels.pikesLeftToMake = (int)this.m_toBeMade_Pikes;
				}
				if (this.m_toBeMade_Swords > 0.0 && this.m_productionRate_Swords > 0.0)
				{
					if (t >= this.m_productionEnd_Swords)
					{
						levels.swordsLevel += this.m_toBeMade_Swords;
					}
					else
					{
						double num6 = (VillageMap.baseServerTime - this.m_productionStart_Swords).TotalSeconds + num;
						double num7 = this.m_productionRate_Swords * num6;
						levels.swordsLevel += num7;
						levels.swordsLevel = Math.Floor(levels.swordsLevel);
						levels.swordsLeftToMake = (int)(this.m_toBeMade_Swords - num7 + 0.999999);
					}
				}
				else
				{
					levels.swordsLeftToMake = (int)this.m_toBeMade_Swords;
				}
				if (this.m_toBeMade_Armour > 0.0 && this.m_productionRate_Armour > 0.0)
				{
					if (t >= this.m_productionEnd_Armour)
					{
						levels.armourLevel += this.m_toBeMade_Armour;
					}
					else
					{
						double num8 = (VillageMap.baseServerTime - this.m_productionStart_Armour).TotalSeconds + num;
						double num9 = this.m_productionRate_Armour * num8;
						levels.armourLevel += num9;
						levels.armourLevel = Math.Floor(levels.armourLevel);
						levels.armourLeftToMake = (int)(this.m_toBeMade_Armour - num9 + 0.999999);
					}
				}
				else
				{
					levels.armourLeftToMake = (int)this.m_toBeMade_Armour;
				}
				if (this.m_toBeMade_Catapults > 0.0 && this.m_productionRate_Catapults > 0.0)
				{
					if (t >= this.m_productionEnd_Catapults)
					{
						levels.catapultsLevel += this.m_toBeMade_Catapults;
					}
					else
					{
						double num10 = (VillageMap.baseServerTime - this.m_productionStart_Catapults).TotalSeconds + num;
						double num11 = this.m_productionRate_Catapults * num10;
						levels.catapultsLevel += num11;
						levels.catapultsLevel = Math.Floor(levels.catapultsLevel);
						levels.catapultsLeftToMake = (int)(this.m_toBeMade_Catapults - num11 + 0.999999);
					}
				}
				else
				{
					levels.catapultsLeftToMake = (int)this.m_toBeMade_Catapults;
				}
			}
			levels.bowsLevel = this.capResource(29, levels.bowsLevel);
			levels.pikesLevel = this.capResource(28, levels.pikesLevel);
			levels.swordsLevel = this.capResource(30, levels.swordsLevel);
			levels.armourLevel = this.capResource(31, levels.armourLevel);
			levels.catapultsLevel = this.capResource(32, levels.catapultsLevel);
			return true;
		}

		// Token: 0x06002E2A RID: 11818 RVA: 0x00021B92 File Offset: 0x0001FD92
		public int getWeaponsPerDayValue(VillageMapBuilding building)
		{
			return (int)this.getWeaponsPerDayValueD(building);
		}

		// Token: 0x06002E2B RID: 11819 RVA: 0x0024EDE4 File Offset: 0x0024CFE4
		public double getWeaponsPerDayValueD(VillageMapBuilding building)
		{
			VillageMapBuilding villageMapBuilding = this.findBuildingType(4);
			VillageMapBuilding villageMapBuilding2 = this.findBuildingType(2);
			if (villageMapBuilding == null || villageMapBuilding2 == null)
			{
				return 0.0;
			}
			double result = 0.0;
			switch (building.buildingType)
			{
			case 28:
				result = this.m_productionRate_Pikes * 86400.0;
				break;
			case 29:
				result = this.m_productionRate_Bows * 86400.0;
				break;
			case 30:
				result = this.m_productionRate_Swords * 86400.0;
				break;
			case 31:
				result = this.m_productionRate_Armour * 86400.0;
				break;
			case 32:
				result = this.m_productionRate_Catapults * 86400.0;
				break;
			}
			return result;
		}

		// Token: 0x06002E2C RID: 11820 RVA: 0x0024EEA0 File Offset: 0x0024D0A0
		public int calcResourceLevel(VillageMapBuilding building, double localTimeLapsed)
		{
			int num = (int)building.lastDataLevel;
			if (building.calcRate != 0.0 && building.complete)
			{
				double num2 = localTimeLapsed + (VillageMap.baseServerTime - building.lastCalcTime).TotalSeconds + building.serverJourneyTime;
				double num3 = num2 / building.calcRate;
				int num4 = (int)num3;
				double num5 = CardTypes.adjustPayloadSize(GameEngine.Instance.cardsManager.UserCardData, GameEngine.Instance.LocalWorldData.getPayloadSize(building.buildingType), building.buildingType);
				int num6 = (int)((double)num4 * num5);
				num += num6;
			}
			return num;
		}

		// Token: 0x06002E2D RID: 11821 RVA: 0x0024EF3C File Offset: 0x0024D13C
		public double getDistanceThroughCycle(VillageMapBuilding building)
		{
			if (building.calcRate != 0.0 && building.complete)
			{
				double num = (DXTimer.GetCurrentMilliseconds() - VillageMap.localBaseTime) / 1000.0;
				double num2 = num + (VillageMap.baseServerTime - building.lastCalcTime).TotalSeconds;
				double num3 = num2 / building.calcRate;
				int num4 = (int)num3;
				return (num2 - (double)num4 * building.calcRate) / building.calcRate;
			}
			return 0.0;
		}

		// Token: 0x06002E2E RID: 11822 RVA: 0x0024EFBC File Offset: 0x0024D1BC
		public double getDistanceThroughCycleSecondary(VillageMapBuilding building)
		{
			if (building.calcRate != 0.0 && building.complete)
			{
				double num = (DXTimer.GetCurrentMilliseconds() - VillageMap.localBaseTime) / 1000.0;
				DateTime d = DateTime.Now;
				switch (building.buildingType)
				{
				case 28:
					d = this.m_productionEnd_Pikes;
					break;
				case 29:
					d = this.m_productionEnd_Bows;
					break;
				case 30:
					d = this.m_productionEnd_Swords;
					break;
				case 31:
					d = this.m_productionEnd_Armour;
					break;
				case 32:
					d = this.m_productionEnd_Catapults;
					break;
				}
				double num2 = (d - VillageMap.baseServerTime).TotalSeconds - num;
				double num3 = num2 / building.calcRate;
				int num4 = (int)num3;
				return (building.calcRate - (num2 - (double)num4 * building.calcRate)) / building.calcRate;
			}
			return 0.0;
		}

		// Token: 0x06002E2F RID: 11823 RVA: 0x0024F0A0 File Offset: 0x0024D2A0
		public double getJourneyTime(Point newStartPos, Point newEndPos)
		{
			Point startPoint = new Point(newStartPos.X, newStartPos.Y);
			Point endPoint = new Point(newEndPos.X, newEndPos.Y);
			startPoint.X *= 32;
			startPoint.Y *= 16;
			startPoint.Y += 8;
			endPoint.X *= 32;
			endPoint.Y *= 16;
			endPoint.Y += 8;
			return VillageBuildingsData.calcTravelTime(GameEngine.Instance.LocalWorldData, startPoint, endPoint).TotalSeconds;
		}

		// Token: 0x06002E30 RID: 11824 RVA: 0x0024F150 File Offset: 0x0024D350
		public double capResource(int buildingType, double level)
		{
			return GameEngine.Instance.World.UserResearchData.capResource(GameEngine.Instance.LocalWorldData, buildingType, level, GameEngine.Instance.cardsManager.UserCardData, GameEngine.Instance.World.isCapital(this.m_villageID));
		}

		// Token: 0x06002E31 RID: 11825 RVA: 0x0024F1A4 File Offset: 0x0024D3A4
		public double getResourceLevel(int buildingType)
		{
			switch (buildingType)
			{
			case 6:
			case 7:
			case 8:
			case 9:
			{
				VillageMap.StockpileLevels stockpileLevels = new VillageMap.StockpileLevels();
				this.getStockpileLevels(stockpileLevels);
				switch (buildingType)
				{
				case 6:
					return this.capResource(buildingType, stockpileLevels.woodLevel);
				case 7:
					return this.capResource(buildingType, stockpileLevels.stoneLevel);
				case 8:
					return this.capResource(buildingType, stockpileLevels.ironLevel);
				case 9:
					return this.capResource(buildingType, stockpileLevels.pitchLevel);
				}
				break;
			}
			case 12:
			{
				VillageMap.InnLevels innLevels = new VillageMap.InnLevels();
				this.getInnLevels(innLevels);
				return this.capResource(buildingType, innLevels.aleLevel);
			}
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			{
				VillageMap.GranaryLevels granaryLevels = new VillageMap.GranaryLevels();
				this.getGranaryLevels(granaryLevels);
				switch (buildingType)
				{
				case 13:
					return this.capResource(buildingType, granaryLevels.applesLevel);
				case 14:
					return this.capResource(buildingType, granaryLevels.breadLevel);
				case 15:
					return this.capResource(buildingType, granaryLevels.vegLevel);
				case 16:
					return this.capResource(buildingType, granaryLevels.meatLevel);
				case 17:
					return this.capResource(buildingType, granaryLevels.cheeseLevel);
				case 18:
					return this.capResource(buildingType, granaryLevels.fishLevel);
				}
				break;
			}
			case 19:
			case 21:
			case 22:
			case 23:
			case 24:
			case 25:
			case 26:
			case 33:
			{
				VillageMap.TownHallLevels townHallLevels = new VillageMap.TownHallLevels();
				this.getTownHallLevels(townHallLevels);
				switch (buildingType)
				{
				case 19:
					return this.capResource(buildingType, townHallLevels.clothesLevel);
				case 21:
					return this.capResource(buildingType, townHallLevels.furnitureLevel);
				case 22:
					return this.capResource(buildingType, townHallLevels.venisonLevel);
				case 23:
					return this.capResource(buildingType, townHallLevels.saltLevel);
				case 24:
					return this.capResource(buildingType, townHallLevels.spicesLevel);
				case 25:
					return this.capResource(buildingType, townHallLevels.silkLevel);
				case 26:
					return this.capResource(buildingType, townHallLevels.metalwareLevel);
				case 33:
					return this.capResource(buildingType, townHallLevels.wineLevel);
				}
				break;
			}
			case 28:
			case 29:
			case 30:
			case 31:
			case 32:
			{
				VillageMap.ArmouryLevels armouryLevels = new VillageMap.ArmouryLevels();
				this.getArmouryLevels(armouryLevels);
				switch (buildingType)
				{
				case 28:
					return this.capResource(buildingType, armouryLevels.pikesLevel);
				case 29:
					return this.capResource(buildingType, armouryLevels.bowsLevel);
				case 30:
					return this.capResource(buildingType, armouryLevels.swordsLevel);
				case 31:
					return this.capResource(buildingType, armouryLevels.armourLevel);
				case 32:
					return this.capResource(buildingType, armouryLevels.catapultsLevel);
				}
				break;
			}
			}
			return 0.0;
		}

		// Token: 0x06002E32 RID: 11826 RVA: 0x0024F480 File Offset: 0x0024D680
		public double getResourceProductionPerDay(int buildingType)
		{
			double num = 0.0;
			foreach (VillageMapBuilding villageMapBuilding in this.localBuildings)
			{
				if (villageMapBuilding.buildingType == buildingType && villageMapBuilding.calcRate != 0.0 && villageMapBuilding.complete)
				{
					num += 86400.0 / villageMapBuilding.calcRate;
				}
			}
			double num2 = CardTypes.adjustPayloadSize(GameEngine.Instance.cardsManager.UserCardData, GameEngine.Instance.LocalWorldData.getPayloadSize(buildingType), buildingType);
			return num * num2;
		}

		// Token: 0x06002E33 RID: 11827 RVA: 0x0024F534 File Offset: 0x0024D734
		public double getFoodProductionPerDay()
		{
			double num = 0.0;
			foreach (VillageMapBuilding villageMapBuilding in this.localBuildings)
			{
				int buildingType = villageMapBuilding.buildingType;
				if (buildingType - 13 <= 5 && villageMapBuilding.calcRate != 0.0 && villageMapBuilding.complete)
				{
					double num2 = CardTypes.adjustPayloadSize(GameEngine.Instance.cardsManager.UserCardData, GameEngine.Instance.LocalWorldData.getPayloadSize(villageMapBuilding.buildingType), villageMapBuilding.buildingType);
					num += 86400.0 / villageMapBuilding.calcRate * num2;
				}
			}
			return num;
		}

		// Token: 0x06002E34 RID: 11828 RVA: 0x0024F5FC File Offset: 0x0024D7FC
		public double getAleProductionPerDay()
		{
			double num = 0.0;
			foreach (VillageMapBuilding villageMapBuilding in this.localBuildings)
			{
				int buildingType = villageMapBuilding.buildingType;
				if (buildingType == 12 && villageMapBuilding.calcRate != 0.0 && villageMapBuilding.complete)
				{
					double num2 = CardTypes.adjustPayloadSize(GameEngine.Instance.cardsManager.UserCardData, GameEngine.Instance.LocalWorldData.getPayloadSize(villageMapBuilding.buildingType), villageMapBuilding.buildingType);
					num += 86400.0 / villageMapBuilding.calcRate * num2;
				}
			}
			return num;
		}

		// Token: 0x06002E35 RID: 11829 RVA: 0x0024F6C0 File Offset: 0x0024D8C0
		public double getHonourFromJusticePerDay()
		{
			double num = 0.0;
			VillageMapBuilding villageMapBuilding = this.findBuildingType(0);
			WorldData localWorldData = GameEngine.Instance.LocalWorldData;
			if (villageMapBuilding != null)
			{
				foreach (VillageMapBuilding villageMapBuilding2 in this.Buildings)
				{
					if (villageMapBuilding2.isComplete())
					{
						double num2 = 0.0;
						switch (villageMapBuilding2.buildingType)
						{
						case 61:
							num2 = localWorldData.HonourBuilding_Stocks;
							break;
						case 62:
							num2 = localWorldData.HonourBuilding_BurningPost;
							break;
						case 63:
							num2 = localWorldData.HonourBuilding_Gibbet;
							break;
						case 64:
							num2 = localWorldData.HonourBuilding_Rack;
							break;
						}
						if (num2 != 0.0)
						{
							double num3 = VillageBuildingsData.calcHonourRateBasedOnDistance(num2, villageMapBuilding.buildingLocation, villageMapBuilding2.buildingLocation);
							num += num3;
						}
					}
				}
			}
			CardTypes.getPopToHonourFromCards(GameEngine.Instance.cardsManager.UserCardData);
			if (GameEngine.Instance.World.ThirdAgeWorld)
			{
				num *= 4.0;
			}
			return num;
		}

		// Token: 0x06002E36 RID: 11830 RVA: 0x0024F7F0 File Offset: 0x0024D9F0
		public int numBuildingsOfType(int buildingType)
		{
			int num = 0;
			foreach (VillageMapBuilding villageMapBuilding in this.localBuildings)
			{
				if (villageMapBuilding.buildingType == buildingType)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06002E37 RID: 11831 RVA: 0x0024F84C File Offset: 0x0024DA4C
		public int numWorkingBuildingsOfType(int buildingType)
		{
			int num = 0;
			foreach (VillageMapBuilding villageMapBuilding in this.localBuildings)
			{
				if (villageMapBuilding.buildingType == buildingType && villageMapBuilding.calcRate > 0.0)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06002E38 RID: 11832 RVA: 0x00021B9C File Offset: 0x0001FD9C
		public int numParishFlags()
		{
			return this.m_numParishFlags;
		}

		// Token: 0x06002E39 RID: 11833 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public static void closePopups()
		{
		}

		// Token: 0x06002E3A RID: 11834 RVA: 0x00021BA4 File Offset: 0x0001FDA4
		public void changeStats(int taxChange, int rationsChange, int aleChange)
		{
			this.changeStats(taxChange, rationsChange, aleChange, 0);
		}

		// Token: 0x06002E3B RID: 11835 RVA: 0x0024F8BC File Offset: 0x0024DABC
		public void changeStats(int taxChange, int rationsChange, int aleChange, int capitalTaxChange)
		{
			if (GameEngine.Instance.World.WorldEnded)
			{
				return;
			}
			if (taxChange != 0)
			{
				this.m_taxLevel += taxChange;
				int maxTaxLevel = CardTypes.getMaxTaxLevel(GameEngine.Instance.cardsManager.UserCardData);
				if (this.m_taxLevel < 0)
				{
					this.m_taxLevel = 0;
				}
				else if (this.m_taxLevel > maxTaxLevel)
				{
					this.m_taxLevel = maxTaxLevel;
				}
			}
			if (rationsChange != 0)
			{
				this.m_rationsLevel += rationsChange;
				if (this.m_rationsLevel < 0)
				{
					this.m_rationsLevel = 0;
				}
				else if (this.m_rationsLevel > 6)
				{
					this.m_rationsLevel = 6;
				}
			}
			if (aleChange != 0)
			{
				this.m_aleRationsLevel += aleChange;
				if (this.m_aleRationsLevel < 0)
				{
					this.m_aleRationsLevel = 0;
				}
				else if (this.m_aleRationsLevel > 4)
				{
					this.m_aleRationsLevel = 4;
				}
			}
			if (capitalTaxChange != 0)
			{
				this.m_capitalTaxRate += capitalTaxChange;
				if (GameEngine.Instance.LocalWorldData.Alternate_Ruleset == 1)
				{
					if (this.m_capitalTaxRate < -3)
					{
						this.m_capitalTaxRate = -3;
					}
					else if (this.m_capitalTaxRate > 50)
					{
						this.m_capitalTaxRate = 50;
					}
				}
				else if (this.m_capitalTaxRate < -3)
				{
					this.m_capitalTaxRate = -3;
				}
				else if (this.m_capitalTaxRate > 9)
				{
					this.m_capitalTaxRate = 9;
				}
			}
			this.m_showEffective = true;
			this.m_showAleEffective = true;
			if (this.m_taxLevel != this.m_taxLevelServer || this.m_rationsLevel != this.m_rationsLevelServer || this.m_aleRationsLevel != this.m_aleRationsLevelServer || this.m_capitalTaxRate != this.m_capitalTaxRateServer)
			{
				this.m_statsChangeTime = DXTimer.GetCurrentMilliseconds();
				if (this.m_rationsLevel != this.m_rationsLevelServer)
				{
					this.m_showEffective = false;
				}
				if (this.m_aleRationsLevel != this.m_aleRationsLevelServer)
				{
					this.m_showAleEffective = false;
				}
			}
			else
			{
				this.m_statsChangeTime = 0.0;
			}
			this.showStats();
		}

		// Token: 0x06002E3C RID: 11836 RVA: 0x0024FA90 File Offset: 0x0024DC90
		public void updateStats()
		{
			if (this.m_statsChangeTime != 0.0)
			{
				double num = DXTimer.GetCurrentMilliseconds() - this.m_statsChangeTime;
				if (num > 1000.0)
				{
					if (this.m_taxLevel != this.m_taxLevelServer)
					{
						GameEngine.Instance.World.handleQuestObjectiveHappening(10003);
					}
					RemoteServices.Instance.set_VillageBuildingChangeRates_UserCallBack(new RemoteServices.VillageBuildingChangeRates_UserCallBack(this.villageBuildingChangeRatesCallback));
					RemoteServices.Instance.VillageBuildingChangeRates(this.m_villageID, this.m_taxLevel, this.m_rationsLevel, this.m_aleRationsLevel, this.m_capitalTaxRate);
					this.m_taxLevelSent = this.m_taxLevel;
					this.m_rationsLevelSent = this.m_rationsLevel;
					this.m_aleRationsLevelSent = this.m_aleRationsLevel;
					this.m_capitalTaxRateSent = this.m_capitalTaxRate;
					this.m_statsChangeTime = 0.0;
				}
			}
			this.showStats();
		}

		// Token: 0x06002E3D RID: 11837 RVA: 0x0024FB74 File Offset: 0x0024DD74
		public void villageBuildingChangeRatesCallback(VillageBuildingChangeRates_ReturnType returnData)
		{
			if (returnData.Success)
			{
				VillageMap village = GameEngine.Instance.getVillage(returnData.villageID);
				if (village != null)
				{
					village.importResourcesAndStats(returnData.villageResourcesAndStats, returnData.currentTime);
					VillageMap.setServerTime(returnData.currentTime);
					if (returnData.villageBuildings != null)
					{
						foreach (VillageMapBuilding villageMapBuilding in village.Buildings)
						{
							foreach (VillageBuildingReturnData villageBuildingReturnData in returnData.villageBuildings)
							{
								if (villageMapBuilding.buildingID == villageBuildingReturnData.buildingID)
								{
									villageMapBuilding.createFromReturnData(villageBuildingReturnData);
									villageMapBuilding.initStorageBuilding(this.gfx, this);
									villageMapBuilding.updateSymbolGFX();
									break;
								}
							}
						}
					}
				}
				GameEngine.Instance.World.setGoldData(returnData.currentGoldLevel, returnData.currentGoldRate);
				GameEngine.Instance.World.setHonourData(returnData.currentHonourLevel, returnData.currentHonourRate);
				return;
			}
			ControlForm controlForm = DX.ControlForm;
			if (controlForm == null)
			{
				return;
			}
			controlForm.Log(ErrorCodes.getErrorString(returnData.m_errorCode, returnData.m_errorID) + ". Village " + GameEngine.Instance.World.getVillageName(returnData.villageID), ControlForm.Tab.Refresh, true);
		}

		// Token: 0x06002E3E RID: 11838 RVA: 0x00021BB0 File Offset: 0x0001FDB0
		public void produceWeaponsCallback(VillageProduceWeapons_ReturnType returnData)
		{
			if (returnData.Success)
			{
				VillageMap village = GameEngine.Instance.getVillage(returnData.villageID);
				if (village != null)
				{
					village.importResourcesAndStats(returnData.villageResourcesAndStats, returnData.currentTime);
				}
				VillageMap.setServerTime(returnData.currentTime);
			}
		}

		// Token: 0x06002E3F RID: 11839 RVA: 0x0024FCE8 File Offset: 0x0024DEE8
		public void holdBanquetCallback(VillageHoldBanquet_ReturnType returnData)
		{
			if (returnData.Success)
			{
				VillageMap village = GameEngine.Instance.getVillage(returnData.villageID);
				if (village != null)
				{
					village.importResourcesAndStats(returnData.villageResourcesAndStats, returnData.currentTime);
				}
				VillageMap.setServerTime(returnData.currentTime);
				GameEngine.Instance.World.setHonourData(returnData.currentHonourLevel, returnData.currentHonourRate);
				this.banqueting.banquetCallback(returnData);
				return;
			}
			ControlForm controlForm = DX.ControlForm;
			if (controlForm == null)
			{
				return;
			}
			controlForm.Log(ErrorCodes.getErrorString(returnData.m_errorCode, returnData.m_errorID) + " Village " + GameEngine.Instance.World.getVillageName(returnData.villageID), ControlForm.Tab.Banquetting, true);
		}

		// Token: 0x06002E40 RID: 11840 RVA: 0x0024FD98 File Offset: 0x0024DF98
		public void showStats()
		{
			if (this.m_villageID != InterfaceMgr.Instance.OwnSelectedVillage)
			{
				return;
			}
			DateTime now = DateTime.Now;
			TimeSpan timeSpan = now - this.m_villageInfoUpdateLastTime;
			string timeLeftString = "";
			string migrationTimeString = "";
			bool flag = false;
			double value = (DXTimer.GetCurrentMilliseconds() - VillageMap.localBaseTime) / 1000.0;
			DateTime dateTime = VillageMap.baseServerTime.AddSeconds(value);
			if (!GameEngine.Instance.World.isCapital(this.m_villageID))
			{
				bool flag2 = false;
				if (this.m_totalPeople >= this.m_housingCapacity && this.m_popularityLevel > 0)
				{
					flag2 = true;
				}
				else if (this.m_totalPeople <= 4 && this.m_popularityLevel < 0)
				{
					flag2 = true;
				}
				if (this.m_popularityLevel != 0 && !flag2)
				{
					double num = (this.m_immigrationNextChangeTime - dateTime).TotalSeconds + 3.0;
					if (num > 0.0)
					{
						num -= 3.0;
						if (num > 0.0)
						{
							migrationTimeString = VillageMap.createBuildTimeString((int)num);
							this.m_statsMigrationUpdateRequested = false;
						}
					}
					else if (!this.m_statsMigrationUpdateRequested)
					{
						this.m_statsMigrationUpdateRequested = true;
						if (!this.ViewOnly && timeSpan.TotalSeconds > 30.0)
						{
							this.m_villageInfoUpdateLastTime = now;
							RemoteServices.Instance.set_VillageBuildingChangeRates_UserCallBack(new RemoteServices.VillageBuildingChangeRates_UserCallBack(this.villageBuildingChangeRatesCallback));
							RemoteServices.Instance.VillageBuildingChangeRates(this.m_villageID, -1, -1, -1, -1);
						}
						flag = true;
					}
				}
				else
				{
					this.m_statsMigrationUpdateRequested = false;
				}
			}
			if (this.m_consumptionChangeTimeNeeded)
			{
				double totalSeconds = (this.m_consumptionChangeTime - dateTime).TotalSeconds;
				if (totalSeconds > 0.0)
				{
					this.m_statsConsumptionUpdateRequested = false;
				}
				else if (!this.m_statsConsumptionUpdateRequested)
				{
					this.m_consumptionChangeTimeNeeded = false;
					this.m_statsConsumptionUpdateRequested = true;
					if (!this.ViewOnly && !GameEngine.Instance.World.isCapital(this.m_villageID) && !flag && timeSpan.TotalSeconds > 30.0)
					{
						this.m_villageInfoUpdateLastTime = now;
						RemoteServices.Instance.set_VillageBuildingChangeRates_UserCallBack(new RemoteServices.VillageBuildingChangeRates_UserCallBack(this.villageBuildingChangeRatesCallback));
						RemoteServices.Instance.VillageBuildingChangeRates(this.m_villageID, -1, -1, -1, -1);
					}
					flag = true;
				}
			}
			else
			{
				this.m_statsConsumptionUpdateRequested = false;
			}
			PopEventData[] popEvents = this.m_popEvents;
			foreach (PopEventData popEventData in popEvents)
			{
				if (popEventData.eventID >= 0)
				{
					double num2 = (popEventData.endTime - dateTime).TotalSeconds + 2.0;
					if (num2 < 0.0)
					{
						if (!flag)
						{
							flag = true;
							if (!this.ViewOnly && !GameEngine.Instance.World.isCapital(this.m_villageID) && timeSpan.TotalSeconds > 30.0)
							{
								this.m_villageInfoUpdateLastTime = now;
								RemoteServices.Instance.set_VillageBuildingChangeRates_UserCallBack(new RemoteServices.VillageBuildingChangeRates_UserCallBack(this.villageBuildingChangeRatesCallback));
								RemoteServices.Instance.VillageBuildingChangeRates(this.m_villageID, -1, -1, -1, -1);
							}
						}
						popEventData.eventID = -1;
					}
				}
			}
			double effectiveRationsLevel = this.m_effectiveRationsLevel;
			if (!this.m_showEffective)
			{
				effectiveRationsLevel = (double)this.m_rationsLevel;
			}
			double effectiveAleRationsLevel = this.m_effectiveAleRationsLevel;
			if (!this.m_showAleEffective)
			{
				effectiveAleRationsLevel = (double)this.m_aleRationsLevel;
			}
			double housingPopularityLevel = VillageBuildingsData.getHousingPopularityLevel(this.m_totalPeople, this.m_housingCapacity);
			int num3 = this.m_totalPeople;
			if (this.m_housingCapacity < this.m_totalPeople)
			{
				num3 = this.m_housingCapacity;
			}
			double goldDayRate = (double)num3 * VillageBuildingsData.getTaxIncomeLevel(this.m_taxLevel, GameEngine.Instance.cardsManager.UserCardData) * GameEngine.Instance.LocalWorldData.goldIncomeRate;
			decimal num4 = (decimal)this.m_effectiveRationsLevel;
			if (num4 <= 2m)
			{
				num4 /= 4m;
			}
			else if (num4 < 3m)
			{
				num4 = (num4 - 2m) / 2m + 0.5m;
			}
			else
			{
				num4 -= 2m;
			}
			decimal d = (decimal)this.m_effectiveAleRationsLevel;
			decimal value2 = this.m_totalPeople / ((decimal)GameEngine.Instance.LocalWorldData.foodConsumptionRate / 24m) * num4;
			decimal value3 = this.m_totalPeople / ((decimal)GameEngine.Instance.LocalWorldData.aleConsumptionRate / 24m) * d;
			double popularityChange = 0.0;
			double popularity = this.getPopularity();
			int parishBonus = (int)(this.m_parishCapitalResearchData.Research_Gardening + this.m_parishCapitalResearchData.Research_Justice);
			double foodProductionPerDay = this.getFoodProductionPerDay();
			double aleProductionPerDay = this.getAleProductionPerDay();
			InterfaceMgr.Instance.showVillageStats(this.m_taxLevel, this.m_rationsLevel, this.m_aleRationsLevel, (int)popularity, popularityChange, timeLeftString, migrationTimeString, effectiveRationsLevel, this.m_numFoodTypesEaten, effectiveAleRationsLevel, housingPopularityLevel, goldDayRate, (double)value2, this.m_totalPeople, this.m_housingCapacity, this.m_numPositiveBuildings, this.m_numNegativeBuildings, this.m_popEvents, (double)value3, dateTime, foodProductionPerDay, aleProductionPerDay, this.m_numPopularityBuildings, this.calcParishVillageTax());
			InterfaceMgr.Instance.showVillageStats2(this.m_preCountedChurches, this.m_preCountedChapels, this.m_preCountedCathedrals, this.m_preCountedSmallGardens, this.m_preCountedLargeGardens, this.m_preCountedSmallStatues, this.m_preCountedLargeStatues, this.m_preCountedDovecotes, this.m_preCountedStocks, this.m_preCountedBurningPosts, this.m_preCountedGibbets, this.m_preCountedRacks, this.m_lastBanquetStored, this.m_lastBanquetHonour, this.m_lastBanquetDate, 0.0, popularity, this.m_capitalTaxRate, this.calcParishCapitalTaxIncome(), this.m_parishPeople, this.m_parentCapitalTaxRate, this.m_lastCapitalTaxRate, parishBonus);
		}

		// Token: 0x06002E41 RID: 11841 RVA: 0x00250388 File Offset: 0x0024E588
		public double getPopularity()
		{
			double num = this.m_effectiveRationsLevel;
			if (!this.m_showEffective)
			{
				num = (double)this.m_rationsLevel;
			}
			double num2 = this.m_effectiveAleRationsLevel;
			if (!this.m_showAleEffective)
			{
				num2 = (double)this.m_aleRationsLevel;
			}
			decimal d = (decimal)this.m_effectiveRationsLevel;
			if (d <= 2m)
			{
				d /= 4m;
			}
			else if (d < 3m)
			{
				d = (d - 2m) / 2m + 0.5m;
			}
			else
			{
				d -= 2m;
			}
			double num3 = (double)this.m_popularityLevel;
			if (this.m_taxLevel != this.m_taxLevelServer || this.m_rationsLevel != this.m_rationsLevelServer || this.m_aleRationsLevel != this.m_aleRationsLevelServer)
			{
				num3 = 0.0;
				num3 += (double)VillageBuildingsData.getTaxPopularityLevel(this.m_taxLevel);
				double num4 = num;
				if (!this.m_showEffective)
				{
					if (this.m_effectiveRationsLevel == Math.Floor(this.m_effectiveRationsLevel) && this.m_effectiveRationsLevel == (double)this.m_rationsLevelServer)
					{
						num4 = num;
					}
					else if (this.m_effectiveRationsLevel < (double)this.m_rationsLevel)
					{
						num4 = this.m_effectiveRationsLevel;
					}
				}
				num3 += VillageBuildingsData.getRationsPopularityLevel(num4, GameEngine.Instance.LocalWorldData, GameEngine.Instance.cardsManager.UserCardData);
				if (num4 > 0.0)
				{
					num3 += VillageBuildingsData.getNumFoodTypesEatenPopularityLevel(this.m_numFoodTypesEaten);
				}
				num3 += VillageBuildingsData.getHousingPopularityLevel(this.m_totalPeople, this.m_housingCapacity);
				double aleRationsLevel = num2;
				if (!this.m_showAleEffective)
				{
					if (this.m_effectiveAleRationsLevel == Math.Floor(this.m_effectiveAleRationsLevel) && this.m_effectiveAleRationsLevel == (double)this.m_aleRationsLevelServer)
					{
						aleRationsLevel = num2;
					}
					else if (this.m_effectiveAleRationsLevel < (double)this.m_aleRationsLevel)
					{
						aleRationsLevel = this.m_effectiveAleRationsLevel;
					}
				}
				num3 += VillageBuildingsData.getAleRationsPopularityLevel(aleRationsLevel, GameEngine.Instance.LocalWorldData, GameEngine.Instance.cardsManager.UserCardData);
				num3 += VillageBuildingsData.getBuildingsTypePopularityLevel(this.m_numPositiveBuildings, this.m_numNegativeBuildings, GameEngine.Instance.cardsManager.UserCardData);
				PopEventData[] popEvents = this.m_popEvents;
				foreach (PopEventData popEventData in popEvents)
				{
					num3 += (double)popEventData.eventEffect;
				}
			}
			return num3;
		}

		// Token: 0x06002E42 RID: 11842 RVA: 0x002505DC File Offset: 0x0024E7DC
		public int getHonourMultiplier()
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			VillageMap village = GameEngine.Instance.Village;
			if (village != null)
			{
				VillageMapBuilding villageMapBuilding = village.findBuildingType(0);
				if (villageMapBuilding != null)
				{
					WorldData localWorldData = GameEngine.Instance.LocalWorldData;
					foreach (VillageMapBuilding villageMapBuilding2 in village.Buildings)
					{
						if (villageMapBuilding2.isComplete())
						{
							double num4 = 0.0;
							bool flag = false;
							bool flag2 = false;
							switch (villageMapBuilding2.buildingType)
							{
							case 34:
								flag2 = true;
								num4 = localWorldData.HonourBuilding_Chapel;
								break;
							case 36:
								flag2 = true;
								num4 = localWorldData.HonourBuilding_Church;
								break;
							case 37:
								flag2 = true;
								num4 = localWorldData.HonourBuilding_Cathedral;
								break;
							case 38:
							case 41:
							case 42:
							case 43:
							case 44:
							case 45:
								num4 = localWorldData.HonourBuilding_SmallGarden;
								break;
							case 49:
							case 50:
							case 51:
								num4 = localWorldData.HonourBuilding_LargeGarden;
								break;
							case 54:
							case 55:
							case 56:
							case 57:
								num4 = localWorldData.HonourBuilding_SmallStatue;
								break;
							case 58:
							case 59:
								num4 = localWorldData.HonourBuilding_LargeStatue;
								break;
							case 60:
								num4 = localWorldData.HonourBuilding_Dovecote;
								break;
							case 61:
								flag = true;
								num4 = localWorldData.HonourBuilding_Stocks;
								break;
							case 62:
								flag = true;
								num4 = localWorldData.HonourBuilding_BurningPost;
								break;
							case 63:
								flag = true;
								num4 = localWorldData.HonourBuilding_Gibbet;
								break;
							case 64:
								flag = true;
								num4 = localWorldData.HonourBuilding_Rack;
								break;
							}
							if (num4 != 0.0)
							{
								double num5 = VillageBuildingsData.calcHonourRateBasedOnDistance(num4, villageMapBuilding.buildingLocation, villageMapBuilding2.buildingLocation);
								if (flag)
								{
									num3 += num5;
								}
								else if (flag2)
								{
									num += num5;
								}
								else
								{
									num2 += num5;
								}
							}
						}
					}
				}
			}
			double popToHonourFromCards = CardTypes.getPopToHonourFromCards(GameEngine.Instance.cardsManager.UserCardData);
			if (GameEngine.Instance.World.ThirdAgeWorld)
			{
				num *= 4.0;
				num2 *= 4.0;
				num3 *= 4.0;
			}
			int num6 = (int)(this.m_parishCapitalResearchData.Research_Gardening + this.m_parishCapitalResearchData.Research_Justice);
			double num7 = (double)ResearchData.artsResearchAffect[(int)GameEngine.Instance.World.UserResearchData.Research_Arts];
			double num8 = num + num2 + num3 + num7 + (double)num6 + popToHonourFromCards;
			return (int)num8;
		}

		// Token: 0x06002E43 RID: 11843 RVA: 0x00021BEC File Offset: 0x0001FDEC
		public bool isPopulationMaxedOut()
		{
			return this.m_totalPeople >= this.m_housingCapacity;
		}

		// Token: 0x06002E44 RID: 11844 RVA: 0x002508AC File Offset: 0x0024EAAC
		public string getMigrationTimeString()
		{
			string result = "";
			if (this.isPopulationMaxedOut())
			{
				return result;
			}
			double value = (DXTimer.GetCurrentMilliseconds() - VillageMap.localBaseTime) / 1000.0;
			DateTime d = VillageMap.baseServerTime.AddSeconds(value);
			double totalSeconds = (this.m_immigrationNextChangeTime - d).TotalSeconds;
			if (totalSeconds > 0.0)
			{
				result = VillageMap.createBuildTimeString((int)totalSeconds);
			}
			return result;
		}

		// Token: 0x06002E45 RID: 11845 RVA: 0x00250918 File Offset: 0x0024EB18
		public double getMigrationSecondsLeft()
		{
			if (this.isPopulationMaxedOut())
			{
				return 0.0;
			}
			double value = (DXTimer.GetCurrentMilliseconds() - VillageMap.localBaseTime) / 1000.0;
			DateTime d = VillageMap.baseServerTime.AddSeconds(value);
			return (this.m_immigrationNextChangeTime - d).TotalSeconds;
		}

		// Token: 0x06002E46 RID: 11846 RVA: 0x00250970 File Offset: 0x0024EB70
		public void importTraders(List<MarketTraderData> traderData, DateTime curServerTime)
		{
			if (traderData != null)
			{
				this.traders.Clear();
				this.traders.AddRange(traderData);
				GameEngine.Instance.World.clearTraderArray(this.m_villageID);
				foreach (MarketTraderData marketTrader in traderData)
				{
					GameEngine.Instance.World.addTrader(marketTrader, curServerTime);
				}
			}
		}

		// Token: 0x06002E47 RID: 11847 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void updateTraders()
		{
		}

		// Token: 0x06002E48 RID: 11848 RVA: 0x002509F8 File Offset: 0x0024EBF8
		public void addTraders(int num, long traderID)
		{
			if (this.findBuildingType(78) != null)
			{
				this.m_numTradersAtHome += num;
			}
			foreach (MarketTraderData marketTraderData in this.traders)
			{
				if (marketTraderData.traderID == traderID)
				{
					this.traders.Remove(marketTraderData);
					break;
				}
			}
		}

		// Token: 0x06002E49 RID: 11849 RVA: 0x00250A74 File Offset: 0x0024EC74
		public int numTraders()
		{
			int num = this.m_numTradersAtHome;
			foreach (MarketTraderData marketTraderData in this.traders)
			{
				num += marketTraderData.numTraders;
			}
			return num;
		}

		// Token: 0x06002E4A RID: 11850 RVA: 0x00021BFF File Offset: 0x0001FDFF
		public int numFreeTraders()
		{
			return this.m_numTradersAtHome;
		}

		// Token: 0x06002E4B RID: 11851 RVA: 0x00250AD4 File Offset: 0x0024ECD4
		public void sendResources(int villageID, int resource, int amount)
		{
			if (this.inMarketSend)
			{
				if ((DateTime.Now - this.lastMarketSend).TotalSeconds < 45.0)
				{
					return;
				}
				this.inMarketSend = false;
			}
			if (!this.inMarketSend)
			{
				this.inMarketSend = true;
				this.lastMarketSend = DateTime.Now;
				RemoteServices.Instance.set_SendMarketResources_UserCallBack(new RemoteServices.SendMarketResources_UserCallBack(this.sendMarketResourcesCallback));
				RemoteServices.Instance.SendMarketResources(this.m_villageID, villageID, resource, amount);
				AllVillagesPanel.travellersChanged();
			}
		}

		// Token: 0x06002E4C RID: 11852 RVA: 0x00250B5C File Offset: 0x0024ED5C
		private void sendMarketResourcesCallback(SendMarketResources_ReturnType returnData)
		{
			this.inMarketSend = false;
			if (returnData.Success)
			{
				VillageMap village = GameEngine.Instance.getVillage(returnData.villageID);
				if (village != null)
				{
					VillageMap.setServerTime(returnData.currentTime);
					if (returnData.cardData != null)
					{
						GameEngine.Instance.cardsManager.UserCardData = returnData.cardData;
					}
					village.importResourcesAndStats(returnData.villageResourcesAndStats, returnData.currentTime);
					village.importTraders(returnData.traders, returnData.currentTime);
					if (returnData.tradersJustStarting != null)
					{
						village.startVillageTraderMovement(returnData.tradersJustStarting, returnData.villageID, returnData.targetVillageID);
						return;
					}
				}
				else
				{
					GameEngine.Instance.World.importOrphanedTraders(returnData.traders, returnData.currentTime, returnData.villageID);
				}
				return;
			}
			ControlForm controlForm = DX.ControlForm;
			if (controlForm == null)
			{
				return;
			}
			controlForm.Log(string.Concat(new string[]
			{
				ErrorCodes.getErrorString(returnData.m_errorCode, returnData.m_errorID),
				". Source Village ",
				GameEngine.Instance.World.getVillageName(returnData.villageID),
				" Target Village ",
				GameEngine.Instance.World.getVillageName(returnData.targetVillageID),
				" "
			}), ControlForm.Tab.Trade, true);
		}

		// Token: 0x06002E4D RID: 11853 RVA: 0x00250C94 File Offset: 0x0024EE94
		public void refreshTraderNumbers()
		{
			if ((DateTime.Now - this.lastTraderRefresh).TotalSeconds > 60.0)
			{
				this.lastTraderRefresh = DateTime.Now;
				RemoteServices.Instance.set_GetUserTraders_UserCallBack(new RemoteServices.GetUserTraders_UserCallBack(this.getUserTradersCallback));
				RemoteServices.Instance.GetUserTraders(this.m_villageID);
			}
		}

		// Token: 0x06002E4E RID: 11854 RVA: 0x00250CF8 File Offset: 0x0024EEF8
		public void getUserTradersCallback(GetUserTraders_ReturnType returnData)
		{
			if (returnData.Success)
			{
				VillageMap village = GameEngine.Instance.getVillage(returnData.villageID);
				if (village != null)
				{
					VillageMap.setServerTime(returnData.currentTime);
					village.importResourcesAndStats(returnData.villageResourcesAndStats, returnData.currentTime);
					village.importTraders(returnData.traders, returnData.currentTime);
					return;
				}
				GameEngine.Instance.World.importOrphanedTraders(returnData.traders, returnData.currentTime, returnData.villageID);
			}
		}

		// Token: 0x06002E4F RID: 11855 RVA: 0x00250D74 File Offset: 0x0024EF74
		private void startVillageTraderMovement(long[] traderList, int homeVillageID, int targetVillageID)
		{
			Point newEndPos = new Point(0, this.layout.gridHeight / 2);
			Point villageLocation = GameEngine.Instance.World.getVillageLocation(homeVillageID);
			Point villageLocation2 = GameEngine.Instance.World.getVillageLocation(targetVillageID);
			if (villageLocation.X < villageLocation2.X)
			{
				newEndPos.X = this.layout.gridWidth + 5;
			}
			else
			{
				newEndPos.X = -5;
			}
			foreach (long num in traderList)
			{
				foreach (MarketTraderData marketTraderData in this.traders)
				{
					if (marketTraderData.traderID == num)
					{
						using (List<VillageMapBuilding>.Enumerator enumerator2 = this.localBuildings.GetEnumerator())
						{
							while (enumerator2.MoveNext())
							{
								VillageMapBuilding villageMapBuilding = enumerator2.Current;
								if (villageMapBuilding.buildingType == 78)
								{
									if (villageMapBuilding.worker == null)
									{
										villageMapBuilding.worker = new VillageMapPerson(this.gfx);
										villageMapBuilding.productionState = 0;
										villageMapBuilding.worker.setPos(villageMapBuilding.buildingLocation);
										villageMapBuilding.worker.startJourneyTileBased(villageMapBuilding.buildingLocation, newEndPos, 0.0);
										this.initWalkingAnim(villageMapBuilding);
										break;
									}
									break;
								}
							}
							break;
						}
					}
				}
			}
		}

		// Token: 0x06002E50 RID: 11856 RVA: 0x00250F04 File Offset: 0x0024F104
		public bool stockExchangeTrade(int targetExchange, int resource, int amount, bool buy)
		{
			if (this.inMarketSend)
			{
				if ((DateTime.Now - this.lastMarketSend).TotalSeconds < 45.0)
				{
					return false;
				}
				this.inMarketSend = false;
			}
			if (!this.inMarketSend)
			{
				this.inMarketSend = true;
				this.lastMarketSend = DateTime.Now;
				RemoteServices.Instance.set_StockExchangeTrade_UserCallBack(new RemoteServices.StockExchangeTrade_UserCallBack(this.stockExchangeTradeCallback));
				RemoteServices.Instance.StockExchangeTrade(this.m_villageID, targetExchange, resource, amount, buy);
				AllVillagesPanel.travellersChanged();
			}
			return true;
		}

		// Token: 0x06002E51 RID: 11857 RVA: 0x00250F90 File Offset: 0x0024F190
		private void stockExchangeTradeCallback(StockExchangeTrade_ReturnType returnData)
		{
			this.inMarketSend = false;
			if (returnData.Success)
			{
				VillageMap village = GameEngine.Instance.getVillage(returnData.villageID);
				if (village != null)
				{
					VillageMap.setServerTime(returnData.currentTime);
					village.importResourcesAndStats(returnData.villageResourcesAndStats, returnData.currentTime);
					village.importTraders(returnData.traders, returnData.currentTime);
					if (returnData.tradersJustStarting != null)
					{
						village.startVillageTraderMovement(returnData.tradersJustStarting, returnData.villageID, returnData.targetVillageID);
					}
				}
				else
				{
					GameEngine.Instance.World.importOrphanedTraders(returnData.traders, returnData.currentTime, returnData.villageID);
				}
				GameEngine.Instance.World.setGoldData(returnData.currentGoldLevel, returnData.currentGoldRate);
				if (returnData.cardData != null)
				{
					GameEngine.Instance.cardsManager.UserCardData = returnData.cardData;
				}
				returnData.stockExchangeData.SetAsSucceeded();
				if (StockExchangePanel.instance != null)
				{
					StockExchangePanel.instance.getStockExchangeDataCallback(returnData.stockExchangeData);
				}
				if (CapitalTradePanel.instance != null)
				{
					CapitalTradePanel.instance.getStockExchangeDataCallback(returnData.stockExchangeData);
					return;
				}
			}
			else
			{
				if (returnData.m_errorCode == ErrorCodes.ErrorCode.TRADE_EXCHANGE_TOO_FAR)
				{
					MyMessageBox.Show(SK.Text("VillageMap_Stock_Exchange_Too_Far", "The Stock Exchange is too far away for you to trade with."), SK.Text("VillageMap_Trade_Error", "Trade Error"));
					return;
				}
				ControlForm controlForm = DX.ControlForm;
				if (controlForm == null)
				{
					return;
				}
				controlForm.Log(string.Concat(new string[]
				{
					ErrorCodes.getErrorString(returnData.m_errorCode, returnData.m_errorID),
					". Source Village ",
					GameEngine.Instance.World.getVillageName(returnData.villageID),
					" Target Village ",
					GameEngine.Instance.World.getVillageName(returnData.targetVillageID),
					" "
				}), ControlForm.Tab.Trade, true);
			}
		}

		// Token: 0x06002E52 RID: 11858 RVA: 0x00251154 File Offset: 0x0024F354
		public void addResources(int resource, int amount)
		{
			switch (resource)
			{
			case 6:
				this.m_woodLevel += (double)amount;
				return;
			case 7:
				this.m_stoneLevel += (double)amount;
				return;
			case 8:
				this.m_ironLevel += (double)amount;
				return;
			case 9:
				this.m_pitchLevel += (double)amount;
				return;
			case 10:
			case 11:
			case 20:
			case 27:
				break;
			case 12:
				this.m_aleLevel += (double)amount;
				break;
			case 13:
				this.m_applesLevel += (double)amount;
				return;
			case 14:
				this.m_breadLevel += (double)amount;
				return;
			case 15:
				this.m_vegLevel += (double)amount;
				return;
			case 16:
				this.m_meatLevel += (double)amount;
				return;
			case 17:
				this.m_cheeseLevel += (double)amount;
				return;
			case 18:
				this.m_fishLevel += (double)amount;
				return;
			case 19:
				this.m_clothesLevel += (double)amount;
				return;
			case 21:
				this.m_furnitureLevel += (double)amount;
				return;
			case 22:
				this.m_venisonLevel += (double)amount;
				return;
			case 23:
				this.m_saltLevel += (double)amount;
				return;
			case 24:
				this.m_spicesLevel += (double)amount;
				return;
			case 25:
				this.m_silkLevel += (double)amount;
				return;
			case 26:
				this.m_metalwareLevel += (double)amount;
				return;
			case 28:
				this.m_pikesLevel += (double)amount;
				return;
			case 29:
				this.m_bowsLevel += (double)amount;
				return;
			case 30:
				this.m_swordsLevel += (double)amount;
				return;
			case 31:
				this.m_armourLevel += (double)amount;
				return;
			case 32:
				this.m_catapultsLevel += (double)amount;
				return;
			case 33:
				this.m_wineLevel += (double)amount;
				return;
			default:
				return;
			}
		}

		// Token: 0x06002E53 RID: 11859 RVA: 0x00021C07 File Offset: 0x0001FE07
		public void makeTroops(int troopType)
		{
			this.makeTroops(troopType, 1, false);
		}

		// Token: 0x06002E54 RID: 11860 RVA: 0x0025135C File Offset: 0x0024F55C
		private static double availableCapitalGold(VillageMap vm, int preMadePeasants, WorldData worldData, int preMadeArchers, int preMadePikemen, int preMadeSwordsmen, int preMadeCatapults)
		{
			double num = vm.m_capitalGold;
			num -= (double)(preMadePeasants * worldData.Barracks_GoldCost_Peasant * worldData.MercenaryCostMultiplier);
			num -= (double)(preMadeArchers * worldData.Barracks_GoldCost_Archer * worldData.MercenaryCostMultiplier);
			num -= (double)(preMadePikemen * worldData.Barracks_GoldCost_Pikeman * worldData.MercenaryCostMultiplier);
			num -= (double)(preMadeSwordsmen * worldData.Barracks_GoldCost_Swordsman * worldData.MercenaryCostMultiplier);
			return num - (double)(preMadeCatapults * worldData.Barracks_GoldCost_Catapult * worldData.MercenaryCostMultiplier);
		}

		// Token: 0x06002E55 RID: 11861 RVA: 0x002513D4 File Offset: 0x0024F5D4
		public static TroopCount GetMaxRecruitableCapitalTroops()
		{
			TroopCount troopCount = new TroopCount();
			WorldData localWorldData = GameEngine.Instance.LocalWorldData;
			VillageMap village = GameEngine.Instance.Village;
			CastleMap castle = GameEngine.Instance.Castle;
			if (village != null && castle != null)
			{
				int locallyMade_Peasants = village.LocallyMade_Peasants;
				int locallyMade_Archers = village.LocallyMade_Archers;
				int locallyMade_Pikemen = village.LocallyMade_Pikemen;
				int locallyMade_Swordsmen = village.LocallyMade_Swordsmen;
				int locallyMade_Catapults = village.LocallyMade_Catapults;
				int num = locallyMade_Swordsmen + locallyMade_Pikemen + locallyMade_Peasants + locallyMade_Catapults + locallyMade_Archers;
				int num2 = village.m_numArchers + village.m_numPeasants + village.m_numPikemen + village.m_numSwordsmen + village.m_numCatapults;
				num2 += num;
				num2 += GameEngine.Instance.World.countYourArmyTroops(village.VillageID);
				num2 += GameEngine.Instance.World.countYourReinforcementTroops(village.VillageID);
				num2 += castle.countOwnPlacedTroops();
				int num3 = 0;
				if (GameEngine.Instance.World.isCapital(village.VillageID))
				{
					num3 = (int)((village.m_parishCapitalResearchData.Research_Command + 1) * 25);
				}
				if (!GameEngine.Instance.World.isUserVillage(village.VillageID))
				{
					num3 = 0;
				}
				double num4 = VillageMap.availableCapitalGold(village, locallyMade_Peasants, localWorldData, locallyMade_Archers, locallyMade_Pikemen, locallyMade_Swordsmen, locallyMade_Catapults);
				int val = num3 - num2;
				int val2 = (int)num4 / (localWorldData.Barracks_GoldCost_Peasant * localWorldData.MercenaryCostMultiplier);
				troopCount.peasants = Math.Min(val, val2);
				val2 = (int)num4 / (localWorldData.Barracks_GoldCost_Archer * localWorldData.MercenaryCostMultiplier);
				troopCount.archers = Math.Min(val, val2);
				val2 = (int)num4 / (localWorldData.Barracks_GoldCost_Pikeman * localWorldData.MercenaryCostMultiplier);
				troopCount.pikemen = Math.Min(val, val2);
				val2 = (int)num4 / (localWorldData.Barracks_GoldCost_Swordsman * localWorldData.MercenaryCostMultiplier);
				troopCount.swordsmen = Math.Min(val, val2);
				val2 = (int)num4 / (localWorldData.Barracks_GoldCost_Catapult * localWorldData.MercenaryCostMultiplier);
				troopCount.catapults = Math.Min(val, val2);
			}
			return troopCount;
		}

		// Token: 0x06002E56 RID: 11862 RVA: 0x002515C4 File Offset: 0x0024F7C4
		public static TroopCount GetMaxRecruitableTroops()
		{
			TroopCount troopCount = new TroopCount();
			WorldData localWorldData = GameEngine.Instance.LocalWorldData;
			VillageMap village = GameEngine.Instance.Village;
			CastleMap castle = GameEngine.Instance.Castle;
			if (village != null && castle != null)
			{
				int locallyMade_Peasants = village.LocallyMade_Peasants;
				int locallyMade_Archers = village.LocallyMade_Archers;
				int locallyMade_Pikemen = village.LocallyMade_Pikemen;
				int locallyMade_Swordsmen = village.LocallyMade_Swordsmen;
				int locallyMade_Catapults = village.LocallyMade_Catapults;
				int locallyMade_Captains = village.LocallyMade_Captains;
				int num = locallyMade_Swordsmen + locallyMade_Pikemen + locallyMade_Peasants + locallyMade_Catapults + locallyMade_Archers + locallyMade_Captains;
				VillageMap.ArmouryLevels armouryLevels = new VillageMap.ArmouryLevels();
				village.getArmouryLevels(armouryLevels);
				int val = (int)armouryLevels.bowsLevel - locallyMade_Archers;
				int val2 = (int)armouryLevels.pikesLevel - locallyMade_Pikemen;
				int val3 = (int)armouryLevels.swordsLevel - locallyMade_Swordsmen;
				int val4 = (int)armouryLevels.armourLevel - locallyMade_Pikemen - locallyMade_Swordsmen;
				int val5 = (int)armouryLevels.catapultsLevel - locallyMade_Catapults;
				int val6 = village.m_spareWorkers - num;
				int num2 = (int)GameEngine.Instance.World.getCurrentGold();
				num2 -= locallyMade_Peasants * localWorldData.Barracks_GoldCost_Peasant;
				num2 -= locallyMade_Archers * localWorldData.Barracks_GoldCost_Archer;
				num2 -= locallyMade_Pikemen * localWorldData.Barracks_GoldCost_Pikeman;
				num2 -= locallyMade_Swordsmen * localWorldData.Barracks_GoldCost_Swordsman;
				num2 -= locallyMade_Catapults * localWorldData.Barracks_GoldCost_Catapult;
				int num3 = CardTypes.adjustTroopCost(GameEngine.Instance.cardsManager.UserCardData, localWorldData.Barracks_GoldCost_Peasant);
				int num4 = CardTypes.adjustTroopCost(GameEngine.Instance.cardsManager.UserCardData, localWorldData.Barracks_GoldCost_Archer);
				int num5 = CardTypes.adjustTroopCost(GameEngine.Instance.cardsManager.UserCardData, localWorldData.Barracks_GoldCost_Pikeman);
				int num6 = CardTypes.adjustTroopCost(GameEngine.Instance.cardsManager.UserCardData, localWorldData.Barracks_GoldCost_Swordsman);
				int num7 = CardTypes.adjustTroopCost(GameEngine.Instance.cardsManager.UserCardData, localWorldData.Barracks_GoldCost_Catapult);
				int num8 = localWorldData.CaptainGoldCost * GameEngine.Instance.World.getNumMadeCaptains();
				int num9 = Math.Min(val6, num2 / num3);
				int num10 = Math.Min(Math.Min(val6, num2 / num4), val);
				int num11 = Math.Min(Math.Min(Math.Min(val6, num2 / num5), val2), val4);
				int num12 = Math.Min(Math.Min(Math.Min(val6, num2 / num6), val3), val4);
				int num13 = Math.Min(Math.Min(val6, num2 / num7), val5);
				int num14 = Math.Min(val6, num2 / num8);
				if (num14 > 1)
				{
					num14 = 1;
				}
				int num15 = village.calcTotalTroops() + num;
				int num16 = village.calcUnitUsages() + num;
				int num17 = ResearchData.commandResearchTroopLevels[(int)GameEngine.Instance.World.userResearchData.Research_Command];
				int num18 = Math.Max(GameEngine.Instance.LocalWorldData.Village_UnitCapacity - num16, 0);
				if (num9 > num18)
				{
					num9 = num18;
				}
				if (num10 > num18)
				{
					num10 = num18;
				}
				if (num11 > num18)
				{
					num11 = num18;
				}
				if (num12 > num18)
				{
					num12 = num18;
				}
				if (num13 > num18)
				{
					num13 = num18;
				}
				if (num14 > num18)
				{
					num14 = num18;
				}
				int num19 = village.m_numCaptains;
				num19 += GameEngine.Instance.World.countYourArmyCaptains(village.VillageID);
				num19 += castle.countOwnPlacedCaptains();
				int num20 = ResearchData.captainsResearchCaptainsLevels[(int)GameEngine.Instance.World.userResearchData.Research_Captains];
				if (num20 > 0 && num19 >= num20)
				{
					num14 = 0;
				}
				if (num15 >= num17 || num16 >= GameEngine.Instance.LocalWorldData.Village_UnitCapacity)
				{
					num9 = 0;
					num10 = 0;
					num11 = 0;
					num12 = 0;
					num13 = 0;
					num14 = 0;
				}
				if (GameEngine.Instance.World.UserResearchData.Research_Conscription == 0)
				{
					num9 = 0;
				}
				if (GameEngine.Instance.World.UserResearchData.Research_LongBow == 0)
				{
					num10 = 0;
				}
				if (GameEngine.Instance.World.UserResearchData.Research_Pike == 0)
				{
					num11 = 0;
				}
				if (GameEngine.Instance.World.UserResearchData.Research_Sword == 0)
				{
					num12 = 0;
				}
				if (GameEngine.Instance.World.UserResearchData.Research_Catapult == 0)
				{
					num13 = 0;
				}
				troopCount.peasants = num9;
				troopCount.archers = num10;
				troopCount.pikemen = num11;
				troopCount.swordsmen = num12;
				troopCount.catapults = num13;
				troopCount.captains = num14;
			}
			return troopCount;
		}

		// Token: 0x06002E57 RID: 11863 RVA: 0x002519E0 File Offset: 0x0024FBE0
		public int numberOfTroopsToDisplay()
		{
			int num = this.LocallyMade_Swordsmen + this.LocallyMade_Pikemen + this.LocallyMade_Peasants + this.LocallyMade_Catapults + this.LocallyMade_Archers + this.LocallyMade_Captains;
			return this.calcUnitUsages() + num;
		}

		// Token: 0x06002E58 RID: 11864 RVA: 0x00251A20 File Offset: 0x0024FC20
		public void makeTroops(int troopType, int amount, bool quickSend)
		{
			UniversalDebugLog.Log("making troop " + troopType.ToString() + " x" + amount.ToString());
			if (troopType == -5)
			{
				if (!this.makeTroopsLocked || (DateTime.Now - this.makeTroopsLockedTime).TotalSeconds > 45.0)
				{
					this.LocallyMade_Traders++;
					this.makeTroopsLockedTime = DateTime.Now;
					this.makeTroopsLocked = true;
					RemoteServices.Instance.set_MakeTroop_UserCallBack(new RemoteServices.MakeTroop_UserCallBack(this.makeTroopCallback));
					RemoteServices.Instance.MakeTroop(this.VillageID, troopType, amount);
				}
				return;
			}
			if (troopType != this.localMadeTroops_lastType && this.localMadeTroops_lastType != -1)
			{
				int amount2 = 0;
				int num = this.localMadeTroops_lastType;
				switch (num)
				{
				case 70:
					amount2 = this.localMadeTroops_Peasants;
					this.localMadeTroopsSent_Peasants = this.localMadeTroops_Peasants;
					this.localMadeTroops_Peasants = 0;
					break;
				case 71:
					amount2 = this.localMadeTroops_Swordsmen;
					this.localMadeTroopsSent_Swordsmen = this.localMadeTroops_Swordsmen;
					this.localMadeTroops_Swordsmen = 0;
					break;
				case 72:
					amount2 = this.localMadeTroops_Archers;
					this.localMadeTroopsSent_Archers = this.localMadeTroops_Archers;
					this.localMadeTroops_Archers = 0;
					break;
				case 73:
					amount2 = this.localMadeTroops_Pikemen;
					this.localMadeTroopsSent_Pikemen = this.localMadeTroops_Pikemen;
					this.localMadeTroops_Pikemen = 0;
					break;
				case 74:
					amount2 = this.localMadeTroops_Catapults;
					this.localMadeTroopsSent_Catapults = this.localMadeTroops_Catapults;
					this.localMadeTroops_Catapults = 0;
					break;
				case 75:
					break;
				case 76:
					amount2 = this.localMadeTroops_Scouts;
					this.localMadeTroopsSent_Scouts = this.localMadeTroops_Scouts;
					this.localMadeTroops_Scouts = 0;
					break;
				default:
					if (num == 85 || num == 100)
					{
						amount2 = this.localMadeTroops_Captains;
						this.localMadeTroopsSent_Captains = this.localMadeTroops_Captains;
						this.localMadeTroops_Captains = 0;
					}
					break;
				}
				this.makeTroopsLockedTime = DateTime.Now;
				RemoteServices.Instance.set_MakeTroop_UserCallBack(new RemoteServices.MakeTroop_UserCallBack(this.makeTroopCallback));
				RemoteServices.Instance.MakeTroop(this.VillageID, this.localMadeTroops_lastType, amount2);
				this.localMadeTroops_lastType = -1;
			}
			switch (troopType)
			{
			case 70:
				this.localMadeTroops_Peasants += amount;
				break;
			case 71:
				this.localMadeTroops_Swordsmen += amount;
				break;
			case 72:
				this.localMadeTroops_Archers += amount;
				break;
			case 73:
				this.localMadeTroops_Pikemen += amount;
				break;
			case 74:
				this.localMadeTroops_Catapults += amount;
				break;
			case 75:
				break;
			case 76:
				this.localMadeTroops_Scouts += amount;
				break;
			default:
				if (troopType == 85 || troopType == 100)
				{
					this.LocalGoldSpentOnCaptains += GameEngine.Instance.LocalWorldData.CaptainGoldCost * GameEngine.Instance.World.getNumMadeCaptains();
					this.localMadeTroops_Captains += amount;
				}
				break;
			}
			this.localMadeTroops_lastType = troopType;
			if (!quickSend)
			{
				this.localMadeTroops_lastTime = DateTime.Now;
				return;
			}
			this.localMadeTroops_lastTime = DateTime.Now.AddMinutes(-1.0);
		}

		// Token: 0x06002E59 RID: 11865 RVA: 0x00251D30 File Offset: 0x0024FF30
		public void makeTroopsUpdate()
		{
			if (this.localMadeTroops_lastType <= 0)
			{
				return;
			}
			DateTime now = DateTime.Now;
			if ((now - this.localMadeTroops_lastTime).TotalSeconds > 2.0)
			{
				int amount = 0;
				int num = this.localMadeTroops_lastType;
				switch (num)
				{
				case 70:
					amount = this.localMadeTroops_Peasants;
					this.localMadeTroopsSent_Peasants = this.localMadeTroops_Peasants;
					this.localMadeTroops_Peasants = 0;
					break;
				case 71:
					amount = this.localMadeTroops_Swordsmen;
					this.localMadeTroopsSent_Swordsmen = this.localMadeTroops_Swordsmen;
					this.localMadeTroops_Swordsmen = 0;
					break;
				case 72:
					amount = this.localMadeTroops_Archers;
					this.localMadeTroopsSent_Archers = this.localMadeTroops_Archers;
					this.localMadeTroops_Archers = 0;
					break;
				case 73:
					amount = this.localMadeTroops_Pikemen;
					this.localMadeTroopsSent_Pikemen = this.localMadeTroops_Pikemen;
					this.localMadeTroops_Pikemen = 0;
					break;
				case 74:
					amount = this.localMadeTroops_Catapults;
					this.localMadeTroopsSent_Catapults = this.localMadeTroops_Catapults;
					this.localMadeTroops_Catapults = 0;
					break;
				case 75:
					break;
				case 76:
					amount = this.localMadeTroops_Scouts;
					this.localMadeTroopsSent_Scouts = this.localMadeTroops_Scouts;
					this.localMadeTroops_Scouts = 0;
					break;
				default:
					if (num == 85 || num == 100)
					{
						amount = this.localMadeTroops_Captains;
						this.localMadeTroopsSent_Captains = this.localMadeTroops_Captains;
						this.localMadeTroops_Captains = 0;
					}
					break;
				}
				this.makeTroopsLockedTime = DateTime.Now;
				RemoteServices.Instance.set_MakeTroop_UserCallBack(new RemoteServices.MakeTroop_UserCallBack(this.makeTroopCallback));
				RemoteServices.Instance.MakeTroop(this.VillageID, this.localMadeTroops_lastType, amount);
				this.localMadeTroops_lastType = -1;
			}
		}

		// Token: 0x06002E5A RID: 11866 RVA: 0x00251EBC File Offset: 0x002500BC
		public void makeTroopCallback(MakeTroop_ReturnType returnData)
		{
			if (!returnData.Success)
			{
				ControlForm controlForm = DX.ControlForm;
				if (controlForm != null)
				{
					controlForm.Log(string.Concat(new string[]
					{
						ErrorCodes.getErrorString(returnData.m_errorCode, returnData.m_errorID),
						". Source Village ",
						GameEngine.Instance.World.getVillageName(returnData.villageID),
						" Troops Type ",
						GameEngine.Instance.World.getVillageName(returnData.troopTypeMade),
						" "
					}), ControlForm.Tab.TroopsRecruiting, true);
				}
			}
			this.makeTroopsLocked = false;
			if (returnData.Success)
			{
				VillageMap village = GameEngine.Instance.getVillage(returnData.villageID);
				if (village != null)
				{
					VillageMap.setServerTime(returnData.currentTime);
					village.importResourcesAndStats(returnData.villageResourcesAndStats, returnData.currentTime);
					GameEngine.Instance.World.setGoldData(returnData.currentGoldLevel, returnData.currentGoldRate);
					if (GameEngine.Instance.Castle != null)
					{
						GameEngine.Instance.Castle.updateAvailableTroops();
					}
					if (returnData.marketTraders != null)
					{
						village.importTraders(returnData.marketTraders, returnData.currentTime);
					}
					if (returnData.villageBuildings != null)
					{
						village.importVillageBuildings(returnData.villageBuildings, false);
					}
				}
			}
			int troopTypeMade = returnData.troopTypeMade;
			if (troopTypeMade <= 76)
			{
				if (troopTypeMade != -5)
				{
					switch (troopTypeMade)
					{
					case 70:
						this.localMadeTroopsSent_Peasants = 0;
						return;
					case 71:
						this.localMadeTroopsSent_Swordsmen = 0;
						return;
					case 72:
						this.localMadeTroopsSent_Archers = 0;
						return;
					case 73:
						this.localMadeTroopsSent_Pikemen = 0;
						return;
					case 74:
						this.localMadeTroopsSent_Catapults = 0;
						return;
					case 75:
						break;
					case 76:
						this.localMadeTroopsSent_Scouts = 0;
						break;
					default:
						return;
					}
					return;
				}
				this.LocallyMade_Traders = 0;
				return;
			}
			else
			{
				if (troopTypeMade != 85 && troopTypeMade != 100)
				{
					return;
				}
				this.localMadeTroopsSent_Captains = 0;
				this.LocalGoldSpentOnCaptains = 0;
				return;
			}
		}

		// Token: 0x06002E5B RID: 11867 RVA: 0x00252080 File Offset: 0x00250280
		public void disbandTroops(int troopType, int amount)
		{
			if (!this.disbandTroopsLocked || (DateTime.Now - this.disbandTroopsLockedTime).TotalSeconds > 45.0)
			{
				this.disbandTroopsLockedTime = DateTime.Now;
				this.disbandTroopsLocked = true;
				RemoteServices.Instance.set_DisbandTroops_UserCallBack(new RemoteServices.DisbandTroops_UserCallBack(this.disbandTroopsCallback));
				RemoteServices.Instance.DisbandTroops(this.VillageID, troopType, amount);
			}
		}

		// Token: 0x06002E5C RID: 11868 RVA: 0x00021C12 File Offset: 0x0001FE12
		public void disbandTroopsCallback(DisbandTroops_ReturnType returnData)
		{
			this.disbandTroopsLocked = false;
			if (returnData.Success)
			{
				GameEngine.Instance.forceDownloadCurrentVillage();
			}
		}

		// Token: 0x06002E5D RID: 11869 RVA: 0x002520F4 File Offset: 0x002502F4
		public void makePeople(int peopleType)
		{
			if (!this.makePeopleLocked || (DateTime.Now - this.makePeopleLockedTime).TotalSeconds > 45.0)
			{
				this.LocallyMadeMonks++;
				this.makePeopleLockedTime = DateTime.Now;
				this.makePeopleLocked = true;
				RemoteServices.Instance.set_MakePeople_UserCallBack(new RemoteServices.MakePeople_UserCallBack(this.makePeopleCallback));
				RemoteServices.Instance.MakePeople(this.VillageID, peopleType);
			}
		}

		// Token: 0x06002E5E RID: 11870 RVA: 0x00252174 File Offset: 0x00250374
		public void makePeopleCallback(MakePeople_ReturnType returnData)
		{
			this.makePeopleLocked = false;
			if (returnData.Success)
			{
				GameEngine.Instance.World.importOrphanedPeople(returnData.people, returnData.currentTime, -2);
				VillageMap village = GameEngine.Instance.getVillage(returnData.villageID);
				if (village != null)
				{
					VillageMap.setServerTime(returnData.currentTime);
					village.importResourcesAndStats(returnData.villageResourcesAndStats, returnData.currentTime);
					GameEngine.Instance.World.setGoldData(returnData.currentGoldLevel, returnData.currentGoldRate);
					if (GameEngine.Instance.Castle != null)
					{
						GameEngine.Instance.Castle.updateAvailableTroops();
					}
				}
			}
			else
			{
				string errorString = ErrorCodes.getErrorString(returnData.m_errorCode, returnData.m_errorID);
				string villageName = GameEngine.Instance.World.getVillageName(returnData.villageID);
				ControlForm controlForm = DX.ControlForm;
				if (controlForm != null)
				{
					controlForm.Log(errorString + ". Village " + villageName, ControlForm.Tab.Main, true);
				}
			}
			this.LocallyMadeMonks = 0;
		}

		// Token: 0x06002E5F RID: 11871 RVA: 0x0025226C File Offset: 0x0025046C
		public void disbandPeople(int peopleType, int amount)
		{
			if (!this.disbandPeopleLocked || (DateTime.Now - this.disbandPeopleLockedTime).TotalSeconds > 45.0)
			{
				this.disbandPeopleLockedTime = DateTime.Now;
				this.disbandPeopleLocked = true;
				RemoteServices.Instance.set_DisbandPeople_UserCallBack(new RemoteServices.DisbandPeople_UserCallBack(this.disbandPeopleCallback));
				RemoteServices.Instance.DisbandPeople(this.VillageID, peopleType, amount);
			}
		}

		// Token: 0x06002E60 RID: 11872 RVA: 0x002522E0 File Offset: 0x002504E0
		public void disbandPeopleCallback(DisbandPeople_ReturnType returnData)
		{
			this.disbandPeopleLocked = false;
			if (returnData.Success)
			{
				if (returnData.marketTraders != null)
				{
					this.importTraders(returnData.marketTraders, returnData.currentTime);
				}
				if (returnData.people != null)
				{
					GameEngine.Instance.World.importOrphanedPeople(returnData.people, returnData.currentTime, returnData.villageID);
				}
				GameEngine.Instance.forceDownloadCurrentVillage();
			}
		}

		// Token: 0x06002E61 RID: 11873 RVA: 0x00021C2D File Offset: 0x0001FE2D
		public void addTroops(int numPeasants, int numArchers, int numPikemen, int numSwordsmen, int numCatapults)
		{
			this.addTroops(numPeasants, numArchers, numPikemen, numSwordsmen, numCatapults, 0);
		}

		// Token: 0x06002E62 RID: 11874 RVA: 0x00021C3D File Offset: 0x0001FE3D
		public void addTroops(int numPeasants, int numArchers, int numPikemen, int numSwordsmen, int numCatapults, int numScouts)
		{
			this.addTroops(numPeasants, numArchers, numPikemen, numSwordsmen, numCatapults, numScouts, 0);
		}

		// Token: 0x06002E63 RID: 11875 RVA: 0x0025234C File Offset: 0x0025054C
		public void addTroops(int numPeasants, int numArchers, int numPikemen, int numSwordsmen, int numCatapults, int numScouts, int numCaptains)
		{
			this.m_numPeasants += numPeasants;
			this.m_numArchers += numArchers;
			this.m_numPikemen += numPikemen;
			this.m_numSwordsmen += numSwordsmen;
			this.m_numCatapults += numCatapults;
			this.m_numScouts += numScouts;
			this.m_numCaptains += numCaptains;
		}

		// Token: 0x06002E64 RID: 11876 RVA: 0x002523C0 File Offset: 0x002505C0
		public void addTroopsArmyReturnSpecial(int numPeasants, int numArchers, int numPikemen, int numSwordsmen, int numCatapults, int numScouts, int numCaptains)
		{
			this.m_numPeasants += numPeasants;
			this.m_numArchers += numArchers;
			this.m_numPikemen += numPikemen;
			this.m_numSwordsmen += numSwordsmen;
			this.m_numCatapults += numCatapults;
			this.m_numCaptains += numCaptains;
			if (numScouts > 0)
			{
				int num = ResearchData.scoutResearchScoutsLevels[(int)GameEngine.Instance.World.userResearchData.Research_Scouts];
				if (this.m_numScouts + numScouts <= num)
				{
					this.m_numScouts += numScouts;
				}
			}
		}

		// Token: 0x06002E65 RID: 11877 RVA: 0x00021C4F File Offset: 0x0001FE4F
		public void addVassalTroops(int numPeasants, int numArchers, int numPikemen, int numSwordsmen)
		{
			this.m_numStationedPeasants += numPeasants;
			this.m_numStationedArchers += numArchers;
			this.m_numStationedPikemen += numPikemen;
			this.m_numStationedSwordsmen += numSwordsmen;
		}

		// Token: 0x06002E66 RID: 11878 RVA: 0x00021C8A File Offset: 0x0001FE8A
		public void addCaptainBack()
		{
			this.m_numCaptains++;
		}

		// Token: 0x06002E67 RID: 11879 RVA: 0x00252460 File Offset: 0x00250660
		public Point findEmptyTile(Point Location, int range, Random rand)
		{
			int num = Location.X - range / 2;
			if (num < 1)
			{
				num = 1;
			}
			int num2 = Location.X + range / 2;
			if (num2 >= this.layout.gridWidth - 2)
			{
				num2 = this.layout.gridWidth - 2;
			}
			int num3 = Location.Y - range;
			if (num3 < 1)
			{
				num3 = 1;
			}
			int num4 = Location.Y + range;
			if (num4 >= this.layout.gridHeight - 2)
			{
				num4 = this.layout.gridHeight - 2;
			}
			List<Point> list = new List<Point>();
			for (int i = num3; i <= num4; i++)
			{
				for (int j = num; j <= num2; j++)
				{
					if (this.layout.mapData[i][j] == 0 && this.layout.mapData[i - 1][j] == 0 && this.layout.mapData[i + 1][j] == 0 && this.layout.mapData[i][j - 1] == 0 && this.layout.mapData[i][j + 1] == 0)
					{
						Point item = new Point(j, i);
						list.Add(item);
					}
				}
			}
			if (list.Count > 0)
			{
				return list[rand.Next(list.Count)];
			}
			return Location;
		}

		// Token: 0x06002E68 RID: 11880 RVA: 0x002525B0 File Offset: 0x002507B0
		public Point findSpaceForBuilding(Point Location, int buildingType)
		{
			int size = VillageMap.s_villageBuildingData[buildingType].size;
			int buildingXSize = VillageBuildingsData.getBuildingXSize(size);
			int buildingYSize = VillageBuildingsData.getBuildingYSize(size);
			int[] buildingLayout = VillageBuildingsData.getBuildingLayout(size);
			int num = Math.Max(buildingXSize, buildingYSize);
			if (num % 2 == 1)
			{
				num++;
			}
			int num2 = Location.X - num / 2;
			if (num2 < 0)
			{
				num2 = 0;
			}
			int num3 = Location.X + num / 2;
			if (num3 >= this.layout.gridWidth - 2)
			{
				num3 = this.layout.gridWidth - 2;
			}
			int num4 = Location.Y - num / 2;
			if (num4 < 0)
			{
				num4 = 0;
			}
			int num5 = Location.Y + num / 2;
			if (num5 >= this.layout.gridHeight - 2)
			{
				num5 = this.layout.gridHeight - 2;
			}
			for (int i = num4; i <= num5; i++)
			{
				for (int j = num2; j <= num3; j++)
				{
					if (VillageLayoutNew.checkBuildingAgainstLandscape(this.layout.mapData, buildingLayout, new Point(j, i), VillageMap.placementType, this.layout.gridWidth, this.layout.gridHeight) == ErrorCodes.ErrorCode.OK && VillageLayoutNew.checkBuildingAgainstOtherBuildings(this.layout.mapData, buildingLayout, new Point(j, i), VillageMap.placementType) == ErrorCodes.ErrorCode.OK)
					{
						return new Point(j, i);
					}
				}
			}
			return Location;
		}

		// Token: 0x06002E69 RID: 11881 RVA: 0x00021C9A File Offset: 0x0001FE9A
		public bool isCreatingCaptain(ref DateTime completeTime)
		{
			completeTime = this.m_captainCreationTime;
			return this.m_creatingCaptain;
		}

		// Token: 0x06002E6A RID: 11882 RVA: 0x00252704 File Offset: 0x00250904
		public bool needParishPeople()
		{
			if (this.m_parishPeople == null)
			{
				return true;
			}
			DateTime currentServerTime = VillageMap.getCurrentServerTime();
			return (currentServerTime - this.m_lastParishPeopleTime).TotalMinutes > 30.0;
		}

		// Token: 0x06002E6B RID: 11883 RVA: 0x00021CAE File Offset: 0x0001FEAE
		public void importParishTaxPeople(ParishTaxCalc[] parishPeople, DateTime updateTime)
		{
			this.m_parishPeople = parishPeople;
			this.m_lastParishPeopleTime = updateTime;
		}

		// Token: 0x06002E6C RID: 11884 RVA: 0x00252744 File Offset: 0x00250944
		public int calcParishCapitalTaxIncome()
		{
			int num = 0;
			if (this.m_parishPeople != null && this.m_parishPeople.Length != 0)
			{
				WorldData localWorldData = GameEngine.Instance.LocalWorldData;
				ParishTaxCalc[] parishPeople = this.m_parishPeople;
				foreach (ParishTaxCalc parishTaxCalc in parishPeople)
				{
					parishTaxCalc.tax = localWorldData.ranks_Tax[parishTaxCalc.rank] * this.m_capitalTaxRate * parishTaxCalc.numVillages;
					if (parishTaxCalc.gold < parishTaxCalc.tax)
					{
						parishTaxCalc.tax = parishTaxCalc.gold;
					}
					num += parishTaxCalc.tax;
				}
			}
			else
			{
				if (GameEngine.Instance.World.isCountyCapital(this.VillageID))
				{
					num = GameEngine.Instance.LocalWorldData.BaseTaxForAreaCounty;
				}
				else if (GameEngine.Instance.World.isProvinceCapital(this.VillageID))
				{
					num = GameEngine.Instance.LocalWorldData.BaseTaxForAreaProvince;
				}
				else if (GameEngine.Instance.World.isCountryCapital(this.VillageID))
				{
					num = GameEngine.Instance.LocalWorldData.BaseTaxForAreaCountry;
				}
				num *= this.m_numOfActiveChildrenAreas * this.m_capitalTaxRate;
			}
			return num;
		}

		// Token: 0x06002E6D RID: 11885 RVA: 0x00252870 File Offset: 0x00250A70
		public int calcParishVillageTax()
		{
			int rank = GameEngine.Instance.World.getRank();
			return GameEngine.Instance.LocalWorldData.ranks_Tax[rank] * this.m_capitalTaxRate;
		}

		// Token: 0x06002E6E RID: 11886 RVA: 0x002528A8 File Offset: 0x00250AA8
		public int calcUnitUsages()
		{
			int num = this.calcTotalTroops();
			num += this.calcTotalScouts() * GameEngine.Instance.LocalWorldData.UnitSize_Scout;
			num += this.calcTotalTraders() * GameEngine.Instance.LocalWorldData.UnitSize_Trader;
			return num + this.calcTotalMonks() * GameEngine.Instance.LocalWorldData.UnitSize_Priests;
		}

		// Token: 0x06002E6F RID: 11887 RVA: 0x00252908 File Offset: 0x00250B08
		public int calcTotalTroops()
		{
			int num = this.m_numArchers + this.m_numPeasants + this.m_numPikemen + this.m_numSwordsmen + this.m_numCatapults;
			num += GameEngine.Instance.World.countYourArmyTroops(this.VillageID);
			num += GameEngine.Instance.World.countYourReinforcementTroops(this.VillageID);
			num += this.m_numCaptains;
			num += GameEngine.Instance.World.countYourArmyCaptains(this.VillageID);
			CastleMap castleMap = (CastleMap)GameEngine.Instance.Castles[this.VillageID];
			if (castleMap != null)
			{
				num += castleMap.countOwnPlacedTroops();
			}
			return num;
		}

		// Token: 0x06002E70 RID: 11888 RVA: 0x002529B4 File Offset: 0x00250BB4
		public int calcTotalScouts()
		{
			int numScouts = this.m_numScouts;
			return numScouts + GameEngine.Instance.World.countYourArmyScouts(this.VillageID);
		}

		// Token: 0x06002E71 RID: 11889 RVA: 0x00021CBE File Offset: 0x0001FEBE
		public int calcTotalScoutsAtHome()
		{
			return this.m_numScouts;
		}

		// Token: 0x06002E72 RID: 11890 RVA: 0x00021CC6 File Offset: 0x0001FEC6
		public int calcTotalTraders()
		{
			return this.numTraders();
		}

		// Token: 0x06002E73 RID: 11891 RVA: 0x00021CCE File Offset: 0x0001FECE
		public int calcTotalTradersAtHome()
		{
			return this.numFreeTraders();
		}

		// Token: 0x06002E74 RID: 11892 RVA: 0x002529E0 File Offset: 0x00250BE0
		public int calcTotalMonks()
		{
			int num = 0;
			return GameEngine.Instance.World.countVillagePeople(this.VillageID, 4, ref num);
		}

		// Token: 0x06002E75 RID: 11893 RVA: 0x00252A08 File Offset: 0x00250C08
		public int calcTotalMonksAtHome()
		{
			int result = 0;
			GameEngine.Instance.World.countVillagePeople(this.VillageID, 4, ref result);
			return result;
		}

		// Token: 0x06002E76 RID: 11894 RVA: 0x00252A34 File Offset: 0x00250C34
		public double LocalGoldAvailable()
		{
			WorldData localWorldData = GameEngine.Instance.LocalWorldData;
			int num = (int)GameEngine.Instance.World.getCurrentGold();
			num -= this.LocallyMade_Peasants * localWorldData.Barracks_GoldCost_Peasant;
			num -= this.LocallyMade_Archers * localWorldData.Barracks_GoldCost_Archer;
			num -= this.LocallyMade_Pikemen * localWorldData.Barracks_GoldCost_Pikeman;
			num -= this.LocallyMade_Swordsmen * localWorldData.Barracks_GoldCost_Swordsman;
			num -= this.LocallyMade_Catapults * localWorldData.Barracks_GoldCost_Catapult;
			return (double)num;
		}

		// Token: 0x06002E77 RID: 11895 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public static void loadVillageSounds()
		{
		}

		// Token: 0x06002E78 RID: 11896 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void manageBackgroundSounds()
		{
		}

		// Token: 0x06002E79 RID: 11897 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void manageWorkingSounds(VillageMapBuilding building)
		{
		}

		// Token: 0x06002E7A RID: 11898 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void randomiseSounds()
		{
		}

		// Token: 0x06002E7B RID: 11899 RVA: 0x00252AB0 File Offset: 0x00250CB0
		private void runPrimaryResourceBuilding(VillageMapBuilding building, int storageBuilding)
		{
			VillageMapBuilding villageMapBuilding = null;
			if (building.calcRate > 0.0)
			{
				villageMapBuilding = this.findBuildingType(storageBuilding);
			}
			if (villageMapBuilding == null)
			{
				if (building.worker == null)
				{
					if (building.gotEmployee)
					{
						building.worker = new VillageMapPerson(this.gfx);
						building.productionState = 0;
						building.worker.setPos(building.buildingLocation);
						this.initIdlingAnim(building);
					}
					else
					{
						building.open = false;
					}
				}
				else if (!building.gotEmployee)
				{
					building.worker.dispose();
					building.worker = null;
					building.productionState = 0;
					building.open = false;
				}
				building.workerNeedsReInitializing = true;
				switch (building.productionState)
				{
				case 0:
					if (building.worker != null && !building.worker.idling)
					{
						this.initIdlingAnim(building);
					}
					break;
				case 1:
				{
					Point realStart = Point.Truncate(building.worker.currentPos);
					Point realEnd = VillageBuildingsData.tileToPixel(building.buildingLocation);
					building.worker.startJourney(realStart, realEnd, 0.0);
					this.initWalkingAnim(building);
					building.productionState = 2;
					break;
				}
				case 2:
					if (building.worker.isJourneyOver())
					{
						building.productionState = 0;
						this.initIdlingAnim(building);
					}
					break;
				}
				int buildingType = building.buildingType;
				if (buildingType == 17 && building.secondaryWorker != null)
				{
					building.secondaryWorker.dispose();
					building.secondaryWorker = null;
				}
			}
			else
			{
				int num = 1;
				if (building.worker == null)
				{
					building.worker = new VillageMapPerson(this.gfx);
					building.worker.setPos(building.buildingLocation);
					building.workerNeedsReInitializing = true;
					building.worker.initWorkerSprite();
				}
				if (building.workerNeedsReInitializing)
				{
					this.getDistanceThroughCycle(building);
					double calcRate = building.calcRate;
					building.journeyTime = this.getJourneyTime(building.buildingLocation, villageMapBuilding.buildingLocation);
					building.productionTime = building.calcRate - building.journeyTime * 2.0;
					building.productionState = 0;
					num = 2;
					building.workerNeedsReInitializing = false;
					this.initWorkingAnim(building, true);
				}
				for (int i = 0; i < num; i++)
				{
					switch (building.productionState)
					{
					case 0:
					{
						double num2 = this.getDistanceThroughCycle(building) * building.calcRate;
						if (num2 >= building.productionTime)
						{
							double distThroughJourney = (num2 - building.productionTime) / building.journeyTime;
							building.worker.startJourneyTileBased(building.buildingLocation, villageMapBuilding.buildingLocation, distThroughJourney);
							this.initCarryingAnim(building);
							building.productionState = 1;
						}
						else
						{
							this.manageWorkingSounds(building);
						}
						break;
					}
					case 1:
						if (building.worker.isJourneyOver())
						{
							double num3 = this.getDistanceThroughCycle(building) * building.calcRate;
							double distThroughJourney2 = (num3 - (building.productionTime + building.journeyTime)) / building.journeyTime;
							building.worker.startJourneyTileBased(villageMapBuilding.buildingLocation, building.buildingLocation, distThroughJourney2);
							this.initWalkingAnim(building);
							building.updateProductionGFX(true);
							building.productionState = 2;
							if (villageMapBuilding.buildingType == 3)
							{
								if (this.granaryOpenCount == 0)
								{
									villageMapBuilding.open = true;
									this.granaryOpenCount = 150;
									this.updateGFXState(villageMapBuilding);
									villageMapBuilding.updateGranary(this.gfx, this);
								}
								else
								{
									this.granaryOpenCount = 150;
								}
							}
						}
						break;
					case 2:
						building.updateProductionGFX(false);
						if (building.worker.isJourneyOver())
						{
							building.productionSprite.clearText();
							building.productionSprite.clearSecondText();
							building.productionSprite.Visible = false;
							double num4 = this.getDistanceThroughCycle(building) * building.calcRate;
							if (num4 < building.productionTime)
							{
								building.productionState = 0;
								this.initWorkingAnim(building, false);
							}
						}
						break;
					}
				}
				int buildingType2 = building.buildingType;
				if (buildingType2 == 17)
				{
					if (building.secondaryWorker == null)
					{
						building.secondaryWorker = new VillageMapPerson(this.gfx);
						Random random = new Random((int)building.buildingID);
						switch (random.Next(3))
						{
						case 0:
							building.secondaryWorker.setPixelPos(new Point(-52, -9));
							break;
						case 1:
							building.secondaryWorker.setPixelPos(new Point(75, 0));
							break;
						case 2:
							building.secondaryWorker.setPixelPos(new Point(22, 30));
							break;
						}
						building.secondaryWorker.initWorkerSpriteInBuilding(building.baseSprite);
						building.data2 = random.Next(8);
						building.secondaryWorker.initAnim(GFXLibrary.Instance.CowAnimTexID, building.data2, VillageMap.cowLayAnim, 100);
						building.data1 = 0;
					}
					if (building.data1 == 0)
					{
						if (building.secondaryWorker.workerSprite.CurrentFramID == VillageMap.cowLayAnim.Length - 1)
						{
							building.data1 = 1;
							building.secondaryWorker.initAnim(GFXLibrary.Instance.CowAnimTexID, 128 + building.data2, VillageMap.cowIdleAnim, 100);
						}
					}
					else if (building.data1 == 1 && building.secondaryWorker.workerSprite.CurrentFramID == VillageMap.cowIdleAnim.Length - 1)
					{
						Random random2 = new Random();
						if (random2.Next(5) == 1)
						{
							building.data1 = 0;
							building.secondaryWorker.initAnim(GFXLibrary.Instance.CowAnimTexID, building.data2, VillageMap.cowLayAnim, 100);
						}
					}
					building.secondaryWorker.update();
				}
				if (building.productionState == 0)
				{
					building.worker.fadeToSolid();
				}
				else
				{
					this.manageFadeOverBuildings(building.worker, building, villageMapBuilding);
				}
			}
			if (building.worker != null)
			{
				building.worker.update();
			}
		}

		// Token: 0x06002E7C RID: 11900 RVA: 0x00253048 File Offset: 0x00251248
		private void manageFadeOverBuildings(VillageMapPerson worker, VillageMapBuilding building, VillageMapBuilding destBuilding)
		{
			PointF pos = worker.getPos();
			Point point = new Point((int)pos.X, (int)pos.Y);
			bool flag = true;
			bool flag2 = false;
			for (int i = 0; i < 16; i++)
			{
				Point worldPos = new Point(point.X - 8 + i, point.Y + 5);
				Point worldPos2 = new Point(point.X - 8 + i, point.Y - 30);
				long buildingIDFromWorldPos = VillageMap.villageClickMask.getBuildingIDFromWorldPos(worldPos);
				long buildingIDFromWorldPos2 = VillageMap.villageClickMask.getBuildingIDFromWorldPos(worldPos2);
				if (buildingIDFromWorldPos >= 0L || buildingIDFromWorldPos2 >= 0L)
				{
					flag = false;
				}
				if (buildingIDFromWorldPos == building.buildingID || buildingIDFromWorldPos2 == building.buildingID)
				{
					flag2 = true;
					break;
				}
				if (destBuilding != null && (buildingIDFromWorldPos == destBuilding.buildingID || buildingIDFromWorldPos2 == destBuilding.buildingID))
				{
					flag2 = true;
					break;
				}
			}
			for (int j = 0; j < 35; j++)
			{
				Point worldPos3 = new Point(point.X - 8, point.Y - 30 + j);
				Point worldPos4 = new Point(point.X + 8, point.Y - 30 + j);
				long buildingIDFromWorldPos3 = VillageMap.villageClickMask.getBuildingIDFromWorldPos(worldPos3);
				long buildingIDFromWorldPos4 = VillageMap.villageClickMask.getBuildingIDFromWorldPos(worldPos4);
				if (buildingIDFromWorldPos3 >= 0L || buildingIDFromWorldPos4 >= 0L)
				{
					flag = false;
				}
				if (buildingIDFromWorldPos3 == building.buildingID || buildingIDFromWorldPos4 == building.buildingID)
				{
					flag2 = true;
					break;
				}
				if (destBuilding != null && (buildingIDFromWorldPos3 == destBuilding.buildingID || buildingIDFromWorldPos4 == destBuilding.buildingID))
				{
					flag2 = true;
					break;
				}
			}
			if (flag || flag2)
			{
				worker.fadeToSolid();
				return;
			}
			worker.fadeToTransparent();
		}

		// Token: 0x06002E7D RID: 11901 RVA: 0x002531E4 File Offset: 0x002513E4
		public void initIdlingAnim(VillageMapBuilding building)
		{
			building.worker.idling = true;
			building.worker.working = false;
			building.open = false;
			switch (building.buildingType)
			{
			case 6:
				building.worker.initAnim(GFXLibrary.Instance.WoodcutterAnimTexID, 256, VillageMap.woodcutterIdleAnim, 50);
				return;
			case 7:
				building.worker.initAnim(GFXLibrary.Instance.StonemasonAnimTexID, 3, 1, 50);
				return;
			case 8:
				building.worker.initAnim(GFXLibrary.Instance.IronMinerAnimTexID, 3, 1, 50);
				return;
			case 9:
				building.worker.initAnim(GFXLibrary.Instance.PitchworkerAnimTexID, 255, VillageMap.pitchworkerIdleAnim, 75);
				return;
			case 12:
			{
				building.worker.setPos(building.buildingLocation);
				PointF currentPos = building.worker.getCurrentPos();
				currentPos.X -= 81f;
				currentPos.Y += 23f;
				building.worker.setPixelPos(Point.Truncate(currentPos));
				building.worker.initAnim(GFXLibrary.Instance.Body_brewerTexID, 255, VillageMap.brewerIdleAnim, 75);
				return;
			}
			case 13:
			{
				building.worker.setPos(building.buildingLocation);
				PointF currentPos2 = building.worker.getCurrentPos();
				currentPos2.X -= 66f;
				currentPos2.Y += 15f;
				building.worker.setPixelPos(Point.Truncate(currentPos2));
				building.worker.initAnim(GFXLibrary.Instance.Farmer3AnimTexID, 256, VillageMap.farmer3IdleAnim, 150);
				return;
			}
			case 14:
			{
				building.worker.setPos(building.buildingLocation);
				PointF currentPos3 = building.worker.getCurrentPos();
				currentPos3.X -= 19f;
				currentPos3.Y += 43f;
				building.worker.setPixelPos(Point.Truncate(currentPos3));
				building.worker.initAnim(GFXLibrary.Instance.BakerAnimTexID, 255, VillageMap.bakerIdleAnim, 100);
				return;
			}
			case 15:
			{
				building.worker.setPos(building.buildingLocation);
				PointF currentPos4 = building.worker.getCurrentPos();
				currentPos4.X += 22f;
				currentPos4.Y += 22f;
				building.worker.setPixelPos(Point.Truncate(currentPos4));
				building.worker.initAnim(GFXLibrary.Instance.Farmer3AnimTexID, 256, VillageMap.farmer3IdleAnim, 150);
				return;
			}
			case 16:
			{
				building.worker.setPos(building.buildingLocation);
				PointF currentPos5 = building.worker.getCurrentPos();
				currentPos5.X += 32f;
				currentPos5.Y += 3f;
				building.worker.setPixelPos(Point.Truncate(currentPos5));
				building.worker.initAnim(GFXLibrary.Instance.Farmer3AnimTexID, 256, VillageMap.farmer3IdleAnim, 150);
				this.removeAnimals(building);
				return;
			}
			case 17:
			{
				building.worker.setPos(building.buildingLocation);
				PointF currentPos6 = building.worker.getCurrentPos();
				currentPos6.X -= 37f;
				currentPos6.Y -= 20f;
				building.worker.setPixelPos(Point.Truncate(currentPos6));
				building.worker.initAnim(GFXLibrary.Instance.Farmer3AnimTexID, 256, VillageMap.farmer3IdleAnim, 150);
				return;
			}
			case 18:
			{
				building.worker.setPos(building.buildingLocation);
				PointF currentPos7 = building.worker.getCurrentPos();
				currentPos7.X += 26f;
				currentPos7.Y -= 28f;
				building.worker.setPixelPos(Point.Truncate(currentPos7));
				building.worker.initAnim(GFXLibrary.Instance.Farmer3AnimTexID, 256, VillageMap.farmer3IdleAnim, 150);
				return;
			}
			case 19:
				building.worker.initAnim(GFXLibrary.Instance.Body_tailorTexID, 255, VillageMap.tailorIdleAnim, 75);
				this.removeAnimals(building);
				return;
			case 21:
				building.worker.initAnim(GFXLibrary.Instance.Body_carpenterTexID, 255, VillageMap.carpenterIdleAnim, 75);
				return;
			case 22:
				building.worker.initAnim(GFXLibrary.Instance.Body_hunterTexID, 255, VillageMap.hunterIdleAnim, 75);
				return;
			case 23:
				building.worker.initAnim(GFXLibrary.Instance.Farmer3AnimTexID, 256, VillageMap.farmer3IdleAnim, 150);
				return;
			case 24:
			case 25:
				building.worker.initAnim(GFXLibrary.Instance.DockworkerAnimTexID, 383, VillageMap.dockworkerIdleAnim, 75);
				return;
			case 26:
				building.worker.initAnim(GFXLibrary.Instance.MetalWorkerAnimTexID, 383, VillageMap.metalWorkerIdleAnim, 75);
				return;
			case 28:
				building.worker.initAnim(GFXLibrary.Instance.PoleturnerAnimTexID, 3, 1, 50);
				return;
			case 29:
				building.worker.initAnim(GFXLibrary.Instance.FletcherAnimTexID, 3, 1, 50);
				return;
			case 30:
				building.worker.initAnim(GFXLibrary.Instance.BlacksmithAnimTexID, 383, VillageMap.blacksmithIdleAnim, 75);
				return;
			case 31:
				building.worker.initAnim(GFXLibrary.Instance.ArmourerAnimTexID, 383, VillageMap.armourerIdleAnim, 75);
				return;
			case 32:
				building.worker.initAnim(GFXLibrary.Instance.Body_siegeworkerTexID, 383, VillageMap.siegeWorkerIdleAnim, 75);
				return;
			case 33:
				building.worker.initAnim(GFXLibrary.Instance.Farmer3AnimTexID, 256, VillageMap.farmer3IdleAnim, 150);
				return;
			}
			building.worker.initAnim(GFXLibrary.Instance.WoodcutterAnimTexID, 256, VillageMap.woodcutterIdleAnim, 50);
		}

		// Token: 0x06002E7E RID: 11902 RVA: 0x0025381C File Offset: 0x00251A1C
		public void initCarryingAnim(VillageMapBuilding building)
		{
			building.worker.idling = false;
			building.worker.working = false;
			building.open = false;
			switch (building.buildingType)
			{
			case 6:
				building.worker.initAnim(GFXLibrary.Instance.WoodcutterAnimTexID, 7, 128, 16, 8, 50, true);
				return;
			case 7:
				building.worker.initAnim(GFXLibrary.Instance.StonemasonAnimTexID, 7, 128, 16, 8, 50, true);
				return;
			case 8:
				building.worker.initAnim(GFXLibrary.Instance.IronMinerAnimTexID, 7, 128, 16, 8, 50, true);
				return;
			case 9:
				building.worker.initAnim(GFXLibrary.Instance.PitchworkerAnimTexID, 7, 128, 16, 8, 50, true);
				return;
			case 12:
				building.worker.initAnim(GFXLibrary.Instance.Body_brewerTexID, 7, 128, 16, 8, 50, true);
				return;
			case 13:
				building.worker.initAnim(GFXLibrary.Instance.FarmerAnimTexID, 7, 256, 16, 8, 50, true);
				return;
			case 14:
				building.worker.initAnim(GFXLibrary.Instance.BakerAnimTexID, 7, 128, 16, 8, 50, true);
				return;
			case 15:
				building.worker.initAnim(GFXLibrary.Instance.Farmer2AnimTexID, 7, 256, 16, 8, 50, true);
				return;
			case 16:
				building.worker.initAnim(GFXLibrary.Instance.Farmer2AnimTexID, 7, 128, 16, 8, 50, true);
				return;
			case 17:
				building.worker.initAnim(GFXLibrary.Instance.FarmerAnimTexID, 7, 384, 16, 8, 50, true);
				return;
			case 18:
				building.worker.initAnim(GFXLibrary.Instance.Farmer2AnimTexID, 7, 512, 16, 8, 50, true);
				return;
			case 19:
				building.worker.initAnim(GFXLibrary.Instance.Body_tailorTexID, 7, 128, 16, 8, 50, true);
				return;
			case 21:
				building.worker.initAnim(GFXLibrary.Instance.Body_carpenterTexID, 7, 128, 16, 8, 50, true);
				return;
			case 22:
				building.worker.initAnim(GFXLibrary.Instance.Body_hunterTexID, 7, 128, 16, 8, 50, true);
				return;
			case 23:
				building.worker.initAnim(GFXLibrary.Instance.Farmer2AnimTexID, 7, 384, 16, 8, 50, true);
				return;
			case 24:
				building.worker.initAnim(GFXLibrary.Instance.DockworkerAnimTexID, 7, 256, 16, 8, 50, true);
				return;
			case 25:
				building.worker.initAnim(GFXLibrary.Instance.DockworkerAnimTexID, 7, 128, 16, 8, 50, true);
				return;
			case 26:
				building.worker.initAnim(GFXLibrary.Instance.MetalWorkerAnimTexID, 7, 256, 16, 8, 50, true);
				return;
			case 28:
				building.worker.initAnim(GFXLibrary.Instance.PoleturnerAnimTexID, 7, 128, 16, 8, 50, true);
				return;
			case 29:
				building.worker.initAnim(GFXLibrary.Instance.FletcherAnimTexID, 7, 256, 16, 8, 50, true);
				return;
			case 30:
				building.worker.initAnim(GFXLibrary.Instance.BlacksmithAnimTexID, 7, 128, 16, 8, 50, true);
				return;
			case 31:
				building.worker.initAnim(GFXLibrary.Instance.ArmourerAnimTexID, 7, 128, 16, 8, 50, true);
				return;
			case 32:
				building.worker.initAnim(GFXLibrary.Instance.Body_siegeworkerTexID, 7, 256, 16, 8, 50, true);
				return;
			case 33:
				building.worker.initAnim(GFXLibrary.Instance.Farmer2AnimTexID, 7, 0, 16, 8, 50, true);
				return;
			}
			building.worker.initAnim(GFXLibrary.Instance.WoodcutterAnimTexID, 7, 128, 16, 8, 50, true);
		}

		// Token: 0x06002E7F RID: 11903 RVA: 0x00253C1C File Offset: 0x00251E1C
		public void initCollectingAnim(VillageMapBuilding building)
		{
			building.worker.idling = false;
			building.worker.working = false;
			building.open = false;
			switch (building.buildingType)
			{
			case 28:
				building.worker.initAnim(GFXLibrary.Instance.PoleturnerAnimTexID, 7, 256, 16, 8, 50, true);
				return;
			case 29:
				building.worker.initAnim(GFXLibrary.Instance.FletcherAnimTexID, 7, 128, 16, 8, 50, true);
				return;
			case 30:
				building.worker.initAnim(GFXLibrary.Instance.BlacksmithAnimTexID, 7, 256, 16, 8, 50, true);
				return;
			case 31:
				building.worker.initAnim(GFXLibrary.Instance.ArmourerAnimTexID, 7, 256, 16, 8, 50, true);
				return;
			case 32:
				building.worker.initAnim(GFXLibrary.Instance.Body_siegeworkerTexID, 7, 128, 16, 8, 50, true);
				return;
			default:
				building.worker.initAnim(GFXLibrary.Instance.WoodcutterAnimTexID, 7, 128, 16, 8, 50, true);
				return;
			}
		}

		// Token: 0x06002E80 RID: 11904 RVA: 0x00253D3C File Offset: 0x00251F3C
		public void initWalkingAnim(VillageMapBuilding building)
		{
			building.worker.idling = false;
			building.worker.working = false;
			building.open = false;
			int buildingType = building.buildingType;
			switch (buildingType)
			{
			case 6:
				building.worker.initAnim(GFXLibrary.Instance.WoodcutterAnimTexID, 7, 0, 16, 8, 50, true);
				return;
			case 7:
				building.worker.initAnim(GFXLibrary.Instance.StonemasonAnimTexID, 7, 0, 16, 8, 50, true);
				return;
			case 8:
				building.worker.initAnim(GFXLibrary.Instance.IronMinerAnimTexID, 7, 0, 16, 8, 50, true);
				return;
			case 9:
				building.worker.initAnim(GFXLibrary.Instance.PitchworkerAnimTexID, 7, 0, 16, 8, 50, true);
				return;
			case 10:
			case 11:
			case 20:
			case 27:
				break;
			case 12:
				building.worker.initAnim(GFXLibrary.Instance.Body_brewerTexID, 7, 0, 16, 8, 50, true);
				return;
			case 13:
			case 15:
			case 16:
			case 17:
			case 18:
			case 23:
			case 33:
				building.worker.initAnim(GFXLibrary.Instance.FarmerAnimTexID, 7, 0, 16, 8, 50, true);
				return;
			case 14:
				building.worker.initAnim(GFXLibrary.Instance.BakerAnimTexID, 7, 0, 16, 8, 50, true);
				return;
			case 19:
				building.worker.initAnim(GFXLibrary.Instance.Body_tailorTexID, 7, 0, 16, 8, 50, true);
				return;
			case 21:
				building.worker.initAnim(GFXLibrary.Instance.Body_carpenterTexID, 7, 0, 16, 8, 50, true);
				return;
			case 22:
				building.worker.initAnim(GFXLibrary.Instance.Body_hunterTexID, 7, 0, 16, 8, 50, true);
				return;
			case 24:
			case 25:
				building.worker.initAnim(GFXLibrary.Instance.DockworkerAnimTexID, 7, 0, 16, 8, 50, true);
				return;
			case 26:
				building.worker.initAnim(GFXLibrary.Instance.MetalWorkerAnimTexID, 7, 0, 16, 8, 50, true);
				return;
			case 28:
				building.worker.initAnim(GFXLibrary.Instance.PoleturnerAnimTexID, 7, 0, 16, 8, 50, true);
				return;
			case 29:
				building.worker.initAnim(GFXLibrary.Instance.FletcherAnimTexID, 7, 0, 16, 8, 50, true);
				return;
			case 30:
				building.worker.initAnim(GFXLibrary.Instance.BlacksmithAnimTexID, 7, 0, 16, 8, 50, true);
				return;
			case 31:
				building.worker.initAnim(GFXLibrary.Instance.ArmourerAnimTexID, 7, 0, 16, 8, 50, true);
				return;
			case 32:
				building.worker.initAnim(GFXLibrary.Instance.Body_siegeworkerTexID, 7, 0, 16, 8, 50, true);
				return;
			default:
				if (buildingType == 78)
				{
					if (building.secondaryWorker != null)
					{
						building.secondaryWorker.initAnim(GFXLibrary.Instance.TraderHorseAnimTexID, 7, 0, 16, 8, 50, true);
						return;
					}
					building.worker.initAnim(GFXLibrary.Instance.TraderAnimTexID, 7, 0, 16, 8, 50, true);
					return;
				}
				break;
			}
			building.worker.initAnim(GFXLibrary.Instance.WoodcutterAnimTexID, 7, 0, 16, 8, 50, true);
		}

		// Token: 0x06002E81 RID: 11905 RVA: 0x00254054 File Offset: 0x00252254
		public void initWorkingAnim(VillageMapBuilding building, bool initialCall)
		{
			if (building == null || building.animSprite == null)
			{
				return;
			}
			building.worker.idling = false;
			building.worker.working = true;
			building.open = true;
			switch (building.buildingType)
			{
			case 6:
				building.worker.workerSprite.Visible = false;
				goto IL_4DA;
			case 7:
				building.worker.workerSprite.Visible = false;
				goto IL_4DA;
			case 8:
				building.worker.workerSprite.Visible = false;
				goto IL_4DA;
			case 9:
				building.worker.workerSprite.Visible = false;
				goto IL_4DA;
			case 12:
				building.worker.workerSprite.Visible = false;
				goto IL_4DA;
			case 13:
			{
				building.worker.workerSprite.Visible = false;
				PointF center = new PointF(0f, 0f);
				Random random = new Random();
				int data = random.Next(5);
				if (building.randState < 0)
				{
					data = this.findRandStateData(building, data);
				}
				else
				{
					this.setRandStateData(building, data);
				}
				switch (data)
				{
				case 1:
					center = new PointF(83f, 51f);
					building.animSprite.changeBaseFrame(162);
					break;
				case 2:
					center = new PointF(-18f, 51f);
					building.animSprite.changeBaseFrame(166);
					break;
				case 3:
					center = new PointF(-21f, 53f);
					building.animSprite.changeBaseFrame(160);
					break;
				case 4:
					center = new PointF(40f, 24f);
					building.animSprite.changeBaseFrame(160);
					break;
				default:
					center = new PointF(65f, 34f);
					building.animSprite.changeBaseFrame(160);
					break;
				}
				building.animSprite.Center = center;
				goto IL_4DA;
			}
			case 14:
				building.worker.workerSprite.Visible = false;
				goto IL_4DA;
			case 15:
			case 23:
				building.worker.workerSprite.Visible = false;
				goto IL_4DA;
			case 16:
				building.worker.workerSprite.Visible = false;
				this.CreateAnimals(building);
				goto IL_4DA;
			case 17:
				building.worker.workerSprite.Visible = false;
				goto IL_4DA;
			case 18:
				building.worker.workerSprite.Visible = false;
				goto IL_4DA;
			case 19:
				building.worker.workerSprite.Visible = false;
				this.CreateAnimals(building);
				goto IL_4DA;
			case 21:
				building.worker.workerSprite.Visible = false;
				goto IL_4DA;
			case 22:
				building.worker.workerSprite.Visible = false;
				goto IL_4DA;
			case 24:
			case 25:
				building.worker.initAnim(GFXLibrary.Instance.DockworkerAnimTexID, 383, VillageMap.dockworkerIdleAnim, 75);
				goto IL_4DA;
			case 26:
				building.worker.workerSprite.Visible = false;
				goto IL_4DA;
			case 28:
				building.worker.workerSprite.Visible = false;
				goto IL_4DA;
			case 29:
				building.worker.workerSprite.Visible = false;
				goto IL_4DA;
			case 30:
				building.worker.workerSprite.Visible = false;
				goto IL_4DA;
			case 31:
				building.worker.workerSprite.Visible = false;
				goto IL_4DA;
			case 32:
				building.worker.workerSprite.Visible = false;
				goto IL_4DA;
			case 33:
			{
				building.worker.workerSprite.Visible = false;
				PointF center2 = new PointF(0f, 0f);
				Random random2 = new Random();
				int data2 = random2.Next(5);
				if (building.randState < 0)
				{
					data2 = this.findRandStateData(building, data2);
				}
				else
				{
					this.setRandStateData(building, data2);
				}
				switch (data2)
				{
				case 1:
					center2 = new PointF(11f, 64f);
					building.animSprite.changeBaseFrame(64);
					break;
				case 2:
					center2 = new PointF(18f, 76f);
					building.animSprite.changeBaseFrame(71);
					break;
				case 3:
					center2 = new PointF(14f, 71f);
					building.animSprite.changeBaseFrame(66);
					break;
				case 4:
					center2 = new PointF(-31f, 54f);
					building.animSprite.changeBaseFrame(70);
					break;
				default:
					center2 = new PointF(-22f, 51f);
					building.animSprite.changeBaseFrame(64);
					break;
				}
				building.animSprite.Center = center2;
				goto IL_4DA;
			}
			}
			building.worker.initAnim(GFXLibrary.Instance.WoodcutterAnimTexID, 256, VillageMap.woodcutterIdleAnim, 50);
			IL_4DA:
			if (GameEngine.Instance.Village != null)
			{
				GameEngine.Instance.Village.updateGFXState(building);
			}
		}

		// Token: 0x06002E82 RID: 11906 RVA: 0x00254558 File Offset: 0x00252758
		private void runSecondaryResourceBuilding(VillageMapBuilding building, int storageBuildingType, int sourceBuildingType, double calcRate)
		{
			VillageMapBuilding villageMapBuilding = this.findBuildingType(storageBuildingType);
			VillageMapBuilding villageMapBuilding2 = this.findBuildingType(sourceBuildingType);
			if (villageMapBuilding == null || villageMapBuilding2 == null || calcRate == 0.0)
			{
				if (building.worker == null)
				{
					if (building.gotEmployee)
					{
						building.worker = new VillageMapPerson(this.gfx);
						building.productionState = 0;
						building.worker.setPos(building.buildingLocation);
						this.initIdlingAnim(building);
						building.workerNeedsReInitializing = true;
					}
					else
					{
						building.open = false;
					}
				}
				else if (!building.gotEmployee)
				{
					building.worker.dispose();
					building.worker = null;
					building.productionState = 0;
					building.open = false;
				}
				if (building.workerNeedsReInitializing)
				{
					this.reInitializeSecondaryBuilding(building, calcRate, villageMapBuilding, villageMapBuilding2);
					building.workerNeedsReInitializing = false;
				}
				switch (building.productionState)
				{
				case 1:
				case 3:
				case 4:
				{
					building.worker.workerSprite.Visible = true;
					Point realStart = Point.Truncate(building.worker.currentPos);
					Point realEnd = VillageBuildingsData.tileToPixel(building.buildingLocation);
					building.worker.startJourney(realStart, realEnd, 0.0);
					this.initWalkingAnim(building);
					building.productionState = 5;
					break;
				}
				case 2:
				case 5:
					if (building.worker.isJourneyOver())
					{
						building.productionState = 0;
						this.initIdlingAnim(building);
					}
					break;
				}
			}
			else
			{
				int num = 1;
				if (building.worker == null)
				{
					building.worker = new VillageMapPerson(this.gfx);
					building.worker.setPos(building.buildingLocation);
					building.workerNeedsReInitializing = true;
					building.worker.initWorkerSprite();
				}
				if (building.workerNeedsReInitializing)
				{
					this.reInitializeSecondaryBuilding(building, calcRate, villageMapBuilding, villageMapBuilding2);
					if (building.serverCalcRate == 0.0)
					{
						num = 0;
					}
					else
					{
						building.productionState = 0;
						num = 2;
						building.workerNeedsReInitializing = false;
						this.initWorkingAnim(building, true);
					}
				}
				this.getNumTrips(building.buildingType);
				for (int i = 0; i < num; i++)
				{
					switch (building.productionState)
					{
					case 0:
					{
						if (!building.worker.working)
						{
							this.initWorkingAnim(building, false);
						}
						double num2 = this.getDistanceThroughCycleSecondary(building) * building.calcRate;
						double num3 = num2 % building.tripCalcRate;
						if (num3 >= building.productionTime)
						{
							double distThroughJourney = (num3 - building.productionTime) / building.journeyTime;
							if (building.weaponContinuance)
							{
								distThroughJourney = 0.0;
							}
							building.worker.startJourneyTileBased(building.buildingLocation, villageMapBuilding2.buildingLocation, distThroughJourney);
							this.initWalkingAnim(building);
							building.productionState = 1;
						}
						else
						{
							building.weaponContinuance = false;
							this.manageWorkingSounds(building);
						}
						break;
					}
					case 1:
						if (building.worker.isJourneyOver())
						{
							double num4 = this.getDistanceThroughCycleSecondary(building) * building.calcRate;
							double num5 = num4 % building.tripCalcRate;
							double distThroughJourney2 = (num5 - (building.productionTime + building.journeyTime)) / building.journeyTime;
							if (building.weaponContinuance)
							{
								distThroughJourney2 = 0.0;
							}
							building.worker.startJourneyTileBased(villageMapBuilding2.buildingLocation, building.buildingLocation, distThroughJourney2);
							this.initCollectingAnim(building);
							building.productionState = 2;
						}
						break;
					case 2:
						if (building.worker.isJourneyOver())
						{
							building.weaponContinuance = false;
							double num6 = this.getDistanceThroughCycleSecondary(building) * building.calcRate;
							double num7 = building.calcRate - building.journeyTime2 * 2.0 - GameEngine.Instance.LocalWorldData.WeaponProductionOffScreenTime;
							if (num6 >= num7)
							{
								double distThroughJourney3 = (num6 - num7) / building.journeyTime2;
								building.worker.startJourneyTileBased(building.buildingLocation, villageMapBuilding.buildingLocation, distThroughJourney3);
								this.initCarryingAnim(building);
								building.productionState = 3;
							}
							else
							{
								building.productionState = 0;
								this.initWorkingAnim(building, false);
							}
						}
						break;
					case 3:
						if (building.worker.isJourneyOver())
						{
							building.productionState = 4;
							building.worker.workerSprite.Visible = false;
							building.weaponContinuance = true;
						}
						break;
					case 4:
					{
						double num8 = this.getDistanceThroughCycleSecondary(building) * building.calcRate;
						double num9 = building.calcRate - building.journeyTime2 * 2.0 - GameEngine.Instance.LocalWorldData.WeaponProductionOffScreenTime;
						if (num8 < num9)
						{
							building.worker.workerSprite.Visible = true;
							building.productionState = 5;
							double distThroughJourney4 = 0.0;
							building.worker.startJourneyTileBased(villageMapBuilding.buildingLocation, building.buildingLocation, distThroughJourney4);
							this.initWalkingAnim(building);
						}
						break;
					}
					case 5:
						if (building.worker.isJourneyOver())
						{
							building.productionState = 0;
							this.initWorkingAnim(building, false);
						}
						break;
					}
				}
				if (building.productionState == 0)
				{
					building.worker.fadeToSolid();
				}
				else
				{
					this.manageFadeOverBuildings(building.worker, building, villageMapBuilding);
				}
			}
			if (building.worker != null)
			{
				building.worker.update();
			}
		}

		// Token: 0x06002E83 RID: 11907 RVA: 0x00254A68 File Offset: 0x00252C68
		private int getNumTrips(int buildingType)
		{
			WorldData localWorldData = GameEngine.Instance.LocalWorldData;
			int trips = 1;
			switch (buildingType)
			{
			case 28:
				trips = localWorldData.pikesBaseProductionTrips;
				break;
			case 29:
				trips = localWorldData.bowsBaseProductionTrips;
				break;
			case 30:
				trips = localWorldData.swordsBaseProductionTrips;
				break;
			case 31:
				trips = localWorldData.armourBaseProductionTrips;
				break;
			case 32:
				trips = localWorldData.catapultsBaseProductionTrips;
				break;
			}
			return CardTypes.cards_adjustWeaponProductionTrips(GameEngine.Instance.cardsManager.UserCardData, trips, buildingType);
		}

		// Token: 0x06002E84 RID: 11908 RVA: 0x00254AE4 File Offset: 0x00252CE4
		private void reInitializeSecondaryBuilding(VillageMapBuilding building, double calcRate, VillageMapBuilding destBuilding, VillageMapBuilding sourceBuilding)
		{
			if (destBuilding == null || sourceBuilding == null)
			{
				building.productionTime = 0.0;
				building.journeyTime = 0.0;
				building.journeyTime2 = 0.0;
				return;
			}
			double num = GameEngine.Instance.World.UserResearchData.getResourceCap(GameEngine.Instance.LocalWorldData, building.buildingType, false);
			num *= CardTypes.getResourceCapMultiplier(building.buildingType, GameEngine.Instance.cardsManager.UserCardData);
			double resourceLevel = this.getResourceLevel(building.buildingType);
			if (num > resourceLevel)
			{
				WorldData localWorldData = GameEngine.Instance.LocalWorldData;
				double num2 = (double)this.getNumTrips(building.buildingType);
				building.journeyTime2 = this.getJourneyTime(building.buildingLocation, destBuilding.buildingLocation);
				building.journeyTime = this.getJourneyTime(building.buildingLocation, sourceBuilding.buildingLocation);
				building.productionTime = (building.serverCalcRate - building.journeyTime2 * 2.0 - GameEngine.Instance.LocalWorldData.WeaponProductionOffScreenTime) / num2 - building.journeyTime * 2.0;
				building.calcRate = building.serverCalcRate;
				building.tripCalcRate = (building.serverCalcRate - building.journeyTime2 * 2.0 - GameEngine.Instance.LocalWorldData.WeaponProductionOffScreenTime) / num2;
				return;
			}
			building.productionTime = 0.0;
			building.journeyTime = 0.0;
			building.journeyTime2 = 0.0;
			if (building.productionState == 0)
			{
				building.productionState = 5;
			}
			building.calcRate = 0.0;
			building.tripCalcRate = 0.0;
			building.serverCalcRate = 0.0;
		}

		// Token: 0x06002E85 RID: 11909 RVA: 0x00254CB4 File Offset: 0x00252EB4
		private void runMarketTrader(VillageMapBuilding building)
		{
			building.productionState++;
			if (building.productionState == 60)
			{
				building.secondaryWorker = new VillageMapPerson(this.gfx);
				building.secondaryWorker.setPos(building.buildingLocation);
				building.secondaryWorker.startJourney(VillageBuildingsData.tileToPixel(building.buildingLocation), Point.Truncate(building.worker.endPos), 0.0);
				this.initWalkingAnim(building);
			}
			if (building.worker != null)
			{
				if (building.worker.isJourneyOver())
				{
					building.worker.dispose();
					building.worker = null;
				}
				else
				{
					this.manageFadeOverBuildings(building.worker, building, null);
					building.worker.update();
				}
			}
			if (building.secondaryWorker != null)
			{
				if (building.secondaryWorker.isJourneyOver())
				{
					building.secondaryWorker.dispose();
					building.secondaryWorker = null;
					return;
				}
				this.manageFadeOverBuildings(building.secondaryWorker, building, null);
				building.secondaryWorker.update();
			}
		}

		// Token: 0x06002E86 RID: 11910 RVA: 0x00021CD6 File Offset: 0x0001FED6
		private int findRandStateData(VillageMapBuilding building, int data)
		{
			if (this.randStateArray[building.buildingID] != null)
			{
				data = (int)this.randStateArray[building.buildingID];
				building.randState = data;
				return data;
			}
			this.setRandStateData(building, data);
			return data;
		}

		// Token: 0x06002E87 RID: 11911 RVA: 0x00021D15 File Offset: 0x0001FF15
		private void setRandStateData(VillageMapBuilding building, int data)
		{
			this.randStateArray[building.buildingID] = data;
			building.randState = data;
		}

		// Token: 0x06002E88 RID: 11912 RVA: 0x00254DB4 File Offset: 0x00252FB4
		private void CreateAnimals(VillageMapBuilding building)
		{
			if (this.animalArray[building.buildingID] != null)
			{
				VillageMap.VillageAnimalCollection villageAnimalCollection = (VillageMap.VillageAnimalCollection)this.animalArray[building.buildingID];
				if (villageAnimalCollection != null)
				{
					foreach (VillageMap.VillageAnimal villageAnimal in villageAnimalCollection.animals)
					{
						villageAnimal.recreate(building);
					}
				}
				return;
			}
			int buildingType = building.buildingType;
			if (buildingType != 3)
			{
				if (buildingType != 16)
				{
					if (buildingType == 19)
					{
						VillageMap.VillageAnimalCollection villageAnimalCollection2 = new VillageMap.VillageAnimalCollection();
						for (int i = 0; i < 5; i++)
						{
							VillageMap.VillageAnimal villageAnimal2 = new VillageMap.VillageAnimal();
							villageAnimal2.buildingType = building.buildingType;
							villageAnimal2.id = i;
							villageAnimalCollection2.animals.Add(villageAnimal2);
							villageAnimal2.init(building);
						}
						this.animalArray[building.buildingID] = villageAnimalCollection2;
					}
				}
				else
				{
					VillageMap.VillageAnimalCollection villageAnimalCollection3 = new VillageMap.VillageAnimalCollection();
					for (int j = 0; j < 3; j++)
					{
						VillageMap.VillageAnimal villageAnimal3 = new VillageMap.VillageAnimal();
						villageAnimal3.buildingType = building.buildingType;
						villageAnimal3.id = j;
						villageAnimalCollection3.animals.Add(villageAnimal3);
						villageAnimal3.init(building);
					}
					this.animalArray[building.buildingID] = villageAnimalCollection3;
				}
			}
			else
			{
				VillageMap.VillageAnimalCollection villageAnimalCollection4 = new VillageMap.VillageAnimalCollection();
				for (int k = 0; k < 8; k++)
				{
					VillageMap.VillageAnimal villageAnimal4 = new VillageMap.VillageAnimal();
					villageAnimal4.buildingType = building.buildingType;
					villageAnimal4.id = k;
					villageAnimalCollection4.animals.Add(villageAnimal4);
					villageAnimal4.init(building);
				}
				this.animalArray[building.buildingID] = villageAnimalCollection4;
			}
			if (GameEngine.Instance.Village != null)
			{
				VillageMap village = GameEngine.Instance.Village;
				int num = 50;
				for (int l = 0; l < num; l++)
				{
					this.runAnimals(building, village, 50);
				}
			}
		}

		// Token: 0x06002E89 RID: 11913 RVA: 0x00254FA8 File Offset: 0x002531A8
		private void removeAnimals(VillageMapBuilding building)
		{
			VillageMap.VillageAnimalCollection villageAnimalCollection = (VillageMap.VillageAnimalCollection)this.animalArray[building.buildingID];
			if (villageAnimalCollection != null)
			{
				foreach (VillageMap.VillageAnimal villageAnimal in villageAnimalCollection.animals)
				{
					villageAnimal.dispose();
				}
				villageAnimalCollection.animals.Clear();
			}
			this.animalArray[building.buildingID] = null;
		}

		// Token: 0x06002E8A RID: 11914 RVA: 0x00255034 File Offset: 0x00253234
		private void removeAnimals(long buildingID)
		{
			VillageMap.VillageAnimalCollection villageAnimalCollection = (VillageMap.VillageAnimalCollection)this.animalArray[buildingID];
			if (villageAnimalCollection != null)
			{
				foreach (VillageMap.VillageAnimal villageAnimal in villageAnimalCollection.animals)
				{
					villageAnimal.dispose();
				}
				villageAnimalCollection.animals.Clear();
			}
			this.animalArray[buildingID] = null;
		}

		// Token: 0x06002E8B RID: 11915 RVA: 0x002550B4 File Offset: 0x002532B4
		private void runAnimals(VillageMapBuilding building, VillageMap vm, int tickRate)
		{
			VillageMap.VillageAnimalCollection villageAnimalCollection = (VillageMap.VillageAnimalCollection)this.animalArray[building.buildingID];
			if (villageAnimalCollection != null)
			{
				foreach (VillageMap.VillageAnimal villageAnimal in villageAnimalCollection.animals)
				{
					if (villageAnimal.id == 0)
					{
						villageAnimal.run(building, vm, null, tickRate);
					}
					else
					{
						villageAnimal.run(building, vm, villageAnimalCollection.animals[0], tickRate);
					}
				}
			}
		}

		// Token: 0x1700026D RID: 621
		// (get) Token: 0x06002E8C RID: 11916 RVA: 0x00021D35 File Offset: 0x0001FF35
		internal bool MakePeopleLocked
		{
			get
			{
				return this.makePeopleLocked;
			}
		}

		// Token: 0x06002E8D RID: 11917 RVA: 0x00255144 File Offset: 0x00253344
		public bool CheckPlacementBuildingToTile(Point mapTile, int placementType, out int placementError)
		{
			bool flag = false;
			placementError = 0;
			if (this.Buildings.Exists((VillageMapBuilding villageMapBuilding) => villageMapBuilding.buildingLocation == mapTile && villageMapBuilding.buildingType == placementType))
			{
				return false;
			}
			SpriteWrapper spriteWrapper = new SpriteWrapper
			{
				TextureID = VillageMap.s_villageBuildingData[placementType].baseGfxTexID,
				SpriteNo = VillageMap.s_villageBuildingData[placementType].baseGfxID
			};
			this.lastPlaceBuildingLoc = mapTile;
			if (mapTile.X >= 0 && mapTile.X < this.layout.gridWidth && mapTile.Y >= 0 && mapTile.Y < this.layout.gridHeight)
			{
				Point buildingSpritePos = this.getBuildingSpritePos(mapTile);
				spriteWrapper.PosX = (float)buildingSpritePos.X;
				spriteWrapper.PosY = (float)buildingSpritePos.Y;
				VillageLayoutNew villageLayoutNew = null;
				if (VillageMap.placingAsFree)
				{
					villageLayoutNew = this.buildMoveBuildingLayout();
				}
				if (villageLayoutNew == null)
				{
					villageLayoutNew = this.layout;
				}
				int[] buildingLayout = VillageBuildingsData.getBuildingLayout(VillageMap.s_villageBuildingData[placementType].size);
				ErrorCodes.ErrorCode errorCode = VillageLayoutNew.checkBuildingAgainstLandscape(villageLayoutNew.mapData, buildingLayout, mapTile, placementType, this.layout.gridWidth, this.layout.gridHeight);
				if (errorCode != ErrorCodes.ErrorCode.OK)
				{
					flag = true;
					placementError = 1;
					if (VillageLayoutNew.checkBuildingAgainstOtherBuildings(villageLayoutNew.mapData, buildingLayout, mapTile, placementType) == ErrorCodes.ErrorCode.OK)
					{
						if (placementType == 6 || placementType == 21)
						{
							placementError = 7;
						}
						else if (placementType == 7)
						{
							placementError = 8;
						}
						else if (placementType == 8 || placementType == 26)
						{
							placementError = 9;
						}
						else if (placementType == 9)
						{
							placementError = 10;
						}
						else if (placementType == 18)
						{
							placementError = 11;
						}
						else if (placementType == 23)
						{
							placementError = 12;
						}
						else if (placementType == 25 || placementType == 24)
						{
							placementError = 13;
						}
					}
				}
				else if (VillageLayoutNew.checkBuildingAgainstOtherBuildings(villageLayoutNew.mapData, buildingLayout, mapTile, placementType) != ErrorCodes.ErrorCode.OK)
				{
					flag = true;
					placementError = 1;
				}
				if (!VillageMap.placingAsFree && !this.genericBuildingValidation(mapTile, placementType))
				{
					flag = true;
					placementError = 2;
				}
			}
			else
			{
				flag = true;
			}
			if (!flag && !VillageMap.placingAsFree)
			{
				int maxBuildingQueueLength = this.getMaxBuildingQueueLength();
				int num = this.countNumBuildingsConstructing();
				if (num >= maxBuildingQueueLength)
				{
					flag = true;
					placementError = 3;
				}
				else
				{
					int num2 = 0;
					int num3 = 0;
					int num4 = 0;
					int num5 = 0;
					int num6 = 0;
					int num7 = -1;
					if (!CardTypes.isFreeBuildingPlacement(GameEngine.Instance.cardsManager.UserCardData, placementType, ref num7))
					{
						VillageBuildingsData.calcBuildingCosts(GameEngine.Instance.LocalWorldData, placementType, this.countBuildingType(placementType), ref num2, ref num3, ref num4, ref num5, (int)GameEngine.Instance.World.UserResearchData.Research_Tools, ref num6);
					}
					if (num6 > 0 && GameEngine.Instance.LocalWorldData.constrFlagCost[placementType] > 0 && this.m_capitalBuildingsBuilt != null && this.m_capitalBuildingsBuilt.Contains(placementType))
					{
						num6 = 0;
					}
					VillageMap.StockpileLevels stockpileLevels = new VillageMap.StockpileLevels();
					this.getStockpileLevels(stockpileLevels);
					double num8 = GameEngine.Instance.World.isCapital(this.m_villageID) ? this.m_capitalGold : GameEngine.Instance.World.getCurrentGold();
					if ((num2 > 0 && (double)num2 > stockpileLevels.woodLevel) || (num3 > 0 && (double)num3 > stockpileLevels.stoneLevel) || (num5 > 0 && (double)num5 > num8) || (num6 > 0 && num6 > this.m_numParishFlags))
					{
						flag = true;
						if (num5 > 0 && (double)num5 > num8)
						{
							placementError = 4;
						}
						else if (num6 > 0 && num6 > this.m_numParishFlags)
						{
							placementError = 5;
						}
						else
						{
							placementError = 6;
						}
					}
				}
			}
			return !flag;
		}

		// Token: 0x06002E8E RID: 11918 RVA: 0x00255540 File Offset: 0x00253740
		public void PlaceBuilding(int placementType, Point buildingLocation)
		{
			this.lastBuildingPlacement = DateTime.Now;
			this.inPlaceBuilding = true;
			RemoteServices.Instance.set_PlaceVillageBuilding_UserCallBack(new RemoteServices.PlaceVillageBuilding_UserCallBack(this.buildingPlacedCallback));
			RemoteServices.Instance.PlaceVillageBuilding(this.m_villageID, placementType, buildingLocation);
			VillageMapBuilding villageMapBuilding = new VillageMapBuilding
			{
				buildingLocation = buildingLocation,
				buildingType = placementType,
				buildingID = -1L,
				complete = false,
				completionTime = DateTime.Now.AddDays(1000.0)
			};
			object localBuildingsLock = this._localBuildingsLock;
			lock (localBuildingsLock)
			{
				this.addBuildingToMap(villageMapBuilding, buildingLocation, placementType);
				villageMapBuilding.updateConstructionGFX(VillageMap.localBaseTime, VillageMap.baseServerTime, true, this);
			}
			this.startPlaceBuilding_ShowPanel(placementType, "", false);
		}

		// Token: 0x06002E8F RID: 11919 RVA: 0x00255618 File Offset: 0x00253818
		public void UpdateBG()
		{
			object localBuildingsLock = this._localBuildingsLock;
			lock (localBuildingsLock)
			{
				foreach (VillageMapBuilding villageMapBuilding in this.localBuildings)
				{
					if (!villageMapBuilding.complete && !villageMapBuilding.serverDeleting && villageMapBuilding.updateConstructionGFX(VillageMap.localBaseTime, VillageMap.baseServerTime, false, this) && !villageMapBuilding.completeRequestSent && !this.ViewOnly)
					{
						RemoteServices.Instance.set_VillageBuildingCompleteDataRetrieval_UserCallBack(new RemoteServices.VillageBuildingCompleteDataRetrieval_UserCallBack(this.villageBuildingCompleteDataRetrievalCallback));
						RemoteServices.Instance.VillageBuildingCompleteDataRetrieval(this.m_villageID, villageMapBuilding.buildingID);
						villageMapBuilding.completeRequestSent = true;
					}
				}
			}
		}

		// Token: 0x06002E90 RID: 11920 RVA: 0x002556EC File Offset: 0x002538EC
		public int[] CalcTotalTroopsArray()
		{
			int[] array = new int[]
			{
				this.m_numPeasants,
				this.m_numArchers,
				this.m_numPikemen,
				this.m_numSwordsmen,
				this.m_numCatapults,
				this.m_numCaptains + GameEngine.Instance.World.countYourArmyCaptains(this.VillageID)
			};
			int[] array2 = GameEngine.Instance.World.CountYourArmyTroopsArray(this.VillageID);
			int[] array3 = GameEngine.Instance.World.CountYourReinforcementTroopsArray(this.VillageID);
			int[] array4 = new int[6];
			CastleMap castleMap = (CastleMap)GameEngine.Instance.Castles[this.VillageID];
			if (castleMap != null)
			{
				array4 = castleMap.CountOwnPlacedTroopsArray();
			}
			for (int i = 0; i < 5; i++)
			{
				array[i] += array2[i] + array3[i] + array4[i];
			}
			return array;
		}

		// Token: 0x06002E91 RID: 11921 RVA: 0x002557D4 File Offset: 0x002539D4
		public int GetAffordableRationsLevel()
		{
			decimal d = (decimal)this.getFoodProductionPerDay();
			decimal d2 = this.m_totalPeople / ((decimal)GameEngine.Instance.LocalWorldData.foodConsumptionRate / 24m);
			int result = 3;
			for (int i = 6; i >= 3; i--)
			{
				if (d2 * this.FoodRationsLevels[i] < d)
				{
					result = i;
					break;
				}
			}
			return result;
		}

		// Token: 0x06002E92 RID: 11922 RVA: 0x0025584C File Offset: 0x00253A4C
		public int GetAffordableAleRationsLevel()
		{
			decimal d = (decimal)this.getAleProductionPerDay();
			decimal d2 = this.m_totalPeople / ((decimal)GameEngine.Instance.LocalWorldData.aleConsumptionRate / 24m);
			int result = 0;
			for (int i = 4; i >= 1; i--)
			{
				if (d2 * i < d)
				{
					result = i;
					break;
				}
			}
			return result;
		}

		// Token: 0x06002E93 RID: 11923 RVA: 0x002558C0 File Offset: 0x00253AC0
		internal void CheckVillagersArrival(ControlForm.Tab tab)
		{
			DateTime now = DateTime.Now;
			TimeSpan timeSpan = now - this.m_villageInfoUpdateLastTime;
			double value = (DXTimer.GetCurrentMilliseconds() - VillageMap.localBaseTime) / 1000.0;
			DateTime d = VillageMap.baseServerTime.AddSeconds(value);
			bool flag = false;
			if (this.m_totalPeople >= this.m_housingCapacity && this.m_popularityLevel > 0)
			{
				flag = true;
			}
			else if (this.m_totalPeople <= 4 && this.m_popularityLevel < 0)
			{
				flag = true;
			}
			if (this.m_popularityLevel != 0 && !flag)
			{
				double num = (this.m_immigrationNextChangeTime - d).TotalSeconds + 3.0;
				if (num > 0.0)
				{
					num -= 3.0;
					if (num > 0.0)
					{
						string str = VillageMap.createBuildTimeString((int)num);
						ControlForm controlForm = DX.ControlForm;
						if (controlForm != null)
						{
							controlForm.Log("Time till new peasants arrive: " + str, tab, false);
						}
						this.m_statsMigrationUpdateRequested = false;
						return;
					}
				}
				else if (!this.m_statsMigrationUpdateRequested)
				{
					this.m_statsMigrationUpdateRequested = true;
					if (!this.ViewOnly && timeSpan.TotalSeconds > 30.0)
					{
						this.m_villageInfoUpdateLastTime = now;
						ControlForm controlForm2 = DX.ControlForm;
						if (controlForm2 != null)
						{
							controlForm2.Log("Updating village resources and stats", tab, false);
						}
						RemoteServices.Instance.set_VillageBuildingChangeRates_UserCallBack(new RemoteServices.VillageBuildingChangeRates_UserCallBack(this.villageBuildingChangeRatesCallback));
						RemoteServices.Instance.VillageBuildingChangeRates(this.m_villageID, -1, -1, -1, -1);
						ControlForm controlForm3 = DX.ControlForm;
						if (controlForm3 != null)
						{
							controlForm3.GetService<TroopsrecruitingService>().RandomSleepOrExit(500, 700);
						}
						return;
					}
				}
			}
			else
			{
				this.m_statsMigrationUpdateRequested = false;
			}
		}

		// Token: 0x06002E94 RID: 11924 RVA: 0x00255A6C File Offset: 0x00253C6C
		internal double CalcDailyFaithPoints()
		{
			double num = 0.0;
			foreach (VillageMapBuilding villageMapBuilding in this.localBuildings)
			{
				if (villageMapBuilding.complete)
				{
					int buildingType = villageMapBuilding.buildingType;
					switch (buildingType)
					{
					case 34:
						num += (double)GameEngine.Instance.LocalWorldData.FaithPoints_Chapel;
						break;
					case 35:
						break;
					case 36:
						num += (double)GameEngine.Instance.LocalWorldData.FaithPoints_Church;
						break;
					case 37:
						num += (double)GameEngine.Instance.LocalWorldData.FaithPoints_Cathedral;
						break;
					default:
						if (buildingType - 70 > 3)
						{
							if (buildingType - 74 <= 1)
							{
								num += (double)GameEngine.Instance.LocalWorldData.FaithPoints_LargeShrine;
							}
						}
						else
						{
							num += (double)GameEngine.Instance.LocalWorldData.FaithPoints_SmallShrine;
						}
						break;
					}
				}
			}
			return num;
		}

		// Token: 0x040038DD RID: 14557
		public const int MAP_TILE_WIDTH = 32;

		// Token: 0x040038DE RID: 14558
		public const int MAP_TILE_HEIGHT = 16;

		// Token: 0x040038DF RID: 14559
		public const int MAP_NUM_TILES_WIDE = 64;

		// Token: 0x040038E0 RID: 14560
		public const int MAP_NUM_TILES_HIGH = 128;

		// Token: 0x040038E1 RID: 14561
		private static short[] updatedSaltWorkerAnim = new short[]
		{
			0,
			4,
			8,
			12,
			16,
			20,
			24,
			28,
			32,
			36,
			40,
			44,
			48,
			52,
			16,
			20,
			24,
			28,
			32,
			36,
			40,
			44,
			48,
			52,
			56,
			52,
			48,
			44,
			40,
			36,
			32,
			28,
			24,
			20,
			16,
			20,
			24,
			28,
			32,
			36,
			40,
			44,
			48,
			52,
			56,
			52,
			48,
			44,
			40,
			36,
			32,
			28,
			24,
			20,
			16,
			20,
			24,
			28,
			32,
			36,
			40,
			44,
			48,
			52,
			56,
			52,
			48,
			44,
			40,
			36,
			32,
			28,
			24,
			20,
			16,
			20,
			24,
			28,
			32,
			36,
			40,
			44,
			48,
			52,
			56,
			52,
			48,
			44,
			40,
			36,
			32,
			28,
			24,
			20,
			16,
			20,
			24,
			28,
			32,
			36,
			40,
			44,
			48,
			52,
			56,
			52,
			48,
			44,
			40,
			36,
			32,
			28,
			24,
			20,
			16,
			20,
			24,
			28,
			32,
			36,
			40,
			44,
			48,
			52,
			56,
			52,
			48,
			44,
			40,
			36,
			32,
			28,
			24,
			20,
			16,
			12,
			8,
			4,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0
		};

		// Token: 0x040038E2 RID: 14562
		private static short[] updatedVegWorkerAnim = new short[]
		{
			0,
			4,
			8,
			12,
			16,
			20,
			24,
			28,
			32,
			36,
			40,
			44,
			48,
			52,
			16,
			20,
			24,
			28,
			32,
			36,
			40,
			44,
			48,
			52,
			56,
			52,
			48,
			44,
			40,
			36,
			32,
			28,
			24,
			20,
			16,
			20,
			24,
			28,
			32,
			36,
			40,
			44,
			48,
			52,
			56,
			52,
			48,
			44,
			40,
			36,
			32,
			28,
			24,
			20,
			16,
			20,
			24,
			28,
			32,
			36,
			40,
			44,
			48,
			52,
			56,
			52,
			48,
			44,
			40,
			36,
			32,
			28,
			24,
			20,
			16,
			20,
			24,
			28,
			32,
			36,
			40,
			44,
			48,
			52,
			56,
			52,
			48,
			44,
			40,
			36,
			32,
			28,
			24,
			20,
			16,
			20,
			24,
			28,
			32,
			36,
			40,
			44,
			48,
			52,
			56,
			52,
			48,
			44,
			40,
			36,
			32,
			28,
			24,
			20,
			16,
			20,
			24,
			28,
			32,
			36,
			40,
			44,
			48,
			52,
			56,
			52,
			48,
			44,
			40,
			36,
			32,
			28,
			24,
			20,
			16,
			20,
			24,
			28,
			32,
			36,
			40,
			44,
			48,
			52,
			56,
			52,
			48,
			44,
			40,
			36,
			32,
			28,
			24,
			20,
			16,
			20,
			24,
			28,
			32,
			36,
			40,
			44,
			48,
			52,
			56,
			52,
			48,
			44,
			40,
			36,
			32,
			28,
			24,
			20,
			16,
			20,
			24,
			28,
			32,
			36,
			40,
			44,
			48,
			52,
			56,
			52,
			48,
			44,
			40,
			36,
			32,
			28,
			24,
			20,
			16,
			20,
			24,
			28,
			32,
			36,
			40,
			44,
			48,
			52,
			56,
			52,
			48,
			44,
			40,
			36,
			32,
			28,
			24,
			20,
			16,
			20,
			24,
			28,
			32,
			36,
			40,
			44,
			48,
			52,
			56,
			52,
			48,
			44,
			40,
			36,
			32,
			28,
			24,
			20,
			16,
			12,
			8,
			4,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0
		};

		// Token: 0x040038E3 RID: 14563
		private static VillageLayoutNew[] s_villageLayout = null;

		// Token: 0x040038E4 RID: 14564
		private static VillageBuildingDataNew[] s_villageBuildingData = null;

		// Token: 0x040038E5 RID: 14565
		public Banqueting banqueting;

		// Token: 0x040038E6 RID: 14566
		public static VillageClickMask villageClickMask = new VillageClickMask();

		// Token: 0x040038E7 RID: 14567
		public DateTime lastDownloadedTime = DateTime.MinValue;

		// Token: 0x040038E8 RID: 14568
		private static bool GFXLoaded = false;

		// Token: 0x040038E9 RID: 14569
		private static DateTime baseServerTime = DateTime.Now;

		// Token: 0x040038EA RID: 14570
		private static double localBaseTime = 0.0;

		// Token: 0x040038EB RID: 14571
		private VillageMap.BuildingOrderComparer buildingOrderComparer = new VillageMap.BuildingOrderComparer();

		// Token: 0x040038EC RID: 14572
		private List<DateTime> ConstrTimeCompletionList = new List<DateTime>();

		// Token: 0x040038ED RID: 14573
		private VillageLayoutNew layout;

		// Token: 0x040038EE RID: 14574
		private int m_mapID = -1;

		// Token: 0x040038EF RID: 14575
		private int m_mapVariant = -1;

		// Token: 0x040038F0 RID: 14576
		private int m_villageID = -1;

		// Token: 0x040038F1 RID: 14577
		private int m_villageMapType;

		// Token: 0x040038F2 RID: 14578
		private static int backgroundTexture = -1;

		// Token: 0x040038F3 RID: 14579
		private SpriteWrapper backgroundSprite;

		// Token: 0x040038F4 RID: 14580
		private SpriteWrapper backgroundOverlaySprite;

		// Token: 0x040038F5 RID: 14581
		private List<VillageMapBuilding> localBuildings = new List<VillageMapBuilding>();

		// Token: 0x040038F6 RID: 14582
		private static SpriteWrapper placementSprite = null;

		// Token: 0x040038F7 RID: 14583
		private static SpriteWrapper placementSprite_subSprite = null;

		// Token: 0x040038F8 RID: 14584
		private static int placementType = 0;

		// Token: 0x040038F9 RID: 14585
		private static bool placingAsFree = false;

		// Token: 0x040038FA RID: 14586
		private static VillageMapBuilding m_movingBuilding = null;

		// Token: 0x040038FB RID: 14587
		private VillageMapBuilding m_selectedBuilding;

		// Token: 0x040038FC RID: 14588
		private DateTime lastClickedSound = DateTime.MinValue;

		// Token: 0x040038FD RID: 14589
		private bool m_leftMouseGrabbed;

		// Token: 0x040038FE RID: 14590
		private bool m_leftMouseHeldDown;

		// Token: 0x040038FF RID: 14591
		private double m_lastMousePressedTime;

		// Token: 0x04003900 RID: 14592
		private Point m_baseMousePos;

		// Token: 0x04003901 RID: 14593
		private double m_baseScreenX;

		// Token: 0x04003902 RID: 14594
		private double m_baseScreenY;

		// Token: 0x04003903 RID: 14595
		private ICameraController m_camera;

		// Token: 0x04003904 RID: 14596
		private Point m_previousMousePos;

		// Token: 0x04003905 RID: 14597
		private Point m_lastMousePos;

		// Token: 0x04003906 RID: 14598
		public int granaryOpenCount;

		// Token: 0x04003907 RID: 14599
		private bool tooltipWasVisble;

		// Token: 0x04003908 RID: 14600
		private int placementError;

		// Token: 0x04003909 RID: 14601
		private string placementErrorString = "";

		// Token: 0x0400390A RID: 14602
		private Point lastPlaceBuildingLoc;

		// Token: 0x0400390B RID: 14603
		private DateTime lastBuildingPlacement = DateTime.MinValue;

		// Token: 0x0400390C RID: 14604
		private bool inPlaceBuilding;

		// Token: 0x0400390D RID: 14605
		private bool inSendBuildingActivity;

		// Token: 0x0400390E RID: 14606
		private DateTime inSendBuildingActivityLastTime = DateTime.MinValue;

		// Token: 0x0400390F RID: 14607
		private bool viewOnly;

		// Token: 0x04003910 RID: 14608
		private double viewHonour;

		// Token: 0x04003911 RID: 14609
		private GraphicsMgr gfx;

		// Token: 0x04003912 RID: 14610
		private static string lastBackgroundImageName = "";

		// Token: 0x04003913 RID: 14611
		private static List<SpriteWrapper> surroundsprites = new List<SpriteWrapper>();

		// Token: 0x04003914 RID: 14612
		private static SpriteWrapper tutorialOverlaySprite = new SpriteWrapper();

		// Token: 0x04003915 RID: 14613
		private static SpriteWrapper wikiHelpSprite = new SpriteWrapper();

		// Token: 0x04003916 RID: 14614
		private Point productionArrowProductionBuilding = new Point(-1, -1);

		// Token: 0x04003917 RID: 14615
		private Point productionArrowTargetBuilding = new Point(-1, -1);

		// Token: 0x04003918 RID: 14616
		private Point productionArrowTarget2Building = new Point(-1, -1);

		// Token: 0x04003919 RID: 14617
		private int updateFilter;

		// Token: 0x0400391A RID: 14618
		private bool overWikiHelp;

		// Token: 0x0400391B RID: 14619
		private float updateTimer;

		// Token: 0x0400391C RID: 14620
		private long m_lastOverBuildingID = -1L;

		// Token: 0x0400391D RID: 14621
		private DateTime m_lastMousePosChangeTime = DateTime.MaxValue;

		// Token: 0x0400391E RID: 14622
		private bool tutorialStage_AppleFarm_Activated;

		// Token: 0x0400391F RID: 14623
		private bool tutorialStage_Wood_Activated;

		// Token: 0x04003920 RID: 14624
		private VillageMapBuilding fakeArmoury = new VillageMapBuilding();

		// Token: 0x04003921 RID: 14625
		private int m_preCountedChurches;

		// Token: 0x04003922 RID: 14626
		private int m_preCountedChapels;

		// Token: 0x04003923 RID: 14627
		private int m_preCountedCathedrals;

		// Token: 0x04003924 RID: 14628
		private int m_preCountedSmallGardens;

		// Token: 0x04003925 RID: 14629
		private int m_preCountedLargeGardens;

		// Token: 0x04003926 RID: 14630
		private int m_preCountedSmallStatues;

		// Token: 0x04003927 RID: 14631
		private int m_preCountedLargeStatues;

		// Token: 0x04003928 RID: 14632
		private int m_preCountedDovecotes;

		// Token: 0x04003929 RID: 14633
		private int m_preCountedStocks;

		// Token: 0x0400392A RID: 14634
		private int m_preCountedBurningPosts;

		// Token: 0x0400392B RID: 14635
		private int m_preCountedGibbets;

		// Token: 0x0400392C RID: 14636
		private int m_preCountedRacks;

		// Token: 0x0400392D RID: 14637
		public double m_woodLevel;

		// Token: 0x0400392E RID: 14638
		public double m_stoneLevel;

		// Token: 0x0400392F RID: 14639
		public double m_ironLevel;

		// Token: 0x04003930 RID: 14640
		public double m_pitchLevel;

		// Token: 0x04003931 RID: 14641
		public double m_aleLevel;

		// Token: 0x04003932 RID: 14642
		public double m_applesLevel;

		// Token: 0x04003933 RID: 14643
		public double m_breadLevel;

		// Token: 0x04003934 RID: 14644
		public double m_cheeseLevel;

		// Token: 0x04003935 RID: 14645
		public double m_meatLevel;

		// Token: 0x04003936 RID: 14646
		public double m_vegLevel;

		// Token: 0x04003937 RID: 14647
		public double m_fishLevel;

		// Token: 0x04003938 RID: 14648
		public double m_saltLevel;

		// Token: 0x04003939 RID: 14649
		public double m_venisonLevel;

		// Token: 0x0400393A RID: 14650
		public double m_wineLevel;

		// Token: 0x0400393B RID: 14651
		public double m_spicesLevel;

		// Token: 0x0400393C RID: 14652
		public double m_silkLevel;

		// Token: 0x0400393D RID: 14653
		public double m_metalwareLevel;

		// Token: 0x0400393E RID: 14654
		public double m_clothesLevel;

		// Token: 0x0400393F RID: 14655
		public double m_furnitureLevel;

		// Token: 0x04003940 RID: 14656
		public double m_bowsLevel;

		// Token: 0x04003941 RID: 14657
		public double m_pikesLevel;

		// Token: 0x04003942 RID: 14658
		public double m_swordsLevel;

		// Token: 0x04003943 RID: 14659
		public double m_armourLevel;

		// Token: 0x04003944 RID: 14660
		public double m_catapultsLevel;

		// Token: 0x04003945 RID: 14661
		public int m_taxLevel;

		// Token: 0x04003946 RID: 14662
		public int m_rationsLevel;

		// Token: 0x04003947 RID: 14663
		public int m_aleRationsLevel;

		// Token: 0x04003948 RID: 14664
		public int m_taxLevelServer;

		// Token: 0x04003949 RID: 14665
		public int m_rationsLevelServer;

		// Token: 0x0400394A RID: 14666
		public int m_aleRationsLevelServer;

		// Token: 0x0400394B RID: 14667
		public int m_taxLevelSent;

		// Token: 0x0400394C RID: 14668
		public int m_rationsLevelSent;

		// Token: 0x0400394D RID: 14669
		public int m_aleRationsLevelSent;

		// Token: 0x0400394E RID: 14670
		public double m_statsChangeTime;

		// Token: 0x0400394F RID: 14671
		public int m_popularityLevel;

		// Token: 0x04003950 RID: 14672
		public int m_housingCapacity;

		// Token: 0x04003951 RID: 14673
		public int m_totalPeople;

		// Token: 0x04003952 RID: 14674
		public int m_spareWorkers;

		// Token: 0x04003953 RID: 14675
		public DateTime m_immigrationNextChangeTime = DateTime.Now;

		// Token: 0x04003954 RID: 14676
		public int m_numPositiveBuildings;

		// Token: 0x04003955 RID: 14677
		public int m_numNegativeBuildings;

		// Token: 0x04003956 RID: 14678
		public int m_numPopularityBuildings;

		// Token: 0x04003957 RID: 14679
		public double m_applesConsumption;

		// Token: 0x04003958 RID: 14680
		public double m_breadConsumption;

		// Token: 0x04003959 RID: 14681
		public double m_cheeseConsumption;

		// Token: 0x0400395A RID: 14682
		public double m_meatConsumption;

		// Token: 0x0400395B RID: 14683
		public double m_vegConsumption;

		// Token: 0x0400395C RID: 14684
		public double m_fishConsumption;

		// Token: 0x0400395D RID: 14685
		public DateTime m_consumptionLastTime = DateTime.Now;

		// Token: 0x0400395E RID: 14686
		public double m_effectiveRationsLevel;

		// Token: 0x0400395F RID: 14687
		public bool m_showEffective = true;

		// Token: 0x04003960 RID: 14688
		public bool m_consumptionChangeTimeNeeded;

		// Token: 0x04003961 RID: 14689
		public DateTime m_consumptionChangeTime = DateTime.Now;

		// Token: 0x04003962 RID: 14690
		public int m_numFoodTypesEaten;

		// Token: 0x04003963 RID: 14691
		public bool m_showAleEffective = true;

		// Token: 0x04003964 RID: 14692
		public double m_effectiveAleRationsLevel;

		// Token: 0x04003965 RID: 14693
		public double m_aleConsumption;

		// Token: 0x04003966 RID: 14694
		public PopEventData[] m_popEvents;

		// Token: 0x04003967 RID: 14695
		public DateTime m_lastServerReply = DateTime.Now;

		// Token: 0x04003968 RID: 14696
		public double m_toBeMade_Bows;

		// Token: 0x04003969 RID: 14697
		public double m_toBeMade_Pikes;

		// Token: 0x0400396A RID: 14698
		public double m_toBeMade_Swords;

		// Token: 0x0400396B RID: 14699
		public double m_toBeMade_Armour;

		// Token: 0x0400396C RID: 14700
		public double m_toBeMade_Catapults;

		// Token: 0x0400396D RID: 14701
		public DateTime m_productionStart_Bows = DateTime.Now;

		// Token: 0x0400396E RID: 14702
		public DateTime m_productionStart_Pikes = DateTime.Now;

		// Token: 0x0400396F RID: 14703
		public DateTime m_productionStart_Swords = DateTime.Now;

		// Token: 0x04003970 RID: 14704
		public DateTime m_productionStart_Armour = DateTime.Now;

		// Token: 0x04003971 RID: 14705
		public DateTime m_productionStart_Catapults = DateTime.Now;

		// Token: 0x04003972 RID: 14706
		public DateTime m_productionEnd_Bows = DateTime.Now;

		// Token: 0x04003973 RID: 14707
		public DateTime m_productionEnd_Pikes = DateTime.Now;

		// Token: 0x04003974 RID: 14708
		public DateTime m_productionEnd_Swords = DateTime.Now;

		// Token: 0x04003975 RID: 14709
		public DateTime m_productionEnd_Armour = DateTime.Now;

		// Token: 0x04003976 RID: 14710
		public DateTime m_productionEnd_Catapults = DateTime.Now;

		// Token: 0x04003977 RID: 14711
		public double m_productionRate_Bows;

		// Token: 0x04003978 RID: 14712
		public double m_productionRate_Pikes;

		// Token: 0x04003979 RID: 14713
		public double m_productionRate_Swords;

		// Token: 0x0400397A RID: 14714
		public double m_productionRate_Armour;

		// Token: 0x0400397B RID: 14715
		public double m_productionRate_Catapults;

		// Token: 0x0400397C RID: 14716
		public DateTime m_nextWeaponsCheck = DateTime.Now.AddHours(4.0);

		// Token: 0x0400397D RID: 14717
		public int m_numArchers;

		// Token: 0x0400397E RID: 14718
		public int m_numPikemen;

		// Token: 0x0400397F RID: 14719
		public int m_numPeasants;

		// Token: 0x04003980 RID: 14720
		public int m_numSwordsmen;

		// Token: 0x04003981 RID: 14721
		public int m_numCatapults;

		// Token: 0x04003982 RID: 14722
		public int m_numScouts;

		// Token: 0x04003983 RID: 14723
		public int m_numCaptains;

		// Token: 0x04003984 RID: 14724
		public bool m_creatingCaptain;

		// Token: 0x04003985 RID: 14725
		public DateTime m_captainCreationTime = DateTime.MinValue;

		// Token: 0x04003986 RID: 14726
		public bool m_lastBanquetStored;

		// Token: 0x04003987 RID: 14727
		public double m_lastBanquetHonour;

		// Token: 0x04003988 RID: 14728
		public DateTime m_lastBanquetDate = DateTime.Now;

		// Token: 0x04003989 RID: 14729
		public double m_capitalGold;

		// Token: 0x0400398A RID: 14730
		public int m_capitalTaxRate;

		// Token: 0x0400398B RID: 14731
		public int m_capitalTaxRateServer;

		// Token: 0x0400398C RID: 14732
		public int m_capitalTaxRateSent;

		// Token: 0x0400398D RID: 14733
		public int m_parentCapitalTaxRate;

		// Token: 0x0400398E RID: 14734
		public int m_lastCapitalTaxRate;

		// Token: 0x0400398F RID: 14735
		public int m_numOfActiveChildrenAreas;

		// Token: 0x04003990 RID: 14736
		public ResearchData m_parishCapitalResearchData;

		// Token: 0x04003991 RID: 14737
		public DateTime m_ownedDate = DateTime.MinValue;

		// Token: 0x04003992 RID: 14738
		public List<int> m_capitalBuildingsBuilt;

		// Token: 0x04003993 RID: 14739
		public int m_numParishFlags;

		// Token: 0x04003994 RID: 14740
		public ParishTaxCalc[] m_parishPeople;

		// Token: 0x04003995 RID: 14741
		public DateTime m_lastParishPeopleTime = DateTime.MinValue;

		// Token: 0x04003996 RID: 14742
		public int m_numStationedArchers;

		// Token: 0x04003997 RID: 14743
		public int m_numStationedPikemen;

		// Token: 0x04003998 RID: 14744
		public int m_numStationedPeasants;

		// Token: 0x04003999 RID: 14745
		public int m_numStationedSwordsmen;

		// Token: 0x0400399A RID: 14746
		public int m_numStationedCatapults;

		// Token: 0x0400399B RID: 14747
		public int m_numTradersAtHome;

		// Token: 0x0400399C RID: 14748
		public DateTime m_nextMapTypeChange = DateTime.MinValue;

		// Token: 0x0400399D RID: 14749
		public bool m_castleEnclosed;

		// Token: 0x0400399E RID: 14750
		public DateTime m_captialNextDelete = DateTime.MinValue;

		// Token: 0x0400399F RID: 14751
		public DateTime m_interdictionTime = DateTime.MinValue;

		// Token: 0x040039A0 RID: 14752
		public DateTime m_excommunicationTime = DateTime.MinValue;

		// Token: 0x040039A1 RID: 14753
		private DateTime weaponProductionLastTimeRequest = DateTime.MinValue;

		// Token: 0x040039A2 RID: 14754
		public bool m_statsMigrationUpdateRequested;

		// Token: 0x040039A3 RID: 14755
		public bool m_statsConsumptionUpdateRequested;

		// Token: 0x040039A4 RID: 14756
		private DateTime m_villageInfoUpdateLastTime = DateTime.MinValue;

		// Token: 0x040039A5 RID: 14757
		private List<MarketTraderData> traders = new List<MarketTraderData>();

		// Token: 0x040039A6 RID: 14758
		private DateTime lastTraderRefresh = DateTime.MinValue;

		// Token: 0x040039A7 RID: 14759
		private DateTime lastMarketSend = DateTime.MinValue;

		// Token: 0x040039A8 RID: 14760
		private bool inMarketSend;

		// Token: 0x040039A9 RID: 14761
		private bool makeTroopsLocked;

		// Token: 0x040039AA RID: 14762
		private DateTime makeTroopsLockedTime = DateTime.MinValue;

		// Token: 0x040039AB RID: 14763
		private int localMadeTroops_Peasants;

		// Token: 0x040039AC RID: 14764
		private int localMadeTroops_Archers;

		// Token: 0x040039AD RID: 14765
		private int localMadeTroops_Pikemen;

		// Token: 0x040039AE RID: 14766
		private int localMadeTroops_Swordsmen;

		// Token: 0x040039AF RID: 14767
		private int localMadeTroops_Catapults;

		// Token: 0x040039B0 RID: 14768
		private int localMadeTroops_Scouts;

		// Token: 0x040039B1 RID: 14769
		private int localMadeTroops_Captains;

		// Token: 0x040039B2 RID: 14770
		private int localMadeTroopsSent_Peasants;

		// Token: 0x040039B3 RID: 14771
		private int localMadeTroopsSent_Archers;

		// Token: 0x040039B4 RID: 14772
		private int localMadeTroopsSent_Pikemen;

		// Token: 0x040039B5 RID: 14773
		private int localMadeTroopsSent_Swordsmen;

		// Token: 0x040039B6 RID: 14774
		private int localMadeTroopsSent_Catapults;

		// Token: 0x040039B7 RID: 14775
		private int localMadeTroopsSent_Scouts;

		// Token: 0x040039B8 RID: 14776
		private int localMadeTroopsSent_Captains;

		// Token: 0x040039B9 RID: 14777
		public int LocalGoldSpentOnCaptains;

		// Token: 0x040039BA RID: 14778
		public int LocallyMade_Traders;

		// Token: 0x040039BB RID: 14779
		private int localMadeTroops_lastType = -1;

		// Token: 0x040039BC RID: 14780
		private DateTime localMadeTroops_lastTime = DateTime.MinValue;

		// Token: 0x040039BD RID: 14781
		private bool disbandTroopsLocked;

		// Token: 0x040039BE RID: 14782
		private DateTime disbandTroopsLockedTime = DateTime.MinValue;

		// Token: 0x040039BF RID: 14783
		private bool makePeopleLocked;

		// Token: 0x040039C0 RID: 14784
		private DateTime makePeopleLockedTime = DateTime.MinValue;

		// Token: 0x040039C1 RID: 14785
		public int LocallyMadeMonks;

		// Token: 0x040039C2 RID: 14786
		private bool disbandPeopleLocked;

		// Token: 0x040039C3 RID: 14787
		private DateTime disbandPeopleLockedTime = DateTime.MinValue;

		// Token: 0x040039C4 RID: 14788
		private static short[] woodcutterIdleAnim = new short[]
		{
			0,
			1,
			2,
			3,
			4,
			5,
			6,
			6,
			6,
			6,
			5,
			5,
			4,
			4,
			3,
			3,
			2,
			2,
			3,
			4,
			5,
			6,
			6,
			6,
			6,
			6,
			6,
			5,
			4,
			3,
			2,
			1,
			0,
			0,
			0,
			1,
			2,
			3,
			4,
			5,
			6,
			6,
			6,
			6,
			6,
			7,
			8,
			9,
			10,
			11,
			12,
			13,
			14,
			15,
			16,
			16,
			16,
			15,
			15,
			14,
			14,
			13,
			13,
			12,
			12,
			11,
			11,
			10,
			10,
			9,
			9,
			9,
			10,
			11,
			12,
			13,
			14,
			15,
			16,
			16,
			16,
			16,
			16,
			16,
			16,
			16,
			17,
			18,
			19,
			20,
			21,
			22,
			23,
			23,
			23,
			23,
			23,
			23,
			23
		};

		// Token: 0x040039C5 RID: 14789
		private static short[] bakerIdleAnim = new short[]
		{
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8,
			9,
			10,
			11,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			13,
			14,
			15,
			16,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			16,
			15,
			14,
			13,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			13,
			14,
			15,
			16,
			17,
			18,
			19,
			20,
			20,
			20,
			20,
			20,
			20,
			19,
			18,
			19,
			20,
			20,
			20,
			19,
			18,
			17,
			16,
			15,
			14,
			13,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			13,
			14,
			15,
			16,
			17,
			18,
			19,
			20,
			20,
			20,
			20,
			20,
			20,
			19,
			18,
			19,
			20,
			20,
			20,
			19,
			18,
			17,
			16,
			15,
			14,
			13,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			13,
			13,
			14,
			14,
			15,
			15,
			16,
			16,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			17,
			16,
			16,
			15,
			15,
			14,
			14,
			13,
			13,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			2,
			12,
			12,
			13,
			14,
			15,
			16,
			17,
			18,
			19,
			20,
			20,
			20,
			20,
			20,
			20,
			19,
			18,
			19,
			20,
			20,
			20,
			19,
			18,
			17,
			16,
			15,
			14,
			13,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			11,
			10,
			9,
			8,
			7,
			6,
			5,
			4,
			3,
			2,
			2,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1
		};

		// Token: 0x040039C6 RID: 14790
		private static short[] farmer3IdleAnim = new short[]
		{
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			7,
			7,
			7,
			7,
			7,
			7,
			7,
			7,
			7,
			6,
			5,
			4,
			3,
			2,
			1,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0
		};

		// Token: 0x040039C7 RID: 14791
		private static short[] brewerIdleAnim = new short[]
		{
			1,
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8,
			9,
			1,
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8,
			9,
			1,
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8,
			9,
			1,
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8,
			9,
			1,
			1,
			2,
			2,
			3,
			3,
			4,
			4,
			5,
			6,
			7,
			8,
			9,
			10,
			11,
			12,
			13,
			14,
			15,
			16,
			16,
			16,
			16,
			16,
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8,
			9,
			10,
			11,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			13,
			14,
			15,
			16,
			16,
			16,
			16,
			16,
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8,
			9,
			10,
			11,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			13,
			14,
			15,
			16,
			1,
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8,
			9,
			1,
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8,
			9,
			1,
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8,
			9,
			1,
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8,
			9,
			1,
			1,
			2,
			2,
			3,
			3,
			4,
			4,
			5,
			6,
			7,
			8,
			9,
			10,
			11,
			12,
			13,
			14,
			15,
			16,
			16,
			16,
			16,
			16,
			1,
			1,
			2,
			2,
			3,
			3,
			4,
			4,
			5,
			6,
			7,
			8,
			9,
			10,
			11,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			12,
			12,
			12,
			12,
			12,
			13,
			13,
			14,
			14,
			15,
			15,
			16,
			16,
			16,
			16,
			16,
			16,
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8,
			9,
			10,
			11,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			13,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			12,
			13,
			14,
			15,
			16
		};

		// Token: 0x040039C8 RID: 14792
		private static short[] pitchworkerIdleAnim = new short[]
		{
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			2,
			2,
			3,
			3,
			4,
			4,
			5,
			5,
			6,
			6,
			7,
			7,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			8,
			7,
			6,
			5,
			4,
			3,
			2,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1
		};

		// Token: 0x040039C9 RID: 14793
		private static short[] hunterIdleAnim = new short[]
		{
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			2,
			2,
			3,
			3,
			4,
			4,
			5,
			6,
			7,
			8,
			9,
			10,
			11,
			12,
			13,
			14,
			15,
			16,
			17,
			18,
			19,
			20,
			21,
			22,
			23,
			24,
			25,
			26,
			27,
			28,
			29,
			30,
			30,
			30,
			31,
			31,
			32,
			32,
			33,
			33,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			2,
			2,
			3,
			3,
			4,
			4,
			5,
			6,
			7,
			8,
			9,
			10,
			11,
			12,
			13,
			14,
			15,
			16,
			17,
			18,
			19,
			20,
			21,
			22,
			23,
			24,
			25,
			26,
			27,
			28,
			29,
			30,
			30,
			30,
			31,
			31,
			32,
			32,
			33,
			33,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			2,
			2,
			3,
			3,
			4,
			4,
			5,
			5,
			6,
			6,
			7,
			7,
			8,
			8,
			9,
			9,
			10,
			10,
			11,
			11,
			12,
			12,
			13,
			13,
			14,
			14,
			15,
			15,
			16,
			16,
			17,
			17,
			18,
			18,
			19,
			19,
			20,
			20,
			21,
			21,
			22,
			22,
			23,
			23,
			24,
			24,
			25,
			25,
			26,
			26,
			27,
			27,
			28,
			28,
			29,
			29,
			28,
			28,
			27,
			27,
			26,
			26,
			25,
			25,
			24,
			24,
			23,
			23,
			22,
			22,
			21,
			21,
			20,
			20,
			19,
			19,
			18,
			18,
			17,
			17,
			16,
			16,
			15,
			15,
			14,
			14,
			13,
			13,
			12,
			12,
			11,
			11,
			10,
			10,
			9,
			9,
			8,
			8,
			7,
			7,
			8,
			8,
			9,
			9,
			10,
			10,
			11,
			11,
			12,
			12,
			13,
			13,
			14,
			14,
			15,
			15,
			16,
			16,
			17,
			17,
			18,
			18,
			19,
			19,
			20,
			20,
			21,
			21,
			22,
			22,
			23,
			23,
			24,
			24,
			25,
			25,
			26,
			26,
			27,
			27,
			28,
			28,
			29,
			29,
			30,
			30,
			31,
			31,
			32,
			32,
			33,
			33,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			2,
			2,
			3,
			3,
			4,
			4,
			5,
			5,
			6,
			6,
			7,
			7,
			8,
			8,
			9,
			9,
			10,
			10,
			11,
			11,
			12,
			12,
			13,
			13,
			14,
			14,
			15,
			15,
			16,
			16,
			17,
			17,
			18,
			18,
			19,
			19,
			20,
			20,
			21,
			21,
			22,
			22,
			23,
			23,
			24,
			24,
			25,
			25,
			26,
			26,
			27,
			27,
			28,
			28,
			29,
			29,
			30,
			30,
			31,
			31,
			32,
			32,
			33,
			33,
			1
		};

		// Token: 0x040039CA RID: 14794
		private static short[] blacksmithIdleAnim = new short[]
		{
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8,
			9,
			10,
			11,
			12,
			13,
			14,
			15
		};

		// Token: 0x040039CB RID: 14795
		private static short[] armourerIdleAnim = new short[]
		{
			1,
			1,
			2,
			2,
			3,
			3,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			5,
			5,
			6,
			6,
			7,
			7,
			8,
			9,
			10,
			11,
			12,
			13,
			14,
			15,
			16,
			8,
			9,
			10,
			11,
			12,
			13,
			14,
			15,
			16,
			8,
			9,
			10,
			11,
			12,
			13,
			14,
			15,
			16,
			8,
			9,
			10,
			11,
			12,
			13,
			14,
			15,
			16,
			8,
			9,
			10,
			11,
			12,
			13,
			14,
			15,
			16,
			8,
			9,
			10,
			11,
			12,
			13,
			14,
			15,
			16,
			2,
			3,
			4,
			4,
			4,
			5,
			6,
			7,
			8,
			9,
			10,
			11,
			12,
			13,
			14,
			15,
			16
		};

		// Token: 0x040039CC RID: 14796
		private static short[] siegeWorkerIdleAnim = new short[]
		{
			1,
			1,
			2,
			2,
			3,
			3,
			4,
			4,
			5,
			5,
			6,
			6,
			7,
			7,
			8,
			8,
			9,
			9,
			10,
			10,
			11,
			11,
			12,
			12,
			13,
			13,
			14,
			14,
			15,
			15,
			16,
			16
		};

		// Token: 0x040039CD RID: 14797
		private static short[] metalWorkerIdleAnim = new short[]
		{
			1,
			1,
			2,
			2,
			3,
			3,
			4,
			4,
			5,
			5,
			6,
			6,
			7,
			7,
			8,
			8,
			9,
			9,
			10,
			10,
			11,
			11,
			12,
			12,
			13,
			13,
			14,
			14,
			15,
			15,
			16,
			16
		};

		// Token: 0x040039CE RID: 14798
		private static short[] carpenterIdleAnim = new short[]
		{
			1,
			1,
			2,
			2,
			3,
			3,
			4,
			4,
			5,
			5,
			6,
			6,
			7,
			7,
			8,
			8,
			9,
			9,
			10,
			10,
			11,
			11,
			12,
			12,
			13,
			13,
			14,
			14,
			15,
			15,
			16,
			16,
			17,
			17,
			18,
			18,
			19,
			19,
			20,
			20,
			21,
			21,
			22,
			22,
			23,
			23,
			24,
			24
		};

		// Token: 0x040039CF RID: 14799
		private static short[] tailorIdleAnim = new short[]
		{
			1,
			1,
			2,
			2,
			3,
			3,
			4,
			4,
			5,
			5,
			6,
			6,
			7,
			7,
			8,
			8,
			9,
			9,
			10,
			10,
			11,
			11,
			12,
			12,
			13,
			13,
			14,
			14,
			15,
			15,
			16,
			16
		};

		// Token: 0x040039D0 RID: 14800
		private static short[] dockworkerIdleAnim = new short[]
		{
			1,
			1,
			2,
			2,
			3,
			3,
			4,
			4,
			5,
			5,
			6,
			6,
			7,
			7,
			8,
			8,
			9,
			9,
			10,
			10,
			11,
			11,
			12,
			12,
			13,
			13,
			14,
			14,
			15,
			15,
			16,
			16,
			16,
			16,
			16,
			16,
			16,
			16,
			16,
			16,
			16,
			16,
			16,
			16,
			16,
			15,
			15,
			14,
			14,
			13,
			13,
			12,
			12,
			11,
			11,
			10,
			10,
			9,
			9,
			8,
			8,
			7,
			7,
			6,
			6,
			5,
			5,
			4,
			4,
			3,
			3,
			2,
			2,
			1,
			1
		};

		// Token: 0x040039D1 RID: 14801
		private static short[] cowLayAnim = new short[]
		{
			0,
			8,
			16,
			24,
			32,
			40,
			48,
			56,
			64,
			72,
			80,
			88,
			96,
			104,
			112,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			120,
			112,
			104,
			96,
			88,
			80,
			72,
			64,
			56,
			48,
			40,
			32,
			24,
			16,
			8,
			0
		};

		// Token: 0x040039D2 RID: 14802
		private static short[] cowIdleAnim = new short[]
		{
			0,
			8,
			16,
			24,
			32,
			40,
			48,
			56,
			64,
			72,
			80,
			88,
			96,
			104,
			112,
			120,
			112,
			104,
			96,
			88,
			80,
			72,
			64,
			56,
			48,
			40,
			32,
			24,
			16,
			8
		};

		// Token: 0x040039D3 RID: 14803
		private SparseArray randStateArray = new SparseArray();

		// Token: 0x040039D4 RID: 14804
		private SparseArray animalArray = new SparseArray();

		// Token: 0x040039D5 RID: 14805
		internal object _localBuildingsLock = new object();

		// Token: 0x040039D6 RID: 14806
		private int[] allowedErrors = new int[]
		{
			3,
			4,
			6
		};

		// Token: 0x040039D7 RID: 14807
		private decimal[] FoodRationsLevels = new decimal[]
		{
			0m,
			0.25m,
			0.5m,
			1m,
			2m,
			3m,
			4m
		};

		// Token: 0x020004D6 RID: 1238
		public class BuildingOrderComparer : IComparer<DateTime>
		{
			// Token: 0x06002E96 RID: 11926 RVA: 0x00021D3D File Offset: 0x0001FF3D
			public int Compare(DateTime x, DateTime y)
			{
				return x.CompareTo(y);
			}
		}

		// Token: 0x020004D7 RID: 1239
		public class StockpileLevels
		{
			// Token: 0x040039D8 RID: 14808
			public double woodLevel;

			// Token: 0x040039D9 RID: 14809
			public double stoneLevel;

			// Token: 0x040039DA RID: 14810
			public double ironLevel;

			// Token: 0x040039DB RID: 14811
			public double pitchLevel;
		}

		// Token: 0x020004D8 RID: 1240
		public class GranaryLevels
		{
			// Token: 0x1700026E RID: 622
			// (get) Token: 0x06002E99 RID: 11929 RVA: 0x00021D47 File Offset: 0x0001FF47
			public double total
			{
				get
				{
					return this.applesLevel + this.breadLevel + this.cheeseLevel + this.meatLevel + this.vegLevel + this.fishLevel;
				}
			}

			// Token: 0x040039DC RID: 14812
			public double applesLevel;

			// Token: 0x040039DD RID: 14813
			public double breadLevel;

			// Token: 0x040039DE RID: 14814
			public double cheeseLevel;

			// Token: 0x040039DF RID: 14815
			public double meatLevel;

			// Token: 0x040039E0 RID: 14816
			public double vegLevel;

			// Token: 0x040039E1 RID: 14817
			public double fishLevel;
		}

		// Token: 0x020004D9 RID: 1241
		public class ArmouryLevels
		{
			// Token: 0x040039E2 RID: 14818
			public double bowsLevel;

			// Token: 0x040039E3 RID: 14819
			public double pikesLevel;

			// Token: 0x040039E4 RID: 14820
			public double swordsLevel;

			// Token: 0x040039E5 RID: 14821
			public double armourLevel;

			// Token: 0x040039E6 RID: 14822
			public double catapultsLevel;

			// Token: 0x040039E7 RID: 14823
			public int bowsLeftToMake;

			// Token: 0x040039E8 RID: 14824
			public int pikesLeftToMake;

			// Token: 0x040039E9 RID: 14825
			public int swordsLeftToMake;

			// Token: 0x040039EA RID: 14826
			public int armourLeftToMake;

			// Token: 0x040039EB RID: 14827
			public int catapultsLeftToMake;
		}

		// Token: 0x020004DA RID: 1242
		public class TownHallLevels
		{
			// Token: 0x040039EC RID: 14828
			public double clothesLevel;

			// Token: 0x040039ED RID: 14829
			public double furnitureLevel;

			// Token: 0x040039EE RID: 14830
			public double saltLevel;

			// Token: 0x040039EF RID: 14831
			public double venisonLevel;

			// Token: 0x040039F0 RID: 14832
			public double wineLevel;

			// Token: 0x040039F1 RID: 14833
			public double spicesLevel;

			// Token: 0x040039F2 RID: 14834
			public double silkLevel;

			// Token: 0x040039F3 RID: 14835
			public double metalwareLevel;
		}

		// Token: 0x020004DB RID: 1243
		public class InnLevels
		{
			// Token: 0x040039F4 RID: 14836
			public double aleLevel;
		}

		// Token: 0x020004DC RID: 1244
		public class VillageAnimal
		{
			// Token: 0x06002E9E RID: 11934 RVA: 0x00021D72 File Offset: 0x0001FF72
			public void recreate(VillageMapBuilding building)
			{
				if (GameEngine.Instance.Village != null)
				{
					GameEngine.Instance.Village.addChildSprite(this.sprite, 15);
				}
			}

			// Token: 0x06002E9F RID: 11935 RVA: 0x00255D98 File Offset: 0x00253F98
			public void init(VillageMapBuilding building)
			{
				this.sprite = new SpriteWrapper();
				if (GameEngine.Instance.Village == null)
				{
					return;
				}
				this.state = 0;
				this.tick = 0;
				this.rand = new Random(VillageMap.getCurrentServerTime().Millisecond + this.id * 50);
				this.randValue = this.rand.Next(256);
				GameEngine.Instance.Village.addChildSprite(this.sprite, 15);
				this.buildingType = building.buildingType;
				int num = this.buildingType;
				if (num == 3)
				{
					this.range = 50;
					if ((this.randValue & 1) == 0)
					{
						this.sprite.Initialize(GameEngine.Instance.Village.GFX, GFXLibrary.Instance.ChickenWhiteAnimTexID, 0);
					}
					else
					{
						this.sprite.Initialize(GameEngine.Instance.Village.GFX, GFXLibrary.Instance.ChickenBrownAnimTexID, 0);
					}
					this.sprite.Center = new PointF(50f, 68f);
					this.numWalkFrames = 16;
					this.numIdleFrames = 16;
					this.baseIdleFrame = 128;
					Point point = new Point(building.buildingLocation.X, building.buildingLocation.Y);
					point.X *= 32;
					point.Y *= 16;
					point.X += this.id * 24 - 16 - 4 - 4 - 72;
					point.Y += 8 + this.id * 12 - 4;
					this.sprite.PosX = (float)point.X;
					this.sprite.PosY = (float)point.Y;
					this.sprite.initDirectionality(8, 7, false);
					this.sprite.initAnim(this.baseIdleFrame, VillageMap.VillageAnimal.chickenIdleAnim, 100);
					this.idleAnim = VillageMap.VillageAnimal.chickenIdleAnim;
					this.sprite.Facing = 1;
					this.currentPos = (this.startPos = (this.endPos = point));
					this.idleTime = this.randValue % 20;
					return;
				}
				if (num == 16)
				{
					this.range = 20;
					this.sprite.Initialize(GameEngine.Instance.Village.GFX, GFXLibrary.Instance.PigAnimTexID, 0);
					this.sprite.AutoCentre = true;
					this.numWalkFrames = 16;
					this.numIdleFrames = 16;
					this.baseIdleFrame = 128;
					Point point2 = new Point(building.buildingLocation.X, building.buildingLocation.Y);
					point2.X *= 32;
					point2.Y *= 16;
					point2.X += this.id * 24 - 16 - 4 - 4;
					point2.Y += 8 + this.id * 12 - 4;
					this.sprite.PosX = (float)point2.X;
					this.sprite.PosY = (float)point2.Y;
					this.sprite.initDirectionality(8, 7, false);
					this.sprite.initAnim(this.baseIdleFrame, VillageMap.VillageAnimal.pigIdleAnim, 100);
					this.idleAnim = VillageMap.VillageAnimal.pigIdleAnim;
					this.sprite.Facing = 1;
					this.currentPos = (this.startPos = (this.endPos = point2));
					this.idleTime = (this.randValue % 3 + 1) * 30;
					return;
				}
				if (num != 19)
				{
					return;
				}
				this.range = 40;
				this.sprite.Initialize(GameEngine.Instance.Village.GFX, GFXLibrary.Instance.SheepAnimTexID, 0);
				this.sprite.AutoCentre = true;
				this.numWalkFrames = 16;
				this.numIdleFrames = 25;
				this.baseIdleFrame = 200;
				Point point3 = new Point(building.buildingLocation.X, building.buildingLocation.Y);
				point3.X *= 32;
				point3.Y *= 16;
				point3.X += this.id * 24 - 16 - 4 - 48;
				point3.Y += 8 + this.id * 12 - 4 - 2;
				this.sprite.PosX = (float)point3.X;
				this.sprite.PosY = (float)point3.Y;
				this.sprite.initDirectionality(8, 7, false);
				this.sprite.initAnim(this.baseIdleFrame, this.numIdleFrames, 8, 100);
				this.sprite.Facing = 1;
				this.currentPos = (this.startPos = (this.endPos = point3));
				this.idleTime = this.randValue % 20 + 1;
				if (this.id > 0)
				{
					this.idleTime += 20;
				}
				this.flock = true;
			}

			// Token: 0x06002EA0 RID: 11936 RVA: 0x002562A8 File Offset: 0x002544A8
			public void run(VillageMapBuilding building, VillageMap vm, VillageMap.VillageAnimal parent, int tickRate)
			{
				this.tick += tickRate;
				int num = this.state;
				if (num != 0)
				{
					if (num != 1)
					{
						return;
					}
					if (this.updateJourney())
					{
						this.tick = 0;
						this.state = 0;
						this.randValue = this.rand.Next(256);
						this.idleTime = (this.randValue % 15 + 5) * 30;
						int facing = this.sprite.Facing;
						this.sprite.initDirectionality(8, 7, false);
						if (this.idleAnim != null)
						{
							this.sprite.initAnim(this.baseIdleFrame, this.idleAnim, 100);
						}
						else
						{
							this.sprite.initAnim(this.baseIdleFrame, this.numIdleFrames, 8, 100);
						}
						if (this.cycleCount == 0)
						{
							this.sprite.Facing = 1;
						}
						else
						{
							this.sprite.Facing = facing;
						}
						this.fadeToSolid();
						return;
					}
					this.manageFadeOverBuildings(building);
				}
				else if (this.tick > this.idleTime)
				{
					this.tick = 0;
					Point point = default(Point);
					this.state++;
					this.cycleCount++;
					if (this.cycleCount > 3)
					{
						this.cycleCount = 0;
						point = new Point(building.buildingLocation.X, building.buildingLocation.Y);
						point.X *= 32;
						point.Y *= 16;
						point.X += this.id * 24 - 16 - 4 - 4;
						point.Y += 8 + this.id * 12 - 4;
					}
					else
					{
						point = ((parent == null || !this.flock) ? this.findAnimalTarget(building, vm, this.range) : this.findAnimalTarget(parent.endPos, vm, 8));
						point.X *= 32;
						point.Y *= 16;
						point.Y += 8;
					}
					this.startPos = this.currentPos;
					this.endPos = point;
					this.createJourney();
					return;
				}
			}

			// Token: 0x06002EA1 RID: 11937 RVA: 0x00021D97 File Offset: 0x0001FF97
			public Point findAnimalTarget(VillageMapBuilding building, VillageMap vm, int range)
			{
				return vm.findEmptyTile(building.buildingLocation, range, this.rand);
			}

			// Token: 0x06002EA2 RID: 11938 RVA: 0x002564D8 File Offset: 0x002546D8
			public Point findAnimalTarget(Point from, VillageMap vm, int range)
			{
				Point location = new Point(from.X / 32, from.Y / 16);
				return vm.findEmptyTile(location, range, this.rand);
			}

			// Token: 0x06002EA3 RID: 11939 RVA: 0x00256510 File Offset: 0x00254710
			public void createJourney()
			{
				this.journeyLength = 1;
				double num = Math.Sqrt((double)((this.endPos.X - this.startPos.X) * (this.endPos.X - this.startPos.X) + (this.endPos.Y - this.startPos.Y) * (this.endPos.Y - this.startPos.Y)));
				num *= 1.0;
				this.journeyLength = (int)num;
				this.sprite.initDirectionality(8, 7, false);
				this.sprite.initAnim(0, this.numWalkFrames, 8, 50);
				this.sprite.setFacing(this.startPos, this.endPos);
			}

			// Token: 0x06002EA4 RID: 11940 RVA: 0x002565D8 File Offset: 0x002547D8
			public bool updateJourney()
			{
				if (this.tick >= this.journeyLength)
				{
					this.sprite.PosX = (float)this.endPos.X;
					this.sprite.PosY = (float)this.endPos.Y;
					this.currentPos.X = (int)this.sprite.PosX;
					this.currentPos.Y = (int)this.sprite.PosY;
					return true;
				}
				this.sprite.PosX = (float)((this.endPos.X - this.startPos.X) * this.tick / this.journeyLength + this.startPos.X);
				this.sprite.PosY = (float)((this.endPos.Y - this.startPos.Y) * this.tick / this.journeyLength + this.startPos.Y);
				this.currentPos.X = (int)this.sprite.PosX;
				this.currentPos.Y = (int)this.sprite.PosY;
				return false;
			}

			// Token: 0x06002EA5 RID: 11941 RVA: 0x00021DAC File Offset: 0x0001FFAC
			public void dispose()
			{
				if (this.sprite != null)
				{
					this.sprite.RemoveSelfFromParent();
					this.sprite = null;
				}
			}

			// Token: 0x06002EA6 RID: 11942 RVA: 0x002566FC File Offset: 0x002548FC
			private void manageFadeOverBuildings(VillageMapBuilding building)
			{
				Point point = this.currentPos;
				bool flag = true;
				bool flag2 = false;
				for (int i = 0; i < 16; i++)
				{
					Point worldPos = new Point(point.X - 8 + i, point.Y + 5);
					Point worldPos2 = new Point(point.X - 8 + i, point.Y - 30);
					long buildingIDFromWorldPos = VillageMap.villageClickMask.getBuildingIDFromWorldPos(worldPos);
					long buildingIDFromWorldPos2 = VillageMap.villageClickMask.getBuildingIDFromWorldPos(worldPos2);
					if (buildingIDFromWorldPos >= 0L)
					{
						flag = false;
					}
					if (buildingIDFromWorldPos2 >= 0L)
					{
						flag = false;
					}
					if (buildingIDFromWorldPos == building.buildingID || buildingIDFromWorldPos2 == building.buildingID)
					{
						flag2 = true;
						break;
					}
				}
				for (int j = 0; j < 35; j++)
				{
					Point worldPos3 = new Point(point.X - 8, point.Y - 30 + j);
					Point worldPos4 = new Point(point.X + 8, point.Y - 30 + j);
					long buildingIDFromWorldPos3 = VillageMap.villageClickMask.getBuildingIDFromWorldPos(worldPos3);
					long buildingIDFromWorldPos4 = VillageMap.villageClickMask.getBuildingIDFromWorldPos(worldPos4);
					if (buildingIDFromWorldPos3 >= 0L)
					{
						flag = false;
					}
					if (buildingIDFromWorldPos4 >= 0L)
					{
						flag = false;
					}
					if (buildingIDFromWorldPos3 == building.buildingID || buildingIDFromWorldPos4 == building.buildingID)
					{
						flag2 = true;
						break;
					}
				}
				if (flag || flag2)
				{
					this.fadeToSolid();
				}
				else
				{
					this.fadeToTransparent();
				}
				int num = (int)this.sprite.ColorToUse.A;
				num += this.fadeDir;
				if (num < 120)
				{
					num = 120;
				}
				else if (num > 255)
				{
					num = 255;
				}
				this.sprite.ColorToUse = Color.FromArgb((int)((byte)num), 255, 255, 255);
			}

			// Token: 0x06002EA7 RID: 11943 RVA: 0x00021DC8 File Offset: 0x0001FFC8
			public void fadeToSolid()
			{
				this.fadeDir = 10;
			}

			// Token: 0x06002EA8 RID: 11944 RVA: 0x00021DD2 File Offset: 0x0001FFD2
			public void fadeToTransparent()
			{
				this.fadeDir = -10;
			}

			// Token: 0x040039F5 RID: 14837
			public int buildingType;

			// Token: 0x040039F6 RID: 14838
			public int id;

			// Token: 0x040039F7 RID: 14839
			public int state;

			// Token: 0x040039F8 RID: 14840
			public int cycleCount;

			// Token: 0x040039F9 RID: 14841
			public int tick;

			// Token: 0x040039FA RID: 14842
			public int randValue;

			// Token: 0x040039FB RID: 14843
			public int idleTime = 1;

			// Token: 0x040039FC RID: 14844
			public int range;

			// Token: 0x040039FD RID: 14845
			public SpriteWrapper sprite;

			// Token: 0x040039FE RID: 14846
			public Point startPos;

			// Token: 0x040039FF RID: 14847
			public Point endPos;

			// Token: 0x04003A00 RID: 14848
			public Point currentPos;

			// Token: 0x04003A01 RID: 14849
			public int journeyLength = 1;

			// Token: 0x04003A02 RID: 14850
			public int numWalkFrames = 1;

			// Token: 0x04003A03 RID: 14851
			public int numIdleFrames = 1;

			// Token: 0x04003A04 RID: 14852
			public short[] idleAnim;

			// Token: 0x04003A05 RID: 14853
			public int baseIdleFrame;

			// Token: 0x04003A06 RID: 14854
			public Random rand;

			// Token: 0x04003A07 RID: 14855
			public int fadeDir;

			// Token: 0x04003A08 RID: 14856
			public bool flock;

			// Token: 0x04003A09 RID: 14857
			private static short[] pigIdleAnim = new short[]
			{
				0,
				8,
				16,
				24,
				32,
				40,
				48,
				56,
				64,
				72,
				80,
				88,
				96,
				104,
				112,
				120,
				32,
				40,
				48,
				56,
				64,
				72,
				80,
				88,
				96,
				104,
				112,
				120,
				32,
				40,
				48,
				56,
				64,
				72,
				80,
				88,
				96,
				104,
				112,
				120,
				32,
				40,
				48,
				56,
				64,
				72,
				80,
				88,
				96,
				104,
				112,
				120,
				32,
				40,
				48,
				56,
				64,
				72,
				80,
				88,
				96,
				104,
				112,
				120,
				32,
				40,
				48,
				56,
				64,
				72,
				80,
				88,
				96,
				104,
				112,
				120,
				32,
				40,
				48,
				56,
				64,
				72,
				80,
				88,
				96,
				104,
				112,
				120,
				16,
				8
			};

			// Token: 0x04003A0A RID: 14858
			private static short[] chickenIdleAnim = new short[]
			{
				0,
				8,
				16,
				24,
				32,
				40,
				48,
				56,
				64,
				72,
				80,
				88,
				96,
				104,
				112,
				120,
				112,
				104,
				96,
				88,
				80,
				72,
				64,
				56,
				48,
				56,
				64,
				72,
				80,
				88,
				96,
				104,
				112,
				120,
				112,
				104,
				96,
				88,
				80,
				72,
				64,
				56,
				48,
				56,
				64,
				72,
				80,
				88,
				96,
				104,
				112,
				120,
				112,
				104,
				96,
				88,
				80,
				72,
				64,
				56,
				48,
				56,
				64,
				72,
				80,
				88,
				96,
				104,
				112,
				120,
				112,
				104,
				96,
				88,
				80,
				72,
				64,
				56,
				48,
				56,
				64,
				72,
				80,
				88,
				96,
				104,
				112,
				120,
				112,
				104,
				96,
				88,
				80,
				72,
				64,
				56,
				40,
				32,
				24,
				16,
				8,
				0
			};
		}

		// Token: 0x020004DD RID: 1245
		public class VillageAnimalCollection
		{
			// Token: 0x04003A0B RID: 14859
			public List<VillageMap.VillageAnimal> animals = new List<VillageMap.VillageAnimal>();

			// Token: 0x04003A0C RID: 14860
			public long buildingID = -1L;
		}
	}
}
