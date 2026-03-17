using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CommonTypes;
using Stronghold.AuthClient;

namespace Kingdoms
{
	// Token: 0x02000156 RID: 342
	public class CreatePopupPanel : CustomSelfDrawPanel
	{
		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000CA9 RID: 3241 RVA: 0x0000F631 File Offset: 0x0000D831
		public Image HeaderImage
		{
			get
			{
				if (CreatePopupPanel.headerImage == null)
				{
					CreatePopupPanel.headerImage = WebStyleButtonImage.Generate(500, 30, this.TextCreateHeader, this.WebTextFontBoldCond, global::ARGBColors.White, this.WebButtonblue, this.WebButtonRadius);
				}
				return CreatePopupPanel.headerImage;
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000CAA RID: 3242 RVA: 0x0000F66D File Offset: 0x0000D86D
		public Image HeaderTranferImage
		{
			get
			{
				if (CreatePopupPanel.headerTransferImage == null)
				{
					CreatePopupPanel.headerTransferImage = WebStyleButtonImage.Generate(600, 30, this.TextCreateHeaderMerge, this.WebTextFontBoldCond, global::ARGBColors.White, this.WebButtonblue, this.WebButtonRadius);
				}
				return CreatePopupPanel.headerTransferImage;
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x06000CAB RID: 3243 RVA: 0x000F2890 File Offset: 0x000F0A90
		public Image NextImage
		{
			get
			{
				if (CreatePopupPanel.nextImage == null)
				{
					CreatePopupPanel.nextImage = WebStyleButtonImage.Generate(300, this.WebButtonheight, this.strNext, this.WebTextFontBoldCond, this.WebButtonYellow, this.WebButtonRed, this.WebButtonRadius);
				}
				return CreatePopupPanel.nextImage;
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000CAC RID: 3244 RVA: 0x000F28DC File Offset: 0x000F0ADC
		public Image NextImageOver
		{
			get
			{
				if (CreatePopupPanel.nextImageOver == null)
				{
					CreatePopupPanel.nextImageOver = WebStyleButtonImage.Generate(300, this.WebButtonheight, this.strNext, this.WebTextFontBoldCond, this.WebButtonblue, this.WebButtonGrey, this.WebButtonRadius);
				}
				return CreatePopupPanel.nextImageOver;
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000CAD RID: 3245 RVA: 0x000F2928 File Offset: 0x000F0B28
		public Image TransferImage
		{
			get
			{
				if (CreatePopupPanel.transferImage == null)
				{
					CreatePopupPanel.transferImage = WebStyleButtonImage.Generate(300, this.WebButtonheight, this.strMerge, this.WebTextFontBoldCond, this.WebButtonYellow, this.WebButtonRed, this.WebButtonRadius);
				}
				return CreatePopupPanel.transferImage;
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000CAE RID: 3246 RVA: 0x000F2974 File Offset: 0x000F0B74
		public Image TransferImageOver
		{
			get
			{
				if (CreatePopupPanel.transferImageOver == null)
				{
					CreatePopupPanel.transferImageOver = WebStyleButtonImage.Generate(300, this.WebButtonheight, this.strMerge, this.WebTextFontBoldCond, this.WebButtonblue, this.WebButtonGrey, this.WebButtonRadius);
				}
				return CreatePopupPanel.transferImageOver;
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000CAF RID: 3247 RVA: 0x000F29C0 File Offset: 0x000F0BC0
		public Image CloseImage
		{
			get
			{
				if (CreatePopupPanel.closeImage == null)
				{
					CreatePopupPanel.closeImage = WebStyleButtonImage.Generate(200, this.WebButtonheight, Program.steamActive ? this.strBack : this.strClose, this.WebTextFontBoldCond, this.WebButtonYellow, this.WebButtonRed, this.WebButtonRadius);
				}
				return CreatePopupPanel.closeImage;
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x06000CB0 RID: 3248 RVA: 0x000F2A1C File Offset: 0x000F0C1C
		public Image CloseImageOver
		{
			get
			{
				if (CreatePopupPanel.closeImageOver == null)
				{
					CreatePopupPanel.closeImageOver = WebStyleButtonImage.Generate(200, this.WebButtonheight, Program.steamActive ? this.strBack : this.strClose, this.WebTextFontBoldCond, this.WebButtonblue, this.WebButtonGrey, this.WebButtonRadius);
				}
				return CreatePopupPanel.closeImageOver;
			}
		}

		// Token: 0x06000CB1 RID: 3249 RVA: 0x0000F6A9 File Offset: 0x0000D8A9
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000CB2 RID: 3250 RVA: 0x0000F6C8 File Offset: 0x0000D8C8
		private void InitializeComponent()
		{
			this.components = new Container();
			base.AutoScaleMode = AutoScaleMode.None;
		}

		// Token: 0x06000CB3 RID: 3251 RVA: 0x000F2A78 File Offset: 0x000F0C78
		public CreatePopupPanel()
		{
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06000CB4 RID: 3252 RVA: 0x0000F6DC File Offset: 0x0000D8DC
		private void AddControlToPanel(CustomSelfDrawPanel.CSDControl c)
		{
			base.addControl(c);
		}

		// Token: 0x06000CB5 RID: 3253 RVA: 0x000F2D00 File Offset: 0x000F0F00
		public void init(bool createMode)
		{
			this.m_createMode = createMode;
			base.clearControls();
			base.Controls.Clear();
			this.BackColor = global::ARGBColors.White;
			int num = 0;
			int num2 = 0;
			if (!Program.steamActive)
			{
				num2 = -15;
			}
			else if (!this.m_createMode)
			{
				num2 = 30;
			}
			if (Program.gamersFirstInstall)
			{
				this.TextEmail = SK.Text("SIGNUP_GF_Email", "GamersFirst Gamer ID / Email");
				this.TextUsername = SK.Text("SIGNUP_GF_Username", "Choose a Stronghold Kingdoms Username");
			}
			else if (Program.arcInstall)
			{
				this.TextEmail = SK.Text("SIGNUP_Arc_Email", "Arc ID");
				this.TextUsername = SK.Text("SIGNUP_GF_Username", "Choose a Stronghold Kingdoms Username");
			}
			else if (this.m_createMode)
			{
				num = -20;
			}
			int num3 = 200;
			int num4 = 100 + num2 + num;
			int num5 = 23;
			int num6 = 14;
			int height = 12;
			this.HeaderTitle = new CustomSelfDrawPanel.CSDImage();
			if (this.m_createMode)
			{
				this.HeaderTitle.Image = this.HeaderImage;
			}
			else
			{
				this.HeaderTitle.Image = this.HeaderTranferImage;
			}
			this.HeaderTitle.Position = new Point((base.Width - this.HeaderTitle.Width) / 2, 32 + num2);
			this.lblEmail = new CustomSelfDrawPanel.CSDLabel();
			this.lblEmail.Position = new Point(num3, num4 - 10);
			this.lblEmail.Text = this.TextEmail;
			this.lblEmail.Size = new Size(300, height);
			this.lblEmail.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.txtEmail = new TextBox();
			this.txtEmail.ForeColor = global::ARGBColors.Black;
			this.txtEmail.BackColor = global::ARGBColors.White;
			this.txtEmail.Location = new Point(num3, num4 + num6 - 10);
			this.txtEmail.Size = new Size(300, this.txtEmail.Height);
			this.fillEmailValid = new CustomSelfDrawPanel.CSDFill();
			this.fillEmailValid.Position = new Point(num3 + 300 + 5, this.txtEmail.Location.Y);
			this.fillEmailValid.Size = new Size(this.txtEmail.Height, this.txtEmail.Height);
			this.fillEmailValid.FillColor = global::ARGBColors.Red;
			if (this.m_createMode)
			{
				this.lblEmailconfirm = new CustomSelfDrawPanel.CSDLabel();
				this.lblEmailconfirm.Position = new Point(this.txtEmail.Location.X, this.txtEmail.Location.Y + num5);
				this.lblEmailconfirm.Text = this.TextEmailConfirm;
				this.lblEmailconfirm.Size = new Size(300, height);
				this.lblEmailconfirm.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
				this.txtEmailconfirm = new TextBox();
				this.txtEmailconfirm.ForeColor = global::ARGBColors.Black;
				this.txtEmailconfirm.BackColor = global::ARGBColors.White;
				this.txtEmailconfirm.Location = new Point(this.lblEmailconfirm.Position.X, this.lblEmailconfirm.Position.Y + num6);
				this.txtEmailconfirm.Size = new Size(300, this.txtEmailconfirm.Height);
				this.fillEmailConfirmValid = new CustomSelfDrawPanel.CSDFill();
				this.fillEmailConfirmValid.Position = new Point(num3 + 300 + 5, this.txtEmailconfirm.Location.Y);
				this.fillEmailConfirmValid.Size = new Size(this.txtEmailconfirm.Height, this.txtEmailconfirm.Height);
				this.fillEmailConfirmValid.FillColor = global::ARGBColors.Red;
				if (Program.gamersFirstInstall || Program.arcInstall)
				{
					this.lblEmailconfirm.Visible = false;
					this.txtEmailconfirm.Visible = false;
					this.fillEmailConfirmValid.Visible = false;
					this.txtEmail.Visible = false;
					this.lblEmail.Visible = false;
				}
				this.lblUsername = new CustomSelfDrawPanel.CSDLabel();
				this.lblUsername.Position = new Point(this.txtEmailconfirm.Location.X, this.txtEmailconfirm.Location.Y + num5);
				this.lblUsername.Text = this.TextUsername;
				this.lblUsername.Size = new Size(300, height);
				this.lblUsername.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
				this.txtUsername = new TextBox();
				this.txtUsername.ForeColor = global::ARGBColors.Black;
				this.txtUsername.BackColor = global::ARGBColors.White;
				this.txtUsername.Location = new Point(this.lblUsername.Position.X, this.lblUsername.Position.Y + num6);
				this.txtUsername.Size = new Size(300, this.txtUsername.Height);
				this.fillUsernameValid = new CustomSelfDrawPanel.CSDFill();
				this.fillUsernameValid.Position = new Point(num3 + 300 + 5, this.txtUsername.Location.Y);
				this.fillUsernameValid.Size = new Size(this.txtUsername.Height, this.txtUsername.Height);
				this.fillUsernameValid.FillColor = global::ARGBColors.Red;
			}
			this.lblPassword = new CustomSelfDrawPanel.CSDLabel();
			if (this.m_createMode)
			{
				this.lblPassword.Position = new Point(this.txtUsername.Location.X, this.txtUsername.Location.Y + num5);
				this.lblPassword.Text = this.TextPassword;
			}
			else
			{
				this.lblPassword.Position = new Point(this.txtEmail.Location.X, this.txtEmail.Location.Y + num5);
				this.lblPassword.Text = this.TextPasswordMerge;
			}
			this.lblPassword.Size = new Size(300, height);
			this.lblPassword.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.txtPassword = new TextBox();
			this.txtPassword.ForeColor = global::ARGBColors.Black;
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.BackColor = global::ARGBColors.White;
			this.txtPassword.Location = new Point(this.lblPassword.Position.X, this.lblPassword.Position.Y + num6);
			this.txtPassword.Size = new Size(300, this.txtPassword.Height);
			this.fillPasswordValid = new CustomSelfDrawPanel.CSDFill();
			this.fillPasswordValid.Position = new Point(num3 + 300 + 5, this.txtPassword.Location.Y);
			this.fillPasswordValid.Size = new Size(this.txtPassword.Height, this.txtPassword.Height);
			this.fillPasswordValid.FillColor = global::ARGBColors.Red;
			if (this.m_createMode)
			{
				this.lblPasswordconfirm = new CustomSelfDrawPanel.CSDLabel();
				this.lblPasswordconfirm.Position = new Point(this.txtPassword.Location.X, this.txtPassword.Location.Y + num5);
				this.lblPasswordconfirm.Text = this.TextPasswordConfirm;
				this.lblPasswordconfirm.Size = new Size(300, height);
				this.lblPasswordconfirm.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
				this.txtPasswordconfirm = new TextBox();
				this.txtPasswordconfirm.ForeColor = global::ARGBColors.Black;
				this.txtPasswordconfirm.PasswordChar = '*';
				this.txtPasswordconfirm.BackColor = global::ARGBColors.White;
				this.txtPasswordconfirm.Location = new Point(this.lblPasswordconfirm.Position.X, this.lblPasswordconfirm.Position.Y + num6);
				this.txtPasswordconfirm.Size = new Size(300, this.txtPasswordconfirm.Height);
				this.fillPasswordConfirmValid = new CustomSelfDrawPanel.CSDFill();
				this.fillPasswordConfirmValid.Position = new Point(num3 + 300 + 5, this.txtPasswordconfirm.Location.Y);
				this.fillPasswordConfirmValid.Size = new Size(this.txtPasswordconfirm.Height, this.txtPasswordconfirm.Height);
				this.fillPasswordConfirmValid.FillColor = global::ARGBColors.Red;
				if (Program.gamersFirstInstall || Program.arcInstall)
				{
					this.lblPasswordconfirm.Visible = false;
					this.txtPasswordconfirm.Visible = false;
					this.fillPasswordConfirmValid.Visible = false;
				}
			}
			if (Program.gamersFirstInstall || Program.arcInstall)
			{
				this.lblPassword.Visible = false;
				this.txtPassword.Visible = false;
				this.fillPasswordValid.Visible = false;
				this.txtEmail.ReadOnly = true;
				this.fillEmailValid.Visible = false;
			}
			else
			{
				this.newsletterCheck = new CustomSelfDrawPanel.CSDCheckBox();
				this.newsletterCheck.CheckedImage = GFXLibrary.reports_checkbox_checked;
				this.newsletterCheck.UncheckedImage = GFXLibrary.reports_checkbox_empty;
				this.newsletterCheck.Position = new Point(num3 + 5, this.txtPasswordconfirm.Location.Y + 25 + 4);
				this.newsletterCheck.Checked = false;
				this.newsletterCheck.CBLabel.Text = SK.Text("Create_Subscribe Newsletter", "Subscribe to Newsletter");
				this.newsletterCheck.CBLabel.Color = global::ARGBColors.Black;
				this.newsletterCheck.CBLabel.Position = new Point(20, -1);
				this.newsletterCheck.CBLabel.Size = new Size(360, 35);
				this.newsletterCheck.CBLabel.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.AddControlToPanel(this.newsletterCheck);
				if (!Program.steamActive)
				{
					this.tandcCheck = new CustomSelfDrawPanel.CSDCheckBox();
					this.tandcCheck.CheckedImage = GFXLibrary.reports_checkbox_checked;
					this.tandcCheck.UncheckedImage = GFXLibrary.reports_checkbox_empty;
					this.tandcCheck.Position = new Point(num3 + 5, this.txtPasswordconfirm.Location.Y + 25 + 4 + 20);
					this.tandcCheck.Checked = false;
					this.tandcCheck.CBLabel.Text = SK.Text("Create_termsandcondCheck", "I accept the Stronghold Kingdoms Terms & Conditions").Replace("&amp;", "&");
					this.tandcCheck.CBLabel.Color = global::ARGBColors.Black;
					this.tandcCheck.CBLabel.Position = new Point(20, -1);
					this.tandcCheck.CBLabel.Size = new Size(360, 35);
					this.tandcCheck.CBLabel.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
					this.tandcCheck.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.tandcToggled));
					this.AddControlToPanel(this.tandcCheck);
				}
				else
				{
					this.newsletterCheck.Position = new Point(num3 + 5 + 60, this.txtPasswordconfirm.Location.Y + 25 + 4);
				}
			}
			this.NextButton = new CustomSelfDrawPanel.CSDImage();
			if (this.m_createMode)
			{
				this.NextButton.Image = this.NextImage;
				this.NextButton.setMouseOverDelegate(delegate
				{
					this.NextButton.Image = this.NextImageOver;
					this.Cursor = Cursors.Hand;
				}, delegate
				{
					this.NextButton.Image = this.NextImage;
					this.Cursor = Cursors.Default;
				});
				this.NextButton.Position = new Point(this.txtPasswordconfirm.Location.X, this.txtPasswordconfirm.Location.Y + num5 + 10 - num + 20);
			}
			else
			{
				this.NextButton.Image = this.TransferImage;
				this.NextButton.setMouseOverDelegate(delegate
				{
					this.NextButton.Image = this.TransferImageOver;
					this.Cursor = Cursors.Hand;
				}, delegate
				{
					this.NextButton.Image = this.TransferImage;
					this.Cursor = Cursors.Default;
				});
				this.NextButton.Position = new Point(this.txtPasswordconfirm.Location.X, this.txtPasswordconfirm.Location.Y + num5 + 10 - 60 + 20);
			}
			this.NextButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.NextClicked), "CreatePopupPanel_next");
			if ((!Program.steamActive || !this.m_createMode) && !Program.gamersFirstInstall && !Program.arcInstall)
			{
				CustomSelfDrawPanel.CSDButton csdbutton = new CustomSelfDrawPanel.CSDButton();
				csdbutton.ImageNorm = this.CloseImage;
				csdbutton.ImageOver = this.CloseImageOver;
				csdbutton.Position = new Point(480, 430);
				csdbutton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "CreatePopupPanel_close");
				this.AddControlToPanel(csdbutton);
			}
			if (CreatePopupPanel.HintBoxImage == null)
			{
				CreatePopupPanel.HintBoxImage = new Bitmap(500, 100);
				Graphics graphics = Graphics.FromImage(CreatePopupPanel.HintBoxImage);
				graphics.Clear(global::ARGBColors.White);
				graphics.DrawRectangle(Pens.LightGray, new Rectangle(0, 0, 500, 100));
				graphics.FillRectangle(Brushes.LightGray, new Rectangle(0, 96, 500, 4));
				graphics.FillRectangle(Brushes.LightGray, new Rectangle(496, 0, 4, 100));
				graphics.Dispose();
			}
			this.HintBox = new CustomSelfDrawPanel.CSDImage();
			this.HintBox.Image = CreatePopupPanel.HintBoxImage;
			this.HintBox.Width = CreatePopupPanel.HintBoxImage.Width;
			this.HintBox.Height = CreatePopupPanel.HintBoxImage.Height;
			if (this.m_createMode)
			{
				this.HintBox.Position = new Point(this.HeaderTitle.Position.X, this.NextButton.Position.Y + num5 + 8);
			}
			else
			{
				this.HintBox.Position = new Point(this.HeaderTitle.Position.X + 50, this.NextButton.Position.Y + num5 + 8);
			}
			this.HintBoxLabel = new CustomSelfDrawPanel.CSDLabel();
			this.HintBoxLabel.Width = CreatePopupPanel.HintBoxImage.Width - 32;
			this.HintBoxLabel.Height = (CreatePopupPanel.HintBoxImage.Height - 32) / 2 + 8;
			this.HintBoxLabel.Position = new Point(this.HintBox.Position.X + 16, this.HintBox.Position.Y + 16);
			this.FeedbackLabel = new CustomSelfDrawPanel.CSDLabel();
			this.FeedbackLabel.Width = this.HintBoxLabel.Width;
			this.FeedbackLabel.Height = this.HintBoxLabel.Height;
			this.FeedbackLabel.Position = new Point(this.HintBoxLabel.Position.X, this.HintBoxLabel.Position.Y + this.HintBoxLabel.Height);
			this.FeedbackLabel.Color = global::ARGBColors.Red;
			int y = 423;
			if (Program.steamActive)
			{
				y = base.Height - 20;
			}
			this.tandcLabel = new CustomSelfDrawPanel.CSDLabel();
			this.tandcLabel.Text = SK.Text("MENU_TandC", "Terms & Conditions").Replace("&amp;", "&");
			if (Program.mySettings.LanguageIdent == "de")
			{
				this.tandcLabel.Size = new Size(270, 20);
				this.tandcLabel.Position = new Point(30, y);
			}
			else
			{
				this.tandcLabel.Size = new Size(170, 20);
				this.tandcLabel.Position = new Point(100, y);
			}
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
			this.AddControlToPanel(this.tandcLabel);
			this.privacyLabel = new CustomSelfDrawPanel.CSDLabel();
			this.privacyLabel.Text = SK.Text("MENU_Privacy", "Privacy Policy");
			this.privacyLabel.Size = new Size(base.Width - 414, 20);
			this.privacyLabel.Position = new Point(207, y);
			this.privacyLabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
			this.privacyLabel.Color = global::ARGBColors.Black;
			this.privacyLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.privacyClicked));
			this.privacyLabel.setMouseOverDelegate(delegate
			{
				this.privacyLabel.Color = global::ARGBColors.Red;
			}, delegate
			{
				this.privacyLabel.Color = global::ARGBColors.Black;
			});
			this.privacyLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.AddControlToPanel(this.privacyLabel);
			if (Program.steamActive && this.m_createMode)
			{
				this.alreadyLabel = new CustomSelfDrawPanel.CSDLabel();
				this.alreadyLabel.Text = SK.Text("Steam_already", "Already have a Stronghold Kingdoms account? Click Here.");
				this.alreadyLabel.Size = new Size(base.Width - 20, 20);
				this.alreadyLabel.Position = new Point(10, this.txtPasswordconfirm.Location.Y + 25 + 4 + 20);
				this.alreadyLabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
				this.alreadyLabel.Color = global::ARGBColors.Black;
				this.alreadyLabel.setClickDelegate(delegate()
				{
					this.init(false);
				});
				this.alreadyLabel.setMouseOverDelegate(delegate
				{
					this.alreadyLabel.Color = global::ARGBColors.Red;
				}, delegate
				{
					this.alreadyLabel.Color = global::ARGBColors.Black;
				});
				this.alreadyLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
				this.AddControlToPanel(this.alreadyLabel);
				this.privacyLabel.Size = new Size(base.Width - 414, 20);
				this.privacyLabel.Position = new Point(314, y);
				this.privacyLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			}
			this.AddControlToPanel(this.HeaderTitle);
			this.AddControlToPanel(this.lblEmail);
			if (!Program.gamersFirstInstall && !Program.arcInstall)
			{
				base.Controls.Add(this.txtEmail);
			}
			if (this.m_createMode)
			{
				this.AddControlToPanel(this.fillEmailValid);
			}
			if (this.m_createMode)
			{
				if (!Program.gamersFirstInstall && !Program.arcInstall)
				{
					this.AddControlToPanel(this.lblEmailconfirm);
					base.Controls.Add(this.txtEmailconfirm);
					this.AddControlToPanel(this.fillEmailConfirmValid);
				}
				this.AddControlToPanel(this.lblUsername);
				base.Controls.Add(this.txtUsername);
				this.txtUsername.MaxLength = 18;
				this.AddControlToPanel(this.fillUsernameValid);
			}
			this.AddControlToPanel(this.lblPassword);
			base.Controls.Add(this.txtPassword);
			if (this.m_createMode)
			{
				this.AddControlToPanel(this.fillPasswordValid);
			}
			if (this.m_createMode && !Program.gamersFirstInstall && !Program.arcInstall)
			{
				this.AddControlToPanel(this.lblPasswordconfirm);
				base.Controls.Add(this.txtPasswordconfirm);
				this.AddControlToPanel(this.fillPasswordConfirmValid);
			}
			if (Program.gamersFirstInstall || Program.arcInstall)
			{
				base.Controls.Add(this.txtEmail);
			}
			this.AddControlToPanel(this.NextButton);
			this.AddControlToPanel(this.HintBox);
			this.AddControlToPanel(this.HintBoxLabel);
			this.AddControlToPanel(this.FeedbackLabel);
			this.txtEmail.Name = "txtEmail";
			if (!Program.gamersFirstInstall && !Program.arcInstall)
			{
				this.txtEmail.GotFocus += this.txtEmail_GotFocus;
			}
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.GotFocus += this.txtPassword_GotFocus;
			this.txtEmail.TextChanged += this.txtEmail_TextChanged;
			this.txtPassword.TextChanged += this.txtPassword_TextChanged;
			if (this.m_createMode)
			{
				this.txtEmailconfirm.Name = "txtEmailConfirm";
				this.txtEmailconfirm.GotFocus += this.txtEmailconfirm_GotFocus;
				this.txtUsername.Name = "txtUsername";
				this.txtUsername.GotFocus += this.txtUsername_GotFocus;
				this.txtPasswordconfirm.Name = "txtPasswordConfirm";
				this.txtPasswordconfirm.GotFocus += this.txtPasswordconfirm_GotFocus;
				this.txtEmailconfirm.TextChanged += this.txtEmailconfirm_TextChanged;
				this.txtUsername.TextChanged += this.txtUsername_TextChanged;
				this.txtPasswordconfirm.TextChanged += this.txtPasswordconfirm_TextChanged;
			}
			base.BringToFront();
			base.Focus();
			if (Program.gamersFirstInstall || Program.arcInstall)
			{
				this.txtUsername.Focus();
			}
			else
			{
				this.txtEmail.Focus();
			}
			this.emailValid = false;
			this.emailconfirmvalid = false;
			this.passwordvalid = false;
			this.passwordconfirmvalid = false;
			this.lastUsernameValid = false;
			this.usernameValidationInProgress = false;
			this.lastUsernameChecked = string.Empty;
			this.usernameNotChecked = false;
			if (Program.gamersFirstInstall || Program.arcInstall)
			{
				this.passwordconfirmvalid = (this.passwordvalid = true);
				this.emailValid = (this.emailconfirmvalid = true);
				this.txtEmail.Text = ProfileLoginWindow.gfEmail;
				this.txtPassword.Text = ProfileLoginWindow.gfPW;
				this.txtUsername.Focus();
			}
			this.ValidateNextButton();
			this.txtEmail.KeyUp += this.Tabfix;
			base.Invalidate();
		}

		// Token: 0x06000CB6 RID: 3254 RVA: 0x000F43C8 File Offset: 0x000F25C8
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

		// Token: 0x06000CB7 RID: 3255 RVA: 0x000F4408 File Offset: 0x000F2608
		private void privacyClicked()
		{
			try
			{
				new Process
				{
					StartInfo = 
					{
						FileName = URLs.PrivacyPolicy
					}
				}.Start();
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000CB8 RID: 3256 RVA: 0x000F4448 File Offset: 0x000F2648
		private void Tabfix(object sender, KeyEventArgs e)
		{
			bool isTab = (e.KeyData & Keys.KeyCode).ToString().ToUpper() == "TAB";
		}

		// Token: 0x06000CB9 RID: 3257 RVA: 0x0000F6E5 File Offset: 0x0000D8E5
		public void update()
		{
			if (this.usernameNotChecked)
			{
				this.ValidateUsername(false);
			}
		}

		// Token: 0x06000CBA RID: 3258 RVA: 0x0000F6F6 File Offset: 0x0000D8F6
		private void txtPasswordconfirm_TextChanged(object sender, EventArgs e)
		{
			if (this.m_createMode)
			{
				this.SwitchHint(this.TextHint_PasswordConfirm, this.txtPasswordconfirm);
				this.ValidatePasswordConfirm();
				this.ValidateNextButton();
			}
		}

		// Token: 0x06000CBB RID: 3259 RVA: 0x0000F71E File Offset: 0x0000D91E
		private void txtPassword_TextChanged(object sender, EventArgs e)
		{
			if (this.m_createMode)
			{
				this.SwitchHint(this.TextHint_Password, this.txtPassword);
				this.ValidatePassword();
			}
			else
			{
				this.SwitchHint(this.TextHint_Password_Merge, this.txtPassword);
			}
			this.ValidateNextButton();
		}

		// Token: 0x06000CBC RID: 3260 RVA: 0x0000F75A File Offset: 0x0000D95A
		private void txtEmailconfirm_TextChanged(object sender, EventArgs e)
		{
			if (this.m_createMode)
			{
				this.SwitchHint(this.TextHint_EmailConfirm, this.txtEmailconfirm);
				this.ValidateEmailconfirm();
				this.ValidateNextButton();
			}
		}

		// Token: 0x06000CBD RID: 3261 RVA: 0x0000F782 File Offset: 0x0000D982
		private void txtEmail_TextChanged(object sender, EventArgs e)
		{
			if (this.m_createMode)
			{
				this.SwitchHint(this.TextHint_Email, this.txtEmail);
				this.ValidateEmail();
			}
			else
			{
				this.SwitchHint(this.TextHint_Email_Merge, this.txtEmail);
			}
			this.ValidateNextButton();
		}

		// Token: 0x06000CBE RID: 3262 RVA: 0x0000F6F6 File Offset: 0x0000D8F6
		private void txtPasswordconfirm_GotFocus(object sender, EventArgs e)
		{
			if (this.m_createMode)
			{
				this.SwitchHint(this.TextHint_PasswordConfirm, this.txtPasswordconfirm);
				this.ValidatePasswordConfirm();
				this.ValidateNextButton();
			}
		}

		// Token: 0x06000CBF RID: 3263 RVA: 0x0000F71E File Offset: 0x0000D91E
		private void txtPassword_GotFocus(object sender, EventArgs e)
		{
			if (this.m_createMode)
			{
				this.SwitchHint(this.TextHint_Password, this.txtPassword);
				this.ValidatePassword();
			}
			else
			{
				this.SwitchHint(this.TextHint_Password_Merge, this.txtPassword);
			}
			this.ValidateNextButton();
		}

		// Token: 0x06000CC0 RID: 3264 RVA: 0x0000F7BE File Offset: 0x0000D9BE
		private void txtUsername_GotFocus(object sender, EventArgs e)
		{
			if (this.m_createMode)
			{
				this.SwitchHint(this.TextHint_Username, this.txtUsername);
				this.ValidateNextButton();
			}
		}

		// Token: 0x06000CC1 RID: 3265 RVA: 0x0000F75A File Offset: 0x0000D95A
		private void txtEmailconfirm_GotFocus(object sender, EventArgs e)
		{
			if (this.m_createMode)
			{
				this.SwitchHint(this.TextHint_EmailConfirm, this.txtEmailconfirm);
				this.ValidateEmailconfirm();
				this.ValidateNextButton();
			}
		}

		// Token: 0x06000CC2 RID: 3266 RVA: 0x0000F782 File Offset: 0x0000D982
		private void txtEmail_GotFocus(object sender, EventArgs e)
		{
			if (this.m_createMode)
			{
				this.SwitchHint(this.TextHint_Email, this.txtEmail);
				this.ValidateEmail();
			}
			else
			{
				this.SwitchHint(this.TextHint_Email_Merge, this.txtEmail);
			}
			this.ValidateNextButton();
		}

		// Token: 0x06000CC3 RID: 3267 RVA: 0x0000F7E0 File Offset: 0x0000D9E0
		private void SwitchHint(string text, TextBox field)
		{
			this.HintBoxLabel.TextDiffOnly = text;
		}

		// Token: 0x06000CC4 RID: 3268 RVA: 0x0000F7EE File Offset: 0x0000D9EE
		private void txtUsername_TextChanged(object sender, EventArgs e)
		{
			if (this.m_createMode)
			{
				this.SwitchHint(this.TextHint_Username, this.txtUsername);
				this.ValidateUsername(false);
				this.ValidateNextButton();
			}
		}

		// Token: 0x06000CC5 RID: 3269 RVA: 0x000F4480 File Offset: 0x000F2680
		private void NextClicked()
		{
			if (this.m_createMode)
			{
				if (this.lastUsernameValid && !this.usernameValidationInProgress && this.txtUsername.Text == this.lastUsernameChecked && this.everythingValid())
				{
					this.CreateUser();
					return;
				}
				if (this.txtUsername.Text != this.lastUsernameChecked && this.lastUsernameValid && !this.usernameValidationInProgress)
				{
					this.ValidateUsername(true);
					return;
				}
			}
			else if (this.txtEmail.Text.Length > 0 && this.txtPassword.Text.Length > 0)
			{
				this.TransferUser();
			}
		}

		// Token: 0x06000CC6 RID: 3270 RVA: 0x0000F817 File Offset: 0x0000DA17
		private void closeClick()
		{
			if (!Program.steamActive && !Program.gamersFirstInstall && !Program.arcInstall)
			{
				InterfaceMgr.Instance.closeCreatePopupWindow();
				return;
			}
			this.init(true);
		}

		// Token: 0x06000CC7 RID: 3271 RVA: 0x000F4528 File Offset: 0x000F2728
		private void CreateUser()
		{
			XmlRpcAuthProvider xmlRpcAuthProvider = XmlRpcAuthProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressLogin, URLs.ProfileServerPort, URLs.ProfilePath);
			XmlRpcAuthRequest xmlRpcAuthRequest = new XmlRpcAuthRequest();
			if (Program.gamersFirstInstall)
			{
				xmlRpcAuthRequest.SteamID = "gamersfirst";
				xmlRpcAuthRequest.EmailAddress = "";
				xmlRpcAuthRequest.Password = Program.gamersFirstTokenMD5;
			}
			else if (Program.arcInstall)
			{
				xmlRpcAuthRequest.SteamID = "arc";
				xmlRpcAuthRequest.EmailAddress = Program.arcUsername;
				xmlRpcAuthRequest.Password = Program.getNewArcToken();
				Program.arcToken = "";
			}
			else if (Program.winStore)
			{
				xmlRpcAuthRequest.SteamID = "winstore";
				xmlRpcAuthRequest.EmailAddress = this.txtEmail.Text;
				xmlRpcAuthRequest.Password = this.txtPassword.Text;
				if (this.newsletterCheck.Checked)
				{
					xmlRpcAuthRequest.ParishID = new int?(100);
				}
				else
				{
					xmlRpcAuthRequest.ParishID = new int?(50);
				}
			}
			else
			{
				xmlRpcAuthRequest.SteamID = Program.steamID;
				xmlRpcAuthRequest.EmailAddress = this.txtEmail.Text;
				xmlRpcAuthRequest.Password = this.txtPassword.Text;
				if (this.newsletterCheck.Checked)
				{
					xmlRpcAuthRequest.ParishID = new int?(100);
				}
				else
				{
					xmlRpcAuthRequest.ParishID = new int?(50);
				}
			}
			xmlRpcAuthRequest.Culture = Program.mySettings.LanguageIdent.ToLower();
			xmlRpcAuthRequest.Username = this.lastUsernameChecked;
			this.NextButton.Image = this.NextImageOver;
			this.NextButton.Enabled = false;
			this.txtEmail.Enabled = false;
			this.txtEmailconfirm.Enabled = false;
			this.txtUsername.Enabled = false;
			this.txtPassword.Enabled = false;
			this.txtPasswordconfirm.Enabled = false;
			xmlRpcAuthProvider.CreateUserSteam(xmlRpcAuthRequest, new AuthEndResponseDelegate(this.createUserCallback), this);
		}

		// Token: 0x06000CC8 RID: 3272 RVA: 0x000F46FC File Offset: 0x000F28FC
		private void TransferUser()
		{
			XmlRpcAuthProvider xmlRpcAuthProvider = XmlRpcAuthProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressLogin, URLs.ProfileServerPort, URLs.ProfilePath);
			XmlRpcAuthRequest xmlRpcAuthRequest = new XmlRpcAuthRequest();
			xmlRpcAuthRequest.SteamID = Program.steamID;
			xmlRpcAuthRequest.Culture = Program.mySettings.LanguageIdent.ToLower();
			xmlRpcAuthRequest.Username = "##Transfer##";
			xmlRpcAuthRequest.EmailAddress = this.txtEmail.Text;
			xmlRpcAuthRequest.Password = this.txtPassword.Text;
			this.NextButton.Image = this.NextImageOver;
			this.NextButton.Enabled = false;
			this.txtEmail.Enabled = false;
			this.txtEmailconfirm.Enabled = false;
			this.txtUsername.Enabled = false;
			this.txtPassword.Enabled = false;
			this.txtPasswordconfirm.Enabled = false;
			xmlRpcAuthProvider.CreateUserSteam(xmlRpcAuthRequest, new AuthEndResponseDelegate(this.createUserCallback), this);
		}

		// Token: 0x06000CC9 RID: 3273 RVA: 0x000F47E4 File Offset: 0x000F29E4
		private void createUserCallback(IAuthProvider sender, IAuthResponse response)
		{
			int? successCode = response.SuccessCode;
			int num = 1;
			if (successCode.GetValueOrDefault() == num & successCode != null)
			{
				Program.kingdomsAccountFound = true;
				if (Program.steamActive)
				{
					Program.profileLogin.SetSteamEmail(this.txtEmail.Text);
				}
				else
				{
					Program.profileLogin.SetNonSteamEmail(this.txtEmail.Text, this.txtPassword.Text);
				}
				Program.profileLogin.btnLogin_Click();
				InterfaceMgr.Instance.closeCreatePopupWindow();
				if (!Program.steamActive && !Program.gamersFirstInstall && !Program.arcInstall)
				{
					MyMessageBox.Show(SK.Text("Login_Account_Created_Message", "Your account has been created and you will receive an Authorization Email soon. Follow the instructions in this email and then you will be able to join game worlds in Stronghold Kingdoms."), SK.Text("Login_Account_Created", "Account Created"));
					return;
				}
			}
			else
			{
				this.FeedbackLabel.Color = global::ARGBColors.Red;
				this.FeedbackLabel.TextDiffOnly = response.Message;
				this.NextButton.Enabled = true;
				this.NextButton.Image = this.NextImage;
				this.txtEmail.Enabled = true;
				this.txtEmailconfirm.Enabled = true;
				this.txtUsername.Enabled = true;
				this.txtPassword.Enabled = true;
				this.txtPasswordconfirm.Enabled = true;
			}
		}

		// Token: 0x06000CCA RID: 3274 RVA: 0x000F4928 File Offset: 0x000F2B28
		private void ValidateEmail()
		{
			Regex regex = new Regex(this.emailPattern);
			if (regex.IsMatch(this.txtEmail.Text.Trim()))
			{
				this.FeedbackLabel.Color = global::ARGBColors.Green;
				this.FeedbackLabel.TextDiffOnly = SK.Text("SIGNUP_Email_Valid", "Email Valid");
				this.emailValid = true;
			}
			else
			{
				this.FeedbackLabel.Color = global::ARGBColors.Red;
				this.FeedbackLabel.TextDiffOnly = SK.Text("SIGNUP_Email_Invalid", "Email Invalid");
				this.emailValid = false;
			}
			this.emailconfirmvalid = (this.txtEmail.Text.Trim() == this.txtEmailconfirm.Text.Trim() && this.emailValid);
			if (Program.gamersFirstInstall || Program.arcInstall)
			{
				this.emailconfirmvalid = (this.emailValid = true);
			}
		}

		// Token: 0x06000CCB RID: 3275 RVA: 0x000F4A14 File Offset: 0x000F2C14
		private void ValidateEmailconfirm()
		{
			this.ValidateEmail();
			if (!this.emailconfirmvalid && !this.emailValid)
			{
				this.FeedbackLabel.Color = global::ARGBColors.Red;
				this.FeedbackLabel.TextDiffOnly = SK.Text("SIGNUP_Email_Invalid", "Email Invalid");
				return;
			}
			if (!this.emailconfirmvalid && this.emailValid)
			{
				this.FeedbackLabel.Color = global::ARGBColors.Red;
				this.FeedbackLabel.TextDiffOnly = SK.Text("SIGNUP_Email_Not_Match", "Emails do not match");
				return;
			}
			if (this.emailconfirmvalid && this.emailValid)
			{
				this.FeedbackLabel.Color = global::ARGBColors.Green;
				this.FeedbackLabel.TextDiffOnly = SK.Text("SIGNUP_Email_Match", "Emails match");
			}
		}

		// Token: 0x06000CCC RID: 3276 RVA: 0x000F4AD8 File Offset: 0x000F2CD8
		private void ValidateUsername(bool create)
		{
			Regex regex = new Regex(this.usernamePattern);
			if (this.txtUsername.Text.Length < 4 || this.txtUsername.Text.Length > 18 || !regex.IsMatch(this.txtUsername.Text.Trim()))
			{
				this.FeedbackLabel.Color = global::ARGBColors.Red;
				this.FeedbackLabel.Text = string.Empty;
				this.lastUsernameValid = false;
				this.ValidateNextButton();
				return;
			}
			if (this.usernameValidationInProgress)
			{
				this.usernameNotChecked = true;
				return;
			}
			this.usernameNotChecked = false;
			this.usernameValidationInProgress = true;
			XmlRpcAuthProvider xmlRpcAuthProvider = XmlRpcAuthProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressLogin, URLs.ProfileServerPort, URLs.ProfilePath);
			XmlRpcAuthRequest xmlRpcAuthRequest = new XmlRpcAuthRequest();
			xmlRpcAuthRequest.SteamID = Program.steamID;
			xmlRpcAuthRequest.Culture = Program.mySettings.LanguageIdent.ToLower();
			xmlRpcAuthRequest.Username = this.txtUsername.Text.Trim();
			this.NextButton.Image = this.NextImageOver;
			this.NextButton.Enabled = false;
			if (create)
			{
				xmlRpcAuthProvider.CheckUsernameSteam(xmlRpcAuthRequest, new AuthEndResponseDelegate(this.usernameCheckCallbackThenCreate), this);
				return;
			}
			xmlRpcAuthProvider.CheckUsernameSteam(xmlRpcAuthRequest, new AuthEndResponseDelegate(this.usernameCheckCallback), this);
		}

		// Token: 0x06000CCD RID: 3277 RVA: 0x000F4C28 File Offset: 0x000F2E28
		private void usernameCheckCallback(IAuthProvider sender, IAuthResponse response)
		{
			this.usernameValidationInProgress = false;
			this.lastUsernameChecked = response.Username;
			int? successCode = response.SuccessCode;
			int num = 1;
			if (successCode.GetValueOrDefault() == num & successCode != null)
			{
				this.lastUsernameValid = true;
			}
			else
			{
				this.lastUsernameValid = false;
			}
			this.NextButton.Image = this.NextImage;
			if (this.txtUsername.Text.Length < 4 || this.txtUsername.Text.Length > 18)
			{
				this.FeedbackLabel.Color = global::ARGBColors.Red;
				this.FeedbackLabel.Text = string.Empty;
			}
			else if (this.lastUsernameValid)
			{
				this.FeedbackLabel.Color = global::ARGBColors.Green;
				this.FeedbackLabel.Text = response.Message;
			}
			else
			{
				this.FeedbackLabel.Color = global::ARGBColors.Red;
				this.FeedbackLabel.Text = response.Message;
			}
			this.ValidateNextButton();
		}

		// Token: 0x06000CCE RID: 3278 RVA: 0x000F4D24 File Offset: 0x000F2F24
		private void usernameCheckCallbackThenCreate(IAuthProvider sender, IAuthResponse response)
		{
			this.usernameValidationInProgress = false;
			this.lastUsernameChecked = response.Username;
			int? successCode = response.SuccessCode;
			int num = 1;
			if (successCode.GetValueOrDefault() == num & successCode != null)
			{
				this.lastUsernameValid = true;
				this.CreateUser();
				return;
			}
			this.lastUsernameValid = false;
		}

		// Token: 0x06000CCF RID: 3279 RVA: 0x000F4D78 File Offset: 0x000F2F78
		private bool PasswordIsValid()
		{
			if (Program.gamersFirstInstall || Program.arcInstall)
			{
				return this.txtPassword.Text.Length > 0;
			}
			return this.txtPassword.Text.Trim().Length >= 5 && this.txtPassword.Text.Trim().Length <= 25;
		}

		// Token: 0x06000CD0 RID: 3280 RVA: 0x000F4DE0 File Offset: 0x000F2FE0
		private void ValidatePassword()
		{
			if (this.PasswordIsValid())
			{
				this.FeedbackLabel.Color = global::ARGBColors.Green;
				this.FeedbackLabel.TextDiffOnly = SK.Text("SIGNUP_Password_Valid", "Password Valid");
				this.passwordvalid = true;
			}
			else
			{
				this.FeedbackLabel.Color = global::ARGBColors.Red;
				this.FeedbackLabel.TextDiffOnly = SK.Text("SIGNUP_Password_Invalid", "Password Invalid");
				this.passwordvalid = false;
			}
			this.passwordconfirmvalid = (this.txtPassword.Text.Trim() == this.txtPasswordconfirm.Text.Trim() && this.passwordvalid);
			if (Program.gamersFirstInstall || Program.arcInstall)
			{
				this.passwordconfirmvalid = (this.passwordvalid = true);
			}
		}

		// Token: 0x06000CD1 RID: 3281 RVA: 0x000F4EB0 File Offset: 0x000F30B0
		private void ValidatePasswordConfirm()
		{
			this.ValidatePassword();
			if (!this.passwordconfirmvalid && !this.passwordvalid)
			{
				this.FeedbackLabel.Color = global::ARGBColors.Red;
				this.FeedbackLabel.TextDiffOnly = SK.Text("SIGNUP_Password_Invalid", "Password Invalid");
				return;
			}
			if (!this.passwordconfirmvalid && this.passwordvalid)
			{
				this.FeedbackLabel.Color = global::ARGBColors.Red;
				this.FeedbackLabel.TextDiffOnly = SK.Text("SIGNUP_Password_Not_Match", "Passwords do not match");
				return;
			}
			if (this.passwordconfirmvalid && this.passwordvalid)
			{
				this.FeedbackLabel.Color = global::ARGBColors.Green;
				this.FeedbackLabel.TextDiffOnly = SK.Text("SIGNUP_Password_Match", "Passwords match");
			}
		}

		// Token: 0x06000CD2 RID: 3282 RVA: 0x0000F840 File Offset: 0x0000DA40
		private void tandcToggled()
		{
			this.ValidateNextButton();
		}

		// Token: 0x06000CD3 RID: 3283 RVA: 0x000F4F74 File Offset: 0x000F3174
		private bool everythingValid()
		{
			this.justTandC = false;
			this.justTandCFailed = false;
			this.justTandCShowing = false;
			if (!this.m_createMode)
			{
				return this.txtEmail.Text.Length > 0 && this.txtPassword.Text.Length > 0;
			}
			if (!this.passwordconfirmvalid)
			{
				return false;
			}
			if (!this.emailValid)
			{
				return false;
			}
			if (this.usernameValidationInProgress)
			{
				return false;
			}
			if (!this.lastUsernameValid)
			{
				return false;
			}
			if (!this.passwordvalid)
			{
				return false;
			}
			if (!this.passwordconfirmvalid)
			{
				return false;
			}
			if (this.tandcCheck != null && this.tandcCheck.Visible)
			{
				this.justTandC = true;
				if (!this.tandcCheck.Checked)
				{
					this.justTandCFailed = true;
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000CD4 RID: 3284 RVA: 0x000F5038 File Offset: 0x000F3238
		private void ValidateNextButton()
		{
			this.NextButton.Enabled = this.everythingValid();
			if (this.m_createMode)
			{
				if (this.NextButton.Enabled)
				{
					this.NextButton.Image = this.NextImage;
				}
				else
				{
					this.NextButton.Image = this.NextImageOver;
				}
			}
			else if (this.NextButton.Enabled)
			{
				this.NextButton.Image = this.TransferImage;
			}
			else
			{
				this.NextButton.Image = this.TransferImageOver;
			}
			if (this.emailValid)
			{
				this.fillEmailValid.FillColor = global::ARGBColors.Green;
			}
			else
			{
				this.fillEmailValid.FillColor = global::ARGBColors.Red;
			}
			if (this.emailconfirmvalid)
			{
				this.fillEmailConfirmValid.FillColor = global::ARGBColors.Green;
			}
			else
			{
				this.fillEmailConfirmValid.FillColor = global::ARGBColors.Red;
			}
			if (this.lastUsernameValid)
			{
				this.fillUsernameValid.FillColor = global::ARGBColors.Green;
			}
			else
			{
				this.fillUsernameValid.FillColor = global::ARGBColors.Red;
			}
			if (this.passwordvalid)
			{
				this.fillPasswordValid.FillColor = global::ARGBColors.Green;
			}
			else
			{
				this.fillPasswordValid.FillColor = global::ARGBColors.Red;
			}
			if (this.passwordconfirmvalid)
			{
				this.fillPasswordConfirmValid.FillColor = global::ARGBColors.Green;
			}
			else
			{
				this.fillPasswordConfirmValid.FillColor = global::ARGBColors.Red;
			}
			if (this.justTandC && this.justTandCFailed)
			{
				this.FeedbackLabel.Color = global::ARGBColors.Red;
				this.FeedbackLabel.TextDiffOnly = SK.Text("SIGNUP_TANDC_FAILED", "You must accept the Terms & Conditions before creating an account").Replace("&amp;", "&");
				this.HintBoxLabel.TextDiffOnly = "";
				return;
			}
			if (this.justTandC)
			{
				this.FeedbackLabel.TextDiffOnly = "";
				this.HintBoxLabel.TextDiffOnly = "";
			}
		}

		// Token: 0x040010E1 RID: 4321
		private IContainer components;

		// Token: 0x040010E2 RID: 4322
		private string emailPattern = "^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,4}$";

		// Token: 0x040010E3 RID: 4323
		private string usernamePattern = "^[A-Za-z0-9 -]+$";

		// Token: 0x040010E4 RID: 4324
		private TextBox txtEmail;

		// Token: 0x040010E5 RID: 4325
		private TextBox txtEmailconfirm;

		// Token: 0x040010E6 RID: 4326
		private TextBox txtUsername;

		// Token: 0x040010E7 RID: 4327
		private TextBox txtPassword;

		// Token: 0x040010E8 RID: 4328
		private TextBox txtPasswordconfirm;

		// Token: 0x040010E9 RID: 4329
		private CustomSelfDrawPanel.CSDLabel lblEmail;

		// Token: 0x040010EA RID: 4330
		private CustomSelfDrawPanel.CSDLabel lblEmailconfirm;

		// Token: 0x040010EB RID: 4331
		private CustomSelfDrawPanel.CSDLabel lblUsername;

		// Token: 0x040010EC RID: 4332
		private CustomSelfDrawPanel.CSDLabel lblPassword;

		// Token: 0x040010ED RID: 4333
		private CustomSelfDrawPanel.CSDLabel lblPasswordconfirm;

		// Token: 0x040010EE RID: 4334
		private string TextHint_Email = SK.Text("SIGNUP_Hint_Email", "This must be a valid email address in the form user@domain.com, your Stronghold account will be linked to this email address and you will be sent an email to confirm your identity.");

		// Token: 0x040010EF RID: 4335
		private string TextHint_EmailConfirm = SK.Text("SIGNUP_Hint_EmailConfirm", "Please confirm your email address above by typing it again here.");

		// Token: 0x040010F0 RID: 4336
		private string TextHint_Username = SK.Text("SIGNUP_Hint_Username", "Please enter your preferred username. this will be your username in Stronghold Kingdoms and in any related web forums. A username must be at least 4 characters long and must be unique.");

		// Token: 0x040010F1 RID: 4337
		private string TextHint_Password = SK.Text("SIGNUP_Hint_Password", "Please enter your desired password. Your password may be anything you like. For better security please consider a strong password containing both upper and lower case letters and at least one digit. The password must be between 5-25 characters long.");

		// Token: 0x040010F2 RID: 4338
		private string TextHint_PasswordConfirm = SK.Text("SIGNUP_Hint_PasswordConfirm", "Please confirm your chosen password by typing it again here.");

		// Token: 0x040010F3 RID: 4339
		private string TextCreateHeader = SK.Text("SIGNUP_header", "Create Your Stronghold Kingdoms Account");

		// Token: 0x040010F4 RID: 4340
		private string TextCreateHeaderMerge = SK.Text("SIGNUP_header_merge", "Transfer Your Stronghold Kingdoms Account To Steam");

		// Token: 0x040010F5 RID: 4341
		private string TextEmail = SK.Text("SIGNUP_your_email", "Your email address");

		// Token: 0x040010F6 RID: 4342
		private string TextEmailConfirm = SK.Text("SIGNUP_confirm_your_email", "Confirm your email address");

		// Token: 0x040010F7 RID: 4343
		private string TextUsername = SK.Text("SIGNUP_username", "Choose a Username");

		// Token: 0x040010F8 RID: 4344
		private string TextPassword = SK.Text("SIGNUP_password", "Choose a Password");

		// Token: 0x040010F9 RID: 4345
		private string TextPasswordConfirm = SK.Text("SIGNUP_confirm_password", "Confirm Password");

		// Token: 0x040010FA RID: 4346
		private string strNext = SK.Text("LOGIN_CreateAccount", "Create Account");

		// Token: 0x040010FB RID: 4347
		private string strClose = SK.Text("GENERIC_Close", "Close");

		// Token: 0x040010FC RID: 4348
		private string strBack = SK.Text("FORUMS_Back", "Back");

		// Token: 0x040010FD RID: 4349
		private string TextHint_Email_Merge = SK.Text("SIGNUP_Hint_Email_Merge", "Please enter your current Stronghold Kingdoms Email Address");

		// Token: 0x040010FE RID: 4350
		private string TextHint_Password_Merge = SK.Text("SIGNUP_Hint_Password_Merge", "Please enter your current Stronghold Kingdoms password.");

		// Token: 0x040010FF RID: 4351
		private string strMerge = SK.Text("SIGNUP_MERGE", "Transfer Account");

		// Token: 0x04001100 RID: 4352
		private string TextPasswordMerge = SK.Text("SIGNUP_password_merge", "Enter your Password");

		// Token: 0x04001101 RID: 4353
		private Font WebTextFontBold = FontManager.GetPrivateFont("AssetIcons/Cards/panel/Brokenscript-Bold.ttf", 10f, FontStyle.Bold);

		// Token: 0x04001102 RID: 4354
		private Font WebTextFontBoldCond = FontManager.GetPrivateFont("AssetIcons/Cards/panel/Brokenscript-BoldCond.ttf", 10f, FontStyle.Bold);

		// Token: 0x04001103 RID: 4355
		private Color WebButtonblue = Color.FromArgb(85, 145, 203);

		// Token: 0x04001104 RID: 4356
		private Color WebButtonRed = Color.FromArgb(160, 0, 0);

		// Token: 0x04001105 RID: 4357
		private Color WebButtonYellow = Color.FromArgb(225, 225, 0);

		// Token: 0x04001106 RID: 4358
		private Color WebButtonGrey = Color.FromArgb(225, 225, 225);

		// Token: 0x04001107 RID: 4359
		private int WebButtonheight = 22;

		// Token: 0x04001108 RID: 4360
		private int WebButtonRadius = 10;

		// Token: 0x04001109 RID: 4361
		public static Image nextImage;

		// Token: 0x0400110A RID: 4362
		public static Image nextImageOver;

		// Token: 0x0400110B RID: 4363
		public static Image headerImage;

		// Token: 0x0400110C RID: 4364
		public static Image headerTransferImage;

		// Token: 0x0400110D RID: 4365
		public static Image closeImage;

		// Token: 0x0400110E RID: 4366
		public static Image closeImageOver;

		// Token: 0x0400110F RID: 4367
		public static Image transferImage;

		// Token: 0x04001110 RID: 4368
		public static Image transferImageOver;

		// Token: 0x04001111 RID: 4369
		private static Image HintBoxImage;

		// Token: 0x04001112 RID: 4370
		private CustomSelfDrawPanel.CSDImage NextButton;

		// Token: 0x04001113 RID: 4371
		private CustomSelfDrawPanel.CSDImage HeaderTitle;

		// Token: 0x04001114 RID: 4372
		private CustomSelfDrawPanel.CSDImage HintBox;

		// Token: 0x04001115 RID: 4373
		private CustomSelfDrawPanel.CSDLabel HintBoxLabel;

		// Token: 0x04001116 RID: 4374
		private CustomSelfDrawPanel.CSDLabel FeedbackLabel;

		// Token: 0x04001117 RID: 4375
		private CustomSelfDrawPanel.CSDLabel alreadyLabel;

		// Token: 0x04001118 RID: 4376
		private CustomSelfDrawPanel.CSDFill fillEmailValid;

		// Token: 0x04001119 RID: 4377
		private CustomSelfDrawPanel.CSDFill fillEmailConfirmValid;

		// Token: 0x0400111A RID: 4378
		private CustomSelfDrawPanel.CSDFill fillUsernameValid;

		// Token: 0x0400111B RID: 4379
		private CustomSelfDrawPanel.CSDFill fillPasswordValid;

		// Token: 0x0400111C RID: 4380
		private CustomSelfDrawPanel.CSDFill fillPasswordConfirmValid;

		// Token: 0x0400111D RID: 4381
		private CustomSelfDrawPanel.CSDLabel tandcLabel;

		// Token: 0x0400111E RID: 4382
		private CustomSelfDrawPanel.CSDLabel privacyLabel;

		// Token: 0x0400111F RID: 4383
		private CustomSelfDrawPanel.CSDCheckBox newsletterCheck;

		// Token: 0x04001120 RID: 4384
		private CustomSelfDrawPanel.CSDCheckBox tandcCheck;

		// Token: 0x04001121 RID: 4385
		private bool m_createMode = true;

		// Token: 0x04001122 RID: 4386
		private bool emailValid;

		// Token: 0x04001123 RID: 4387
		private bool emailconfirmvalid;

		// Token: 0x04001124 RID: 4388
		private bool passwordvalid;

		// Token: 0x04001125 RID: 4389
		private bool passwordconfirmvalid;

		// Token: 0x04001126 RID: 4390
		private bool lastUsernameValid;

		// Token: 0x04001127 RID: 4391
		private bool usernameValidationInProgress;

		// Token: 0x04001128 RID: 4392
		private string lastUsernameChecked = string.Empty;

		// Token: 0x04001129 RID: 4393
		private bool usernameNotChecked;

		// Token: 0x0400112A RID: 4394
		private bool justTandC;

		// Token: 0x0400112B RID: 4395
		private bool justTandCFailed;

		// Token: 0x0400112C RID: 4396
		private bool justTandCShowing;
	}
}
