using System;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x02000201 RID: 513
	public interface IDockWindow
	{
		// Token: 0x06001448 RID: 5192
		void AddControl(UserControl control, int x, int y);

		// Token: 0x06001449 RID: 5193
		void RemoveControl(UserControl control);
	}
}
