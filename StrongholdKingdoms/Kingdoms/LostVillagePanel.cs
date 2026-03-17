using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000218 RID: 536
	public class LostVillagePanel : CustomSelfDrawPanel
	{
		// Token: 0x06001688 RID: 5768 RVA: 0x001645D8 File Offset: 0x001627D8
		public LostVillagePanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06001689 RID: 5769 RVA: 0x00164680 File Offset: 0x00162880
		public void init(LostVillageWindow parent, int age, int cardsMode)
		{
			this.m_secondAgeMessage = age;
			this.m_parent = parent;
			this.m_cardsMode = cardsMode;
			base.clearControls();
			this.transparentBackground.Size = base.Size;
			this.transparentBackground.FillColor = Color.FromArgb(255, 0, 255);
			base.addControl(this.transparentBackground);
			if (age != 1000)
			{
				this.background.Position = new Point(0, 70);
				this.background.Size = new Size(base.Width, 446);
				base.addControl(this.background);
				this.background.Create(GFXLibrary._9sclice_fancy_top_left, GFXLibrary._9sclice_fancy_top_mid, GFXLibrary._9sclice_fancy_top_right, GFXLibrary._9sclice_fancy_mid_left, GFXLibrary._9sclice_fancy_mid_mid, GFXLibrary._9sclice_fancy_mid_right, GFXLibrary._9sclice_fancy_bottom_left, GFXLibrary._9sclice_fancy_bottom_mid, GFXLibrary._9sclice_fancy_bottom_right);
				this.background.ForceTiling();
				this.topImage.Image = GFXLibrary._9sclice_fancy_top_mid_over_01;
				this.topImage.Position = new Point((base.Width - this.topImage.Image.Width) / 2, 0);
				base.addControl(this.topImage);
				this.bottomImage.Image = GFXLibrary._9sclice_fancy_bottom_mid_over;
				this.bottomImage.Position = new Point((base.Width - this.bottomImage.Image.Width) / 2, base.Height - this.bottomImage.Image.Height - 5);
				base.addControl(this.bottomImage);
				this.backgroundArea.Position = new Point(171, 134);
				this.backgroundArea.Size = new Size(514, 340);
				base.addControl(this.backgroundArea);
			}
			else
			{
				this.backgroundImage.Position = new Point(0, 0);
				this.backgroundImage.Image = GFXLibrary.dominationEnd;
				base.addControl(this.backgroundImage);
				this.backgroundArea.Position = new Point(0, 0);
				this.backgroundArea.Size = this.backgroundImage.Size;
				base.addControl(this.backgroundArea);
			}
			this.btnLogout.ImageNorm = GFXLibrary.worldSelect_swap_norm;
			this.btnLogout.ImageOver = GFXLibrary.worldSelect_swap_over;
			this.btnLogout.ImageClick = GFXLibrary.worldSelect_swap_pushed;
			if (age != 1000)
			{
				this.btnLogout.Position = new Point(260 - this.btnLogout.ImageNorm.Width / 2, 327);
			}
			else
			{
				this.btnLogout.Position = new Point(base.Width / 2 - this.btnLogout.ImageNorm.Width / 2, 573);
			}
			this.btnLogout.Text.Text = SK.Text("GENERIC_Continue", "Continue");
			this.btnLogout.TextYOffset = -2;
			this.btnLogout.Text.Color = global::ARGBColors.White;
			this.btnLogout.Text.DropShadowColor = global::ARGBColors.Black;
			this.btnLogout.Text.Font = FontManager.GetFont("Arial", 11f, FontStyle.Regular);
			this.btnLogout.Text.Position = new Point(-3, 0);
			this.btnLogout.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.logoutClick));
			this.btnLogout.Enabled = true;
			this.backgroundArea.addControl(this.btnLogout);
			if (cardsMode < 0)
			{
				if (this.m_secondAgeMessage == 0)
				{
					this.headerLabel.Text = SK.Text("WorldSelect_Villages_Lost", "Your village was lost due to") + " :";
					this.headerLabel.Position = new Point(-50, 12);
					this.headerLabel.Size = new Size(this.backgroundArea.Width + 100, 150);
					this.headerLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
					this.headerLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
					this.headerLabel.Color = global::ARGBColors.Black;
					this.headerLabel.DropShadowColor = global::ARGBColors.LightGray;
					this.backgroundArea.addControl(this.headerLabel);
					if (GameEngine.Instance.World.lastAttacker.Length == 0)
					{
						this.lostMessageLabel.Text = SK.Text("WorldSelect_Inactivity", "Inactivity");
					}
					else if (GameEngine.Instance.World.lastAttacker == RemoteServices.Instance.UserName)
					{
						this.lostMessageLabel.Text = SK.Text("WorldSelect_Abandoning", "You Abandoned Your Village");
					}
					else
					{
						this.lostMessageLabel.Text = SK.Text("WorldSelect_Attacking_Player", "An Attacking Player") + " (" + GameEngine.Instance.World.lastAttacker + ")";
					}
					this.lostMessageLabel.Position = new Point(0, 47);
					this.lostMessageLabel.Size = new Size(this.backgroundArea.Width, 240);
					this.lostMessageLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
					this.lostMessageLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
					this.lostMessageLabel.Color = global::ARGBColors.Black;
					this.lostMessageLabel.DropShadowColor = global::ARGBColors.LightGray;
					this.backgroundArea.addControl(this.lostMessageLabel);
					this.wallOfText.Text = string.Concat(new string[]
					{
						SK.Text("WorldSelect_wall_of_text1", "Losing your village is all part of the game and this is only the beginning!"),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("WorldSelect_wall_of_text2", "There are no penalties for losing a village. You have the same amount of Gold, Honour and Faith Points as before and any unused Cards, Card Packs or Premium Tokens remain in your account. Quests, Research and Achievements are all unaffected and your Rank remains the same."),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("WorldSelect_wall_of_text3", "With all your resources and abilities intact all that remains is for you to rebuild and rise to fight again!")
					});
					this.wallOfText.Position = new Point(0, 64);
					this.wallOfText.Size = new Size(this.backgroundArea.Width, 260);
					this.wallOfText.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
					this.wallOfText.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.wallOfText.Color = global::ARGBColors.Black;
					this.wallOfText.DropShadowColor = global::ARGBColors.LightGray;
					this.backgroundArea.addControl(this.wallOfText);
					return;
				}
				if (this.m_secondAgeMessage == 2)
				{
					this.headerLabel.Position = new Point(-50, 12);
					this.headerLabel.Size = new Size(this.backgroundArea.Width + 100, 150);
					this.headerLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
					this.headerLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
					this.headerLabel.Color = global::ARGBColors.Black;
					this.headerLabel.DropShadowColor = global::ARGBColors.LightGray;
					this.backgroundArea.addControl(this.headerLabel);
					if (!GameEngine.Instance.LocalWorldData.EraWorld)
					{
						this.headerLabel.Text = SK.Text("WorldSelect_2ndAge_Header", "Welcome to the Second Age!");
						this.wallOfText.Text = string.Concat(new string[]
						{
							SK.Text("WorldSelect_2ndAge_body1", "A new rule set is now in effect:"),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("WorldSelect_2ndAge_body2", "1. Armies move across the world map at double speed."),
							Environment.NewLine,
							SK.Text("WorldSelect_2ndAge_body3", "2. Three times as much Glory is earned for holding territory."),
							Environment.NewLine,
							SK.Text("WorldSelect_2ndAge_body4", "3. Monks can influence voting at county level, with high voting costs and caps at county, province and country level."),
							Environment.NewLine,
							SK.Text("WorldSelect_2ndAge_body5", "4. Interdicting and excommunicating villages costs twice the usual amount."),
							Environment.NewLine,
							SK.Text("WorldSelect_2ndAge_body6", "5. At the end of the Second Age Glory Race players will be given unique treasures for their victory and a 'Champion Pack'."),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("WorldSelect_2ndAge_body7", "For more information on the Second Age please check your mail.")
						});
					}
					else
					{
						this.headerLabel.Text = SK.Text("WorldSelect_2ndEra_Header", "Welcome to the Second Era!");
						this.wallOfText.Text = string.Concat(new string[]
						{
							SK.Text("WorldSelect_Era_body1", "These changes are now in effect:"),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("WorldSelect_Era_body2", "1. Armies, scouts, and monks move at increased speed."),
							Environment.NewLine,
							SK.Text("WorldSelect_Era_body3", "2. Goods have been cleared from all Markets, with prices reset to their starting levels."),
							Environment.NewLine,
							SK.Text("WorldSelect_2ndEra_body4", "3. The Faith Point cost for Interdiction and Excommunication has increased."),
							Environment.NewLine,
							SK.Text("WorldSelect_2ndEra_body5", "4. Votes and officers in all capitals have been cleared and the Glory Race has restarted."),
							Environment.NewLine,
							SK.Text("WorldSelect_2ndEra_body6", "5. More Glory is earned for holding territory."),
							Environment.NewLine,
							SK.Text("WorldSelect_2ndEra_body7", "6. Monks can influence voting at the county level."),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("WorldSelect_2ndEra_body8", "For more detailed information on the Second Era please check the Wiki.")
						});
					}
					this.wallOfText.Position = new Point(0, 49);
					this.wallOfText.Size = new Size(this.backgroundArea.Width, 260);
					if (Program.mySettings.LanguageIdent == "fr" || Program.mySettings.LanguageIdent == "ru")
					{
						this.wallOfText.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
					}
					else
					{
						this.wallOfText.Font = FontManager.GetFont("Arial", 11f, FontStyle.Regular);
					}
					this.wallOfText.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
					this.wallOfText.Color = global::ARGBColors.Black;
					this.wallOfText.DropShadowColor = global::ARGBColors.LightGray;
					this.backgroundArea.addControl(this.wallOfText);
					CustomSelfDrawPanel.WikiLinkControl.init(this.backgroundArea, 45, new Point(513, -6));
					return;
				}
				if (this.m_secondAgeMessage == 3)
				{
					this.headerLabel.Position = new Point(-50, 12);
					this.headerLabel.Size = new Size(this.backgroundArea.Width + 100, 150);
					this.headerLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
					this.headerLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
					this.headerLabel.Color = global::ARGBColors.Black;
					this.headerLabel.DropShadowColor = global::ARGBColors.LightGray;
					this.backgroundArea.addControl(this.headerLabel);
					if (!GameEngine.Instance.LocalWorldData.EraWorld)
					{
						this.headerLabel.Text = SK.Text("WorldSelect_3rdAge_Header", "Welcome to the Third Age!");
						this.wallOfText.Text = string.Concat(new string[]
						{
							SK.Text("WorldSelect_2ndAge_body1", "A new rule set is now in effect:"),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("WorldSelect_3rdAge_body2", "1. Crown Princes may now access up to 30 villages"),
							Environment.NewLine,
							SK.Text("WorldSelect_3rdAge_body3", "2. Honour production has been increased by 900% for Banqueting and 300% for Popularity"),
							Environment.NewLine,
							SK.Text("WorldSelect_3rdAge_body4", "3. Goods have been cleared from all Markets, with prices reset to their starting levels"),
							Environment.NewLine,
							SK.Text("WorldSelect_3rdAge_body5", "4. All in-game Factions and Houses have been disbanded"),
							Environment.NewLine,
							SK.Text("WorldSelect_3rdAge_body6", "5. Certain upgradeable parish buildings can now gain additional levels"),
							Environment.NewLine,
							SK.Text("WorldSelect_3rdAge_body7", "6. The rate at which Glory is gained has been rebalanced"),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("WorldSelect_3rdAge_body8", "For more information on the Third Age please check your mail")
						});
					}
					else
					{
						this.headerLabel.Text = SK.Text("WorldSelect_3rdEra_Header", "Welcome to the Third Era!");
						this.wallOfText.Text = string.Concat(new string[]
						{
							SK.Text("WorldSelect_Era_body1", "These changes are now in effect:"),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("WorldSelect_Era_body2", "1. Armies, scouts, and monks move at increased speed."),
							Environment.NewLine,
							SK.Text("WorldSelect_Era_body3", "2. Goods have been cleared from all Markets, with prices reset to their starting levels."),
							Environment.NewLine,
							SK.Text("WorldSelect_3rdEra_body4", "3. The Faith Point cost for Interdiction and Excommunication has increased."),
							Environment.NewLine,
							SK.Text("WorldSelect_3rdEra_body5", "4. Votes and officers in all capitals have been cleared and the Glory Race has restarted."),
							Environment.NewLine,
							SK.Text("WorldSelect_3rdEra_body6", "5. More Glory is earned for holding territory."),
							Environment.NewLine,
							SK.Text("WorldSelect_3rdEra_body7", "6. Crown Princes may now access up to 30 villages."),
							Environment.NewLine,
							SK.Text("WorldSelect_3rdEra_body8", "7. Honour production has been increased for Banqueting and for Popularity."),
							Environment.NewLine,
							SK.Text("WorldSelect_3rdEra_body9", "8. Honor received from destroying hostile AI castles has been increased."),
							Environment.NewLine,
							SK.Text("WorldSelect_3rdEra_body10", "9. Certain upgradeable parish buildings can now gain additional levels."),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("WorldSelect_3rdEra_body11", "For more detailed information on the Third Era please check the Wiki.")
						});
					}
					this.wallOfText.Position = new Point(0, 49);
					this.wallOfText.Size = new Size(this.backgroundArea.Width, 260);
					if (!GameEngine.Instance.LocalWorldData.EraWorld || Program.mySettings.LanguageIdent == "en")
					{
						this.wallOfText.Font = FontManager.GetFont("Arial", 11f, FontStyle.Regular);
					}
					else
					{
						this.wallOfText.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
					}
					this.wallOfText.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
					this.wallOfText.Color = global::ARGBColors.Black;
					this.wallOfText.DropShadowColor = global::ARGBColors.LightGray;
					this.backgroundArea.addControl(this.wallOfText);
					CustomSelfDrawPanel.WikiLinkControl.init(this.backgroundArea, 46, new Point(513, -6));
					return;
				}
				if (this.m_secondAgeMessage == 4)
				{
					this.headerLabel.Position = new Point(-50, 12);
					this.headerLabel.Size = new Size(this.backgroundArea.Width + 100, 150);
					this.headerLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
					this.headerLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
					this.headerLabel.Color = global::ARGBColors.Black;
					this.headerLabel.DropShadowColor = global::ARGBColors.LightGray;
					this.backgroundArea.addControl(this.headerLabel);
					if (!GameEngine.Instance.LocalWorldData.EraWorld)
					{
						this.headerLabel.Text = SK.Text("WorldSelect_4thAge_Header", "Welcome to the Fourth Age!");
						this.wallOfText.Text = string.Concat(new string[]
						{
							SK.Text("WorldSelect_2ndAge_body1", "A new rule set is now in effect:"),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("WorldSelect_4thAge_body2", "1. Crown Princes may now own up to 40 villages."),
							Environment.NewLine,
							SK.Text("WorldSelect_4thAge_body3", "2. Army and Scout movement speeds are three times faster than in the First Age."),
							Environment.NewLine,
							SK.Text("WorldSelect_4thAge_body4", "3. Weapons can no longer be sold or purchased at Markets."),
							Environment.NewLine,
							SK.Text("WorldSelect_4thAge_body5", "4. Goods have been cleared from all Markets, with prices reset to their starting level."),
							Environment.NewLine,
							SK.Text("WorldSelect_4thAge_body6", "5. The Faith Point cost for Interdiction has been increased."),
							Environment.NewLine,
							SK.Text("WorldSelect_4thAge_body7", "6. A Military School can be built in a parish, which gives access to Bombards."),
							Environment.NewLine,
							SK.Text("WorldSelect_4thAge_body8", "7. Players who own more than 10 villages will no longer have to pay the extra honour cost to regain a village, if one of their villages is captured."),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("WorldSelect_4thAge_body9", "For more information on the Fourth Age please check your mail.")
						});
					}
					else
					{
						this.headerLabel.Text = SK.Text("WorldSelect_4thEra_Header", "Welcome to the Fourth Era!");
						this.wallOfText.Text = string.Concat(new string[]
						{
							SK.Text("WorldSelect_Era_body1", "These changes are now in effect:"),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("WorldSelect_Era_body2", "1. Armies, scouts, and monks move at increased speed."),
							Environment.NewLine,
							SK.Text("WorldSelect_Era_body3", "2. Goods have been cleared from all Markets, with prices reset to their starting levels."),
							Environment.NewLine,
							SK.Text("WorldSelect_4thEra_body4", "3. The Faith Point cost for Interdiction and Excommunication has increased."),
							Environment.NewLine,
							SK.Text("WorldSelect_4thEra_body5", "4. Votes and officers in all capitals have been cleared and the Glory Race has restarted."),
							Environment.NewLine,
							SK.Text("WorldSelect_4thEra_body6", "5. Crown Princes may now own up to 40 villages."),
							Environment.NewLine,
							SK.Text("WorldSelect_4thEra_body7", "6. A Military School can be built in a parish, which gives access to Bombards."),
							Environment.NewLine,
							SK.Text("WorldSelect_4thEra_body8", "7. Certain upgradable Parish buildings can now gain 5 additional levels."),
							Environment.NewLine,
							SK.Text("WorldSelect_4thEra_body9", "8. Players who own more than 10 villages will no longer have to pay the extra honour cost to regain a village, if one of their villages is lost."),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("WorldSelect_4thEra_body10", "For more detailed information on the Fourth Era please check the Wiki.")
						});
					}
					this.wallOfText.Position = new Point(0, 49);
					this.wallOfText.Size = new Size(this.backgroundArea.Width, 260);
					if (!GameEngine.Instance.LocalWorldData.EraWorld || Program.mySettings.LanguageIdent != "fr")
					{
						this.wallOfText.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
					}
					else
					{
						this.wallOfText.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
					}
					this.wallOfText.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
					this.wallOfText.Color = global::ARGBColors.Black;
					this.wallOfText.DropShadowColor = global::ARGBColors.LightGray;
					this.backgroundArea.addControl(this.wallOfText);
					CustomSelfDrawPanel.WikiLinkControl.init(this.backgroundArea, 48, new Point(513, -6));
					return;
				}
				if (this.m_secondAgeMessage == 5)
				{
					this.headerLabel.Position = new Point(-50, 12);
					this.headerLabel.Size = new Size(this.backgroundArea.Width + 100, 150);
					this.headerLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
					this.headerLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
					this.headerLabel.Color = global::ARGBColors.Black;
					this.headerLabel.DropShadowColor = global::ARGBColors.LightGray;
					this.backgroundArea.addControl(this.headerLabel);
					if (!GameEngine.Instance.LocalWorldData.EraWorld)
					{
						this.headerLabel.Text = SK.Text("WorldSelect_5thAge_Header", "Welcome to the Fifth Age!");
						this.wallOfText.Text = string.Concat(new string[]
						{
							SK.Text("WorldSelect_2ndAge_body1", "A new rule set is now in effect:"),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("FifthAge_Mail_03", "1. Military Schools can be upgraded to level 5."),
							Environment.NewLine,
							SK.Text("FifthAge_Mail_04", "2. Treasure Castles are twice as likely to appear."),
							Environment.NewLine,
							SK.Text("FifthAge_Mail_05", "3. All factions and houses have been disbanded."),
							Environment.NewLine,
							SK.Text("FifthAge_Mail_06", "4. All capital forums and walls have been cleared."),
							Environment.NewLine,
							SK.Text("FifthAge_Mail_07", "5. Only members of a House can be candidates for County elections."),
							Environment.NewLine,
							SK.Text("FifthAge_Mail_08", "6. To be eligible for the office of sheriff, a candidate must belong to a House which controls at least 30% of the parishes in the county."),
							Environment.NewLine,
							SK.Text("WorldSelect_5thAge_body8", "7. Large Houses gain Glory more slowly than small Houses."),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("WorldSelect_5thAge_body9", "For more information on the Fifth Age please check your mail.")
						});
					}
					else
					{
						this.headerLabel.Text = SK.Text("WorldSelect_5thEra_Header", "Welcome to the Fifth Era!");
						this.wallOfText.Text = string.Concat(new string[]
						{
							SK.Text("WorldSelect_Era_body1", "These changes are now in effect:"),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("WorldSelect_Era_body2", "1. Armies, scouts, and monks move at increased speed."),
							Environment.NewLine,
							SK.Text("WorldSelect_Era_body3", "2. Goods have been cleared from all Markets, with prices reset to their starting levels."),
							Environment.NewLine,
							SK.Text("WorldSelect_5thEra_body4", "3. The Faith Point cost for Interdiction and Excommunication has increased."),
							Environment.NewLine,
							SK.Text("WorldSelect_5thEra_body5", "4. Votes and officers in all capitals have been cleared and the Glory Race has restarted."),
							Environment.NewLine,
							SK.Text("WorldSelect_5thEra_body6", "5. Military Schools can be upgraded to level 5."),
							Environment.NewLine,
							SK.Text("WorldSelect_5thEra_body7", "6. Treasure Castles are twice as likely to appear."),
							Environment.NewLine,
							SK.Text("WorldSelect_5thEra_body8", "7. Only members of a House can be candidates for County elections."),
							Environment.NewLine,
							SK.Text("WorldSelect_5thEra_body9", "8. To be eligible for the office of sheriff, a candidate must belong to a House which controls at least 30% of the parishes in the county."),
							Environment.NewLine,
							SK.Text("WorldSelect_5thEra_body10", "9. Large Houses gain Glory more slowly than small Houses.  A House with 60 members will gain one-third the amount of Glory that would be normally gained."),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("WorldSelect_5thEra_body11", "For more detailed information on the Fifth Era please check the Wiki.")
						});
					}
					this.wallOfText.Position = new Point(0, 49);
					this.wallOfText.Size = new Size(this.backgroundArea.Width, 260);
					if (!GameEngine.Instance.LocalWorldData.EraWorld || Program.mySettings.LanguageIdent == "en")
					{
						this.wallOfText.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
					}
					else
					{
						this.wallOfText.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
					}
					this.wallOfText.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
					this.wallOfText.Color = global::ARGBColors.Black;
					this.wallOfText.DropShadowColor = global::ARGBColors.LightGray;
					this.backgroundArea.addControl(this.wallOfText);
					CustomSelfDrawPanel.WikiLinkControl.init(this.backgroundArea, 51, new Point(513, -6));
					return;
				}
				if (this.m_secondAgeMessage == 6)
				{
					this.headerLabel.Position = new Point(-50, 12);
					this.headerLabel.Size = new Size(this.backgroundArea.Width + 100, 150);
					this.headerLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
					this.headerLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
					this.headerLabel.Color = global::ARGBColors.Black;
					this.headerLabel.DropShadowColor = global::ARGBColors.LightGray;
					this.backgroundArea.addControl(this.headerLabel);
					if (!GameEngine.Instance.LocalWorldData.EraWorld)
					{
						this.headerLabel.Text = SK.Text("WorldSelect_6thAge_Header", "Welcome to the Sixth Age!");
						this.wallOfText.Text = string.Concat(new string[]
						{
							SK.Text("WorldSelect_6thAge_body1", "Please be aware of the following changes:"),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("SixthAge_Mail_03", "1. The cost to recruit troops in capitals has been halved."),
							Environment.NewLine,
							SK.Text("WorldSelect_6thAge_body", "2. The speed of armies and scouts is increased."),
							Environment.NewLine,
							SK.Text("SixthAge_Mail_05", "3. Monk movement speed has been doubled."),
							Environment.NewLine,
							SK.Text("SixthAge_Mail_06", "4. Weapons can now be found in stashes."),
							Environment.NewLine,
							SK.Text("SixthAge_Mail_07", "5. Weapons can once again be bought and sold at markets."),
							Environment.NewLine,
							SK.Text("SixthAge_Mail_08", "6. The maximum faction size is now 10 players."),
							Environment.NewLine,
							SK.Text("SixthAge_Mail_09", "7. 1 million Glory Points are required to win each Glory Round."),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("WorldSelect_6thAge_body10", "For more information on the Sixth Age please check your mail.")
						});
					}
					else
					{
						this.headerLabel.Text = SK.Text("WorldSelect_6thEra_Header", "Welcome to the Sixth Era!");
						this.wallOfText.Text = string.Concat(new string[]
						{
							SK.Text("WorldSelect_Era_body1", "These changes are now in effect:"),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("WorldSelect_Era_body2", "1. Armies, scouts, and monks move at increased speed."),
							Environment.NewLine,
							SK.Text("WorldSelect_Era_body3", "2. Goods have been cleared from all Markets, with prices reset to their starting levels."),
							Environment.NewLine,
							SK.Text("WorldSelect_6thEra_body4", "3. The Faith Point cost for Interdiction and Excommunication has increased."),
							Environment.NewLine,
							SK.Text("WorldSelect_6thEra_body5", "4. Votes and officers in all capitals have been cleared and the Glory Race has restarted."),
							Environment.NewLine,
							SK.Text("WorldSelect_6thEra_body6", "5. The cost to recruit troops in capitals has been halved."),
							Environment.NewLine,
							SK.Text("WorldSelect_6thEra_body7", "6. Weapons can now be found in stashes."),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("WorldSelect_6thEra_body8", "For more detailed information on the Sixth Era please check the Wiki.")
						});
					}
					this.wallOfText.Position = new Point(0, 49);
					this.wallOfText.Size = new Size(this.backgroundArea.Width, 260);
					this.wallOfText.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
					this.wallOfText.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
					this.wallOfText.Color = global::ARGBColors.Black;
					this.wallOfText.DropShadowColor = global::ARGBColors.LightGray;
					this.backgroundArea.addControl(this.wallOfText);
					CustomSelfDrawPanel.WikiLinkControl.init(this.backgroundArea, 52, new Point(513, -6));
					return;
				}
				if (this.m_secondAgeMessage == 7)
				{
					this.headerLabel.Position = new Point(-50, 12);
					this.headerLabel.Size = new Size(this.backgroundArea.Width + 100, 150);
					this.headerLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
					this.headerLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
					this.headerLabel.Color = global::ARGBColors.Black;
					this.headerLabel.DropShadowColor = global::ARGBColors.LightGray;
					this.backgroundArea.addControl(this.headerLabel);
					if (!GameEngine.Instance.LocalWorldData.EraWorld)
					{
						this.headerLabel.Text = SK.Text("WorldSelect_7thAge_Header", "Welcome to the Final Age!");
						this.wallOfText.Text = string.Concat(new string[]
						{
							SK.Text("WorldSelect_7thAge_body1", "A unique endgame rule set is now in effect:"),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("WorldSelect_7thAge_02", "1. The Final Age begins with 150 'Royal Towers' on the map."),
							Environment.NewLine,
							SK.Text("WorldSelect_7thAge_03", "2. 'The Button' can be pressed by the Marshall of the House that controls all towers."),
							Environment.NewLine,
							SK.Text("WorldSelect_7thAge_04", "3. Pressing 'The Button' ends the world, determining which players claim each reward tier!"),
							Environment.NewLine,
							SK.Text("WorldSelect_7thAge_05", "4. The Glory Race has no end and Houses are no longer eliminated."),
							Environment.NewLine,
							SK.Text("WorldSelect_7thAge_07", "5. After each Glory Round towers respawn and tower control is reset."),
							Environment.NewLine,
							SK.Text("WorldSelect_7thAge_08", "6. Each Round brings the number of towers down by 10, with a minimum of 20."),
							Environment.NewLine,
							SK.Text("WorldSelect_7thAge_09", "7. A new 'Royal Towers' tab has been added to the Glory screen."),
							Environment.NewLine,
							SK.Text("WorldSelect_7thAge_10", "8. Capital guilds can now be upgraded an additional five levels."),
							Environment.NewLine,
							SK.Text("WorldSelect_7thAge_body8", "9. No new players may join this game world."),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("WorldSelect_7thAge_body9", "For more information on the Final Age of Stronghold Kingdoms please check your mail.")
						});
					}
					else
					{
						this.headerLabel.Text = SK.Text("WorldSelect_FinalEra_Header", "Welcome to the Final Era!");
						this.wallOfText.Text = string.Concat(new string[]
						{
							SK.Text("WorldSelect_Era_body1", "These changes are now in effect:"),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("WorldSelect_Era_body2", "1. Armies, scouts, and monks move at increased speed."),
							Environment.NewLine,
							SK.Text("WorldSelect_Era_body3", "2. Goods have been cleared from all Markets, with prices reset to their starting levels."),
							Environment.NewLine,
							SK.Text("WorldSelect_FinalEra_body4", "3. The Faith Point cost for Interdiction and Excommunication has increased."),
							Environment.NewLine,
							SK.Text("WorldSelect_FinalEra_body5", "4. Votes and officers in all capitals have been cleared and the Glory Race has restarted."),
							Environment.NewLine,
							SK.Text("WorldSelect_FinalEra_body6", "5. Capital guilds can now be upgraded an additional five levels."),
							Environment.NewLine,
							SK.Text("WorldSelect_FinalEra_body7", "6. No new players may join this game world. Only those who previously had a village on this world may enter it."),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("WorldSelect_FinalEra_body8", "For more detailed information on the Final Era of Stronghold Kingdoms and the Royal Tower Mechanics please check your mail and visit the Wiki.")
						});
					}
					this.wallOfText.Position = new Point(0, 49);
					this.wallOfText.Size = new Size(this.backgroundArea.Width, 260);
					this.wallOfText.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
					this.wallOfText.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
					this.wallOfText.Color = global::ARGBColors.Black;
					this.wallOfText.DropShadowColor = global::ARGBColors.LightGray;
					this.backgroundArea.addControl(this.wallOfText);
					CustomSelfDrawPanel.WikiLinkControl.init(this.backgroundArea, 53, new Point(513, -6));
					return;
				}
				if (this.m_secondAgeMessage == 8)
				{
					this.headerLabel.Text = SK.Text("WorldSelect_WORLD_ENDED_Header", "This World has now Ended!");
					this.headerLabel.Position = new Point(-50, 12);
					this.headerLabel.Size = new Size(this.backgroundArea.Width + 100, 150);
					this.headerLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
					this.headerLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
					this.headerLabel.Color = global::ARGBColors.Black;
					this.headerLabel.DropShadowColor = global::ARGBColors.LightGray;
					this.backgroundArea.addControl(this.headerLabel);
					this.wallOfText.Text = string.Concat(new string[]
					{
						SKX.Text("World_Ended_message1", "Blah"),
						Environment.NewLine,
						Environment.NewLine,
						SKX.Text("World_Ended_message2", "1. "),
						Environment.NewLine,
						SKX.Text("World_Ended_message3", "2. "),
						Environment.NewLine,
						SKX.Text("World_Ended_message4", "3. "),
						Environment.NewLine,
						SKX.Text("World_Ended_message5", "4. "),
						Environment.NewLine,
						SKX.Text("World_Ended_message6", "5. "),
						Environment.NewLine,
						SKX.Text("World_Ended_message7", "6. "),
						Environment.NewLine,
						SKX.Text("World_Ended_message8", "7. ")
					});
					this.wallOfText.Position = new Point(0, 49);
					this.wallOfText.Size = new Size(this.backgroundArea.Width, 260);
					this.wallOfText.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
					this.wallOfText.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
					this.wallOfText.Color = global::ARGBColors.Black;
					this.wallOfText.DropShadowColor = global::ARGBColors.LightGray;
					this.backgroundArea.addControl(this.wallOfText);
					return;
				}
				if (this.m_secondAgeMessage == 10)
				{
					this.headerLabel.Text = SK.Text("WorldSelect_Dom_Heading1", "Welcome to Domination World!");
					this.headerLabel.Position = new Point(-50, 0);
					this.headerLabel.Size = new Size(this.backgroundArea.Width + 100, 150);
					this.headerLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
					this.headerLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
					this.headerLabel.Color = global::ARGBColors.Black;
					this.headerLabel.DropShadowColor = global::ARGBColors.LightGray;
					this.backgroundArea.addControl(this.headerLabel);
					this.wallOfText.Text = string.Concat(new string[]
					{
						SK.Text("WorldSelect_Dom_body2", "New gameplay rules are in effect"),
						":",
						Environment.NewLine,
						Environment.NewLine,
						"1. ",
						SK.Text("WorldSelect_Dom_body3", "Interdiction cannot be used."),
						Environment.NewLine,
						"2. ",
						SK.Text("WorldSelect_Dom_body4", "Build speeds quadrupled for buildings and castles in villages and capitals."),
						Environment.NewLine,
						"3. ",
						SK.Text("WorldSelect_Dom_body5", "Research times reduced by half."),
						Environment.NewLine,
						"4. ",
						SK.Text("WorldSelect_Dom_body6", "Time limit of 91 days, after which the world ends."),
						Environment.NewLine,
						"5. ",
						SK.Text("WorldSelect_Dom_body7", "No Glory Rounds or Ages. The House with the most Glory when the world ends wins."),
						Environment.NewLine,
						SK.Text("WorldSelect_Dom_body11", "For more information on Domination World please check your mail.")
					});
					this.wallOfText.Position = new Point(0, 32);
					this.wallOfText.Size = new Size(this.backgroundArea.Width, 285);
					if (Program.mySettings.LanguageIdent == "de" || Program.mySettings.LanguageIdent == "ru")
					{
						this.wallOfText.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
					}
					else
					{
						this.wallOfText.Font = FontManager.GetFont("Arial", 11f, FontStyle.Regular);
					}
					this.wallOfText.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
					this.wallOfText.Color = global::ARGBColors.Black;
					this.wallOfText.DropShadowColor = global::ARGBColors.LightGray;
					this.backgroundArea.addControl(this.wallOfText);
					CustomSelfDrawPanel.WikiLinkControl.init(this.backgroundArea, 47, new Point(513, -6));
					return;
				}
				if (this.m_secondAgeMessage == 1000)
				{
					this.headerLabel.Text = SK.Text("PT_TUT_header1", "Congratulations!");
					this.headerLabel.Position = new Point(0, 25);
					this.headerLabel.Size = new Size(this.backgroundArea.Width, 150);
					this.headerLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
					this.headerLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
					this.headerLabel.DropShadowColor = global::ARGBColors.Black;
					this.headerLabel.Color = global::ARGBColors.LightGray;
					this.backgroundArea.addControl(this.headerLabel);
					this.wallOfText.Text = SK.Text("DOMINATION_END_MESSAGE", "Goodness my lord! The end of days is now upon us! My how you've grown from that stumbling bumpkin I tutored long ago! It seems that the final reckoning has come and that this world is at its end!  Will your name also be recorded amongst the storied warriors in the Hall of Legends to be remembered for all eternity? This world has been a true test of your mettle and you are to be congratulated for having achieved so much here!");
					this.wallOfText.Position = new Point(112, 250);
					this.wallOfText.Size = new Size(this.backgroundArea.Width - 224, 300);
					this.wallOfText.Font = FontManager.GetFont("Arial", 11f, FontStyle.Regular);
					this.wallOfText.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
					this.wallOfText.DropShadowColor = global::ARGBColors.Black;
					this.wallOfText.Color = global::ARGBColors.LightGray;
					this.backgroundArea.addControl(this.wallOfText);
					this.btnLogout.Text.Text = SK.Text("LogoutPanel_Swap_Worlds", "Swap Worlds");
					this.btnHallOfLegends.ImageNorm = GFXLibrary.HOLlink;
					this.btnHallOfLegends.OverBrighten = true;
					this.btnHallOfLegends.MoveOnClick = true;
					this.btnHallOfLegends.Position = new Point(base.Width / 2 - this.btnHallOfLegends.ImageNorm.Width / 2, 483);
					this.btnHallOfLegends.Text.Text = SK.Text("HALL_OF_LEGENDS", "Hall of Legends");
					this.btnHallOfLegends.TextYOffset = -2;
					this.btnHallOfLegends.Text.Color = global::ARGBColors.White;
					this.btnHallOfLegends.Text.DropShadowColor = global::ARGBColors.Black;
					this.btnHallOfLegends.Text.Font = FontManager.GetFont("Arial", 11f, FontStyle.Regular);
					this.btnHallOfLegends.Text.Position = new Point(-3, 0);
					this.btnHallOfLegends.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.hallOfLegendsClick));
					this.btnHallOfLegends.Enabled = true;
					this.backgroundArea.addControl(this.btnHallOfLegends);
					return;
				}
			}
			else
			{
				if (cardsMode == 0)
				{
					this.headerLabel.Text = SK.Text("CARD_OFFERS_Super_Random_Pack", "Super Random Pack");
				}
				else
				{
					this.headerLabel.Text = SK.Text("CARD_OFFERS_Ultimate_Random_Pack", "Ultimate Random Pack");
				}
				this.headerLabel.Position = new Point(-50, 12);
				this.headerLabel.Size = new Size(this.backgroundArea.Width + 100, 150);
				this.headerLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
				this.headerLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
				this.headerLabel.Color = global::ARGBColors.Black;
				this.headerLabel.DropShadowColor = global::ARGBColors.LightGray;
				this.backgroundArea.addControl(this.headerLabel);
				if (cardsMode == 0)
				{
					this.lostMessageLabel.Text = SK.Text("Cards_Super_Explanation", "Super random packs generally contain less silver ranked cards and give you a much greater chance of rare diamond and double diamond cards.");
				}
				else
				{
					this.lostMessageLabel.Text = SK.Text("Cards_Ultimate_Explanation", "Ultimate random packs generally contain far less silver ranked cards and give you a much greater chance of super rare triple diamond and Sapphire cards.");
				}
				this.lostMessageLabel.Position = new Point(0, 47);
				this.lostMessageLabel.Size = new Size(this.backgroundArea.Width, 240);
				this.lostMessageLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
				this.lostMessageLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
				this.lostMessageLabel.Color = global::ARGBColors.Black;
				this.lostMessageLabel.DropShadowColor = global::ARGBColors.LightGray;
				this.backgroundArea.addControl(this.lostMessageLabel);
				this.wallOfText.Text = SK.Text("Cards_NewPacks", "While one can expect better cards across all ranks, some of the cards in this pack may be suitable only for higher ranked players.");
				this.wallOfText.Position = new Point(25, 250);
				this.wallOfText.Size = new Size(this.backgroundArea.Width - 50, 60);
				this.wallOfText.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
				this.wallOfText.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_CENTER;
				this.wallOfText.Color = global::ARGBColors.Black;
				this.wallOfText.DropShadowColor = global::ARGBColors.LightGray;
				this.backgroundArea.addControl(this.wallOfText);
				CustomSelfDrawPanel.CSDImage csdimage = new CustomSelfDrawPanel.CSDImage();
				if (cardsMode == 0)
				{
					csdimage.Image = GFXLibrary.SuperFan;
				}
				else
				{
					csdimage.Image = GFXLibrary.UltimateFan;
				}
				csdimage.Position = new Point(120, 105);
				this.backgroundArea.addControl(csdimage);
			}
		}

		// Token: 0x0600168A RID: 5770 RVA: 0x00166EA4 File Offset: 0x001650A4
		private void logoutClick()
		{
			GameEngine.Instance.playInterfaceSound("AutoSelectVillageAreaPopup_logout");
			this.m_parent.closing = true;
			GameEngine.Instance.closeNoVillagePopup(false);
			if (this.m_secondAgeMessage == 0 && this.m_cardsMode < 0)
			{
				GameEngine.Instance.openSimpleSelectVillage();
			}
		}

		// Token: 0x0600168B RID: 5771 RVA: 0x00166EF4 File Offset: 0x001650F4
		private void hallOfLegendsClick()
		{
			string languageIdent = Program.mySettings.LanguageIdent;
			string fileName;
			if (languageIdent != null)
			{
				uint num = PrivateImplementationDetails.ComputeStringHash(languageIdent);
				if (num <= 1195724803U)
				{
					if (num <= 1176137065U)
					{
						if (num != 1162757945U)
						{
							if (num == 1176137065U)
							{
								if (languageIdent == "es")
								{
									fileName = "https://es.strongholdkingdoms.com/glory/HoH.php?worldid=2550&age=1";
									goto IL_15D;
								}
							}
						}
						else if (languageIdent == "pl")
						{
							fileName = "https://pl.strongholdkingdoms.com/glory/HoH.php?worldid=2550&age=1";
							goto IL_15D;
						}
					}
					else if (num != 1194886160U)
					{
						if (num == 1195724803U)
						{
							if (languageIdent == "tr")
							{
								fileName = "https://tr.strongholdkingdoms.com/glory/HoH.php?worldid=2550&age=1";
								goto IL_15D;
							}
						}
					}
					else if (languageIdent == "it")
					{
						fileName = "https://it.strongholdkingdoms.com/glory/HoH.php?worldid=2550&age=1";
						goto IL_15D;
					}
				}
				else if (num <= 1461901041U)
				{
					if (num != 1213488160U)
					{
						if (num == 1461901041U)
						{
							if (languageIdent == "fr")
							{
								fileName = "https://fr.strongholdkingdoms.com/glory/HoH.php?worldid=2550&age=1";
								goto IL_15D;
							}
						}
					}
					else if (languageIdent == "ru")
					{
						fileName = "https://ru.strongholdkingdoms.com/glory/HoH.php?worldid=2550&age=1";
						goto IL_15D;
					}
				}
				else if (num != 1545391778U)
				{
					if (num == 1565420801U)
					{
						if (languageIdent == "pt")
						{
							fileName = "https://pt.strongholdkingdoms.com/glory/HoH.php?worldid=2550&age=1";
							goto IL_15D;
						}
					}
				}
				else if (languageIdent == "de")
				{
					fileName = "https://de.strongholdkingdoms.com/glory/HoH.php?worldid=2550&age=1";
					goto IL_15D;
				}
			}
			fileName = "https://www.strongholdkingdoms.com/glory/HoH.php?worldid=2550&age=1";
			IL_15D:
			new Process
			{
				StartInfo = 
				{
					FileName = fileName
				}
			}.Start();
		}

		// Token: 0x0600168C RID: 5772 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void closePopup()
		{
		}

		// Token: 0x0600168D RID: 5773 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void update()
		{
		}

		// Token: 0x0600168E RID: 5774 RVA: 0x00017D5E File Offset: 0x00015F5E
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600168F RID: 5775 RVA: 0x00167078 File Offset: 0x00165278
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.None;
			base.Name = "LostVillagePanel";
			base.Size = new Size(600, 55);
			base.ResumeLayout(false);
		}

		// Token: 0x040026D8 RID: 9944
		private CustomSelfDrawPanel.CSDExtendingPanel background = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x040026D9 RID: 9945
		private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040026DA RID: 9946
		private CustomSelfDrawPanel.CSDArea backgroundArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040026DB RID: 9947
		private CustomSelfDrawPanel.CSDFill transparentBackground = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x040026DC RID: 9948
		private CustomSelfDrawPanel.CSDImage topImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040026DD RID: 9949
		private CustomSelfDrawPanel.CSDImage bottomImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040026DE RID: 9950
		private CustomSelfDrawPanel.CSDButton btnLogout = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040026DF RID: 9951
		private CustomSelfDrawPanel.CSDButton btnHallOfLegends = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040026E0 RID: 9952
		private CustomSelfDrawPanel.CSDLabel headerLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040026E1 RID: 9953
		private CustomSelfDrawPanel.CSDLabel lostMessageLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040026E2 RID: 9954
		private CustomSelfDrawPanel.CSDLabel wallOfText = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040026E3 RID: 9955
		private LostVillageWindow m_parent;

		// Token: 0x040026E4 RID: 9956
		private int m_secondAgeMessage;

		// Token: 0x040026E5 RID: 9957
		private int m_cardsMode = -1;

		// Token: 0x040026E6 RID: 9958
		private IContainer components;
	}
}
