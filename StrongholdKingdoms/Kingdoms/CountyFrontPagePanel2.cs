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
	// Token: 0x02000150 RID: 336
	public class CountyFrontPagePanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06000C75 RID: 3189 RVA: 0x000EF70C File Offset: 0x000ED90C
		public CountyFrontPagePanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.focusPanel.Focus();
		}

		// Token: 0x06000C76 RID: 3190 RVA: 0x000EF844 File Offset: 0x000EDA44
		public void init()
		{
			int height = base.Height;
			CountyFrontPagePanel2.instance = this;
			base.clearControls();
			int selectedMenuVillage = InterfaceMgr.Instance.getSelectedMenuVillage();
			int countyFromVillageID = GameEngine.Instance.World.getCountyFromVillageID(selectedMenuVillage);
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
				SK.Text("GENERIC_County", "County"),
				" : ",
				GameEngine.Instance.World.getCountyName(countyFromVillageID),
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
			this.sheriffLabel.Text = SK.Text("CountyFrontPagePanel_Current_Sheriff", "Current Sheriff");
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
			CountyFrontPagePanel2.StoredCountyInfo storedCountyInfo = (CountyFrontPagePanel2.StoredCountyInfo)this.countyList[countyFromVillageID];
			bool flag = false;
			if (storedCountyInfo == null || (DateTime.Now - storedCountyInfo.m_lastUpdateTime).TotalMinutes > 2.0 || storedCountyInfo.lastReturnData == null)
			{
				flag = true;
			}
			this.m_currentVillage = selectedMenuVillage;
			if (this.currentCounty != countyFromVillageID)
			{
				this.currentLeaderID = -1;
				this.currentLeaderName = "";
				this.m_userIDOnCurrent = -1;
			}
			this.currentCounty = countyFromVillageID;
			if (flag)
			{
				RemoteServices.Instance.set_GetCountyFrontPageInfo_UserCallBack(new RemoteServices.GetCountyFrontPageInfo_UserCallBack(this.getCountyFrontPageInfoCallback));
				RemoteServices.Instance.GetCountyFrontPageInfo(this.m_currentVillage);
			}
			this.updateLeaderInfo();
			if (!flag)
			{
				this.getCountyFrontPageInfoCallback(storedCountyInfo.lastReturnData);
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
			this.btnChat.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.chatClick), "CountyFrontPagePanel2_chat");
			this.backgroundImage.addControl(this.btnChat);
		}

		// Token: 0x06000C77 RID: 3191 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void update()
		{
		}

		// Token: 0x06000C78 RID: 3192 RVA: 0x0000F3FD File Offset: 0x0000D5FD
		public void logout()
		{
			this.countyList.Clear();
		}

		// Token: 0x06000C79 RID: 3193 RVA: 0x0000F40A File Offset: 0x0000D60A
		private void chatClick()
		{
			if (this.currentCounty >= 0)
			{
				InterfaceMgr.Instance.initChatPanel(2, this.currentCounty);
			}
		}

		// Token: 0x06000C7A RID: 3194 RVA: 0x0000F426 File Offset: 0x0000D626
		public void updateLeaderInfo()
		{
			this.sheriffName.Text = this.currentLeaderName;
			this.m_userIDOnCurrent = this.currentLeaderID;
			this.update();
		}

		// Token: 0x06000C7B RID: 3195 RVA: 0x000F0274 File Offset: 0x000EE474
		public void getCountyFrontPageInfoCallback(GetCountyFrontPageInfo_ReturnType returnData)
		{
			if (!returnData.Success)
			{
				return;
			}
			CountyFrontPagePanel2.StoredCountyInfo storedCountyInfo = (CountyFrontPagePanel2.StoredCountyInfo)this.countyList[returnData.countyID];
			if (storedCountyInfo == null)
			{
				storedCountyInfo = new CountyFrontPagePanel2.StoredCountyInfo();
				this.countyList[returnData.countyID] = storedCountyInfo;
			}
			storedCountyInfo.m_lastUpdateTime = DateTime.Now;
			storedCountyInfo.lastReturnData = returnData;
			if (this.currentCounty == returnData.countyID)
			{
				this.m_userIDOnCurrent = -1;
				this.currentLeaderID = returnData.leaderID;
				this.currentLeaderName = returnData.leaderName;
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
				this.createParishWall(returnData.countyWallInfo);
			}
		}

		// Token: 0x06000C7C RID: 3196 RVA: 0x000F0424 File Offset: 0x000EE624
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

		// Token: 0x06000C7D RID: 3197 RVA: 0x000F0588 File Offset: 0x000EE788
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

		// Token: 0x06000C7E RID: 3198 RVA: 0x000F06CC File Offset: 0x000EE8CC
		private void wallScrollBarMoved()
		{
			int value = this.wallScrollBar.Value;
			this.wallScrollArea.Position = new Point(this.wallScrollArea.X, 15 - value);
			this.wallScrollArea.ClipRect = new Rectangle(this.wallScrollArea.ClipRect.X, value, this.wallScrollArea.ClipRect.Width, this.wallScrollArea.ClipRect.Height);
			this.wallScrollArea.invalidate();
			this.wallScrollBar.invalidate();
		}

		// Token: 0x06000C7F RID: 3199 RVA: 0x0000F44B File Offset: 0x0000D64B
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06000C80 RID: 3200 RVA: 0x0000F45B File Offset: 0x0000D65B
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06000C81 RID: 3201 RVA: 0x0000F46B File Offset: 0x0000D66B
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06000C82 RID: 3202 RVA: 0x0000F47D File Offset: 0x0000D67D
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06000C83 RID: 3203 RVA: 0x0000F48A File Offset: 0x0000D68A
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
		}

		// Token: 0x06000C84 RID: 3204 RVA: 0x0000F49E File Offset: 0x0000D69E
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06000C85 RID: 3205 RVA: 0x0000F4AB File Offset: 0x0000D6AB
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06000C86 RID: 3206 RVA: 0x0000F4B8 File Offset: 0x0000D6B8
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000C87 RID: 3207 RVA: 0x000F0764 File Offset: 0x000EE964
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
			base.Name = "CountyFrontPagePanel2";
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x0400108B RID: 4235
		public static CountyFrontPagePanel2 instance;

		// Token: 0x0400108C RID: 4236
		private SparseArray countyList = new SparseArray();

		// Token: 0x0400108D RID: 4237
		private int currentCounty = -1;

		// Token: 0x0400108E RID: 4238
		private DateTime nextElectionTime = DateTime.MinValue;

		// Token: 0x0400108F RID: 4239
		private int currentLeaderID = -1;

		// Token: 0x04001090 RID: 4240
		private string currentLeaderName = "";

		// Token: 0x04001091 RID: 4241
		private int m_userIDOnCurrent = -1;

		// Token: 0x04001092 RID: 4242
		private int m_currentVillage = -1;

		// Token: 0x04001093 RID: 4243
		private CustomSelfDrawPanel.CSDExtendingPanel wallInfoImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04001094 RID: 4244
		private CustomSelfDrawPanel.CSDVertScrollBar wallScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x04001095 RID: 4245
		private CustomSelfDrawPanel.CSDArea wallScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04001096 RID: 4246
		private CustomSelfDrawPanel.CSDLabel activityLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001097 RID: 4247
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04001098 RID: 4248
		private CustomSelfDrawPanel.CSDExtendingPanel backgroundImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04001099 RID: 4249
		private CustomSelfDrawPanel.CSDLabel parishNameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400109A RID: 4250
		private CustomSelfDrawPanel.CSDExtendingPanel windowImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x0400109B RID: 4251
		private CustomSelfDrawPanel.CSDLabel sheriffLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400109C RID: 4252
		private CustomSelfDrawPanel.CSDLabel sheriffName = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400109D RID: 4253
		private CustomSelfDrawPanel.CSDLabel goldLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400109E RID: 4254
		private CustomSelfDrawPanel.CSDLabel goldValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400109F RID: 4255
		private CustomSelfDrawPanel.CSDLabel taxLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040010A0 RID: 4256
		private CustomSelfDrawPanel.CSDLabel taxValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040010A1 RID: 4257
		private CustomSelfDrawPanel.CSDButton btnChat = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040010A2 RID: 4258
		private List<CustomSelfDrawPanel.ParishWallEntry> lineList = new List<CustomSelfDrawPanel.ParishWallEntry>();

		// Token: 0x040010A3 RID: 4259
		private WallInfo[] origWallInfo;

		// Token: 0x040010A4 RID: 4260
		private List<WallInfo> wallList = new List<WallInfo>();

		// Token: 0x040010A5 RID: 4261
		private DockableControl dockableControl;

		// Token: 0x040010A6 RID: 4262
		private IContainer components;

		// Token: 0x040010A7 RID: 4263
		private Panel focusPanel;

		// Token: 0x02000151 RID: 337
		public class StoredCountyInfo
		{
			// Token: 0x040010A8 RID: 4264
			public GetCountyFrontPageInfo_ReturnType lastReturnData;

			// Token: 0x040010A9 RID: 4265
			public DateTime m_lastUpdateTime = DateTime.MinValue;
		}
	}
}
