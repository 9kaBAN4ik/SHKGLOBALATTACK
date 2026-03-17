using System;
using System.Drawing;

namespace Kingdoms
{
	// Token: 0x02000109 RID: 265
	public class CardBarDX
	{
		// Token: 0x06000866 RID: 2150 RVA: 0x0000CDA4 File Offset: 0x0000AFA4
		public void init(int cardSection)
		{
			this.delayedSection = -1;
			this.csd.clearControls();
			this.csd.addControl(this.cardbar);
			this.cardbar.init(cardSection);
			this.update();
		}

		// Token: 0x06000867 RID: 2151 RVA: 0x0000CDDB File Offset: 0x0000AFDB
		public void delayedInit(int cardSection)
		{
			this.delayedSection = cardSection;
		}

		// Token: 0x06000868 RID: 2152 RVA: 0x000B17A8 File Offset: 0x000AF9A8
		public void update()
		{
			if (!InterfaceMgr.Instance.allowDrawCircles())
			{
				return;
			}
			if (this.delayedSection >= 0)
			{
				this.init(this.delayedSection);
				return;
			}
			this.cardbar.update();
			if (!this.cardbar.Dirty)
			{
				return;
			}
			Graphics graphics = GameEngine.Instance.GFX.createDXOverlayTexture(this.cardbar.Size);
			if (graphics != null)
			{
				if (this.csd.initFromDX(graphics, this.cardbar))
				{
					this.csd.drawControls();
					this.csd.endPaint();
				}
				GameEngine.Instance.GFX.renderDXOverlayTexture(graphics);
			}
			this.cardbar.flagAsRendered();
		}

		// Token: 0x06000869 RID: 2153 RVA: 0x0000CDE4 File Offset: 0x0000AFE4
		public bool click(Point mousePos)
		{
			return this.csd.baseControl.parentClicked(mousePos);
		}

		// Token: 0x0600086A RID: 2154 RVA: 0x0000CDF7 File Offset: 0x0000AFF7
		public void toggleEnabled(bool value)
		{
			this.cardbar.toggleActive(value);
		}

		// Token: 0x0600086B RID: 2155 RVA: 0x0000CE05 File Offset: 0x0000B005
		public void mouseMove(Point mousePos)
		{
			this.csd.tooltipSet = false;
			CustomTooltipManager.MouseLeaveTooltipArea();
			this.csd.baseControl.parentMouseOver(mousePos);
			TutorialWindow.tooltip(mousePos);
		}

		// Token: 0x04000C01 RID: 3073
		private CardBarGDI cardbar = new CardBarGDI();

		// Token: 0x04000C02 RID: 3074
		private CustomSelfDrawPanel csd = new CustomSelfDrawPanel();

		// Token: 0x04000C03 RID: 3075
		private int delayedSection = -1;
	}
}
