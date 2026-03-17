using System;
using System.Drawing;
using CommonTypes;
using DXGraphics;

namespace Kingdoms
{
	// Token: 0x0200023A RID: 570
	public class MapIconDrawCall
	{
		// Token: 0x06001921 RID: 6433 RVA: 0x0018DE9C File Offset: 0x0018C09C
		public MapIconDrawCall(GraphicsMgr graphicsManager, SpriteWrapper VillageSprite, double WorldZoom, double WorldScale, bool MapEditing, Size ScreenSize, int Pulse, int PulseValue, bool XmasPresents)
		{
			this.worldZoom = WorldZoom;
			this.worldScale = WorldScale;
			this.mapEditing = MapEditing;
			this.gfx = graphicsManager;
			this.villageSprite = VillageSprite;
			this.pulse = Pulse;
			this.pulseValue = PulseValue;
			this.xmasPresents = XmasPresents;
			this.screenSize = ScreenSize;
		}

		// Token: 0x06001922 RID: 6434 RVA: 0x000199CA File Offset: 0x00017BCA
		private int iScale(int i, float scale)
		{
			return (int)((float)i * scale);
		}

		// Token: 0x06001923 RID: 6435 RVA: 0x000199D1 File Offset: 0x00017BD1
		public int getHouseIDFromVillage(VillageData village)
		{
			if (village.userID < 0)
			{
				return 21;
			}
			return GameEngine.Instance.World.getHouse(village.factionID);
		}

		// Token: 0x06001924 RID: 6436 RVA: 0x000199F4 File Offset: 0x00017BF4
		private Color getColorFromArray(Color[] carray, int index)
		{
			if (carray != null && index >= 0 && index < carray.Length)
			{
				return carray[index];
			}
			return global::ARGBColors.White;
		}

		// Token: 0x06001925 RID: 6437 RVA: 0x00019A10 File Offset: 0x00017C10
		public int fixupVillageSprites(int colourID)
		{
			if (colourID != 0)
			{
				if (colourID == 7)
				{
					colourID = 0;
				}
			}
			else
			{
				colourID = 7;
			}
			return colourID;
		}

		// Token: 0x06001926 RID: 6438 RVA: 0x0018DF0C File Offset: 0x0018C10C
		private void setSpriteToCountryCapital(ref bool drawSprite, ref int spriteID, VillageData village, ref Color villageColoriser, ref bool capitalVillage, ref float scale, ref string capitalName)
		{
			drawSprite = true;
			int houseIDFromVillage = this.getHouseIDFromVillage(village);
			villageColoriser = WorldMap.getVillageColor(houseIDFromVillage);
			capitalVillage = true;
			scale = (float)this.worldScale / 8.5f;
			spriteID = 58;
			if (scale < 0.15f)
			{
				scale = 0.15f;
			}
			if (scale > 1f)
			{
				scale = 1f;
			}
			if (this.worldScale > 3.0)
			{
				capitalName = village.villageName;
			}
		}

		// Token: 0x06001927 RID: 6439 RVA: 0x0018DF88 File Offset: 0x0018C188
		private void setSpriteToProvinceCapital(ref bool drawSprite, ref int spriteID, VillageData village, ref Color villageColoriser, ref bool capitalVillage, ref float scale, ref string capitalName)
		{
			drawSprite = true;
			int houseIDFromVillage = this.getHouseIDFromVillage(village);
			villageColoriser = WorldMap.getVillageColor(houseIDFromVillage);
			capitalVillage = true;
			scale = (float)this.worldScale / 8.5f;
			spriteID = 57;
			if (scale < 0.15f)
			{
				scale = 0.15f;
			}
			if (scale > 1f)
			{
				scale = 1f;
			}
			if (this.worldScale > 3.0)
			{
				capitalName = village.villageName;
			}
		}

		// Token: 0x06001928 RID: 6440 RVA: 0x0018E004 File Offset: 0x0018C204
		private void setSpriteToCountyCapital(ref bool drawSprite, ref int spriteID, VillageData village, ref Color villageColoriser, ref bool capitalVillage, ref float scale, ref string capitalName)
		{
			drawSprite = true;
			int houseIDFromVillage = this.getHouseIDFromVillage(village);
			villageColoriser = WorldMap.getVillageColor(houseIDFromVillage);
			capitalVillage = true;
			scale = (float)this.worldScale / 11.333333f;
			spriteID = 56;
			if (scale < 0.1f)
			{
				scale = 0.1f;
			}
			if (scale > 1f)
			{
				scale = 1f;
			}
			if (this.worldScale > 3.0)
			{
				capitalName = village.villageName;
			}
		}

		// Token: 0x06001929 RID: 6441 RVA: 0x0018E080 File Offset: 0x0018C280
		private void setSpriteToParishCapital(ref bool drawSprite, ref int spriteID, VillageData village, ref Color villageColoriser, ref bool capitalVillage, ref float scale, ref string capitalName)
		{
			drawSprite = true;
			int houseIDFromVillage = this.getHouseIDFromVillage(village);
			villageColoriser = WorldMap.getVillageColor(houseIDFromVillage);
			capitalVillage = true;
			scale = (float)this.worldScale / 17f;
			spriteID = 55;
			if (scale < 0.1f)
			{
				scale = 0.1f;
			}
			if (scale > 1f)
			{
				scale = 1f;
			}
			if (this.worldScale > 5.0)
			{
				capitalName = village.villageName;
			}
		}

