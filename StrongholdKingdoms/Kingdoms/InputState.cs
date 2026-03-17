using System;
using System.Drawing;

namespace Kingdoms
{
	// Token: 0x02000206 RID: 518
	public abstract class InputState
	{
		// Token: 0x0600144F RID: 5199
		public abstract void getInput();

		// Token: 0x040025E4 RID: 9700
		public bool leftdown;

		// Token: 0x040025E5 RID: 9701
		public bool rightdown;

		// Token: 0x040025E6 RID: 9702
		public Point mousePos;

		// Token: 0x040025E7 RID: 9703
		public int TouchCount;
	}
}
