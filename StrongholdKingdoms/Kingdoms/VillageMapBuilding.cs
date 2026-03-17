using System;
using System.Drawing;
using CommonTypes;
using DXGraphics;

namespace Kingdoms
{
	// Token: 0x020004E0 RID: 1248
	public class VillageMapBuilding
	{
		// Token: 0x1700026F RID: 623
		// (set) Token: 0x06002EB0 RID: 11952 RVA: 0x00021E7F File Offset: 0x0002007F
		public bool Visible
		{
			set
			{
				if (this.shadowSprite != null)
				{
					this.shadowSprite.Visible = value;
				}
				if (this.baseSprite != null)
				{
					this.baseSprite.Visible = value;
				}
				if (this.worker != null)
				{
					this.worker.Visible = value;
				}
			}
		}

		// Token: 0x06002EB1 RID: 11953 RVA: 0x00021EBD File Offset: 0x000200BD
		public bool isComplete()
		{
			return this.complete && this.localComplete;
		}

		// Token: 0x06002EB2 RID: 11954 RVA: 0x00021ECF File Offset: 0x000200CF
		public bool isDeleting()
		{
			return this.serverDeleting;
		}

		// Token: 0x06002EB3 RID: 11955 RVA: 0x002568A8 File Offset: 0x00254AA8
		public void createFromReturnData(VillageBuildingReturnData serverBuild)
		{
			this.completeRequestSent = false;
			this.buildingID = serverBuild.buildingID;
			this.buildingLocation = serverBuild.buildingLocation;
			this.buildingType = serverBuild.buildingType;
			this.serverCalcRate = (this.calcRate = serverBuild.calcRate);
			this.serverJourneyTime = serverBuild.journeyTime;
			this.completionTime = serverBuild.completionTime;
			this.lastCalcTime = serverBuild.lastCalcTime;
			this.lastDataLevel = serverBuild.lastDataLevel;
			this.gotEmployee = serverBuild.gotEmployee;
			this.buildingActive = serverBuild.active;
			this.localComplete = true;
			this.deletionTime = serverBuild.deletionTime;
			this.serverDeleting = serverBuild.deleting;
			this.capitalResourceLevels = serverBuild.capitalResourceLevels;
			if (this.baseSprite != null)
			{
				this.baseSprite.clearText();
				this.baseSprite.clearSecondText();
			}
		}

		// Token: 0x06002EB4 RID: 11956 RVA: 0x00021ED7 File Offset: 0x000200D7
		public void initStorageBuilding(GraphicsMgr gfx, VillageMap vm)
		{
			if (this.buildingType == 2)
			{
				this.updateStockpile(gfx, vm);
			}
			if (this.buildingType == 3)
			{
				this.updateGranary(gfx, vm);
			}
			if (this.buildingType == 35)
			{
				this.updateInn(gfx, vm);
			}
		}

