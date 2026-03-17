using System;
using System.Collections.Generic;
using System.Drawing;
using CommonTypes;
using DXGraphics;

namespace Kingdoms
{
	// Token: 0x02000128 RID: 296
	public class CastleMapRendering
	{
		// Token: 0x06000AF2 RID: 2802 RVA: 0x000DA508 File Offset: 0x000D8708
		public CastleMapRendering(GraphicsMgr gfx)
		{
			this.gfx = gfx;
			this.backgroundSprite = new SpriteWrapper();
		}

		// Token: 0x06000AF3 RID: 2803 RVA: 0x000DA9E4 File Offset: 0x000D8BE4
		public void drawDyingTroops(CastleMap m_castleMap)
		{
			if (!m_castleMap.castleCombat.Paused)
			{
				List<BattleTroop> dyingTroops = m_castleMap.castleCombat.getDyingTroops();
				foreach (BattleTroop battleTroop in dyingTroops)
				{
					int xPos = (int)battleTroop.xPos;
					int yPos = (int)battleTroop.yPos;
					int textureID = -1;
					int num = -1;
					int num2 = 0;
					int num3 = -1;
					int num4 = 32;
					int troopType = (int)battleTroop.elementType;
					if (battleTroop.dyingOnFire)
					{
						textureID = GFXLibrary.Instance.ManOnFireTexID;
						troopType = 0;
						num2 = (battleTroop.facing + 6 & 7);
						num2 += this.dyingOnFire[Math.Min(battleTroop.animFrame, this.dyingOnFire.Length - 1)] * 8;
						num4 = 39;
					}
					else
					{
						switch (battleTroop.elementType)
						{
						case 70:
							textureID = GFXLibrary.Instance.PeasantAnimTexID;
							num2 = ((!battleTroop.dyingArrowAttack) ? (152 + this.peasantDyingNormal[Math.Min(battleTroop.animFrame, this.peasantDyingNormal.Length - 1)]) : (128 + this.peasantDyingArrow[Math.Min(battleTroop.animFrame, this.peasantDyingArrow.Length - 1)]));
							break;
						case 71:
							textureID = GFXLibrary.Instance.SwordsmanAnimTexID;
							num2 = ((!battleTroop.dyingArrowAttack) ? (352 + this.swordsmanDyingNormal[Math.Min(battleTroop.animFrame, this.swordsmanDyingNormal.Length - 1)]) : (400 + this.swordsmanDyingArrow[Math.Min(battleTroop.animFrame, this.swordsmanDyingArrow.Length - 1)]));
							break;
						case 72:
							textureID = GFXLibrary.Instance.ArcherAnimTexID;
							num2 = ((!battleTroop.dyingArrowAttack) ? (464 + this.archerDyingNormal[Math.Min(battleTroop.animFrame, this.archerDyingNormal.Length - 1)]) : (496 + this.archerDyingArrow[Math.Min(battleTroop.animFrame, this.archerDyingArrow.Length - 1)]));
							break;
						case 73:
							textureID = GFXLibrary.Instance.PikemanAnimTexID;
							num2 = ((!battleTroop.dyingArrowAttack) ? (192 + this.pikemanDyingNormal[Math.Min(battleTroop.animFrame, this.pikemanDyingNormal.Length - 1)]) : (216 + this.pikemanDyingArrow[Math.Min(battleTroop.animFrame, this.pikemanDyingArrow.Length - 1)]));
							break;
						case 75:
							textureID = GFXLibrary.Instance.OilPotAnimTexID;
							break;
						case 77:
							textureID = GFXLibrary.Instance.WolfAnimTexID;
							num2 = ((!battleTroop.dyingArrowAttack) ? (464 + this.wolfDyingNormal[Math.Min(battleTroop.animFrame, this.wolfDyingNormal.Length - 1)]) : (440 + this.wolfDyingArrow[Math.Min(battleTroop.animFrame, this.wolfDyingArrow.Length - 1)]));
							break;
						case 78:
							textureID = GFXLibrary.Instance.KnightAnimTexID;
							num = GFXLibrary.Instance.KnightTopAnimTexID;
							if (battleTroop.dyingArrowAttack)
							{
								num2 = 176 + this.knightDyingArrow[Math.Min(battleTroop.animFrame, this.knightDyingArrow.Length - 1)];
								num3 = 248 + this.knightDyingArrow[Math.Min(battleTroop.animFrame, this.knightDyingArrow.Length - 1)];
							}
							else
							{
								num2 = 152 + this.knightDyingNormal[Math.Min(battleTroop.animFrame, this.knightDyingNormal.Length - 1)];
								num3 = 224 + this.knightDyingNormal[Math.Min(battleTroop.animFrame, this.knightDyingNormal.Length - 1)];
							}
							break;
						case 85:
							textureID = GFXLibrary.Instance.CaptainAnimTexID;
							num2 = 575 + this.captainDyingAnim[Math.Min(battleTroop.animFrame, this.captainDyingAnim.Length - 1)];
							break;
						case 90:
							textureID = GFXLibrary.Instance.PeasantRedAnimTexID;
							num2 = ((!battleTroop.dyingArrowAttack) ? (152 + this.peasantDyingNormal[Math.Min(battleTroop.animFrame, this.peasantDyingNormal.Length - 1)]) : (128 + this.peasantDyingArrow[Math.Min(battleTroop.animFrame, this.peasantDyingArrow.Length - 1)]));
							break;
						case 91:
							textureID = GFXLibrary.Instance.SwordsmanRedAnimTexID;
							num2 = ((!battleTroop.dyingArrowAttack) ? (352 + this.swordsmanDyingNormal[Math.Min(battleTroop.animFrame, this.swordsmanDyingNormal.Length - 1)]) : (400 + this.swordsmanDyingArrow[Math.Min(battleTroop.animFrame, this.swordsmanDyingArrow.Length - 1)]));
							break;
						case 92:
							textureID = GFXLibrary.Instance.ArcherRedAnimTexID;
							num2 = ((!battleTroop.dyingArrowAttack) ? (464 + this.archerDyingNormal[Math.Min(battleTroop.animFrame, this.archerDyingNormal.Length - 1)]) : (496 + this.archerDyingArrow[Math.Min(battleTroop.animFrame, this.archerDyingArrow.Length - 1)]));
							break;
						case 93:
							textureID = GFXLibrary.Instance.PikemanRedAnimTexID;
							num2 = ((!battleTroop.dyingArrowAttack) ? (192 + this.pikemanDyingNormal[Math.Min(battleTroop.animFrame, this.pikemanDyingNormal.Length - 1)]) : (216 + this.pikemanDyingArrow[Math.Min(battleTroop.animFrame, this.pikemanDyingArrow.Length - 1)]));
							break;
						case 94:
							textureID = GFXLibrary.Instance.CatapultAnimTexID;
							break;
						case 100:
						case 101:
						case 102:
						case 103:
						case 104:
						case 105:
						case 106:
						case 107:
							textureID = GFXLibrary.Instance.CaptainAnimRedTexID;
							num2 = 575 + this.captainDyingAnim[Math.Min(battleTroop.animFrame, this.captainDyingAnim.Length - 1)];
							break;
						}
					}
					int num5 = 1;
					if (num >= 0)
					{
						num5 = 2;
					}
					for (int i = 0; i < num5; i++)
					{
						if (i == 1)
						{
							textureID = num;
							num2 = num3;
						}
						SpriteWrapper nextExtraSprite = m_castleMap.getNextExtraSprite(textureID, num2);
						nextExtraSprite.TroopType = troopType;
						Point point = CastleMap.castleUnitSpritePoint[xPos, yPos];
						if (battleTroop.moving)
						{
							Point point2 = CastleMap.castleUnitSpritePoint[battleTroop.otherX, battleTroop.otherY];
							float moveRatio = battleTroop.getMoveRatio();
							point.X = (int)((float)(point.X - point2.X) * moveRatio + (float)point2.X);
							point.Y = (int)((float)(point.Y - point2.Y) * moveRatio + (float)point2.Y);
						}
						int num6 = (int)((!CastleMap.displayCollapsed && (!m_castleMap.battleMode || !CastleMap.AlwaysCollapsedWallsInBattles)) ? m_castleMap.castleLayout.fullHeightMap[xPos, yPos] : m_castleMap.castleLayout.collapsedHeightMap[xPos, yPos]);
						point.Y -= num6;
						nextExtraSprite.Visible = true;
						if (battleTroop.elementType == 78)
						{
							nextExtraSprite.Center = new PointF(75f, 100f);
						}
						else
						{
							nextExtraSprite.Center = new PointF(50f, 66f);
						}
						nextExtraSprite.PosX = (float)point.X;
						nextExtraSprite.PosY = (float)point.Y;
						if (battleTroop.animFrame > num4)
						{
							int num7 = (num4 + 16 - battleTroop.animFrame) * 16;
							if (num7 < 16)
							{
								num7 = 16;
							}
							else if (num7 > 255)
							{
								num7 = 255;
							}
							nextExtraSprite.ColorToUse = Color.FromArgb(num7, global::ARGBColors.White);
						}
						if (CastleMap.castleSpriteGrid[xPos, yPos] != null)
						{
							if (CastleMap.castleSpriteGrid[xPos, yPos].Visible)
							{
								SpriteWrapper spriteWrapper = CastleMap.castleSpriteGrid[xPos, yPos];
								spriteWrapper.TroopType = 0;
								nextExtraSprite.PosX -= spriteWrapper.PosX;
								nextExtraSprite.PosY -= spriteWrapper.PosY;
								spriteWrapper.DrawChildrenWithParent = true;
								spriteWrapper.AddChild(nextExtraSprite);
							}
							else
							{
								long num8 = m_castleMap.castleLayout.elemMap[xPos, yPos];
								if (num8 >= 0L || num8 == -1L)
								{
									CastleElement castleElement = (CastleElement)CastleMap.activeCastleInfrastructureElements[num8];
									if (castleElement != null)
									{
										SpriteWrapper spriteWrapper2 = CastleMap.castleSpriteGrid[(int)castleElement.xPos, (int)castleElement.yPos];
										spriteWrapper2.TroopType = 0;
										if (spriteWrapper2.Visible)
										{
											nextExtraSprite.PosX -= spriteWrapper2.PosX;
											nextExtraSprite.PosY -= spriteWrapper2.PosY;
											spriteWrapper2.DrawChildrenWithParent = true;
											spriteWrapper2.AddChild(nextExtraSprite);
										}
										else
										{
											this.backgroundSprite.AddChild(nextExtraSprite, 2);
										}
									}
									else
									{
										this.backgroundSprite.AddChild(nextExtraSprite, 2);
									}
								}
								else
								{
									this.backgroundSprite.AddChild(nextExtraSprite, 2 + i);
								}
							}
						}
						else
						{
							this.backgroundSprite.AddChild(nextExtraSprite, 2 + i);
						}
					}
				}
			}
		}

