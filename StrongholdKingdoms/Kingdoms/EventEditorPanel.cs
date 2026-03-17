using System;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x020001AA RID: 426
	public class EventEditorPanel : UserControl, IDockableControl
	{
		// Token: 0x0600103C RID: 4156 RVA: 0x00011EB1 File Offset: 0x000100B1
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x0600103D RID: 4157 RVA: 0x00011EC1 File Offset: 0x000100C1
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x0600103E RID: 4158 RVA: 0x00011ED1 File Offset: 0x000100D1
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x0600103F RID: 4159 RVA: 0x00011EE3 File Offset: 0x000100E3
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06001040 RID: 4160 RVA: 0x00011EF0 File Offset: 0x000100F0
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x06001041 RID: 4161 RVA: 0x00011EFE File Offset: 0x000100FE
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06001042 RID: 4162 RVA: 0x00011F0B File Offset: 0x0001010B
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x04001663 RID: 5731
		private DockableControl dockableControl;
	}
}
