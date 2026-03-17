using System;

namespace Kingdoms
{
	// Token: 0x02000131 RID: 305
	public class ClickLock
	{
		// Token: 0x06000B5B RID: 2907 RVA: 0x000E3A04 File Offset: 0x000E1C04
		public bool canCall()
		{
			if (this.inClick && (DateTime.Now - this.lastClick).TotalSeconds < 45.0)
			{
				return false;
			}
			this.inClick = true;
			this.lastClick = DateTime.Now;
			return true;
		}

		// Token: 0x06000B5C RID: 2908 RVA: 0x0000E739 File Offset: 0x0000C939
		public void called()
		{
			this.inClick = false;
		}

		// Token: 0x06000B5D RID: 2909 RVA: 0x000E3A54 File Offset: 0x000E1C54
		public bool IsInCooldown()
		{
			return this.inClick && (DateTime.Now - this.lastClick).TotalSeconds < 45.0;
		}

		// Token: 0x04000F7C RID: 3964
		private DateTime lastClick = DateTime.MinValue;

		// Token: 0x04000F7D RID: 3965
		private bool inClick;
	}
}