		// Token: 0x06002EB5 RID: 11957 RVA: 0x0025698C File Offset: 0x00254B8C
		public void updateStockpile(GraphicsMgr gfx, VillageMap vm)
		{
			if (this.baseSprite == null)
			{
				return;
			}
			if (this.stockpileExtension == null)
			{
				this.stockpileExtension = new VillageMapBuildingStockpileExtension();
				for (int i = 0; i < 16; i++)
				{
					this.stockpileExtension.cell[i] = new SpriteWrapper();
					this.stockpileExtension.cell[i].Visible = false;
					this.stockpileExtension.cell[i].PosX = (float)(-96 + VillageMapBuildingStockpileExtension.stockpileLayout[i * 2]);
					this.stockpileExtension.cell[i].PosY = (float)(-43 + VillageMapBuildingStockpileExtension.stockpileLayout[i * 2 + 1]);
					this.baseSprite.AddChild(this.stockpileExtension.cell[i]);
					this.stockpileExtension.showGood(gfx, i, -1, 0);
				}
			}
			for (int j = 0; j < 16; j++)
			{
				this.stockpileExtension.showGood(gfx, j, -1, 0);
			}
			VillageMap.StockpileLevels stockpileLevels = new VillageMap.StockpileLevels();
			if (vm.getStockpileLevels(stockpileLevels))
			{
				int num = (stockpileLevels.woodLevel > 13333248.0) ? 12 : ((stockpileLevels.woodLevel > 3733248.0) ? 11 : ((stockpileLevels.woodLevel > 1333248.0) ? 10 : ((stockpileLevels.woodLevel > 373248.0) ? 9 : ((stockpileLevels.woodLevel > 133248.0) ? 8 : ((stockpileLevels.woodLevel > 37248.0) ? 7 : ((stockpileLevels.woodLevel > 13248.0) ? 6 : ((stockpileLevels.woodLevel > 3648.0) ? 5 : ((stockpileLevels.woodLevel > 1248.0) ? 4 : ((stockpileLevels.woodLevel > 288.0) ? 3 : ((stockpileLevels.woodLevel > 48.0) ? 2 : ((stockpileLevels.woodLevel > 0.0) ? 1 : 0)))))))))));
				int num2 = (stockpileLevels.stoneLevel > 13333248.0) ? 12 : ((stockpileLevels.stoneLevel > 3733248.0) ? 11 : ((stockpileLevels.stoneLevel > 1333248.0) ? 10 : ((stockpileLevels.stoneLevel > 373248.0) ? 9 : ((stockpileLevels.stoneLevel > 133248.0) ? 8 : ((stockpileLevels.stoneLevel > 37248.0) ? 7 : ((stockpileLevels.stoneLevel > 13248.0) ? 6 : ((stockpileLevels.stoneLevel > 3648.0) ? 5 : ((stockpileLevels.stoneLevel > 1248.0) ? 4 : ((stockpileLevels.stoneLevel > 288.0) ? 3 : ((stockpileLevels.stoneLevel > 48.0) ? 2 : ((stockpileLevels.stoneLevel > 0.0) ? 1 : 0)))))))))));
				int num3 = (stockpileLevels.ironLevel > 13333248.0) ? 12 : ((stockpileLevels.ironLevel > 3733248.0) ? 11 : ((stockpileLevels.ironLevel > 1333248.0) ? 10 : ((stockpileLevels.ironLevel > 373248.0) ? 9 : ((stockpileLevels.ironLevel > 133248.0) ? 8 : ((stockpileLevels.ironLevel > 37248.0) ? 7 : ((stockpileLevels.ironLevel > 13248.0) ? 6 : ((stockpileLevels.ironLevel > 3648.0) ? 5 : ((stockpileLevels.ironLevel > 1248.0) ? 4 : ((stockpileLevels.ironLevel > 288.0) ? 3 : ((stockpileLevels.ironLevel > 48.0) ? 2 : ((stockpileLevels.ironLevel > 0.0) ? 1 : 0)))))))))));
				int num4 = (stockpileLevels.pitchLevel > 4444416.0) ? 12 : ((stockpileLevels.pitchLevel > 1244416.0) ? 11 : ((stockpileLevels.pitchLevel > 444416.0) ? 10 : ((stockpileLevels.pitchLevel > 124416.0) ? 9 : ((stockpileLevels.pitchLevel > 44416.0) ? 8 : ((stockpileLevels.pitchLevel > 12416.0) ? 7 : ((stockpileLevels.pitchLevel > 4416.0) ? 6 : ((stockpileLevels.pitchLevel > 1216.0) ? 5 : ((stockpileLevels.pitchLevel > 416.0) ? 4 : ((stockpileLevels.pitchLevel > 96.0) ? 3 : ((stockpileLevels.pitchLevel > 16.0) ? 2 : ((stockpileLevels.pitchLevel > 0.0) ? 1 : 0)))))))))));
				for (int k = 0; k < 16; k++)
				{
					this.pilesUsed[k] = false;
				}
				int num5 = num + num2 + num3 + num4;
				if (num5 > 16)
				{
					int num6 = 16;
					int num7 = 0;
					if (num >= 1)
					{
						num7++;
					}
					if (num2 >= 1)
					{
						num7++;
					}
					if (num3 >= 1)
					{
						num7++;
					}
					if (num4 >= 1)
					{
						num7++;
					}
					num6 -= num7;
					double num8 = (double)num6 / (double)(num5 - num7);
					VillageMapBuilding.PileOrderSort[] array = new VillageMapBuilding.PileOrderSort[4];
					int num9 = 0;
					if (num > 1)
					{
						VillageMapBuilding.PileOrderSort pileOrderSort = new VillageMapBuilding.PileOrderSort();
						pileOrderSort.origPiles = (pileOrderSort.numPiles = (double)(num - 1));
						pileOrderSort.type = 0;
						array[num9++] = pileOrderSort;
					}
					if (num2 > 1)
					{
						VillageMapBuilding.PileOrderSort pileOrderSort2 = new VillageMapBuilding.PileOrderSort();
						pileOrderSort2.origPiles = (pileOrderSort2.numPiles = (double)(num2 - 1));
						pileOrderSort2.type = 3;
						array[num9++] = pileOrderSort2;
					}
					if (num3 > 1)
					{
						VillageMapBuilding.PileOrderSort pileOrderSort3 = new VillageMapBuilding.PileOrderSort();
						pileOrderSort3.origPiles = (pileOrderSort3.numPiles = (double)(num3 - 1));
						pileOrderSort3.type = 4;
						array[num9++] = pileOrderSort3;
					}
					if (num4 > 1)
					{
						VillageMapBuilding.PileOrderSort pileOrderSort4 = new VillageMapBuilding.PileOrderSort();
						pileOrderSort4.origPiles = (pileOrderSort4.numPiles = (double)(num4 - 1));
						pileOrderSort4.type = 5;
						array[num9++] = pileOrderSort4;
					}
					if (num9 > 1)
					{
						for (int l = 0; l < num9 - 1; l++)
						{
							for (int m = 0; m < num9 - 1; m++)
							{
								if (array[m].numPiles < array[m + 1].numPiles)
								{
									VillageMapBuilding.PileOrderSort pileOrderSort5 = array[m];
									array[m] = array[m + 1];
									array[m + 1] = pileOrderSort5;
								}
							}
						}
					}
					int num10 = 0;
					for (int n = 0; n < num9; n++)
					{
						array[n].numPiles = Math.Floor(array[n].numPiles * num8);
						num10 += (int)array[n].numPiles;
					}
					if (num10 < num6)
					{
						int num11 = num6 - num10;
						int num12 = 0;
						while (num11 > 0)
						{
							int num13 = num12 % num9;
							if (array[num13].numPiles < array[num13].origPiles)
							{
								array[num13].numPiles += 1.0;
								num11--;
							}
							num12++;
						}
					}
					if (num >= 1)
					{
						num = 1;
					}
					if (num2 >= 1)
					{
						num2 = 1;
					}
					if (num3 >= 1)
					{
						num3 = 1;
					}
					if (num4 >= 1)
					{
						num4 = 1;
					}
					for (int num14 = 0; num14 < num9; num14++)
					{
						int num15 = (int)array[num14].numPiles;
						switch (array[num14].type)
						{
						case 0:
							num += num15;
							break;
						case 3:
							num2 += num15;
							break;
						case 4:
							num3 += num15;
							break;
						case 5:
							num4 += num15;
							break;
						}
					}
					int num16 = num + num2 + num3 + num4;
					if (num16 != 16)
					{
						num = 0;
					}
				}
				int num17 = 0;
				for (int num18 = 0; num18 < num; num18++)
				{
					int num19 = VillageMapBuilding.woodPileOrder[num17++];
					this.pilesUsed[num19] = true;
					if (num18 != num - 1)
					{
						this.stockpileExtension.showGood(gfx, num19, 6, 48);
					}
					else
					{
						int val = ((int)stockpileLevels.woodLevel - VillageMapBuilding.goods48Levels[num]) / VillageMapBuilding.goodsDividers[num];
						this.stockpileExtension.showGood(gfx, num19, 6, Math.Min(val, 48));
					}
				}
				num17 = 0;
				for (int num20 = 0; num20 < num3; num20++)
				{
					int num19;
					do
					{
						num19 = VillageMapBuilding.ironPileOrder[num17++];
					}
					while (this.pilesUsed[num19]);
					this.pilesUsed[num19] = true;
					if (num20 != num3 - 1)
					{
						this.stockpileExtension.showGood(gfx, num19, 8, 48);
					}
					else
					{
						int val2 = ((int)stockpileLevels.ironLevel - VillageMapBuilding.goods48Levels[num3]) / VillageMapBuilding.goodsDividers[num3];
						this.stockpileExtension.showGood(gfx, num19, 8, Math.Min(val2, 48));
					}
				}
				num17 = 0;
				for (int num21 = 0; num21 < num2; num21++)
				{
					int num19;
					do
					{
						num19 = VillageMapBuilding.stonePileOrder[num17++];
					}
					while (this.pilesUsed[num19]);
					this.pilesUsed[num19] = true;
					if (num21 != num2 - 1)
					{
						this.stockpileExtension.showGood(gfx, num19, 7, 48);
					}
					else
					{
						int val3 = ((int)stockpileLevels.stoneLevel - VillageMapBuilding.goods48Levels[num2]) / VillageMapBuilding.goodsDividers[num2];
						this.stockpileExtension.showGood(gfx, num19, 7, Math.Min(val3, 48));
					}
				}
				num17 = 0;
				for (int num22 = 0; num22 < num4; num22++)
				{
					int num19;
					do
					{
						num19 = VillageMapBuilding.pitchPileOrder[num17++];
					}
					while (this.pilesUsed[num19]);
					this.pilesUsed[num19] = true;
					if (num22 != num4 - 1)
					{
						this.stockpileExtension.showGood(gfx, num19, 9, 16);
					}
					else
					{
						int val4 = ((int)stockpileLevels.pitchLevel - VillageMapBuilding.goods16Levels[num4]) / VillageMapBuilding.goodsDividers[num4];
						this.stockpileExtension.showGood(gfx, num19, 9, Math.Min(val4, 16));
					}
				}
				return;
			}
			for (int num23 = 0; num23 < 16; num23++)
			{
				this.stockpileExtension.showGood(gfx, num23, -1, 0);
			}
		}

