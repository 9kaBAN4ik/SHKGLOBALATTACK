using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using CommonTypes;
using Gecko;
using Gecko.Events;
using Properties;
using StatTracking;
using Stronghold.AuthClient;
using Stronghold.ShieldClient;
using Upgrade;
using Upgrade.Forms;

namespace Kingdoms
{
	// Token: 0x02000292 RID: 658
	public partial class ProfileLoginWindow : Form
	{
		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x06001D45 RID: 7493 RVA: 0x0001C6F8 File Offset: 0x0001A8F8
		public Image LoginImage
		{
			get
			{
				if (this.loginImage == null)
				{
					this.loginImage = WebStyleButtonImage.Generate(100, this.WebButtonheight, this.strLogin, this.WebTextFontBoldCond, global::ARGBColors.White, this.WebButtonblue, this.WebButtonRadius);
				}
				return this.loginImage;
			}
		}

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x06001D46 RID: 7494 RVA: 0x001C72D4 File Offset: 0x001C54D4
		public Image LoginImageOver
		{
			get
			{
				if (this.loginImageOver == null)
				{
					this.loginImageOver = WebStyleButtonImage.Generate(100, this.WebButtonheight, this.strLogin, this.WebTextFontBoldCond, this.WebButtonblue, this.WebButtonGrey, this.WebButtonRadius);
				}
				return this.loginImageOver;
			}
		}

		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x06001D47 RID: 7495 RVA: 0x0001C738 File Offset: 0x0001A938
		public Image LogoutImage
		{
			get
			{
				if (this.logoutImage == null)
				{
					this.logoutImage = WebStyleButtonImage.Generate(100, this.WebButtonheight, this.strLogout, this.WebTextFontBoldCond, global::ARGBColors.White, this.WebButtonblue, this.WebButtonRadius);
				}
				return this.logoutImage;
			}
		}

		// Token: 0x170001EA RID: 490
		// (get) Token: 0x06001D48 RID: 7496 RVA: 0x001C7320 File Offset: 0x001C5520
		public Image LogoutImageOver
		{
			get
			{
				if (this.logoutImageOver == null)
				{
					this.logoutImageOver = WebStyleButtonImage.Generate(100, this.WebButtonheight, this.strLogout, this.WebTextFontBoldCond, this.WebButtonblue, this.WebButtonGrey, this.WebButtonRadius);
				}
				return this.logoutImageOver;
			}
		}

		// Token: 0x170001EB RID: 491
		// (get) Token: 0x06001D49 RID: 7497 RVA: 0x001C736C File Offset: 0x001C556C
		public Image JoinImage
		{
			get
			{
				if (this.joinImage == null)
				{
					this.joinImage = WebStyleButtonImage.Generate(this.WebButtonWidth, this.WebButtonheight, this.strJoin, this.WebTextFontBoldCond, global::ARGBColors.White, this.WebButtonblue, this.WebButtonRadius);
				}
				return this.joinImage;
			}
		}

		// Token: 0x170001EC RID: 492
		// (get) Token: 0x06001D4A RID: 7498 RVA: 0x001C73BC File Offset: 0x001C55BC
		public Image JoinImageOver
		{
			get
			{
				if (this.joinImageOver == null)
				{
					this.joinImageOver = WebStyleButtonImage.Generate(this.WebButtonWidth, this.WebButtonheight, this.strJoin, this.WebTextFontBoldCond, this.WebButtonblue, this.WebButtonGrey, this.WebButtonRadius);
				}
				return this.joinImageOver;
			}
		}

		// Token: 0x170001ED RID: 493
		// (get) Token: 0x06001D4B RID: 7499 RVA: 0x001C740C File Offset: 0x001C560C
		public Image PlayImage
		{
			get
			{
				if (this.playImage == null)
				{
					this.playImage = WebStyleButtonImage.Generate(this.WebButtonWidth, this.WebButtonheight, this.strPlay, this.WebTextFontBoldCond, global::ARGBColors.White, this.WebButtonblue, this.WebButtonRadius);
				}
				return this.playImage;
			}
		}

		// Token: 0x170001EE RID: 494
		// (get) Token: 0x06001D4C RID: 7500 RVA: 0x001C745C File Offset: 0x001C565C
		public Image PlayImageOver
		{
			get
			{
				if (this.playImageOver == null)
				{
					this.playImageOver = WebStyleButtonImage.Generate(this.WebButtonWidth, this.WebButtonheight, this.strPlay, this.WebTextFontBoldCond, this.WebButtonblue, this.WebButtonGrey, this.WebButtonRadius);
				}
				return this.playImageOver;
			}
		}

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x06001D4D RID: 7501 RVA: 0x001C74AC File Offset: 0x001C56AC
		public Image ClosedImage
		{
			get
			{
				if (this.closedImage == null)
				{
					this.closedImage = WebStyleButtonImage.Generate(this.WebButtonWidth, this.WebButtonheight, this.strClosed, this.WebTextFontBoldCond, global::ARGBColors.White, this.WebButtonRed, this.WebButtonRadius);
				}
				return this.closedImage;
			}
		}

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x06001D4E RID: 7502 RVA: 0x001C74FC File Offset: 0x001C56FC
		public Image SelectImage
		{
			get
			{
				if (this.selectImage == null)
				{
					this.selectImage = WebStyleButtonImage.Generate(this.WebButtonWidth * 2 + 100, this.WebButtonheight, this.strSelect, this.WebTextFontBoldCond, global::ARGBColors.White, this.WebButtonblue, this.WebButtonRadius);
				}
				return this.selectImage;
			}
		}

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x06001D4F RID: 7503 RVA: 0x001C7550 File Offset: 0x001C5750
		public Image SelectImageOver
		{
			get
			{
				if (this.selectImageOver == null)
				{
					this.selectImageOver = WebStyleButtonImage.Generate(this.WebButtonWidth * 2 + 100, this.WebButtonheight, this.strSelect, this.WebTextFontBoldCond, this.WebButtonblue, this.WebButtonGrey, this.WebButtonRadius);
				}
				return this.selectImageOver;
			}
		}

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x06001D50 RID: 7504 RVA: 0x0001C778 File Offset: 0x0001A978
		public Image NewsImage
		{
			get
			{
				if (this.newsImage == null)
				{
					this.newsImage = WebStyleButtonImage.Generate(80, this.WebButtonheight, this.strNews, this.WebTextFontBoldCond, global::ARGBColors.White, this.WebButtonblue, this.WebButtonRadius);
				}
				return this.newsImage;
			}
		}

		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x06001D51 RID: 7505 RVA: 0x001C75A8 File Offset: 0x001C57A8
		public Image NewsImageOver
		{
			get
			{
				if (this.newsImageOver == null)
				{
					this.newsImageOver = WebStyleButtonImage.Generate(80, this.WebButtonheight, this.strNews, this.WebTextFontBoldCond, this.WebButtonblue, this.WebButtonGrey, this.WebButtonRadius);
				}
				return this.newsImageOver;
			}
		}

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x06001D52 RID: 7506 RVA: 0x001C75F4 File Offset: 0x001C57F4
		public Image AccountImage
		{
			get
			{
				if (this.accountImage == null)
				{
					this.accountImage = WebStyleButtonImage.Generate(130, this.WebButtonheight, this.strAccountDetails, this.WebTextFontBoldCond, global::ARGBColors.White, this.WebButtonblue, this.WebButtonRadius);
				}
				return this.accountImage;
			}
		}

		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x06001D53 RID: 7507 RVA: 0x001C7644 File Offset: 0x001C5844
		public Image AccountImageOver
		{
			get
			{
				if (this.accountImageOver == null)
				{
					this.accountImageOver = WebStyleButtonImage.Generate(130, this.WebButtonheight, this.strAccountDetails, this.WebTextFontBoldCond, this.WebButtonblue, this.WebButtonGrey, this.WebButtonRadius);
				}
				return this.accountImageOver;
			}
		}

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x06001D54 RID: 7508 RVA: 0x001C7694 File Offset: 0x001C5894
		public Image CreateAccountImage
		{
			get
			{
				if (this.createAccountImage == null)
				{
					this.createAccountImage = WebStyleButtonImage.Generate(250, this.WebButtonheight, this.strCreateAccount, this.WebTextFontBoldCond, global::ARGBColors.White, this.WebButtonblue, this.WebButtonRadius);
				}
				return this.createAccountImage;
			}
		}

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x06001D55 RID: 7509 RVA: 0x001C76E4 File Offset: 0x001C58E4
		public Image CreateAccountImageOver
		{
			get
			{
				if (this.createAccountImageOver == null)
				{
					this.createAccountImageOver = WebStyleButtonImage.Generate(250, this.WebButtonheight, this.strCreateAccount, this.WebTextFontBoldCond, this.WebButtonblue, this.WebButtonGrey, this.WebButtonRadius);
				}
				return this.createAccountImageOver;
			}
		}

		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x06001D56 RID: 7510 RVA: 0x001C7734 File Offset: 0x001C5934
		public Image CreateAccountImage2
		{
			get
			{
				if (this.createAccountImage2 == null)
				{
					this.createAccountImage2 = WebStyleButtonImage.Generate(250, this.WebButtonheight, "StrongholdKingdoms.com", this.WebTextFontBoldCond, global::ARGBColors.White, this.WebButtonblue, this.WebButtonRadius);
				}
				return this.createAccountImage2;
			}
		}

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x06001D57 RID: 7511 RVA: 0x001C7784 File Offset: 0x001C5984
		public Image CreateAccountImageOver2
		{
			get
			{
				if (this.createAccountImageOver2 == null)
				{
					this.createAccountImageOver2 = WebStyleButtonImage.Generate(250, this.WebButtonheight, "StrongholdKingdoms.com", this.WebTextFontBoldCond, this.WebButtonblue, this.WebButtonGrey, this.WebButtonRadius);
				}
				return this.createAccountImageOver2;
			}
		}

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x06001D58 RID: 7512 RVA: 0x001C77D4 File Offset: 0x001C59D4
		public Image OptionsImage
		{
			get
			{
				if (this.optionsImage == null)
				{
					this.optionsImage = WebStyleButtonImage.Generate(250, this.WebButtonheight, this.strOptions, this.WebTextFontBoldCond, global::ARGBColors.White, this.WebButtonblue, this.WebButtonRadius);
				}
				return this.optionsImage;
			}
		}

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x06001D59 RID: 7513 RVA: 0x001C7824 File Offset: 0x001C5A24
		public Image OptionsImageOver
		{
			get
			{
				if (this.optionsImageOver == null)
				{
					this.optionsImageOver = WebStyleButtonImage.Generate(250, this.WebButtonheight, this.strOptions, this.WebTextFontBoldCond, this.WebButtonblue, this.WebButtonGrey, this.WebButtonRadius);
				}
				return this.optionsImageOver;
			}
		}

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x06001D5A RID: 7514 RVA: 0x001C7874 File Offset: 0x001C5A74
		public Image ForgottenImage
		{
			get
			{
				if (this.forgottenImage == null)
				{
					this.forgottenImage = WebStyleButtonImage.Generate(150, this.WebButtonheight, this.strForgottenPassword, this.WebTextFontBoldCond, global::ARGBColors.White, this.WebButtonblue, this.WebButtonRadius);
				}
				return this.forgottenImage;
			}
		}

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x06001D5B RID: 7515 RVA: 0x001C78C4 File Offset: 0x001C5AC4
		public Image ForgottenImageOver
		{
			get
			{
				if (this.forgottenImageOver == null)
				{
					this.forgottenImageOver = WebStyleButtonImage.Generate(150, this.WebButtonheight, this.strForgottenPassword, this.WebTextFontBoldCond, this.WebButtonblue, this.WebButtonGrey, this.WebButtonRadius);
				}
				return this.forgottenImageOver;
			}
		}

		// Token: 0x170001FE RID: 510
		// (get) Token: 0x06001D5C RID: 7516 RVA: 0x0001C7B8 File Offset: 0x0001A9B8
		public Image ExitImage
		{
			get
			{
				if (this.exitImage == null)
				{
					this.exitImage = WebStyleButtonImage.Generate(100, this.WebButtonheight, this.strExit, this.WebTextFontBoldCond, global::ARGBColors.White, this.WebButtonblue, this.WebButtonRadius);
				}
				return this.exitImage;
			}
		}

		// Token: 0x170001FF RID: 511
		// (get) Token: 0x06001D5D RID: 7517 RVA: 0x001C7914 File Offset: 0x001C5B14
		public Image ExitImageOver
		{
			get
			{
				if (this.exitImageOver == null)
				{
					this.exitImageOver = WebStyleButtonImage.Generate(100, this.WebButtonheight, this.strExit, this.WebTextFontBoldCond, this.WebButtonblue, this.WebButtonGrey, this.WebButtonRadius);
				}
				return this.exitImageOver;
			}
		}

		// Token: 0x17000200 RID: 512
		// (get) Token: 0x06001D5E RID: 7518 RVA: 0x0001C7F8 File Offset: 0x0001A9F8
		public Image CancelImage
		{
			get
			{
				if (this.cancelImage == null)
				{
					this.cancelImage = WebStyleButtonImage.Generate(100, this.WebButtonheight, this.strCancel, this.WebTextFontBoldCond, global::ARGBColors.White, this.WebButtonblue, this.WebButtonRadius);
				}
				return this.cancelImage;
			}
		}

		// Token: 0x17000201 RID: 513
		// (get) Token: 0x06001D5F RID: 7519 RVA: 0x001C7960 File Offset: 0x001C5B60
		public Image CancelImageOver
		{
			get
			{
				if (this.cancelImageOver == null)
				{
					this.cancelImageOver = WebStyleButtonImage.Generate(100, this.WebButtonheight, this.strCancel, this.WebTextFontBoldCond, this.WebButtonblue, this.WebButtonGrey, this.WebButtonRadius);
				}
				return this.cancelImageOver;
			}
		}

		// Token: 0x06001D60 RID: 7520
		[DllImport("kernel32.dll")]
		private static extern ushort GetSystemDefaultLangID();

		// Token: 0x06001D61 RID: 7521 RVA: 0x0001C838 File Offset: 0x0001AA38
		public CustomSelfDrawPanel.CSDImage MakeGreyoutImage(Control ctrl)
		{
			return this.MakeGreyoutImage(ctrl.Width, ctrl.Height);
		}

		// Token: 0x06001D62 RID: 7522 RVA: 0x001C79AC File Offset: 0x001C5BAC
		public CustomSelfDrawPanel.CSDImage MakeGreyoutImage(int width, int height)
		{
			Image image = new Bitmap(width, height);
			Color color = Color.FromArgb(125, 100, 100, 100);
			Brush brush = new SolidBrush(color);
			using (Graphics graphics = Graphics.FromImage(image))
			{
				graphics.FillRectangle(brush, 0, 0, width, height);
			}
			brush.Dispose();
			return new CustomSelfDrawPanel.CSDImage
			{
				Height = image.Height,
				Width = image.Width,
				X = 0,
				Y = 0,
				Image = image
			};
		}

		// Token: 0x06001D63 RID: 7523 RVA: 0x0001C84C File Offset: 0x0001AA4C
		public void SetSteamEmail(string text)
		{
			this.txtEmail.Text = text;
			this.lblEmailSteam.Text = text;
			this.lblEmail.Visible = true;
			this.lblPassword.Visible = false;
			this.txtPassword.Visible = false;
		}

		// Token: 0x06001D64 RID: 7524 RVA: 0x0001C88A File Offset: 0x0001AA8A
		public void SetNonSteamEmail(string text, string password)
		{
			this.txtEmail.Text = text;
			this.txtPassword.Text = password;
			this.lblEmail.Visible = true;
		}

