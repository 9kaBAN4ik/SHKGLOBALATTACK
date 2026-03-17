using System;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x02000247 RID: 583
	public class MouseInputState : InputState
	{
		// Token: 0x060019CC RID: 6604 RVA: 0x0019A8AC File Offset: 0x00198AAC
		public override void getInput()
		{
			this.leftdown = GameEngine.Instance.GFX.leftmousedown;
			this.rightdown = GameEngine.Instance.GFX.rightClick;
			this.mousebackward = GameEngine.Instance.GFX.mouseBackward;
			this.mouseforward = GameEngine.Instance.GFX.mouseForward;
			this.mousePos = new Point(Cursor.Position.X, Cursor.Position.Y);
			this.clientMousePos = InterfaceMgr.Instance.ParentForm.PointToClient(this.mousePos);
			this.dxMousePos = InterfaceMgr.Instance.getDXBasePanel().PointToClient(this.mousePos);
			if (!this.mousePos.Equals(GameEngine.Instance.lastMouseMovePosition))
			{
				GameEngine.Instance.lastMouseMovePosition = this.mousePos;
				GameEngine.Instance.lastMouseMoveTime = DateTime.Now;
			}
		}

		// Token: 0x060019CD RID: 6605 RVA: 0x00019F35 File Offset: 0x00018135
		public bool isScrolling()
		{
			return this.scrollLeft || this.scrollRight || this.scrollUp || this.scrollDown;
		}

		// Token: 0x04002A4C RID: 10828
		public bool mousebackward;

		// Token: 0x04002A4D RID: 10829
		public bool mouseforward;

		// Token: 0x04002A4E RID: 10830
		public bool scrollLeft;

		// Token: 0x04002A4F RID: 10831
		public bool scrollRight;

		// Token: 0x04002A50 RID: 10832
		public bool scrollUp;

		// Token: 0x04002A51 RID: 10833
		public bool scrollDown;

		// Token: 0x04002A52 RID: 10834
		public Point clientMousePos;

		// Token: 0x04002A53 RID: 10835
		public Point dxMousePos;
	}
}