		// Token: 0x06002EB6 RID: 11958 RVA: 0x002573CC File Offset: 0x002555CC
		public void updateGranary(GraphicsMgr gfx, VillageMap vm)
		{
			if (this.baseSprite == null)
			{
				return;
			}
			if (this.granaryExtension == null)
			{
				this.granaryExtension = new VillageMapBuildingGranaryExtension();
				for (int i = 0; i < 21; i++)
				{
					this.granaryExtension.cell[i] = new SpriteWrapper();
					this.granaryExtension.cell[i].Visible = false;
					this.granaryExtension.cell[i].PosX = (float)(5 + VillageMapBuildingGranaryExtension.granaryLayout[i * 2]);
					this.granaryExtension.cell[i].PosY = (float)(-33 + VillageMapBuildingGranaryExtension.granaryLayout[i * 2 + 1]);
					this.baseSprite.AddChild(this.granaryExtension.cell[i]);
					this.granaryExtension.showGood(gfx, i, -1, 0);
				}
			}
			for (int j = 0; j < 21; j++)
			{
				this.granaryExtension.showGood(gfx, j, -1, 0);
			}
			VillageMap.GranaryLevels granaryLevels = new VillageMap.GranaryLevels();
			if (!vm.getGranaryLevels(granaryLevels))
			{
				return;
			}
			if (vm.granaryOpenCount == 0)
			{
				this.open = false;
			}
			double num = granaryLevels.applesLevel + granaryLevels.breadLevel + granaryLevels.cheeseLevel + granaryLevels.fishLevel + granaryLevels.meatLevel + granaryLevels.vegLevel;
			if (num <= 0.0 || vm.granaryOpenCount <= 0)
			{
				return;
			}
			this.open = true;
			int num2 = (granaryLevels.meatLevel > 416.0) ? 4 : ((granaryLevels.meatLevel > 96.0) ? 3 : ((granaryLevels.meatLevel > 16.0) ? 2 : ((granaryLevels.meatLevel > 0.0) ? 1 : 0)));
			int num3 = (granaryLevels.vegLevel > 96.0) ? 3 : ((granaryLevels.vegLevel > 16.0) ? 2 : ((granaryLevels.vegLevel > 0.0) ? 1 : 0));
			int num4 = (granaryLevels.cheeseLevel > 416.0) ? 4 : ((granaryLevels.cheeseLevel > 96.0) ? 3 : ((granaryLevels.cheeseLevel > 16.0) ? 2 : ((granaryLevels.cheeseLevel > 0.0) ? 1 : 0)));
			int num5 = (granaryLevels.applesLevel > 96.0) ? 3 : ((granaryLevels.applesLevel > 16.0) ? 2 : ((granaryLevels.applesLevel > 0.0) ? 1 : 0));
			int num6 = (granaryLevels.fishLevel > 96.0) ? 3 : ((granaryLevels.fishLevel > 16.0) ? 2 : ((granaryLevels.fishLevel > 0.0) ? 1 : 0));
			int num7 = (granaryLevels.breadLevel > 832.0) ? 4 : ((granaryLevels.breadLevel > 192.0) ? 3 : ((granaryLevels.breadLevel > 32.0) ? 2 : ((granaryLevels.breadLevel > 0.0) ? 1 : 0)));
			for (int k = 0; k < num2; k++)
			{
				int cellID = VillageMapBuilding.meatPileOrder[k];
				if (k != num2 - 1)
				{
					this.granaryExtension.showGood(gfx, cellID, 16, 16);
				}
				else
				{
					int val = ((int)granaryLevels.meatLevel - VillageMapBuilding.goods16Levels[num2]) / VillageMapBuilding.goodsDividers[num2];
					this.granaryExtension.showGood(gfx, cellID, 16, Math.Min(val, 16));
				}
			}
			for (int l = 0; l < num3; l++)
			{
				int cellID = VillageMapBuilding.vegPileOrder[l];
				if (l != num3 - 1)
				{
					this.granaryExtension.showGood(gfx, cellID, 15, 16);
				}
				else
				{
					int val2 = ((int)granaryLevels.vegLevel - VillageMapBuilding.goods16Levels[num3]) / VillageMapBuilding.goodsDividers[num3];
					this.granaryExtension.showGood(gfx, cellID, 15, Math.Min(val2, 16));
				}
			}
			for (int m = 0; m < num4; m++)
			{
				int cellID = VillageMapBuilding.cheesePileOrder[m];
				if (m != num4 - 1)
				{
					this.granaryExtension.showGood(gfx, cellID, 17, 16);
				}
				else
				{
					int val3 = ((int)granaryLevels.cheeseLevel - VillageMapBuilding.goods16Levels[num4]) / VillageMapBuilding.goodsDividers[num4];
					this.granaryExtension.showGood(gfx, cellID, 17, Math.Min(val3, 16));
				}
			}
			for (int n = 0; n < num5; n++)
			{
				int cellID = VillageMapBuilding.applesPileOrder[n];
				if (n != num5 - 1)
				{
					this.granaryExtension.showGood(gfx, cellID, 13, 16);
				}
				else
				{
					int val4 = ((int)granaryLevels.applesLevel - VillageMapBuilding.goods16Levels[num5]) / VillageMapBuilding.goodsDividers[num5];
					this.granaryExtension.showGood(gfx, cellID, 13, Math.Min(val4, 16));
				}
			}
			for (int num8 = 0; num8 < num6; num8++)
			{
				int cellID = VillageMapBuilding.fishPileOrder[num8];
				if (num8 != num6 - 1)
				{
					this.granaryExtension.showGood(gfx, cellID, 18, 16);
				}
				else
				{
					int val5 = ((int)granaryLevels.fishLevel - VillageMapBuilding.goods16Levels[num6]) / VillageMapBuilding.goodsDividers[num6];
					this.granaryExtension.showGood(gfx, cellID, 18, Math.Min(val5, 16));
				}
			}
			for (int num9 = 0; num9 < num7; num9++)
			{
				int cellID = VillageMapBuilding.breadPileOrder[num9];
				if (num9 != num7 - 1)
				{
					this.granaryExtension.showGood(gfx, cellID, 14, 32);
				}
				else
				{
					int val6 = ((int)granaryLevels.breadLevel - VillageMapBuilding.goods16Levels[num7] * 2) / VillageMapBuilding.goodsDividers[num7];
					this.granaryExtension.showGood(gfx, cellID, 14, Math.Min(val6, 32));
				}
			}
		}