		// Token: 0x0600192A RID: 6442 RVA: 0x0018E0FC File Offset: 0x0018C2FC
		private void setSpriteToInvasionMarkerAndDraw(ref bool allowSurroundDraw, ref bool drawSprite, ref float scale, VillageData village, ref int spriteID, double xPos, double yPos, ref Color villageColoriser)
		{
			allowSurroundDraw = false;
			drawSprite = true;
			if (this.worldScale > 0.67)
			{
				scale = 1f;
			}
			else
			{
				scale = (float)(this.worldScale / 0.66);
			}
			int aiinvasionMarkerState = GameEngine.Instance.World.getAIInvasionMarkerState(village.id);
			if (aiinvasionMarkerState == 0)
			{
				spriteID = 418;
			}
			else
			{
				if (aiinvasionMarkerState == 2)
				{
					this.gfx.beginSprites();
					this.villageSprite.PosX = (float)xPos * (float)this.screenSize.Width;
					this.villageSprite.PosY = (float)yPos * (float)this.screenSize.Height;
					int alpha = this.pulseValue;
					this.villageSprite.Scale = scale;
					this.villageSprite.TextureID = GFXLibrary.Instance.WorldMapIconsTexID;
					this.villageSprite.SpriteNo = 420;
					this.villageSprite.ColorToUse = Color.FromArgb(alpha, global::ARGBColors.Yellow);
					this.villageSprite.Update();
					this.villageSprite.DrawAndClear_NoCenter();
					this.villageSprite.ColorToUse = global::ARGBColors.White;
				}
				spriteID = 419;
			}
			villageColoriser = global::ARGBColors.White;
		}

		// Token: 0x0600192B RID: 6443 RVA: 0x0018E234 File Offset: 0x0018C434
		private void drawMapIconSelectedTint(float origScale, VillageData village, bool newVillage)
		{
			this.villageSprite.Scale = origScale;
			this.villageSprite.TextureID = GFXLibrary.Instance.WorldMapIconsTexID;
			if (InterfaceMgr.Instance.OwnSelectedVillage == village.id || InterfaceMgr.Instance.SelectedVassalVillage == village.id)
			{
				this.villageSprite.SpriteNo = 34;
			}
			else
			{
				this.villageSprite.SpriteNo = 30;
			}
			if (newVillage)
			{
				this.villageSprite.SpriteNo += 2;
				this.villageSprite.Center = new PointF(44f, 47f);
			}
			else
			{
				if (village.regionCapital)
				{
					SpriteWrapper spriteWrapper = this.villageSprite;
					int spriteNo = spriteWrapper.SpriteNo;
					spriteWrapper.SpriteNo = spriteNo + 1;
				}
				if (village.countyCapital)
				{
					this.villageSprite.SpriteNo += 2;
				}
				if (village.provinceCapital)
				{
					this.villageSprite.SpriteNo += 3;
				}
				if (village.countryCapital)
				{
					this.villageSprite.SpriteNo += 3;
				}
			}
			this.villageSprite.Update();
			this.villageSprite.DrawAndClear();
		}

		// Token: 0x0600192C RID: 6444 RVA: 0x0018E358 File Offset: 0x0018C558
		private void drawMapIconSurround(ref Color surroundColoriser, Color villageColoriser, float origScale, bool aiWorldSpecial, VillageData village, int spriteID, bool showSurround, int NORMAL_OFFSET_30, ref Color buildingsColoriser, int NORMAL_OFFSET_110)
		{
			surroundColoriser = Color.FromArgb(192, villageColoriser);
			if (villageColoriser == global::ARGBColors.White)
			{
				surroundColoriser = Color.FromArgb(128, villageColoriser);
			}
			this.villageSprite.Scale = origScale;
			int num = 0;
			int num2 = 35;
			if (aiWorldSpecial)
			{
				num = Math.Min((int)(village.villageInfo * 3 + 4), 19);
			}
			else if (village.special == 0)
			{
				num = Math.Min((int)(village.villageInfo / 6), 19);
			}
			else
			{
				num2 = spriteID;
			}
			if (village.special == 0 || aiWorldSpecial)
			{
				if (showSurround)
				{
					this.villageSprite.TextureID = GFXLibrary.Instance.WorldMapIconsTexID;
					this.villageSprite.SpriteNo = num2 + NORMAL_OFFSET_30 + num;
					this.villageSprite.ColorToUse = surroundColoriser;
					this.villageSprite.Update();
					this.villageSprite.DrawAndClear_NoCenter();
				}
				else if (aiWorldSpecial)
				{
					surroundColoriser = Color.FromArgb(255, 41, 41, 48);
					this.villageSprite.Scale = origScale;
					this.villageSprite.TextureID = GFXLibrary.Instance.WorldMapIconsTexID;
					this.villageSprite.SpriteNo = num2 + NORMAL_OFFSET_30 + num;
					this.villageSprite.ColorToUse = surroundColoriser;
					this.villageSprite.Update();
					this.villageSprite.DrawAndClear_NoCenter();
					this.villageSprite.ColorToUse = global::ARGBColors.White;
					buildingsColoriser = Color.FromArgb(255, 228, 228);
					surroundColoriser = Color.FromArgb(255, 255, 0, 0);
					this.villageSprite.Scale = origScale;
					this.villageSprite.TextureID = GFXLibrary.Instance.WorldMapIconsTexID;
					if (num2 == 63 || num2 == 64)
					{
						this.villageSprite.SpriteNo = num2 + NORMAL_OFFSET_110 + num + 1;
					}
					else
					{
						this.villageSprite.SpriteNo = num2 + NORMAL_OFFSET_110 + num;
					}
					this.villageSprite.ColorToUse = surroundColoriser;
					this.villageSprite.Update();
					this.villageSprite.DrawAndClear_NoCenter();
					this.villageSprite.ColorToUse = global::ARGBColors.White;
					buildingsColoriser = Color.FromArgb(255, 228, 228);
				}
				this.villageSprite.ColorToUse = global::ARGBColors.White;
			}
			if (InterfaceMgr.Instance.OwnSelectedVillage == village.id || InterfaceMgr.Instance.SelectedVassalVillage == village.id)
			{
				int alpha = this.pulseValue;
				surroundColoriser = Color.FromArgb(alpha, global::ARGBColors.Yellow);
				this.villageSprite.Scale = origScale;
				this.villageSprite.TextureID = GFXLibrary.Instance.WorldMapIconsTexID;
				this.villageSprite.SpriteNo = num2 + NORMAL_OFFSET_110 + num;
				this.villageSprite.ColorToUse = surroundColoriser;
				this.villageSprite.Update();
				this.villageSprite.DrawAndClear_NoCenter();
				this.villageSprite.ColorToUse = global::ARGBColors.White;
				buildingsColoriser = Color.FromArgb(255, 255, 192);
			}
			else if (InterfaceMgr.Instance.SelectedVillage == village.id)
			{
				int alpha2 = this.pulseValue;
				surroundColoriser = Color.FromArgb(alpha2, 64, 255, 64);
				this.villageSprite.Scale = origScale;
				this.villageSprite.TextureID = GFXLibrary.Instance.WorldMapIconsTexID;
				if (village.userID < 0 && (village.special == 0 || village.special == 30))
				{
					this.villageSprite.SpriteNo = 65;
				}
				else if (num2 == 63 || num2 == 64)
				{
					this.villageSprite.SpriteNo = num2 + NORMAL_OFFSET_110 + num + 1;
				}
				else
				{
					this.villageSprite.SpriteNo = num2 + NORMAL_OFFSET_110 + num;
				}
				this.villageSprite.ColorToUse = surroundColoriser;
				this.villageSprite.Update();
				this.villageSprite.DrawAndClear_NoCenter();
				this.villageSprite.ColorToUse = global::ARGBColors.White;
				buildingsColoriser = Color.FromArgb(192, 255, 192);
				if (SpecialVillageTypes.IS_ROYAL_TOWER(village.special))
				{
					this.villageSprite.Center = new PointF(43f, 110f);
				}
			}
			this.villageSprite.Scale = origScale;
			if (village.userID >= 0 || village.special != 0)
			{
				this.villageSprite.TextureID = GFXLibrary.Instance.WorldMapIconsTexID;
				this.villageSprite.SpriteNo = num2 + num;
			}
			else
			{
				this.villageSprite.TextureID = GFXLibrary.Instance.WorldMapIconsTexID;
				this.villageSprite.SpriteNo = 401;
			}
			this.villageSprite.ColorToUse = buildingsColoriser;
			this.villageSprite.Update();
			this.villageSprite.DrawAndClear();
		}

