using System;
using DXGraphics;

namespace Kingdoms
{
	// Token: 0x020000E9 RID: 233
	public class Building
	{
		// Token: 0x06000705 RID: 1797 RVA: 0x0000BC7E File Offset: 0x00009E7E
		public Building(int buildingType, int mapX, int mapY, int UID)
		{
			this.m_type = buildingType;
			this.m_UID = UID;
			this.m_X = mapX;
			this.m_Y = mapY;
			this.sprite = new SpriteWrapper();
		}

		// Token: 0x04000946 RID: 2374
		private int m_type;

		// Token: 0x04000947 RID: 2375
		private int m_UID;

		// Token: 0x04000948 RID: 2376
		private int m_X;

		// Token: 0x04000949 RID: 2377
		private int m_Y;

		// Token: 0x0400094A RID: 2378
		private SpriteWrapper sprite;
	}
}