		// Token: 0x06002EB7 RID: 11959 RVA: 0x0025796C File Offset: 0x00255B6C
		public void updateInn(GraphicsMgr gfx, VillageMap vm)
		{
			if (this.baseSprite == null)
			{
				return;
			}
			if (this.innExtension == null)
			{
				this.innExtension = new VillageMapBuildingInnExtension();
				for (int i = 0; i < 3; i++)
				{
					this.innExtension.cell[i] = new SpriteWrapper();
					this.innExtension.cell[i].Visible = false;
					this.innExtension.cell[i].PosX = (float)(-80 + VillageMapBuildingInnExtension.innLayout[i * 2]);
					this.innExtension.cell[i].PosY = (float)(-44 + VillageMapBuildingInnExtension.innLayout[i * 2 + 1]);
					this.baseSprite.AddChild(this.innExtension.cell[i]);
					this.innExtension.showGood(gfx, i, -1, 0);
				}
			}
			for (int j = 0; j < 3; j++)
			{
				this.innExtension.showGood(gfx, j, -1, 0);
			}
			VillageMap.InnLevels innLevels = new VillageMap.InnLevels();
			if (!vm.getInnLevels(innLevels))
			{
				return;
			}
			double aleLevel = innLevels.aleLevel;
			if (aleLevel != 0.0)
			{
				this.open = true;
				int num = (innLevels.aleLevel > 416.0) ? 4 : ((innLevels.aleLevel > 96.0) ? 3 : ((innLevels.aleLevel > 16.0) ? 2 : ((innLevels.aleLevel > 0.0) ? 1 : 0)));
				if (num > 3)
				{
					num = 3;
				}
				for (int k = 0; k < num; k++)
				{
					if (k != num - 1)
					{
						this.innExtension.showGood(gfx, k, 12, 16);
					}
					else
					{
						int val = ((int)innLevels.aleLevel - VillageMapBuilding.goods16Levels[num]) / VillageMapBuilding.goodsDividers[num];
						this.innExtension.showGood(gfx, k, 12, Math.Min(val, 16));
					}
				}
				return;
			}
			if (vm.m_effectiveAleRationsLevel > 0.0)
			{
				this.open = true;
				return;
			}
			this.open = false;
		}

