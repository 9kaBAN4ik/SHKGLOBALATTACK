using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x020004A5 RID: 1189
	public partial class TutorialBattleReportPopup : MyFormBase
	{
		// Token: 0x06002B87 RID: 11143 RVA: 0x00224770 File Offset: 0x00222970
		public TutorialBattleReportPopup()
		{
			this.InitializeComponent();
			this.lblMessage.Font = FontManager.GetFont("Arial", 9.75f, FontStyle.Regular);
			base.Title = (this.Text = SK.Text("TutorialBattleReport_Victorious", "We are victorious Sire"));
			this.btnViewReport.Text = SK.Text("TutorialBattleReport_View_Battle", "View Battle");
			this.btnViewReport.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
		}

		// Token: 0x06002B88 RID: 11144 RVA: 0x0001FFB7 File Offset: 0x0001E1B7
		public void init()
		{
			this.lblMessage.Text = SK.Text("TutorialBattleReport_Message", "Your castle has been attacked!");
			this.closeCallback = new MyFormBase.MFBClose(this.closeCallbackClicked);
		}

		// Token: 0x06002B89 RID: 11145 RVA: 0x0001FFE5 File Offset: 0x0001E1E5
		private void closeCallbackClicked()
		{
			PostTutorialWindow.CreatePostTutorialWindow(true);
		}

		// Token: 0x06002B8A RID: 11146 RVA: 0x0001FFED File Offset: 0x0001E1ED
		private void btnOK_Click(object sender, EventArgs e)
		{
			this.btnViewReport.Enabled = false;
			RemoteServices.Instance.set_ViewBattle_UserCallBack(new RemoteServices.ViewBattle_UserCallBack(this.viewBattleCallback));
			RemoteServices.Instance.ViewBattle(-5555L);
		}

		// Token: 0x06002B8B RID: 11147 RVA: 0x002247F8 File Offset: 0x002229F8
		private void viewBattleCallback(ViewBattle_ReturnType returnData)
		{
			if (returnData.Success)
			{
				InterfaceMgr.Instance.reactiveMainWindow();
				InterfaceMgr.Instance.getMainTabBar().selectDummyTab(6);
				int campMode = 0;
				List<int> userVillageIDList = GameEngine.Instance.World.getUserVillageIDList();
				if (userVillageIDList.Count > 0)
				{
					int villageID = userVillageIDList[0];
					Sound.playBattleMusic();
					GameEngine.Instance.InitBattle(returnData.castleMapSnapshot, returnData.damageMapSnapshot, returnData.castleTroopsSnapshot, returnData.attackMapSnapshot, returnData.keepLevel, returnData.defenderResearchData, returnData.attackerResearchData, campMode, -1, -1, -1, 13, villageID, null, returnData.landType);
					GameEngine.Instance.CastleBattle.tutorialFastForward();
				}
			}
			base.Close();
		}
	}
}
