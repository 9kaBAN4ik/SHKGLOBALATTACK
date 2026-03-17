using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000212 RID: 530
	public partial class LoggingOutPopup : MyFormBase
	{
		// Token: 0x0600164E RID: 5710 RVA: 0x000179ED File Offset: 0x00015BED
		public LoggingOutPopup()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x0600164F RID: 5711 RVA: 0x001603F8 File Offset: 0x0015E5F8
		public static void open(bool manual, bool autoScout, bool autoTrade, bool autoAttack, bool autoAttackWolf, bool autoAttackBandit, bool autoAttackAI, int resourceType, int percent, bool autoRecruit, bool autoRecruitPeasant, bool autoRecruitArchers, bool autoRecruitPikemen, bool autoRecruitSwordsmen, bool autoRecruitCatapults, int autoRecruitPeasant_Cap, int autoRecruitArchers_Cap, int autoRecruitPikemen_Cap, int autoRecruitSwordsmen_Cap, int autoRecruitCatapults_Cap)
		{
			LoggingOutPopup.loggingOut = true;
			LoggingOutPopup loggingOutPopup = new LoggingOutPopup();
			loggingOutPopup.doOpen(manual, autoScout, autoTrade, autoAttack, autoAttackWolf, autoAttackBandit, autoAttackAI, resourceType, percent, autoRecruit, autoRecruitPeasant, autoRecruitArchers, autoRecruitPikemen, autoRecruitSwordsmen, autoRecruitCatapults, autoRecruitPeasant_Cap, autoRecruitArchers_Cap, autoRecruitPikemen_Cap, autoRecruitSwordsmen_Cap, autoRecruitCatapults_Cap);
			loggingOutPopup.Show();
		}

		// Token: 0x06001650 RID: 5712 RVA: 0x00017A10 File Offset: 0x00015C10
		public static void clearLoggingOut()
		{
			LoggingOutPopup.loggingOut = false;
		}

		// Token: 0x06001651 RID: 5713 RVA: 0x00160444 File Offset: 0x0015E644
		public void doOpen(bool manual, bool autoScout, bool autoTrade, bool autoAttack, bool autoAttackWolf, bool autoAttackBandit, bool autoAttackAI, int resourceType, int percent, bool autoRecruit, bool autoRecruitPeasant, bool autoRecruitArchers, bool autoRecruitPikemen, bool autoRecruitSwordsmen, bool autoRecruitCatapults, int autoRecruitPeasant_Cap, int autoRecruitArchers_Cap, int autoRecruitPikemen_Cap, int autoRecruitSwordsmen_Cap, int autoRecruitCatapults_Cap)
		{
			this.label1.Text = SK.Text("LoggingOutPopup_Please_Wait", "Please wait....");
			string text = this.Text = (base.Title = SK.Text("LoggingOutPopup_Logging_Out", "Logging Out"));
			RemoteServices.Instance.set_Chat_Logout_UserCallBack(null);
			RemoteServices.Instance.Chat_Logout();
			RemoteServices.Instance.set_LogOut_UserCallBack(new RemoteServices.LogOut_UserCallBack(this.LogOutCallback));
			RemoteServices.Instance.LogOut(manual, autoScout, autoTrade, autoAttack, autoAttackWolf, autoAttackBandit, autoAttackAI, resourceType, percent, autoRecruit, autoRecruitPeasant, autoRecruitArchers, autoRecruitPikemen, autoRecruitSwordsmen, autoRecruitCatapults, autoRecruitPeasant_Cap, autoRecruitArchers_Cap, autoRecruitPikemen_Cap, autoRecruitSwordsmen_Cap, autoRecruitCatapults_Cap);
			RemoteServices.Instance.SessionID = 0;
		}

		// Token: 0x06001652 RID: 5714 RVA: 0x00017A18 File Offset: 0x00015C18
		public void LogOutCallback(LogOut_ReturnType returnData)
		{
			Thread.Sleep(1500);
			LoggingOutPopup.loggingOut = false;
			GameEngine.Instance.sessionExpired(-1);
			base.Close();
		}

		// Token: 0x04002697 RID: 9879
		public static bool loggingOut;
	}
}
