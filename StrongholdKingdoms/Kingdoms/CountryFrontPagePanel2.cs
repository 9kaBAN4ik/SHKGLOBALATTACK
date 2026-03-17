using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000149 RID: 329
	public class CountryFrontPagePanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06000C2E RID: 3118 RVA: 0x0000F109 File Offset: 0x0000D309
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06000C2F RID: 3119 RVA: 0x0000F119 File Offset: 0x0000D319
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06000C30 RID: 3120 RVA: 0x0000F129 File Offset: 0x0000D329
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06000C31 RID: 3121 RVA: 0x0000F13B File Offset: 0x0000D33B
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06000C32 RID: 3122 RVA: 0x0000F148 File Offset: 0x0000D348
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
		}

		// Token: 0x06000C33 RID: 3123 RVA: 0x0000F15C File Offset: 0x0000D35C
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06000C34 RID: 3124 RVA: 0x0000F169 File Offset: 0x0000D369
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06000C35 RID: 3125 RVA: 0x0000F176 File Offset: 0x0000D376
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000C36 RID: 3126 RVA: 0x000EBB54 File Offset: 0x000E9D54
		private void InitializeComponent()
		{
			this.focusPanel = new Panel();
			base.SuspendLayout();
			this.focusPanel.BackColor = global::ARGBColors.Transparent;
			this.focusPanel.ForeColor = global::ARGBColors.Transparent;
			this.focusPanel.Location = new Point(988, 3);
			this.focusPanel.Name = "focusPanel";
			this.focusPanel.Size = new Size(1, 1);
			this.focusPanel.TabIndex = 0;
			base.AutoScaleMode = AutoScaleMode.None;
			base.Controls.Add(this.focusPanel);
			this.MaximumSize = new Size(992, 566);
			this.MinimumSize = new Size(992, 566);
			base.Name = "CountryFrontPagePanel2";
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x06000C37 RID: 3127 RVA: 0x000EBC40 File Offset: 0x000E9E40
		public CountryFrontPagePanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.focusPanel.Focus();
		}

		// Token: 0x06000C38 RID: 3128 RVA: 0x000EBD78 File Offset: 0x000E9F78
		public void init()
		{
			int height = base.Height;
			CountryFrontPagePanel2.instance = this;
			base.clearControls();
			int selectedMenuVillage = InterfaceMgr.Instance.getSelectedMenuVillage();
			int countryFromVillageID = GameEngine.Instance.World.getCountryFromVillageID(selectedMenuVillage);
			this.headerImage.Size = new Size(base.Width, 40);
			this.headerImage.Position = new Point(0, 0);
			base.addControl(this.headerImage);
			this.headerImage.Create(GFXLibrary.mail2_titlebar_left, GFXLibrary.mail2_titlebar_middle, GFXLibrary.mail2_titlebar_right);
			CustomSelfDrawPanel.WikiLinkControl.init(this.headerImage, 14, new Point(base.Width - 44, 3));
			this.backgroundImage.Size = new Size(base.Width, height - 40);
			this.backgroundImage.Position = new Point(0, 40);
			base.addControl(this.backgroundImage);
			this.backgroundImage.Create(GFXLibrary.mail2_mail_panel_upper_left, GFXLibrary.mail2_mail_panel_upper_middle, GFXLibrary.mail2_mail_panel_upper_right, GFXLibrary.mail2_mail_panel_middle_left, GFXLibrary.mail2_mail_panel_middle_middle, GFXLibrary.mail2_mail_panel_middle_right, GFXLibrary.mail2_mail_panel_lower_left, GFXLibrary.mail2_mail_panel_lower_middle, GFXLibrary.mail2_mail_panel_lower_right);
			this.parishNameLabel.Text = string.Concat(new string[]
			{
				SK.Text("GENERIC_Country", "Country"),
				" : ",
				GameEngine.Instance.World.getCountryName(countryFromVillageID),
				" (",
				GameEngine.Instance.World.getVillageName(selectedMenuVillage),
				")"
			});
			this.parishNameLabel.Color = global::ARGBColors.White;
			this.parishNameLabel.DropShadowColor = global::ARGBColors.Black;
			this.parishNameLabel.Position = new Point(20, 0);
			this.parishNameLabel.Size = new Size(base.Width - 40, 40);
			this.parishNameLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
			this.parishNameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerImage.addControl(this.parishNameLabel);
			this.windowImage.Size = new Size(400, 150);
			this.windowImage.Position = new Point(493, 130);
			this.backgroundImage.addControl(this.windowImage);
			this.windowImage.Create(GFXLibrary.mail2_rounded_rectangle_tan_upper_left, GFXLibrary.mail2_rounded_rectangle_tan_upper_middle, GFXLibrary.mail2_rounded_rectangle_tan_upper_right, GFXLibrary.mail2_rounded_rectangle_tan_middle_left, GFXLibrary.mail2_rounded_rectangle_tan_middle_middle, GFXLibrary.mail2_rounded_rectangle_tan_middle_right, GFXLibrary.mail2_rounded_rectangle_tan_bottom_left, GFXLibrary.mail2_rounded_rectangle_tan_bottom_middle, GFXLibrary.mail2_rounded_rectangle_tan_bottom_right);
			this.sheriffLabel.Text = SK.Text("CountryFrontPagePanel_Current_King", "Current King");
			this.sheriffLabel.Position = new Point(30, 26);
			this.sheriffLabel.Size = new Size(250, 40);
			this.sheriffLabel.Color = global::ARGBColors.Black;
			this.sheriffLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.sheriffLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.windowImage.addControl(this.sheriffLabel);
			this.goldLabel.Text = SK.Text("GENERIC_Current_Gold", "Current Gold");
			this.goldLabel.Position = new Point(30, 66);
			this.goldLabel.Size = new Size(250, 40);
			this.goldLabel.Color = global::ARGBColors.Black;
			this.goldLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.goldLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.windowImage.addControl(this.goldLabel);
			this.taxLabel.Text = SK.Text("GENERIC_Tax_Rate", "Tax Rate");
			this.taxLabel.Position = new Point(30, 106);
			this.taxLabel.Size = new Size(250, 40);
			this.taxLabel.Color = global::ARGBColors.Black;
			this.taxLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.taxLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.windowImage.addControl(this.taxLabel);
			this.sheriffName.Text = "";
			this.sheriffName.Position = new Point(170, 26);
			this.sheriffName.Size = new Size(200, 40);
			this.sheriffName.Color = global::ARGBColors.Black;
			this.sheriffName.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.sheriffName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.windowImage.addControl(this.sheriffName);
			this.goldValue.Text = "";
			this.goldValue.Position = new Point(170, 66);
			this.goldValue.Size = new Size(200, 40);
			this.goldValue.Color = global::ARGBColors.Black;
			this.goldValue.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.goldValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.windowImage.addControl(this.goldValue);
			this.taxValue.Text = "";
			this.taxValue.Position = new Point(170, 106);
			this.taxValue.Size = new Size(200, 40);
			this.taxValue.Color = global::ARGBColors.Black;
			this.taxValue.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.taxValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.windowImage.addControl(this.taxValue);
			this.activityLabel.Text = SK.Text("WALL_recent_activity", "Recent Activity");
			this.activityLabel.Position = new Point(8, -16);
			this.activityLabel.Size = new Size(388, 40);
			this.activityLabel.Color = global::ARGBColors.Black;
			this.activityLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.activityLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_CENTER;
			this.backgroundImage.addControl(this.activityLabel);
			this.wallInfoImage.Size = new Size(396, height - 80);
			this.wallInfoImage.Position = new Point(8, 29);
			this.backgroundImage.addControl(this.wallInfoImage);
			this.wallInfoImage.Create(GFXLibrary.mail2_rounded_rectangle_tan_upper_left, GFXLibrary.mail2_rounded_rectangle_tan_upper_middle, GFXLibrary.mail2_rounded_rectangle_tan_upper_right, GFXLibrary.mail2_rounded_rectangle_tan_middle_left, GFXLibrary.mail2_rounded_rectangle_tan_middle_middle, GFXLibrary.mail2_rounded_rectangle_tan_middle_right, GFXLibrary.mail2_rounded_rectangle_tan_bottom_left, GFXLibrary.mail2_rounded_rectangle_tan_bottom_middle, GFXLibrary.mail2_rounded_rectangle_tan_bottom_right);
			this.wallScrollArea.Position = new Point(15, 15);
			this.wallScrollArea.Size = new Size(337, height - 101);
			this.wallScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(337, height - 101));
			this.wallInfoImage.addControl(this.wallScrollArea);
			int value = this.wallScrollBar.Value;
			this.wallScrollBar.Visible = false;
			this.wallScrollBar.Position = new Point(358, 15);
			this.wallScrollBar.Size = new Size(24, height - 101);
			this.wallInfoImage.addControl(this.wallScrollBar);
			this.wallScrollBar.Value = 0;
			this.wallScrollBar.Max = 100;
			this.wallScrollBar.NumVisibleLines = 25;
			this.wallScrollBar.Create(null, null, null, GFXLibrary._24wide_thumb_top, GFXLibrary._24wide_thumb_middle, GFXLibrary._24wide_thumb_bottom);
			this.wallScrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.wallScrollBarMoved));
			CountryFrontPagePanel2.StoredCountryInfo storedCountryInfo = (CountryFrontPagePanel2.StoredCountryInfo)this.countryList[countryFromVillageID];
			bool flag = false;
			if (storedCountryInfo == null || (DateTime.Now - storedCountryInfo.m_lastUpdateTime).TotalMinutes > 2.0 || storedCountryInfo.lastReturnData == null)
			{
				flag = true;
			}
			this.m_currentVillage = selectedMenuVillage;
			if (this.currentCountry != countryFromVillageID)
			{
				this.currentLeaderID = -1;
				this.currentLeaderName = "";
				this.m_userIDOnCurrent = -1;
			}
			this.currentCountry = countryFromVillageID;
			if (flag)
			{
				RemoteServices.Instance.set_GetCountryFrontPageInfo_UserCallBack(new RemoteServices.GetCountryFrontPageInfo_UserCallBack(this.getCountryFrontPageInfoCallback));
				RemoteServices.Instance.GetCountryFrontPageInfo(this.m_currentVillage);
			}
			this.updateLeaderInfo();
			if (!flag)
			{
				this.getCountryFrontPageInfoCallback(storedCountryInfo.lastReturnData);
			}
			this.btnChat.ImageNorm = GFXLibrary.misc_button_blue_210wide_normal;
			this.btnChat.ImageOver = GFXLibrary.misc_button_blue_210wide_over;
			this.btnChat.ImageClick = GFXLibrary.misc_button_blue_210wide_pushed;
			this.btnChat.Position = new Point(base.Width - 230, base.Height - 90);
			this.btnChat.Text.Text = SK.Text("GENERIC_Chat", "Chat");
			this.btnChat.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.btnChat.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.btnChat.TextYOffset = -3;
			this.btnChat.Text.Color = global::ARGBColors.Black;
			this.btnChat.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.chatClick), "CountryFrontPagePanel2_chat");
			this.backgroundImage.addControl(this.btnChat);
		}

		// Token: 0x06000C39 RID: 3129 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void update()
		{
		}

		// Token: 0x06000C3A RID: 3130 RVA: 0x0000F195 File Offset: 0x0000D395
		public void logout()
		{
			this.countryList.Clear();
		}

		// Token: 0x06000C3B RID: 3131 RVA: 0x0000F1A2 File Offset: 0x0000D3A2
		private void chatClick()
		{
			if (this.currentCountry >= 0)
			{
				InterfaceMgr.Instance.initChatPanel(0, this.currentCountry);
			}
		}

		// Token: 0x06000C3C RID: 3132 RVA: 0x000EC7A8 File Offset: 0x000EA9A8
		public void updateLeaderInfo()
		{
			if (!string.IsNullOrEmpty(this.currentLeaderName))
			{
				if (this.currentLeaderMale)
				{
					this.sheriffLabel.Text = SK.Text("CountryFrontPagePanel_Current_King", "Current King");
				}
				else
				{
					this.sheriffLabel.Text = SK.Text("CountryFrontPagePanel_Current_Queen", "Current Queen");
				}
			}
			else
			{
				this.sheriffLabel.Text = "";
			}
			this.sheriffName.Text = this.currentLeaderName;
			this.m_userIDOnCurrent = this.currentLeaderID;
			this.update();
		}

		// Token: 0x06000C3D RID: 3133 RVA: 0x000EC838 File Offset: 0x000EAA38
		public void getCountryFrontPageInfoCallback(GetCountryFrontPageInfo_ReturnType returnData)
		{
			if (!returnData.Success)
			{
				return;
			}
			CountryFrontPagePanel2.StoredCountryInfo storedCountryInfo = (CountryFrontPagePanel2.StoredCountryInfo)this.countryList[returnData.countryID];
			if (storedCountryInfo == null)
			{
				storedCountryInfo = new CountryFrontPagePanel2.StoredCountryInfo();
				this.countryList[returnData.countryID] = storedCountryInfo;
			}
			storedCountryInfo.m_lastUpdateTime = DateTime.Now;
			storedCountryInfo.lastReturnData = returnData;
			if (this.currentCountry == returnData.countryID)
			{
				this.m_userIDOnCurrent = -1;
				this.currentLeaderID = returnData.leaderID;
				this.currentLeaderName = returnData.leaderName;
				this.currentLeaderMale = returnData.leaderMale;
				this.updateLeaderInfo();
				NumberFormatInfo nfi = GameEngine.NFI;
				switch (returnData.taxRate)
				{
				case 0:
					this.taxValue.Text = "0";
					break;
				case 1:
					this.taxValue.Text = "x1";
					break;
				case 2:
					this.taxValue.Text = "x2";
					break;
				case 3:
					this.taxValue.Text = "x3";
					break;
				case 4:
					this.taxValue.Text = "x4";
					break;
				case 5:
					this.taxValue.Text = "x5";
					break;
				case 6:
					this.taxValue.Text = "x6";
					break;
				case 7:
					this.taxValue.Text = "x7";
					break;
				case 8:
					this.taxValue.Text = "x8";
					break;
				case 9:
					this.taxValue.Text = "x9";
					break;
				}
				this.goldValue.Text = returnData.gold.ToString("N", nfi);
				this.createParishWall(returnData.countryWallInfo);
			}
		}

		// Token: 0x06000C3E RID: 3134 RVA: 0x000EC9F4 File Offset: 0x000EABF4
		private void createParishWall(WallInfo[] wallInfos)
		{
			this.origWallInfo = wallInfos;
			List<WallInfo> list = new List<WallInfo>();
			this.wallList.Clear();
			foreach (WallInfo wallInfo in wallInfos)
			{
				if (wallInfo.entryType == 1)
				{
					bool flag = false;
					foreach (WallInfo wallInfo2 in list)
					{
						if (wallInfo2.userID == wallInfo.userID)
						{
							flag = true;
							wallInfo2.fData1 += wallInfo.fData1;
							wallInfo2.data4 += wallInfo.data4;
						}
					}
					if (!flag)
					{
						WallInfo wallInfo3 = new WallInfo();
						wallInfo3.data1 = wallInfo.data1;
						wallInfo3.data2 = wallInfo.data2;
						wallInfo3.data3 = wallInfo.data3;
						wallInfo3.data4 = wallInfo.data4;
						wallInfo3.fData1 = wallInfo.fData1;
						wallInfo3.entryType = wallInfo.entryType;
						wallInfo3.userID = wallInfo.userID;
						wallInfo3.username = wallInfo.username;
						list.Add(wallInfo3);
						this.wallList.Add(wallInfo3);
					}
				}
				else
				{
					this.wallList.Add(wallInfo);
				}
			}
			this.updateWallArea();
		}

		// Token: 0x06000C3F RID: 3135 RVA: 0x000ECB58 File Offset: 0x000EAD58
		public void updateWallArea()
		{
			this.wallScrollArea.clearControls();
			int num = 0;
			this.lineList.Clear();
			int num2 = 0;
			foreach (WallInfo wallInfo in this.wallList)
			{
				CustomSelfDrawPanel.ParishWallEntry parishWallEntry = new CustomSelfDrawPanel.ParishWallEntry();
				if (num != 0)
				{
					num += 5;
				}
				parishWallEntry.Position = new Point(0, num);
				parishWallEntry.init(wallInfo, num2, this.m_currentVillage, this);
				this.wallScrollArea.addControl(parishWallEntry);
				num += parishWallEntry.Height;
				this.lineList.Add(parishWallEntry);
				num2++;
			}
			this.wallScrollArea.Size = new Size(this.wallScrollArea.Width, num);
			if (num < this.wallScrollBar.Height)
			{
				this.wallScrollBar.Visible = false;
			}
			else
			{
				this.wallScrollBar.Visible = true;
				this.wallScrollBar.NumVisibleLines = this.wallScrollBar.Height;
				this.wallScrollBar.Max = num - this.wallScrollBar.Height;
			}
			this.wallScrollArea.invalidate();
			this.wallScrollBar.invalidate();
		}

		// Token: 0x06000C40 RID: 3136 RVA: 0x000ECC9C File Offset: 0x000EAE9C
		private void wallScrollBarMoved()
		{
			int value = this.wallScrollBar.Value;
			this.wallScrollArea.Position = new Point(this.wallScrollArea.X, 15 - value);
			this.wallScrollArea.ClipRect = new Rectangle(this.wallScrollArea.ClipRect.X, value, this.wallScrollArea.ClipRect.Width, this.wallScrollArea.ClipRect.Height);
			this.wallScrollArea.invalidate();
			this.wallScrollBar.invalidate();
		}

		// Token: 0x04001027 RID: 4135
		private DockableControl dockableControl;

		// Token: 0x04001028 RID: 4136
		private IContainer components;

		// Token: 0x04001029 RID: 4137
		private Panel focusPanel;

		// Token: 0x0400102A RID: 4138
		public static CountryFrontPagePanel2 instance;

		// Token: 0x0400102B RID: 4139
		private SparseArray countryList = new SparseArray();

		// Token: 0x0400102C RID: 4140
		private int currentCountry = -1;

		// Token: 0x0400102D RID: 4141
		private DateTime nextElectionTime = DateTime.MinValue;

		// Token: 0x0400102E RID: 4142
		private int currentLeaderID = -1;

		// Token: 0x0400102F RID: 4143
		private string currentLeaderName = "";

		// Token: 0x04001030 RID: 4144
		private bool currentLeaderMale;

		// Token: 0x04001031 RID: 4145
		private int m_userIDOnCurrent = -1;

		// Token: 0x04001032 RID: 4146
		private int m_currentVillage = -1;

		// Token: 0x04001033 RID: 4147
		private CustomSelfDrawPanel.CSDExtendingPanel wallInfoImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04001034 RID: 4148
		private CustomSelfDrawPanel.CSDVertScrollBar wallScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x04001035 RID: 4149
		private CustomSelfDrawPanel.CSDArea wallScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04001036 RID: 4150
		private CustomSelfDrawPanel.CSDLabel activityLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001037 RID: 4151
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04001038 RID: 4152
		private CustomSelfDrawPanel.CSDExtendingPanel backgroundImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04001039 RID: 4153
		private CustomSelfDrawPanel.CSDLabel parishNameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400103A RID: 4154
		private CustomSelfDrawPanel.CSDExtendingPanel windowImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x0400103B RID: 4155
		private CustomSelfDrawPanel.CSDLabel sheriffLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400103C RID: 4156
		private CustomSelfDrawPanel.CSDLabel sheriffName = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400103D RID: 4157
		private CustomSelfDrawPanel.CSDLabel goldLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400103E RID: 4158
		private CustomSelfDrawPanel.CSDLabel goldValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400103F RID: 4159
		private CustomSelfDrawPanel.CSDLabel taxLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001040 RID: 4160
		private CustomSelfDrawPanel.CSDLabel taxValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001041 RID: 4161
		private CustomSelfDrawPanel.CSDButton btnChat = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001042 RID: 4162
		private List<CustomSelfDrawPanel.ParishWallEntry> lineList = new List<CustomSelfDrawPanel.ParishWallEntry>();

		// Token: 0x04001043 RID: 4163
		private WallInfo[] origWallInfo;

		// Token: 0x04001044 RID: 4164
		private List<WallInfo> wallList = new List<WallInfo>();

		// Token: 0x0200014A RID: 330
		public class StoredCountryInfo
		{
			// Token: 0x04001045 RID: 4165
			public GetCountryFrontPageInfo_ReturnType lastReturnData;

			// Token: 0x04001046 RID: 4166
			public DateTime m_lastUpdateTime = DateTime.MinValue;
		}
	}
}
