using System;
using System.Drawing;

namespace Kingdoms
{
	// Token: 0x020001FF RID: 511
	public interface ICameraController
	{
		// Token: 0x06001436 RID: 5174
		Rectangle GetCameraRectangle();

		// Token: 0x06001437 RID: 5175
		Point getCameraCentre();

		// Token: 0x06001438 RID: 5176
		void MoveToPosition(Point position);

		// Token: 0x06001439 RID: 5177
		void Drag(Point mousePos);

		// Token: 0x0600143A RID: 5178
		void ChangeZoom(float delta);

		// Token: 0x0600143B RID: 5179
		Point ScreenToWorldSpace(Point point);

		// Token: 0x0600143C RID: 5180
		Point WorldToScreenSpace(Point point);

		// Token: 0x0600143D RID: 5181
		Point WorldSpaceToMapTile(Point worldPos);

		// Token: 0x0600143E RID: 5182
		Point MapTileToWorldSpace(Point mapTile);

		// Token: 0x0600143F RID: 5183
		Point ScreenSpaceToMapTile(Point point);

		// Token: 0x06001440 RID: 5184
		Point MapTileToScreenSpace(Point mapTile);
	}
}
