using System;
using System.Collections.Generic;
using System.Drawing;
using DXGraphics;

namespace Kingdoms
{
	// Token: 0x020004CE RID: 1230
	public class VillageClickMask
	{
		// Token: 0x06002D7C RID: 11644 RVA: 0x0002166E File Offset: 0x0001F86E
		public void init(int width, int height, GraphicsMgr graphics)
		{
			this.gfx = graphics;
			this.mapWidth = width;
			this.mapHeight = height;
			this.maskMap = new byte[width, height];
			this.clearMap();
			this.buildings.Clear();
		}

		// Token: 0x06002D7D RID: 11645 RVA: 0x000216A3 File Offset: 0x0001F8A3
		public void clearMapAndBuildings()
		{
			this.clearMap();
			this.buildings.Clear();
		}

		// Token: 0x06002D7E RID: 11646 RVA: 0x00243018 File Offset: 0x00241218
		public void clearMap()
		{
			if (this.maskMap != null && !this.mapClear)
			{
				for (int i = 0; i < this.mapWidth; i++)
				{
					for (int j = 0; j < this.mapHeight; j++)
					{
						this.maskMap[i, j] = 0;
					}
				}
			}
			this.mapClear = true;
			this.mapDirty = false;
		}

		// Token: 0x06002D7F RID: 11647 RVA: 0x00243074 File Offset: 0x00241274
		public void addBuilding(long buildingID, int xPos, int yPos, int textureID, int spriteNo, PointF center)
		{
			if (buildingID >= 0L)
			{
				VillageClickMask.BuildingClickMask buildingClickMask = new VillageClickMask.BuildingClickMask();
				buildingClickMask.buildingID = buildingID;
				buildingClickMask.x = xPos;
				buildingClickMask.y = yPos;
				buildingClickMask.center = new Point((int)center.X, (int)center.Y);
				buildingClickMask.textureID = textureID;
				buildingClickMask.spriteNo = spriteNo;
				buildingClickMask.vcmID = this.buildings.Count;
				this.buildings.Add(buildingClickMask);
				this.mapDirty = true;
			}
		}

		// Token: 0x06002D80 RID: 11648 RVA: 0x002430F0 File Offset: 0x002412F0
		public void removeBuilding(long buildingID)
		{
			if (buildingID >= 0L)
			{
				foreach (VillageClickMask.BuildingClickMask buildingClickMask in this.buildings)
				{
					if (buildingClickMask.buildingID == buildingID)
					{
						buildingClickMask.buildingID = -1L;
						this.mapDirty = true;
					}
				}
			}
		}

		// Token: 0x06002D81 RID: 11649 RVA: 0x0024315C File Offset: 0x0024135C
		public long getBuildingIDFromWorldPos(Point worldPos)
		{
			this.rebuildMap();
			if (worldPos.X >= 0 && worldPos.X < this.mapWidth && worldPos.Y >= 0 && worldPos.Y < this.mapHeight)
			{
				int num = (int)(this.maskMap[worldPos.X, worldPos.Y] - 1);
				if (num >= 0)
				{
					if (this.buildings.Count > 250 && worldPos.Y > this.mapHeight * 3 / 4 && num < 100 && num + 255 < this.buildings.Count)
					{
						num += 255;
					}
					if (num < this.buildings.Count && this.buildings[num] != null)
					{
						return this.buildings[num].buildingID;
					}
				}
			}
			return -1L;
		}

		// Token: 0x06002D82 RID: 11650 RVA: 0x000216B6 File Offset: 0x0001F8B6
		public void forceDirtyMap()
		{
			this.mapDirty = true;
		}

		// Token: 0x06002D83 RID: 11651 RVA: 0x00243244 File Offset: 0x00241444
		private void rebuildMap()
		{
			if (this.mapDirty)
			{
				this.clearMap();
				this.mapDirty = false;
				this.mapClear = false;
				this.buildings.Sort(new Comparison<VillageClickMask.BuildingClickMask>(VillageClickMask.CompareBuildingByYpos));
				int num = 0;
				foreach (VillageClickMask.BuildingClickMask buildingClickMask in this.buildings)
				{
					buildingClickMask.vcmID = num++;
					if (buildingClickMask.buildingID >= 0L && buildingClickMask.buildingID != this.ignoredBuildingID)
					{
						int num2 = 1;
						UVSpriteLoader spriteLoader = this.gfx.getSpriteLoader(buildingClickMask.textureID, ref num2);
						if (spriteLoader != null)
						{
							UVSpriteLoader.MaskImage mask = spriteLoader.getMask(num2, buildingClickMask.spriteNo);
							if (mask != null)
							{
								Rectangle rectangle;
								PointF pointF;
								SizeF sizeF;
								spriteLoader.GetSpriteXYdata(num2, buildingClickMask.spriteNo, out rectangle, out pointF, out sizeF);
								byte b = (byte)(buildingClickMask.vcmID + 1);
								if (buildingClickMask.vcmID >= 255)
								{
									b += 1;
								}
								int num3 = buildingClickMask.x + (int)pointF.X - buildingClickMask.center.X;
								int num4 = buildingClickMask.y + (int)pointF.Y - buildingClickMask.center.Y;
								int width = rectangle.Width;
								int height = rectangle.Height;
								for (int i = 0; i < height; i++)
								{
									if (num4 + i >= 0 && num4 + i < this.mapHeight)
									{
										for (int j = 0; j < width; j++)
										{
											if (num3 + j >= 0 && num3 + j < this.mapWidth && mask.test(j, i))
											{
												this.maskMap[num3 + j, num4 + i] = b;
											}
										}
									}
								}
							}
						}
					}
				}
				if (this.ignoredBuildingID >= 0L)
				{
					this.mapDirty = true;
					this.ignoredBuildingID = -1L;
				}
			}
		}

		// Token: 0x06002D84 RID: 11652 RVA: 0x000216BF File Offset: 0x0001F8BF
		private static int CompareBuildingByYpos(VillageClickMask.BuildingClickMask x, VillageClickMask.BuildingClickMask y)
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
				if (x.y > y.y)
				{
					return 1;
				}
				if (x.y == y.y)
				{
					return 0;
				}
				return -1;
			}
		}

		// Token: 0x0400389D RID: 14493
		private GraphicsMgr gfx;

		// Token: 0x0400389E RID: 14494
		private List<VillageClickMask.BuildingClickMask> buildings = new List<VillageClickMask.BuildingClickMask>();

		// Token: 0x0400389F RID: 14495
		public byte[,] maskMap;

		// Token: 0x040038A0 RID: 14496
		public int mapWidth;

		// Token: 0x040038A1 RID: 14497
		public int mapHeight;

		// Token: 0x040038A2 RID: 14498
		public bool mapDirty;

		// Token: 0x040038A3 RID: 14499
		public bool mapClear = true;

		// Token: 0x040038A4 RID: 14500
		public long ignoredBuildingID = -1L;

		// Token: 0x020004CF RID: 1231
		private class BuildingClickMask
		{
			// Token: 0x040038A5 RID: 14501
			public int vcmID = -1;

			// Token: 0x040038A6 RID: 14502
			public int textureID = -1;

			// Token: 0x040038A7 RID: 14503
			public int spriteNo;

			// Token: 0x040038A8 RID: 14504
			public int x;

			// Token: 0x040038A9 RID: 14505
			public int y;

			// Token: 0x040038AA RID: 14506
			public Point center;

			// Token: 0x040038AB RID: 14507
			public long buildingID;
		}
	}
}