		// Token: 0x0600192D RID: 6445 RVA: 0x00019A24 File Offset: 0x00017C24
		private void drawUnopenedStash(int villageTexture, int spriteID, float origScale, VillageData village)
		{
			this.villageSprite.TextureID = villageTexture;
			this.villageSprite.SpriteNo = spriteID;
			this.villageSprite.Scale = origScale;
			this.villageSprite.Update();
			this.villageSprite.DrawAndClear();
		}

		// Token: 0x0600192E RID: 6446 RVA: 0x0018E838 File Offset: 0x0018CA38
		private void drawParishPlagueLevel(int villageTexture, int plagueLevel, float origScale, VillageData village)
		{
			this.villageSprite.TextureID = villageTexture;
			if (plagueLevel > 133)
			{
				this.villageSprite.SpriteNo = 176;
			}
			else if (plagueLevel > 66)
			{
				this.villageSprite.SpriteNo = 144;
			}
			else
			{
				this.villageSprite.SpriteNo = 143;
			}
			this.villageSprite.Center = new PointF(61f, 61f);
			this.villageSprite.Scale = origScale;
			this.villageSprite.Update();
			this.villageSprite.DrawAndClear();
		}

		// Token: 0x0600192F RID: 6447 RVA: 0x0018E8D0 File Offset: 0x0018CAD0
		private void drawParishFlags(int villageTexture, float origScale, VillageData village, float scale)
		{
			this.villageSprite.TextureID = villageTexture;
			this.villageSprite.SpriteNo = 28;
			this.villageSprite.Center = new PointF(26f, 58f);
			this.villageSprite.Scale = origScale;
			this.villageSprite.Update();
			this.villageSprite.DrawAndClear();
			if (scale == 1f)
			{
				Color col = global::ARGBColors.Black;
				if (village.whiteFlags && this.worldScale >= 11.0)
				{
					col = Color.FromArgb(240, 240, 240);
					GameEngine.Instance.World.addText(village.numFlags.ToString(), new PointF(this.villageSprite.PosX + 35f * origScale + 1f, this.villageSprite.PosY + -27f * origScale + 1f), global::ARGBColors.Black, false, 1, false);
					GameEngine.Instance.World.addText(village.numFlags.ToString(), new PointF(this.villageSprite.PosX + 35f * origScale, this.villageSprite.PosY + -27f * origScale), col, false, 1, false);
					return;
				}
				GameEngine.Instance.World.addText(village.numFlags.ToString(), new PointF(this.villageSprite.PosX + 35f * origScale, this.villageSprite.PosY + -27f * origScale), col, false, 1, false);
			}
		}

		// Token: 0x06001930 RID: 6448 RVA: 0x0018EA64 File Offset: 0x0018CC64
		private void drawCapitalName(VillageData village, float origScale, string capitalName)
		{
			if (GameEngine.Instance.World.DrawDebugNames)
			{
				if (village.regionCapital)
				{
					GameEngine.Instance.World.addText("P:" + village.regionID.ToString() + " V:" + village.id.ToString(), new PointF(this.villageSprite.PosX, this.villageSprite.PosY + 30f * origScale), global::ARGBColors.Black, true, 1, true);
				}
				if (village.countyCapital)
				{
					GameEngine.Instance.World.addText("Cty:" + village.countyID.ToString() + " V:" + village.id.ToString(), new PointF(this.villageSprite.PosX, this.villageSprite.PosY + 30f * origScale), global::ARGBColors.Black, true, 1, true);
				}
				if (village.provinceCapital)
				{
					int countyProvince = GameEngine.Instance.World.getCountyProvince((int)village.countyID);
					GameEngine.Instance.World.addText("Prv:" + countyProvince.ToString() + " V:" + village.id.ToString(), new PointF(this.villageSprite.PosX, this.villageSprite.PosY + 30f * origScale), global::ARGBColors.Black, true, 1, true);
				}
				if (village.countryCapital)
				{
					int countyProvince2 = GameEngine.Instance.World.getCountyProvince((int)village.countyID);
					int provinceCountry = GameEngine.Instance.World.getProvinceCountry(countyProvince2);
					GameEngine.Instance.World.addText("Ctry:" + provinceCountry.ToString() + " V:" + village.id.ToString(), new PointF(this.villageSprite.PosX, this.villageSprite.PosY + 30f * origScale), global::ARGBColors.Black, true, 1, true);
					return;
				}
			}
			else if (capitalName.Length > 0)
			{
				Color black = global::ARGBColors.Black;
				GameEngine.Instance.World.addText(capitalName, new PointF(this.villageSprite.PosX, this.villageSprite.PosY + 40f * origScale), black, true, 1, true);
			}
		}

