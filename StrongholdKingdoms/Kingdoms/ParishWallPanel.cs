using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x0200026E RID: 622
	public class ParishWallPanel : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06001BAE RID: 7086 RVA: 0x0001B790 File Offset: 0x00019990
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06001BAF RID: 7087 RVA: 0x0001B7A0 File Offset: 0x000199A0
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06001BB0 RID: 7088 RVA: 0x0001B7B0 File Offset: 0x000199B0
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06001BB1 RID: 7089 RVA: 0x0001B7C2 File Offset: 0x000199C2
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06001BB2 RID: 7090 RVA: 0x0001B7CF File Offset: 0x000199CF
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
			this.closing();
		}

		// Token: 0x06001BB3 RID: 7091 RVA: 0x0001B7E9 File Offset: 0x000199E9
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06001BB4 RID: 7092 RVA: 0x0001B7F6 File Offset: 0x000199F6
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06001BB5 RID: 7093 RVA: 0x0001B803 File Offset: 0x00019A03
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001BB6 RID: 7094 RVA: 0x001AFD38 File Offset: 0x001ADF38
		private void InitializeComponent()
		{
			this.textBox1 = new TextBox();
			this.focusPanel = new Panel();
			base.SuspendLayout();
			this.textBox1.BackColor = Color.FromArgb(134, 153, 165);
			this.textBox1.BorderStyle = BorderStyle.None;
			this.textBox1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.textBox1.ForeColor = global::ARGBColors.Black;
			this.textBox1.Location = new Point(439, 94);
			this.textBox1.MaxLength = 100;
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new Size(461, 18);
			this.textBox1.TabIndex = 99;
			this.textBox1.Text = "Enter text here";
			this.textBox1.WordWrap = false;
			this.textBox1.KeyPress += this.textBox1_KeyPress;
			this.textBox1.Enter += this.textBox1_Enter;
			this.focusPanel.BackColor = global::ARGBColors.Transparent;
			this.focusPanel.ForeColor = global::ARGBColors.Transparent;
			this.focusPanel.Location = new Point(988, 3);
			this.focusPanel.Name = "focusPanel";
			this.focusPanel.Size = new Size(1, 1);
			this.focusPanel.TabIndex = 0;
			base.AutoScaleMode = AutoScaleMode.None;
			base.Controls.Add(this.focusPanel);
			base.Controls.Add(this.textBox1);
			this.MaximumSize = new Size(992, 10000);
			this.MinimumSize = new Size(992, 566);
			base.Name = "ParishWallPanel";
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x06001BB7 RID: 7095 RVA: 0x001AFF4C File Offset: 0x001AE14C
		public ParishWallPanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			this.textBox1.Font = FontManager.GetFont("Microsoft Sans Serif", 9.75f);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.focusPanel.Focus();
		}

		// Token: 0x06001BB8 RID: 7096 RVA: 0x001B00E0 File Offset: 0x001AE2E0
		public void init(bool resized)
		{
			int villageID = this.m_currentVillage = InterfaceMgr.Instance.getSelectedMenuVillage();
			int parishFromVillageID = GameEngine.Instance.World.getParishFromVillageID(villageID);
			int height = base.Height;
			ParishWallPanel.instance = this;
			base.clearControls();
			this.headerImage.Size = new Size(base.Width, 40);
			this.headerImage.Position = new Point(0, 0);
			base.addControl(this.headerImage);
			this.headerImage.Create(GFXLibrary.mail2_titlebar_left, GFXLibrary.mail2_titlebar_middle, GFXLibrary.mail2_titlebar_right);
			CustomSelfDrawPanel.WikiLinkControl.init(this.headerImage, 14, new Point(base.Width - 44, 3));
			this.backgroundImage.Size = new Size(base.Width, height - 40);
			this.backgroundImage.Position = new Point(0, 40);
			base.addControl(this.backgroundImage);
			this.backgroundImage.Create(GFXLibrary.mail2_mail_panel_upper_left, GFXLibrary.mail2_mail_panel_upper_middle, GFXLibrary.mail2_mail_panel_upper_right, GFXLibrary.mail2_mail_panel_middle_left, GFXLibrary.mail2_mail_panel_middle_middle, GFXLibrary.mail2_mail_panel_middle_right, GFXLibrary.mail2_mail_panel_lower_left, GFXLibrary.mail2_mail_panel_lower_middle, GFXLibrary.mail2_mail_panel_lower_right);
			this.parishNameLabel.Text = GameEngine.Instance.World.getParishName(parishFromVillageID);
			this.parishNameLabel.Color = global::ARGBColors.White;
			this.parishNameLabel.DropShadowColor = global::ARGBColors.Black;
			this.parishNameLabel.Position = new Point(20, 0);
			this.parishNameLabel.Size = new Size(base.Width - 40, 40);
			this.parishNameLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
			this.parishNameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerImage.addControl(this.parishNameLabel);
			this.illustrationImage.Image = GFXLibrary.parishwall_village_illlustration_01;
			this.illustrationImage.Position = new Point(17, 5);
			this.backgroundImage.addControl(this.illustrationImage);
			this.stewardLabel.Text = SK.Text("ParishWallPanel_Steward", "Steward") + " : ";
			this.stewardLabel.Color = global::ARGBColors.Black;
			this.stewardLabel.Position = new Point(5, 5);
			this.stewardLabel.Size = new Size(this.illustrationImage.Width - 6, 30);
			this.stewardLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.stewardLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.illustrationImage.addControl(this.stewardLabel);
			this.wallInfoImage.Size = new Size(396, height - 170);
			this.wallInfoImage.Position = new Point(8, 119);
			this.backgroundImage.addControl(this.wallInfoImage);
			this.wallInfoImage.Create(GFXLibrary.mail2_rounded_rectangle_tan_upper_left, GFXLibrary.mail2_rounded_rectangle_tan_upper_middle, GFXLibrary.mail2_rounded_rectangle_tan_upper_right, GFXLibrary.mail2_rounded_rectangle_tan_middle_left, GFXLibrary.mail2_rounded_rectangle_tan_middle_middle, GFXLibrary.mail2_rounded_rectangle_tan_middle_right, GFXLibrary.mail2_rounded_rectangle_tan_bottom_left, GFXLibrary.mail2_rounded_rectangle_tan_bottom_middle, GFXLibrary.mail2_rounded_rectangle_tan_bottom_right);
			this.areaWindow.Size = new Size(564, height - 78);
			this.areaWindow.Position = new Point(411, 26);
			this.backgroundImage.addControl(this.areaWindow);
			this.areaWindow.Create(GFXLibrary.parishwall_village_center_tab_outline_top_left, GFXLibrary.parishwall_village_center_tab_outline_top_middle, GFXLibrary.parishwall_village_center_tab_outline_top_right, GFXLibrary.parishwall_village_center_tab_outline_middle_left, null, GFXLibrary.parishwall_village_center_tab_outline_middle_right, GFXLibrary.parishwall_village_center_tab_outline_bottom_left, GFXLibrary.parishwall_village_center_tab_outline_bottom_middle, GFXLibrary.parishwall_village_center_tab_outline_bottom_right);
			this.tab1Button.UseTextSize = true;
			this.tab1Button.ImageNorm = GFXLibrary.parishwall_village_center_tab_up;
			this.tab1Button.ImageOver = GFXLibrary.parishwall_village_center_tab_up;
			this.tab1Button.Position = new Point(425, 6);
			this.tab1Button.Text.Text = SK.Text("ParishWallPanel_General", "General");
			this.tab1Button.Text.Size = new Size(this.tab1Button.Size.Width, this.tab1Button.Text.Size.Height + 20);
			this.tab1Button.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.tab1Button.TextYOffset = 3;
			this.tab1Button.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.tab1Button.Text.Color = global::ARGBColors.Black;
			this.tab1Button.Data = 0;
			this.tab1Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.tabClick), "ParishWallPanel_tab");
			this.backgroundImage.addControl(this.tab1Button);
			this.tab2Button.UseTextSize = true;
			this.tab2Button.ImageNorm = GFXLibrary.parishwall_village_center_tab_down;
			this.tab2Button.ImageOver = GFXLibrary.parishwall_village_center_tab_down;
			this.tab2Button.Position = new Point(510, 6);
			this.tab2Button.Text.Text = SK.Text("ParishWallPanel_War", "War");
			this.tab2Button.Text.Size = new Size(this.tab2Button.Size.Width, this.tab2Button.Text.Size.Height + 20);
			this.tab2Button.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.tab2Button.TextYOffset = 3;
			this.tab2Button.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.tab2Button.Text.Color = global::ARGBColors.Black;
			this.tab2Button.Data = 1;
			this.tab2Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.tabClick), "ParishWallPanel_tab");
			this.backgroundImage.addControl(this.tab2Button);
			this.tab3Button.UseTextSize = true;
			this.tab3Button.ImageNorm = GFXLibrary.parishwall_village_center_tab_down;
			this.tab3Button.ImageOver = GFXLibrary.parishwall_village_center_tab_down;
			this.tab3Button.Position = new Point(595, 6);
			this.tab3Button.Text.Text = SK.Text("ParishWallPanel_inn", "Inn");
			this.tab3Button.Text.Size = new Size(this.tab3Button.Size.Width, this.tab3Button.Text.Size.Height + 20);
			this.tab3Button.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.tab3Button.TextYOffset = 3;
			this.tab3Button.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.tab3Button.Text.Color = global::ARGBColors.Black;
			this.tab3Button.Data = 2;
			this.tab3Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.tabClick), "ParishWallPanel_tab");
			this.backgroundImage.addControl(this.tab3Button);
			this.tab4Button.UseTextSize = true;
			this.tab4Button.ImageNorm = GFXLibrary.parishwall_village_center_tab_down;
			this.tab4Button.ImageOver = GFXLibrary.parishwall_village_center_tab_down;
			this.tab4Button.Position = new Point(680, 6);
			this.tab4Button.Text.Text = SK.Text("ParishWallPanel_Steward", "Steward");
			this.tab4Button.Text.Size = new Size(this.tab4Button.Size.Width, this.tab4Button.Text.Size.Height + 20);
			this.tab4Button.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.tab4Button.TextYOffset = 3;
			this.tab4Button.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.tab4Button.Text.Color = global::ARGBColors.Black;
			this.tab4Button.Data = 3;
			this.tab4Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.tabClick), "ParishWallPanel_tab");
			this.backgroundImage.addControl(this.tab4Button);
			this.tab5Button.UseTextSize = true;
			this.tab5Button.ImageNorm = GFXLibrary.parishwall_village_center_tab_down;
			this.tab5Button.ImageOver = GFXLibrary.parishwall_village_center_tab_down;
			this.tab5Button.Position = new Point(765, 6);
			this.tab5Button.Text.Text = SK.Text("ParishWallPanel_Free", "Free");
			this.tab5Button.Text.Size = new Size(this.tab5Button.Size.Width, this.tab5Button.Text.Size.Height + 20);
			this.tab5Button.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.tab5Button.TextYOffset = 3;
			this.tab5Button.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.tab5Button.Text.Color = global::ARGBColors.Black;
			this.tab5Button.Data = 4;
			this.tab5Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.tabClick), "ParishWallPanel_tab");
			this.backgroundImage.addControl(this.tab5Button);
			this.tab6Button.UseTextSize = true;
			this.tab6Button.ImageNorm = GFXLibrary.parishwall_village_center_tab_down;
			this.tab6Button.ImageOver = GFXLibrary.parishwall_village_center_tab_down;
			this.tab6Button.Position = new Point(850, 6);
			this.tab6Button.Text.Text = SK.Text("ParishWallPanel_Free", "Free");
			this.tab6Button.Text.Size = new Size(this.tab6Button.Size.Width, this.tab6Button.Text.Size.Height + 20);
			this.tab6Button.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.tab6Button.TextYOffset = 3;
			this.tab6Button.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.tab6Button.Text.Color = global::ARGBColors.Black;
			this.tab6Button.Data = 5;
			this.tab6Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.tabClick), "ParishWallPanel_tab");
			this.backgroundImage.addControl(this.tab6Button);
			this.textInputImage.Image = GFXLibrary.parishwall_what_say_thou_box;
			this.textInputImage.Position = new Point(432, 47);
			this.backgroundImage.addControl(this.textInputImage);
			this.wallScrollArea.Position = new Point(15, 15);
			this.wallScrollArea.Size = new Size(337, height - 191);
			this.wallScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(337, height - 191));
			this.wallInfoImage.addControl(this.wallScrollArea);
			int num = this.wallScrollBar.Value;
			this.wallScrollBar.Visible = false;
			this.wallScrollBar.Position = new Point(358, 15);
			this.wallScrollBar.Size = new Size(24, height - 191);
			this.wallInfoImage.addControl(this.wallScrollBar);
			this.wallScrollBar.Value = 0;
			this.wallScrollBar.Max = 100;
			this.wallScrollBar.NumVisibleLines = 25;
			this.wallScrollBar.Create(null, null, null, GFXLibrary._24wide_thumb_top, GFXLibrary._24wide_thumb_middle, GFXLibrary._24wide_thumb_bottom);
			this.wallScrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.wallScrollBarMoved));
			if (!resized)
			{
				this.focusPanel.Focus();
				this.initialTextInTextbox = true;
				this.textBox1.Text = SK.Text("ParishWallPanel_Enter_Text_Here", "Enter Text Here");
				ParishWallPanel.StoredParishInfo storedParishInfo = (ParishWallPanel.StoredParishInfo)this.parishList[parishFromVillageID];
				bool flag = false;
				if (storedParishInfo == null || (DateTime.Now - storedParishInfo.m_lastUpdateTime).TotalMinutes > 1.0 || storedParishInfo.lastReturnData == null)
				{
					flag = true;
				}
				if (this.chatAreas == null)
				{
					this.chatAreas = new CustomSelfDrawPanel.ParishChatPanel[6];
					for (int i = 0; i < 6; i++)
					{
						CustomSelfDrawPanel.ParishChatPanel parishChatPanel = new CustomSelfDrawPanel.ParishChatPanel();
						parishChatPanel.Position = new Point(20, 68);
						parishChatPanel.Size = new Size(534, height - 153);
						this.chatAreas[i] = parishChatPanel;
					}
				}
				if (this.currentParish != parishFromVillageID || this.forceNextUpdate)
				{
					this.forceNextUpdate = false;
					this.currentLeaderID = -1;
					this.electedLeaderID = -1;
					this.currentLeaderName = "";
					this.electedLeaderName = "";
					ParishWallPanel.m_userIDOnCurrent = -1;
					this.checkTextUpdateTime = 5;
					int num2 = 0;
					CustomSelfDrawPanel.ParishChatPanel[] array = this.chatAreas;
					foreach (CustomSelfDrawPanel.ParishChatPanel parishChatPanel2 in array)
					{
						this.areaWindow.addControl(parishChatPanel2);
						parishChatPanel2.Visible = false;
						parishChatPanel2.reset(this, num2);
						if (GameEngine.Instance.Village != null)
						{
							parishChatPanel2.importText(GameEngine.Instance.World.getParishChat(parishFromVillageID, num2, GameEngine.Instance.Village.m_ownedDate).ToArray(), false, -1L);
						}
						parishChatPanel2.scrollToBottom();
						parishChatPanel2.Visible = false;
						num2++;
					}
					long[] readIDs = new long[]
					{
						-1L,
						-1L,
						-1L,
						-1L,
						-1L,
						-1L
					};
					int[] array3 = GameEngine.Instance.World.setReadIDs(parishFromVillageID, readIDs);
					if (array3 != null)
					{
						for (int k = 0; k < 6; k++)
						{
							this.chatAreas[k].setUnreads(array3[k]);
						}
					}
					this.currentParish = parishFromVillageID;
					this.tabEntered(0);
				}
				else
				{
					CustomSelfDrawPanel.ParishChatPanel[] array4 = this.chatAreas;
					foreach (CustomSelfDrawPanel.ParishChatPanel parishChatPanel3 in array4)
					{
						parishChatPanel3.Repopulate = true;
						parishChatPanel3.Size = new Size(534, height - 153);
						this.areaWindow.addControl(parishChatPanel3);
						parishChatPanel3.Visible = false;
					}
					this.currentParish = parishFromVillageID;
					this.tabEntered(this.lastTab);
				}
				this.currentParish = parishFromVillageID;
				if (GameEngine.Instance.Village != null)
				{
					if (flag)
					{
						RemoteServices.Instance.set_GetParishFrontPageInfo_UserCallBack(new RemoteServices.GetParishFrontPageInfo_UserCallBack(this.getParishFrontPageCallback));
						RemoteServices.Instance.GetParishFrontPageInfo(this.m_currentVillage, DateTime.MinValue);
						Thread.Sleep(500);
					}
					else
					{
						DateTime lastUpdateTime = storedParishInfo.m_lastUpdateTime;
						this.getParishFrontPageCallback(storedParishInfo.lastReturnData);
						storedParishInfo.m_lastUpdateTime = lastUpdateTime;
					}
					this.inSend = true;
					RemoteServices.Instance.set_Chat_ReceiveParishText_UserCallBack(new RemoteServices.Chat_ReceiveParishText_UserCallBack(this.chat_ReceiveParishTextCallback));
					RemoteServices.Instance.Chat_ReceiveParishText(this.currentParish, GameEngine.Instance.World.getParishChatNewestPostTime(this.currentParish, GameEngine.Instance.Village.m_ownedDate));
				}
				else
				{
					this.forceNextUpdate = true;
				}
			}
			else
			{
				this.updateWallArea();
				if (num > 0 && this.wallScrollBar.Visible)
				{
					if (num >= this.wallScrollBar.Max)
					{
						num = this.wallScrollBar.Max;
					}
					this.wallScrollBar.Value = num;
					this.wallScrollBarMoved();
				}
				int num3 = 0;
				CustomSelfDrawPanel.ParishChatPanel[] array6 = this.chatAreas;
				foreach (CustomSelfDrawPanel.ParishChatPanel parishChatPanel4 in array6)
				{
					parishChatPanel4.Size = new Size(534, height - 153);
					this.areaWindow.addControl(parishChatPanel4);
					parishChatPanel4.reset(this, num3);
					if (GameEngine.Instance.Village != null)
					{
						parishChatPanel4.importText(GameEngine.Instance.World.getParishChat(parishFromVillageID, num3, GameEngine.Instance.Village.m_ownedDate).ToArray(), false, -1L);
					}
					parishChatPanel4.scrollToBottom();
					parishChatPanel4.Visible = false;
					num3++;
				}
				this.tabEntered(this.lastTab);
			}
			this.updateLeaderInfo();
		}

		// Token: 0x06001BB9 RID: 7097 RVA: 0x001B122C File Offset: 0x001AF42C
		public void update()
		{
			DateTime now = DateTime.Now;
			if ((now - this.lastRequestTime).TotalSeconds > (double)this.checkTextUpdateTime && !this.inSend && RemoteServices.Instance.ChatActive && GameEngine.Instance.Village != null)
			{
				this.inSend = true;
				RemoteServices.Instance.set_Chat_ReceiveParishText_UserCallBack(new RemoteServices.Chat_ReceiveParishText_UserCallBack(this.chat_ReceiveParishTextCallback));
				RemoteServices.Instance.Chat_ReceiveParishText(this.currentParish, GameEngine.Instance.World.getParishChatNewestPostTime(this.currentParish, GameEngine.Instance.Village.m_ownedDate));
			}
		}

		// Token: 0x06001BBA RID: 7098 RVA: 0x001B12D0 File Offset: 0x001AF4D0
		private void clearLastTabsUnreads(int pageID)
		{
			long[] array = new long[]
			{
				-1L,
				-1L,
				-1L,
				-1L,
				-1L,
				-1L
			};
			int[] array2 = GameEngine.Instance.World.setReadIDs(this.currentParish, array);
			if (array2 != null && array2[pageID] > 0)
			{
				long highestReadID = GameEngine.Instance.World.getHighestReadID(this.currentParish, pageID);
				RemoteServices.Instance.Chat_MarkParishTextRead(this.currentParish, pageID, highestReadID);
				array[pageID] = highestReadID;
				GameEngine.Instance.World.setReadIDs(this.currentParish, array);
			}
		}

		// Token: 0x06001BBB RID: 7099 RVA: 0x0001B822 File Offset: 0x00019A22
		public void leaving()
		{
			if (this.lastTab >= 0)
			{
				this.clearLastTabsUnreads(this.lastTab);
			}
		}

		// Token: 0x06001BBC RID: 7100 RVA: 0x0001B839 File Offset: 0x00019A39
		public void logout()
		{
			this.parishList.Clear();
			this.currentParish = -1;
		}

		// Token: 0x06001BBD RID: 7101 RVA: 0x0001B84D File Offset: 0x00019A4D
		public void flushData(int parishID)
		{
			this.parishList[parishID] = null;
			GameEngine.Instance.World.flushParishWallDonation(GameEngine.Instance.World.getParishCapital(parishID), RemoteServices.Instance.UserID);
		}

		// Token: 0x06001BBE RID: 7102 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void forceUpdateParish()
		{
		}

		// Token: 0x06001BBF RID: 7103 RVA: 0x001B1354 File Offset: 0x001AF554
		private void tabClick()
		{
			if (this.ClickedControl != null)
			{
				CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)this.ClickedControl;
				int data = csdbutton.Data;
				if (this.lastTab != data)
				{
					this.clearLastTabsUnreads(this.lastTab);
				}
				this.tabEntered(data);
			}
		}

		// Token: 0x06001BC0 RID: 7104 RVA: 0x001B1398 File Offset: 0x001AF598
		private void tabEntered(int pageID)
		{
			this.lastTab = pageID;
			long[] array = new long[]
			{
				-1L,
				-1L,
				-1L,
				-1L,
				-1L,
				-1L
			};
			int[] array2 = GameEngine.Instance.World.setReadIDs(this.currentParish, array);
			if (array2 != null)
			{
				for (int i = 0; i < 6; i++)
				{
					this.chatAreas[i].setUnreads(array2[i]);
				}
				if (array2[pageID] > 0)
				{
					long highestReadID = GameEngine.Instance.World.getHighestReadID(this.currentParish, pageID);
					RemoteServices.Instance.Chat_MarkParishTextRead(this.currentParish, pageID, highestReadID);
					array[pageID] = highestReadID;
					GameEngine.Instance.World.setReadIDs(this.currentParish, array);
				}
			}
			for (int j = 0; j < 6; j++)
			{
				this.chatAreas[j].Visible = (j == pageID);
			}
			this.tab1Button.ImageNorm = GFXLibrary.parishwall_village_center_tab_down;
			this.tab1Button.ImageOver = GFXLibrary.parishwall_village_center_tab_down;
			this.tab2Button.ImageNorm = GFXLibrary.parishwall_village_center_tab_down;
			this.tab2Button.ImageOver = GFXLibrary.parishwall_village_center_tab_down;
			this.tab3Button.ImageNorm = GFXLibrary.parishwall_village_center_tab_down;
			this.tab3Button.ImageOver = GFXLibrary.parishwall_village_center_tab_down;
			this.tab4Button.ImageNorm = GFXLibrary.parishwall_village_center_tab_down;
			this.tab4Button.ImageOver = GFXLibrary.parishwall_village_center_tab_down;
			this.tab5Button.ImageNorm = GFXLibrary.parishwall_village_center_tab_down;
			this.tab5Button.ImageOver = GFXLibrary.parishwall_village_center_tab_down;
			this.tab6Button.ImageNorm = GFXLibrary.parishwall_village_center_tab_down;
			this.tab6Button.ImageOver = GFXLibrary.parishwall_village_center_tab_down;
			this.tab1Button.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.tab2Button.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.tab3Button.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.tab4Button.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.tab5Button.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.tab6Button.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			switch (pageID)
			{
			case 0:
				this.tab1Button.ImageNorm = GFXLibrary.parishwall_village_center_tab_up;
				this.tab1Button.ImageOver = GFXLibrary.parishwall_village_center_tab_up;
				this.tab1Button.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				break;
			case 1:
				this.tab2Button.ImageNorm = GFXLibrary.parishwall_village_center_tab_up;
				this.tab2Button.ImageOver = GFXLibrary.parishwall_village_center_tab_up;
				this.tab2Button.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				break;
			case 2:
				this.tab3Button.ImageNorm = GFXLibrary.parishwall_village_center_tab_up;
				this.tab3Button.ImageOver = GFXLibrary.parishwall_village_center_tab_up;
				this.tab3Button.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				break;
			case 3:
				this.tab4Button.ImageNorm = GFXLibrary.parishwall_village_center_tab_up;
				this.tab4Button.ImageOver = GFXLibrary.parishwall_village_center_tab_up;
				this.tab4Button.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				break;
			case 4:
				this.tab5Button.ImageNorm = GFXLibrary.parishwall_village_center_tab_up;
				this.tab5Button.ImageOver = GFXLibrary.parishwall_village_center_tab_up;
				this.tab5Button.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				break;
			case 5:
				this.tab6Button.ImageNorm = GFXLibrary.parishwall_village_center_tab_up;
				this.tab6Button.ImageOver = GFXLibrary.parishwall_village_center_tab_up;
				this.tab6Button.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				break;
			}
			if (!this.chatAreas[pageID].Locked)
			{
				this.textBox1.Enabled = true;
				return;
			}
			this.textBox1.Enabled = false;
		}

		// Token: 0x06001BC1 RID: 7105 RVA: 0x001B183C File Offset: 0x001AFA3C
		public void setTabText(int tabID, string title)
		{
			switch (tabID)
			{
			case 0:
				this.tab1Button.Text.Text = title;
				return;
			case 1:
				this.tab2Button.Text.Text = title;
				return;
			case 2:
				this.tab3Button.Text.Text = title;
				return;
			case 3:
				this.tab4Button.Text.Text = title;
				return;
			case 4:
				this.tab5Button.Text.Text = title;
				return;
			case 5:
				this.tab6Button.Text.Text = title;
				return;
			default:
				return;
			}
		}

		// Token: 0x06001BC2 RID: 7106 RVA: 0x001B18D4 File Offset: 0x001AFAD4
		public void chat_ReceiveParishTextCallback(Chat_ReceiveParishText_ReturnType returnData)
		{
			if (RemoteServices.Instance.UserOptions.profanityFilter && returnData.textList != null && returnData.textList.Count > 0)
			{
				foreach (Chat_TextEntry chat_TextEntry in returnData.textList)
				{
					chat_TextEntry.text = GameEngine.Instance.censorString(chat_TextEntry.text);
				}
			}
			if (returnData.Success && returnData.parishID == this.currentParish && returnData.textList != null && returnData.textList.Count > 0)
			{
				this.checkTextUpdateTime = 10;
				this.importText(returnData.textList, returnData.unreadIDs);
			}
			else
			{
				this.importText(returnData.textList, returnData.unreadIDs);
			}
			this.checkTextUpdateTime += 2;
			if (this.checkTextUpdateTime >= 40)
			{
				this.checkTextUpdateTime = 40;
			}
			this.lastRequestTime = DateTime.Now;
			this.inSend = false;
		}

		// Token: 0x06001BC3 RID: 7107 RVA: 0x001B19EC File Offset: 0x001AFBEC
		private void importText(List<Chat_TextEntry> importTextList, long[] readIDs)
		{
			List<Chat_TextEntry> list = GameEngine.Instance.World.addParishChat(this.currentParish, importTextList);
			int[] array = GameEngine.Instance.World.setReadIDs(this.currentParish, readIDs);
			List<Chat_TextEntry> list2 = new List<Chat_TextEntry>();
			List<Chat_TextEntry> list3 = new List<Chat_TextEntry>();
			List<Chat_TextEntry> list4 = new List<Chat_TextEntry>();
			List<Chat_TextEntry> list5 = new List<Chat_TextEntry>();
			List<Chat_TextEntry> list6 = new List<Chat_TextEntry>();
			List<Chat_TextEntry> list7 = new List<Chat_TextEntry>();
			if (list != null)
			{
				foreach (Chat_TextEntry chat_TextEntry in list)
				{
					switch (chat_TextEntry.roomID)
					{
					case 0:
						list2.Add(chat_TextEntry);
						break;
					case 1:
						list3.Add(chat_TextEntry);
						break;
					case 2:
						list4.Add(chat_TextEntry);
						break;
					case 3:
						list5.Add(chat_TextEntry);
						break;
					case 4:
						list6.Add(chat_TextEntry);
						break;
					case 5:
						list7.Add(chat_TextEntry);
						break;
					}
				}
			}
			this.chatAreas[0].importText(list2.ToArray(), false, -1L);
			this.chatAreas[1].importText(list3.ToArray(), false, -1L);
			this.chatAreas[2].importText(list4.ToArray(), false, -1L);
			this.chatAreas[3].importText(list5.ToArray(), false, -1L);
			this.chatAreas[4].importText(list6.ToArray(), false, -1L);
			this.chatAreas[5].importText(list7.ToArray(), false, -1L);
			for (int i = 0; i < 6; i++)
			{
				this.chatAreas[i].setUnreads(array[i]);
			}
		}

		// Token: 0x06001BC4 RID: 7108 RVA: 0x001B1BA4 File Offset: 0x001AFDA4
		public void getParishFrontPageCallback(GetParishFrontPageInfo_ReturnType returnData)
		{
			if (returnData.Success)
			{
				ParishWallPanel.StoredParishInfo storedParishInfo = (ParishWallPanel.StoredParishInfo)this.parishList[returnData.parishID];
				if (storedParishInfo == null)
				{
					storedParishInfo = new ParishWallPanel.StoredParishInfo();
					this.parishList[returnData.parishID] = storedParishInfo;
				}
				storedParishInfo.m_lastUpdateTime = DateTime.Now;
				storedParishInfo.lastReturnData = returnData;
				if (this.currentParish == returnData.parishID)
				{
					ParishWallPanel.m_userIDOnCurrent = -1;
					this.electedLeaderID = returnData.leaderID;
					this.electedLeaderName = returnData.leaderName;
					this.currentLeaderID = returnData.leaderID;
					this.currentLeaderName = returnData.leaderName;
					if (this.currentLeaderID == RemoteServices.Instance.UserID)
					{
						CustomSelfDrawPanel.ParishChatPanel[] array = this.chatAreas;
						foreach (CustomSelfDrawPanel.ParishChatPanel parishChatPanel in array)
						{
							parishChatPanel.setAsSteward();
						}
					}
					this.createParishWall(returnData.parishWallInfo);
				}
			}
			this.updateLeaderInfo();
		}

		// Token: 0x06001BC5 RID: 7109 RVA: 0x0001B885 File Offset: 0x00019A85
		public void updateLeaderInfo()
		{
			this.stewardLabel.Text = SK.Text("ParishWallPanel_Steward", "Steward") + " : " + this.currentLeaderName;
			ParishWallPanel.m_userIDOnCurrent = this.currentLeaderID;
			this.update();
		}

		// Token: 0x06001BC6 RID: 7110 RVA: 0x001B1C8C File Offset: 0x001AFE8C
		private void createParishWall(WallInfo[] wallInfos)
		{
			this.origWallInfo = wallInfos;
			List<WallInfo> list = new List<WallInfo>();
			this.wallList.Clear();
			int num = 0;
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
				num++;
				if (num > 200)
				{
					break;
				}
			}
			this.updateWallArea();
		}

		// Token: 0x06001BC7 RID: 7111 RVA: 0x001B1E0C File Offset: 0x001B000C
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

		// Token: 0x06001BC8 RID: 7112 RVA: 0x001B1F50 File Offset: 0x001B0150
		private void wallScrollBarMoved()
		{
			int value = this.wallScrollBar.Value;
			this.wallScrollArea.Position = new Point(this.wallScrollArea.X, 15 - value);
			this.wallScrollArea.ClipRect = new Rectangle(this.wallScrollArea.ClipRect.X, value, this.wallScrollArea.ClipRect.Width, this.wallScrollArea.ClipRect.Height);
			this.wallScrollArea.invalidate();
			this.wallScrollBar.invalidate();
		}

		// Token: 0x06001BC9 RID: 7113 RVA: 0x001B1FE8 File Offset: 0x001B01E8
		public void sendParishText(string text, int id)
		{
			if (GameEngine.Instance.Village != null)
			{
				text = text.Replace("\n", " ");
				text = text.Replace("\r", " ");
				text = text.Replace("\t", " ");
				RemoteServices.Instance.set_Chat_SendParishText_UserCallBack(new RemoteServices.Chat_SendParishText_UserCallBack(this.chat_SendParishTextCallback));
				RemoteServices.Instance.Chat_SendParishText(text, this.currentParish, id, GameEngine.Instance.World.getParishChatNewestPostTime(this.currentParish, GameEngine.Instance.Village.m_ownedDate));
			}
		}

		// Token: 0x06001BCA RID: 7114 RVA: 0x001B2088 File Offset: 0x001B0288
		public void chat_SendParishTextCallback(Chat_SendParishText_ReturnType returnData)
		{
			if (!this.chatAreas[this.lastTab].Locked)
			{
				this.textBox1.Enabled = true;
			}
			this.textBox1.Focus();
			if (returnData.Success && returnData.textList != null && returnData.textList.Count > 0)
			{
				if (RemoteServices.Instance.UserOptions.profanityFilter)
				{
					foreach (Chat_TextEntry chat_TextEntry in returnData.textList)
					{
						chat_TextEntry.text = GameEngine.Instance.censorString(chat_TextEntry.text);
					}
				}
				this.checkTextUpdateTime = 2;
				this.importText(returnData.textList, returnData.unreadIDs);
			}
		}

		// Token: 0x06001BCB RID: 7115 RVA: 0x001B2164 File Offset: 0x001B0364
		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				if (this.textBox1.Text.Length > 0)
				{
					this.sendParishText(this.textBox1.Text, this.lastTab);
					this.textBox1.Text = "";
					this.textBox1.Enabled = false;
				}
				e.Handled = true;
			}
		}

		// Token: 0x06001BCC RID: 7116 RVA: 0x0001B8C2 File Offset: 0x00019AC2
		private void textBox1_Enter(object sender, EventArgs e)
		{
			if (this.initialTextInTextbox)
			{
				this.initialTextInTextbox = false;
				this.textBox1.Text = "";
			}
		}

		// Token: 0x06001BCD RID: 7117 RVA: 0x001B21C8 File Offset: 0x001B03C8
		public void backfillPage(int pageID)
		{
			long num = -1L;
			List<Chat_TextEntry> parishChat = GameEngine.Instance.World.getParishChat(this.currentParish, pageID, DateTime.MinValue);
			foreach (Chat_TextEntry chat_TextEntry in parishChat)
			{
				if (num == -1L || chat_TextEntry.textID < num)
				{
					num = chat_TextEntry.textID;
				}
			}
			RemoteServices.Instance.set_Chat_BackFillParishText_UserCallBack(new RemoteServices.Chat_BackFillParishText_UserCallBack(this.chat_BackFillParishTextCallback));
			DateTime dateTime = GameEngine.Instance.Village.m_ownedDate;
			if (dateTime == DateTime.MaxValue && RemoteServices.Instance.Admin)
			{
				dateTime = DateTime.MinValue;
			}
			RemoteServices.Instance.Chat_BackFillParishText(this.currentParish, pageID, num, dateTime);
		}

		// Token: 0x06001BCE RID: 7118 RVA: 0x001B22A0 File Offset: 0x001B04A0
		public void chat_BackFillParishTextCallback(Chat_BackFillParishText_ReturnType returnData)
		{
			if (!returnData.Success || returnData.parishID != this.currentParish || returnData.textList == null)
			{
				this.chatAreas[returnData.pageID].freeOldMessagesButton();
				return;
			}
			if (RemoteServices.Instance.UserOptions.profanityFilter && returnData.textList != null && returnData.textList.Count > 0)
			{
				foreach (Chat_TextEntry chat_TextEntry in returnData.textList)
				{
					chat_TextEntry.text = GameEngine.Instance.censorString(chat_TextEntry.text);
				}
			}
			if (returnData.textList.Count > 0)
			{
				List<Chat_TextEntry> list = GameEngine.Instance.World.addParishChat(returnData.parishID, returnData.textList);
				this.chatAreas[returnData.pageID].importText(list.ToArray(), true, -1L);
				return;
			}
			this.chatAreas[returnData.pageID].importText(returnData.textList.ToArray(), true, -1L);
		}

		// Token: 0x06001BCF RID: 7119 RVA: 0x0001B8E3 File Offset: 0x00019AE3
		public void deleteWallPost(long id)
		{
			this.chatAreas[0].importText(new Chat_TextEntry[0], false, id);
		}

		// Token: 0x06001BD0 RID: 7120 RVA: 0x0000ADE9 File Offset: 0x00008FE9
		public void closing()
		{
			InterfaceMgr.Instance.closeDonatePopup();
		}

		// Token: 0x04002C6C RID: 11372
		private DockableControl dockableControl;

		// Token: 0x04002C6D RID: 11373
		private IContainer components;

		// Token: 0x04002C6E RID: 11374
		private TextBox textBox1;

		// Token: 0x04002C6F RID: 11375
		private Panel focusPanel;

		// Token: 0x04002C70 RID: 11376
		public static ParishWallPanel instance = null;

		// Token: 0x04002C71 RID: 11377
		private SparseArray parishList = new SparseArray();

		// Token: 0x04002C72 RID: 11378
		private DateTime lastChatUpdate = DateTime.MinValue;

		// Token: 0x04002C73 RID: 11379
		private bool initialTextInTextbox = true;

		// Token: 0x04002C74 RID: 11380
		private int m_currentVillage = -1;

		// Token: 0x04002C75 RID: 11381
		private int currentParish = -1;

		// Token: 0x04002C76 RID: 11382
		private int electedLeaderID = -1;

		// Token: 0x04002C77 RID: 11383
		private string electedLeaderName = "";

		// Token: 0x04002C78 RID: 11384
		private int currentLeaderID = -1;

		// Token: 0x04002C79 RID: 11385
		private string currentLeaderName = "";

		// Token: 0x04002C7A RID: 11386
		public static int m_userIDOnCurrent = -1;

		// Token: 0x04002C7B RID: 11387
		private DateTime lastRequestTime = DateTime.MinValue;

		// Token: 0x04002C7C RID: 11388
		private int checkTextUpdateTime = 5;

		// Token: 0x04002C7D RID: 11389
		private bool forceNextUpdate;

		// Token: 0x04002C7E RID: 11390
		private CustomSelfDrawPanel.ParishChatPanel[] chatAreas;

		// Token: 0x04002C7F RID: 11391
		private int[] unreadMessages = new int[6];

		// Token: 0x04002C80 RID: 11392
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04002C81 RID: 11393
		private CustomSelfDrawPanel.CSDExtendingPanel backgroundImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04002C82 RID: 11394
		private CustomSelfDrawPanel.CSDLabel parishNameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002C83 RID: 11395
		private CustomSelfDrawPanel.CSDImage illustrationImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002C84 RID: 11396
		private CustomSelfDrawPanel.CSDLabel stewardLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002C85 RID: 11397
		private CustomSelfDrawPanel.CSDExtendingPanel wallInfoImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04002C86 RID: 11398
		private CustomSelfDrawPanel.CSDImage textInputImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002C87 RID: 11399
		private CustomSelfDrawPanel.CSDButton tab1Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002C88 RID: 11400
		private CustomSelfDrawPanel.CSDButton tab2Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002C89 RID: 11401
		private CustomSelfDrawPanel.CSDButton tab3Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002C8A RID: 11402
		private CustomSelfDrawPanel.CSDButton tab4Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002C8B RID: 11403
		private CustomSelfDrawPanel.CSDButton tab5Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002C8C RID: 11404
		private CustomSelfDrawPanel.CSDButton tab6Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002C8D RID: 11405
		private CustomSelfDrawPanel.CSDExtendingPanel areaWindow = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04002C8E RID: 11406
		private CustomSelfDrawPanel.CSDVertScrollBar wallScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x04002C8F RID: 11407
		private CustomSelfDrawPanel.CSDArea wallScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04002C90 RID: 11408
		private bool inSend;

		// Token: 0x04002C91 RID: 11409
		private int lastTab = -1;

		// Token: 0x04002C92 RID: 11410
		private List<CustomSelfDrawPanel.ParishWallEntry> lineList = new List<CustomSelfDrawPanel.ParishWallEntry>();

		// Token: 0x04002C93 RID: 11411
		private WallInfo[] origWallInfo;

		// Token: 0x04002C94 RID: 11412
		private List<WallInfo> wallList = new List<WallInfo>();

		// Token: 0x0200026F RID: 623
		public class StoredParishInfo
		{
			// Token: 0x04002C95 RID: 11413
			public GetParishFrontPageInfo_ReturnType lastReturnData;

			// Token: 0x04002C96 RID: 11414
			public DateTime m_lastUpdateTime = DateTime.MinValue;
		}
	}
}