		// Token: 0x06002EB8 RID: 11960 RVA: 0x00257B58 File Offset: 0x00255D58
		public bool updateConstructionGFX(double localBaseTime, DateTime serverBaseTime, bool initialUpdate, VillageMap vm)
		{
			if (this.baseSprite == null)
			{
				return false;
			}
			if (this.serverDeleting)
			{
				double num = (DXTimer.GetCurrentMilliseconds() - localBaseTime) / 1000.0;
				num -= 1.5;
				DateTime d = serverBaseTime.AddSeconds(num);
				if (!this.complete && d.CompareTo(this.completionTime) >= 0)
				{
					this.complete = true;
				}
				TimeSpan timeSpan = this.deletionTime - d;
				int num2 = (int)(timeSpan.TotalSeconds - 0.5);
				if (timeSpan.TotalDays > 10.0)
				{
					num2 = 9999999;
				}
				if (num2 > 0 && num2 < 10000000)
				{
					if (!vm.ViewOnly)
					{
						string text = VillageMap.createBuildTimeString(num2);
						this.baseSprite.attachText(text, new Point(0, -50), global::ARGBColors.White, true, true);
					}
				}
				else
				{
					this.baseSprite.clearText();
					this.baseSprite.clearSecondText();
					if (num2 <= 0)
					{
						return true;
					}
				}
				this.baseSprite.ColorToUse = Color.FromArgb(255, 255, 128, 128);
				if (this.animSprite != null)
				{
					this.animSprite.ColorToUse = this.baseSprite.ColorToUse;
				}
				if (this.extraAnimSprite1 != null)
				{
					this.extraAnimSprite1.ColorToUse = this.baseSprite.ColorToUse;
				}
				if (this.extraAnimSprite2 != null)
				{
					this.extraAnimSprite2.ColorToUse = this.baseSprite.ColorToUse;
				}
				return false;
			}
			if (this.complete)
			{
				return false;
			}
			bool flag = false;
			double num3 = (DXTimer.GetCurrentMilliseconds() - localBaseTime) / 1000.0;
			if (initialUpdate)
			{
				num3 = 0.0;
			}
			num3 -= 3.0;
			DateTime d2 = serverBaseTime.AddSeconds(num3);
			if (d2.CompareTo(this.completionTime) < 0)
			{
				flag = true;
			}
			if (this.buildingType == 0)
			{
				flag = false;
			}
			if (flag)
			{
				if (!this.highlighted)
				{
					this.baseSprite.ColorToUse = Color.FromArgb(128, 128, 128, 128);
					if (this.animSprite != null)
					{
						this.animSprite.ColorToUse = Color.FromArgb(128, 128, 128, 128);
					}
					if (this.extraAnimSprite1 != null)
					{
						this.extraAnimSprite1.ColorToUse = Color.FromArgb(128, 128, 128, 128);
					}
					if (this.extraAnimSprite2 != null)
					{
						this.extraAnimSprite2.ColorToUse = Color.FromArgb(128, 128, 128, 128);
					}
				}
				int num4 = (int)((this.completionTime - d2).TotalSeconds - 0.5);
				if (num4 > 0 && num4 < 10000000)
				{
					int num5 = num4;
					int num6;
					num4 = vm.updateConstructionDisplayTime(num4, this.completionTime, out num6);
					Color col = (num6 == 1) ? global::ARGBColors.White : global::ARGBColors.WhiteSmoke;
					if (!vm.ViewOnly)
					{
						string text2 = VillageMap.createBuildTimeString(num4);
						if (num4 != num5 && this.showFullConstructionText)
						{
							this.showFullConstructionText = false;
							string text3 = text2;
							text2 = string.Concat(new string[]
							{
								text3,
								Environment.NewLine,
								"(",
								VillageMap.createBuildTimeString(num5),
								")"
							});
						}
						this.baseSprite.attachText(text2, new Point(0, -40), global::ARGBColors.White, true, true);
						if (num6 > 0)
						{
							this.baseSprite.attachSecondText(num6.ToString(), new Point(0, -55), col, true, true);
						}
						else
						{
							this.baseSprite.clearSecondText();
						}
					}
				}
				else
				{
					this.baseSprite.clearText();
					this.baseSprite.clearSecondText();
				}
			}
			else
			{
				Color white = global::ARGBColors.White;
				this.baseSprite.ColorToUse = white;
				if (this.animSprite != null)
				{
					this.animSprite.ColorToUse = white;
				}
				if (this.extraAnimSprite1 != null)
				{
					this.extraAnimSprite1.ColorToUse = white;
				}
				if (this.extraAnimSprite2 != null)
				{
					this.extraAnimSprite2.ColorToUse = white;
				}
				this.complete = true;
				if (!initialUpdate)
				{
					this.localComplete = false;
					return true;
				}
				this.baseSprite.clearText();
				this.baseSprite.clearSecondText();
			}
			return false;
		}

