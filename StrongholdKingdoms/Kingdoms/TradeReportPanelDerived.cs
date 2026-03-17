using System;
using System.Drawing;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x0200049E RID: 1182
	internal class TradeReportPanelDerived : GenericReportPanelBasic
	{
		// Token: 0x06002B4A RID: 11082 RVA: 0x002232C8 File Offset: 0x002214C8
		public override void setData(GetReport_ReturnType returnData)
		{
			base.setData(returnData);
			short reportType = returnData.reportType;
			if (reportType != 73)
			{
				if (reportType == 78)
				{
					this.lblMainText.Text = GameEngine.Instance.World.getVillageName(returnData.attackingVillage);
					this.lblSubTitle.Text = SK.Text("Report_Auto_Sent_Resources_To", "Has Auto-Sent resources to");
					this.lblSecondaryText.Text = GameEngine.Instance.World.getVillageName(returnData.defendingVillage);
				}
			}
			else
			{
				this.lblMainText.Text = returnData.otherUser + " (" + GameEngine.Instance.World.getVillageName(returnData.attackingVillage) + ")";
				this.lblSubTitle.Text = SK.Text("Reports_Sent_Resources_To", "Has sent resources to");
				this.lblSecondaryText.Text = this.reportOwner + " (" + GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + ")";
			}
			this.imgFurther.Image = GFXLibrary.getCommodity32Image(this.m_returnData.genericData1);
			this.imgFurther.setSizeToImage();
			this.imgFurther.Position = new Point(base.Width / 2 - this.imgFurther.Width, this.btnDelete.Position.Y);
			this.lblFurther.Text = this.m_returnData.genericData2.ToString("N", this.nfi);
			this.lblFurther.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.lblFurther.Size = new Size(base.Width, this.imgFurther.Height);
			this.lblFurther.Position = new Point(this.imgFurther.Rectangle.Right + 10, this.imgFurther.Position.Y);
			base.showFurtherInfo();
		}
	}
}
