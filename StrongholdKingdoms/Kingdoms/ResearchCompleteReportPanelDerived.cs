using System;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000477 RID: 1143
	internal class ResearchCompleteReportPanelDerived : GenericReportPanelBasic
	{
		// Token: 0x06002963 RID: 10595 RVA: 0x001F7F74 File Offset: 0x001F6174
		public override void setData(GetReport_ReturnType returnData)
		{
			base.setData(returnData);
			this.lblSecondaryText.Text = string.Concat(new string[]
			{
				ResearchData.getResearchName(returnData.genericData1),
				" : ",
				SK.Text("Reports_Research_Level", "Level"),
				" : ",
				(returnData.genericData2 + 1).ToString()
			});
			this.lblSubTitle.Text = SK.Text("Reports_Research_Complete", "Research Complete");
			this.btnUtility.Text.Text = SK.Text("GENERIC_Research", "Research");
			this.btnUtility.Visible = true;
		}

		// Token: 0x06002964 RID: 10596 RVA: 0x0001E766 File Offset: 0x0001C966
		protected override void utilityClick()
		{
			GameEngine.Instance.playInterfaceSound("ResearchCompleteReportPanel_research");
			InterfaceMgr.Instance.getMainTabBar().changeTab(3);
			this.m_parent.closeControl(true);
			InterfaceMgr.Instance.reactiveMainWindow();
		}
	}
}
