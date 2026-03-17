using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000278 RID: 632
	public class PostTutorialPanel : CustomSelfDrawPanel
	{
		// Token: 0x06001C68 RID: 7272 RVA: 0x0001BE2D File Offset: 0x0001A02D
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001C69 RID: 7273 RVA: 0x001BC01C File Offset: 0x001BA21C
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.None;
			base.Name = "PostTutorialPanel";
			base.Size = new Size(600, 55);
			base.ResumeLayout(false);
		}

		// Token: 0x06001C6A RID: 7274 RVA: 0x001BC070 File Offset: 0x001BA270
		public PostTutorialPanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06001C6B RID: 7275 RVA: 0x001BC15C File Offset: 0x001BA35C
		public void init(bool fromTutorial, PostTutorialWindow parent)
		{
			this.m_parent = parent;
			base.clearControls();
			int num = 10;
			if (GameEngine.Instance.World.isBigpointAccount || Program.bigpointInstall || Program.aeriaInstall || Program.bigpointPartnerInstall)
			{
				num = 9;
			}
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
			if (fromTutorial)
			{
				this.header3Label.Text = SK.Text("PT_TUT_header1", "Congratulations!");
				this.header3Label.Position = new Point(8, 216);
				this.header3Label.Size = new Size(this.backgroundArea.Width, 150);
				this.header3Label.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
				this.header3Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
				this.header3Label.Color = global::ARGBColors.Black;
				this.header3Label.DropShadowColor = global::ARGBColors.LightGray;
				this.backgroundArea.addControl(this.header3Label);
				this.header1Label.Text = SK.Text("PT_TUT_header2", "You have completed the Stronghold Kingdoms Tutorial.");
				this.header1Label.Font = FontManager.GetFont("Arial", 11f, FontStyle.Regular);
			}
			else
			{
				this.header1Label.Text = SK.Text("PT_header1", "Welcome to the Stronghold Kingdoms Player Guide");
				this.header1Label.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			}
			this.header1Label.Position = new Point(8, 256);
			this.header1Label.Size = new Size(this.backgroundArea.Width, 150);
			this.header1Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.header1Label.Color = global::ARGBColors.Black;
			this.header1Label.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.header1Label);
			this.header2Label.Text = SK.Text("PT_header2", "Here are a few suggestions for what to do next") + ":";
			this.header2Label.Position = new Point(108, 277);
			this.header2Label.Size = new Size(this.backgroundArea.Width - 200, 34);
			this.header2Label.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.header2Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.header2Label.Color = global::ARGBColors.Black;
			this.header2Label.DropShadowColor = global::ARGBColors.LightGray;
			this.backgroundArea.addControl(this.header2Label);
			int num2 = 0;
			this.feature1Button.ImageNorm = GFXLibrary.pt_Research;
			this.feature1Button.ImageOver = GFXLibrary.pt_Research_over;
			this.feature1Button.ImageClick = GFXLibrary.pt_Research_down;
			this.feature1Button.Position = this.getIconPosition(num2++, num);
			this.feature1Button.Data = 0;
			this.feature1Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.iconClicked));
			this.feature1Button.CustomTooltipID = 4300;
			this.background.addControl(this.feature1Button);
			this.feature2Button.ImageNorm = GFXLibrary.pt_rank;
			this.feature2Button.ImageOver = GFXLibrary.pt_rank_over;
			this.feature2Button.ImageClick = GFXLibrary.pt_rank_down;
			this.feature2Button.Position = this.getIconPosition(num2++, num);
			this.feature2Button.Data = 1;
			this.feature2Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.iconClicked));
			this.feature2Button.CustomTooltipID = 4301;
			this.background.addControl(this.feature2Button);
			this.feature3Button.ImageNorm = GFXLibrary.pt_Achievements;
			this.feature3Button.ImageOver = GFXLibrary.pt_Achievements_over;
			this.feature3Button.ImageClick = GFXLibrary.pt_Achievements_down;
			this.feature3Button.Position = this.getIconPosition(num2++, num);
			this.feature3Button.Data = 2;
			this.feature3Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.iconClicked));
			this.feature3Button.CustomTooltipID = 4302;
			this.background.addControl(this.feature3Button);
			this.feature4Button.ImageNorm = GFXLibrary.pt_Quests;
			this.feature4Button.ImageOver = GFXLibrary.pt_Quests_over;
			this.feature4Button.ImageClick = GFXLibrary.pt_Quests_down;
			this.feature4Button.Position = this.getIconPosition(num2++, num);
			this.feature4Button.Data = 3;
			this.feature4Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.iconClicked));
			this.feature4Button.CustomTooltipID = 4303;
			this.background.addControl(this.feature4Button);
			this.feature5Button.ImageNorm = GFXLibrary.pt_Reports;
			this.feature5Button.ImageOver = GFXLibrary.pt_Reports_over;
			this.feature5Button.ImageClick = GFXLibrary.pt_Reports_down;
			this.feature5Button.Position = this.getIconPosition(num2++, num);
			this.feature5Button.Data = 4;
			this.feature5Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.iconClicked));
			this.feature5Button.CustomTooltipID = 4304;
			this.background.addControl(this.feature5Button);
			this.feature6Button.ImageNorm = GFXLibrary.pt_Coat_of_Arms;
			this.feature6Button.ImageOver = GFXLibrary.pt_Coat_of_Arms_over;
			this.feature6Button.ImageClick = GFXLibrary.pt_Coat_of_Arms_down;
			this.feature6Button.Position = this.getIconPosition(num2++, num);
			this.feature6Button.Data = 5;
			this.feature6Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.iconClicked));
			this.feature6Button.CustomTooltipID = 4305;
			this.background.addControl(this.feature6Button);
			this.feature7Button.ImageNorm = GFXLibrary.pt_Avatar;
			this.feature7Button.ImageOver = GFXLibrary.pt_Avatar_over;
			this.feature7Button.ImageClick = GFXLibrary.pt_Avatar_down;
			this.feature7Button.Position = this.getIconPosition(num2++, num);
			this.feature7Button.Data = 6;
			this.feature7Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.iconClicked));
			this.feature7Button.CustomTooltipID = 4306;
			this.background.addControl(this.feature7Button);
			if (num == 10)
			{
				this.feature8Button.ImageNorm = GFXLibrary.pt_Invite_a_Friend;
				this.feature8Button.ImageOver = GFXLibrary.pt_Invite_a_Friend_over;
				this.feature8Button.ImageClick = GFXLibrary.pt_Invite_a_Friend_down;
				this.feature8Button.Position = this.getIconPosition(num2++, num);
				this.feature8Button.Data = 7;
				this.feature8Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.iconClicked));
				this.feature8Button.CustomTooltipID = 4307;
				this.background.addControl(this.feature8Button);
			}
			this.feature9Button.ImageNorm = GFXLibrary.pt_Parish_Wall;
			this.feature9Button.ImageOver = GFXLibrary.pt_Parish_Wall_over;
			this.feature9Button.ImageClick = GFXLibrary.pt_Parish_Wall_down;
			this.feature9Button.Position = this.getIconPosition(num2++, num);
			this.feature9Button.Data = 8;
			this.feature9Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.iconClicked));
			this.feature9Button.CustomTooltipID = 4308;
			this.background.addControl(this.feature9Button);
			this.feature10Button.ImageNorm = GFXLibrary.pt_Mail;
			this.feature10Button.ImageOver = GFXLibrary.pt_Mail_over;
			this.feature10Button.ImageClick = GFXLibrary.pt_Mail_down;
			this.feature10Button.Position = this.getIconPosition(num2++, num);
			this.feature10Button.Data = 9;
			this.feature10Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.iconClicked));
			this.feature10Button.CustomTooltipID = 4309;
			this.background.addControl(this.feature10Button);
			this.btnLogout.ImageNorm = GFXLibrary.worldSelect_swap_norm;
			this.btnLogout.ImageOver = GFXLibrary.worldSelect_swap_over;
			this.btnLogout.ImageClick = GFXLibrary.worldSelect_swap_pushed;
			this.btnLogout.Position = new Point(245, 516);
			this.btnLogout.Text.Text = SK.Text("GENERIC_Close", "Close");
			this.btnLogout.TextYOffset = -2;
			this.btnLogout.Text.Color = global::ARGBColors.White;
			this.btnLogout.Text.DropShadowColor = global::ARGBColors.Black;
			this.btnLogout.Text.Font = FontManager.GetFont("Arial", 11f, FontStyle.Regular);
			this.btnLogout.Text.Position = new Point(-3, 0);
			this.btnLogout.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.logoutClick));
			this.btnLogout.Enabled = true;
			this.backgroundArea.addControl(this.btnLogout);
			this.showCheck.CheckedImage = GFXLibrary.reports_checkbox_checked;
			this.showCheck.UncheckedImage = GFXLibrary.reports_checkbox_empty;
			this.showCheck.Position = new Point(225, 494);
			this.showCheck.Checked = Program.mySettings.showGameFeaturesScreenIcon;
			this.showCheck.CBLabel.Text = SK.Text("PT_show_icon", "Show Player Guide icon");
			this.showCheck.CBLabel.Color = global::ARGBColors.Black;
			this.showCheck.CBLabel.Position = new Point(20, -1);
			this.showCheck.CBLabel.Size = new Size(360, 35);
			this.showCheck.CBLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.showCheck.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.checkToggled));
			this.backgroundArea.addControl(this.showCheck);
		}

		// Token: 0x06001C6C RID: 7276 RVA: 0x0001BE4C File Offset: 0x0001A04C
		private void checkToggled()
		{
			Program.mySettings.showGameFeaturesScreenIcon = this.showCheck.Checked;
		}

		// Token: 0x06001C6D RID: 7277 RVA: 0x001BCCF0 File Offset: 0x001BAEF0
		private Point getIconPosition(int id, int total)
		{
			if (id == 8 && total == 9)
			{
				return new Point(287, 441);
			}
			int num = id % 4;
			int num2 = id / 4;
			if (num2 == 2)
			{
				num++;
			}
			return new Point(173 + num * 74, 315 + num2 * 63);
		}

		// Token: 0x06001C6E RID: 7278 RVA: 0x001BCD40 File Offset: 0x001BAF40
		private void iconClicked()
		{
			if (this.ClickedControl == null)
			{
				return;
			}
			switch (this.ClickedControl.Data)
			{
			case 0:
				InterfaceMgr.Instance.getMainTabBar().changeTab(3);
				PostTutorialWindow.close();
				return;
			case 1:
				InterfaceMgr.Instance.getMainTabBar().changeTab(4);
				PostTutorialWindow.close();
				return;
			case 2:
				InterfaceMgr.Instance.getMainTabBar().changeTab(4);
				PostTutorialWindow.close();
				return;
			case 3:
				InterfaceMgr.Instance.getMainTabBar().changeTab(5);
				PostTutorialWindow.close();
				return;
			case 4:
				InterfaceMgr.Instance.getMainTabBar().changeTab(7);
				PostTutorialWindow.close();
				return;
			case 5:
				Process.Start(string.Concat(new string[]
				{
					URLs.shieldDesignerURL,
					"?webtoken=",
					RemoteServices.Instance.WebToken,
					"&lang=",
					Program.mySettings.LanguageIdent.ToLower()
				}));
				return;
			case 6:
				InterfaceMgr.Instance.getMainTabBar().selectDummyTab(10);
				PostTutorialWindow.close();
				return;
			case 7:
			{
				string text = URLs.InviteAFriendURL + "?webtoken=" + RemoteServices.Instance.WebToken;
				text = text + "&lang=" + Program.mySettings.LanguageIdent.ToLower();
				try
				{
					Process.Start(text);
					return;
				}
				catch (Exception)
				{
					MyMessageBox.Show(SK.Text("ERROR_Browser1", "Stronghold Kingdoms encountered an error when trying to open your system's Default Web Browser. Please check that your web browser is working correctly and there are no unresponsive copies showing in task manager->Processes and then try again.") + Environment.NewLine + Environment.NewLine + SK.Text("ERROR_Browser2", "If this problem persists, please contact support."), SK.Text("ERROR_Browser3", "Error opening Web Browser"));
					return;
				}
				break;
			}
			case 8:
				break;
			case 9:
				if (InterfaceMgr.Instance.isMailDocked())
				{
					InterfaceMgr.Instance.getMainTabBar().selectDummyTab(21);
				}
				else if (InterfaceMgr.Instance.mailScreenNeedsOpening())
				{
					InterfaceMgr.Instance.initMailSubTab(0);
				}
				else
				{
					InterfaceMgr.Instance.mailScreenRePop();
				}
				PostTutorialWindow.close();
				return;
			default:
				return;
			}
			InterfaceMgr.Instance.getMainTabBar().changeTab(2);
			PostTutorialWindow.close();
		}

		// Token: 0x06001C6F RID: 7279 RVA: 0x0001BE63 File Offset: 0x0001A063
		private void logoutClick()
		{
			PostTutorialWindow.close();
		}

		// Token: 0x04002D35 RID: 11573
		private IContainer components;

		// Token: 0x04002D36 RID: 11574
		private CustomSelfDrawPanel.CSDImage background = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002D37 RID: 11575
		private CustomSelfDrawPanel.CSDArea backgroundArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04002D38 RID: 11576
		private CustomSelfDrawPanel.CSDFill transparentBackground = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x04002D39 RID: 11577
		private CustomSelfDrawPanel.CSDButton btnLogout = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002D3A RID: 11578
		private CustomSelfDrawPanel.CSDLabel header1Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002D3B RID: 11579
		private CustomSelfDrawPanel.CSDLabel header2Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002D3C RID: 11580
		private CustomSelfDrawPanel.CSDLabel header3Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002D3D RID: 11581
		private CustomSelfDrawPanel.CSDButton feature1Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002D3E RID: 11582
		private CustomSelfDrawPanel.CSDButton feature2Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002D3F RID: 11583
		private CustomSelfDrawPanel.CSDButton feature3Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002D40 RID: 11584
		private CustomSelfDrawPanel.CSDButton feature4Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002D41 RID: 11585
		private CustomSelfDrawPanel.CSDButton feature5Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002D42 RID: 11586
		private CustomSelfDrawPanel.CSDButton feature6Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002D43 RID: 11587
		private CustomSelfDrawPanel.CSDButton feature7Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002D44 RID: 11588
		private CustomSelfDrawPanel.CSDButton feature8Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002D45 RID: 11589
		private CustomSelfDrawPanel.CSDButton feature9Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002D46 RID: 11590
		private CustomSelfDrawPanel.CSDButton feature10Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002D47 RID: 11591
		private CustomSelfDrawPanel.CSDCheckBox showCheck = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x04002D48 RID: 11592
		private PostTutorialWindow m_parent;
	}
}