		// Token: 0x06001931 RID: 6449 RVA: 0x0018ECA0 File Offset: 0x0018CEA0
		private void setSpriteToSpecialType(VillageData village, ref int resourceSpriteNo, ref int spriteID, ref float scale, ref bool newVillage, ref Color villageColoriser, ref bool aiWorldSpecial, ref int NORMAL_OFFSET_110, ref int NORMAL_OFFSET_30)
		{
			if (village.special >= 100 && village.special <= 199)
			{
				resourceSpriteNo = GFXLibrary.getCommodity32GFXno(village.special - 100);
				if (resourceSpriteNo < 0)
				{
					if (this.xmasPresents)
					{
						spriteID = 400;
					}
					else
					{
						spriteID = 124;
					}
				}
				else
				{
					spriteID = -1;
				}
				scale = 1f;
				return;
			}
			if (village.special == 30)
			{
				scale = 1f;
				spriteID = 59;
				newVillage = true;
				villageColoriser = global::ARGBColors.White;
				return;
			}
			if (village.special == 3)
			{
				spriteID = 59;
				newVillage = true;
				villageColoriser = global::ARGBColors.White;
				return;
			}
			if (village.special == 4)
			{
				spriteID = 61;
				newVillage = true;
				villageColoriser = global::ARGBColors.White;
				return;
			}
			if (village.special == 5)
			{
				spriteID = 60;
				newVillage = true;
				villageColoriser = global::ARGBColors.White;
				return;
			}
			if (village.special == 6)
			{
				spriteID = 62;
				newVillage = true;
				villageColoriser = global::ARGBColors.White;
				return;
			}
			if (village.isAICastle)
			{
				if (GameEngine.Instance.LocalWorldData.AIWorld)
				{
					villageColoriser = global::ARGBColors.Black;
					aiWorldSpecial = true;
					newVillage = true;
					return;
				}
				spriteID = 63;
				newVillage = true;
				villageColoriser = global::ARGBColors.White;
				return;
			}
			else
			{
				if (village.special == 8 || village.special == 10 || village.special == 12 || village.special == 14)
				{
					spriteID = 64;
					newVillage = true;
					villageColoriser = global::ARGBColors.White;
					return;
				}
				if (village.special == 15 || village.special == 17)
				{
					spriteID = 388;
					newVillage = true;
					villageColoriser = global::ARGBColors.White;
					NORMAL_OFFSET_110 = -214;
					return;
				}
				if (village.special == 16 || village.special == 18)
				{
					spriteID = 389;
					newVillage = true;
					villageColoriser = global::ARGBColors.White;
					NORMAL_OFFSET_110 = -214;
					return;
				}
				if (village.special >= 41 && village.special <= 50)
				{
					spriteID = 390;
					newVillage = true;
					villageColoriser = global::ARGBColors.White;
					NORMAL_OFFSET_110 = -216;
					scale = 1f;
					return;
				}
				if (village.special >= 51 && village.special <= 60)
				{
					spriteID = 392;
					newVillage = true;
					villageColoriser = global::ARGBColors.White;
					NORMAL_OFFSET_110 = -218;
					scale = 1f;
					return;
				}
				if (village.special >= 61 && village.special <= 70)
				{
					spriteID = 394;
					newVillage = true;
					villageColoriser = global::ARGBColors.White;
					NORMAL_OFFSET_110 = -220;
					scale = 1f;
					return;
				}
				if (village.special >= 71 && village.special <= 80)
				{
					spriteID = 396;
					newVillage = true;
					villageColoriser = global::ARGBColors.White;
					NORMAL_OFFSET_110 = -222;
					scale = 1f;
					return;
				}
				if (village.special >= 81 && village.special <= 90)
				{
					spriteID = 398;
					newVillage = true;
					villageColoriser = global::ARGBColors.White;
					NORMAL_OFFSET_110 = -224;
					scale = 1f;
					return;
				}
				if (village.special == 40)
				{
					spriteID = 391;
					newVillage = true;
					villageColoriser = global::ARGBColors.White;
					NORMAL_OFFSET_110 = -216;
					return;
				}
				if (SpecialVillageTypes.IS_ROYAL_TOWER(village.special))
				{
					newVillage = true;
					villageColoriser = global::ARGBColors.White;
					int special = village.special;
					if (special != 200)
					{
						if (special - 201 <= 19)
						{
							spriteID = 433 + (village.special - 200);
							NORMAL_OFFSET_110 = 455 - spriteID;
						}
					}
					else
					{
						spriteID = 433;
						NORMAL_OFFSET_110 = 454 - spriteID;
					}
					scale = 1f;
					return;
				}
				if (village.special == 21)
				{
					spriteID = 376;
					newVillage = true;
					villageColoriser = global::ARGBColors.White;
					NORMAL_OFFSET_30 = 2;
					NORMAL_OFFSET_110 = 4;
					return;
				}
				if (village.special == 2)
				{
					village.visible = false;
				}
				return;
			}
		}

