using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x0200012E RID: 302
	public class ChatScreen : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06000B13 RID: 2835 RVA: 0x0000E3C9 File Offset: 0x0000C5C9
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06000B14 RID: 2836 RVA: 0x0000E3D9 File Offset: 0x0000C5D9
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06000B15 RID: 2837 RVA: 0x0000E3E9 File Offset: 0x0000C5E9
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y, true, true);
		}

		// Token: 0x06000B16 RID: 2838 RVA: 0x0000E3FD File Offset: 0x0000C5FD
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06000B17 RID: 2839 RVA: 0x0000E40A File Offset: 0x0000C60A
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x06000B18 RID: 2840 RVA: 0x0000E418 File Offset: 0x0000C618
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06000B19 RID: 2841 RVA: 0x0000E425 File Offset: 0x0000C625
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06000B1A RID: 2842 RVA: 0x0000E432 File Offset: 0x0000C632
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000B1B RID: 2843 RVA: 0x000E05BC File Offset: 0x000DE7BC
		private void InitializeComponent()
		{
			this.label1 = new Label();
			this.tbTextInput = new TextBox();
			this.tbTextViewer = new RichTextBox();
			this.btnSend = new BitmapButton();
			this.btnClose = new BitmapButton();
			this.lblRoomName = new Label();
			this.lbActiveChatters = new ListBox();
			this.lbRooms = new ListBox();
			this.label2 = new Label();
			this.label3 = new Label();
			this.label4 = new Label();
			this.cbChatUpdate = new CheckBox();
			this.lblLanguage = new Label();
			this.pnlWikiHelp = new Panel();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(17, 11);
			this.label1.Name = "label1";
			this.label1.Size = new Size(48, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "Chat";
			this.tbTextInput.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.tbTextInput.ForeColor = global::ARGBColors.Black;
			this.tbTextInput.Location = new Point(225, 460);
			this.tbTextInput.MaxLength = 500;
			this.tbTextInput.Multiline = true;
			this.tbTextInput.Name = "tbTextInput";
			this.tbTextInput.ScrollBars = ScrollBars.Vertical;
			this.tbTextInput.Size = new Size(532, 79);
			this.tbTextInput.TabIndex = 1;
			this.tbTextInput.KeyPress += this.tbTextInput_KeyPress;
			this.tbTextViewer.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.tbTextViewer.BackColor = Color.FromArgb(220, 220, 220);
			this.tbTextViewer.Location = new Point(225, 67);
			this.tbTextViewer.Name = "tbTextViewer";
			this.tbTextViewer.ReadOnly = true;
			this.tbTextViewer.ScrollBars = RichTextBoxScrollBars.Vertical;
			this.tbTextViewer.Size = new Size(532, 387);
			this.tbTextViewer.TabIndex = 2;
			this.tbTextViewer.Text = "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n";
			this.tbTextViewer.LinkClicked += this.tbTextViewer_LinkClicked;
			this.btnSend.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.btnSend.BorderColor = Color.FromArgb(0, 0, 139);
			this.btnSend.BorderDrawing = true;
			this.btnSend.FocusRectangleEnabled = false;
			this.btnSend.Image = null;
			this.btnSend.ImageBorderColor = Color.FromArgb(210, 105, 30);
			this.btnSend.ImageBorderEnabled = true;
			this.btnSend.ImageDropShadow = true;
			this.btnSend.ImageFocused = null;
			this.btnSend.ImageInactive = null;
			this.btnSend.ImageMouseOver = null;
			this.btnSend.ImageNormal = null;
			this.btnSend.ImagePressed = null;
			this.btnSend.InnerBorderColor = Color.FromArgb(211, 211, 211);
			this.btnSend.InnerBorderColor_Focus = Color.FromArgb(173, 216, 230);
			this.btnSend.InnerBorderColor_MouseOver = Color.FromArgb(255, 215, 0);
			this.btnSend.Location = new Point(763, 516);
			this.btnSend.Name = "btnSend";
			this.btnSend.OffsetPressedContent = true;
			this.btnSend.Padding2 = 5;
			this.btnSend.Size = new Size(89, 23);
			this.btnSend.StretchImage = false;
			this.btnSend.TabIndex = 3;
			this.btnSend.Text = "Send";
			this.btnSend.TextDropShadow = false;
			this.btnSend.UseVisualStyleBackColor = true;
			this.btnSend.Click += this.btnSend_Click;
			this.btnClose.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.btnClose.BorderColor = Color.FromArgb(0, 0, 139);
			this.btnClose.BorderDrawing = true;
			this.btnClose.FocusRectangleEnabled = false;
			this.btnClose.Image = null;
			this.btnClose.ImageBorderColor = Color.FromArgb(210, 105, 30);
			this.btnClose.ImageBorderEnabled = true;
			this.btnClose.ImageDropShadow = true;
			this.btnClose.ImageFocused = null;
			this.btnClose.ImageInactive = null;
			this.btnClose.ImageMouseOver = null;
			this.btnClose.ImageNormal = null;
			this.btnClose.ImagePressed = null;
			this.btnClose.InnerBorderColor = Color.FromArgb(211, 211, 211);
			this.btnClose.InnerBorderColor_Focus = Color.FromArgb(173, 216, 230);
			this.btnClose.InnerBorderColor_MouseOver = Color.FromArgb(255, 215, 0);
			this.btnClose.Location = new Point(891, 516);
			this.btnClose.Name = "btnClose";
			this.btnClose.OffsetPressedContent = true;
			this.btnClose.Padding2 = 5;
			this.btnClose.Size = new Size(89, 23);
			this.btnClose.StretchImage = false;
			this.btnClose.TabIndex = 4;
			this.btnClose.Text = "Close";
			this.btnClose.TextDropShadow = false;
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += this.btnClose_Click;
			this.lblRoomName.AutoSize = true;
			this.lblRoomName.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.lblRoomName.Location = new Point(221, 40);
			this.lblRoomName.Name = "lblRoomName";
			this.lblRoomName.Size = new Size(160, 24);
			this.lblRoomName.TabIndex = 5;
			this.lblRoomName.Text = "Chat Room Name";
			this.lbActiveChatters.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right);
			this.lbActiveChatters.ForeColor = Color.Black;
			this.lbActiveChatters.FormattingEnabled = true;
			this.lbActiveChatters.Location = new Point(777, 67);
			this.lbActiveChatters.Name = "lbActiveChatters";
			this.lbActiveChatters.Size = new Size(189, 381);
			this.lbActiveChatters.TabIndex = 6;
			this.lbActiveChatters.DoubleClick += this.lbActiveChatters_DoubleClick;
			this.lbRooms.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left);
			this.lbRooms.ForeColor = Color.Black;
			this.lbRooms.FormattingEnabled = true;
			this.lbRooms.Location = new Point(21, 67);
			this.lbRooms.Name = "lbRooms";
			this.lbRooms.Size = new Size(178, 394);
			this.lbRooms.TabIndex = 7;
			this.lbRooms.SelectedIndexChanged += this.lbRooms_SelectedIndexChanged;
			this.label2.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.label2.AutoSize = true;
			this.label2.Location = new Point(774, 51);
			this.label2.Name = "label2";
			this.label2.Size = new Size(67, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Users Online";
			this.label3.AutoSize = true;
			this.label3.Location = new Point(18, 51);
			this.label3.Name = "label3";
			this.label3.Size = new Size(86, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Available Rooms";
			this.label4.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.label4.Location = new Point(21, 547);
			this.label4.Name = "label4";
			this.label4.Size = new Size(945, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "Personal Abuse or abusing this system (such as spamming or copy / pasting) will result in removal from Stronghold Kingdoms.";
			this.label4.TextAlign = ContentAlignment.TopCenter;
			this.cbChatUpdate.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.cbChatUpdate.Checked = true;
			this.cbChatUpdate.CheckState = CheckState.Checked;
			this.cbChatUpdate.Location = new Point(777, 462);
			this.cbChatUpdate.Name = "cbChatUpdate";
			this.cbChatUpdate.Size = new Size(189, 17);
			this.cbChatUpdate.TabIndex = 11;
			this.cbChatUpdate.Text = "Notify new chat";
			this.cbChatUpdate.UseVisualStyleBackColor = true;
			this.cbChatUpdate.CheckedChanged += this.cbChatUpdate_CheckedChanged;
			this.lblLanguage.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.lblLanguage.Location = new Point(557, 51);
			this.lblLanguage.Name = "lblLanguage";
			this.lblLanguage.Size = new Size(200, 13);
			this.lblLanguage.TabIndex = 12;
			this.lblLanguage.Text = "English Only";
			this.lblLanguage.TextAlign = ContentAlignment.TopRight;
			this.pnlWikiHelp.Location = new Point(931, 11);
			this.pnlWikiHelp.Name = "pnlWikiHelp";
			this.pnlWikiHelp.Size = new Size(35, 35);
			this.pnlWikiHelp.TabIndex = 13;
			this.pnlWikiHelp.MouseLeave += this.pnlWikiHelp_MouseLeave;
			this.pnlWikiHelp.MouseClick += this.pnlWikiHelp_MouseClick;
			this.pnlWikiHelp.MouseEnter += this.pnlWikiHelp_MouseEnter;
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = Color.FromArgb(0, 255, 255, 255);
			base.Controls.Add(this.pnlWikiHelp);
			base.Controls.Add(this.lblLanguage);
			base.Controls.Add(this.cbChatUpdate);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.lbRooms);
			base.Controls.Add(this.lbActiveChatters);
			base.Controls.Add(this.lblRoomName);
			base.Controls.Add(this.btnClose);
			base.Controls.Add(this.btnSend);
			base.Controls.Add(this.tbTextViewer);
			base.Controls.Add(this.tbTextInput);
			base.Controls.Add(this.label1);
			this.MaximumSize = new Size(2000, 2000);
			this.MinimumSize = new Size(750, 350);
			base.Name = "ChatScreen";
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x06000B1C RID: 2844 RVA: 0x000E11A8 File Offset: 0x000DF3A8
		public ChatScreen()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.tbTextInput.Focus();
			this.dockableControl.setSizeableWindow();
			this.label1.Font = FontManager.GetFont("Microsoft Sans Serif", 14f);
			this.lblRoomName.Font = FontManager.GetFont("Microsoft Sans Serif", 14f);
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			base.ClickThru = true;
		}

		// Token: 0x06000B1D RID: 2845 RVA: 0x000E1290 File Offset: 0x000DF490
		public void init(ChatScreenManager parent)
		{
			this.label1.Text = SK.Text("GENERIC_Chat", "Chat");
			this.btnSend.Text = SK.Text("ChatScreen_Send", "Send");
			this.btnClose.Text = SK.Text("GENERIC_Close", "Close");
			this.lblRoomName.Text = SK.Text("ChatScreen_Chat_Room_Name", "Chat Room Name");
			this.label2.Text = SK.Text("ChatScreen_Users_Online", "Users Online");
			this.label3.Text = SK.Text("ChatScreen_Available_Rooms", "Available Rooms");
			this.label4.Text = SK.Text("ChatScreen_Abuse_Warning", "Personal Abuse or abusing this system (such as spamming or copy / pasting) will result in removal from Stronghold Kingdoms.");
			this.cbChatUpdate.Text = SK.Text("ChatScreen_Notify", "Notify new chat");
			if (GameEngine.Instance.LocalWorldData.Alternate_Ruleset == 1 || (GameEngine.Instance.World.GetGlobalWorldID() >= 700 && GameEngine.Instance.World.GetGlobalWorldID() < 800) || (GameEngine.Instance.World.GetGlobalWorldID() >= 1200 && GameEngine.Instance.World.GetGlobalWorldID() < 1400) || (GameEngine.Instance.World.GetGlobalWorldID() >= 3500 && GameEngine.Instance.World.GetGlobalWorldID() < 3600))
			{
				this.lblLanguage.Text = "";
			}
			else
			{
				string worldDefaultLanguage = GameEngine.Instance.World.WorldDefaultLanguage;
				if (worldDefaultLanguage != null)
				{
					uint num = PrivateImplementationDetails.ComputeStringHash(worldDefaultLanguage);
					if (num <= 1194886160U)
					{
						if (num <= 1162757945U)
						{
							if (num != 1092248970U)
							{
								if (num == 1162757945U)
								{
									if (worldDefaultLanguage == "pl")
									{
										this.lblLanguage.Text = SK.Text("ChatScreen_Polish_Only", "Languages: Polish Only");
									}
								}
							}
							else if (worldDefaultLanguage == "en")
							{
								this.lblLanguage.Text = SK.Text("ChatScreen_English_Only", "Languages: English Only");
							}
						}
						else if (num != 1176137065U)
						{
							if (num == 1194886160U)
							{
								if (worldDefaultLanguage == "it")
								{
									this.lblLanguage.Text = SK.Text("ChatScreen_Italian_Only", "Languages: Italian Only");
								}
							}
						}
						else if (worldDefaultLanguage == "es")
						{
							this.lblLanguage.Text = SK.Text("ChatScreen_Spanish_Only", "Languages: Spanish Only");
						}
					}
					else if (num <= 1213488160U)
					{
						if (num != 1195724803U)
						{
							if (num == 1213488160U)
							{
								if (worldDefaultLanguage == "ru")
								{
									this.lblLanguage.Text = SK.Text("ChatScreen_Russian_Only", "Languages: Russian Only");
								}
							}
						}
						else if (worldDefaultLanguage == "tr")
						{
							this.lblLanguage.Text = SK.Text("ChatScreen_Turkish_Only", "Languages: Turkish Only");
						}
					}
					else if (num != 1461901041U)
					{
						if (num != 1545391778U)
						{
							if (num == 1565420801U)
							{
								if (worldDefaultLanguage == "pt")
								{
									this.lblLanguage.Text = SK.Text("ChatScreen_BrazilianPortuguese_Only", "Languages: Brazilian-Portuguese Only");
								}
							}
						}
						else if (worldDefaultLanguage == "de")
						{
							this.lblLanguage.Text = SK.Text("ChatScreen_German_Only", "Languages: German Only");
						}
					}
					else if (worldDefaultLanguage == "fr")
					{
						this.lblLanguage.Text = SK.Text("ChatScreen_French_Only", "Languages: French Only");
					}
				}
			}
			this.tbTextInput.Visible = true;
			this.btnSend.Visible = true;
			this.pnlWikiHelp.BackgroundImage = GFXLibrary.int_button_Q_normal;
			CustomTooltipManager.addTooltipToSystemControl(this.pnlWikiHelp, 4401);
			this.lbActiveChatters.Visible = true;
			this.tbTextViewer.Size = new Size(532, 387);
			this.m_parent = parent;
			base.clearControls();
			this.initTextWindow();
			this.cbChatUpdate.Checked = Program.mySettings.NotifyChatUpdate;
			if (this.registeredRooms.Count == 0)
			{
				this.btnSend.Enabled = false;
			}
		}

		// Token: 0x06000B1E RID: 2846 RVA: 0x000E1724 File Offset: 0x000DF924
		private void initTextWindow()
		{
			this.cbChatUpdate.Checked = Program.mySettings.NotifyChatUpdate;
			this.tbTextViewer.Text = "";
			for (int i = 0; i < 28; i++)
			{
				RichTextBox richTextBox = this.tbTextViewer;
				richTextBox.Text += "\r\n";
			}
			this.tbTextViewer.SelectionStart = this.tbTextViewer.TextLength;
			this.tbTextViewer.ScrollToCaret();
		}

		// Token: 0x06000B1F RID: 2847 RVA: 0x000E17A0 File Offset: 0x000DF9A0
		public void openFresh(int startingAreaType, int startingAreaID)
		{
			if (GameEngine.Instance.LocalWorldData.Alternate_Ruleset == 1 || (GameEngine.Instance.World.GetGlobalWorldID() >= 700 && GameEngine.Instance.World.GetGlobalWorldID() < 800) || (GameEngine.Instance.World.GetGlobalWorldID() >= 1200 && GameEngine.Instance.World.GetGlobalWorldID() < 1400) || (GameEngine.Instance.World.GetGlobalWorldID() >= 3500 && GameEngine.Instance.World.GetGlobalWorldID() < 3600))
			{
				this.lblLanguage.Text = "";
			}
			else
			{
				string worldDefaultLanguage = GameEngine.Instance.World.WorldDefaultLanguage;
				if (worldDefaultLanguage != null)
				{
					uint num = PrivateImplementationDetails.ComputeStringHash(worldDefaultLanguage);
					if (num <= 1194886160U)
					{
						if (num <= 1162757945U)
						{
							if (num != 1092248970U)
							{
								if (num == 1162757945U)
								{
									if (worldDefaultLanguage == "pl")
									{
										this.lblLanguage.Text = SK.Text("ChatScreen_Polish_Only", "Languages: Polish Only");
									}
								}
							}
							else if (worldDefaultLanguage == "en")
							{
								this.lblLanguage.Text = SK.Text("ChatScreen_English_Only", "Languages: English Only");
							}
						}
						else if (num != 1176137065U)
						{
							if (num == 1194886160U)
							{
								if (worldDefaultLanguage == "it")
								{
									this.lblLanguage.Text = SK.Text("ChatScreen_Italian_Only", "Languages: Italian Only");
								}
							}
						}
						else if (worldDefaultLanguage == "es")
						{
							this.lblLanguage.Text = SK.Text("ChatScreen_Spanish_Only", "Languages: Spanish Only");
						}
					}
					else if (num <= 1213488160U)
					{
						if (num != 1195724803U)
						{
							if (num == 1213488160U)
							{
								if (worldDefaultLanguage == "ru")
								{
									this.lblLanguage.Text = SK.Text("ChatScreen_Russian_Only", "Languages: Russian Only");
								}
							}
						}
						else if (worldDefaultLanguage == "tr")
						{
							this.lblLanguage.Text = SK.Text("ChatScreen_Turkish_Only", "Languages: Turkish Only");
						}
					}
					else if (num != 1461901041U)
					{
						if (num != 1545391778U)
						{
							if (num == 1565420801U)
							{
								if (worldDefaultLanguage == "pt")
								{
									this.lblLanguage.Text = SK.Text("ChatScreen_BrazilianPortuguese_Only", "Languages: Brazilian-Portuguese Only");
								}
							}
						}
						else if (worldDefaultLanguage == "de")
						{
							this.lblLanguage.Text = SK.Text("ChatScreen_German_Only", "Languages: German Only");
						}
					}
					else if (worldDefaultLanguage == "fr")
					{
						this.lblLanguage.Text = SK.Text("ChatScreen_French_Only", "Languages: French Only");
					}
				}
			}
			this.cbChatUpdate.Checked = Program.mySettings.NotifyChatUpdate;
			this.registeredRooms.Clear();
			this.activeChatRoomIdent = -1;
			this.lastRequestTime = DateTime.MinValue;
			base.Enabled = false;
			this.tbTextInput.Visible = true;
			this.btnSend.Visible = true;
			this.update();
			if (startingAreaType >= 0)
			{
				foreach (ChatScreen.ChatRoom chatRoom in this.roomsDataSource)
				{
					if (chatRoom.roomType == startingAreaType && chatRoom.roomID == startingAreaID)
					{
						this.lbRooms.SelectedItem = chatRoom;
						break;
					}
				}
			}
		}

		// Token: 0x06000B20 RID: 2848 RVA: 0x0000E451 File Offset: 0x0000C651
		public void openUpdate()
		{
			this.tbTextViewer.SelectionStart = this.tbTextViewer.TextLength;
			this.tbTextViewer.ScrollToCaret();
		}

		// Token: 0x06000B21 RID: 2849 RVA: 0x0000E474 File Offset: 0x0000C674
		public bool isActive()
		{
			return base.ParentForm != null;
		}

		// Token: 0x06000B22 RID: 2850 RVA: 0x000E1B78 File Offset: 0x000DFD78
		public void update()
		{
			if (Form.ActiveForm == base.ParentForm)
			{
				FlashWindow.Stop(base.ParentForm);
			}
			DateTime now = DateTime.Now;
			TimeSpan timeSpan = now - this.lastRequestTime;
			if (this.inSend && (now - this.lastSendTime).TotalSeconds > 3.0)
			{
				this.inSend = false;
			}
			if (timeSpan.TotalSeconds > (double)this.checkTime && !this.inSend && RemoteServices.Instance.ChatActive)
			{
				List<Chat_RoomID> list = this.calcUsersRooms();
				this.inSend = true;
				this.lastSendTime = DateTime.Now;
				RemoteServices.Instance.set_Chat_ReceiveText_UserCallBack(new RemoteServices.Chat_ReceiveText_UserCallBack(this.chat_ReceiveText_UserCallBack));
				if (list.Count == 0)
				{
					RemoteServices.Instance.Chat_GetText(this.registeredRooms, false);
				}
				else
				{
					RemoteServices.Instance.Chat_GetText(list, true);
				}
				if (list.Count > 0)
				{
					this.registeredRooms = list;
					this.recreateRooms();
				}
			}
		}

		// Token: 0x06000B23 RID: 2851 RVA: 0x000E1C74 File Offset: 0x000DFE74
		private List<Chat_RoomID> calcUsersRooms()
		{
			List<Chat_RoomID> list = new List<Chat_RoomID>();
			int userFactionID = RemoteServices.Instance.UserFactionID;
			if (userFactionID >= 0)
			{
				list.Add(new Chat_RoomID
				{
					roomType = 5,
					roomID = userFactionID
				});
				if (GameEngine.Instance.World.YourFaction != null)
				{
					int houseID = GameEngine.Instance.World.YourFaction.houseID;
					if (houseID > 0)
					{
						list.Add(new Chat_RoomID
						{
							roomType = 6,
							roomID = houseID
						});
					}
				}
			}
			List<int> listOfUserParishes = GameEngine.Instance.World.getListOfUserParishes();
			foreach (int roomID in listOfUserParishes)
			{
				list.Add(new Chat_RoomID
				{
					roomType = 3,
					roomID = roomID
				});
			}
			List<int> listOfUserCounties = GameEngine.Instance.World.getListOfUserCounties();
			foreach (int roomID2 in listOfUserCounties)
			{
				list.Add(new Chat_RoomID
				{
					roomType = 9,
					roomID = roomID2
				});
			}
			List<int> listOfUserProvinces = GameEngine.Instance.World.getListOfUserProvinces();
			foreach (int roomID3 in listOfUserProvinces)
			{
				list.Add(new Chat_RoomID
				{
					roomType = 1,
					roomID = roomID3
				});
			}
			List<int> listOfUserCountries = GameEngine.Instance.World.getListOfUserCountries();
			foreach (int roomID4 in listOfUserCountries)
			{
				list.Add(new Chat_RoomID
				{
					roomType = 0,
					roomID = roomID4
				});
			}
			List<int> list2 = new List<int>();
			list2.Add(0);
			list.Add(new Chat_RoomID
			{
				roomType = 8,
				roomID = 0
			});
			foreach (int roomID5 in list2)
			{
				list.Add(new Chat_RoomID
				{
					roomType = 2,
					roomID = roomID5
				});
			}
			if (GameEngine.Instance.World.GetGlobalWorldID() >= 700 && GameEngine.Instance.World.GetGlobalWorldID() < 800)
			{
				list.Add(new Chat_RoomID
				{
					roomType = 2,
					roomID = 10
				});
				list.Add(new Chat_RoomID
				{
					roomType = 2,
					roomID = 12
				});
				list.Add(new Chat_RoomID
				{
					roomType = 2,
					roomID = 11
				});
				list.Add(new Chat_RoomID
				{
					roomType = 2,
					roomID = 13
				});
				list.Add(new Chat_RoomID
				{
					roomType = 2,
					roomID = 14
				});
				list.Add(new Chat_RoomID
				{
					roomType = 2,
					roomID = 15
				});
				list.Add(new Chat_RoomID
				{
					roomType = 2,
					roomID = 16
				});
				list.Add(new Chat_RoomID
				{
					roomType = 2,
					roomID = 17
				});
				list.Add(new Chat_RoomID
				{
					roomType = 2,
					roomID = 18
				});
			}
			if (list.Count != this.registeredRooms.Count)
			{
				return list;
			}
			bool flag = false;
			foreach (Chat_RoomID chat_RoomID in list)
			{
				bool flag2 = false;
				foreach (Chat_RoomID chat_RoomID2 in this.registeredRooms)
				{
					if (chat_RoomID.roomID == chat_RoomID2.roomID && chat_RoomID.roomType == chat_RoomID2.roomType)
					{
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				return list;
			}
			list.Clear();
			return list;
		}

		// Token: 0x06000B24 RID: 2852 RVA: 0x000E2150 File Offset: 0x000E0350
		private void chat_ReceiveText_UserCallBack(Chat_ReceiveText_ReturnType returnData)
		{
			if (!base.Enabled)
			{
				base.Enabled = true;
			}
			if (returnData.Success)
			{
				if (returnData.textList != null && returnData.textList.Count > 0)
				{
					if (RemoteServices.Instance.UserOptions.profanityFilter)
					{
						foreach (Chat_TextEntry chat_TextEntry in returnData.textList)
						{
							chat_TextEntry.text = GameEngine.Instance.censorString(chat_TextEntry.text);
						}
					}
					this.addText(returnData.textList);
					this.checkTime = 1;
					GameEngine.Instance.playInterfaceSound("ChatScreen_new_chat");
					if (Form.ActiveForm != base.ParentForm && Program.mySettings.NotifyChatUpdate)
					{
						FlashWindow.Start(base.ParentForm);
					}
				}
				if (returnData.activeUsers != null)
				{
					this.splitUsersIntoRooms(returnData.activeUsers);
				}
			}
			this.checkTime++;
			if (this.checkTime >= 30)
			{
				this.checkTime = 30;
			}
			this.lastRequestTime = DateTime.Now;
			this.inSend = false;
			if (this.registeredRooms.Count > 0)
			{
				this.btnSend.Enabled = true;
			}
		}

		// Token: 0x06000B25 RID: 2853 RVA: 0x000E22A0 File Offset: 0x000E04A0
		private void openChatRoom(int openRoomIdent)
		{
			this.dontPlayChangeSound = true;
			ChatScreen.ChatRoom chatRoom = (ChatScreen.ChatRoom)this.localChatRooms[openRoomIdent];
			if (chatRoom != null)
			{
				this.tbTextViewer.Clear();
				this.tbTextViewer.Rtf = chatRoom.text;
				this.tbTextViewer.SelectionStart = this.tbTextViewer.TextLength;
				this.tbTextViewer.SelectionLength = 0;
				this.tbTextViewer.ScrollToCaret();
				this.activeChatRoomIdent = openRoomIdent;
				chatRoom.newText = false;
				this.lblRoomName.Text = chatRoom.roomName;
				if (chatRoom.roomType == 5)
				{
					this.lblLanguage.Visible = false;
				}
				else
				{
					this.lblLanguage.Visible = true;
				}
				this.updateUsersListBox();
				this.lbRooms.DataSource = null;
				this.lbRooms.DataSource = this.roomsDataSource;
			}
			this.dontPlayChangeSound = false;
		}

		// Token: 0x06000B26 RID: 2854 RVA: 0x000E2384 File Offset: 0x000E0584
		private void addText(List<Chat_TextEntry> newText)
		{
			Regex regex = new Regex("({\\\\)(.+?)(})|(\\\\)(.+?)(\\b)");
			bool flag = false;
			bool flag2 = false;
			foreach (Chat_TextEntry chat_TextEntry in newText)
			{
				chat_TextEntry.text = regex.Replace(chat_TextEntry.text, "");
				this.rtb.Text = "";
				this.rtb.SelectionColor = global::ARGBColors.Red;
				this.rtb.SelectionFont = FontManager.GetFont("Arial", 8.25f, FontStyle.Bold);
				this.rtb.AppendText(string.Concat(new string[]
				{
					"[ ",
					chat_TextEntry.username,
					" - ",
					chat_TextEntry.postedTime.ToShortTimeString(),
					" ]     "
				}));
				this.rtb.SelectionFont = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.rtb.SelectionColor = global::ARGBColors.Black;
				this.rtb.AppendText(chat_TextEntry.text);
				string rtf = this.rtb.Rtf;
				int num = this.createChatRoomIdent(chat_TextEntry.roomType, chat_TextEntry.roomID);
				ChatScreen.ChatRoom chatRoom = (ChatScreen.ChatRoom)this.localChatRooms[num];
				if (chatRoom != null)
				{
					this.rtb.Clear();
					this.rtb.SelectedRtf = chatRoom.text;
					this.rtb.SelectionStart = this.rtb.TextLength - 1;
					this.rtb.SelectionLength = 1;
					this.rtb.SelectedRtf = rtf;
					chatRoom.text = this.rtb.Rtf;
					if (num == this.activeChatRoomIdent)
					{
						int selectionStart = this.tbTextViewer.SelectionStart;
						int selectionLength = this.tbTextViewer.SelectionLength;
						this.tbTextViewer.SelectionStart = this.tbTextViewer.Rtf.Length;
						this.tbTextViewer.SelectionLength = 0;
						this.tbTextViewer.SelectedRtf = rtf;
						flag2 = true;
						chatRoom.newText = false;
						this.tbTextViewer.SelectionStart = selectionStart;
						this.tbTextViewer.SelectionLength = selectionLength;
					}
					else if (!chatRoom.newText)
					{
						chatRoom.newText = true;
						flag = true;
					}
				}
			}
			if (flag)
			{
				this.lbRooms.DataSource = null;
				this.lbRooms.DataSource = this.roomsDataSource;
			}
			if (flag2)
			{
				this.tbTextViewer.SelectionStart = this.tbTextViewer.TextLength;
				this.tbTextViewer.ScrollToCaret();
			}
		}

		// Token: 0x06000B27 RID: 2855 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void closeClick()
		{
		}

		// Token: 0x06000B28 RID: 2856 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void dockClick()
		{
		}

		// Token: 0x06000B29 RID: 2857 RVA: 0x0000E481 File Offset: 0x0000C681
		private void btnClose_Click(object sender, EventArgs e)
		{
			if (!this.inClosing)
			{
				this.inClosing = true;
				if (this.m_parent != null)
				{
					GameEngine.Instance.playInterfaceSound("ChatScreen_close");
					this.m_parent.close(true, true);
				}
				this.inClosing = false;
			}
		}

		// Token: 0x06000B2A RID: 2858 RVA: 0x0000E4BD File Offset: 0x0000C6BD
		public void closeClickForm(object sender, FormClosingEventArgs e)
		{
			if (!this.inClosing)
			{
				this.inClosing = true;
				if (this.m_parent != null)
				{
					this.m_parent.close(true, true);
				}
				this.inClosing = false;
			}
		}

		// Token: 0x06000B2B RID: 2859 RVA: 0x000E2638 File Offset: 0x000E0838
		private bool isRealString(string text)
		{
			if (this.tbTextInput.Text.Length <= 0)
			{
				return false;
			}
			bool result = false;
			string text2 = this.tbTextInput.Text;
			foreach (char c in text2)
			{
				if (c != ' ' && c != '.' && c != '*' && c != '-' && c != '=' && c != '+' && c != ',')
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06000B2C RID: 2860 RVA: 0x000E26B8 File Offset: 0x000E08B8
		private void btnSend_Click(object sender, EventArgs e)
		{
			if (!RemoteServices.Instance.ChatActive)
			{
				this.btnSend.Enabled = false;
				return;
			}
			if (this.isRealString(this.tbTextInput.Text))
			{
				this.btnSend.Enabled = false;
				if (this.inSend)
				{
					int num = 0;
					while (this.inSend)
					{
						num++;
						Thread.Sleep(1);
						Program.DoEvents();
						RemoteServices.Instance.processData();
						if (num > 5000)
						{
							break;
						}
					}
				}
				this.btnSend.Enabled = false;
				this.inSend = true;
				GameEngine.Instance.playInterfaceSound("ChatScreen_sendchat");
				RemoteServices.Instance.set_Chat_SendText_UserCallBack(new RemoteServices.Chat_SendText_UserCallBack(this.chat_SendText_UserCallBack));
				int roomType = 0;
				int roomID = 0;
				this.splitChatRoomIdent(this.activeChatRoomIdent, ref roomType, ref roomID);
				RemoteServices.Instance.Chat_SendText(this.tbTextInput.Text, roomType, roomID);
				this.tbTextInput.Text = "";
				this.tbTextInput.Focus();
				return;
			}
			this.tbTextInput.Text = "";
			this.tbTextInput.Focus();
		}

		// Token: 0x06000B2D RID: 2861 RVA: 0x000E27D4 File Offset: 0x000E09D4
		private void chat_SendText_UserCallBack(Chat_SendText_ReturnType returnData)
		{
			if (returnData.Success)
			{
				if (returnData.textList != null && returnData.textList.Count > 0)
				{
					if (RemoteServices.Instance.UserOptions.profanityFilter)
					{
						foreach (Chat_TextEntry chat_TextEntry in returnData.textList)
						{
							chat_TextEntry.text = GameEngine.Instance.censorString(chat_TextEntry.text);
						}
					}
					this.addText(returnData.textList);
				}
				if (returnData.banned)
				{
					InterfaceMgr.Instance.chatSetBan(true);
					this.closeClickForm(null, null);
				}
			}
			this.checkTime = 2;
			this.lastRequestTime = DateTime.Now;
			this.btnSend.Enabled = true;
			this.inSend = false;
		}

		// Token: 0x06000B2E RID: 2862 RVA: 0x0000E4EA File Offset: 0x0000C6EA
		private void tbTextInput_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r' && !GameEngine.shiftPressed)
			{
				if (this.btnSend.Enabled)
				{
					this.btnSend_Click(null, null);
				}
				e.Handled = true;
			}
		}

		// Token: 0x06000B2F RID: 2863 RVA: 0x0000E519 File Offset: 0x0000C719
		private int createChatRoomIdent(int roomType, int roomID)
		{
			return roomID * 10 + roomType;
		}

		// Token: 0x06000B30 RID: 2864 RVA: 0x0000E521 File Offset: 0x0000C721
		private void splitChatRoomIdent(int roomIdent, ref int roomType, ref int roomID)
		{
			roomType = roomIdent % 10;
			roomID = roomIdent / 10;
		}

		// Token: 0x06000B31 RID: 2865 RVA: 0x000E28B4 File Offset: 0x000E0AB4
		private void recreateRooms()
		{
			List<ChatScreen.ChatRoom> list = new List<ChatScreen.ChatRoom>();
			foreach (object obj in this.localChatRooms)
			{
				ChatScreen.ChatRoom chatRoom = (ChatScreen.ChatRoom)obj;
				bool flag = false;
				foreach (Chat_RoomID chat_RoomID in this.registeredRooms)
				{
					if (chatRoom.roomID == chat_RoomID.roomID && chatRoom.roomType == chat_RoomID.roomType)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					list.Add(chatRoom);
				}
			}
			foreach (ChatScreen.ChatRoom chatRoom2 in list)
			{
				this.localChatRooms[this.createChatRoomIdent(chatRoom2.roomType, chatRoom2.roomID)] = null;
			}
			this.roomsDataSource.Clear();
			foreach (Chat_RoomID chat_RoomID2 in this.registeredRooms)
			{
				bool flag2 = false;
				foreach (object obj2 in this.localChatRooms)
				{
					ChatScreen.ChatRoom chatRoom3 = (ChatScreen.ChatRoom)obj2;
					if (chatRoom3.roomID == chat_RoomID2.roomID && chatRoom3.roomType == chat_RoomID2.roomType)
					{
						flag2 = true;
						this.roomsDataSource.Add(chatRoom3);
						break;
					}
				}
				if (!flag2)
				{
					ChatScreen.ChatRoom chatRoom4 = new ChatScreen.ChatRoom();
					chatRoom4.roomID = chat_RoomID2.roomID;
					chatRoom4.roomType = chat_RoomID2.roomType;
					chatRoom4.text = "";
					this.rtb.Text = "";
					this.rtb.SelectionColor = global::ARGBColors.Red;
					for (int i = 0; i < 28; i++)
					{
						this.rtb.AppendText("\r\n");
					}
					chatRoom4.text = this.rtb.Rtf;
					chatRoom4.roomName = this.getRoomName(chatRoom4.roomType, chatRoom4.roomID);
					this.localChatRooms[this.createChatRoomIdent(chatRoom4.roomType, chatRoom4.roomID)] = chatRoom4;
					this.roomsDataSource.Add(chatRoom4);
				}
			}
			if ((this.activeChatRoomIdent < 0 || this.localChatRooms[this.activeChatRoomIdent] == null) && this.registeredRooms.Count > 0)
			{
				Chat_RoomID chat_RoomID3 = this.registeredRooms[0];
				this.activeChatRoomIdent = this.createChatRoomIdent(chat_RoomID3.roomType, chat_RoomID3.roomID);
				this.openChatRoom(this.activeChatRoomIdent);
			}
			this.lbRooms.DataSource = this.roomsDataSource;
			if (this.activeChatRoomIdent >= 0 && this.localChatRooms[this.activeChatRoomIdent] != null)
			{
				ChatScreen.ChatRoom selectedItem = (ChatScreen.ChatRoom)this.localChatRooms[this.activeChatRoomIdent];
				this.lbRooms.SelectedItem = selectedItem;
			}
		}

		// Token: 0x06000B32 RID: 2866 RVA: 0x000E2C5C File Offset: 0x000E0E5C
		public string getRoomName(int roomType, int roomID)
		{
			string result = "";
			switch (roomType)
			{
			case 0:
				result = SK.Text("GENERIC_Country", "Country") + " : " + GameEngine.Instance.World.getCountryName(roomID);
				break;
			case 1:
				result = SK.Text("GENERIC_Province", "Province") + " : " + GameEngine.Instance.World.getProvinceName(roomID);
				break;
			case 2:
				switch (roomID)
				{
				case 10:
					result = "English Chat";
					break;
				case 11:
					result = "Deutsch Chat";
					break;
				case 12:
					result = "Francais Chat";
					break;
				case 13:
					result = "Русский Чат";
					break;
				case 14:
					result = "Espanol Chat";
					break;
				case 15:
					result = "Polski Czat";
					break;
				case 16:
					result = "Turkce Sohbet";
					break;
				case 17:
					result = "Chat Italiana";
					break;
				case 18:
					result = "Bate-papo Portugues do Brasil";
					break;
				default:
					result = SK.Text("ChatScreen_Global_Chat", "Global Chat");
					break;
				}
				break;
			case 3:
				result = SK.Text("GENERIC_Parish", "Parish") + " : " + GameEngine.Instance.World.getParishName(roomID);
				break;
			case 5:
				if (GameEngine.Instance.World.YourFaction != null)
				{
					result = SK.Text("STATS_CATEGORY_TITLE_FACTION", "Faction") + " : " + GameEngine.Instance.World.YourFaction.factionNameAbrv;
				}
				break;
			case 6:
				result = SK.Text("STATS_CATEGORY_TITLE_HOUSE", "House") + " " + roomID.ToString();
				break;
			case 8:
				result = SK.Text("MENU_Help", "Help");
				break;
			case 9:
				result = SK.Text("GENERIC_County", "County") + " : " + GameEngine.Instance.World.getCountyName(roomID);
				break;
			}
			return result;
		}

		// Token: 0x06000B33 RID: 2867 RVA: 0x000E2E74 File Offset: 0x000E1074
		private void lbRooms_SelectedIndexChanged(object sender, EventArgs e)
		{
			ChatScreen.ChatRoom chatRoom = (ChatScreen.ChatRoom)this.lbRooms.SelectedItem;
			if (chatRoom == null)
			{
				return;
			}
			int num = this.createChatRoomIdent(chatRoom.roomType, chatRoom.roomID);
			if (num != this.activeChatRoomIdent)
			{
				if (!this.dontPlayChangeSound)
				{
					GameEngine.Instance.playInterfaceSound("ChatScreen_change_room");
				}
				this.openChatRoom(num);
			}
		}

		// Token: 0x06000B34 RID: 2868 RVA: 0x000E2ED0 File Offset: 0x000E10D0
		private void splitUsersIntoRooms(List<Chat_UserInRoom> activeUsers)
		{
			if (activeUsers.Count != 0)
			{
				foreach (object obj in this.localChatRooms)
				{
					ChatScreen.ChatRoom chatRoom = (ChatScreen.ChatRoom)obj;
					List<string> list = new List<string>();
					List<Chat_UserInRoom> list2 = new List<Chat_UserInRoom>();
					foreach (Chat_UserInRoom chat_UserInRoom in activeUsers)
					{
						if (chat_UserInRoom.roomType == chatRoom.roomType && chat_UserInRoom.roomID == chatRoom.roomID)
						{
							list.Add(chat_UserInRoom.username);
							list2.Add(chat_UserInRoom);
						}
					}
					if (!this.areListsEqual(list, chatRoom.usersInRoom))
					{
						chatRoom.usersInRoom = list;
						chatRoom.usersDataInRoom = list2;
						if (this.activeChatRoomIdent == this.createChatRoomIdent(chatRoom.roomType, chatRoom.roomID))
						{
							this.updateUsersListBox();
						}
					}
				}
			}
		}

		// Token: 0x06000B35 RID: 2869 RVA: 0x000E2FEC File Offset: 0x000E11EC
		public bool areListsEqual(List<string> list1, List<string> list2)
		{
			if (list1.Count != list2.Count)
			{
				return false;
			}
			foreach (string item in list1)
			{
				if (!list2.Contains(item))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000B36 RID: 2870 RVA: 0x000E3054 File Offset: 0x000E1254
		private void updateUsersListBox()
		{
			bool flag = false;
			this.lbActiveChatters.Items.Clear();
			ChatScreen.ChatRoom chatRoom = (ChatScreen.ChatRoom)this.localChatRooms[this.activeChatRoomIdent];
			if (chatRoom == null)
			{
				return;
			}
			chatRoom.usersInRoom.Sort();
			foreach (string text in chatRoom.usersInRoom)
			{
				this.lbActiveChatters.Items.Add(text);
				if (text == RemoteServices.Instance.UserName)
				{
					flag = true;
				}
			}
			if (!flag && chatRoom.usersInRoom.Count > 0 && this.tbTextInput.Visible)
			{
				MyMessageBox.Show(SK.Text("ChatScreen_Dismiss", "You have been dismissed from chat."), SK.Text("ChatScreen_Chat_Warning", "Chat Warning"));
				this.tbTextInput.Visible = false;
				this.btnSend.Visible = false;
				if (this.m_parent != null)
				{
					this.m_parent.close(true, true);
				}
				this.activeChatRoomIdent = -1;
				this.localChatRooms = new SparseArray();
			}
		}

		// Token: 0x06000B37 RID: 2871 RVA: 0x0000E52F File Offset: 0x0000C72F
		private void cbChatUpdate_CheckedChanged(object sender, EventArgs e)
		{
			Program.mySettings.NotifyChatUpdate = this.cbChatUpdate.Checked;
			GameEngine.Instance.playInterfaceSound("ChatScreen_notify_toggle");
		}

		// Token: 0x06000B38 RID: 2872 RVA: 0x000E3180 File Offset: 0x000E1380
		private void lbActiveChatters_DoubleClick(object sender, EventArgs e)
		{
			int selectedIndex = this.lbActiveChatters.SelectedIndex;
			if (selectedIndex >= 0 && selectedIndex < this.lbActiveChatters.Items.Count)
			{
				string b = (string)this.lbActiveChatters.Items[selectedIndex];
				ChatScreen.ChatRoom chatRoom = (ChatScreen.ChatRoom)this.localChatRooms[this.activeChatRoomIdent];
				if (chatRoom != null)
				{
					foreach (Chat_UserInRoom chat_UserInRoom in chatRoom.usersDataInRoom)
					{
						if (chat_UserInRoom.username == b)
						{
							GameEngine.Instance.playInterfaceSound("ChatScreen_user_clicked");
							InterfaceMgr.Instance.changeTab(0);
							WorldMap.CachedUserInfo cachedUserInfo = new WorldMap.CachedUserInfo();
							cachedUserInfo.userID = chat_UserInRoom.userID;
							InterfaceMgr.Instance.showUserInfoScreen(cachedUserInfo);
							break;
						}
					}
				}
			}
		}

		// Token: 0x06000B39 RID: 2873 RVA: 0x000E3274 File Offset: 0x000E1474
		private void tbTextViewer_LinkClicked(object sender, LinkClickedEventArgs e)
		{
			string text = e.LinkText;
			if (!text.ToLowerInvariant().Contains("http://") && !text.ToLowerInvariant().Contains("https://"))
			{
				text = "http://" + text;
			}
			DialogResult dialogResult = MyMessageBox.Show(string.Concat(new string[]
			{
				SK.Text("CHAT_Link_Warning1", "WARNING : You have clicked on an external link which will open a webpage in your browser. The link you have clicked is"),
				Environment.NewLine,
				Environment.NewLine,
				text,
				Environment.NewLine,
				Environment.NewLine,
				SK.Text("CHAT_Link_Warning2", "If you are sure you want to open this webpage, click OK, otherwise click cancel."),
				Environment.NewLine,
				Environment.NewLine
			}), SK.Text("CHAT_Open_Link", "Open External Link"), MessageBoxButtons.OKCancel);
			if (dialogResult == DialogResult.OK)
			{
				Process.Start(text);
			}
		}

		// Token: 0x06000B3A RID: 2874 RVA: 0x0000E555 File Offset: 0x0000C755
		private void pnlWikiHelp_MouseEnter(object sender, EventArgs e)
		{
			this.pnlWikiHelp.BackgroundImage = GFXLibrary.int_button_Q_over;
		}

		// Token: 0x06000B3B RID: 2875 RVA: 0x0000E56C File Offset: 0x0000C76C
		private void pnlWikiHelp_MouseLeave(object sender, EventArgs e)
		{
			this.pnlWikiHelp.BackgroundImage = GFXLibrary.int_button_Q_normal;
		}

		// Token: 0x06000B3C RID: 2876 RVA: 0x0000E583 File Offset: 0x0000C783
		private void pnlWikiHelp_MouseClick(object sender, MouseEventArgs e)
		{
			CustomSelfDrawPanel.WikiLinkControl.openHelpLink(27);
		}

		// Token: 0x04000F4B RID: 3915
		private DockableControl dockableControl;

		// Token: 0x04000F4C RID: 3916
		private IContainer components;

		// Token: 0x04000F4D RID: 3917
		private Label label1;

		// Token: 0x04000F4E RID: 3918
		private TextBox tbTextInput;

		// Token: 0x04000F4F RID: 3919
		private RichTextBox tbTextViewer;

		// Token: 0x04000F50 RID: 3920
		private BitmapButton btnSend;

		// Token: 0x04000F51 RID: 3921
		private BitmapButton btnClose;

		// Token: 0x04000F52 RID: 3922
		private Label lblRoomName;

		// Token: 0x04000F53 RID: 3923
		private ListBox lbActiveChatters;

		// Token: 0x04000F54 RID: 3924
		private ListBox lbRooms;

		// Token: 0x04000F55 RID: 3925
		private Label label2;

		// Token: 0x04000F56 RID: 3926
		private Label label3;

		// Token: 0x04000F57 RID: 3927
		private Label label4;

		// Token: 0x04000F58 RID: 3928
		private CheckBox cbChatUpdate;

		// Token: 0x04000F59 RID: 3929
		private Label lblLanguage;

		// Token: 0x04000F5A RID: 3930
		private Panel pnlWikiHelp;

		// Token: 0x04000F5B RID: 3931
		private ChatScreenManager m_parent;

		// Token: 0x04000F5C RID: 3932
		private DateTime lastRequestTime = DateTime.MinValue;

		// Token: 0x04000F5D RID: 3933
		private int checkTime = 5;

		// Token: 0x04000F5E RID: 3934
		private List<Chat_RoomID> registeredRooms = new List<Chat_RoomID>();

		// Token: 0x04000F5F RID: 3935
		private bool inSend;

		// Token: 0x04000F60 RID: 3936
		private DateTime lastSendTime = DateTime.MinValue;

		// Token: 0x04000F61 RID: 3937
		private RichTextBox rtb = new RichTextBox();

		// Token: 0x04000F62 RID: 3938
		private bool inClosing;

		// Token: 0x04000F63 RID: 3939
		private int activeChatRoomIdent = -1;

		// Token: 0x04000F64 RID: 3940
		private SparseArray localChatRooms = new SparseArray();

		// Token: 0x04000F65 RID: 3941
		private List<ChatScreen.ChatRoom> roomsDataSource = new List<ChatScreen.ChatRoom>();

		// Token: 0x04000F66 RID: 3942
		private bool dontPlayChangeSound;

		// Token: 0x0200012F RID: 303
		public class ChatRoom
		{
			// Token: 0x06000B3D RID: 2877 RVA: 0x0000E58C File Offset: 0x0000C78C
			public override string ToString()
			{
				if (this.newText)
				{
					return this.roomName + "*";
				}
				return this.roomName;
			}

			// Token: 0x04000F67 RID: 3943
			public int roomType = -1;

			// Token: 0x04000F68 RID: 3944
			public int roomID = -1;

			// Token: 0x04000F69 RID: 3945
			public string roomName = "";

			// Token: 0x04000F6A RID: 3946
			public string text = "";

			// Token: 0x04000F6B RID: 3947
			public bool newText;

			// Token: 0x04000F6C RID: 3948
			public List<string> usersInRoom = new List<string>();

			// Token: 0x04000F6D RID: 3949
			public List<Chat_UserInRoom> usersDataInRoom = new List<Chat_UserInRoom>();
		}
	}
}
