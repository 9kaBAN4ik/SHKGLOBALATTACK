using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x0200022C RID: 556
	public class MainMenuBar2 : CustomSelfDrawPanel.CSDControl
	{
		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x06001826 RID: 6182 RVA: 0x00019042 File Offset: 0x00017242
		public static bool CastleCopyMode
		{
			get
			{
				return MainMenuBar2.castleCopyMode && RemoteServices.Instance.Admin;
			}
		}

		// Token: 0x06001827 RID: 6183 RVA: 0x0017EA78 File Offset: 0x0017CC78
		public MainMenuBar2()
		{
			this.SaveCSVFileDialog = new SaveFileDialog();
			this.SaveCSVFileDialog.DefaultExt = "csv";
			this.SaveCSVFileDialog.Filter = "CSV (*.csv)|*.csv";
			this.SaveCSVFileDialog.Title = "Save Stats .csv File";
			this.SavePNGFileDialog = new SaveFileDialog();
			this.SavePNGFileDialog.DefaultExt = "png";
			this.SavePNGFileDialog.Filter = "PNG (*.png)|*.png";
			this.SavePNGFileDialog.Title = "Save Avatar .png File";
			if (RemoteServices.Instance.Admin)
			{
				this.btnAdminMenu.Visible = true;
			}
			else
			{
				this.btnAdminMenu.Visible = false;
			}
			this.btnCombat.Visible = false;
		}

		// Token: 0x06001828 RID: 6184 RVA: 0x0017EB98 File Offset: 0x0017CD98
		public void init2()
		{
			this.MenuButtonsPanel.init();
			this.clearControls();
			this.mainBackgroundImage.Image = GFXLibrary.menu_Background;
			this.mainBackgroundImage.Position = new Point(0, 0);
			this.mainBackgroundImage.Size = new Size(463, 29);
			base.addControl(this.mainBackgroundImage);
			this.btnAdminMenu.FillRectOverColor = Color.FromArgb(32, 0, 0, 0);
			this.btnAdminMenu.Position = new Point(79, 1);
			this.btnAdminMenu.Size = new Size(45, 23);
			this.btnAdminMenu.Text.Text = "Admin";
			this.btnAdminMenu.Text.Size = this.btnAdminMenu.Size;
			this.btnAdminMenu.Text.Color = global::ARGBColors.Black;
			this.btnAdminMenu.TextYOffset = -1;
			this.btnAdminMenu.Text.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.btnAdminMenu.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.btnAdminMenu.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.adminOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.genericLeave));
			this.btnAdminMenu.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnAdminMenu_Click));
			this.btnAdminMenu.Visible = RemoteServices.Instance.Admin;
			this.mainBackgroundImage.addControl(this.btnAdminMenu);
			this.btnCombat.FillRectOverColor = Color.FromArgb(32, 0, 0, 0);
			this.btnCombat.Position = new Point(19, 1);
			this.btnCombat.Size = new Size(54, 23);
			this.btnCombat.Text.Text = "Combat";
			this.btnCombat.Text.Size = this.btnCombat.Size;
			this.btnCombat.Text.Color = global::ARGBColors.Black;
			this.btnCombat.TextYOffset = -1;
			this.btnCombat.Text.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.btnCombat.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.btnCombat.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.combatOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.genericLeave));
			this.btnCombat.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnCombat_Click));
			this.btnCombat.Visible = RemoteServices.Instance.Admin;
			this.mainBackgroundImage.addControl(this.btnCombat);
			this.pnlLoadLight.Position = new Point(459, 0);
			this.pnlLoadLight.Size = new Size(4, 4);
			this.pnlLoadLight.Visible = false;
			this.pnlLoadLight.FillColor = global::ARGBColors.Green;
			this.mainBackgroundImage.addControl(this.pnlLoadLight);
			this.MenuButtonsPanel.Position = new Point(10, 0);
			this.MenuButtonsPanel.Size = new Size(150, 24);
			this.mainBackgroundImage.addControl(this.MenuButtonsPanel);
			this.MenuButtonsPanel.init();
			this.btnHelpMenu.FillRectOverColor = Color.FromArgb(32, 0, 0, 0);
			this.btnHelpMenu.Position = new Point(323, 1);
			this.btnHelpMenu.Size = new Size(62, 23);
			this.btnHelpMenu.Text.Text = SK.Text("MENU_Help", "Help");
			this.btnHelpMenu.Text.Size = this.btnHelpMenu.Size;
			this.btnHelpMenu.Text.Color = global::ARGBColors.Black;
			this.btnHelpMenu.TextYOffset = -1;
			this.btnHelpMenu.Text.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.btnHelpMenu.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.btnHelpMenu.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.helpOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.genericLeave));
			this.btnHelpMenu.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnHelp_Click));
			this.mainBackgroundImage.addControl(this.btnHelpMenu);
			this.btnLogOut.FillRectOverColor = Color.FromArgb(32, 0, 0, 0);
			this.btnLogOut.Position = new Point(391, 1);
			this.btnLogOut.Size = new Size(62, 23);
			this.btnLogOut.Text.Text = SK.Text("GENERIC_Log_Out", "Log Out");
			this.btnLogOut.Text.Size = this.btnLogOut.Size;
			this.btnLogOut.Text.Color = global::ARGBColors.Black;
			this.btnLogOut.TextYOffset = -1;
			this.btnLogOut.Text.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.btnLogOut.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.btnLogOut.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnLogOut_Click));
			this.mainBackgroundImage.addControl(this.btnLogOut);
			this.btnFileMenu.FillRectOverColor = Color.FromArgb(32, 0, 0, 0);
			this.btnFileMenu.Position = new Point(246, 1);
			this.btnFileMenu.Size = new Size(78, 23);
			this.btnFileMenu.Text.Text = SK.Text("MENU_Settings", "Settings");
			this.btnFileMenu.Text.Size = this.btnFileMenu.Size;
			this.btnFileMenu.Text.Color = global::ARGBColors.Black;
			this.btnFileMenu.TextYOffset = -1;
			this.btnFileMenu.Text.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.btnFileMenu.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.btnFileMenu.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.fileOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.genericLeave));
			this.btnFileMenu.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.button2_Click));
			this.mainBackgroundImage.addControl(this.btnFileMenu);
			this.btnMyAccount.FillRectOverColor = Color.FromArgb(32, 0, 0, 0);
			this.btnMyAccount.Position = new Point(166, 1);
			this.btnMyAccount.Size = new Size(78, 23);
			this.btnMyAccount.Text.Text = SK.Text("MENU_My_Account", "My Account");
			this.btnMyAccount.Text.Size = this.btnMyAccount.Size;
			this.btnMyAccount.Text.Color = global::ARGBColors.Black;
			this.btnMyAccount.TextYOffset = -1;
			this.btnMyAccount.Text.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.btnMyAccount.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.btnMyAccount.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.accountOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.genericLeave));
			this.btnMyAccount.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnMyAccount_Click));
			this.mainBackgroundImage.addControl(this.btnMyAccount);
			this.resize();
		}

		// Token: 0x06001829 RID: 6185 RVA: 0x00019057 File Offset: 0x00017257
		private void helpOver()
		{
			if (MenuPopup.isAMenuVisible())
			{
				this.btnHelp_Click(false);
			}
		}

		// Token: 0x0600182A RID: 6186 RVA: 0x00019067 File Offset: 0x00017267
		private void fileOver()
		{
			if (MenuPopup.isAMenuVisible())
			{
				this.button2_Click(false);
			}
		}

		// Token: 0x0600182B RID: 6187 RVA: 0x00019077 File Offset: 0x00017277
		private void accountOver()
		{
			if (MenuPopup.isAMenuVisible())
			{
				this.btnMyAccount_Click(false);
			}
		}

		// Token: 0x0600182C RID: 6188 RVA: 0x00019087 File Offset: 0x00017287
		private void adminOver()
		{
			if (MenuPopup.isAMenuVisible())
			{
				this.btnAdminMenu_Click();
			}
		}

		// Token: 0x0600182D RID: 6189 RVA: 0x00019096 File Offset: 0x00017296
		private void combatOver()
		{
			if (MenuPopup.isAMenuVisible())
			{
				this.btnCombat_Click();
			}
		}

		// Token: 0x0600182E RID: 6190 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void genericLeave()
		{
		}

		// Token: 0x0600182F RID: 6191 RVA: 0x000190A5 File Offset: 0x000172A5
		public void setAdmin()
		{
			if (RemoteServices.Instance.Admin)
			{
				this.btnAdminMenu.Visible = true;
				return;
			}
			this.btnAdminMenu.Visible = false;
			this.btnCombat.Visible = false;
		}

		// Token: 0x06001830 RID: 6192 RVA: 0x000190D8 File Offset: 0x000172D8
		private void button2_Click()
		{
			this.button2_Click(true);
		}

		// Token: 0x06001831 RID: 6193 RVA: 0x0017F30C File Offset: 0x0017D50C
		private void button2_Click(bool sfx)
		{
			if (sfx)
			{
				GameEngine.Instance.playInterfaceSound("WorldMapScreen_menu_settings");
			}
			MenuPopup menuPopup = new MenuPopup();
			Point point = base.csd.PointToScreen(this.btnFileMenu.Position);
			menuPopup.setPosition(point.X, point.Y + 24);
			menuPopup.setCallBack(new MenuPopup.MenuCallback(this.menu1Callback));
			menuPopup.addMenuItem(SK.Text("MENU_Settings", "Settings"), 1);
			if (!GameEngine.Instance.World.WorldEnded)
			{
				menuPopup.addMenuItem(SK.Text("MENU_Edit_Avatar", "Edit Avatar"), 5);
				menuPopup.addMenuItem(SK.Text("User_Manage_Relations", "Manage Diplomacy"), 300);
			}
			int ownSelectedVillage = InterfaceMgr.Instance.OwnSelectedVillage;
			if (ownSelectedVillage >= 0 && !GameEngine.Instance.World.isCapital(ownSelectedVillage) && GameEngine.Instance.World.isUserVillage(ownSelectedVillage) && !GameEngine.Instance.World.WorldEnded)
			{
				menuPopup.addBar();
				menuPopup.addMenuItem(SK.Text("MENU_Rename_Current_Village", "Rename Current Village"), 9);
				CustomSelfDrawPanel.CSDControl csdcontrol = menuPopup.addMenuItem(SK.Text("MENU_Convert_Current_Village", "Convert Current Village"), 12);
				CustomSelfDrawPanel.CSDControl csdcontrol2 = menuPopup.addMenuItem(SK.Text("MENU_Abandon_Current_Village", "Abandon Current Village"), 11);
				csdcontrol.CustomTooltipID = 1200;
				csdcontrol2.CustomTooltipID = 1201;
			}
			menuPopup.showMenu();
		}

		// Token: 0x06001832 RID: 6194 RVA: 0x000190E1 File Offset: 0x000172E1
		private void btnHelp_Click()
		{
			this.btnHelp_Click(true);
		}

		// Token: 0x06001833 RID: 6195 RVA: 0x0017F484 File Offset: 0x0017D684
		private void btnHelp_Click(bool sfx)
		{
			if (sfx)
			{
				GameEngine.Instance.playInterfaceSound("WorldMapScreen_menu_help");
			}
			MenuPopup menuPopup = new MenuPopup();
			Point point = base.csd.PointToScreen(this.btnHelpMenu.Position);
			menuPopup.setPosition(point.X, point.Y + 24);
			menuPopup.setCallBack(new MenuPopup.MenuCallback(this.menu1Callback));
			menuPopup.addMenuItem(SK.Text("MENU_SHK_Help", "Stronghold Kingdoms Help"), 108);
			menuPopup.addMenuItem(SK.Text("MENU_Game_Rules", "Game Rules"), 109);
			if (Program.mySettings.LanguageIdent == "en")
			{
				menuPopup.addMenuItem("Terms & Conditions", 151);
			}
			else
			{
				menuPopup.addMenuItem(SK.Text("MENU_TandC", "Terms & Conditions").Replace("&amp;", "&&"), 151);
			}
			menuPopup.addMenuItem(SK.Text("MENU_Privacy", "Privacy Policy"), 152);
			menuPopup.addMenuItem(SK.Text("MENU_Forum", "Forum"), 107);
			menuPopup.addBar();
			menuPopup.addMenuItem(SK.Text("MENU_Show_Admin_Message", "Show Admin Message"), 103);
			menuPopup.addBar();
			if (GameEngine.Instance.World.isTutorialResumable())
			{
				menuPopup.addMenuItem(SK.Text("Options_Resume_Tutorial", "Resume Tutorial"), 1109);
			}
			menuPopup.addMenuItem(SK.Text("Options_Player_Guide", "Player Guide"), 1201);
			menuPopup.addBar();
			menuPopup.addMenuItem(SK.Text("MENU_About_Stronghold Kingdoms", "About Stronghold Kingdoms"), 102);
			menuPopup.showMenu();
		}

		// Token: 0x06001834 RID: 6196 RVA: 0x000190EA File Offset: 0x000172EA
		private void btnMyAccount_Click()
		{
			this.btnMyAccount_Click(true);
		}

		// Token: 0x06001835 RID: 6197 RVA: 0x0017F630 File Offset: 0x0017D830
		private void btnMyAccount_Click(bool sfx)
		{
			if (sfx)
			{
				GameEngine.Instance.playInterfaceSound("WorldMapScreen_menu_myaccount");
			}
			MenuPopup menuPopup = new MenuPopup();
			Point point = base.csd.PointToScreen(this.btnMyAccount.Position);
			menuPopup.setPosition(point.X, point.Y + 24);
			menuPopup.setCallBack(new MenuPopup.MenuCallback(this.menu1Callback));
			menuPopup.addMenuItem(SK.Text("MENU_Account_Information", "Account Information"), 21001);
			if (!GameEngine.Instance.World.isBigpointAccount && !Program.bigpointInstall && !Program.aeriaInstall && !Program.bigpointPartnerInstall)
			{
				menuPopup.addMenuItem(SK.Text("MENU_Invite_A_Friend", "Invite a Friend"), 21002);
			}
			menuPopup.addMenuItem(SK.Text("MENU_Redeem_Offer_Code", "Redeem Offer Code"), 21003);
			if (!GameEngine.Instance.World.WorldEnded)
			{
				menuPopup.addBar();
				if (GameEngine.Instance.LocalWorldData.Alternate_Ruleset != 1)
				{
					menuPopup.addMenuItem(SK.Text("MENU_VacationMode", "Vacation Mode Options"), 21009);
				}
			}
			menuPopup.showMenu();
		}

		// Token: 0x06001836 RID: 6198 RVA: 0x0017F758 File Offset: 0x0017D958
		private void menu1Callback(int id)
		{
			GameEngine.Instance.playInterfaceSound("WorldMapScreen_menu_item_selected");
			this.fixCommandSent = false;
			if (id <= 232)
			{
				if (id <= 152)
				{
					if (id <= 109)
					{
						switch (id)
						{
						case 1:
							GameEngine.Instance.playInterfaceSound("Options_open");
							OptionsPopup.openSettings();
							return;
						case 2:
							InterfaceMgr.Instance.openLogoutWindow(true);
							return;
						case 3:
						case 4:
							return;
						case 5:
							InterfaceMgr.Instance.getMainTabBar().selectDummyTab(10);
							return;
						default:
							switch (id)
							{
							case 9:
							{
								if (RemoteServices.Instance.Admin && GameEngine.Instance.World.DrawDebugVillageNames)
								{
									int selectedVillage = InterfaceMgr.Instance.SelectedVillage;
									RenameVillagePopup renameVillagePopup = new RenameVillagePopup();
									renameVillagePopup.setVillageID(selectedVillage, GameEngine.Instance.World.getVillageNameOnly(selectedVillage));
									renameVillagePopup.Show(InterfaceMgr.Instance.ParentForm);
									return;
								}
								int ownSelectedVillage = InterfaceMgr.Instance.OwnSelectedVillage;
								if (ownSelectedVillage >= 0 && !GameEngine.Instance.World.isCapital(ownSelectedVillage) && GameEngine.Instance.World.isUserVillage(ownSelectedVillage))
								{
									RenameVillagePopup renameVillagePopup2 = new RenameVillagePopup();
									renameVillagePopup2.setVillageID(ownSelectedVillage, GameEngine.Instance.World.getVillageNameOnly(ownSelectedVillage));
									renameVillagePopup2.Show(InterfaceMgr.Instance.ParentForm);
									return;
								}
								MyMessageBox.Show(SK.Text("MENU_Cannot_Rename", "You cannot rename this village."), SK.Text("MENU_Rename_Error", "Rename Error"));
								return;
							}
							case 10:
								return;
							case 11:
							{
								int ownSelectedVillage2 = InterfaceMgr.Instance.OwnSelectedVillage;
								if (ownSelectedVillage2 >= 0 && !GameEngine.Instance.World.isCapital(ownSelectedVillage2) && GameEngine.Instance.World.isUserVillage(ownSelectedVillage2))
								{
									GameEngine.Instance.villageToAbandon = ownSelectedVillage2;
									return;
								}
								MyMessageBox.Show(SK.Text("MENU_Cannot_Abandon", "You cannot abandon this village."), SK.Text("GENERIC_Error", "Error"));
								return;
							}
							case 12:
							{
								int ownSelectedVillage3 = InterfaceMgr.Instance.OwnSelectedVillage;
								if (ownSelectedVillage3 < 0 || GameEngine.Instance.World.isCapital(ownSelectedVillage3) || !GameEngine.Instance.World.isUserVillage(ownSelectedVillage3))
								{
									return;
								}
								InterfaceMgr.Instance.changeTab(1);
								VillageMap village = GameEngine.Instance.getVillage(ownSelectedVillage3);
								if (village != null && village.m_nextMapTypeChange > VillageMap.getCurrentServerTime())
								{
									TimeSpan timeSpan = village.m_nextMapTypeChange - VillageMap.getCurrentServerTime();
									string str = (timeSpan.Days <= 0) ? string.Format("{0:D1} " + SK.Text("MENU_hours_short", "hrs") + ", {1:D2} " + SK.Text("MENU_minutes_short", "mins"), timeSpan.Hours, timeSpan.Minutes) : string.Format(string.Concat(new string[]
									{
										"{0:D2} ",
										SK.Text("MENU_days", "days"),
										", {1:D2} ",
										SK.Text("MENU_hours_short", "hrs"),
										", {2:D2} ",
										SK.Text("MENU_minutes_short", "mins")
									}), timeSpan.Days, timeSpan.Hours, timeSpan.Minutes);
									MyMessageBox.Show(SK.Text("MENU_Cannot_Change_Type", "You cannot change this Village's Type for") + " : " + str, SK.Text("MENU_Change_Type_Error", "Change Village Type Error"));
									return;
								}
								InterfaceMgr.Instance.openBuyVillageWindow(ownSelectedVillage3, false);
								return;
							}
							default:
								switch (id)
								{
								case 101:
									new Process
									{
										StartInfo = 
										{
											FileName = "readme.txt"
										}
									}.Start();
									return;
								case 102:
								{
									AboutPopup aboutPopup = new AboutPopup();
									aboutPopup.init();
									aboutPopup.Show();
									return;
								}
								case 103:
									AdminInfoPopup.showMessage();
									return;
								case 104:
								case 106:
									return;
								case 105:
									try
									{
										new Process
										{
											StartInfo = 
											{
												FileName = URLs.FireflyHomepage
											}
										}.Start();
										return;
									}
									catch (Exception)
									{
										return;
									}
									break;
								case 107:
									break;
								case 108:
									goto IL_64F;
								case 109:
									goto IL_67B;
								default:
									return;
								}
								try
								{
									new Process
									{
										StartInfo = 
										{
											FileName = URLs.ForumHomepage
										}
									}.Start();
									return;
								}
								catch (Exception)
								{
									return;
								}
								break;
							}
							break;
						}
					}
					else
					{
						if (id == 121)
						{
							goto IL_6FF;
						}
						if (id == 151)
						{
							goto IL_6A7;
						}
						if (id != 152)
						{
							return;
						}
						goto IL_6D3;
					}
				}
				else if (id <= 221)
				{
					switch (id)
					{
					case 201:
						goto IL_72B;
					case 202:
						this.nextPlaybackCountries = true;
						if (GameEngine.Instance.World.gotPlaybackData())
						{
							GameEngine.Instance.World.playbackCountries();
							InterfaceMgr.Instance.togglePlaybackBarDXActive(true);
							return;
						}
						this.retrieveGameStats();
						return;
					case 203:
						this.retrieveGameInfo();
						return;
					default:
						if (id != 209)
						{
							if (id != 221)
							{
								return;
							}
							this.createIngameMessage();
							return;
						}
						else
						{
							MessageBoxButtons buts = MessageBoxButtons.YesNo;
							DialogResult dialogResult = MyMessageBox.Show("This call is not entirely 'game friendly'. Only use sparingly and at quiet game times and make sure no one else is using them same function!", "Admin Warning!", buts, MessageBoxIcon.None, MessageBoxDefaultButton.Button2, 0);
							if (dialogResult == DialogResult.Yes)
							{
								this.fixCommandSent = true;
								RemoteServices.Instance.set_CompleteVillageCastle_UserCallBack(new RemoteServices.CompleteVillageCastle_UserCallBack(this.CompleteVillageCastleCallBack));
								RemoteServices.Instance.CompleteVillageCastle(InterfaceMgr.Instance.getSelectedMenuVillage(), 15);
								return;
							}
							return;
						}
						break;
					}
				}
				else
				{
					if (id == 223)
					{
						this.clearIngameMessage();
						return;
					}
					if (id == 231)
					{
						GameEngine.Instance.World.DrawDebugNames = !GameEngine.Instance.World.DrawDebugNames;
						GameEngine.Instance.World.DrawDebugVillageNames = false;
						return;
					}
					if (id != 232)
					{
						return;
					}
					GameEngine.Instance.World.DrawDebugVillageNames = !GameEngine.Instance.World.DrawDebugVillageNames;
					GameEngine.Instance.World.DrawDebugNames = false;
					return;
				}
			}
			else
			{
				if (id > 9202)
				{
					if (id <= 21003)
					{
						if (id == 9203)
						{
							GameEngine.Instance.World.stopPlayback();
							InterfaceMgr.Instance.togglePlaybackBarDXActive(false);
							return;
						}
						if (id == 10799)
						{
							goto IL_601;
						}
						switch (id)
						{
						case 20999:
							MainMenuBar2.castleCopyMode = true;
							return;
						case 21000:
							return;
						case 21001:
						{
							string text = URLs.AccountInfoURL + "?webtoken=" + RemoteServices.Instance.WebToken;
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
						case 21002:
							break;
						case 21003:
							goto IL_CA4;
						default:
							return;
						}
						string text2 = URLs.InviteAFriendURL + "?webtoken=" + RemoteServices.Instance.WebToken;
						text2 = text2 + "&lang=" + Program.mySettings.LanguageIdent.ToLower();
						try
						{
							Process.Start(text2);
							return;
						}
						catch (Exception)
						{
							MyMessageBox.Show(SK.Text("ERROR_Browser1", "Stronghold Kingdoms encountered an error when trying to open your system's Default Web Browser. Please check that your web browser is working correctly and there are no unresponsive copies showing in task manager->Processes and then try again.") + Environment.NewLine + Environment.NewLine + SK.Text("ERROR_Browser2", "If this problem persists, please contact support."), SK.Text("ERROR_Browser3", "Error opening Web Browser"));
							return;
						}
						IL_CA4:
						string text3 = URLs.AccountInfoURL + "?section=codes&webtoken=" + RemoteServices.Instance.WebToken;
						text3 = text3 + "&lang=" + Program.mySettings.LanguageIdent.ToLower();
						try
						{
							Process.Start(text3);
							return;
						}
						catch (Exception)
						{
							MyMessageBox.Show(SK.Text("ERROR_Browser1", "Stronghold Kingdoms encountered an error when trying to open your system's Default Web Browser. Please check that your web browser is working correctly and there are no unresponsive copies showing in task manager->Processes and then try again.") + Environment.NewLine + Environment.NewLine + SK.Text("ERROR_Browser2", "If this problem persists, please contact support."), SK.Text("ERROR_Browser3", "Error opening Web Browser"));
							return;
						}
					}
					else if (id != 21009)
					{
						if (id != 40001)
						{
							if (id != 40002)
							{
								return;
							}
							if (!GameEngine.Instance.World.WorldEnded)
							{
								if (GameEngine.Instance.LocalWorldData.EraWorld)
								{
									return;
								}
								GloryRoundData houseGloryRoundData = GameEngine.Instance.World.HouseGloryRoundData;
								WorldMap.CachedUserInfo cachedUserInfo = new WorldMap.CachedUserInfo();
								WorldMap.VillageRolloverInfo villageRolloverInfo = null;
								cachedUserInfo.userID = houseGloryRoundData.marshallUserID;
								GameEngine.Instance.World.retrieveUserData(-1, houseGloryRoundData.marshallUserID, ref villageRolloverInfo, ref cachedUserInfo, true, true);
								if (cachedUserInfo == null)
								{
									return;
								}
								this.SavePNGFileDialog.Title = "Map Data Export";
								DialogResult dialogResult2 = this.SavePNGFileDialog.ShowDialog();
								if (dialogResult2 == DialogResult.OK)
								{
									Avatar.CreateExportAvatar(cachedUserInfo, this.SavePNGFileDialog.FileName);
									return;
								}
								return;
							}
							else
							{
								if (WorldsEndPanel.cachedData == null || WorldsEndPanel.cachedData.globalData == null || WorldsEndPanel.cachedData.globalData.winningUser <= 0)
								{
									return;
								}
								WorldMap.CachedUserInfo cachedUserInfo2 = new WorldMap.CachedUserInfo();
								WorldMap.VillageRolloverInfo villageRolloverInfo2 = null;
								cachedUserInfo2.userID = WorldsEndPanel.cachedData.globalData.winningUser;
								GameEngine.Instance.World.retrieveUserData(-1, WorldsEndPanel.cachedData.globalData.winningUser, ref villageRolloverInfo2, ref cachedUserInfo2, true, true);
								if (cachedUserInfo2 == null)
								{
									return;
								}
								this.SavePNGFileDialog.Title = "Map Data Export";
								DialogResult dialogResult3 = this.SavePNGFileDialog.ShowDialog();
								if (dialogResult3 == DialogResult.OK)
								{
									Avatar.CreateExportAvatar(cachedUserInfo2, this.SavePNGFileDialog.FileName);
									return;
								}
								return;
							}
						}
						else
						{
							if (GameEngine.Instance.World.WorldEnded)
							{
								RemoteServices.Instance.set_EndOfTheWorldStats_UserCallBack(new RemoteServices.EndOfTheWorldStats_UserCallBack(this.endOfTheWorldCallback));
								RemoteServices.Instance.EndOfTheWorldStats();
								return;
							}
							if (!GameEngine.Instance.LocalWorldData.EraWorld)
							{
								GloryRoundData houseGloryRoundData2 = GameEngine.Instance.World.HouseGloryRoundData;
								WorldMap.CachedUserInfo cachedUserInfo3 = new WorldMap.CachedUserInfo();
								WorldMap.VillageRolloverInfo villageRolloverInfo3 = null;
								cachedUserInfo3.userID = houseGloryRoundData2.marshallUserID;
								GameEngine.Instance.World.retrieveUserData(-1, houseGloryRoundData2.marshallUserID, ref villageRolloverInfo3, ref cachedUserInfo3, true, true);
								return;
							}
							return;
						}
					}
					CreateVacationWindow.showVacationMode();
					return;
				}
				if (id <= 1123)
				{
					if (id == 300)
					{
						InterfaceMgr.Instance.getMainTabBar().selectDummyTab(60);
						return;
					}
					if (id == 1001)
					{
						InterfaceMgr.Instance.ParentForm.Close();
						return;
					}
					switch (id)
					{
					case 1101:
						InterfaceMgr.Instance.getMainTabBar().selectDummyTab(2);
						GameEngine.Instance.InitCastleAttackSetup();
						return;
					case 1102:
						GameEngine.Instance.SkipVillageTab();
						InterfaceMgr.Instance.getMainTabBar().changeTab(1);
						InterfaceMgr.Instance.getVillageTabBar().changeTab(1);
						CastleMap.CreateMode = true;
						return;
					case 1103:
					case 1104:
					case 1105:
					case 1106:
					case 1107:
					case 1108:
						return;
					case 1109:
						GameEngine.Instance.playInterfaceSound("Options_resume_tutorial");
						GameEngine.Instance.World.resumeTutorial();
						return;
					case 1110:
					case 1111:
					case 1112:
					case 1113:
					case 1114:
					case 1115:
					case 1116:
					case 1117:
					case 1118:
					case 1119:
						CastleMap.FakeKeep = id - 1110 + 1;
						return;
					case 1120:
					case 1121:
					case 1122:
					case 1123:
						CastleMap.FakeDefensiveMode = id - 1120;
						return;
					default:
						return;
					}
				}
				else
				{
					if (id == 1201)
					{
						PostTutorialWindow.CreatePostTutorialWindow(false);
						return;
					}
					if (id != 2219)
					{
						if (id != 9202)
						{
							return;
						}
						this.nextPlaybackCountries = false;
						if (GameEngine.Instance.World.gotPlaybackData())
						{
							GameEngine.Instance.World.playbackProvinces();
							InterfaceMgr.Instance.togglePlaybackBarDXActive(true);
							return;
						}
						this.retrieveGameStats();
						return;
					}
					else
					{
						if (GameEngine.Instance.World.MapEditing)
						{
							int villageID = GameEngine.Instance.World.lastClickedVillage();
							if (GameEngine.Instance.World.isCountyCapital(villageID) && !GameEngine.Instance.World.isVillageVisible(villageID))
							{
								RemoteServices.Instance.CompleteVillageCastle(villageID, 21);
							}
							GameEngine.Instance.World.MapEditing = false;
							return;
						}
						GameEngine.Instance.World.MapEditing = true;
						return;
					}
				}
			}
			IL_601:
			try
			{
				string fileName = "http://login.strongholdkingdoms.com/support/?webtoken=" + RemoteServices.Instance.WebToken + "&lang=" + Program.mySettings.languageIdent;
				new Process
				{
					StartInfo = 
					{
						FileName = fileName
					}
				}.Start();
				return;
			}
			catch (Exception)
			{
				return;
			}
			IL_64F:
			try
			{
				new Process
				{
					StartInfo = 
					{
						FileName = URLs.WikiPage
					}
				}.Start();
				return;
			}
			catch (Exception)
			{
				return;
			}
			IL_67B:
			try
			{
				new Process
				{
					StartInfo = 
					{
						FileName = URLs.IPSharingPage
					}
				}.Start();
				return;
			}
			catch (Exception)
			{
				return;
			}
			IL_6A7:
			try
			{
				new Process
				{
					StartInfo = 
					{
						FileName = URLs.TermsAndConditions
					}
				}.Start();
				return;
			}
			catch (Exception)
			{
				return;
			}
			IL_6D3:
			try
			{
				new Process
				{
					StartInfo = 
					{
						FileName = URLs.PrivacyPolicy
					}
				}.Start();
				return;
			}
			catch (Exception)
			{
				return;
			}
			IL_6FF:
			try
			{
				new Process
				{
					StartInfo = 
					{
						FileName = URLs.WikiPage
					}
				}.Start();
				return;
			}
			catch (Exception)
			{
				return;
			}
			IL_72B:
			AdminInfoPopup.showAdminEdit();
		}

		// Token: 0x06001837 RID: 6199 RVA: 0x00180520 File Offset: 0x0017E720
		private void btnAdminMenu_Click()
		{
			MenuPopup menuPopup = new MenuPopup();
			Point point = base.csd.PointToScreen(this.btnAdminMenu.Position);
			menuPopup.setPosition(point.X, point.Y + 24);
			menuPopup.setCallBack(new MenuPopup.MenuCallback(this.menu1Callback));
			menuPopup.addMenuItem("Edit Admin Message", 201);
			menuPopup.addMenuItem("Retrieve Game Info", 203);
			menuPopup.addBar();
			menuPopup.addMenuItem("Country Playback (Admins Only)", 202);
			menuPopup.addMenuItem("Province Playback (Admins Only)", 9202);
			menuPopup.addMenuItem("Stop Playback (Admins Only)", 9203);
			menuPopup.addBar();
			menuPopup.addMenuItem("Fix Lost Units (CAREFUL!)", 209);
			menuPopup.addMenuItem("Castle Copy Mode", 20999);
			if (!GameEngine.Instance.World.MapEditing)
			{
				menuPopup.addMenuItem("Open County - Select Capital", 2219);
			}
			else
			{
				int villageID = GameEngine.Instance.World.lastClickedVillage();
				if (GameEngine.Instance.World.isCountyCapital(villageID) && !GameEngine.Instance.World.isVillageVisible(villageID))
				{
					int countyFromVillageID = GameEngine.Instance.World.getCountyFromVillageID(villageID);
					menuPopup.addMenuItem("Open County : " + GameEngine.Instance.World.getCountyName(countyFromVillageID), 2219);
				}
				else
				{
					menuPopup.addMenuItem("Open County : NONE SELECTED", 2219);
				}
			}
			menuPopup.addBar();
			menuPopup.addMenuItem("Prep Winners Avatar", 40001);
			menuPopup.addMenuItem("Export Winners Avatar", 40002);
			menuPopup.addBar();
			menuPopup.addMenuItem("Toggle Village IDs", 231);
			menuPopup.addMenuItem("Toggle Village Names", 232);
			menuPopup.addBar();
			menuPopup.addMenuItem("Create Ingame Message", 221);
			menuPopup.addMenuItem("Remove Ingame Message", 223);
			menuPopup.showMenu();
		}

		// Token: 0x06001838 RID: 6200 RVA: 0x00180718 File Offset: 0x0017E918
		private void CompleteVillageCastleCallBack(CompleteVillageCastle_ReturnType returnData)
		{
			if (returnData.Success && returnData.cardData >= 0)
			{
				GameEngine.Instance.cardsManager.addProfileCard(returnData.cardData, CardTypes.getStringFromCard(3080));
			}
			if (returnData.Success && this.fixCommandSent)
			{
				MyMessageBox.Show(string.Concat(new string[]
				{
					"Armies : ",
					returnData.armies.ToString(),
					Environment.NewLine,
					"Monks : ",
					returnData.monks.ToString(),
					Environment.NewLine,
					"Traders : ",
					returnData.traders.ToString(),
					Environment.NewLine,
					"Cards : ",
					returnData.cards.ToString(),
					Environment.NewLine
				}), "Fixes");
			}
			this.fixCommandSent = false;
		}

		// Token: 0x06001839 RID: 6201 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void btnMail_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600183A RID: 6202 RVA: 0x000190F3 File Offset: 0x000172F3
		private void btnMail_MouseEnter(object sender, EventArgs e)
		{
			if (MenuPopup.isAMenuVisible())
			{
				this.btnMail_Click(null, null);
			}
		}

		// Token: 0x0600183B RID: 6203 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void btnCombat_Click()
		{
		}

		// Token: 0x0600183C RID: 6204 RVA: 0x00019104 File Offset: 0x00017304
		public void setLoadingLight(bool loading)
		{
			this.pnlLoadLight.Visible = loading;
		}

		// Token: 0x0600183D RID: 6205 RVA: 0x00019112 File Offset: 0x00017312
		public void retrieveGameStats()
		{
			RemoteServices.Instance.set_RetrieveStats_UserCallBack(new RemoteServices.RetrieveStats_UserCallBack(this.retrieveStatsCallback));
			RemoteServices.Instance.RetrieveStats();
		}

		// Token: 0x0600183E RID: 6206 RVA: 0x00180804 File Offset: 0x0017EA04
		public void retrieveStatsCallback(RetrieveStats_ReturnType returnData)
		{
			if (returnData.Success && returnData.mapHistory != null)
			{
				GameEngine.Instance.World.setPlaybackData(returnData.mapHistory, returnData.worldStartTime);
				if (this.nextPlaybackCountries)
				{
					GameEngine.Instance.World.playbackCountries();
					return;
				}
				GameEngine.Instance.World.playbackProvinces();
			}
		}

		// Token: 0x0600183F RID: 6207 RVA: 0x00019134 File Offset: 0x00017334
		public void retrieveGameInfo()
		{
			RemoteServices.Instance.set_GetAdminStats_UserCallBack(new RemoteServices.GetAdminStats_UserCallBack(this.getAdminStatsCallback));
			RemoteServices.Instance.GetAdminStats();
		}

		// Token: 0x06001840 RID: 6208 RVA: 0x00180864 File Offset: 0x0017EA64
		public void getAdminStatsCallback(GetAdminStats_ReturnType returnData)
		{
			if (returnData.Success)
			{
				AdminStatsPopup adminStatsPopup = new AdminStatsPopup();
				adminStatsPopup.init(returnData);
				adminStatsPopup.Show();
			}
		}

		// Token: 0x06001841 RID: 6209 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void shutdownMessage()
		{
		}

		// Token: 0x06001842 RID: 6210 RVA: 0x0018088C File Offset: 0x0017EA8C
		public void createIngameMessage()
		{
			AdminIngameMessage adminIngameMessage = new AdminIngameMessage();
			adminIngameMessage.Show();
		}

		// Token: 0x06001843 RID: 6211 RVA: 0x00019156 File Offset: 0x00017356
		public void clearIngameMessage()
		{
			RemoteServices.Instance.SetAdminMessage("", 1000);
		}

		// Token: 0x06001844 RID: 6212 RVA: 0x001808A8 File Offset: 0x0017EAA8
		public static void VillageRenameCallback(VillageRename_ReturnType returnData)
		{
			if (returnData.Success)
			{
				if (returnData.abandoned)
				{
					GameEngine.Instance.World.newPlayer = false;
					GameEngine.Instance.World.lastAttacker = RemoteServices.Instance.UserName;
					GameEngine.Instance.World.lastAttackerLastUpdate = DateTime.Now;
					GameEngine.Instance.flushVillages();
					GameEngine.Instance.forceFullTick();
					return;
				}
			}
			else
			{
				if (returnData.m_errorCode == ErrorCodes.ErrorCode.ABANDONED_TOO_SOON)
				{
					MyMessageBox.Show(SK.Text("MENU_Abandon_Once_Week", "You can only abandon your village once a week"), SK.Text("MENU_Abandon_Village_Error", "Abandon Village Error"));
				}
				if (returnData.m_errorCode == ErrorCodes.ErrorCode.CANT_ABANDON_WITH_INCOMING_ATTACKS)
				{
					MyMessageBox.Show(SK.Text("MENU_Abandon_Incoming", "You cannot abandon your village while you have incoming attacks"), SK.Text("MENU_Abandon_Village_Error", "Abandon Village Error"));
				}
			}
		}

		// Token: 0x06001845 RID: 6213 RVA: 0x0018097C File Offset: 0x0017EB7C
		public void setServerTime(DateTime serverTime, int gameDay)
		{
			int playbackDay = GameEngine.Instance.World.getPlaybackDay();
			if (playbackDay >= 0)
			{
				InterfaceMgr.Instance.getTopLeftMenu().setServerTime(playbackDay.ToString());
				return;
			}
			bool flag = false;
			if (GameEngine.Instance.LocalWorldData.Alternate_Ruleset == 1)
			{
				TimeSpan dominationTimeLeft = GameEngine.Instance.getDominationTimeLeft();
				if (dominationTimeLeft.TotalHours < 15.0)
				{
					flag = true;
				}
				int num = (int)dominationTimeLeft.TotalSeconds;
				int num2 = num % 60;
				int num3 = num / 60 % 60;
				int num4 = num / 3600 % 24;
				int num5 = num / 86400;
				if (dominationTimeLeft.TotalHours >= 24.0)
				{
					string text = num5.ToString() + SK.Text("VillageMap_Day_Abbrev", "d") + ":";
					text = ((num4 == 0) ? (text + "00:") : ((num4 >= 10) ? (text + num4.ToString() + ":") : (text + "0" + num4.ToString() + ":")));
					text = ((num3 == 0) ? (text + "00:") : ((num3 >= 10) ? (text + num3.ToString() + ":") : (text + "0" + num3.ToString() + ":")));
					text = ((num2 == 0) ? (text + "00") : ((num2 >= 10) ? (text + num2.ToString()) : (text + "0" + num2.ToString())));
					if (flag)
					{
						InterfaceMgr.Instance.getTopLeftMenu().setServerTime(SK.Text("Dom_Time_Left", "Time Remaining") + " " + text);
					}
					InterfaceMgr.Instance.updateDominationWindow(text);
				}
				else
				{
					string text2 = "";
					text2 = ((num4 == 0) ? (text2 + "00:") : ((num4 >= 10) ? (text2 + num4.ToString() + ":") : (text2 + "0" + num4.ToString() + ":")));
					text2 = ((num3 == 0) ? (text2 + "00:") : ((num3 >= 10) ? (text2 + num3.ToString() + ":") : (text2 + "0" + num3.ToString() + ":")));
					text2 = ((num2 == 0) ? (text2 + "00") : ((num2 >= 10) ? (text2 + num2.ToString()) : (text2 + "0" + num2.ToString())));
					if (flag)
					{
						InterfaceMgr.Instance.getTopLeftMenu().setServerTime(SK.Text("Dom_Time_Left", "Time Remaining") + " " + text2);
					}
					InterfaceMgr.Instance.updateDominationWindow(text2);
				}
			}
			if (!flag)
			{
				InterfaceMgr.Instance.getTopLeftMenu().setServerTime(string.Concat(new string[]
				{
					SK.Text("MENU_Day_X", "Day"),
					" ",
					gameDay.ToString(),
					" - ",
					serverTime.ToLongTimeString()
				}));
			}
		}

		// Token: 0x06001846 RID: 6214 RVA: 0x00180CB8 File Offset: 0x0017EEB8
		private void btnLogOut_Click()
		{
			GameEngine.Instance.playInterfaceSound("WorldMapScreen_menu_logout");
			if (this.logoutPopup != null && this.logoutPopup.Created)
			{
				this.logoutPopup.Close();
				this.logoutPopup = null;
			}
			this.logoutPopup = InterfaceMgr.Instance.openLogoutWindow(true);
		}

		// Token: 0x06001847 RID: 6215 RVA: 0x0001916C File Offset: 0x0001736C
		public void newMail(bool newMail)
		{
			this.MenuButtonsPanel.newMail(newMail);
		}

		// Token: 0x06001848 RID: 6216 RVA: 0x0001917A File Offset: 0x0001737A
		public void setMailAlpha(double alpha)
		{
			this.MenuButtonsPanel.setMailAlpha(alpha);
		}

		// Token: 0x06001849 RID: 6217 RVA: 0x00019188 File Offset: 0x00017388
		public void setContestLeaderboardButtonVisible(bool visible)
		{
			this.MenuButtonsPanel.setContestLeaderboardButtonVisible(visible);
		}

		// Token: 0x0600184A RID: 6218 RVA: 0x00180D0C File Offset: 0x0017EF0C
		public void resize()
		{
			this.mainBackgroundImage.Size = new Size(this.Size.Width, 29);
			this.btnHelpMenu.Position = new Point(-140 + base.Width, 1);
			this.btnLogOut.Position = new Point(-72 + base.Width, 1);
			this.btnFileMenu.Position = new Point(-217 + base.Width, 1);
			this.btnMyAccount.Position = new Point(-297 + base.Width, 1);
			this.pnlLoadLight.Position = new Point(base.Width - 4, 0);
			this.MenuButtonsPanel.Position = new Point(-464 + base.Width, 0);
		}

		// Token: 0x0600184B RID: 6219 RVA: 0x00019196 File Offset: 0x00017396
		private void endOfTheWorldCallback(EndOfTheWorldStats_ReturnType returnData)
		{
			if (returnData.Success)
			{
				WorldsEndPanel.cachedData = returnData;
			}
		}

		// Token: 0x040028C0 RID: 10432
		private CustomSelfDrawPanel.CSDImage mainBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040028C1 RID: 10433
		private CustomSelfDrawPanel.CSDButton btnHelpMenu = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040028C2 RID: 10434
		private CustomSelfDrawPanel.CSDButton btnFileMenu = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040028C3 RID: 10435
		private CustomSelfDrawPanel.CSDButton btnAdminMenu = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040028C4 RID: 10436
		private CustomSelfDrawPanel.CSDButton btnCombat = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040028C5 RID: 10437
		private CustomSelfDrawPanel.CSDButton btnLogOut = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040028C6 RID: 10438
		private CustomSelfDrawPanel.CSDButton btnMyAccount = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040028C7 RID: 10439
		private CustomSelfDrawPanel.CSDFill pnlLoadLight = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x040028C8 RID: 10440
		private MenuMailPanel MenuButtonsPanel = new MenuMailPanel();

		// Token: 0x040028C9 RID: 10441
		private SaveFileDialog SaveCSVFileDialog;

		// Token: 0x040028CA RID: 10442
		private SaveFileDialog SavePNGFileDialog;

		// Token: 0x040028CB RID: 10443
		private static bool castleCopyMode;

		// Token: 0x040028CC RID: 10444
		private bool fixCommandSent;

		// Token: 0x040028CD RID: 10445
		private bool nextPlaybackCountries;

		// Token: 0x040028CE RID: 10446
		private LogoutOptionsWindow2 logoutPopup;
	}
}
