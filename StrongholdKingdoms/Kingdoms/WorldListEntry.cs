using System;
using System.Drawing;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020004FA RID: 1274
	public class WorldListEntry : CustomSelfDrawPanel.CSDControl
	{
		// Token: 0x17000273 RID: 627
		// (get) Token: 0x0600305D RID: 12381 RVA: 0x0002332B File Offset: 0x0002152B
		public WorldInfo Info
		{
			get
			{
				return this.m_Info;
			}
		}

		// Token: 0x0600305E RID: 12382 RVA: 0x0027DA9C File Offset: 0x0027BC9C
		public void Init(WorldInfo info, bool isDark, WorldSelectPopupPanel parentPanel)
		{
			DateTime t = new DateTime(2019, 7, 4, 15, 0, 0);
			base.Width = 80;
			base.Height = 24;
			this.m_Info = info;
			this.backGround.Image = (isDark ? GFXLibrary.lineitem_strip_02_dark : GFXLibrary.lineitem_strip_02_light);
			this.backGround.Colorise = (this.m_Info.Online ? global::ARGBColors.Green : global::ARGBColors.Red);
			this.backGround.setSizeToImage();
			base.addControl(this.backGround);
			this.imgWorldMap.Image = GFXLibrary.getLoginWorldMap(this.m_Info.MapCulture);
			this.imgWorldMap.setSizeToImage();
			this.imgWorldMap.X = 17;
			this.imgWorldMap.Y = 4;
			this.imgWorldMap.CustomTooltipID = this.GetMapTooltipID();
			this.backGround.addControl(this.imgWorldMap);
			this.imgWorldName.Image = WebStyleButtonImage.Generate(200, this.backGround.Image.Height + 10, ProfileLoginWindow.getWorldShortDesc(this.m_Info), this.WebTextFont, global::ARGBColors.Black, global::ARGBColors.Transparent, 0);
			this.imgWorldName.setSizeToImage();
			this.imgWorldName.Y = this.backGround.Image.Height / 2 - this.imgWorldName.Height / 2;
			this.imgWorldName.X = 50;
			this.backGround.addControl(this.imgWorldName);
			this.lblWorldFlag.X = this.imgWorldName.Rectangle.Right + 50;
			this.lblWorldFlag.Image = GFXLibrary.getLoginWorldFlag(this.m_Info.Supportculture);
			this.lblWorldFlag.Size = this.lblWorldFlag.Image.Size;
			this.lblWorldFlag.Y = 7;
			this.lblWorldFlag.CustomTooltipID = this.GetFlagTooltipID();
			this.lblWorldStatus.Width = 121;
			this.lblWorldStatus.Height = this.backGround.Image.Height;
			this.lblWorldStatus.Y = 0;
			this.lblWorldStatus.X = 529;
			this.lblWorldStatus.Font = FontManager.GetFont("Arial", 8f, FontStyle.Bold);
			if (this.m_Info.Online)
			{
				this.btnWorldAction.Width = base.Width;
				this.btnWorldAction.Height = base.Height;
				this.btnWorldAction.Y = 5;
				this.btnWorldAction.Tag = this.m_Info;
				this.btnWorldAction.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(parentPanel.btnWorldAction_Click), "WorldSelectPopupPanel_world_select");
				if (this.m_Info.Playing)
				{
					this.btnWorldAction.ImageNorm = parentPanel.PlayImage;
					this.btnWorldAction.ImageOver = parentPanel.PlayImageOver;
				}
				else if (this.m_Info.AvailableToJoin)
				{
					this.btnWorldAction.ImageNorm = parentPanel.JoinImage;
					this.btnWorldAction.ImageOver = parentPanel.JoinImageOver;
				}
				else
				{
					this.btnWorldAction.ImageNorm = parentPanel.ClosedImage;
					this.btnWorldAction.ImageOver = parentPanel.ClosedImage;
					this.btnWorldAction.setClickDelegate(null);
					this.btnWorldAction.Active = false;
				}
				this.btnWorldAction.Width = this.btnWorldAction.ImageNorm.Width;
				this.btnWorldAction.Height = this.btnWorldAction.ImageNorm.Height;
				this.btnWorldAction.X = 650 - this.btnWorldAction.Width;
				this.backGround.addControl(this.btnWorldAction);
				if (this.btnWorldAction.Active)
				{
					if (this.m_Info.KingdomsWorldID % 100 < 50)
					{
						this.btnWorldInfo.ImageNorm = GFXLibrary.help_normal;
						this.btnWorldInfo.ImageOver = GFXLibrary.help_over;
						this.btnWorldInfo.ImageClick = GFXLibrary.help_pushed;
					}
					else
					{
						this.btnWorldInfo.ImageNorm = GFXLibrary.help_gold_normal;
						this.btnWorldInfo.ImageOver = GFXLibrary.help_gold_over;
						this.btnWorldInfo.ImageClick = GFXLibrary.help_gold_pushed;
					}
					this.btnWorldInfo.Position = new Point(490, 8);
					this.btnWorldInfo.Data = this.m_Info.KingdomsWorldID;
					this.btnWorldInfo.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(parentPanel.infoOverlayOpenedClick));
					this.backGround.addControl(this.btnWorldInfo);
				}
				this.lblWorldStatus.CustomTooltipID = 4010;
			}
			else
			{
				if (this.m_Info.KingdomsWorldID == 2550 && DateTime.UtcNow > t)
				{
					this.lblWorldStatus.Text = SK.Text("WorldEnded", "This World has ended.");
					this.lblWorldStatus.Width = 300;
				}
				else
				{
					this.lblWorldStatus.Text = SK.Text("WORLD_Offline", "Offline");
					this.lblWorldStatus.Color = global::ARGBColors.Red;
				}
				this.lblWorldStatus.CustomTooltipID = 4009;
				this.lblWorldStatus.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.backGround.addControl(this.lblWorldStatus);
			}
			this.backGround.addControl(this.imgWorldMap);
		}

		// Token: 0x0600305F RID: 12383 RVA: 0x0027E02C File Offset: 0x0027C22C
		private int GetFlagTooltipID()
		{
			string supportculture = this.m_Info.Supportculture;
			if (supportculture != null)
			{
				uint num = PrivateImplementationDetails.ComputeStringHash(supportculture);
				if (num <= 1194886160U)
				{
					if (num <= 1162757945U)
					{
						if (num != 507104076U)
						{
							if (num != 1092248970U)
							{
								if (num != 1162757945U)
								{
									return 4041;
								}
								if (!(supportculture == "pl"))
								{
									return 4041;
								}
							}
							else
							{
								if (!(supportculture == "en"))
								{
									return 4041;
								}
								return 4001;
							}
						}
						else if (!(supportculture == "pl="))
						{
							return 4041;
						}
						return 4020;
					}
					if (num != 1164435231U)
					{
						if (num != 1176137065U)
						{
							if (num == 1194886160U)
							{
								if (supportculture == "it")
								{
									return 4027;
								}
							}
						}
						else if (supportculture == "es")
						{
							return 4016;
						}
					}
					else if (supportculture == "zh")
					{
						return 4046;
					}
				}
				else if (num <= 1213488160U)
				{
					if (num != 1195724803U)
					{
						if (num != 1209692303U)
						{
							if (num == 1213488160U)
							{
								if (supportculture == "ru")
								{
									return 4004;
								}
							}
						}
						else if (supportculture == "eu")
						{
							return 4031;
						}
					}
					else if (supportculture == "tr")
					{
						return 4023;
					}
				}
				else if (num != 1461901041U)
				{
					if (num != 1545391778U)
					{
						if (num == 1565420801U)
						{
							if (supportculture == "pt")
							{
								return 4035;
							}
						}
					}
					else if (supportculture == "de")
					{
						return 4002;
					}
				}
				else if (supportculture == "fr")
				{
					return 4003;
				}
			}
			return 4041;
		}

		// Token: 0x06003060 RID: 12384 RVA: 0x0027E21C File Offset: 0x0027C41C
		private int GetMapTooltipID()
		{
			string mapCulture = this.m_Info.MapCulture;
			if (mapCulture != null)
			{
				uint num = PrivateImplementationDetails.ComputeStringHash(mapCulture);
				if (num <= 1195724803U)
				{
					if (num <= 1164435231U)
					{
						if (num != 1092248970U)
						{
							if (num != 1162757945U)
							{
								if (num == 1164435231U)
								{
									if (mapCulture == "zh")
									{
										return 4047;
									}
								}
							}
							else if (mapCulture == "pl")
							{
								return 4021;
							}
						}
						else if (mapCulture == "en")
						{
							return 4005;
						}
					}
					else if (num <= 1178800089U)
					{
						if (num != 1176137065U)
						{
							if (num == 1178800089U)
							{
								if (mapCulture == "us")
								{
									return 4030;
								}
							}
						}
						else if (mapCulture == "es")
						{
							return 4017;
						}
					}
					else if (num != 1194886160U)
					{
						if (num == 1195724803U)
						{
							if (mapCulture == "tr")
							{
								return 4024;
							}
						}
					}
					else if (mapCulture == "it")
					{
						return 4028;
					}
				}
				else if (num <= 1229868421U)
				{
					if (num != 1209692303U)
					{
						if (num != 1213488160U)
						{
							if (num == 1229868421U)
							{
								if (mapCulture == "ph")
								{
									return 4043;
								}
							}
						}
						else if (mapCulture == "ru")
						{
							return 4008;
						}
					}
					else if (mapCulture == "eu")
					{
						return 4032;
					}
				}
				else if (num <= 1461901041U)
				{
					if (num != 1245513207U)
					{
						if (num == 1461901041U)
						{
							if (mapCulture == "fr")
							{
								return 4007;
							}
						}
					}
					else if (mapCulture == "kg")
					{
						return 4049;
					}
				}
				else if (num != 1545391778U)
				{
					if (num == 1565420801U)
					{
						if (mapCulture == "pt")
						{
							return 4036;
						}
					}
				}
				else if (mapCulture == "de")
				{
					return 4006;
				}
			}
			return 4042;
		}

		// Token: 0x04003CD7 RID: 15575
		private WorldInfo m_Info;

		// Token: 0x04003CD8 RID: 15576
		private Font WebTextFont = FontManager.GetPrivateFont("AssetIcons/Cards/panel/Brokenscript-Bold.ttf", 40f, FontStyle.Regular);

		// Token: 0x04003CD9 RID: 15577
		private CustomSelfDrawPanel.CSDImage lblWorldFlag = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003CDA RID: 15578
		private CustomSelfDrawPanel.CSDImage imgWorldMap = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003CDB RID: 15579
		private CustomSelfDrawPanel.CSDLabel lblWorldStatus = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003CDC RID: 15580
		private CustomSelfDrawPanel.CSDImage backGround = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003CDD RID: 15581
		private CustomSelfDrawPanel.CSDImage imgWorldName = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003CDE RID: 15582
		private CustomSelfDrawPanel.CSDImage secondAgeImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003CDF RID: 15583
		private CustomSelfDrawPanel.CSDButton btnWorldAction = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003CE0 RID: 15584
		private CustomSelfDrawPanel.CSDButton btnWorldInfo = new CustomSelfDrawPanel.CSDButton();
	}
}
