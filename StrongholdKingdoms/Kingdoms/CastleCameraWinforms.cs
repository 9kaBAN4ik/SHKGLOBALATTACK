using System;
using System.Drawing;
using DXGraphics;

namespace Kingdoms
{
	// Token: 0x02000112 RID: 274
	public class CastleCameraWinforms : ICameraController
	{
		// Token: 0x060008E4 RID: 2276 RVA: 0x0000D307 File Offset: 0x0000B507
		public CastleCameraWinforms(SpriteWrapper backgroundSprite)
		{
			this.m_backgroundSprite = backgroundSprite;
		}

		// Token: 0x060008E5 RID: 2277 RVA: 0x000BA0B4 File Offset: 0x000B82B4
		public Rectangle GetCameraRectangle()
		{
			Point point = this.ScreenToWorldSpace(new Point(0, 0));
			return new Rectangle(point.X, point.Y, GameEngine.Instance.GFX.ViewportWidth, GameEngine.Instance.GFX.ViewportHeight);
		}

		// Token: 0x060008E6 RID: 2278 RVA: 0x000BA100 File Offset: 0x000B8300
		public Point getCameraCentre()
		{
			Point point = this.ScreenToWorldSpace(new Point(0, 0));
			return new Point(point.X + GameEngine.Instance.GFX.ViewportWidth / 2, point.Y + GameEngine.Instance.GFX.ViewportHeight / 2);
		}

		// Token: 0x060008E7 RID: 2279 RVA: 0x0000D316 File Offset: 0x0000B516
		public void MoveToPosition(Point position)
		{
			this.m_backgroundSprite.PosX = (float)position.X;
			this.m_backgroundSprite.PosY = (float)position.Y;
			this.Drag(new Point(0, 0));
		}

		// Token: 0x060008E8 RID: 2280 RVA: 0x000BA154 File Offset: 0x000B8354
		public void Drag(Point delta)
		{
			if (this.m_backgroundSprite != null)
			{
				this.m_backgroundSprite.move(delta.X, delta.Y);
				this.m_backgroundSprite.keepBounded();
				this.m_backgroundSprite.centreSmallerSprite();
				this.m_backgroundSprite.fixup2DPos();
				return;
			}
			UniversalDebugLog.Log("background sprite is null :(");
		}

		// Token: 0x060008E9 RID: 2281 RVA: 0x0000D34B File Offset: 0x0000B54B
		public void ChangeZoom(float delta)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060008EA RID: 2282 RVA: 0x000BA1B0 File Offset: 0x000B83B0
		public Point ScreenToWorldSpace(Point point)
		{
			point.X -= (int)this.m_backgroundSprite.DrawPos.X;
			point.Y -= (int)this.m_backgroundSprite.DrawPos.Y;
			return point;
		}

		// Token: 0x060008EB RID: 2283 RVA: 0x000BA204 File Offset: 0x000B8404
		public Point WorldToScreenSpace(Point point)
		{
			point.X += (int)this.m_backgroundSprite.DrawPos.X;
			point.Y += (int)this.m_backgroundSprite.DrawPos.Y;
			return point;
		}

		// Token: 0x060008EC RID: 2284 RVA: 0x000BA258 File Offset: 0x000B8458
		public Point WorldSpaceToMapTile(Point worldPos)
		{
			worldPos.X -= 5;
			worldPos.Y -= 16;
			worldPos.Y *= 2;
			PointF point = new PointF((float)worldPos.X, (float)worldPos.Y);
			PointF pointF = GameEngine.Instance.GFX.rotatePoint(point, 315);
			pointF.X /= 22.627417f;
			pointF.Y /= 22.627417f;
			pointF.X += 58f;
			return new Point((int)pointF.X, (int)pointF.Y);
		}

		// Token: 0x060008ED RID: 2285 RVA: 0x000BA310 File Offset: 0x000B8510
		public Point MapTileToWorldSpace(Point mapTile)
		{
			return new Point
			{
				X = mapTile.X * 16 + mapTile.Y * 16 - 922,
				Y = mapTile.Y * 8 - mapTile.X * 8 + 474
			};
		}

		// Token: 0x060008EE RID: 2286 RVA: 0x000BA368 File Offset: 0x000B8568
		public Point ScreenSpaceToMapTile(Point point)
		{
			Point worldPos = this.ScreenToWorldSpace(point);
			return this.WorldSpaceToMapTile(worldPos);
		}

		// Token: 0x060008EF RID: 2287 RVA: 0x000BA384 File Offset: 0x000B8584
		public Point MapTileToScreenSpace(Point mapTile)
		{
			Point point = this.MapTileToWorldSpace(mapTile);
			return this.WorldToScreenSpace(point);
		}

		// Token: 0x04000C5F RID: 3167
		private SpriteWrapper m_backgroundSprite;
	}
}
