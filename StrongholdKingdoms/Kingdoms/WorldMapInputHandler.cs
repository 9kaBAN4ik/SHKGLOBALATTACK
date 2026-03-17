using System;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x02000522 RID: 1314
	internal class WorldMapInputHandler : InputHandler
	{
		// Token: 0x06003392 RID: 13202 RVA: 0x00024F55 File Offset: 0x00023155
		public WorldMapInputHandler(WorldMap worldMap)
		{
			this.world = worldMap;
		}

		// Token: 0x06003393 RID: 13203 RVA: 0x002A7344 File Offset: 0x002A5544
		public void handleInput(MouseInputState input)
		{
			if (!input.leftdown && input.isScrolling())
			{
				if (input.scrollLeft)
				{
					this.world.moveMap(0.0 - 10.0 / this.world.WorldScale, 0.0);
				}
				if (input.scrollRight)
				{
					this.world.moveMap(10.0 / this.world.WorldScale, 0.0);
				}
				if (input.scrollUp)
				{
					this.world.moveMap(0.0, 0.0 - 10.0 / this.world.WorldScale);
				}
				if (input.scrollDown)
				{
					this.world.moveMap(0.0, 10.0 / this.world.WorldScale);
				}
			}
			bool flag = InterfaceMgr.Instance.isOverDXScreen(input.dxMousePos);
			if (flag && !input.leftdown)
			{
				this.world.mouseNotDown(input.dxMousePos);
			}
			if (flag || this.world.holdingLeftMouse())
			{
				if (input.leftdown)
				{
					this.world.leftMouseDown(input.dxMousePos);
				}
				else if (input.rightdown)
				{
					this.world.zoomOut();
				}
				else if (input.mousebackward)
				{
					this.world.stopZoom();
					double worldZoom = this.world.WorldZoom;
					if (worldZoom > 26.899999998509884)
					{
						this.world.setMouseWheelZoomOut(14f);
					}
					else if (worldZoom > 13.899999618530273)
					{
						this.world.setMouseWheelZoomOut(9.5f);
					}
					else if (worldZoom > 9.399999618530273)
					{
						this.world.setMouseWheelZoomOut(6.5f);
					}
					else if (worldZoom > 6.400000095367432)
					{
						this.world.setMouseWheelZoomOut(3.5f);
					}
					else if (worldZoom > 3.4000000953674316)
					{
						this.world.setMouseWheelZoomOut(2f);
					}
					else
					{
						this.world.setMouseWheelZoomOut(0f);
					}
				}
				else if (input.mouseforward)
				{
					this.world.stopZoom();
					double worldZoom2 = this.world.WorldZoom;
					if (worldZoom2 < 0.10000000149011612)
					{
						this.world.changeZoom(2f, input.dxMousePos);
					}
					else if (worldZoom2 < 2.0999999046325684)
					{
						this.world.changeZoom(3.5f, input.dxMousePos);
					}
					else if (worldZoom2 < 3.5999999046325684)
					{
						this.world.changeZoom(6.5f, input.dxMousePos);
					}
					else if (worldZoom2 < 6.599999904632568)
					{
						this.world.changeZoom(9.5f, input.dxMousePos);
					}
					else if (worldZoom2 < 9.600000381469727)
					{
						this.world.changeZoom(14f, input.dxMousePos);
					}
					else
					{
						this.world.changeZoom(27f, input.dxMousePos);
					}
					if (worldZoom2 < 26.899999998509884)
					{
						GameEngine.Instance.playInterfaceSound("WorldMap_mousewheel_zoomin");
					}
					this.world.centreMap(false);
				}
				else
				{
					this.world.moveMouse(input.dxMousePos);
				}
				InterfaceMgr.Instance.mouseMoveDXCardBar(input.dxMousePos);
				InterfaceMgr.Instance.mouseMoveDXPlaybackBar(input.dxMousePos);
				GameEngine.Instance.World.freeCardTooltip(input.dxMousePos);
				return;
			}
			if (WorldMapInputHandler.wasOverDXWindow)
			{
				CustomTooltipManager.MouseLeaveTooltipAreaMapSpecial();
			}
			WorldMapInputHandler.wasOverDXWindow = flag;
			if (InterfaceMgr.Instance.ParentForm.Cursor == Cursors.Hand)
			{
				InterfaceMgr.Instance.ParentForm.Cursor = Cursors.Default;
			}
		}

		// Token: 0x0400404F RID: 16463
		private WorldMap world;

		// Token: 0x04004050 RID: 16464
		private static bool wasOverDXWindow;
	}
}
