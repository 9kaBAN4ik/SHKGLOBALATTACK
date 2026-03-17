using System;
using System.Drawing;
using DXGraphics;

namespace Kingdoms
{
	// Token: 0x020004E2 RID: 1250
	public class VillageMapBuildingGranaryExtension
	{
		// Token: 0x06002EC0 RID: 11968 RVA: 0x00258428 File Offset: 0x00256628
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
			case 13:
				num += 80;
				break;
			case 14:
				num += 128;
				break;
			case 15:
				num += 160;
				break;
			case 16:
				num += 112;
				break;
			case 17:
				num += 96;
				break;
			case 18:
				num += 64;
				break;
			}
			this.cell[cellID].Initialize(gfx, GFXLibrary.Instance.Goods2TexID, num);
			PointF center = new PointF(32f, 101f);
			this.cell[cellID].Center = center;
			this.cell[cellID].PosX = posX;
			this.cell[cellID].PosY = posY;
		}

		// Token: 0x06002EC1 RID: 11969 RVA: 0x00258520 File Offset: 0x00256720
		public void colorSprites(Color col)
		{
			for (int i = 0; i < 21; i++)
			{
				if (this.cell[i] != null)
				{
					this.cell[i].ColorToUse = col;
				}
			}
		}

		// Token: 0x06002EC2 RID: 11970 RVA: 0x00258554 File Offset: 0x00256754
		public void dispose()
		{
			for (int i = 0; i < 21; i++)
			{
				this.cell[i] = null;
			}
		}

		// Token: 0x04003A50 RID: 14928
		public const int granaryBaseY = -33;

		// Token: 0x04003A51 RID: 14929
		public const int granaryBaseX = 5;

		// Token: 0x04003A52 RID: 14930
		public SpriteWrapper[] cell = new SpriteWrapper[21];

		// Token: 0x04003A53 RID: 14931
		public static int[] granaryLayout = new int[]
		{
			8,
			28,
			20,
			32,
			-6,
			27,
			-6,
			3,
			-6,
			-21,
			-37,
			40,
			-37,
			23,
			-37,
			6,
			32,
			36,
			41,
			43,
			25,
			39,
			25,
			23,
			25,
			7,
			-5,
			50,
			-5,
			28,
			-16,
			54,
			-16,
			24,
			11,
			58,
			11,
			36,
			0,
			62,
			0,
			32
		};
	}
}
