using System;

namespace Kingdoms
{
	// Token: 0x0200012B RID: 299
	internal class CastleMouseInputHandler
	{
		// Token: 0x06000B07 RID: 2823 RVA: 0x0000E355 File Offset: 0x0000C555
		public CastleMouseInputHandler(CastleMap castlemap, GameEngine.GameDisplaySubModes castleSubMode)
		{
			this.castle = castlemap;
			this.gameDisplayModeSubMode = castleSubMode;
		}

		// Token: 0x06000B08 RID: 2824 RVA: 0x000DF620 File Offset: 0x000DD820
		public void handleInput(MouseInputState input)
		{
			if (this.castle == null)
			{
				return;
			}
			if (input.leftdown && input.isScrolling())
			{
				if (input.scrollLeft)
				{
					this.castle.moveMap(10, 0);
				}
				if (input.scrollRight)
				{
					this.castle.moveMap(-10, 0);
				}
				if (input.scrollUp)
				{
					this.castle.moveMap(0, 10);
				}
				if (input.scrollDown)
				{
					this.castle.moveMap(0, -10);
				}
			}
			if (!input.leftdown)
			{
				this.castle.mouseNotClicked(input.dxMousePos);
			}
			bool flag = InterfaceMgr.Instance.isOverDXScreen(input.dxMousePos);
			if (flag || this.castle.holdingLeftMouse())
			{
				if (input.rightdown)
				{
					this.castle.rightClick(input.dxMousePos);
				}
				else
				{
					this.castle.mouseMoveUpdate(input.dxMousePos, input.leftdown);
				}
			}
			else if (CastleMouseInputHandler.wasOverDXWindow)
			{
				CustomTooltipManager.MouseLeaveTooltipAreaMapSpecial();
			}
			CastleMouseInputHandler.wasOverDXWindow = flag;
			if ((input.mousebackward || input.mouseforward || GameEngine.Instance.GFX.keyCode == 32) && this.gameDisplayModeSubMode == GameEngine.GameDisplaySubModes.SUBMODE_DEFAULT)
			{
				this.castle.mouseWheel();
			}
		}

		// Token: 0x04000F47 RID: 3911
		private CastleMap castle;

		// Token: 0x04000F48 RID: 3912
		private GameEngine.GameDisplaySubModes gameDisplayModeSubMode;

		// Token: 0x04000F49 RID: 3913
		private static bool wasOverDXWindow;
	}
}
