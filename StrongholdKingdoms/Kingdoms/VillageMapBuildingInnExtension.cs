using System;
using System.Drawing;
using DXGraphics;

namespace Kingdoms
{
	// Token: 0x020004E3 RID: 1251
	public class VillageMapBuildingInnExtension
	{
		// Token: 0x06002EC5 RID: 11973 RVA: 0x00258578 File Offset: 0x00256778
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
			num += 192;
			this.cell[cellID].Initialize(gfx, GFXLibrary.Instance.Goods1TexID, num);
			PointF center = new PointF(32f, 101f);
			this.cell[cellID].Center = center;
			this.cell[cellID].PosX = posX;
			this.cell[cellID].PosY = posY;
		}

		// Token: 0x06002EC6 RID: 11974 RVA: 0x00258628 File Offset: 0x00256828
		public void colorSprites(Color col)
		{
			for (int i = 0; i < 3; i++)
			{
				if (this.cell[i] != null)
				{
					this.cell[i].ColorToUse = col;
				}
			}
		}

		// Token: 0x06002EC7 RID: 11975 RVA: 0x0025865C File Offset: 0x0025685C
		public void dispose()
		{
			for (int i = 0; i < 3; i++)
			{
				this.cell[i] = null;
			}
		}

		// Token: 0x04003A54 RID: 14932
		public const int numPilesAtInn = 3;

		// Token: 0x04003A55 RID: 14933
		public const int innBaseY = -44;

		// Token: 0x04003A56 RID: 14934
		public const int innBaseX = -80;

		// Token: 0x04003A57 RID: 14935
		public SpriteWrapper[] cell = new SpriteWrapper[3];

		// Token: 0x04003A58 RID: 14936
		public static int[] innLayout = new int[]
		{
			160,
			64,
			128,
			80,
			96,
			96
		};
	}
}