		// Token: 0x06001932 RID: 6450 RVA: 0x0018F088 File Offset: 0x0018D288
		private void drawHouseColourSurroundOnCapital(int villageTexture, int spriteID, int NORMAL_OFFSET_30, Color surroundColoriser, float origScale, VillageData village)
		{
			this.villageSprite.TextureID = villageTexture;
			this.villageSprite.SpriteNo = spriteID + NORMAL_OFFSET_30;
			this.villageSprite.ColorToUse = surroundColoriser;
			this.villageSprite.Center = new PointF(75f, 105f);
			this.villageSprite.Scale = origScale;
			this.villageSprite.Update();
			this.villageSprite.DrawAndClear_NoCenter();
		}

		// Token: 0x06001933 RID: 6451 RVA: 0x0018F0FC File Offset: 0x0018D2FC
		private void drawPulsingGlowOnCurrentPlayerControlledCapital(ref Color surroundColoriser, int villageTexture, int spriteID, int NORMAL_OFFSET_110, float origScale, VillageData village, ref Color buildingsColoriser)
		{
			int alpha = this.pulseValue;
			surroundColoriser = Color.FromArgb(alpha, global::ARGBColors.Yellow);
			this.villageSprite.TextureID = villageTexture;
			this.villageSprite.SpriteNo = spriteID + NORMAL_OFFSET_110;
			this.villageSprite.ColorToUse = surroundColoriser;
			this.villageSprite.Center = new PointF(75f, 105f);
			this.villageSprite.Scale = origScale;
			this.villageSprite.Update();
			this.villageSprite.DrawAndClear_NoCenter();
			buildingsColoriser = Color.FromArgb(255, 255, 192);
		}

		// Token: 0x06001934 RID: 6452 RVA: 0x0018F1A8 File Offset: 0x0018D3A8
		private void drawPulsingGlowOnTargetedCapital(ref Color surroundColoriser, int villageTexture, int spriteID, int NORMAL_OFFSET_110, float origScale, VillageData village, ref Color buildingsColoriser)
		{
			int alpha = this.pulseValue;
			surroundColoriser = Color.FromArgb(alpha, 64, 255, 64);
			this.villageSprite.TextureID = villageTexture;
			this.villageSprite.SpriteNo = spriteID + NORMAL_OFFSET_110;
			this.villageSprite.ColorToUse = surroundColoriser;
			this.villageSprite.Center = new PointF(75f, 105f);
			this.villageSprite.Scale = origScale;
			this.villageSprite.Update();
			this.villageSprite.DrawAndClear_NoCenter();
			buildingsColoriser = Color.FromArgb(192, 255, 192);
		}

		// Token: 0x06001935 RID: 6453 RVA: 0x0018F258 File Offset: 0x0018D458
		private void drawCapitalSprite(int villageTexture, int spriteID, Color buildingsColoriser, float origScale, VillageData village)
		{
			this.villageSprite.TextureID = villageTexture;
			this.villageSprite.SpriteNo = spriteID;
			this.villageSprite.ColorToUse = buildingsColoriser;
			this.villageSprite.Center = new PointF(75f, 105f);
			this.villageSprite.Scale = origScale;
			this.villageSprite.Update();
			this.villageSprite.DrawAndClear();
		}

		// Token: 0x06001936 RID: 6454 RVA: 0x0018F2C8 File Offset: 0x0018D4C8
		private void drawResourceStash(int resourceSpriteNo, float origScale, VillageData village)
		{
			this.gfx.beginSprites();
			this.villageSprite.TextureID = GFXLibrary.Instance.WorldMapIconsTexID;
			this.villageSprite.SpriteNo = resourceSpriteNo + 95;
			this.villageSprite.Scale = origScale;
			this.villageSprite.Update();
			this.villageSprite.DrawAndClear();
		}

		// Token: 0x06001937 RID: 6455 RVA: 0x0018F328 File Offset: 0x0018D528
		private bool checkVillageForShieldRollover(VillageData rolloverTargetVillage, VillageData village, ref int shieldXOff, ref int shieldYOff, ref int shieldTypeID)
		{
			bool result = false;
			if (rolloverTargetVillage.userID >= 0 && rolloverTargetVillage.userID == village.userID)
			{
				result = true;
			}
			else if (!GameEngine.Instance.LocalWorldData.AIWorld)
			{
				if (rolloverTargetVillage.isAICastle && village.isAICastle)
				{
					result = true;
					shieldXOff = -1;
					shieldYOff = -4;
					if (village.special == 7)
					{
						shieldTypeID = -1;
					}
					if (village.special == 9)
					{
						shieldTypeID = -2;
					}
					if (village.special == 11)
					{
						shieldTypeID = -3;
					}
					if (village.special == 13)
					{
						shieldTypeID = -4;
					}
				}
			}
			else if (rolloverTargetVillage.isAICastle && village.special == rolloverTargetVillage.special)
			{
				result = true;
				shieldXOff = -1;
				shieldYOff = -4;
				if (village.special == 7)
				{
					shieldTypeID = -1;
				}
				if (village.special == 9)
				{
					shieldTypeID = -2;
				}
				if (village.special == 11)
				{
					shieldTypeID = -3;
				}
				if (village.special == 13)
				{
					shieldTypeID = -4;
				}
			}
			return result;
		}

