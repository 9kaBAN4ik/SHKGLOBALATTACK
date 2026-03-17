using System;
using System.Drawing;
using DXGraphics;

namespace Kingdoms.GameWorld.CameraControllers
{
	// Token: 0x02000529 RID: 1321
	internal class VillageCameraWinforms : ICameraController
	{
		// Token: 0x060033FB RID: 13307 RVA: 0x0002539F File Offset: 0x0002359F
		public VillageCameraWinforms(SpriteWrapper backgroundSprite)
		{
			this.m_backgroundSprite = backgroundSprite;
		}

		// Token: 0x060033FC RID: 13308 RVA: 0x002AE450 File Offset: 0x002AC650
		public Rectangle GetCameraRectangle()
		{
			Point point = this.ScreenToWorldSpace(new Point(0, 0));
			return new Rectangle(point.X, point.Y, GameEngine.Instance.GFX.ViewportWidth, GameEngine.Instance.GFX.ViewportHeight);
		}

		// Token: 0x060033FD RID: 13309 RVA: 0x002AE49C File Offset: 0x002AC69C
		public Point getCameraCentre()
		{
			Point point = this.ScreenToWorldSpace(new Point(0, 0));
			return new Point(point.X + GameEngine.Instance.GFX.ViewportWidth / 2, point.Y + GameEngine.Instance.GFX.ViewportHeight / 2);
		}

		// Token: 0x060033FE RID: 13310 RVA: 0x000253AE File Offset: 0x000235AE
		public void MoveToPosition(Point position)
		{
			this.m_backgroundSprite.PosX = (float)position.X;
			this.m_backgroundSprite.PosY = (float)position.Y;
			this.Drag(new Point(0, 0));
		}

		// Token: 0x060033FF RID: 13311 RVA: 0x002AE4F0 File Offset: 0x002AC6F0
		public void Drag(Point delta)
		{
			if (this.m_backgroundSprite != null)
			{
				this.m_backgroundSprite.move(delta.X, delta.Y);
				this.m_backgroundSprite.keepBounded();
				this.m_backgroundSprite.centreSmallerSprite();
				this.m_backgroundSprite.fixup2DPos();
			}
		}

		// Token: 0x06003400 RID: 13312 RVA: 0x0000D34B File Offset: 0x0000B54B
		public void ChangeZoom(float delta)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06003401 RID: 13313 RVA: 0x002AE540 File Offset: 0x002AC740
		public Point ScreenToWorldSpace(Point point)
		{
			point.X -= (int)this.m_backgroundSprite.DrawPos.X;
			point.Y -= (int)this.m_backgroundSprite.DrawPos.Y;
			return point;
		}

		// Token: 0x06003402 RID: 13314 RVA: 0x002AE594 File Offset: 0x002AC794
		public Point WorldToScreenSpace(Point point)
		{
			point.X += (int)this.m_backgroundSprite.DrawPos.X;
			point.Y += (int)this.m_backgroundSprite.DrawPos.Y;
			return point;
		}

		// Token: 0x06003403 RID: 13315 RVA: 0x002AE5E8 File Offset: 0x002AC7E8
		public Point WorldSpaceToMapTile(Point worldPos)
		{
			worldPos.X += 16;
			worldPos.Y += 8;
			worldPos.X /= 32;
			worldPos.Y /= 16;
			return worldPos;
		}

		// Token: 0x06003404 RID: 13316 RVA: 0x002AE638 File Offset: 0x002AC838
		public Point MapTileToWorldSpace(Point mapTile)
		{
			Point result = default(Point);
			result.X = mapTile.X * 32;
			result.Y = mapTile.Y * 16;
			result.X -= 16;
			result.Y -= 8;
			return result;
		}

		// Token: 0x06003405 RID: 13317 RVA: 0x002AE690 File Offset: 0x002AC890
		public Point ScreenSpaceToMapTile(Point point)
		{
			Point worldPos = this.ScreenToWorldSpace(point);
			return this.WorldSpaceToMapTile(worldPos);
		}

		// Token: 0x06003406 RID: 13318 RVA: 0x002AE6AC File Offset: 0x002AC8AC
		public Point MapTileToScreenSpace(Point mapTile)
		{
			Point point = this.MapTileToWorldSpace(mapTile);
			return this.WorldToScreenSpace(point);
		}

		// Token: 0x040040FF RID: 16639
		private SpriteWrapper m_backgroundSprite;
	}
}