		// Token: 0x06000AF4 RID: 2804 RVA: 0x000DB344 File Offset: 0x000D9544
		public void drawArrows(CastleMap m_castleMap)
		{
			List<BattleArrow> arrows = m_castleMap.castleCombat.getArrows();
			foreach (BattleArrow battleArrow in arrows)
			{
				int textureID;
				int num;
				if (battleArrow.bolt)
				{
					textureID = GFXLibrary.Instance.Missile2TexID;
					num = 50;
				}
				else
				{
					textureID = GFXLibrary.Instance.MissileTexID;
					num = 28;
				}
				PointF pointF;
				for (int i = 0; i < battleArrow.trail.Length; i++)
				{
					if (battleArrow.trail[i] != null && battleArrow.trail[i].visible)
					{
						SpriteWrapper nextExtraSprite = m_castleMap.getNextExtraSprite(textureID, battleArrow.trail[i].gfx + battleArrow.trail[i].tilt * 16);
						pointF = (nextExtraSprite.Center = new PointF((float)num, (float)(num + 27 + battleArrow.trail[i].height)));
						nextExtraSprite.PosX = battleArrow.trail[i].pos.X;
						nextExtraSprite.PosY = battleArrow.trail[i].pos.Y;
						nextExtraSprite.ColorToUse = Color.FromArgb(255 - 255 * i / battleArrow.trail.Length, global::ARGBColors.White);
						this.backgroundSprite.AddChild(nextExtraSprite, 2);
					}
				}
				Point point = CastleMap.castleUnitSpritePoint[battleArrow.startX, battleArrow.startY];
				Point point2 = CastleMap.castleUnitSpritePoint[battleArrow.targetX, battleArrow.targetY];
				float num2 = (float)battleArrow.travelledDist / (float)battleArrow.fullDist;
				int num3;
				int num4;
				int num5;
				if (CastleMap.displayCollapsed || (m_castleMap.battleMode && CastleMap.AlwaysCollapsedWallsInBattles))
				{
					num3 = ((!battleArrow.turretArrow) ? ((int)m_castleMap.castleLayout.collapsedHeightMap[battleArrow.startX, battleArrow.startY]) : battleArrow.turrentCollapsedHeight);
					num4 = (int)m_castleMap.castleLayout.collapsedHeightMap[battleArrow.targetX, battleArrow.targetY];
					if (battleArrow.tilt < 0)
					{
						battleArrow.tilt = this.getArrowTiltSpriteID(battleArrow, num3, num4);
					}
					num5 = battleArrow.tilt;
				}
				else
				{
					num3 = ((!battleArrow.turretArrow) ? ((int)m_castleMap.castleLayout.fullHeightMap[battleArrow.startX, battleArrow.startY]) : battleArrow.turretFullHeight);
					num4 = (int)m_castleMap.castleLayout.fullHeightMap[battleArrow.targetX, battleArrow.targetY];
					if (battleArrow.tiltHigh < 0)
					{
						battleArrow.tiltHigh = this.getArrowTiltSpriteID(battleArrow, num3, num4);
					}
					num5 = battleArrow.tiltHigh;
				}
				point2.X = (int)((float)(point2.X - point.X) * num2 + (float)point.X);
				point2.Y = (int)((float)(point2.Y - point.Y) * num2 + (float)point.Y);
				num4 = (int)((float)(num4 - num3) * num2 + (float)num3);
				SpriteWrapper nextExtraSprite2 = m_castleMap.getNextExtraSprite(textureID, battleArrow.gfxDirc + num5 * 16);
				pointF = (nextExtraSprite2.Center = new PointF((float)num, (float)(num + 27 + num4)));
				nextExtraSprite2.PosX = (float)point2.X;
				nextExtraSprite2.PosY = (float)point2.Y;
				this.backgroundSprite.AddChild(nextExtraSprite2, 2);
				if (!m_castleMap.castleCombat.Paused && (!battleArrow.bolt || (m_castleMap.castleCombat.TickValue & 1) == 0) && battleArrow.trail[0] != null)
				{
					for (int j = battleArrow.trail.Length - 1; j > 0; j--)
					{
						battleArrow.trail[j].pos = battleArrow.trail[j - 1].pos;
						battleArrow.trail[j].height = battleArrow.trail[j - 1].height;
						battleArrow.trail[j].visible = battleArrow.trail[j - 1].visible;
						battleArrow.trail[j].tilt = battleArrow.trail[j - 1].tilt;
						battleArrow.trail[j].gfx = battleArrow.trail[j - 1].gfx;
					}
					battleArrow.trail[0].pos = new PointF((float)point2.X, (float)point2.Y);
					battleArrow.trail[0].height = num4;
					battleArrow.trail[0].gfx = battleArrow.gfxDirc;
					battleArrow.trail[0].tilt = num5;
					battleArrow.trail[0].visible = true;
				}
			}
		}

		// Token: 0x06000AF5 RID: 2805 RVA: 0x000DB818 File Offset: 0x000D9A18
		public void drawRocks(CastleMap m_castleMap)
		{
			List<RockMissile> rocks = m_castleMap.castleCombat.getRocks();
			foreach (RockMissile rockMissile in rocks)
			{
				if (rockMissile.firingDelay <= 0)
				{
					PointF pointF;
					for (int i = 0; i < rockMissile.trail.Length; i++)
					{
						if (rockMissile.trail[i].visible)
						{
							SpriteWrapper spriteWrapper = (!rockMissile.bombard) ? m_castleMap.getNextExtraSprite(GFXLibrary.Instance.MissileTexID, 144) : m_castleMap.getNextExtraSprite(GFXLibrary.Instance.MissileTexID, 152);
							pointF = (spriteWrapper.Center = new PointF(28f, (float)(28 + rockMissile.trail[i].height)));
							spriteWrapper.PosX = rockMissile.trail[i].pos.X;
							spriteWrapper.PosY = rockMissile.trail[i].pos.Y;
							spriteWrapper.ColorToUse = Color.FromArgb(255 - 255 * i / rockMissile.trail.Length, global::ARGBColors.White);
							this.backgroundSprite.AddChild(spriteWrapper, 2);
						}
					}
					Point point = CastleMap.castleUnitSpritePoint[rockMissile.startX, rockMissile.startY];
					Point point2 = CastleMap.castleUnitSpritePoint[rockMissile.targX, rockMissile.targY];
					int num = (int)rockMissile.height;
					double num2 = rockMissile.distTravelled / rockMissile.journeyLength;
					point2.X = (int)((double)((float)(point2.X - point.X)) * num2 + (double)((float)point.X));
					point2.Y = (int)((double)((float)(point2.Y - point.Y)) * num2 + (double)((float)point.Y));
					SpriteWrapper spriteWrapper2 = (!rockMissile.bombard) ? m_castleMap.getNextExtraSprite(GFXLibrary.Instance.MissileTexID, 144 + m_castleMap.castleCombat.TickValue / 3 % 8) : m_castleMap.getNextExtraSprite(GFXLibrary.Instance.MissileTexID, 152);
					pointF = (spriteWrapper2.Center = new PointF(28f, (float)(28 + num)));
					spriteWrapper2.PosX = (float)point2.X;
					spriteWrapper2.PosY = (float)point2.Y;
					this.backgroundSprite.AddChild(spriteWrapper2, 2);
					SpriteWrapper spriteWrapper3 = (!rockMissile.bombard) ? m_castleMap.getNextExtraSprite(GFXLibrary.Instance.MissileTexID, 144 + m_castleMap.castleCombat.TickValue / 3 % 8) : m_castleMap.getNextExtraSprite(GFXLibrary.Instance.MissileTexID, 152);
					pointF = (spriteWrapper3.Center = new PointF(28f, 28f));
					spriteWrapper3.PosX = (float)point2.X;
					spriteWrapper3.PosY = (float)point2.Y;
					spriteWrapper3.ColorToUse = Color.FromArgb(64, global::ARGBColors.Black);
					spriteWrapper3.Scale = 0.85f;
					this.backgroundSprite.AddChild(spriteWrapper3);
					if (!m_castleMap.castleCombat.Paused)
					{
						for (int j = rockMissile.trail.Length - 1; j > 0; j--)
						{
							rockMissile.trail[j].pos = rockMissile.trail[j - 1].pos;
							rockMissile.trail[j].height = rockMissile.trail[j - 1].height;
							rockMissile.trail[j].visible = rockMissile.trail[j - 1].visible;
						}
						rockMissile.trail[0].pos = new PointF((float)point2.X, (float)point2.Y);
						rockMissile.trail[0].height = num;
						rockMissile.trail[0].visible = true;
					}
				}
			}
		}