		// Token: 0x06001938 RID: 6456 RVA: 0x0018F420 File Offset: 0x0018D620
		public bool DrawShields(VillageData village, double xPos, double yPos, float scale)
		{
			bool flag = false;
			bool flag2 = false;
			bool force = false;
			int num = 0;
			int num2 = 0;
			int num3 = village.userID;
			if (num3 < 0)
			{
				num3 = -10000;
			}
			if (GameEngine.Instance.World.isUserVillage(village.id))
			{
				flag = true;
				force = true;
				flag2 = (this.worldScale >= 7.0);
			}
			else if (GameEngine.Instance.World.isUserRelatedVillage(village.id))
			{
				flag = true;
				force = true;
				flag2 = (this.worldScale >= 7.0);
			}
			else if (village.Capital && this.worldScale >= 7.0)
			{
				flag = true;
				force = true;
				flag2 = true;
			}
			else if (this.worldScale >= 11.0)
			{
				VillageData rolloverTargetVillage = GameEngine.Instance.World.rolloverTargetVillage;
				if (rolloverTargetVillage != null)
				{
					flag = this.checkVillageForShieldRollover(rolloverTargetVillage, village, ref num, ref num2, ref num3);
					flag2 = flag;
				}
				if (GameEngine.Instance.World.m_userInfoShieldRolloverUserID != -1 && village.userID == GameEngine.Instance.World.m_userInfoShieldRolloverUserID)
				{
					flag = true;
					flag2 = true;
				}
			}
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			bool flag6 = false;
			float num4 = 5f;
			if (!flag3 && flag && num3 > -10000)
			{
				int worldShieldTexture = GameEngine.Instance.World.getWorldShieldTexture(num3, force);
				if (worldShieldTexture > 0)
				{
					this.gfx.beginSprites();
					Color color = global::ARGBColors.White;
					if (village.userID == RemoteServices.Instance.UserID || GameEngine.Instance.World.isUserRelatedVillage(village.id))
					{
						this.villageSprite.TextureID = GFXLibrary.Instance.WorldMapIconsTexID;
						if (village.userID == RemoteServices.Instance.UserID)
						{
							this.villageSprite.SpriteNo = 386;
							this.villageSprite.Center = new PointF(33f, 69f);
							color = Color.FromArgb(255, 255, 0);
						}
						else
						{
							this.villageSprite.SpriteNo = 387;
							this.villageSprite.Center = new PointF(33f, 69f);
							color = Color.FromArgb(0, 255, 0);
						}
						scale = (float)this.worldScale / 17f;
						if (scale < 0.15f)
						{
							scale = 0.15f;
						}
						if (scale > 1f)
						{
							scale = 1f;
						}
						if (village.id == InterfaceMgr.Instance.getSelectedMenuVillage())
						{
							float num5 = (float)this.pulse / 128f;
							if (num5 > 1f)
							{
								num5 = 2f - num5;
							}
							color = Color.FromArgb((int)(255f - 255f * (num5 / 2f)), color);
						}
						this.villageSprite.ColorToUse = color;
						this.villageSprite.Scale = scale;
						this.villageSprite.Update();
						if (flag4)
						{
							this.villageSprite.FakeDrawAndClear();
						}
						else if (flag2)
						{
							this.villageSprite.DrawAndClear();
						}
						else
						{
							this.villageSprite.FakeDrawAndClear();
						}
					}
					scale = (float)this.worldScale / 17f;
					if (scale < 0.15f)
					{
						scale = 0.15f;
					}
					if (scale > 1f)
					{
						scale = 1f;
					}
					int num6 = 32;
					int num7 = 14;
					if (village.userID == RemoteServices.Instance.UserID)
					{
						num6 = 64;
						num7 = 18;
					}
					if (flag5)
					{
						scale = 1f;
					}
					if (flag6)
					{
						scale = num4;
					}
					Rectangle srcRect = new Rectangle(0, 0, num6, num6);
					Size p = new Size(this.iScale(num6, scale), this.iScale(num6, scale));
					PointF renderPos = new PointF(this.villageSprite.PosX - (float)(num7 - num) * scale, this.villageSprite.PosY - (float)(36 + num7 - num2) * scale);
					this.gfx.Draw2D(this.gfx.getTexture(worldShieldTexture), srcRect, p, renderPos, global::ARGBColors.White);
				}
				else
				{
					flag = false;
				}
			}
			return flag;
		}

