using System;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x02000159 RID: 345
	public class CursorManager
	{
		// Token: 0x06000CEF RID: 3311 RVA: 0x000F6378 File Offset: 0x000F4578
		public static void SetCursor(CursorManager.CursorType type, Form ParentForm)
		{
			if (ParentForm != null)
			{
				switch (type)
				{
				case CursorManager.CursorType.WaitCursor:
					ParentForm.Cursor = Cursors.WaitCursor;
					break;
				case CursorManager.CursorType.Default:
					ParentForm.Cursor = Cursors.Default;
					break;
				case CursorManager.CursorType.Hand:
					ParentForm.Cursor = Cursors.Hand;
					break;
				case CursorManager.CursorType.SizeWE:
					ParentForm.Cursor = Cursors.SizeWE;
					break;
				case CursorManager.CursorType.Cross:
					ParentForm.Cursor = Cursors.Cross;
					break;
				case CursorManager.CursorType.VSplit:
					ParentForm.Cursor = Cursors.VSplit;
					break;
				}
				CursorManager.CurrentCursor = type;
			}
		}

		// Token: 0x0400113D RID: 4413
		public static CursorManager.CursorType CurrentCursor = CursorManager.CursorType.Default;

		// Token: 0x0200015A RID: 346
		public enum CursorType
		{
			// Token: 0x0400113F RID: 4415
			WaitCursor,
			// Token: 0x04001140 RID: 4416
			Default,
			// Token: 0x04001141 RID: 4417
			Hand,
			// Token: 0x04001142 RID: 4418
			SizeWE,
			// Token: 0x04001143 RID: 4419
			Cross,
			// Token: 0x04001144 RID: 4420
			VSplit
		}
	}
}