		// Token: 0x06001D65 RID: 7525 RVA: 0x001C7A44 File Offset: 0x001C5C44
		public void AddControls()
		{
			this.pnlWorlds.Controls.Clear();
			this.pnlLogin.Controls.Clear();
			this.pnlFeedback.Controls.Clear();
			this.pnlTabs.Controls.Clear();
			this.allButtons = new List<CustomSelfDrawPanel.CSDControl>();
			this.txtEmail = new TextBox();
			this.lblEmailSteam = new CustomSelfDrawPanel.CSDLabel();
			this.lblEmail = new CustomSelfDrawPanel.CSDLabel();
			if (Program.gamersFirstInstall || Program.arcInstall)
			{
				this.lblEmail.Text = "";
			}
			else if (!Program.bigpointInstall)
			{
				this.lblEmail.Text = this.strEmailAddress;
			}
			else
			{
				this.lblEmail.Text = SK.Text("Login_BigPoint_username", "Stronghold Kingdoms Username");
			}
			this.lblEmail.Width = 300;
			this.lblEmail.Height = 18;
			this.txtPassword = new TextBox();
			this.lblPassword = new CustomSelfDrawPanel.CSDLabel();
			if (Program.gamersFirstInstall || Program.arcInstall)
			{
				this.lblPassword.Text = "";
			}
			else if (!Program.bigpointInstall)
			{
				this.lblPassword.Text = this.strPassword;
			}
			else
			{
				this.lblPassword.Text = SK.Text("Login_BigPoint_Password", "Your Bigpoint Password");
			}
			this.lblPassword.Width = 300;
			this.lblPassword.Height = 18;
			this.LoginPanelControls_LoggedOut = new CustomSelfDrawPanel();
			this.LoginPanelControls_LoggedOut.AutoScaleMode = AutoScaleMode.None;
			this.LoginPanelControls_LoggedOut.forceStyle();
			this.btnLogin = new CustomSelfDrawPanel.CSDImage();
			this.allButtons.Add(this.btnLogin);
			this.btnLogin.Image = this.LoginImage;
			this.btnLogin.Width = this.btnLogin.Image.Width;
			this.btnLogin.Height = this.btnLogin.Image.Height;
			this.btnLogin.Enabled = false;
			this.lblLoginError = new CustomSelfDrawPanel.CSDLabel();
			this.lblLoginError.Color = global::ARGBColors.Red;
			this.lblLoginError.Visible = false;
			this.lblLoginError.Text = "ERROR:";
			this.lblLoginError.Width = this.pnlLogin.Width;
			this.lblEmail.Position = new Point(4, this.pnlTabs.Height - 29);
			this.txtEmail.Location = new Point(4, this.lblEmail.Y + this.lblEmail.Height);
			this.lblEmailSteam.Position = new Point(4, this.lblEmail.Y + this.lblEmail.Height);
			this.lblPassword.Position = new Point(4, this.txtEmail.Bottom + 2);
			this.txtPassword.Location = new Point(4, this.lblPassword.Y + this.lblPassword.Height);
			this.txtPassword.Width = this.pnlLogin.Width - 8;
			this.lblConnectionInfo = new CustomSelfDrawPanel.CSDLabel
			{
				Visible = true,
				Width = 300,
				Height = 60,
				Text = DX.GetConnectionInfo(this.GetMacAddress()),
				Position = new Point(4, this.txtPassword.Bottom + 2)
			};
			this.lblConnectionInfo.setClickDelegate(delegate()
			{
				new AdvancedLogin(this.txtEmail, this.txtPassword, this.lblConnectionInfo, new GetMAC(this.GetMacAddress)).Show();
			}, "ProfileLoginWindow_login");
			try
			{
				if (Settings.Default.ShowAdvancedLoginOptions)
				{
					AdvancedLogin advancedLogin = new AdvancedLogin(this.txtEmail, this.txtPassword, this.lblConnectionInfo, new GetMAC(this.GetMacAddress));
					advancedLogin.Show();
				}
			}
			catch (ConfigurationErrorsException)
			{
				string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
				string path = Path.Combine(folderPath, "Local");
				string text = Path.Combine(path, "Firefly_Studios");
				MessageBox.Show(text, "Please delete old settings", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			this.LoginPanelControls_LoggedOut.addControl(this.lblConnectionInfo);
			this.txtEmail.Width = this.pnlLogin.Width - 8;
			this.lblEmailSteam.Width = this.pnlLogin.Width - 8;
			this.lblEmailSteam.Height = this.lblEmail.Height;
			this.txtPassword.PasswordChar = '*';
			this.btnLogin.Position = new Point(4, this.lblConnectionInfo.Y + this.lblConnectionInfo.Height + 4);
			this.lblLoginError.Position = new Point(4, this.btnLogin.Y + this.btnLogin.Height);
			this.btnLogin.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnLogin_Click), "ProfileLoginWindow_login");
			this.btnLogin.setMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.loginOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.loginOut));
			this.txtEmail.TextChanged += this.txtLoginField_Validate_email;
			this.txtPassword.TextChanged += this.txtLoginField_Validate;
			this.btnLoginFB = new CustomSelfDrawPanel.CSDButton();
			this.allButtons.Add(this.btnLoginFB);
			string languageIdent = Program.mySettings.LanguageIdent;
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
									this.btnLoginFB.ImageNorm = GFXLibrary.facebookLogin_ES;
									goto IL_74F;
								}
							}
						}
						else if (languageIdent == "pl")
						{
							this.btnLoginFB.ImageNorm = GFXLibrary.facebookLogin_PL;
							goto IL_74F;
						}
					}
					else if (num != 1194886160U)
					{
						if (num == 1195724803U)
						{
							if (languageIdent == "tr")
							{
								this.btnLoginFB.ImageNorm = GFXLibrary.facebookLogin_TR;
								goto IL_74F;
							}
						}
					}
					else if (languageIdent == "it")
					{
						this.btnLoginFB.ImageNorm = GFXLibrary.facebookLogin_IT;
						goto IL_74F;
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
								this.btnLoginFB.ImageNorm = GFXLibrary.facebookLogin_EN;
								goto IL_74F;
							}
						}
					}
					else if (languageIdent == "ru")
					{
						this.btnLoginFB.ImageNorm = GFXLibrary.facebookLogin_RU;
						goto IL_74F;
					}
				}
				else if (num != 1545391778U)
				{
					if (num == 1565420801U)
					{
						if (languageIdent == "pt")
						{
							this.btnLoginFB.ImageNorm = GFXLibrary.facebookLogin_PT;
							goto IL_74F;
						}
					}
				}
				else if (languageIdent == "de")
				{
					this.btnLoginFB.ImageNorm = GFXLibrary.facebookLogin_DE;
					goto IL_74F;
				}
			}
			this.btnLoginFB.ImageNorm = GFXLibrary.facebookLogin_EN;
			IL_74F:
			this.btnLoginFB.OverBrighten = true;
			this.btnLoginFB.MoveOnClick = true;
			this.btnLoginFB.Enabled = false;
			this.btnLoginFB.Position = new Point(4 + this.btnLogin.Image.Width + 4, this.lblConnectionInfo.Y + this.lblConnectionInfo.Height + 4);
			this.lblLoginError.Position = new Point(4, this.btnLoginFB.Y + this.btnLoginFB.Height);
			this.btnLoginFB.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnLoginFB_Click), "ProfileLoginWindow_login");
			this.txtEmail.KeyPress += this.txtEmail_KeyPress;
			this.txtPassword.KeyPress += this.txtEmail_KeyPress;
			this.LoginPanelControls_LoggedOut.addControl(this.lblEmail);
			this.LoginPanelControls_LoggedOut.Controls.Add(this.txtEmail);
			this.LoginPanelControls_LoggedOut.addControl(this.lblEmailSteam);
			if (Program.steamInstall && Program.steamActive && Program.kingdomsAccountFound)
			{
				this.txtEmail.Visible = false;
				this.lblEmailSteam.Visible = true;
				this.lblEmailSteam.Text = Program.steamEmail;
				this.btnLoginFB.Visible = false;
			}
			else if (Program.steamInstall && Program.steamActive && !Program.kingdomsAccountFound)
			{
				this.txtEmail.Visible = false;
				this.lblEmailSteam.Visible = true;
				this.delayedCreateUserOpen = true;
				this.btnLoginFB.Visible = false;
			}
			else if (Program.aeriaInstall || Program.bigpointInstall)
			{
				this.txtEmail.Visible = false;
				this.lblEmail.Visible = false;
				this.txtPassword.Visible = false;
				this.lblPassword.Visible = false;
				this.btnLogin.Visible = false;
				this.btnLoginFB.Visible = false;
			}
			else if (Program.winStore && !Program.mySettings.hasLoggedIn())
			{
				this.delayedCreateUserOpen = true;
			}
			if (Program.bigpointPartnerInstall)
			{
				this.txtEmail.Visible = false;
				this.lblEmail.Visible = false;
				this.txtPassword.Visible = false;
				this.lblPassword.Visible = false;
				this.btnLogin.Visible = true;
				this.btnLoginFB.Visible = false;
				this.btnLogin.Position = new Point(84, this.txtPassword.Bottom + 4 - 30);
				this.bp2_loginMode = 0;
			}
			this.LoginPanelControls_LoggedOut.addControl(this.lblPassword);
			this.LoginPanelControls_LoggedOut.Controls.Add(this.txtPassword);
			this.LoginPanelControls_LoggedOut.addControl(this.btnLogin);
			this.LoginPanelControls_LoggedOut.addControl(this.btnLoginFB);
			this.LoginPanelControls_LoggedOut.addControl(this.lblLoginError);
			this.LoginPanelControls_LoggedOut.Size = this.pnlLogin.Size;
			this.LoginPanelControls_LoggedOut.Visible = true;
			this.pnlLogin.Controls.Add(this.LoginPanelControls_LoggedOut);
			this.LoginPanelControls_LoggedIn = new CustomSelfDrawPanel();
			this.LoginPanelControls_LoggedIn.AutoScaleMode = AutoScaleMode.None;
			this.LoginPanelControls_LoggedIn.forceStyle();
			this.LoginPanelControls_LoggedIn.Size = this.pnlLogin.Size;
			this.btnClientLogout = new CustomSelfDrawPanel.CSDImage();
			this.allButtons.Add(this.btnClientLogout);
			this.btnClientLogout.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnClientLogout_Click), "ProfileLoginWindow_logout");
			this.btnClientLogout.setMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.logoutOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.logoutOut));
			this.btnClientLogout.Image = this.LogoutImage;
			this.btnClientLogout.Width = this.btnClientLogout.Image.Width;
			this.btnClientLogout.Height = this.btnClientLogout.Image.Height;
			if (!Program.steamActive && !Program.aeriaInstall && !Program.gamersFirstInstall && !Program.arcInstall && !Program.bigpointInstall)
			{
				this.LoginPanelControls_LoggedIn.addControl(this.btnClientLogout);
			}
			this.pnlLogin.Controls.Add(this.LoginPanelControls_LoggedIn);
			this.btnShieldDesigner = new CustomSelfDrawPanel.CSDImage();
			this.allButtons.Add(this.btnShieldDesigner);
			this.lblUsername = new CustomSelfDrawPanel.CSDImage();
			this.LoginPanelControls_LoggedIn.addControl(this.btnShieldDesigner);
			this.LoginPanelControls_LoggedIn.addControl(this.lblUsername);
			this.btnShieldDesigner.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.LoadShieldDesigner), "ProfileLoginWindow_shield_designer");
			this.btnClientLogout.Y = this.pnlTabs.Height - 29;
			this.btnClientLogout.X = this.LoginPanelControls_LoggedIn.Width - this.btnClientLogout.Width - 4;
			this.lblUsername.X = 4;
			this.lblUsername.Y = this.btnClientLogout.Y;
			this.WorldsPanelcontrols_LoggedOut = new CustomSelfDrawPanel();
			this.WorldsPanelcontrols_LoggedOut.AutoScaleMode = AutoScaleMode.None;
			this.WorldsPanelcontrols_LoggedOut.forceStyle();
			this.WorldsPanelcontrols_LoggedOut.Size = this.pnlWorlds.Size;
			this.lblWorldsOfflineError = new CustomSelfDrawPanel.CSDLabel();
			this.lblWorldsOfflineError.Color = global::ARGBColors.Red;
			this.WorldsPanelcontrols_LoggedOut.addControl(this.lblWorldsOfflineError);
			this.WorldsPanelcontrols_LoggedOut.Visible = false;
			this.pnlWorlds.Controls.Add(this.WorldsPanelcontrols_LoggedOut);
			this.WorldsPanelcontrols_LoggedIn = new CustomSelfDrawPanel();
			this.WorldsPanelcontrols_LoggedIn.forceStyle();
			this.WorldsPanelcontrols_LoggedIn.AutoScaleMode = AutoScaleMode.None;
			this.WorldsPanelcontrols_LoggedIn.Size = this.pnlWorlds.Size;
			this.lblWorldsOnlineError = new CustomSelfDrawPanel.CSDLabel();
			this.lblWorldsOnlineError.Color = global::ARGBColors.Red;
			this.WorldsPanelcontrols_LoggedIn.addControl(this.lblWorldsOnlineError);
			this.WorldsPanelcontrols_LoggedIn.Visible = false;
			this.pnlWorlds.Controls.Add(this.WorldsPanelcontrols_LoggedIn);
			this.BrowserTabsControls = new CustomSelfDrawPanel();
			this.BrowserTabsControls.forceStyle();
			this.BrowserTabsControls.AutoScaleMode = AutoScaleMode.None;
			this.BrowserTabsControls.Size = this.pnlTabs.Size;
			this.pnlTabs.Controls.Add(this.BrowserTabsControls);
			this.btnExit.GotFocus += this.btnExit_GotFocus;
			if (Program.mySettings.Username.Trim().Length > 0)
			{
				this.ignoreEmailChange = true;
				this.txtEmail.Text = Program.mySettings.Username;
				this.ignoreEmailChange = false;
				if (Program.steamActive)
				{
					this.lblEmailSteam.Text = Program.steamEmail;
					this.txtPassword.Visible = false;
					this.lblPassword.Visible = false;
					this.btnLogin.Visible = false;
					this.btnLoginFB.Visible = false;
				}
				this.txtPassword.Focus();
			}
			else
			{
				this.txtEmail.Focus();
			}
			this.LoginPanelControls_Feedback = new CustomSelfDrawPanel();
			this.LoginPanelControls_Feedback.forceStyle();
			this.LoginPanelControls_Feedback.Location = new Point(0, 0);
			this.LoginPanelControls_Feedback.AutoScaleMode = AutoScaleMode.None;
			this.LoginPanelControls_Feedback.Size = this.pnlFeedback.Size;
			this.feedbackProgressArea = new CustomSelfDrawPanel.CSDArea();
			this.feedbackProgressArea.Size = this.LoginPanelControls_Feedback.Size;
			this.LoginPanelControls_Feedback.addControl(this.feedbackProgressArea);
			this.feedbackProgress = new CustomSelfDrawPanel.CSDFill();
			this.feedbackProgress.FillColor = Color.FromArgb(255, 182, 0);
			this.feedbackProgress.Size = new Size(0, this.pnlFeedback.Height);
			this.feedbackProgressArea.addControl(this.feedbackProgress);
			this.feedbackLine = new CustomSelfDrawPanel.CSDLine();
			this.feedbackLine.Position = new Point(0, 0);
			this.feedbackLine.Size = new Size(this.pnlFeedback.Width, 0);
			this.feedbackLine.LineColor = global::ARGBColors.Black;
			this.feedbackProgressArea.addControl(this.feedbackLine);
			this.exitButton = new CustomSelfDrawPanel.CSDImage();
			this.allButtons.Add(this.exitButton);
			this.exitButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnExit_Click), "ProfileLoginWindow_exit");
			this.exitButton.setMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.exitOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.exitOut));
			this.exitButton.Image = this.ExitImage;
			this.exitButton.Width = this.exitButton.Image.Width;
			this.exitButton.Height = this.exitButton.Image.Height;
			this.exitButton.Position = new Point(823, 5);
			this.feedbackProgressArea.addControl(this.exitButton);
			this.cancelButton = new CustomSelfDrawPanel.CSDImage();
			this.cancelButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.cancelClick), "ProfileLoginWindow_cancel");
			this.cancelButton.setMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.cancelOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.cancelOut));
			this.cancelButton.Image = this.CancelImage;
			this.cancelButton.Width = this.cancelButton.Image.Width;
			this.cancelButton.Height = this.cancelButton.Image.Height;
			this.cancelButton.Position = new Point(4, 5);
			this.cancelButton.Visible = false;
			this.feedbackProgressArea.addControl(this.cancelButton);
			this.lblRetrieving = new CustomSelfDrawPanel.CSDLabel();
			this.lblRetrieving.Text = "";
			this.lblRetrieving.Position = new Point(112, 10);
			this.lblRetrieving.Size = new Size(600, 20);
			this.lblRetrieving.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.lblRetrieving.Color = global::ARGBColors.Black;
			this.lblRetrieving.Visible = false;
			this.Text = this.defaultWindowTitle;
			this.feedbackProgressArea.addControl(this.lblRetrieving);
			this.lblVersion = new CustomSelfDrawPanel.CSDLabel();
			this.lblVersion.Text = "";
			this.lblVersion.Position = new Point(640, 10);
			this.lblVersion.Size = new Size(168, 20);
			this.lblVersion.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.lblVersion.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.lblVersion.Color = global::ARGBColors.Black;
			this.lblVersion.Visible = false;
			this.feedbackProgressArea.addControl(this.lblVersion);
			this.tandcLabel = new CustomSelfDrawPanel.CSDLabel();
			this.tandcLabel.Text = SK.Text("MENU_TandC", "Terms & Conditions").Replace("&amp;", "&");
			this.tandcLabel.Size = new Size(270, 15);
			this.tandcLabel.Position = new Point(40, 10);
			this.tandcLabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
			this.tandcLabel.Color = global::ARGBColors.Black;
			this.tandcLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.tcClicked));
			this.tandcLabel.setMouseOverDelegate(delegate
			{
				this.tandcLabel.Color = global::ARGBColors.Red;
			}, delegate
			{
				this.tandcLabel.Color = global::ARGBColors.Black;
			});
			this.tandcLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.tandcLabel.Visible = true;
			this.feedbackProgressArea.addControl(this.tandcLabel);
			this.gameRulesLabel = new CustomSelfDrawPanel.CSDLabel();
			this.gameRulesLabel.Text = SK.Text("MENU_Game_Rules", "Game Rules");
			this.gameRulesLabel.Size = new Size(300, 15);
			if (Program.mySettings.languageIdent == "de")
			{
				this.gameRulesLabel.Position = new Point(253, 10);
			}
			else
			{
				this.gameRulesLabel.Position = new Point(205, 10);
			}
			this.gameRulesLabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
			this.gameRulesLabel.Color = global::ARGBColors.Black;
			this.gameRulesLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.gameRulesClicked));
			this.gameRulesLabel.setMouseOverDelegate(delegate
			{
				this.gameRulesLabel.Color = global::ARGBColors.Red;
			}, delegate
			{
				this.gameRulesLabel.Color = global::ARGBColors.Black;
			});
			this.gameRulesLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.gameRulesLabel.Visible = true;
			this.feedbackProgressArea.addControl(this.gameRulesLabel);
			this.forumLabel = new CustomSelfDrawPanel.CSDLabel();
			this.forumLabel.Text = SK.Text("MENU_Forum", "Forum");
			this.forumLabel.Size = new Size(300, 15);
			this.forumLabel.Position = new Point(370, 10);
			this.forumLabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
			this.forumLabel.Color = global::ARGBColors.Black;
			this.forumLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.forumClicked));
			this.forumLabel.setMouseOverDelegate(delegate
			{
				this.forumLabel.Color = global::ARGBColors.Red;
			}, delegate
			{
				this.forumLabel.Color = global::ARGBColors.Black;
			});
			this.forumLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			if (Program.bigpointInstall || Program.bigpointPartnerInstall)
			{
				this.forumLabel.Visible = false;
			}
			else
			{
				this.forumLabel.Visible = true;
			}
			this.feedbackProgressArea.addControl(this.forumLabel);
			this.supportLabel = new CustomSelfDrawPanel.CSDLabel();
			this.supportLabel.Text = SK.Text("MENU_Support", "Support");
			this.supportLabel.Size = new Size(100, 15);
			this.supportLabel.Position = new Point(535, 10);
			this.supportLabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
			this.supportLabel.Color = global::ARGBColors.Black;
			this.supportLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.supportClicked));
			this.supportLabel.setMouseOverDelegate(delegate
			{
				this.supportLabel.Color = global::ARGBColors.Red;
			}, delegate
			{
				this.supportLabel.Color = global::ARGBColors.Black;
			});
			this.supportLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.supportLabel.Visible = true;
			this.feedbackProgressArea.addControl(this.supportLabel);
			this.pnlFeedback.Controls.Add(this.LoginPanelControls_Feedback);
			this.GreyoutWorlds = this.MakeGreyoutImage(this.pnlWorlds);
			this.GreyoutLogin = this.MakeGreyoutImage(this.pnlLogin);
			this.GreyoutTabs = this.MakeGreyoutImage(this.pnlFeedback);
			if (Program.steamActive)
			{
				this.lblEmail.Visible = false;
				this.lblPassword.Visible = false;
				this.txtPassword.Visible = false;
			}
			if (Program.steamInstall && Program.steamActive && Program.kingdomsAccountFound && !ProfileLoginWindow.successfulAutoLogin)
			{
				this.btnLogin_Click();
			}
			if (Program.gamersFirstInstall || Program.arcInstall)
			{
				this.lblEmail.Visible = false;
				this.lblPassword.Visible = false;
				this.txtPassword.Visible = false;
				this.txtEmail.Visible = false;
				this.btnLogin.Visible = false;
				this.btnLoginFB.Visible = false;
				Program.mySettings.AutoLogin = false;
				if (!ProfileLoginWindow.successfulAutoLogin)
				{
					this.btnLogin_Click();
				}
			}
			if (File.Exists(ControlForm.SettingsFolder + "Password.txt"))
			{
				this.txtPassword.Text = File.ReadAllText(ControlForm.SettingsFolder + "Password.txt");
			}
			string path2 = ControlForm.SettingsFolder + "AutomaticActions.txt";
			if (!File.Exists(path2))
			{
				return;
			}
			string[] array = File.ReadAllLines(path2);
			if (Array.IndexOf<string>(array, "Login") > -1)
			{
				this.btnLogin_Click();
			}
		}

		// Token: 0x06001D66 RID: 7526 RVA: 0x001C91EC File Offset: 0x001C73EC
		private void statusPageClicked()
		{
			try
			{
				new Process
				{
					StartInfo = 
					{
						FileName = "https://slogin.strongholdkingdoms.com/status.php?lang=" + Program.mySettings.languageIdent
					}
				}.Start();
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06001D67 RID: 7527 RVA: 0x000F43C8 File Offset: 0x000F25C8
		private void tcClicked()
		{
			try
			{
				new Process
				{
					StartInfo = 
					{
						FileName = URLs.TermsAndConditions
					}
				}.Start();
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06001D68 RID: 7528 RVA: 0x001C923C File Offset: 0x001C743C
		private void gameRulesClicked()
		{
			try
			{
				new Process
				{
					StartInfo = 
					{
						FileName = URLs.IPSharingPage
					}
				}.Start();
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06001D69 RID: 7529 RVA: 0x001C927C File Offset: 0x001C747C
		private void forumClicked()
		{
			try
			{
				new Process
				{
					StartInfo = 
					{
						FileName = URLs.ForumHomepage
					}
				}.Start();
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06001D6A RID: 7530 RVA: 0x001C92BC File Offset: 0x001C74BC
		private void supportClicked()
		{
			try
			{
				Process process = new Process();
				if (RemoteServices.Instance.UserGuid == Guid.Empty)
				{
					process.StartInfo.FileName = URLs.Supportpage;
				}
				else
				{
					process.StartInfo.FileName = string.Concat(new string[]
					{
						"https://login.strongholdkingdoms.com/support/?u=",
						RemoteServices.Instance.UserGuid.ToString().Replace("-", ""),
						"&s=",
						RemoteServices.Instance.SessionGuid.ToString().Replace("-", ""),
						"&lang=",
						Program.mySettings.languageIdent
					});
				}
				process.Start();
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06001D6B RID: 7531 RVA: 0x0001C8B0 File Offset: 0x0001AAB0
		public void openAeriaPopup()
		{
			this.openAeriaPopup(false);
		}

		// Token: 0x06001D6C RID: 7532 RVA: 0x001C93A8 File Offset: 0x001C75A8
		public void openAeriaPopup(bool logout)
		{
			string text = "https://www.aeriagames.com/dialog/oauth?response_type=code&client_id=";
			string text2 = Program.mySettings.LanguageIdent.ToLower();
			if (text2 != null)
			{
				if (text2 == "fr")
				{
					text += "c855f84df02e095dfc674de414ac912005048e61c&state=login_fr&lang=fr";
					goto IL_99;
				}
				if (text2 == "de")
				{
					text += "8ab4b5d461753ddf4bca8ace798ec5a705048e5a8&state=login_de&lang=de";
					goto IL_99;
				}
				if (text2 == "ru")
				{
					text += "46a58fca1d92ee6eba5245668660db0a05048e6b1&state=login_ru&lang=ru";
					goto IL_99;
				}
				if (text2 == "es")
				{
					text += "34f89db79f7699370f70b91ba0f93960051143200&state=login_es&lang=es";
					goto IL_99;
				}
			}
			text += "bcccf8ff68ac2d79fa9dd659332cf83405048e30a&state=login&lang=en";
			IL_99:
			text += "&theme=api_ignite&redirect_uri=https://login.strongholdkingdoms.com/aeria/login.php";
			AeriaWindow.ShowAeriaLogin(text, "", this, delegate(object sender, AeriaEventArgs e)
			{
				ProfileLoginWindow.AeriaToken = e.token;
			});
		}

		// Token: 0x06001D6D RID: 7533 RVA: 0x0001C8B9 File Offset: 0x0001AAB9
		public void aeriaClose()
		{
			this.btnExit_Click();
		}

		// Token: 0x06001D6E RID: 7534 RVA: 0x0001C8C1 File Offset: 0x0001AAC1
		public void aeriaLogin(string userGUID, string sessionGUID)
		{
			this.txtEmail.Text = userGUID;
			this.txtPassword.Text = sessionGUID;
			this.btnLogin_Click();
		}

		// Token: 0x06001D6F RID: 7535 RVA: 0x0001C8E1 File Offset: 0x0001AAE1
		public void openBigPointPopup()
		{
			this.openBigPointPopup(false);
		}

		// Token: 0x06001D70 RID: 7536 RVA: 0x001C9488 File Offset: 0x001C7688
		public void openBigPointPopup(bool logout)
		{
			string url = "https://login.strongholdkingdoms.com/bigpoint/iframelogin.php?lang=" + Program.mySettings.LanguageIdent.ToLower();
			BigPointWindow.ShowBigPointLogin(url, "", this, delegate(object sender, BigPointEventArgs e)
			{
				ProfileLoginWindow.AeriaToken = e.token;
			});
		}

		// Token: 0x06001D71 RID: 7537 RVA: 0x0001C8B9 File Offset: 0x0001AAB9
		public void bigpointClose()
		{
			this.btnExit_Click();
		}

		// Token: 0x06001D72 RID: 7538 RVA: 0x0001C8C1 File Offset: 0x0001AAC1
		public void bigpointLogin(string userGUID, string sessionGUID)
		{
			this.txtEmail.Text = userGUID;
			this.txtPassword.Text = sessionGUID;
			this.btnLogin_Click();
		}

		// Token: 0x06001D73 RID: 7539 RVA: 0x001C94E0 File Offset: 0x001C76E0
		public void openFacebookPopup()
		{
			string url = "https://login.strongholdkingdoms.com/facebook/index.php?lang=" + Program.mySettings.LanguageIdent.ToLower();
			FacebookWindow.ShowFacebookLogin(url, "", this, delegate(object sender, FacebookEventArgs e)
			{
				ProfileLoginWindow.AeriaToken = e.token;
			});
		}

		// Token: 0x06001D74 RID: 7540 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void FacebookClose()
		{
		}

		// Token: 0x06001D75 RID: 7541 RVA: 0x0001C8EA File Offset: 0x0001AAEA
		public void FacebookLogin(string userGUID, string sessionGUID)
		{
			this.tempFacebookLogin = true;
			this.btnLogin_Click();
			this.tempFacebookLogin = false;
		}

		// Token: 0x06001D76 RID: 7542 RVA: 0x0001C900 File Offset: 0x0001AB00
		private void btnExit_GotFocus(object sender, EventArgs e)
		{
			this.txtPassword.Focus();
		}

		// Token: 0x06001D77 RID: 7543 RVA: 0x0001C90E File Offset: 0x0001AB0E
		private void txtEmail_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Return)
			{
				if (this.btnLogin.Enabled)
				{
					GameEngine.Instance.playInterfaceSound("ProfileLoginWindow_login");
					this.btnLogin_Click();
				}
				e.Handled = true;
			}
		}

		// Token: 0x06001D78 RID: 7544 RVA: 0x0001C94D File Offset: 0x0001AB4D
		private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				if (this.btnLogin.Enabled)
				{
					GameEngine.Instance.playInterfaceSound("ProfileLoginWindow_login");
					this.btnLogin_Click();
				}
				e.Handled = true;
			}
		}

		// Token: 0x06001D79 RID: 7545 RVA: 0x001C9538 File Offset: 0x001C7738
		public void SetUsername()
		{
			this.lblUsername.Image = WebStyleButtonImage.GenerateLabel(200, 25, RemoteServices.Instance.UserName, global::ARGBColors.Black, global::ARGBColors.Transparent);
			this.lblUsername.Width = 200;
			this.lblUsername.Height = 25;
		}

		// Token: 0x06001D7A RID: 7546 RVA: 0x001C9590 File Offset: 0x001C7790
		public void SetShieldImage()
		{
			this.btnShieldDesigner.Image = ProfileLoginWindow.ShieldImage["profile"];
			this.btnShieldDesigner.Width = this.btnShieldDesigner.Image.Width;
			this.btnShieldDesigner.Height = this.btnShieldDesigner.Image.Height;
			this.btnShieldDesigner.X = (this.pnlLogin.Width - this.btnShieldDesigner.Width) / 2;
			this.btnShieldDesigner.Y = this.pnlTabs.Bottom + 8;
			this.btnShieldDesigner.CustomTooltipID = 4015;
		}

		// Token: 0x06001D7B RID: 7547 RVA: 0x001C963C File Offset: 0x001C783C
		public void LoadShieldImages()
		{
			foreach (string text in ProfileLoginWindow.ShieldURL.Keys)
			{
				try
				{
					if (text == "profile")
					{
						if (ProfileLoginWindow.ShieldURL[text].ToLowerInvariant() != "/shield/render/profile_coa_placeholder.png")
						{
							char[] separator = new char[]
							{
								'_',
								'.'
							};
							string[] array = ProfileLoginWindow.ShieldURL[text].ToLowerInvariant().Split(separator);
							GameEngine.Instance.World.downloadPlayerShield(array[1], new ShieldFactory.AsyncDelegate(this.shieldDownloaded));
							ProfileLoginWindow.ShieldImage[text] = GFXLibrary.dummy;
						}
						else
						{
							ProfileLoginWindow.ShieldImage[text] = GameEngine.Instance.World.getDummyShield(140, 156);
						}
					}
					else
					{
						ProfileLoginWindow.ShieldImage[text] = GameEngine.Instance.World.getDummyShield(140, 156);
					}
				}
				catch (Exception)
				{
					ProfileLoginWindow.ShieldImage[text] = GameEngine.Instance.World.getDummyShield(140, 156);
				}
			}
		}

		// Token: 0x06001D7C RID: 7548 RVA: 0x001C97B0 File Offset: 0x001C79B0
		private void shieldDownloaded()
		{
			if (ShieldFactory.LastErrorString.Length <= 0)
			{
				ProfileLoginWindow.ShieldImage["profile"] = GameEngine.Instance.World.getPlayerShieldImage(140, 156);
			}
			if (ProfileLoginWindow.ShieldImage["profile"] == null)
			{
				ProfileLoginWindow.ShieldImage["profile"] = GameEngine.Instance.World.getDummyShield(140, 156);
			}
			if (this.btnShieldDesigner != null)
			{
				this.SetShieldImage();
				this.btnShieldDesigner.invalidate();
			}
		}

		// Token: 0x06001D7D RID: 7549 RVA: 0x001C9844 File Offset: 0x001C7A44
		private void RespCallback(IAsyncResult ar)
		{
			try
			{
				ProfileLoginWindow.RequestState requestState = (ProfileLoginWindow.RequestState)ar.AsyncState;
				WebRequest req = requestState.req;
				WebResponse webResponse = req.EndGetResponse(ar);
				Image value = Image.FromStream(webResponse.GetResponseStream());
				ProfileLoginWindow.ShieldImage["profile"] = value;
			}
			catch (Exception)
			{
				ProfileLoginWindow.ShieldImage["profile"] = GFXLibrary.LoginShieldPlaceholder;
			}
			if (this.btnShieldDesigner != null)
			{
				this.SetShieldImage();
				this.btnShieldDesigner.invalidate();
			}
		}

		// Token: 0x06001D7E RID: 7550 RVA: 0x001C98D0 File Offset: 0x001C7AD0
		public void LoadShieldDesigner()
		{
			Process.Start(string.Concat(new string[]
			{
				URLs.shieldDesignerURL,
				"?webtoken=",
				RemoteServices.Instance.WebToken,
				"&lang=",
				Program.mySettings.LanguageIdent.ToLower()
			}));
		}

		// Token: 0x06001D7F RID: 7551 RVA: 0x0001C982 File Offset: 0x0001AB82
		public void loginOver()
		{
			this.btnLogin.Image = this.LoginImageOver;
		}

		// Token: 0x06001D80 RID: 7552 RVA: 0x0001C995 File Offset: 0x0001AB95
		public void loginOut()
		{
			this.btnLogin.Image = this.LoginImage;
		}

		// Token: 0x06001D81 RID: 7553 RVA: 0x0001C9A8 File Offset: 0x0001ABA8
		public void logoutOver()
		{
			this.btnClientLogout.Image = this.LogoutImageOver;
		}

		// Token: 0x06001D82 RID: 7554 RVA: 0x0001C9BB File Offset: 0x0001ABBB
		public void logoutOut()
		{
			this.btnClientLogout.Image = this.LogoutImage;
		}

		// Token: 0x06001D83 RID: 7555 RVA: 0x0001C9CE File Offset: 0x0001ABCE
		public void exitOver()
		{
			this.exitButton.Image = this.ExitImageOver;
		}

		// Token: 0x06001D84 RID: 7556 RVA: 0x0001C9E1 File Offset: 0x0001ABE1
		public void exitOut()
		{
			this.exitButton.Image = this.ExitImage;
		}

		// Token: 0x06001D85 RID: 7557 RVA: 0x0001C9F4 File Offset: 0x0001ABF4
		public void cancelOver()
		{
			this.cancelButton.Image = this.CancelImageOver;
		}

		// Token: 0x06001D86 RID: 7558 RVA: 0x0001CA07 File Offset: 0x0001AC07
		public void cancelOut()
		{
			this.cancelButton.Image = this.CancelImage;
		}

		// Token: 0x06001D87 RID: 7559 RVA: 0x001C9928 File Offset: 0x001C7B28
		public void ShowTabs()
		{
			this.BrowserTabsControls.clearControls();
			bool flag = this.isPlayerLoggedIn();
			int num = 8;
			int y = this.BrowserTabsControls.Height - 29;
			CustomSelfDrawPanel.CSDImage btnNews = new CustomSelfDrawPanel.CSDImage();
			this.allButtons.Add(btnNews);
			btnNews.Image = this.NewsImage;
			btnNews.Height = btnNews.Image.Height;
			btnNews.Width = btnNews.Image.Width;
			btnNews.X = num;
			btnNews.Y = y;
			this.BrowserTabsControls.addControl(btnNews);
			num += btnNews.Width + 2;
			btnNews.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnNews_Click), "ProfileLoginWindow_news");
			btnNews.setMouseOverDelegate(delegate
			{
				btnNews.Image = this.NewsImageOver;
			}, delegate
			{
				btnNews.Image = this.NewsImage;
			});
			if (!Program.bigpointPartnerInstall)
			{
				if (Program.mySettings.LanguageIdent == "ru")
				{
					this.imgSHKRu.ImageNorm = GFXLibrary.vk;
					this.imgSHKRu.OverBrighten = true;
					this.imgSHKRu.Size = new Size(32, 32);
					this.imgSHKRu.Position = new Point(268, 5);
					this.imgSHKRu.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.shkruClick));
					this.BrowserTabsControls.addControl(this.imgSHKRu);
					this.imgTwitter.ImageNorm = GFXLibrary.twitter;
					this.imgTwitter.OverBrighten = true;
					this.imgTwitter.Size = new Size(32, 32);
					this.imgTwitter.Position = new Point(305, 5);
					this.imgTwitter.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.twitterClick));
					this.BrowserTabsControls.addControl(this.imgTwitter);
					this.imgYoutube.ImageNorm = GFXLibrary.youtube;
					this.imgYoutube.OverBrighten = true;
					this.imgYoutube.Position = new Point(342, 5);
					this.imgYoutube.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.youtubeClick));
					this.BrowserTabsControls.addControl(this.imgYoutube);
				}
				else
				{
					this.imgTwitter.ImageNorm = GFXLibrary.twitter;
					this.imgTwitter.OverBrighten = true;
					this.imgTwitter.Size = new Size(32, 32);
					this.imgTwitter.Position = new Point(268, 5);
					this.imgTwitter.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.twitterClick));
					this.BrowserTabsControls.addControl(this.imgTwitter);
					this.imgFacebook.ImageNorm = GFXLibrary.facebook;
					this.imgFacebook.OverBrighten = true;
					this.imgFacebook.Size = new Size(32, 32);
					this.imgFacebook.Position = new Point(305, 5);
					this.imgFacebook.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.facebookClick));
					this.BrowserTabsControls.addControl(this.imgFacebook);
					this.imgYoutube.ImageNorm = GFXLibrary.youtube;
					this.imgYoutube.OverBrighten = true;
					this.imgYoutube.Position = new Point(342, 5);
					this.imgYoutube.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.youtubeClick));
					this.BrowserTabsControls.addControl(this.imgYoutube);
				}
			}
			if (flag)
			{
				CustomSelfDrawPanel.CSDImage btnAccountDetails = new CustomSelfDrawPanel.CSDImage();
				this.allButtons.Add(btnAccountDetails);
				btnAccountDetails.Image = this.AccountImage;
				btnAccountDetails.Height = btnAccountDetails.Image.Height;
				btnAccountDetails.Width = btnAccountDetails.Image.Width;
				btnAccountDetails.X = num;
				btnAccountDetails.Y = y;
				this.BrowserTabsControls.addControl(btnAccountDetails);
				num += btnAccountDetails.Width + 2;
				btnAccountDetails.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnAccountDetails_Click), "ProfileLoginWindow_account_details");
				btnAccountDetails.setMouseOverDelegate(delegate
				{
					btnAccountDetails.Image = this.AccountImageOver;
				}, delegate
				{
					btnAccountDetails.Image = this.AccountImage;
				});
				CustomSelfDrawPanel.CSDImage btnCreateAccount = new CustomSelfDrawPanel.CSDImage();
				this.allButtons.Add(btnCreateAccount);
				btnCreateAccount.Image = this.OptionsImage;
				btnCreateAccount.X = 400;
				btnCreateAccount.Height = btnCreateAccount.Image.Height;
				btnCreateAccount.Width = btnCreateAccount.Image.Width;
				btnCreateAccount.Y = y;
				this.BrowserTabsControls.addControl(btnCreateAccount);
				btnCreateAccount.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.options_Click), "ProfileLoginWindow_create_account");
				btnCreateAccount.setMouseOverDelegate(delegate
				{
					btnCreateAccount.Image = this.OptionsImageOver;
				}, delegate
				{
					btnCreateAccount.Image = this.OptionsImage;
				});
				return;
			}
			if (!Program.steamActive && !Program.aeriaInstall && !Program.gamersFirstInstall && !Program.arcInstall && !Program.bigpointInstall && !Program.bigpointPartnerInstall)
			{
				CustomSelfDrawPanel.CSDImage btnCreateAccount2 = new CustomSelfDrawPanel.CSDImage();
				this.allButtons.Add(btnCreateAccount2);
				if (!Program.mySettings.hasLoggedIn() && !Program.bigpointInstall && !Program.aeriaInstall && !Program.bigpointPartnerInstall)
				{
					btnCreateAccount2.Image = this.CreateAccountImage;
				}
				else
				{
					btnCreateAccount2.Image = this.CreateAccountImage2;
				}
				btnCreateAccount2.X = 400;
				btnCreateAccount2.Height = btnCreateAccount2.Image.Height;
				btnCreateAccount2.Width = btnCreateAccount2.Image.Width;
				btnCreateAccount2.Y = y;
				this.BrowserTabsControls.addControl(btnCreateAccount2);
				btnCreateAccount2.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnCreateAccount_Click), "ProfileLoginWindow_create_account");
				btnCreateAccount2.setMouseOverDelegate(delegate
				{
					if (!Program.mySettings.hasLoggedIn() && !Program.bigpointInstall && !Program.aeriaInstall && !Program.bigpointPartnerInstall)
					{
						btnCreateAccount2.Image = this.CreateAccountImageOver;
						return;
					}
					btnCreateAccount2.Image = this.CreateAccountImageOver2;
				}, delegate
				{
					if (!Program.mySettings.hasLoggedIn() && !Program.bigpointInstall && !Program.aeriaInstall && !Program.bigpointPartnerInstall)
					{
						btnCreateAccount2.Image = this.CreateAccountImage;
						return;
					}
					btnCreateAccount2.Image = this.CreateAccountImage2;
				});
			}
			if (!Program.bigpointInstall && !Program.aeriaInstall && !Program.gamersFirstInstall && !Program.bigpointPartnerInstall && !Program.arcInstall)
			{
				CustomSelfDrawPanel.CSDImage btnForgottenPassword = new CustomSelfDrawPanel.CSDImage();
				this.allButtons.Add(btnForgottenPassword);
				btnForgottenPassword.Image = this.ForgottenImage;
				btnForgottenPassword.Height = btnForgottenPassword.Image.Height;
				btnForgottenPassword.Width = btnForgottenPassword.Image.Width;
				btnForgottenPassword.X = num;
				btnForgottenPassword.Y = y;
				this.BrowserTabsControls.addControl(btnForgottenPassword);
				num += btnForgottenPassword.Width + 2;
				btnForgottenPassword.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnForgotten_Click), "ProfileLoginWindow_forgotten_password");
				btnForgottenPassword.setMouseOverDelegate(delegate
				{
					btnForgottenPassword.Image = this.ForgottenImageOver;
				}, delegate
				{
					btnForgottenPassword.Image = this.forgottenImage;
				});
			}
		}

		// Token: 0x06001D88 RID: 7560 RVA: 0x001CA158 File Offset: 0x001C8358
		private void btnAccountDetails_Click()
		{
			this.EnablePanels(false);
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary.Add("webtoken", RemoteServices.Instance.WebToken);
			dictionary.Add("ClientLanguage", Program.mySettings.LanguageIdent.ToLower());
			dictionary.Add("NewLoginScreen", "1");
			this.geckoWebBrowser1.Navigate(new Uri(URLs.AccountMainPage), dictionary);
		}

		// Token: 0x06001D89 RID: 7561 RVA: 0x0001CA1A File Offset: 0x0001AC1A
		private void options_Click()
		{
			GameEngine.Instance.playInterfaceSound("Options_open");
			OptionsPopup.openSettingsLogin();
		}

		// Token: 0x06001D8A RID: 7562 RVA: 0x001CA1C8 File Offset: 0x001C83C8
		private void btnCreateAccount_Click()
		{
			if (!Program.mySettings.hasLoggedIn() && !Program.bigpointInstall && !Program.aeriaInstall && !Program.bigpointPartnerInstall)
			{
				this.ShowCreateUserForm();
				return;
			}
			if (Program.mySettings.LanguageIdent == "de")
			{
				new Process
				{
					StartInfo = 
					{
						FileName = "https://de.strongholdkingdoms.com/"
					}
				}.Start();
				return;
			}
			if (Program.mySettings.LanguageIdent == "fr")
			{
				new Process
				{
					StartInfo = 
					{
						FileName = "https://fr.strongholdkingdoms.com/"
					}
				}.Start();
				return;
			}
			if (Program.mySettings.LanguageIdent == "ru")
			{
				new Process
				{
					StartInfo = 
					{
						FileName = "https://ru.strongholdkingdoms.com"
					}
				}.Start();
				return;
			}
			if (Program.mySettings.LanguageIdent == "es")
			{
				new Process
				{
					StartInfo = 
					{
						FileName = "https://es.strongholdkingdoms.com"
					}
				}.Start();
				return;
			}
			if (Program.mySettings.LanguageIdent == "pl")
			{
				new Process
				{
					StartInfo = 
					{
						FileName = "https://pl.strongholdkingdoms.com"
					}
				}.Start();
				return;
			}
			if (Program.mySettings.LanguageIdent == "tr")
			{
				new Process
				{
					StartInfo = 
					{
						FileName = "https://tr.strongholdkingdoms.com"
					}
				}.Start();
				return;
			}
			if (Program.mySettings.LanguageIdent == "it")
			{
				new Process
				{
					StartInfo = 
					{
						FileName = "https://it.strongholdkingdoms.com"
					}
				}.Start();
				return;
			}
			if (Program.mySettings.LanguageIdent == "pt")
			{
				new Process
				{
					StartInfo = 
					{
						FileName = "https://pt.strongholdkingdoms.com"
					}
				}.Start();
				return;
			}
			new Process
			{
				StartInfo = 
				{
					FileName = "https://www.strongholdkingdoms.com"
				}
			}.Start();
		}

		// Token: 0x06001D8B RID: 7563 RVA: 0x0001CA30 File Offset: 0x0001AC30
		private void btnForgotten_Click()
		{
			this.EnablePanels(false);
			this.geckoWebBrowser1.Navigate(URLs.ForgottenPasswordLink + "?lang=" + Program.mySettings.LanguageIdent.ToLower());
		}

		// Token: 0x06001D8C RID: 7564 RVA: 0x0001CA62 File Offset: 0x0001AC62
		private void btnNews_Click()
		{
			this.EnablePanels(false);
			this.geckoWebBrowser1.Navigate(URLs.NewsMainPage);
		}

		// Token: 0x06001D8D RID: 7565 RVA: 0x0001CA7B File Offset: 0x0001AC7B
		public void ShowCreateUserForm()
		{
			InterfaceMgr.Instance.openCreatePopupWindow();
		}

		// Token: 0x06001D8E RID: 7566 RVA: 0x0001CA88 File Offset: 0x0001AC88
		public void ShowWorldSelect()
		{
			InterfaceMgr.Instance.openWorldSelectPopupWindow();
		}

		// Token: 0x06001D8F RID: 7567 RVA: 0x001CA3CC File Offset: 0x001C85CC
		public void EnablePanels(bool enabled)
		{
			if (this.lblRetrieving == null)
			{
				return;
			}
			if (this.lblRetrieving.Visible)
			{
				enabled = false;
			}
			this.pnlWorlds.Enabled = enabled;
			this.pnlLogin.Enabled = enabled;
			this.pnlTabs.Enabled = enabled;
			this.btnLogin.Enabled = enabled;
			this.btnLoginFB.Enabled = enabled;
			this.btnClientLogout.Enabled = enabled;
			foreach (CustomSelfDrawPanel.CSDControl csdcontrol in this.allButtons)
			{
				if (csdcontrol != null)
				{
					csdcontrol.Enabled = enabled;
				}
			}
			if (this.isPlayerLoggedIn())
			{
				this.WorldsPanelcontrols_LoggedIn.removeControl(this.GreyoutWorlds);
				this.LoginPanelControls_LoggedIn.removeControl(this.GreyoutLogin);
				if (!enabled)
				{
					this.WorldsPanelcontrols_LoggedIn.addControl(this.GreyoutWorlds);
					this.LoginPanelControls_LoggedIn.addControl(this.GreyoutLogin);
				}
				this.WorldsPanelcontrols_LoggedIn.Invalidate();
				this.LoginPanelControls_LoggedIn.Invalidate();
			}
			else
			{
				this.WorldsPanelcontrols_LoggedOut.removeControl(this.GreyoutWorlds);
				this.LoginPanelControls_LoggedOut.removeControl(this.GreyoutLogin);
				if (!enabled)
				{
					this.WorldsPanelcontrols_LoggedOut.addControl(this.GreyoutWorlds);
					this.LoginPanelControls_LoggedOut.addControl(this.GreyoutLogin);
				}
				this.WorldsPanelcontrols_LoggedOut.Invalidate();
				this.LoginPanelControls_LoggedOut.Invalidate();
			}
			this.pnlWorlds.Invalidate();
			this.pnlFeedback.Invalidate();
			this.pnlTabs.Invalidate();
			this.pnlLogin.Invalidate();
		}

		// Token: 0x06001D90 RID: 7568 RVA: 0x001CA574 File Offset: 0x001C8774
		public void JoinGameworld(int? playing, int? firstworld, int? worldid, string worldName)
		{
			if (playing != null && !(playing != 0))
			{
				ProfileLoginWindow.LastNumberOfWorldsPlaying++;
			}
			Program.mySettings.LastWorldID = worldid.Value;
			this.lastWorldLoggedIn = Program.mySettings.LastWorldID;
			Program.mySettings.Save();
			this.lblRetrieving.Text = SK.Text("ProfileLogin_Connecting", "Connecting To : ") + worldName;
			this.lblRetrieving.Visible = true;
			this.tandcLabel.Visible = false;
			this.gameRulesLabel.Visible = false;
			this.forumLabel.Visible = false;
			this.supportLabel.Visible = false;
			this.feedbackProgress.Size = new Size(Math.Min(this.pnlFeedback.Width / 11, this.pnlFeedback.Width), this.pnlFeedback.Height);
			this.feedbackProgressArea.invalidate();
			this.Text = this.defaultWindowTitle + " - " + this.lblRetrieving.Text;
			this.cancelButton.Visible = true;
			XmlRpcAuthProvider xmlRpcAuthProvider = XmlRpcAuthProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressLogin, URLs.ProfileServerPort, URLs.ProfilePath);
			xmlRpcAuthProvider.ChooseWorld(new XmlRpcAuthRequest(RemoteServices.Instance.UserGuid.ToString().Replace("-", ""), "", "", "", RemoteServices.Instance.SessionGuid.ToString().Replace("-", ""), "", "", "", worldid, firstworld, playing)
			{
				Culture = Program.syslang + ";" + Program.mySettings.LanguageIdent.ToLower()
			}, new AuthEndResponseDelegate(this.JoinGameworldCallback), this);
		}

		// Token: 0x06001D91 RID: 7569 RVA: 0x001CA76C File Offset: 0x001C896C
		private void JoinGameworldCallback(IAuthProvider sender, IAuthResponse response)
		{
			int? successCode = response.SuccessCode;
			int num = 1;
			if (!(successCode.GetValueOrDefault() == num & successCode != null))
			{
				this.lblRetrieving.Visible = false;
				this.tandcLabel.Visible = true;
				this.gameRulesLabel.Visible = true;
				if (Program.bigpointInstall || Program.bigpointPartnerInstall)
				{
					this.forumLabel.Visible = false;
				}
				else
				{
					this.forumLabel.Visible = true;
				}
				this.supportLabel.Visible = true;
				this.feedbackProgress.Size = new Size(Math.Min(this.pnlFeedback.Width / 11, this.pnlFeedback.Width), this.pnlFeedback.Height);
				this.feedbackProgressArea.invalidate();
				this.Text = this.defaultWindowTitle;
				this.cancelButton.Visible = false;
				MessageBox.Show("ERROR: " + response.Message);
				this.EnablePanels(true);
				return;
			}
			foreach (WorldInfo worldInfo in ProfileLoginWindow.WorldList)
			{
				if (worldInfo.KingdomsWorldID == this.lastWorldLoggedIn)
				{
					if (!worldInfo.Playing)
					{
						worldInfo.Playing = true;
					}
					GameEngine.Instance.World.contestStartTime = worldInfo.ContestStartTime;
					GameEngine.Instance.World.contestEndTime = worldInfo.ContestEndTime;
					GameEngine.Instance.World.contestName = worldInfo.ContestName;
					GameEngine.Instance.World.contestDescription = worldInfo.ContestDescription;
					GameEngine.Instance.World.contestID = worldInfo.ContestID;
				}
			}
			string admin = string.Empty;
			if (this.AdminGUID != null && this.AdminGUID.Length > 0)
			{
				admin = this.AdminGUID;
			}
			if (!Program.kingdomsAccountFound)
			{
				this.LoginBeta(RemoteServices.Instance.UserGuid.ToString().Replace("-", ""), RemoteServices.Instance.SessionGuid.ToString().Replace("-", ""), this.txtEmail.Text, admin);
				return;
			}
			this.LoginBeta(RemoteServices.Instance.UserGuid.ToString().Replace("-", ""), RemoteServices.Instance.SessionGuid.ToString().Replace("-", ""), Program.steamEmail, admin);
		}

		// Token: 0x06001D92 RID: 7570 RVA: 0x001CAA28 File Offset: 0x001C8C28
		public void BuildOnlineWorldList(List<WorldInfo> list)
		{
			if (this.loggedInWorldControls != null && this.loggedInWorldControls.Count > 0)
			{
				foreach (CustomSelfDrawPanel.CSDControl control in this.loggedInWorldControls)
				{
					this.WorldsPanelcontrols_LoggedIn.removeControl(control);
				}
				this.loggedInWorldControls.Clear();
			}
			else if (this.loggedInWorldControls == null)
			{
				this.loggedInWorldControls = new List<CustomSelfDrawPanel.CSDControl>();
			}
			int num = Program.mySettings.LastWorldID;
			string text = SK.Text("LOGIN_LastWorld", "Last World Played");
			int num2 = 0;
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].Playing)
				{
					num2++;
				}
			}
			int num3 = -1;
			if (num2 == 0)
			{
				if (this.chkAutoLogin != null)
				{
					this.chkAutoLogin.Checked = false;
				}
				Program.mySettings.AutoLogin = false;
				text = SK.Text("LOGIN_Recommended_Server", "Recommended World");
				bool flag = false;
				int num4 = 0;
				int num5 = num;
				for (int j = 0; j < list.Count; j++)
				{
					if (list[j].Supportculture == Program.mySettings.LanguageIdent)
					{
						flag = true;
					}
					if (list[j].NewWorld)
					{
						num4++;
						num5 = list[j].KingdomsWorldID;
						if ((list[j].KingdomsWorldID >= 700 && list[j].KingdomsWorldID < 799) || (list[j].KingdomsWorldID >= 1200 && list[j].KingdomsWorldID < 1299))
						{
							num3 = list[j].KingdomsWorldID;
						}
					}
				}
				if (num4 == 1)
				{
					num = num5;
				}
				else
				{
					bool flag2 = false;
					string text2 = Program.mySettings.LanguageIdent;
					if (!flag)
					{
						text2 = "en";
					}
					bool flag3 = false;
					int num6 = -1;
					if (text2 != null)
					{
						if (!(text2 == "en"))
						{
							if (!(text2 == "es"))
							{
								if (text2 == "pt")
								{
									uint num7 = 0U;
									try
									{
										num7 = (uint)ProfileLoginWindow.GetSystemDefaultLangID();
									}
									catch (Exception)
									{
									}
									uint num8 = num7;
									if (num8 == 2070U)
									{
										text2 = "es";
									}
									else
									{
										bool flag4 = false;
										for (int k = 0; k < list.Count; k++)
										{
											if (list[k].Supportculture == "pt")
											{
												flag4 = true;
												break;
											}
										}
										if (!flag4)
										{
											text2 = "es";
										}
									}
								}
							}
							else
							{
								uint num9 = 0U;
								try
								{
									num9 = (uint)ProfileLoginWindow.GetSystemDefaultLangID();
								}
								catch (Exception)
								{
								}
								if (num9 <= 11274U)
								{
									if (num9 <= 6154U)
									{
										if (num9 <= 4106U)
										{
											if (num9 != 2058U && num9 != 4106U)
											{
												goto IL_4C3;
											}
										}
										else if (num9 != 5130U && num9 != 6154U)
										{
											goto IL_4C3;
										}
									}
									else if (num9 <= 8202U)
									{
										if (num9 != 7178U && num9 != 8202U)
										{
											goto IL_4C3;
										}
									}
									else if (num9 != 9226U && num9 != 10250U && num9 != 11274U)
									{
										goto IL_4C3;
									}
								}
								else if (num9 <= 16394U)
								{
									if (num9 <= 13322U)
									{
										if (num9 != 12298U && num9 != 13322U)
										{
											goto IL_4C3;
										}
									}
									else if (num9 != 14346U && num9 != 15370U && num9 != 16394U)
									{
										goto IL_4C3;
									}
								}
								else if (num9 <= 18442U)
								{
									if (num9 != 17418U && num9 != 18442U)
									{
										goto IL_4C3;
									}
								}
								else if (num9 != 19466U && num9 != 20490U && num9 != 21514U)
								{
									goto IL_4C3;
								}
								for (int l = 0; l < list.Count; l++)
								{
									if (list[l].Supportculture == "pt")
									{
										text2 = "pt";
										break;
									}
								}
							}
						}
						else
						{
							uint num10 = 0U;
							try
							{
								num10 = (uint)ProfileLoginWindow.GetSystemDefaultLangID();
							}
							catch (Exception)
							{
							}
							if (num10 == 1033U)
							{
								for (int m = 0; m < list.Count; m++)
								{
									if (list[m].Supportculture == text2 && list[m].KingdomsWorldID >= 900 && list[m].KingdomsWorldID < 1000 && list[m].NewWorld && list[m].Online && list[m].AvailableToJoin)
									{
										flag3 = true;
										num = list[m].KingdomsWorldID;
										flag2 = true;
										break;
									}
								}
							}
						}
					}
					IL_4C3:
					if (!flag3)
					{
						bool flag5 = false;
						for (int n = 0; n < list.Count; n++)
						{
							if (list[n].Supportculture == text2 && (text2 != "en" || list[n].KingdomsWorldID < 200))
							{
								if (list[n].KingdomsWorldID > num6 && (list[n].Online || !flag2) && list[n].AvailableToJoin)
								{
									num = list[n].KingdomsWorldID;
									num6 = list[n].KingdomsWorldID;
									if (list[n].Online)
									{
										flag2 = true;
									}
								}
								if (list[n].NewWorld && list[n].Online && list[n].AvailableToJoin)
								{
									num = list[n].KingdomsWorldID;
									flag2 = true;
									flag5 = true;
									break;
								}
							}
						}
						if (!flag5 && num3 >= 0)
						{
							num = num3;
						}
					}
				}
			}
			ProfileLoginWindow.LastNumberOfWorldsPlaying = num2;
			DateTime t = new DateTime(2017, 1, 24, 15, 0, 0);
			CustomSelfDrawPanel.CSDLabel statusLinkLabel = new CustomSelfDrawPanel.CSDLabel();
			statusLinkLabel.Text = SK.Text("LOGIN_WORLDS_STATUS_PAGE", "Live Status Webpage");
			statusLinkLabel.Color = global::ARGBColors.Black;
			statusLinkLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			statusLinkLabel.Position = new Point(0, 175);
			statusLinkLabel.Size = new Size(this.WorldsPanelcontrols_LoggedOut.Width, 25);
			statusLinkLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			statusLinkLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.statusPageClicked));
			statusLinkLabel.setMouseOverDelegate(delegate
			{
				statusLinkLabel.Color = global::ARGBColors.Red;
			}, delegate
			{
				statusLinkLabel.Color = global::ARGBColors.Black;
			});
			this.loggedInWorldControls.Add(statusLinkLabel);
			for (int num11 = 0; num11 < list.Count; num11++)
			{
				if (list[num11].KingdomsWorldID == num && (num2 == 0 || list[num11].Playing))
				{
					CustomSelfDrawPanel.CSDLabel csdlabel = new CustomSelfDrawPanel.CSDLabel();
					CustomSelfDrawPanel.CSDImage csdimage = new CustomSelfDrawPanel.CSDImage();
					CustomSelfDrawPanel.CSDImage csdimage2 = new CustomSelfDrawPanel.CSDImage();
					CustomSelfDrawPanel.CSDLabel csdlabel2 = new CustomSelfDrawPanel.CSDLabel();
					CustomSelfDrawPanel.CSDLabel csdlabel3 = new CustomSelfDrawPanel.CSDLabel();
					csdlabel3.Text = text;
					csdlabel3.Position = new Point(0, 10);
					csdlabel3.Size = new Size(this.WorldsPanelcontrols_LoggedIn.Width, 60);
					csdlabel3.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
					csdlabel3.Color = global::ARGBColors.Black;
					csdlabel3.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.loggedInWorldControls.Add(csdlabel3);
					int y = csdlabel2.Y = (csdlabel.Y = (csdimage2.Y = (csdimage.Y = 70)));
					csdlabel.Width = this.worldControlWidth + 8 + 8;
					csdlabel.Height = this.worldControlHeight;
					csdlabel2.Width = this.worldControlWidth - 8;
					csdlabel2.Height = this.worldControlHeight;
					string supportculture = list[num11].Supportculture;
					if (supportculture != null)
					{
						uint num12 = PrivateImplementationDetails.ComputeStringHash(supportculture);
						if (num12 <= 1194886160U)
						{
							if (num12 <= 1162757945U)
							{
								if (num12 != 1092248970U)
								{
									if (num12 == 1162757945U)
									{
										if (supportculture == "pl")
										{
											csdimage.CustomTooltipID = 4020;
										}
									}
								}
								else if (supportculture == "en")
								{
									csdimage.CustomTooltipID = 4001;
								}
							}
							else if (num12 != 1164435231U)
							{
								if (num12 != 1176137065U)
								{
									if (num12 == 1194886160U)
									{
										if (supportculture == "it")
										{
											csdimage.CustomTooltipID = 4027;
										}
									}
								}
								else if (supportculture == "es")
								{
									csdimage.CustomTooltipID = 4016;
								}
							}
							else if (supportculture == "zh")
							{
								csdimage.CustomTooltipID = 4046;
							}
						}
						else if (num12 <= 1213488160U)
						{
							if (num12 != 1195724803U)
							{
								if (num12 != 1209692303U)
								{
									if (num12 == 1213488160U)
									{
										if (supportculture == "ru")
										{
											csdimage.CustomTooltipID = 4004;
										}
									}
								}
								else if (supportculture == "eu")
								{
									csdimage.CustomTooltipID = 4031;
								}
							}
							else if (supportculture == "tr")
							{
								csdimage.CustomTooltipID = 4023;
							}
						}
						else if (num12 != 1461901041U)
						{
							if (num12 != 1545391778U)
							{
								if (num12 == 1565420801U)
								{
									if (supportculture == "pt")
									{
										csdimage.CustomTooltipID = 4035;
									}
								}
							}
							else if (supportculture == "de")
							{
								csdimage.CustomTooltipID = 4002;
							}
						}
						else if (supportculture == "fr")
						{
							csdimage.CustomTooltipID = 4003;
						}
					}
					string mapCulture = list[num11].MapCulture;
					if (mapCulture != null)
					{
						uint num12 = PrivateImplementationDetails.ComputeStringHash(mapCulture);
						if (num12 <= 1194886160U)
						{
							if (num12 <= 1164435231U)
							{
								if (num12 != 1092248970U)
								{
									if (num12 != 1162757945U)
									{
										if (num12 == 1164435231U)
										{
											if (mapCulture == "zh")
											{
												csdimage2.CustomTooltipID = 4047;
											}
										}
									}
									else if (mapCulture == "pl")
									{
										csdimage2.CustomTooltipID = 4021;
									}
								}
								else if (mapCulture == "en")
								{
									csdimage2.CustomTooltipID = 4005;
								}
							}
							else if (num12 != 1176137065U)
							{
								if (num12 != 1178800089U)
								{
									if (num12 == 1194886160U)
									{
										if (mapCulture == "it")
										{
											csdimage2.CustomTooltipID = 4028;
										}
									}
								}
								else if (mapCulture == "us")
								{
									csdimage2.CustomTooltipID = 4030;
								}
							}
							else if (mapCulture == "es")
							{
								csdimage2.CustomTooltipID = 4017;
							}
						}
						else if (num12 <= 1213488160U)
						{
							if (num12 != 1195724803U)
							{
								if (num12 != 1209692303U)
								{
									if (num12 == 1213488160U)
									{
										if (mapCulture == "ru")
										{
											csdimage2.CustomTooltipID = 4008;
										}
									}
								}
								else if (mapCulture == "eu")
								{
									csdimage2.CustomTooltipID = 4032;
								}
							}
							else if (mapCulture == "tr")
							{
								csdimage2.CustomTooltipID = 4024;
							}
						}
						else if (num12 <= 1461901041U)
						{
							if (num12 != 1245513207U)
							{
								if (num12 == 1461901041U)
								{
									if (mapCulture == "fr")
									{
										csdimage2.CustomTooltipID = 4007;
									}
								}
							}
							else if (mapCulture == "kg")
							{
								csdimage2.CustomTooltipID = 4049;
							}
						}
						else if (num12 != 1545391778U)
						{
							if (num12 == 1565420801U)
							{
								if (mapCulture == "pt")
								{
									csdimage2.CustomTooltipID = 4036;
								}
							}
						}
						else if (mapCulture == "de")
						{
							csdimage2.CustomTooltipID = 4006;
						}
					}
					csdlabel.Text = ProfileLoginWindow.getWorldShortDesc(list[num11]);
					if (list[num11].Supportculture == "ph")
					{
						csdimage.Image = GFXLibrary.getLoginWorldFlag("wd");
					}
					else
					{
						csdimage.Image = GFXLibrary.getLoginWorldFlag(list[num11].Supportculture);
					}
					csdimage.Width = csdimage.Image.Width;
					csdimage.Height = csdimage.Image.Height;
					csdimage2.Image = GFXLibrary.getLoginWorldMap(list[num11].MapCulture);
					csdimage2.Width = csdimage2.Image.Width;
					csdimage2.Height = csdimage2.Image.Height;
					csdlabel.X = 3;
					csdimage.X = csdlabel.X + csdlabel.Width + 8;
					csdimage2.X = csdimage.X + csdimage.Width + 8;
					csdlabel2.X = csdimage2.X + csdimage2.Width + 8;
					if (list[num11].Online)
					{
						csdlabel2.Text = this.strOnline;
						csdlabel2.Color = global::ARGBColors.Green;
						CustomSelfDrawPanel.CSDImage csdimage3 = new CustomSelfDrawPanel.CSDImage();
						this.allButtons.Add(csdimage3);
						csdimage3.Width = this.worldControlWidth;
						csdimage3.Height = this.worldControlHeight;
						csdimage3.Y = y;
						csdimage3.Tag = list[num11];
						csdimage3.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnWorldAction_Click), "ProfileLoginWindow_enter_world");
						csdimage3.setMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.btnWorldAction_mouseOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.btnWorldAction_mouseOut));
						if (list[num11].Playing)
						{
							csdimage3.Image = this.PlayImage;
						}
						else if (list[num11].AvailableToJoin)
						{
							csdimage3.Image = this.JoinImage;
						}
						else
						{
							csdimage3.Image = this.ClosedImage;
							csdimage3.setClickDelegate(null);
							csdimage3.setMouseOverDelegate(null, null);
						}
						csdimage3.Width = csdimage3.Image.Width;
						csdimage3.Height = csdimage3.Image.Height;
						csdimage3.X = this.pnlWorlds.Width - 4 - csdimage3.Width;
						this.loggedInWorldControls.Add(csdimage3);
						csdlabel2.CustomTooltipID = 4010;
					}
					else
					{
						if (list[num11].KingdomsWorldID == 2502 && DateTime.UtcNow > t)
						{
							csdlabel2.Text = this.strWorldEnded;
							csdlabel2.Width = 128;
						}
						else
						{
							csdlabel2.Text = this.strOffline;
							csdlabel2.Color = global::ARGBColors.Red;
						}
						csdlabel2.CustomTooltipID = 4009;
					}
					this.loggedInWorldControls.Add(csdimage);
					this.loggedInWorldControls.Add(csdimage2);
					this.loggedInWorldControls.Add(csdlabel);
					this.loggedInWorldControls.Add(csdlabel2);
					break;
				}
			}
			CustomSelfDrawPanel.CSDButton csdbutton = new CustomSelfDrawPanel.CSDButton();
			csdbutton.ImageNorm = this.SelectImage;
			csdbutton.ImageOver = this.SelectImageOver;
			csdbutton.Position = new Point(23, 120);
			csdbutton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.ShowWorldSelect), "ProfileLoginWindow_show_worlds");
			this.loggedInWorldControls.Add(csdbutton);
			if (ProfileLoginWindow.NewWorldsAvailable)
			{
				CustomSelfDrawPanel.CSDLabel csdlabel4 = new CustomSelfDrawPanel.CSDLabel();
				csdlabel4.Text = SK.Text("LOGIN_New_Worlds", "A New World is available!");
				csdlabel4.Color = global::ARGBColors.Green;
				csdlabel4.Position = new Point(0, 155);
				csdlabel4.Size = new Size(this.WorldsPanelcontrols_LoggedIn.Width, 60);
				csdlabel4.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				csdlabel4.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
				this.loggedInWorldControls.Add(csdlabel4);
			}
			foreach (CustomSelfDrawPanel.CSDControl control2 in this.loggedInWorldControls)
			{
				this.WorldsPanelcontrols_LoggedIn.addControl(control2);
			}
			this.WorldsPanelcontrols_LoggedIn.Invalidate(true);
		}

		// Token: 0x06001D93 RID: 7571 RVA: 0x001CBBDC File Offset: 0x001C9DDC
		private void btnWorldAction_mouseOver()
		{
			WorldInfo worldInfo = (WorldInfo)this.WorldsPanelcontrols_LoggedIn.OverControl.Tag;
			if (worldInfo.Playing)
			{
				((CustomSelfDrawPanel.CSDImage)this.WorldsPanelcontrols_LoggedIn.OverControl).Image = this.PlayImageOver;
				return;
			}
			((CustomSelfDrawPanel.CSDImage)this.WorldsPanelcontrols_LoggedIn.OverControl).Image = this.JoinImageOver;
		}

		// Token: 0x06001D94 RID: 7572 RVA: 0x001CBC40 File Offset: 0x001C9E40
		private void btnWorldAction_mouseOut()
		{
			WorldInfo worldInfo = (WorldInfo)this.WorldsPanelcontrols_LoggedIn.OverControl.Tag;
			if (worldInfo.Playing)
			{
				((CustomSelfDrawPanel.CSDImage)this.WorldsPanelcontrols_LoggedIn.OverControl).Image = this.PlayImage;
				return;
			}
			((CustomSelfDrawPanel.CSDImage)this.WorldsPanelcontrols_LoggedIn.OverControl).Image = this.JoinImage;
		}

		// Token: 0x06001D95 RID: 7573 RVA: 0x001CBCA4 File Offset: 0x001C9EA4
		private void btnWorldAction_Click()
		{
			WorldInfo worldInfo = (WorldInfo)this.WorldsPanelcontrols_LoggedIn.ClickedControl.Tag;
			if (worldInfo.Online)
			{
				this.serverAddr = worldInfo.HostExt;
				Program.WorldName = ProfileLoginWindow.getWorldShortDesc(worldInfo);
				RemoteServices.Instance.ProfileWorldID = worldInfo.KingdomsWorldID;
				this.EnablePanels(false);
				this.JoinGameworld(new int?(worldInfo.Playing ? 1 : 0), new int?((this.PlayerGameworldCount <= 0) ? 1 : 0), new int?(worldInfo.KingdomsWorldID), ProfileLoginWindow.getWorldShortDesc(worldInfo));
			}
		}

		// Token: 0x06001D96 RID: 7574 RVA: 0x001CBD38 File Offset: 0x001C9F38
		public void btnWorldAction_Click(WorldInfo i)
		{
			if (i.Online)
			{
				this.serverAddr = i.HostExt;
				Program.WorldName = ProfileLoginWindow.getWorldShortDesc(i);
				RemoteServices.Instance.ProfileWorldID = i.KingdomsWorldID;
				this.EnablePanels(false);
				this.JoinGameworld(new int?(i.Playing ? 1 : 0), new int?((this.PlayerGameworldCount <= 0) ? 1 : 0), new int?(i.KingdomsWorldID), ProfileLoginWindow.getWorldShortDesc(i));
			}
		}

		// Token: 0x06001D97 RID: 7575 RVA: 0x001CBDB8 File Offset: 0x001C9FB8
		public void BuildOfflineWorldList(List<WorldInfo> list)
		{
			if (this.loggedOutWorldControls != null && this.loggedOutWorldControls.Count > 0)
			{
				foreach (CustomSelfDrawPanel.CSDControl control in this.loggedOutWorldControls)
				{
					this.WorldsPanelcontrols_LoggedOut.removeControl(control);
				}
				this.loggedOutWorldControls.Clear();
			}
			else if (this.loggedOutWorldControls == null)
			{
				this.loggedOutWorldControls = new List<CustomSelfDrawPanel.CSDControl>();
			}
			int num = 0;
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].Online)
				{
					num++;
				}
			}
			Color color = global::ARGBColors.Green;
			string text;
			if (num == 0)
			{
				text = SK.Text("LOGIN_ALL_OFFLINE", "All Worlds Offline");
				color = global::ARGBColors.Red;
			}
			else if (num == list.Count)
			{
				text = SK.Text("LOGIN_ALL_ONLINE", "All Worlds Online");
			}
			else
			{
				text = SK.Text("LOGIN_WORLDS_ONLINE", "Worlds Online : ") + num.ToString() + " / " + list.Count.ToString();
				color = global::ARGBColors.Black;
			}
			CustomSelfDrawPanel.CSDLabel csdlabel = new CustomSelfDrawPanel.CSDLabel();
			csdlabel.Text = text;
			csdlabel.Color = color;
			csdlabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			csdlabel.Position = new Point(0, 0);
			csdlabel.Size = new Size(this.WorldsPanelcontrols_LoggedOut.Width, 80);
			csdlabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.loggedOutWorldControls.Add(csdlabel);
			CustomSelfDrawPanel.CSDLabel statusLinkLabel = new CustomSelfDrawPanel.CSDLabel();
			statusLinkLabel.Text = SK.Text("LOGIN_WORLDS_STATUS_PAGE", "Live Status Webpage");
			statusLinkLabel.Color = global::ARGBColors.Black;
			statusLinkLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			statusLinkLabel.Position = new Point(0, 20);
			statusLinkLabel.Size = new Size(this.WorldsPanelcontrols_LoggedOut.Width, 25);
			statusLinkLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			statusLinkLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.statusPageClicked));
			statusLinkLabel.setMouseOverDelegate(delegate
			{
				statusLinkLabel.Color = global::ARGBColors.Red;
			}, delegate
			{
				statusLinkLabel.Color = global::ARGBColors.Black;
			});
			this.loggedOutWorldControls.Add(statusLinkLabel);
			foreach (CustomSelfDrawPanel.CSDControl control2 in this.loggedOutWorldControls)
			{
				this.WorldsPanelcontrols_LoggedOut.addControl(control2);
			}
			this.WorldsPanelcontrols_LoggedOut.Invalidate(true);
		}

		// Token: 0x06001D98 RID: 7576 RVA: 0x001CC088 File Offset: 0x001CA288
		public void GetOfflineWorlds()
		{
			XmlRpcAuthProvider xmlRpcAuthProvider = XmlRpcAuthProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressLogin, URLs.ProfileServerPort, URLs.ProfilePath);
			XmlRpcAuthRequest req = new XmlRpcAuthRequest("", "", "", "", "", "", "", "");
			xmlRpcAuthProvider.GetWorlds(req, new AuthEndResponseDelegate(this.GetOfflineWorldsCallback), this);
		}

		// Token: 0x06001D99 RID: 7577 RVA: 0x001CC0F4 File Offset: 0x001CA2F4
		private void GetOfflineWorldsCallback(IAuthProvider sender, IAuthResponse response)
		{
			int? successCode = response.SuccessCode;
			int num = 1;
			if (!(successCode.GetValueOrDefault() == num & successCode != null))
			{
				this.throwClientErrorConnection(this.lblLoginError, response.Message);
				return;
			}
			ProfileLoginWindow.WorldList = ((XmlRpcAuthResponse)response).WorldList;
			ProfileLoginWindow.LanguageList = new Dictionary<string, LocalizationLanguage>();
			foreach (WorldInfo worldInfo in ProfileLoginWindow.WorldList)
			{
				if (!ProfileLoginWindow.LanguageList.ContainsKey(worldInfo.Supportculture))
				{
					LocalizationLanguage localizationLanguage = new LocalizationLanguage();
					localizationLanguage.CultureCode = worldInfo.Supportculture;
					ProfileLoginWindow.LanguageList.Add(worldInfo.Supportculture, localizationLanguage);
				}
			}
			if (Program.mySettings.NumWorldsCount < 0)
			{
				Program.mySettings.NumWorldsCount = ProfileLoginWindow.WorldList.Count;
				Program.mySettings.NumWorldsLastChanged = DateTime.MinValue;
				Program.mySettings.Save();
			}
			else if (Program.mySettings.NumWorldsCount != ProfileLoginWindow.WorldList.Count)
			{
				Program.mySettings.NumWorldsCount = ProfileLoginWindow.WorldList.Count;
				Program.mySettings.NumWorldsLastChanged = DateTime.Now;
				Program.mySettings.Save();
				ProfileLoginWindow.NewWorldsAvailable = true;
			}
			else if ((DateTime.Now - Program.mySettings.NumWorldsLastChanged).TotalDays < 7.0)
			{
				ProfileLoginWindow.NewWorldsAvailable = true;
			}
			if (DateTime.Now < new DateTime(2012, 2, 18))
			{
				ProfileLoginWindow.NewWorldsAvailable = false;
			}
			List<WorldInfo> worldsBySupportCulture = this.GetWorldsBySupportCulture("");
			this.BuildOfflineWorldList(worldsBySupportCulture);
			if (ProfileLoginWindow.NewWorldsAvailable)
			{
				if (this.lblNewWorlds == null)
				{
					this.lblNewWorlds = new CustomSelfDrawPanel.CSDLabel();
				}
				this.lblNewWorlds.Text = SK.Text("LOGIN_New_Worlds", "A New World is available!");
				this.lblNewWorlds.Color = global::ARGBColors.Green;
				this.lblNewWorlds.Position = new Point(10, this.LoginPanelControls_LoggedOut.Height - 45);
				this.lblNewWorlds.Size = new Size(this.LoginPanelControls_LoggedOut.Width - 20, 40);
				this.lblNewWorlds.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
				this.lblNewWorlds.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
				this.LoginPanelControls_LoggedOut.removeControl(this.lblNewWorlds);
				this.LoginPanelControls_LoggedOut.addControl(this.lblNewWorlds);
			}
			if (this.chkAutoLogin != null)
			{
				this.chkAutoLogin.Visible = false;
			}
			if (Program.mySettings.LastWorldID < 0)
			{
				return;
			}
			string text = "";
			foreach (WorldInfo worldInfo2 in worldsBySupportCulture)
			{
				if (worldInfo2.KingdomsWorldID == Program.mySettings.LastWorldID)
				{
					text = ProfileLoginWindow.getWorldShortDesc(worldInfo2);
					break;
				}
			}
			if (text.Length > 0)
			{
				if (this.chkAutoLogin != null)
				{
					this.LoginPanelControls_LoggedOut.removeControl(this.chkAutoLogin);
				}
				this.chkAutoLogin = new CustomSelfDrawPanel.CSDCheckBox();
				this.chkAutoLogin.CheckedImage = GFXLibrary.mrhp_world_filter_check[0];
				this.chkAutoLogin.UncheckedImage = GFXLibrary.mrhp_world_filter_check[1];
				this.chkAutoLogin.Position = new Point(10, this.LoginPanelControls_LoggedOut.Height - 30);
				this.chkAutoLogin.Checked = Program.mySettings.AutoLogin;
				this.chkAutoLogin.CBLabel.Text = SK.Text("LOGIN_Auto_Load", "Auto Connect to : ") + text;
				this.chkAutoLogin.CBLabel.Color = global::ARGBColors.Black;
				this.chkAutoLogin.CBLabel.Position = new Point(20, -1);
				this.chkAutoLogin.CBLabel.Size = new Size(this.LoginPanelControls_LoggedOut.Width, 25);
				this.chkAutoLogin.CBLabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
				this.chkAutoLogin.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.autoLoadToggled));
				this.chkAutoLogin.Visible = true;
				this.LoginPanelControls_LoggedOut.addControl(this.chkAutoLogin);
				this.LoginPanelControls_LoggedOut.Invalidate();
			}
		}

		// Token: 0x06001D9A RID: 7578 RVA: 0x001CC560 File Offset: 0x001CA760
		public void GetOnlineWorlds()
		{
			XmlRpcAuthProvider xmlRpcAuthProvider = XmlRpcAuthProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressLogin, URLs.ProfileServerPort, URLs.ProfilePath);
			XmlRpcAuthRequest req = new XmlRpcAuthRequest(RemoteServices.Instance.UserGuid.ToString().Replace("-", ""), "", "", "", "", "", "", "");
			xmlRpcAuthProvider.GetWorlds(req, new AuthEndResponseDelegate(this.GetOnlineWorldsCallback), this);
		}

		// Token: 0x06001D9B RID: 7579 RVA: 0x001CC5EC File Offset: 0x001CA7EC
		private void GetOnlineWorldsCallback(IAuthProvider sender, IAuthResponse response)
		{
			int? successCode = response.SuccessCode;
			int num = 1;
			if (!(successCode.GetValueOrDefault() == num & successCode != null))
			{
				this.throwClientErrorConnection(this.lblLoginError, response.Message);
				return;
			}
			ProfileLoginWindow.WorldList = ((XmlRpcAuthResponse)response).WorldList;
			this.processVacationModeInfo(ProfileLoginWindow.WorldList);
			this.ShowOnlinePanels();
		}

		// Token: 0x06001D9C RID: 7580 RVA: 0x001CC64C File Offset: 0x001CA84C
		private void processVacationModeInfo(List<WorldInfo> worldList)
		{
			ProfileLoginWindow.inSpecialWorld = false;
			ProfileLoginWindow.specialWorldName = "";
			foreach (WorldInfo worldInfo in worldList)
			{
				if (ProfileLoginWindow.isSpecialWorld(worldInfo.KingdomsWorldID) && worldInfo.Playing)
				{
					ProfileLoginWindow.inSpecialWorld = true;
					ProfileLoginWindow.specialWorldName = ProfileLoginWindow.getWorldShortDesc(worldInfo);
					break;
				}
			}
		}

		// Token: 0x06001D9D RID: 7581 RVA: 0x0001CA95 File Offset: 0x0001AC95
		private void autoLoadToggled()
		{
			Program.mySettings.AutoLogin = this.chkAutoLogin.Checked;
		}

		// Token: 0x06001D9E RID: 7582 RVA: 0x001CC6CC File Offset: 0x001CA8CC
		private void btnClientLogout_Click()
		{
			if (Program.bigpointPartnerInstall)
			{
				this.forumLabel.Visible = false;
				if (ProfileLoginWindow.bp2_logoutURL != null && ProfileLoginWindow.bp2_logoutURL.Length > 0)
				{
					Process.Start(ProfileLoginWindow.bp2_logoutURL);
				}
				RemoteServices.Instance.UserGuid = Guid.Empty;
				RemoteServices.Instance.SessionGuid = Guid.Empty;
				this.AdminGUID = null;
				this.bp2_loginMode = 0;
				this.PlayerGameworldCount = 0;
				this.GetOfflineWorlds();
				this.RefreshControls();
				this.geckoWebBrowser1.Navigate(URLs.NewsMainPage);
				this.EnablePanels(true);
				return;
			}
			XmlRpcAuthProvider xmlRpcAuthProvider = XmlRpcAuthProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressLogin, URLs.ProfileServerPort, URLs.ProfilePath);
			XmlRpcAuthRequest req = new XmlRpcAuthRequest(RemoteServices.Instance.UserGuid.ToString().Replace("-", ""), "", "", "", RemoteServices.Instance.SessionGuid.ToString().Replace("-", ""), "", "", "");
			this.clearErrorMessages();
			xmlRpcAuthProvider.clientLogout(req, new AuthEndResponseDelegate(this.ClientLogoutCallback), this);
			this.EnablePanels(false);
			this.geckoWebBrowser1.Enabled = false;
			if (ProfileLoginWindow.LoggedInViaFacebook)
			{
				if (ProfileLoginWindow.tempBrowser == null)
				{
					ProfileLoginWindow.tempBrowser = new WebBrowser();
					ProfileLoginWindow.tempBrowser.Location = new Point(1000, 1000);
				}
				ProfileLoginWindow.tempBrowser.Navigate("https://login.strongholdkingdoms.com/facebook/logout.php?access_token=" + Program.mySettings.facebookaccesstoken);
				Thread.Sleep(1000);
				Program.mySettings.facebookaccesstoken = "";
			}
			ProfileLoginWindow.LoggedInViaFacebook = false;
			if (Program.aeriaInstall)
			{
				this.openAeriaPopup(true);
			}
			if (Program.bigpointInstall)
			{
				this.openBigPointPopup(true);
			}
			bool bigpointPartnerInstall = Program.bigpointPartnerInstall;
		}

		// Token: 0x06001D9F RID: 7583 RVA: 0x001CC8B0 File Offset: 0x001CAAB0
		private void ClientLogoutCallback(IAuthProvider sender, IAuthResponse response)
		{
			RemoteServices.Instance.UserGuid = Guid.Empty;
			RemoteServices.Instance.SessionGuid = Guid.Empty;
			this.AdminGUID = null;
			int? successCode = response.SuccessCode;
			int num = 1;
			if (!(successCode.GetValueOrDefault() == num & successCode != null))
			{
				this.throwClientErrorConnection(this.lblLoginError, response.Message);
			}
			this.PlayerGameworldCount = 0;
			this.GetOfflineWorlds();
			this.RefreshControls();
			this.geckoWebBrowser1.Navigate(URLs.NewsMainPage);
			this.EnablePanels(true);
			if (Program.bigpointInstall || Program.bigpointPartnerInstall)
			{
				this.forumLabel.Visible = false;
			}
		}

		// Token: 0x06001DA0 RID: 7584 RVA: 0x0001CAAC File Offset: 0x0001ACAC
		public bool isPlayerLoggedIn()
		{
			Guid userGuid = RemoteServices.Instance.UserGuid;
			return RemoteServices.Instance.UserGuid != Guid.Empty;
		}

		// Token: 0x06001DA1 RID: 7585 RVA: 0x001CC958 File Offset: 0x001CAB58
		public void RefreshControls()
		{
			bool flag = this.isPlayerLoggedIn();
			this.LoginPanelControls_LoggedIn.Visible = flag;
			this.WorldsPanelcontrols_LoggedIn.Visible = flag;
			this.LoginPanelControls_LoggedOut.Visible = !flag;
			this.WorldsPanelcontrols_LoggedOut.Visible = !flag;
			this.ShowTabs();
		}

		// Token: 0x06001DA2 RID: 7586 RVA: 0x001CC9A8 File Offset: 0x001CABA8
		private void txtLoginField_Validate_email(object sender, EventArgs e)
		{
			this.btnLogin.Enabled = (this.txtEmail.TextLength > 0 && this.txtPassword.TextLength > 0);
			if (this.chkAutoLogin != null && !this.ignoreEmailChange)
			{
				this.chkAutoLogin.Checked = false;
				Program.mySettings.AutoLogin = false;
			}
		}

		// Token: 0x06001DA3 RID: 7587 RVA: 0x0001CACD File Offset: 0x0001ACCD
		private void txtLoginField_Validate(object sender, EventArgs e)
		{
			this.btnLogin.Enabled = (this.txtEmail.TextLength > 0 && this.txtPassword.TextLength > 0);
		}

		// Token: 0x06001DA4 RID: 7588 RVA: 0x0001CAF9 File Offset: 0x0001ACF9
		public void clearErrorMessages()
		{
			this.lblLoginError.Visible = false;
		}

		// Token: 0x06001DA5 RID: 7589 RVA: 0x001CCA08 File Offset: 0x001CAC08
		public void throwClientError(CustomSelfDrawPanel.CSDLabel l, string message)
		{
			l.Visible = true;
			l.Text = this.strGenericLoginError;
			l.X = 4;
			l.Y = this.LoginPanelControls_LoggedOut.Height - 30;
			l.Width = this.LoginPanelControls_LoggedOut.Width - 8;
			l.Height = 60;
			this.EnablePanels(true);
		}

		// Token: 0x06001DA6 RID: 7590 RVA: 0x001CCA68 File Offset: 0x001CAC68
		public void throwClientErrorConnection(CustomSelfDrawPanel.CSDLabel l, string message)
		{
			l.Visible = true;
			l.Text = this.strGenericLoginErrorConnection;
			l.X = 4;
			l.Y = this.LoginPanelControls_LoggedOut.Height - 30;
			l.Width = this.LoginPanelControls_LoggedOut.Width - 8;
			l.Height = 60;
			this.EnablePanels(true);
		}

		// Token: 0x06001DA7 RID: 7591 RVA: 0x001CCAC8 File Offset: 0x001CACC8
		public void btnLoginFB_Click()
		{
			if (Program.mySettings.facebookaccesstoken != "")
			{
				this.specialFacebookLogin = true;
				this.tempFacebookLogin = true;
				ProfileLoginWindow.AeriaToken = Program.mySettings.facebookaccesstoken;
				this.btnLogin_Click();
				this.tempFacebookLogin = false;
				return;
			}
			this.openFacebookPopup();
		}

		// Token: 0x06001DA8 RID: 7592 RVA: 0x0001CB07 File Offset: 0x0001AD07
		public void BP2_Closed()
		{
			this.btnLogin.Enabled = true;
			this.bp2_loginMode = 0;
			this.EnablePanels(true);
		}

		// Token: 0x06001DA9 RID: 7593 RVA: 0x0001CB23 File Offset: 0x0001AD23
		public void bp2_autoLoginAttempt()
		{
			this.bp2_loginMode = 1;
			this.btnLogin_Click();
		}

		// Token: 0x06001DAA RID: 7594 RVA: 0x0001CB32 File Offset: 0x0001AD32
		public void bp2_manualLoginAttempt()
		{
			this.bp2_loginMode = 2;
			this.btnLogin_Click();
		}

		// Token: 0x06001DAB RID: 7595 RVA: 0x001CCB1C File Offset: 0x001CAD1C
		public void btnLogin_Click()
		{
			if (Program.bigpointPartnerInstall && this.bp2_loginMode == 0)
			{
				ProfileLoginWindow.bp2_currentGuid = Guid.NewGuid().ToString().Replace("-", "");
				Process.Start("https://api.bigpoint.com/oauth/authorize?response_type=code&client_id=strongholdkingdoms&redirect_uri=https://login.strongholdkingdoms.com/bigpoint/2/oauth2/authorized.php&state=" + ProfileLoginWindow.bp2_currentGuid);
				InterfaceMgr.Instance.openBPPopupWindow(this);
				this.btnLogin.Enabled = false;
				return;
			}
			ProfileLoginWindow.LoggedInViaFacebook = false;
			XmlRpcAuthProvider xmlRpcAuthProvider = null;
			if (Control.ModifierKeys != Keys.Shift)
			{
				ProfileLoginWindow.httpLogin = false;
				ShieldFactory.HTTP_only = false;
				if (!ProfileLoginWindow.certPolicyCreated)
				{
					ServicePointManager.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback)Delegate.Combine(ServicePointManager.ServerCertificateValidationCallback, new RemoteCertificateValidationCallback(delegate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
					{
						if (sslPolicyErrors == SslPolicyErrors.None)
						{
							return true;
						}
						bool flag = true;
						string str = "The server could not be validated for the following reason(s):\r\n";
						if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateNotAvailable) == SslPolicyErrors.RemoteCertificateNotAvailable)
						{
							str += "\r\n    -The server did not present a certificate.\r\n";
							flag = false;
						}
						else
						{
							if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateNameMismatch) == SslPolicyErrors.RemoteCertificateNameMismatch)
							{
								str += "\r\n    -The certificate name does not match the authenticated name.\r\n";
								flag = false;
							}
							if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateChainErrors) == SslPolicyErrors.RemoteCertificateChainErrors)
							{
								foreach (X509ChainStatus x509ChainStatus in chain.ChainStatus)
								{
									if (x509ChainStatus.Status != X509ChainStatusFlags.RevocationStatusUnknown && x509ChainStatus.Status != X509ChainStatusFlags.OfflineRevocation)
									{
										break;
									}
									if (x509ChainStatus.Status != X509ChainStatusFlags.NoError)
									{
										str = str + "\r\n    -" + x509ChainStatus.StatusInformation;
										flag = false;
									}
								}
							}
						}
						if (!flag)
						{
							str += "\r\nDo you wish to override the security check?";
							flag = true;
						}
						return flag;
					}));
					ProfileLoginWindow.certPolicyCreated = true;
				}
				xmlRpcAuthProvider = XmlRpcAuthProvider.CreateForEndpoint("https", URLs.ProfileServerAddressLogin, "443", URLs.ProfilePath);
			}
			else
			{
				xmlRpcAuthProvider = XmlRpcAuthProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressLogin, URLs.ProfileServerPort, URLs.ProfilePath);
				ProfileLoginWindow.httpLogin = true;
				ShieldFactory.HTTP_only = true;
			}
			XmlRpcAuthRequest xmlRpcAuthRequest;
			if (Program.arcInstall)
			{
				xmlRpcAuthRequest = new XmlRpcAuthRequest("", Program.arcUsername, this.txtEmail.Text, this.txtPassword.Text, "", "", "", "");
			}
			else if (!Program.kingdomsAccountFound || !Program.steamActive)
			{
				xmlRpcAuthRequest = new XmlRpcAuthRequest("", this.txtEmail.Text, this.txtEmail.Text, this.txtPassword.Text, "", "", "", "");
				XmlRpcAuthRequest xmlRpcAuthRequest2 = xmlRpcAuthRequest;
				xmlRpcAuthRequest2.OrderID += "t";
			}
			else
			{
				xmlRpcAuthRequest = new XmlRpcAuthRequest("", Program.steamEmail, Program.steamEmail, this.txtPassword.Text, "", "", "", "");
				Program.Steam_getTicket();
				string text = BitConverter.ToString(Program.steam_SessionTicket);
				string text2 = xmlRpcAuthRequest.SteamID = text.Replace("-", "");
			}
			try
			{
				Process[] processes = Process.GetProcesses();
				Process[] array = processes;
				foreach (Process process in array)
				{
					if (Rot13.Transform(process.ProcessName.ToLowerInvariant()).Contains("fipubfg") && xmlRpcAuthRequest.OrderID != null && !xmlRpcAuthRequest.OrderID.Contains("o"))
					{
						XmlRpcAuthRequest xmlRpcAuthRequest3 = xmlRpcAuthRequest;
						xmlRpcAuthRequest3.OrderID += "o";
					}
					if (Rot13.Transform(process.ProcessName.ToLowerInvariant()).Contains("fxfgrjneq"))
					{
						XmlRpcAuthRequest xmlRpcAuthRequest4 = xmlRpcAuthRequest;
						xmlRpcAuthRequest4.OrderID += "s";
					}
					if (Rot13.Transform(process.ProcessName.ToLowerInvariant()).Contains("znpebk"))
					{
						XmlRpcAuthRequest xmlRpcAuthRequest5 = xmlRpcAuthRequest;
						xmlRpcAuthRequest5.OrderID += "m";
					}
					if (Rot13.Transform(process.ProcessName.ToLowerInvariant()).Contains("fuxobg"))
					{
						XmlRpcAuthRequest xmlRpcAuthRequest6 = xmlRpcAuthRequest;
						xmlRpcAuthRequest6.OrderID += "j";
					}
				}
			}
			catch (Exception)
			{
			}
			if (Program.gamersFirstInstall)
			{
				xmlRpcAuthRequest.SteamID = "gamersfirst";
				xmlRpcAuthRequest.Password = Program.gamersFirstTokenMD5;
			}
			if (Program.arcInstall)
			{
				xmlRpcAuthRequest.SteamID = "arc";
				if (Program.arcToken.Length < 5)
				{
					Thread.Sleep(2000);
					Program.arcToken = Program.getNewArcToken();
				}
				ProfileLoginWindow.AeriaToken = Program.arcToken;
			}
			if (Program.bigpointInstall)
			{
				xmlRpcAuthRequest.SteamID = "bp";
			}
			if (this.tempFacebookLogin)
			{
				this.FacebookToken = ProfileLoginWindow.AeriaToken;
				xmlRpcAuthRequest.SteamID = "fb";
			}
			else
			{
				this.FacebookToken = "";
				this.specialFacebookLogin = false;
			}
			if (Program.bigpointPartnerInstall)
			{
				xmlRpcAuthRequest.SteamID = "bp2";
				ProfileLoginWindow.AeriaToken = ProfileLoginWindow.bp2_currentGuid;
			}
			xmlRpcAuthRequest.AeriaToken = ProfileLoginWindow.AeriaToken;
			xmlRpcAuthRequest.Platform = this.GetMacAddress();
			DX.AuthorizedMAC = xmlRpcAuthRequest.Platform;
			xmlRpcAuthRequest.Culture = Program.syslang + ";" + Program.mySettings.LanguageIdent.ToLower();
			this.clearErrorMessages();
			this.EnablePanels(false);
			xmlRpcAuthProvider.clientLogin(xmlRpcAuthRequest, new AuthEndResponseDelegate(this.ClientLoginCallback), this);
		}

		// Token: 0x06001DAC RID: 7596 RVA: 0x001CCF94 File Offset: 0x001CB194
		private void ClientLoginCallback(IAuthProvider sender, IAuthResponse response)
		{
			int? num = response.SuccessCode;
			int num2 = 1;
			if (!(num.GetValueOrDefault() == num2 & num != null))
			{
				if (Program.bigpointPartnerInstall)
				{
					if (this.bp2_loginMode == 1)
					{
						BPPopupWindow bppopupWindow = InterfaceMgr.Instance.getBPPopupWindow();
						if (bppopupWindow != null)
						{
							bppopupWindow.attempt1Failed();
							this.EnablePanels(true);
						}
						return;
					}
					if (this.bp2_loginMode == 2)
					{
						this.bp2_loginMode = 0;
						this.btnLogin.Enabled = true;
						InterfaceMgr.Instance.closeBPPopupWindow();
					}
				}
				if (this.FacebookToken == "")
				{
					GameEngine.Instance.playInterfaceSound("ProfileLoginWindow_login_failed");
					if (!(response.Message.ToLower() == "the provided password is incorrect.") && !(response.Message.ToLower() == "the specified user doesn't exist."))
					{
						num = response.SuccessCode;
						num2 = 100;
						if (num.GetValueOrDefault() >= num2 & num != null)
						{
							num = response.SuccessCode;
							num2 = 105;
							if (num.GetValueOrDefault() <= num2 & num != null)
							{
								goto IL_109;
							}
						}
						this.throwClientErrorConnection(this.lblLoginError, response.Message);
						goto IL_12F;
					}
					IL_109:
					this.throwClientError(this.lblLoginError, response.Message);
					IL_12F:
					if (Program.aeriaInstall)
					{
						this.openAeriaPopup();
					}
					if (Program.bigpointInstall)
					{
						this.openBigPointPopup();
					}
				}
				else
				{
					Program.mySettings.facebookaccesstoken = "";
					if (this.specialFacebookLogin)
					{
						this.openFacebookPopup();
						this.EnablePanels(true);
					}
				}
				this.specialFacebookLogin = false;
				return;
			}
			ProfileLoginWindow.successfulAutoLogin = true;
			GameEngine.Instance.playInterfaceSound("ProfileLoginWindow_login_success");
			if (Program.bigpointPartnerInstall)
			{
				ProfileLoginWindow.bp2_logoutURL = response.Password;
				InterfaceMgr.Instance.closeBPPopupWindow();
			}
			if (this.FacebookToken != "")
			{
				Program.mySettings.facebookaccesstoken = this.FacebookToken;
				ProfileLoginWindow.LoggedInViaFacebook = true;
			}
			else
			{
				Program.mySettings.facebookaccesstoken = "";
			}
			this.specialFacebookLogin = false;
			if (Program.gamersFirstInstall && response.Username.Length == 0)
			{
				this.EnablePanels(true);
				ProfileLoginWindow.gfEmail = this.txtEmail.Text;
				ProfileLoginWindow.gfPW = this.txtPassword.Text;
				this.delayedCreateUserOpen = true;
				return;
			}
			if (Program.arcInstall && response.Username.Length == 0)
			{
				this.EnablePanels(true);
				ProfileLoginWindow.gfEmail = this.txtEmail.Text;
				ProfileLoginWindow.gfPW = this.txtPassword.Text;
				this.delayedCreateUserOpen = true;
				return;
			}
			if (Program.aeriaInstall || Program.gamersFirstInstall || Program.arcInstall || Program.bigpointInstall)
			{
				Program.mySettings.Username = response.Username;
			}
			else if (!Program.kingdomsAccountFound)
			{
				Program.mySettings.Username = this.txtEmail.Text;
			}
			else
			{
				Program.mySettings.Username = Program.steamEmail;
			}
			Program.mySettings.HasLoggedIn = true;
			ProfileLoginWindow.WorldList = ((XmlRpcAuthResponse)response).WorldList;
			this.processVacationModeInfo(ProfileLoginWindow.WorldList);
			ProfileLoginWindow.ShieldURL = ((XmlRpcAuthResponse)response).Shields;
			RemoteServices.Instance.UserGuid = new Guid(response.UserGUID);
			RemoteServices.Instance.SessionGuid = new Guid(response.SessionID);
			RemoteServices.Instance.WebToken = response.WebToken;
			RemoteServices.Instance.UserName = response.Username;
			string text = ((XmlRpcAuthResponse)response).SpecialURL;
			if (((XmlRpcAuthResponse)response).hasUnviewedOffers)
			{
				text = URLs.AccountOffersPage;
			}
			if (text.Length > 0)
			{
				string url = string.Concat(new string[]
				{
					text,
					"?lang=",
					Program.mySettings.LanguageIdent.ToLower(),
					"&culture=",
					Program.mySettings.LanguageIdent.ToLower(),
					"&webtoken=",
					response.WebToken
				});
				this.geckoWebBrowser1.Navigate(url);
			}
			bool flag = false;
			if (response.OnVacation != null && !(response.OnVacation == 0))
			{
				flag = true;
			}
			if (flag && this.chkAutoLogin != null && this.chkAutoLogin.Checked)
			{
				this.chkAutoLogin.Checked = false;
			}
			GameEngine.Instance.World.FacebookFreePack = false;
			if (response.FacebookFreePack != null && !(response.FacebookFreePack == 0))
			{
				GameEngine.Instance.World.FacebookFreePack = true;
			}
			if (Program.bigpointInstall || Program.bigpointPartnerInstall)
			{
				this.forumLabel.Visible = true;
			}
			this.ShowOnlinePanels();
			GameEngine.Instance.World.NumVacationsAvailable = 2 - response.VacationsTaken.Value;
			GameEngine.Instance.World.VacationNot30Days = false;
			if (response.VacationPossible != null)
			{
				num = response.VacationPossible;
				num2 = 0;
				if (num.GetValueOrDefault() <= num2 & num != null)
				{
					GameEngine.Instance.World.NumVacationsAvailable = 0;
					num = response.VacationPossible;
					num2 = -1;
					if (num.GetValueOrDefault() == num2 & num != null)
					{
						GameEngine.Instance.World.VacationNot30Days = true;
					}
				}
			}
			else
			{
				GameEngine.Instance.World.NumVacationsAvailable = 0;
			}
			if (flag && (this.AdminGUID == null || this.AdminGUID.Length == 0))
			{
				try
				{
					int value = response.VacationSecondsLeft.Value;
					int value2 = response.VacationSecondsToCancel.Value;
					bool canCancel = false;
					if (response.CancelVacation != null && !(response.CancelVacation == 0))
					{
						canCancel = true;
					}
					InterfaceMgr.Instance.openVacationCancelPopupWindow(value, value2, canCancel);
					return;
				}
				catch (Exception)
				{
				}
			}
			if (response.RequiresOptInCheck != null)
			{
				num = response.RequiresOptInCheck;
				num.GetValueOrDefault();
				bool flag2 = num != null;
			}
			StatTrackingClient.Instance().Init("http://shk-data.strongholdkingdoms.com", RemoteServices.Instance.UserGuid.ToString());
			GameEngine.Instance.World.saleStartTime = response.SaleStartTime.Value;
			GameEngine.Instance.World.saleEndTime = response.SaleEndTime.Value;
			GameEngine.Instance.World.salePercentage = response.SalePercentage.Value;
			if (ProfileLoginWindow.httpLogin)
			{
				string presetURL = response.PresetURL.Replace("https:", "http:");
				PresetManager.Instance.SetPresetURL(presetURL);
				return;
			}
			string presetURL2 = response.PresetURL.Replace("http:", "https:");
			PresetManager.Instance.SetPresetURL(presetURL2);
		}

		// Token: 0x06001DAD RID: 7597 RVA: 0x001CD670 File Offset: 0x001CB870
		private string GetMacAddress()
		{
			if (!string.IsNullOrEmpty(DX.OverrideMAC))
			{
				return DX.OverrideMAC;
			}
			string text = "";
			string result;
			try
			{
				long num = -1L;
				NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
				foreach (NetworkInterface networkInterface in allNetworkInterfaces)
				{
					string text2 = networkInterface.GetPhysicalAddress().ToString();
					bool flag = true;
					string text3 = text2.ToUpper();
					if (text3 != null)
					{
						uint num2 = PrivateImplementationDetails.ComputeStringHash(text3);
						if (num2 <= 1964407356U)
						{
							if (num2 <= 1094235591U)
							{
								if (num2 != 311207695U)
								{
									if (num2 != 366258393U)
									{
										if (num2 != 1094235591U)
										{
											goto IL_1E7;
										}
										if (!(text3 == "002637BD3942"))
										{
											goto IL_1E7;
										}
									}
									else if (!(text3 == "00A0C6000000"))
									{
										goto IL_1E7;
									}
								}
								else if (!(text3 == "582C80139263"))
								{
									goto IL_1E7;
								}
							}
							else if (num2 != 1304575778U)
							{
								if (num2 != 1884023373U)
								{
									if (num2 != 1964407356U)
									{
										goto IL_1E7;
									}
									if (!(text3 == "020054554E01"))
									{
										goto IL_1E7;
									}
								}
								else if (!(text3 == "7A7900000000"))
								{
									goto IL_1E7;
								}
							}
							else if (!(text3 == "020054746872"))
							{
								goto IL_1E7;
							}
						}
						else if (num2 <= 2929711365U)
						{
							if (num2 != 2262344821U)
							{
								if (num2 != 2702322179U)
								{
									if (num2 != 2929711365U)
									{
										goto IL_1E7;
									}
									if (!(text3 == "0000000000000000"))
									{
										goto IL_1E7;
									}
								}
								else if (!(text3 == "005056C00001"))
								{
									goto IL_1E7;
								}
							}
							else if (!(text3 == "000000000000"))
							{
								goto IL_1E7;
							}
						}
						else if (num2 != 2959868104U)
						{
							if (num2 != 3002675003U)
							{
								if (num2 != 3943963550U)
								{
									goto IL_1E7;
								}
								if (!(text3 == "005345000000"))
								{
									goto IL_1E7;
								}
							}
							else if (!(text3 == "00093BF01A40"))
							{
								goto IL_1E7;
							}
						}
						else if (!(text3 == "00000000000000E0"))
						{
							goto IL_1E7;
						}
						flag = false;
					}
					IL_1E7:
					if (flag && networkInterface.Speed > num && !string.IsNullOrEmpty(text2) && text2.Length >= 12)
					{
						num = networkInterface.Speed;
						text = text2;
					}
				}
				result = text;
			}
			catch (Exception)
			{
				result = text;
			}
			return result;
		}

		// Token: 0x06001DAE RID: 7598 RVA: 0x001CD8CC File Offset: 0x001CBACC
		public void ShowOnlinePanels()
		{
			this.LoadShieldImages();
			ProfileLoginWindow.LanguageList = new Dictionary<string, LocalizationLanguage>();
			foreach (WorldInfo worldInfo in ProfileLoginWindow.WorldList)
			{
				if (!ProfileLoginWindow.LanguageList.ContainsKey(worldInfo.Supportculture))
				{
					LocalizationLanguage localizationLanguage = new LocalizationLanguage();
					localizationLanguage.CultureCode = worldInfo.Supportculture;
					ProfileLoginWindow.LanguageList.Add(worldInfo.Supportculture, localizationLanguage);
				}
			}
			this.SetUsername();
			this.SetShieldImage();
			List<WorldInfo> worldsBySupportCulture = this.GetWorldsBySupportCulture("");
			this.BuildOnlineWorldList(worldsBySupportCulture);
			this.RefreshControls();
			this.EnablePanels(true);
			this.WorldsPanelcontrols_LoggedIn.Invalidate();
			if (this.chkAutoLogin != null && this.chkAutoLogin.Checked)
			{
				foreach (WorldInfo worldInfo2 in worldsBySupportCulture)
				{
					if (worldInfo2.KingdomsWorldID == Program.mySettings.LastWorldID && worldInfo2.Playing)
					{
						this.btnWorldAction_Click(worldInfo2);
						break;
					}
				}
			}
		}

		// Token: 0x06001DAF RID: 7599 RVA: 0x001CDA08 File Offset: 0x001CBC08
		public void cancelVacationMode()
		{
			XmlRpcCardsRequest xmlRpcCardsRequest = new XmlRpcCardsRequest();
			xmlRpcCardsRequest.UserGUID = RemoteServices.Instance.UserGuid.ToString().Replace("-", "");
			xmlRpcCardsRequest.SessionGUID = RemoteServices.Instance.SessionGuid.ToString().Replace("-", "");
			XmlRpcCardsProvider xmlRpcCardsProvider = XmlRpcCardsProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressLogin, URLs.ProfileServerPort, "/services/cardserver.php");
			XmlRpcCardsResponse xmlRpcCardsResponse = xmlRpcCardsProvider.cancelVacation(xmlRpcCardsRequest, null, null, 30000);
			if (xmlRpcCardsResponse.SuccessCode != null)
			{
				int? successCode = xmlRpcCardsResponse.SuccessCode;
				int num = 1;
				if (successCode.GetValueOrDefault() == num & successCode != null)
				{
					InterfaceMgr.Instance.closeVacationCancelPopupWindow();
				}
			}
		}

		// Token: 0x06001DB0 RID: 7600 RVA: 0x0001CB41 File Offset: 0x0001AD41
		public void CertOverrideFunction(object s, CertOverrideEventArgs e)
		{
			e.OverrideResult = (CertOverride.Mismatch | CertOverride.Time | CertOverride.Untrusted);
			e.Temporary = true;
			e.Handled = true;
		}

		// Token: 0x06001DB1 RID: 7601 RVA: 0x001CDADC File Offset: 0x001CBCDC
		public ProfileLoginWindow()
		{
			this.InitializeComponent();
			this.geckoWebBrowser1.NoDefaultContextMenu = true;
			this.browserServerNews.NoDefaultContextMenu = true;
			CertOverrideService.GetService().ValidityOverride -= this.CertOverrideFunction;
			CertOverrideService.GetService().ValidityOverride += this.CertOverrideFunction;
			this.label1.Font = FontManager.GetFont("Microsoft Sans Serif", 10f);
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.Text = "Stronghold Kingdoms";
			this.defaultWindowTitle = this.Text;
		}

		// Token: 0x06001DB2 RID: 7602 RVA: 0x001CDE50 File Offset: 0x001CC050
		private void ProfileLoginWindow_Load(object sender, EventArgs e)
		{
			GeckoPreferences.User["general.useragent.override"] = this.Text;
			base.FormBorderStyle = FormBorderStyle.FixedSingle;
			System.Windows.Forms.Screen primaryScreen = System.Windows.Forms.Screen.PrimaryScreen;
			Point location = primaryScreen.WorkingArea.Location;
			location.X += (primaryScreen.WorkingArea.Width - base.Size.Width) / 2;
			location.Y += (primaryScreen.WorkingArea.Height - base.Size.Height) / 2;
			base.Location = location;
			RemoteServices.Instance.Admin = false;
			RemoteServices.Instance.MapEditor = false;
			RemoteServices.Instance.Moderator = false;
			this.lastLogoutClicked = DateTime.MinValue;
		}

		// Token: 0x06001DB3 RID: 7603 RVA: 0x001CDF1C File Offset: 0x001CC11C
		public void initialNavigate()
		{
			this.URL_landingPage = new Uri(URLs.NewsMainPage);
			if (RemoteServices.Instance.UserGuid == Guid.Empty)
			{
				this.geckoWebBrowser1.Navigate(this.URL_landingPage);
				this.browserServerNews.Navigate(URLs.ServerNewsFeed);
				if (Program.aeriaInstall)
				{
					this.openAeriaPopup();
				}
				if (Program.bigpointInstall)
				{
					this.openBigPointPopup();
				}
				this.loginButtonActive = true;
				return;
			}
			this.geckoWebBrowser1.Navigate(this.URL_landingPage);
			this.browserServerNews.Navigate(URLs.ServerNewsFeed);
			this.loginButtonActive = true;
		}

		// Token: 0x06001DB4 RID: 7604 RVA: 0x001CDFBC File Offset: 0x001CC1BC
		public void init()
		{
			GameEngine.Instance.forcingLogout = false;
			this.delayedCreateUserOpen = false;
			this.emailOptInPopup = false;
			this.strOnline = SK.Text("WORLD_Online", "Online");
			this.strOffline = SK.Text("WORLD_Offline", "Offline");
			this.strWorldEnded = SK.Text("WorldEnded", "This World has ended.");
			this.strJoin = SK.Text("WORLD_Join", "Join");
			this.strClosed = SK.Text("FactionInvites_Membership_closed", "Closed");
			this.strPlay = SK.Text("WORLD_Play", "Play");
			this.strSelect = SK.Text("WORLD_Select", "Select World");
			this.strEmailAddress = SK.Text("LOGIN_Email", "Email Address");
			this.strPassword = SK.Text("LOGIN_Password", "Password");
			this.strLogin = SK.Text("LOGIN_Login", "Login");
			this.strLogout = SK.Text("LogoutPanel_Logout", "Logout");
			this.strNews = SK.Text("LOGIN_News", "News");
			this.strCreateAccount = SK.Text("LOGIN_CreateAccount", "Create Account");
			this.strOptions = SK.Text("MENU_Settings", "Settings");
			this.strAccountDetails = SK.Text("LOGIN_AccountDetails", "Account Details");
			this.strGenericLoginError = SK.Text("LOGIN_GenericLoginError", "Login Failed: Please check that your email and password are entered correctly.");
			this.strGenericLoginErrorConnection = SK.Text("LOGIN_GenericLoginErrorConnection", "Login Failed: There is a problem connecting to the Login Server.");
			this.strForgottenPassword = SK.Text("LOGIN_ForgottenPassword", "Forgotten Password");
			this.strExit = SK.Text("GENERIC_Exit", "Exit");
			this.strCancel = SK.Text("GENERIC_Cancel", "Cancel");
			this.initialisedLanguage = Program.mySettings.LanguageIdent;
			this.UserEntryMode = true;
			this.btnExit.Text = SK.Text("GENERIC_Exit", "Exit");
			this.label1.Text = SK.Text("ProfileLoginWindow_Connecting", "Connecting to Login Server...");
			base.Focus();
			base.BringToFront();
			base.Activate();
			base.TopMost = true;
			this.browserServerNews.Visible = false;
			this.geckoWebBrowser1.Visible = false;
			Program.DoEvents();
			Thread.Sleep(100);
			Program.DoEvents();
			this.geckoWebBrowser1.Visible = true;
			this.browserServerNews.Visible = true;
			base.Focus();
			base.BringToFront();
			base.TopMost = false;
			base.Activate();
			base.BringToFront();
			base.ShowInTaskbar = false;
			this.AddControls();
			Program.DoEvents();
			base.ShowInTaskbar = true;
			if (this.isPlayerLoggedIn())
			{
				this.GetOnlineWorlds();
			}
			else
			{
				this.GetOfflineWorlds();
			}
			this.RefreshControls();
			string startupPath = Application.StartupPath;
			string[] array = Regex.Split(startupPath, "\\\\");
			if (array.Length != 0)
			{
				this.lblVersion.Visible = true;
				this.lblVersion.Text = SK.Text("ProfileLoginWindow_Version", "Version") + " : " + array[array.Length - 1];
			}
			this.initialNavigate();
		}

		// Token: 0x06001DB5 RID: 7605 RVA: 0x00018231 File Offset: 0x00016431
		private void tbLoginUser_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				e.Handled = true;
			}
		}

		// Token: 0x06001DB6 RID: 7606 RVA: 0x00018231 File Offset: 0x00016431
		private void tbLoginPassword_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				e.Handled = true;
			}
		}

		// Token: 0x06001DB7 RID: 7607 RVA: 0x001CE2D4 File Offset: 0x001CC4D4
		private void LoginBeta(string userguid, string sessionguid, string email, string admin)
		{
			GameEngine.Instance.World.isBigpointAccount = false;
			this.connectingCancelled = false;
			ProfileLoginWindow.storedUserLoginEmail = email;
			IAuthProvider authProvider = XmlRpcAuthProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressLogin, URLs.ProfileServerPort, URLs.ProfilePath);
			authProvider.LoginBetaUser(new XmlRpcAuthRequest(userguid, "", "", "", null, "", "Kingdoms Client v0.xx", admin)
			{
				SessionID = sessionguid,
				Admin = admin,
				WorldID = new int?(this.lastWorldLoggedIn)
			}, new AuthEndResponseDelegate(this.LoginCallback), this);
			Program.mySettings.Username = ProfileLoginWindow.storedUserLoginEmail;
			Program.mySettings.Save();
		}

		// Token: 0x06001DB8 RID: 7608 RVA: 0x001CE388 File Offset: 0x001CC588
		private void LoginCallback(IAuthProvider sender, IAuthResponse response)
		{
			if (this.connectingCancelled)
			{
				this.openAfterCancel();
				this.manageLoginButton();
				return;
			}
			if (response.SuccessCode != null && response.SuccessCode.Value == 1)
			{
				RemoteServices.Instance.BoxUser = (response.PremiumBox != null && response.PremiumBox.Value == 1);
				GameEngine.Instance.World.ProfileCrowns = response.Crowns.GetValueOrDefault();
				GameEngine.Instance.premiumTokenManager.ProfilePremiumCards = response.PremiumCards.GetValueOrDefault();
				GameEngine.Instance.World.ProfileCardpoints = response.Cardpoints.GetValueOrDefault();
				GameEngine.Instance.World.ProfileNumFriends = response.Friends.GetValueOrDefault();
				GameEngine.Instance.World.isBigpointAccount = response.isBigPoint;
				RemoteServices.Instance.MapEditor = false;
				GameEngine.Instance.World.MapEditing = false;
				GameEngine.Instance.premiumTokenManager.ProfilePremiumTokens.Clear();
				foreach (int key in response.Tokens.Keys)
				{
					GameEngine.Instance.premiumTokenManager.ProfilePremiumTokens.Add(key, response.Tokens[key]);
				}
				GameEngine.Instance.cardsManager.ProfileCards.Clear();
				foreach (int num in response.Cards.Keys)
				{
					GameEngine.Instance.cardsManager.addProfileCard(num, response.Cards[num]);
				}
				GameEngine.Instance.cardPackManager.ProfileCardOffers.Clear();
				foreach (int key2 in response.CardOffers.Keys)
				{
					GameEngine.Instance.cardPackManager.ProfileCardOffers.Add(key2, response.CardOffers[key2]);
				}
				GameEngine.Instance.cardPackManager.ProfileUserCardPacks.Clear();
				foreach (int key3 in response.UserCardPacks.Keys)
				{
					GameEngine.Instance.cardPackManager.ProfileUserCardPacks.Add(key3, response.UserCardPacks[key3]);
				}
				bool[] array = new bool[10];
				int num2 = 0;
				bool flag;
				if (((XmlRpcAuthResponse)response).VeteranLevel1 != null)
				{
					int? num3 = ((XmlRpcAuthResponse)response).VeteranLevel1;
					int num4 = 1;
					flag = (num3.GetValueOrDefault() == num4 & num3 != null);
				}
				else
				{
					flag = false;
				}
				array[num2] = flag;
				int num5 = 1;
				bool flag2;
				if (((XmlRpcAuthResponse)response).VeteranLevel2 != null)
				{
					int? num3 = ((XmlRpcAuthResponse)response).VeteranLevel2;
					int num4 = 1;
					flag2 = (num3.GetValueOrDefault() == num4 & num3 != null);
				}
				else
				{
					flag2 = false;
				}
				array[num5] = flag2;
				int num6 = 2;
				bool flag3;
				if (((XmlRpcAuthResponse)response).VeteranLevel3 != null)
				{
					int? num3 = ((XmlRpcAuthResponse)response).VeteranLevel3;
					int num4 = 1;
					flag3 = (num3.GetValueOrDefault() == num4 & num3 != null);
				}
				else
				{
					flag3 = false;
				}
				array[num6] = flag3;
				int num7 = 3;
				bool flag4;
				if (((XmlRpcAuthResponse)response).VeteranLevel4 != null)
				{
					int? num3 = ((XmlRpcAuthResponse)response).VeteranLevel4;
					int num4 = 1;
					flag4 = (num3.GetValueOrDefault() == num4 & num3 != null);
				}
				else
				{
					flag4 = false;
				}
				array[num7] = flag4;
				int num8 = 4;
				bool flag5;
				if (((XmlRpcAuthResponse)response).VeteranLevel5 != null)
				{
					int? num3 = ((XmlRpcAuthResponse)response).VeteranLevel5;
					int num4 = 1;
					flag5 = (num3.GetValueOrDefault() == num4 & num3 != null);
				}
				else
				{
					flag5 = false;
				}
				array[num8] = flag5;
				int num9 = 5;
				bool flag6;
				if (((XmlRpcAuthResponse)response).VeteranLevel6 != null)
				{
					int? num3 = ((XmlRpcAuthResponse)response).VeteranLevel6;
					int num4 = 1;
					flag6 = (num3.GetValueOrDefault() == num4 & num3 != null);
				}
				else
				{
					flag6 = false;
				}
				array[num9] = flag6;
				int num10 = 6;
				bool flag7;
				if (((XmlRpcAuthResponse)response).VeteranLevel7 != null)
				{
					int? num3 = ((XmlRpcAuthResponse)response).VeteranLevel7;
					int num4 = 1;
					flag7 = (num3.GetValueOrDefault() == num4 & num3 != null);
				}
				else
				{
					flag7 = false;
				}
				array[num10] = flag7;
				int num11 = 7;
				bool flag8;
				if (((XmlRpcAuthResponse)response).VeteranLevel8 != null)
				{
					int? num3 = ((XmlRpcAuthResponse)response).VeteranLevel8;
					int num4 = 1;
					flag8 = (num3.GetValueOrDefault() == num4 & num3 != null);
				}
				else
				{
					flag8 = false;
				}
				array[num11] = flag8;
				int num12 = 8;
				bool flag9;
				if (((XmlRpcAuthResponse)response).VeteranLevel9 != null)
				{
					int? num3 = ((XmlRpcAuthResponse)response).VeteranLevel9;
					int num4 = 1;
					flag9 = (num3.GetValueOrDefault() == num4 & num3 != null);
				}
				else
				{
					flag9 = false;
				}
				array[num12] = flag9;
				int num13 = 9;
				bool flag10;
				if (((XmlRpcAuthResponse)response).VeteranLevel10 != null)
				{
					int? num3 = ((XmlRpcAuthResponse)response).VeteranLevel10;
					int num4 = 1;
					flag10 = (num3.GetValueOrDefault() == num4 & num3 != null);
				}
				else
				{
					flag10 = false;
				}
				array[num13] = flag10;
				bool[] stages = array;
				if (((XmlRpcAuthResponse)response).VeteranLevel6 != null)
				{
					int? num3 = ((XmlRpcAuthResponse)response).VeteranLevel6;
					int num4 = 2;
					if (num3.GetValueOrDefault() == num4 & num3 != null)
					{
						GameEngine.Instance.World.InviteSystemNotImplemented = true;
						goto IL_57F;
					}
				}
				GameEngine.Instance.World.InviteSystemNotImplemented = false;
				IL_57F:
				if (((XmlRpcAuthResponse)response).VeteranCurrentLevel != null && ((XmlRpcAuthResponse)response).VeteranSecondsLeft != null)
				{
					GameEngine.Instance.World.importFreeCardData(((XmlRpcAuthResponse)response).VeteranCurrentLevel.Value, stages, DateTime.Now.AddSeconds((double)((XmlRpcAuthResponse)response).VeteranSecondsLeft.Value), DateTime.Now);
				}
				GameEngine.Instance.cardsManager.calcAvailableCategories();
				FreeCardsData.veteranFreeCardsDuration = response.FreeCardDurations;
				RemoteServices.Instance.UserGuid = new Guid(response.UserGUID);
				RemoteServices.Instance.SessionGuid = new Guid(response.SessionID);
				URLs.GameRPCAddress = this.serverAddr;
				URLs.ChatRPCAddress = this.serverAddr;
				RemoteServices.Instance.init(URLs.GameRPC);
				RemoteServices.Instance.set_LoginUserGuid_UserCallBack(new RemoteServices.LoginUserGuid_UserCallBack(this.loginUserGuid));
				RemoteServices.Instance.LoginUserGuid(ProfileLoginWindow.storedUserLoginEmail, RemoteServices.Instance.UserGuid, RemoteServices.Instance.SessionGuid);
				this.Cursor = Cursors.WaitCursor;
				return;
			}
			if (response.Message == "On Vacation.")
			{
				MyMessageBox.Show(SK.Text("Login_Vacation_Error", "Your Account is currently in Vacation Mode and you are not able to log into this game world at this time."), SK.Text("ProfileLoginWindow_Login_Error", "Login Error"));
				this.btnExit_Click();
				return;
			}
			MyMessageBox.Show(response.Message, SK.Text("ProfileLoginWindow_Login_Error", "Login Error"));
			this.openAfterCancel();
			this.manageLoginButton();
		}

		// Token: 0x06001DB9 RID: 7609 RVA: 0x001CEAD0 File Offset: 0x001CCCD0
		private void RequestGameWorlds(string SessionID, string UserID)
		{
			this.loginButtonActive = false;
			IDictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary.Add(new KeyValuePair<string, string>("uid", UserID));
			dictionary.Add(new KeyValuePair<string, string>("sid", SessionID));
			this.geckoWebBrowser1.Navigate(this.URL_gameWorldPage, dictionary);
		}

		// Token: 0x06001DBA RID: 7610 RVA: 0x0001CB58 File Offset: 0x0001AD58
		public void selfClose()
		{
			this.selfClosing = true;
		}

		// Token: 0x06001DBB RID: 7611 RVA: 0x0001CB61 File Offset: 0x0001AD61
		private void btnExit_Click(object sender, EventArgs e)
		{
			RemoteServices.Instance.UserID = -1;
			this.selfClosing = true;
			base.Close();
		}

		// Token: 0x06001DBC RID: 7612 RVA: 0x0001CB61 File Offset: 0x0001AD61
		public void btnExit_Click()
		{
			RemoteServices.Instance.UserID = -1;
			this.selfClosing = true;
			base.Close();
		}

		// Token: 0x06001DBD RID: 7613 RVA: 0x001CEB20 File Offset: 0x001CCD20
		private void geckoWebBrowser1_ClientFeedback(object sender, EventArgs e)
		{
			this.EnablePanels(true);
			this.geckoWebBrowser1.Enabled = true;
			bool flag = false;
			bool flag2 = false;
			string sessionguid = string.Empty;
			string userguid = string.Empty;
			string email = string.Empty;
			string admin = string.Empty;
			string text = string.Empty;
			string text2 = string.Empty;
			string text3 = string.Empty;
			string text4 = string.Empty;
			string text5 = string.Empty;
			string text6 = "";
			foreach (string text7 in this.geckoWebBrowser1.PageValues.Keys)
			{
				string text8 = text6;
				text6 = string.Concat(new string[]
				{
					text8,
					text7,
					" : ",
					this.geckoWebBrowser1.PageValues[text7],
					" "
				});
				if (text7 != "")
				{
					string text9 = this.geckoWebBrowser1.PageValues[text7];
					if (text7.ToLowerInvariant() == "errorcode" || text7.ToLowerInvariant() == "errorCode")
					{
						int int32FromString = this.getInt32FromString(text9);
						if (int32FromString != 1)
						{
							flag2 = true;
						}
					}
					else if (text7.Trim().ToLowerInvariant() == "switchadmin")
					{
						text2 = text9;
					}
					else if (text7.Trim().ToLowerInvariant() == "switchuser")
					{
						text3 = text9;
					}
					else if (text7.Trim().ToLowerInvariant() == "switchsession")
					{
						text4 = text9;
					}
					else if (text7.Trim().ToLowerInvariant() == "switchemail")
					{
						text5 = text9;
					}
					else if (text7.ToLowerInvariant() == "server" || text7.ToLowerInvariant() == " server")
					{
						flag = true;
						this.serverAddr = text9;
					}
					else if (text7.Trim().ToLowerInvariant() == "email")
					{
						email = text9;
					}
					else if (text7.Trim().ToLowerInvariant() == "sessionguid")
					{
						sessionguid = text9;
					}
					else if (text7.Trim().ToLowerInvariant() == "userguid")
					{
						userguid = text9;
					}
					else if (text7.Trim().ToLowerInvariant() == "adminguid")
					{
						admin = text9;
					}
					else if (text7.Trim().ToLowerInvariant() == "worldname")
					{
						text = text9.Replace('+', ' ');
					}
					else if (text7.Trim().ToLowerInvariant() == "openlink")
					{
						text9 = text9.Replace("%2F", "/");
						Process.Start("https://" + text9);
					}
					else if (text7.Trim().ToLowerInvariant() == "selectedworldid")
					{
						int profileWorldID = -1;
						string s = this.geckoWebBrowser1.PageValues[text7];
						try
						{
							profileWorldID = int.Parse(s, CultureInfo.InvariantCulture);
						}
						catch (Exception)
						{
							profileWorldID = -1;
						}
						RemoteServices.Instance.ProfileWorldID = profileWorldID;
					}
				}
			}
			if (text2.Length > 0 && text3.Length > 0 && text4.Length > 0)
			{
				this.geckoWebBrowser1.Document.Cookie = "";
				this.AdminGUID = text2;
				XmlRpcAuthProvider xmlRpcAuthProvider = XmlRpcAuthProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressLogin, URLs.ProfileServerPort, URLs.ProfilePath);
				XmlRpcAuthRequest req = new XmlRpcAuthRequest(text3, text5, text5, "", text4, "", "", text2);
				this.clearErrorMessages();
				xmlRpcAuthProvider.clientLogin(req, new AuthEndResponseDelegate(this.ClientLoginCallback), this);
				this.EnablePanels(false);
			}
			if (RemoteServices.Instance.ProfileWorldID == 0 || RemoteServices.Instance.ProfileWorldID == -1)
			{
				RemoteServices.Instance.ProfileWorldID = 5;
			}
			if (flag && !flag2 && this.serverAddr.Length > 0)
			{
				if (text != string.Empty)
				{
					Program.WorldName = text;
				}
				this.LoginBeta(userguid, sessionguid, email, admin);
				return;
			}
			if (this.geckoWebBrowser1.Url.AbsoluteUri.ToLowerInvariant().Contains("gotogameworld"))
			{
				if (text6.Length > 0)
				{
					MyMessageBox.Show(SK.Text("ProfileLoginWindow_Connection_Problem", "There was a problem logging in, please check that Kingdoms is not blocked by your firewall or proxy.") + Environment.NewLine + text6);
				}
				else
				{
					MyMessageBox.Show(SK.Text("ProfileLoginWindow_Connection_Problem", "There was a problem logging in, please check that Kingdoms is not blocked by your firewall or proxy.") + Environment.NewLine + SK.Text("ProfileLoginWindow_No_Cookies_Written", "No cookies written!"));
				}
				this.RequestGameWorlds(RemoteServices.Instance.SessionGuid.ToString("N"), RemoteServices.Instance.UserGuid.ToString("N"));
			}
		}

		// Token: 0x06001DBE RID: 7614 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void kingdomsBrowserIE1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
		{
		}

		// Token: 0x06001DBF RID: 7615 RVA: 0x0012C738 File Offset: 0x0012A938
		public int getInt32FromString(string text)
		{
			if (text.Length == 0)
			{
				return 0;
			}
			try
			{
				return Convert.ToInt32(text);
			}
			catch (Exception)
			{
			}
			return 0;
		}

		// Token: 0x06001DC0 RID: 7616 RVA: 0x001CF044 File Offset: 0x001CD244
		private void loginUserGuid(LoginUserGuid_ReturnType returnData)
		{
			if (this.connectingCancelled)
			{
				this.openAfterCancel();
				this.manageLoginButton();
				return;
			}
			this.Cursor = Cursors.Default;
			if (returnData.Success && returnData.m_errorCode == ErrorCodes.ErrorCode.OK)
			{
				RemoteServices.Instance.UserID = returnData.m_userID;
				if (returnData.m_requiresVerification)
				{
					RemoteServices.Instance.RequiresVerification = true;
				}
				else
				{
					RemoteServices.Instance.RequiresVerification = false;
					ProfileLoginWindow.installLoginInfo(returnData);
				}
				RemoteServices.Instance.UserName = returnData.m_userName;
				RemoteServices.Instance.RealName = returnData.m_realName;
				this.UserEntryMode = false;
				this.lblRetrieving.Visible = true;
				this.tandcLabel.Visible = false;
				this.gameRulesLabel.Visible = false;
				this.forumLabel.Visible = false;
				this.supportLabel.Visible = false;
				this.feedbackProgress.Size = new Size(Math.Min(this.pnlFeedback.Width / 11, this.pnlFeedback.Width), this.pnlFeedback.Height);
				this.feedbackProgressArea.invalidate();
				this.cancelButton.Visible = true;
				this.lastCount = -1;
				GameEngine.Instance.cardsManager.addRecentCardsFromServer(returnData.m_RecentCards);
				return;
			}
			string txtMessage = (returnData.m_errorCode == ErrorCodes.ErrorCode.VACATION_MODE_LOGIN_NOT_ALLOWED) ? SK.Text("ProfileLoginWindow_Vacation_Mode_Active", "You cannot login, Vacation Mode is still active.") : ((returnData.m_errorCode == ErrorCodes.ErrorCode.LOGIN_SERVER_INACTIVE) ? returnData.m_maintenanceMessage : ((returnData.m_errorCode != ErrorCodes.ErrorCode.LOGIN_SQL_CONNECTION_ISSUE) ? (SK.Text("ProfileLoginWindow_Login_User_Failed", "Login User Failed") + Environment.NewLine + ErrorCodes.getErrorString(returnData.m_errorCode, returnData.m_errorID)) : SK.Text("ProfileLoginWindow_Connection_Problems", "Connection problems, please try again a little later.")));
			MyMessageBox.Show(txtMessage, SK.Text("ProfileLoginWindow_Login_User_Error", "Login User Error"));
			if (returnData.m_errorCode == ErrorCodes.ErrorCode.LOGIN_NEW_VERSION)
			{
				RemoteServices.Instance.UserID = -1;
				this.selfClosing = true;
				base.Close();
				return;
			}
			this.openAfterCancel();
			this.manageLoginButton();
		}

		// Token: 0x06001DC1 RID: 7617 RVA: 0x001CF250 File Offset: 0x001CD450
		public List<WorldInfo> GetAllPlayedWorlds()
		{
			List<WorldInfo> list = new List<WorldInfo>();
			foreach (WorldInfo worldInfo in ProfileLoginWindow.WorldList)
			{
				if (worldInfo.Playing)
				{
					list.Add(worldInfo);
				}
			}
			return list;
		}

		// Token: 0x06001DC2 RID: 7618 RVA: 0x001CF2B4 File Offset: 0x001CD4B4
		public List<WorldInfo> GetNonPlayedBySupportCulture(string culture)
		{
			List<WorldInfo> list = new List<WorldInfo>();
			foreach (WorldInfo worldInfo in ProfileLoginWindow.WorldList)
			{
				if (!worldInfo.Playing && (worldInfo.Supportculture == culture || culture == "" || (worldInfo.Supportculture == "eu" && culture != "pt" && culture != "wd") || (worldInfo.Supportculture == "pt" && culture == "es") || worldInfo.Supportculture == "wd" || worldInfo.Supportculture == "kg" || worldInfo.Supportculture == "ph" || worldInfo.Supportculture == "ch" || worldInfo.Supportculture == "zh" || (worldInfo.KingdomsWorldID >= 2500 && worldInfo.KingdomsWorldID <= 2599)))
				{
					list.Add(worldInfo);
				}
			}
			if (culture != "")
			{
				ProfileLoginWindow.LastSelectedSupportCulture = culture;
			}
			return list;
		}

		// Token: 0x06001DC3 RID: 7619 RVA: 0x0001CB7B File Offset: 0x0001AD7B
		public List<WorldInfo> GetWorldsBySupportCulture(string culture)
		{
			return this.GetWorldsBySupportCulture(culture, true, 0);
		}

		// Token: 0x06001DC4 RID: 7620 RVA: 0x001CF420 File Offset: 0x001CD620
		public List<WorldInfo> GetWorldsBySupportCulture(string culture, bool includeOwn, int specialMode)
		{
			if (specialMode == 2)
			{
				culture = "";
			}
			List<WorldInfo> list = new List<WorldInfo>();
			foreach (WorldInfo worldInfo in ProfileLoginWindow.WorldList)
			{
				bool flag = ProfileLoginWindow.isSpecialWorld(worldInfo.KingdomsWorldID);
				bool flag2 = ProfileLoginWindow.isAIWorld(worldInfo.KingdomsWorldID);
				bool flag3 = false;
				if (specialMode == 0)
				{
					flag3 = true;
				}
				else if (specialMode == -1 && !flag && !flag2)
				{
					flag3 = true;
				}
				else if (specialMode == 1 && flag)
				{
					flag3 = true;
				}
				else if (specialMode == 2 && flag2)
				{
					flag3 = true;
				}
				if (flag3 && (worldInfo.Supportculture == culture || (worldInfo.Playing && includeOwn) || culture == "" || (worldInfo.Supportculture == "eu" && culture != "pt" && culture != "wd") || (worldInfo.Supportculture == "pt" && culture == "es") || ((worldInfo.Supportculture == "wd" || worldInfo.Supportculture == "kg") && culture != "eu")))
				{
					list.Add(worldInfo);
					if (worldInfo.Playing)
					{
						this.PlayerGameworldCount++;
					}
				}
			}
			list.Sort(delegate(WorldInfo a, WorldInfo b)
			{
				if ((a.Supportculture == culture || a.Supportculture == "kg") && b.Supportculture != culture && b.Supportculture != "kg")
				{
					return -1;
				}
				if ((b.Supportculture == culture || b.Supportculture == "kg") && a.Supportculture != culture && a.Supportculture != "kg")
				{
					return 1;
				}
				if ((a.Supportculture == culture || a.Supportculture == "wd") && b.Supportculture != culture && b.Supportculture != "wd")
				{
					return -1;
				}
				if ((b.Supportculture == culture || b.Supportculture == "wd") && a.Supportculture != culture && a.Supportculture != "wd")
				{
					return 1;
				}
				if ((a.Supportculture == culture || a.Supportculture == "eu") && b.Supportculture != culture && b.Supportculture != "eu")
				{
					return -1;
				}
				if ((b.Supportculture == culture || b.Supportculture == "eu") && a.Supportculture != culture && a.Supportculture != "eu")
				{
					return 1;
				}
				if (a.Playing == b.Playing)
				{
					if (a.Supportculture != b.Supportculture)
					{
						if (a.Supportculture == culture)
						{
							return -1;
						}
						if (b.Supportculture == culture)
						{
							return 1;
						}
						if (a.Supportculture == "eu")
						{
							return -1;
						}
						if (b.Supportculture == "eu")
						{
							return 1;
						}
					}
					return a.KingdomsWorldID.CompareTo(b.KingdomsWorldID);
				}
				return b.Playing.CompareTo(a.Playing);
			});
			if (culture != "")
			{
				ProfileLoginWindow.LastSelectedSupportCulture = culture;
			}
			return list;
		}

		// Token: 0x06001DC5 RID: 7621 RVA: 0x00009262 File Offset: 0x00007462
		public static bool isSpecialWorld(int worldID)
		{
			return false;
		}

		// Token: 0x06001DC6 RID: 7622 RVA: 0x001CF60C File Offset: 0x001CD80C
		public static bool isAIWorld(int worldID)
		{
			return (worldID >= 2500 && worldID < 2599) || (worldID >= 3500 && worldID < 3599) || (worldID >= 1300 && worldID < 1399) || (worldID >= 1200 && worldID < 1299) || (worldID >= 1400 && worldID < 1499);
		}

		// Token: 0x06001DC7 RID: 7623 RVA: 0x001CF674 File Offset: 0x001CD874
		public static void installLoginInfo(LoginUserGuid_ReturnType returnData)
		{
			GameEngine.Instance.World.registerWorldIdentifier(returnData.m_worldID);
			GameEngine.Instance.World.initWorldMap(returnData.m_worldMapType);
			GameEngine.Instance.World.downloadWorldShields(returnData.m_worldID);
			StatTrackingClient.Instance().ActivateTrigger(8, returnData.m_worldID);
			StatTrackingClient.Instance().ActivateTrigger(14, ProfileLoginWindow.LastNumberOfWorldsPlaying);
			VillageMap.setServerTime(returnData.m_currentTime);
			RemoteServices.Instance.SessionID = returnData.m_sessionID;
			RemoteServices.Instance.WorldGUID = new Guid(returnData.m_worldIdentity);
			RemoteServices.Instance.UserFactionID = returnData.m_userFactionID;
			RemoteServices.Instance.Admin = returnData.m_admin;
			RemoteServices.Instance.Moderator = returnData.m_moderator;
			AdminInfoPopup.setMessage(returnData.m_adminMessage);
			RemoteServices.Instance.ShowAdminMessage = returnData.m_showAdminMessage;
			RemoteServices.Instance.Show2ndAgeMessage = returnData.m_show2ndAgeMessage;
			RemoteServices.Instance.Show3rdAgeMessage = returnData.m_show3rdAgeMessage;
			RemoteServices.Instance.Show4thAgeMessage = returnData.m_show4thAgeMessage;
			RemoteServices.Instance.Show5thAgeMessage = returnData.m_show5thAgeMessage;
			RemoteServices.Instance.ReportFilters = returnData.m_reportFilters;
			GameEngine.Instance.initWorldData(returnData.m_worldData);
			if (returnData.m_villageLayoutData != null)
			{
				VillageMap.villageLayout = returnData.m_villageLayoutData;
			}
			if (returnData.m_villageBuildingData != null)
			{
				VillageMap.villageBuildingData = returnData.m_villageBuildingData;
			}
			MarketTransferPanel.addHistory(returnData.m_tradeVillageHistory);
			StockExchangePanel.addHistory(returnData.m_stockExchangeHistory);
			AttackTargetsPanel.addHistory(returnData.m_attackTargetHistory);
			MarketTransferPanel.addFavourites(returnData.m_tradeVillageFavourites);
			StockExchangePanel.addFavourites(returnData.m_stockExchangeFavourites);
			AttackTargetsPanel.addFavourites(returnData.m_attackTargetFavourites);
			if (returnData.FlushCache)
			{
				GameEngine.Instance.World.flushCaches();
			}
			GameEngine.Instance.World.setResearchData(returnData.m_researchData);
			GameEngine.Instance.World.setWorldStartDate(returnData.m_gameStartDate);
			GameEngine.Instance.World.HouseInfo = returnData.m_houseData;
			GameEngine.Instance.World.HouseVoteInfo = returnData.m_houseVoteData;
			RemoteServices.Instance.LoginLeaderInfo = returnData.m_leaderInfo;
			RemoteServices.Instance.UserAvatar = returnData.m_avatarData;
			InterfaceMgr.Instance.processAchievements(returnData.m_achievements);
			GameEngine.Instance.cardsManager.UserCardData = returnData.m_cardData;
			InterfaceMgr.Instance.clearStoredMail();
			GameEngine.Instance.World.resetParishTextReadID();
			RemoteServices.Instance.UserOptions = returnData.m_gameOptions;
			GameEngine.Instance.World.HouseGloryPoints = returnData.m_gloryPoints;
			GameEngine.Instance.World.HouseGloryRoundData = returnData.gloryRoundData;
			GameEngine.Instance.World.setTutorialInfo(returnData.m_questsAndTutorialInfo);
			GameEngine.Instance.World.MostAge4Villages = returnData.mostAge4Villages;
			GameEngine.Instance.World.setTickets(0, returnData.wheel_Treasure1Tickets);
			GameEngine.Instance.World.setTickets(1, returnData.wheel_Treasure2Tickets);
			GameEngine.Instance.World.setTickets(2, returnData.wheel_Treasure3Tickets);
			GameEngine.Instance.World.setTickets(3, returnData.wheel_Treasure4Tickets);
			GameEngine.Instance.World.setTickets(4, returnData.wheel_Treasure5Tickets);
			if (returnData.m_questCompleted != -1)
			{
				GameEngine.Instance.World.addCompletedQuestObjectives(returnData.m_questCompleted);
			}
			GameEngine.Instance.World.setLastTreasureCastleAttackTime(returnData.lastTreasureCastleAttackTime);
			GameEngine.Instance.initCensorText(returnData.words);
			InterfaceMgr.Instance.getMainMenuBar().setAdmin();
			InterfaceMgr.Instance.chatLogin();
			GameEngine.Instance.tryingToJoinCounty = returnData.tryingToJoinCounty;
			GameEngine.Instance.setServerDownTime(returnData.serverDownTime);
			GameEngine.Instance.World.setNewQuestData(returnData.m_newQuestsData);
			GameEngine.Instance.World.setTickets(-1, returnData.m_numQuestTickets);
			NewQuestsPanel.handleClientSideQuestReporting(false);
			GameEngine.Instance.World.lastAttacker = returnData.m_lastAttacker;
			GameEngine.Instance.World.newPlayer = returnData.m_newPlayer;
			GameEngine.Instance.World.lastAttackerLastUpdate = DateTime.Now;
			if (returnData.m_worldData != null && returnData.m_worldData.AIWorld)
			{
				if (returnData.m_secondAgeWorld)
				{
					GameEngine.Instance.World.WorldEnded = true;
				}
				GameEngine.Instance.World.SecondAgeWorld = false;
				GameEngine.Instance.World.ThirdAgeWorld = false;
				GameEngine.Instance.World.FourthAgeWorld = false;
				GameEngine.Instance.World.FifthAgeWorld = false;
				GameEngine.Instance.World.WorldEnded = false;
				GameEngine.Instance.World.SeventhAgeWorld = false;
				GameEngine.Instance.World.SixthAgeWorld = false;
			}
			else
			{
				GameEngine.Instance.World.SecondAgeWorld = returnData.m_secondAgeWorld;
				GameEngine.Instance.World.ThirdAgeWorld = returnData.m_thirdAgeWorld;
				GameEngine.Instance.World.FourthAgeWorld = returnData.m_fourthAgeWorld;
				GameEngine.Instance.World.FifthAgeWorld = returnData.m_fifthAgeWorld;
				GameEngine.Instance.World.WorldEnded = false;
				GameEngine.Instance.World.SeventhAgeWorld = false;
				GameEngine.Instance.World.SixthAgeWorld = false;
				RemoteServices.Instance.Show7thAgeMessage = false;
				RemoteServices.Instance.Show6thAgeMessage = false;
				if (GameEngine.Instance.World.FifthAgeWorld)
				{
					GameEngine.Instance.World.FourthAgeWorld = true;
					GameEngine.Instance.World.ThirdAgeWorld = true;
					GameEngine.Instance.World.SecondAgeWorld = true;
					if (!returnData.m_fourthAgeWorld)
					{
						GameEngine.Instance.World.SixthAgeWorld = true;
					}
					if (!returnData.m_thirdAgeWorld)
					{
						GameEngine.Instance.World.SeventhAgeWorld = true;
					}
					if (!returnData.m_secondAgeWorld)
					{
						GameEngine.Instance.World.WorldEnded = true;
					}
				}
			}
			if (GameEngine.Instance.World.SeventhAgeWorld && returnData.m_show3rdAgeMessage)
			{
				RemoteServices.Instance.Show3rdAgeMessage = false;
				RemoteServices.Instance.Show7thAgeMessage = true;
			}
			if (GameEngine.Instance.World.SixthAgeWorld && returnData.m_show2ndAgeMessage)
			{
				RemoteServices.Instance.Show2ndAgeMessage = false;
				RemoteServices.Instance.Show6thAgeMessage = true;
			}
			GameEngine.Instance.World.UserRelations = returnData.m_userRelationships;
			GameEngine.Instance.World.UserMarkers = returnData.m_userMarkers;
			if (!GameEngine.Instance.World.isIslandWorld())
			{
				WorldMap.TreasureCastle_AttackGap = returnData.m_treasureCastle_AttackGap;
			}
			else
			{
				GameEngine.Instance.World.SpecialSeaConditionsData = returnData.m_treasureCastle_AttackGap;
				WorldMap.TreasureCastle_AttackGap = 86400;
			}
			InterfaceMgr.Instance.chatSetBan(returnData.m_chatBanned);
			if (returnData.m_PendingPrizes != null)
			{
				GameEngine.Instance.World.pendingPrizes = new List<int>(returnData.m_PendingPrizes);
			}
			else
			{
				GameEngine.Instance.World.pendingPrizes = new List<int>();
			}
			if (ProfileLoginWindow.lastLoadedEmail.Length == 0)
			{
				ProfileLoginWindow.lastLoadedEmail = ProfileLoginWindow.storedUserLoginEmail;
			}
			else if (ProfileLoginWindow.lastLoadedEmail.ToLowerInvariant() != ProfileLoginWindow.storedUserLoginEmail.ToLowerInvariant())
			{
				int level = 0;
				if (ProfileLoginWindow.lastLoadedEmail2.Length == 0)
				{
					ProfileLoginWindow.lastLoadedEmail2 = ProfileLoginWindow.storedUserLoginEmail;
				}
				else
				{
					level = 1;
				}
				GameEngine.Instance.World.maybeMultiAccount(level);
			}
			bool showGloryResults = returnData.m_showGloryResults;
			GameEngine.Instance.World.showGloryResults = returnData.m_showGloryResults;
			GameEngine.Instance.World.RetrievePreviousContestIDs();
			GameEngine.Instance.cardsManager.ResetPremiumOffers();
			GameEngine.Instance.cardsManager.RetrievePremiumOffers();
		}

		// Token: 0x06001DC8 RID: 7624 RVA: 0x0001CB86 File Offset: 0x0001AD86
		private void manageLoginButton()
		{
			bool flag = this.loginButtonActive;
		}

		// Token: 0x06001DC9 RID: 7625 RVA: 0x0001CB8F File Offset: 0x0001AD8F
		private void tbLoginUser_TextChanged(object sender, EventArgs e)
		{
			this.manageLoginButton();
		}

		// Token: 0x06001DCA RID: 7626 RVA: 0x0001CB8F File Offset: 0x0001AD8F
		private void tbLoginPassword_TextChanged(object sender, EventArgs e)
		{
			this.manageLoginButton();
		}

		// Token: 0x06001DCB RID: 7627 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void geckoWebBrowser1_DocumentCompleted(object sender, EventArgs e)
		{
		}

		// Token: 0x06001DCC RID: 7628 RVA: 0x0001CB97 File Offset: 0x0001AD97
		private void geckoWebBrowser1_StatusTextChanged(object sender, EventArgs e)
		{
			string statusText = this.geckoWebBrowser1.StatusText;
		}

		// Token: 0x06001DCD RID: 7629 RVA: 0x0001CBA5 File Offset: 0x0001ADA5
		public void SetEmailOptInState(bool state)
		{
			this.emailOptInState = state;
		}

		// Token: 0x06001DCE RID: 7630 RVA: 0x001CFE38 File Offset: 0x001CE038
		public void update()
		{
			if (this.initialisedLanguage != Program.mySettings.LanguageIdent)
			{
				if (this.joinImage != null)
				{
					this.joinImage.Dispose();
				}
				if (this.joinImageOver != null)
				{
					this.joinImageOver.Dispose();
				}
				if (this.playImage != null)
				{
					this.playImage.Dispose();
				}
				if (this.playImageOver != null)
				{
					this.playImageOver.Dispose();
				}
				if (this.loginImage != null)
				{
					this.loginImage.Dispose();
				}
				if (this.logoutImage != null)
				{
					this.logoutImage.Dispose();
				}
				if (this.loginImageOver != null)
				{
					this.loginImageOver.Dispose();
				}
				if (this.closedImage != null)
				{
					this.closedImage.Dispose();
				}
				if (this.closedImageOver != null)
				{
					this.closedImageOver.Dispose();
				}
				if (this.logoutImageOver != null)
				{
					this.logoutImageOver.Dispose();
				}
				if (this.newsImage != null)
				{
					this.newsImage.Dispose();
				}
				if (this.newsImageOver != null)
				{
					this.newsImageOver.Dispose();
				}
				if (this.accountImage != null)
				{
					this.accountImage.Dispose();
				}
				if (this.accountImageOver != null)
				{
					this.accountImageOver.Dispose();
				}
				if (this.exitImage != null)
				{
					this.exitImage.Dispose();
				}
				if (this.exitImageOver != null)
				{
					this.exitImageOver.Dispose();
				}
				if (this.cancelImage != null)
				{
					this.cancelImage.Dispose();
				}
				if (this.cancelImageOver != null)
				{
					this.cancelImageOver.Dispose();
				}
				if (this.forgottenImage != null)
				{
					this.forgottenImage.Dispose();
				}
				if (this.forgottenImageOver != null)
				{
					this.forgottenImageOver.Dispose();
				}
				if (this.selectImage != null)
				{
					this.selectImage.Dispose();
				}
				if (this.selectImageOver != null)
				{
					this.selectImageOver.Dispose();
				}
				if (this.createAccountImage != null)
				{
					this.createAccountImage.Dispose();
				}
				if (this.createAccountImageOver != null)
				{
					this.createAccountImageOver.Dispose();
				}
				if (this.createAccountImage2 != null)
				{
					this.createAccountImage2.Dispose();
				}
				if (this.createAccountImageOver2 != null)
				{
					this.createAccountImageOver2.Dispose();
				}
				if (this.optionsImage != null)
				{
					this.optionsImage.Dispose();
				}
				if (this.optionsImageOver != null)
				{
					this.optionsImageOver.Dispose();
				}
				this.joinImage = (this.joinImageOver = (this.playImage = (this.playImageOver = (this.loginImage = (this.logoutImage = (this.loginImageOver = (this.closedImage = (this.closedImageOver = (this.logoutImageOver = (this.newsImage = (this.newsImageOver = (this.accountImage = (this.accountImageOver = (this.exitImage = (this.exitImageOver = (this.cancelImage = (this.cancelImageOver = (this.forgottenImage = (this.forgottenImageOver = (this.selectImage = (this.selectImageOver = (this.createAccountImage = (this.createAccountImageOver = (this.createAccountImage2 = (this.createAccountImageOver2 = (this.optionsImage = (this.optionsImageOver = null)))))))))))))))))))))))))));
				if (WorldSelectPopupPanel.closeImage != null)
				{
					WorldSelectPopupPanel.closeImage.Dispose();
				}
				if (WorldSelectPopupPanel.closeImageOver != null)
				{
					WorldSelectPopupPanel.closeImageOver.Dispose();
				}
				if (WorldSelectPopupPanel.selectImageSelected != null)
				{
					WorldSelectPopupPanel.selectImageSelected.Dispose();
				}
				if (WorldSelectPopupPanel.selectImage != null)
				{
					WorldSelectPopupPanel.selectImage.Dispose();
				}
				if (WorldSelectPopupPanel.selectImageOver != null)
				{
					WorldSelectPopupPanel.selectImageOver.Dispose();
				}
				if (WorldSelectPopupPanel.selectSpecialImage != null)
				{
					WorldSelectPopupPanel.selectSpecialImage.Dispose();
				}
				if (WorldSelectPopupPanel.selectSpecialImageSelected != null)
				{
					WorldSelectPopupPanel.selectSpecialImageSelected.Dispose();
				}
				if (WorldSelectPopupPanel.selectSpecialImageOver != null)
				{
					WorldSelectPopupPanel.selectSpecialImageOver.Dispose();
				}
				if (WorldSelectPopupPanel.selectAIImage != null)
				{
					WorldSelectPopupPanel.selectAIImage.Dispose();
				}
				if (WorldSelectPopupPanel.selectAIImageSelected != null)
				{
					WorldSelectPopupPanel.selectAIImageSelected.Dispose();
				}
				if (WorldSelectPopupPanel.selectAIImageOver != null)
				{
					WorldSelectPopupPanel.selectAIImageOver.Dispose();
				}
				if (WorldSelectPopupPanel.joinImage != null)
				{
					WorldSelectPopupPanel.joinImage.Dispose();
				}
				if (WorldSelectPopupPanel.joinImageOver != null)
				{
					WorldSelectPopupPanel.joinImageOver.Dispose();
				}
				if (WorldSelectPopupPanel.playImage != null)
				{
					WorldSelectPopupPanel.playImage.Dispose();
				}
				if (WorldSelectPopupPanel.playImageOver != null)
				{
					WorldSelectPopupPanel.playImageOver.Dispose();
				}
				if (WorldSelectPopupPanel.closedImage != null)
				{
					WorldSelectPopupPanel.closedImage.Dispose();
				}
				WorldSelectPopupPanel.closeImage = (WorldSelectPopupPanel.closeImageOver = (WorldSelectPopupPanel.selectImageSelected = (WorldSelectPopupPanel.selectImage = (WorldSelectPopupPanel.selectImageOver = (WorldSelectPopupPanel.selectSpecialImage = (WorldSelectPopupPanel.selectSpecialImageSelected = (WorldSelectPopupPanel.selectSpecialImageOver = (WorldSelectPopupPanel.selectAIImage = (WorldSelectPopupPanel.selectAIImageSelected = (WorldSelectPopupPanel.selectAIImageOver = (WorldSelectPopupPanel.joinImage = (WorldSelectPopupPanel.joinImageOver = (WorldSelectPopupPanel.playImage = (WorldSelectPopupPanel.playImageOver = (WorldSelectPopupPanel.closedImage = null)))))))))))))));
				if (BPPopupPanel.closeImage != null)
				{
					BPPopupPanel.closeImage.Dispose();
				}
				if (BPPopupPanel.closeImageOver != null)
				{
					BPPopupPanel.closeImageOver.Dispose();
				}
				if (BPPopupPanel.completeImage != null)
				{
					BPPopupPanel.completeImage.Dispose();
				}
				if (BPPopupPanel.completeImageOver != null)
				{
					BPPopupPanel.completeImageOver.Dispose();
				}
				BPPopupPanel.closeImage = (BPPopupPanel.closeImageOver = (BPPopupPanel.completeImage = (BPPopupPanel.completeImageOver = null)));
				if (CreatePopupPanel.nextImage != null)
				{
					CreatePopupPanel.nextImage.Dispose();
				}
				if (CreatePopupPanel.nextImageOver != null)
				{
					CreatePopupPanel.nextImageOver.Dispose();
				}
				if (CreatePopupPanel.headerImage != null)
				{
					CreatePopupPanel.headerImage.Dispose();
				}
				if (CreatePopupPanel.headerTransferImage != null)
				{
					CreatePopupPanel.headerTransferImage.Dispose();
				}
				if (CreatePopupPanel.closeImage != null)
				{
					CreatePopupPanel.closeImage.Dispose();
				}
				if (CreatePopupPanel.closeImageOver != null)
				{
					CreatePopupPanel.closeImageOver.Dispose();
				}
				if (CreatePopupPanel.transferImage != null)
				{
					CreatePopupPanel.transferImage.Dispose();
				}
				if (CreatePopupPanel.transferImageOver != null)
				{
					CreatePopupPanel.transferImageOver.Dispose();
				}
				CreatePopupPanel.nextImage = (CreatePopupPanel.nextImageOver = (CreatePopupPanel.headerImage = (CreatePopupPanel.headerTransferImage = (CreatePopupPanel.closeImage = (CreatePopupPanel.closeImageOver = (CreatePopupPanel.transferImage = (CreatePopupPanel.transferImageOver = null)))))));
				if (VacationCancelPopupPanel.cancelImageOver != null)
				{
					VacationCancelPopupPanel.cancelImageOver.Dispose();
				}
				if (VacationCancelPopupPanel.closeImage != null)
				{
					VacationCancelPopupPanel.closeImage.Dispose();
				}
				if (VacationCancelPopupPanel.closeImageOver != null)
				{
					VacationCancelPopupPanel.closeImageOver.Dispose();
				}
				if (VacationCancelPopupPanel.headerImage != null)
				{
					VacationCancelPopupPanel.headerImage.Dispose();
				}
				if (VacationCancelPopupPanel.cancelImage != null)
				{
					VacationCancelPopupPanel.cancelImage.Dispose();
				}
				VacationCancelPopupPanel.closeImage = (VacationCancelPopupPanel.closeImageOver = (VacationCancelPopupPanel.headerImage = (VacationCancelPopupPanel.cancelImage = (VacationCancelPopupPanel.cancelImageOver = null))));
				if (this.chkAutoLogin != null)
				{
					this.chkAutoLogin.Checked = false;
				}
				this.init();
				if (this.chkAutoLogin != null)
				{
					this.chkAutoLogin.Checked = false;
				}
				base.Invalidate();
				return;
			}
			if (this.delayedCreateUserOpen)
			{
				this.delayedCreateUserOpen = false;
				this.ShowCreateUserForm();
				return;
			}
			if (this.emailOptInPopup)
			{
				this.emailOptInPopup = false;
				new EmailOptInPopup
				{
					m_Parent = this
				}.ShowDialog(Program.profileLogin);
				int value = 0;
				if (this.emailOptInState)
				{
					value = 1;
				}
				XmlRpcAuthProvider xmlRpcAuthProvider = XmlRpcAuthProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressLogin, URLs.ProfileServerPort, URLs.ProfilePath);
				XmlRpcAuthRequest req = new XmlRpcAuthRequest(RemoteServices.Instance.UserGuid.ToString().Replace("-", ""), "", "", "", RemoteServices.Instance.SessionGuid.ToString().Replace("-", ""), "", "", "", new int?(0), new int?(0), new int?(value));
				xmlRpcAuthProvider.SetEmailOptIn(req, new AuthEndResponseDelegate(this.EmailOptInCallback), this);
			}
			InterfaceMgr.Instance.runTooltips();
			if (this.lastLogoutClicked != DateTime.MinValue && (DateTime.Now - this.lastLogoutClicked).TotalSeconds > 60.0)
			{
				this.lastLogoutClicked = DateTime.MinValue;
			}
			int downloadingCounter = GameEngine.Instance.World.downloadingCounter;
			if (downloadingCounter != this.lastCount)
			{
				string text = SK.Text("ConnectingPopup_Retrieving_Data", "Retrieving Data From Server.");
				for (int i = 0; i < downloadingCounter; i++)
				{
					text += ".";
				}
				this.lblRetrieving.Text = text;
				if (this.lblRetrieving.Visible)
				{
					this.Text = this.defaultWindowTitle + " - " + this.lblRetrieving.Text;
				}
				this.lastCount = downloadingCounter;
				if (this.lblRetrieving.Visible)
				{
					this.feedbackProgress.Size = new Size(Math.Min(this.pnlFeedback.Width * (downloadingCounter + 2) / 12, this.pnlFeedback.Width), this.pnlFeedback.Height);
				}
				else
				{
					this.feedbackProgress.Size = new Size(0, this.pnlFeedback.Height);
				}
				this.feedbackProgressArea.invalidate();
			}
			if (InterfaceMgr.Instance.isCreatePopup() || InterfaceMgr.Instance.isVacationCancelPopupWindow() || InterfaceMgr.Instance.isBPPopup() || InterfaceMgr.Instance.isWorldSelectPopup())
			{
				InterfaceMgr.Instance.updatePopups();
			}
		}

		// Token: 0x06001DCF RID: 7631 RVA: 0x001D0724 File Offset: 0x001CE924
		private void EmailOptInCallback(IAuthProvider sender, IAuthResponse response)
		{
			int? successCode = response.SuccessCode;
			int num = 1;
			bool flag = successCode.GetValueOrDefault() == num & successCode != null;
		}

		// Token: 0x06001DD0 RID: 7632 RVA: 0x001D0750 File Offset: 0x001CE950
		private void cancelClick()
		{
			this.Cursor = Cursors.Default;
			this.connectingCancelled = true;
			GameEngine.Instance.forceRelogin();
			GameEngine.Instance.sessionExpired(-1);
			this.feedbackProgressArea.invalidate();
			while (GameEngine.Instance.World.isWorkerThreadAlive())
			{
				Thread.Sleep(200);
				Program.DoEvents();
			}
		}

		// Token: 0x06001DD1 RID: 7633 RVA: 0x001D07B4 File Offset: 0x001CE9B4
		public void openAfterCancel()
		{
			this.lblRetrieving.Visible = false;
			this.tandcLabel.Visible = true;
			this.gameRulesLabel.Visible = true;
			this.forumLabel.Visible = true;
			this.supportLabel.Visible = true;
			this.feedbackProgress.Size = new Size(0, this.pnlFeedback.Height);
			this.Text = this.defaultWindowTitle;
			this.cancelButton.Visible = false;
			this.feedbackProgressArea.invalidate();
			this.UserEntryMode = true;
			this.EnablePanels(true);
		}

		// Token: 0x06001DD2 RID: 7634 RVA: 0x001D084C File Offset: 0x001CEA4C
		private void ProfileLoginWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			CloseReason closeReason = e.CloseReason;
			if (closeReason == CloseReason.UserClosing && !this.selfClosing)
			{
				GameEngine.Instance.appClosing();
				RemoteServices.Instance.UserID = -1;
			}
		}

		// Token: 0x06001DD3 RID: 7635 RVA: 0x0001CBAE File Offset: 0x0001ADAE
		private void ProfileLoginWindow_LocationChanged(object sender, EventArgs e)
		{
			InterfaceMgr.Instance.moveGreyOutWindow();
			InterfaceMgr.Instance.moveCreatePopupWindow();
		}

		// Token: 0x06001DD4 RID: 7636 RVA: 0x001D0884 File Offset: 0x001CEA84
		private void shkruClick()
		{
			new Process
			{
				StartInfo = 
				{
					FileName = "www.vk.com/shkru"
				}
			}.Start();
		}

		// Token: 0x06001DD5 RID: 7637 RVA: 0x001D08B0 File Offset: 0x001CEAB0
		private void facebookClick()
		{
			new Process
			{
				StartInfo = 
				{
					FileName = URLs.FacebookURL
				}
			}.Start();
		}

		// Token: 0x06001DD6 RID: 7638 RVA: 0x001D08DC File Offset: 0x001CEADC
		private void youtubeClick()
		{
			new Process
			{
				StartInfo = 
				{
					FileName = URLs.YoutubeURL
				}
			}.Start();
		}

		// Token: 0x06001DD7 RID: 7639 RVA: 0x001D0908 File Offset: 0x001CEB08
		private void twitterClick()
		{
			new Process
			{
				StartInfo = 
				{
					FileName = URLs.TwitterURL
				}
			}.Start();
		}

		// Token: 0x06001DD8 RID: 7640 RVA: 0x001D0934 File Offset: 0x001CEB34
		private void ProfileLoginWindow_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (this.LoginPanelControls_Feedback != null)
			{
				this.LoginPanelControls_Feedback.PanelActive = false;
			}
			if (this.LoginPanelControls_LoggedIn != null)
			{
				this.LoginPanelControls_LoggedIn.PanelActive = false;
			}
			if (this.LoginPanelControls_LoggedOut != null)
			{
				this.LoginPanelControls_LoggedOut.PanelActive = false;
			}
			if (this.LoginPanelControls_Feedback != null)
			{
				this.LoginPanelControls_Feedback.PanelActive = false;
			}
			if (this.BrowserTabsControls != null)
			{
				this.BrowserTabsControls.PanelActive = false;
			}
			if (this.WorldsPanelcontrols_LoggedIn != null)
			{
				this.WorldsPanelcontrols_LoggedIn.PanelActive = false;
			}
			if (this.WorldsPanelcontrols_LoggedOut != null)
			{
				this.WorldsPanelcontrols_LoggedOut.PanelActive = false;
			}
			if (this.joinImage != null)
			{
				this.joinImage.Dispose();
			}
			if (this.joinImageOver != null)
			{
				this.joinImageOver.Dispose();
			}
			if (this.playImage != null)
			{
				this.playImage.Dispose();
			}
			if (this.playImageOver != null)
			{
				this.playImageOver.Dispose();
			}
			if (this.loginImage != null)
			{
				this.loginImage.Dispose();
			}
			if (this.logoutImage != null)
			{
				this.logoutImage.Dispose();
			}
			if (this.loginImageOver != null)
			{
				this.loginImageOver.Dispose();
			}
			if (this.closedImage != null)
			{
				this.closedImage.Dispose();
			}
			if (this.closedImageOver != null)
			{
				this.closedImageOver.Dispose();
			}
			if (this.logoutImageOver != null)
			{
				this.logoutImageOver.Dispose();
			}
			if (this.newsImage != null)
			{
				this.newsImage.Dispose();
			}
			if (this.newsImageOver != null)
			{
				this.newsImageOver.Dispose();
			}
			if (this.accountImage != null)
			{
				this.accountImage.Dispose();
			}
			if (this.accountImageOver != null)
			{
				this.accountImageOver.Dispose();
			}
			if (this.exitImage != null)
			{
				this.exitImage.Dispose();
			}
			if (this.exitImageOver != null)
			{
				this.exitImageOver.Dispose();
			}
			if (this.cancelImage != null)
			{
				this.cancelImage.Dispose();
			}
			if (this.cancelImageOver != null)
			{
				this.cancelImageOver.Dispose();
			}
			if (this.forgottenImage != null)
			{
				this.forgottenImage.Dispose();
			}
			if (this.forgottenImageOver != null)
			{
				this.forgottenImageOver.Dispose();
			}
			if (this.selectImage != null)
			{
				this.selectImage.Dispose();
			}
			if (this.selectImageOver != null)
			{
				this.selectImageOver.Dispose();
			}
			if (this.createAccountImage != null)
			{
				this.createAccountImage.Dispose();
			}
			if (this.createAccountImageOver != null)
			{
				this.createAccountImageOver.Dispose();
			}
			if (this.createAccountImage2 != null)
			{
				this.createAccountImage2.Dispose();
			}
			if (this.createAccountImageOver2 != null)
			{
				this.createAccountImageOver2.Dispose();
			}
			if (this.optionsImage != null)
			{
				this.optionsImage.Dispose();
			}
			if (this.optionsImageOver != null)
			{
				this.optionsImageOver.Dispose();
			}
			if (this.GreyoutLogin != null && this.GreyoutLogin.Image != null)
			{
				this.GreyoutLogin.Image.Dispose();
				this.GreyoutLogin.Image = null;
			}
			if (this.GreyoutTabs != null && this.GreyoutTabs.Image != null)
			{
				this.GreyoutTabs.Image.Dispose();
				this.GreyoutTabs.Image = null;
			}
			if (this.GreyoutWorlds != null && this.GreyoutWorlds.Image != null)
			{
				this.GreyoutWorlds.Image.Dispose();
				this.GreyoutWorlds.Image = null;
			}
		}

		// Token: 0x06001DD9 RID: 7641 RVA: 0x001D0C74 File Offset: 0x001CEE74
		public static string getWorldShortDesc(WorldInfo world)
		{
			if (world.Supportculture == "ru" && world.MapCulture == "ru")
			{
				string text = world.ShortDesc.Replace("*", "");
				return text.Replace("World", "Мир");
			}
			return world.ShortDesc.Replace("*", "");
		}

		// Token: 0x04002E0A RID: 11786
		public static bool NewWorldsAvailable = false;

		// Token: 0x04002E0B RID: 11787
		private string strOnline = SK.Text("WORLD_Online", "Online");

		// Token: 0x04002E0C RID: 11788
		private string strOffline = SK.Text("WORLD_Offline", "Offline");

		// Token: 0x04002E0D RID: 11789
		private string strWorldEnded = SK.Text("WorldEnded", "This World has ended.");

		// Token: 0x04002E0E RID: 11790
		private string strJoin = SK.Text("WORLD_Join", "Join");

		// Token: 0x04002E0F RID: 11791
		private string strClosed = SK.Text("FactionInvites_Membership_closed", "Closed");

		// Token: 0x04002E10 RID: 11792
		private string strPlay = SK.Text("WORLD_Play", "Play");

		// Token: 0x04002E11 RID: 11793
		private string strSelect = SK.Text("WORLD_Select", "Select World");

		// Token: 0x04002E12 RID: 11794
		private string strEmailAddress = SK.Text("LOGIN_Email", "Email Address");

		// Token: 0x04002E13 RID: 11795
		private string strPassword = SK.Text("LOGIN_Password", "Password");

		// Token: 0x04002E14 RID: 11796
		private string strLogin = SK.Text("LOGIN_Login", "Login");

		// Token: 0x04002E15 RID: 11797
		private string strLogout = SK.Text("LogoutPanel_Logout", "Logout");

		// Token: 0x04002E16 RID: 11798
		private string strNews = SK.Text("LOGIN_News", "News");

		// Token: 0x04002E17 RID: 11799
		private string strCreateAccount = SK.Text("LOGIN_CreateAccount", "Create Account");

		// Token: 0x04002E18 RID: 11800
		private string strOptions = SK.Text("MENU_Settings", "Settings");

		// Token: 0x04002E19 RID: 11801
		private string strAccountDetails = SK.Text("LOGIN_AccountDetails", "Account Details");

		// Token: 0x04002E1A RID: 11802
		private string strGenericLoginError = SK.Text("LOGIN_GenericLoginError", "Login Failed: Please check that your email and password are entered correctly.");

		// Token: 0x04002E1B RID: 11803
		private string strGenericLoginErrorConnection = SK.Text("LOGIN_GenericLoginErrorConnection", "Login Failed: There is a problem connecting to the Login Server.");

		// Token: 0x04002E1C RID: 11804
		private string strForgottenPassword = SK.Text("LOGIN_ForgottenPassword", "Forgotten Password");

		// Token: 0x04002E1D RID: 11805
		private string strExit = SK.Text("GENERIC_Exit", "Exit");

		// Token: 0x04002E1E RID: 11806
		private string strCancel = SK.Text("GENERIC_Cancel", "Cancel");

		// Token: 0x04002E1F RID: 11807
		private string AdminGUID;

		// Token: 0x04002E20 RID: 11808
		private Font WebTextFontBold = FontManager.GetPrivateFont("AssetIcons/Cards/panel/Brokenscript-Bold.ttf", 10f, FontStyle.Bold);

		// Token: 0x04002E21 RID: 11809
		private Font WebTextFontBoldCond = FontManager.GetPrivateFont("AssetIcons/Cards/panel/Brokenscript-BoldCond.ttf", 10f, FontStyle.Bold);

		// Token: 0x04002E22 RID: 11810
		private Color WebButtonblue = Color.FromArgb(85, 145, 203);

		// Token: 0x04002E23 RID: 11811
		private Color WebButtonRed = Color.FromArgb(160, 0, 0);

		// Token: 0x04002E24 RID: 11812
		private Color WebButtonYellow = Color.FromArgb(225, 225, 0);

		// Token: 0x04002E25 RID: 11813
		private Color WebButtonGrey = Color.FromArgb(225, 225, 225);

		// Token: 0x04002E26 RID: 11814
		private int WebButtonWidth = 60;

		// Token: 0x04002E27 RID: 11815
		private int WebButtonheight = 22;

		// Token: 0x04002E28 RID: 11816
		private int WebButtonRadius = 10;

		// Token: 0x04002E29 RID: 11817
		private Image joinImage;

		// Token: 0x04002E2A RID: 11818
		private Image joinImageOver;

		// Token: 0x04002E2B RID: 11819
		private Image playImage;

		// Token: 0x04002E2C RID: 11820
		private Image playImageOver;

		// Token: 0x04002E2D RID: 11821
		private Image loginImage;

		// Token: 0x04002E2E RID: 11822
		private Image logoutImage;

		// Token: 0x04002E2F RID: 11823
		private Image loginImageOver;

		// Token: 0x04002E30 RID: 11824
		private Image closedImage;

		// Token: 0x04002E31 RID: 11825
		private Image closedImageOver;

		// Token: 0x04002E32 RID: 11826
		private Image logoutImageOver;

		// Token: 0x04002E33 RID: 11827
		private Image newsImage;

		// Token: 0x04002E34 RID: 11828
		private Image newsImageOver;

		// Token: 0x04002E35 RID: 11829
		private Image accountImage;

		// Token: 0x04002E36 RID: 11830
		private Image accountImageOver;

		// Token: 0x04002E37 RID: 11831
		private Image exitImage;

		// Token: 0x04002E38 RID: 11832
		private Image exitImageOver;

		// Token: 0x04002E39 RID: 11833
		private Image cancelImage;

		// Token: 0x04002E3A RID: 11834
		private Image cancelImageOver;

		// Token: 0x04002E3B RID: 11835
		private Image forgottenImage;

		// Token: 0x04002E3C RID: 11836
		private Image forgottenImageOver;

		// Token: 0x04002E3D RID: 11837
		private Image selectImage;

		// Token: 0x04002E3E RID: 11838
		private Image selectImageOver;

		// Token: 0x04002E3F RID: 11839
		private Image createAccountImage;

		// Token: 0x04002E40 RID: 11840
		private Image createAccountImageOver;

		// Token: 0x04002E41 RID: 11841
		private Image createAccountImage2;

		// Token: 0x04002E42 RID: 11842
		private Image createAccountImageOver2;

		// Token: 0x04002E43 RID: 11843
		private Image optionsImage;

		// Token: 0x04002E44 RID: 11844
		private Image optionsImageOver;

		// Token: 0x04002E45 RID: 11845
		private int worldControlWidth = 45;

		// Token: 0x04002E46 RID: 11846
		private int worldControlHeight = 24;

		// Token: 0x04002E47 RID: 11847
		private string serverAddr = string.Empty;

		// Token: 0x04002E48 RID: 11848
		private bool ignoreEmailChange;

		// Token: 0x04002E49 RID: 11849
		public static Dictionary<string, LocalizationLanguage> LanguageList;

		// Token: 0x04002E4A RID: 11850
		public static Dictionary<string, string> ShieldURL = new Dictionary<string, string>();

		// Token: 0x04002E4B RID: 11851
		public static Dictionary<string, Image> ShieldImage = new Dictionary<string, Image>();

		// Token: 0x04002E4C RID: 11852
		public CustomSelfDrawPanel LoginPanelControls_LoggedOut;

		// Token: 0x04002E4D RID: 11853
		public TextBox txtEmail;

		// Token: 0x04002E4E RID: 11854
		public CustomSelfDrawPanel.CSDLabel lblEmailSteam;

		// Token: 0x04002E4F RID: 11855
		public CustomSelfDrawPanel.CSDLabel lblEmail;

		// Token: 0x04002E50 RID: 11856
		public TextBox txtPassword;

		// Token: 0x04002E51 RID: 11857
		public CustomSelfDrawPanel.CSDLabel lblPassword;

		// Token: 0x04002E52 RID: 11858
		public CustomSelfDrawPanel.CSDLabel lblConnectionInfo;

		// Token: 0x04002E53 RID: 11859
		public CustomSelfDrawPanel.CSDImage btnLogin;

		// Token: 0x04002E54 RID: 11860
		public CustomSelfDrawPanel.CSDButton btnLoginFB;

		// Token: 0x04002E55 RID: 11861
		public CustomSelfDrawPanel.CSDLabel lblLoginError;

		// Token: 0x04002E56 RID: 11862
		public CustomSelfDrawPanel LoginPanelControls_LoggedIn;

		// Token: 0x04002E57 RID: 11863
		public CustomSelfDrawPanel.CSDImage btnClientLogout;

		// Token: 0x04002E58 RID: 11864
		public CustomSelfDrawPanel.CSDImage btnShieldDesigner;

		// Token: 0x04002E59 RID: 11865
		public CustomSelfDrawPanel.CSDImage lblUsername;

		// Token: 0x04002E5A RID: 11866
		public CustomSelfDrawPanel.CSDCheckBox chkAutoLogin;

		// Token: 0x04002E5B RID: 11867
		public CustomSelfDrawPanel.CSDLabel lblNewWorlds;

		// Token: 0x04002E5C RID: 11868
		public CustomSelfDrawPanel WorldsPanelcontrols_LoggedOut;

		// Token: 0x04002E5D RID: 11869
		public CustomSelfDrawPanel.CSDLabel lblWorldsOfflineError;

		// Token: 0x04002E5E RID: 11870
		public List<CustomSelfDrawPanel.CSDControl> loggedOutWorldControls;

		// Token: 0x04002E5F RID: 11871
		public CustomSelfDrawPanel WorldsPanelcontrols_LoggedIn;

		// Token: 0x04002E60 RID: 11872
		public CustomSelfDrawPanel.CSDLabel lblWorldsOnlineError;

		// Token: 0x04002E61 RID: 11873
		public List<CustomSelfDrawPanel.CSDControl> loggedInWorldControls;

		// Token: 0x04002E62 RID: 11874
		public CustomSelfDrawPanel BrowserTabsControls;

		// Token: 0x04002E63 RID: 11875
		public CustomSelfDrawPanel LoginPanelControls_Feedback;

		// Token: 0x04002E64 RID: 11876
		public CustomSelfDrawPanel.CSDImage exitButton;

		// Token: 0x04002E65 RID: 11877
		public CustomSelfDrawPanel.CSDImage cancelButton;

		// Token: 0x04002E66 RID: 11878
		public CustomSelfDrawPanel.CSDLabel lblRetrieving;

		// Token: 0x04002E67 RID: 11879
		public CustomSelfDrawPanel.CSDLabel lblVersion;

		// Token: 0x04002E68 RID: 11880
		public CustomSelfDrawPanel.CSDLine feedbackLine;

		// Token: 0x04002E69 RID: 11881
		public CustomSelfDrawPanel.CSDFill feedbackProgress;

		// Token: 0x04002E6A RID: 11882
		public CustomSelfDrawPanel.CSDArea feedbackProgressArea;

		// Token: 0x04002E6B RID: 11883
		private List<CustomSelfDrawPanel.CSDControl> allButtons;

		// Token: 0x04002E6C RID: 11884
		public CustomSelfDrawPanel.CSDLabel tandcLabel;

		// Token: 0x04002E6D RID: 11885
		public CustomSelfDrawPanel.CSDLabel gameRulesLabel;

		// Token: 0x04002E6E RID: 11886
		public CustomSelfDrawPanel.CSDLabel supportLabel;

		// Token: 0x04002E6F RID: 11887
		public CustomSelfDrawPanel.CSDLabel forumLabel;

		// Token: 0x04002E70 RID: 11888
		public Uri URL_landingPage;

		// Token: 0x04002E71 RID: 11889
		public Uri URL_gameWorldPage;

		// Token: 0x04002E72 RID: 11890
		public CustomSelfDrawPanel.CSDImage GreyoutWorlds;

		// Token: 0x04002E73 RID: 11891
		public CustomSelfDrawPanel.CSDImage GreyoutLogin;

		// Token: 0x04002E74 RID: 11892
		public CustomSelfDrawPanel.CSDImage GreyoutTabs;

		// Token: 0x04002E75 RID: 11893
		public CustomSelfDrawPanel.CSDButton imgFacebook = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002E76 RID: 11894
		public CustomSelfDrawPanel.CSDButton imgTwitter = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002E77 RID: 11895
		public CustomSelfDrawPanel.CSDButton imgYoutube = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002E78 RID: 11896
		public CustomSelfDrawPanel.CSDButton imgSHKRu = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002E79 RID: 11897
		private static bool successfulAutoLogin = false;

		// Token: 0x04002E7A RID: 11898
		public static string AeriaToken = string.Empty;

		// Token: 0x04002E7B RID: 11899
		private string FacebookToken = "";

		// Token: 0x04002E7C RID: 11900
		private bool delayedCreateUserOpen;

		// Token: 0x04002E7D RID: 11901
		private bool emailOptInPopup;

		// Token: 0x04002E7E RID: 11902
		private int lastWorldLoggedIn = -1;

		// Token: 0x04002E7F RID: 11903
		public static int LastNumberOfWorldsPlaying = 0;

		// Token: 0x04002E80 RID: 11904
		public static bool inSpecialWorld = false;

		// Token: 0x04002E81 RID: 11905
		public static string specialWorldName = "";

		// Token: 0x04002E82 RID: 11906
		private static WebBrowser tempBrowser = null;

		// Token: 0x04002E83 RID: 11907
		private static string bp2_currentGuid = "";

		// Token: 0x04002E84 RID: 11908
		private int bp2_loginMode;

		// Token: 0x04002E85 RID: 11909
		private bool tempFacebookLogin;

		// Token: 0x04002E86 RID: 11910
		private bool specialFacebookLogin;

		// Token: 0x04002E87 RID: 11911
		private static bool certPolicyCreated = false;

		// Token: 0x04002E88 RID: 11912
		public static bool LoggedInViaFacebook = false;

		// Token: 0x04002E89 RID: 11913
		public static bool httpLogin = false;

		// Token: 0x04002E8A RID: 11914
		public static string gfEmail = "";

		// Token: 0x04002E8B RID: 11915
		public static string gfPW = "";

		// Token: 0x04002E8C RID: 11916
		private static string bp2_logoutURL = "";

		// Token: 0x04002E8D RID: 11917
		private string defaultWindowTitle = "";

		// Token: 0x04002E8E RID: 11918
		public string initialisedLanguage = "";

		// Token: 0x04002E8F RID: 11919
		public bool UserEntryMode = true;

		// Token: 0x04002E90 RID: 11920
		public bool connectingCancelled;

		// Token: 0x04002E91 RID: 11921
		public static string storedUserLoginEmail = "";

		// Token: 0x04002E92 RID: 11922
		private bool loginButtonActive = true;

		// Token: 0x04002E93 RID: 11923
		private bool selfClosing;

		// Token: 0x04002E94 RID: 11924
		public static string LastSelectedSupportCulture = Program.mySettings.LanguageIdent.ToLower();

		// Token: 0x04002E95 RID: 11925
		private static string lastLoadedEmail = "";

		// Token: 0x04002E96 RID: 11926
		private static string lastLoadedEmail2 = "";

		// Token: 0x04002E97 RID: 11927
		private bool emailOptInState;

		// Token: 0x04002E98 RID: 11928
		private DateTime lastLogoutClicked = DateTime.MinValue;

		// Token: 0x04002E99 RID: 11929
		private int lastCount = -1;

		// Token: 0x04002E9A RID: 11930
		private int PlayerGameworldCount;

		// Token: 0x04002E9B RID: 11931
		public static List<WorldInfo> WorldList;

		// Token: 0x04002EA7 RID: 11943
		[CompilerGenerated]
		private static AeriaEventHandler _003C_003E9__CachedAnonymousMethodDelegate9;

		// Token: 0x04002EA8 RID: 11944
		[CompilerGenerated]
		private static BigPointEventHandler _003C_003E9__CachedAnonymousMethodDelegateb;

		// Token: 0x04002EA9 RID: 11945
		[CompilerGenerated]
		private static FacebookEventHandler _003C_003E9__CachedAnonymousMethodDelegated;

		// Token: 0x04002EAA RID: 11946
		[CompilerGenerated]
		private static RemoteCertificateValidationCallback _003C_003E9__CachedAnonymousMethodDelegate29;

		// Token: 0x02000293 RID: 659
		private class RequestState
		{
			// Token: 0x04002EAB RID: 11947
			public WebRequest req;
		}
	}
}
