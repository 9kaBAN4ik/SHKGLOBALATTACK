using System;
using System.Collections;

namespace Kingdoms
{
	// Token: 0x020000EA RID: 234
	public class BuildingMgr
	{
		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000706 RID: 1798 RVA: 0x0000BCAE File Offset: 0x00009EAE
		public static BuildingMgr Instance
		{
			get
			{
				return BuildingMgr.instance;
			}
		}

		// Token: 0x06000707 RID: 1799 RVA: 0x0000BCB5 File Offset: 0x00009EB5
		private BuildingMgr()
		{
		}

		// Token: 0x06000708 RID: 1800 RVA: 0x000904DC File Offset: 0x0008E6DC
		public void AddBuilding(int buildingType, int mapX, int mapY)
		{
			Building value = new Building(buildingType, mapX, mapY, this.buildingUID);
			this.buildingList.Add(value);
			this.buildingUID++;
		}

		// Token: 0x0400094B RID: 2379
		private static readonly BuildingMgr instance = new BuildingMgr();

		// Token: 0x0400094C RID: 2380
		private ArrayList buildingList = new ArrayList();

		// Token: 0x0400094D RID: 2381
		private int buildingUID;
	}
}