		// Token: 0x06002EB9 RID: 11961 RVA: 0x00257F98 File Offset: 0x00256198
		public void updateSymbolGFX()
		{
			this.symbolSprite.Visible = false;
			this.symbolSprite.SpriteNo = 58;
			if (VillageBuildingsData.buildingRequiresWorker(this.buildingType) && this.complete)
			{
				if (!this.buildingActive)
				{
					this.symbolSprite.initAnim(59, 11, 1, 100);
					this.symbolSprite.Visible = true;
					return;
				}
				if (!this.gotEmployee)
				{
					this.symbolSprite.Visible = true;
				}
			}
		}

		// Token: 0x06002EBA RID: 11962 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void initProductionGFX()
		{
		}

		// Token: 0x06002EBB RID: 11963 RVA: 0x00258010 File Offset: 0x00256210
		public int getProductionSpriteNo(int buildingType)
		{
			switch (buildingType)
			{
			case 6:
				return 122;
			case 7:
				return 117;
			case 8:
				return 107;
			case 9:
				return 113;
			case 12:
				return 95;
			case 13:
				return 96;
			case 14:
				return 99;
			case 15:
				return 119;
			case 16:
				return 108;
			case 17:
				return 101;
			case 18:
				return 103;
			case 19:
				return 102;
			case 21:
				return 105;
			case 22:
				return 120;
			case 23:
				return 114;
			case 24:
				return 116;
			case 25:
				return 115;
			case 26:
				return 109;
			case 28:
				return 112;
			case 29:
				return 98;
			case 30:
				return 118;
			case 31:
				return 97;
			case 32:
				return 100;
			case 33:
				return 121;
			}
			return 123;
		}

