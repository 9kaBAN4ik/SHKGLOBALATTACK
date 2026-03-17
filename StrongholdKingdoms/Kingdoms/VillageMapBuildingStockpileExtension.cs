using System;
using System.Drawing;
using DXGraphics;

namespace Kingdoms
{
	// Token: 0x020004E4 RID: 1252
	public class VillageMapBuildingStockpileExtension
	{
		// Token: 0x06002ECA RID: 11978 RVA: 0x00258680 File Offset: 0x00256880
		public void showGood(GraphicsMgr gfx, int cellID, int buildingType, int level)
		{
			if (buildingType < 0 || level == 0)
			{
				this.cell[cellID].Visible = false;
				return;
			}
			this.cell[cellID].Visible = true;
			float posX = this.cell[cellID].PosX;
			float posY = this.cell[cellID].PosY;
			int num = level - 1;
			switch (buildingType)
			{
			case 6:
				num += 144;
				break;
			case 7:
				num += 224;
				break;
			case 8:
				num += 48;
				break;
			case 9:
				num += 208;
				break;
			}
			this.cell[cellID].Initialize(gfx, GFXLibrary.Instance.Goods1TexID, num);
			PointF center = new PointF(32f, 101f);
			this.cell[cellID].Center = center;
			this.cell[cellID].PosX = posX;
			this.cell[cellID].PosY = posY;
		}

		// Token: 0x06002ECB RID: 11979 RVA: 0x00258764 File Offset: 0x00256964
		public void colorSprites(Color col)
		{
			for (int i = 0; i < 16; i++)
			{
				if (this.cell[i] != null)
				{
					this.cell[i].ColorToUse = col;
				}
			}
		}

		// Token: 0x06002ECC RID: 11980 RVA: 0x00258798 File Offset: 0x00256998
		public void dispose()
		{
			for (int i = 0; i < 16; i++)
			{
				this.cell[i] = null;
			}
		}

		// Token: 0x04003A59 RID: 14937
		public const int stockpileBaseY = -43;

		// Token: 0x04003A5A RID: 14938
		public const int stockpileBaseX = -96;

		// Token: 0x04003A5B RID: 14939
		public SpriteWrapper[] cell = new SpriteWrapper[16];

		// Token: 0x04003A5C RID: 14940
		public static int[] stockpileLayout = new int[]
		{
			96,
			0,
			64,
			16,
			128,
			16,
			32,
			32,
			96,
			32,
			160,
			32,
			0,
			48,
			64,
			48,
			128,
			48,
			192,
			48,
			32,
			64,
			96,
			64,
			160,
			64,
			64,
			80,
			128,
			80,
			96,
			96
		};
	}
}
