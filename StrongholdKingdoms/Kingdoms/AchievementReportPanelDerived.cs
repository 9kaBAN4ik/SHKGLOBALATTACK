using System;
using System.Drawing;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020000B4 RID: 180
	internal class AchievementReportPanelDerived : GenericReportPanelBasic
	{
		// Token: 0x060004EF RID: 1263 RVA: 0x0005F744 File Offset: 0x0005D944
		public override void setData(GetReport_ReturnType returnData)
		{
			base.setData(returnData);
			this.lblSecondaryText.Text = CustomTooltipManager.getAchievementTitle(returnData.genericData1) + " - " + CustomTooltipManager.getAchievementRank(returnData.genericData1);
			this.lblSubTitle.Text = SK.Text("ReportsPanel_Achievement_Attained", "Achievement Attained");
			this.imgFurther.Image = GFXLibrary.com_32_honour_DS;
			this.imgFurther.setSizeToImage();
			this.imgFurther.Position = new Point(base.Width / 2 - this.imgFurther.Width, this.btnDelete.Position.Y);
			this.lblFurther.Text = this.m_returnData.genericData2.ToString("N", this.nfi);
			this.lblFurther.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.lblFurther.Size = new Size(base.Width, this.imgFurther.Height);
			this.lblFurther.Position = new Point(this.imgFurther.Rectangle.Right + 10, this.imgFurther.Position.Y);
			base.showFurtherInfo();
			this.btnUtility.Visible = true;
			this.btnUtility.Text.Text = SK.Text("GENERIC_Achievements", "Achievements");
		}

		// Token: 0x060004F0 RID: 1264 RVA: 0x0000A8DF File Offset: 0x00008ADF
		protected override void utilityClick()
		{
			GameEngine.Instance.playInterfaceSound("AchievementReportPanel_achievements");
			InterfaceMgr.Instance.getMainTabBar().changeTab(4);
			this.m_parent.closeControl(true);
			InterfaceMgr.Instance.reactiveMainWindow();
		}
	}
}
