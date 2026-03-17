using System;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x02000200 RID: 512
	public interface IDockableControl
	{
		// Token: 0x06001441 RID: 5185
		void initProperties(bool dockable, string title, ContainerControl parent);

		// Token: 0x06001442 RID: 5186
		void display(ContainerControl parent, int x, int y);

		// Token: 0x06001443 RID: 5187
		void display(bool asPopup, ContainerControl parent, int x, int y);

		// Token: 0x06001444 RID: 5188
		void controlDockToggle();

		// Token: 0x06001445 RID: 5189
		void closeControl(bool includePopups);

		// Token: 0x06001446 RID: 5190
		bool isVisible();

		// Token: 0x06001447 RID: 5191
		bool isPopup();
	}
}
