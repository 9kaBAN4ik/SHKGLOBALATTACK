using System;
using System.Drawing;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000291 RID: 657
	internal class PrizeWonReportPanelDerived : GenericReportPanelBasic
	{
		// Token: 0x06001D42 RID: 7490 RVA: 0x001C7160 File Offset: 0x001C5360
		public override void setData(GetReport_ReturnType returnData)
		{
			base.setData(returnData);
			this.m_prizeID = returnData.genericData1;
			this.m_contestID = returnData.genericData2;
			this.lblDate.Position = new Point(0, this.lblSubTitle.Rectangle.Bottom);
			this.lblMainText.Text = SK.Text("Reports_Prize_Won", "Prize Won!");
			if (GameEngine.Instance.World.pendingPrizes != null && GameEngine.Instance.World.pendingPrizes.Count > 0)
			{
				CustomSelfDrawPanel.CSDButton csdbutton = new CustomSelfDrawPanel.CSDButton();
				csdbutton.ImageNorm = GFXLibrary.button_132_normal_gold;
				csdbutton.ImageOver = GFXLibrary.button_132_over_gold;
				csdbutton.ImageClick = GFXLibrary.button_132_in_gold;
				csdbutton.setSizeToImage();
				csdbutton.Position = new Point(base.Width / 2 - csdbutton.Width / 2, this.btnClose.Y);
				csdbutton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				csdbutton.TextYOffset = -2;
				csdbutton.Text.Color = global::ARGBColors.Black;
				csdbutton.Enabled = true;
				csdbutton.Visible = true;
				csdbutton.Text.Text = SK.Text("Event_Prizes_Header", "Prizes");
				csdbutton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.showPrizesClick), "Reports_Show_Prizes");
				base.addControl(csdbutton);
			}
		}

		// Token: 0x06001D43 RID: 7491 RVA: 0x0001C6F1 File Offset: 0x0001A8F1
		private void showPrizesClick()
		{
			PrizeClaimWindow.CreatePrizeClaimWindow();
		}

		// Token: 0x04002E08 RID: 11784
		private int m_prizeID;

		// Token: 0x04002E09 RID: 11785
		private int m_contestID;
	}
}
