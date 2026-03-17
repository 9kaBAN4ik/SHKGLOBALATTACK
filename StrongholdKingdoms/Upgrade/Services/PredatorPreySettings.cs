using System;

namespace Upgrade.Services
{
	// Token: 0x02000083 RID: 131
	internal class PredatorPreySettings
	{
		// Token: 0x06000396 RID: 918 RVA: 0x00054040 File Offset: 0x00052240
		public PredatorPreySettings(int typeId, string typeName, bool hunt, int maxDistance, int maxSquareDistance, bool includeVassalHonourRange, bool includeCapitalHonourRange, bool notifyWithMessage, bool notifyWithSound, bool kill, string formation)
		{
			this.TypeId = typeId;
			this.TypeName = typeName;
			this.Hunt = hunt;
			this.MaxDistance = maxDistance;
			this.MaxSquareDistance = maxSquareDistance;
			this.IncludeVassalHonourRange = includeVassalHonourRange;
			this.IncludeCapitalHonourRange = includeCapitalHonourRange;
			this.NotifyWithMessage = notifyWithMessage;
			this.NotifyWithSound = notifyWithSound;
			this.Kill = kill;
			this.Formation = formation;
		}

		// Token: 0x06000397 RID: 919 RVA: 0x000540A8 File Offset: 0x000522A8
		public void SetValue(int property, bool value)
		{
			switch (property)
			{
			case 2:
				this.Hunt = value;
				return;
			case 3:
				break;
			case 4:
				this.IncludeVassalHonourRange = value;
				return;
			case 5:
				this.IncludeCapitalHonourRange = value;
				return;
			case 6:
				this.NotifyWithMessage = value;
				return;
			case 7:
				this.NotifyWithSound = value;
				return;
			case 8:
				this.Kill = value;
				break;
			default:
				return;
			}
		}

		// Token: 0x06000398 RID: 920 RVA: 0x0005410C File Offset: 0x0005230C
		public object[] GetParams()
		{
			return new object[]
			{
				this.TypeId,
				this.TypeName,
				this.Hunt,
				this.MaxDistance,
				this.IncludeVassalHonourRange,
				this.IncludeCapitalHonourRange,
				this.NotifyWithMessage,
				this.NotifyWithSound,
				this.Kill,
				this.Formation
			};
		}

		// Token: 0x040004CB RID: 1227
		public int TypeId;

		// Token: 0x040004CC RID: 1228
		public string TypeName;

		// Token: 0x040004CD RID: 1229
		public bool Hunt;

		// Token: 0x040004CE RID: 1230
		public int MaxDistance;

		// Token: 0x040004CF RID: 1231
		public int MaxSquareDistance;

		// Token: 0x040004D0 RID: 1232
		public bool IncludeVassalHonourRange;

		// Token: 0x040004D1 RID: 1233
		public bool IncludeCapitalHonourRange;

		// Token: 0x040004D2 RID: 1234
		public bool NotifyWithMessage;

		// Token: 0x040004D3 RID: 1235
		public bool NotifyWithSound;

		// Token: 0x040004D4 RID: 1236
		public bool Kill;

		// Token: 0x040004D5 RID: 1237
		public string Formation;
	}
}
