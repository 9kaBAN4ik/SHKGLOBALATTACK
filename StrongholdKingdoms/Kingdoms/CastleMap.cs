using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using CommonTypes;
using DXGraphics;
using Upgrade;
using Upgrade.Services;

namespace Kingdoms
{
	// Token: 0x02000115 RID: 277
	public class CastleMap
	{
		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060008FA RID: 2298 RVA: 0x0000D3C1 File Offset: 0x0000B5C1
		public int VillageID
		{
			get
			{
				return this.m_villageID;
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060008FB RID: 2299 RVA: 0x0000D3C9 File Offset: 0x0000B5C9
		// (set) Token: 0x060008FC RID: 2300 RVA: 0x0000D3D0 File Offset: 0x0000B5D0
		public static int FakeKeep
		{
			get
			{
				return CastleMap.fakeKeep;
			}
			set
			{
				CastleMap.fakeKeep = value;
			}
		}

		// Token: 0x17000069 RID: 105
		// (set) Token: 0x060008FD RID: 2301 RVA: 0x0000D3D8 File Offset: 0x0000B5D8
		public static int FakeDefensiveMode
		{
			set
			{
				CastleMap.fakeDefensiveMode = value;
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060008FE RID: 2302 RVA: 0x0000D3E0 File Offset: 0x0000B5E0
		// (set) Token: 0x060008FF RID: 2303 RVA: 0x0000D3E7 File Offset: 0x0000B5E7
		public static bool CreateMode
		{
			get
			{
				return CastleMap.createMode;
			}
			set
			{
				CastleMap.createMode = value;
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000900 RID: 2304 RVA: 0x0000D3EF File Offset: 0x0000B5EF
		public int CastleMode
		{
			get
			{
				return this.m_castleMode;
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000901 RID: 2305 RVA: 0x0000D3F7 File Offset: 0x0000B5F7
		public bool Enclosed
		{
			get
			{
				return this.m_castleEnclosed;
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000902 RID: 2306 RVA: 0x0000D3FF File Offset: 0x0000B5FF
		public bool InBuilderMode
		{
			get
			{
				return this.inBuilderMode;
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000903 RID: 2307 RVA: 0x0000D407 File Offset: 0x0000B607
		public bool InTroopPlacerMode
		{
			get
			{
				return this.inTroopPlacerMode;
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06000904 RID: 2308 RVA: 0x0000D40F File Offset: 0x0000B60F
		public CastleCameraWinforms Camera
		{
			get
			{
				return this.m_camera;
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x06000905 RID: 2309 RVA: 0x0000D417 File Offset: 0x0000B617
		public bool isDragging
		{
			get
			{
				return this.m_draggingMap;
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06000906 RID: 2310 RVA: 0x0000D41F File Offset: 0x0000B61F
		// (set) Token: 0x06000907 RID: 2311 RVA: 0x0000D427 File Offset: 0x0000B627
		public int placementType
		{
			get
			{
				return this.m_placementType;
			}
			set
			{
				this.m_placementType = value;
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000908 RID: 2312 RVA: 0x0000D430 File Offset: 0x0000B630
		// (set) Token: 0x06000909 RID: 2313 RVA: 0x0000D438 File Offset: 0x0000B638
		private bool placingDefender
		{
			get
			{
				return this.m_placingDefender;
			}
			set
			{
				this.m_placingDefender = value;
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x0600090A RID: 2314 RVA: 0x0000D441 File Offset: 0x0000B641
		public CastleMap.Gesture gesture
		{
			get
			{
				return this.m_gesture;
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x0600090B RID: 2315 RVA: 0x0000D449 File Offset: 0x0000B649
		public bool canUndoWalls
		{
			get
			{
				return this.wallUndoSteps.Count > 0;
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x0600090C RID: 2316 RVA: 0x0000D459 File Offset: 0x0000B659
		public int PiecesBeingPlaced
		{
			get
			{
				return this.piecesBeingPlaced;
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x0600090D RID: 2317 RVA: 0x0000D461 File Offset: 0x0000B661
		// (set) Token: 0x0600090E RID: 2318 RVA: 0x0000D469 File Offset: 0x0000B669
		public CastleMap.BrushSize CurrentBrushSize
		{
			get
			{
				return this.m_currentBrushSize;
			}
			set
			{
				this.m_currentBrushSize = value;
				this.createDestroyPlacementTroopSprites();
				if (CastleMap.placementTroopSprite[0] != null && !this.placingElement)
				{
					this.troopsFollowMouse(this.lastMoveTileX, this.lastMoveTileY);
				}
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x0600090F RID: 2319 RVA: 0x0000D49B File Offset: 0x0000B69B
		public double CapitalAttackRate
		{
			get
			{
				return this.attackCapitalAttackRate;
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x06000910 RID: 2320 RVA: 0x0000D4A3 File Offset: 0x0000B6A3
		public CastleMapRendering castleMapRendering
		{
			get
			{
				return GameEngine.Instance.castleMapRendering;
			}
		}

		// Token: 0x06000911 RID: 2321 RVA: 0x0000D4AF File Offset: 0x0000B6AF
		public static void setServerTime(DateTime serverTime)
		{
			CastleMap.baseServerTime = serverTime;
			CastleMap.localBaseTime = DXTimer.GetCurrentMilliseconds();
		}

		// Token: 0x06000912 RID: 2322 RVA: 0x000BA938 File Offset: 0x000B8B38
		public static DateTime getCurrentServerTime()
		{
			double value = (DXTimer.GetCurrentMilliseconds() - CastleMap.localBaseTime) / 1000.0;
			return CastleMap.baseServerTime.AddSeconds(value);
		}

		// Token: 0x06000913 RID: 2323 RVA: 0x000BA968 File Offset: 0x000B8B68
		public bool isTutorialEnclosedComplete()
		{
			if (this.inBuilderMode || this.inTroopPlacerMode)
			{
				return false;
			}
			if (this.m_castleEnclosed)
			{
				return true;
			}
			if (this.elements.Count == 31)
			{
				return false;
			}
			foreach (CastleElement castleElement in this.elements)
			{
				if (castleElement.elementType > 10 && castleElement.elementType < 69)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000914 RID: 2324 RVA: 0x0000D4C1 File Offset: 0x0000B6C1
		public void setCampMode(int mode)
		{
			this.campMode = mode;
		}

		// Token: 0x06000915 RID: 2325 RVA: 0x000BA9FC File Offset: 0x000B8BFC
		public CastleMap(int villageID, GraphicsMgr mgr, int mode)
		{
			CastleMap.fakeKeep = -1;
			this.m_castleMode = mode;
			this.m_villageID = villageID;
			if (!CastleMap.spritesInitiated)
			{
				List<CastleMap.TempTileSortClass> list = new List<CastleMap.TempTileSortClass>();
				List<CastleMap.TempTileSortClass> list2 = new List<CastleMap.TempTileSortClass>();
				for (int i = 0; i < 118; i++)
				{
					for (int j = 0; j < 118; j++)
					{
						int num = i * 16 + j * 16 - 922;
						int num2 = j * 8 - i * 8 + 474;
						if (num >= -48 && num2 >= -24 && num < 1952 && num2 < 976)
						{
							if (i >= 29 && j >= 29 && i < 89 && j < 89)
							{
								list.Add(new CastleMap.TempTileSortClass
								{
									gx = i,
									gy = j,
									sx = num,
									sy = num2
								});
							}
							else
							{
								list2.Add(new CastleMap.TempTileSortClass
								{
									gx = i,
									gy = j,
									sx = num,
									sy = num2
								});
							}
						}
					}
				}
				this.castleMapRendering.backgroundSprite.TextureID = GFXLibrary.Instance.CastleBackgroundTexID;
				this.castleMapRendering.backgroundSprite.Initialize(this.castleMapRendering.gfx);
				this.castleMapRendering.backgroundSprite.SpriteNo = 0;
				this.castleMapRendering.backgroundSprite.PosX = (float)((int)(0f - (this.castleMapRendering.backgroundSprite.Width - (float)InterfaceMgr.Instance.ParentMainWindow.getDXBasePanel().Width) / 2f));
				this.castleMapRendering.backgroundSprite.PosY = (float)((int)(0f - (this.castleMapRendering.backgroundSprite.Height - (float)InterfaceMgr.Instance.ParentMainWindow.getDXBasePanel().Height) / 2f));
				this.castleMapRendering.backgroundSprite.Scale = 1f;
				this.createSurroundSprites();
				list.Sort(this.tempTileSortComparer);
				foreach (CastleMap.TempTileSortClass tempTileSortClass in list)
				{
					CastleMap.castleSpriteGrid[tempTileSortClass.gx, tempTileSortClass.gy] = new SpriteWrapper();
					CastleMap.castleSpriteGrid[tempTileSortClass.gx, tempTileSortClass.gy].TextureID = GFXLibrary.Instance.CastleSpritesTexID;
					CastleMap.castleSpriteGrid[tempTileSortClass.gx, tempTileSortClass.gy].Initialize(this.castleMapRendering.gfx);
					CastleMap.castleSpriteGrid[tempTileSortClass.gx, tempTileSortClass.gy].PosX = (float)(tempTileSortClass.sx + 16);
					CastleMap.castleSpriteGrid[tempTileSortClass.gx, tempTileSortClass.gy].PosY = (float)(tempTileSortClass.sy + 8);
					CastleMap.castleSpriteGrid[tempTileSortClass.gx, tempTileSortClass.gy].Center = new PointF(16f, 8f);
					CastleMap.castleSpriteGrid[tempTileSortClass.gx, tempTileSortClass.gy].SpriteNo = 0;
					CastleMap.castleSpriteGrid[tempTileSortClass.gx, tempTileSortClass.gy].Visible = false;
					CastleMap.castleDefenderSpriteGrid[tempTileSortClass.gx, tempTileSortClass.gy] = new SpriteWrapper();
					CastleMap.castleDefenderSpriteGrid[tempTileSortClass.gx, tempTileSortClass.gy].TextureID = GFXLibrary.Instance.CastleSpritesTexID;
					CastleMap.castleDefenderSpriteGrid[tempTileSortClass.gx, tempTileSortClass.gy].Initialize(this.castleMapRendering.gfx);
					CastleMap.castleDefenderSpriteGrid[tempTileSortClass.gx, tempTileSortClass.gy].PosX = (float)(tempTileSortClass.sx + 16);
					CastleMap.castleDefenderSpriteGrid[tempTileSortClass.gx, tempTileSortClass.gy].PosY = (float)(tempTileSortClass.sy + 8);
					CastleMap.castleUnitSpritePoint[tempTileSortClass.gx, tempTileSortClass.gy] = new Point(tempTileSortClass.sx + 16, tempTileSortClass.sy + 8);
					CastleMap.castleDefenderSpriteGrid[tempTileSortClass.gx, tempTileSortClass.gy].Center = new PointF(50f, 66f);
					CastleMap.castleDefenderSpriteGrid[tempTileSortClass.gx, tempTileSortClass.gy].SpriteNo = 0;
					CastleMap.castleDefenderSpriteGrid[tempTileSortClass.gx, tempTileSortClass.gy].Visible = false;
				}
				list2.Sort(this.tempTileSortComparer);
				foreach (CastleMap.TempTileSortClass tempTileSortClass2 in list2)
				{
					CastleMap.castleSpriteGrid[tempTileSortClass2.gx, tempTileSortClass2.gy] = new SpriteWrapper();
					CastleMap.castleSpriteGrid[tempTileSortClass2.gx, tempTileSortClass2.gy].TextureID = GFXLibrary.Instance.CastleSpritesTexID;
					CastleMap.castleSpriteGrid[tempTileSortClass2.gx, tempTileSortClass2.gy].Initialize(this.castleMapRendering.gfx);
					CastleMap.castleSpriteGrid[tempTileSortClass2.gx, tempTileSortClass2.gy].PosX = (float)(tempTileSortClass2.sx + 16);
					CastleMap.castleSpriteGrid[tempTileSortClass2.gx, tempTileSortClass2.gy].PosY = (float)(tempTileSortClass2.sy + 8);
					CastleMap.castleSpriteGrid[tempTileSortClass2.gx, tempTileSortClass2.gy].Center = new PointF(16f, 8f);
					CastleMap.castleSpriteGrid[tempTileSortClass2.gx, tempTileSortClass2.gy].SpriteNo = 0;
					CastleMap.castleSpriteGrid[tempTileSortClass2.gx, tempTileSortClass2.gy].Visible = false;
					CastleMap.castleAttackerSpriteGrid[tempTileSortClass2.gx, tempTileSortClass2.gy] = new SpriteWrapper();
					CastleMap.castleAttackerSpriteGrid[tempTileSortClass2.gx, tempTileSortClass2.gy].TextureID = GFXLibrary.Instance.CastleSpritesTexID;
					CastleMap.castleAttackerSpriteGrid[tempTileSortClass2.gx, tempTileSortClass2.gy].Initialize(this.castleMapRendering.gfx);
					CastleMap.castleAttackerSpriteGrid[tempTileSortClass2.gx, tempTileSortClass2.gy].PosX = (float)(tempTileSortClass2.sx + 16);
					CastleMap.castleAttackerSpriteGrid[tempTileSortClass2.gx, tempTileSortClass2.gy].PosY = (float)(tempTileSortClass2.sy + 8);
					CastleMap.castleUnitSpritePoint[tempTileSortClass2.gx, tempTileSortClass2.gy] = new Point(tempTileSortClass2.sx + 16, tempTileSortClass2.sy + 8);
					CastleMap.castleAttackerSpriteGrid[tempTileSortClass2.gx, tempTileSortClass2.gy].Center = new PointF(50f, 66f);
					CastleMap.castleAttackerSpriteGrid[tempTileSortClass2.gx, tempTileSortClass2.gy].SpriteNo = 0;
					CastleMap.castleAttackerSpriteGrid[tempTileSortClass2.gx, tempTileSortClass2.gy].Visible = false;
				}
				CastleMap.spritesInitiated = true;
			}
			this.m_camera = new CastleCameraWinforms(this.castleMapRendering.backgroundSprite);
		}

		// Token: 0x06000916 RID: 2326 RVA: 0x0000D4CA File Offset: 0x0000B6CA
		public void startBuilderMode()
		{
			this.inBuilderMode = true;
			if (this.removedElements == null)
			{
				this.removedElements = new List<CastleElement>();
			}
			else
			{
				this.removedElements.Clear();
			}
			this.recalcCastleLayout();
		}

		// Token: 0x06000917 RID: 2327 RVA: 0x000BC6C4 File Offset: 0x000BA8C4
		public void startTroopPlacerMode()
		{
			this.inTroopPlacerMode = true;
			if (this.removedElements == null)
			{
				this.removedElements = new List<CastleElement>();
			}
			else
			{
				this.removedElements.Clear();
			}
			if (this.movedElements == null)
			{
				this.movedElements = new List<CastleElement>();
			}
			else
			{
				this.movedElements.Clear();
			}
			if (this.movedElementsOriginal == null)
			{
				this.movedElementsOriginal = new List<CastleElement>();
				return;
			}
			this.movedElementsOriginal.Clear();
		}

		// Token: 0x06000918 RID: 2328 RVA: 0x000BC738 File Offset: 0x000BA938
		public void adjustLevels(ref VillageMap.StockpileLevels levels, ref int goldLevel)
		{
			if (this.inBuilderMode)
			{
				bool flag = false;
				foreach (CastleElement castleElement in this.elements)
				{
					if (castleElement.elementID < -1L)
					{
						int num = 0;
						int num2 = 0;
						int num3 = 0;
						int num4 = 0;
						int num5 = 0;
						CastlesCommon.getConstrCost(GameEngine.Instance.LocalWorldData, (int)castleElement.elementType, ref num, ref num2, ref num3, ref num4, ref num5);
						levels.woodLevel -= (double)num;
						levels.stoneLevel -= (double)num2;
						levels.pitchLevel -= (double)num4;
						levels.ironLevel -= (double)num5;
						goldLevel -= num3;
						flag = true;
					}
				}
				if (!flag)
				{
					this.inBuilderMode = false;
					this.recalcCastleLayout();
				}
			}
			if (this.inTroopPlacerMode && this.placingDefender)
			{
				bool flag2 = false;
				foreach (CastleElement castleElement2 in this.elements)
				{
					if (castleElement2.elementID < -1L)
					{
						int num6 = 0;
						int num7 = 0;
						int num8 = 0;
						int num9 = 0;
						int num10 = 0;
						CastlesCommon.getConstrCost(GameEngine.Instance.LocalWorldData, (int)castleElement2.elementType, ref num6, ref num7, ref num8, ref num9, ref num10);
						levels.woodLevel -= (double)num6;
						levels.stoneLevel -= (double)num7;
						levels.pitchLevel -= (double)num9;
						levels.ironLevel -= (double)num10;
						goldLevel -= num8;
						flag2 = true;
					}
				}
				if (!flag2)
				{
					this.inBuilderMode = false;
					this.recalcCastleLayout();
				}
			}
		}

		// Token: 0x06000919 RID: 2329 RVA: 0x000BC920 File Offset: 0x000BAB20
		public string GetNewBuildTime()
		{
			bool flag = GameEngine.Instance.World.isCapital(this.m_villageID);
			CardData cardData = new CardData();
			if (!flag)
			{
				cardData = GameEngine.Instance.cardsManager.UserCardData;
			}
			double num = 0.0;
			foreach (CastleElement castleElement in this.elements)
			{
				if (castleElement.elementID < -1L)
				{
					num += CastlesCommon.calcConstrTime(GameEngine.Instance.LocalWorldData, (int)castleElement.elementType, (int)GameEngine.Instance.World.GetResearchDataForCurrentVillage().Research_Construction, flag, cardData);
				}
			}
			return VillageMap.createBuildTimeString((int)(num * 3600.0));
		}

		// Token: 0x0600091A RID: 2330 RVA: 0x000BC9F4 File Offset: 0x000BABF4
		public void reInitGFX()
		{
			this.recalcCastleLayout();
			VillageMap village = GameEngine.Instance.Village;
			if (village != null)
			{
				this.numAvailableDefenderPeasants = 0;
				this.numAvailableDefenderArchers = 0;
				this.numAvailableDefenderPikemen = 0;
				this.numAvailableDefenderSwordsmen = 0;
				this.numAvailableDefenderCaptains = 0;
				village.getVillageTroops(ref this.numAvailableDefenderPeasants, ref this.numAvailableDefenderArchers, ref this.numAvailableDefenderPikemen, ref this.numAvailableDefenderSwordsmen, ref this.numAvailableDefenderCaptains);
				GameEngine.Instance.World.getReinforceTotals(village.VillageID, ref this.numAvailableReinforceDefenderPeasants, ref this.numAvailableReinforceDefenderArchers, ref this.numAvailableReinforceDefenderPikemen, ref this.numAvailableReinforceDefenderSwordsmen);
				village.getVillageVassalTroops(ref this.numAvailableVassalReinforceDefenderPeasants, ref this.numAvailableVassalReinforceDefenderArchers, ref this.numAvailableVassalReinforceDefenderPikemen, ref this.numAvailableVassalReinforceDefenderSwordsmen);
			}
			this.createSurroundSprites();
			this.cancelBuilderMode();
		}

		// Token: 0x0600091B RID: 2331 RVA: 0x000BCAB8 File Offset: 0x000BACB8
		public void updateAvailableTroops()
		{
			VillageMap village = GameEngine.Instance.Village;
			if (village != null)
			{
				this.numAvailableDefenderPeasants = 0;
				this.numAvailableDefenderArchers = 0;
				this.numAvailableDefenderPikemen = 0;
				this.numAvailableDefenderSwordsmen = 0;
				this.numAvailableDefenderCaptains = 0;
				village.getVillageTroops(ref this.numAvailableDefenderPeasants, ref this.numAvailableDefenderArchers, ref this.numAvailableDefenderPikemen, ref this.numAvailableDefenderSwordsmen, ref this.numAvailableDefenderCaptains);
				GameEngine.Instance.World.getReinforceTotals(village.VillageID, ref this.numAvailableReinforceDefenderPeasants, ref this.numAvailableReinforceDefenderArchers, ref this.numAvailableReinforceDefenderPikemen, ref this.numAvailableReinforceDefenderSwordsmen);
				village.getVillageVassalTroops(ref this.numAvailableVassalReinforceDefenderPeasants, ref this.numAvailableVassalReinforceDefenderArchers, ref this.numAvailableVassalReinforceDefenderPikemen, ref this.numAvailableVassalReinforceDefenderSwordsmen);
			}
		}

		// Token: 0x0600091C RID: 2332 RVA: 0x000BCB68 File Offset: 0x000BAD68
		public void castleShown(bool getTroops)
		{
			GameEngine.Instance.castleMapRendering.backgroundSprite.PosX = (float)((int)(0f - (GameEngine.Instance.castleMapRendering.backgroundSprite.Width - (float)InterfaceMgr.Instance.ParentMainWindow.getDXBasePanel().Width) / 2f));
			GameEngine.Instance.castleMapRendering.backgroundSprite.PosY = (float)((int)(0f - (GameEngine.Instance.castleMapRendering.backgroundSprite.Height - (float)InterfaceMgr.Instance.ParentMainWindow.getDXBasePanel().Height) / 2f));
			this.stopPlaceElement();
			this.displayType = 0;
			CastleMap.fakeKeep = -1;
			if (getTroops)
			{
				this.manageTutorial();
				VillageMap village = GameEngine.Instance.Village;
				if (village != null)
				{
					this.numAvailableDefenderPeasants = 0;
					this.numAvailableDefenderArchers = 0;
					this.numAvailableDefenderPikemen = 0;
					this.numAvailableDefenderSwordsmen = 0;
					this.numAvailableDefenderCaptains = 0;
					village.getVillageTroops(ref this.numAvailableDefenderPeasants, ref this.numAvailableDefenderArchers, ref this.numAvailableDefenderPikemen, ref this.numAvailableDefenderSwordsmen, ref this.numAvailableDefenderCaptains);
					GameEngine.Instance.World.getReinforceTotals(village.VillageID, ref this.numAvailableReinforceDefenderPeasants, ref this.numAvailableReinforceDefenderArchers, ref this.numAvailableReinforceDefenderPikemen, ref this.numAvailableReinforceDefenderSwordsmen);
					village.getVillageVassalTroops(ref this.numAvailableVassalReinforceDefenderPeasants, ref this.numAvailableVassalReinforceDefenderArchers, ref this.numAvailableVassalReinforceDefenderPikemen, ref this.numAvailableVassalReinforceDefenderSwordsmen);
				}
				this.recalcCastleLayout();
			}
		}

		// Token: 0x0600091D RID: 2333 RVA: 0x000BCCD8 File Offset: 0x000BAED8
		public int countOwnPlacedTroops()
		{
			int num = 0;
			foreach (CastleElement castleElement in this.elements)
			{
				if (!castleElement.reinforcement && !castleElement.vassalReinforcements)
				{
					byte elementType = castleElement.elementType;
					if (elementType - 70 <= 3 || elementType == 77 || elementType == 85)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x0600091E RID: 2334 RVA: 0x000BCD54 File Offset: 0x000BAF54
		public int countPlacedTroops()
		{
			int num = 0;
			foreach (CastleElement castleElement in this.elements)
			{
				byte elementType = castleElement.elementType;
				if (elementType - 70 <= 3 || elementType == 77 || elementType == 85)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x0600091F RID: 2335 RVA: 0x000BCDC0 File Offset: 0x000BAFC0
		public int countPlacedElements(params int[] elementTypes)
		{
			int num = 0;
			foreach (CastleElement castleElement in this.elements)
			{
				foreach (int num2 in elementTypes)
				{
					if ((int)castleElement.elementType == num2)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x06000920 RID: 2336 RVA: 0x000BCE38 File Offset: 0x000BB038
		public int countPlacedInfrastructure()
		{
			int num = 0;
			foreach (CastleElement castleElement in this.elements)
			{
				if (castleElement.elementType > 10 && castleElement.elementType < 69)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000921 RID: 2337 RVA: 0x000BCEA0 File Offset: 0x000BB0A0
		public int countPlacedMoat()
		{
			int num = 0;
			foreach (CastleElement castleElement in this.elements)
			{
				if (castleElement.elementType == 35)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000922 RID: 2338 RVA: 0x000BCF00 File Offset: 0x000BB100
		public int countPlacedPits()
		{
			int num = 0;
			foreach (CastleElement castleElement in this.elements)
			{
				if (castleElement.elementType == 36)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000923 RID: 2339 RVA: 0x000BCF60 File Offset: 0x000BB160
		public int countPlacedOilPots()
		{
			int num = 0;
			foreach (CastleElement castleElement in this.elements)
			{
				if (castleElement.elementType == 75)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000924 RID: 2340 RVA: 0x000BCFC0 File Offset: 0x000BB1C0
		public int countOwnPlacedCaptains()
		{
			int num = 0;
			foreach (CastleElement castleElement in this.elements)
			{
				if (!castleElement.reinforcement && !castleElement.vassalReinforcements)
				{
					byte elementType = castleElement.elementType;
					if (elementType == 85)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x06000925 RID: 2341 RVA: 0x000BD030 File Offset: 0x000BB230
		public void countOwnPlacedTroopTypes(ref int numPeasants, ref int numArchers, ref int numPikemen, ref int numSwordsmen, ref int numCaptains)
		{
			numPeasants = 0;
			numArchers = 0;
			numPikemen = 0;
			numSwordsmen = 0;
			numCaptains = 0;
			foreach (CastleElement castleElement in this.elements)
			{
				if (!castleElement.reinforcement && !castleElement.vassalReinforcements)
				{
					byte elementType = castleElement.elementType;
					switch (elementType)
					{
					case 70:
						numPeasants++;
						break;
					case 71:
						numSwordsmen++;
						break;
					case 72:
						numArchers++;
						break;
					case 73:
						numPikemen++;
						break;
					default:
						if (elementType == 85)
						{
							numCaptains++;
						}
						break;
					}
				}
			}
		}

		// Token: 0x06000926 RID: 2342 RVA: 0x000BD0F0 File Offset: 0x000BB2F0
		public void importElements(List<CastleElement> newElements)
		{
			if (this.elements == null)
			{
				this.elements = new List<CastleElement>();
			}
			else
			{
				this.elements.Clear();
			}
			CastleElement castleElement = new CastleElement();
			castleElement.completionTime = DateTime.Now.AddDays(-100.0);
			int num = (int)(GameEngine.Instance.World.GetResearchDataForCurrentVillage().Research_Castellation - 1);
			if (num < 0)
			{
				num = 0;
			}
			num++;
			if (CastleMap.CreateMode)
			{
				num = 1;
			}
			castleElement.elementType = (byte)num;
			castleElement.elementID = -1L;
			castleElement.xPos = 58;
			castleElement.yPos = 59;
			this.elements.Add(castleElement);
			this.elements.AddRange(newElements);
			VillageMap village = GameEngine.Instance.getVillage(this.m_villageID);
			if (village != null)
			{
				int villageMapType = village.VillageMapType;
				CastlesCommon.addLandTypeAdditions(this.elements, villageMapType);
				this.attackerSetupForest = (villageMapType == 9);
			}
			this.updateLayoutAndRedraw();
		}

		// Token: 0x06000927 RID: 2343 RVA: 0x0000D4F9 File Offset: 0x0000B6F9
		public void dispose()
		{
			this.elements.Clear();
		}

		// Token: 0x06000928 RID: 2344 RVA: 0x0000D506 File Offset: 0x0000B706
		public void leaveMap()
		{
			Sound.stopVillageEnvironmentalExceptWorld();
		}

		// Token: 0x06000929 RID: 2345 RVA: 0x000BD1DC File Offset: 0x000BB3DC
		private void addNoBuildTile(int x, int y)
		{
			SpriteWrapper spriteWrapper = CastleMap.castleSpriteGrid[x, y];
			SizeF sizeF = new SizeF(0f, 0f);
			spriteWrapper.Visible = true;
			spriteWrapper.ColorToUse = Color.FromArgb(64, global::ARGBColors.Black);
			PointF center = new PointF(16f, 0f);
			float num = 8f;
			int spriteTag = 1;
			UVSpriteLoader spriteLoader = this.castleMapRendering.gfx.getSpriteLoader(GFXLibrary.Instance.CastleSpritesTexID, ref spriteTag);
			Rectangle rectangle;
			PointF pointF;
			spriteLoader.GetSpriteXYdata(spriteTag, 276, out rectangle, out pointF, out sizeF);
			center.Y = (float)((int)sizeF.Height) - num;
			spriteWrapper.SpriteNo = 276;
			spriteWrapper.Center = center;
			this.castleMapRendering.backgroundSprite.AddChild(spriteWrapper, 2);
		}

		// Token: 0x0600092A RID: 2346 RVA: 0x000BD2A4 File Offset: 0x000BB4A4
		public void recalcCastleInit()
		{
			if (this.attackerSetupForest)
			{
				if (this.castleMapRendering.backgroundSprite.TextureID == GFXLibrary.Instance.CastleBackgroundTexID)
				{
					this.castleMapRendering.backgroundSprite.Initialize(this.castleMapRendering.gfx, GFXLibrary.Instance.FreeCardIconsID, 29);
				}
			}
			else if (this.castleMapRendering.backgroundSprite.TextureID != GFXLibrary.Instance.CastleBackgroundTexID)
			{
				this.castleMapRendering.backgroundSprite.Initialize(this.castleMapRendering.gfx, GFXLibrary.Instance.CastleBackgroundTexID, 0);
			}
			this.castleMapRendering.backgroundSprite.RemoveAllChildrenFast();
			for (int i = 0; i < 118; i++)
			{
				for (int j = 0; j < 118; j++)
				{
					if (CastleMap.castleSpriteGrid[i, j] != null)
					{
						CastleMap.castleSpriteGrid[i, j].Visible = false;
					}
					SpriteWrapper spriteWrapper = CastleMap.castleDefenderSpriteGrid[i, j];
					if (spriteWrapper != null && spriteWrapper.Visible)
					{
						spriteWrapper.Visible = false;
					}
					SpriteWrapper spriteWrapper2 = CastleMap.castleAttackerSpriteGrid[i, j];
					if (spriteWrapper2 != null && spriteWrapper2.Visible)
					{
						spriteWrapper2.Visible = false;
					}
				}
			}
			foreach (SpriteWrapper spriteWrapper3 in CastleMap.castleExtraSprites)
			{
				if (spriteWrapper3.Visible)
				{
					spriteWrapper3.Visible = false;
				}
			}
			if (CastleMap.buildingPlacementSprite != null)
			{
				this.castleMapRendering.backgroundSprite.AddChild(CastleMap.buildingPlacementSprite, 10);
			}
			for (int k = 0; k < 25; k++)
			{
				if (CastleMap.placementTroopSprite[k] != null)
				{
					this.castleMapRendering.backgroundSprite.AddChild(CastleMap.placementTroopSprite[k], 10);
					if (CastleMap.placementTroopCastleSprite[k] != null)
					{
						CastleMap.placementTroopSprite[k].AddChild(CastleMap.placementTroopCastleSprite[k], 1);
					}
				}
			}
			foreach (SpriteWrapper child in CastleMap.wallPlacementSprites)
			{
				this.castleMapRendering.backgroundSprite.AddChild(child, 10);
			}
			if (this.placementSprite_handleone != null)
			{
				this.castleMapRendering.backgroundSprite.AddChild(this.placementSprite_handleone, 11);
			}
			if (this.placementSprite_handletwo != null)
			{
				this.castleMapRendering.backgroundSprite.AddChild(this.placementSprite_handletwo, 11);
			}
		}

		// Token: 0x0600092B RID: 2347 RVA: 0x000BD51C File Offset: 0x000BB71C
		public void recalcCastleLayout()
		{
			CastleMap.activeCastleInfrastructureElements.Clear();
			this.recalcCastleInit();
			this.nextExtraSpriteID = 0;
			CastleMap.numClickAreas = 0;
			double value = (DXTimer.GetCurrentMilliseconds() - CastleMap.localBaseTime) / 1000.0;
			DateTime curTime = CastleMap.baseServerTime.AddSeconds(value);
			this.numGuardHouses = 0;
			this.numPlacedDefenderArchers = 0;
			this.numPlacedDefenderPeasants = 0;
			this.numPlacedDefenderSwordsmen = 0;
			this.numPlacedDefenderPikemen = 0;
			this.numPlacedDefenderCaptains = 0;
			this.numPlacedReinforceDefenderArchers = 0;
			this.numPlacedReinforceDefenderPeasants = 0;
			this.numPlacedReinforceDefenderSwordsmen = 0;
			this.numPlacedReinforceDefenderPikemen = 0;
			this.numPlacedVassalReinforceDefenderArchers = 0;
			this.numPlacedVassalReinforceDefenderPeasants = 0;
			this.numPlacedVassalReinforceDefenderSwordsmen = 0;
			this.numPlacedVassalReinforceDefenderPikemen = 0;
			this.attackNumPeasants = 0;
			this.attackNumArchers = 0;
			this.attackNumPikemen = 0;
			this.attackNumSwordsmen = 0;
			this.attackNumCatapults = 0;
			this.attackNumCaptains = 0;
			this.numPots = 0;
			this.castleDamaged = false;
			bool collapsed = CastleMap.displayCollapsed || (this.battleMode && CastleMap.AlwaysCollapsedWallsInBattles);
			this.completed = true;
			this.completeTime = curTime;
			if (this.elements != null)
			{
				if (this.debugDisplayMode == 1 || this.debugDisplayMode == 2 || this.debugDisplayMode == 3)
				{
					for (int i = 0; i < 118; i++)
					{
						for (int j = 0; j < 118; j++)
						{
							SpriteWrapper spriteWrapper = CastleMap.castleSpriteGrid[j, i];
							if (spriteWrapper != null)
							{
								PointF center = new PointF(16f, 0f);
								float num = 8f;
								int num2 = -1;
								if (this.debugDisplayMode == 1)
								{
									int attackerRouteMap = this.castleCombat.getAttackerRouteMap(j, i);
									if (attackerRouteMap >= 0)
									{
										num2 = 315 + attackerRouteMap % 64;
									}
								}
								else if (this.debugDisplayMode == 2)
								{
									int obstacleMap = this.castleCombat.getObstacleMap(j, i);
									if (obstacleMap > 0)
									{
										num2 = 315 + obstacleMap - 1;
									}
								}
								else if (this.debugDisplayMode == 3 && this.castleCombat.getPillageLeaveTargetMap(j, i))
								{
									num2 = 315;
								}
								if (num2 >= 0)
								{
									spriteWrapper.Visible = true;
									spriteWrapper.ColorToUse = global::ARGBColors.White;
									int spriteTag = 1;
									UVSpriteLoader spriteLoader = GameEngine.Instance.castleMapRendering.gfx.getSpriteLoader(GFXLibrary.Instance.CastleSpritesTexID, ref spriteTag);
									Rectangle rectangle;
									PointF center2;
									SizeF sizeF;
									spriteLoader.GetSpriteXYdata(spriteTag, num2, out rectangle, out center2, out sizeF);
									center.Y = (float)((int)sizeF.Height) - num;
									spriteWrapper.SpriteNo = num2;
									spriteWrapper.Center = center;
								}
								this.castleMapRendering.backgroundSprite.AddChild(spriteWrapper, 2);
							}
						}
					}
				}
				if (!this.attackerSetupMode && !this.battleMode && (this.InBuilderMode || this.placementType != -1))
				{
					for (int k = 55; k < 63; k++)
					{
						this.addNoBuildTile(k, 55);
						this.addNoBuildTile(k, 62);
					}
					for (int l = 56; l < 62; l++)
					{
						this.addNoBuildTile(55, l);
						this.addNoBuildTile(62, l);
					}
				}
				this.castleMapRendering.drawCastleLoop(collapsed, ref this.completed, ref this.completeTime, curTime, this);
				if (this.battleMode)
				{
					this.castleMapRendering.doFireList(this);
				}
				this.castleMapRendering.drawTroops(this);
				if (this.castleCombat != null)
				{
					this.castleMapRendering.drawDyingTroops(this);
					this.castleMapRendering.drawArrows(this);
					this.castleMapRendering.drawRocks(this);
				}
				if (this.attackerSetupMode)
				{
					this.clearCatapultLines();
					foreach (CatapultTarget catapultTarget in this.catapultTargets)
					{
						if (this.selectedCatapult == catapultTarget.elemID || this.showCatapultTargets || this.m_lassoElements.Contains(catapultTarget.elemID))
						{
							SpriteWrapper nextExtraSprite = this.getNextExtraSprite(GFXLibrary.Instance.CastleSpritesTexID, 379);
							PointF center2 = nextExtraSprite.Center = new PointF(96f, 46f);
							Point point = CastleMap.castleUnitSpritePoint[(int)catapultTarget.xPos, (int)catapultTarget.yPos];
							nextExtraSprite.PosX = (float)point.X;
							nextExtraSprite.PosY = (float)point.Y;
							if (!catapultTarget.valid)
							{
								nextExtraSprite.ColorToUse = Color.FromArgb(128, global::ARGBColors.Red);
							}
							this.castleMapRendering.backgroundSprite.AddChild(nextExtraSprite, 10);
							if (catapultTarget.catapult != null)
							{
								this.addCatapultTargetLine((int)catapultTarget.catapult.xPos, (int)catapultTarget.catapult.yPos, (int)catapultTarget.xPos, (int)catapultTarget.yPos);
							}
						}
					}
					if (this.selectedCatapult != -1L)
					{
						bool flag = true;
						if (this.selectedCatapult != -1L)
						{
							foreach (CastleElement castleElement in this.elements)
							{
								if (castleElement.elementID == this.selectedCatapult)
								{
									flag = CatapultTarget.validateCatapultSelect(castleElement, this.catapultTargetMoveX, this.catapultTargetMoveY);
									break;
								}
							}
						}
						if (flag)
						{
							SpriteWrapper nextExtraSprite2 = this.getNextExtraSprite(GFXLibrary.Instance.CastleSpritesTexID, 379);
							SpriteWrapper spriteWrapper2 = nextExtraSprite2;
							PointF center2 = new PointF(96f, 46f);
							spriteWrapper2.Center = center2;
							Point point2 = CastleMap.castleUnitSpritePoint[this.catapultTargetMoveX, this.catapultTargetMoveY];
							nextExtraSprite2.PosX = (float)point2.X;
							nextExtraSprite2.PosY = (float)point2.Y;
							if (!this.catapultTargetMoveValid)
							{
								nextExtraSprite2.ColorToUse = Color.FromArgb(128, global::ARGBColors.Red);
							}
							this.castleMapRendering.backgroundSprite.AddChild(nextExtraSprite2, 10);
						}
					}
				}
				this.castleMapRendering.backgroundSprite.Update();
			}
			if (!this.attackerSetupMode && !this.battleMode)
			{
				if (!GameEngine.Instance.World.isCapital(this.m_villageID))
				{
					bool flag2 = false;
					if (this.inBuilderMode)
					{
						flag2 = this.castleLayout.isCastleEnclosedGateHouseBlocking();
					}
					else
					{
						VillageMap village = GameEngine.Instance.Village;
						if (village != null)
						{
							flag2 = village.m_castleEnclosed;
						}
						else if (this.castleLayout != null)
						{
							flag2 = this.castleLayout.isCastleEnclosedGateHouseBlocking();
						}
					}
					if (flag2)
					{
						CastleMap.enclosedOverlaySprite.Initialize(this.castleMapRendering.gfx, GFXLibrary.Instance.CastleSpritesTexID, 465);
					}
					else
					{
						CastleMap.enclosedOverlaySprite.Initialize(this.castleMapRendering.gfx, GFXLibrary.Instance.CastleSpritesTexID, 466);
						CastleMap.enclosedOverlaySprite2.Initialize(this.castleMapRendering.gfx, GFXLibrary.Instance.CastleSpritesTexID, 467);
					}
					this.m_castleEnclosed = flag2;
				}
				this.numGuardHouseSpaces = this.getGuardHouseCapacity();
				this.numSmelterPlaces = this.numSmelter * GameEngine.Instance.LocalWorldData.castle_oilPerSmelter;
				InterfaceMgr.Instance.setCastleStats(this.numGuardHouseSpaces, this.numPlacedDefenderArchers, this.numPlacedDefenderPeasants, this.numPlacedDefenderPikemen, this.numPlacedDefenderSwordsmen, this.completeTime, this.completed, this.numAvailableDefenderPeasants, this.numAvailableDefenderArchers, this.numAvailableDefenderPikemen, this.numAvailableDefenderSwordsmen, this.numPots, this.numSmelterPlaces, this.castleDamaged, this.numPlacedReinforceDefenderArchers, this.numPlacedReinforceDefenderPeasants, this.numPlacedReinforceDefenderPikemen, this.numPlacedReinforceDefenderSwordsmen, this.numAvailableReinforceDefenderPeasants, this.numAvailableReinforceDefenderArchers, this.numAvailableReinforceDefenderPikemen, this.numAvailableReinforceDefenderSwordsmen, this.numAvailableVassalReinforceDefenderPeasants, this.numAvailableVassalReinforceDefenderArchers, this.numAvailableVassalReinforceDefenderPikemen, this.numAvailableVassalReinforceDefenderSwordsmen, this.numPlacedVassalReinforceDefenderArchers, this.numPlacedVassalReinforceDefenderPeasants, this.numPlacedVassalReinforceDefenderPikemen, this.numPlacedVassalReinforceDefenderSwordsmen, this.numPlacedDefenderCaptains, this.numAvailableDefenderCaptains);
				if (!this.attackerSetupMode && !this.battleMode && GameEngine.Instance.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_CASTLE)
				{
					if (!this.completed)
					{
						Sound.playVillageEnvironmental(18);
					}
					else
					{
						Sound.playVillageEnvironmental(17);
					}
				}
			}
			if (this.attackerSetupMode)
			{
				InterfaceMgr.Instance.castleShowPlacedAttackers(this.attackNumPeasants, this.attackNumArchers, this.attackNumPikemen, this.attackNumSwordsmen, this.attackNumCatapults, this.attackMaxPeasants, this.attackMaxArchers, this.attackMaxPikemen, this.attackMaxSwordsmen, this.attackMaxCatapults, this.attackNumCaptains, this.attackMaxCaptains, this.attackCaptainsCommand, this.attackMaxPeasantsInCastle, this.attackMaxArchersInCastle, this.attackMaxPikemenInCastle, this.attackMaxSwordsmenInCastle);
				this.updateLaunchButton();
			}
		}

		// Token: 0x0600092C RID: 2348 RVA: 0x000BDDC0 File Offset: 0x000BBFC0
		public int getGuardHouseCapacity()
		{
			if (!GameEngine.Instance.World.isCapital(this.m_villageID))
			{
				int numSpaces = (this.numGuardHouses + 2) * GameEngine.Instance.LocalWorldData.castle_troopsPerGuardHouse;
				return CardTypes.adjustGuardHouseSpace(GameEngine.Instance.cardsManager.UserCardData, numSpaces);
			}
			return (this.numGuardHouses + 5) * GameEngine.Instance.LocalWorldData.castle_troopsPerGuardHouse;
		}

		// Token: 0x0600092D RID: 2349 RVA: 0x000BDE30 File Offset: 0x000BC030
		public SpriteWrapper getNextExtraSprite()
		{
			SpriteWrapper spriteWrapper;
			if (this.nextExtraSpriteID >= CastleMap.castleExtraSprites.Count)
			{
				spriteWrapper = new SpriteWrapper();
				CastleMap.castleExtraSprites.Add(spriteWrapper);
			}
			else
			{
				spriteWrapper = CastleMap.castleExtraSprites[this.nextExtraSpriteID];
			}
			this.nextExtraSpriteID++;
			spriteWrapper.Initialize(this.castleMapRendering.gfx, GFXLibrary.Instance.CastleSpritesTexID, 0);
			spriteWrapper.Scale = 1f;
			spriteWrapper.Visible = true;
			spriteWrapper.ColorToUse = global::ARGBColors.White;
			spriteWrapper.TroopType = 0;
			return spriteWrapper;
		}

		// Token: 0x0600092E RID: 2350 RVA: 0x000BDEC4 File Offset: 0x000BC0C4
		public SpriteWrapper getNextExtraSprite(int spriteID)
		{
			SpriteWrapper spriteWrapper;
			if (this.nextExtraSpriteID >= CastleMap.castleExtraSprites.Count)
			{
				spriteWrapper = new SpriteWrapper();
				CastleMap.castleExtraSprites.Add(spriteWrapper);
			}
			else
			{
				spriteWrapper = CastleMap.castleExtraSprites[this.nextExtraSpriteID];
			}
			this.nextExtraSpriteID++;
			spriteWrapper.Initialize(this.castleMapRendering.gfx, GFXLibrary.Instance.CastleSpritesTexID, spriteID);
			spriteWrapper.Scale = 1f;
			spriteWrapper.Visible = true;
			spriteWrapper.ColorToUse = global::ARGBColors.White;
			spriteWrapper.TroopType = 0;
			return spriteWrapper;
		}

		// Token: 0x0600092F RID: 2351 RVA: 0x000BDF58 File Offset: 0x000BC158
		public SpriteWrapper getNextExtraSprite(int textureID, int spriteNo)
		{
			SpriteWrapper spriteWrapper;
			if (this.nextExtraSpriteID >= CastleMap.castleExtraSprites.Count)
			{
				spriteWrapper = new SpriteWrapper();
				CastleMap.castleExtraSprites.Add(spriteWrapper);
			}
			else
			{
				spriteWrapper = CastleMap.castleExtraSprites[this.nextExtraSpriteID];
			}
			this.nextExtraSpriteID++;
			spriteWrapper.Initialize(this.castleMapRendering.gfx, textureID, spriteNo);
			spriteWrapper.Scale = 1f;
			spriteWrapper.Visible = true;
			spriteWrapper.ColorToUse = global::ARGBColors.White;
			spriteWrapper.TroopType = 0;
			return spriteWrapper;
		}

		// Token: 0x06000930 RID: 2352 RVA: 0x000BDFE4 File Offset: 0x000BC1E4
		public bool isInEastWestWall(int x, int y)
		{
			if (this.castleLayout != null)
			{
				if (x <= 0 || x >= 116)
				{
					return false;
				}
				if (this.castleLayout.map[x + 1, y] == 34 && this.castleLayout.map[x - 1, y] == 34)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000931 RID: 2353 RVA: 0x000BE038 File Offset: 0x000BC238
		public bool isInNorthSouthWall(int x, int y)
		{
			if (this.castleLayout != null)
			{
				if (y <= 0 || y >= 116)
				{
					return false;
				}
				if (this.castleLayout.map[x, y + 1] == 34 && this.castleLayout.map[x, y - 1] == 34)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000932 RID: 2354 RVA: 0x0000D50D File Offset: 0x0000B70D
		public bool isEastEndWall(int x, int y)
		{
			if (this.castleLayout != null)
			{
				if (x >= 116)
				{
					return false;
				}
				if (this.castleLayout.map[x + 1, y] == 34)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000933 RID: 2355 RVA: 0x0000D539 File Offset: 0x0000B739
		public bool isSouthEndWall(int x, int y)
		{
			if (this.castleLayout != null)
			{
				if (y >= 116)
				{
					return false;
				}
				if (this.castleLayout.map[x, y + 1] == 34)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000934 RID: 2356 RVA: 0x000BE08C File Offset: 0x000BC28C
		public void moveTroopLocal(CastleElement element, Point originalPosition)
		{
			if (element.elementID >= 0L && !this.movedElements.Contains(element))
			{
				CastleElement castleElement = new CastleElement();
				castleElement.elementID = element.elementID;
				castleElement.xPos = (byte)originalPosition.X;
				castleElement.yPos = (byte)originalPosition.Y;
				this.movedElementsOriginal.Add(castleElement);
				this.movedElements.Add(element);
			}
		}

		// Token: 0x06000935 RID: 2357 RVA: 0x000BE0F8 File Offset: 0x000BC2F8
		public void cancelBuilderMode()
		{
			this.cancelPendingDeletes();
			if (this.inBuilderMode)
			{
				List<CastleElement> list = new List<CastleElement>();
				foreach (CastleElement castleElement in this.elements)
				{
					if (castleElement.elementID < -1L)
					{
						list.Add(castleElement);
					}
				}
				foreach (CastleElement item in list)
				{
					this.elements.Remove(item);
				}
				if (this.removedElements != null)
				{
					this.elements.AddRange(this.removedElements);
					this.removedElements.Clear();
				}
				this.inBuilderMode = false;
				if (GameEngine.Instance.World.getTutorialStage() == 11)
				{
					this.tutorialAutoPlace();
					this.tutorialAutoPlace();
				}
				this.updateLayoutAndRedraw();
			}
			if (!this.InTroopPlacerMode)
			{
				return;
			}
			List<CastleElement> list2 = new List<CastleElement>();
			VillageMap village = GameEngine.Instance.Village;
			if (village != null)
			{
				foreach (CastleElement castleElement2 in this.elements)
				{
					if (castleElement2.elementID < -1L)
					{
						list2.Add(castleElement2);
						byte elementType = castleElement2.elementType;
						switch (elementType)
						{
						case 70:
							if (!castleElement2.reinforcement && !castleElement2.vassalReinforcements)
							{
								village.addTroops(1, 0, 0, 0, 0);
							}
							else if (!castleElement2.vassalReinforcements)
							{
								this.numPlacedReinforceDefenderPeasants--;
							}
							else
							{
								village.addVassalTroops(1, 0, 0, 0);
							}
							break;
						case 71:
							if (!castleElement2.reinforcement && !castleElement2.vassalReinforcements)
							{
								village.addTroops(0, 0, 0, 1, 0);
							}
							else if (!castleElement2.vassalReinforcements)
							{
								this.numPlacedReinforceDefenderSwordsmen--;
							}
							else
							{
								village.addVassalTroops(0, 0, 0, 1);
							}
							break;
						case 72:
							if (!castleElement2.reinforcement && !castleElement2.vassalReinforcements)
							{
								village.addTroops(0, 1, 0, 0, 0);
							}
							else if (!castleElement2.vassalReinforcements)
							{
								this.numPlacedReinforceDefenderArchers--;
							}
							else
							{
								village.addVassalTroops(0, 1, 0, 0);
							}
							break;
						case 73:
							if (!castleElement2.reinforcement && !castleElement2.vassalReinforcements)
							{
								village.addTroops(0, 0, 1, 0, 0);
							}
							else if (!castleElement2.vassalReinforcements)
							{
								this.numPlacedReinforceDefenderPikemen--;
							}
							else
							{
								village.addVassalTroops(0, 0, 1, 0);
							}
							break;
						default:
							if (elementType == 85)
							{
								village.addTroops(0, 0, 0, 0, 0, 0, 1);
							}
							break;
						}
					}
				}
			}
			foreach (CastleElement item2 in list2)
			{
				this.elements.Remove(item2);
			}
			if (this.removedElements != null)
			{
				if (village != null)
				{
					foreach (CastleElement castleElement3 in this.removedElements)
					{
						byte elementType2 = castleElement3.elementType;
						switch (elementType2)
						{
						case 70:
							village.addTroops(-1, 0, 0, 0, 0);
							break;
						case 71:
							village.addTroops(0, 0, 0, -1, 0);
							break;
						case 72:
							village.addTroops(0, -1, 0, 0, 0);
							break;
						case 73:
							village.addTroops(0, 0, -1, 0, 0);
							break;
						default:
							if (elementType2 == 85)
							{
								village.addTroops(0, 0, 0, 0, 0, 0, -1);
							}
							break;
						}
					}
				}
				this.elements.AddRange(this.removedElements);
				this.removedElements.Clear();
			}
			CastlesCommon.buildCastleLayoutClient(this.elements, ref this.castleLayout);
			if (this.movedElementsOriginal != null)
			{
				foreach (CastleElement castleElement4 in this.movedElementsOriginal)
				{
					CastleElement elementFromElemID = this.castleLayout.getElementFromElemID(castleElement4.elementID);
					elementFromElemID.xPos = castleElement4.xPos;
					elementFromElemID.yPos = castleElement4.yPos;
				}
			}
			this.inTroopPlacerMode = false;
			if (village != null)
			{
				this.numAvailableDefenderPeasants = 0;
				this.numAvailableDefenderArchers = 0;
				this.numAvailableDefenderPikemen = 0;
				this.numAvailableDefenderSwordsmen = 0;
				this.numAvailableDefenderCaptains = 0;
				this.numAvailableDefenderCaptains = 0;
				village.getVillageTroops(ref this.numAvailableDefenderPeasants, ref this.numAvailableDefenderArchers, ref this.numAvailableDefenderPikemen, ref this.numAvailableDefenderSwordsmen, ref this.numAvailableDefenderCaptains);
				GameEngine.Instance.World.getReinforceTotals(village.VillageID, ref this.numAvailableReinforceDefenderPeasants, ref this.numAvailableReinforceDefenderArchers, ref this.numAvailableReinforceDefenderPikemen, ref this.numAvailableReinforceDefenderSwordsmen);
				village.getVillageVassalTroops(ref this.numAvailableVassalReinforceDefenderPeasants, ref this.numAvailableVassalReinforceDefenderArchers, ref this.numAvailableVassalReinforceDefenderPikemen, ref this.numAvailableVassalReinforceDefenderSwordsmen);
			}
			this.clearLasso();
			this.updateLayoutAndRedraw();
		}

		// Token: 0x06000936 RID: 2358 RVA: 0x000BE67C File Offset: 0x000BC87C
		private int correctPlacementType(int placementType)
		{
			int num = placementType;
			if (num != 65)
			{
				if (num == 66)
				{
					num = 33;
				}
			}
			else
			{
				num = 34;
			}
			return num;
		}

		// Token: 0x06000937 RID: 2359 RVA: 0x0000D565 File Offset: 0x0000B765
		public bool isInsideDefenderArea(Point mapTile)
		{
			return mapTile.X >= 33 && mapTile.X < 85 && mapTile.Y >= 33 && mapTile.Y < 85;
		}

		// Token: 0x06000938 RID: 2360 RVA: 0x000BE6A0 File Offset: 0x000BC8A0
		private Rectangle fitRectangleToAttackerArea(Rectangle rect, CastleMap.TroopFacingDirection direction, bool isCatapult)
		{
			switch (direction)
			{
			case CastleMap.TroopFacingDirection.LOOKING_SOUTHEAST:
				rect.Y = Math.Min(rect.Top, 33 - rect.Height);
				break;
			case CastleMap.TroopFacingDirection.LOOKING_SOUTHWEST:
				if (isCatapult)
				{
					rect.X = Math.Max(rect.Left, 86);
				}
				else
				{
					rect.X = Math.Max(rect.Left, 85);
				}
				break;
			case CastleMap.TroopFacingDirection.LOOKING_NORTHEAST:
				if (isCatapult)
				{
					rect.X = Math.Min(rect.Left, 33 - rect.Width + 1);
				}
				else
				{
					rect.X = Math.Min(rect.Left, 33 - rect.Width);
				}
				break;
			case CastleMap.TroopFacingDirection.LOOKING_NORTHWEST:
				if (isCatapult)
				{
					rect.Y = Math.Max(rect.Top, 86);
				}
				else
				{
					rect.Y = Math.Max(rect.Top, 85);
				}
				break;
			}
			return rect;
		}

		// Token: 0x06000939 RID: 2361 RVA: 0x000BE790 File Offset: 0x000BC990
		private Rectangle fitRectangleToDefenderArea(Rectangle rect, CastleMap.TroopFacingDirection direction)
		{
			switch (direction)
			{
			case CastleMap.TroopFacingDirection.LOOKING_SOUTHEAST:
				rect.Y = Math.Min(rect.Top, 85 - rect.Height);
				break;
			case CastleMap.TroopFacingDirection.LOOKING_SOUTHWEST:
				rect.X = Math.Max(rect.Left, 33);
				break;
			case CastleMap.TroopFacingDirection.LOOKING_NORTHEAST:
				rect.X = Math.Min(rect.Left, 85 - rect.Width);
				break;
			case CastleMap.TroopFacingDirection.LOOKING_NORTHWEST:
				rect.Y = Math.Max(rect.Top, 33);
				break;
			}
			return rect;
		}

		// Token: 0x0600093A RID: 2362 RVA: 0x000BE824 File Offset: 0x000BCA24
		public void commitCastle(bool backGround = false)
		{
			InterfaceMgr.Instance.WaitingForCallback = true;
			int num = 0;
			foreach (CastleElement castleElement in this.elements)
			{
				if (castleElement.elementID < -1L)
				{
					num++;
				}
			}
			if (num >= 0)
			{
				List<long> list = new List<long>();
				if (this.inTroopPlacerMode)
				{
					foreach (CastleElement castleElement2 in this.removedElements)
					{
						if (castleElement2.elementID >= 0L)
						{
							list.Add(castleElement2.elementID);
						}
					}
				}
				byte[,] array = new byte[num, 4];
				int num2 = 0;
				foreach (CastleElement castleElement3 in this.elements)
				{
					if (castleElement3.elementID < -1L)
					{
						if (castleElement3.aggressiveDefender && (castleElement3.elementType == 70 || castleElement3.elementType == 73 || castleElement3.elementType == 71))
						{
							switch (castleElement3.elementType)
							{
							case 70:
								array[num2, 0] = 80;
								break;
							case 71:
								array[num2, 0] = 81;
								break;
							case 73:
								array[num2, 0] = 82;
								break;
							}
						}
						else if (castleElement3.elementType == 71 && castleElement3.aggressiveDefender)
						{
							array[num2, 0] = 83;
						}
						else
						{
							array[num2, 0] = castleElement3.elementType;
						}
						array[num2, 1] = castleElement3.xPos;
						array[num2, 2] = castleElement3.yPos;
						array[num2, 3] = 0;
						if (castleElement3.reinforcement)
						{
							byte ptr = array[num2, 3];
							ptr |= 1;
							array[num2, 3] = ptr;
						}
						if (castleElement3.vassalReinforcements)
						{
							byte ptr2 = array[num2, 3];
							ptr2 |= 2;
							array[num2, 3] = ptr2;
						}
						num2++;
					}
				}
				if (this.removedElements != null)
				{
					this.removedElements.Clear();
				}
				if (this.movedElementsOriginal != null)
				{
					this.movedElementsOriginal.Clear();
				}
				RemoteServices.Instance.set_AddCastleElement_UserCallBack(new RemoteServices.AddCastleElement_UserCallBack(this.newElementCallback));
				if (list.Count == 0 && (this.movedElements == null || this.movedElements.Count == 0))
				{
					RemoteServices.Instance.AddCastleElementList(this.m_villageID, array);
				}
				else
				{
					List<MoveElementData> list2 = new List<MoveElementData>();
					if (this.movedElements != null)
					{
						foreach (CastleElement castleElement4 in this.movedElements)
						{
							list2.Add(new MoveElementData
							{
								elementID = castleElement4.elementID,
								xPos = castleElement4.xPos,
								yPos = castleElement4.yPos
							});
						}
					}
					RemoteServices.Instance.AddCastleElementList(this.m_villageID, array, list.ToArray(), list2.ToArray());
				}
				this.closeCommitPopup();
				this.commitPopup = new CastleCommitPopup();
				if (!backGround)
				{
					this.commitPopup.Show();
				}
			}
			this.clearLasso();
			this.stopPlaceElement();
		}

		// Token: 0x0600093B RID: 2363 RVA: 0x0000D595 File Offset: 0x0000B795
		public void closeCommitPopup()
		{
			if (this.commitPopup != null)
			{
				this.commitPopup.Close();
				this.commitPopup = null;
			}
		}

		// Token: 0x0600093C RID: 2364 RVA: 0x000BEBD4 File Offset: 0x000BCDD4
		public void newElementCallback(AddCastleElement_ReturnType returnData)
		{
			InterfaceMgr.Instance.castleCommitReturn();
			this.closeCommitPopup();
			if (returnData.villageID != this.m_villageID)
			{
				return;
			}
			if (returnData.list)
			{
				this.newElementListCallback(returnData);
				this.manageTutorial();
				return;
			}
			if (returnData.element == null)
			{
				this.waitingForWallReturn = false;
				this.clearPlacementWallSprites();
			}
			if (returnData.clientElementNumber < 0L)
			{
				foreach (CastleElement castleElement in this.elements)
				{
					if (castleElement.elementID == returnData.clientElementNumber)
					{
						this.elements.Remove(castleElement);
						break;
					}
				}
			}
			bool flag = true;
			if (returnData.Success)
			{
				GameEngine.Instance.World.setGoldData(returnData.currentGoldLevel, returnData.currentGoldRate);
				CastleMap.setServerTime(returnData.currentTime);
				if (returnData.element != null)
				{
					if (returnData.element.elementType == 43)
					{
						List<CastleElement> list = new List<CastleElement>();
						foreach (CastleElement castleElement2 in this.elements)
						{
							if (castleElement2.elementType == 43)
							{
								list.Add(castleElement2);
							}
						}
						foreach (CastleElement item in list)
						{
							this.elements.Remove(item);
						}
					}
					this.elements.Add(returnData.element);
				}
				if (returnData.elements != null)
				{
					this.importElements(returnData.elements);
					flag = false;
				}
				if (returnData.villageResourcesAndStats != null && GameEngine.Instance.Village != null)
				{
					GameEngine.Instance.Village.importResourcesAndStats(returnData.villageResourcesAndStats, returnData.currentTime);
					VillageMap village = GameEngine.Instance.Village;
					if (village != null)
					{
						this.numAvailableDefenderPeasants = 0;
						this.numAvailableDefenderArchers = 0;
						this.numAvailableDefenderPikemen = 0;
						this.numAvailableDefenderSwordsmen = 0;
						this.numAvailableDefenderCaptains = 0;
						village.getVillageTroops(ref this.numAvailableDefenderPeasants, ref this.numAvailableDefenderArchers, ref this.numAvailableDefenderPikemen, ref this.numAvailableDefenderSwordsmen, ref this.numAvailableDefenderCaptains);
						GameEngine.Instance.World.getReinforceTotals(village.VillageID, ref this.numAvailableReinforceDefenderPeasants, ref this.numAvailableReinforceDefenderArchers, ref this.numAvailableReinforceDefenderPikemen, ref this.numAvailableReinforceDefenderSwordsmen);
						village.getVillageVassalTroops(ref this.numAvailableVassalReinforceDefenderPeasants, ref this.numAvailableVassalReinforceDefenderArchers, ref this.numAvailableVassalReinforceDefenderPikemen, ref this.numAvailableVassalReinforceDefenderSwordsmen);
					}
				}
			}
			else
			{
				foreach (CastleElement castleElement3 in this.elements)
				{
					if (castleElement3.elementID == returnData.clientElementNumber)
					{
						this.elements.Remove(castleElement3);
						break;
					}
				}
				VillageMap village2 = GameEngine.Instance.Village;
				if (village2 != null)
				{
					byte elementType = returnData.elementType;
					switch (elementType)
					{
					case 70:
						village2.addTroops(1, 0, 0, 0, 0);
						break;
					case 71:
						village2.addTroops(0, 0, 0, 1, 0);
						break;
					case 72:
						village2.addTroops(0, 1, 0, 0, 0);
						break;
					case 73:
						village2.addTroops(0, 0, 1, 0, 0);
						break;
					default:
						if (elementType == 85)
						{
							village2.addTroops(0, 0, 0, 0, 0, 0, 1);
						}
						break;
					}
					this.numAvailableDefenderPeasants = 0;
					this.numAvailableDefenderArchers = 0;
					this.numAvailableDefenderPikemen = 0;
					this.numAvailableDefenderSwordsmen = 0;
					this.numAvailableDefenderCaptains = 0;
					village2.getVillageTroops(ref this.numAvailableDefenderPeasants, ref this.numAvailableDefenderArchers, ref this.numAvailableDefenderPikemen, ref this.numAvailableDefenderSwordsmen, ref this.numAvailableDefenderCaptains);
					GameEngine.Instance.World.getReinforceTotals(village2.VillageID, ref this.numAvailableReinforceDefenderPeasants, ref this.numAvailableReinforceDefenderArchers, ref this.numAvailableReinforceDefenderPikemen, ref this.numAvailableReinforceDefenderSwordsmen);
					village2.getVillageVassalTroops(ref this.numAvailableVassalReinforceDefenderPeasants, ref this.numAvailableVassalReinforceDefenderArchers, ref this.numAvailableVassalReinforceDefenderPikemen, ref this.numAvailableVassalReinforceDefenderSwordsmen);
				}
			}
			if (flag)
			{
				this.updateLayoutAndRedraw();
			}
			InterfaceMgr.Instance.refreshCastleInterface();
			this.manageTutorial();
		}

		// Token: 0x0600093D RID: 2365 RVA: 0x000BF014 File Offset: 0x000BD214
		public void newElementListCallback(AddCastleElement_ReturnType returnData)
		{
			if (returnData.villageResourcesAndStats != null && GameEngine.Instance.Village != null)
			{
				GameEngine.Instance.Village.importResourcesAndStats(returnData.villageResourcesAndStats, returnData.currentTime);
				VillageMap village = GameEngine.Instance.Village;
				if (village != null)
				{
					this.numAvailableDefenderPeasants = 0;
					this.numAvailableDefenderArchers = 0;
					this.numAvailableDefenderPikemen = 0;
					this.numAvailableDefenderSwordsmen = 0;
					this.numAvailableDefenderCaptains = 0;
					village.getVillageTroops(ref this.numAvailableDefenderPeasants, ref this.numAvailableDefenderArchers, ref this.numAvailableDefenderPikemen, ref this.numAvailableDefenderSwordsmen, ref this.numAvailableDefenderCaptains);
					GameEngine.Instance.World.getReinforceTotals(village.VillageID, ref this.numAvailableReinforceDefenderPeasants, ref this.numAvailableReinforceDefenderArchers, ref this.numAvailableReinforceDefenderPikemen, ref this.numAvailableReinforceDefenderSwordsmen);
					village.getVillageVassalTroops(ref this.numAvailableVassalReinforceDefenderPeasants, ref this.numAvailableVassalReinforceDefenderArchers, ref this.numAvailableVassalReinforceDefenderPikemen, ref this.numAvailableVassalReinforceDefenderSwordsmen);
				}
			}
			if (returnData.Success)
			{
				if (returnData.elements != null)
				{
					this.inBuilderMode = false;
					this.inTroopPlacerMode = false;
					this.importElements(returnData.elements);
					InterfaceMgr.Instance.castleEndBuilderMode();
				}
			}
			else
			{
				MyMessageBox.Show(ErrorCodes.getErrorString(returnData.m_errorCode, returnData.m_errorID), SK.Text("CastleMap_Placement_Error", "Castle Placement Error"));
			}
			GameEngine.Instance.World.setGoldData(returnData.currentGoldLevel, returnData.currentGoldRate);
			CastleMap.setServerTime(returnData.currentTime);
		}

		// Token: 0x0600093E RID: 2366 RVA: 0x000BF17C File Offset: 0x000BD37C
		public void manageTutorial()
		{
			if (this.m_castleEnclosed && !GameEngine.Instance.World.TutorialIsAdvancing())
			{
				int tutorialStage = GameEngine.Instance.World.getTutorialStage();
				if (tutorialStage == 11)
				{
					GameEngine.Instance.World.forceTutorialToBeShown();
				}
			}
		}

		// Token: 0x0600093F RID: 2367 RVA: 0x000BF1C8 File Offset: 0x000BD3C8
		public void DeleteElementCallback(DeleteCastleElement_ReturnType returnData)
		{
			this.deletingElements.Clear();
			this.inDeleteConstructing = false;
			if (this.inDeleting)
			{
				this.inDeleting = false;
				CursorManager.SetCursor(CursorManager.CursorType.Cross, InterfaceMgr.Instance.ParentForm);
			}
			if (returnData.Success)
			{
				CastleMap.setServerTime(returnData.currentTime);
				GameEngine.Instance.World.setGoldData(returnData.currentGoldLevel, returnData.currentGoldRate);
				if (returnData.villageResourcesAndStats != null && GameEngine.Instance.Village != null)
				{
					GameEngine.Instance.Village.importResourcesAndStats(returnData.villageResourcesAndStats, returnData.currentTime);
					VillageMap village = GameEngine.Instance.Village;
					if (village != null)
					{
						this.numAvailableDefenderPeasants = 0;
						this.numAvailableDefenderArchers = 0;
						this.numAvailableDefenderPikemen = 0;
						this.numAvailableDefenderSwordsmen = 0;
						this.numAvailableDefenderCaptains = 0;
						village.getVillageTroops(ref this.numAvailableDefenderPeasants, ref this.numAvailableDefenderArchers, ref this.numAvailableDefenderPikemen, ref this.numAvailableDefenderSwordsmen, ref this.numAvailableDefenderCaptains);
						GameEngine.Instance.World.getReinforceTotals(village.VillageID, ref this.numAvailableReinforceDefenderPeasants, ref this.numAvailableReinforceDefenderArchers, ref this.numAvailableReinforceDefenderPikemen, ref this.numAvailableReinforceDefenderSwordsmen);
						village.getVillageVassalTroops(ref this.numAvailableVassalReinforceDefenderPeasants, ref this.numAvailableVassalReinforceDefenderArchers, ref this.numAvailableVassalReinforceDefenderPikemen, ref this.numAvailableVassalReinforceDefenderSwordsmen);
					}
				}
				if (returnData.elements != null)
				{
					this.importElements(returnData.elements);
				}
				InterfaceMgr.Instance.refreshCastleInterface();
				return;
			}
			MyMessageBox.Show(ErrorCodes.getErrorString(returnData.m_errorCode, returnData.m_errorID), SK.Text("CastleMap_Placement_Error", "Castle Placement Error"));
		}

		// Token: 0x06000940 RID: 2368 RVA: 0x000BF354 File Offset: 0x000BD554
		public void AutoRepairCastleCallback(AutoRepairCastle_ReturnType returnData)
		{
			if (!returnData.Success)
			{
				return;
			}
			CastleMap.setServerTime(returnData.currentTime);
			if (returnData.villageResourcesAndStats != null && GameEngine.Instance.Village != null)
			{
				GameEngine.Instance.Village.importResourcesAndStats(returnData.villageResourcesAndStats, returnData.currentTime);
				VillageMap village = GameEngine.Instance.Village;
				if (village != null)
				{
					this.numAvailableDefenderPeasants = 0;
					this.numAvailableDefenderArchers = 0;
					this.numAvailableDefenderPikemen = 0;
					this.numAvailableDefenderSwordsmen = 0;
					this.numAvailableDefenderCaptains = 0;
					village.getVillageTroops(ref this.numAvailableDefenderPeasants, ref this.numAvailableDefenderArchers, ref this.numAvailableDefenderPikemen, ref this.numAvailableDefenderSwordsmen, ref this.numAvailableDefenderCaptains);
					GameEngine.Instance.World.getReinforceTotals(village.VillageID, ref this.numAvailableReinforceDefenderPeasants, ref this.numAvailableReinforceDefenderArchers, ref this.numAvailableReinforceDefenderPikemen, ref this.numAvailableReinforceDefenderSwordsmen);
					village.getVillageVassalTroops(ref this.numAvailableVassalReinforceDefenderPeasants, ref this.numAvailableVassalReinforceDefenderArchers, ref this.numAvailableVassalReinforceDefenderPikemen, ref this.numAvailableVassalReinforceDefenderSwordsmen);
				}
			}
			if (returnData.elements != null)
			{
				this.importElements(returnData.elements);
			}
		}

		// Token: 0x06000941 RID: 2369 RVA: 0x0000D5B1 File Offset: 0x0000B7B1
		public void moveMap(int dx, int dy)
		{
			this.Camera.Drag(new Point(dx, dy));
		}

		// Token: 0x06000942 RID: 2370 RVA: 0x000BF464 File Offset: 0x000BD664
		public void mouseWheel()
		{
			if (this.placingElement)
			{
				bool flag = false;
				if (this.placementType == 40)
				{
					flag = true;
					this.placementType = 39;
				}
				else if (this.placementType == 39)
				{
					flag = true;
					this.placementType = 40;
				}
				if (this.placementType == 38)
				{
					flag = true;
					this.placementType = 37;
				}
				else if (this.placementType == 37)
				{
					flag = true;
					this.placementType = 38;
				}
				if (flag)
				{
					this.startPlaceElement(this.placementType);
				}
			}
		}

		// Token: 0x06000943 RID: 2371 RVA: 0x000BF4E0 File Offset: 0x000BD6E0
		public bool commonMouseClicked(Point mousePos)
		{
			bool flag = true;
			if (!GameEngine.Instance.World.isCapital(this.m_villageID))
			{
				flag = false;
				if (InterfaceMgr.Instance.clickDXCardBar(mousePos))
				{
					return true;
				}
				if (GameEngine.Instance.World.isTutorialActive() && mousePos.X < 64 && mousePos.Y >= this.castleMapRendering.gfx.ViewportHeight - 64)
				{
					GameEngine.Instance.World.forceTutorialToBeShown();
					return true;
				}
			}
			if (!this.attackerSetupMode && mousePos.X > this.castleMapRendering.gfx.ViewportWidth - 32 && (float)mousePos.Y < 32f + CastleMap.wikiHelpSprite.PosY && (float)mousePos.Y > CastleMap.wikiHelpSprite.PosY)
			{
				if (!flag)
				{
					CustomSelfDrawPanel.WikiLinkControl.openHelpLink(2);
				}
				else
				{
					CustomSelfDrawPanel.WikiLinkControl.openHelpLink(10);
				}
				return true;
			}
			return false;
		}

		// Token: 0x06000944 RID: 2372 RVA: 0x000BF5C8 File Offset: 0x000BD7C8
		private void confirmCatapultPlacement(int facing, int mapX, int mapY)
		{
			int num = 1;
			if (this.CurrentBrushSize == CastleMap.BrushSize.BRUSH_3X3)
			{
				num = 2;
			}
			else if (this.CurrentBrushSize == CastleMap.BrushSize.BRUSH_5X5)
			{
				num = 4;
			}
			else if (this.CurrentBrushSize == CastleMap.BrushSize.BRUSH_1X5)
			{
				if (facing == 0 || facing == 4)
				{
					int num2 = 0;
					num = 4;
					for (int i = mapX - num; i <= mapX + num; i += 2)
					{
						if (this.mouseMovePlaceTroops(i, mapY, true, num2))
						{
							this.troopPlaceAttacker(i, mapY);
						}
						num2++;
					}
					return;
				}
				int num3 = 0;
				num = 4;
				for (int j = mapY - num; j <= mapY + num; j += 2)
				{
					if (this.mouseMovePlaceTroops(mapX, j, true, num3))
					{
						this.troopPlaceAttacker(mapX, j);
					}
					num3++;
				}
				return;
			}
			if (facing == 0 || facing == 4)
			{
				int num4 = 0;
				for (int k = mapX - num; k <= mapX + num; k += 2)
				{
					if (this.mouseMovePlaceTroops(k, mapY, true, num4))
					{
						this.troopPlaceAttacker(k, mapY);
					}
					num4++;
				}
				return;
			}
			int num5 = 0;
			for (int l = mapY - num; l <= mapY + num; l += 2)
			{
				if (this.mouseMovePlaceTroops(mapX, l, true, num5))
				{
					this.troopPlaceAttacker(mapX, l);
				}
				num5++;
			}
		}

		// Token: 0x06000945 RID: 2373 RVA: 0x000BF6DC File Offset: 0x000BD8DC
		public void confirmTroopPlacement(int mapX, int mapY)
		{
			int num = (mapX < mapY) ? ((117 - mapX >= mapY) ? 2 : 0) : ((117 - mapX >= mapY) ? 4 : 6);
			if (this.CurrentBrushSize == CastleMap.BrushSize.BRUSH_1X1)
			{
				if (this.mouseMovePlaceTroops(mapX, mapY, true, 0))
				{
					if (this.placingDefender)
					{
						this.troopPlaceDefender(mapX, mapY);
						return;
					}
					this.troopPlaceAttacker(mapX, mapY);
				}
				return;
			}
			if (this.placementType == 94)
			{
				this.confirmCatapultPlacement(num, mapX, mapY);
				return;
			}
			if (this.CurrentBrushSize != CastleMap.BrushSize.BRUSH_1X5)
			{
				int num2 = 0;
				int num3 = 0;
				if (this.CurrentBrushSize == CastleMap.BrushSize.BRUSH_3X3)
				{
					num3 = 1;
				}
				else if (this.CurrentBrushSize == CastleMap.BrushSize.BRUSH_5X5)
				{
					num3 = 2;
				}
				for (int i = mapY - num3; i <= mapY + num3; i++)
				{
					for (int j = mapX - num3; j <= mapX + num3; j++)
					{
						if (this.mouseMovePlaceTroops(j, i, true, num2))
						{
							if (this.placingDefender)
							{
								this.troopPlaceDefender(j, i);
							}
							else
							{
								this.troopPlaceAttacker(j, i);
							}
						}
						num2++;
					}
				}
				return;
			}
			if (num == 0 || num == 4)
			{
				int num4 = 0;
				int num5 = 2;
				for (int k = mapX - num5; k <= mapX + num5; k++)
				{
					if (this.mouseMovePlaceTroops(k, mapY, true, num4))
					{
						if (this.placingDefender)
						{
							this.troopPlaceDefender(k, mapY);
						}
						else
						{
							this.troopPlaceAttacker(k, mapY);
						}
					}
					num4++;
				}
				return;
			}
			int num6 = 0;
			int num7 = 2;
			for (int l = mapY - num7; l <= mapY + num7; l++)
			{
				if (this.mouseMovePlaceTroops(mapX, l, true, num6))
				{
					if (this.placingDefender)
					{
						this.troopPlaceDefender(mapX, l);
					}
					else
					{
						this.troopPlaceAttacker(mapX, l);
					}
				}
				num6++;
			}
		}

		// Token: 0x06000946 RID: 2374 RVA: 0x000BF870 File Offset: 0x000BDA70
		public void mouseClicked(Point mousePos)
		{
			if (this.castleMapRendering.backgroundSprite == null)
			{
				return;
			}
			if (this.m_lassoMade && !GameEngine.shiftPressed)
			{
				Point mousePos2 = this.Camera.ScreenToWorldSpace(mousePos);
				long num = this.clickFindTroop(mousePos2);
				if (this.m_lassoElements.Count == 1 && this.m_lassoElements[0] == num && (DateTime.Now - this.troopSelectDoubleClickTIme).TotalMilliseconds < 500.0)
				{
					foreach (CastleElement castleElement in this.elements)
					{
						if (castleElement != null && castleElement.elementID == num)
						{
							using (List<CastleElement>.Enumerator enumerator2 = this.elements.GetEnumerator())
							{
								while (enumerator2.MoveNext())
								{
									CastleElement castleElement2 = enumerator2.Current;
									if (castleElement2 != castleElement && castleElement2.elementType == castleElement.elementType && (!this.attackerSetupMode || castleElement2.elementID < -2L))
									{
										this.m_lassoElements.Add(castleElement2.elementID);
									}
								}
								break;
							}
						}
					}
					this.lassoMade();
					this.recalcCastleLayout();
					return;
				}
				this.clearLasso();
			}
			Point mapTile = this.Camera.ScreenSpaceToMapTile(mousePos);
			if (this.troopMovingMode)
			{
				return;
			}
			if (this.deleting)
			{
				if (!this.isValidMapTile(mapTile) || this.castleLayout == null || this.castleLayout.map[mapTile.X, mapTile.Y] == 0)
				{
					return;
				}
				long num2 = this.castleLayout.elemMap[mapTile.X, mapTile.Y];
				if (!CastleMap.CreateMode && !this.inBuilderMode)
				{
					int num3 = (int)this.castleLayout.map[mapTile.X, mapTile.Y];
					if (num3 == 51 || num3 == 52 || num3 == 53 || num3 == 54 || num3 == 55 || num3 == 56 || num3 == 57 || num2 < 0L || GameEngine.Instance.World.WorldEnded)
					{
						return;
					}
					if (this.inDeleting && (DateTime.Now - this.lastDeleteTime).TotalSeconds > 8.0)
					{
						this.inDeleting = false;
					}
					if (this.inDeleting)
					{
						return;
					}
					GameEngine.Instance.playInterfaceSound("CastleMap_delete");
					CursorManager.SetCursor(CursorManager.CursorType.WaitCursor, InterfaceMgr.Instance.ParentForm);
					this.inDeleting = true;
					this.lastDeleteTime = DateTime.Now;
					RemoteServices.Instance.set_DeleteCastleElement_UserCallBack(new RemoteServices.DeleteCastleElement_UserCallBack(this.DeleteElementCallback));
					RemoteServices.Instance.DeleteCastleElement(this.m_villageID, num2);
					using (List<CastleElement>.Enumerator enumerator3 = this.elements.GetEnumerator())
					{
						while (enumerator3.MoveNext())
						{
							CastleElement castleElement3 = enumerator3.Current;
							if (castleElement3.elementID == num2)
							{
								this.elements.Remove(castleElement3);
								this.updateLayoutAndRedraw();
								break;
							}
						}
						return;
					}
				}
				if (num2 >= -1L && !CastleMap.CreateMode)
				{
					return;
				}
				using (List<CastleElement>.Enumerator enumerator4 = this.elements.GetEnumerator())
				{
					while (enumerator4.MoveNext())
					{
						CastleElement castleElement4 = enumerator4.Current;
						if (castleElement4 != null && castleElement4.elementID == num2)
						{
							this.elements.Remove(castleElement4);
							this.updateLayoutAndRedraw();
							InterfaceMgr.Instance.castleStartBuilderMode();
							break;
						}
					}
					return;
				}
			}
			if (CastleMap.buildingPlacementSprite != null && this.placingElement)
			{
				if (this.placementType != 34 && this.placementType != 33 && this.placementType != 65 && this.placementType != 66 && this.placementType != 36 && this.placementType != 35 && this.isValidMapTile(mapTile))
				{
					this.placeBuildingElement(mapTile.X, mapTile.Y);
					return;
				}
			}
			else
			{
				if (this.inBuilderMode && !CastleMap.CreateMode)
				{
					return;
				}
				if (CastleMap.placementTroopSprite[0] != null && !this.placingElement)
				{
					if (this.isValidMapTile(mapTile))
					{
						this.stopPlacementOnTroopModeSwap = false;
						this.confirmTroopPlacement(mapTile.X, mapTile.Y);
						this.updateLayoutAndRedraw();
						if (this.stopPlacementOnTroopModeSwap)
						{
							this.stopPlaceElement();
							return;
						}
					}
				}
				else
				{
					if (this.attackerSetupMode && this.isValidMapTile(mapTile) && (!this.m_lassoMade || GameEngine.shiftPressed) && this.selectCatapult(mapTile.X, mapTile.Y))
					{
						this.troopSelectDoubleClickTIme = DateTime.Now;
						return;
					}
					if (this.battleMode || this.draggingWall)
					{
						return;
					}
					Point mousePos3 = this.Camera.ScreenToWorldSpace(mousePos);
					long num4 = this.clickFindTroop(mousePos3);
					if (num4 == -2L || (this.attackerSetupMode && num4 >= -2L))
					{
						return;
					}
					if (this.m_lassoMade && GameEngine.shiftPressed)
					{
						if (!this.m_lassoElements.Contains(num4))
						{
							this.m_lassoElements.Add(num4);
							this.lassoMade();
						}
					}
					else
					{
						this.troopSelectDoubleClickTIme = DateTime.Now;
						this.clearLasso();
						this.m_lassoMade = true;
						this.m_lassoElements.Add(num4);
						this.lassoMade();
					}
					this.recalcCastleLayout();
				}
			}
		}

		// Token: 0x06000947 RID: 2375 RVA: 0x0000D5C5 File Offset: 0x0000B7C5
		public CastleElement placeBuildingElement(int mapX, int mapY)
		{
			return this.placeBuildingElement(mapX, mapY, false);
		}

		// Token: 0x06000948 RID: 2376 RVA: 0x0000D5D0 File Offset: 0x0000B7D0
		public CastleElement placeBuildingElement(int mapX, int mapY, bool fastMode)
		{
			return this.placeBuildingElement(mapX, mapY, fastMode, true);
		}

		// Token: 0x06000949 RID: 2377 RVA: 0x000BFE24 File Offset: 0x000BE024
		public CastleElement placeBuildingElement(int mapX, int mapY, bool fastMode, bool playSound)
		{
			if (this.movePlaceElement(mapX, mapY, CastleMap.buildingPlacementSprite, false, true))
			{
				if (!this.inBuilderMode)
				{
					this.startBuilderMode();
				}
				if (this.placementType == 43)
				{
					foreach (CastleElement castleElement in this.elements)
					{
						if (castleElement.elementID < -1L && castleElement.elementType == 43)
						{
							this.elements.Remove(castleElement);
							break;
						}
					}
				}
				CastleElement castleElement2 = new CastleElement();
				castleElement2.elementID = this.localTempElementNumber;
				this.localTempElementNumber -= 1L;
				castleElement2.elementType = (byte)this.placementType;
				castleElement2.xPos = (byte)mapX;
				castleElement2.yPos = (byte)mapY;
				bool flag = false;
				int placementType = this.placementType;
				if (placementType - 11 > 3 && placementType != 21)
				{
					switch (placementType)
					{
					case 31:
					{
						flag = true;
						int num = this.countGuardHouses() + 1;
						int num2 = 400 / GameEngine.Instance.LocalWorldData.castle_troopsPerGuardHouse;
						num2 = (GameEngine.Instance.World.isCapital(this.m_villageID) ? (num2 - 5) : (num2 - 2));
						if (num >= num2)
						{
							this.stopPlaceElement();
							goto IL_1FF;
						}
						goto IL_1FF;
					}
					case 32:
					case 37:
					case 38:
					case 39:
					case 40:
						break;
					case 33:
					case 34:
					case 35:
					case 36:
					case 43:
						goto IL_1FF;
					case 41:
					{
						flag = true;
						int num3 = this.countTurrets() + 1;
						if (num3 >= (int)GameEngine.Instance.Village.m_parishCapitalResearchData.Research_CAP_Turrets)
						{
							this.stopPlaceElement();
							goto IL_1FF;
						}
						goto IL_1FF;
					}
					case 42:
					{
						flag = true;
						int num4 = this.countBallistas() + 1;
						if (num4 >= (int)GameEngine.Instance.Village.m_parishCapitalResearchData.Research_CAP_Ballista)
						{
							this.stopPlaceElement();
							goto IL_1FF;
						}
						goto IL_1FF;
					}
					case 44:
					{
						int num5 = this.countBombards() + 1;
						if (num5 >= (int)GameEngine.Instance.Village.m_parishCapitalResearchData.Research_Leadership)
						{
							this.stopPlaceElement();
							goto IL_1FF;
						}
						goto IL_1FF;
					}
					default:
						goto IL_1FF;
					}
				}
				flag = true;
				IL_1FF:
				if (flag)
				{
					List<long> underlyingWallElements = this.castleLayout.getUnderlyingWallElements(castleElement2);
					foreach (long num6 in underlyingWallElements)
					{
						foreach (CastleElement castleElement3 in this.elements)
						{
							if (castleElement3.elementID == num6)
							{
								this.elements.Remove(castleElement3);
								if (castleElement3.elementID >= 0L)
								{
									this.removedElements.Add(castleElement3);
									break;
								}
								break;
							}
						}
					}
				}
				if (playSound)
				{
					GameEngine.Instance.playInterfaceSound("CastleMap_place_building");
				}
				this.elements.Add(castleElement2);
				if (!fastMode)
				{
					this.updateLayoutAndRedraw();
					InterfaceMgr.Instance.castleStartBuilderMode();
				}
				return castleElement2;
			}
			return null;
		}

		// Token: 0x0600094A RID: 2378 RVA: 0x000C0134 File Offset: 0x000BE334
		public void startDrag(Point mousePos)
		{
			this.m_leftMouseHeldDown = true;
			this.m_baseMousePos = mousePos;
			this.m_previousMousePos = mousePos;
			this.m_baseScreenX = (double)this.castleMapRendering.backgroundSprite.PosX;
			this.m_baseScreenY = (double)this.castleMapRendering.backgroundSprite.PosY;
		}

		// Token: 0x0600094B RID: 2379 RVA: 0x0000D5DC File Offset: 0x0000B7DC
		public void stopDrag()
		{
			this.m_leftMouseHeldDown = false;
			this.m_draggingMap = false;
		}

		// Token: 0x0600094C RID: 2380 RVA: 0x000C0184 File Offset: 0x000BE384
		public void mouseNotClicked(Point mousePos)
		{
			if (!this.m_leftMouseHeldDown)
			{
				return;
			}
			if (!this.m_draggingMap)
			{
				if (GameEngine.Instance.World.isUserVillage(this.m_villageID) || this.attackerSetupMode)
				{
					if (!this.commonMouseClicked(mousePos))
					{
						this.mouseClicked(mousePos);
					}
				}
				else
				{
					this.commonMouseClicked(mousePos);
				}
			}
			this.m_leftMouseHeldDown = false;
			this.m_draggingMap = false;
			if (!this.troopMovingMode)
			{
				CursorManager.SetCursor(CursorManager.CursorType.Default, InterfaceMgr.Instance.ParentForm);
				return;
			}
			CursorManager.SetCursor(CursorManager.CursorType.VSplit, InterfaceMgr.Instance.ParentForm);
		}

		// Token: 0x0600094D RID: 2381 RVA: 0x0000D5EC File Offset: 0x0000B7EC
		public bool holdingLeftMouse()
		{
			return this.m_leftMouseHeldDown || this.m_lassoLeftHeldDown;
		}

		// Token: 0x0600094E RID: 2382 RVA: 0x000C0214 File Offset: 0x000BE414
		public void mouseMoveUpdate(Point mousePos, bool leftDown)
		{
			bool flag = !GameEngine.Instance.World.isUserVillage(this.m_villageID) && !this.attackerSetupMode;
			if (this.castleMapRendering.backgroundSprite == null)
			{
				return;
			}
			if (!GameEngine.Instance.World.isCapital(this.m_villageID))
			{
				InterfaceMgr.Instance.mouseMoveDXCardBar(mousePos);
			}
			if (!this.attackerSetupMode)
			{
				if (mousePos.X > this.castleMapRendering.gfx.ViewportWidth - 32 && (float)mousePos.Y < 32f + CastleMap.wikiHelpSprite.PosY && (float)mousePos.Y > CastleMap.wikiHelpSprite.PosY)
				{
					this.overWikiHelp = true;
					CustomTooltipManager.MouseEnterTooltipArea(4400, 2);
				}
				else
				{
					this.overWikiHelp = false;
				}
			}
			if (this.troopMovingMode && this.updateTroopMove(mousePos, leftDown))
			{
				return;
			}
			if ((this.castleMapRendering.gfx.keyControlled || this.m_lassoLeftHeldDown) && !this.battleMode && !flag && !this.inBuilderMode)
			{
				if (leftDown)
				{
					if (!this.m_lassoLeftHeldDown)
					{
						this.m_lassoLeftHeldDown = true;
						this.m_lassoLastX = (this.m_lassoEndX = (this.m_lassoStartX = mousePos.X));
						this.m_lassoLastY = (this.m_lassoEndY = (this.m_lassoStartY = mousePos.Y));
						this.castleLayout.createSparseArray();
						this.updateLasso(false);
						this.recalcCastleLayout();
						return;
					}
					this.m_lassoEndX = mousePos.X;
					this.m_lassoEndY = mousePos.Y;
					this.updateLasso(false);
					return;
				}
				else
				{
					if (!this.m_lassoLeftHeldDown)
					{
						return;
					}
					this.m_lassoLeftHeldDown = false;
					this.m_lassoMade = true;
					this.m_lassoEndX = mousePos.X;
					this.m_lassoEndY = mousePos.Y;
					this.updateLasso(false);
					if (this.m_lassoElements.Count > 0)
					{
						if (!this.inTroopPlacerMode)
						{
							this.startTroopPlacerMode();
						}
						this.lassoMade();
						this.recalcCastleLayout();
						return;
					}
					this.clearLasso();
					return;
				}
			}
			else
			{
				this.m_lassoLeftHeldDown = false;
				if (leftDown && this.placementType != 34 && this.placementType != 33 && this.placementType != 36 && this.placementType != 35 && this.placementType != 65 && this.placementType != 66)
				{
					double currentMilliseconds = DXTimer.GetCurrentMilliseconds();
					bool flag2 = this.mouseDrag(mousePos, flag);
					this.m_previousMousePos = mousePos;
					if (this.m_holdLassoModeAvailable && flag2)
					{
						this.m_holdLassoModeAvailable = false;
					}
					if (this.m_holdLassoModeAvailable && currentMilliseconds - this.m_lastMousePressedTime > 250.0)
					{
						CursorManager.SetCursor(CursorManager.CursorType.Cross, InterfaceMgr.Instance.ParentForm);
						this.m_lassoLeftHeldDown = true;
						this.m_lassoLastX = (this.m_lassoEndX = (this.m_lassoStartX = mousePos.X));
						this.m_lassoLastY = (this.m_lassoEndY = (this.m_lassoStartY = mousePos.Y));
						this.clearLasso();
						this.castleLayout.createSparseArray();
						this.updateLasso(false);
						return;
					}
				}
				if (this.m_lassoMade)
				{
					return;
				}
				Point mapTile = this.Camera.ScreenSpaceToMapTile(mousePos);
				if (this.isValidMapTile(mapTile))
				{
					CastleMap.Builder_MapX = mapTile.X;
					CastleMap.Builder_MapY = mapTile.Y;
					if (this.deleting)
					{
						long num = this.deletingHighlightElementID;
						this.deletingHighlightElementID = this.castleLayout.getCastleElementID(mapTile.X, mapTile.Y);
						int num2 = (int)this.castleLayout.map[mapTile.X, mapTile.Y];
						if ((num2 >= 1 && num2 <= 10) || (num2 >= 51 && num2 <= 57))
						{
							this.deletingHighlightElementID = -2L;
						}
						if (num != this.deletingHighlightElementID)
						{
							this.recalcCastleLayout();
						}
						if (!this.inDeleting)
						{
							CursorManager.SetCursor(CursorManager.CursorType.Cross, InterfaceMgr.Instance.ParentForm);
							return;
						}
						if ((DateTime.Now - this.lastDeleteTime).TotalSeconds > 8.0)
						{
							CursorManager.SetCursor(CursorManager.CursorType.Cross, InterfaceMgr.Instance.ParentForm);
							return;
						}
						CursorManager.SetCursor(CursorManager.CursorType.WaitCursor, InterfaceMgr.Instance.ParentForm);
						return;
					}
					else
					{
						if (this.troopMovingMode)
						{
							Point mousePos2 = this.Camera.ScreenToWorldSpace(mousePos);
							long num3 = this.deletingHighlightElementID;
							if (this.placingDefender)
							{
								long num4 = this.clickFindTroop(mousePos2);
								if (num4 != -2L)
								{
									this.deletingHighlightElementID = num4;
								}
								else
								{
									this.deletingHighlightElementID = -2L;
								}
							}
							if (num3 != this.deletingHighlightElementID)
							{
								this.recalcCastleLayout();
							}
							CursorManager.SetCursor(CursorManager.CursorType.Cross, InterfaceMgr.Instance.ParentForm);
							return;
						}
						if (this.selectedCatapult != -1L)
						{
							this.mouseMoveCatapultTarget(mapTile.X, mapTile.Y);
							return;
						}
						if (!this.placingElement)
						{
							this.troopsFollowMouse(mapTile.X, mapTile.Y);
							return;
						}
						this.moveConstruction(mousePos, leftDown);
						if (this.battleMode)
						{
							this.battleModeMousePos = this.Camera.ScreenToWorldSpace(mousePos);
							return;
						}
					}
				}
				else if (this.battleMode)
				{
					this.battleModeMousePos = new Point(-1000, -1000);
				}
				return;
			}
		}

		// Token: 0x0600094F RID: 2383 RVA: 0x000C0738 File Offset: 0x000BE938
		private void catapultsFollowMouse(int facing, int mapX, int mapY)
		{
			int num = 0;
			int num2 = 0;
			if (this.CurrentBrushSize == CastleMap.BrushSize.BRUSH_3X3)
			{
				num2 = 2;
			}
			else if (this.CurrentBrushSize == CastleMap.BrushSize.BRUSH_5X5)
			{
				num2 = 4;
			}
			else if (this.CurrentBrushSize == CastleMap.BrushSize.BRUSH_1X5)
			{
				num2 = 4;
				if (facing == 0 || facing == 4)
				{
					for (int i = mapX - num2; i <= mapX + num2; i += 2)
					{
						this.mouseMovePlaceTroops(i, mapY, true, num);
						num++;
					}
					return;
				}
				for (int j = mapY - num2; j <= mapY + num2; j += 2)
				{
					this.mouseMovePlaceTroops(mapX, j, true, num);
					num++;
				}
				return;
			}
			if (facing == 0 || facing == 4)
			{
				for (int k = mapX - num2; k <= mapX + num2; k += 2)
				{
					this.mouseMovePlaceTroops(k, mapY, true, num);
					num++;
				}
				return;
			}
			for (int l = mapY - num2; l <= mapY + num2; l += 2)
			{
				this.mouseMovePlaceTroops(mapX, l, true, num);
				num++;
			}
		}

		// Token: 0x06000950 RID: 2384 RVA: 0x000C0804 File Offset: 0x000BEA04
		public void troopsFollowMouse(int mapX, int mapY)
		{
			if (this.CurrentBrushSize == CastleMap.BrushSize.BRUSH_1X1)
			{
				this.mouseMovePlaceTroops(mapX, mapY, true, 0);
				return;
			}
			int num = (mapX < mapY) ? ((117 - mapX >= mapY) ? 2 : 0) : ((117 - mapX >= mapY) ? 4 : 6);
			if (this.placementType == 94)
			{
				this.catapultsFollowMouse(num, mapX, mapY);
				return;
			}
			if (this.CurrentBrushSize != CastleMap.BrushSize.BRUSH_1X5)
			{
				int num2 = 0;
				int num3 = 0;
				if (this.CurrentBrushSize == CastleMap.BrushSize.BRUSH_3X3)
				{
					num3 = 1;
				}
				else if (this.CurrentBrushSize == CastleMap.BrushSize.BRUSH_5X5)
				{
					num3 = 2;
				}
				for (int i = mapY - num3; i <= mapY + num3; i++)
				{
					for (int j = mapX - num3; j <= mapX + num3; j++)
					{
						this.mouseMovePlaceTroops(j, i, true, num2);
						num2++;
					}
				}
				return;
			}
			int num4 = 0;
			int num5 = 2;
			if (num == 0 || num == 4)
			{
				for (int k = mapX - num5; k <= mapX + num5; k++)
				{
					this.mouseMovePlaceTroops(k, mapY, true, num4);
					num4++;
				}
				return;
			}
			for (int l = mapY - num5; l <= mapY + num5; l++)
			{
				this.mouseMovePlaceTroops(mapX, l, true, num4);
				num4++;
			}
		}

		// Token: 0x06000951 RID: 2385 RVA: 0x000C0914 File Offset: 0x000BEB14
		public void pressConstructionConfirm()
		{
			this.clearPlacementWallSprites();
			UniversalDebugLog.Log("begin pressConstructionConfirm");
			if (this.isPlacingResizableElement())
			{
				this.confirmEndHandle(this.lastMoveTileX, this.lastMoveTileY);
				this.stopPlaceElement();
				return;
			}
			if (this.isPlacingTroops())
			{
				this.confirmTroopPlacement(this.lastMoveTileX, this.lastMoveTileY);
				return;
			}
			this.placeBuildingElement(this.lastMoveTileX, this.lastMoveTileY);
			this.stopPlaceElement();
		}

		// Token: 0x06000952 RID: 2386 RVA: 0x0000D5FE File Offset: 0x0000B7FE
		public void moveStartHandle(int mapX, int mapY)
		{
			this.startWallMapX = mapX;
			this.startWallMapY = mapY;
			this.lastMoveTileX = mapX;
			this.lastMoveTileY = mapY;
			this.clearPlacementWallSprites();
			this.addPlacementWallSprites(mapX, mapY, this.placementType);
		}

		// Token: 0x06000953 RID: 2387 RVA: 0x000C0988 File Offset: 0x000BEB88
		public void moveConstructionOrthogonally(int mapX, int mapY)
		{
			if (mapX != this.lastMoveTileX || mapY != this.lastMoveTileY || !this.draggingWall)
			{
				int num = Math.Abs(this.startWallMapX - mapX);
				int num2 = Math.Abs(this.startWallMapY - mapY);
				if (num > num2)
				{
					mapY = this.startWallMapY;
				}
				else
				{
					mapX = this.startWallMapX;
				}
				this.lastMoveTileX = mapX;
				this.lastMoveTileY = mapY;
				this.wallMouseMove(mapX, mapY, true);
			}
		}

		// Token: 0x06000954 RID: 2388 RVA: 0x0000D630 File Offset: 0x0000B830
		public void confirmEndHandle(int mapX, int mapY)
		{
			if (mapX != this.lastMoveTileX || mapY != this.lastMoveTileY || !this.draggingWall)
			{
				this.lastMoveTileX = mapX;
				this.lastMoveTileY = mapY;
			}
			this.wallMouseMove(mapX, mapY, false);
		}

		// Token: 0x06000955 RID: 2389 RVA: 0x000C09F8 File Offset: 0x000BEBF8
		public void moveConstruction(Point mousePos, bool leftDown)
		{
			Point point = this.Camera.ScreenSpaceToMapTile(mousePos);
			if (this.isPlacingResizableElement())
			{
				if (point.X != this.lastMoveTileX || point.Y != this.lastMoveTileY || !this.draggingWall)
				{
					this.lastMoveTileX = point.X;
					this.lastMoveTileY = point.Y;
					this.wallMouseMove(point.X, point.Y, leftDown);
					return;
				}
			}
			else if (point.X != this.lastMoveTileX || point.Y != this.lastMoveTileY)
			{
				this.lastMoveTileX = point.X;
				this.lastMoveTileY = point.Y;
				this.movePlaceElement(point.X, point.Y, CastleMap.buildingPlacementSprite, false, true);
			}
		}

		// Token: 0x06000956 RID: 2390 RVA: 0x000C0AC8 File Offset: 0x000BECC8
		public void moveBuilding(Point delta)
		{
			this.lastMoveTileX += delta.X;
			this.lastMoveTileY += delta.Y;
			this.movePlaceElement(this.lastMoveTileX, this.lastMoveTileY, CastleMap.buildingPlacementSprite, false, true);
		}

		// Token: 0x06000957 RID: 2391 RVA: 0x000C0B18 File Offset: 0x000BED18
		public void moveResizable(Point delta)
		{
			this.lastMoveTileX += delta.X;
			this.lastMoveTileY += delta.Y;
			this.startWallMapX += delta.X;
			this.startWallMapY += delta.Y;
			this.wallMouseMove(this.lastMoveTileX, this.lastMoveTileY, true);
		}

		// Token: 0x06000958 RID: 2392 RVA: 0x000C0B88 File Offset: 0x000BED88
		public Point GetCenterOfPlacementOnScreen()
		{
			if (this.isPlacingResizableElement())
			{
				Point mapTile = new Point((this.lastMoveTileX + this.startWallMapX) / 2, (this.lastMoveTileY + this.startWallMapY) / 2);
				return this.Camera.MapTileToScreenSpace(mapTile);
			}
			return this.Camera.MapTileToScreenSpace(new Point(this.lastMoveTileX, this.lastMoveTileY));
		}

		// Token: 0x06000959 RID: 2393 RVA: 0x000C0BEC File Offset: 0x000BEDEC
		public Rectangle GetCurrentPlacementRect()
		{
			Rectangle result = default(Rectangle);
			if (this.isPlacingResizableElement())
			{
				int num = 0;
				if (this.CurrentBrushSize == CastleMap.BrushSize.BRUSH_3X3)
				{
					num = 1;
				}
				else if (this.CurrentBrushSize == CastleMap.BrushSize.BRUSH_5X5)
				{
					num = 2;
				}
				result.X = Math.Min(this.lastMoveTileX, this.startWallMapX) - num;
				result.Y = Math.Min(this.lastMoveTileY, this.startWallMapY) - num;
				result.Width = Math.Max(this.lastMoveTileX, this.startWallMapX) - result.X + num + 1;
				result.Height = Math.Max(this.lastMoveTileY, this.startWallMapY) - result.Y + num + 1;
			}
			else
			{
				int x = this.lastMoveTileX;
				int y = this.lastMoveTileY;
				int elementSize = CastlesCommon.getElementSize(this.placementType, ref x, ref y);
				result.X = x;
				result.Y = y;
				result.Width = elementSize;
				result.Height = elementSize;
			}
			return result;
		}

		// Token: 0x0600095A RID: 2394 RVA: 0x0000D663 File Offset: 0x0000B863
		public bool isPlacingBuildingOrWall()
		{
			return this.placementType < 69;
		}

		// Token: 0x0600095B RID: 2395 RVA: 0x0000D663 File Offset: 0x0000B863
		public bool isPlacingBuildingOrInfrastructure()
		{
			return this.placementType < 69;
		}

		// Token: 0x0600095C RID: 2396 RVA: 0x0000D66F File Offset: 0x0000B86F
		public bool isPlacingResizableElement()
		{
			return this.isWall(this.placementType) || this.placementType == 35 || this.placementType == 36;
		}

		// Token: 0x0600095D RID: 2397 RVA: 0x0000D695 File Offset: 0x0000B895
		public void BeginGesture(CastleMap.Gesture gesture)
		{
			UniversalDebugLog.Log("Start " + gesture.ToString());
			this.m_gesture = gesture;
			this.PlacementMoved = false;
		}

		// Token: 0x0600095E RID: 2398 RVA: 0x0000D6C1 File Offset: 0x0000B8C1
		public void EndGesture()
		{
			UniversalDebugLog.Log("End " + this.m_gesture.ToString());
			this.m_gesture = CastleMap.Gesture.NONE;
			this.PlacementMoved = false;
		}

		// Token: 0x0600095F RID: 2399 RVA: 0x0000D6F1 File Offset: 0x0000B8F1
		public bool isDeletingTroops()
		{
			return this.deletingTroops;
		}

		// Token: 0x06000960 RID: 2400 RVA: 0x0000D6F9 File Offset: 0x0000B8F9
		public bool isPlacingTroops()
		{
			return this.placementType > 69 && this.placementType < 110;
		}

		// Token: 0x06000961 RID: 2401 RVA: 0x0000D711 File Offset: 0x0000B911
		public bool isPlacingSomething()
		{
			return this.placementType > 0;
		}

		// Token: 0x06000962 RID: 2402 RVA: 0x0000D71C File Offset: 0x0000B91C
		public void floodFillPlaceTroops(int mapx, int mapy)
		{
			this.floodFillPlaceTroops(mapx, mapy, -1);
		}

		// Token: 0x06000963 RID: 2403 RVA: 0x000C0CE8 File Offset: 0x000BEEE8
		private bool doesElementTypeExistAtPosition(int x, int y, int elementTypeToPlaceOn)
		{
			bool result = false;
			if (GameEngine.Instance.GameDisplayModeSubMode == GameEngine.GameDisplaySubModes.SUBMODE_CASTLE_ATTACKER_SETUP)
			{
				result = true;
			}
			else
			{
				if (this.elements == null)
				{
					throw new Exception("elements is null");
				}
				if (this.castleLayout == null)
				{
					CastlesCommon.buildCastleLayoutClient(this.elements, ref this.castleLayout);
				}
				CastleElement castleElement = this.castleLayout.getCastleElement(x, y);
				int num = -1;
				if (castleElement != null)
				{
					num = (int)castleElement.elementType;
				}
				bool flag = num == elementTypeToPlaceOn;
				bool flag2 = CastlesCommon.isTower(num) && CastlesCommon.isTower(elementTypeToPlaceOn);
				bool flag3 = (num == 4 || elementTypeToPlaceOn == 4) && (num == -1 || elementTypeToPlaceOn == -1);
				if (flag || flag2 || flag3)
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06000964 RID: 2404 RVA: 0x000C0D90 File Offset: 0x000BEF90
		public void floodFillPlaceTroops(int mapx, int mapy, int elementTypeToPlaceOn)
		{
			for (int i = 0; i < 6; i++)
			{
				for (int j = mapx - i; j < mapx + i; j++)
				{
					for (int k = mapy - i; k < mapy + i; k++)
					{
						bool flag = (j == mapx - i || j == mapx + i - 1) && (k == mapy - i || k == mapy + i - 1);
						if (this.doesElementTypeExistAtPosition(j, k, elementTypeToPlaceOn) && this.tryPlaceTroop(j, k))
						{
							return;
						}
					}
				}
			}
		}

		// Token: 0x06000965 RID: 2405 RVA: 0x000C0E04 File Offset: 0x000BF004
		public int getBrushRadius(CastleMap.BrushSize size, bool catapult)
		{
			int num = 0;
			if (this.CurrentBrushSize == CastleMap.BrushSize.BRUSH_3X3)
			{
				num = 1;
			}
			else if (this.CurrentBrushSize == CastleMap.BrushSize.BRUSH_5X5)
			{
				num = 2;
			}
			if (catapult)
			{
				num *= 2;
			}
			return num;
		}

		// Token: 0x06000966 RID: 2406 RVA: 0x000C0E34 File Offset: 0x000BF034
		private Rectangle getElementFootprint(CastleElement element)
		{
			int xPos = (int)element.xPos;
			int yPos = (int)element.yPos;
			int elementSize = CastlesCommon.getElementSize((int)element.elementType, ref xPos, ref yPos);
			return new Rectangle(xPos, yPos, elementSize, elementSize);
		}

		// Token: 0x06000967 RID: 2407 RVA: 0x000C0E68 File Offset: 0x000BF068
		public void brushPlaceTroops(int mapx, int mapy, int elementTypeToPlaceOn)
		{
			bool flag = false;
			bool flag2 = this.placementType == 94 || this.placementType == 74;
			int num = this.getBrushRadius(this.CurrentBrushSize, flag2);
			int num2 = num;
			if (flag2)
			{
				if (mapx < mapy)
				{
					if (117 - mapx < mapy)
					{
						num2 = 0;
					}
					else
					{
						num = 0;
					}
				}
				else if (117 - mapx < mapy)
				{
					num = 0;
				}
				else
				{
					num2 = 0;
				}
			}
			for (int i = mapx - num; i <= mapx + num; i++)
			{
				for (int j = mapy - num2; j <= mapy + num2; j++)
				{
					if (this.doesElementTypeExistAtPosition(i, j, elementTypeToPlaceOn) && this.tryPlaceTroop(i, j))
					{
						flag = true;
					}
				}
			}
			if (flag)
			{
				GameEngine.Instance.playInterfaceSound("CastleMap_place_defender");
			}
		}

		// Token: 0x06000968 RID: 2408 RVA: 0x000C0F18 File Offset: 0x000BF118
		public bool tryPlaceTroop(int mapx, int mapy)
		{
			if (!this.hasFreeTroopToPlace())
			{
				return false;
			}
			if (this.placingDefender && this.canPlaceDefender(mapx, mapy))
			{
				if (this.countPlacedTroops() >= this.getGuardHouseCapacity())
				{
					return false;
				}
				this.troopPlaceDefender(mapx, mapy);
				this.updateLayoutAndRedraw();
				return true;
			}
			else
			{
				if (!this.placingDefender && this.canPlaceAttacker(mapx, mapy))
				{
					this.troopPlaceAttacker(mapx, mapy);
					this.updateLayoutAndRedraw();
					return true;
				}
				return false;
			}
		}

		// Token: 0x06000969 RID: 2409 RVA: 0x000C0F88 File Offset: 0x000BF188
		public bool startPlaceElement(int elementType)
		{
			this.stopPlaceElement();
			if (elementType == 41)
			{
				int num = this.countTurrets();
				if (num >= (int)GameEngine.Instance.Village.m_parishCapitalResearchData.Research_CAP_Turrets)
				{
					return false;
				}
			}
			if (elementType == 42)
			{
				int num2 = this.countBallistas();
				if (num2 >= (int)GameEngine.Instance.Village.m_parishCapitalResearchData.Research_CAP_Ballista)
				{
					return false;
				}
			}
			if (elementType == 44)
			{
				int num3 = this.countBombards();
				if (num3 >= (int)GameEngine.Instance.Village.m_parishCapitalResearchData.Research_Leadership)
				{
					return false;
				}
			}
			this.placingElement = true;
			this.placementType = elementType;
			CastleMap.buildingPlacementSprite = new SpriteWrapper();
			CastleMap.buildingPlacementSprite.TextureID = GFXLibrary.Instance.CastleSpritesTexID;
			CastleMap.buildingPlacementSprite.Initialize(this.castleMapRendering.gfx);
			int elementType2 = this.correctPlacementType(elementType);
			int spriteNo = GameEngine.Instance.castleMapRendering.initCastleSprite(CastleMap.buildingPlacementSprite, elementType2, 0, 0, true, null, this);
			CastleMap.buildingPlacementSprite.SpriteNo = spriteNo;
			this.castleMapRendering.backgroundSprite.AddChild(CastleMap.buildingPlacementSprite, 10);
			this.draggingWall = false;
			this.clearPlacementWallSprites();
			if (elementType == 38 || elementType == 37 || elementType == 40 || elementType == 39)
			{
				this.startPlaceElement_ShowPanel(elementType, CastlesCommon.getPieceName(elementType), false);
			}
			this.recalcCastleLayout();
			InterfaceMgr.Instance.toggleDXCardBarActive(false);
			return true;
		}

		// Token: 0x0600096A RID: 2410 RVA: 0x000C10D4 File Offset: 0x000BF2D4
		public bool mouseDrag(Point mousePos, bool viewOnly)
		{
			double currentMilliseconds = DXTimer.GetCurrentMilliseconds();
			if (!this.m_leftMouseHeldDown)
			{
				this.m_lastMousePressedTime = currentMilliseconds;
				this.startDrag(mousePos);
				this.m_draggingMap = false;
				if (!viewOnly && !this.inBuilderMode)
				{
					this.m_holdLassoModeAvailable = true;
				}
			}
			bool flag = Math.Abs(this.m_baseMousePos.X - mousePos.X) > 3 || Math.Abs(this.m_baseMousePos.Y - mousePos.Y) > 3;
			if (currentMilliseconds - this.m_lastMousePressedTime > 250.0 || flag)
			{
				this.m_draggingMap = true;
				int x = mousePos.X - this.m_previousMousePos.X;
				int y = mousePos.Y - this.m_previousMousePos.Y;
				this.Camera.Drag(new Point(x, y));
			}
			return flag;
		}

		// Token: 0x0600096B RID: 2411 RVA: 0x000C11AC File Offset: 0x000BF3AC
		public bool isMouseOverTroopPlacementSprite(Point mousePos)
		{
			if (this.dummySprite != null)
			{
				Point point = this.Camera.ScreenSpaceToMapTile(mousePos);
				int num = 5;
				int num2 = Math.Abs(point.X - this.lastMoveTileX);
				int num3 = Math.Abs(point.Y - this.lastMoveTileY);
				if (num2 < num && num3 < num)
				{
					UniversalDebugLog.Log("clicked on placement troop");
					return true;
				}
			}
			else
			{
				UniversalDebugLog.Log("Dummy sprite is null");
			}
			return false;
		}

		// Token: 0x0600096C RID: 2412 RVA: 0x000C1218 File Offset: 0x000BF418
		public bool isOverPlacementSprite(int mapX, int mapY)
		{
			if (CastleMap.buildingPlacementSprite != null && this.castleMapRendering.backgroundSprite != null)
			{
				int num = 5;
				int num2 = Math.Abs(mapX - this.lastMoveTileX);
				int num3 = Math.Abs(mapY - this.lastMoveTileY);
				if (num2 < num && num3 < num)
				{
					return true;
				}
				if (this.isPlacingResizableElement())
				{
					return this.GetCurrentPlacementRect().Contains(mapX, mapY);
				}
			}
			return false;
		}

		// Token: 0x0600096D RID: 2413 RVA: 0x0000D727 File Offset: 0x0000B927
		public bool isWall(int element)
		{
			return element == 34 || element == 33 || element == 65 || element == 66;
		}

		// Token: 0x0600096E RID: 2414 RVA: 0x000C127C File Offset: 0x000BF47C
		public int countBombards()
		{
			int num = 0;
			foreach (CastleElement castleElement in this.elements)
			{
				if (castleElement.elementType == 44)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x0600096F RID: 2415 RVA: 0x000C12DC File Offset: 0x000BF4DC
		public int countTurrets()
		{
			int num = 0;
			foreach (CastleElement castleElement in this.elements)
			{
				if (castleElement.elementType == 41)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000970 RID: 2416 RVA: 0x000C133C File Offset: 0x000BF53C
		public int countBallistas()
		{
			int num = 0;
			foreach (CastleElement castleElement in this.elements)
			{
				if (castleElement.elementType == 42)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000971 RID: 2417 RVA: 0x000C139C File Offset: 0x000BF59C
		public int countGuardHouses()
		{
			int num = 0;
			foreach (CastleElement castleElement in this.elements)
			{
				if (castleElement.elementType == 31)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000972 RID: 2418 RVA: 0x000C13FC File Offset: 0x000BF5FC
		public int countCompletedSmelters()
		{
			int num = 0;
			foreach (CastleElement castleElement in this.elements)
			{
				if (castleElement.elementType == 32 && castleElement.completionTime < VillageMap.getCurrentServerTime())
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000973 RID: 2419 RVA: 0x000BCEA0 File Offset: 0x000BB0A0
		public int countMoat()
		{
			int num = 0;
			foreach (CastleElement castleElement in this.elements)
			{
				if (castleElement.elementType == 35)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06000974 RID: 2420 RVA: 0x0000D73F File Offset: 0x0000B93F
		public void rightClick(Point mousePos)
		{
			if (this.m_lassoMade && this.m_lassoElements.Count > 0)
			{
				this.moveLassoTroops(mousePos);
				return;
			}
			this.stopPlaceElement();
		}

		// Token: 0x06000975 RID: 2421 RVA: 0x000C146C File Offset: 0x000BF66C
		public void stopPlaceElement()
		{
			CursorManager.SetCursor(CursorManager.CursorType.Default, InterfaceMgr.Instance.ParentForm);
			InterfaceMgr.Instance.toggleDXCardBarActive(true);
			if (CastleMap.buildingPlacementSprite != null)
			{
				if (this.castleMapRendering.backgroundSprite != null)
				{
					this.castleMapRendering.backgroundSprite.RemoveChild(CastleMap.buildingPlacementSprite);
				}
				CastleMap.buildingPlacementSprite = null;
			}
			this.clearPlacementTroopSprites();
			this.clearPlacementWallSprites();
			this.draggingWall = false;
			this.placingElement = true;
			this.placingDefender = true;
			if (this.troopMovingMode)
			{
				this.troopMovingMode = false;
				if (this.troopMovingElemID != -2L || this.deletingHighlightElementID != -2L)
				{
					this.deletingHighlightElementID = -2L;
					this.troopMovingElemID = -2L;
					this.recalcCastleLayout();
				}
			}
			this.troopMovingElemID = -2L;
			this.placementType = -1;
			if (this.selectedCatapult != -1L)
			{
				this.selectedCatapult = -1L;
				this.recalcCastleLayout();
			}
			if (this.troopSelected != -1L)
			{
				this.troopSelected = -1L;
				this.recalcCastleLayout();
				InterfaceMgr.Instance.castle_ClearSelectedTroop();
			}
			if (this.deleting)
			{
				CursorManager.SetCursor(CursorManager.CursorType.Default, InterfaceMgr.Instance.ParentForm);
				this.deleting = false;
				this.deletingHighlightElementID = -2L;
				this.recalcCastleLayout();
			}
			if (this.m_lassoMade)
			{
				this.clearLasso();
			}
			this.lastMoveTileX = -1;
			this.lastMoveTileY = -1;
			InterfaceMgr.Instance.castleStopPlacing();
		}

		// Token: 0x06000976 RID: 2422 RVA: 0x000C15C0 File Offset: 0x000BF7C0
		public void FindEmptyBuildingSpot()
		{
			int xPos = this.lastMoveTileX;
			int yPos = this.lastMoveTileY;
			int elementSize = CastlesCommon.getElementSize(this.placementType, ref xPos, ref yPos);
			int num = this.lastMoveTileX - elementSize - 1;
			if (num < 33)
			{
				num = 33 + elementSize / 2;
				if (elementSize % 2 == 0)
				{
					num--;
				}
			}
			int num2 = this.lastMoveTileX + elementSize + 1;
			if (num2 > 84)
			{
				num2 = 84 - elementSize / 2;
				if (elementSize % 2 == 0)
				{
					num2++;
				}
			}
			int num3 = this.lastMoveTileY - elementSize - 1;
			if (num3 < 33)
			{
				num3 = 33 + elementSize / 2;
				if (elementSize % 2 == 0)
				{
					num3--;
				}
			}
			int num4 = this.lastMoveTileY + elementSize + 1;
			if (num4 > 84)
			{
				num4 = 84 - elementSize / 2;
				if (elementSize % 2 == 0)
				{
					num4++;
				}
			}
			CastleElement castleElement = new CastleElement();
			castleElement.elementType = (byte)this.placementType;
			for (int i = num3; i <= num4; i++)
			{
				for (int j = num; j <= num2; j++)
				{
					if (j != this.lastMoveTileX || i != this.lastMoveTileY)
					{
						castleElement.xPos = (byte)j;
						castleElement.yPos = (byte)i;
						xPos = j;
						yPos = i;
						if (CastlesCommon.validatePlacement(this.placementType, xPos, yPos) && this.castleLayout.testElement(castleElement))
						{
							this.lastMoveTileX = j;
							this.lastMoveTileY = i;
							this.movePlaceElement(j, i, CastleMap.buildingPlacementSprite, false, true);
							return;
						}
					}
				}
			}
			this.movePlaceElement(this.lastMoveTileX, this.lastMoveTileY, CastleMap.buildingPlacementSprite, false, true);
		}

		// Token: 0x06000977 RID: 2423 RVA: 0x000C1744 File Offset: 0x000BF944
		public bool movePlaceElement(int mapX, int mapY, SpriteWrapper sprite, bool forceInvalid, bool checkEnclosed)
		{
			if (sprite != null && this.castleMapRendering.backgroundSprite != null)
			{
				int num = mapX * 16 + mapY * 16 - 922;
				int num2 = mapY * 8 - mapX * 8 + 474;
				if (num >= 0 && num2 >= 0 && num < 1904 && num2 < 952)
				{
					sprite.Visible = true;
					sprite.PosX = (float)(num + 16);
					sprite.PosY = (float)(num2 + 8);
					CastleElement castleElement = new CastleElement();
					castleElement.elementType = (byte)this.placementType;
					castleElement.xPos = (byte)mapX;
					castleElement.yPos = (byte)mapY;
					int num3 = 0;
					int num4 = 0;
					int num5 = 0;
					int num6 = 0;
					int num7 = 0;
					if (!forceInvalid && CastlesCommon.validatePlacement(castleElement))
					{
						if (this.placementType == 43 && this.attackerSetupForest && mapY < 33)
						{
							forceInvalid = true;
						}
						else if (!CastleMap.CreateMode)
						{
							CastlesCommon.getConstrCost(GameEngine.Instance.LocalWorldData, this.placementType, ref num3, ref num4, ref num5, ref num6, ref num7);
							VillageMap.StockpileLevels stockpileLevels = new VillageMap.StockpileLevels();
							if (GameEngine.Instance.Village != null)
							{
								GameEngine.Instance.Village.getStockpileLevels(stockpileLevels);
							}
							int num8 = 0;
							if (!GameEngine.Instance.World.isCapital(this.m_villageID))
							{
								num8 = (int)GameEngine.Instance.World.getCurrentGold();
							}
							else if (GameEngine.Instance.Village != null)
							{
								num8 = (int)GameEngine.Instance.Village.m_capitalGold;
							}
							this.adjustLevels(ref stockpileLevels, ref num8);
							if ((num3 <= 0 || (double)num3 > stockpileLevels.woodLevel) && (num4 <= 0 || (double)num4 > stockpileLevels.stoneLevel) && (num5 <= 0 || num5 > num8) && (num7 <= 0 || (double)num7 > stockpileLevels.ironLevel) && (num3 != 0 || num4 != 0 || num5 != 0 || num7 != 0 || num6 != 0))
							{
								forceInvalid = true;
							}
						}
					}
					if (forceInvalid)
					{
						sprite.ColorToUse = Color.FromArgb(128, global::ARGBColors.Red);
						return false;
					}
					if (!CastlesCommon.validatePlacement(castleElement))
					{
						sprite.ColorToUse = Color.FromArgb(128, global::ARGBColors.White);
						return false;
					}
					if (this.castleLayout != null && !this.castleLayout.testElement(castleElement))
					{
						sprite.ColorToUse = Color.FromArgb(128, global::ARGBColors.Red);
						return false;
					}
					if (this.castleLayout != null && checkEnclosed && this.castleLayout.isCastleEnclosed(castleElement, null))
					{
						sprite.ColorToUse = Color.FromArgb(128, global::ARGBColors.Blue);
						return false;
					}
					sprite.ColorToUse = global::ARGBColors.White;
					if ((this.placementType == 40 || this.placementType == 39 || (this.placementType == 38 | this.placementType == 37)) && (mapX != this.lastGHX || mapY != this.lastGHY))
					{
						this.lastGHX = mapX;
						this.lastGHY = mapY;
						if ((mapX < mapY) ? (117 - mapX < mapY) : (117 - mapX >= mapY))
						{
							if (this.placementType == 40)
							{
								this.startPlaceElement(39);
							}
							if (this.placementType == 38)
							{
								this.startPlaceElement(37);
							}
						}
						else
						{
							if (this.placementType == 39)
							{
								this.startPlaceElement(40);
							}
							if (this.placementType == 37)
							{
								this.startPlaceElement(38);
							}
						}
					}
					return true;
				}
				else
				{
					sprite.Visible = false;
				}
			}
			return false;
		}

		// Token: 0x06000978 RID: 2424 RVA: 0x000C1A8C File Offset: 0x000BFC8C
		public void startPlaceElement_ShowPanel(int pieceType, string name, bool rollover)
		{
			if (pieceType == 65)
			{
				pieceType = 34;
			}
			if (pieceType == 66)
			{
				pieceType = 33;
			}
			int woodCost = 0;
			int stoneCost = 0;
			int ironCost = 0;
			int pitchCost = 0;
			int goldCost = 0;
			CastlesCommon.getConstrCost(GameEngine.Instance.LocalWorldData, pieceType, ref woodCost, ref stoneCost, ref goldCost, ref pitchCost, ref ironCost);
			bool flag = GameEngine.Instance.World.isCapital(this.m_villageID);
			CardData cardData = new CardData();
			if (!flag)
			{
				cardData = GameEngine.Instance.cardsManager.UserCardData;
			}
			double num = CastlesCommon.calcConstrTime(GameEngine.Instance.LocalWorldData, pieceType, (int)GameEngine.Instance.World.GetResearchDataForCurrentVillage().Research_Construction, flag, cardData);
			InterfaceMgr.Instance.showCastlePieceInfo(name, woodCost, stoneCost, ironCost, pitchCost, goldCost, VillageMap.createBuildTimeString((int)(num * 3600.0)), rollover);
		}

		// Token: 0x06000979 RID: 2425 RVA: 0x0000D765 File Offset: 0x0000B965
		public void startDeleting()
		{
			this.stopPlaceElement();
			this.deleting = true;
			this.deletingHighlightElementID = -2L;
			CursorManager.SetCursor(CursorManager.CursorType.Cross, InterfaceMgr.Instance.ParentForm);
		}

		// Token: 0x0600097A RID: 2426 RVA: 0x000C1B54 File Offset: 0x000BFD54
		public void deleteAllAttackers()
		{
			List<CastleElement> list = new List<CastleElement>();
			foreach (CastleElement castleElement in this.elements)
			{
				if (castleElement.elementType >= 90 && castleElement.elementType <= 109)
				{
					this.deleteCatapultTarget(castleElement.elementID);
					this.deleteCaptainsDetails(castleElement.elementID);
					list.Add(castleElement);
					this.castleLayout.removeTroop((int)castleElement.xPos, (int)castleElement.yPos, castleElement.elementID);
				}
			}
			foreach (CastleElement item in list)
			{
				this.elements.Remove(item);
			}
			this.recalcCastleLayout();
		}

		// Token: 0x0600097B RID: 2427 RVA: 0x000C1C44 File Offset: 0x000BFE44
		public SpriteWrapper getNextWallCacheSprite()
		{
			SpriteWrapper spriteWrapper;
			if (this.nextWallCacheSpriteID >= CastleMap.wallCachedSprites.Count)
			{
				spriteWrapper = new SpriteWrapper();
				CastleMap.wallCachedSprites.Add(spriteWrapper);
			}
			else
			{
				spriteWrapper = CastleMap.wallCachedSprites[this.nextWallCacheSpriteID];
			}
			this.nextWallCacheSpriteID++;
			spriteWrapper.Initialize(this.castleMapRendering.gfx, GFXLibrary.Instance.CastleSpritesTexID, 0);
			spriteWrapper.Scale = 1f;
			spriteWrapper.Visible = true;
			spriteWrapper.ColorToUse = global::ARGBColors.White;
			return spriteWrapper;
		}

		// Token: 0x0600097C RID: 2428 RVA: 0x000C1CD4 File Offset: 0x000BFED4
		private bool addWallSprite(int sx, int sy, bool forceInvalid)
		{
			SpriteWrapper nextWallCacheSprite = this.getNextWallCacheSprite();
			int num = nextWallCacheSprite.SpriteNo = ((this.placementType == 66) ? GameEngine.Instance.castleMapRendering.initCastleSprite(nextWallCacheSprite, 33, 0, 0, true, null, this) : ((this.placementType != 65) ? GameEngine.Instance.castleMapRendering.initCastleSprite(nextWallCacheSprite, this.placementType, 0, 0, true, null, this) : GameEngine.Instance.castleMapRendering.initCastleSprite(nextWallCacheSprite, 34, 0, 0, true, null, this)));
			bool result = this.movePlaceElement(sx, sy, nextWallCacheSprite, forceInvalid, false);
			CastleMap.wallPlacementSprites.Add(nextWallCacheSprite);
			this.castleMapRendering.backgroundSprite.AddChild(nextWallCacheSprite, 10);
			return result;
		}

		// Token: 0x0600097D RID: 2429 RVA: 0x000C1D80 File Offset: 0x000BFF80
		private void addFakeWallSprite(int sx, int sy)
		{
			CastleElement castleElement = new CastleElement();
			castleElement.elementID = this.localTempElementNumber;
			this.localTempElementNumber -= 1L;
			if (this.placementType == 66)
			{
				castleElement.elementType = 33;
			}
			else if (this.placementType == 65)
			{
				castleElement.elementType = 34;
			}
			else
			{
				castleElement.elementType = (byte)this.placementType;
			}
			castleElement.xPos = (byte)sx;
			castleElement.yPos = (byte)sy;
			List<long> underlyingWallElements = this.castleLayout.getUnderlyingWallElements(castleElement);
			foreach (long num in underlyingWallElements)
			{
				foreach (CastleElement castleElement2 in this.elements)
				{
					if (castleElement2.elementID == num)
					{
						this.elements.Remove(castleElement2);
						if (castleElement2.elementID >= 0L)
						{
							this.removedElements.Add(castleElement2);
							break;
						}
						break;
					}
				}
			}
			this.elements.Add(castleElement);
		}

		// Token: 0x0600097E RID: 2430 RVA: 0x000C1EB8 File Offset: 0x000C00B8
		public void undoWallPlacement()
		{
			try
			{
				if (this.wallUndoSteps.Count > 0)
				{
					foreach (CastleElement item in this.wallUndoSteps[this.wallUndoSteps.Count - 1])
					{
						this.elements.Remove(item);
					}
					this.wallUndoSteps[this.wallUndoSteps.Count - 1].Clear();
					this.wallUndoSteps.RemoveAt(this.wallUndoSteps.Count - 1);
				}
			}
			catch (Exception ex)
			{
				UniversalDebugLog.Log("Undo failed " + ex.Message);
			}
			this.updateLayoutAndRedraw();
		}

		// Token: 0x0600097F RID: 2431 RVA: 0x0000D78D File Offset: 0x0000B98D
		public void clearUndoSteps()
		{
			this.wallUndoSteps.Clear();
		}

		// Token: 0x06000980 RID: 2432 RVA: 0x000C1F98 File Offset: 0x000C0198
		private void finishWallPlacingGesture(int mapX, int mapY)
		{
			this.draggingWall = false;
			if (!this.wallWasValid)
			{
				this.clearPlacementWallSprites();
				return;
			}
			if (!this.inBuilderMode)
			{
				this.startBuilderMode();
			}
			if (this.placementType == 36)
			{
				GameEngine.Instance.playInterfaceSound("CastleMap_EndPit");
			}
			else if (this.placementType == 35)
			{
				GameEngine.Instance.playInterfaceSound("CastleMap_EndMoat");
			}
			else if (this.placementType == 34 || this.placementType == 65)
			{
				GameEngine.Instance.playInterfaceSound("CastleMap_EndStoneWall");
			}
			else if (this.placementType == 33 || this.placementType == 66)
			{
				GameEngine.Instance.playInterfaceSound("CastleMap_EndWoodWall");
			}
			this.addWallSprites();
			InterfaceMgr.Instance.castleStartBuilderMode();
			this.wallWasValid = false;
		}

		// Token: 0x06000981 RID: 2433 RVA: 0x000C2060 File Offset: 0x000C0260
		public void wallMouseMove(int mapX, int mapY, bool leftDown)
		{
			this.correctPlacementType(this.placementType);
			if (leftDown && !this.waitingForWallReturn)
			{
				if (!this.draggingWall)
				{
					if (this.placementType == 36)
					{
						GameEngine.Instance.playInterfaceSound("CastleMap_StartPit");
					}
					else if (this.placementType == 35)
					{
						GameEngine.Instance.playInterfaceSound("CastleMap_StartMoat");
					}
					else if (this.placementType == 34 || this.placementType == 65)
					{
						GameEngine.Instance.playInterfaceSound("CastleMap_StartStoneWall");
					}
					else if (this.placementType == 33 || this.placementType == 66)
					{
						GameEngine.Instance.playInterfaceSound("CastleMap_StartWoodWall");
					}
					this.startWallMapX = mapX;
					this.startWallMapY = mapY;
					this.draggingWall = true;
					if (CastleMap.buildingPlacementSprite != null)
					{
						CastleMap.buildingPlacementSprite.Visible = false;
					}
				}
				this.clearPlacementWallSprites();
				this.addPlacementWallSprites(mapX, mapY, this.placementType);
				return;
			}
			if (!this.draggingWall)
			{
				this.movePlaceElement(mapX, mapY, CastleMap.buildingPlacementSprite, false, true);
				return;
			}
			this.finishWallPlacingGesture(mapX, mapY);
		}

		// Token: 0x06000982 RID: 2434 RVA: 0x000C216C File Offset: 0x000C036C
		private void addWallSprites()
		{
			CastleElement castleElement = null;
			this.correctPlacementType(this.placementType);
			if (this.placementType == 36 || this.placementType == 35 || this.placementType == 65 || this.placementType == 66)
			{
				int num = this.startWallMapX;
				int num2 = this.startWallMapY;
				int num3 = this.lastValidWallX;
				int num4 = this.lastValidWallY;
				if (num > num3)
				{
					int num5 = num;
					num = num3;
					num3 = num5;
				}
				if (num2 > num4)
				{
					int num6 = num2;
					num2 = num4;
					num4 = num6;
				}
				for (int i = num2; i <= num4; i++)
				{
					for (int j = num; j <= num3; j++)
					{
						if (this.testWallSprite(j, i, out castleElement) && castleElement != null)
						{
							this.addFakeWallSprite(j, i);
						}
					}
				}
				this.updateLayoutAndRedraw();
				this.clearPlacementWallSprites();
				return;
			}
			int num7 = this.startWallMapX;
			int num8 = this.startWallMapY;
			int num9 = this.lastValidWallX;
			int num10 = this.lastValidWallY;
			int num11 = 0;
			int num12 = 0;
			if (num7 > num9)
			{
				num11 = -1;
			}
			else if (num7 < num9)
			{
				num11 = 1;
			}
			if (num8 > num10)
			{
				num12 = -1;
			}
			else if (num8 < num10)
			{
				num12 = 1;
			}
			num7 = this.startWallMapX;
			num8 = this.startWallMapY;
			if (this.testWallSprite(num7, num8, out castleElement) && castleElement != null)
			{
				this.addFakeWallSprite(num7, num8);
			}
			while (num7 != num9 || num8 != num10)
			{
				if (num7 != num9)
				{
					num7 += num11;
				}
				if (num8 != num10)
				{
					num8 += num12;
				}
				if (this.testWallSprite(num7, num8, out castleElement) && castleElement != null)
				{
					this.addFakeWallSprite(num7, num8);
				}
			}
			UniversalDebugLog.Log(string.Concat(new string[]
			{
				"placing line = ",
				this.elements.Count.ToString(),
				" ",
				num7.ToString(),
				",",
				num8.ToString(),
				" to ",
				num9.ToString(),
				",",
				num10.ToString()
			}));
			this.updateLayoutAndRedraw();
			this.clearPlacementWallSprites();
		}

		// Token: 0x06000983 RID: 2435 RVA: 0x000C2368 File Offset: 0x000C0568
		private void addPlacementWallSprites(int mapX, int mapY, int placementType)
		{
			CastleElement castleElement = null;
			bool flag = false;
			int elementType = this.correctPlacementType(placementType);
			if (placementType == 36 || placementType == 35 || placementType == 65 || placementType == 66)
			{
				List<CastleElement> list = new List<CastleElement>();
				int num = this.startWallMapX;
				int num2 = this.startWallMapY;
				int num3 = mapX;
				int num4 = mapY;
				if (num > num3)
				{
					int num5 = num;
					num = num3;
					num3 = num5;
				}
				if (num2 > num4)
				{
					int num6 = num2;
					num2 = num4;
					num4 = num6;
				}
				for (int i = num2; i <= num4; i++)
				{
					for (int j = num; j <= num3; j++)
					{
						if (!this.testWallSprite(j, i, out castleElement))
						{
							flag = true;
						}
						else if (castleElement != null)
						{
							list.Add(castleElement);
						}
					}
				}
				if (this.castleLayout == null || this.castleLayout.isCastleEnclosed(null, list))
				{
					flag = true;
				}
				if (placementType == 35)
				{
					int num7 = this.countMoat();
					int count = list.Count;
					if (num7 + count > GameEngine.Instance.LocalWorldData.Castle_Max_Moat_Tiles)
					{
						flag = true;
					}
				}
				if (!flag)
				{
					int num8 = 0;
					int num9 = 0;
					int num10 = 0;
					int num11 = 0;
					int num12 = 0;
					if (!CastleMap.CreateMode)
					{
						CastlesCommon.getConstrCost(GameEngine.Instance.LocalWorldData, elementType, ref num8, ref num9, ref num10, ref num11, ref num12);
						num8 *= list.Count;
						num9 *= list.Count;
						num12 *= list.Count;
						num11 *= list.Count;
						num10 *= list.Count;
						VillageMap.StockpileLevels stockpileLevels = new VillageMap.StockpileLevels();
						if (GameEngine.Instance.Village != null)
						{
							GameEngine.Instance.Village.getStockpileLevels(stockpileLevels);
						}
						int num13 = 0;
						if (!GameEngine.Instance.World.isCapital(this.m_villageID))
						{
							num13 = (int)GameEngine.Instance.World.getCurrentGold();
						}
						else if (GameEngine.Instance.Village != null)
						{
							num13 = (int)GameEngine.Instance.Village.m_capitalGold;
						}
						this.adjustLevels(ref stockpileLevels, ref num13);
						if ((num8 <= 0 || (double)num8 > stockpileLevels.woodLevel) && (num9 <= 0 || (double)num9 > stockpileLevels.stoneLevel) && (num10 <= 0 || num10 > num13) && (num11 <= 0 || (double)num11 > stockpileLevels.pitchLevel) && (num12 <= 0 || (double)num12 > stockpileLevels.ironLevel))
						{
							flag = true;
						}
					}
				}
				this.wallWasValid = !flag;
				this.lastValidWallX = mapX;
				this.lastValidWallY = mapY;
				for (int k = num2; k <= num4; k++)
				{
					for (int l = num; l <= num3; l++)
					{
						this.addWallSprite(l, k, flag);
					}
				}
				return;
			}
			int num14 = this.startWallMapX;
			int num15 = this.startWallMapY;
			int num16 = 0;
			int num17 = 0;
			if (num14 > mapX)
			{
				num16 = -1;
			}
			else if (num14 < mapX)
			{
				num16 = 1;
			}
			if (num15 > mapY)
			{
				num17 = -1;
			}
			else if (num15 < mapY)
			{
				num17 = 1;
			}
			List<CastleElement> list2 = new List<CastleElement>();
			if (!this.testWallSprite(num14, num15, out castleElement))
			{
				flag = true;
			}
			else
			{
				if (castleElement != null)
				{
					list2.Add(castleElement);
				}
				while (num14 != mapX || num15 != mapY)
				{
					if (num14 != mapX)
					{
						num14 += num16;
					}
					if (num15 != mapY)
					{
						num15 += num17;
					}
					if (!this.testWallSprite(num14, num15, out castleElement))
					{
						flag = true;
						break;
					}
					if (castleElement != null)
					{
						list2.Add(castleElement);
					}
				}
			}
			if (this.castleLayout == null || this.castleLayout.isCastleEnclosed(null, list2))
			{
				flag = true;
			}
			if (!flag)
			{
				int num18 = 0;
				int num19 = 0;
				int num20 = 0;
				int num21 = 0;
				int num22 = 0;
				this.piecesBeingPlaced = list2.Count;
				if (!CastleMap.CreateMode)
				{
					CastlesCommon.getConstrCost(GameEngine.Instance.LocalWorldData, placementType, ref num18, ref num19, ref num20, ref num21, ref num22);
					num18 *= list2.Count;
					num19 *= list2.Count;
					VillageMap.StockpileLevels stockpileLevels2 = new VillageMap.StockpileLevels();
					if (GameEngine.Instance.Village != null)
					{
						GameEngine.Instance.Village.getStockpileLevels(stockpileLevels2);
					}
					int num23 = 0;
					this.adjustLevels(ref stockpileLevels2, ref num23);
					bool flag2 = num18 > 0 && (double)num18 <= stockpileLevels2.woodLevel;
					bool flag3 = num19 > 0 && (double)num19 <= stockpileLevels2.stoneLevel;
					if (!flag2 && !flag3)
					{
						flag = true;
					}
				}
			}
			this.wallWasValid = !flag;
			this.lastValidWallX = mapX;
			this.lastValidWallY = mapY;
			num14 = this.startWallMapX;
			num15 = this.startWallMapY;
			this.addWallSprite(num14, num15, flag);
			while (num14 != mapX || num15 != mapY)
			{
				if (num14 != mapX)
				{
					num14 += num16;
				}
				if (num15 != mapY)
				{
					num15 += num17;
				}
				this.addWallSprite(num14, num15, flag);
			}
		}

		// Token: 0x06000984 RID: 2436 RVA: 0x000C27C8 File Offset: 0x000C09C8
		public Rectangle GetBrushStrokeRect(int startX, int startY, int endX, int endY, CastleMap.BrushSize brushSize)
		{
			Rectangle result = default(Rectangle);
			if (startX > endX)
			{
				result.X = endX;
				result.Width = startX - endX;
			}
			else
			{
				result.X = startX;
				result.Width = endX - startX;
			}
			if (startY > endY)
			{
				result.Y = endY;
				result.Height = startY - endY;
			}
			else
			{
				result.Y = startY;
				result.Height = endY - startY;
			}
			if (brushSize != CastleMap.BrushSize.BRUSH_3X3)
			{
				if (brushSize == CastleMap.BrushSize.BRUSH_5X5)
				{
					result.X -= 2;
					result.Y -= 2;
					result.Width += 4;
					result.Height += 4;
				}
			}
			else
			{
				int num = result.X;
				result.X = num - 1;
				num = result.Y;
				result.Y = num - 1;
				result.Width += 2;
				result.Height += 2;
			}
			return result;
		}

		// Token: 0x06000985 RID: 2437 RVA: 0x000C28C0 File Offset: 0x000C0AC0
		private bool testWallSprite(int mapX, int mapY, out CastleElement tempElement)
		{
			CastleElement castleElement = new CastleElement();
			if (this.placementType == 66)
			{
				castleElement.elementType = 33;
			}
			else if (this.placementType == 65)
			{
				castleElement.elementType = 34;
			}
			else
			{
				castleElement.elementType = (byte)this.placementType;
			}
			castleElement.xPos = (byte)mapX;
			castleElement.yPos = (byte)mapY;
			tempElement = castleElement;
			if (!CastlesCommon.validatePlacement(castleElement))
			{
				tempElement = null;
				return true;
			}
			if (this.castleLayout != null && !this.castleLayout.testElement(castleElement))
			{
				tempElement = null;
				return true;
			}
			return true;
		}

		// Token: 0x06000986 RID: 2438 RVA: 0x000C2944 File Offset: 0x000C0B44
		private void clearPlacementTroopSprites()
		{
			for (int i = 0; i < 25; i++)
			{
				if (CastleMap.placementTroopCastleSprite[i] != null)
				{
					if (CastleMap.placementTroopSprite[i] != null)
					{
						CastleMap.placementTroopSprite[i].RemoveChild(CastleMap.placementTroopCastleSprite[i]);
					}
					CastleMap.placementTroopCastleSprite[i] = null;
				}
				if (CastleMap.placementTroopSprite[i] != null)
				{
					if (this.castleMapRendering.backgroundSprite != null)
					{
						this.castleMapRendering.backgroundSprite.RemoveChild(CastleMap.placementTroopSprite[i]);
					}
					CastleMap.placementTroopSprite[i] = null;
				}
			}
		}

		// Token: 0x06000987 RID: 2439 RVA: 0x000C29C0 File Offset: 0x000C0BC0
		private void clearPlacementWallSprites()
		{
			foreach (SpriteWrapper child in CastleMap.wallPlacementSprites)
			{
				this.castleMapRendering.backgroundSprite.RemoveChild(child);
			}
			CastleMap.wallPlacementSprites.Clear();
			this.nextWallCacheSpriteID = 0;
		}

		// Token: 0x06000988 RID: 2440 RVA: 0x000C2A30 File Offset: 0x000C0C30
		public void updateLasso(bool force)
		{
			if (this.m_lassoLastX == this.m_lassoEndX && this.m_lassoLastY == this.m_lassoEndY && !force)
			{
				return;
			}
			this.m_lassoLastX = this.m_lassoEndX;
			this.m_lassoLastY = this.m_lassoEndY;
			this.m_lassoElements.Clear();
			int num = this.m_lassoStartX;
			int num2 = this.m_lassoStartY;
			int num3 = this.m_lassoEndX;
			int num4 = this.m_lassoEndY;
			if (num > num3)
			{
				int num5 = num;
				num = num3;
				num3 = num5;
			}
			if (num2 > num4)
			{
				int num6 = num2;
				num2 = num4;
				num4 = num6;
			}
			if (!this.attackerSetupMode)
			{
				this.placingDefender = true;
				for (int i = num2; i < num4; i += 4)
				{
					for (int j = num; j < num3; j += 4)
					{
						Point mapTile = this.Camera.ScreenSpaceToMapTile(new Point(j, i));
						if (this.isValidMapTile(mapTile))
						{
							CastleElement castleElement = this.castleLayout.getTroopElement(mapTile.X, mapTile.Y);
							if (castleElement == null && (CastleMap.CreateMode || this.inTroopPlacerMode))
							{
								castleElement = this.castleLayout.getTroopElementMover(mapTile.X, mapTile.Y);
							}
							if (castleElement != null && ((castleElement.elementType <= 75 && castleElement.elementType >= 69) || (castleElement.elementType <= 89 && castleElement.elementType >= 85)) && !this.m_lassoElements.Contains(castleElement.elementID))
							{
								if (castleElement.elementType != 75)
								{
									this.m_lassoElements.Insert(0, castleElement.elementID);
								}
								else
								{
									this.m_lassoElements.Add(castleElement.elementID);
								}
							}
						}
					}
				}
			}
			else
			{
				this.placingDefender = false;
				List<long> list = new List<long>();
				for (int k = num2; k < num4; k += 4)
				{
					for (int l = num; l < num3; l += 4)
					{
						Point mapTile2 = this.Camera.ScreenSpaceToMapTile(new Point(l, k));
						if (this.isValidMapTile(mapTile2))
						{
							CastleElement troopElementMover = this.castleLayout.getTroopElementMover(mapTile2.X, mapTile2.Y);
							if (troopElementMover != null)
							{
								if (troopElementMover.elementType == 94)
								{
									if (!list.Contains(troopElementMover.elementID))
									{
										list.Add(troopElementMover.elementID);
									}
								}
								else if (troopElementMover.elementType >= 90 && !this.m_lassoElements.Contains(troopElementMover.elementID))
								{
									this.m_lassoElements.Add(troopElementMover.elementID);
								}
							}
						}
					}
				}
				if (this.m_lassoElements.Count == 0 && list.Count > 0)
				{
					this.m_lassoElements = list;
				}
			}
			this.recalcCastleLayout();
		}

		// Token: 0x06000989 RID: 2441 RVA: 0x0000D79A File Offset: 0x0000B99A
		public void lassoElement(CastleElement element)
		{
			if (element != null && !this.m_lassoElements.Contains(element.elementID))
			{
				this.m_lassoElements.Add(element.elementID);
			}
		}

		// Token: 0x0600098A RID: 2442 RVA: 0x000C2CD4 File Offset: 0x000C0ED4
		public void lassoMade()
		{
			if (!this.attackerSetupMode)
			{
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				int num4 = 0;
				int num5 = 0;
				int num6 = 0;
				int num7 = 0;
				int num8 = 0;
				int num9 = 0;
				int num10 = 0;
				foreach (long elemID in this.m_lassoElements)
				{
					CastleElement elementFromElemID = this.castleLayout.getElementFromElemID(elemID);
					if (elementFromElemID != null)
					{
						if (elementFromElemID.aggressiveDefender)
						{
							byte elementType = elementFromElemID.elementType;
							switch (elementType)
							{
							case 70:
								num2++;
								break;
							case 71:
								num8++;
								break;
							case 72:
								num4++;
								break;
							case 73:
								num6++;
								break;
							default:
								if (elementType == 85)
								{
									num10++;
								}
								break;
							}
						}
						else
						{
							byte elementType2 = elementFromElemID.elementType;
							switch (elementType2)
							{
							case 70:
								num++;
								break;
							case 71:
								num7++;
								break;
							case 72:
								num3++;
								break;
							case 73:
								num5++;
								break;
							default:
								if (elementType2 == 85)
								{
									num9++;
								}
								break;
							}
						}
					}
				}
				int peasantsState = 0;
				if (num2 > 0)
				{
					peasantsState = ((num <= 0) ? 1 : -1);
				}
				int archersState = 0;
				if (num4 > 0)
				{
					archersState = ((num3 <= 0) ? 1 : -1);
				}
				int pikemenState = 0;
				if (num6 > 0)
				{
					pikemenState = ((num5 <= 0) ? 1 : -1);
				}
				int swordsmenState = 0;
				if (num8 > 0)
				{
					swordsmenState = ((num7 <= 0) ? 1 : -1);
				}
				int captainState = 0;
				if (num10 > 0)
				{
					captainState = ((num9 <= 0) ? 1 : -1);
				}
				InterfaceMgr.Instance.castle_SetSelectedTroop(num + num2, peasantsState, num3 + num4, archersState, num5 + num6, pikemenState, num7 + num8, swordsmenState, num9 + num10, captainState);
				return;
			}
			int num11 = 0;
			int num12 = 0;
			int num13 = 0;
			int num14 = 0;
			int num15 = 0;
			int num16 = 0;
			int captainsCommand = 0;
			int captainsData = 0;
			foreach (long elemID2 in this.m_lassoElements)
			{
				CastleElement elementFromElemID2 = this.castleLayout.getElementFromElemID(elemID2);
				if (elementFromElemID2 != null)
				{
					switch (elementFromElemID2.elementType)
					{
					case 90:
						num11++;
						break;
					case 91:
						num14++;
						break;
					case 92:
						num12++;
						break;
					case 93:
						num13++;
						break;
					case 94:
						num15++;
						break;
					case 100:
					case 101:
					case 102:
					case 103:
					case 104:
					case 105:
					case 106:
					case 107:
						num16++;
						captainsCommand = (int)elementFromElemID2.elementType;
						if (num16 == 1)
						{
							captainsData = this.getCaptainsDetails(elementFromElemID2.elementID);
						}
						break;
					}
				}
			}
			InterfaceMgr.Instance.castleAttack_SetSelectedTroop(num11, num12, num13, num14, num15, num16, captainsCommand, captainsData);
		}

		// Token: 0x0600098B RID: 2443 RVA: 0x0000D7C3 File Offset: 0x0000B9C3
		public void clearLasso()
		{
			this.m_lassoElements.Clear();
			this.m_lassoMade = false;
			InterfaceMgr.Instance.castle_ClearSelectedTroop();
			this.recalcCastleLayout();
		}

		// Token: 0x0600098C RID: 2444 RVA: 0x0000D7E7 File Offset: 0x0000B9E7
		private bool matchDeleteTypeForCaptains(int type1, int type2)
		{
			return type1 == type2 || (type1 >= 100 && type1 <= 109 && type2 >= 100 && type2 <= 109);
		}

		// Token: 0x0600098D RID: 2445 RVA: 0x000C2FC0 File Offset: 0x000C11C0
		private void deleteLassoedDefenders(int troopType)
		{
			if (!this.InTroopPlacerMode)
			{
				this.startTroopPlacerMode();
			}
			List<long> list = new List<long>();
			foreach (long num in this.m_lassoElements)
			{
				CastleElement elementFromElemID = this.castleLayout.getElementFromElemID(num);
				if (elementFromElemID != null && (int)elementFromElemID.elementType == troopType)
				{
					if (elementFromElemID.elementID >= 0L)
					{
						list.Add(num);
					}
					this.elements.Remove(elementFromElemID);
					if (!CastleMap.CreateMode)
					{
						VillageMap village = GameEngine.Instance.Village;
						if (village != null)
						{
							byte elementType = elementFromElemID.elementType;
							switch (elementType)
							{
							case 70:
								if (elementFromElemID.vassalReinforcements)
								{
									village.addVassalTroops(1, 0, 0, 0);
								}
								else if (elementFromElemID.reinforcement)
								{
									this.numPlacedReinforceDefenderPeasants--;
								}
								else
								{
									village.addTroops(1, 0, 0, 0, 0);
								}
								break;
							case 71:
								if (elementFromElemID.vassalReinforcements)
								{
									village.addVassalTroops(0, 0, 0, 1);
								}
								else if (elementFromElemID.reinforcement)
								{
									this.numPlacedReinforceDefenderSwordsmen--;
								}
								else
								{
									village.addTroops(0, 0, 0, 1, 0);
								}
								break;
							case 72:
								if (elementFromElemID.vassalReinforcements)
								{
									village.addVassalTroops(0, 1, 0, 0);
								}
								else if (elementFromElemID.reinforcement)
								{
									this.numPlacedReinforceDefenderArchers--;
								}
								else
								{
									village.addTroops(0, 1, 0, 0, 0);
								}
								break;
							case 73:
								if (elementFromElemID.vassalReinforcements)
								{
									village.addVassalTroops(0, 0, 1, 0);
								}
								else if (elementFromElemID.reinforcement)
								{
									this.numPlacedReinforceDefenderPikemen--;
								}
								else
								{
									village.addTroops(0, 0, 1, 0, 0);
								}
								break;
							default:
								if (elementType == 85)
								{
									if (!elementFromElemID.vassalReinforcements && !elementFromElemID.reinforcement)
									{
										village.addTroops(0, 0, 0, 0, 0, 0, 1);
									}
								}
								break;
							}
						}
					}
				}
			}
			foreach (long elemID in list)
			{
				CastleElement elementFromElemID2 = this.castleLayout.getElementFromElemID(elemID);
				if (elementFromElemID2 != null && (int)elementFromElemID2.elementType == troopType)
				{
					if (elementFromElemID2.elementID >= 0L)
					{
						this.removedElements.Add(elementFromElemID2);
					}
					this.movedElements.Remove(elementFromElemID2);
				}
			}
			if (troopType == 70)
			{
				this.numAvailableDefenderPeasants = 0;
			}
			if (troopType == 72)
			{
				this.numAvailableDefenderArchers = 0;
			}
			if (troopType == 73)
			{
				this.numAvailableDefenderPikemen = 0;
			}
			if (troopType == 71)
			{
				this.numAvailableDefenderSwordsmen = 0;
			}
			if (troopType == 85)
			{
				this.numAvailableDefenderCaptains = 0;
			}
			VillageMap village2 = GameEngine.Instance.Village;
			if (village2 != null)
			{
				village2.getVillageTroops(ref this.numAvailableDefenderPeasants, ref this.numAvailableDefenderArchers, ref this.numAvailableDefenderPikemen, ref this.numAvailableDefenderSwordsmen, ref this.numAvailableDefenderCaptains);
				village2.getVillageVassalTroops(ref this.numAvailableVassalReinforceDefenderPeasants, ref this.numAvailableVassalReinforceDefenderArchers, ref this.numAvailableVassalReinforceDefenderPikemen, ref this.numAvailableVassalReinforceDefenderSwordsmen);
			}
			GameEngine.Instance.World.getReinforceTotals(village2.VillageID, ref this.numAvailableReinforceDefenderPeasants, ref this.numAvailableReinforceDefenderArchers, ref this.numAvailableReinforceDefenderPikemen, ref this.numAvailableReinforceDefenderSwordsmen);
			this.updateLayoutAndRedraw();
			this.updateLasso(true);
			if (this.m_lassoElements.Count > 0)
			{
				this.lassoMade();
			}
			else
			{
				this.clearLasso();
			}
			InterfaceMgr.Instance.castleStartBuilderMode();
		}

		// Token: 0x0600098E RID: 2446 RVA: 0x000C3360 File Offset: 0x000C1560
		private void deleteLassoedAttackers(int troopType)
		{
			foreach (long elemID in this.m_lassoElements)
			{
				CastleElement elementFromElemID = this.castleLayout.getElementFromElemID(elemID);
				if (elementFromElemID != null && this.matchDeleteTypeForCaptains((int)elementFromElemID.elementType, troopType))
				{
					this.elements.Remove(elementFromElemID);
					this.deleteCatapultTarget(elemID);
					this.deleteCaptainsDetails(elemID);
				}
			}
			this.updateLayoutAndRedraw();
			this.updateLasso(true);
			if (this.m_lassoElements.Count > 0)
			{
				this.lassoMade();
				return;
			}
			this.clearLasso();
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x0000D806 File Offset: 0x0000BA06
		public void lassoDelete(bool attacking, int troopType)
		{
			if (!attacking)
			{
				this.deleteLassoedDefenders(troopType);
				return;
			}
			this.deleteLassoedAttackers(troopType);
		}

		// Token: 0x06000990 RID: 2448 RVA: 0x000C3410 File Offset: 0x000C1610
		private CastleMap.TroopFacingDirection getTroopFacingDirectionFromMapPosition(bool defender, Point mapTile)
		{
			CastleMap.TroopFacingDirection result = (mapTile.X < mapTile.Y) ? ((117 - mapTile.X < mapTile.Y) ? CastleMap.TroopFacingDirection.LOOKING_SOUTHEAST : CastleMap.TroopFacingDirection.LOOKING_SOUTHWEST) : ((117 - mapTile.X >= mapTile.Y) ? CastleMap.TroopFacingDirection.LOOKING_NORTHWEST : CastleMap.TroopFacingDirection.LOOKING_NORTHEAST);
			if (defender)
			{
				return result;
			}
			switch (result)
			{
			case CastleMap.TroopFacingDirection.LOOKING_SOUTHEAST:
				return CastleMap.TroopFacingDirection.LOOKING_NORTHWEST;
			case CastleMap.TroopFacingDirection.LOOKING_SOUTHWEST:
				return CastleMap.TroopFacingDirection.LOOKING_NORTHEAST;
			case CastleMap.TroopFacingDirection.LOOKING_NORTHEAST:
				return CastleMap.TroopFacingDirection.LOOKING_SOUTHWEST;
			case CastleMap.TroopFacingDirection.LOOKING_NORTHWEST:
				return CastleMap.TroopFacingDirection.LOOKING_SOUTHEAST;
			default:
				throw new Exception("invalid direction type");
			}
		}

		// Token: 0x06000991 RID: 2449 RVA: 0x000C3490 File Offset: 0x000C1690
		private void layoutLassoTroopsAsSpiral(Point mapTile, List<Point> origPositions)
		{
			int i = 0;
			while (i < this.m_lassoElements.Count)
			{
				bool flag = false;
				int num = 1;
				int num2 = 1;
				for (int j = 1; j < 236; j += 2)
				{
					if (j > 1)
					{
						num = j * j - (j - 2) * (j - 2);
						num2 = num / 4;
					}
					for (int k = 0; k < num; k++)
					{
						int num3 = k;
						int mapX = 0;
						int mapY = 0;
						if (j == 1)
						{
							mapX = mapTile.X;
							mapY = mapTile.Y;
						}
						if (j > 1)
						{
							num3 += (j - 1) / 2;
							num3 %= num;
							int num4 = num3 / num2;
							int num5 = num3 % num2;
							switch (num4)
							{
							case 0:
								mapX = mapTile.X - (j - 1) / 2 + num5;
								mapY = mapTile.Y - (j - 1) / 2;
								break;
							case 1:
								mapX = mapTile.X + (j - 1) / 2;
								mapY = mapTile.Y - (j - 1) / 2 + num5;
								break;
							case 2:
								mapX = mapTile.X + (j - 1) / 2 - num5;
								mapY = mapTile.Y + (j - 1) / 2;
								break;
							case 3:
								mapX = mapTile.X - (j - 1) / 2;
								mapY = mapTile.Y + (j - 1) / 2 - num5;
								break;
							}
						}
						Point originalPosition = origPositions[i];
						if (this.tryMoveTroop(this.m_lassoElements[i], mapX, mapY, originalPosition))
						{
							flag = true;
							i++;
							if (i >= this.m_lassoElements.Count)
							{
								j = 10000;
								break;
							}
						}
					}
				}
				if (!flag)
				{
					i++;
				}
			}
		}

		// Token: 0x06000992 RID: 2450 RVA: 0x000C3640 File Offset: 0x000C1840
		public void aimElement(CastleElement element, Point mapTile)
		{
			foreach (CatapultTarget catapultTarget in this.catapultTargets)
			{
				if (element.elementID == catapultTarget.elemID)
				{
					catapultTarget.xPos = (byte)mapTile.X;
					catapultTarget.yPos = (byte)mapTile.Y;
					catapultTarget.validate(element, GameEngine.Instance.LocalWorldData.Castle_Catapult_MaxRange);
					if (!catapultTarget.valid)
					{
						catapultTarget.createDefaultLocation((int)element.xPos, (int)element.yPos, element);
						break;
					}
					break;
				}
			}
		}

		// Token: 0x06000993 RID: 2451 RVA: 0x000C36EC File Offset: 0x000C18EC
		public void clearElementAim(CastleElement element)
		{
			foreach (CatapultTarget catapultTarget in this.catapultTargets)
			{
				if (element.elementID == catapultTarget.elemID)
				{
					catapultTarget.createDefaultLocation((int)element.xPos, (int)element.yPos, element);
				}
			}
		}

		// Token: 0x06000994 RID: 2452 RVA: 0x000C375C File Offset: 0x000C195C
		public void moveLassoTroops(Point mousePos)
		{
			Point mapTile = this.Camera.ScreenSpaceToMapTile(mousePos);
			if (this.isValidMapTile(mapTile) && this.m_lassoElements.Count > 0)
			{
				if (this.attackerSetupMode)
				{
					this.placingDefender = false;
					if (this.isInsideDefenderArea(mapTile))
					{
						CastleElement elementFromElemID = this.castleLayout.getElementFromElemID(this.m_lassoElements[0]);
						if (elementFromElemID == null || !CastlesCommon.canBeAimed((int)elementFromElemID.elementType))
						{
							return;
						}
						for (int i = 0; i < this.m_lassoElements.Count; i++)
						{
							elementFromElemID = this.castleLayout.getElementFromElemID(this.m_lassoElements[i]);
							if (elementFromElemID != null)
							{
								this.aimElement(elementFromElemID, mapTile);
							}
						}
						this.recalcCastleLayout();
						return;
					}
				}
				else
				{
					this.placingDefender = true;
				}
				List<Point> list = new List<Point>();
				for (int j = 0; j < this.m_lassoElements.Count; j++)
				{
					CastleElement elementFromElemID2 = this.castleLayout.getElementFromElemID(this.m_lassoElements[j]);
					if (elementFromElemID2 != null)
					{
						list.Add(new Point((int)elementFromElemID2.xPos, (int)elementFromElemID2.yPos));
						elementFromElemID2.xPos = 1;
						elementFromElemID2.yPos = 1;
					}
					else
					{
						list.Add(new Point(0, 0));
					}
				}
				CastlesCommon.buildCastleLayoutClient(this.elements, ref this.castleLayout);
				this.layoutLassoTroopsAsSpiral(mapTile, list);
				for (int k = 0; k < this.m_lassoElements.Count; k++)
				{
					CastleElement elementFromElemID3 = this.castleLayout.getElementFromElemID(this.m_lassoElements[k]);
					if (elementFromElemID3 != null && elementFromElemID3.xPos == 1 && elementFromElemID3.yPos == 1)
					{
						elementFromElemID3.xPos = (byte)list[k].X;
						elementFromElemID3.yPos = (byte)list[k].Y;
					}
				}
				CastlesCommon.buildCastleLayoutClient(this.elements, ref this.castleLayout);
			}
			this.recalcCastleLayout();
		}

		// Token: 0x06000995 RID: 2453 RVA: 0x000C3940 File Offset: 0x000C1B40
		private bool tryMoveTroop(long elemID, int mapX, int mapY, Point originalPosition)
		{
			this.movingElement = this.castleLayout.getElementFromElemID(elemID);
			if (this.movingElement == null)
			{
				return false;
			}
			this.placementType = (int)this.movingElement.elementType;
			if (this.mouseMovePlaceTroops(mapX, mapY, false, -1) && this.movingElement.elementID == elemID)
			{
				if (!this.attackerSetupMode && !CastleMap.CreateMode)
				{
					if (!this.InTroopPlacerMode)
					{
						this.startTroopPlacerMode();
					}
					this.moveTroopLocal(this.movingElement, originalPosition);
				}
				this.movingElement.xPos = (byte)mapX;
				this.movingElement.yPos = (byte)mapY;
				if (this.movingElement.elementType == 94 || this.movingElement.elementType == 102 || this.movingElement.elementType == 103)
				{
					foreach (CatapultTarget catapultTarget in this.catapultTargets)
					{
						if (this.movingElement.elementID == catapultTarget.elemID)
						{
							catapultTarget.createDefaultLocation((int)this.movingElement.xPos, (int)this.movingElement.yPos, this.movingElement);
							break;
						}
					}
				}
				CastlesCommon.buildCastleLayoutClient(this.elements, ref this.castleLayout);
				InterfaceMgr.Instance.castleStartBuilderMode();
				return true;
			}
			return false;
		}

		// Token: 0x06000996 RID: 2454 RVA: 0x000C3AA0 File Offset: 0x000C1CA0
		public void drawLasso()
		{
			if (this.m_lassoLeftHeldDown && this.m_lassoStartX != this.m_lassoEndX && this.m_lassoStartY != this.m_lassoEndY)
			{
				this.castleMapRendering.gfx.startThickLine(global::ARGBColors.Black, 2f);
				this.castleMapRendering.gfx.setThickLineRadius(1f);
				this.castleMapRendering.gfx.addThickLinePoint((float)this.m_lassoStartX, (float)this.m_lassoStartY);
				this.castleMapRendering.gfx.addThickLinePoint((float)this.m_lassoEndX, (float)this.m_lassoStartY);
				this.castleMapRendering.gfx.addThickLinePoint((float)this.m_lassoEndX, (float)this.m_lassoEndY);
				this.castleMapRendering.gfx.addThickLinePoint((float)this.m_lassoStartX, (float)this.m_lassoEndY);
				this.castleMapRendering.gfx.drawThickLines(true);
			}
		}

		// Token: 0x06000997 RID: 2455 RVA: 0x000C3B94 File Offset: 0x000C1D94
		private void createDestroyPlacementTroopSprites()
		{
			int num = 1;
			if (this.CurrentBrushSize == CastleMap.BrushSize.BRUSH_3X3)
			{
				num = 9;
			}
			else if (this.CurrentBrushSize == CastleMap.BrushSize.BRUSH_5X5)
			{
				num = 25;
			}
			else if (this.CurrentBrushSize == CastleMap.BrushSize.BRUSH_1X5)
			{
				num = 5;
			}
			for (int i = 0; i < 25; i++)
			{
				if (i < num)
				{
					if (CastleMap.placementTroopSprite[i] == null)
					{
						PointF center = new PointF(50f, 66f);
						CastleMap.placementTroopSprite[i] = new SpriteWrapper();
						int placementType = this.placementType;
						switch (placementType)
						{
						case 70:
							if (!this.PlacingReinforcement)
							{
								CastleMap.placementTroopSprite[i].TextureID = GFXLibrary.Instance.PeasantAnimTexID;
							}
							else
							{
								CastleMap.placementTroopSprite[i].TextureID = GFXLibrary.Instance.PeasantGreenAnimTexID;
							}
							break;
						case 71:
							if (!this.PlacingReinforcement)
							{
								CastleMap.placementTroopSprite[i].TextureID = GFXLibrary.Instance.SwordsmanAnimTexID;
							}
							else
							{
								CastleMap.placementTroopSprite[i].TextureID = GFXLibrary.Instance.SwordsmanGreenAnimTexID;
							}
							break;
						case 72:
							if (!this.PlacingReinforcement)
							{
								CastleMap.placementTroopSprite[i].TextureID = GFXLibrary.Instance.ArcherAnimTexID;
							}
							else
							{
								CastleMap.placementTroopSprite[i].TextureID = GFXLibrary.Instance.ArcherGreenAnimTexID;
							}
							break;
						case 73:
							if (!this.PlacingReinforcement)
							{
								CastleMap.placementTroopSprite[i].TextureID = GFXLibrary.Instance.PikemanAnimTexID;
							}
							else
							{
								CastleMap.placementTroopSprite[i].TextureID = GFXLibrary.Instance.PikemanGreenAnimTexID;
							}
							break;
						case 74:
						case 76:
							goto IL_2F0;
						case 75:
							CastleMap.placementTroopSprite[i].TextureID = GFXLibrary.Instance.CastleSpritesTexID;
							CastleMap.placementTroopSprite[i].SpriteNo = 396;
							break;
						case 77:
							CastleMap.placementTroopSprite[i].TextureID = GFXLibrary.Instance.WolfAnimTexID;
							break;
						default:
							switch (placementType)
							{
							case 85:
								CastleMap.placementTroopSprite[i].TextureID = GFXLibrary.Instance.CaptainAnimTexID;
								break;
							case 86:
							case 87:
							case 88:
							case 89:
							case 91:
							case 95:
							case 96:
							case 97:
							case 98:
							case 99:
								goto IL_2F0;
							case 90:
								CastleMap.placementTroopSprite[i].TextureID = GFXLibrary.Instance.PeasantRedAnimTexID;
								center = new PointF(18f, 28f);
								break;
							case 92:
								CastleMap.placementTroopSprite[i].TextureID = GFXLibrary.Instance.ArcherRedAnimTexID;
								break;
							case 93:
								CastleMap.placementTroopSprite[i].TextureID = GFXLibrary.Instance.PikemanRedAnimTexID;
								break;
							case 94:
								CastleMap.placementTroopSprite[i].TextureID = GFXLibrary.Instance.CatapultAnimTexID;
								center = new PointF(93f, 100f);
								break;
							case 100:
							case 101:
							case 102:
							case 103:
							case 104:
							case 105:
							case 106:
							case 107:
								CastleMap.placementTroopSprite[i].TextureID = GFXLibrary.Instance.CaptainAnimRedTexID;
								break;
							default:
								goto IL_2F0;
							}
							break;
						}
						IL_306:
						CastleMap.placementTroopSprite[i].Initialize(this.castleMapRendering.gfx);
						CastleMap.placementTroopSprite[i].Center = center;
						this.castleMapRendering.backgroundSprite.AddChild(CastleMap.placementTroopSprite[i], 10);
						CastleMap.placementTroopCastleSprite[i] = new SpriteWrapper();
						CastleMap.placementTroopCastleSprite[i].TextureID = GFXLibrary.Instance.CastleSpritesTexID;
						CastleMap.placementTroopCastleSprite[i].SpriteNo = 36;
						CastleMap.placementTroopCastleSprite[i].Initialize(this.castleMapRendering.gfx);
						CastleMap.placementTroopCastleSprite[i].PosX = 0f;
						CastleMap.placementTroopCastleSprite[i].PosY = -50f;
						CastleMap.placementTroopCastleSprite[i].ColorToUse = Color.FromArgb(128, 255, 128);
						CastleMap.placementTroopCastleSprite[i].Visible = false;
						CastleMap.placementTroopSprite[i].AddChild(CastleMap.placementTroopCastleSprite[i], 1);
						goto IL_448;
						IL_2F0:
						CastleMap.placementTroopSprite[i].TextureID = GFXLibrary.Instance.SwordsmanRedAnimTexID;
						goto IL_306;
					}
				}
				else if (CastleMap.placementTroopSprite[i] != null)
				{
					if (CastleMap.placementTroopCastleSprite[i] != null)
					{
						CastleMap.placementTroopSprite[i].RemoveChild(CastleMap.placementTroopCastleSprite[i]);
						CastleMap.placementTroopCastleSprite[i] = null;
					}
					if (this.castleMapRendering.backgroundSprite != null)
					{
						this.castleMapRendering.backgroundSprite.RemoveChild(CastleMap.placementTroopSprite[i]);
					}
					CastleMap.placementTroopSprite[i] = null;
				}
				IL_448:;
			}
		}

		// Token: 0x06000998 RID: 2456 RVA: 0x000C3FF8 File Offset: 0x000C21F8
		public void startPlacingTroops(int type, bool reinforcement)
		{
			UniversalDebugLog.Log("Start placing troops type: " + type.ToString());
			if (type == 100 || type == 85 || type == 75)
			{
				this.CurrentBrushSize = CastleMap.BrushSize.BRUSH_1X1;
			}
			this.stopPlaceElement();
			this.placingElement = false;
			this.placementType = type;
			this.placingDefender = true;
			this.PlacingReinforcement = reinforcement;
			this.createDestroyPlacementTroopSprites();
			InterfaceMgr.Instance.toggleDXCardBarActive(false);
		}

		// Token: 0x06000999 RID: 2457 RVA: 0x000C4064 File Offset: 0x000C2264
		public TroopCount getRemainingPlaceableAttackers()
		{
			TroopCount troopCount = new TroopCount();
			troopCount.peasants = this.attackMaxPeasants - this.attackNumPeasants;
			troopCount.archers = this.attackMaxArchers - this.attackNumArchers;
			troopCount.pikemen = this.attackMaxPikemen - this.attackNumPikemen;
			troopCount.swordsmen = this.attackMaxSwordsmen - this.attackNumSwordsmen;
			troopCount.catapults = this.attackMaxCatapults - this.attackNumCatapults;
			troopCount.captains = this.attackMaxCaptains - this.attackNumCaptains;
			if (this.m_usingCastleTroopsOK)
			{
				troopCount.peasants += this.attackMaxPeasantsInCastle;
				troopCount.archers += this.attackMaxArchersInCastle;
				troopCount.pikemen += this.attackMaxPikemenInCastle;
				troopCount.swordsmen += this.attackMaxSwordsmenInCastle;
			}
			return troopCount;
		}

		// Token: 0x0600099A RID: 2458 RVA: 0x000C4140 File Offset: 0x000C2340
		public TroopCount getRemainingPlaceableDefenders()
		{
			TroopCount troopCount = new TroopCount();
			if (this.PlacingReinforcement)
			{
				troopCount.peasants = this.numAvailableReinforceDefenderPeasants + this.numAvailableVassalReinforceDefenderPeasants - this.numPlacedReinforceDefenderPeasants;
				troopCount.archers = this.numAvailableReinforceDefenderArchers + this.numAvailableVassalReinforceDefenderArchers - this.numPlacedReinforceDefenderArchers;
				troopCount.pikemen = this.numAvailableReinforceDefenderPikemen + this.numAvailableVassalReinforceDefenderPikemen - this.numPlacedReinforceDefenderPikemen;
				troopCount.swordsmen = this.numAvailableReinforceDefenderSwordsmen + this.numAvailableVassalReinforceDefenderSwordsmen - this.numPlacedReinforceDefenderSwordsmen;
				troopCount.captains = 0;
			}
			else
			{
				troopCount.peasants = this.numAvailableDefenderPeasants;
				troopCount.archers = this.numAvailableDefenderArchers;
				troopCount.pikemen = this.numAvailableDefenderPikemen;
				troopCount.swordsmen = this.numAvailableDefenderSwordsmen;
				troopCount.captains = this.numAvailableDefenderCaptains;
			}
			troopCount.catapults = 0;
			return troopCount;
		}

		// Token: 0x0600099B RID: 2459 RVA: 0x000C4210 File Offset: 0x000C2410
		public TroopCount getPlacedDefenders()
		{
			return new TroopCount
			{
				peasants = this.numPlacedDefenderPeasants + this.numPlacedReinforceDefenderPeasants + this.numPlacedVassalReinforceDefenderPeasants,
				archers = this.numPlacedDefenderArchers + this.numPlacedReinforceDefenderArchers + this.numPlacedVassalReinforceDefenderArchers,
				pikemen = this.numPlacedDefenderPikemen + this.numPlacedReinforceDefenderPikemen + this.numPlacedVassalReinforceDefenderPikemen,
				swordsmen = this.numPlacedDefenderSwordsmen + this.numPlacedReinforceDefenderSwordsmen + this.numPlacedVassalReinforceDefenderSwordsmen,
				captains = this.numPlacedDefenderCaptains,
				catapults = 0
			};
		}

		// Token: 0x0600099C RID: 2460 RVA: 0x000C42A0 File Offset: 0x000C24A0
		public TroopCount getPlacedAttackers()
		{
			return new TroopCount
			{
				peasants = this.attackNumPeasants,
				archers = this.attackNumArchers,
				pikemen = this.attackNumPikemen,
				swordsmen = this.attackNumSwordsmen,
				captains = this.attackNumCaptains,
				catapults = this.attackNumCatapults
			};
		}

		// Token: 0x0600099D RID: 2461 RVA: 0x000C42FC File Offset: 0x000C24FC
		public int getRemainingCurrentPlacingTroop()
		{
			TroopCount troopCount = (!this.placingDefender) ? this.getRemainingPlaceableAttackers() : this.getRemainingPlaceableDefenders();
			return troopCount.byUnitID(this.placementType);
		}

		// Token: 0x0600099E RID: 2462 RVA: 0x000C432C File Offset: 0x000C252C
		public bool hasAnyFreeTroopsToPlace()
		{
			TroopCount troopCount = (!this.placingDefender) ? this.getRemainingPlaceableAttackers() : this.getRemainingPlaceableDefenders();
			return troopCount.total > 0;
		}

		// Token: 0x0600099F RID: 2463 RVA: 0x000C435C File Offset: 0x000C255C
		public bool hasFreeTroopToPlace()
		{
			TroopCount troopCount = (!this.placingDefender) ? this.getRemainingPlaceableAttackers() : this.getRemainingPlaceableDefenders();
			switch (this.placementType)
			{
			case 70:
			case 90:
				return troopCount.peasants > 0;
			case 71:
			case 91:
				return troopCount.swordsmen > 0;
			case 72:
			case 92:
				return troopCount.archers > 0;
			case 73:
			case 93:
				return troopCount.pikemen > 0;
			case 74:
			case 94:
				return troopCount.catapults > 0;
			case 75:
			{
				int num = GameEngine.Instance.Castle.countPlacedOilPots();
				int num2 = GameEngine.Instance.LocalWorldData.castle_oilPerSmelter * GameEngine.Instance.Castle.countCompletedSmelters();
				return num < num2;
			}
			case 85:
			case 100:
			case 101:
			case 102:
			case 103:
			case 104:
			case 105:
			case 106:
			case 107:
				return troopCount.captains > 0;
			}
			return false;
		}

		// Token: 0x060009A0 RID: 2464 RVA: 0x000C449C File Offset: 0x000C269C
		public bool mouseMovePlaceTroops(int mapX, int mapY, bool placing, int spriteIndex)
		{
			Point point = new Point(mapX, mapY);
			SpriteWrapper spriteWrapper;
			SpriteWrapper spriteWrapper2;
			if (spriteIndex >= 0 && spriteIndex < CastleMap.placementTroopSprite.Length)
			{
				spriteWrapper = CastleMap.placementTroopSprite[spriteIndex];
				spriteWrapper2 = CastleMap.placementTroopCastleSprite[spriteIndex];
			}
			else
			{
				spriteWrapper = this.dummySprite;
				spriteWrapper2 = this.dummySprite;
			}
			if (spriteWrapper != null)
			{
				int num = point.X * 16 + point.Y * 16 - 922;
				int num2 = point.Y * 8 - point.X * 8 + 474;
				if (num < 0 || num2 < 0 || num >= 1904 || num2 >= 952)
				{
					spriteWrapper.Visible = false;
				}
				else
				{
					int num3 = (int)((!CastleMap.displayCollapsed && (!this.battleMode || !CastleMap.AlwaysCollapsedWallsInBattles)) ? this.castleLayout.fullHeightMap[mapX, mapY] : this.castleLayout.collapsedHeightMap[mapX, mapY]);
					spriteWrapper.Visible = true;
					spriteWrapper.PosX = (float)(num + 16);
					spriteWrapper.PosY = (float)(num2 + 8 - num3);
					if (this.placementType == 75)
					{
						spriteWrapper.Center = new PointF(18f, 28f);
					}
					else if (this.placementType == 94)
					{
						spriteWrapper.Center = new PointF(93f, 100f);
					}
					else if (this.placementType >= 100 && this.placementType <= 109)
					{
						spriteWrapper.Center = new PointF(65f, 82f);
					}
					else
					{
						spriteWrapper.Center = new PointF(50f, 66f);
					}
					CastleElement castleElement = this.castleLayout.getCastleElement(mapX, mapY);
					if (num3 > 0 && castleElement != null && (castleElement.elementType < 1 || castleElement.elementType > 10))
					{
						spriteWrapper2.Visible = true;
					}
					else
					{
						spriteWrapper2.Visible = false;
					}
					if (this.placingDefender)
					{
						bool flag = true;
						if (placing)
						{
							if (this.placementType == 75)
							{
								if (this.numPots >= this.numSmelterPlaces)
								{
									flag = false;
								}
							}
							else
							{
								int placementType = this.placementType;
								switch (placementType)
								{
								case 70:
									if (!this.PlacingReinforcement)
									{
										if (this.numAvailableDefenderPeasants == 0)
										{
											flag = false;
										}
									}
									else if (this.numPlacedReinforceDefenderPeasants >= this.numAvailableReinforceDefenderPeasants + this.numAvailableVassalReinforceDefenderPeasants)
									{
										flag = false;
									}
									break;
								case 71:
									if (!this.PlacingReinforcement)
									{
										if (this.numAvailableDefenderSwordsmen == 0)
										{
											flag = false;
										}
									}
									else if (this.numPlacedReinforceDefenderSwordsmen >= this.numAvailableReinforceDefenderSwordsmen + this.numAvailableVassalReinforceDefenderSwordsmen)
									{
										flag = false;
									}
									break;
								case 72:
									if (!this.PlacingReinforcement)
									{
										if (this.numAvailableDefenderArchers == 0)
										{
											flag = false;
										}
									}
									else if (this.numPlacedReinforceDefenderArchers >= this.numAvailableReinforceDefenderArchers + this.numAvailableVassalReinforceDefenderArchers)
									{
										flag = false;
									}
									break;
								case 73:
									if (!this.PlacingReinforcement)
									{
										if (this.numAvailableDefenderPikemen == 0)
										{
											flag = false;
										}
									}
									else if (this.numPlacedReinforceDefenderPikemen >= this.numAvailableReinforceDefenderPikemen + this.numAvailableVassalReinforceDefenderPikemen)
									{
										flag = false;
									}
									break;
								default:
									if (placementType == 85)
									{
										if (!this.PlacingReinforcement)
										{
											if (this.numAvailableDefenderCaptains == 0)
											{
												flag = false;
											}
										}
										else
										{
											flag = false;
										}
									}
									break;
								}
								if (this.numPlacedDefenderPeasants + this.numPlacedDefenderArchers + this.numPlacedDefenderPikemen + this.numPlacedDefenderSwordsmen + this.numPlacedDefenderCaptains + this.numPlacedReinforceDefenderPeasants + this.numPlacedReinforceDefenderArchers + this.numPlacedReinforceDefenderPikemen + this.numPlacedReinforceDefenderSwordsmen + this.numPlacedVassalReinforceDefenderPeasants + this.numPlacedVassalReinforceDefenderArchers + this.numPlacedVassalReinforceDefenderPikemen + this.numPlacedVassalReinforceDefenderSwordsmen >= this.numGuardHouseSpaces)
								{
									flag = false;
								}
								if (CastleMap.CreateMode)
								{
									flag = true;
								}
							}
						}
						if (!flag)
						{
							spriteWrapper.ColorToUse = Color.FromArgb(128, global::ARGBColors.Blue);
						}
						else if (!this.castleLayout.canPlaceDefenderHere(this.placementType, point.X, point.Y))
						{
							spriteWrapper.ColorToUse = Color.FromArgb(128, global::ARGBColors.Red);
						}
						else
						{
							if (this.placementType != 75 || !placing)
							{
								spriteWrapper.ColorToUse = global::ARGBColors.White;
								return true;
							}
							int num4 = 0;
							int num5 = 0;
							int num6 = 0;
							int num7 = 0;
							int num8 = 0;
							CastlesCommon.getConstrCost(GameEngine.Instance.LocalWorldData, this.placementType, ref num4, ref num5, ref num6, ref num7, ref num8);
							VillageMap.StockpileLevels stockpileLevels = new VillageMap.StockpileLevels();
							if (GameEngine.Instance.Village != null)
							{
								GameEngine.Instance.Village.getStockpileLevels(stockpileLevels);
							}
							int num9 = 0;
							this.adjustLevels(ref stockpileLevels, ref num9);
							if ((double)num7 <= stockpileLevels.pitchLevel)
							{
								spriteWrapper.ColorToUse = global::ARGBColors.White;
								return true;
							}
							spriteWrapper.ColorToUse = Color.FromArgb(128, global::ARGBColors.Red);
						}
					}
					else
					{
						int num10 = (point.X < point.Y) ? ((117 - point.X >= point.Y) ? 2 : 0) : ((117 - point.X >= point.Y) ? 4 : 6);
						spriteWrapper.SpriteNo = (num10 + 6 & 7);
						bool flag2 = true;
						if (this.placingAttackerRealMode && placing)
						{
							flag2 = this.hasFreeTroopToPlace();
							if (!flag2)
							{
								this.stopPlacementOnTroopModeSwap = true;
							}
						}
						if (this.castleLayout.map[point.X, point.Y] != 0)
						{
							flag2 = false;
						}
						if (!flag2)
						{
							spriteWrapper.ColorToUse = Color.FromArgb(128, global::ARGBColors.Blue);
						}
						else
						{
							if (this.castleLayout.canPlaceAttackerHere(this.placementType, point.X, point.Y, this.attackerSetupForest))
							{
								spriteWrapper.ColorToUse = global::ARGBColors.White;
								return true;
							}
							if (this.attackerSetupForest && point.Y < 33)
							{
								spriteWrapper.ColorToUse = Color.FromArgb(128, global::ARGBColors.Blue);
							}
							else
							{
								spriteWrapper.ColorToUse = Color.FromArgb(128, global::ARGBColors.Red);
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x060009A1 RID: 2465 RVA: 0x0000D81A File Offset: 0x0000BA1A
		public bool canPlaceAttacker(int mapX, int mapY)
		{
			return this.castleLayout.canPlaceAttackerHere(this.placementType, mapX, mapY, this.attackerSetupForest);
		}

		// Token: 0x060009A2 RID: 2466 RVA: 0x0000D835 File Offset: 0x0000BA35
		public bool canPlaceDefender(int mapX, int mapY)
		{
			return this.castleLayout.canPlaceDefenderHere(this.placementType, mapX, mapY);
		}

		// Token: 0x060009A3 RID: 2467 RVA: 0x000C4A50 File Offset: 0x000C2C50
		public bool checkNormalTroopsAvailable(int troopType)
		{
			switch (troopType)
			{
			case 90:
				if (this.attackNumPeasants >= this.attackMaxPeasants)
				{
					return false;
				}
				break;
			case 91:
				if (this.attackNumSwordsmen >= this.attackMaxSwordsmen)
				{
					return false;
				}
				break;
			case 92:
				if (this.attackNumArchers >= this.attackMaxArchers)
				{
					return false;
				}
				break;
			case 93:
				if (this.attackNumPikemen >= this.attackMaxPikemen)
				{
					return false;
				}
				break;
			}
			return true;
		}

		// Token: 0x060009A4 RID: 2468 RVA: 0x0000D84A File Offset: 0x0000BA4A
		public CastleElement troopPlaceDefender(int mapX, int mapY)
		{
			return this.troopPlaceDefender(mapX, mapY, false);
		}

		// Token: 0x060009A5 RID: 2469 RVA: 0x000C4ABC File Offset: 0x000C2CBC
		public CastleElement troopPlaceDefender(int mapX, int mapY, bool fastMode)
		{
			bool flag = false;
			if (!CastleMap.CreateMode)
			{
				if (this.PlacingReinforcement)
				{
					switch (this.placementType)
					{
					case 70:
						if (this.numPlacedReinforceDefenderPeasants >= this.numAvailableReinforceDefenderPeasants)
						{
							flag = true;
						}
						break;
					case 71:
						if (this.numPlacedReinforceDefenderSwordsmen >= this.numAvailableReinforceDefenderSwordsmen)
						{
							flag = true;
						}
						break;
					case 72:
						if (this.numPlacedReinforceDefenderArchers >= this.numAvailableReinforceDefenderArchers)
						{
							flag = true;
						}
						break;
					case 73:
						if (this.numPlacedReinforceDefenderPikemen >= this.numAvailableReinforceDefenderPikemen)
						{
							flag = true;
						}
						break;
					}
				}
				if (!this.inTroopPlacerMode)
				{
					this.startTroopPlacerMode();
				}
			}
			CastleElement castleElement = new CastleElement();
			castleElement.elementID = this.localTempElementNumber;
			this.localTempElementNumber -= 1L;
			castleElement.elementType = (byte)this.placementType;
			if (this.placementType == 71)
			{
				castleElement.aggressiveDefender = true;
			}
			castleElement.xPos = (byte)mapX;
			castleElement.yPos = (byte)mapY;
			if (!flag)
			{
				castleElement.reinforcement = this.PlacingReinforcement;
			}
			castleElement.vassalReinforcements = flag;
			GameEngine.Instance.playInterfaceSound("CastleMap_place_defender");
			this.elements.Add(castleElement);
			VillageMap village = GameEngine.Instance.Village;
			if (village != null)
			{
				int placementType = this.placementType;
				switch (placementType)
				{
				case 70:
					if (!this.PlacingReinforcement)
					{
						village.addTroops(-1, 0, 0, 0, 0);
					}
					else if (!flag)
					{
						this.numPlacedReinforceDefenderPeasants++;
					}
					else
					{
						village.addVassalTroops(-1, 0, 0, 0);
					}
					break;
				case 71:
					if (!this.PlacingReinforcement)
					{
						village.addTroops(0, 0, 0, -1, 0);
					}
					else if (!flag)
					{
						this.numPlacedReinforceDefenderSwordsmen++;
					}
					else
					{
						village.addVassalTroops(0, 0, 0, -1);
					}
					break;
				case 72:
					if (!this.PlacingReinforcement)
					{
						village.addTroops(0, -1, 0, 0, 0);
					}
					else if (!flag)
					{
						this.numPlacedReinforceDefenderArchers++;
					}
					else
					{
						village.addVassalTroops(0, -1, 0, 0);
					}
					break;
				case 73:
					if (!this.PlacingReinforcement)
					{
						village.addTroops(0, 0, -1, 0, 0);
					}
					else if (!flag)
					{
						this.numPlacedReinforceDefenderPikemen++;
					}
					else
					{
						village.addVassalTroops(0, 0, -1, 0);
					}
					break;
				default:
					if (placementType == 85)
					{
						village.addTroops(0, 0, 0, 0, 0, 0, -1);
					}
					break;
				}
				this.numAvailableDefenderPeasants = 0;
				this.numAvailableDefenderArchers = 0;
				this.numAvailableDefenderPikemen = 0;
				this.numAvailableDefenderSwordsmen = 0;
				this.numAvailableDefenderCaptains = 0;
				this.numAvailableDefenderCaptains = 0;
				village.getVillageTroops(ref this.numAvailableDefenderPeasants, ref this.numAvailableDefenderArchers, ref this.numAvailableDefenderPikemen, ref this.numAvailableDefenderSwordsmen, ref this.numAvailableDefenderCaptains);
				GameEngine.Instance.World.getReinforceTotals(village.VillageID, ref this.numAvailableReinforceDefenderPeasants, ref this.numAvailableReinforceDefenderArchers, ref this.numAvailableReinforceDefenderPikemen, ref this.numAvailableReinforceDefenderSwordsmen);
				village.getVillageVassalTroops(ref this.numAvailableVassalReinforceDefenderPeasants, ref this.numAvailableVassalReinforceDefenderArchers, ref this.numAvailableVassalReinforceDefenderPikemen, ref this.numAvailableVassalReinforceDefenderSwordsmen);
			}
			if (!fastMode)
			{
				this.updateLayoutAndRedraw();
				InterfaceMgr.Instance.castleStartBuilderMode();
			}
			if (this.OnTroopPlaced != null)
			{
				this.OnTroopPlaced(castleElement);
			}
			return castleElement;
		}

		// Token: 0x060009A6 RID: 2470 RVA: 0x0000D855 File Offset: 0x0000BA55
		public void startDefenderTroopMove()
		{
			this.stopPlaceElement();
			this.deletingHighlightElementID = -2L;
			this.placingDefender = true;
			this.troopMovingMode = true;
			this.troopMovingElemID = -2L;
		}

		// Token: 0x060009A7 RID: 2471 RVA: 0x000C4DC0 File Offset: 0x000C2FC0
		public void dragTroopPlacer(Point mousePos)
		{
			Point point = this.Camera.ScreenSpaceToMapTile(mousePos);
			this.troopsFollowMouse(point.X, point.Y);
		}

		// Token: 0x060009A8 RID: 2472 RVA: 0x000C4DF0 File Offset: 0x000C2FF0
		public bool updateTroopMove(Point mousePos, bool leftDown)
		{
			if (!leftDown)
			{
				UniversalDebugLog.Log("updatedTroopMove " + this.troopMovingElemID.ToString());
				if (this.troopMovingElemID == -2L)
				{
					return false;
				}
				Point mapTile = this.Camera.ScreenSpaceToMapTile(mousePos);
				if (this.isValidMapTile(mapTile) && this.mouseMovePlaceTroops(mapTile.X, mapTile.Y, false, 0))
				{
					foreach (CastleElement castleElement in this.elements)
					{
						if (castleElement.elementID == this.troopMovingElemID)
						{
							if (this.placingDefender && !CastleMap.CreateMode)
							{
								RemoteServices.Instance.set_AddCastleElement_UserCallBack(new RemoteServices.AddCastleElement_UserCallBack(this.newElementCallback));
								RemoteServices.Instance.AddCastleElement(this.m_villageID, (int)castleElement.elementType, mapTile.X, mapTile.Y, this.troopMovingElemID);
							}
							castleElement.xPos = (byte)mapTile.X;
							castleElement.yPos = (byte)mapTile.Y;
							this.updateLayoutAndRedraw();
							break;
						}
					}
				}
				this.troopMovingElemID = -2L;
				if (CastleMap.placementTroopCastleSprite[0] != null)
				{
					if (CastleMap.placementTroopSprite[0] != null)
					{
						CastleMap.placementTroopSprite[0].RemoveChild(CastleMap.placementTroopCastleSprite[0]);
					}
					CastleMap.placementTroopCastleSprite[0] = null;
				}
				if (CastleMap.placementTroopSprite[0] != null)
				{
					if (this.castleMapRendering.backgroundSprite != null)
					{
						this.castleMapRendering.backgroundSprite.RemoveChild(CastleMap.placementTroopSprite[0]);
					}
					CastleMap.placementTroopSprite[0] = null;
				}
				this.recalcCastleLayout();
				return true;
			}
			else
			{
				if (this.troopMovingElemID == -2L)
				{
					Point mousePos2 = this.Camera.ScreenToWorldSpace(mousePos);
					long num = this.clickFindTroop(mousePos2);
					if (num != -2L)
					{
						foreach (CastleElement castleElement2 in this.elements)
						{
							if (castleElement2.elementID == num)
							{
								this.troopMovingMode = false;
								if (this.placingDefender)
								{
									this.startPlacingTroops((int)castleElement2.elementType, castleElement2.reinforcement);
								}
								else
								{
									this.CurrentBrushSize = CastleMap.BrushSize.BRUSH_1X1;
									this.startPlacingAttackerTroops((int)castleElement2.elementType);
								}
								CursorManager.SetCursor(CursorManager.CursorType.VSplit, InterfaceMgr.Instance.ParentForm);
								this.troopMovingMode = true;
								this.troopMovingElemID = num;
								this.recalcCastleLayout();
								return true;
							}
						}
						return false;
					}
					return false;
				}
				Point mapTile2 = this.Camera.ScreenSpaceToMapTile(mousePos);
				if (this.isValidMapTile(mapTile2))
				{
					this.mouseMovePlaceTroops(mapTile2.X, mapTile2.Y, false, 0);
				}
				return true;
			}
		}

		// Token: 0x060009A9 RID: 2473 RVA: 0x0000D87D File Offset: 0x0000BA7D
		public void deleteTroopsFromSelection(int troopType)
		{
			if (this.m_lassoMade)
			{
				this.lassoDelete(false, troopType);
			}
		}

		// Token: 0x060009AA RID: 2474 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void toggleDeleteBrush(bool enabled)
		{
		}

		// Token: 0x060009AB RID: 2475 RVA: 0x000C50A8 File Offset: 0x000C32A8
		public void deleteTroops(Point mousePos)
		{
			Point mousePos2 = this.Camera.ScreenToWorldSpace(mousePos);
			if (this.placingDefender)
			{
				if (GameEngine.Instance.World.WorldEnded)
				{
					return;
				}
				long num = this.clickFindTroop(mousePos2);
				UniversalDebugLog.Log("defender trydelete " + num.ToString());
				if (num < 0L && (!CastleMap.CreateMode || num == -2L))
				{
					return;
				}
				if (!CastleMap.CreateMode)
				{
					RemoteServices.Instance.set_DeleteCastleElement_UserCallBack(new RemoteServices.DeleteCastleElement_UserCallBack(this.DeleteElementCallback));
					RemoteServices.Instance.DeleteCastleElement(this.m_villageID, num);
				}
				using (List<CastleElement>.Enumerator enumerator = this.elements.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						CastleElement castleElement = enumerator.Current;
						if (castleElement.elementID == num)
						{
							this.elements.Remove(castleElement);
							VillageMap village = GameEngine.Instance.Village;
							if (village != null)
							{
								switch (castleElement.elementType)
								{
								case 70:
									village.addTroops(-1, 0, 0, 0, 0);
									break;
								case 71:
									village.addTroops(0, 0, 0, -1, 0);
									break;
								case 72:
									village.addTroops(0, -1, 0, 0, 0);
									break;
								case 73:
									village.addTroops(0, 0, -1, 0, 0);
									break;
								}
								this.numAvailableDefenderPeasants = 0;
								this.numAvailableDefenderArchers = 0;
								this.numAvailableDefenderPikemen = 0;
								this.numAvailableDefenderSwordsmen = 0;
								this.numAvailableDefenderCaptains = 0;
								village.getVillageTroops(ref this.numAvailableDefenderPeasants, ref this.numAvailableDefenderArchers, ref this.numAvailableDefenderPikemen, ref this.numAvailableDefenderSwordsmen, ref this.numAvailableDefenderCaptains);
								GameEngine.Instance.World.getReinforceTotals(village.VillageID, ref this.numAvailableReinforceDefenderPeasants, ref this.numAvailableReinforceDefenderArchers, ref this.numAvailableReinforceDefenderPikemen, ref this.numAvailableReinforceDefenderSwordsmen);
								village.getVillageVassalTroops(ref this.numAvailableVassalReinforceDefenderPeasants, ref this.numAvailableVassalReinforceDefenderArchers, ref this.numAvailableVassalReinforceDefenderPikemen, ref this.numAvailableVassalReinforceDefenderSwordsmen);
							}
							this.updateLayoutAndRedraw();
							CursorManager.SetCursor(CursorManager.CursorType.Cross, InterfaceMgr.Instance.ParentForm);
							break;
						}
					}
					return;
				}
			}
			long num2 = this.clickFindTroop(mousePos2);
			UniversalDebugLog.Log("attacker trydelete " + num2.ToString());
			if (num2 < -2L)
			{
				foreach (CastleElement castleElement2 in this.elements)
				{
					if (castleElement2.elementID == num2)
					{
						this.elements.Remove(castleElement2);
						this.deleteCatapultTarget(castleElement2.elementID);
						this.deleteCaptainsDetails(castleElement2.elementID);
						CursorManager.SetCursor(CursorManager.CursorType.Cross, InterfaceMgr.Instance.ParentForm);
						this.updateLayoutAndRedraw();
						break;
					}
				}
			}
		}

		// Token: 0x060009AC RID: 2476 RVA: 0x000C5388 File Offset: 0x000C3588
		public Point getCenterOfTowerAtPosition(int mapX, int mapY)
		{
			if (this.castleLayout == null)
			{
				return new Point(mapX, mapY);
			}
			CastleElement castleElement = this.castleLayout.getCastleElement(mapX, mapY);
			if (castleElement == null)
			{
				return new Point(mapX, mapY);
			}
			return new Point((int)castleElement.xPos, (int)castleElement.yPos);
		}

		// Token: 0x060009AD RID: 2477 RVA: 0x000C53D0 File Offset: 0x000C35D0
		public int getElementTypeAtPositionIgnoreNonWalkable(int mapX, int mapY)
		{
			int num = -1;
			if (this.castleLayout != null)
			{
				CastleElement castleElement = this.castleLayout.getCastleElement(mapX, mapY);
				if (castleElement != null)
				{
					num = (int)castleElement.elementType;
					if (num == 33 || num == 36 || num == 35)
					{
						num = -1;
					}
				}
			}
			return num;
		}

		// Token: 0x060009AE RID: 2478 RVA: 0x000C5414 File Offset: 0x000C3614
		public long getTowerIDAtPosition(int mapX, int mapY)
		{
			if (this.castleLayout != null)
			{
				CastleElement castleElement = this.castleLayout.getCastleElement(mapX, mapY);
				if (castleElement != null && CastlesCommon.isTower((int)castleElement.elementType))
				{
					return castleElement.elementID;
				}
			}
			return -1L;
		}

		// Token: 0x060009AF RID: 2479 RVA: 0x000C5450 File Offset: 0x000C3650
		public int getElementTypeAtPosition(int mapX, int mapY)
		{
			int result = -1;
			if (this.castleLayout != null)
			{
				CastleElement castleElement = this.castleLayout.getCastleElement(mapX, mapY);
				if (castleElement != null)
				{
					result = (int)castleElement.elementType;
				}
			}
			return result;
		}

		// Token: 0x060009B0 RID: 2480 RVA: 0x000C5480 File Offset: 0x000C3680
		public void retrieveArmyFromGarrison()
		{
			List<CastleElement> list = new List<CastleElement>();
			foreach (CastleElement castleElement in this.elements)
			{
				if (castleElement.elementType >= 70 && castleElement.elementType <= 71)
				{
					list.Add(castleElement);
				}
			}
			foreach (CastleElement item in list)
			{
				this.elements.Remove(item);
			}
			this.updateLayoutAndRedraw();
		}

		// Token: 0x060009B1 RID: 2481 RVA: 0x000C5538 File Offset: 0x000C3738
		public void clearAttackingTroops()
		{
			List<CastleElement> list = new List<CastleElement>();
			foreach (CastleElement castleElement in this.elements)
			{
				if (castleElement.elementType >= 90 && castleElement.elementType <= 94)
				{
					list.Add(castleElement);
				}
			}
			foreach (CastleElement castleElement2 in list)
			{
				this.elements.Remove(castleElement2);
				this.deleteCatapultTarget(castleElement2.elementID);
				this.deleteCaptainsDetails(castleElement2.elementID);
			}
			this.updateLayoutAndRedraw();
		}

		// Token: 0x060009B2 RID: 2482 RVA: 0x0000D88F File Offset: 0x0000BA8F
		public void autoRepairCastle()
		{
			RemoteServices.Instance.set_AutoRepairCastle_UserCallBack(new RemoteServices.AutoRepairCastle_UserCallBack(this.AutoRepairCastleCallback));
			RemoteServices.Instance.AutoRepairCastle(this.VillageID);
		}

		// Token: 0x060009B3 RID: 2483 RVA: 0x0000D8B7 File Offset: 0x0000BAB7
		public bool castleNeedsRepair()
		{
			return this.castleDamaged;
		}

		// Token: 0x060009B4 RID: 2484 RVA: 0x000C560C File Offset: 0x000C380C
		private long clickFindTroop(Point mousePos)
		{
			int num = -1000;
			long result = -2L;
			for (int i = 0; i < CastleMap.numClickAreas; i++)
			{
				CastleMap.TroopClickArea troopClickArea = CastleMap.troopClickAreas[i];
				if (troopClickArea.y > num && troopClickArea.clicked(mousePos))
				{
					num = troopClickArea.y;
					result = troopClickArea.elementID;
				}
			}
			return result;
		}

		// Token: 0x060009B5 RID: 2485 RVA: 0x000C5660 File Offset: 0x000C3860
		public CastleMap.TroopClickArea getNextClickArea()
		{
			CastleMap.TroopClickArea troopClickArea;
			if (CastleMap.numClickAreas < CastleMap.troopClickAreas.Count)
			{
				troopClickArea = CastleMap.troopClickAreas[CastleMap.numClickAreas];
				CastleMap.numClickAreas++;
			}
			else
			{
				troopClickArea = new CastleMap.TroopClickArea();
				CastleMap.troopClickAreas.Add(troopClickArea);
				CastleMap.numClickAreas = CastleMap.troopClickAreas.Count;
			}
			return troopClickArea;
		}

		// Token: 0x060009B6 RID: 2486 RVA: 0x000C56C0 File Offset: 0x000C38C0
		public void setTroopAggressiveMode(int troopType, bool state)
		{
			if (this.m_lassoMade)
			{
				List<long> list = new List<long>();
				foreach (long num in this.m_lassoElements)
				{
					CastleElement elementFromElemID = this.castleLayout.getElementFromElemID(num);
					if (elementFromElemID != null && elementFromElemID.aggressiveDefender != state && (int)elementFromElemID.elementType == troopType)
					{
						elementFromElemID.aggressiveDefender = state;
						if (!CastleMap.CreateMode)
						{
							list.Add(num);
						}
					}
				}
				if (list.Count > 0)
				{
					RemoteServices.Instance.ChangeCastleElementAggressiveDefender(this.m_villageID, list.ToArray(), state);
				}
				this.lassoMade();
			}
		}

		// Token: 0x060009B7 RID: 2487 RVA: 0x0000D8BF File Offset: 0x0000BABF
		public void setUsingCastleTroops(bool mode)
		{
			this.m_usingCastleTroopsOK = mode;
		}

		// Token: 0x060009B8 RID: 2488 RVA: 0x000C577C File Offset: 0x000C397C
		public void startPlacingAttackerTroops(int type)
		{
			InterfaceMgr.Instance.toggleDXCardBarActive(false);
			if (type == 100 || type == 85)
			{
				this.CurrentBrushSize = CastleMap.BrushSize.BRUSH_1X1;
			}
			this.stopPlaceElement();
			this.placingElement = false;
			this.placementType = type;
			this.placingDefender = false;
			this.createDestroyPlacementTroopSprites();
			InterfaceMgr.Instance.toggleDXCardBarActive(false);
		}

		// Token: 0x060009B9 RID: 2489 RVA: 0x0000D8C8 File Offset: 0x0000BAC8
		public void updateLayoutAndRedraw()
		{
			CastlesCommon.buildCastleLayoutClient(this.elements, ref this.castleLayout);
			this.recalcCastleLayout();
		}

		// Token: 0x060009BA RID: 2490 RVA: 0x000C57D4 File Offset: 0x000C39D4
		public CastleElement troopPlaceAttacker(int mapX, int mapY)
		{
			CastleElement castleElement = new CastleElement();
			castleElement.elementID = this.localTempElementNumber;
			this.localTempElementNumber -= 1L;
			castleElement.elementType = (byte)this.placementType;
			castleElement.xPos = (byte)mapX;
			castleElement.yPos = (byte)mapY;
			GameEngine.Instance.playInterfaceSound("CastleMap_place_attacker");
			this.elements.Add(castleElement);
			switch (this.placementType)
			{
			case 90:
				this.attackNumPeasants++;
				break;
			case 91:
				this.attackNumSwordsmen++;
				break;
			case 92:
				this.attackNumArchers++;
				break;
			case 93:
				this.attackNumPikemen++;
				break;
			case 94:
				this.addNewCatapultTargetDefault(castleElement);
				this.attackNumCatapults++;
				break;
			case 100:
			case 101:
			case 104:
			case 105:
			case 106:
			case 107:
				this.addNewCaptainDetails(castleElement);
				this.attackNumCaptains++;
				break;
			case 102:
			case 103:
				this.addNewCaptainDetails(castleElement);
				this.attackNumCaptains++;
				break;
			}
			if (this.OnTroopPlaced != null)
			{
				this.OnTroopPlaced(castleElement);
			}
			return castleElement;
		}

		// Token: 0x060009BB RID: 2491 RVA: 0x0000D8E1 File Offset: 0x0000BAE1
		public void startAttackerTroopMove()
		{
			this.stopPlaceElement();
			this.troopMovingMode = true;
			this.troopMovingElemID = -2L;
			this.placingDefender = false;
		}

		// Token: 0x060009BC RID: 2492 RVA: 0x0000D900 File Offset: 0x0000BB00
		public void startDeleteAttackingTroops(int troopType)
		{
			if (this.m_lassoMade)
			{
				this.lassoDelete(true, troopType);
			}
		}

		// Token: 0x060009BD RID: 2493 RVA: 0x000C5930 File Offset: 0x000C3B30
		public void updateAttackingCaptainCommand(int captainsCommand)
		{
			if (this.m_lassoMade && this.m_lassoElements.Count == 1)
			{
				foreach (long elemID in this.m_lassoElements)
				{
					CastleElement elementFromElemID = this.castleLayout.getElementFromElemID(elemID);
					if (elementFromElemID != null && elementFromElemID.elementType >= 100 && elementFromElemID.elementType <= 109)
					{
						if (elementFromElemID.elementType == 102 || elementFromElemID.elementType == 103)
						{
							this.deleteCatapultTarget(elemID);
							this.attackNumCatapults--;
						}
						elementFromElemID.elementType = (byte)captainsCommand;
						if (elementFromElemID.elementType == 102 || elementFromElemID.elementType == 103)
						{
							this.addNewCatapultTargetDefault(elementFromElemID);
							this.attackNumCatapults++;
						}
						this.updateLayoutAndRedraw();
						break;
					}
				}
			}
		}

		// Token: 0x060009BE RID: 2494 RVA: 0x000C5A24 File Offset: 0x000C3C24
		public void addCatapultTargetLine(int sx, int sy, int ex, int ey)
		{
			CastleMap.CatapultLine catapultLine = new CastleMap.CatapultLine();
			catapultLine.startX = sx;
			catapultLine.startY = sy;
			catapultLine.endX = ex;
			catapultLine.endY = ey;
			this.catapultLines.Add(catapultLine);
		}

		// Token: 0x060009BF RID: 2495 RVA: 0x0000D912 File Offset: 0x0000BB12
		public void clearCatapultLines()
		{
			this.catapultLines.Clear();
		}

		// Token: 0x060009C0 RID: 2496 RVA: 0x000C5A60 File Offset: 0x000C3C60
		public void drawCatapultLines()
		{
			foreach (CastleMap.CatapultLine line in this.catapultLines)
			{
				GameEngine.Instance.castleMapRendering.drawCatapultLine(line);
			}
		}

		// Token: 0x060009C1 RID: 2497 RVA: 0x000C5ABC File Offset: 0x000C3CBC
		public void regenerateDefaultCatapultTargets()
		{
			this.catapultTargets.Clear();
			foreach (CastleElement castleElement in this.elements)
			{
				if (castleElement.elementType == 94 || castleElement.elementType == 102 || castleElement.elementType == 103)
				{
					CatapultTarget catapultTarget = new CatapultTarget();
					catapultTarget.elemID = castleElement.elementID;
					catapultTarget.createDefaultLocation((int)castleElement.xPos, (int)castleElement.yPos, castleElement);
					this.catapultTargets.Add(catapultTarget);
				}
			}
		}

		// Token: 0x060009C2 RID: 2498 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void regenerateSelectedDefaultCatapultTargets()
		{
		}

		// Token: 0x060009C3 RID: 2499 RVA: 0x000C5B64 File Offset: 0x000C3D64
		public bool isOverCatapultTarget(int mapX, int mapY)
		{
			Size size = new Size(5, 5);
			Rectangle rectangle = new Rectangle(Point.Empty, size);
			foreach (CatapultTarget catapultTarget in this.catapultTargets)
			{
				rectangle.X = (int)catapultTarget.xPos - size.Width / 2;
				rectangle.Y = (int)catapultTarget.yPos - size.Height / 2;
				if (rectangle.Contains(mapX, mapY))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060009C4 RID: 2500 RVA: 0x000C5C08 File Offset: 0x000C3E08
		public void addNewCatapultTargetDefault(CastleElement element)
		{
			CatapultTarget catapultTarget = new CatapultTarget();
			catapultTarget.elemID = element.elementID;
			catapultTarget.createDefaultLocation((int)element.xPos, (int)element.yPos, element);
			this.catapultTargets.Add(catapultTarget);
		}

		// Token: 0x060009C5 RID: 2501 RVA: 0x000C5C48 File Offset: 0x000C3E48
		public void deleteCatapultTarget(long elemID)
		{
			foreach (CatapultTarget catapultTarget in this.catapultTargets)
			{
				if (catapultTarget.elemID == elemID)
				{
					this.catapultTargets.Remove(catapultTarget);
					break;
				}
			}
		}

		// Token: 0x060009C6 RID: 2502 RVA: 0x0000D91F File Offset: 0x0000BB1F
		public void startSetupCatapults()
		{
			this.stopPlaceElement();
		}

		// Token: 0x060009C7 RID: 2503 RVA: 0x0000D927 File Offset: 0x0000BB27
		public void showTargets(bool show)
		{
			this.showCatapultTargets = show;
			this.recalcCastleLayout();
		}

		// Token: 0x060009C8 RID: 2504 RVA: 0x000C5CAC File Offset: 0x000C3EAC
		private bool selectCatapult(int mapX, int mapY)
		{
			if (this.castleLayout.attackerMap[mapX, mapY] == 94)
			{
				long item = this.castleLayout.elemCatapultTroopMap[mapX, mapY];
				if (this.m_lassoMade)
				{
					if (!this.m_lassoElements.Contains(item))
					{
						this.m_lassoElements.Add(item);
					}
				}
				else
				{
					this.clearLasso();
					this.m_lassoMade = true;
					this.m_lassoElements.Add(item);
				}
				this.recalcCastleLayout();
				return true;
			}
			return false;
		}

		// Token: 0x060009C9 RID: 2505 RVA: 0x000C5D28 File Offset: 0x000C3F28
		private void mouseMoveCatapultTarget(int mapX, int mapY)
		{
			this.catapultTargetMoveX = mapX;
			this.catapultTargetMoveY = mapY;
			this.catapultTargetMoveValid = false;
			foreach (CastleElement castleElement in this.elements)
			{
				if (castleElement.elementID == this.selectedCatapult)
				{
					this.catapultTargetMoveValid = CatapultTarget.validateCatapultRange(castleElement, mapX, mapY, GameEngine.Instance.LocalWorldData.Castle_Catapult_MaxRange);
					break;
				}
			}
			this.recalcCastleLayout();
		}

		// Token: 0x060009CA RID: 2506 RVA: 0x000C5DBC File Offset: 0x000C3FBC
		public void addNewCaptainDetails(CastleElement element)
		{
			CaptainsDetails captainsDetails = new CaptainsDetails();
			captainsDetails.elemID = element.elementID;
			captainsDetails.seconds = 5;
			this.captainsDetails.Add(captainsDetails);
		}

		// Token: 0x060009CB RID: 2507 RVA: 0x000C5DF0 File Offset: 0x000C3FF0
		public void deleteCaptainsDetails(long elemID)
		{
			foreach (CaptainsDetails captainsDetails in this.captainsDetails)
			{
				if (captainsDetails.elemID == elemID)
				{
					this.captainsDetails.Remove(captainsDetails);
					break;
				}
			}
		}

		// Token: 0x060009CC RID: 2508 RVA: 0x000C5E54 File Offset: 0x000C4054
		public int getCaptainsDetails(long elemID)
		{
			foreach (CaptainsDetails captainsDetails in this.captainsDetails)
			{
				if (captainsDetails.elemID == elemID)
				{
					return (int)captainsDetails.seconds;
				}
			}
			return 0;
		}

		// Token: 0x060009CD RID: 2509 RVA: 0x000C5EB8 File Offset: 0x000C40B8
		public void setCaptainsDetails(long elemID, int value)
		{
			foreach (CaptainsDetails captainsDetails in this.captainsDetails)
			{
				if (captainsDetails.elemID == elemID)
				{
					captainsDetails.seconds = (byte)value;
				}
			}
		}

		// Token: 0x060009CE RID: 2510 RVA: 0x000C5F18 File Offset: 0x000C4118
		public void updateCaptainsDetails(int value)
		{
			if (this.m_lassoElements.Count == 1)
			{
				foreach (long elemID in this.m_lassoElements)
				{
					this.setCaptainsDetails(elemID, value);
				}
			}
		}

		// Token: 0x060009CF RID: 2511 RVA: 0x0000D936 File Offset: 0x0000BB36
		public bool isValidMapTile(Point mapTile)
		{
			return mapTile.X >= 0 && mapTile.X < 118 && mapTile.Y >= 0 && mapTile.Y < 118;
		}

		// Token: 0x060009D0 RID: 2512 RVA: 0x0000D965 File Offset: 0x0000BB65
		public void toggleHeight()
		{
			this.toggleHeight(CastleMap.displayCollapsed || (this.battleMode && CastleMap.AlwaysCollapsedWallsInBattles));
		}

		// Token: 0x060009D1 RID: 2513 RVA: 0x0000D987 File Offset: 0x0000BB87
		public void toggleHeight(bool high)
		{
			CastleMap.displayCollapsed = !high;
			this.recalcCastleLayout();
		}

		// Token: 0x060009D2 RID: 2514 RVA: 0x0000D998 File Offset: 0x0000BB98
		public void toggleDisplayMode()
		{
			this.displayType++;
			if (this.displayType > 2)
			{
				this.displayType = 0;
			}
			this.recalcCastleLayout();
		}

		// Token: 0x060009D3 RID: 2515 RVA: 0x0000D9BE File Offset: 0x0000BBBE
		public int getDisplayMode()
		{
			return this.displayType;
		}

		// Token: 0x060009D4 RID: 2516 RVA: 0x000C5F7C File Offset: 0x000C417C
		public void createSurroundSprites()
		{
			if (this.castleMapRendering.backgroundSprite == null)
			{
				return;
			}
			int viewportWidth = this.castleMapRendering.gfx.ViewportWidth;
			int viewportHeight = this.castleMapRendering.gfx.ViewportHeight;
			int num = (int)this.castleMapRendering.backgroundSprite.Width;
			int num2 = (int)this.castleMapRendering.backgroundSprite.Height;
			if (!this.attackerSetupMode && !this.battleMode)
			{
				int num3 = (viewportHeight - num2) / 2;
				int num4 = (viewportWidth - num) / 2;
				if (num3 < 0)
				{
					num3 = 0;
				}
				if (num4 < 0)
				{
					num4 = 0;
				}
				int num5 = viewportWidth;
				if (num4 > 0)
				{
					num5 = num4 + num;
				}
				CastleMap.enclosedOverlaySprite.Initialize(this.castleMapRendering.gfx, GFXLibrary.Instance.CastleSpritesTexID, 465);
				PointF center = new PointF(0f, 0f);
				CastleMap.enclosedOverlaySprite.Layer = 19;
				CastleMap.enclosedOverlaySprite.Center = center;
				CastleMap.enclosedOverlaySprite.PosX = (float)(num5 - 60);
				CastleMap.enclosedOverlaySprite.PosY = (float)num3;
				CastleMap.enclosedOverlaySprite.Update();
				CastleMap.enclosedOverlaySprite2.Initialize(this.castleMapRendering.gfx, GFXLibrary.Instance.CastleSpritesTexID, 465);
				CastleMap.enclosedOverlaySprite2.Layer = 19;
				CastleMap.enclosedOverlaySprite2.Center = center;
				CastleMap.enclosedOverlaySprite2.PosX = (float)(num5 - 60);
				CastleMap.enclosedOverlaySprite2.PosY = (float)num3;
				CastleMap.enclosedOverlaySprite2.Update();
				if (!GameEngine.Instance.World.isCapital(this.m_villageID))
				{
					bool flag = false;
					if (this.inBuilderMode)
					{
						flag = this.castleLayout.isCastleEnclosedGateHouseBlocking();
					}
					else
					{
						VillageMap village = GameEngine.Instance.Village;
						if (village != null)
						{
							flag = village.m_castleEnclosed;
						}
						else if (this.castleLayout != null)
						{
							flag = this.castleLayout.isCastleEnclosedGateHouseBlocking();
						}
					}
					if (flag)
					{
						CastleMap.enclosedOverlaySprite.Initialize(this.castleMapRendering.gfx, GFXLibrary.Instance.CastleSpritesTexID, 465);
					}
					else
					{
						CastleMap.enclosedOverlaySprite.Initialize(this.castleMapRendering.gfx, GFXLibrary.Instance.CastleSpritesTexID, 466);
						CastleMap.enclosedOverlaySprite2.Initialize(this.castleMapRendering.gfx, GFXLibrary.Instance.CastleSpritesTexID, 467);
					}
					this.m_castleEnclosed = flag;
				}
				CastleMap.tutorialOverlaySprite.Initialize(this.castleMapRendering.gfx, GFXLibrary.Instance.TutorialIconNormalID, 0);
				CastleMap.tutorialOverlaySprite.Layer = 19;
				CastleMap.tutorialOverlaySprite.Center = center;
				CastleMap.tutorialOverlaySprite.PosX = 0f;
				CastleMap.tutorialOverlaySprite.PosY = (float)(viewportHeight - 64);
				CastleMap.tutorialOverlaySprite.Update();
				CastleMap.wikiHelpSprite.Initialize(this.castleMapRendering.gfx, GFXLibrary.Instance.WikiHelpIconNormal, 0);
				CastleMap.wikiHelpSprite.Layer = 19;
				CastleMap.wikiHelpSprite.Center = new PointF(0f, 0f);
				CastleMap.wikiHelpSprite.PosX = (float)(viewportWidth - 31);
				CastleMap.wikiHelpSprite.PosY = (float)(num3 + 60);
				CastleMap.wikiHelpSprite.Scale = 0.66f;
				CastleMap.wikiHelpSprite.Update();
			}
			CastleMap.surroundsprites.Clear();
			int num6 = 17;
			if (num < viewportWidth && num2 < viewportHeight)
			{
				int num7 = (viewportHeight - num2) / 2;
				for (int i = num7; i > 0; i -= 512)
				{
					for (int j = 0; j < viewportWidth; j += 512)
					{
						SpriteWrapper spriteWrapper = new SpriteWrapper();
						spriteWrapper.TextureID = GFXLibrary.Instance.ImageSurroundTexID3;
						spriteWrapper.Initialize(this.castleMapRendering.gfx);
						spriteWrapper.Layer = num6;
						spriteWrapper.PosX = (float)j;
						spriteWrapper.PosY = (float)(i - 512);
						spriteWrapper.Update();
						CastleMap.surroundsprites.Add(spriteWrapper);
					}
				}
				for (int k = (viewportHeight - num2) / 2 + num2; k < viewportHeight; k += 512)
				{
					for (int l = 0; l < viewportWidth; l += 512)
					{
						SpriteWrapper spriteWrapper2 = new SpriteWrapper();
						spriteWrapper2.TextureID = GFXLibrary.Instance.ImageSurroundTexID3;
						spriteWrapper2.Initialize(this.castleMapRendering.gfx);
						spriteWrapper2.Layer = num6;
						spriteWrapper2.PosX = (float)l;
						spriteWrapper2.PosY = (float)k;
						spriteWrapper2.Update();
						CastleMap.surroundsprites.Add(spriteWrapper2);
					}
				}
				int num8 = (viewportWidth - num) / 2;
				for (int m = num8; m > 0; m -= 512)
				{
					for (int n = 0; n < viewportHeight; n += 512)
					{
						SpriteWrapper spriteWrapper3 = new SpriteWrapper();
						spriteWrapper3.TextureID = GFXLibrary.Instance.ImageSurroundTexID3;
						spriteWrapper3.Initialize(this.castleMapRendering.gfx);
						spriteWrapper3.Layer = num6;
						spriteWrapper3.PosX = (float)(m - 512);
						spriteWrapper3.PosY = (float)n;
						spriteWrapper3.Update();
						CastleMap.surroundsprites.Add(spriteWrapper3);
					}
				}
				for (int num9 = (viewportWidth - num) / 2 + num; num9 < viewportWidth; num9 += 512)
				{
					for (int num10 = 0; num10 < viewportHeight; num10 += 512)
					{
						SpriteWrapper spriteWrapper4 = new SpriteWrapper();
						spriteWrapper4.TextureID = GFXLibrary.Instance.ImageSurroundTexID3;
						spriteWrapper4.Initialize(this.castleMapRendering.gfx);
						spriteWrapper4.Layer = num6;
						spriteWrapper4.PosX = (float)num9;
						spriteWrapper4.PosY = (float)num10;
						spriteWrapper4.Update();
						CastleMap.surroundsprites.Add(spriteWrapper4);
					}
				}
				SpriteWrapper spriteWrapper5 = new SpriteWrapper();
				spriteWrapper5.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
				spriteWrapper5.Initialize(this.castleMapRendering.gfx);
				spriteWrapper5.Layer = num6 + 1;
				spriteWrapper5.PosX = (float)(num8 - 3);
				spriteWrapper5.PosY = (float)(num7 - 3);
				spriteWrapper5.Size = new Size(3, num2 + 6);
				spriteWrapper5.Update();
				CastleMap.surroundsprites.Add(spriteWrapper5);
				SpriteWrapper spriteWrapper6 = new SpriteWrapper();
				spriteWrapper6.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
				spriteWrapper6.Initialize(this.castleMapRendering.gfx);
				spriteWrapper6.Layer = num6 + 1;
				spriteWrapper6.PosX = (float)(num8 + num);
				spriteWrapper6.PosY = (float)num7;
				spriteWrapper6.Size = new Size(3, num2);
				spriteWrapper6.Update();
				CastleMap.surroundsprites.Add(spriteWrapper6);
				SpriteWrapper spriteWrapper7 = new SpriteWrapper();
				spriteWrapper7.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
				spriteWrapper7.Initialize(this.castleMapRendering.gfx);
				spriteWrapper7.Layer = num6 + 1;
				spriteWrapper7.PosX = (float)(num8 + num);
				spriteWrapper7.PosY = (float)(num7 + 3);
				spriteWrapper7.Size = new Size(6, num2);
				spriteWrapper7.Update();
				CastleMap.surroundsprites.Add(spriteWrapper7);
				SpriteWrapper spriteWrapper8 = new SpriteWrapper();
				spriteWrapper8.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
				spriteWrapper8.Initialize(this.castleMapRendering.gfx);
				spriteWrapper8.Layer = num6 + 1;
				spriteWrapper8.PosX = (float)(num8 + num);
				spriteWrapper8.PosY = (float)(num7 + 6);
				spriteWrapper8.Size = new Size(9, num2);
				spriteWrapper8.Update();
				CastleMap.surroundsprites.Add(spriteWrapper8);
				SpriteWrapper spriteWrapper9 = new SpriteWrapper();
				spriteWrapper9.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
				spriteWrapper9.Initialize(this.castleMapRendering.gfx);
				spriteWrapper9.Layer = num6 + 1;
				spriteWrapper9.PosX = (float)(num8 + num);
				spriteWrapper9.PosY = (float)(num7 + 9);
				spriteWrapper9.Size = new Size(14, num2);
				spriteWrapper9.Update();
				CastleMap.surroundsprites.Add(spriteWrapper9);
				SpriteWrapper spriteWrapper10 = new SpriteWrapper();
				spriteWrapper10.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
				spriteWrapper10.Initialize(this.castleMapRendering.gfx);
				spriteWrapper10.Layer = num6 + 1;
				spriteWrapper10.PosY = (float)(num7 - 3);
				spriteWrapper10.PosX = (float)num8;
				spriteWrapper10.Size = new Size(num, 3);
				spriteWrapper10.Update();
				CastleMap.surroundsprites.Add(spriteWrapper10);
				SpriteWrapper spriteWrapper11 = new SpriteWrapper();
				spriteWrapper11.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
				spriteWrapper11.Initialize(this.castleMapRendering.gfx);
				spriteWrapper11.Layer = num6 + 1;
				spriteWrapper11.PosY = (float)(num7 + num2);
				spriteWrapper11.PosX = (float)num8;
				spriteWrapper11.Size = new Size(num, 3);
				spriteWrapper11.Update();
				CastleMap.surroundsprites.Add(spriteWrapper11);
				SpriteWrapper spriteWrapper12 = new SpriteWrapper();
				spriteWrapper12.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
				spriteWrapper12.Initialize(this.castleMapRendering.gfx);
				spriteWrapper12.Layer = num6 + 1;
				spriteWrapper12.PosY = (float)(num7 + num2);
				spriteWrapper12.PosX = (float)(num8 + 3);
				spriteWrapper12.Size = new Size(num, 6);
				spriteWrapper12.Update();
				CastleMap.surroundsprites.Add(spriteWrapper12);
				SpriteWrapper spriteWrapper13 = new SpriteWrapper();
				spriteWrapper13.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
				spriteWrapper13.Initialize(this.castleMapRendering.gfx);
				spriteWrapper13.Layer = num6 + 1;
				spriteWrapper13.PosY = (float)(num7 + num2);
				spriteWrapper13.PosX = (float)(num8 + 6);
				spriteWrapper13.Size = new Size(num, 9);
				spriteWrapper13.Update();
				CastleMap.surroundsprites.Add(spriteWrapper13);
				SpriteWrapper spriteWrapper14 = new SpriteWrapper();
				spriteWrapper14.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
				spriteWrapper14.Initialize(this.castleMapRendering.gfx);
				spriteWrapper14.Layer = num6 + 1;
				spriteWrapper14.PosY = (float)(num7 + num2);
				spriteWrapper14.PosX = (float)(num8 + 9);
				spriteWrapper14.Size = new Size(num, 14);
				spriteWrapper14.Update();
				CastleMap.surroundsprites.Add(spriteWrapper14);
				return;
			}
			if (num < viewportWidth)
			{
				int num11 = (viewportWidth - num) / 2;
				int num12 = num11;
				while (num11 > 0)
				{
					for (int num13 = 0; num13 < viewportHeight; num13 += 512)
					{
						SpriteWrapper spriteWrapper15 = new SpriteWrapper();
						spriteWrapper15.TextureID = GFXLibrary.Instance.ImageSurroundTexID3;
						spriteWrapper15.Initialize(this.castleMapRendering.gfx);
						spriteWrapper15.Layer = num6;
						spriteWrapper15.PosX = (float)(num11 - 512);
						spriteWrapper15.PosY = (float)num13;
						spriteWrapper15.Update();
						CastleMap.surroundsprites.Add(spriteWrapper15);
					}
					num11 -= 512;
				}
				SpriteWrapper spriteWrapper16 = new SpriteWrapper();
				spriteWrapper16.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
				spriteWrapper16.Initialize(this.castleMapRendering.gfx);
				spriteWrapper16.Layer = num6 + 1;
				spriteWrapper16.PosX = (float)(num12 - 3);
				spriteWrapper16.PosY = 0f;
				spriteWrapper16.Size = new Size(3, num2);
				spriteWrapper16.Update();
				CastleMap.surroundsprites.Add(spriteWrapper16);
				for (num11 = (viewportWidth - num) / 2 + num; num11 < viewportWidth; num11 += 512)
				{
					for (int num14 = 0; num14 < viewportHeight; num14 += 512)
					{
						SpriteWrapper spriteWrapper17 = new SpriteWrapper();
						spriteWrapper17.TextureID = GFXLibrary.Instance.ImageSurroundTexID3;
						spriteWrapper17.Initialize(this.castleMapRendering.gfx);
						spriteWrapper17.Layer = num6;
						spriteWrapper17.PosX = (float)num11;
						spriteWrapper17.PosY = (float)num14;
						spriteWrapper17.Update();
						CastleMap.surroundsprites.Add(spriteWrapper17);
					}
				}
				SpriteWrapper spriteWrapper18 = new SpriteWrapper();
				spriteWrapper18.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
				spriteWrapper18.Initialize(this.castleMapRendering.gfx);
				spriteWrapper18.Layer = num6 + 1;
				spriteWrapper18.PosX = (float)(num12 + num);
				spriteWrapper18.PosY = 0f;
				spriteWrapper18.Size = new Size(3, num2);
				spriteWrapper18.Update();
				CastleMap.surroundsprites.Add(spriteWrapper18);
				SpriteWrapper spriteWrapper19 = new SpriteWrapper();
				spriteWrapper19.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
				spriteWrapper19.Initialize(this.castleMapRendering.gfx);
				spriteWrapper19.Layer = num6 + 1;
				spriteWrapper19.PosX = (float)(num12 + num);
				spriteWrapper19.PosY = 0f;
				spriteWrapper19.Size = new Size(6, num2);
				spriteWrapper19.Update();
				CastleMap.surroundsprites.Add(spriteWrapper19);
				SpriteWrapper spriteWrapper20 = new SpriteWrapper();
				spriteWrapper20.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
				spriteWrapper20.Initialize(this.castleMapRendering.gfx);
				spriteWrapper20.Layer = num6 + 1;
				spriteWrapper20.PosX = (float)(num12 + num);
				spriteWrapper20.PosY = 0f;
				spriteWrapper20.Size = new Size(9, num2);
				spriteWrapper20.Update();
				CastleMap.surroundsprites.Add(spriteWrapper20);
				SpriteWrapper spriteWrapper21 = new SpriteWrapper();
				spriteWrapper21.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
				spriteWrapper21.Initialize(this.castleMapRendering.gfx);
				spriteWrapper21.Layer = num6 + 1;
				spriteWrapper21.PosX = (float)(num12 + num);
				spriteWrapper21.PosY = 0f;
				spriteWrapper21.Size = new Size(14, num2);
				spriteWrapper21.Update();
				CastleMap.surroundsprites.Add(spriteWrapper21);
				return;
			}
			if (num2 >= viewportHeight)
			{
				return;
			}
			int num15 = (viewportHeight - num2) / 2;
			int num16 = num15;
			while (num15 > 0)
			{
				for (int num17 = 0; num17 < viewportWidth; num17 += 512)
				{
					SpriteWrapper spriteWrapper22 = new SpriteWrapper();
					spriteWrapper22.TextureID = GFXLibrary.Instance.ImageSurroundTexID3;
					spriteWrapper22.Initialize(this.castleMapRendering.gfx);
					spriteWrapper22.Layer = num6;
					spriteWrapper22.PosX = (float)num17;
					spriteWrapper22.PosY = (float)(num15 - 512);
					spriteWrapper22.Update();
					CastleMap.surroundsprites.Add(spriteWrapper22);
				}
				num15 -= 512;
			}
			SpriteWrapper spriteWrapper23 = new SpriteWrapper();
			spriteWrapper23.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
			spriteWrapper23.Initialize(this.castleMapRendering.gfx);
			spriteWrapper23.Layer = num6 + 1;
			spriteWrapper23.PosY = (float)(num16 - 3);
			spriteWrapper23.PosX = 0f;
			spriteWrapper23.Size = new Size(num, 3);
			spriteWrapper23.Update();
			CastleMap.surroundsprites.Add(spriteWrapper23);
			for (num15 = (viewportHeight - num2) / 2 + num2; num15 < viewportHeight; num15 += 512)
			{
				for (int num18 = 0; num18 < viewportWidth; num18 += 512)
				{
					SpriteWrapper spriteWrapper24 = new SpriteWrapper();
					spriteWrapper24.TextureID = GFXLibrary.Instance.ImageSurroundTexID3;
					spriteWrapper24.Initialize(this.castleMapRendering.gfx);
					spriteWrapper24.Layer = num6;
					spriteWrapper24.PosX = (float)num18;
					spriteWrapper24.PosY = (float)num15;
					spriteWrapper24.Update();
					CastleMap.surroundsprites.Add(spriteWrapper24);
				}
			}
			SpriteWrapper spriteWrapper25 = new SpriteWrapper();
			spriteWrapper25.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
			spriteWrapper25.Initialize(this.castleMapRendering.gfx);
			spriteWrapper25.Layer = num6 + 1;
			spriteWrapper25.PosY = (float)(num16 + num2);
			spriteWrapper25.PosX = 0f;
			spriteWrapper25.Size = new Size(num, 3);
			spriteWrapper25.Update();
			CastleMap.surroundsprites.Add(spriteWrapper25);
			SpriteWrapper spriteWrapper26 = new SpriteWrapper();
			spriteWrapper26.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
			spriteWrapper26.Initialize(this.castleMapRendering.gfx);
			spriteWrapper26.Layer = num6 + 1;
			spriteWrapper26.PosY = (float)(num16 + num2);
			spriteWrapper26.PosX = 0f;
			spriteWrapper26.Size = new Size(num, 6);
			spriteWrapper26.Update();
			CastleMap.surroundsprites.Add(spriteWrapper26);
			SpriteWrapper spriteWrapper27 = new SpriteWrapper();
			spriteWrapper27.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
			spriteWrapper27.Initialize(this.castleMapRendering.gfx);
			spriteWrapper27.Layer = num6 + 1;
			spriteWrapper27.PosY = (float)(num16 + num2);
			spriteWrapper27.PosX = 0f;
			spriteWrapper27.Size = new Size(num, 9);
			spriteWrapper27.Update();
			CastleMap.surroundsprites.Add(spriteWrapper27);
			SpriteWrapper spriteWrapper28 = new SpriteWrapper();
			spriteWrapper28.TextureID = GFXLibrary.Instance.ImageSurroundShadowTexID;
			spriteWrapper28.Initialize(this.castleMapRendering.gfx);
			spriteWrapper28.Layer = num6 + 1;
			spriteWrapper28.PosY = (float)(num16 + num2);
			spriteWrapper28.PosX = 0f;
			spriteWrapper28.Size = new Size(num, 14);
			spriteWrapper28.Update();
			CastleMap.surroundsprites.Add(spriteWrapper28);
		}

		// Token: 0x060009D5 RID: 2517 RVA: 0x000C704C File Offset: 0x000C524C
		private void drawSurroundSprites()
		{
			foreach (SpriteWrapper spriteWrapper in CastleMap.surroundsprites)
			{
				spriteWrapper.AddToRenderList();
			}
			if (this.attackerSetupMode || this.battleMode)
			{
				return;
			}
			CastleMap.enclosedOverlaySprite.AddToRenderList();
			if (!this.m_castleEnclosed)
			{
				CastleMap.enclosedOverlaySprite2.AddToRenderList();
				this.enclosedGlow += 16;
				if (this.enclosedGlow >= 512)
				{
					this.enclosedGlow = 0;
				}
				int num = this.enclosedGlow;
				if (num >= 256)
				{
					num = 511 - num;
				}
				CastleMap.enclosedOverlaySprite2.ColorToUse = Color.FromArgb(num, global::ARGBColors.White);
			}
			if (GameEngine.Instance.World.isTutorialActive())
			{
				if (!TutorialWindow.overIcon)
				{
					CastleMap.tutorialOverlaySprite.TextureID = GFXLibrary.Instance.TutorialIconNormalID;
				}
				else
				{
					CastleMap.tutorialOverlaySprite.TextureID = GFXLibrary.Instance.TutorialIconOverID;
				}
				CastleMap.tutorialOverlaySprite.AddToRenderList();
			}
			if (!this.overWikiHelp)
			{
				CastleMap.wikiHelpSprite.TextureID = GFXLibrary.Instance.WikiHelpIconNormal;
			}
			else
			{
				CastleMap.wikiHelpSprite.TextureID = GFXLibrary.Instance.WikiHelpIconOver;
			}
			CastleMap.wikiHelpSprite.Scale = 0.66f;
			CastleMap.wikiHelpSprite.AddToRenderList();
		}

		// Token: 0x060009D6 RID: 2518 RVA: 0x0000D9C6 File Offset: 0x0000BBC6
		public void justDrawSprites()
		{
			if (this.castleMapRendering.backgroundSprite != null)
			{
				this.castleMapRendering.backgroundSprite.Update();
				this.castleMapRendering.backgroundSprite.AddToRenderList();
				this.drawSurroundSprites();
			}
		}

		// Token: 0x060009D7 RID: 2519 RVA: 0x000C71B0 File Offset: 0x000C53B0
		public void Update(bool villageDisplayed)
		{
			if (this.castleMapRendering == null)
			{
				ABaseService.ReportError(new Exception(string.Format("Castle error prevented: castleMapRendering = null; m_villageID: {0}; OwnSelectedVillage: {1}", this.m_villageID, InterfaceMgr.Instance.OwnSelectedVillage)), ControlForm.Tab.Castle);
				return;
			}
			try
			{
				if (this.castleMapRendering.backgroundSprite != null && villageDisplayed)
				{
					this.tick++;
					this.castleMapRendering.pulse += 8;
					if (this.castleMapRendering.pulse > 255)
					{
						this.castleMapRendering.pulse -= 255;
					}
					if (this.castleMapRendering.pulse > 127)
					{
						this.castleMapRendering.pulseValue = 255 - this.castleMapRendering.pulse + 127;
					}
					else
					{
						this.castleMapRendering.pulseValue = this.castleMapRendering.pulse + 127;
					}
					if (this.tick % 300 == 0 || (CastleMap.fakeKeep > 0 && this.tick % 30 == 0) || this.m_lassoMade || CastleMap.CreateMode)
					{
						this.recalcCastleLayout();
					}
					if (this.tick % 45 == 0)
					{
						GameEngine.Instance.World.getReinforceTotals(this.VillageID, ref this.numAvailableReinforceDefenderPeasants, ref this.numAvailableReinforceDefenderArchers, ref this.numAvailableReinforceDefenderPikemen, ref this.numAvailableReinforceDefenderSwordsmen);
					}
					this.castleMapRendering.backgroundSprite.Update();
					this.castleMapRendering.backgroundSprite.AddToRenderList();
					this.drawSurroundSprites();
				}
			}
			catch (Exception ex)
			{
				ABaseService.ReportError(ex, ControlForm.Tab.Castle);
			}
		}

		// Token: 0x060009D8 RID: 2520 RVA: 0x000C735C File Offset: 0x000C555C
		public void BattleUpdateManager(bool villageDisplayed)
		{
			if (this.realBattleMode)
			{
				if (this.fastPlayback)
				{
					this.BattleUpdate(villageDisplayed, false);
					this.BattleUpdate(villageDisplayed, false);
				}
				this.BattleUpdate(villageDisplayed, true);
			}
			else
			{
				this.castleMapRendering.backgroundSprite.Update();
				this.castleMapRendering.backgroundSprite.AddToRenderList();
			}
			this.drawSurroundSprites();
		}

		// Token: 0x060009D9 RID: 2521 RVA: 0x0000D9FB File Offset: 0x0000BBFB
		public void setFastPlayback(bool state)
		{
			this.fastPlayback = state;
		}

		// Token: 0x060009DA RID: 2522 RVA: 0x0000DA04 File Offset: 0x0000BC04
		public void setRealBattleMode(bool state)
		{
			this.realBattleMode = state;
		}

		// Token: 0x060009DB RID: 2523 RVA: 0x000C73BC File Offset: 0x000C55BC
		public void tutorialFastForward()
		{
			List<CastleElement> attackerList = this.castleCombat.getAttackerList();
			if (attackerList.Count > 0)
			{
				int xPos = (int)attackerList[0].xPos;
				int yPos = (int)attackerList[0].yPos;
				if (xPos > 100)
				{
					this.moveMap(10000, 10000);
					this.moveMap(-808, 0);
				}
				if (yPos < 20)
				{
					this.moveMap(10000, 10000);
					this.moveMap(-280, 0);
				}
				if (yPos > 100)
				{
					this.moveMap(10000, 10000);
					this.moveMap(-808, -399);
				}
				if (xPos < 20)
				{
					this.moveMap(10000, 10000);
					this.moveMap(-280, -399);
				}
			}
			for (int i = 0; i < 325; i++)
			{
				this.castleCombat.tick();
			}
		}

		// Token: 0x060009DC RID: 2524 RVA: 0x000C74A4 File Offset: 0x000C56A4
		public void BattleUpdate(bool villageDisplayed, bool addToGFX)
		{
			if (this.castleMapRendering.backgroundSprite == null || !villageDisplayed)
			{
				return;
			}
			this.updates++;
			if (!this.castleCombat.Paused)
			{
				this.castleMapRendering.updateRocks();
			}
			if (!this.endOfBattle)
			{
				if (this.castleCombat.tick())
				{
					this.elements = this.castleCombat.getElementList();
				}
				this.runCastleSounds();
				if (this.castleCombat.hasBattleFinished())
				{
					this.castleCombat.CloseExtremeLogging();
					this.castleCombat.battlePaused = true;
					this.endOfBattle = true;
					this.endingTroopNumbers = this.castleCombat.getBattleTroopNumbers();
					InterfaceMgr.Instance.ShowViewBattleResults(this.castleCombat.hasAttackerWon(), this.startingTroopNumbers, this.endingTroopNumbers, this.VillageID, this.m_reportReturnData);
				}
			}
			if (addToGFX)
			{
				this.recalcCastleLayout();
				this.castleMapRendering.drawRockChips(this);
				this.castleMapRendering.backgroundSprite.Update();
				this.castleMapRendering.backgroundSprite.AddToRenderList();
				InterfaceMgr.Instance.setCastlePillageClock(this.castleCombat.PillageClock, this.castleCombat.PillageClockMax);
				InterfaceMgr.Instance.setCastleReportClock(this.castleCombat.ReportClock, this.castleCombat.ReportClockMax);
			}
		}

		// Token: 0x060009DD RID: 2525 RVA: 0x000C75F8 File Offset: 0x000C57F8
		private void runCastleSounds()
		{
			if (this.castleCombat.isBattlePaused())
			{
				return;
			}
			int tickValue = this.castleCombat.TickValue;
			if (tickValue % 30 == 1)
			{
				int num = this.castleCombat.sfxGetTotalPeople();
				int num2 = (num < 20) ? 42 : ((num < 150) ? 43 : ((num >= 400) ? 45 : 44));
				int currentEnvironmental = Sound.getCurrentEnvironmental();
				if (num2 != currentEnvironmental && !Sound.isFading())
				{
					if (currentEnvironmental >= 42 && currentEnvironmental <= 45)
					{
						Sound.fadeOutCurrentPlaying();
					}
					else
					{
						Sound.fadeInVillageEnvironmental(num2);
					}
				}
			}
			if (tickValue % 300 == 5)
			{
				GameEngine.Instance.AudioEngine.unloadUnplayingSounds();
			}
			int multiplier = 1;
			if (this.fastPlayback)
			{
				multiplier = 3;
			}
			this.castleCombat.processSoundTrackingQueue(90, 90, 90, 150, 240, 30, 90, 30, 30, 90, 30, 30);
			this.arrowSounds.playBattleSounds(tickValue, this.castleCombat.sfxGetNumArrows(), 30, multiplier, 3, this.arrow_low_sounds, 20, this.arrow_mid_sounds, this.arrow_high_sounds, this);
			this.meleeLightSounds.playBattleSounds(tickValue, this.castleCombat.sfxGetNumMeleeLight(), 30, multiplier, 3, this.meleeLight_low_sounds, 20, this.meleeLight_mid_sounds, this.meleeLight_high_sounds, this);
			this.meleeMetalSounds.playBattleSounds(tickValue, this.castleCombat.sfxGetNumMeleeMetal(), 30, multiplier, 3, this.meleeMetal_low_sounds, 20, this.meleeMetal_mid_sounds, this.meleeMetal_high_sounds, this);
			this.infraWoodSounds.playBattleSoundsNO(tickValue, this.castleCombat.sfxGetNumInfraWood(), 30, multiplier, 3, this.infraWood_low_sounds, 20, this.infraWood_mid_sounds, this.infraWood_high_sounds, this);
			this.infraStoneSounds.playBattleSoundsNO(tickValue, this.castleCombat.sfxGetNumInfraStone(), 30, multiplier, 3, this.infraStone_low_sounds, 20, this.infraStone_mid_sounds, this.infraStone_high_sounds, this);
			this.oilSounds.playBattleSoundsNO(tickValue, this.castleCombat.sfxGetNumOilPots(), 30, multiplier, 2, this.oil_low_sounds, 10000, this.oil_mid_sounds, this.oil_mid_sounds, this);
			this.ballistaBoltSounds.playBattleSoundsNO(tickValue, this.castleCombat.sfxGetNumBallistaBolts(), 45, multiplier, 3, this.ballista_low_sounds, 10, this.ballista_mid_sounds, this.ballista_high_sounds, this);
			this.troopDeathSounds.playBattleSoundsNO(tickValue, this.castleCombat.sfxGetNumTroopDeaths(), 30, multiplier, 3, this.troopdeath_low_sounds, 10, this.troopdeath_mid_sounds, this.troopdeath_high_sounds, this);
			this.troopDeathOnFireSounds.playBattleSoundsNO(tickValue, this.castleCombat.sfxGetNumTroopDeathsOnFire(), 90, multiplier, 2, this.troopdeathonfire_low_sounds, 8, this.troopdeathonfire_low_sounds, this.troopdeathonfire_low_sounds, this);
			this.infraWoodDestroyedSounds.playBattleSoundsNO(tickValue, this.castleCombat.sfxGetNumWoodDestroyed(), 30, multiplier, 3, this.wooddestroyed_low_sounds, 15, this.wooddestroyed_mid_sounds, this.wooddestroyed_high_sounds, this);
			this.infraStoneSmallDestroyedSounds.playBattleSoundsNO(tickValue, this.castleCombat.sfxGetNumStoneSmallDestroyed(), 30, multiplier, 3, this.stonesmalldestroyed_low_sounds, 15, this.stonesmalldestroyed_mid_sounds, this.stonesmalldestroyed_high_sounds, this);
			this.infraStoneLargeDestroyedSounds.playBattleSoundsNO(tickValue, this.castleCombat.sfxGetNumStoneLargeDestroyed(), 30, multiplier, 2, this.stonelargedestroyed_low_sounds, 10, this.stonelargedestroyed_mid_sounds, this.stonelargedestroyed_high_sounds, this);
			this.rockFirstSounds.playBattleSounds(tickValue, this.castleCombat.sfxGetNumRocksFired(), 30, multiplier, 3, this.rockfired_low_sounds, 15, this.rockfired_mid_sounds, this.rockfired_high_sounds, this);
			this.rockLandSounds.playBattleSounds(tickValue, this.castleCombat.sfxGetNumRocksLand(), 30, multiplier, 3, this.rockland_low_sounds, 15, this.rockland_mid_sounds, this.rockland_high_sounds, this);
			this.rockHitSounds.playBattleSounds(tickValue, this.castleCombat.sfxGetNumRocksHit(), 30, multiplier, 3, this.rockhit_low_sounds, 15, this.rockhit_mid_sounds, this.rockhit_high_sounds, this);
			this.openPitsSounds.playBattleSoundsNO(tickValue, this.castleCombat.sfxGetNumPitsOpen(), 30, multiplier, 2, this.openpits_low_sounds, 8, this.openpits_mid_sounds, this.openpits_high_sounds, this);
			this.horseDeathSounds.playBattleSoundsNO(tickValue, this.castleCombat.sfxGetNumHorseDeaths(), 100, multiplier, 100000, this.horsedeath_low_sounds, 10, this.horsedeath_low_sounds, this.horsedeath_low_sounds, this);
			this.wolfDeathSounds.playBattleSoundsNO(tickValue, this.castleCombat.sfxGetNumWolfDeaths(), 80, multiplier, 100000, this.wolfdeath_low_sounds, 10, this.wolfdeath_low_sounds, this.wolfdeath_low_sounds, this);
			this.catapultDeathSounds.playBattleSoundsNO(tickValue, this.castleCombat.sfxGetNumCatapultsDeaths(), 80, multiplier, 100000, this.catapultdeath_low_sounds, 10, this.catapultdeath_low_sounds, this.catapultdeath_low_sounds, this);
			if (this.m_nextWolfSound < tickValue)
			{
				this.m_nextWolfSound = tickValue + 30 + this.sfxRandom.Next(60);
				int num3 = this.castleCombat.sfxGetNumWolves();
				if (num3 > 0)
				{
					if (num3 < 3)
					{
						this.playRandSFXNoOverwrite(this.wolves_low_sounds);
					}
					else if (num3 < 15)
					{
						this.playRandSFXNoOverwrite(this.wolves_mid_sounds);
					}
					else
					{
						this.playRandSFXNoOverwrite(this.wolves_high_sounds);
					}
				}
			}
			if (this.m_nextKnightSound < tickValue)
			{
				this.m_nextKnightSound = tickValue + 30 + this.sfxRandom.Next(30);
				int num4 = this.castleCombat.sfxGetNumKnights();
				if (num4 > 0)
				{
					if (num4 < 3)
					{
						this.playRandSFXNoOverwrite(this.knight_low_sounds);
					}
					else if (num4 < 10)
					{
						this.playRandSFXNoOverwrite(this.knight_mid_sounds);
					}
					else
					{
						this.playRandSFXNoOverwrite(this.knight_high_sounds);
					}
				}
			}
			if (this.m_nextCaptainDelaySound < tickValue)
			{
				this.m_nextCaptainDelaySound = tickValue + 30;
				int num5 = this.castleCombat.sfxGetNumCaptainDelay();
				if (num5 > 0)
				{
					GameEngine.Instance.playInterfaceSound("captain_delay_sound", false);
				}
			}
			if (this.m_nextCaptainRallySound < tickValue)
			{
				this.m_nextCaptainRallySound = tickValue + 30;
				int num6 = this.castleCombat.sfxGetNumCaptainRallyCry();
				if (num6 > 0)
				{
					GameEngine.Instance.playInterfaceSound("captain_rally_sound", false);
				}
			}
			if (this.m_nextCaptainBattleSound < tickValue)
			{
				this.m_nextCaptainBattleSound = tickValue + 30;
				int num7 = this.castleCombat.sfxGetNumCaptainBattleCry();
				if (num7 > 0)
				{
					GameEngine.Instance.playInterfaceSound("captain_battle_sound", false);
				}
			}
		}

		// Token: 0x060009DE RID: 2526 RVA: 0x0000DA0D File Offset: 0x0000BC0D
		private void playRandSFX(string[] tags)
		{
			if (tags != null)
			{
				GameEngine.Instance.playInterfaceSound(tags[this.sfxRandom.Next(tags.Length)]);
			}
		}

		// Token: 0x060009DF RID: 2527 RVA: 0x0000DA2C File Offset: 0x0000BC2C
		private void playRandSFXNoOverwrite(string[] tags)
		{
			if (tags != null)
			{
				GameEngine.Instance.playInterfaceSound(tags[this.sfxRandom.Next(tags.Length)], false);
			}
		}

		// Token: 0x060009E0 RID: 2528 RVA: 0x000C7BDC File Offset: 0x000C5DDC
		public byte[] generateCastleMapSnapshot()
		{
			byte[] fullData = this.castleLayout.createCastleMapArray(CastleMap.getCurrentServerTime());
			return CastlesCommon.compressCastleData(fullData);
		}

		// Token: 0x060009E1 RID: 2529 RVA: 0x000C7C00 File Offset: 0x000C5E00
		public byte[] generateCastleTroopsSnapshot()
		{
			byte[] fullData = this.castleLayout.createDefenderMapArray();
			return CastlesCommon.compressCastleData(fullData);
		}

		// Token: 0x060009E2 RID: 2530 RVA: 0x000C7C20 File Offset: 0x000C5E20
		public void importDefenderSnapshot(byte[] compressedCastleMap, byte[] compressedDefenderMap, int keepLevel, bool ignorePits, int landType)
		{
			UniversalDebugLog.Log("IMPORTING DEFENDER SNAPSHOT");
			this.attackerSetupMode = true;
			this.captainsDetails.Clear();
			this.displayType = 1;
			this.showCatapultTargets = false;
			if (this.elements == null)
			{
				this.elements = new List<CastleElement>();
			}
			else
			{
				this.elements.Clear();
			}
			CastleElement castleElement = new CastleElement();
			castleElement.completionTime = DateTime.Now.AddDays(-100.0);
			if (keepLevel < 1)
			{
				keepLevel = 1;
			}
			castleElement.elementType = (byte)keepLevel;
			castleElement.elementID = -1L;
			castleElement.xPos = 58;
			castleElement.yPos = 59;
			this.elements.Add(castleElement);
			long num = -100000L;
			if (compressedDefenderMap != null)
			{
				byte[] array = CastlesCommon.decompressCastleData(compressedDefenderMap);
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] > 0)
					{
						CastleElement castleElement2 = new CastleElement();
						castleElement2.completionTime = castleElement.completionTime;
						CastleElement castleElement3 = castleElement2;
						long num2 = num;
						num = num2 - 1L;
						castleElement3.elementID = num2;
						castleElement2.elementType = array[i];
						if (castleElement2.elementType >= 80)
						{
							switch (castleElement2.elementType)
							{
							case 80:
								castleElement2.elementType = 70;
								castleElement2.aggressiveDefender = true;
								break;
							case 81:
								castleElement2.elementType = 71;
								castleElement2.aggressiveDefender = true;
								break;
							case 82:
								castleElement2.elementType = 73;
								castleElement2.aggressiveDefender = true;
								break;
							}
						}
						else if (castleElement2.elementType == 77)
						{
							castleElement2.aggressiveDefender = true;
						}
						castleElement2.damage = 0f;
						castleElement2.xPos = (byte)(i % 118);
						castleElement2.yPos = (byte)(i / 118);
						this.elements.Add(castleElement2);
					}
				}
			}
			if (compressedCastleMap != null)
			{
				byte[] array2 = CastlesCommon.decompressCastleData(compressedCastleMap);
				for (int j = 0; j < array2.Length; j++)
				{
					if (array2[j] > 0 && (array2[j] != 36 || !ignorePits))
					{
						CastleElement castleElement4 = new CastleElement();
						castleElement4.completionTime = castleElement.completionTime;
						CastleElement castleElement5 = castleElement4;
						long num3 = num;
						num = num3 - 1L;
						castleElement5.elementID = num3;
						castleElement4.elementType = array2[j];
						castleElement4.damage = 0f;
						castleElement4.xPos = (byte)(j % 118);
						castleElement4.yPos = (byte)(j / 118);
						this.elements.Add(castleElement4);
					}
				}
			}
			CastlesCommon.addLandTypeAdditions(this.elements, landType);
			this.attackerSetupForest = (landType == 9);
			this.regenerateDefaultCatapultTargets();
			this.updateLayoutAndRedraw();
		}

		// Token: 0x060009E3 RID: 2531 RVA: 0x000C7E98 File Offset: 0x000C6098
		public void initFakeSetup()
		{
			this.placingAttackerRealMode = false;
			this.attackMaxPeasants = 1000;
			this.attackMaxArchers = 1000;
			this.attackMaxPikemen = 1000;
			this.attackMaxSwordsmen = 1000;
			this.attackMaxCatapults = 1000;
			this.attackMaxCaptains = 5;
			this.attackRealAttackingVillage = -1;
			this.attackRealTargetVillage = -1;
			this.attackNumPeasants = 0;
			this.attackNumArchers = 0;
			this.attackNumPikemen = 0;
			this.attackNumSwordsmen = 0;
			this.attackNumCatapults = 0;
			this.attackNumCaptains = 0;
			this.attackMaxPeasantsInCastle = 0;
			this.attackMaxArchersInCastle = 0;
			this.attackMaxPikemenInCastle = 0;
			this.attackMaxSwordsmenInCastle = 0;
			this.attackCaptainsCommand = 1;
			InterfaceMgr.Instance.castleShowPlacedAttackers(this.attackNumPeasants, this.attackNumArchers, this.attackNumPikemen, this.attackNumSwordsmen, this.attackNumCatapults, this.attackMaxPeasants, this.attackMaxArchers, this.attackMaxPikemen, this.attackMaxSwordsmen, this.attackMaxCatapults, this.attackNumCaptains, this.attackMaxCaptains, this.attackCaptainsCommand, this.attackMaxPeasantsInCastle, this.attackMaxArchersInCastle, this.attackMaxPikemenInCastle, this.attackMaxSwordsmenInCastle);
			InterfaceMgr.Instance.castleAttackShowRealAttack(false);
			this.localTempElementNumber = -3L;
		}

		// Token: 0x060009E4 RID: 2532 RVA: 0x000C7FCC File Offset: 0x000C61CC
		public void initRealSetup(int attackingVillage, int targetVillage, int numPeasants, int numArchers, int numPikemen, int numSwordsmen, int numCatapults, int attackType, int pillagePercent, int captainsCommand, int parentOfAttackingVillage, int numPeasantsInCastle, int numArchersInCastle, int numPikemenInCastle, int numSwordsmenInCastle, int targetUserID, string targetUserName, BattleHonourData battleHonourData, int numCaptainsInCastle, int numCaptains, double capitalAttackRate)
		{
			this.m_villageID = attackingVillage;
			this.ParentOfAttackingVillage = parentOfAttackingVillage;
			this.placingAttackerRealMode = true;
			this.attackRealAttackingVillage = attackingVillage;
			this.attackRealTargetVillage = targetVillage;
			this.attackMaxPeasants = numPeasants;
			this.attackMaxArchers = numArchers;
			this.attackMaxPikemen = numPikemen;
			this.attackMaxSwordsmen = numSwordsmen;
			this.attackMaxCatapults = numCatapults;
			this.attackMaxPeasantsInCastle = numPeasantsInCastle;
			this.attackMaxArchersInCastle = numArchersInCastle;
			this.attackMaxPikemenInCastle = numPikemenInCastle;
			this.attackMaxSwordsmenInCastle = numSwordsmenInCastle;
			this.attackRealAttackType = attackType;
			this.attackPillagePercent = pillagePercent;
			this.attackCaptainsCommand = captainsCommand;
			this.attackMaxCaptains = numCaptains;
			this.attackNumPeasants = 0;
			this.attackNumArchers = 0;
			this.attackNumPikemen = 0;
			this.attackNumSwordsmen = 0;
			this.attackNumCatapults = 0;
			this.attackNumCaptains = 0;
			this.m_targetUserID = targetUserID;
			this.m_targetUserName = targetUserName;
			this.m_battleHonourData = battleHonourData;
			this.attackCapitalAttackRate = capitalAttackRate;
			InterfaceMgr.Instance.castleShowPlacedAttackers(this.attackNumPeasants, this.attackNumArchers, this.attackNumPikemen, this.attackNumSwordsmen, this.attackNumCatapults, this.attackMaxPeasants, this.attackMaxArchers, this.attackMaxPikemen, this.attackMaxSwordsmen, this.attackMaxCatapults, this.attackNumCaptains, this.attackMaxCaptains, this.attackCaptainsCommand, this.attackMaxPeasantsInCastle, this.attackMaxArchersInCastle, this.attackMaxPikemenInCastle, this.attackMaxSwordsmenInCastle);
			InterfaceMgr.Instance.castleAttackShowRealAttack(true);
			this.localTempElementNumber = -3L;
		}

		// Token: 0x060009E5 RID: 2533 RVA: 0x000C8134 File Offset: 0x000C6334
		public void updateLaunchButton()
		{
			if (this.placingAttackerRealMode)
			{
				bool state = this.isAttackReady();
				InterfaceMgr.Instance.castleAttackShowAttackReady(state);
				return;
			}
			InterfaceMgr.Instance.castleAttackShowAttackReady(true);
		}

		// Token: 0x060009E6 RID: 2534 RVA: 0x0000DA4C File Offset: 0x0000BC4C
		private bool isAttackReady()
		{
			return this.attackNumPeasants > 0 || this.attackNumArchers > 0 || this.attackNumPikemen > 0 || this.attackNumSwordsmen > 0 || this.attackNumCaptains > 0;
		}

		// Token: 0x060009E7 RID: 2535 RVA: 0x000C8168 File Offset: 0x000C6368
		public bool captainPlaced()
		{
			foreach (CastleElement castleElement in this.elements)
			{
				if (castleElement.elementType >= 100 && castleElement.elementType <= 109)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060009E8 RID: 2536 RVA: 0x000C81D0 File Offset: 0x000C63D0
		public void autoPlaceAttackers(int mode)
		{
			int num = 0;
			int num2 = 0;
			this.placingDefender = false;
			while (!this.isAttackReady())
			{
				int mapX = 0;
				int mapY = 0;
				switch (mode)
				{
				case 0:
					mapX = (((num & 1) != 1) ? (58 + num / 2) : (58 - (num + 1) / 2));
					mapY = num2;
					break;
				case 1:
					mapY = (((num & 1) != 1) ? (58 + num / 2) : (58 - (num + 1) / 2));
					mapX = 117 - num2;
					break;
				case 2:
					mapY = (((num & 1) != 1) ? (58 + num / 2) : (58 - (num + 1) / 2));
					mapX = num2;
					break;
				case 3:
					mapX = (((num & 1) != 1) ? (58 + num / 2) : (58 - (num + 1) / 2));
					mapY = 117 - num2;
					break;
				}
				if (this.attackNumCatapults != this.attackMaxCatapults)
				{
					this.placementType = 94;
				}
				else if (this.attackNumArchers != this.attackMaxArchers)
				{
					this.placementType = 92;
				}
				else if (this.attackNumPikemen != this.attackMaxPikemen)
				{
					this.placementType = 93;
				}
				else if (this.attackNumSwordsmen != this.attackMaxSwordsmen)
				{
					this.placementType = 91;
				}
				else
				{
					this.placementType = 90;
				}
				this.startPlacingAttackerTroops(this.placementType);
				if (this.mouseMovePlaceTroops(mapX, mapY, true, 0))
				{
					this.troopPlaceAttacker(mapX, mapY);
				}
				num++;
				if (num >= 118)
				{
					num = 0;
					num2++;
					if (num2 >= 118)
					{
						break;
					}
				}
			}
			this.stopPlaceElement();
			this.updateLayoutAndRedraw();
		}

		// Token: 0x060009E9 RID: 2537 RVA: 0x000C8168 File Offset: 0x000C6368
		public bool containsCaptain()
		{
			foreach (CastleElement castleElement in this.elements)
			{
				if (castleElement.elementType >= 100 && castleElement.elementType <= 109)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060009EA RID: 2538 RVA: 0x0000DA7E File Offset: 0x0000BC7E
		public void setupLaunchArmy(int attackType, int pillagePercent, int captainsCommand)
		{
			this.attackRealAttackType = attackType;
			this.attackPillagePercent = pillagePercent;
			this.attackCaptainsCommand = captainsCommand;
		}

		// Token: 0x060009EB RID: 2539 RVA: 0x000C8330 File Offset: 0x000C6530
		public void launchArmy(bool background = false)
		{
			byte[] array = this.castleLayout.createAttackerMapArray();
			if (this.catapultTargets.Count > 0)
			{
				int count = this.catapultTargets.Count;
				byte[] array2 = new byte[count * 4];
				int num = 0;
				foreach (CatapultTarget catapultTarget in this.catapultTargets)
				{
					foreach (CastleElement castleElement in this.elements)
					{
						if ((castleElement.elementType == 94 || castleElement.elementType == 102 || castleElement.elementType == 103) && castleElement.elementID == catapultTarget.elemID)
						{
							catapultTarget.validate(castleElement, GameEngine.Instance.LocalWorldData.Castle_Catapult_MaxRange);
							if (!catapultTarget.valid)
							{
								catapultTarget.createDefaultLocation((int)castleElement.xPos, (int)castleElement.yPos, castleElement);
							}
							array2[num * 4] = castleElement.xPos;
							array2[num * 4 + 1] = castleElement.yPos;
							array2[num * 4 + 2] = catapultTarget.xPos;
							array2[num * 4 + 3] = catapultTarget.yPos;
							num++;
							break;
						}
					}
				}
				byte[] array3 = new byte[array.Length + array2.Length];
				num = 0;
				int i = 0;
				while (i < array.Length)
				{
					array3[num] = array[i];
					i++;
					num++;
				}
				int j = 0;
				while (j < array2.Length)
				{
					array3[num] = array2[j];
					j++;
					num++;
				}
				array = array3;
			}
			if (this.captainsDetails.Count > 0)
			{
				int count2 = this.captainsDetails.Count;
				byte[] array4 = new byte[count2 * 3];
				int num2 = 0;
				foreach (CaptainsDetails captainsDetails in this.captainsDetails)
				{
					foreach (CastleElement castleElement2 in this.elements)
					{
						if (castleElement2.elementType >= 100 && castleElement2.elementType <= 109 && castleElement2.elementID == captainsDetails.elemID)
						{
							array4[num2 * 3] = castleElement2.xPos;
							array4[num2 * 3 + 1] = castleElement2.yPos;
							array4[num2 * 3 + 2] = captainsDetails.seconds;
							num2++;
							break;
						}
					}
				}
				byte[] array5 = new byte[array.Length + array4.Length];
				num2 = 0;
				int k = 0;
				while (k < array.Length)
				{
					array5[num2] = array[k];
					k++;
					num2++;
				}
				int l = 0;
				while (l < array4.Length)
				{
					array5[num2] = array4[l];
					l++;
					num2++;
				}
				array = array5;
			}
			byte[] troopMap = CastlesCommon.compressCastleData(array);
			int targetVillageID = -1;
			if (this.placingAttackerRealMode)
			{
				targetVillageID = this.attackRealTargetVillage;
			}
			if (background)
			{
				this.attackRealAttackType = 11;
				RemoteServices.Instance.set_LaunchCastleAttack_UserCallBack(new RemoteServices.LaunchCastleAttack_UserCallBack(CastleMap.launchCastleAttackCallbackBG));
			}
			else
			{
				RemoteServices.Instance.set_LaunchCastleAttack_UserCallBack(new RemoteServices.LaunchCastleAttack_UserCallBack(this.launchCastleAttackCallback));
			}
			RemoteServices.Instance.LaunchCastleAttack(this.ParentOfAttackingVillage, this.m_villageID, targetVillageID, troopMap, this.attackNumPeasants, this.attackNumArchers, this.attackNumPikemen, this.attackNumSwordsmen, this.attackNumCatapults, this.attackRealAttackType, this.attackPillagePercent, this.attackCaptainsCommand, this.attackNumCaptains);
			AllVillagesPanel.travellersChanged();
			CastleMap.tempCompressedAttackerMap = troopMap;
			GameEngine.Instance.flushVillage(this.m_villageID);
		}

		// Token: 0x060009EC RID: 2540 RVA: 0x000C8754 File Offset: 0x000C6954
		public void launchCastleAttackCallback(LaunchCastleAttack_ReturnType returnData)
		{
			if (returnData.protectedVillage)
			{
				MyMessageBox.Show(SK.Text("CastleMap_Interdiction", "This village is protected from attack by an Interdiction."), SK.Text("CastleMap_Protected", "Village Protected"));
				InterfaceMgr.Instance.getMainTabBar().changeTab(9);
				InterfaceMgr.Instance.getMainTabBar().changeTab(0);
				return;
			}
			if (returnData.Success)
			{
				if (returnData.villageResourcesAndStats != null)
				{
					VillageMap village = GameEngine.Instance.getVillage(returnData.sourceVillage);
					if (village != null)
					{
						village.importResourcesAndStats(returnData.villageResourcesAndStats, returnData.currentTime);
					}
				}
				ArmyReturnData[] armyReturnData = new ArmyReturnData[]
				{
					returnData.armyData
				};
				GameEngine.Instance.World.doGetArmyData(armyReturnData, null, false);
				GameEngine.Instance.World.addExistingArmy(returnData.armyData.armyID);
				InterfaceMgr.Instance.getMainTabBar().changeTab(9);
				InterfaceMgr.Instance.getMainTabBar().changeTab(0);
				if (SpecialVillageTypes.IS_TREASURE_CASTLE(GameEngine.Instance.World.getSpecial(returnData.targetVillage)))
				{
					GameEngine.Instance.World.setLastTreasureCastleAttackTime(VillageMap.getCurrentServerTime());
				}
				AttackTargetsPanel.addRecent(returnData.targetVillage);
				return;
			}
			MyMessageBox.Show(ErrorCodes.getErrorString(returnData.m_errorCode, returnData.m_errorID), SK.Text("GENERIC_Attack_Error", "Attack Error"));
			InterfaceMgr.Instance.getMainTabBar().changeTab(9);
			InterfaceMgr.Instance.getMainTabBar().changeTab(0);
		}

		// Token: 0x060009ED RID: 2541 RVA: 0x000C88CC File Offset: 0x000C6ACC
		public void restoreCastleTroopsCallback(RestoreCastleTroops_ReturnType returnData)
		{
			if (!returnData.Success)
			{
				return;
			}
			if (returnData.elements != null)
			{
				this.importElements(returnData.elements);
			}
			if (returnData.villageResourcesAndStats != null && GameEngine.Instance.Village != null)
			{
				GameEngine.Instance.Village.importResourcesAndStats(returnData.villageResourcesAndStats, returnData.currentTime);
				VillageMap village = GameEngine.Instance.Village;
				if (village != null)
				{
					this.numAvailableDefenderPeasants = 0;
					this.numAvailableDefenderArchers = 0;
					this.numAvailableDefenderPikemen = 0;
					this.numAvailableDefenderSwordsmen = 0;
					this.numAvailableDefenderCaptains = 0;
					village.getVillageTroops(ref this.numAvailableDefenderPeasants, ref this.numAvailableDefenderArchers, ref this.numAvailableDefenderPikemen, ref this.numAvailableDefenderSwordsmen, ref this.numAvailableDefenderCaptains);
					GameEngine.Instance.World.getReinforceTotals(village.VillageID, ref this.numAvailableReinforceDefenderPeasants, ref this.numAvailableReinforceDefenderArchers, ref this.numAvailableReinforceDefenderPikemen, ref this.numAvailableReinforceDefenderSwordsmen);
					village.getVillageVassalTroops(ref this.numAvailableVassalReinforceDefenderPeasants, ref this.numAvailableVassalReinforceDefenderArchers, ref this.numAvailableVassalReinforceDefenderPikemen, ref this.numAvailableVassalReinforceDefenderSwordsmen);
				}
			}
		}

		// Token: 0x060009EE RID: 2542 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void returnToReports()
		{
		}

		// Token: 0x060009EF RID: 2543 RVA: 0x0000DA95 File Offset: 0x0000BC95
		public void clearTempAttackers()
		{
			CastleMap.tempCompressedAttackerMap = null;
		}

		// Token: 0x060009F0 RID: 2544 RVA: 0x0000DA9D File Offset: 0x0000BC9D
		public int getDefenderDefenceResearch()
		{
			if (this.battleMode && this.m_defenderResearch != null)
			{
				return this.m_defenderResearch.defences;
			}
			if (this.placingAttackerRealMode)
			{
				return 0;
			}
			return (int)GameEngine.Instance.World.GetResearchDataForCurrentVillage().Research_Defences;
		}

		// Token: 0x060009F1 RID: 2545 RVA: 0x0000DAD9 File Offset: 0x0000BCD9
		public int getLandType()
		{
			if (this.battleMode)
			{
				return this.battleLandType;
			}
			return 0;
		}

		// Token: 0x060009F2 RID: 2546 RVA: 0x000C89D0 File Offset: 0x000C6BD0
		public void launchBattle(byte[] compressedCastleMap, byte[] compressedCastleDamageMap, byte[] compressedDefenderMap, byte[] compressedAttackerMap, int keepType, CastleResearchData defenderResearchData, CastleResearchData attackerResearchData, int castleMode, int pillageInfo, int ransackCount, int raidCount, int landType, bool addLandFeatures, bool oldReport)
		{
			GameEngine.Instance.AudioEngine.unloadUnplayingSounds();
			this.m_defenderResearch = defenderResearchData;
			this.m_attackerResearch = attackerResearchData;
			this.endOfBattle = false;
			this.battleMode = true;
			this.displayType = 1;
			this.fastPlayback = false;
			this.realBattleMode = true;
			this.battleLandType = landType;
			bool ignoreForestSetup = false;
			this.attackerSetupForest = (landType == 9);
			if (this.attackerSetupForest && oldReport)
			{
				this.attackerSetupForest = false;
				ignoreForestSetup = true;
			}
			this.castleCombat = new CastleCombat();
			if (castleMode == 1)
			{
				this.castleCombat.setAsBanditCamp();
			}
			if (castleMode == 2)
			{
				this.castleCombat.setAsWolfCamp();
			}
			this.castleMapRendering.initRockchips(this);
			if (compressedAttackerMap == null)
			{
				compressedAttackerMap = CastleMap.tempCompressedAttackerMap;
			}
			this.castleCombat.InitExtremeLogging("Client View Report.txt");
			this.castleCombat.setSoundTracking();
			this.castleLayout = this.castleCombat.startBattle(GameEngine.Instance.LocalWorldData, compressedCastleMap, compressedCastleDamageMap, compressedDefenderMap, compressedAttackerMap, 1000, 1000, 1000, 1000, keepType, null, VillageMap.getCurrentServerTime(), defenderResearchData, attackerResearchData, pillageInfo, ransackCount, raidCount, landType, ignoreForestSetup);
			this.startingTroopNumbers = this.castleCombat.getBattleTroopNumbers();
			this.elements = this.castleCombat.getElementList();
			if (addLandFeatures)
			{
				CastlesCommon.addLandTypeAdditions(this.elements, landType);
			}
			this.recalcCastleLayout();
			if (this.castleCombat.numTreasurePieces > 0)
			{
				this.treasureCastle = true;
				this.treasureCastleClock = 300;
				return;
			}
			this.treasureCastle = false;
		}

		// Token: 0x060009F3 RID: 2547 RVA: 0x0000DAEB File Offset: 0x0000BCEB
		public void setReportData(GetReport_ReturnType reportReturnData)
		{
			this.m_reportReturnData = reportReturnData;
		}

		// Token: 0x060009F4 RID: 2548 RVA: 0x000C8B50 File Offset: 0x000C6D50
		public bool isInDeleteConstructing()
		{
			if (this.inDeleteConstructing && (DateTime.Now - this.lastDeleteConstructing).TotalMinutes > 2.0)
			{
				this.inDeleteConstructing = false;
			}
			return this.inDeleteConstructing;
		}

		// Token: 0x060009F5 RID: 2549 RVA: 0x000C8B98 File Offset: 0x000C6D98
		public void deleteConstructingElements()
		{
			if (this.inDeleteConstructing && (DateTime.Now - this.lastDeleteConstructing).TotalMinutes > 2.0)
			{
				this.inDeleteConstructing = false;
			}
			if (!this.inDeleteConstructing)
			{
				this.inDeleting = true;
				this.inDeleteConstructing = true;
				this.lastDeleteConstructing = DateTime.Now;
				RemoteServices.Instance.set_DeleteCastleElement_UserCallBack(new RemoteServices.DeleteCastleElement_UserCallBack(this.DeleteElementCallback));
				RemoteServices.Instance.DeleteConstructingCastleElements(this.m_villageID);
				this.stopPlaceElement();
			}
		}

		// Token: 0x060009F6 RID: 2550 RVA: 0x000C8C24 File Offset: 0x000C6E24
		public void deleteAllElements()
		{
			if (this.inDeleteConstructing && (DateTime.Now - this.lastDeleteConstructing).TotalMinutes > 2.0)
			{
				this.inDeleteConstructing = false;
			}
			if (!this.inDeleteConstructing)
			{
				this.inDeleting = true;
				this.inDeleteConstructing = true;
				this.lastDeleteConstructing = DateTime.Now;
				RemoteServices.Instance.set_DeleteCastleElement_UserCallBack(new RemoteServices.DeleteCastleElement_UserCallBack(this.DeleteElementCallback));
				RemoteServices.Instance.DeleteAllCastleElements(this.m_villageID);
				this.stopPlaceElement();
			}
		}

		// Token: 0x060009F7 RID: 2551 RVA: 0x0000DAF4 File Offset: 0x0000BCF4
		public void startDeletingTouchscreen()
		{
			this.deleteType = CastleMap.DeleteType.ALL;
			this.deletingTouchScreen = true;
		}

		// Token: 0x060009F8 RID: 2552 RVA: 0x0000DB04 File Offset: 0x0000BD04
		public void stopDeletingTouchscreen()
		{
			this.deletingTouchScreen = false;
		}

		// Token: 0x060009F9 RID: 2553 RVA: 0x0000DB0D File Offset: 0x0000BD0D
		public bool isDeletingTouchscreen()
		{
			return this.deletingTouchScreen;
		}

		// Token: 0x060009FA RID: 2554 RVA: 0x0000DB15 File Offset: 0x0000BD15
		public bool isDeletingThisElement(long elementID)
		{
			return this.deletingElements.Contains(elementID);
		}

		// Token: 0x060009FB RID: 2555 RVA: 0x000C8CB0 File Offset: 0x000C6EB0
		public void deleteAtMapTile(Point maptile)
		{
			CastleElement castleElement = this.castleLayout.getCastleElement(maptile.X, maptile.Y);
			if (castleElement == null || this.deletingElements.Contains(castleElement.elementID) || (castleElement.elementType >= 1 && castleElement.elementType <= 10))
			{
				return;
			}
			if (this.isWall((int)castleElement.elementType) || castleElement.elementType == 35 || castleElement.elementType == 43 || castleElement.elementType == 36)
			{
				if (this.deleteType == CastleMap.DeleteType.ALL || this.deleteType == CastleMap.DeleteType.WALLS)
				{
					this.deletingElements.Add(castleElement.elementID);
				}
			}
			else if (castleElement.elementType < 69 && (this.deleteType == CastleMap.DeleteType.ALL || this.deleteType == CastleMap.DeleteType.BUILDINGS))
			{
				this.deletingElements.Add(castleElement.elementID);
			}
			this.recalcCastleLayout();
		}

		// Token: 0x060009FC RID: 2556 RVA: 0x0000DB23 File Offset: 0x0000BD23
		public void undoLastDelete()
		{
			if (this.deletingElements.Count > 0)
			{
				this.deletingElements.RemoveAt(this.deletingElements.Count - 1);
			}
			this.recalcCastleLayout();
		}

		// Token: 0x060009FD RID: 2557 RVA: 0x0000DB51 File Offset: 0x0000BD51
		public void cancelPendingDeletes()
		{
			this.deletingElements.Clear();
			this.recalcCastleLayout();
		}

		// Token: 0x060009FE RID: 2558 RVA: 0x000C8D84 File Offset: 0x000C6F84
		private void confirmPendingDeletes()
		{
			UniversalDebugLog.Log("CONFIRMING DELETES");
			if (this.inDeleteConstructing && (DateTime.Now - this.lastDeleteConstructing).TotalMinutes > 2.0)
			{
				this.inDeleteConstructing = false;
			}
			if (!this.inDeleteConstructing)
			{
				this.inDeleting = true;
				this.inDeleteConstructing = true;
				this.lastDeleteConstructing = DateTime.Now;
				RemoteServices.Instance.set_DeleteCastleElement_UserCallBack(new RemoteServices.DeleteCastleElement_UserCallBack(this.DeleteElementCallback));
				RemoteServices.Instance.DeleteCastleElement(this.m_villageID, this.deletingElements);
			}
		}

		// Token: 0x060009FF RID: 2559 RVA: 0x000C8E1C File Offset: 0x000C701C
		public void deleteAllMoatElements()
		{
			if (this.inDeleteConstructing && (DateTime.Now - this.lastDeleteConstructing).TotalMinutes > 2.0)
			{
				this.inDeleteConstructing = false;
			}
			if (!this.inDeleteConstructing)
			{
				this.inDeleting = true;
				this.inDeleteConstructing = true;
				this.lastDeleteConstructing = DateTime.Now;
				RemoteServices.Instance.set_DeleteCastleElement_UserCallBack(new RemoteServices.DeleteCastleElement_UserCallBack(this.DeleteElementCallback));
				RemoteServices.Instance.DeleteAllCastleMoatElements(this.m_villageID);
				this.stopPlaceElement();
			}
		}

		// Token: 0x06000A00 RID: 2560 RVA: 0x000C8EA8 File Offset: 0x000C70A8
		public void deleteAllPitsElements()
		{
			if (this.inDeleteConstructing && (DateTime.Now - this.lastDeleteConstructing).TotalMinutes > 2.0)
			{
				this.inDeleteConstructing = false;
			}
			if (!this.inDeleteConstructing)
			{
				this.inDeleting = true;
				this.inDeleteConstructing = true;
				this.lastDeleteConstructing = DateTime.Now;
				RemoteServices.Instance.set_DeleteCastleElement_UserCallBack(new RemoteServices.DeleteCastleElement_UserCallBack(this.DeleteElementCallback));
				RemoteServices.Instance.DeleteAllCastlePitsElements(this.m_villageID);
				this.stopPlaceElement();
			}
		}

		// Token: 0x06000A01 RID: 2561 RVA: 0x000C8F34 File Offset: 0x000C7134
		public void deleteAllOilPotElements()
		{
			if (this.inDeleteConstructing && (DateTime.Now - this.lastDeleteConstructing).TotalMinutes > 2.0)
			{
				this.inDeleteConstructing = false;
			}
			if (!this.inDeleteConstructing)
			{
				this.inDeleting = true;
				this.inDeleteConstructing = true;
				this.lastDeleteConstructing = DateTime.Now;
				RemoteServices.Instance.set_DeleteCastleElement_UserCallBack(new RemoteServices.DeleteCastleElement_UserCallBack(this.DeleteElementCallback));
				RemoteServices.Instance.DeleteAllCastleOilPotsElements(this.m_villageID);
				this.stopPlaceElement();
			}
		}

		// Token: 0x06000A02 RID: 2562 RVA: 0x000C8FC0 File Offset: 0x000C71C0
		public bool isAnyConstructing()
		{
			DateTime currentServerTime = VillageMap.getCurrentServerTime();
			foreach (CastleElement castleElement in this.elements)
			{
				if (castleElement.elementType < 69 && castleElement.completionTime > currentServerTime)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000A03 RID: 2563 RVA: 0x000C9034 File Offset: 0x000C7234
		public void tutorialAutoPlace()
		{
			if (this.elements.Count <= 1)
			{
				this.startPlaceElement(40);
				this.placeBuildingElement(53, 59, true, false);
				this.startPlaceElement(33);
				this.placeBuildingElement(63, 54, true, false);
				this.placeBuildingElement(62, 54, true, false);
				this.placeBuildingElement(61, 54, true, false);
				this.placeBuildingElement(60, 54, true, false);
				this.placeBuildingElement(59, 54, true, false);
				this.placeBuildingElement(58, 54, true, false);
				this.placeBuildingElement(57, 54, true, false);
				this.placeBuildingElement(56, 54, true, false);
				this.placeBuildingElement(55, 54, true, false);
				this.placeBuildingElement(54, 54, true, false);
				this.placeBuildingElement(63, 55, true, false);
				this.placeBuildingElement(63, 56, true, false);
				this.placeBuildingElement(63, 57, true, false);
				this.placeBuildingElement(63, 58, true, false);
				this.placeBuildingElement(63, 59, true, false);
				this.placeBuildingElement(63, 60, true, false);
				this.placeBuildingElement(63, 61, true, false);
				this.placeBuildingElement(63, 62, true, false);
				this.placeBuildingElement(63, 63, true, false);
				this.placeBuildingElement(62, 63, true, false);
				this.placeBuildingElement(61, 63, true, false);
				this.placeBuildingElement(54, 63, true, false);
				this.placeBuildingElement(55, 63, true, false);
				this.placeBuildingElement(56, 63, true, false);
				this.placeBuildingElement(54, 55, true, false);
				this.placeBuildingElement(54, 56, true, false);
				this.placeBuildingElement(54, 57, true, false);
				this.placeBuildingElement(54, 61, true, false);
				this.placeBuildingElement(54, 62, true, false);
				this.stopPlaceElement();
				this.updateLayoutAndRedraw();
				this.inBuilderMode = false;
			}
		}

		// Token: 0x06000A04 RID: 2564 RVA: 0x0000DB64 File Offset: 0x0000BD64
		public void changeDebugLayers()
		{
			this.debugDisplayMode++;
			if (this.debugDisplayMode >= 3)
			{
				this.debugDisplayMode = 0;
			}
			this.recalcCastleLayout();
		}

		// Token: 0x06000A05 RID: 2565 RVA: 0x0000DB8A File Offset: 0x0000BD8A
		public void changeSpreadType()
		{
			this.spreadTypeDiamond = !this.spreadTypeDiamond;
			this.castleCombat.buildAttackerRouteMap(this.spreadTypeDiamond);
			this.recalcCastleLayout();
		}

		// Token: 0x06000A06 RID: 2566 RVA: 0x000C9200 File Offset: 0x000C7400
		public void DEBUG_SaveAIWorldSetup(string filename)
		{
			TextWriter textWriter = new StreamWriter(filename);
			CampCastleElement[] array = this.castleLayout.createCastleCampArray_MemoriseAttackSetupTroops();
			CampCastleElement[] array2 = array;
			foreach (CampCastleElement campCastleElement in array2)
			{
				byte[] array4 = new byte[6];
				array4[0] = campCastleElement.elementType;
				array4[1] = campCastleElement.xPos;
				array4[2] = campCastleElement.yPos;
				byte[] array5 = array4;
				if (campCastleElement.elementType == 94)
				{
					Point catapultAttackLocation = this.getCatapultAttackLocation((int)campCastleElement.xPos, (int)campCastleElement.yPos);
					array5[3] = (byte)catapultAttackLocation.X;
					array5[4] = (byte)catapultAttackLocation.Y;
				}
				if (campCastleElement.elementType >= 100 && campCastleElement.elementType < 109)
				{
					int captainsDelayValue = this.getCaptainsDelayValue((int)campCastleElement.xPos, (int)campCastleElement.yPos);
					array5[5] = (byte)captainsDelayValue;
					if (campCastleElement.elementType == 102 || campCastleElement.elementType == 103)
					{
						Point catapultAttackLocation2 = this.getCatapultAttackLocation((int)campCastleElement.xPos, (int)campCastleElement.yPos);
						array5[3] = (byte)catapultAttackLocation2.X;
						array5[4] = (byte)catapultAttackLocation2.Y;
					}
				}
				textWriter.WriteLine(string.Concat(new string[]
				{
					array5[0].ToString(),
					",",
					array5[1].ToString(),
					",",
					array5[2].ToString(),
					",",
					array5[3].ToString(),
					",",
					array5[4].ToString(),
					",",
					array5[5].ToString(),
					","
				}));
			}
			textWriter.Close();
		}

		// Token: 0x06000A07 RID: 2567 RVA: 0x000C93C4 File Offset: 0x000C75C4
		public void DEBUG_SaveCastleMap(string filename)
		{
			FileStream fileStream = new FileStream(filename, FileMode.Create);
			BinaryWriter binaryWriter = new BinaryWriter(fileStream);
			byte[] array = this.generateCastleMapSnapshot();
			byte[] array2 = this.generateCastleTroopsSnapshot();
			byte[] fullData = this.castleLayout.createAttackerMapArray();
			byte[] array3 = CastlesCommon.compressCastleData(fullData);
			binaryWriter.Write(array.Length);
			binaryWriter.Write(array, 0, array.Length);
			binaryWriter.Write(array2.Length);
			binaryWriter.Write(array2, 0, array2.Length);
			binaryWriter.Write(array3.Length);
			binaryWriter.Write(array3, 0, array3.Length);
			binaryWriter.Close();
			fileStream.Close();
		}

		// Token: 0x06000A08 RID: 2568 RVA: 0x000C9450 File Offset: 0x000C7650
		public void loadCamp(string filename)
		{
			new Random();
			List<CampCastleElement> list = new List<CampCastleElement>();
			FileStream fileStream = new FileStream(filename, FileMode.Open);
			BinaryReader binaryReader = new BinaryReader(fileStream);
			int num = binaryReader.ReadInt32();
			for (int i = 0; i < num; i++)
			{
				list.Add(new CampCastleElement
				{
					xPos = binaryReader.ReadByte(),
					yPos = binaryReader.ReadByte(),
					elementType = binaryReader.ReadByte(),
					aggressiveDefender = binaryReader.ReadBoolean()
				});
			}
			binaryReader.Close();
			fileStream.Close();
			this.elements.Clear();
			this.localTempElementNumber = -4L;
			foreach (CampCastleElement campCastleElement in list)
			{
				CastleElement castleElement = new CastleElement();
				castleElement.xPos = campCastleElement.xPos;
				castleElement.yPos = campCastleElement.yPos;
				castleElement.elementType = campCastleElement.elementType;
				castleElement.aggressiveDefender = campCastleElement.aggressiveDefender;
				CastleElement castleElement2 = castleElement;
				long num2 = this.localTempElementNumber;
				this.localTempElementNumber = num2 - 1L;
				castleElement2.elementID = num2;
				castleElement.completionTime = DateTime.Now.AddHours(-1.0);
				this.elements.Add(castleElement);
			}
			this.updateLayoutAndRedraw();
		}

		// Token: 0x06000A09 RID: 2569 RVA: 0x000C95C0 File Offset: 0x000C77C0
		public void saveCamp(string filename)
		{
			CampCastleElement[] array = this.castleLayout.createCastleCampArray();
			FileStream fileStream = new FileStream(filename, FileMode.Create);
			BinaryWriter binaryWriter = new BinaryWriter(fileStream);
			int value = array.Length;
			binaryWriter.Write(value);
			CampCastleElement[] array2 = array;
			foreach (CampCastleElement campCastleElement in array2)
			{
				binaryWriter.Write(campCastleElement.xPos);
				binaryWriter.Write(campCastleElement.yPos);
				binaryWriter.Write(campCastleElement.elementType);
				binaryWriter.Write(campCastleElement.aggressiveDefender);
			}
			binaryWriter.Close();
			fileStream.Close();
		}

		// Token: 0x06000A0A RID: 2570 RVA: 0x000C9654 File Offset: 0x000C7854
		private string getTroopsSaveName()
		{
			string settingsPath = GameEngine.getSettingsPath(true);
			string str = "CasTroop_" + GameEngine.Instance.World.GetGlobalWorldID().ToString() + this.m_villageID.ToString() + ".cas";
			return settingsPath + "\\" + str;
		}

		// Token: 0x06000A0B RID: 2571 RVA: 0x000C96A8 File Offset: 0x000C78A8
		private string getInfrastructureSaveName()
		{
			string settingsPath = GameEngine.getSettingsPath(true);
			string str = "CasInfra_" + GameEngine.Instance.World.GetGlobalWorldID().ToString() + this.m_villageID.ToString() + ".cas";
			return settingsPath + "\\" + str;
		}

		// Token: 0x06000A0C RID: 2572 RVA: 0x000C96FC File Offset: 0x000C78FC
		public bool memoriseInfrastructure()
		{
			FileStream fileStream = null;
			BinaryWriter binaryWriter = null;
			bool result;
			try
			{
				CampCastleElement[] array = this.castleLayout.createCastleCampArray_MemoriseInfrastructure();
				fileStream = new FileStream(this.getInfrastructureSaveName(), FileMode.Create);
				binaryWriter = new BinaryWriter(fileStream);
				int value = array.Length;
				binaryWriter.Write(value);
				CampCastleElement[] array2 = array;
				foreach (CampCastleElement campCastleElement in array2)
				{
					binaryWriter.Write(campCastleElement.xPos);
					binaryWriter.Write(campCastleElement.yPos);
					binaryWriter.Write(campCastleElement.elementType);
					binaryWriter.Write(campCastleElement.aggressiveDefender);
				}
				binaryWriter.Close();
				fileStream.Close();
				result = true;
			}
			catch (Exception)
			{
				try
				{
					if (binaryWriter != null)
					{
						binaryWriter.Close();
					}
					if (fileStream != null)
					{
						fileStream.Close();
					}
				}
				catch (Exception)
				{
				}
				result = false;
			}
			return result;
		}

		// Token: 0x06000A0D RID: 2573 RVA: 0x000C97DC File Offset: 0x000C79DC
		public bool memoriseTroops()
		{
			FileStream fileStream = null;
			BinaryWriter binaryWriter = null;
			bool result;
			try
			{
				CampCastleElementLL[] array = this.castleLayout.createCastleCampArray_MemoriseTroops();
				fileStream = new FileStream(this.getTroopsSaveName(), FileMode.Create);
				binaryWriter = new BinaryWriter(fileStream);
				int value = -1;
				binaryWriter.Write(value);
				int value2 = array.Length;
				binaryWriter.Write(value2);
				CampCastleElementLL[] array2 = array;
				foreach (CampCastleElementLL campCastleElementLL in array2)
				{
					binaryWriter.Write(campCastleElementLL.xPos);
					binaryWriter.Write(campCastleElementLL.yPos);
					binaryWriter.Write(campCastleElementLL.elementType);
					binaryWriter.Write(campCastleElementLL.aggressiveDefender);
					binaryWriter.Write(campCastleElementLL.reinforcement);
				}
				binaryWriter.Close();
				fileStream.Close();
				result = true;
			}
			catch (Exception)
			{
				try
				{
					if (binaryWriter != null)
					{
						binaryWriter.Close();
					}
					if (fileStream != null)
					{
						fileStream.Close();
					}
				}
				catch (Exception)
				{
				}
				result = false;
			}
			return result;
		}

		// Token: 0x06000A0E RID: 2574 RVA: 0x000C98D4 File Offset: 0x000C7AD4
		public int restoreTroops()
		{
			List<CampCastleElementLL> list = new List<CampCastleElementLL>();
			try
			{
				FileStream fileStream = new FileStream(this.getTroopsSaveName(), FileMode.Open);
				BinaryReader binaryReader = new BinaryReader(fileStream);
				int num = binaryReader.ReadInt32();
				if (num >= 0)
				{
					for (int i = 0; i < num; i++)
					{
						CampCastleElementLL campCastleElementLL = new CampCastleElementLL();
						campCastleElementLL.xPos = binaryReader.ReadByte();
						campCastleElementLL.yPos = binaryReader.ReadByte();
						campCastleElementLL.elementType = binaryReader.ReadByte();
						campCastleElementLL.aggressiveDefender = binaryReader.ReadBoolean();
						if (campCastleElementLL.elementType > 69)
						{
							list.Add(campCastleElementLL);
						}
					}
				}
				else
				{
					num = binaryReader.ReadInt32();
					for (int j = 0; j < num; j++)
					{
						CampCastleElementLL campCastleElementLL2 = new CampCastleElementLL();
						campCastleElementLL2.xPos = binaryReader.ReadByte();
						campCastleElementLL2.yPos = binaryReader.ReadByte();
						campCastleElementLL2.elementType = binaryReader.ReadByte();
						campCastleElementLL2.aggressiveDefender = binaryReader.ReadBoolean();
						campCastleElementLL2.reinforcement = binaryReader.ReadBoolean();
						if (campCastleElementLL2.elementType > 69)
						{
							list.Add(campCastleElementLL2);
						}
					}
				}
				binaryReader.Close();
				fileStream.Close();
			}
			catch (Exception)
			{
				return -1;
			}
			return this.placeTroops(list);
		}

		// Token: 0x06000A0F RID: 2575 RVA: 0x000C9A08 File Offset: 0x000C7C08
		public int restoreInfrastructure()
		{
			List<CampCastleElement> list = new List<CampCastleElement>();
			try
			{
				FileStream fileStream = new FileStream(this.getInfrastructureSaveName(), FileMode.Open);
				BinaryReader binaryReader = new BinaryReader(fileStream);
				int num = binaryReader.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					CampCastleElement campCastleElement = new CampCastleElement();
					campCastleElement.xPos = binaryReader.ReadByte();
					campCastleElement.yPos = binaryReader.ReadByte();
					campCastleElement.elementType = binaryReader.ReadByte();
					campCastleElement.aggressiveDefender = binaryReader.ReadBoolean();
					if (campCastleElement.elementType < 69 && campCastleElement.elementType != 43)
					{
						list.Add(campCastleElement);
					}
				}
				binaryReader.Close();
				fileStream.Close();
			}
			catch (Exception)
			{
				return -1;
			}
			return this.placeInfrastructure(list);
		}

		// Token: 0x06000A10 RID: 2576 RVA: 0x000C9AD0 File Offset: 0x000C7CD0
		public int placeInfrastructure(List<CampCastleElement> array)
		{
			GameEngine.Instance.stopInterfaceSounds = true;
			int num = 0;
			int num2 = -1;
			foreach (CampCastleElement campCastleElement in array)
			{
				if (this.startPlaceElement((int)campCastleElement.elementType))
				{
					CastleElement castleElement = this.placeBuildingElement((int)campCastleElement.xPos, (int)campCastleElement.yPos, true);
					if (castleElement != null)
					{
						num++;
					}
				}
			}
			if (num > 0)
			{
				GameEngine.Instance.Castle.startPlaceElement_ShowPanel(num2, CastlesCommon.getPieceName(num2), false);
				this.updateLayoutAndRedraw();
				InterfaceMgr.Instance.castleStartBuilderMode();
			}
			this.stopPlaceElement();
			GameEngine.Instance.stopInterfaceSounds = false;
			return num;
		}

		// Token: 0x06000A11 RID: 2577 RVA: 0x0000DBB2 File Offset: 0x0000BDB2
		public bool gotTroopsSave()
		{
			return File.Exists(this.getTroopsSaveName());
		}

		// Token: 0x06000A12 RID: 2578 RVA: 0x0000DBBF File Offset: 0x0000BDBF
		public bool gotInfrastructureSave()
		{
			return File.Exists(this.getInfrastructureSaveName());
		}

		// Token: 0x06000A13 RID: 2579 RVA: 0x000C9B90 File Offset: 0x000C7D90
		public void updateOldAttackSetupFilenames()
		{
			FileStream fileStream = null;
			BinaryWriter binaryWriter = null;
			BinaryReader binaryReader = null;
			List<string> list = new List<string>();
			int num = 0;
			bool flag = false;
			try
			{
				for (int i = 1; i < 6; i++)
				{
					string attackSetupSaveName = this.getAttackSetupSaveName(i);
					if (File.Exists(attackSetupSaveName))
					{
						string attackSetupSaveName2 = this.getAttackSetupSaveName("Formation " + i.ToString());
						File.Move(attackSetupSaveName, attackSetupSaveName2);
						list.Add("Formation " + i.ToString());
						num++;
						flag = true;
					}
				}
				if (flag)
				{
					string settingsPath = GameEngine.getSettingsPath(true);
					string text = "StoredSetupNames.cas";
					text = settingsPath + "\\" + text;
					if (File.Exists(text))
					{
						fileStream = new FileStream(text, FileMode.Open);
						binaryReader = new BinaryReader(fileStream);
						num += binaryReader.ReadInt32();
						for (int j = 0; j < num; j++)
						{
							list.Add(binaryReader.ReadString());
						}
						binaryReader.Close();
						fileStream.Close();
					}
					fileStream = new FileStream(text, FileMode.Create);
					binaryWriter = new BinaryWriter(fileStream);
					binaryWriter.Write(num);
					foreach (string value in list)
					{
						binaryWriter.Write(value);
					}
					binaryWriter.Close();
					fileStream.Close();
				}
			}
			catch (Exception)
			{
				if (fileStream != null)
				{
					fileStream.Close();
				}
				if (binaryReader != null)
				{
					binaryReader.Close();
				}
				if (binaryWriter != null)
				{
					binaryWriter.Close();
				}
			}
		}

		// Token: 0x06000A14 RID: 2580 RVA: 0x000C9D34 File Offset: 0x000C7F34
		public void cleanUpAttackSaveNames()
		{
			char[] separator = new char[]
			{
				'_'
			};
			string[] files = Directory.GetFiles(GameEngine.getSettingsPath(true), "*.cas");
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			List<string> list = new List<string>();
			string[] array = files;
			foreach (string path in array)
			{
				string text = Path.GetFileName(path);
				text = text.Remove(text.LastIndexOf('.'));
				string[] array3 = text.Split(separator);
				if (array3.Length >= 3 && !(array3[0].ToLowerInvariant() != "attacksetup"))
				{
					try
					{
						Convert.ToInt32(array3[array3.Length - 1]);
					}
					catch
					{
						goto IL_108;
					}
					text = "";
					for (int j = 1; j < array3.Length - 1; j++)
					{
						if (j > 1)
						{
							text += "_";
						}
						text += array3[j];
					}
					if (list.Contains(text))
					{
						list.Remove(text);
						dictionary.Add(text, 1);
					}
					else if (!dictionary.ContainsKey(text))
					{
						list.Add(text);
					}
				}
				IL_108:;
			}
			for (int k = 0; k < files.Length; k++)
			{
				try
				{
					string text2 = Path.GetFileName(files[k]);
					text2 = text2.Remove(text2.LastIndexOf('.'));
					string[] array4 = text2.Split(separator);
					string text3 = "";
					if (array4.Length >= 3 && !(array4[0].ToLowerInvariant() != "attacksetup"))
					{
						text2 = "";
						for (int l = 1; l < array4.Length - 1; l++)
						{
							if (l > 1)
							{
								text2 += "_";
							}
							text2 += array4[l];
						}
						if (list.Contains(text2))
						{
							text3 = files[k].Replace("_" + array4[array4.Length - 1], "");
						}
						else if (dictionary.ContainsKey(text2))
						{
							int num;
							dictionary.TryGetValue(text2, out num);
							text3 = files[k].Replace("_" + array4[array4.Length - 1], " (" + num.ToString() + ")");
							Dictionary<string, int> dictionary2 = dictionary;
							string key = text2;
							int num2 = dictionary2[key];
							dictionary2[key] = num2 + 1;
						}
						if (!(text3 == ""))
						{
							File.Move(files[k], text3);
						}
					}
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x06000A15 RID: 2581 RVA: 0x000C9FE4 File Offset: 0x000C81E4
		private string getAttackSetupSaveName(int ID)
		{
			string settingsPath = GameEngine.getSettingsPath(true);
			string str = "AttackSetup_" + ID.ToString() + ".cas";
			return settingsPath + "\\" + str;
		}

		// Token: 0x06000A16 RID: 2582 RVA: 0x000CA01C File Offset: 0x000C821C
		private string getAttackSetupSaveName(string name)
		{
			string settingsPath = GameEngine.getSettingsPath(true);
			string str = "AttackSetup_" + name + ".cas";
			return settingsPath + "\\" + str;
		}

		// Token: 0x06000A17 RID: 2583 RVA: 0x0000DBCC File Offset: 0x0000BDCC
		public bool gotAttackSetupSave(int ID)
		{
			return File.Exists(this.getAttackSetupSaveName(ID));
		}

		// Token: 0x06000A18 RID: 2584 RVA: 0x000CA050 File Offset: 0x000C8250
		public bool canMemoriseAttackSetup()
		{
			CampCastleElement[] array = this.castleLayout.createCastleCampArray_MemoriseAttackSetupTroops();
			return array.Length != 0;
		}

		// Token: 0x06000A19 RID: 2585 RVA: 0x0000DBDA File Offset: 0x0000BDDA
		public CampCastleElement[] getCurrentAttackSetup()
		{
			return this.castleLayout.createCastleCampArray_MemoriseAttackSetupTroops();
		}

		// Token: 0x06000A1A RID: 2586 RVA: 0x000CA070 File Offset: 0x000C8270
		public bool memoriseAttackSetup(int ID)
		{
			FileStream fileStream = null;
			BinaryWriter binaryWriter = null;
			bool result;
			try
			{
				CampCastleElement[] array = this.castleLayout.createCastleCampArray_MemoriseAttackSetupTroops();
				fileStream = new FileStream(this.getAttackSetupSaveName(ID), FileMode.Create);
				binaryWriter = new BinaryWriter(fileStream);
				int value = array.Length;
				binaryWriter.Write(value);
				CampCastleElement[] array2 = array;
				foreach (CampCastleElement campCastleElement in array2)
				{
					binaryWriter.Write(campCastleElement.xPos);
					binaryWriter.Write(campCastleElement.yPos);
					binaryWriter.Write(campCastleElement.elementType);
					if (campCastleElement.elementType == 94)
					{
						Point catapultAttackLocation = this.getCatapultAttackLocation((int)campCastleElement.xPos, (int)campCastleElement.yPos);
						binaryWriter.Write((byte)catapultAttackLocation.X);
						binaryWriter.Write((byte)catapultAttackLocation.Y);
					}
					if (campCastleElement.elementType >= 100 && campCastleElement.elementType < 109)
					{
						int captainsDelayValue = this.getCaptainsDelayValue((int)campCastleElement.xPos, (int)campCastleElement.yPos);
						binaryWriter.Write((byte)captainsDelayValue);
						if (campCastleElement.elementType == 102 || campCastleElement.elementType == 103)
						{
							Point catapultAttackLocation2 = this.getCatapultAttackLocation((int)campCastleElement.xPos, (int)campCastleElement.yPos);
							binaryWriter.Write((byte)catapultAttackLocation2.X);
							binaryWriter.Write((byte)catapultAttackLocation2.Y);
						}
					}
				}
				binaryWriter.Close();
				fileStream.Close();
				result = true;
			}
			catch (Exception)
			{
				try
				{
					if (binaryWriter != null)
					{
						binaryWriter.Close();
					}
					if (fileStream != null)
					{
						fileStream.Close();
					}
				}
				catch (Exception)
				{
				}
				result = false;
			}
			return result;
		}

		// Token: 0x06000A1B RID: 2587 RVA: 0x000CA21C File Offset: 0x000C841C
		public bool memoriseAttackSetup(string name)
		{
			FileStream fileStream = null;
			BinaryWriter binaryWriter = null;
			bool result;
			try
			{
				CampCastleElement[] array = this.castleLayout.createCastleCampArray_MemoriseAttackSetupTroops();
				fileStream = new FileStream(this.getAttackSetupSaveName(name), FileMode.Create);
				binaryWriter = new BinaryWriter(fileStream);
				int value = array.Length;
				binaryWriter.Write(value);
				CampCastleElement[] array2 = array;
				foreach (CampCastleElement campCastleElement in array2)
				{
					binaryWriter.Write(campCastleElement.xPos);
					binaryWriter.Write(campCastleElement.yPos);
					binaryWriter.Write(campCastleElement.elementType);
					if (campCastleElement.elementType == 94)
					{
						Point catapultAttackLocation = this.getCatapultAttackLocation((int)campCastleElement.xPos, (int)campCastleElement.yPos);
						binaryWriter.Write((byte)catapultAttackLocation.X);
						binaryWriter.Write((byte)catapultAttackLocation.Y);
					}
					if (campCastleElement.elementType >= 100 && campCastleElement.elementType < 109)
					{
						int captainsDelayValue = this.getCaptainsDelayValue((int)campCastleElement.xPos, (int)campCastleElement.yPos);
						binaryWriter.Write((byte)captainsDelayValue);
						if (campCastleElement.elementType == 102 || campCastleElement.elementType == 103)
						{
							Point catapultAttackLocation2 = this.getCatapultAttackLocation((int)campCastleElement.xPos, (int)campCastleElement.yPos);
							binaryWriter.Write((byte)catapultAttackLocation2.X);
							binaryWriter.Write((byte)catapultAttackLocation2.Y);
						}
					}
				}
				binaryWriter.Close();
				fileStream.Close();
				result = true;
			}
			catch (Exception)
			{
				try
				{
					if (binaryWriter != null)
					{
						binaryWriter.Close();
					}
					if (fileStream != null)
					{
						fileStream.Close();
					}
				}
				catch (Exception)
				{
				}
				result = false;
			}
			return result;
		}

		// Token: 0x06000A1C RID: 2588 RVA: 0x000CA3C8 File Offset: 0x000C85C8
		public bool deleteAttackSetup(string name)
		{
			bool result;
			try
			{
				File.Delete(this.getAttackSetupSaveName(name));
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000A1D RID: 2589 RVA: 0x000CA3FC File Offset: 0x000C85FC
		public bool renameAttackSetup(string oldName, string newName)
		{
			string attackSetupSaveName = this.getAttackSetupSaveName(oldName);
			string attackSetupSaveName2 = this.getAttackSetupSaveName(newName);
			if (File.Exists(attackSetupSaveName))
			{
				File.Move(attackSetupSaveName, attackSetupSaveName2);
				return true;
			}
			return false;
		}

		// Token: 0x06000A1E RID: 2590 RVA: 0x000CA42C File Offset: 0x000C862C
		private bool validateCatapultRange(int xPos, int yPos, int xTarg, int yTarg, int radius)
		{
			int num = (xPos - xTarg) * (xPos - xTarg) + (yPos - yTarg) * (yPos - yTarg);
			return num < radius * radius && xTarg >= 33 && yTarg >= 33 && xTarg < 85 && yTarg < 85;
		}

		// Token: 0x06000A1F RID: 2591 RVA: 0x000CA470 File Offset: 0x000C8670
		public bool restoreAttackSetup(int ID)
		{
			List<CastleMap.RestoreCastleElement> list = new List<CastleMap.RestoreCastleElement>();
			try
			{
				FileStream fileStream = new FileStream(this.getAttackSetupSaveName(ID), FileMode.Open);
				BinaryReader binaryReader = new BinaryReader(fileStream);
				int num = binaryReader.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					CastleMap.RestoreCastleElement restoreCastleElement = new CastleMap.RestoreCastleElement();
					restoreCastleElement.xPos = binaryReader.ReadByte();
					restoreCastleElement.yPos = binaryReader.ReadByte();
					restoreCastleElement.elementType = binaryReader.ReadByte();
					if (restoreCastleElement.elementType == 94)
					{
						restoreCastleElement.targXPos = binaryReader.ReadByte();
						restoreCastleElement.targYPos = binaryReader.ReadByte();
					}
					if (restoreCastleElement.elementType >= 100 && restoreCastleElement.elementType < 109)
					{
						restoreCastleElement.delay = binaryReader.ReadByte();
						if (restoreCastleElement.elementType == 102 || restoreCastleElement.elementType == 103)
						{
							restoreCastleElement.targXPos = binaryReader.ReadByte();
							restoreCastleElement.targYPos = binaryReader.ReadByte();
						}
					}
					list.Add(restoreCastleElement);
				}
				binaryReader.Close();
				fileStream.Close();
			}
			catch (Exception)
			{
				return false;
			}
			GameEngine.Instance.stopInterfaceSounds = true;
			int num2 = 0;
			int num3 = -1;
			foreach (CastleMap.RestoreCastleElement restoreCastleElement2 in list)
			{
				int elementType = (int)restoreCastleElement2.elementType;
				if (restoreCastleElement2.elementType >= 100 && restoreCastleElement2.elementType < 109)
				{
					restoreCastleElement2.elementType = 100;
				}
				this.startPlacingAttackerTroops((int)restoreCastleElement2.elementType);
				this.CurrentBrushSize = CastleMap.BrushSize.BRUSH_1X1;
				if (this.mouseMovePlaceTroops((int)restoreCastleElement2.xPos, (int)restoreCastleElement2.yPos, true, 0))
				{
					CastleElement castleElement = this.troopPlaceAttacker((int)restoreCastleElement2.xPos, (int)restoreCastleElement2.yPos);
					num3 = (int)restoreCastleElement2.elementType;
					num2++;
					if (restoreCastleElement2.elementType == 94)
					{
						foreach (CatapultTarget catapultTarget in this.catapultTargets)
						{
							if (catapultTarget.elemID == castleElement.elementID)
							{
								catapultTarget.xPos = restoreCastleElement2.targXPos;
								catapultTarget.yPos = restoreCastleElement2.targYPos;
								if (!this.validateCatapultRange((int)restoreCastleElement2.xPos, (int)restoreCastleElement2.yPos, (int)catapultTarget.xPos, (int)catapultTarget.yPos, GameEngine.Instance.LocalWorldData.Castle_Catapult_MaxRange))
								{
									catapultTarget.createDefaultLocation((int)restoreCastleElement2.xPos, (int)restoreCastleElement2.yPos, castleElement);
									break;
								}
								break;
							}
						}
					}
					if (restoreCastleElement2.elementType >= 100 && restoreCastleElement2.elementType < 109)
					{
						foreach (CaptainsDetails captainsDetails in this.captainsDetails)
						{
							if (captainsDetails.elemID == castleElement.elementID)
							{
								captainsDetails.seconds = restoreCastleElement2.delay;
								break;
							}
						}
						if (elementType != 100)
						{
							castleElement.elementType = (byte)elementType;
						}
						if (elementType == 102 || elementType == 103)
						{
							this.addNewCatapultTargetDefault(castleElement);
							foreach (CatapultTarget catapultTarget2 in this.catapultTargets)
							{
								if (catapultTarget2.elemID == castleElement.elementID)
								{
									catapultTarget2.xPos = restoreCastleElement2.targXPos;
									catapultTarget2.yPos = restoreCastleElement2.targYPos;
									break;
								}
							}
						}
					}
					CastlesCommon.buildCastleLayoutClient(this.elements, ref this.castleLayout);
				}
			}
			if (num3 >= 0)
			{
				this.startPlaceElement_ShowPanel(num3, CastlesCommon.getPieceName(num3), false);
				this.updateLayoutAndRedraw();
				InterfaceMgr.Instance.castleStartBuilderMode();
			}
			this.stopPlaceElement();
			GameEngine.Instance.stopInterfaceSounds = false;
			return true;
		}

		// Token: 0x06000A20 RID: 2592 RVA: 0x000CA8B4 File Offset: 0x000C8AB4
		public bool restoreAttackSetup(string name)
		{
			List<CastleMap.RestoreCastleElement> list = new List<CastleMap.RestoreCastleElement>();
			try
			{
				FileStream fileStream = new FileStream(this.getAttackSetupSaveName(name), FileMode.Open);
				BinaryReader binaryReader = new BinaryReader(fileStream);
				int num = binaryReader.ReadInt32();
				int i = 0;
				while (i < num)
				{
					CastleMap.RestoreCastleElement restoreCastleElement = new CastleMap.RestoreCastleElement();
					restoreCastleElement.xPos = binaryReader.ReadByte();
					restoreCastleElement.yPos = binaryReader.ReadByte();
					restoreCastleElement.elementType = binaryReader.ReadByte();
					if (restoreCastleElement.elementType == 94)
					{
						restoreCastleElement.targXPos = binaryReader.ReadByte();
						restoreCastleElement.targYPos = binaryReader.ReadByte();
					}
					if (restoreCastleElement.elementType < 100 || restoreCastleElement.elementType >= 109)
					{
						goto IL_152;
					}
					restoreCastleElement.delay = binaryReader.ReadByte();
					if (restoreCastleElement.elementType == 102 || restoreCastleElement.elementType == 103)
					{
						restoreCastleElement.targXPos = binaryReader.ReadByte();
						restoreCastleElement.targYPos = binaryReader.ReadByte();
					}
					bool flag = false;
					int research_Tactics = (int)GameEngine.Instance.World.UserResearchData.Research_Tactics;
					switch (restoreCastleElement.elementType)
					{
					case 100:
						flag = true;
						break;
					case 101:
						if (research_Tactics > 0)
						{
							flag = true;
						}
						break;
					case 102:
						if (research_Tactics > 1)
						{
							flag = true;
						}
						break;
					case 103:
						if (research_Tactics > 3)
						{
							flag = true;
						}
						break;
					case 104:
						if (research_Tactics > 2)
						{
							flag = true;
						}
						break;
					}
					if (flag)
					{
						goto IL_152;
					}
					IL_15A:
					i++;
					continue;
					IL_152:
					list.Add(restoreCastleElement);
					goto IL_15A;
				}
				binaryReader.Close();
				fileStream.Close();
			}
			catch (Exception)
			{
				return false;
			}
			GameEngine.Instance.stopInterfaceSounds = true;
			int num2 = 0;
			int num3 = -1;
			foreach (CastleMap.RestoreCastleElement restoreCastleElement2 in list)
			{
				int elementType = (int)restoreCastleElement2.elementType;
				if (restoreCastleElement2.elementType >= 100 && restoreCastleElement2.elementType < 109)
				{
					restoreCastleElement2.elementType = 100;
				}
				this.startPlacingAttackerTroops((int)restoreCastleElement2.elementType);
				this.CurrentBrushSize = CastleMap.BrushSize.BRUSH_1X1;
				if (this.mouseMovePlaceTroops((int)restoreCastleElement2.xPos, (int)restoreCastleElement2.yPos, true, 0))
				{
					CastleElement castleElement = this.troopPlaceAttacker((int)restoreCastleElement2.xPos, (int)restoreCastleElement2.yPos);
					num3 = (int)restoreCastleElement2.elementType;
					num2++;
					if (restoreCastleElement2.elementType == 94)
					{
						foreach (CatapultTarget catapultTarget in this.catapultTargets)
						{
							if (catapultTarget.elemID == castleElement.elementID)
							{
								catapultTarget.xPos = restoreCastleElement2.targXPos;
								catapultTarget.yPos = restoreCastleElement2.targYPos;
								if (!this.validateCatapultRange((int)restoreCastleElement2.xPos, (int)restoreCastleElement2.yPos, (int)catapultTarget.xPos, (int)catapultTarget.yPos, GameEngine.Instance.LocalWorldData.Castle_Catapult_MaxRange))
								{
									catapultTarget.createDefaultLocation((int)restoreCastleElement2.xPos, (int)restoreCastleElement2.yPos, castleElement);
									break;
								}
								break;
							}
						}
					}
					if (restoreCastleElement2.elementType >= 100 && restoreCastleElement2.elementType < 109)
					{
						foreach (CaptainsDetails captainsDetails in this.captainsDetails)
						{
							if (captainsDetails.elemID == castleElement.elementID)
							{
								captainsDetails.seconds = restoreCastleElement2.delay;
								break;
							}
						}
						if (elementType != 100)
						{
							castleElement.elementType = (byte)elementType;
						}
						if (elementType == 102 || elementType == 103)
						{
							this.addNewCatapultTargetDefault(castleElement);
							foreach (CatapultTarget catapultTarget2 in this.catapultTargets)
							{
								if (catapultTarget2.elemID == castleElement.elementID)
								{
									catapultTarget2.xPos = restoreCastleElement2.targXPos;
									catapultTarget2.yPos = restoreCastleElement2.targYPos;
									break;
								}
							}
						}
					}
					CastlesCommon.buildCastleLayoutClient(this.elements, ref this.castleLayout);
				}
			}
			if (num3 >= 0)
			{
				this.startPlaceElement_ShowPanel(num3, CastlesCommon.getPieceName(num3), false);
				this.updateLayoutAndRedraw();
				InterfaceMgr.Instance.castleStartBuilderMode();
			}
			this.stopPlaceElement();
			GameEngine.Instance.stopInterfaceSounds = false;
			return true;
		}

		// Token: 0x06000A21 RID: 2593 RVA: 0x000CAD70 File Offset: 0x000C8F70
		public List<CastleMap.RestoreCastleElement> getAttackSetup(string name)
		{
			List<CastleMap.RestoreCastleElement> list = new List<CastleMap.RestoreCastleElement>();
			List<CastleMap.RestoreCastleElement> result;
			try
			{
				FileStream fileStream = new FileStream(this.getAttackSetupSaveName(name), FileMode.Open);
				BinaryReader binaryReader = new BinaryReader(fileStream);
				int num = binaryReader.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					CastleMap.RestoreCastleElement restoreCastleElement = new CastleMap.RestoreCastleElement();
					restoreCastleElement.xPos = binaryReader.ReadByte();
					restoreCastleElement.yPos = binaryReader.ReadByte();
					restoreCastleElement.elementType = binaryReader.ReadByte();
					if (restoreCastleElement.elementType == 94)
					{
						restoreCastleElement.targXPos = binaryReader.ReadByte();
						restoreCastleElement.targYPos = binaryReader.ReadByte();
					}
					if (restoreCastleElement.elementType >= 100 && restoreCastleElement.elementType < 109)
					{
						restoreCastleElement.delay = binaryReader.ReadByte();
						if (restoreCastleElement.elementType == 102 || restoreCastleElement.elementType == 103)
						{
							restoreCastleElement.targXPos = binaryReader.ReadByte();
							restoreCastleElement.targYPos = binaryReader.ReadByte();
						}
					}
					list.Add(restoreCastleElement);
				}
				binaryReader.Close();
				fileStream.Close();
				result = list;
			}
			catch (Exception)
			{
				list.Clear();
				result = list;
			}
			return result;
		}

		// Token: 0x06000A22 RID: 2594 RVA: 0x000CAE94 File Offset: 0x000C9094
		private Point getCatapultAttackLocation(int x, int y)
		{
			Point result = new Point(-1, -1);
			foreach (CastleElement castleElement in this.elements)
			{
				if ((int)castleElement.xPos == x && (int)castleElement.yPos == y)
				{
					long elementID = castleElement.elementID;
					foreach (CatapultTarget catapultTarget in this.catapultTargets)
					{
						if (catapultTarget.elemID == elementID)
						{
							result.X = (int)catapultTarget.xPos;
							result.Y = (int)catapultTarget.yPos;
							return result;
						}
					}
					return result;
				}
			}
			return result;
		}

		// Token: 0x06000A23 RID: 2595 RVA: 0x000CAF7C File Offset: 0x000C917C
		private int getCaptainsDelayValue(int x, int y)
		{
			foreach (CastleElement castleElement in this.elements)
			{
				if ((int)castleElement.xPos == x && (int)castleElement.yPos == y)
				{
					long elementID = castleElement.elementID;
					using (List<CaptainsDetails>.Enumerator enumerator2 = this.captainsDetails.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							CaptainsDetails captainsDetails = enumerator2.Current;
							if (captainsDetails.elemID == elementID)
							{
								return (int)captainsDetails.seconds;
							}
						}
						break;
					}
				}
			}
			return 5;
		}

		// Token: 0x06000A24 RID: 2596 RVA: 0x0000DBE7 File Offset: 0x0000BDE7
		public void pauseBattle()
		{
			Sound.pauseEnvironmental(true);
			this.castleCombat.pause(true);
		}

		// Token: 0x06000A25 RID: 2597 RVA: 0x0000DBFB File Offset: 0x0000BDFB
		public void unpauseBattle()
		{
			Sound.pauseEnvironmental(false);
			this.castleCombat.pause(false);
		}

		// Token: 0x06000A26 RID: 2598 RVA: 0x000CB038 File Offset: 0x000C9238
		public CastleMapPreset generateAttackPreset(string name)
		{
			CampCastleElement[] array = this.castleLayout.createCastleCampArray_MemoriseAttackSetupTroops();
			CastleMapPreset castleMapPreset = new CastleMapPreset(name, DateTime.Now, PresetType.TROOP_ATTACK, array.Length);
			StringBuilder stringBuilder = new StringBuilder();
			CampCastleElement[] array2 = array;
			foreach (CampCastleElement campCastleElement in array2)
			{
				stringBuilder.Append(campCastleElement.xPos.ToString() + " ");
				stringBuilder.Append(campCastleElement.yPos.ToString() + " ");
				stringBuilder.Append(campCastleElement.elementType.ToString() + " ");
				CastleMapPreset.CastleElementInfo castleElementInfo = new CastleMapPreset.CastleElementInfo();
				castleElementInfo.xPos = campCastleElement.xPos;
				castleElementInfo.yPos = campCastleElement.yPos;
				castleElementInfo.elementType = campCastleElement.elementType;
				castleMapPreset.BasicData.Add(castleElementInfo);
				if (campCastleElement.elementType == 94)
				{
					Point catapultAttackLocation = this.getCatapultAttackLocation((int)campCastleElement.xPos, (int)campCastleElement.yPos);
					stringBuilder.Append(catapultAttackLocation.X.ToString() + " ");
					stringBuilder.Append(catapultAttackLocation.Y.ToString() + " ");
				}
				if (campCastleElement.elementType >= 100 && campCastleElement.elementType < 109)
				{
					stringBuilder.Append(this.getCaptainsDelayValue((int)campCastleElement.xPos, (int)campCastleElement.yPos).ToString() + " ");
					if (campCastleElement.elementType == 102 || campCastleElement.elementType == 103)
					{
						Point catapultAttackLocation2 = this.getCatapultAttackLocation((int)campCastleElement.xPos, (int)campCastleElement.yPos);
						stringBuilder.Append(catapultAttackLocation2.X.ToString() + " ");
						stringBuilder.Append(catapultAttackLocation2.Y.ToString() + " ");
					}
				}
			}
			castleMapPreset.Data = stringBuilder.ToString();
			return castleMapPreset;
		}

		// Token: 0x06000A27 RID: 2599 RVA: 0x000CB24C File Offset: 0x000C944C
		public CastleMapPreset generateTroopsPreset(string name)
		{
			CampCastleElementLL[] array = this.castleLayout.createCastleCampArray_MemoriseTroops();
			CastleMapPreset castleMapPreset = new CastleMapPreset(name, DateTime.Now, PresetType.TROOP_DEFEND, array.Length);
			StringBuilder stringBuilder = new StringBuilder();
			CampCastleElementLL[] array2 = array;
			foreach (CampCastleElementLL campCastleElementLL in array2)
			{
				stringBuilder.Append(campCastleElementLL.xPos.ToString() + " ");
				stringBuilder.Append(campCastleElementLL.yPos.ToString() + " ");
				stringBuilder.Append(campCastleElementLL.elementType.ToString() + " ");
				stringBuilder.Append((campCastleElementLL.aggressiveDefender ? 1 : 0).ToString() + " ");
				stringBuilder.Append((campCastleElementLL.reinforcement ? 1 : 0).ToString() + " ");
				CastleMapPreset.CastleElementInfo castleElementInfo = new CastleMapPreset.CastleElementInfo();
				castleElementInfo.xPos = campCastleElementLL.xPos;
				castleElementInfo.yPos = campCastleElementLL.yPos;
				castleElementInfo.elementType = campCastleElementLL.elementType;
				castleElementInfo.reinforcement = campCastleElementLL.reinforcement;
				castleMapPreset.BasicData.Add(castleElementInfo);
			}
			castleMapPreset.Data = stringBuilder.ToString();
			return castleMapPreset;
		}

		// Token: 0x06000A28 RID: 2600 RVA: 0x000CB3A0 File Offset: 0x000C95A0
		public CastleMapPreset generateInfrastructurePreset(string name)
		{
			CampCastleElement[] array = this.castleLayout.createCastleCampArray_MemoriseInfrastructure();
			CastleMapPreset castleMapPreset = new CastleMapPreset(name, DateTime.Now, PresetType.INFRASTRUCTURE, array.Length);
			StringBuilder stringBuilder = new StringBuilder();
			CampCastleElement[] array2 = array;
			foreach (CampCastleElement campCastleElement in array2)
			{
				stringBuilder.Append(campCastleElement.xPos.ToString() + " ");
				stringBuilder.Append(campCastleElement.yPos.ToString() + " ");
				stringBuilder.Append(campCastleElement.elementType.ToString() + " ");
				stringBuilder.Append((campCastleElement.aggressiveDefender ? 1 : 0).ToString() + " ");
				CastleMapPreset.CastleElementInfo castleElementInfo = new CastleMapPreset.CastleElementInfo();
				castleElementInfo.xPos = campCastleElement.xPos;
				castleElementInfo.yPos = campCastleElement.yPos;
				castleElementInfo.elementType = campCastleElement.elementType;
				castleMapPreset.BasicData.Add(castleElementInfo);
			}
			castleMapPreset.Data = stringBuilder.ToString();
			return castleMapPreset;
		}

		// Token: 0x06000A29 RID: 2601 RVA: 0x000CB4C0 File Offset: 0x000C96C0
		public bool restoreAttackPreset(CastleMapPreset preset)
		{
			List<CastleMap.RestoreCastleElement> list = new List<CastleMap.RestoreCastleElement>();
			string[] array = preset.Data.Split(new char[]
			{
				' '
			});
			int num = 0;
			int i = 0;
			while (i < preset.ElementCount)
			{
				CastleMap.RestoreCastleElement restoreCastleElement = new CastleMap.RestoreCastleElement();
				restoreCastleElement.xPos = Convert.ToByte(array[num++]);
				restoreCastleElement.yPos = Convert.ToByte(array[num++]);
				restoreCastleElement.elementType = Convert.ToByte(array[num++]);
				if (restoreCastleElement.elementType == 94)
				{
					restoreCastleElement.targXPos = Convert.ToByte(array[num++]);
					restoreCastleElement.targYPos = Convert.ToByte(array[num++]);
				}
				if (restoreCastleElement.elementType < 100 || restoreCastleElement.elementType >= 109)
				{
					goto IL_174;
				}
				restoreCastleElement.delay = Convert.ToByte(array[num++]);
				if (restoreCastleElement.elementType == 102 || restoreCastleElement.elementType == 103)
				{
					restoreCastleElement.targXPos = Convert.ToByte(array[num++]);
					restoreCastleElement.targYPos = Convert.ToByte(array[num++]);
				}
				bool flag = false;
				int research_Tactics = (int)GameEngine.Instance.World.UserResearchData.Research_Tactics;
				switch (restoreCastleElement.elementType)
				{
				case 100:
					flag = true;
					break;
				case 101:
					if (research_Tactics > 0)
					{
						flag = true;
					}
					break;
				case 102:
					if (research_Tactics > 1)
					{
						flag = true;
					}
					break;
				case 103:
					if (research_Tactics > 3)
					{
						flag = true;
					}
					break;
				case 104:
					if (research_Tactics > 2)
					{
						flag = true;
					}
					break;
				}
				if (flag)
				{
					goto IL_174;
				}
				IL_17C:
				i++;
				continue;
				IL_174:
				list.Add(restoreCastleElement);
				goto IL_17C;
			}
			GameEngine.Instance.stopInterfaceSounds = true;
			int num2 = 0;
			int num3 = -1;
			foreach (CastleMap.RestoreCastleElement restoreCastleElement2 in list)
			{
				int elementType = (int)restoreCastleElement2.elementType;
				if (restoreCastleElement2.elementType >= 100 && restoreCastleElement2.elementType < 109)
				{
					restoreCastleElement2.elementType = 100;
				}
				this.startPlacingAttackerTroops((int)restoreCastleElement2.elementType);
				this.CurrentBrushSize = CastleMap.BrushSize.BRUSH_1X1;
				if (this.mouseMovePlaceTroops((int)restoreCastleElement2.xPos, (int)restoreCastleElement2.yPos, true, 0))
				{
					CastleElement castleElement = this.troopPlaceAttacker((int)restoreCastleElement2.xPos, (int)restoreCastleElement2.yPos);
					num3 = (int)restoreCastleElement2.elementType;
					num2++;
					if (restoreCastleElement2.elementType == 94)
					{
						foreach (CatapultTarget catapultTarget in this.catapultTargets)
						{
							if (catapultTarget.elemID == castleElement.elementID)
							{
								catapultTarget.xPos = restoreCastleElement2.targXPos;
								catapultTarget.yPos = restoreCastleElement2.targYPos;
								break;
							}
						}
					}
					if (restoreCastleElement2.elementType >= 100 && restoreCastleElement2.elementType < 109)
					{
						foreach (CaptainsDetails captainsDetails in this.captainsDetails)
						{
							if (captainsDetails.elemID == castleElement.elementID)
							{
								captainsDetails.seconds = restoreCastleElement2.delay;
								break;
							}
						}
						if (elementType != 100)
						{
							castleElement.elementType = (byte)elementType;
						}
						if (elementType == 102 || elementType == 103)
						{
							this.addNewCatapultTargetDefault(castleElement);
							foreach (CatapultTarget catapultTarget2 in this.catapultTargets)
							{
								if (catapultTarget2.elemID == castleElement.elementID)
								{
									catapultTarget2.xPos = restoreCastleElement2.targXPos;
									catapultTarget2.yPos = restoreCastleElement2.targYPos;
									break;
								}
							}
						}
					}
					CastlesCommon.buildCastleLayoutClient(this.elements, ref this.castleLayout);
				}
			}
			if (num3 >= 0)
			{
				this.startPlaceElement_ShowPanel(num3, CastlesCommon.getPieceName(num3), false);
				CastlesCommon.buildCastleLayoutClient(this.elements, ref this.castleLayout);
				this.recalcCastleLayout();
				InterfaceMgr.Instance.castleStartBuilderMode();
			}
			this.stopPlaceElement();
			GameEngine.Instance.stopInterfaceSounds = false;
			return true;
		}

		// Token: 0x06000A2A RID: 2602 RVA: 0x000CB930 File Offset: 0x000C9B30
		public int restoreTroopsPreset(CastleMapPreset preset)
		{
			List<CampCastleElementLL> list = new List<CampCastleElementLL>();
			string[] array = preset.Data.Split(new char[]
			{
				' '
			});
			int num = 0;
			for (int i = 0; i < preset.ElementCount; i++)
			{
				CampCastleElementLL campCastleElementLL = new CampCastleElementLL();
				campCastleElementLL.xPos = Convert.ToByte(array[num++]);
				campCastleElementLL.yPos = Convert.ToByte(array[num++]);
				campCastleElementLL.elementType = Convert.ToByte(array[num++]);
				campCastleElementLL.aggressiveDefender = (Convert.ToByte(array[num++]) == 1);
				campCastleElementLL.reinforcement = (Convert.ToByte(array[num++]) == 1);
				if (campCastleElementLL.elementType > 69)
				{
					list.Add(campCastleElementLL);
				}
			}
			return this.placeTroops(list);
		}

		// Token: 0x06000A2B RID: 2603 RVA: 0x000CB9FC File Offset: 0x000C9BFC
		public int restoreInfrastructurePreset(CastleMapPreset preset)
		{
			List<CampCastleElement> list = new List<CampCastleElement>();
			string[] array = preset.Data.Split(new char[]
			{
				' '
			});
			int num = 0;
			for (int i = 0; i < preset.ElementCount; i++)
			{
				CampCastleElement campCastleElement = new CampCastleElement();
				campCastleElement.xPos = Convert.ToByte(array[num++]);
				campCastleElement.yPos = Convert.ToByte(array[num++]);
				campCastleElement.elementType = Convert.ToByte(array[num++]);
				campCastleElement.aggressiveDefender = (Convert.ToByte(array[num++]) == 1);
				if (campCastleElement.elementType < 69 && campCastleElement.elementType != 43)
				{
					list.Add(campCastleElement);
				}
			}
			return this.placeInfrastructure(list);
		}

		// Token: 0x06000A2C RID: 2604 RVA: 0x000CBAB8 File Offset: 0x000C9CB8
		public static void PopulateBasicInfo(CastleMapPreset preset)
		{
			preset.BasicData.Clear();
			string[] array = preset.Data.Split(new char[]
			{
				' '
			});
			int num = 0;
			for (int i = 0; i < preset.ElementCount; i++)
			{
				bool flag = true;
				CastleMapPreset.CastleElementInfo castleElementInfo = new CastleMapPreset.CastleElementInfo();
				castleElementInfo.xPos = Convert.ToByte(array[num++]);
				castleElementInfo.yPos = Convert.ToByte(array[num++]);
				castleElementInfo.elementType = Convert.ToByte(array[num++]);
				switch (preset.Type)
				{
				case PresetType.TROOP_ATTACK:
					if (castleElementInfo.elementType == 94)
					{
						num += 2;
					}
					if (castleElementInfo.elementType >= 100 && castleElementInfo.elementType < 109)
					{
						num++;
						if (castleElementInfo.elementType == 102 || castleElementInfo.elementType == 103)
						{
							num += 2;
						}
					}
					break;
				case PresetType.TROOP_DEFEND:
					num++;
					castleElementInfo.reinforcement = (Convert.ToByte(array[num++]) == 1);
					flag = (castleElementInfo.elementType > 69);
					break;
				case PresetType.INFRASTRUCTURE:
					num++;
					flag = (castleElementInfo.elementType < 69 && castleElementInfo.elementType != 43);
					break;
				}
				if (flag)
				{
					preset.BasicData.Add(castleElementInfo);
				}
			}
		}

		// Token: 0x06000A2D RID: 2605 RVA: 0x000CBC04 File Offset: 0x000C9E04
		public void resizePlacement(Point delta)
		{
			if (delta.X != 0 || delta.Y != 0)
			{
				this.PlacementMoved = true;
			}
			if (this.gesture == CastleMap.Gesture.RESIZING_NORTHWEST)
			{
				if (this.startWallMapY + delta.Y > this.lastMoveTileY)
				{
					this.m_gesture = CastleMap.Gesture.RESIZING_SOUTHEAST;
					this.lastMoveTileY = Math.Max(this.startWallMapY, this.lastMoveTileY + delta.Y);
				}
				else
				{
					this.startWallMapY = Math.Min(this.lastMoveTileY, this.startWallMapY + delta.Y);
				}
			}
			else if (this.gesture == CastleMap.Gesture.RESIZING_SOUTHEAST)
			{
				if (this.lastMoveTileY + delta.Y < this.startWallMapY)
				{
					this.m_gesture = CastleMap.Gesture.RESIZING_NORTHWEST;
					this.startWallMapY = Math.Min(this.lastMoveTileY, this.startWallMapY + delta.Y);
				}
				else
				{
					this.lastMoveTileY = Math.Max(this.startWallMapY, this.lastMoveTileY + delta.Y);
				}
			}
			if (this.gesture == CastleMap.Gesture.RESIZING_SOUTHWEST)
			{
				if (this.startWallMapX + delta.Y > this.lastMoveTileX)
				{
					this.m_gesture = CastleMap.Gesture.RESIZING_NORTHEAST;
					this.lastMoveTileX = Math.Max(this.startWallMapX, this.lastMoveTileX + delta.X);
				}
				else
				{
					this.startWallMapX = Math.Min(this.lastMoveTileX, this.startWallMapX + delta.X);
				}
			}
			else if (this.gesture == CastleMap.Gesture.RESIZING_NORTHEAST)
			{
				if (this.lastMoveTileX + delta.X < this.startWallMapX)
				{
					this.m_gesture = CastleMap.Gesture.RESIZING_SOUTHWEST;
					this.startWallMapX = Math.Min(this.lastMoveTileX, this.startWallMapX + delta.X);
				}
				else
				{
					this.lastMoveTileX = Math.Max(this.startWallMapX, this.lastMoveTileX + delta.X);
				}
			}
			if (this.isPlacingResizableElement())
			{
				this.wallMouseMove(this.lastMoveTileX, this.lastMoveTileY, true);
			}
		}

		// Token: 0x06000A2E RID: 2606 RVA: 0x000CBDE8 File Offset: 0x000C9FE8
		public void rotatePlacement()
		{
			Size size = new Size(this.lastMoveTileX - this.startWallMapX, this.lastMoveTileY - this.startWallMapY);
			this.startWallMapX = this.lastMoveTileX - size.Height;
			this.lastMoveTileY = this.startWallMapY + size.Width;
			this.wallMouseMove(this.lastMoveTileX, this.lastMoveTileY, true);
		}

		// Token: 0x06000A2F RID: 2607 RVA: 0x000CBE54 File Offset: 0x000CA054
		public static Research getCastleBuildingTechRequirement(int pieceType)
		{
			if (pieceType <= 40)
			{
				switch (pieceType)
				{
				case 11:
					return new Research(23, 4);
				case 12:
					return new Research(23, 5);
				case 13:
					return new Research(23, 7);
				case 14:
					return new Research(23, 8);
				default:
					switch (pieceType)
					{
					case 21:
						return new Research(23, 2);
					case 22:
					case 23:
					case 24:
					case 25:
					case 26:
					case 27:
					case 28:
					case 29:
					case 30:
						goto IL_109;
					case 31:
						return new Research(21, 1);
					case 32:
						return new Research(21, 5);
					case 33:
						break;
					case 34:
						goto IL_D3;
					case 35:
						return new Research(21, 7);
					case 36:
						return new Research(21, 2);
					case 37:
					case 38:
						return new Research(23, 6);
					case 39:
					case 40:
						return new Research(23, 1);
					default:
						goto IL_109;
					}
					break;
				}
			}
			else
			{
				if (pieceType == 65)
				{
					goto IL_D3;
				}
				if (pieceType != 66)
				{
					if (pieceType == 75)
					{
						return new Research(21, 5);
					}
					goto IL_109;
				}
			}
			return new Research(23, 1);
			IL_D3:
			return new Research(23, 3);
			IL_109:
			return null;
		}

		// Token: 0x06000A30 RID: 2608 RVA: 0x000CBF6C File Offset: 0x000CA16C
		public bool HasEnoughTroopsToPlace(ref int[] array)
		{
			array[6] = this.attackMaxPeasants;
			array[7] = this.attackMaxArchers;
			array[8] = this.attackMaxPikemen;
			array[9] = this.attackMaxSwordsmen;
			array[10] = this.attackMaxCatapults;
			array[11] = this.attackMaxCaptains;
			if (this.m_usingCastleTroopsOK)
			{
				array[6] += this.attackMaxPeasantsInCastle;
				array[7] += this.attackMaxArchersInCastle;
				array[8] += this.attackMaxPikemenInCastle;
				array[9] += this.attackMaxSwordsmenInCastle;
			}
			for (int i = 0; i < 6; i++)
			{
				if (array[i] > array[i + 6])
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000A31 RID: 2609 RVA: 0x000CC024 File Offset: 0x000CA224
		public int[] CountOwnPlacedTroopsArray()
		{
			int[] array = new int[6];
			foreach (CastleElement castleElement in this.elements)
			{
				if (!castleElement.reinforcement && !castleElement.vassalReinforcements)
				{
					byte elementType = castleElement.elementType;
					switch (elementType)
					{
					case 70:
						array[0]++;
						break;
					case 71:
						array[3]++;
						break;
					case 72:
						array[1]++;
						break;
					case 73:
						array[2]++;
						break;
					case 74:
					case 75:
					case 76:
						break;
					case 77:
						array[4]++;
						break;
					default:
						if (elementType == 85)
						{
							array[5]++;
						}
						break;
					}
				}
			}
			return array;
		}

		// Token: 0x06000A32 RID: 2610 RVA: 0x000CC120 File Offset: 0x000CA320
		public CastleElement TroopPlaceAttackerBG(int mapX, int mapY, byte elemType = 0)
		{
			CastleElement castleElement = new CastleElement
			{
				elementID = this.localTempElementNumber
			};
			this.localTempElementNumber -= 1L;
			castleElement.elementType = elemType;
			castleElement.xPos = (byte)mapX;
			castleElement.yPos = (byte)mapY;
			this.elements.Add(castleElement);
			switch (elemType)
			{
			case 90:
				this.attackNumPeasants++;
				break;
			case 91:
				this.attackNumSwordsmen++;
				break;
			case 92:
				this.attackNumArchers++;
				break;
			case 93:
				this.attackNumPikemen++;
				break;
			case 94:
				this.addNewCatapultTargetDefault(castleElement);
				this.attackNumCatapults++;
				break;
			case 100:
			case 101:
			case 104:
			case 105:
			case 106:
			case 107:
				this.addNewCaptainDetails(castleElement);
				this.attackNumCaptains++;
				break;
			case 102:
			case 103:
				this.addNewCaptainDetails(castleElement);
				this.attackNumCaptains++;
				break;
			}
			CastleMap.OnTroopPlaced_Delegate onTroopPlaced = this.OnTroopPlaced;
			if (onTroopPlaced != null)
			{
				onTroopPlaced(castleElement);
			}
			return castleElement;
		}

		// Token: 0x06000A33 RID: 2611 RVA: 0x000CC260 File Offset: 0x000CA460
		public bool RestoreAttackSetupBG(List<CastleMap.RestoreCastleElement> list)
		{
			int num = -1;
			foreach (CastleMap.RestoreCastleElement restoreCastleElement in list)
			{
				int elementType = (int)restoreCastleElement.elementType;
				if (restoreCastleElement.elementType >= 100 && restoreCastleElement.elementType < 109)
				{
					restoreCastleElement.elementType = 100;
				}
				this.CurrentBrushSize = CastleMap.BrushSize.BRUSH_1X1;
				if (this.castleLayout.map[(int)restoreCastleElement.xPos, (int)restoreCastleElement.yPos] == 0 && this.castleLayout.canPlaceAttackerHere(elementType, (int)restoreCastleElement.xPos, (int)restoreCastleElement.yPos, this.attackerSetupForest))
				{
					CastleElement castleElement = this.TroopPlaceAttackerBG((int)restoreCastleElement.xPos, (int)restoreCastleElement.yPos, restoreCastleElement.elementType);
					num = (int)restoreCastleElement.elementType;
					if (restoreCastleElement.elementType == 94)
					{
						foreach (CatapultTarget catapultTarget in this.catapultTargets)
						{
							if (catapultTarget.elemID == castleElement.elementID)
							{
								catapultTarget.xPos = restoreCastleElement.targXPos;
								catapultTarget.yPos = restoreCastleElement.targYPos;
								if (!this.validateCatapultRange((int)restoreCastleElement.xPos, (int)restoreCastleElement.yPos, (int)catapultTarget.xPos, (int)catapultTarget.yPos, GameEngine.Instance.LocalWorldData.Castle_Catapult_MaxRange))
								{
									catapultTarget.createDefaultLocation((int)restoreCastleElement.xPos, (int)restoreCastleElement.yPos, castleElement);
									break;
								}
								break;
							}
						}
					}
					if (restoreCastleElement.elementType >= 100 && restoreCastleElement.elementType < 109)
					{
						foreach (CaptainsDetails captainsDetails in this.captainsDetails)
						{
							if (captainsDetails.elemID == castleElement.elementID)
							{
								captainsDetails.seconds = restoreCastleElement.delay;
								break;
							}
						}
						if (elementType != 100)
						{
							castleElement.elementType = (byte)elementType;
						}
						if (elementType == 102 || elementType == 103)
						{
							this.addNewCatapultTargetDefault(castleElement);
							foreach (CatapultTarget catapultTarget2 in this.catapultTargets)
							{
								if (catapultTarget2.elemID == castleElement.elementID)
								{
									catapultTarget2.xPos = restoreCastleElement.targXPos;
									catapultTarget2.yPos = restoreCastleElement.targYPos;
									break;
								}
							}
						}
					}
					CastlesCommon.buildCastleLayoutClient(this.elements, ref this.castleLayout);
				}
			}
			if (num >= 0)
			{
				this.updateLayoutAndRedraw();
			}
			return true;
		}

		// Token: 0x06000A34 RID: 2612 RVA: 0x000CC548 File Offset: 0x000CA748
		public bool RestoreAttackPresetBG(CastleMapPreset preset)
		{
			List<CastleMap.RestoreCastleElement> list = new List<CastleMap.RestoreCastleElement>();
			string[] array = preset.Data.Split(new char[]
			{
				' '
			});
			int num = 0;
			int i = 0;
			while (i < preset.ElementCount)
			{
				CastleMap.RestoreCastleElement restoreCastleElement = new CastleMap.RestoreCastleElement
				{
					xPos = Convert.ToByte(array[num++]),
					yPos = Convert.ToByte(array[num++]),
					elementType = Convert.ToByte(array[num++])
				};
				if (restoreCastleElement.elementType == 94)
				{
					restoreCastleElement.targXPos = Convert.ToByte(array[num++]);
					restoreCastleElement.targYPos = Convert.ToByte(array[num++]);
				}
				if (restoreCastleElement.elementType < 100 || restoreCastleElement.elementType >= 109)
				{
					goto IL_170;
				}
				restoreCastleElement.delay = Convert.ToByte(array[num++]);
				if (restoreCastleElement.elementType == 102 || restoreCastleElement.elementType == 103)
				{
					restoreCastleElement.targXPos = Convert.ToByte(array[num++]);
					restoreCastleElement.targYPos = Convert.ToByte(array[num++]);
				}
				bool flag = false;
				int research_Tactics = (int)GameEngine.Instance.World.UserResearchData.Research_Tactics;
				switch (restoreCastleElement.elementType)
				{
				case 100:
					flag = true;
					break;
				case 101:
					if (research_Tactics > 0)
					{
						flag = true;
					}
					break;
				case 102:
					if (research_Tactics > 1)
					{
						flag = true;
					}
					break;
				case 103:
					if (research_Tactics > 3)
					{
						flag = true;
					}
					break;
				case 104:
					if (research_Tactics > 2)
					{
						flag = true;
					}
					break;
				}
				if (flag)
				{
					goto IL_170;
				}
				IL_178:
				i++;
				continue;
				IL_170:
				list.Add(restoreCastleElement);
				goto IL_178;
			}
			return this.RestoreAttackSetupBG(list);
		}

		// Token: 0x06000A35 RID: 2613 RVA: 0x000CC6E4 File Offset: 0x000CA8E4
		public int placeTroops(List<CampCastleElementLL> array)
		{
			GameEngine.Instance.stopInterfaceSounds = true;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = -1;
			int num5 = this.getGuardHouseCapacity() - this.countPlacedTroops();
			int num6 = GameEngine.Instance.LocalWorldData.castle_oilPerSmelter * GameEngine.Instance.Castle.countCompletedSmelters() - this.countPlacedOilPots();
			foreach (CampCastleElementLL campCastleElementLL in array)
			{
				byte elementType = campCastleElementLL.elementType;
				switch (elementType)
				{
				case 70:
				case 71:
				case 72:
				case 73:
				case 77:
					break;
				case 74:
				case 76:
					goto IL_AB;
				case 75:
					if (num3 < num6)
					{
						goto IL_AB;
					}
					continue;
				default:
					if (elementType != 85)
					{
						goto IL_AB;
					}
					break;
				}
				if (num2 >= num5)
				{
					continue;
				}
				IL_AB:
				this.startPlacingTroops((int)campCastleElementLL.elementType, campCastleElementLL.reinforcement);
				this.CurrentBrushSize = CastleMap.BrushSize.BRUSH_1X1;
				if (this.mouseMovePlaceTroops((int)campCastleElementLL.xPos, (int)campCastleElementLL.yPos, true, 0))
				{
					CastleElement castleElement = this.troopPlaceDefender((int)campCastleElementLL.xPos, (int)campCastleElementLL.yPos, true);
					if (castleElement != null)
					{
						castleElement.aggressiveDefender = campCastleElementLL.aggressiveDefender;
						byte elementType2 = castleElement.elementType;
						switch (elementType2)
						{
						case 70:
						case 71:
						case 72:
						case 73:
						case 77:
							break;
						case 74:
						case 76:
							goto IL_14A;
						case 75:
							num3++;
							goto IL_14A;
						default:
							if (elementType2 != 85)
							{
								goto IL_14A;
							}
							break;
						}
						num2++;
					}
					IL_14A:
					num4 = (int)campCastleElementLL.elementType;
					num++;
				}
			}
			if (num4 >= 0)
			{
				this.startPlaceElement_ShowPanel(num4, CastlesCommon.getPieceName(num4), false);
				this.updateLayoutAndRedraw();
				InterfaceMgr.Instance.castleStartBuilderMode();
			}
			this.stopPlaceElement();
			GameEngine.Instance.stopInterfaceSounds = false;
			return num;
		}

		// Token: 0x06000A36 RID: 2614 RVA: 0x0000D8BF File Offset: 0x0000BABF
		public void SetUsingCastleTroopsOK(bool value)
		{
			this.m_usingCastleTroopsOK = value;
		}

		// Token: 0x06000A37 RID: 2615 RVA: 0x000CC8B4 File Offset: 0x000CAAB4
		public static void launchCastleAttackCallbackBG(LaunchCastleAttack_ReturnType returnData)
		{
			if (returnData.protectedVillage)
			{
				MyMessageBox.Show(SK.Text("CastleMap_Interdiction", "This village is protected from attack by an Interdiction."), SK.Text("CastleMap_Protected", "Village Protected"));
				InterfaceMgr.Instance.getMainTabBar().changeTab(9);
				InterfaceMgr.Instance.getMainTabBar().changeTab(0);
				return;
			}
			if (returnData.Success)
			{
				if (returnData.villageResourcesAndStats != null)
				{
					VillageMap village = GameEngine.Instance.getVillage(returnData.sourceVillage);
					if (village != null)
					{
						village.importResourcesAndStats(returnData.villageResourcesAndStats, returnData.currentTime);
					}
				}
				ArmyReturnData[] armyReturnData = new ArmyReturnData[]
				{
					returnData.armyData
				};
				GameEngine.Instance.World.doGetArmyData(armyReturnData, null, false);
				GameEngine.Instance.World.addExistingArmy(returnData.armyData.armyID);
				if (SpecialVillageTypes.IS_TREASURE_CASTLE(GameEngine.Instance.World.getSpecial(returnData.targetVillage)))
				{
					GameEngine.Instance.World.setLastTreasureCastleAttackTime(VillageMap.getCurrentServerTime());
				}
				AttackTargetsPanel.addRecent(returnData.targetVillage);
				return;
			}
			MyMessageBox.Show(ErrorCodes.getErrorString(returnData.m_errorCode, returnData.m_errorID), SK.Text("GENERIC_Attack_Error", "Attack Error"));
			ControlForm controlForm = DX.ControlForm;
			if (controlForm != null)
			{
				controlForm.Log(string.Concat(new string[]
				{
					ErrorCodes.getErrorString(returnData.m_errorCode, returnData.m_errorID),
					". Source Village ",
					GameEngine.Instance.World.getVillageName(returnData.armyData.homeVillageID),
					" Target Village ",
					GameEngine.Instance.World.getVillageName(returnData.targetVillage),
					" "
				}), ControlForm.Tab.Predator, true);
			}
			InterfaceMgr.Instance.getMainTabBar().changeTab(9);
			InterfaceMgr.Instance.getMainTabBar().changeTab(0);
		}

		// Token: 0x06000A38 RID: 2616 RVA: 0x000CCA88 File Offset: 0x000CAC88
		public void SaveCastleMap(string filename)
		{
			List<string> list = new List<string>();
			foreach (CastleElement castleElement in this.elements)
			{
				list.Add(string.Format("{0} {1} {2} {3}", new object[]
				{
					castleElement.xPos,
					castleElement.yPos,
					castleElement.elementType,
					castleElement.aggressiveDefender
				}));
			}
			File.WriteAllLines(filename + ".txt", list.ToArray());
			FileStream fileStream = null;
			BinaryWriter binaryWriter = null;
			try
			{
				fileStream = new FileStream(filename + "_researches.dat", FileMode.Create);
				binaryWriter = new BinaryWriter(fileStream);
				this.m_defenderResearch.Write(binaryWriter);
			}
			catch (Exception ex)
			{
				DX.ShowErrorMessage(ex);
			}
			finally
			{
				if (binaryWriter != null)
				{
					binaryWriter.Close();
				}
				if (fileStream != null)
				{
					fileStream.Close();
				}
			}
		}

		// Token: 0x04000C6A RID: 3178
		public const int CASTLE_MODE_NORMAL = 0;

		// Token: 0x04000C6B RID: 3179
		public const int CASTLE_MODE_ATTACKER_SETUP = 1;

		// Token: 0x04000C6C RID: 3180
		public const int CASTLE_MODE_VIEW_SPY_REPORT = 2;

		// Token: 0x04000C6D RID: 3181
		public const int CASTLE_MODE_BATTLE = 3;

		// Token: 0x04000C6E RID: 3182
		public const int CASTLE_MODE_PREVIEW = 4;

		// Token: 0x04000C6F RID: 3183
		private static DateTime baseServerTime = DateTime.Now;

		// Token: 0x04000C70 RID: 3184
		private static double localBaseTime = 0.0;

		// Token: 0x04000C71 RID: 3185
		private static SpriteWrapper TCWarningSprite = null;

		// Token: 0x04000C72 RID: 3186
		private int m_villageID = -1;

		// Token: 0x04000C73 RID: 3187
		public List<CastleElement> elements;

		// Token: 0x04000C74 RID: 3188
		private List<CastleElement> removedElements;

		// Token: 0x04000C75 RID: 3189
		private List<CastleElement> movedElements;

		// Token: 0x04000C76 RID: 3190
		private List<CastleElement> movedElementsOriginal;

		// Token: 0x04000C77 RID: 3191
		public CastleLayout castleLayout;

		// Token: 0x04000C78 RID: 3192
		private static int fakeKeep = -1;

		// Token: 0x04000C79 RID: 3193
		private static int fakeDefensiveMode = -1;

		// Token: 0x04000C7A RID: 3194
		private static bool createMode = false;

		// Token: 0x04000C7B RID: 3195
		private CastleMap.TempTileSortComparer tempTileSortComparer = new CastleMap.TempTileSortComparer();

		// Token: 0x04000C7C RID: 3196
		private static int numClickAreas = 0;

		// Token: 0x04000C7D RID: 3197
		private static List<CastleMap.TroopClickArea> troopClickAreas = new List<CastleMap.TroopClickArea>();

		// Token: 0x04000C7E RID: 3198
		public int[] moatSurroundTests = new int[]
		{
			-1,
			-1,
			0,
			-1,
			1,
			-1,
			-1,
			0,
			1,
			0,
			-1,
			1,
			0,
			1,
			1,
			1
		};

		// Token: 0x04000C7F RID: 3199
		public int[] moatSurroundLogic = new int[]
		{
			268,
			2,
			0,
			2,
			1,
			0,
			1,
			1,
			2,
			269,
			1,
			1,
			2,
			1,
			0,
			2,
			0,
			2,
			270,
			2,
			1,
			1,
			0,
			1,
			2,
			0,
			2,
			271,
			2,
			0,
			2,
			0,
			1,
			2,
			1,
			1,
			272,
			1,
			1,
			2,
			1,
			0,
			1,
			1,
			2,
			273,
			1,
			1,
			1,
			1,
			1,
			2,
			0,
			2,
			274,
			2,
			1,
			1,
			0,
			1,
			2,
			1,
			1,
			275,
			2,
			0,
			2,
			1,
			1,
			1,
			1,
			1,
			276,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			277,
			1,
			1,
			1,
			1,
			1,
			0,
			1,
			1,
			278,
			0,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			279,
			1,
			1,
			0,
			1,
			1,
			1,
			1,
			1,
			280,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			0,
			281,
			2,
			1,
			2,
			0,
			0,
			2,
			1,
			2,
			282,
			2,
			0,
			2,
			1,
			1,
			2,
			0,
			2,
			283,
			0,
			1,
			0,
			1,
			1,
			0,
			1,
			0,
			284,
			0,
			1,
			2,
			1,
			0,
			2,
			0,
			2,
			285,
			2,
			0,
			2,
			0,
			1,
			2,
			1,
			0,
			286,
			2,
			1,
			0,
			0,
			1,
			2,
			0,
			2,
			287,
			2,
			0,
			2,
			1,
			0,
			0,
			1,
			2,
			288,
			2,
			0,
			2,
			0,
			0,
			2,
			0,
			2,
			289,
			0,
			1,
			2,
			1,
			0,
			0,
			1,
			2,
			290,
			2,
			0,
			2,
			1,
			1,
			0,
			1,
			0,
			291,
			0,
			1,
			0,
			1,
			1,
			2,
			0,
			2,
			292,
			2,
			1,
			0,
			0,
			1,
			2,
			1,
			0,
			293,
			2,
			0,
			2,
			1,
			0,
			2,
			0,
			2,
			294,
			2,
			0,
			2,
			0,
			0,
			2,
			1,
			2,
			295,
			2,
			1,
			2,
			0,
			0,
			2,
			0,
			2,
			296,
			2,
			0,
			2,
			0,
			1,
			2,
			0,
			2,
			297,
			2,
			0,
			2,
			1,
			1,
			1,
			1,
			0,
			298,
			0,
			1,
			2,
			1,
			0,
			1,
			1,
			2,
			299,
			1,
			1,
			0,
			1,
			1,
			2,
			0,
			2,
			300,
			1,
			1,
			2,
			1,
			0,
			0,
			1,
			2,
			301,
			0,
			1,
			1,
			1,
			1,
			2,
			0,
			2,
			302,
			2,
			1,
			1,
			0,
			1,
			2,
			1,
			0,
			303,
			2,
			1,
			0,
			0,
			1,
			2,
			1,
			1,
			304,
			2,
			0,
			2,
			1,
			1,
			0,
			1,
			1,
			305,
			1,
			1,
			0,
			1,
			1,
			1,
			1,
			0,
			306,
			1,
			1,
			1,
			1,
			1,
			0,
			1,
			0,
			307,
			0,
			1,
			1,
			1,
			1,
			0,
			1,
			1,
			308,
			0,
			1,
			0,
			1,
			1,
			1,
			1,
			1,
			309,
			1,
			1,
			0,
			1,
			1,
			0,
			1,
			1,
			310,
			0,
			1,
			1,
			1,
			1,
			1,
			1,
			0,
			311,
			0,
			1,
			0,
			1,
			1,
			0,
			1,
			1,
			312,
			0,
			1,
			0,
			1,
			1,
			1,
			1,
			0,
			313,
			1,
			1,
			0,
			1,
			1,
			0,
			1,
			0,
			314,
			0,
			1,
			1,
			1,
			1,
			0,
			1,
			0,
			-1
		};

		// Token: 0x04000C80 RID: 3200
		private int m_castleMode;

		// Token: 0x04000C81 RID: 3201
		public int campMode;

		// Token: 0x04000C82 RID: 3202
		private bool m_castleEnclosed;

		// Token: 0x04000C83 RID: 3203
		private static bool spritesInitiated = false;

		// Token: 0x04000C84 RID: 3204
		public static SpriteWrapper[,] castleSpriteGrid = new SpriteWrapper[118, 118];

		// Token: 0x04000C85 RID: 3205
		public static SpriteWrapper[,] castleDefenderSpriteGrid = new SpriteWrapper[118, 118];

		// Token: 0x04000C86 RID: 3206
		public static SpriteWrapper[,] castleAttackerSpriteGrid = new SpriteWrapper[118, 118];

		// Token: 0x04000C87 RID: 3207
		public static Point[,] castleUnitSpritePoint = new Point[118, 118];

		// Token: 0x04000C88 RID: 3208
		private static List<SpriteWrapper> castleExtraSprites = new List<SpriteWrapper>();

		// Token: 0x04000C89 RID: 3209
		private static List<SpriteWrapper> wallCachedSprites = new List<SpriteWrapper>();

		// Token: 0x04000C8A RID: 3210
		public bool RegimentsSelectable;

		// Token: 0x04000C8B RID: 3211
		private bool inBuilderMode;

		// Token: 0x04000C8C RID: 3212
		private bool inTroopPlacerMode;

		// Token: 0x04000C8D RID: 3213
		public static bool AlwaysCollapsedWallsInBattles = false;

		// Token: 0x04000C8E RID: 3214
		public static bool displayCollapsed = true;

		// Token: 0x04000C8F RID: 3215
		public int displayType;

		// Token: 0x04000C90 RID: 3216
		public static SparseArray activeCastleInfrastructureElements = new SparseArray();

		// Token: 0x04000C91 RID: 3217
		public bool completed;

		// Token: 0x04000C92 RID: 3218
		public DateTime completeTime;

		// Token: 0x04000C93 RID: 3219
		public bool dirtyCastle = true;

		// Token: 0x04000C94 RID: 3220
		private int nextExtraSpriteID;

		// Token: 0x04000C95 RID: 3221
		private int draggingHandle;

		// Token: 0x04000C96 RID: 3222
		private CastleCommitPopup commitPopup;

		// Token: 0x04000C97 RID: 3223
		private long localTempElementNumber = -3L;

		// Token: 0x04000C98 RID: 3224
		public long troopSelected = -1L;

		// Token: 0x04000C99 RID: 3225
		private bool stopPlacementOnTroopModeSwap;

		// Token: 0x04000C9A RID: 3226
		private bool inDeleting;

		// Token: 0x04000C9B RID: 3227
		private DateTime lastDeleteTime = DateTime.MinValue;

		// Token: 0x04000C9C RID: 3228
		private CastleCameraWinforms m_camera;

		// Token: 0x04000C9D RID: 3229
		private DateTime troopSelectDoubleClickTIme = DateTime.MinValue;

		// Token: 0x04000C9E RID: 3230
		private bool m_draggingMap;

		// Token: 0x04000C9F RID: 3231
		private bool m_leftMouseHeldDown;

		// Token: 0x04000CA0 RID: 3232
		private double m_lastMousePressedTime;

		// Token: 0x04000CA1 RID: 3233
		private Point m_baseMousePos;

		// Token: 0x04000CA2 RID: 3234
		private Point m_previousMousePos;

		// Token: 0x04000CA3 RID: 3235
		private double m_baseScreenX;

		// Token: 0x04000CA4 RID: 3236
		private double m_baseScreenY;

		// Token: 0x04000CA5 RID: 3237
		private int startWallMapX = -1;

		// Token: 0x04000CA6 RID: 3238
		private int startWallMapY = -1;

		// Token: 0x04000CA7 RID: 3239
		private bool draggingWall;

		// Token: 0x04000CA8 RID: 3240
		private bool wallWasValid;

		// Token: 0x04000CA9 RID: 3241
		private bool waitingForWallReturn;

		// Token: 0x04000CAA RID: 3242
		public Point battleModeMousePos = new Point(-1000, -1000);

		// Token: 0x04000CAB RID: 3243
		private bool m_holdLassoModeAvailable;

		// Token: 0x04000CAC RID: 3244
		public static int Builder_MapX = 0;

		// Token: 0x04000CAD RID: 3245
		public static int Builder_MapY = 0;

		// Token: 0x04000CAE RID: 3246
		private bool overWikiHelp;

		// Token: 0x04000CAF RID: 3247
		private int lastMoveTileX = -1;

		// Token: 0x04000CB0 RID: 3248
		private int lastMoveTileY = -1;

		// Token: 0x04000CB1 RID: 3249
		private static SpriteWrapper buildingPlacementSprite = null;

		// Token: 0x04000CB2 RID: 3250
		private static SpriteWrapper[] placementTroopSprite = new SpriteWrapper[25];

		// Token: 0x04000CB3 RID: 3251
		private static SpriteWrapper[] placementTroopCastleSprite = new SpriteWrapper[25];

		// Token: 0x04000CB4 RID: 3252
		private static List<SpriteWrapper> wallPlacementSprites = new List<SpriteWrapper>();

		// Token: 0x04000CB5 RID: 3253
		private SpriteWrapper placementSprite_handleone;

		// Token: 0x04000CB6 RID: 3254
		private SpriteWrapper placementSprite_handletwo;

		// Token: 0x04000CB7 RID: 3255
		public int m_placementType;

		// Token: 0x04000CB8 RID: 3256
		public int LastPlacedBuilding = -1;

		// Token: 0x04000CB9 RID: 3257
		private bool placingElement = true;

		// Token: 0x04000CBA RID: 3258
		private bool m_placingDefender = true;

		// Token: 0x04000CBB RID: 3259
		public bool PlacingReinforcement;

		// Token: 0x04000CBC RID: 3260
		private CastleMap.Gesture m_gesture;

		// Token: 0x04000CBD RID: 3261
		public bool PlacementMoved;

		// Token: 0x04000CBE RID: 3262
		public CastleMap.OnTroopPlaced_Delegate OnTroopPlaced;

		// Token: 0x04000CBF RID: 3263
		public int lastGHX = -1;

		// Token: 0x04000CC0 RID: 3264
		public int lastGHY = -1;

		// Token: 0x04000CC1 RID: 3265
		public long deletingHighlightElementID = -2L;

		// Token: 0x04000CC2 RID: 3266
		private bool deleting;

		// Token: 0x04000CC3 RID: 3267
		private int nextWallCacheSpriteID;

		// Token: 0x04000CC4 RID: 3268
		private List<List<CastleElement>> wallUndoSteps = new List<List<CastleElement>>();

		// Token: 0x04000CC5 RID: 3269
		private int lastValidWallX = -1;

		// Token: 0x04000CC6 RID: 3270
		private int lastValidWallY = -1;

		// Token: 0x04000CC7 RID: 3271
		private int piecesBeingPlaced;

		// Token: 0x04000CC8 RID: 3272
		public bool m_lassoLeftHeldDown;

		// Token: 0x04000CC9 RID: 3273
		private int m_lassoStartX;

		// Token: 0x04000CCA RID: 3274
		private int m_lassoStartY;

		// Token: 0x04000CCB RID: 3275
		private int m_lassoEndX;

		// Token: 0x04000CCC RID: 3276
		private int m_lassoEndY;

		// Token: 0x04000CCD RID: 3277
		private int m_lassoLastX;

		// Token: 0x04000CCE RID: 3278
		private int m_lassoLastY;

		// Token: 0x04000CCF RID: 3279
		public bool m_lassoMade;

		// Token: 0x04000CD0 RID: 3280
		public List<long> m_lassoElements = new List<long>();

		// Token: 0x04000CD1 RID: 3281
		private CastleElement movingElement;

		// Token: 0x04000CD2 RID: 3282
		private int numGuardHouseSpaces;

		// Token: 0x04000CD3 RID: 3283
		public int numGuardHouses;

		// Token: 0x04000CD4 RID: 3284
		public int numSmelter;

		// Token: 0x04000CD5 RID: 3285
		public int numPlacedDefenderArchers;

		// Token: 0x04000CD6 RID: 3286
		public int numPlacedDefenderPeasants;

		// Token: 0x04000CD7 RID: 3287
		public int numPlacedDefenderSwordsmen;

		// Token: 0x04000CD8 RID: 3288
		public int numPlacedDefenderPikemen;

		// Token: 0x04000CD9 RID: 3289
		public int numPlacedDefenderCaptains;

		// Token: 0x04000CDA RID: 3290
		private int numAvailableDefenderPeasants;

		// Token: 0x04000CDB RID: 3291
		private int numAvailableDefenderArchers;

		// Token: 0x04000CDC RID: 3292
		private int numAvailableDefenderPikemen;

		// Token: 0x04000CDD RID: 3293
		private int numAvailableDefenderSwordsmen;

		// Token: 0x04000CDE RID: 3294
		private int numAvailableDefenderCaptains;

		// Token: 0x04000CDF RID: 3295
		public int numPlacedReinforceDefenderArchers;

		// Token: 0x04000CE0 RID: 3296
		public int numPlacedReinforceDefenderPeasants;

		// Token: 0x04000CE1 RID: 3297
		public int numPlacedReinforceDefenderSwordsmen;

		// Token: 0x04000CE2 RID: 3298
		public int numPlacedReinforceDefenderPikemen;

		// Token: 0x04000CE3 RID: 3299
		public int numPlacedVassalReinforceDefenderArchers;

		// Token: 0x04000CE4 RID: 3300
		public int numPlacedVassalReinforceDefenderPeasants;

		// Token: 0x04000CE5 RID: 3301
		public int numPlacedVassalReinforceDefenderSwordsmen;

		// Token: 0x04000CE6 RID: 3302
		public int numPlacedVassalReinforceDefenderPikemen;

		// Token: 0x04000CE7 RID: 3303
		private int numAvailableReinforceDefenderPeasants;

		// Token: 0x04000CE8 RID: 3304
		private int numAvailableReinforceDefenderArchers;

		// Token: 0x04000CE9 RID: 3305
		private int numAvailableReinforceDefenderPikemen;

		// Token: 0x04000CEA RID: 3306
		private int numAvailableReinforceDefenderSwordsmen;

		// Token: 0x04000CEB RID: 3307
		private int numAvailableVassalReinforceDefenderPeasants;

		// Token: 0x04000CEC RID: 3308
		private int numAvailableVassalReinforceDefenderArchers;

		// Token: 0x04000CED RID: 3309
		private int numAvailableVassalReinforceDefenderPikemen;

		// Token: 0x04000CEE RID: 3310
		private int numAvailableVassalReinforceDefenderSwordsmen;

		// Token: 0x04000CEF RID: 3311
		public int numPots;

		// Token: 0x04000CF0 RID: 3312
		private int numSmelterPlaces;

		// Token: 0x04000CF1 RID: 3313
		private CastleMap.BrushSize m_currentBrushSize = CastleMap.BrushSize.BRUSH_1X1;

		// Token: 0x04000CF2 RID: 3314
		private SpriteWrapper dummySprite = new SpriteWrapper();

		// Token: 0x04000CF3 RID: 3315
		public bool troopMovingMode;

		// Token: 0x04000CF4 RID: 3316
		public long troopMovingElemID = -2L;

		// Token: 0x04000CF5 RID: 3317
		private bool deletingTroops;

		// Token: 0x04000CF6 RID: 3318
		public bool castleDamaged;

		// Token: 0x04000CF7 RID: 3319
		private bool m_usingCastleTroopsOK;

		// Token: 0x04000CF8 RID: 3320
		public List<CastleMap.CatapultLine> catapultLines = new List<CastleMap.CatapultLine>();

		// Token: 0x04000CF9 RID: 3321
		private bool showCatapultTargets;

		// Token: 0x04000CFA RID: 3322
		public long selectedCatapult = -1L;

		// Token: 0x04000CFB RID: 3323
		private List<CatapultTarget> catapultTargets = new List<CatapultTarget>();

		// Token: 0x04000CFC RID: 3324
		private int catapultTargetMoveX;

		// Token: 0x04000CFD RID: 3325
		private int catapultTargetMoveY;

		// Token: 0x04000CFE RID: 3326
		private bool catapultTargetMoveValid;

		// Token: 0x04000CFF RID: 3327
		private List<CaptainsDetails> captainsDetails = new List<CaptainsDetails>();

		// Token: 0x04000D00 RID: 3328
		private static List<SpriteWrapper> surroundsprites = new List<SpriteWrapper>();

		// Token: 0x04000D01 RID: 3329
		private static SpriteWrapper enclosedOverlaySprite = new SpriteWrapper();

		// Token: 0x04000D02 RID: 3330
		private static SpriteWrapper enclosedOverlaySprite2 = new SpriteWrapper();

		// Token: 0x04000D03 RID: 3331
		private static SpriteWrapper tutorialOverlaySprite = new SpriteWrapper();

		// Token: 0x04000D04 RID: 3332
		private static SpriteWrapper wikiHelpSprite = new SpriteWrapper();

		// Token: 0x04000D05 RID: 3333
		private int enclosedGlow;

		// Token: 0x04000D06 RID: 3334
		private int tick;

		// Token: 0x04000D07 RID: 3335
		private bool fastPlayback;

		// Token: 0x04000D08 RID: 3336
		private bool realBattleMode = true;

		// Token: 0x04000D09 RID: 3337
		private int updates;

		// Token: 0x04000D0A RID: 3338
		public CastleMap.onBattleFinishDelegate OnBattleFinish;

		// Token: 0x04000D0B RID: 3339
		private CastleMap.BattlePlaySFX arrowSounds = new CastleMap.BattlePlaySFX();

		// Token: 0x04000D0C RID: 3340
		private string[] arrow_low_sounds = new string[]
		{
			"arrow_low_1",
			"arrow_low_2",
			"arrow_low_3",
			"arrow_low_4",
			"arrow_low_5",
			"arrow_low_6",
			"arrow_low_7",
			"arrow_low_8",
			"arrow_low_9",
			"arrow_low_10"
		};

		// Token: 0x04000D0D RID: 3341
		private string[] arrow_mid_sounds = new string[]
		{
			"arrow_med_1",
			"arrow_med_2",
			"arrow_med_3",
			"arrow_med_4",
			"arrow_med_5",
			"arrow_med_6",
			"arrow_med_7",
			"arrow_med_8",
			"arrow_med_9",
			"arrow_med_10"
		};

		// Token: 0x04000D0E RID: 3342
		private string[] arrow_high_sounds = new string[]
		{
			"arrow_high_1",
			"arrow_high_2",
			"arrow_high_3",
			"arrow_high_4",
			"arrow_high_5",
			"arrow_high_6",
			"arrow_high_7",
			"arrow_high_8",
			"arrow_high_9",
			"arrow_high_10"
		};

		// Token: 0x04000D0F RID: 3343
		private CastleMap.BattlePlaySFX meleeLightSounds = new CastleMap.BattlePlaySFX();

		// Token: 0x04000D10 RID: 3344
		private string[] meleeLight_low_sounds = new string[]
		{
			"melee_light_low_1",
			"melee_light_low_2",
			"melee_light_low_3",
			"melee_light_low_4",
			"melee_light_low_5",
			"melee_light_low_6",
			"melee_light_low_7",
			"melee_light_low_8",
			"melee_light_low_9",
			"melee_light_low_10"
		};

		// Token: 0x04000D11 RID: 3345
		private string[] meleeLight_mid_sounds = new string[]
		{
			"melee_light_med_1",
			"melee_light_med_2",
			"melee_light_med_3",
			"melee_light_med_4",
			"melee_light_med_5",
			"melee_light_med_6",
			"melee_light_med_7",
			"melee_light_med_8",
			"melee_light_med_9",
			"melee_light_med_10"
		};

		// Token: 0x04000D12 RID: 3346
		private string[] meleeLight_high_sounds = new string[]
		{
			"melee_light_high_1",
			"melee_light_high_2",
			"melee_light_high_3",
			"melee_light_high_4",
			"melee_light_high_5",
			"melee_light_high_6",
			"melee_light_high_7",
			"melee_light_high_8",
			"melee_light_high_9",
			"melee_light_high_10"
		};

		// Token: 0x04000D13 RID: 3347
		private CastleMap.BattlePlaySFX meleeMetalSounds = new CastleMap.BattlePlaySFX();

		// Token: 0x04000D14 RID: 3348
		private string[] meleeMetal_low_sounds = new string[]
		{
			"melee_metal_low_1",
			"melee_metal_low_2",
			"melee_metal_low_3",
			"melee_metal_low_4",
			"melee_metal_low_5",
			"melee_metal_low_6",
			"melee_metal_low_7",
			"melee_metal_low_8",
			"melee_metal_low_9",
			"melee_metal_low_10"
		};

		// Token: 0x04000D15 RID: 3349
		private string[] meleeMetal_mid_sounds = new string[]
		{
			"melee_metal_med_1",
			"melee_metal_med_2",
			"melee_metal_med_3",
			"melee_metal_med_4",
			"melee_metal_med_5",
			"melee_metal_med_6",
			"melee_metal_med_7",
			"melee_metal_med_8",
			"melee_metal_med_9",
			"melee_metal_med_10"
		};

		// Token: 0x04000D16 RID: 3350
		private string[] meleeMetal_high_sounds = new string[]
		{
			"melee_metal_high_1",
			"melee_metal_high_2",
			"melee_metal_high_3",
			"melee_metal_high_4",
			"melee_metal_high_5",
			"melee_metal_high_6",
			"melee_metal_high_7",
			"melee_metal_high_8",
			"melee_metal_high_9",
			"melee_metal_high_10"
		};

		// Token: 0x04000D17 RID: 3351
		private CastleMap.BattlePlaySFX infraWoodSounds = new CastleMap.BattlePlaySFX();

		// Token: 0x04000D18 RID: 3352
		private string[] infraWood_low_sounds = new string[]
		{
			"infrastructure_wood_low_1",
			"infrastructure_wood_low_2",
			"infrastructure_wood_low_3",
			"infrastructure_wood_low_4",
			"infrastructure_wood_low_5",
			"infrastructure_wood_low_6",
			"infrastructure_wood_low_7",
			"infrastructure_wood_low_8",
			"infrastructure_wood_low_9",
			"infrastructure_wood_low_10"
		};

		// Token: 0x04000D19 RID: 3353
		private string[] infraWood_mid_sounds = new string[]
		{
			"infrastructure_wood_med_1",
			"infrastructure_wood_med_2",
			"infrastructure_wood_med_3",
			"infrastructure_wood_med_4",
			"infrastructure_wood_med_5",
			"infrastructure_wood_med_6",
			"infrastructure_wood_med_7",
			"infrastructure_wood_med_8",
			"infrastructure_wood_med_9",
			"infrastructure_wood_med_10"
		};

		// Token: 0x04000D1A RID: 3354
		private string[] infraWood_high_sounds = new string[]
		{
			"infrastructure_wood_high_1",
			"infrastructure_wood_high_2",
			"infrastructure_wood_high_3",
			"infrastructure_wood_high_4",
			"infrastructure_wood_high_5",
			"infrastructure_wood_high_6",
			"infrastructure_wood_high_7",
			"infrastructure_wood_high_8",
			"infrastructure_wood_high_9",
			"infrastructure_wood_high_10"
		};

		// Token: 0x04000D1B RID: 3355
		private CastleMap.BattlePlaySFX infraStoneSounds = new CastleMap.BattlePlaySFX();

		// Token: 0x04000D1C RID: 3356
		private string[] infraStone_low_sounds = new string[]
		{
			"infrastructure_stone_low_1",
			"infrastructure_stone_low_2",
			"infrastructure_stone_low_3",
			"infrastructure_stone_low_4",
			"infrastructure_stone_low_5",
			"infrastructure_stone_low_6",
			"infrastructure_stone_low_7",
			"infrastructure_stone_low_8",
			"infrastructure_stone_low_9",
			"infrastructure_stone_low_10"
		};

		// Token: 0x04000D1D RID: 3357
		private string[] infraStone_mid_sounds = new string[]
		{
			"infrastructure_stone_med_1",
			"infrastructure_stone_med_2",
			"infrastructure_stone_med_3",
			"infrastructure_stone_med_4",
			"infrastructure_stone_med_5",
			"infrastructure_stone_med_6",
			"infrastructure_stone_med_7",
			"infrastructure_stone_med_8",
			"infrastructure_stone_med_9",
			"infrastructure_stone_med_10"
		};

		// Token: 0x04000D1E RID: 3358
		private string[] infraStone_high_sounds = new string[]
		{
			"infrastructure_stone_high_1",
			"infrastructure_stone_high_2",
			"infrastructure_stone_high_3",
			"infrastructure_stone_high_4",
			"infrastructure_stone_high_5",
			"infrastructure_stone_high_6",
			"infrastructure_stone_high_7",
			"infrastructure_stone_high_8",
			"infrastructure_stone_high_9",
			"infrastructure_stone_high_10"
		};

		// Token: 0x04000D1F RID: 3359
		private CastleMap.BattlePlaySFX oilSounds = new CastleMap.BattlePlaySFX();

		// Token: 0x04000D20 RID: 3360
		private string[] oil_low_sounds = new string[]
		{
			"oil_single_1",
			"oil_single_2",
			"oil_single_3",
			"oil_single_4",
			"oil_single_5"
		};

		// Token: 0x04000D21 RID: 3361
		private string[] oil_mid_sounds = new string[]
		{
			"oil_several_1",
			"oil_several_2",
			"oil_several_3",
			"oil_several_4",
			"oil_several_5"
		};

		// Token: 0x04000D22 RID: 3362
		private CastleMap.BattlePlaySFX ballistaBoltSounds = new CastleMap.BattlePlaySFX();

		// Token: 0x04000D23 RID: 3363
		private string[] ballista_low_sounds = new string[]
		{
			"ballista_low_1",
			"ballista_low_2",
			"ballista_low_3",
			"ballista_low_4",
			"ballista_low_5"
		};

		// Token: 0x04000D24 RID: 3364
		private string[] ballista_mid_sounds = new string[]
		{
			"ballista_med_1",
			"ballista_med_2",
			"ballista_med_3",
			"ballista_med_4",
			"ballista_med_5"
		};

		// Token: 0x04000D25 RID: 3365
		private string[] ballista_high_sounds = new string[]
		{
			"ballista_high_1",
			"ballista_high_2",
			"ballista_high_3",
			"ballista_high_4",
			"ballista_high_5"
		};

		// Token: 0x04000D26 RID: 3366
		private CastleMap.BattlePlaySFX troopDeathSounds = new CastleMap.BattlePlaySFX();

		// Token: 0x04000D27 RID: 3367
		private string[] troopdeath_low_sounds = new string[]
		{
			"troopdeath_low_1",
			"troopdeath_low_2",
			"troopdeath_low_3",
			"troopdeath_low_4",
			"troopdeath_low_5",
			"troopdeath_low_6",
			"troopdeath_low_7",
			"troopdeath_low_8",
			"troopdeath_low_9",
			"troopdeath_low_10",
			"troopdeath_med_1",
			"troopdeath_med_2",
			"troopdeath_med_3",
			"troopdeath_med_4",
			"troopdeath_med_5",
			"troopdeath_med_6",
			"troopdeath_med_7",
			"troopdeath_med_8",
			"troopdeath_med_9",
			"troopdeath_med_10",
			"troopdeath_high_1",
			"troopdeath_high_2",
			"troopdeath_high_3",
			"troopdeath_high_4",
			"troopdeath_high_5",
			"troopdeath_high_6",
			"troopdeath_high_7",
			"troopdeath_high_8",
			"troopdeath_high_9",
			"troopdeath_high_10"
		};

		// Token: 0x04000D28 RID: 3368
		private string[] troopdeath_mid_sounds = new string[]
		{
			"troopdeath_low_1",
			"troopdeath_low_2",
			"troopdeath_low_3",
			"troopdeath_low_4",
			"troopdeath_low_5",
			"troopdeath_low_6",
			"troopdeath_low_7",
			"troopdeath_low_8",
			"troopdeath_low_9",
			"troopdeath_low_10",
			"troopdeath_med_1",
			"troopdeath_med_2",
			"troopdeath_med_3",
			"troopdeath_med_4",
			"troopdeath_med_5",
			"troopdeath_med_6",
			"troopdeath_med_7",
			"troopdeath_med_8",
			"troopdeath_med_9",
			"troopdeath_med_10",
			"troopdeath_high_1",
			"troopdeath_high_2",
			"troopdeath_high_3",
			"troopdeath_high_4",
			"troopdeath_high_5",
			"troopdeath_high_6",
			"troopdeath_high_7",
			"troopdeath_high_8",
			"troopdeath_high_9",
			"troopdeath_high_10"
		};

		// Token: 0x04000D29 RID: 3369
		private string[] troopdeath_high_sounds = new string[]
		{
			"troopdeath_low_1",
			"troopdeath_low_2",
			"troopdeath_low_3",
			"troopdeath_low_4",
			"troopdeath_low_5",
			"troopdeath_low_6",
			"troopdeath_low_7",
			"troopdeath_low_8",
			"troopdeath_low_9",
			"troopdeath_low_10",
			"troopdeath_med_1",
			"troopdeath_med_2",
			"troopdeath_med_3",
			"troopdeath_med_4",
			"troopdeath_med_5",
			"troopdeath_med_6",
			"troopdeath_med_7",
			"troopdeath_med_8",
			"troopdeath_med_9",
			"troopdeath_med_10",
			"troopdeath_high_1",
			"troopdeath_high_2",
			"troopdeath_high_3",
			"troopdeath_high_4",
			"troopdeath_high_5",
			"troopdeath_high_6",
			"troopdeath_high_7",
			"troopdeath_high_8",
			"troopdeath_high_9",
			"troopdeath_high_10"
		};

		// Token: 0x04000D2A RID: 3370
		private CastleMap.BattlePlaySFX troopDeathOnFireSounds = new CastleMap.BattlePlaySFX();

		// Token: 0x04000D2B RID: 3371
		private string[] troopdeathonfire_low_sounds = new string[]
		{
			"troopdeathonfire_low_1",
			"troopdeathonfire_low_2",
			"troopdeathonfire_low_3",
			"troopdeathonfire_low_4",
			"troopdeathonfire_med_1",
			"troopdeathonfire_med_2",
			"troopdeathonfire_med_3",
			"troopdeathonfire_med_4",
			"troopdeathonfire_high_1",
			"troopdeathonfire_high_2",
			"troopdeathonfire_high_3",
			"troopdeathonfire_high_4"
		};

		// Token: 0x04000D2C RID: 3372
		private CastleMap.BattlePlaySFX infraWoodDestroyedSounds = new CastleMap.BattlePlaySFX();

		// Token: 0x04000D2D RID: 3373
		private string[] wooddestroyed_low_sounds = new string[]
		{
			"wooddestroyed_low_1",
			"wooddestroyed_low_2",
			"wooddestroyed_low_3",
			"wooddestroyed_low_4",
			"wooddestroyed_low_5",
			"wooddestroyed_low_6"
		};

		// Token: 0x04000D2E RID: 3374
		private string[] wooddestroyed_mid_sounds = new string[]
		{
			"wooddestroyed_med_1",
			"wooddestroyed_med_2",
			"wooddestroyed_med_3",
			"wooddestroyed_med_4",
			"wooddestroyed_med_5",
			"wooddestroyed_med_6"
		};

		// Token: 0x04000D2F RID: 3375
		private string[] wooddestroyed_high_sounds = new string[]
		{
			"wooddestroyed_high_1",
			"wooddestroyed_high_2",
			"wooddestroyed_high_3",
			"wooddestroyed_high_4",
			"wooddestroyed_high_5",
			"wooddestroyed_high_6"
		};

		// Token: 0x04000D30 RID: 3376
		private CastleMap.BattlePlaySFX infraStoneSmallDestroyedSounds = new CastleMap.BattlePlaySFX();

		// Token: 0x04000D31 RID: 3377
		private string[] stonesmalldestroyed_low_sounds = new string[]
		{
			"stonesmalldestroyed_low_1",
			"stonesmalldestroyed_low_2",
			"stonesmalldestroyed_low_3",
			"stonesmalldestroyed_low_4",
			"stonesmalldestroyed_low_5",
			"stonesmalldestroyed_low_6"
		};

		// Token: 0x04000D32 RID: 3378
		private string[] stonesmalldestroyed_mid_sounds = new string[]
		{
			"stonesmalldestroyed_med_1",
			"stonesmalldestroyed_med_2",
			"stonesmalldestroyed_med_3",
			"stonesmalldestroyed_med_4",
			"stonesmalldestroyed_med_5",
			"stonesmalldestroyed_med_6"
		};

		// Token: 0x04000D33 RID: 3379
		private string[] stonesmalldestroyed_high_sounds = new string[]
		{
			"stonesmalldestroyed_high_1",
			"stonesmalldestroyed_high_2",
			"stonesmalldestroyed_high_3",
			"stonesmalldestroyed_high_4",
			"stonesmalldestroyed_high_5",
			"stonesmalldestroyed_high_6"
		};

		// Token: 0x04000D34 RID: 3380
		private CastleMap.BattlePlaySFX infraStoneLargeDestroyedSounds = new CastleMap.BattlePlaySFX();

		// Token: 0x04000D35 RID: 3381
		private string[] stonelargedestroyed_low_sounds = new string[]
		{
			"stonelargedestroyed_low_1",
			"stonelargedestroyed_low_2",
			"stonelargedestroyed_low_3",
			"stonelargedestroyed_low_4"
		};

		// Token: 0x04000D36 RID: 3382
		private string[] stonelargedestroyed_mid_sounds = new string[]
		{
			"stonelargedestroyed_med_1",
			"stonelargedestroyed_med_2",
			"stonelargedestroyed_med_3",
			"stonelargedestroyed_med_4"
		};

		// Token: 0x04000D37 RID: 3383
		private string[] stonelargedestroyed_high_sounds = new string[]
		{
			"stonelargedestroyed_high_1",
			"stonelargedestroyed_high_2",
			"stonelargedestroyed_high_3",
			"stonelargedestroyed_high_4"
		};

		// Token: 0x04000D38 RID: 3384
		private CastleMap.BattlePlaySFX rockFirstSounds = new CastleMap.BattlePlaySFX();

		// Token: 0x04000D39 RID: 3385
		private string[] rockfired_low_sounds = new string[]
		{
			"rockfired_low_1",
			"rockfired_low_2",
			"rockfired_low_3",
			"rockfired_low_4",
			"rockfired_low_5",
			"rockfired_low_6",
			"rockfired_low_7",
			"rockfired_low_8",
			"rockfired_low_9",
			"rockfired_low_10"
		};

		// Token: 0x04000D3A RID: 3386
		private string[] rockfired_mid_sounds = new string[]
		{
			"rockfired_med_1",
			"rockfired_med_2",
			"rockfired_med_3",
			"rockfired_med_4",
			"rockfired_med_5",
			"rockfired_med_6",
			"rockfired_med_7",
			"rockfired_med_8",
			"rockfired_med_9",
			"rockfired_med_10"
		};

		// Token: 0x04000D3B RID: 3387
		private string[] rockfired_high_sounds = new string[]
		{
			"rockfired_high_1",
			"rockfired_high_2",
			"rockfired_high_3",
			"rockfired_high_4",
			"rockfired_high_5",
			"rockfired_high_6",
			"rockfired_high_7",
			"rockfired_high_8",
			"rockfired_high_9",
			"rockfired_high_10"
		};

		// Token: 0x04000D3C RID: 3388
		private CastleMap.BattlePlaySFX rockLandSounds = new CastleMap.BattlePlaySFX();

		// Token: 0x04000D3D RID: 3389
		private string[] rockland_low_sounds = new string[]
		{
			"rockland_low_1",
			"rockland_low_2",
			"rockland_low_3",
			"rockland_low_4",
			"rockland_low_5",
			"rockland_low_6",
			"rockland_low_7",
			"rockland_low_8",
			"rockland_low_9",
			"rockland_low_10"
		};

		// Token: 0x04000D3E RID: 3390
		private string[] rockland_mid_sounds = new string[]
		{
			"rockland_med_1",
			"rockland_med_2",
			"rockland_med_3",
			"rockland_med_4",
			"rockland_med_5",
			"rockland_med_6",
			"rockland_med_7",
			"rockland_med_8",
			"rockland_med_9",
			"rockland_med_10"
		};

		// Token: 0x04000D3F RID: 3391
		private string[] rockland_high_sounds = new string[]
		{
			"rockland_high_1",
			"rockland_high_2",
			"rockland_high_3",
			"rockland_high_4",
			"rockland_high_5",
			"rockland_high_6",
			"rockland_high_7",
			"rockland_high_8",
			"rockland_high_9",
			"rockland_high_10"
		};

		// Token: 0x04000D40 RID: 3392
		private CastleMap.BattlePlaySFX rockHitSounds = new CastleMap.BattlePlaySFX();

		// Token: 0x04000D41 RID: 3393
		private string[] rockhit_low_sounds = new string[]
		{
			"rockhit_low_1",
			"rockhit_low_2",
			"rockhit_low_3",
			"rockhit_low_4",
			"rockhit_low_5",
			"rockhit_low_6",
			"rockhit_low_7",
			"rockhit_low_8",
			"rockhit_low_9",
			"rockhit_low_10"
		};

		// Token: 0x04000D42 RID: 3394
		private string[] rockhit_mid_sounds = new string[]
		{
			"rockhit_med_1",
			"rockhit_med_2",
			"rockhit_med_3",
			"rockhit_med_4",
			"rockhit_med_5",
			"rockhit_med_6",
			"rockhit_med_7",
			"rockhit_med_8",
			"rockhit_med_9",
			"rockhit_med_10"
		};

		// Token: 0x04000D43 RID: 3395
		private string[] rockhit_high_sounds = new string[]
		{
			"rockhit_high_1",
			"rockhit_high_2",
			"rockhit_high_3",
			"rockhit_high_4",
			"rockhit_high_5",
			"rockhit_high_6",
			"rockhit_high_7",
			"rockhit_high_8",
			"rockhit_high_9",
			"rockhit_high_10"
		};

		// Token: 0x04000D44 RID: 3396
		private CastleMap.BattlePlaySFX openPitsSounds = new CastleMap.BattlePlaySFX();

		// Token: 0x04000D45 RID: 3397
		private string[] openpits_low_sounds = new string[]
		{
			"openpits_low_1",
			"openpits_low_2",
			"openpits_low_3",
			"openpits_low_4",
			"openpits_low_5",
			"openpits_low_6"
		};

		// Token: 0x04000D46 RID: 3398
		private string[] openpits_mid_sounds = new string[]
		{
			"openpits_med_1",
			"openpits_med_2",
			"openpits_med_3",
			"openpits_med_4",
			"openpits_med_5",
			"openpits_med_6"
		};

		// Token: 0x04000D47 RID: 3399
		private string[] openpits_high_sounds = new string[]
		{
			"openpits_high_1",
			"openpits_high_2",
			"openpits_high_3",
			"openpits_high_4",
			"openpits_high_5",
			"openpits_high_6"
		};

		// Token: 0x04000D48 RID: 3400
		private int m_nextWolfSound = -1000000;

		// Token: 0x04000D49 RID: 3401
		private string[] wolves_low_sounds = new string[]
		{
			"wolfhowl_low_1",
			"wolfhowl_low_2",
			"wolfhowl_low_3",
			"wolfhowl_low_4",
			"wolfhowl_low_5",
			"wolfhowl_low_6",
			"wolfhowl_low_7",
			"wolfhowl_low_8",
			"wolfhowl_low_9",
			"wolfhowl_low_10"
		};

		// Token: 0x04000D4A RID: 3402
		private string[] wolves_mid_sounds = new string[]
		{
			"wolfhowl_med_1",
			"wolfhowl_med_2",
			"wolfhowl_med_3",
			"wolfhowl_med_4",
			"wolfhowl_med_5",
			"wolfhowl_med_6",
			"wolfhowl_med_7",
			"wolfhowl_med_8",
			"wolfhowl_med_9",
			"wolfhowl_med_10"
		};

		// Token: 0x04000D4B RID: 3403
		private string[] wolves_high_sounds = new string[]
		{
			"wolfhowl_high_1",
			"wolfhowl_high_2",
			"wolfhowl_high_3",
			"wolfhowl_high_4",
			"wolfhowl_high_5",
			"wolfhowl_high_6",
			"wolfhowl_high_7",
			"wolfhowl_high_8",
			"wolfhowl_high_9",
			"wolfhowl_high_10"
		};

		// Token: 0x04000D4C RID: 3404
		private int m_nextKnightSound = -1000000;

		// Token: 0x04000D4D RID: 3405
		private string[] knight_low_sounds = new string[]
		{
			"movingknight_low_1",
			"movingknight_low_2",
			"movingknight_low_3",
			"movingknight_low_4",
			"movingknight_low_5",
			"movingknight_low_6"
		};

		// Token: 0x04000D4E RID: 3406
		private string[] knight_mid_sounds = new string[]
		{
			"movingknight_med_1",
			"movingknight_med_2",
			"movingknight_med_3",
			"movingknight_med_4",
			"movingknight_med_5",
			"movingknight_med_6"
		};

		// Token: 0x04000D4F RID: 3407
		private string[] knight_high_sounds = new string[]
		{
			"movingknight_high_1",
			"movingknight_high_2",
			"movingknight_high_3",
			"movingknight_high_4",
			"movingknight_high_5",
			"movingknight_high_6"
		};

		// Token: 0x04000D50 RID: 3408
		private CastleMap.BattlePlaySFX horseDeathSounds = new CastleMap.BattlePlaySFX();

		// Token: 0x04000D51 RID: 3409
		private string[] horsedeath_low_sounds = new string[]
		{
			"horsedeath_1",
			"horsedeath_2",
			"horsedeath_3",
			"horsedeath_4",
			"horsedeath_5"
		};

		// Token: 0x04000D52 RID: 3410
		private CastleMap.BattlePlaySFX wolfDeathSounds = new CastleMap.BattlePlaySFX();

		// Token: 0x04000D53 RID: 3411
		private string[] wolfdeath_low_sounds = new string[]
		{
			"wolfdeath_1",
			"wolfdeath_2",
			"wolfdeath_3",
			"wolfdeath_4",
			"wolfdeath_5"
		};

		// Token: 0x04000D54 RID: 3412
		private CastleMap.BattlePlaySFX catapultDeathSounds = new CastleMap.BattlePlaySFX();

		// Token: 0x04000D55 RID: 3413
		private string[] catapultdeath_low_sounds = new string[]
		{
			"catapultdeath_1",
			"catapultdeath_2",
			"catapulteath_3",
			"catapultdeath_4",
			"catapultdeath_5"
		};

		// Token: 0x04000D56 RID: 3414
		private int m_nextCaptainDelaySound = -1000000;

		// Token: 0x04000D57 RID: 3415
		private int m_nextCaptainRallySound = -1000000;

		// Token: 0x04000D58 RID: 3416
		private int m_nextCaptainBattleSound = -1000000;

		// Token: 0x04000D59 RID: 3417
		protected Random sfxRandom = new Random();

		// Token: 0x04000D5A RID: 3418
		public bool attackerSetupMode;

		// Token: 0x04000D5B RID: 3419
		public bool attackerSetupForest;

		// Token: 0x04000D5C RID: 3420
		private bool placingAttackerRealMode;

		// Token: 0x04000D5D RID: 3421
		private int attackMaxPeasants;

		// Token: 0x04000D5E RID: 3422
		private int attackMaxArchers;

		// Token: 0x04000D5F RID: 3423
		private int attackMaxPikemen;

		// Token: 0x04000D60 RID: 3424
		private int attackMaxSwordsmen;

		// Token: 0x04000D61 RID: 3425
		private int attackMaxCatapults;

		// Token: 0x04000D62 RID: 3426
		private int attackMaxCaptains;

		// Token: 0x04000D63 RID: 3427
		public int attackNumPeasants;

		// Token: 0x04000D64 RID: 3428
		public int attackNumArchers;

		// Token: 0x04000D65 RID: 3429
		public int attackNumPikemen;

		// Token: 0x04000D66 RID: 3430
		public int attackNumSwordsmen;

		// Token: 0x04000D67 RID: 3431
		public int attackNumCatapults;

		// Token: 0x04000D68 RID: 3432
		public int attackNumCaptains;

		// Token: 0x04000D69 RID: 3433
		public int attackRealAttackingVillage = -1;

		// Token: 0x04000D6A RID: 3434
		public int attackRealTargetVillage = -1;

		// Token: 0x04000D6B RID: 3435
		private int attackRealAttackType;

		// Token: 0x04000D6C RID: 3436
		private int attackPillagePercent;

		// Token: 0x04000D6D RID: 3437
		private int attackCaptainsCommand;

		// Token: 0x04000D6E RID: 3438
		private int attackMaxPeasantsInCastle;

		// Token: 0x04000D6F RID: 3439
		private int attackMaxArchersInCastle;

		// Token: 0x04000D70 RID: 3440
		private int attackMaxPikemenInCastle;

		// Token: 0x04000D71 RID: 3441
		private int attackMaxSwordsmenInCastle;

		// Token: 0x04000D72 RID: 3442
		private double attackCapitalAttackRate;

		// Token: 0x04000D73 RID: 3443
		public int m_targetUserID = -1;

		// Token: 0x04000D74 RID: 3444
		public string m_targetUserName = "";

		// Token: 0x04000D75 RID: 3445
		public BattleHonourData m_battleHonourData;

		// Token: 0x04000D76 RID: 3446
		public int ParentOfAttackingVillage = -1;

		// Token: 0x04000D77 RID: 3447
		public CastleCombat castleCombat;

		// Token: 0x04000D78 RID: 3448
		private static byte[] tempCompressedAttackerMap;

		// Token: 0x04000D79 RID: 3449
		public int debugDisplayMode;

		// Token: 0x04000D7A RID: 3450
		public bool battleMode;

		// Token: 0x04000D7B RID: 3451
		private bool endOfBattle;

		// Token: 0x04000D7C RID: 3452
		private BattleTroopNumbers startingTroopNumbers;

		// Token: 0x04000D7D RID: 3453
		private BattleTroopNumbers endingTroopNumbers;

		// Token: 0x04000D7E RID: 3454
		private CastleResearchData m_defenderResearch;

		// Token: 0x04000D7F RID: 3455
		private CastleResearchData m_attackerResearch;

		// Token: 0x04000D80 RID: 3456
		private int battleLandType;

		// Token: 0x04000D81 RID: 3457
		private bool treasureCastle;

		// Token: 0x04000D82 RID: 3458
		private int treasureCastleClock;

		// Token: 0x04000D83 RID: 3459
		private GetReport_ReturnType m_reportReturnData;

		// Token: 0x04000D84 RID: 3460
		private bool inDeleteConstructing;

		// Token: 0x04000D85 RID: 3461
		private DateTime lastDeleteConstructing = DateTime.MinValue;

		// Token: 0x04000D86 RID: 3462
		private bool deletingTouchScreen;

		// Token: 0x04000D87 RID: 3463
		public CastleMap.DeleteType deleteType;

		// Token: 0x04000D88 RID: 3464
		private List<long> deletingElements = new List<long>();

		// Token: 0x04000D89 RID: 3465
		private bool spreadTypeDiamond = true;

		// Token: 0x02000116 RID: 278
		public class TempTileSortClass
		{
			// Token: 0x04000D8A RID: 3466
			public int gx;

			// Token: 0x04000D8B RID: 3467
			public int gy;

			// Token: 0x04000D8C RID: 3468
			public int sx;

			// Token: 0x04000D8D RID: 3469
			public int sy;
		}

		// Token: 0x02000117 RID: 279
		public class TempTileSortComparer : IComparer<CastleMap.TempTileSortClass>
		{
			// Token: 0x06000A3B RID: 2619 RVA: 0x0000DC0F File Offset: 0x0000BE0F
			public int Compare(CastleMap.TempTileSortClass y, CastleMap.TempTileSortClass x)
			{
				if (x == null)
				{
					if (y == null)
					{
						return 0;
					}
					return -1;
				}
				else
				{
					if (y == null)
					{
						return 1;
					}
					if (x.sy < y.sy)
					{
						return 1;
					}
					if (x.sy > y.sy)
					{
						return -1;
					}
					return 0;
				}
			}
		}

		// Token: 0x02000118 RID: 280
		public class TroopClickArea
		{
			// Token: 0x06000A3D RID: 2621 RVA: 0x0000DC41 File Offset: 0x0000BE41
			public void addUnit(Point pos, long id)
			{
				this.elementID = id;
				this.x = pos.X - 16;
				this.w = 32;
				this.h = 50;
				this.y = pos.Y - 39;
			}

			// Token: 0x06000A3E RID: 2622 RVA: 0x000CCCC0 File Offset: 0x000CAEC0
			public bool clicked(Point mousePos)
			{
				return mousePos.X >= this.x && mousePos.X <= this.x + this.w && mousePos.Y >= this.y && mousePos.Y <= this.y + this.h;
			}

			// Token: 0x04000D8E RID: 3470
			public int x;

			// Token: 0x04000D8F RID: 3471
			public int y;

			// Token: 0x04000D90 RID: 3472
			public int w;

			// Token: 0x04000D91 RID: 3473
			public int h;

			// Token: 0x04000D92 RID: 3474
			public long elementID;
		}

		// Token: 0x02000119 RID: 281
		public enum Gesture
		{
			// Token: 0x04000D94 RID: 3476
			NONE,
			// Token: 0x04000D95 RID: 3477
			RESIZING_NORTHWEST,
			// Token: 0x04000D96 RID: 3478
			RESIZING_NORTHEAST,
			// Token: 0x04000D97 RID: 3479
			RESIZING_SOUTHWEST,
			// Token: 0x04000D98 RID: 3480
			RESIZING_SOUTHEAST,
			// Token: 0x04000D99 RID: 3481
			DRAGGING
		}

		// Token: 0x0200011A RID: 282
		// (Invoke) Token: 0x06000A41 RID: 2625
		public delegate void OnTroopPlaced_Delegate(CastleElement element);

		// Token: 0x0200011B RID: 283
		public enum TroopFacingDirection
		{
			// Token: 0x04000D9B RID: 3483
			NONE,
			// Token: 0x04000D9C RID: 3484
			LOOKING_SOUTHEAST,
			// Token: 0x04000D9D RID: 3485
			LOOKING_SOUTHWEST,
			// Token: 0x04000D9E RID: 3486
			LOOKING_NORTHEAST,
			// Token: 0x04000D9F RID: 3487
			LOOKING_NORTHWEST
		}

		// Token: 0x0200011C RID: 284
		public enum BrushSize
		{
			// Token: 0x04000DA1 RID: 3489
			BRUSH_1X5,
			// Token: 0x04000DA2 RID: 3490
			BRUSH_1X1,
			// Token: 0x04000DA3 RID: 3491
			BRUSH_3X3,
			// Token: 0x04000DA4 RID: 3492
			BRUSH_5X5
		}

		// Token: 0x0200011D RID: 285
		public class CatapultLine
		{
			// Token: 0x04000DA5 RID: 3493
			public int startX = -1;

			// Token: 0x04000DA6 RID: 3494
			public int startY = -1;

			// Token: 0x04000DA7 RID: 3495
			public int endX = -1;

			// Token: 0x04000DA8 RID: 3496
			public int endY = -1;
		}

		// Token: 0x0200011E RID: 286
		// (Invoke) Token: 0x06000A46 RID: 2630
		public delegate void onBattleFinishDelegate(bool attackerVictory, BattleTroopNumbers startingTroops, BattleTroopNumbers endingTroops, int villageID, GetReport_ReturnType reportReturnData);

		// Token: 0x0200011F RID: 287
		public class BattlePlaySFX
		{
			// Token: 0x06000A49 RID: 2633 RVA: 0x000CCD1C File Offset: 0x000CAF1C
			public void playBattleSounds(int tick, int numEvents, int soundDelay, int multiplier, int lowThreshold, string[] lowSounds, int midThreshold, string[] midSounds, string[] highSounds, CastleMap parent)
			{
				if (tick - this.sfx_nextSound > 0 && numEvents > 0)
				{
					this.sfx_nextSound = tick + soundDelay * multiplier;
					if (numEvents < lowThreshold)
					{
						parent.playRandSFX(lowSounds);
						return;
					}
					if (numEvents < midThreshold)
					{
						parent.playRandSFX(midSounds);
						return;
					}
					parent.playRandSFX(highSounds);
				}
			}

			// Token: 0x06000A4A RID: 2634 RVA: 0x000CCD6C File Offset: 0x000CAF6C
			public void playBattleSoundsNO(int tick, int numEvents, int soundDelay, int multiplier, int lowThreshold, string[] lowSounds, int midThreshold, string[] midSounds, string[] highSounds, CastleMap parent)
			{
				if (tick - this.sfx_nextSound > 0 && numEvents > 0)
				{
					this.sfx_nextSound = tick + (soundDelay + parent.sfxRandom.Next(soundDelay / 2)) * multiplier;
					if (numEvents < lowThreshold)
					{
						parent.playRandSFXNoOverwrite(lowSounds);
						return;
					}
					if (numEvents < midThreshold)
					{
						parent.playRandSFXNoOverwrite(midSounds);
						return;
					}
					parent.playRandSFXNoOverwrite(highSounds);
				}
			}

			// Token: 0x04000DA9 RID: 3497
			public int sfx_nextSound = -1000000;
		}

		// Token: 0x02000120 RID: 288
		public enum DeleteType
		{
			// Token: 0x04000DAB RID: 3499
			ALL,
			// Token: 0x04000DAC RID: 3500
			WALLS,
			// Token: 0x04000DAD RID: 3501
			BUILDINGS
		}

		// Token: 0x02000121 RID: 289
		public class RestoreCastleElement
		{
			// Token: 0x04000DAE RID: 3502
			public byte xPos;

			// Token: 0x04000DAF RID: 3503
			public byte yPos;

			// Token: 0x04000DB0 RID: 3504
			public byte elementType;

			// Token: 0x04000DB1 RID: 3505
			public byte targXPos;

			// Token: 0x04000DB2 RID: 3506
			public byte targYPos;

			// Token: 0x04000DB3 RID: 3507
			public byte delay;
		}
	}
}