		// Token: 0x06000AF6 RID: 2806 RVA: 0x000DBC20 File Offset: 0x000D9E20
		public void drawCastleLoop(bool collapsed, ref bool completed, ref DateTime completeTime, DateTime curTime, CastleMap m_castleMap)
		{
			this.isCollapsed = collapsed;
			Random random = new Random();
			List<CastleElement> list = new List<CastleElement>();
			foreach (CastleElement item in m_castleMap.elements)
			{
				if (random.Next(2) == 0 || list.Count == 0)
				{
					list.Add(item);
				}
				else
				{
					list.Insert(0, item);
				}
			}
			m_castleMap.numSmelter = 0;
			foreach (CastleElement castleElement in list)
			{
				int xPos = (int)castleElement.xPos;
				int yPos = (int)castleElement.yPos;
				Color color = global::ARGBColors.White;
				if (castleElement.elementType < 69)
				{
					SpriteWrapper spriteWrapper = CastleMap.castleSpriteGrid[xPos, yPos];
					if (spriteWrapper != null && m_castleMap.debugDisplayMode <= 0)
					{
						int num = this.initCastleSprite(spriteWrapper, (int)castleElement.elementType, xPos, yPos, collapsed, castleElement, m_castleMap);
						if (num >= 0)
						{
							CastleMap.activeCastleInfrastructureElements[castleElement.elementID] = castleElement;
							bool flag = false;
							int texID = GFXLibrary.Instance.CastleSpritesTexID;
							byte elementType = castleElement.elementType;
							if (elementType - 51 <= 6)
							{
								texID = GFXLibrary.Instance.FreeCardIconsID;
								flag = true;
							}
							if (!flag || !m_castleMap.attackerSetupForest || yPos >= 33)
							{
								spriteWrapper.reInitializeSpecial(texID, num);
								if (spriteWrapper.Visible)
								{
									this.backgroundSprite.AddChild(spriteWrapper, 2);
								}
								if (m_castleMap.displayType == 0)
								{
									if (castleElement.completionTime > curTime && !m_castleMap.InBuilderMode)
									{
										spriteWrapper.ColorToUse = Color.FromArgb(128, global::ARGBColors.White);
									}
								}
								else if (m_castleMap.displayType != 1 && m_castleMap.displayType == 2 && castleElement.completionTime > curTime)
								{
									spriteWrapper.Visible = false;
								}
								if (castleElement.completionTime > completeTime)
								{
									completeTime = castleElement.completionTime;
									completed = false;
								}
								color = spriteWrapper.ColorToUse;
								int num2 = (int)(castleElement.damage * 10f);
								int num3 = CastleCombat.GetInfrastructureMaxDamage(GameEngine.Instance.LocalWorldData, (int)castleElement.elementType, m_castleMap.getDefenderDefenceResearch(), m_castleMap.getLandType()) * 10;
								int num4 = 192 - num2 * 192 / num3;
								if (num4 < 0)
								{
									num4 = 0;
								}
								if (num2 != 0)
								{
									if (castleElement.elementType != 36 || !m_castleMap.battleMode)
									{
										m_castleMap.castleDamaged = true;
										color = ((castleElement.elementType == 35) ? Color.FromArgb((int)color.A, num4, 255, num4) : Color.FromArgb((int)color.A, 255, num4, num4));
									}
								}
								else if (m_castleMap.InBuilderMode && castleElement.elementID >= -1L)
								{
									color = Color.FromArgb(255, 127, 127, 127);
								}
								spriteWrapper.ColorToUse = color;
								if (!m_castleMap.battleMode && castleElement.elementID == m_castleMap.deletingHighlightElementID && (!m_castleMap.InBuilderMode || castleElement.elementID < -1L))
								{
									spriteWrapper.ColorToUse = Color.FromArgb(127, 32, 32, 32);
								}
								if (m_castleMap.isDeletingThisElement(castleElement.elementID))
								{
									spriteWrapper.ColorToUse = Color.FromArgb(127, 255, 32, 32);
								}
								byte elementType2 = castleElement.elementType;
								switch (elementType2)
								{
								case 1:
								case 2:
								case 3:
								case 4:
								case 5:
								case 6:
								case 7:
								case 8:
								case 9:
								case 10:
								{
									int num5 = (int)castleElement.elementType;
									if (CastleMap.FakeKeep >= 0)
									{
										num5 = CastleMap.FakeKeep;
									}
									if (CastleMap.displayCollapsed || (m_castleMap.battleMode && CastleMap.AlwaysCollapsedWallsInBattles))
									{
										if (m_castleMap.displayType == 1)
										{
											int spriteID = 0;
											if (m_castleMap.campMode == 0)
											{
												spriteID = 413 + num5 - 1;
											}
											else if (m_castleMap.campMode == 1)
											{
												spriteID = 449;
											}
											else if (m_castleMap.campMode == 2)
											{
												spriteID = 444;
											}
											SpriteWrapper nextExtraSprite = m_castleMap.getNextExtraSprite(spriteID);
											PointF center = new PointF(96f, 0f);
											int spriteTag = 1;
											UVSpriteLoader spriteLoader = this.gfx.getSpriteLoader(GFXLibrary.Instance.CastleSpritesTexID, ref spriteTag);
											Rectangle rectangle;
											PointF pointF;
											SizeF sizeF;
											spriteLoader.GetSpriteXYdata(spriteTag, nextExtraSprite.SpriteNo, out rectangle, out pointF, out sizeF);
											center.Y = (float)((int)sizeF.Height);
											nextExtraSprite.Center = center;
											nextExtraSprite.PosY = 40f;
											nextExtraSprite.ColorToUse = Color.FromArgb(160, color);
											spriteWrapper.DrawChildrenWithParent = true;
											spriteWrapper.AddChildAsLast(nextExtraSprite);
										}
									}
									else
									{
										int spriteID2 = 0;
										if (m_castleMap.campMode == 0)
										{
											spriteID2 = 258 + num5 - 1;
										}
										else if (m_castleMap.campMode == 1)
										{
											spriteID2 = 450;
										}
										else if (m_castleMap.campMode == 2)
										{
											spriteID2 = 445;
										}
										SpriteWrapper nextExtraSprite2 = m_castleMap.getNextExtraSprite(spriteID2);
										PointF center2 = new PointF(96f, 0f);
										int spriteTag2 = 1;
										UVSpriteLoader spriteLoader2 = this.gfx.getSpriteLoader(GFXLibrary.Instance.CastleSpritesTexID, ref spriteTag2);
										Rectangle rectangle;
										PointF pointF;
										SizeF sizeF;
										spriteLoader2.GetSpriteXYdata(spriteTag2, nextExtraSprite2.SpriteNo, out rectangle, out pointF, out sizeF);
										center2.Y = (float)((int)sizeF.Height);
										nextExtraSprite2.Center = center2;
										nextExtraSprite2.PosY = 40f;
										nextExtraSprite2.ColorToUse = Color.FromArgb(160, color);
										spriteWrapper.DrawChildrenWithParent = true;
										spriteWrapper.AddChildAsLast(nextExtraSprite2);
									}
									break;
								}
								case 11:
									if (!CastleMap.displayCollapsed && (!m_castleMap.battleMode || !CastleMap.AlwaysCollapsedWallsInBattles) && (m_castleMap.displayType != 0 || castleElement.completionTime <= curTime))
									{
										SpriteWrapper nextExtraSprite3 = m_castleMap.getNextExtraSprite(43);
										nextExtraSprite3.Center = new PointF(32f, 42f);
										nextExtraSprite3.PosY = -121f;
										nextExtraSprite3.ColorToUse = color;
										spriteWrapper.DrawChildrenWithParent = true;
										spriteWrapper.AddChildAsLast(nextExtraSprite3);
									}
									break;
								case 12:
									if (!CastleMap.displayCollapsed && (!m_castleMap.battleMode || !CastleMap.AlwaysCollapsedWallsInBattles) && (m_castleMap.displayType != 0 || castleElement.completionTime <= curTime))
									{
										SpriteWrapper nextExtraSprite4 = m_castleMap.getNextExtraSprite(44);
										nextExtraSprite4.Center = new PointF(48f, 57f);
										nextExtraSprite4.PosY = -120f;
										nextExtraSprite4.ColorToUse = color;
										spriteWrapper.DrawChildrenWithParent = true;
										spriteWrapper.AddChildAsLast(nextExtraSprite4);
									}
									break;
								case 13:
									if (!CastleMap.displayCollapsed && (!m_castleMap.battleMode || !CastleMap.AlwaysCollapsedWallsInBattles) && (m_castleMap.displayType != 0 || castleElement.completionTime <= curTime))
									{
										SpriteWrapper nextExtraSprite5 = m_castleMap.getNextExtraSprite(45);
										nextExtraSprite5.Center = new PointF(64f, 66f);
										nextExtraSprite5.PosY = -120f;
										nextExtraSprite5.ColorToUse = color;
										spriteWrapper.DrawChildrenWithParent = true;
										spriteWrapper.AddChildAsLast(nextExtraSprite5);
									}
									break;
								case 14:
									if (!CastleMap.displayCollapsed && (!m_castleMap.battleMode || !CastleMap.AlwaysCollapsedWallsInBattles) && (m_castleMap.displayType != 0 || castleElement.completionTime <= curTime))
									{
										SpriteWrapper nextExtraSprite6 = m_castleMap.getNextExtraSprite(46);
										nextExtraSprite6.Center = new PointF(80f, 74f);
										nextExtraSprite6.PosY = -124f;
										nextExtraSprite6.ColorToUse = color;
										spriteWrapper.DrawChildrenWithParent = true;
										spriteWrapper.AddChildAsLast(nextExtraSprite6);
									}
									break;
								default:
									switch (elementType2)
									{
									case 31:
										if (castleElement.completionTime <= curTime)
										{
											m_castleMap.numGuardHouses++;
										}
										break;
									case 32:
										if (castleElement.completionTime <= curTime)
										{
											m_castleMap.numSmelter++;
										}
										break;
									case 37:
									case 38:
										if (m_castleMap.battleMode)
										{
											if (CastleMap.displayCollapsed || (m_castleMap.battleMode && CastleMap.AlwaysCollapsedWallsInBattles))
											{
												SpriteWrapper spriteWrapper2 = (castleElement.elementType != 37) ? m_castleMap.getNextExtraSprite(428) : m_castleMap.getNextExtraSprite(432);
												PointF center3 = new PointF(64f, 0f);
												int spriteTag3 = 1;
												UVSpriteLoader spriteLoader3 = this.gfx.getSpriteLoader(GFXLibrary.Instance.CastleSpritesTexID, ref spriteTag3);
												Rectangle rectangle;
												PointF pointF;
												SizeF sizeF;
												spriteLoader3.GetSpriteXYdata(spriteTag3, spriteWrapper2.SpriteNo, out rectangle, out pointF, out sizeF);
												center3.Y = (float)((int)sizeF.Height - 9);
												spriteWrapper2.Center = center3;
												spriteWrapper2.PosY = 24f;
												spriteWrapper2.ColorToUse = Color.FromArgb(160, color);
												spriteWrapper.DrawChildrenWithParent = true;
												spriteWrapper.AddChildAsLast(spriteWrapper2);
											}
											else
											{
												SpriteWrapper spriteWrapper3 = (castleElement.elementType != 37) ? m_castleMap.getNextExtraSprite(427) : m_castleMap.getNextExtraSprite(431);
												PointF center4 = new PointF(64f, 0f);
												int spriteTag4 = 1;
												UVSpriteLoader spriteLoader4 = this.gfx.getSpriteLoader(GFXLibrary.Instance.CastleSpritesTexID, ref spriteTag4);
												Rectangle rectangle;
												PointF pointF;
												SizeF sizeF;
												spriteLoader4.GetSpriteXYdata(spriteTag4, spriteWrapper3.SpriteNo, out rectangle, out pointF, out sizeF);
												center4.Y = (float)((int)sizeF.Height - 9);
												spriteWrapper3.Center = center4;
												spriteWrapper3.PosY = 24f;
												spriteWrapper3.ColorToUse = Color.FromArgb(160, color);
												spriteWrapper.DrawChildrenWithParent = true;
												spriteWrapper.AddChildAsLast(spriteWrapper3);
											}
										}
										break;
									case 39:
									case 40:
										if (m_castleMap.battleMode)
										{
											if (CastleMap.displayCollapsed || (m_castleMap.battleMode && CastleMap.AlwaysCollapsedWallsInBattles))
											{
												SpriteWrapper spriteWrapper4 = (castleElement.elementType != 39) ? m_castleMap.getNextExtraSprite(454) : m_castleMap.getNextExtraSprite(458);
												PointF center5 = new PointF(64f, 0f);
												int spriteTag5 = 1;
												UVSpriteLoader spriteLoader5 = this.gfx.getSpriteLoader(GFXLibrary.Instance.CastleSpritesTexID, ref spriteTag5);
												Rectangle rectangle;
												PointF pointF;
												SizeF sizeF;
												spriteLoader5.GetSpriteXYdata(spriteTag5, spriteWrapper4.SpriteNo, out rectangle, out pointF, out sizeF);
												center5.Y = (float)((int)sizeF.Height - 9);
												spriteWrapper4.Center = center5;
												spriteWrapper4.PosY = 24f;
												spriteWrapper4.ColorToUse = Color.FromArgb(160, color);
												spriteWrapper.DrawChildrenWithParent = true;
												spriteWrapper.AddChildAsLast(spriteWrapper4);
											}
											else
											{
												SpriteWrapper spriteWrapper5 = (castleElement.elementType != 39) ? m_castleMap.getNextExtraSprite(453) : m_castleMap.getNextExtraSprite(457);
												PointF center6 = new PointF(64f, 0f);
												int spriteTag6 = 1;
												UVSpriteLoader spriteLoader6 = this.gfx.getSpriteLoader(GFXLibrary.Instance.CastleSpritesTexID, ref spriteTag6);
												Rectangle rectangle;
												PointF pointF;
												SizeF sizeF;
												spriteLoader6.GetSpriteXYdata(spriteTag6, spriteWrapper5.SpriteNo, out rectangle, out pointF, out sizeF);
												center6.Y = (float)((int)sizeF.Height - 9);
												spriteWrapper5.Center = center6;
												spriteWrapper5.PosY = 24f;
												spriteWrapper5.ColorToUse = Color.FromArgb(160, color);
												spriteWrapper.DrawChildrenWithParent = true;
												spriteWrapper.AddChildAsLast(spriteWrapper5);
											}
										}
										break;
									case 42:
									{
										SpriteWrapper nextExtraSprite7;
										if (m_castleMap.battleMode)
										{
											BattleBuilding battleBuilding = (BattleBuilding)castleElement;
											int num6 = battleBuilding.facing + 6 & 7;
											num6 += battleBuilding.animFrame * 8;
											nextExtraSprite7 = m_castleMap.getNextExtraSprite(GFXLibrary.Instance.BallistaTexID, num6);
										}
										else
										{
											nextExtraSprite7 = m_castleMap.getNextExtraSprite(GFXLibrary.Instance.BallistaTexID, 0);
										}
										if (collapsed)
										{
											nextExtraSprite7.PosY = -16f;
										}
										else
										{
											nextExtraSprite7.PosY = -100f;
										}
										PointF center7 = new PointF(65f, 65f);
										int spriteTag7 = 1;
										UVSpriteLoader spriteLoader7 = this.gfx.getSpriteLoader(GFXLibrary.Instance.BallistaTexID, ref spriteTag7);
										Rectangle rectangle;
										PointF pointF;
										SizeF sizeF;
										spriteLoader7.GetSpriteXYdata(spriteTag7, nextExtraSprite7.SpriteNo, out rectangle, out pointF, out sizeF);
										nextExtraSprite7.Center = center7;
										nextExtraSprite7.ColorToUse = color;
										spriteWrapper.DrawChildrenWithParent = true;
										spriteWrapper.AddChild(nextExtraSprite7);
										break;
									}
									}
									break;
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000AF7 RID: 2807 RVA: 0x000DC8CC File Offset: 0x000DAACC
		public void doFireList(CastleMap m_castleMap)
		{
			List<BattleFire> fireList = m_castleMap.castleCombat.getFireList();
			foreach (BattleFire battleFire in fireList)
			{
				Point point = CastleMap.castleUnitSpritePoint[battleFire.xPos, battleFire.yPos];
				int num = (int)((!CastleMap.displayCollapsed && (!m_castleMap.battleMode || !CastleMap.AlwaysCollapsedWallsInBattles)) ? m_castleMap.castleLayout.fullHeightMap[battleFire.xPos, battleFire.yPos] : m_castleMap.castleLayout.collapsedHeightMap[battleFire.xPos, battleFire.yPos]);
				int spriteNo = 0;
				if (battleFire.state == 0)
				{
					spriteNo = this.fireStart[battleFire.animFrame];
				}
				else if (battleFire.state == 1)
				{
					spriteNo = 7 + this.fireLoop[(battleFire.animFrame + battleFire.randValue) % this.fireLoop.Length];
				}
				else if (battleFire.state == 2)
				{
					spriteNo = 41 + this.fireEnd[battleFire.animFrame];
				}
				SpriteWrapper nextExtraSprite = m_castleMap.getNextExtraSprite(GFXLibrary.Instance.FireTexID, spriteNo);
				PointF pointF = nextExtraSprite.Center = new PointF(50f, (float)(83 + num));
				nextExtraSprite.PosX = (float)point.X;
				nextExtraSprite.PosY = (float)point.Y;
				this.backgroundSprite.AddChild(nextExtraSprite, 2);
			}
		}

		// Token: 0x06000AF8 RID: 2808 RVA: 0x000DCA60 File Offset: 0x000DAC60
		public void drawTroops(CastleMap m_castleMap)
		{
			foreach (CastleElement castleElement in m_castleMap.elements)
			{
				if (castleElement.elementType >= 69)
				{
					int xPos = (int)castleElement.xPos;
					int yPos = (int)castleElement.yPos;
					int num = -1;
					int num2 = -1;
					int troopType = (int)castleElement.elementType;
					bool greenTroop = castleElement.reinforcement || castleElement.vassalReinforcements;
					bool flag = castleElement.elementType < 90;
					switch (castleElement.elementType)
					{
					case 70:
						num = ((castleElement.reinforcement || castleElement.vassalReinforcements) ? GFXLibrary.Instance.PeasantGreenAnimTexID : GFXLibrary.Instance.PeasantAnimTexID);
						break;
					case 71:
						num = ((castleElement.reinforcement || castleElement.vassalReinforcements) ? GFXLibrary.Instance.SwordsmanGreenAnimTexID : GFXLibrary.Instance.SwordsmanAnimTexID);
						break;
					case 72:
						num = ((castleElement.reinforcement || castleElement.vassalReinforcements) ? GFXLibrary.Instance.ArcherGreenAnimTexID : GFXLibrary.Instance.ArcherAnimTexID);
						break;
					case 73:
						num = ((castleElement.reinforcement || castleElement.vassalReinforcements) ? GFXLibrary.Instance.PikemanGreenAnimTexID : GFXLibrary.Instance.PikemanAnimTexID);
						break;
					case 75:
						num = GFXLibrary.Instance.CastleSpritesTexID;
						m_castleMap.numPots++;
						break;
					case 77:
						num = GFXLibrary.Instance.WolfAnimTexID;
						break;
					case 78:
						num = GFXLibrary.Instance.KnightAnimTexID;
						num2 = GFXLibrary.Instance.KnightTopAnimTexID;
						break;
					case 85:
						num = GFXLibrary.Instance.CaptainAnimTexID;
						break;
					case 90:
						num = GFXLibrary.Instance.PeasantRedAnimTexID;
						break;
					case 91:
						num = GFXLibrary.Instance.SwordsmanRedAnimTexID;
						break;
					case 92:
						num = GFXLibrary.Instance.ArcherRedAnimTexID;
						break;
					case 93:
						num = GFXLibrary.Instance.PikemanRedAnimTexID;
						break;
					case 94:
						num = GFXLibrary.Instance.CatapultAnimTexID;
						break;
					case 100:
					case 101:
					case 102:
					case 103:
					case 104:
					case 105:
					case 106:
					case 107:
						num = GFXLibrary.Instance.CaptainAnimRedTexID;
						break;
					}
					if (num >= 0)
					{
						BattleTroop battleTroop = null;
						if (m_castleMap.battleMode)
						{
							battleTroop = (BattleTroop)castleElement;
						}
						PointF center = new PointF(18f, 28f);
						int num3 = 0;
						int num4;
						if (castleElement.elementType == 75)
						{
							num4 = 396;
							if (m_castleMap.battleMode && battleTroop.pouring)
							{
								num = GFXLibrary.Instance.OilPotAnimTexID;
								num4 = (battleTroop.facing + 6 & 7);
								num4 += battleTroop.animFrame * 8;
								center = new PointF(48f, 54f);
							}
						}
						else if (!m_castleMap.battleMode)
						{
							num4 = ((xPos < yPos) ? ((117 - xPos < yPos) ? ((!flag) ? 6 : 2) : (flag ? 4 : 0)) : ((117 - xPos < yPos) ? ((!flag) ? 4 : 0) : ((!flag) ? 2 : 6)));
						}
						else
						{
							num4 = (battleTroop.facing + 6 & 7);
							num3 = num4;
							if (battleTroop.moving)
							{
								num4 = (num3 = num4 + (battleTroop.animFrame + battleTroop.walkAnimOffset) % 16 * 8);
								if (battleTroop.pillageCarry)
								{
									switch (battleTroop.elementType)
									{
									case 90:
										num = GFXLibrary.Instance.PeasantCarryAnimTexID;
										break;
									case 91:
										num = GFXLibrary.Instance.SwordsmanCarryAnimTexID;
										break;
									case 92:
										num = GFXLibrary.Instance.ArcherCarryAnimTexID;
										break;
									case 93:
										num = GFXLibrary.Instance.PikemanCarryAnimTexID;
										break;
									}
									troopType = 0;
								}
							}
							else if (battleTroop.attackingEnemy)
							{
								if (battleTroop.blockedClock > 0)
								{
									byte elementType = battleTroop.elementType;
									switch (elementType)
									{
									case 70:
										num4 += 208 + this.peasantBlocked[Math.Min(battleTroop.animFrame, this.peasantBlocked.Length - 1)] * 8;
										num = GFXLibrary.Instance.Peasant2AnimTexID;
										goto IL_F22;
									case 71:
										goto IL_51D;
									case 72:
										break;
									case 73:
										goto IL_4F4;
									default:
										switch (elementType)
										{
										case 90:
											num4 += 208 + this.peasantBlocked[Math.Min(battleTroop.animFrame, this.peasantBlocked.Length - 1)] * 8;
											num = GFXLibrary.Instance.Peasant2RedAnimTexID;
											goto IL_F22;
										case 91:
											goto IL_51D;
										case 92:
											break;
										case 93:
											goto IL_4F4;
										default:
											goto IL_F22;
										}
										break;
									}
									num4 += 616 + this.archerBlocked[battleTroop.animFrame % this.archerBlocked.Length] * 8;
									goto IL_F22;
									IL_4F4:
									num4 += 448 + this.pikemanBlocked[battleTroop.animFrame % this.pikemanBlocked.Length] * 8;
									goto IL_F22;
									IL_51D:
									num4 += 424 + this.swordsmanBlocked[battleTroop.animFrame % this.swordsmanBlocked.Length] * 8;
								}
								else
								{
									byte elementType2 = battleTroop.elementType;
									switch (elementType2)
									{
									case 70:
										num4 += this.peasantAttack[battleTroop.animFrame % this.peasantAttack.Length] * 8;
										num = GFXLibrary.Instance.Peasant2AnimTexID;
										goto IL_F22;
									case 71:
										goto IL_698;
									case 72:
										break;
									case 73:
										goto IL_66F;
									case 74:
									case 75:
									case 76:
										goto IL_F22;
									case 77:
										num4 += 128 + this.wolfAttackUnit[battleTroop.animFrame % this.wolfAttackUnit.Length] * 8;
										goto IL_F22;
									case 78:
										num4 += 128;
										num3 += 128 + this.knightAttackUnit[battleTroop.animFrame % this.knightAttackUnit.Length] * 8;
										goto IL_F22;
									default:
										switch (elementType2)
										{
										case 85:
										case 100:
										case 101:
										case 102:
										case 103:
										case 104:
										case 105:
										case 106:
										case 107:
											num4 += 287 + this.captainAttackUnit[battleTroop.animFrame % this.captainAttackUnit.Length] * 8;
											goto IL_F22;
										case 86:
										case 87:
										case 88:
										case 89:
										case 94:
										case 95:
										case 96:
										case 97:
										case 98:
										case 99:
											goto IL_F22;
										case 90:
											num4 += this.peasantAttack[battleTroop.animFrame % this.peasantAttack.Length] * 8;
											num = GFXLibrary.Instance.Peasant2RedAnimTexID;
											goto IL_F22;
										case 91:
											goto IL_698;
										case 92:
											break;
										case 93:
											goto IL_66F;
										default:
											goto IL_F22;
										}
										break;
									}
									num4 += 520 + this.archerAttackUnit[battleTroop.animFrame % this.archerAttackUnit.Length] * 8;
									goto IL_F22;
									IL_66F:
									num4 += 264 + this.pikemanAttackJab[battleTroop.animFrame % this.pikemanAttackJab.Length] * 8;
									goto IL_F22;
									IL_698:
									num4 += 128 + this.swordsmanAttackUnit[battleTroop.animFrame % this.swordsmanAttackUnit.Length] * 8;
								}
							}
							else if (battleTroop.attackingMoat)
							{
								byte elementType3 = battleTroop.elementType;
								switch (elementType3)
								{
								case 70:
									num4 += 288 + this.peasantAttackMoat[battleTroop.animFrame % this.peasantAttackMoat.Length] * 8;
									num = GFXLibrary.Instance.Peasant2AnimTexID;
									goto IL_F22;
								case 71:
									goto IL_8D1;
								case 72:
									num4 += this.archerAttackMoat[battleTroop.animFrame % this.archerAttackMoat.Length] * 8;
									num = GFXLibrary.Instance.Archer2AnimTexID;
									goto IL_F22;
								case 73:
									break;
								default:
									switch (elementType3)
									{
									case 85:
									case 100:
									case 101:
									case 102:
									case 103:
									case 104:
									case 105:
									case 106:
									case 107:
										num4 += 287 + this.captainAttackMoat[battleTroop.animFrame % this.captainAttackMoat.Length] * 8;
										goto IL_F22;
									case 86:
									case 87:
									case 88:
									case 89:
									case 94:
									case 95:
									case 96:
									case 97:
									case 98:
									case 99:
										goto IL_F22;
									case 90:
										num4 += 288 + this.peasantAttackMoat[battleTroop.animFrame % this.peasantAttackMoat.Length] * 8;
										num = GFXLibrary.Instance.Peasant2RedAnimTexID;
										goto IL_F22;
									case 91:
										goto IL_8D1;
									case 92:
										num4 += this.archerAttackMoat[battleTroop.animFrame % this.archerAttackMoat.Length] * 8;
										num = GFXLibrary.Instance.Archer2RedAnimTexID;
										goto IL_F22;
									case 93:
										break;
									default:
										goto IL_F22;
									}
									break;
								}
								num4 += 328 + this.pikemanAttackMoat[battleTroop.animFrame % this.pikemanAttackMoat.Length] * 8;
								goto IL_F22;
								IL_8D1:
								num4 += 456 + this.swordsmanAttackMoat[battleTroop.animFrame % this.swordsmanAttackMoat.Length] * 8;
							}
							else if (battleTroop.attackingIntrastructure)
							{
								byte elementType4 = battleTroop.elementType;
								switch (elementType4)
								{
								case 70:
									num4 += this.peasantAttack[battleTroop.animFrame % this.peasantAttack.Length] * 8;
									num = GFXLibrary.Instance.Peasant2AnimTexID;
									goto IL_F22;
								case 71:
									goto IL_A6D;
								case 72:
									break;
								case 73:
									goto IL_A44;
								default:
									switch (elementType4)
									{
									case 85:
									case 100:
									case 101:
									case 102:
									case 103:
									case 104:
									case 105:
									case 106:
									case 107:
										num4 += 287 + this.captainAttackWall[battleTroop.animFrame % this.captainAttackWall.Length] * 8;
										goto IL_F22;
									case 86:
									case 87:
									case 88:
									case 89:
									case 94:
									case 95:
									case 96:
									case 97:
									case 98:
									case 99:
										goto IL_F22;
									case 90:
										num4 += this.peasantAttack[battleTroop.animFrame % this.peasantAttack.Length] * 8;
										num = GFXLibrary.Instance.Peasant2RedAnimTexID;
										goto IL_F22;
									case 91:
										goto IL_A6D;
									case 92:
										break;
									case 93:
										goto IL_A44;
									default:
										goto IL_F22;
									}
									break;
								}
								num4 += 520 + this.archerAttackWall[battleTroop.animFrame % this.archerAttackWall.Length] * 8;
								goto IL_F22;
								IL_A44:
								num4 += 264 + this.pikemanAttackChop[battleTroop.animFrame % this.pikemanAttackChop.Length] * 8;
								goto IL_F22;
								IL_A6D:
								num4 += 128 + this.swordsmanAttackWall[battleTroop.animFrame % this.swordsmanAttackWall.Length] * 8;
							}
							else if (battleTroop.firingRock)
							{
								if (battleTroop.animFrame < this.catapultAnim.Length)
								{
									num4 += this.catapultAnim[battleTroop.animFrame % this.catapultAnim.Length] * 8;
								}
							}
							else if (battleTroop.shootingArrow)
							{
								if (CastleMap.displayCollapsed || (m_castleMap.battleMode && CastleMap.AlwaysCollapsedWallsInBattles))
								{
									num4 = ((battleTroop.animFrame >= this.archerAttackFiringStraight.Length) ? (num4 + 640) : (num4 + (136 + this.archerAttackFiringStraight[battleTroop.animFrame % this.archerAttackFiringStraight.Length] * 8)));
								}
								else
								{
									if (battleTroop.arrowTilt < 0)
									{
										int startHeight = (int)m_castleMap.castleLayout.fullHeightMap[battleTroop.arrow.startX, battleTroop.arrow.startY];
										int targetHeight = (int)m_castleMap.castleLayout.fullHeightMap[battleTroop.arrow.targetX, battleTroop.arrow.targetY];
										battleTroop.arrowTilt = this.getArrowTiltSpriteID(battleTroop.arrow, startHeight, targetHeight);
									}
									num4 = ((battleTroop.arrowTilt < 3) ? ((battleTroop.animFrame >= this.archerAttackFiringDown.Length) ? (num4 + 640) : (num4 + (136 + this.archerAttackFiringDown[battleTroop.animFrame % this.archerAttackFiringDown.Length] * 8))) : ((battleTroop.arrowTilt < 6) ? ((battleTroop.animFrame >= this.archerAttackFiringStraight.Length) ? (num4 + 640) : (num4 + (136 + this.archerAttackFiringStraight[battleTroop.animFrame % this.archerAttackFiringStraight.Length] * 8))) : ((battleTroop.animFrame >= this.archerAttackFiringUp.Length) ? (num4 + 640) : (num4 + (136 + this.archerAttackFiringUp[battleTroop.animFrame % this.archerAttackFiringUp.Length] * 8)))));
								}
							}
							else if (battleTroop.pillageCarry)
							{
								switch (battleTroop.elementType)
								{
								case 90:
									num = GFXLibrary.Instance.PeasantCarryAnimTexID;
									break;
								case 91:
									num = GFXLibrary.Instance.SwordsmanCarryAnimTexID;
									break;
								case 92:
									num = GFXLibrary.Instance.ArcherCarryAnimTexID;
									break;
								case 93:
									num = GFXLibrary.Instance.PikemanCarryAnimTexID;
									break;
								}
							}
							else
							{
								byte elementType5 = battleTroop.elementType;
								switch (elementType5)
								{
								case 70:
									num4 += 128 + this.peasantIdle[battleTroop.animFrame % this.peasantIdle.Length] * 8;
									num = GFXLibrary.Instance.Peasant2AnimTexID;
									goto IL_F22;
								case 71:
									goto IL_EB8;
								case 72:
									break;
								case 73:
									num4 = ((battleTroop.blockClock < GameEngine.Instance.LocalWorldData.Castle_Pikeman_BlockRechargeTime) ? (num4 + (128 + this.pikemanIdle[battleTroop.animFrame % this.pikemanIdle.Length] * 8)) : (num4 + 264));
									goto IL_F22;
								case 74:
								case 75:
								case 76:
									goto IL_F22;
								case 77:
									num4 += 424;
									goto IL_F22;
								case 78:
									num4 += 128 + this.knightHorseIdle[battleTroop.animFrame % this.knightHorseIdle.Length] * 8;
									num3 = num3;
									goto IL_F22;
								default:
									switch (elementType5)
									{
									case 85:
									case 100:
									case 101:
									case 102:
									case 103:
									case 104:
									case 105:
									case 106:
									case 107:
										num4 += 128 + (this.captainIdle[battleTroop.animFrame / 2 % this.captainIdle.Length] - 1) * 8;
										goto IL_F22;
									case 86:
									case 87:
									case 88:
									case 89:
									case 94:
									case 95:
									case 96:
									case 97:
									case 98:
									case 99:
										goto IL_F22;
									case 90:
										num4 += 128 + this.peasantIdle[battleTroop.animFrame % this.peasantIdle.Length] * 8;
										num = GFXLibrary.Instance.Peasant2RedAnimTexID;
										goto IL_F22;
									case 91:
										goto IL_EB8;
									case 92:
										break;
									case 93:
										num4 += 128 + this.pikemanIdle[battleTroop.animFrame % this.pikemanIdle.Length] * 8;
										goto IL_F22;
									default:
										goto IL_F22;
									}
									break;
								}
								num4 += 640;
								goto IL_F22;
								IL_EB8:
								num4 += 448;
							}
						}
						IL_F22:
						SpriteWrapper spriteWrapper = CastleMap.castleDefenderSpriteGrid[xPos, yPos];
						if (spriteWrapper == null)
						{
							spriteWrapper = CastleMap.castleAttackerSpriteGrid[xPos, yPos];
						}
						spriteWrapper.TroopType = troopType;
						spriteWrapper.GreenTroop = greenTroop;
						int num5 = 1;
						if (num2 >= 0)
						{
							num5 = 2;
						}
						SpriteWrapper spriteWrapper2 = null;
						for (int i = 0; i < num5; i++)
						{
							if (num2 >= 0 && i == 1)
							{
								spriteWrapper = m_castleMap.getNextExtraSprite(num2, num3);
								spriteWrapper.TroopType = 0;
								num = num2;
								num4 = num3;
							}
							else
							{
								spriteWrapper.Initialize(this.gfx, num, num4);
							}
							Point pos = CastleMap.castleUnitSpritePoint[xPos, yPos];
							if (m_castleMap.battleMode && battleTroop.moving)
							{
								Point point = CastleMap.castleUnitSpritePoint[battleTroop.otherX, battleTroop.otherY];
								float moveRatio = battleTroop.getMoveRatio();
								pos.X = (int)((float)(pos.X - point.X) * moveRatio + (float)point.X);
								pos.Y = (int)((float)(pos.Y - point.Y) * moveRatio + (float)point.Y);
							}
							int num6 = (int)((!CastleMap.displayCollapsed && (!m_castleMap.battleMode || !CastleMap.AlwaysCollapsedWallsInBattles)) ? m_castleMap.castleLayout.fullHeightMap[xPos, yPos] : m_castleMap.castleLayout.collapsedHeightMap[xPos, yPos]);
							pos.Y -= num6;
							spriteWrapper.PosX = (float)pos.X;
							spriteWrapper.PosY = (float)pos.Y;
							spriteWrapper.Visible = true;
							if (castleElement.elementType == 75)
							{
								spriteWrapper.Center = center;
							}
							else if (castleElement.elementType == 94)
							{
								spriteWrapper.Center = new PointF(93f, 100f);
							}
							else if (castleElement.elementType == 78)
							{
								spriteWrapper.Center = new PointF(75f, 100f);
							}
							else if ((castleElement.elementType >= 85 && castleElement.elementType <= 89) || (castleElement.elementType >= 100 && castleElement.elementType <= 109))
							{
								spriteWrapper.Center = new PointF(65f, 82f);
							}
							else
							{
								spriteWrapper.Center = new PointF(50f, 66f);
							}
							CastleMap.TroopClickArea nextClickArea = m_castleMap.getNextClickArea();
							nextClickArea.addUnit(pos, castleElement.elementID);
							if (castleElement.elementID == m_castleMap.troopMovingElemID && m_castleMap.troopMovingMode)
							{
								spriteWrapper.ColorToUse = Color.FromArgb(128, global::ARGBColors.White);
							}
							else if (castleElement.elementID == m_castleMap.selectedCatapult && m_castleMap.selectedCatapult != -1L)
							{
								spriteWrapper.ColorToUse = Color.FromArgb(192, global::ARGBColors.Red);
							}
							else if (castleElement.elementID == m_castleMap.troopSelected && m_castleMap.troopSelected != -1L)
							{
								spriteWrapper.ColorToUse = Color.FromArgb(192, global::ARGBColors.Red);
							}
							else if (m_castleMap.m_lassoLeftHeldDown)
							{
								if (!m_castleMap.m_lassoElements.Contains(castleElement.elementID))
								{
									spriteWrapper.ColorToUse = Color.FromArgb(160, global::ARGBColors.White);
								}
								else
								{
									spriteWrapper.ColorToUse = Color.FromArgb(255, this.pulseValue, this.pulseValue, this.pulseValue);
								}
							}
							else if (m_castleMap.m_lassoMade)
							{
								if (!m_castleMap.m_lassoElements.Contains(castleElement.elementID))
								{
									spriteWrapper.ColorToUse = Color.FromArgb(128, global::ARGBColors.White);
								}
								else
								{
									spriteWrapper.ColorToUse = Color.FromArgb(255, this.pulseValue, this.pulseValue, this.pulseValue);
								}
							}
							else
							{
								spriteWrapper.ColorToUse = global::ARGBColors.White;
							}
							if (!m_castleMap.battleMode && castleElement.elementID == m_castleMap.deletingHighlightElementID)
							{
								spriteWrapper.ColorToUse = Color.FromArgb(127, 32, 32, 32);
							}
							if (CastleMap.castleSpriteGrid[xPos, yPos] != null)
							{
								if (CastleMap.castleSpriteGrid[xPos, yPos].Visible)
								{
									SpriteWrapper spriteWrapper3 = CastleMap.castleSpriteGrid[xPos, yPos];
									spriteWrapper.PosX -= spriteWrapper3.PosX;
									spriteWrapper.PosY -= spriteWrapper3.PosY;
									spriteWrapper3.DrawChildrenWithParent = true;
									spriteWrapper3.AddChild(spriteWrapper);
								}
								else
								{
									long num7 = m_castleMap.castleLayout.elemMap[xPos, yPos];
									if (num7 != -2L || num7 == -1L)
									{
										CastleElement castleElement2 = (CastleElement)CastleMap.activeCastleInfrastructureElements[num7];
										if (castleElement2 != null)
										{
											SpriteWrapper spriteWrapper4 = CastleMap.castleSpriteGrid[(int)castleElement2.xPos, (int)castleElement2.yPos];
											if (spriteWrapper4.Visible)
											{
												spriteWrapper.PosX -= spriteWrapper4.PosX;
												spriteWrapper.PosY -= spriteWrapper4.PosY;
												spriteWrapper4.DrawChildrenWithParent = true;
												spriteWrapper4.AddChild(spriteWrapper);
											}
											else
											{
												this.backgroundSprite.AddChild(spriteWrapper, 2);
											}
										}
										else
										{
											this.backgroundSprite.AddChild(spriteWrapper, 2);
										}
									}
									else if (spriteWrapper2 != null)
									{
										spriteWrapper.PosX -= spriteWrapper2.PosX;
										spriteWrapper.PosY -= spriteWrapper2.PosY;
										spriteWrapper2.DrawChildrenWithParent = true;
										spriteWrapper2.AddChild(spriteWrapper, 2);
									}
									else
									{
										this.backgroundSprite.AddChild(spriteWrapper, 2 + i);
									}
								}
							}
							else if (spriteWrapper2 != null)
							{
								spriteWrapper.PosX -= spriteWrapper2.PosX;
								spriteWrapper.PosY -= spriteWrapper2.PosY;
								spriteWrapper2.DrawChildrenWithParent = true;
								spriteWrapper2.AddChild(spriteWrapper, 2);
							}
							else
							{
								this.backgroundSprite.AddChild(spriteWrapper, 2 + i);
							}
							if (m_castleMap.battleMode && m_castleMap.battleModeMousePos.X != 1000 && battleTroop.elementType != 75)
							{
								int num8 = (m_castleMap.battleModeMousePos.X - pos.X) * (m_castleMap.battleModeMousePos.X - pos.X) + (m_castleMap.battleModeMousePos.Y - (pos.Y - 15)) * (m_castleMap.battleModeMousePos.Y - (pos.Y - 15));
								if (num8 < 22500)
								{
									int num9 = (int)battleTroop.damage;
									int unitMaxDamage = m_castleMap.castleCombat.getUnitMaxDamage((int)battleTroop.elementType);
									int unitMaxDamageNumLevels = m_castleMap.castleCombat.getUnitMaxDamageNumLevels((int)battleTroop.elementType);
									int num10 = num9 * unitMaxDamageNumLevels / unitMaxDamage;
									if (num10 >= unitMaxDamageNumLevels)
									{
										num10 = unitMaxDamageNumLevels - 1;
									}
									int num11;
									switch (unitMaxDamageNumLevels)
									{
									case 12:
										num11 = 11;
										break;
									case 13:
										num11 = 23;
										break;
									case 14:
										num11 = 36;
										break;
									case 15:
										num11 = 50;
										break;
									case 16:
										num11 = 65;
										break;
									case 17:
										num11 = 81;
										break;
									case 18:
										num11 = 98;
										break;
									case 19:
										num11 = 116;
										break;
									case 20:
										num11 = 135;
										break;
									case 21:
										num11 = 155;
										break;
									default:
										num11 = 0;
										break;
									}
									SpriteWrapper nextExtraSprite = m_castleMap.getNextExtraSprite(GFXLibrary.Instance.HpsBarsTexID, num11 + (unitMaxDamageNumLevels - 1) - num10);
									nextExtraSprite.Center = new PointF(11f, 2f);
									nextExtraSprite.PosX = 0f;
									nextExtraSprite.PosY = -40f;
									spriteWrapper.DrawChildrenWithParent = true;
									spriteWrapper.AddChild(nextExtraSprite);
								}
							}
							if (m_castleMap.battleMode && battleTroop.captainsBonusDamageClock > 0)
							{
								int num12 = 900 - battleTroop.captainsBonusDamageClock;
								if (num12 >= 22)
								{
									if (num12 > 878)
									{
										num12 = 900 - num12;
									}
									else
									{
										num12 = (num12 - 22) % 44;
										if (num12 >= 23)
										{
											num12 = 45 - num12;
										}
										num12 += 22;
									}
								}
								if (num12 < 0)
								{
									num12 = 0;
								}
								else if (num12 >= 45)
								{
									num12 = 44;
								}
								num12 += 45;
								SpriteWrapper nextExtraSprite2 = m_castleMap.getNextExtraSprite(GFXLibrary.Instance.ArmyAnimsTexID, num12);
								nextExtraSprite2.Center = new PointF(30f, 32f);
								nextExtraSprite2.PosX = 0f;
								nextExtraSprite2.PosY = -40f;
								spriteWrapper.DrawChildrenWithParent = true;
								spriteWrapper.AddChild(nextExtraSprite2);
							}
							if (m_castleMap.battleMode && battleTroop.captainsHealAnimClock > 0)
							{
								int num13 = (450 - battleTroop.captainsHealAnimClock) % 45;
								if (num13 < 0)
								{
									num13 = 0;
								}
								else if (num13 >= 45)
								{
									num13 = 44;
								}
								SpriteWrapper nextExtraSprite3 = m_castleMap.getNextExtraSprite(GFXLibrary.Instance.ArmyAnimsTexID, num13);
								nextExtraSprite3.Center = new PointF(35f, 32f);
								nextExtraSprite3.PosX = 0f;
								nextExtraSprite3.PosY = -50f;
								spriteWrapper.DrawChildrenWithParent = true;
								spriteWrapper.AddChild(nextExtraSprite3);
							}
							spriteWrapper2 = spriteWrapper;
						}
					}
					byte elementType6 = castleElement.elementType;
					switch (elementType6)
					{
					case 70:
						if (!castleElement.reinforcement && !castleElement.vassalReinforcements)
						{
							m_castleMap.numPlacedDefenderPeasants++;
						}
						else if (castleElement.reinforcement)
						{
							m_castleMap.numPlacedReinforceDefenderPeasants++;
						}
						else
						{
							m_castleMap.numPlacedVassalReinforceDefenderPeasants++;
						}
						break;
					case 71:
						if (!castleElement.reinforcement && !castleElement.vassalReinforcements)
						{
							m_castleMap.numPlacedDefenderSwordsmen++;
						}
						else if (castleElement.reinforcement)
						{
							m_castleMap.numPlacedReinforceDefenderSwordsmen++;
						}
						else
						{
							m_castleMap.numPlacedVassalReinforceDefenderSwordsmen++;
						}
						break;
					case 72:
						if (!castleElement.reinforcement && !castleElement.vassalReinforcements)
						{
							m_castleMap.numPlacedDefenderArchers++;
						}
						else if (castleElement.reinforcement)
						{
							m_castleMap.numPlacedReinforceDefenderArchers++;
						}
						else
						{
							m_castleMap.numPlacedVassalReinforceDefenderArchers++;
						}
						break;
					case 73:
						if (!castleElement.reinforcement && !castleElement.vassalReinforcements)
						{
							m_castleMap.numPlacedDefenderPikemen++;
						}
						else if (castleElement.reinforcement)
						{
							m_castleMap.numPlacedReinforceDefenderPikemen++;
						}
						else
						{
							m_castleMap.numPlacedVassalReinforceDefenderPikemen++;
						}
						break;
					case 74:
					case 75:
					case 76:
						break;
					case 77:
						m_castleMap.numPlacedReinforceDefenderSwordsmen++;
						break;
					default:
						switch (elementType6)
						{
						case 85:
							m_castleMap.numPlacedDefenderCaptains++;
							break;
						case 90:
							m_castleMap.attackNumPeasants++;
							break;
						case 91:
							m_castleMap.attackNumSwordsmen++;
							break;
						case 92:
							m_castleMap.attackNumArchers++;
							break;
						case 93:
							m_castleMap.attackNumPikemen++;
							break;
						case 94:
							m_castleMap.attackNumCatapults++;
							break;
						case 100:
						case 101:
						case 102:
						case 103:
						case 104:
						case 105:
						case 106:
						case 107:
							m_castleMap.attackNumCaptains++;
							break;
						}
						break;
					}
				}
			}
		}

		// Token: 0x06000AF9 RID: 2809 RVA: 0x000DE4EC File Offset: 0x000DC6EC
		public int initCastleSprite(SpriteWrapper sprite, int elementType, int gx, int gy, bool collapsed, CastleElement element, CastleMap m_castleMap)
		{
			int textureID = GFXLibrary.Instance.CastleSpritesTexID;
			sprite.Visible = true;
			sprite.ColorToUse = global::ARGBColors.White;
			PointF center = new PointF(16f, 0f);
			float num = 8f;
			int num2 = 0;
			switch (elementType)
			{
			case 1:
			case 2:
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
				center.X = 96f;
				num = 40f;
				if (collapsed)
				{
					if (m_castleMap.campMode == 0)
					{
						num2 = 224;
						if (m_castleMap.displayType == 1)
						{
							num2 = 234;
						}
					}
					else if (m_castleMap.campMode == 1)
					{
						num2 = 446;
						if (m_castleMap.displayType == 1)
						{
							num2 = 447;
						}
					}
					else if (m_castleMap.campMode == 2)
					{
						num2 = 441;
						if (m_castleMap.displayType == 1)
						{
							num2 = 442;
						}
					}
				}
				else if (m_castleMap.campMode == 0)
				{
					num2 = 244;
				}
				else if (m_castleMap.campMode == 1)
				{
					num2 = 448;
				}
				else if (m_castleMap.campMode == 2)
				{
					num2 = 443;
				}
				if (m_castleMap.campMode == 0)
				{
					num2 = ((CastleMap.FakeKeep < 0) ? (num2 + (elementType - 1)) : (num2 + (CastleMap.FakeKeep - 1)));
				}
				break;
			case 11:
				center.X = 32f;
				num2 = ((!collapsed) ? 218 : 214);
				break;
			case 12:
				center.X = 48f;
				num = 24f;
				num2 = ((!collapsed) ? 219 : 215);
				break;
			case 13:
				center.X = 64f;
				num = 24f;
				num2 = ((!collapsed) ? 220 : 216);
				break;
			case 14:
				center.X = 80f;
				num = 40f;
				num2 = ((!collapsed) ? 221 : 217);
				break;
			case 21:
				center.X = 32f;
				num2 = ((!collapsed) ? 223 : 222);
				break;
			case 31:
			{
				center.X = 101f;
				int defenderDefenceResearch = m_castleMap.getDefenderDefenceResearch();
				if (defenderDefenceResearch < 4)
				{
					num2 = ((!collapsed) ? 433 : 434);
					num = 95f;
				}
				else if (defenderDefenceResearch < 8)
				{
					num2 = ((!collapsed) ? 435 : 436);
					num = 74f;
				}
				else if (defenderDefenceResearch < 10)
				{
					num2 = ((!collapsed) ? 437 : 438);
					num = 74f;
				}
				else
				{
					num2 = ((!collapsed) ? 439 : 440);
					num = 74f;
				}
				break;
			}
			case 32:
				center.X = 64f;
				num = 24f;
				num2 = ((!collapsed) ? 210 : 211);
				break;
			case 33:
				num2 = (gx + gy) % 8;
				num2 = ((!collapsed) ? (num2 + 154) : (num2 + 162));
				break;
			case 34:
				if (collapsed)
				{
					num2 = (gx + gy) % 8 + 35;
				}
				else
				{
					num2 = ((!m_castleMap.isInNorthSouthWall(gx, gy)) ? ((!m_castleMap.isInEastWestWall(gx, gy)) ? ((!m_castleMap.isSouthEndWall(gx, gy)) ? ((!m_castleMap.isEastEndWall(gx, gy)) ? 34 : 32) : 33) : (((gx & 15) != 15) ? (31 - (gx & 15)) : 0)) : (16 - (gy & 15)));
				}
				break;
			case 35:
				if (gx < 33 || gy < 33 || gx >= 85 || gy >= 85)
				{
					num2 = 276;
				}
				else
				{
					num2 = 276;
					int num3 = 0;
					while (this.moatSurroundLogic[num3 * 9] > 0)
					{
						bool flag = false;
						for (int i = 0; i < 8; i++)
						{
							int num4 = (int)m_castleMap.castleLayout.map[gx + this.moatSurroundTests[i * 2], gy + this.moatSurroundTests[i * 2 + 1]];
							int num5 = this.moatSurroundLogic[num3 * 9 + 1 + i];
							if (num5 != 2)
							{
								if (num4 == 35)
								{
									if (num5 == 0)
									{
										flag = true;
										break;
									}
								}
								else if (num5 == 1)
								{
									flag = true;
									break;
								}
							}
						}
						if (!flag)
						{
							num2 = this.moatSurroundLogic[num3 * 9];
							int num6 = gx ^ gy ^ gx / 10 ^ gy / 20;
							switch (num2)
							{
							case 272:
								if (num6 % 3 != 2)
								{
									num2 = 397 + num6 % 3;
									goto IL_905;
								}
								goto IL_905;
							case 273:
								if (num6 % 3 != 2)
								{
									num2 = 399 + num6 % 3;
									goto IL_905;
								}
								goto IL_905;
							case 274:
								if (num6 % 3 != 2)
								{
									num2 = 401 + num6 % 3;
									goto IL_905;
								}
								goto IL_905;
							case 275:
								if (num6 % 3 != 2)
								{
									num2 = 403 + num6 % 3;
									goto IL_905;
								}
								goto IL_905;
							case 276:
								if (num6 % 9 != 8)
								{
									num2 = 405 + num6 % 9;
									goto IL_905;
								}
								goto IL_905;
							default:
								goto IL_905;
							}
						}
						else
						{
							num3++;
						}
					}
				}
				break;
			case 36:
			{
				int num7 = (gx ^ gy) % 8;
				num2 = 388 + num7;
				if (element != null && m_castleMap.battleMode)
				{
					BattleBuilding battleBuilding = (BattleBuilding)element;
					if (!battleBuilding.visible)
					{
						sprite.Visible = false;
						return -1;
					}
					if (battleBuilding.openPit)
					{
						num2 -= 8;
					}
					if (battleBuilding.animating)
					{
						int num8 = battleBuilding.animFrame;
						if (m_castleMap.castleCombat.TickValue < battleBuilding.endingTick)
						{
							if (num8 > 3)
							{
								num8 = 3;
							}
							SpriteWrapper nextExtraSprite = m_castleMap.getNextExtraSprite(GFXLibrary.Instance.AnimKillingPitsTexID, num8 + num7 * 4);
							nextExtraSprite.Center = new PointF(50f, 50f);
							nextExtraSprite.PosX = 0f;
							nextExtraSprite.PosY = 0f;
							sprite.AddChild(nextExtraSprite);
						}
					}
				}
				break;
			}
			case 37:
				center.X = 64f;
				num = 33f;
				num2 = ((!collapsed) ? 429 : 430);
				break;
			case 38:
				center.X = 64f;
				num = 33f;
				num2 = ((!collapsed) ? 425 : 426);
				break;
			case 39:
				center.X = 64f;
				num = 33f;
				num2 = ((!collapsed) ? 455 : 456);
				break;
			case 40:
				center.X = 64f;
				num = 33f;
				num2 = ((!collapsed) ? 451 : 452);
				break;
			case 41:
				center.X = 80f;
				num = 16f;
				num2 = ((!collapsed) ? 460 : 463);
				break;
			case 42:
				center.X = 80f;
				num = 32f;
				num2 = ((!collapsed) ? 459 : 462);
				break;
			case 43:
				center.X = 91f;
				num = 16f;
				num2 = ((!collapsed) ? 461 : 464);
				if (element != null && m_castleMap.battleMode)
				{
					BattleBuilding battleBuilding2 = (BattleBuilding)element;
					if (!battleBuilding2.visible)
					{
						sprite.Visible = false;
						return -1;
					}
				}
				else if (m_castleMap.attackerSetupMode)
				{
					sprite.Visible = false;
					return -1;
				}
				break;
			case 44:
				center.X = 80f;
				num = 32f;
				num2 = ((!collapsed) ? 468 : 469);
				break;
			case 45:
				num2 = 470;
				center.X = 24f;
				num = 8f;
				break;
			case 46:
				num2 = 471;
				center.X = 24f;
				num = 8f;
				break;
			case 51:
				textureID = GFXLibrary.Instance.FreeCardIconsID;
				num2 = ((!collapsed) ? 7 : 11);
				break;
			case 52:
				textureID = GFXLibrary.Instance.FreeCardIconsID;
				num2 = ((!collapsed) ? 8 : 12);
				break;
			case 53:
				textureID = GFXLibrary.Instance.FreeCardIconsID;
				num2 = ((!collapsed) ? 9 : 13);
				break;
			case 54:
				textureID = GFXLibrary.Instance.FreeCardIconsID;
				num2 = ((!collapsed) ? 10 : 14);
				break;
			case 55:
				textureID = GFXLibrary.Instance.FreeCardIconsID;
				center.X = 32f;
				num2 = ((!collapsed) ? 15 : 17);
				break;
			case 56:
				textureID = GFXLibrary.Instance.FreeCardIconsID;
				center.X = 32f;
				num2 = ((!collapsed) ? 16 : 18);
				break;
			case 57:
				textureID = GFXLibrary.Instance.FreeCardIconsID;
				center.X = 48f;
				num = 24f;
				num2 = ((!collapsed) ? 19 : 20);
				break;
			}
			IL_905:
			int spriteTag = 1;
			UVSpriteLoader spriteLoader = this.gfx.getSpriteLoader(textureID, ref spriteTag);
			Rectangle rectangle;
			PointF pointF;
			SizeF sizeF;
			spriteLoader.GetSpriteXYdata(spriteTag, num2, out rectangle, out pointF, out sizeF);
			center.Y = (float)((int)sizeF.Height) - num;
			sprite.Center = center;
			return num2;
		}

		// Token: 0x06000AFA RID: 2810 RVA: 0x000DEE3C File Offset: 0x000DD03C
		private int getArrowTiltSpriteID(BattleArrow arrow, int startHeight, int targetHeight)
		{
			double x = (double)(arrow.fullDist / 8 * 24);
			double y = (double)(targetHeight - startHeight);
			double num = Math.Atan2(y, x) * 57.2957795;
			if (num < -50.0)
			{
				return 0;
			}
			if (num < -35.0)
			{
				return 1;
			}
			if (num < -17.0)
			{
				return 2;
			}
			if (num < -5.0)
			{
				return 3;
			}
			if (num < 5.0)
			{
				return 4;
			}
			if (num < 20.0)
			{
				return 5;
			}
			if (num < 35.0)
			{
				return 6;
			}
			if (num < 50.0)
			{
				return 7;
			}
			return 8;
		}

		// Token: 0x06000AFB RID: 2811 RVA: 0x0000E33C File Offset: 0x0000C53C
		public void initRockchips(CastleMap m_castleMap)
		{
			m_castleMap.castleCombat.setRockCallback(new CastleCombat.RockChipCallback(this.rockChipCallback));
		}

		// Token: 0x06000AFC RID: 2812 RVA: 0x000DEEEC File Offset: 0x000DD0EC
		public void rockChipCallback(RockMissile rock)
		{
			int num = this.chipRand.Next(12, 18);
			for (int i = 0; i < num; i++)
			{
				this.addRockChips(rock.targX, rock.targY, rock.bombard);
			}
			Point point = CastleMap.castleUnitSpritePoint[rock.targX, rock.targY];
			this.addRockSmoke((float)point.X, (float)point.Y, rock.bombard);
		}

		// Token: 0x06000AFD RID: 2813 RVA: 0x000DEF60 File Offset: 0x000DD160
		private void addRockChips(int posX, int posY, bool black)
		{
			CastleMapRendering.RockChip rockChip = new CastleMapRendering.RockChip();
			Point point = CastleMap.castleUnitSpritePoint[posX, posY];
			rockChip.xPos = (float)point.X;
			rockChip.yPos = (float)point.Y;
			rockChip.height = 1f;
			rockChip.vVelocity = (float)((100 + this.chipRand.Next(25)) / 5);
			rockChip.gravityValue = 2.55112f;
			rockChip.dx = (float)this.chipRand.Next(-50, 50);
			rockChip.dy = (float)this.chipRand.Next(-50, 50);
			float num = (float)Math.Sqrt((double)(rockChip.dx * rockChip.dx + rockChip.dy * rockChip.dy)) / 1.3f;
			rockChip.dx /= num;
			rockChip.dy /= num;
			rockChip.image = this.chipRand.Next(8);
			rockChip.black = black;
			this.rockChips.Add(rockChip);
		}

		// Token: 0x06000AFE RID: 2814 RVA: 0x000DF064 File Offset: 0x000DD264
		public void updateRocks()
		{
			List<CastleMapRendering.RockChip> list = new List<CastleMapRendering.RockChip>();
			foreach (CastleMapRendering.RockChip rockChip in this.rockChips)
			{
				rockChip.height += rockChip.vVelocity;
				rockChip.vVelocity -= rockChip.gravityValue;
				rockChip.xPos += rockChip.dx;
				rockChip.yPos += rockChip.dy;
				if (rockChip.height <= 0f)
				{
					list.Add(rockChip);
				}
			}
			foreach (CastleMapRendering.RockChip item in list)
			{
				this.rockChips.Remove(item);
			}
			this.updateRockSmoke();
		}

		// Token: 0x06000AFF RID: 2815 RVA: 0x000DF164 File Offset: 0x000DD364
		public void drawRockChips(CastleMap m_castleMap)
		{
			foreach (CastleMapRendering.RockChip rockChip in this.rockChips)
			{
				SpriteWrapper nextExtraSprite = m_castleMap.getNextExtraSprite(GFXLibrary.Instance.MissileTexID, 144 + rockChip.image);
				PointF pointF = nextExtraSprite.Center = new PointF(28f, 28f + rockChip.height);
				nextExtraSprite.PosX = rockChip.xPos;
				nextExtraSprite.PosY = rockChip.yPos;
				nextExtraSprite.Scale = 0.4f;
				if (rockChip.black)
				{
					nextExtraSprite.ColorToUse = Color.FromArgb(255, 64, 64, 64);
				}
				else
				{
					nextExtraSprite.ColorToUse = global::ARGBColors.White;
				}
				this.backgroundSprite.AddChild(nextExtraSprite, 2);
			}
			this.drawSmoke(m_castleMap);
		}

		// Token: 0x06000B00 RID: 2816 RVA: 0x000DF258 File Offset: 0x000DD458
		private void addRockSmoke(float xPos, float yPos, bool black)
		{
			CastleMapRendering.RockSmoke rockSmoke = new CastleMapRendering.RockSmoke();
			rockSmoke.xPos = xPos;
			rockSmoke.yPos = yPos;
			rockSmoke.animFrame = 2;
			rockSmoke.black = black;
			this.rockSmoke.Add(rockSmoke);
		}

		// Token: 0x06000B01 RID: 2817 RVA: 0x000DF294 File Offset: 0x000DD494
		private void updateRockSmoke()
		{
			List<CastleMapRendering.RockSmoke> list = new List<CastleMapRendering.RockSmoke>();
			foreach (CastleMapRendering.RockSmoke rockSmoke in this.rockSmoke)
			{
				rockSmoke.animFrame++;
				if (rockSmoke.animFrame >= 20)
				{
					list.Add(rockSmoke);
				}
			}
			foreach (CastleMapRendering.RockSmoke item in list)
			{
				this.rockSmoke.Remove(item);
			}
		}

		// Token: 0x06000B02 RID: 2818 RVA: 0x000DF34C File Offset: 0x000DD54C
		private void drawSmoke(CastleMap m_castleMap)
		{
			foreach (CastleMapRendering.RockSmoke rockSmoke in this.rockSmoke)
			{
				SpriteWrapper nextExtraSprite = m_castleMap.getNextExtraSprite(GFXLibrary.Instance.Smoke1TexID, rockSmoke.animFrame / 2);
				nextExtraSprite.Center = new PointF(50f, 75f);
				nextExtraSprite.PosX = rockSmoke.xPos;
				nextExtraSprite.PosY = rockSmoke.yPos;
				nextExtraSprite.Scale = 1.5f;
				if (rockSmoke.black)
				{
					nextExtraSprite.ColorToUse = Color.FromArgb(255, 64, 64, 64);
					nextExtraSprite.ScaleX = 2.3f;
				}
				else
				{
					nextExtraSprite.ColorToUse = global::ARGBColors.White;
				}
				this.backgroundSprite.AddChild(nextExtraSprite, 2);
			}
		}

		// Token: 0x06000B03 RID: 2819 RVA: 0x000DF434 File Offset: 0x000DD634
		public void drawCatapultLine(CastleMap.CatapultLine line)
		{
			this.gfx.startThickLine(Color.FromArgb(0, 255, 0), 3f);
			this.gfx.setThickLineRadius(1f);
			Point point = CastleMap.castleUnitSpritePoint[line.startX, line.startY];
			Point point2 = CastleMap.castleUnitSpritePoint[line.endX, line.endY];
			this.gfx.addThickLinePoint((float)point.X + this.backgroundSprite.DrawPos.X, (float)point.Y + this.backgroundSprite.DrawPos.Y);
			this.gfx.addThickLinePoint((float)point2.X + this.backgroundSprite.DrawPos.X, (float)point2.Y + this.backgroundSprite.DrawPos.Y);
			this.gfx.drawThickLines(true);
		}

		// Token: 0x06000B04 RID: 2820 RVA: 0x000DF530 File Offset: 0x000DD730
		public void drawCastleLoopBG(ref bool completed, ref DateTime completeTime, DateTime curTime, CastleMap m_castleMap)
		{
			foreach (CastleElement castleElement in m_castleMap.elements)
			{
				if (castleElement.completionTime > completeTime)
				{
					completeTime = castleElement.completionTime;
					completed = false;
				}
				byte elementType = castleElement.elementType;
				if (elementType != 31)
				{
					if (elementType == 32)
					{
						if (castleElement.completionTime <= curTime)
						{
							m_castleMap.numSmelter++;
						}
					}
				}
				else if (castleElement.completionTime <= curTime)
				{
					m_castleMap.numGuardHouses++;
				}
				int num = (int)(castleElement.damage * 10f);
				if (num != 0 && (castleElement.elementType != 36 || !m_castleMap.battleMode))
				{
					m_castleMap.castleDamaged = true;
				}
			}
		}

		// Token: 0x04000EFE RID: 3838
		private const double RAD2DEG = 57.2957795;

		// Token: 0x04000EFF RID: 3839
		public SpriteWrapper backgroundSprite;

		// Token: 0x04000F00 RID: 3840
		public GraphicsMgr gfx;

		// Token: 0x04000F01 RID: 3841
		public int pulse;

		// Token: 0x04000F02 RID: 3842
		public int pulseValue;

		// Token: 0x04000F03 RID: 3843
		private int[] archerAttackWall = new int[]
		{
			0,
			1,
			2,
			3,
			4,
			5,
			5,
			5,
			4,
			3,
			2,
			1
		};

		// Token: 0x04000F04 RID: 3844
		private int[] archerAttackUnit = new int[]
		{
			0,
			9,
			10,
			11,
			10,
			9
		};

		// Token: 0x04000F05 RID: 3845
		private int[] archerAttackMoat = new int[]
		{
			0,
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

		// Token: 0x04000F06 RID: 3846
		private int[] archerBlocked = new int[]
		{
			0,
			0,
			1,
			1,
			2,
			2,
			1,
			1
		};

		// Token: 0x04000F07 RID: 3847
		private int[] archerDyingArrow = new int[]
		{
			0,
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
			15,
			16,
			17,
			18,
			19,
			20,
			21,
			22,
			23
		};

		// Token: 0x04000F08 RID: 3848
		private int[] archerDyingNormal = new int[]
		{
			0,
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
			31
		};

		// Token: 0x04000F09 RID: 3849
		private int[] archerAttackFiringStraight = new int[]
		{
			0,
			1,
			2,
			3,
			4,
			5,
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
			12,
			13,
			13,
			13,
			13,
			14,
			15,
			16,
			16,
			16,
			16,
			16
		};

		// Token: 0x04000F0A RID: 3850
		private int[] archerAttackFiringDown = new int[]
		{
			0,
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8,
			17,
			18,
			19,
			20,
			21,
			22,
			23,
			24,
			25,
			25,
			25,
			25,
			26,
			27,
			28,
			28,
			28,
			28,
			28
		};

		// Token: 0x04000F0B RID: 3851
		private int[] archerAttackFiringUp = new int[]
		{
			0,
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8,
			29,
			30,
			31,
			32,
			33,
			34,
			35,
			36,
			37,
			37,
			37,
			37,
			38,
			39,
			40,
			40,
			40,
			40,
			40
		};

		// Token: 0x04000F0C RID: 3852
		private int[] pikemanAttackJab = new int[]
		{
			0,
			1,
			2,
			3,
			3,
			3,
			3,
			2,
			2,
			1,
			1,
			0,
			0,
			0,
			0
		};

		// Token: 0x04000F0D RID: 3853
		private int[] pikemanAttackJabQuick = new int[]
		{
			1,
			2,
			3,
			3,
			2,
			1,
			0
		};

		// Token: 0x04000F0E RID: 3854
		private int[] pikemanAttackChop = new int[]
		{
			4,
			5,
			5,
			6,
			6,
			7,
			7,
			7,
			7,
			7,
			7,
			2,
			1,
			0,
			0
		};

		// Token: 0x04000F0F RID: 3855
		private int[] pikemanIdle = new int[]
		{
			0,
			0,
			0,
			1,
			1,
			1,
			2,
			2,
			2,
			3,
			3,
			3,
			2,
			2,
			2,
			1,
			1,
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

		// Token: 0x04000F10 RID: 3856
		private int[] pikemanBlocked = new int[]
		{
			0,
			0,
			1,
			1,
			2,
			2,
			1,
			1
		};

		// Token: 0x04000F11 RID: 3857
		private int[] pikemanAttackMoat = new int[]
		{
			0,
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
			14
		};

		// Token: 0x04000F12 RID: 3858
		private int[] pikemanDyingArrow = new int[]
		{
			0,
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
			15,
			16,
			17,
			18,
			19,
			20,
			21,
			22,
			23
		};

		// Token: 0x04000F13 RID: 3859
		private int[] pikemanDyingNormal = new int[]
		{
			0,
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
			15,
			16,
			17,
			18,
			19,
			20,
			21,
			22,
			23
		};

		// Token: 0x04000F14 RID: 3860
		private int[] swordsmanAttackWall = new int[]
		{
			0,
			1,
			2,
			3,
			3,
			4,
			5,
			6,
			7,
			8,
			8,
			8,
			9,
			10,
			11
		};

		// Token: 0x04000F15 RID: 3861
		private int[] swordsmanAttackUnit = new int[]
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
			7,
			8,
			9,
			10,
			11
		};

		// Token: 0x04000F16 RID: 3862
		private int[] swordsmanAttackMoat = new int[]
		{
			0,
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
			14
		};

		// Token: 0x04000F17 RID: 3863
		private int[] swordsmanBlocked = new int[]
		{
			0,
			0,
			1,
			1,
			2,
			2,
			1,
			1
		};

		// Token: 0x04000F18 RID: 3864
		private int[] swordsmanDyingArrow = new int[]
		{
			0,
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
			15,
			16,
			17,
			18,
			19,
			20,
			21,
			22,
			23
		};

		// Token: 0x04000F19 RID: 3865
		private int[] swordsmanDyingNormal = new int[]
		{
			0,
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
			15,
			16,
			17,
			18,
			19,
			20,
			21,
			22,
			23
		};

		// Token: 0x04000F1A RID: 3866
		private int[] captainAttackWall = new int[]
		{
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8,
			8,
			9,
			10,
			10,
			10,
			10,
			11,
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
			23,
			23,
			24,
			25,
			26,
			27,
			28,
			29,
			30,
			31,
			32,
			33,
			34,
			35,
			36,
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
			23,
			23,
			24
		};

		// Token: 0x04000F1B RID: 3867
		private int[] captainAttackUnit = new int[]
		{
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8,
			8,
			9,
			10,
			10,
			10,
			10,
			11,
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
			23,
			23,
			24,
			25,
			26,
			27,
			28,
			29,
			30,
			31,
			32,
			33,
			34,
			35,
			36,
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
			23,
			23,
			24
		};

		// Token: 0x04000F1C RID: 3868
		private int[] captainAttackMoat = new int[]
		{
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8,
			8,
			9,
			10,
			10,
			10,
			10,
			11,
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
			23,
			23,
			24,
			25,
			26,
			27,
			28,
			29,
			30,
			31,
			32,
			33,
			34,
			35,
			36,
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
			23,
			23,
			24
		};

		// Token: 0x04000F1D RID: 3869
		private int[] captainDyingAnim = new int[]
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
			28
		};

		// Token: 0x04000F1E RID: 3870
		private int[] captainIdle = new int[]
		{
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
			3,
			3,
			3,
			3,
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
			5,
			5,
			5,
			5,
			5,
			6,
			6,
			6,
			6,
			6,
			6,
			5,
			5,
			5,
			5,
			5,
			5,
			5,
			3,
			3,
			3,
			3,
			3,
			3,
			2,
			2,
			2,
			2,
			2
		};

		// Token: 0x04000F1F RID: 3871
		private int[] wolfAttackUnit = new int[]
		{
			0,
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
			27
		};

		// Token: 0x04000F20 RID: 3872
		private int[] wolfDyingArrow = new int[]
		{
			0,
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
			15,
			16,
			17,
			18,
			19,
			20,
			21,
			22,
			23
		};

		// Token: 0x04000F21 RID: 3873
		private int[] wolfDyingNormal = new int[]
		{
			0,
			1,
			2,
			3,
			4,
			5,
			6,
			7
		};

		// Token: 0x04000F22 RID: 3874
		private int[] knightAttackUnit = new int[]
		{
			0,
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
			11
		};

		// Token: 0x04000F23 RID: 3875
		private int[] knightHorseIdle = new int[]
		{
			0,
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
			1,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			1,
			0,
			0,
			0,
			0,
			0,
			0,
			1,
			2,
			2,
			2,
			2,
			2,
			1,
			0,
			0,
			0,
			0,
			1,
			2,
			2,
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
			1,
			2,
			2,
			2,
			2,
			2,
			1,
			0,
			0,
			0,
			0
		};

		// Token: 0x04000F24 RID: 3876
		private int[] knightDyingArrow = new int[]
		{
			0,
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
			15,
			16,
			17,
			18,
			19,
			20,
			21,
			22,
			23
		};

		// Token: 0x04000F25 RID: 3877
		private int[] knightDyingNormal = new int[]
		{
			0,
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
			15,
			16,
			17,
			18,
			19,
			20,
			21,
			22,
			23
		};

		// Token: 0x04000F26 RID: 3878
		private int[] peasantAttack = new int[]
		{
			0,
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

		// Token: 0x04000F27 RID: 3879
		private int[] peasantIdle = new int[]
		{
			0,
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8,
			9,
			8,
			7,
			6,
			5,
			4,
			3,
			2,
			1
		};

		// Token: 0x04000F28 RID: 3880
		private int[] peasantBlocked = new int[]
		{
			0,
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8,
			9,
			8,
			7,
			6,
			5,
			4,
			3,
			2,
			1
		};

		// Token: 0x04000F29 RID: 3881
		private int[] peasantAttackMoat = new int[]
		{
			0,
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
			14
		};

		// Token: 0x04000F2A RID: 3882
		private int[] peasantDyingArrow = new int[]
		{
			0,
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
			15,
			16,
			17,
			18,
			19,
			20,
			21,
			22,
			23
		};

		// Token: 0x04000F2B RID: 3883
		private int[] peasantDyingNormal = new int[]
		{
			0,
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
			15,
			16,
			17,
			18,
			19,
			20,
			21,
			22,
			23
		};

		// Token: 0x04000F2C RID: 3884
		private int[] catapultAnim = new int[]
		{
			0,
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
			27
		};

		// Token: 0x04000F2D RID: 3885
		private int[] fireStart = new int[]
		{
			0,
			1,
			2,
			3,
			4,
			5,
			6
		};

		// Token: 0x04000F2E RID: 3886
		private int[] fireLoop = new int[]
		{
			0,
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
			31,
			32,
			33,
			34
		};

		// Token: 0x04000F2F RID: 3887
		private int[] fireEnd = new int[]
		{
			0,
			1,
			2,
			3,
			4,
			5,
			6
		};

		// Token: 0x04000F30 RID: 3888
		private int[] dyingOnFire = new int[]
		{
			0,
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
			31,
			32,
			33,
			34,
			35,
			36,
			37,
			38
		};

		// Token: 0x04000F31 RID: 3889
		private int[] captainBattleCryAnim = new int[]
		{
			335,
			334,
			333,
			332,
			331,
			332,
			333,
			334,
			335
		};

		// Token: 0x04000F32 RID: 3890
		private List<CastleMapRendering.RockChip> rockChips = new List<CastleMapRendering.RockChip>();

		// Token: 0x04000F33 RID: 3891
		private Random chipRand = new Random();

		// Token: 0x04000F34 RID: 3892
		private List<CastleMapRendering.RockSmoke> rockSmoke = new List<CastleMapRendering.RockSmoke>();

		// Token: 0x04000F35 RID: 3893
		private bool isCollapsed;

		// Token: 0x04000F36 RID: 3894
		private static bool invalidateWallsOnCollapseChange;

		// Token: 0x04000F37 RID: 3895
		private int elementsDrawn;

		// Token: 0x04000F38 RID: 3896
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

		// Token: 0x04000F39 RID: 3897
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

		// Token: 0x02000129 RID: 297
		public class RockChip
		{
			// Token: 0x04000F3A RID: 3898
			public float xPos;

			// Token: 0x04000F3B RID: 3899
			public float yPos;

			// Token: 0x04000F3C RID: 3900
			public float dx;

			// Token: 0x04000F3D RID: 3901
			public float dy;

			// Token: 0x04000F3E RID: 3902
			public float height;

			// Token: 0x04000F3F RID: 3903
			public float vVelocity;

			// Token: 0x04000F40 RID: 3904
			public float gravityValue;

			// Token: 0x04000F41 RID: 3905
			public int image;

			// Token: 0x04000F42 RID: 3906
			public bool black;
		}

		// Token: 0x0200012A RID: 298
		public class RockSmoke
		{
			// Token: 0x04000F43 RID: 3907
			public float xPos;

			// Token: 0x04000F44 RID: 3908
			public float yPos;

			// Token: 0x04000F45 RID: 3909
			public int animFrame;

			// Token: 0x04000F46 RID: 3910
			public bool black;
		}
	}
}