		// Token: 0x06002EBC RID: 11964 RVA: 0x002580E4 File Offset: 0x002562E4
		public void updateProductionGFX(bool reset)
		{
			if (!Program.mySettings.ShowProductionInfo && this.productionSprite.Visible)
			{
				this.productionSprite.Visible = false;
				return;
			}
			if (!reset)
			{
				if (this.productionGFXCounter <= 50)
				{
					this.productionSprite.PosY -= 0.5f;
					this.productionSprite.changeAlpha(80);
					this.productionSprite.changeTextAlpha(80);
					this.productionSprite.changeSecondTextAlpha(80);
				}
				else
				{
					this.productionSprite.PosY -= 2f;
					this.productionSprite.changeAlpha(-10);
					this.productionSprite.changeTextAlpha(-10);
					this.productionSprite.changeSecondTextAlpha(-10);
				}
				this.productionGFXCounter++;
				return;
			}
			this.productionSprite.SpriteNo = this.getProductionSpriteNo(this.buildingType);
			this.productionSprite.Visible = true;
			this.productionSprite.PosX = 0f;
			this.productionSprite.PosY = -50f;
			this.productionSprite.ColorToUse = Color.FromArgb(0, 255, 255, 255);
			this.productionGFXCounter = 0;
			double payloadSize = GameEngine.Instance.LocalWorldData.getPayloadSize(this.buildingType);
			double num = CardTypes.adjustPayloadSize(GameEngine.Instance.cardsManager.UserCardData, payloadSize, this.buildingType) - payloadSize;
			if (num > 0.99)
			{
				this.productionSprite.attachText(payloadSize.ToString(), new Point(-15, 15), Color.FromArgb(0, 255, 255, 255), true, true);
				this.productionSprite.attachSecondText("(+" + num.ToString() + ")", new Point(10, 15), Color.FromArgb(0, 150, 255, 180), true, true);
				return;
			}
			this.productionSprite.attachText(payloadSize.ToString(), new Point(0, 15), global::ARGBColors.White, true, true);
		}

		// Token: 0x04003A10 RID: 14864
		public long buildingID;

		// Token: 0x04003A11 RID: 14865
		public int buildingType;

		// Token: 0x04003A12 RID: 14866
		public Point buildingLocation;

		// Token: 0x04003A13 RID: 14867
		public DateTime completionTime;

		// Token: 0x04003A14 RID: 14868
		public bool complete;

		// Token: 0x04003A15 RID: 14869
		public bool localComplete = true;

		// Token: 0x04003A16 RID: 14870
		public bool showFullConstructionText;

		// Token: 0x04003A17 RID: 14871
		public bool goTransparent;

		// Token: 0x04003A18 RID: 14872
		public bool completeRequestSent;

		// Token: 0x04003A19 RID: 14873
		public bool serverDeleting;

		// Token: 0x04003A1A RID: 14874
		public DateTime deletionTime;

		// Token: 0x04003A1B RID: 14875
		public DateTime lastCalcTime;

		// Token: 0x04003A1C RID: 14876
		public double calcRate;

		// Token: 0x04003A1D RID: 14877
		public double serverCalcRate;

		// Token: 0x04003A1E RID: 14878
		public double lastDataLevel;

		// Token: 0x04003A1F RID: 14879
		public double serverJourneyTime;

		// Token: 0x04003A20 RID: 14880
		public double tripCalcRate;

		// Token: 0x04003A21 RID: 14881
		public Point storageLocation;

		// Token: 0x04003A22 RID: 14882
		public bool gotEmployee;

		// Token: 0x04003A23 RID: 14883
		public bool buildingActive;

		// Token: 0x04003A24 RID: 14884
		public bool highlighted;

		// Token: 0x04003A25 RID: 14885
		public SpriteWrapper baseSprite;

		// Token: 0x04003A26 RID: 14886
		public SpriteWrapper shadowSprite;

		// Token: 0x04003A27 RID: 14887
		public SpriteWrapper animSprite;

		// Token: 0x04003A28 RID: 14888
		public SpriteWrapper symbolSprite;

		// Token: 0x04003A29 RID: 14889
		public SpriteWrapper productionSprite;

		// Token: 0x04003A2A RID: 14890
		public SpriteWrapper extraAnimSprite1;

		// Token: 0x04003A2B RID: 14891
		public SpriteWrapper extraAnimSprite2;

		// Token: 0x04003A2C RID: 14892
		public VillageMapBuildingStockpileExtension stockpileExtension;

