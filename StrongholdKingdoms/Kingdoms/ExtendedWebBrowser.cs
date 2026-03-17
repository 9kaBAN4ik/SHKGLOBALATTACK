using System;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x020001AB RID: 427
	public class ExtendedWebBrowser : WebBrowser
	{
		// Token: 0x06001044 RID: 4164 RVA: 0x0011B020 File Offset: 0x00119220
		protected override void WndProc(ref Message m)
		{
			int msg = m.Msg;
			if (msg == 528)
			{
				try
				{
					if (!base.DesignMode && m.WParam.ToInt32() == 2)
					{
						m.Msg = 2;
						((Form)base.Parent).Close();
					}
				}
				catch (Exception)
				{
				}
				this.DefWndProc(ref m);
				return;
			}
			base.WndProc(ref m);
		}

		// Token: 0x04001664 RID: 5732
		private const int WM_PARENTNOTIFY = 528;

		// Token: 0x04001665 RID: 5733
		private const int WM_DESTROY = 2;
	}
}
