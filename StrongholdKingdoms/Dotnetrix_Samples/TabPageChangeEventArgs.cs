using System;
using System.Windows.Forms;

namespace Dotnetrix_Samples
{
	// Token: 0x02000538 RID: 1336
	public class TabPageChangeEventArgs : EventArgs
	{
		// Token: 0x170006B9 RID: 1721
		// (get) Token: 0x0600380A RID: 14346 RVA: 0x000255C9 File Offset: 0x000237C9
		public TabPage CurrentTab
		{
			get
			{
				return this._Selected;
			}
		}

		// Token: 0x170006BA RID: 1722
		// (get) Token: 0x0600380B RID: 14347 RVA: 0x000255D1 File Offset: 0x000237D1
		public TabPage NextTab
		{
			get
			{
				return this._PreSelected;
			}
		}

		// Token: 0x0600380C RID: 14348 RVA: 0x000255D9 File Offset: 0x000237D9
		public TabPageChangeEventArgs(TabPage CurrentTab, TabPage NextTab)
		{
			this._Selected = CurrentTab;
			this._PreSelected = NextTab;
		}

		// Token: 0x04004121 RID: 16673
		private TabPage _Selected;

		// Token: 0x04004122 RID: 16674
		private TabPage _PreSelected;

		// Token: 0x04004123 RID: 16675
		public bool Cancel;
	}
}
