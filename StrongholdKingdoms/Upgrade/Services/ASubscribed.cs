using System;
using System.Threading;

namespace Upgrade.Services
{
	// Token: 0x02000037 RID: 55
	public abstract class ASubscribed
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600020A RID: 522 RVA: 0x00009133 File Offset: 0x00007333
		// (set) Token: 0x0600020B RID: 523 RVA: 0x0000913B File Offset: 0x0000733B
		public bool IsSubscribed
		{
			get
			{
				return this._isSubscribed;
			}
			set
			{
				this._isSubscribed = value;
				this.ModuleSleep.Set();
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600020C RID: 524 RVA: 0x00009150 File Offset: 0x00007350
		// (set) Token: 0x0600020D RID: 525 RVA: 0x00009158 File Offset: 0x00007358
		public bool Enabled
		{
			get
			{
				return this._enabled;
			}
			set
			{
				this._enabled = value;
				this.ModuleSleep.Set();
			}
		}

		// Token: 0x0600020E RID: 526 RVA: 0x0000916D File Offset: 0x0000736D
		internal bool RandomSleepOrExit(int minMiliSeconds, int maxMiliSeconds)
		{
			return this.Exiting.WaitOne(ASubscribed._random.Next(minMiliSeconds, maxMiliSeconds)) || !this.Enabled;
		}

		// Token: 0x0600020F RID: 527 RVA: 0x00009193 File Offset: 0x00007393
		internal bool SleepOrExit(int miliSeconds)
		{
			return this.Exiting.WaitOne(miliSeconds) || !this.Enabled;
		}

		// Token: 0x06000210 RID: 528
		internal abstract void TranslateUI();

		// Token: 0x040003A2 RID: 930
		private bool _isSubscribed;

		// Token: 0x040003A3 RID: 931
		private bool _enabled;

		// Token: 0x040003A4 RID: 932
		public AutoResetEvent ModuleSleep = new AutoResetEvent(false);

		// Token: 0x040003A5 RID: 933
		public ManualResetEvent Exiting = new ManualResetEvent(false);

		// Token: 0x040003A6 RID: 934
		internal static Random _random = new Random();
	}
}
