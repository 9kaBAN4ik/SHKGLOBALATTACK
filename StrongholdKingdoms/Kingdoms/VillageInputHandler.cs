using System;
using System.Drawing;

namespace Kingdoms
{
	// Token: 0x020004D3 RID: 1235
	internal class VillageInputHandler : InputHandler
	{
		// Token: 0x06002D9B RID: 11675 RVA: 0x00021802 File Offset: 0x0001FA02
		public VillageInputHandler(VillageMap villagemap)
		{
			this.village = villagemap;
		}

		// Token: 0x06002D9C RID: 11676 RVA: 0x0024422C File Offset: 0x0024242C
		public void handleInput(MouseInputState input)
		{
			if (this.village == null)
			{
				return;
			}
			if (!input.leftdown && input.isScrolling())
			{
				if (input.scrollLeft)
				{
					this.village.Camera.Drag(new Point(10, 0));
				}
				if (input.scrollRight)
				{
					this.village.Camera.Drag(new Point(-10, 0));
				}
				if (input.scrollUp)
				{
					this.village.Camera.Drag(new Point(0, 10));
				}
				if (input.scrollDown)
				{
					this.village.Camera.Drag(new Point(0, -10));
				}
			}
			if (!input.leftdown)
			{
				this.village.mouseNotClicked(input.dxMousePos);
			}
			bool flag = InterfaceMgr.Instance.isOverDXScreen(input.dxMousePos);
			if (flag || this.village.holdingLeftMouse())
			{
				this.village.mouseMoveUpdate(input.dxMousePos, input.leftdown);
			}
			else if (VillageInputHandler.wasOverDXWindow)
			{
				CustomTooltipManager.MouseLeaveTooltipAreaMapSpecial();
			}
			VillageInputHandler.wasOverDXWindow = flag;
			if (input.rightdown)
			{
				this.village.stopPlaceBuilding(true);
			}
		}

		// Token: 0x040038DB RID: 14555
		private VillageMap village;

		// Token: 0x040038DC RID: 14556
		private static bool wasOverDXWindow;
	}
}
