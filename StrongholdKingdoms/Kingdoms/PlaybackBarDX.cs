using System;
using System.Drawing;

namespace Kingdoms
{
	// Token: 0x02000274 RID: 628
	internal class PlaybackBarDX
	{
		// Token: 0x06001BF8 RID: 7160 RVA: 0x001B383C File Offset: 0x001B1A3C
		public void init()
		{
			this.awaitingInit = false;
			this.csd.clearControls();
			this.csd.addControl(this.GDIBar);
			this.GDIBar.init();
			this.GDIBar.isDirty = true;
			this.update();
		}

		// Token: 0x06001BF9 RID: 7161 RVA: 0x0001BADD File Offset: 0x00019CDD
		public void delayedInit()
		{
			this.awaitingInit = true;
		}

		// Token: 0x06001BFA RID: 7162 RVA: 0x001B388C File Offset: 0x001B1A8C
		public void update()
		{
			if (!InterfaceMgr.Instance.allowDrawCircles())
			{
				return;
			}
			if (this.awaitingInit)
			{
				this.init();
				return;
			}
			this.GDIBar.update();
			if (!this.GDIBar.isDirty)
			{
				return;
			}
			Graphics graphics = GameEngine.Instance.GFX.createDXPlaybackTexture(this.GDIBar.Size, new Point(GameEngine.Instance.World.m_screenWidth / 2 - this.GDIBar.Size.Width / 2, GameEngine.Instance.World.m_screenHeight - this.GDIBar.Size.Height));
			if (graphics != null)
			{
				if (this.csd.initFromDX(graphics, this.GDIBar))
				{
					this.csd.drawControls();
					this.csd.endPaint();
				}
				GameEngine.Instance.GFX.renderDXPlaybackTexture(graphics);
			}
			this.GDIBar.flagAsRendered();
		}

		// Token: 0x06001BFB RID: 7163 RVA: 0x001B3980 File Offset: 0x001B1B80
		public bool click(Point mousePos)
		{
			if (!GameEngine.Instance.GFX.drawPlaybackTexture)
			{
				return false;
			}
			Point mousePos2 = mousePos;
			mousePos2.X -= GameEngine.Instance.GFX.pbLocation.X;
			mousePos2.Y -= GameEngine.Instance.GFX.pbLocation.Y;
			return this.csd.baseControl.parentClicked(mousePos2);
		}

		// Token: 0x06001BFC RID: 7164 RVA: 0x001B39F8 File Offset: 0x001B1BF8
		public bool mouseUp(Point mousePos)
		{
			if (!GameEngine.Instance.GFX.drawPlaybackTexture)
			{
				return false;
			}
			Point mousePos2 = mousePos;
			mousePos2.X -= GameEngine.Instance.GFX.pbLocation.X;
			mousePos2.Y -= GameEngine.Instance.GFX.pbLocation.Y;
			return this.csd.baseControl.parentMouseUp(mousePos2) != null;
		}

		// Token: 0x06001BFD RID: 7165 RVA: 0x001B3A74 File Offset: 0x001B1C74
		public bool mouseDown(Point mousePos)
		{
			if (!GameEngine.Instance.GFX.drawPlaybackTexture)
			{
				return false;
			}
			Point mousePos2 = mousePos;
			mousePos2.X -= GameEngine.Instance.GFX.pbLocation.X;
			mousePos2.Y -= GameEngine.Instance.GFX.pbLocation.Y;
			return this.csd.baseControl.parentMouseDown(mousePos2) != null;
		}

		// Token: 0x06001BFE RID: 7166 RVA: 0x0001BAE6 File Offset: 0x00019CE6
		public void toggleEnabled(bool value)
		{
			this.GDIBar.toggleActive(value);
		}

		// Token: 0x06001BFF RID: 7167 RVA: 0x001B3AF0 File Offset: 0x001B1CF0
		public void mouseMove(Point mousePos)
		{
			if (GameEngine.Instance.GFX.drawPlaybackTexture)
			{
				Point point = mousePos;
				point.X -= GameEngine.Instance.GFX.pbLocation.X;
				point.Y -= GameEngine.Instance.GFX.pbLocation.Y;
				this.csd.tooltipSet = false;
				CustomTooltipManager.MouseLeaveTooltipArea();
				this.csd.baseControl.parentMouseOver(point);
				this.GDIBar.setMouseRelative(point);
			}
		}

		// Token: 0x04002CD9 RID: 11481
		private PlaybackBarGDI GDIBar = new PlaybackBarGDI();

		// Token: 0x04002CDA RID: 11482
		private CustomSelfDrawPanel csd = new CustomSelfDrawPanel();

		// Token: 0x04002CDB RID: 11483
		private bool awaitingInit;
	}
}
