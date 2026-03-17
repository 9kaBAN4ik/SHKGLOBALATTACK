using System;
using System.Text;
using Kingdoms;

namespace Upgrade
{
	// Token: 0x02000011 RID: 17
	public class Attacker
	{
		// Token: 0x06000028 RID: 40 RVA: 0x00027378 File Offset: 0x00025578
		public static string CsvHeaderString()
		{
			StringBuilder stringBuilder = new StringBuilder("Id\tName\tType\tDistance\tTotal Army seconds\tTotal Captain seconds");
			for (int i = 1; i <= 6; i++)
			{
				stringBuilder.Append(string.Format("\tx{0} ArmyTime\tx{1} CaptainTime", i, i));
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000273C0 File Offset: 0x000255C0
		public string DivideTimeSpan(TimeSpan normalTime, int speedMultiplier)
		{
			long value = normalTime.Ticks / (long)speedMultiplier;
			return VillageMap.createBuildTimeString((int)TimeSpan.FromTicks(value).TotalSeconds);
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000273EC File Offset: 0x000255EC
		public string ToCsvString()
		{
			StringBuilder stringBuilder = new StringBuilder(string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", new object[]
			{
				this.Id,
				this.Name,
				this.Type,
				(int)this.Distance,
				this.TotalArmySeconds,
				this.TotalCaptSeconds
			}));
			for (int i = 1; i <= 6; i++)
			{
				stringBuilder.Append("\t" + this.DivideTimeSpan(this.ArmyTime, i) + "\t" + this.DivideTimeSpan(this.CaptainTime, i));
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0400005A RID: 90
		public int Id;

		// Token: 0x0400005B RID: 91
		public string Name;

		// Token: 0x0400005C RID: 92
		public double Distance;

		// Token: 0x0400005D RID: 93
		public int TotalArmySeconds;

		// Token: 0x0400005E RID: 94
		public int TotalCaptSeconds;

		// Token: 0x0400005F RID: 95
		public TimeSpan ArmyTime;

		// Token: 0x04000060 RID: 96
		public TimeSpan CaptainTime;

		// Token: 0x04000061 RID: 97
		public TimeSpan CapitalTime;

		// Token: 0x04000062 RID: 98
		public AttackerType Type;

		// Token: 0x04000063 RID: 99
		private const int MaxSpeedMultiplier = 6;
	}
}