		// Token: 0x04003A2D RID: 14893
		public VillageMapBuildingGranaryExtension granaryExtension;

		// Token: 0x04003A2E RID: 14894
		public VillageMapBuildingInnExtension innExtension;

		// Token: 0x04003A2F RID: 14895
		public bool open;

		// Token: 0x04003A30 RID: 14896
		public bool lastOpenState;

		// Token: 0x04003A31 RID: 14897
		public VillageMapPerson worker;

		// Token: 0x04003A32 RID: 14898
		public VillageMapPerson secondaryWorker;

		// Token: 0x04003A33 RID: 14899
		public int productionState;

		// Token: 0x04003A34 RID: 14900
		public int productionGFXCounter;

		// Token: 0x04003A35 RID: 14901
		public float productionGFXVelocity = 0.5f;

		// Token: 0x04003A36 RID: 14902
		public double productionTime;

		// Token: 0x04003A37 RID: 14903
		public double journeyTime;

		// Token: 0x04003A38 RID: 14904
		public double journeyTime2;

		// Token: 0x04003A39 RID: 14905
		public bool workerNeedsReInitializing;

		// Token: 0x04003A3A RID: 14906
		public bool weaponContinuance;

		// Token: 0x04003A3B RID: 14907
		public int data1;

		// Token: 0x04003A3C RID: 14908
		public int data2;

		// Token: 0x04003A3D RID: 14909
		public int[] capitalResourceLevels;

		// Token: 0x04003A3E RID: 14910
		public int randState = -1;

		// Token: 0x04003A3F RID: 14911
		public static readonly int[] goods48Levels = new int[]
		{
			0,
			0,
			48,
			288,
			1248,
			3648,
			13248,
			37248,
			133248,
			373248,
			1333248,
			3733248,
			13333248,
			133333248
		};

		// Token: 0x04003A40 RID: 14912
		public static readonly int[] goods16Levels = new int[]
		{
			0,
			0,
			16,
			96,
			416,
			1216,
			4416,
			12416,
			44416,
			124416,
			444416,
			1244416,
			4444416,
			12444416,
			124444416
		};

		// Token: 0x04003A41 RID: 14913
		public static readonly int[] goodsDividers = new int[]
		{
			1,
			1,
			5,
			20,
			50,
			200,
			500,
			2000,
			5000,
			20000,
			50000,
			200000,
			500000,
			200000,
			5000000,
			2000000,
			5000000,
			20000000,
			50000000
		};

		// Token: 0x04003A42 RID: 14914
		public static readonly int[] woodPileOrder = new int[]
		{
			6,
			3,
			7,
			10,
			1,
			4,
			8,
			11,
			13,
			0,
			2,
			5,
			9,
			12,
			14,
			15
		};

		// Token: 0x04003A43 RID: 14915
		public static readonly int[] stonePileOrder = new int[]
		{
			0,
			1,
			2,
			4,
			3,
			7,
			11,
			8,
			5,
			6,
			10,
			13,
			15,
			14,
			12,
			9
		};

		// Token: 0x04003A44 RID: 14916
		public static readonly int[] ironPileOrder = new int[]
		{
			15,
			11,
			13,
			14,
			4,
			7,
			8,
			10,
			12,
			0,
			1,
			2,
			3,
			5,
			6,
			9
		};

		// Token: 0x04003A45 RID: 14917
		public static readonly int[] pitchPileOrder = new int[]
		{
			9,
			5,
			8,
			12,
			2,
			4,
			7,
			11,
			14,
			0,
			1,
			3,
			6,
			10,
			13,
			15
		};

		// Token: 0x04003A46 RID: 14918
		public static readonly int[] meatPileOrder = new int[]
		{
			9,
			8,
			1,
			0
		};

		// Token: 0x04003A47 RID: 14919
		public static readonly int[] vegPileOrder = new int[]
		{
			5,
			6,
			7
		};

		// Token: 0x04003A48 RID: 14920
		public static readonly int[] applesPileOrder = new int[]
		{
			2,
			3,
			4
		};

		// Token: 0x04003A49 RID: 14921
		public static readonly int[] fishPileOrder = new int[]
		{
			10,
			11,
			12
		};

		// Token: 0x04003A4A RID: 14922
		public static readonly int[] cheesePileOrder = new int[]
		{
			15,
			16,
			19,
			20
		};

		// Token: 0x04003A4B RID: 14923
		public static readonly int[] breadPileOrder = new int[]
		{
			13,
			14,
			17,
			18
		};

		// Token: 0x04003A4C RID: 14924
		private bool[] pilesUsed = new bool[16];

		// Token: 0x020004E1 RID: 1249
		public class PileOrderSort
		{
			// Token: 0x04003A4D RID: 14925
			public int type;

			// Token: 0x04003A4E RID: 14926
			public double numPiles;

			// Token: 0x04003A4F RID: 14927
			public double origPiles;
		}
	}
}