		// Token: 0x06001939 RID: 6457 RVA: 0x0018F81C File Offset: 0x0018DA1C
		public void draw(VillageData village, double xPos, double yPos)
		{
			bool flag = false;
			float num = 1f;
			int num2 = 0;
			int worldMapIconsTexID = GFXLibrary.Instance.WorldMapIconsTexID;
			int num3 = -1;
			bool flag2 = false;
			bool flag3 = false;
			Color color = global::ARGBColors.White;
			Color surroundColoriser = Color.FromArgb(128, 255, 255, 192);
			string capitalName = "";
			bool flag4 = true;
			double num4 = 27.0 - this.worldZoom;
			int normal_OFFSET_ = 30;
			int normal_OFFSET_2 = 110;
			bool aiWorldSpecial = false;
			if (village.countryCapital)
			{
				if (this.worldZoom <= 23.59)
				{
					this.setSpriteToCountryCapital(ref flag, ref num2, village, ref color, ref flag3, ref num, ref capitalName);
				}
			}
			else if (village.provinceCapital)
			{
				if (this.worldZoom <= 23.0)
				{
					this.setSpriteToProvinceCapital(ref flag, ref num2, village, ref color, ref flag3, ref num, ref capitalName);
				}
			}
			else if (village.countyCapital)
			{
				if (this.worldZoom <= 22.5 || GameEngine.Instance.World.PickingStartCounty)
				{
					this.setSpriteToCountyCapital(ref flag, ref num2, village, ref color, ref flag3, ref num, ref capitalName);
				}
			}
			else if (village.regionCapital)
			{
				if (this.worldZoom <= 19.5 || this.mapEditing)
				{
					this.setSpriteToParishCapital(ref flag, ref num2, village, ref color, ref flag3, ref num, ref capitalName);
				}
			}
			else if (village.special == 30)
			{
				this.setSpriteToInvasionMarkerAndDraw(ref flag4, ref flag, ref num, village, ref num2, xPos, yPos, ref color);
				flag2 = true;
			}
			else if (num4 >= 8.0)
			{
				if (this.worldScale < 11.0 && (((village.special < 100 || village.special > 199) && !SpecialVillageTypes.IS_TREASURE_CASTLE(village.special) && !SpecialVillageTypes.IS_ROYAL_TOWER(village.special) && village.special != 30 && village.special != 17 && village.special != 15) || num4 < 6.0))
				{
					this.gfx.endSprites();
					this.gfx.drawLine(global::ARGBColors.Black, (float)xPos * (float)this.screenSize.Width, (float)yPos * (float)this.screenSize.Height, (float)xPos * (float)this.screenSize.Width + 1f, (float)yPos * (float)this.screenSize.Height);
				}
				else
				{
					flag = true;
					num = ((float)this.worldScale - 8.5f) / 8.5f;
					if (num > 1f)
					{
						num = 1f;
					}
					if (village.special == 0)
					{
						int houseIDFromVillage = this.getHouseIDFromVillage(village);
						color = WorldMap.getVillageColor(houseIDFromVillage);
						num2 = this.fixupVillageSprites(houseIDFromVillage);
						worldMapIconsTexID = GFXLibrary.Instance.WorldMapIconsTexID;
						flag2 = true;
					}
					else
					{
						if (village.special == 20)
						{
							return;
						}
						this.setSpriteToSpecialType(village, ref num3, ref num2, ref num, ref flag2, ref color, ref aiWorldSpecial, ref normal_OFFSET_2, ref normal_OFFSET_);
					}
				}
			}
			float num5 = num;
			this.villageSprite.PosX = (float)xPos * (float)this.screenSize.Width;
			this.villageSprite.PosY = (float)yPos * (float)this.screenSize.Height;
			if (flag)
			{
				bool flag5 = false;
				if (village.userID >= 0 && GameEngine.Instance.World.getHouse(village.factionID) > 0)
				{
					flag5 = true;
				}
				this.gfx.beginSprites();
				if ((InterfaceMgr.Instance.SelectedVillage == village.id || InterfaceMgr.Instance.OwnSelectedVillage == village.id || InterfaceMgr.Instance.SelectedVassalVillage == village.id) && !flag2 && !flag3 && flag4)
				{
					this.drawMapIconSelectedTint(num5, village, flag2);
				}
				if (SpecialVillageTypes.IS_ROYAL_TOWER(village.special))
				{
					this.villageSprite.Center = new PointF(43f, 110f);
				}
				if (!village.Capital)
				{
					Color white = global::ARGBColors.White;
					if (village.special == 0 || flag2)
					{
						this.drawMapIconSurround(ref surroundColoriser, color, num5, aiWorldSpecial, village, num2, flag5, normal_OFFSET_, ref white, normal_OFFSET_2);
						if (GameEngine.Instance.World.DrawDebugNames)
						{
							GameEngine.Instance.World.addText(village.id.ToString(), new PointF(this.villageSprite.PosX, this.villageSprite.PosY + 10f * num5), global::ARGBColors.Black, true, 1);
						}
						if (GameEngine.Instance.World.DrawDebugVillageNames)
						{
							GameEngine.Instance.World.addText(village.villageName, new PointF(this.villageSprite.PosX, this.villageSprite.PosY + 10f * num5), global::ARGBColors.Black, true, 1);
						}
					}
				}
				if (num2 >= 0 && !flag2)
				{
					if (flag3)
					{
						surroundColoriser = Color.FromArgb(192, color);
						if (color == global::ARGBColors.White)
						{
							surroundColoriser = Color.FromArgb(128, color);
						}
						if (flag5)
						{
							this.drawHouseColourSurroundOnCapital(worldMapIconsTexID, num2, normal_OFFSET_, surroundColoriser, num5, village);
						}
						Color white2 = global::ARGBColors.White;
						if (InterfaceMgr.Instance.OwnSelectedVillage == village.id || InterfaceMgr.Instance.SelectedVassalVillage == village.id)
						{
							this.drawPulsingGlowOnCurrentPlayerControlledCapital(ref surroundColoriser, worldMapIconsTexID, num2, normal_OFFSET_2, num5, village, ref white2);
						}
						else if (InterfaceMgr.Instance.SelectedVillage == village.id)
						{
							this.drawPulsingGlowOnTargetedCapital(ref surroundColoriser, worldMapIconsTexID, num2, normal_OFFSET_2, num5, village, ref white2);
						}
						this.drawCapitalSprite(worldMapIconsTexID, num2, white2, num5, village);
						this.drawCapitalName(village, num5, capitalName);
						int regionID = (int)village.regionID;
						int parishPlague = GameEngine.Instance.World.getParishPlague(regionID);
						int numFlags = (int)village.numFlags;
						bool flag6 = true;
						if (parishPlague > 0 && flag6)
						{
							this.drawParishPlagueLevel(worldMapIconsTexID, parishPlague, num5, village);
						}
						if (numFlags > 0 && flag6)
						{
							this.drawParishFlags(worldMapIconsTexID, num5, village, num);
						}
					}
					else
					{
						this.drawUnopenedStash(worldMapIconsTexID, num2, num5, village);
					}
				}
				if (num3 >= 0)
				{
					this.drawResourceStash(num3, num5, village);
				}
			}
			bool flag7 = this.DrawShields(village, xPos, yPos, num);
			if (GameEngine.Instance.World.isUserVillage(village.id) || GameEngine.Instance.World.isUserRelatedVillage(village.id) || ((village.factionID < 0 || RemoteServices.Instance.UserFactionID < 0 || (!GameEngine.Instance.World.worldMapFilter.FilterShowHouseSymbols && !GameEngine.Instance.World.worldMapFilter.FilterShowFactionSymbols)) && (village.userID < 0 || !GameEngine.Instance.World.worldMapFilter.FilterShowUserSymbols)))
			{
				return;
			}
			bool flag8 = false;
			if (village.countryCapital)
			{
				flag8 = true;
			}
			else if (village.provinceCapital)
			{
				flag8 = true;
			}
			else if (village.countyCapital)
			{
				if (num4 >= 4.0)
				{
					flag8 = true;
				}
			}
			else if (village.regionCapital)
			{
				if (num4 >= 6.0)
				{
					flag8 = true;
				}
			}
			else if (num4 >= 8.0)
			{
				flag8 = true;
			}
			if (!flag8)
			{
				return;
			}
			bool flag9 = false;
			int num6 = -1;
			int num7 = -1;
			if (village.factionID == RemoteServices.Instance.UserFactionID)
			{
				if (GameEngine.Instance.World.worldMapFilter.FilterShowUserSymbols)
				{
					int userRelationship = GameEngine.Instance.World.getUserRelationship(village.userID);
					if (userRelationship > 0)
					{
						num7 = 179;
					}
					else if (userRelationship < 0)
					{
						num7 = 180;
					}
				}
				if (num7 == -1 && RemoteServices.Instance.UserFactionID >= 0)
				{
					num7 = 178;
				}
			}
			else
			{
				if (GameEngine.Instance.World.worldMapFilter.FilterShowHouseSymbols && num7 == -1)
				{
					int house = GameEngine.Instance.World.getHouse(RemoteServices.Instance.UserFactionID);
					int house2 = GameEngine.Instance.World.getHouse(village.factionID);
					if (house != house2)
					{
						int yourHouseRelation = GameEngine.Instance.World.getYourHouseRelation(house2);
						if (yourHouseRelation > 0)
						{
							num7 = 179;
						}
						else if (yourHouseRelation < 0)
						{
							num7 = 180;
						}
					}
				}
				if (GameEngine.Instance.World.worldMapFilter.FilterShowFactionSymbols)
				{
					if (num7 != -1)
					{
						num6 = num7;
					}
					int yourFactionRelation = GameEngine.Instance.World.getYourFactionRelation(village.factionID);
					if (yourFactionRelation > 0)
					{
						num7 = 179;
					}
					else if (yourFactionRelation < 0)
					{
						num7 = 180;
					}
					if (num6 != -1 && num7 != -1 && num7 != num6)
					{
						flag9 = true;
					}
				}
				if (num7 != -1)
				{
					num6 = num7;
				}
				int userRelationship2 = GameEngine.Instance.World.getUserRelationship(village.userID);
				if (userRelationship2 > 0)
				{
					num7 = 179;
				}
				else if (userRelationship2 < 0)
				{
					num7 = 180;
				}
				if (num6 != -1 && num7 != -1 && num7 != num6)
				{
					flag9 = true;
				}
			}
			if (num7 >= 0)
			{
				if (flag9)
				{
					num7 = 179;
				}
				this.villageSprite.TextureID = GFXLibrary.Instance.WorldMapIconsTexID;
				this.villageSprite.SpriteNo = num7;
				int num8 = 0;
				if (flag7)
				{
					num8 = 30;
				}
				if (num7 != 180)
				{
					this.villageSprite.Center = new PointF((float)(39 + num8), 77f);
				}
				else
				{
					this.villageSprite.Center = new PointF((float)(42 + num8), 77f);
				}
				num = (float)this.worldScale / 17f;
				if (num < 0.15f)
				{
					num = 0.15f;
				}
				if (num > 1f)
				{
					num = 1f;
				}
				this.gfx.beginSprites();
				this.villageSprite.Scale = num;
				this.villageSprite.Update();
				this.villageSprite.DrawAndClear();
				if (flag9)
				{
					num7 = 180;
					this.villageSprite.TextureID = GFXLibrary.Instance.WorldMapIconsTexID;
					this.villageSprite.SpriteNo = num7;
					if (num7 != 180)
					{
						this.villageSprite.Center = new PointF((float)(39 + num8 + 20), 77f);
					}
					else
					{
						this.villageSprite.Center = new PointF((float)(42 + num8 + 20), 77f);
					}
					num = (float)this.worldScale / 17f;
					num *= 0.75f;
					if (num < 0.15f)
					{
						num = 0.15f;
					}
					if (num > 0.75f)
					{
						num = 0.75f;
					}
					this.villageSprite.Scale = num;
					this.villageSprite.Update();
					this.villageSprite.DrawAndClear();
				}
			}
			UserMarker userMarker = GameEngine.Instance.World.getUserMarker(village.userID);
			if (userMarker != null && userMarker.markerType > 0)
			{
				int num9 = 30;
				if (num4 > 16.0)
				{
					num9 = 10;
				}
				num7 = 459 + userMarker.markerType;
				this.villageSprite.TextureID = GFXLibrary.Instance.WorldMapIconsTexID;
				this.villageSprite.SpriteNo = num7;
				this.villageSprite.Center = new PointF((float)num9, (float)num9);
				num = (float)this.worldScale / 17f;
				num *= 0.5f;
				if (num < 0.35f)
				{
					num = 0.35f;
				}
				if (num > 0.65f)
				{
					num = 0.65f;
				}
				this.gfx.beginSprites();
				this.villageSprite.Scale = 1f;
				this.villageSprite.ColorToUse = Color.FromArgb(180, global::ARGBColors.White);
				this.villageSprite.Update();
				this.villageSprite.DrawAndClear();
			}
		}

		// Token: 0x04002985 RID: 10629
		private bool mapEditing;

		// Token: 0x04002986 RID: 10630
		private int village_y = 1;

		// Token: 0x04002987 RID: 10631
		private double worldZoom;

		// Token: 0x04002988 RID: 10632
		private double worldScale = 1.0;

		// Token: 0x04002989 RID: 10633
		private GraphicsMgr gfx;

		// Token: 0x0400298A RID: 10634
		private SpriteWrapper villageSprite;

		// Token: 0x0400298B RID: 10635
		private Size screenSize;

		// Token: 0x0400298C RID: 10636
		private int pulse;

		// Token: 0x0400298D RID: 10637
		private int pulseValue;

		// Token: 0x0400298E RID: 10638
		private bool xmasPresents;
	}
}
