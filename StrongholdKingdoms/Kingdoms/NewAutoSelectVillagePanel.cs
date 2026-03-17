using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000250 RID: 592
	public class NewAutoSelectVillagePanel : CustomSelfDrawPanel
	{
		// Token: 0x06001A26 RID: 6694 RVA: 0x0001A34C File Offset: 0x0001854C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001A27 RID: 6695 RVA: 0x0019DB80 File Offset: 0x0019BD80
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.None;
			base.Name = "NewAutoSelectVillagePanel";
			base.Size = new Size(600, 55);
			base.ResumeLayout(false);
		}

		// Token: 0x06001A28 RID: 6696 RVA: 0x0019DBD4 File Offset: 0x0019BDD4
		public NewAutoSelectVillagePanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06001A29 RID: 6697 RVA: 0x0019DC68 File Offset: 0x0019BE68
		public void init(int tryingToJoinCounty, NewAutoSelectVillageWindow parent)
		{
			this.m_parent = parent;
			base.clearControls();
			this.transparentBackground.Size = base.Size;
			this.transparentBackground.FillColor = Color.FromArgb(255, 0, 255);
			base.addControl(this.transparentBackground);
			this.background.Position = new Point(0, 0);
			this.background.Image = GFXLibrary.worldSelect_Background;
			this.background.Size = new Size(this.background.Image.Width, this.background.Image.Height);
			base.addControl(this.background);
			this.backgroundArea.Position = new Point(0, 0);
			this.backgroundArea.Size = new Size(625, 668);
			this.background.addControl(this.backgroundArea);
			if (Program.mySettings.LanguageIdent == "en" || Program.mySettings.LanguageIdent == "fr" || Program.mySettings.LanguageIdent == "de")
			{
				this.header1Label.Text = SK.Text("WorldSelect_Place_Your_Village1", "Place");
				this.header1Label.Position = new Point(108, 170);
				this.header1Label.Size = new Size(this.backgroundArea.Width - 200, 150);
				this.header1Label.Font = FontManager.GetFont("Arial", 24f, FontStyle.Regular);
				this.header1Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
				this.header1Label.Color = global::ARGBColors.Black;
				this.header1Label.DropShadowColor = global::ARGBColors.LightGray;
				this.backgroundArea.addControl(this.header1Label);
			}
			this.header2Label.Text = SK.Text("WorldSelect_Place_Your_Village2", "Your");
			this.header2Label.Position = new Point(108, 215);
			this.header2Label.Size = new Size(this.backgroundArea.Width - 200, 150);
			this.header2Label.Font = FontManager.GetFont("Arial", 24f, FontStyle.Regular);
			this.header2Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.header2Label.Color = global::ARGBColors.Black;
			this.header2Label.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.header2Label);
			this.header3Label.Text = SK.Text("WorldSelect_Place_Your_Village3", "Village");
			this.header3Label.Position = new Point(108, 260);
			this.header3Label.Size = new Size(this.backgroundArea.Width - 200, 150);
			this.header3Label.Font = FontManager.GetFont("Arial", 24f, FontStyle.Regular);
			this.header3Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.header3Label.Color = global::ARGBColors.Black;
			this.header3Label.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.header3Label);
			this.btnEnterGame.ImageNorm = GFXLibrary.worldSelect_random_norm;
			this.btnEnterGame.ImageOver = GFXLibrary.worldSelect_random_over;
			this.btnEnterGame.ImageClick = GFXLibrary.worldSelect_random_pushed;
			this.btnEnterGame.Position = new Point(193, 316);
			this.btnEnterGame.Text.Text = SK.Text("WorldSelect_Random", "Random");
			this.btnEnterGame.TextYOffset = -2;
			this.btnEnterGame.Text.Color = global::ARGBColors.White;
			this.btnEnterGame.Text.DropShadowColor = global::ARGBColors.Black;
			this.btnEnterGame.Text.Font = FontManager.GetFont("Arial", 20f, FontStyle.Regular);
			this.btnEnterGame.Text.Position = new Point(-3, 0);
			this.btnEnterGame.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.enterGameClicked));
			this.btnEnterGame.Enabled = true;
			this.btnEnterGame.CustomTooltipID = 1800;
			this.backgroundArea.addControl(this.btnEnterGame);
			this.btnAdvanced.ImageNorm = GFXLibrary.worldSelect_manual_norm;
			this.btnAdvanced.ImageOver = GFXLibrary.worldSelect_manual_over;
			this.btnAdvanced.ImageClick = GFXLibrary.worldSelect_manual_pushed;
			this.btnAdvanced.Position = new Point(193, 416);
			this.btnAdvanced.Text.Text = SK.Text("WorldSelect_Manual", "Manual");
			this.btnAdvanced.TextYOffset = -2;
			this.btnAdvanced.Text.Color = global::ARGBColors.White;
			this.btnAdvanced.Text.DropShadowColor = global::ARGBColors.Black;
			this.btnAdvanced.Text.Font = FontManager.GetFont("Arial", 20f, FontStyle.Regular);
			this.btnAdvanced.Text.Position = new Point(-3, 0);
			this.btnAdvanced.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.advancedClicked));
			this.btnAdvanced.Enabled = true;
			this.btnAdvanced.CustomTooltipID = 1801;
			this.backgroundArea.addControl(this.btnAdvanced);
			if (GameEngine.Instance.LocalWorldData.AIWorld)
			{
				this.btnAdvanced.Visible = false;
			}
			else
			{
				this.btnAdvanced.Visible = true;
			}
			this.btnLogout.ImageNorm = GFXLibrary.worldSelect_swap_norm;
			this.btnLogout.ImageOver = GFXLibrary.worldSelect_swap_over;
			this.btnLogout.ImageClick = GFXLibrary.worldSelect_swap_pushed;
			this.btnLogout.Position = new Point(245, 516);
			this.btnLogout.Text.Text = SK.Text("LogoutPanel_Swap_Worlds", "Swap Worlds");
			this.btnLogout.TextYOffset = -2;
			this.btnLogout.Text.Color = global::ARGBColors.White;
			this.btnLogout.Text.DropShadowColor = global::ARGBColors.Black;
			this.btnLogout.Text.Font = FontManager.GetFont("Arial", 11f, FontStyle.Regular);
			this.btnLogout.Text.Position = new Point(-3, 0);
			this.btnLogout.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.logoutClick));
			this.btnLogout.Enabled = true;
			this.btnLogout.CustomTooltipID = 1802;
			this.backgroundArea.addControl(this.btnLogout);
			this.delayedRetry = DateTime.MinValue;
			if (tryingToJoinCounty >= -1)
			{
				this.closePopup();
				this.m_popup = new JoiningWorldPopup();
				this.m_popup.init(-1, "");
				this.m_popup.Show(this);
				this.btnEnterGame.Enabled = false;
				this.delayedRetry = DateTime.Now.AddSeconds(-25.0);
				GameEngine.Instance.tryingToJoinCounty = -2;
			}
		}

		// Token: 0x06001A2A RID: 6698 RVA: 0x0019E3CC File Offset: 0x0019C5CC
		private void logoutClick()
		{
			GameEngine.Instance.playInterfaceSound("AutoSelectVillageAreaPopup_logout");
			this.m_parent.closing = true;
			GameEngine.Instance.closeNoVillagePopup(false);
			LoggingOutPopup.open(true, false, false, false, false, false, false, 0, 100, false, false, false, false, false, false, 500, 500, 500, 500, 250);
		}

		// Token: 0x06001A2B RID: 6699 RVA: 0x0019E430 File Offset: 0x0019C630
		private void enterGameClicked()
		{
			GameEngine.Instance.playInterfaceSound("AutoSelectVillageAreaPopup_random");
			this.closePopup();
			this.m_popup = new JoiningWorldPopup();
			this.m_popup.init(-1, "");
			this.m_popup.Show(this);
			this.btnEnterGame.Enabled = false;
			this.btnAdvanced.Enabled = false;
			this.retries = 0;
			RemoteServices.Instance.set_SetStartingCounty_UserCallBack(new RemoteServices.SetStartingCounty_UserCallBack(this.SetStartingCountyCallback));
			RemoteServices.Instance.SetStartingCounty(9999);
		}

		// Token: 0x06001A2C RID: 6700 RVA: 0x0001A36B File Offset: 0x0001856B
		public void closePopup()
		{
			if (this.m_popup != null)
			{
				this.m_popup.Close();
				this.m_popup = null;
			}
		}

		// Token: 0x06001A2D RID: 6701 RVA: 0x0019E4C0 File Offset: 0x0019C6C0
		private void SetStartingCountyCallback(SetStartingCounty_ReturnType returnData)
		{
			if (!returnData.Success)
			{
				return;
			}
			if (returnData.availableCounties != null)
			{
				this.retries++;
				if (this.retries >= 2)
				{
					this.btnEnterGame.Enabled = true;
					this.btnAdvanced.Enabled = true;
					this.closePopup();
					MyMessageBox.Show(SK.Text("SelectVillageAreaPopup_Village_Placement_Error_Message", "The server failed to find you a village, please try again."), SK.Text("SelectVillageAreaPopup_Village_Placement_Error", "Village Placement Error"));
					return;
				}
				Thread.Sleep(2000);
				RemoteServices.Instance.set_SetStartingCounty_UserCallBack(new RemoteServices.SetStartingCounty_UserCallBack(this.SetStartingCountyCallback));
				RemoteServices.Instance.SetStartingCounty(9999);
				return;
			}
			else
			{
				if (returnData.villageID >= 0)
				{
					GameEngine.Instance.World.setVillageName(returnData.villageID, returnData.villageName);
					GameEngine.Instance.World.addUserVillage(returnData.villageID);
					GameEngine.Instance.World.updateWorldMapOwnership();
					this.m_parent.closing = true;
					GameEngine.Instance.closeNoVillagePopup(true);
					GameEngine.Instance.World.setResearchData(returnData.m_researchData);
					InterfaceMgr.Instance.selectUserVillage(returnData.villageID, false);
					return;
				}
				this.delayedRetry = DateTime.Now;
				return;
			}
		}

		// Token: 0x06001A2E RID: 6702 RVA: 0x0019E5FC File Offset: 0x0019C7FC
		public void update()
		{
			if (this.delayedRetry != DateTime.MinValue && (DateTime.Now - this.delayedRetry).TotalSeconds > 30.0)
			{
				this.delayedRetry = DateTime.MinValue;
				RemoteServices.Instance.set_SetStartingCounty_UserCallBack(new RemoteServices.SetStartingCounty_UserCallBack(this.SetStartingCountyCallback));
				RemoteServices.Instance.SetStartingCounty(-1);
			}
		}

		// Token: 0x06001A2F RID: 6703 RVA: 0x0001A387 File Offset: 0x00018587
		private void advancedClicked()
		{
			GameEngine.Instance.playInterfaceSound("AutoSelectVillageAreaPopup_manual");
			this.closePopup();
			this.m_parent.closing = true;
			GameEngine.Instance.closeNoVillagePopup(false);
			GameEngine.Instance.openAdvancedSelectVillage();
		}

		// Token: 0x04002AE0 RID: 10976
		private IContainer components;

		// Token: 0x04002AE1 RID: 10977
		private CustomSelfDrawPanel.CSDImage background = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002AE2 RID: 10978
		private CustomSelfDrawPanel.CSDArea backgroundArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04002AE3 RID: 10979
		private CustomSelfDrawPanel.CSDFill transparentBackground = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x04002AE4 RID: 10980
		private CustomSelfDrawPanel.CSDButton btnEnterGame = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002AE5 RID: 10981
		private CustomSelfDrawPanel.CSDButton btnAdvanced = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002AE6 RID: 10982
		private CustomSelfDrawPanel.CSDButton btnLogout = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002AE7 RID: 10983
		private CustomSelfDrawPanel.CSDLabel header1Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002AE8 RID: 10984
		private CustomSelfDrawPanel.CSDLabel header2Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002AE9 RID: 10985
		private CustomSelfDrawPanel.CSDLabel header3Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002AEA RID: 10986
		private NewAutoSelectVillageWindow m_parent;

		// Token: 0x04002AEB RID: 10987
		private JoiningWorldPopup m_popup;

		// Token: 0x04002AEC RID: 10988
		private int retries;

		// Token: 0x04002AED RID: 10989
		private DateTime delayedRetry = DateTime.MinValue;
	}
}
