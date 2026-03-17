using System;
using System.Collections.Generic;
using System.Linq;

namespace Upgrade.Services
{
	// Token: 0x02000040 RID: 64
	public class MonkRoute
	{
		// Token: 0x06000246 RID: 582 RVA: 0x00048F30 File Offset: 0x00047130
		public MonkRoute(string name, bool enabled, IEnumerable<int> from, IEnumerable<int> to, int command, int stopConditionType, int extraParameter, Dictionary<int, int> currentProgress, bool isDistanceLimited, int distanceLimit)
		{
			this.Name = name;
			this.Enabled = enabled;
			this.From = from;
			this.To = to;
			this.Command = command;
			this.StopConditionType = stopConditionType;
			this.ExtraParameter = extraParameter;
			this.CurrentProgress = currentProgress;
			this.SortedRecipients = new Dictionary<int, IEnumerable<int>>();
			this.IsDistanceLimited = isDistanceLimited;
			this.DistanceLimit = distanceLimit;
			this.UpdateCurrentProgress();
		}

		// Token: 0x06000247 RID: 583 RVA: 0x00048FA4 File Offset: 0x000471A4
		private void UpdateCurrentProgress()
		{
			if (this.CurrentProgress == null)
			{
				this.CurrentProgress = new Dictionary<int, int>();
				using (IEnumerator<int> enumerator = this.To.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						int key = enumerator.Current;
						this.CurrentProgress.Add(key, 0);
					}
					return;
				}
			}
			foreach (int key2 in this.To)
			{
				if (!this.CurrentProgress.ContainsKey(key2))
				{
					this.CurrentProgress.Add(key2, 0);
				}
			}
			List<int> list = (from k in this.CurrentProgress.Keys
			where !this.To.Contains(k)
			select k).ToList<int>();
			foreach (int key3 in list)
			{
				this.CurrentProgress.Remove(key3);
			}
		}

		// Token: 0x040003C1 RID: 961
		public string Name;

		// Token: 0x040003C2 RID: 962
		public bool Enabled;

		// Token: 0x040003C3 RID: 963
		public IEnumerable<int> From;

		// Token: 0x040003C4 RID: 964
		public IEnumerable<int> To;

		// Token: 0x040003C5 RID: 965
		public Dictionary<int, IEnumerable<int>> SortedRecipients;

		// Token: 0x040003C6 RID: 966
		public int Command;

		// Token: 0x040003C7 RID: 967
		public int StopConditionType;

		// Token: 0x040003C8 RID: 968
		public int ExtraParameter;

		// Token: 0x040003C9 RID: 969
		public Dictionary<int, int> CurrentProgress;

		// Token: 0x040003CA RID: 970
		public bool IsDistanceLimited;

		// Token: 0x040003CB RID: 971
		public int DistanceLimit;
	}
}
