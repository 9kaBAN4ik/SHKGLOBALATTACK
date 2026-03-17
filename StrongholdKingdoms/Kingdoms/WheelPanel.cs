using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using Upgrade;

namespace Kingdoms
{
	// Token: 0x020004F5 RID: 1269
	public class WheelPanel : CustomSelfDrawPanel
	{
		// Token: 0x06003034 RID: 12340 RVA: 0x00023111 File Offset: 0x00021311
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06003035 RID: 12341 RVA: 0x00023130 File Offset: 0x00021330
		private void InitializeComponent()
		{
			this.components = new Container();
			base.AutoScaleMode = AutoScaleMode.None;
		}

		// Token: 0x06003036 RID: 12342 RVA: 0x0027953C File Offset: 0x0027773C
		public WheelPanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06003037 RID: 12343 RVA: 0x00279684 File Offset: 0x00277884
		public void init(bool initialCall, int wheelType)
		{
			this.m_wheelType = wheelType;
			WheelPanel.Instance = this;
			base.clearControls();
			if (!this.rewardImagesCreated)
			{
				this.rewardImagesCreated = true;
				for (int i = 0; i < 20; i++)
				{
					this.rewardImages[i] = new WheelPanel.RewardImage();
				}
			}
			this.mainBackgroundImage.Image = GFXLibrary.dummy;
			this.mainBackgroundImage.Position = new Point(0, 0);
			this.mainBackgroundImage.Size = base.Size;
			this.mainBackgroundImage.Tile = true;
			base.addControl(this.mainBackgroundImage);
			this.MainPanel.Size = base.Size;
			this.MainPanel.Position = new Point(0, 0);
			this.mainBackgroundImage.addControl(this.MainPanel);
			this.MainPanel.Create(GFXLibrary.cardpanel_panel_back_top_left, GFXLibrary.cardpanel_panel_back_top_mid, GFXLibrary.cardpanel_panel_back_top_right, GFXLibrary.cardpanel_panel_back_mid_left, GFXLibrary.cardpanel_panel_back_mid_mid, GFXLibrary.cardpanel_panel_back_mid_right, GFXLibrary.cardpanel_panel_back_bottom_left, GFXLibrary.cardpanel_panel_back_bottom_mid, GFXLibrary.cardpanel_panel_back_bottom_right);
			CustomSelfDrawPanel.CSDImage csdimage = new CustomSelfDrawPanel.CSDImage();
			csdimage.Image = GFXLibrary.cardpanel_panel_gradient_top_left;
			csdimage.Size = GFXLibrary.cardpanel_panel_gradient_top_left.Size;
			csdimage.Position = new Point(0, 0);
			this.MainPanel.addControl(csdimage);
			CustomSelfDrawPanel.CSDImage csdimage2 = new CustomSelfDrawPanel.CSDImage();
			csdimage2.Image = GFXLibrary.cardpanel_panel_gradient_bottom_right;
			csdimage2.Size = GFXLibrary.cardpanel_panel_gradient_bottom_right.Size;
			csdimage2.Position = new Point(this.MainPanel.Width - csdimage2.Width - 6, this.MainPanel.Height - csdimage2.Height - 6);
			this.MainPanel.addControl(csdimage2);
			this.closeImage.Image = GFXLibrary.cardpanel_button_close_normal;
			this.closeImage.Size = this.closeImage.Image.Size;
			this.closeImage.setMouseOverDelegate(delegate
			{
				this.closeImage.Image = GFXLibrary.cardpanel_button_close_over;
			}, delegate
			{
				this.closeImage.Image = GFXLibrary.cardpanel_button_close_normal;
			});
			this.closeImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "Cards_Close");
			this.closeImage.Position = new Point(base.Width - 14 - 17, 10);
			this.closeImage.CustomTooltipID = 10100;
			this.mainBackgroundImage.addControl(this.closeImage);
			CustomSelfDrawPanel.WikiLinkControl.init(this.mainBackgroundImage, 32, new Point(base.Width - 40 - 40, 2));
			CustomSelfDrawPanel.CSDFill csdfill = new CustomSelfDrawPanel.CSDFill();
			csdfill.FillColor = Color.FromArgb(255, 130, 129, 126);
			csdfill.Size = new Size(base.Width - 10, 1);
			csdfill.Position = new Point(5, 34);
			this.mainBackgroundImage.addControl(csdfill);
			this.labelTitle.Position = new Point(27, 5);
			this.labelTitle.Size = new Size(600, 64);
			switch (this.m_wheelType)
			{
			case -1:
				this.labelTitle.Text = SK.Text("WheelPanel_Royal_Wheel", "Quest Wheel");
				break;
			case 0:
				this.labelTitle.Text = SK.Text("WheelPanel_Treasure_Wheel_1", "Treasure Wheel Tier 1");
				break;
			case 1:
				this.labelTitle.Text = SK.Text("WheelPanel_Treasure_Wheel_2", "Treasure Wheel Tier 2");
				break;
			case 2:
				this.labelTitle.Text = SK.Text("WheelPanel_Treasure_Wheel_3", "Treasure Wheel Tier 3");
				break;
			case 3:
				this.labelTitle.Text = SK.Text("WheelPanel_Treasure_Wheel_4", "Treasure Wheel Tier 4");
				break;
			case 4:
				this.labelTitle.Text = SK.Text("WheelPanel_Treasure_Wheel_5", "Treasure Wheel Tier 5");
				break;
			}
			this.labelTitle.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.labelTitle.Font = FontManager.GetFont("Arial", 18f, FontStyle.Bold);
			this.labelTitle.Color = global::ARGBColors.Black;
			this.mainBackgroundImage.addControl(this.labelTitle);
			if (this.m_wheelType == -1)
			{
				if (Program.mySettings.LanguageIdent == "it")
				{
					this.labelTitle2.Position = new Point(300, 10);
				}
				else
				{
					this.labelTitle2.Position = new Point(250, 10);
				}
				this.labelTitle2.Size = new Size(600, 64);
				this.labelTitle2.Text = string.Concat(new string[]
				{
					"(",
					SK.Text("WheelPanel_Level", "Level"),
					" ",
					(Wheel.getWheelLevel(GameEngine.Instance.World.getRank()) + 1).ToString(),
					")"
				});
				this.labelTitle2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.labelTitle2.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
				this.labelTitle2.Color = global::ARGBColors.Black;
				this.mainBackgroundImage.addControl(this.labelTitle2);
			}
			this.wheelImage.Image = GFXLibrary.wheel_wheel_royal;
			this.wheelImage.Position = new Point(3, 35);
			this.mainBackgroundImage.addControl(this.wheelImage);
			this.numTicketsLabel.Position = new Point(725, 42);
			this.numTicketsLabel.Size = new Size(600, 54);
			this.numTicketsLabel.Text = SK.Text("WheelPanel_Spins", "Spins") + ": " + GameEngine.Instance.World.getTickets(this.m_wheelType).ToString();
			this.numTicketsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.numTicketsLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Bold);
			this.numTicketsLabel.Color = global::ARGBColors.Black;
			this.wheelImage.addControl(this.numTicketsLabel);
			this.starImage.Image = GFXLibrary.wheel_star[0];
			this.starImage.Position = new Point(557, 47);
			this.starImage.RotateCentre = new PointF(128f, 128f);
			this.starImage.Visible = false;
			this.starSpinMode = 0;
			this.wheelImage.addControl(this.starImage);
			if (this.royal)
			{
				this.pegImage.Image = GFXLibrary.wheel_icons[12];
			}
			else
			{
				this.pegImage.Image = GFXLibrary.wheel_icons[13];
			}
			this.pegImage.Position = new Point(622, 115);
			this.pegImage.Visible = true;
			this.wheelImage.addControl(this.pegImage);
			this.rewardDescription.Position = new Point(733, 138);
			this.rewardDescription.Size = new Size(155, 80);
			this.rewardDescription.Text = "";
			this.rewardDescription.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.rewardDescription.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.rewardDescription.Color = global::ARGBColors.Black;
			this.wheelImage.addControl(this.rewardDescription);
			this.wheelLayer1.Position = new Point(0, 0);
			this.wheelLayer1.Size = this.wheelImage.Size;
			this.wheelImage.addControl(this.wheelLayer1);
			this.wheelLayer2.Position = new Point(0, 0);
			this.wheelLayer2.Size = this.wheelImage.Size;
			this.wheelImage.addControl(this.wheelLayer2);
			this.wheelLayer3.Position = new Point(0, 0);
			this.wheelLayer3.Size = this.wheelImage.Size;
			this.wheelImage.addControl(this.wheelLayer3);
			this.spinGlow.Image = GFXLibrary.wheel_icons[0];
			this.spinGlow.Position = new Point(517, 423);
			this.wheelImage.addControl(this.spinGlow);
			this.spinButton.ImageNorm = GFXLibrary.wheel_spinButton_royal[0];
			this.spinButton.ImageOver = GFXLibrary.wheel_spinButton_royal[1];
			this.spinButton.MoveOnClick = false;
			this.spinButton.Position = new Point(514, 442);
			this.spinButton.Text.Text = SK.Text("Wheel_Spin", "Spin");
			this.spinButton.TextYOffset = 32;
			this.spinButton.Text.Color = global::ARGBColors.Black;
			this.spinButton.Text.DropShadowColor = Color.FromArgb(160, 160, 160);
			this.spinButton.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.spinButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.spinCard));
			this.wheelImage.addControl(this.spinButton);
			int num = 5;
			this.pointerShadowImage.Image = GFXLibrary.wheel_arrowBlurShadow[0];
			this.pointerShadowImage.Position = new Point(215 + num, 108 + num);
			this.pointerShadowImage.RotateCentre = new PointF(76.5f, 172.5f);
			this.pointerShadowImage.Alpha = 0.5f;
			this.wheelImage.addControl(this.pointerShadowImage);
			this.pointerImage.Image = GFXLibrary.wheel_arrowBlur_royal[0];
			this.pointerImage.RotateCentre = new PointF(76.5f, 172.5f);
			this.pointerImage.Position = new Point(-num, -num);
			this.pointerShadowImage.addControl(this.pointerImage);
			this.centreRewardImage.init(null, new Point(293, 283));
			this.wheelImage.addControl(this.centreRewardImage);
			this.prizeRewardImage.init(null, new Point(690, 183));
			this.wheelImage.addControl(this.prizeRewardImage);
			this.rewards = Wheel.getRewardWheel(GameEngine.Instance.World.getRank(), this.m_wheelType, GameEngine.Instance.LocalWorldData.AIWorld, GameEngine.Instance.LocalWorldData.EUAIWorld);
			if (this.rewards.Count == 20)
			{
				Random random = new Random();
				for (int j = 0; j < 20; j++)
				{
					int index = random.Next(20);
					WheelReward value = this.rewards[j];
					this.rewards[j] = this.rewards[index];
					this.rewards[index] = value;
				}
				for (int k = 0; k < 20; k++)
				{
					Point point = this.rotatePoint(new Point(0, 230), (float)(k * 18 + 9));
					this.rewardImages[k].init(this.rewards[k], new Point(293 + point.X, 283 - point.Y), this.wheelLayer1, this.wheelLayer2, this.wheelLayer3);
					this.wheelImage.addControl(this.rewardImages[k]);
				}
			}
			if (GameEngine.Instance.World.getTickets(this.m_wheelType) > 0)
			{
				this.helpLabel.Text = SK.Text("WheelPanel_spin_help", "Spin the wheel to win a prize");
			}
			else
			{
				this.helpLabel.Text = SK.Text("WheelPanel_nospin_help", "You have no spins available");
			}
			this.helpLabel.Position = new Point(686, 260);
			this.helpLabel.Size = new Size(199, 180);
			this.helpLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.helpLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.helpLabel.Color = global::ARGBColors.Black;
			this.wheelImage.addControl(this.helpLabel);
			this.pointerRotate = 0f;
			this.pointerRotateSpeed = 0f;
			this.spinMode = -2;
			this.lastRotate = -1000f;
			this.updateSpinButton();
			base.Invalidate();
			this.update();
		}

		// Token: 0x06003038 RID: 12344 RVA: 0x0027A378 File Offset: 0x00278578
		public void update()
		{
			float num = 1f;
			for (int i = 0; i < 20; i++)
			{
				this.rewardImages[i].update();
			}
			if (this.pointerRotateSpeed != 0f || this.lastRotate != this.pointerRotate)
			{
				float num2 = this.pointerRotate;
				if (num2 >= 179.9f && num2 <= 180f)
				{
					num2 = 179.9f;
				}
				else if (num2 > 180f && num2 <= 180.1f)
				{
					num2 = 180.1f;
				}
				this.pointerShadowImage.Rotate = num2;
				this.pointerImage.Rotate = num2;
				this.pointerRotate += num * this.pointerRotateSpeed;
				if (this.pointerRotate >= 360f)
				{
					this.pointerRotate -= 360f;
				}
				this.lastRotate = this.pointerRotate;
				if (this.pointerRotateSpeed < 7f)
				{
					this.pointerShadowImage.Image = GFXLibrary.wheel_arrowBlurShadow[0];
					this.pointerImage.Image = GFXLibrary.wheel_arrowBlur_royal[0];
				}
				else if (this.pointerRotateSpeed < 15f)
				{
					this.pointerShadowImage.Image = GFXLibrary.wheel_arrowBlurShadow[1];
					this.pointerImage.Image = GFXLibrary.wheel_arrowBlur_royal[1];
				}
				else
				{
					this.pointerShadowImage.Image = GFXLibrary.wheel_arrowBlurShadow[2];
					this.pointerImage.Image = GFXLibrary.wheel_arrowBlur_royal[2];
				}
				if (this.spinMode > 1 && this.spinMode < 50 && this.pointerRotateSpeed < 18f)
				{
					int num3 = (int)(this.pointerRotate / 18f);
					if (num3 >= 0 && num3 < 20 && num3 != this.lastGlowSegment)
					{
						this.lastGlowSegment = num3;
						GameEngine.Instance.playInterfaceSound("Wheel_individual_segment_" + num3.ToString());
						this.rewardImages[num3].highlight();
					}
				}
				if (this.spinMode >= -1)
				{
					int num4 = (int)(this.pointerRotate / 18f);
					if (num4 >= 0 && num4 < 20)
					{
						this.centreRewardImage.fixedHighlight();
						this.centreRewardImage.updateImage(this.rewards[num4]);
					}
				}
				base.Invalidate(new Rectangle(108, 130, 370, 370));
			}
			int num5 = this.spinMode;
			switch (num5)
			{
			case 0:
				if (this.pointerRotateSpeed < 30f)
				{
					this.pointerRotateSpeed += 0.4f;
				}
				else
				{
					this.pointerRotateSpeed = 30f;
					this.spinMode = 1;
					this.m_storedReward = null;
					this.m_cardAdded = -1;
					RemoteServices.Instance.set_SpinTheWheel_UserCallBack(new RemoteServices.SpinTheWheel_UserCallBack(WheelPanel.s_SpinTheWheelCallback));
					RemoteServices.Instance.SpinTheRoyalWheel(-1, this.m_wheelType);
				}
				break;
			case 1:
				break;
			case 2:
			{
				float num6 = (float)(this.targetSegment * 18 + 9 - 100 - 78) - this.spinStopExtra + 54f;
				if (this.isPointerInAngle(this.pointerRotate, num6, num6 + 90f))
				{
					this.spinMode++;
				}
				break;
			}
			case 3:
			{
				float num7 = (float)(this.targetSegment * 18 + 9 - 196 - 78) - this.spinStopExtra + 54f;
				if (this.isPointerInAngle(this.pointerRotate, num7 - 30f, num7))
				{
					this.spinMode++;
				}
				break;
			}
			case 4:
				if (this.pointerRotateSpeed > 5f)
				{
					this.pointerRotateSpeed -= 1f;
				}
				else if (this.pointerRotateSpeed > 1.4f)
				{
					this.pointerRotateSpeed -= 0.5f;
				}
				else
				{
					this.pointerRotateSpeed = 1.4f;
					this.spinMode++;
				}
				break;
			case 5:
			{
				float num8 = (float)(this.targetSegment * 18);
				if (this.isPointerInAngle(this.pointerRotate, num8 - this.spinStopExtra / 3f, num8 + 18f))
				{
					if (this.pointerRotateSpeed > 0f)
					{
						if (this.pointerRotateSpeed >= 0.5f || this.isPointerInAngle(this.pointerRotate, num8, num8 + 18f))
						{
							this.pointerRotateSpeed -= 0.1f;
						}
					}
					else
					{
						this.pointerRotateSpeed = 0f;
						this.prizeRewardImage.updateImage(this.m_storedReward);
						this.pegImage.Visible = false;
						this.rewardDescription.Text = Wheel.getRewardText(this.m_storedReward.rewardType, this.m_storedReward.rewardAmount, GameEngine.NFI);
						ControlForm controlForm = DX.ControlForm;
						if (controlForm != null)
						{
							controlForm.Log(this.rewardDescription.Text, ControlForm.Tab.Spins, false);
						}
						this.giveReward();
						this.spinMode = -1;
						this.updateSpinButton();
						this.starSpinMode = 1;
					}
				}
				break;
			}
			default:
				if (num5 != 50)
				{
					if (num5 == 51)
					{
						this.pointerRotateSpeed += 4f;
						if (this.pointerRotateSpeed >= 30f)
						{
							this.spinMode = 1;
							this.m_storedReward = null;
							this.m_cardAdded = -1;
							RemoteServices.Instance.set_SpinTheWheel_UserCallBack(new RemoteServices.SpinTheWheel_UserCallBack(WheelPanel.s_SpinTheWheelCallback));
							RemoteServices.Instance.SpinTheRoyalWheel(-1, this.m_wheelType);
						}
					}
				}
				else
				{
					this.pullbackCount--;
					if (this.pullbackCount == 0)
					{
						this.pointerRotateSpeed = 1f;
						this.spinMode = 51;
					}
				}
				break;
			}
			if (this.starSpinMode <= 0)
			{
				return;
			}
			switch (this.starSpinMode)
			{
			case 1:
				this.starImage.Image = GFXLibrary.wheel_star[2];
				this.starImage.Visible = true;
				if (this.prizeRewardImage.iconImage.Image == null)
				{
					this.starImage.Visible = false;
				}
				else
				{
					GameEngine.Instance.playInterfaceSound("Wheel_star_start");
				}
				this.starImage.Alpha = 0.01f;
				this.starSpinMode++;
				this.starRotate = 0f;
				this.starRotateSpeed = 8f;
				this.starSpinCount = 90;
				break;
			case 2:
				this.starImage.Alpha += 0.2f;
				if (this.starImage.Alpha > 1f)
				{
					this.starImage.Alpha = 1f;
					this.starSpinMode++;
				}
				break;
			case 3:
				this.starSpinCount--;
				if (this.starSpinCount == 0)
				{
					this.starSpinMode++;
				}
				break;
			case 4:
				this.starImage.Alpha -= 0.1f;
				if (this.starImage.Alpha < 0f)
				{
					this.starImage.Alpha = 0f;
					this.starImage.Visible = false;
					this.starSpinMode = 0;
					this.starRotateSpeed = 0f;
				}
				break;
			}
			float num9 = this.starRotate;
			if (num9 >= 179.9f && num9 <= 180f)
			{
				num9 = 179.9f;
			}
			else if (num9 > 180f && num9 <= 180.1f)
			{
				num9 = 180.1f;
			}
			this.starImage.Rotate = num9;
			this.starRotate += this.starRotateSpeed;
			if (this.starRotate >= 360f)
			{
				this.starRotate -= 360f;
			}
			if (this.starRotateSpeed <= 8f)
			{
				this.starImage.Image = GFXLibrary.wheel_star[0];
			}
			else if (this.starRotateSpeed < 15f)
			{
				this.starImage.Image = GFXLibrary.wheel_star[1];
			}
			else
			{
				this.starImage.Image = GFXLibrary.wheel_star[2];
			}
			this.starImage.invalidate();
		}

		// Token: 0x06003039 RID: 12345 RVA: 0x0027AB90 File Offset: 0x00278D90
		private bool isPointerInAngle(float testAngle, float minAngle, float maxAngle)
		{
			return (testAngle >= minAngle && testAngle < maxAngle) || (minAngle < 0f && testAngle - 360f >= minAngle && testAngle - 360f < maxAngle) || (maxAngle >= 360f && testAngle + 360f >= minAngle && testAngle + 360f < maxAngle);
		}

		// Token: 0x0600303A RID: 12346 RVA: 0x0027ABE4 File Offset: 0x00278DE4
		private void startWheelSpinning()
		{
			this.lastGlowSegment = -1;
			this.pointerRotateSpeed = -2f;
			this.pullbackCount = 10;
			this.spinMode = 50;
			Random random = new Random();
			this.spinStopExtra = (float)random.Next(10);
			this.starImage.Visible = false;
			this.starImage.Alpha = 0.01f;
			this.starSpinMode = 0;
		}

		// Token: 0x0600303B RID: 12347 RVA: 0x0027AC4C File Offset: 0x00278E4C
		private void updateSpinButton()
		{
			if (GameEngine.Instance.World.getTickets(this.m_wheelType) == 0 || this.spinMode >= 0)
			{
				this.spinButton.Enabled = false;
				this.spinGlow.Visible = false;
				return;
			}
			this.spinButton.Enabled = true;
			this.spinGlow.Visible = true;
		}

		// Token: 0x0600303C RID: 12348 RVA: 0x00023144 File Offset: 0x00021344
		private void closeClick()
		{
			InterfaceMgr.Instance.closeWheelPopup();
			InterfaceMgr.Instance.ParentForm.TopMost = true;
			InterfaceMgr.Instance.ParentForm.TopMost = false;
		}

		// Token: 0x0600303D RID: 12349 RVA: 0x00023170 File Offset: 0x00021370
		public static void ClearInstance()
		{
			WheelPanel.Instance = null;
		}

		// Token: 0x0600303E RID: 12350 RVA: 0x0027ACAC File Offset: 0x00278EAC
		internal void spinCard()
		{
			if (this.spinMode < 0)
			{
				GameEngine.Instance.playInterfaceSound("Wheel_start");
				this.startWheelSpinning();
				this.m_storedReward = null;
				this.prizeRewardImage.updateImage(null);
				this.rewardDescription.Text = "";
				this.updateSpinButton();
				GameEngine.Instance.World.useTickets(this.m_wheelType, 1);
				this.numTicketsLabel.Text = SK.Text("WheelPanel_Spins", "Spins") + ": " + GameEngine.Instance.World.getTickets(this.m_wheelType).ToString();
			}
		}

		// Token: 0x0600303F RID: 12351 RVA: 0x00023178 File Offset: 0x00021378
		private static void s_SpinTheWheelCallback(SpinTheWheel_ReturnType returnData)
		{
			if (WheelPanel.Instance != null)
			{
				WheelPanel.Instance.spinTheWheelCallback(returnData);
			}
		}

		// Token: 0x06003040 RID: 12352 RVA: 0x0027AD5C File Offset: 0x00278F5C
		private void spinTheWheelCallback(SpinTheWheel_ReturnType returnData)
		{
			if (returnData.Success && returnData.reward != null)
			{
				this.targetSegment = 0;
				this.m_storedReward = returnData.reward;
				for (int i = 0; i < 20; i++)
				{
					if (this.m_storedReward.rewardType == this.rewards[i].rewardType && this.m_storedReward.rewardAmount == this.rewards[i].rewardAmount)
					{
						this.targetSegment = i;
						break;
					}
				}
				this.spinMode = 2;
				this.m_cardAdded = returnData.cardAdded;
				return;
			}
			this.spinMode = -1;
			this.pointerRotateSpeed = 0f;
			GameEngine.Instance.World.addTickets(this.m_wheelType, 1);
			this.numTicketsLabel.Text = SK.Text("WheelPanel_Spins", "Spins") + ": " + GameEngine.Instance.World.getTickets(this.m_wheelType).ToString();
			this.updateSpinButton();
		}

		// Token: 0x06003041 RID: 12353 RVA: 0x0027AE64 File Offset: 0x00279064
		private void giveReward()
		{
			switch (this.m_storedReward.rewardType)
			{
			case 200:
				GameEngine.Instance.World.addGold((double)this.m_storedReward.rewardAmount);
				break;
			case 202:
				GameEngine.Instance.World.addFaithPoints((double)this.m_storedReward.rewardAmount);
				break;
			case 203:
				GameEngine.Instance.World.ProfileCardpoints += this.m_storedReward.rewardAmount;
				break;
			case 204:
				GameEngine.Instance.cardPackManager.addCardPack(1, this.m_storedReward.rewardAmount);
				break;
			case 205:
				GameEngine.Instance.cardPackManager.addCardPack(4, this.m_storedReward.rewardAmount);
				break;
			case 206:
				GameEngine.Instance.cardPackManager.addCardPack(27, this.m_storedReward.rewardAmount);
				break;
			case 207:
				GameEngine.Instance.cardPackManager.addCardPack(3, this.m_storedReward.rewardAmount);
				break;
			case 208:
				GameEngine.Instance.cardPackManager.addCardPack(28, this.m_storedReward.rewardAmount);
				break;
			case 209:
				GameEngine.Instance.World.addResearchPoints(this.m_storedReward.rewardAmount);
				break;
			case 210:
				GameEngine.Instance.World.addTickets(this.m_wheelType, this.m_storedReward.rewardAmount);
				this.numTicketsLabel.Text = SK.Text("WheelPanel_Spins", "Spins") + ": " + GameEngine.Instance.World.getTickets(this.m_wheelType).ToString();
				break;
			case 211:
				GameEngine.Instance.cardPackManager.addCardPack(1, this.m_storedReward.rewardAmount);
				GameEngine.Instance.cardPackManager.addCardPack(3, this.m_storedReward.rewardAmount);
				GameEngine.Instance.cardPackManager.addCardPack(4, this.m_storedReward.rewardAmount);
				GameEngine.Instance.cardPackManager.addCardPack(27, this.m_storedReward.rewardAmount);
				GameEngine.Instance.cardPackManager.addCardPack(28, this.m_storedReward.rewardAmount);
				break;
			case 212:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(3077));
				}
				break;
			case 213:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(3114));
				}
				break;
			case 214:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(3086));
				}
				break;
			case 215:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(3161));
				}
				break;
			case 216:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(3090));
				}
				break;
			case 217:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(3118));
				}
				break;
			case 218:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(3169));
				}
				break;
			case 219:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(3165));
				}
				break;
			case 220:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(3078));
				}
				break;
			case 221:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(3079));
				}
				break;
			case 223:
				GameEngine.Instance.cardPackManager.addCardPack(49, this.m_storedReward.rewardAmount);
				break;
			case 224:
				GameEngine.Instance.cardPackManager.addCardPack(50, this.m_storedReward.rewardAmount);
				break;
			case 225:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(3264));
				}
				break;
			case 226:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(3201));
				}
				break;
			case 227:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(3115));
				}
				break;
			case 228:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(3091));
				}
				break;
			case 229:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(3121));
				}
				break;
			case 230:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(257));
				}
				break;
			case 231:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(3119));
				}
				break;
			case 232:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(3269));
				}
				break;
			case 233:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(258));
				}
				break;
			case 234:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(3202));
				}
				break;
			case 235:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(3270));
				}
				break;
			case 236:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(2307));
				}
				break;
			case 237:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(3273));
				}
				break;
			case 238:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(3277));
				}
				break;
			case 239:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(259));
				}
				break;
			case 240:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(3271));
				}
				break;
			case 241:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(3203));
				}
				break;
			case 242:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(3274));
				}
				break;
			case 243:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(3268));
				}
				break;
			case 244:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(3031));
				}
				break;
			case 245:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(3123));
				}
				break;
			case 246:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(3032));
				}
				break;
			case 247:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(2690));
				}
				break;
			case 248:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(2696));
				}
				break;
			case 250:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(2946));
				}
				break;
			case 251:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(2965));
				}
				break;
			case 252:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(3278));
				}
				break;
			case 253:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(3045));
				}
				break;
			case 254:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(2947));
				}
				break;
			case 255:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(3283));
				}
				break;
			case 256:
				if (this.m_cardAdded >= 0)
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.m_cardAdded, CardTypes.getStringFromCard(2072));
				}
				break;
			}
			this.m_storedReward = null;
			this.updateSpinButton();
		}

		// Token: 0x06003042 RID: 12354 RVA: 0x0027B97C File Offset: 0x00279B7C
		public Point rotatePoint(Point pos, float angle)
		{
			double num = (double)angle;
			num *= -0.0174533;
			double num2 = Math.Cos(num);
			double num3 = Math.Sin(num);
			double num4 = (double)pos.X;
			double num5 = (double)pos.Y;
			double num6 = num4 * num2 - num5 * num3;
			double num7 = num4 * num3 + num5 * num2;
			return new Point((int)num6, (int)num7);
		}

		// Token: 0x04003C8F RID: 15503
		private const double DEG2RAD = 0.0174533;

		// Token: 0x04003C90 RID: 15504
		private IContainer components;

		// Token: 0x04003C91 RID: 15505
		private static WheelPanel Instance;

		// Token: 0x04003C92 RID: 15506
		private CustomSelfDrawPanel.CSDImage mainBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003C93 RID: 15507
		private CustomSelfDrawPanel.CSDImage closeImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003C94 RID: 15508
		private CustomSelfDrawPanel.CSDLabel labelTitle = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003C95 RID: 15509
		private CustomSelfDrawPanel.CSDLabel labelTitle2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003C96 RID: 15510
		private CustomSelfDrawPanel.CSDLabel helpLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003C97 RID: 15511
		private CustomSelfDrawPanel.CSDLabel numTicketsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003C98 RID: 15512
		private CustomSelfDrawPanel.CSDExtendingPanel greenArea = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04003C99 RID: 15513
		private CustomSelfDrawPanel.CSDExtendingPanel MainPanel = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04003C9A RID: 15514
		private CustomSelfDrawPanel.CSDButton spinButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003C9B RID: 15515
		private CustomSelfDrawPanel.CSDImage spinGlow = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003C9C RID: 15516
		private CustomSelfDrawPanel.CSDImage wheelImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003C9D RID: 15517
		private CustomSelfDrawPanel.CSDArea wheelLayer1 = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04003C9E RID: 15518
		private CustomSelfDrawPanel.CSDArea wheelLayer2 = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04003C9F RID: 15519
		private CustomSelfDrawPanel.CSDArea wheelLayer3 = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04003CA0 RID: 15520
		private CustomSelfDrawPanel.CSDImage pointerShadowImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003CA1 RID: 15521
		private CustomSelfDrawPanel.CSDImage pointerImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003CA2 RID: 15522
		private WheelPanel.RewardImage[] rewardImages = new WheelPanel.RewardImage[20];

		// Token: 0x04003CA3 RID: 15523
		private WheelPanel.RewardImage centreRewardImage = new WheelPanel.RewardImage();

		// Token: 0x04003CA4 RID: 15524
		private WheelPanel.RewardImage prizeRewardImage = new WheelPanel.RewardImage();

		// Token: 0x04003CA5 RID: 15525
		private CustomSelfDrawPanel.CSDLabel rewardDescription = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003CA6 RID: 15526
		private CustomSelfDrawPanel.CSDImage starImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003CA7 RID: 15527
		private CustomSelfDrawPanel.CSDImage pegImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003CA8 RID: 15528
		private bool rewardImagesCreated;

		// Token: 0x04003CA9 RID: 15529
		private int m_cardAdded = -1;

		// Token: 0x04003CAA RID: 15530
		private int m_wheelType = -1;

		// Token: 0x04003CAB RID: 15531
		private bool royal = true;

		// Token: 0x04003CAC RID: 15532
		private List<WheelReward> rewards;

		// Token: 0x04003CAD RID: 15533
		private float pointerRotate;

		// Token: 0x04003CAE RID: 15534
		private float pointerRotateSpeed;

		// Token: 0x04003CAF RID: 15535
		private float lastRotate = -1000f;

		// Token: 0x04003CB0 RID: 15536
		private int spinMode;

		// Token: 0x04003CB1 RID: 15537
		private int targetSegment = 5;

		// Token: 0x04003CB2 RID: 15538
		private int pullbackCount;

		// Token: 0x04003CB3 RID: 15539
		private int starSpinMode;

		// Token: 0x04003CB4 RID: 15540
		private int starSpinCount;

		// Token: 0x04003CB5 RID: 15541
		private float starRotate;

		// Token: 0x04003CB6 RID: 15542
		private float starRotateSpeed;

		// Token: 0x04003CB7 RID: 15543
		private float spinStopExtra;

		// Token: 0x04003CB8 RID: 15544
		private int lastGlowSegment = -1;

		// Token: 0x04003CB9 RID: 15545
		private WheelReward m_storedReward;

		// Token: 0x020004F6 RID: 1270
		public class RewardImage : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x06003045 RID: 12357 RVA: 0x000231BA File Offset: 0x000213BA
			public void init(WheelReward reward, Point position)
			{
				this.init(reward, position, null, null, null);
			}

			// Token: 0x06003046 RID: 12358 RVA: 0x0027B9D8 File Offset: 0x00279BD8
			public void init(WheelReward reward, Point position, CustomSelfDrawPanel.CSDArea layer1, CustomSelfDrawPanel.CSDArea layer2, CustomSelfDrawPanel.CSDArea layer3)
			{
				this.fadeValue = 0f;
				this.m_reward = reward;
				this.Position = new Point(position.X - 64, position.Y - 64);
				this.Size = new Size(128, 128);
				this.glowImage.Image = GFXLibrary.wheel_icons[0];
				if (layer1 != null)
				{
					this.glowImage.Position = this.Position;
					this.glowImage.Alpha = 0f;
					layer1.addControl(this.glowImage);
					this.updateImage(reward);
					this.iconImage.Position = new Point(this.Position.X + 2, this.Position.Y + 2);
					layer2.addControl(this.iconImage);
					this.numberImage.Position = new Point(this.Position.X + 13, this.Position.Y + 75);
					layer3.addControl(this.numberImage);
					return;
				}
				this.glowImage.Alpha = 0f;
				base.addControl(this.glowImage);
				this.updateImage(reward);
				this.iconImage.Position = new Point(2, 2);
				base.addControl(this.iconImage);
				this.numberImage.Position = new Point(13, 75);
				base.addControl(this.numberImage);
			}

			// Token: 0x06003047 RID: 12359 RVA: 0x0027BB5C File Offset: 0x00279D5C
			public void updateImage(WheelReward reward)
			{
				this.m_reward = reward;
				this.numberImage.Visible = false;
				if (reward != null)
				{
					bool flag = false;
					bool flag2 = true;
					switch (reward.rewardType)
					{
					case 200:
						this.iconImage.Image = GFXLibrary.wheel_icons[5];
						break;
					case 202:
						this.iconImage.Image = GFXLibrary.wheel_icons[4];
						break;
					case 203:
						this.iconImage.Image = GFXLibrary.wheel_icons[1];
						break;
					case 204:
						this.iconImage.Image = GFXLibrary.wheel_icons[10];
						flag = true;
						break;
					case 205:
						this.iconImage.Image = GFXLibrary.wheel_icons[8];
						flag = true;
						break;
					case 206:
						this.iconImage.Image = GFXLibrary.wheel_icons[6];
						flag = true;
						break;
					case 207:
						this.iconImage.Image = GFXLibrary.wheel_icons[9];
						flag = true;
						break;
					case 208:
						this.iconImage.Image = GFXLibrary.wheel_icons[7];
						flag = true;
						break;
					case 209:
						this.iconImage.Image = GFXLibrary.wheel_icons[2];
						break;
					case 210:
						this.iconImage.Image = GFXLibrary.wheel_icons[3];
						flag2 = false;
						break;
					case 211:
						this.iconImage.Image = GFXLibrary.wheel_icons[11];
						flag = true;
						break;
					case 212:
						this.iconImage.Image = GFXLibrary.wheel_icons[26];
						flag2 = false;
						break;
					case 213:
						this.iconImage.Image = GFXLibrary.wheel_icons[17];
						flag2 = false;
						break;
					case 214:
						this.iconImage.Image = GFXLibrary.wheel_icons[19];
						flag2 = false;
						break;
					case 215:
						this.iconImage.Image = GFXLibrary.wheel_icons[16];
						flag2 = false;
						break;
					case 216:
						this.iconImage.Image = GFXLibrary.wheel_icons[20];
						flag2 = false;
						break;
					case 217:
						this.iconImage.Image = GFXLibrary.wheel_icons[18];
						flag2 = false;
						break;
					case 218:
						this.iconImage.Image = GFXLibrary.wheel_icons[21];
						flag2 = false;
						break;
					case 219:
						this.iconImage.Image = GFXLibrary.wheel_icons[22];
						flag2 = false;
						break;
					case 220:
						this.iconImage.Image = GFXLibrary.wheel_icons[27];
						flag2 = false;
						break;
					case 221:
						this.iconImage.Image = GFXLibrary.wheel_icons[28];
						flag2 = false;
						break;
					case 222:
						this.iconImage.Image = null;
						this.numberImage.Visible = false;
						flag2 = false;
						break;
					case 223:
						this.iconImage.Image = GFXLibrary.wheel_icons[30];
						flag = true;
						break;
					case 224:
						this.iconImage.Image = GFXLibrary.wheel_icons[29];
						flag = true;
						break;
					case 225:
						this.iconImage.Image = GFXLibrary.wheel_icons[31];
						flag2 = false;
						break;
					case 226:
						this.iconImage.Image = GFXLibrary.wheel_icons[32];
						flag2 = false;
						break;
					case 227:
						this.iconImage.Image = GFXLibrary.wheel_icons[33];
						flag2 = false;
						break;
					case 228:
						this.iconImage.Image = GFXLibrary.wheel_icons[34];
						flag2 = false;
						break;
					case 229:
						this.iconImage.Image = GFXLibrary.wheel_icons[35];
						flag2 = false;
						break;
					case 230:
						this.iconImage.Image = GFXLibrary.wheel_icons[36];
						flag2 = false;
						break;
					case 231:
						this.iconImage.Image = GFXLibrary.wheel_icons[37];
						flag2 = false;
						break;
					case 232:
						this.iconImage.Image = GFXLibrary.wheel_icons[38];
						flag2 = false;
						break;
					case 233:
						this.iconImage.Image = GFXLibrary.wheel_icons[39];
						flag2 = false;
						break;
					case 234:
						this.iconImage.Image = GFXLibrary.wheel_icons[40];
						flag2 = false;
						break;
					case 235:
						this.iconImage.Image = GFXLibrary.wheel_icons[41];
						flag2 = false;
						break;
					case 236:
						this.iconImage.Image = GFXLibrary.wheel_icons[42];
						flag2 = false;
						break;
					case 237:
						this.iconImage.Image = GFXLibrary.wheel_icons[43];
						flag2 = false;
						break;
					case 238:
						this.iconImage.Image = GFXLibrary.wheel_icons[44];
						flag2 = false;
						break;
					case 239:
						this.iconImage.Image = GFXLibrary.wheel_icons[45];
						flag2 = false;
						break;
					case 240:
						this.iconImage.Image = GFXLibrary.wheel_icons[46];
						flag2 = false;
						break;
					case 241:
						this.iconImage.Image = GFXLibrary.wheel_icons[47];
						flag2 = false;
						break;
					case 242:
						this.iconImage.Image = GFXLibrary.wheel_icons[48];
						flag2 = false;
						break;
					case 243:
						this.iconImage.Image = GFXLibrary.wheel_icons[49];
						flag2 = false;
						break;
					case 244:
						this.iconImage.Image = GFXLibrary.wheel_icons[50];
						flag2 = false;
						break;
					case 245:
						this.iconImage.Image = GFXLibrary.wheel_icons[51];
						flag2 = false;
						break;
					case 246:
						this.iconImage.Image = GFXLibrary.wheel_icons[52];
						flag2 = false;
						break;
					case 247:
						this.iconImage.Image = GFXLibrary.wheel_icons[53];
						flag2 = false;
						break;
					case 248:
						this.iconImage.Image = GFXLibrary.wheel_icons[54];
						flag2 = false;
						break;
					case 250:
						this.iconImage.Image = GFXLibrary.wheel_icons[55];
						flag2 = false;
						break;
					case 251:
						this.iconImage.Image = GFXLibrary.wheel_icons[56];
						flag2 = false;
						break;
					case 252:
						this.iconImage.Image = GFXLibrary.wheel_icons[57];
						flag2 = false;
						break;
					case 253:
						this.iconImage.Image = GFXLibrary.wheel_icons[58];
						flag2 = false;
						break;
					case 254:
						this.iconImage.Image = GFXLibrary.wheel_icons[59];
						flag2 = false;
						break;
					case 255:
						this.iconImage.Image = GFXLibrary.wheel_icons[60];
						flag2 = false;
						break;
					case 256:
						this.iconImage.Image = GFXLibrary.wheel_icons[61];
						flag2 = false;
						break;
					}
					if (flag2)
					{
						int num = -1;
						if (flag)
						{
							switch (reward.rewardAmount)
							{
							case 1:
								num = 28;
								break;
							case 2:
								num = 27;
								break;
							case 3:
								num = 26;
								break;
							case 4:
								num = 25;
								break;
							case 5:
								num = 24;
								break;
							case 10:
								num = 23;
								break;
							}
						}
						else
						{
							int rewardAmount = reward.rewardAmount;
							if (rewardAmount <= 400)
							{
								if (rewardAmount <= 40)
								{
									if (rewardAmount <= 10)
									{
										if (rewardAmount != 1)
										{
											if (rewardAmount != 2)
											{
												if (rewardAmount == 10)
												{
													num = 20;
												}
											}
											else
											{
												num = 21;
											}
										}
										else
										{
											num = 22;
										}
									}
									else if (rewardAmount <= 25)
									{
										if (rewardAmount != 20)
										{
											if (rewardAmount == 25)
											{
												num = 19;
											}
										}
										else
										{
											num = 31;
										}
									}
									else if (rewardAmount != 35)
									{
										if (rewardAmount == 40)
										{
											num = 32;
										}
									}
									else
									{
										num = 18;
									}
								}
								else if (rewardAmount <= 100)
								{
									if (rewardAmount <= 75)
									{
										if (rewardAmount != 50)
										{
											if (rewardAmount == 75)
											{
												num = 16;
											}
										}
										else
										{
											num = 17;
										}
									}
									else if (rewardAmount != 80)
									{
										if (rewardAmount == 100)
										{
											num = 15;
										}
									}
									else
									{
										num = 33;
									}
								}
								else if (rewardAmount <= 200)
								{
									if (rewardAmount != 150)
									{
										if (rewardAmount == 200)
										{
											num = 12;
										}
									}
									else
									{
										num = 14;
									}
								}
								else if (rewardAmount != 250)
								{
									if (rewardAmount == 400)
									{
										num = 11;
									}
								}
								else
								{
									num = 13;
								}
							}
							else if (rewardAmount <= 20000)
							{
								if (rewardAmount <= 2000)
								{
									if (rewardAmount != 500)
									{
										if (rewardAmount != 1000)
										{
											if (rewardAmount == 2000)
											{
												num = 8;
											}
										}
										else
										{
											num = 9;
										}
									}
									else
									{
										num = 10;
									}
								}
								else if (rewardAmount <= 10000)
								{
									if (rewardAmount != 5000)
									{
										if (rewardAmount == 10000)
										{
											num = 6;
										}
									}
									else
									{
										num = 7;
									}
								}
								else if (rewardAmount != 15000)
								{
									if (rewardAmount == 20000)
									{
										num = 5;
									}
								}
								else
								{
									num = 29;
								}
							}
							else if (rewardAmount <= 50000)
							{
								if (rewardAmount <= 30000)
								{
									if (rewardAmount != 25000)
									{
										if (rewardAmount == 30000)
										{
											num = 30;
										}
									}
									else
									{
										num = 4;
									}
								}
								else if (rewardAmount != 40000)
								{
									if (rewardAmount == 50000)
									{
										num = 3;
									}
								}
								else
								{
									num = 34;
								}
							}
							else if (rewardAmount <= 150000)
							{
								if (rewardAmount != 100000)
								{
									if (rewardAmount == 150000)
									{
										num = 35;
									}
								}
								else
								{
									num = 2;
								}
							}
							else if (rewardAmount != 250000)
							{
								if (rewardAmount == 500000)
								{
									num = 0;
								}
							}
							else
							{
								num = 1;
							}
						}
						if (num >= 0)
						{
							this.numberImage.Visible = true;
							this.numberImage.Image = GFXLibrary.wheel_numbers[num];
						}
						else
						{
							this.numberImage.Visible = false;
						}
					}
				}
				else
				{
					this.iconImage.Image = null;
					this.numberImage.Visible = false;
				}
				base.invalidate();
			}

			// Token: 0x06003048 RID: 12360 RVA: 0x000231C7 File Offset: 0x000213C7
			public void fixedHighlight()
			{
				this.fadeValue = 0f;
				this.glowImage.Alpha = 1f;
				base.invalidate();
			}

			// Token: 0x06003049 RID: 12361 RVA: 0x000231EA File Offset: 0x000213EA
			public void highlight()
			{
				this.fadeValue = 10f;
				this.glowImage.Alpha = 1f;
				base.invalidate();
			}

			// Token: 0x0600304A RID: 12362 RVA: 0x0027C668 File Offset: 0x0027A868
			public bool update()
			{
				if (this.fadeValue > 0f)
				{
					this.fadeValue -= 1f;
					if (this.fadeValue < 0f)
					{
						this.fadeValue = 0f;
					}
					this.glowImage.Alpha = this.fadeValue / 10f;
					base.invalidate();
				}
				return true;
			}

			// Token: 0x04003CBA RID: 15546
			private const float FADE_MAX = 10f;

			// Token: 0x04003CBB RID: 15547
			private CustomSelfDrawPanel.CSDImage glowImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04003CBC RID: 15548
			public CustomSelfDrawPanel.CSDImage iconImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04003CBD RID: 15549
			private CustomSelfDrawPanel.CSDImage numberImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04003CBE RID: 15550
			private WheelReward m_reward;

			// Token: 0x04003CBF RID: 15551
			private float fadeValue;
		}
	}
}
