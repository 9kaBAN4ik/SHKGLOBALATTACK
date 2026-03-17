using System;

namespace Upgrade.Services
{
	// Token: 0x02000084 RID: 132
	internal class PredatorPrey
	{
		// Token: 0x06000399 RID: 921 RVA: 0x00009C1F File Offset: 0x00007E1F
		public PredatorPrey(int id, int typeId, double distance, int parentOfNextTo, int nextTo)
		{
			this.Id = id;
			this.TypeId = typeId;
			this.Distance = distance;
			this.ParentOfNextTo = parentOfNextTo;
			this.NextTo = nextTo;
		}

		// Token: 0x040004D6 RID: 1238
		public int Id;

		// Token: 0x040004D7 RID: 1239
		public int TypeId;

		// Token: 0x040004D8 RID: 1240
		public double Distance;

		// Token: 0x040004D9 RID: 1241
		public int ParentOfNextTo;

		// Token: 0x040004DA RID: 1242
		public int NextTo;

		// Token: 0x040004DB RID: 1243
		public bool Attacked;
	}
}
