using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using Stronghold.AuthClient;

namespace Kingdoms
{
	// Token: 0x0200028B RID: 651
	public class PrizeClaimPanel : CustomSelfDrawPanel
	{
		// Token: 0x06001D1E RID: 7454 RVA: 0x0001C65F File Offset: 0x0001A85F
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001D1F RID: 7455 RVA: 0x001C581C File Offset: 0x001C3A1C
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.None;
			base.Name = "PrizeClaimPanel";
			base.Size = new Size(600, 55);
			base.ResumeLayout(false);
		}

		// Token: 0x06001D20 RID: 7456 RVA: 0x001C5870 File Offset: 0x001C3A70
		public PrizeClaimPanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06001D21 RID: 7457 RVA: 0x001C5948 File Offset: 0x001C3B48
		public void init(PrizeClaimWindow parent)
		{
			this.m_parent = parent;
			base.clearControls();
			this.background.Size = new Size(parent.Width, parent.Height);
			this.background.Create(GFXLibrary._9sclice_generic_top_left, GFXLibrary._9sclice_generic_top_mid, GFXLibrary._9sclice_generic_top_right, GFXLibrary._9sclice_generic_mid_left, GFXLibrary._9sclice_generic_mid_mid, GFXLibrary._9sclice_generic_mid_right, GFXLibrary._9sclice_generic_bottom_left, GFXLibrary._9sclice_generic_bottom_mid, GFXLibrary._9sclice_generic_bottom_right);
			base.addControl(this.background);
			this.backgroundArea.Position = new Point(0, 0);
			this.backgroundArea.Size = new Size(625, 668);
			this.background.addControl(this.backgroundArea);
			this.claimButton.ImageNorm = GFXLibrary.button_132_normal_gold;
			this.claimButton.ImageOver = GFXLibrary.button_132_over_gold;
			this.claimButton.ImageClick = GFXLibrary.button_132_in_gold;
			this.claimButton.setSizeToImage();
			this.claimButton.Position = new Point(this.background.Width / 4 - this.claimButton.Width / 2, this.background.Height - 40 - this.claimButton.Height / 2);
			this.claimButton.Text.Text = SK.Text("CONTEST_Claim_Prize", "Claim Prize");
			this.claimButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.claimButton.TextYOffset = -2;
			this.claimButton.Text.Color = global::ARGBColors.Black;
			this.claimButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.claimClick));
			this.claimButton.Enabled = true;
			this.background.addControl(this.claimButton);
			this.closeButton.ImageNorm = GFXLibrary.button_132_normal;
			this.closeButton.ImageOver = GFXLibrary.button_132_over;
			this.closeButton.ImageClick = GFXLibrary.button_132_in;
			this.closeButton.setSizeToImage();
			this.closeButton.Position = new Point(this.background.Width * 3 / 4 - this.closeButton.Width / 2, this.background.Rectangle.Bottom - 40 - this.closeButton.Height / 2);
			this.closeButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.closeButton.TextYOffset = -2;
			this.closeButton.Text.Color = global::ARGBColors.Black;
			this.closeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick));
			this.closeButton.Enabled = true;
			this.closeButton.Text.Text = SK.Text("GENERIC_Close", "Close");
			this.background.addControl(this.closeButton);
			this.m_PrizeContent.clearControls();
			this.m_PrizeContent.Visible = false;
			this.headerLabel = new CustomSelfDrawPanel.CSDLabel();
			this.headerLabel.Text = SK.Text("Reports_Prize_Claimed", "Prize Claimed");
			this.headerLabel.Color = global::ARGBColors.Black;
			this.headerLabel.Size = new Size(this.background.Width, 40);
			this.headerLabel.Position = new Point(0, 30);
			this.headerLabel.Font = FontManager.GetFont("Arial", 24f, FontStyle.Bold);
			this.headerLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.background.addControl(this.headerLabel);
			this.prizeNameLabel = new CustomSelfDrawPanel.CSDLabel();
			this.prizeNameLabel.Text = "";
			this.prizeNameLabel.Color = global::ARGBColors.Black;
			this.prizeNameLabel.Size = new Size(this.background.Width, 30);
			this.prizeNameLabel.Position = new Point(0, this.headerLabel.Rectangle.Bottom);
			this.prizeNameLabel.Font = FontManager.GetFont("Arial", 16f, FontStyle.Bold);
			this.prizeNameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.background.addControl(this.prizeNameLabel);
			this.prizeContentInset.Size = new Size(this.background.Width - 80, this.closeButton.Y - this.prizeNameLabel.Rectangle.Bottom);
			this.prizeContentInset.Position = new Point(base.Width / 2 - this.prizeContentInset.Width / 2, this.prizeNameLabel.Rectangle.Bottom);
			this.prizeContentInset.Create(GFXLibrary._9sclice_bracket_top_left, GFXLibrary._9sclice_bracket_mid_mid, GFXLibrary._9sclice_bracket_top_right, GFXLibrary._9sclice_bracket_mid_mid, GFXLibrary._9sclice_bracket_mid_mid, GFXLibrary._9sclice_bracket_mid_mid, GFXLibrary._9sclice_bracket_bottom_left, GFXLibrary._9sclice_bracket_mid_mid, GFXLibrary._9sclice_bracket_bottom_right);
			this.background.addControl(this.prizeContentInset);
			this.prizeContentInset.addControl(this.m_PrizeContent);
			this.prizeCountLabel = new CustomSelfDrawPanel.CSDLabel();
			this.prizeCountLabel.Color = global::ARGBColors.Black;
			this.prizeCountLabel.Position = new Point(0, this.prizeContentInset.Rectangle.Bottom - 15);
			this.prizeCountLabel.Size = new Size(this.background.Width, this.claimButton.Y - this.prizeCountLabel.Y);
			this.prizeCountLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.prizeCountLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			int count = GameEngine.Instance.World.pendingPrizes.Count;
			if (count > 0)
			{
				this.prizeCountLabel.Text = SK.Text("CONTEST_Prizes_Remaining", "Prizes waiting to be claimed") + ": ";
				CustomSelfDrawPanel.CSDLabel csdlabel = this.prizeCountLabel;
				csdlabel.Text += count.ToString();
			}
			else
			{
				this.prizeCountLabel.Text = "";
			}
			this.background.addControl(this.prizeCountLabel);
			this.background.Visible = false;
			this.initialBackground.Size = new Size(parent.Width, parent.Height / 2);
			this.initialBackground.Create(GFXLibrary._9sclice_generic_top_left, GFXLibrary._9sclice_generic_top_mid, GFXLibrary._9sclice_generic_top_right, GFXLibrary._9sclice_generic_mid_left, GFXLibrary._9sclice_generic_mid_mid, GFXLibrary._9sclice_generic_mid_right, GFXLibrary._9sclice_generic_bottom_left, GFXLibrary._9sclice_generic_bottom_mid, GFXLibrary._9sclice_generic_bottom_right);
			this.initialBackground.Position = new Point(0, parent.Height / 4);
			base.addControl(this.initialBackground);
			this.initialBackgroundArea.Position = new Point(0, 0);
			this.initialBackgroundArea.Size = this.initialBackground.Size;
			this.initialBackground.addControl(this.initialBackgroundArea);
			this.initialClaimButton.ImageNorm = GFXLibrary.button_132_normal_gold;
			this.initialClaimButton.ImageOver = GFXLibrary.button_132_over_gold;
			this.initialClaimButton.ImageClick = GFXLibrary.button_132_in_gold;
			this.initialClaimButton.setSizeToImage();
			this.initialClaimButton.Position = new Point(this.initialBackground.Width / 4 - this.initialClaimButton.Width / 2, this.initialBackground.Height - 40 - this.initialClaimButton.Height / 2);
			this.initialClaimButton.Text.Text = SK.Text("CONTEST_Claim_Prize", "Claim Prize");
			this.initialClaimButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.initialClaimButton.TextYOffset = -2;
			this.initialClaimButton.Text.Color = global::ARGBColors.Black;
			this.initialClaimButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.claimClick));
			this.initialClaimButton.Enabled = true;
			this.initialBackground.addControl(this.initialClaimButton);
			this.initialCloseButton.ImageNorm = GFXLibrary.button_132_normal;
			this.initialCloseButton.ImageOver = GFXLibrary.button_132_over;
			this.initialCloseButton.ImageClick = GFXLibrary.button_132_in;
			this.initialCloseButton.setSizeToImage();
			this.initialCloseButton.Position = new Point(this.background.Width * 3 / 4 - this.initialCloseButton.Width / 2, this.initialClaimButton.Y);
			this.initialCloseButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.initialCloseButton.TextYOffset = -2;
			this.initialCloseButton.Text.Color = global::ARGBColors.Black;
			this.initialCloseButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick));
			this.initialCloseButton.Enabled = true;
			this.initialCloseButton.Text.Text = SK.Text("GENERIC_Close", "Close");
			this.initialBackground.addControl(this.initialCloseButton);
			this.initialHeaderLabel = new CustomSelfDrawPanel.CSDLabel();
			this.initialHeaderLabel.Text = SK.Text("CONTEST_Claim_Your_Prize", "Claim Your Prize!");
			this.initialHeaderLabel.Color = global::ARGBColors.Black;
			this.initialHeaderLabel.Size = new Size(this.initialBackground.Width, 40);
			this.initialHeaderLabel.Position = new Point(0, 30);
			this.initialHeaderLabel.Font = FontManager.GetFont("Arial", 24f, FontStyle.Bold);
			this.initialHeaderLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.initialBackground.addControl(this.initialHeaderLabel);
			this.initialPrizeCountLabel = new CustomSelfDrawPanel.CSDLabel();
			this.initialPrizeCountLabel.Color = global::ARGBColors.Black;
			this.initialPrizeCountLabel.Position = new Point(0, this.initialHeaderLabel.Rectangle.Bottom);
			this.initialPrizeCountLabel.Size = new Size(this.initialBackground.Width, this.initialClaimButton.Y - this.initialPrizeCountLabel.Y);
			this.initialPrizeCountLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.initialPrizeCountLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			if (count > 0)
			{
				this.initialPrizeCountLabel.Text = SK.Text("CONTEST_Prizes_Remaining", "Prizes waiting to be claimed") + ": ";
				CustomSelfDrawPanel.CSDLabel csdlabel2 = this.initialPrizeCountLabel;
				csdlabel2.Text += count.ToString();
			}
			else
			{
				this.initialPrizeCountLabel.Text = "";
			}
			this.initialBackground.addControl(this.initialPrizeCountLabel);
			this.background.Visible = false;
		}

		// Token: 0x06001D22 RID: 7458 RVA: 0x001C64C4 File Offset: 0x001C46C4
		private void claimClick()
		{
			if (GameEngine.Instance.World.pendingPrizes.Count > 0)
			{
				if (this.claimLock.canCall())
				{
					this.ClaimPrize(GameEngine.Instance.World.pendingPrizes[0]);
					return;
				}
			}
			else
			{
				this.closeClick();
			}
		}

		// Token: 0x06001D23 RID: 7459 RVA: 0x001C6518 File Offset: 0x001C4718
		private void ClaimPrize(int prizeID)
		{
			this.m_PrizeContent.Visible = false;
			this.prizeNameLabel.Text = "";
			XmlRpcContestProvider xmlRpcContestProvider = XmlRpcContestProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressLogin, URLs.ProfileServerPort, URLs.ProfilePath);
			XmlRpcContestRequest xmlRpcContestRequest = new XmlRpcContestRequest();
			xmlRpcContestRequest.SessionID = RemoteServices.Instance.SessionGuid.ToString().Replace("-", "");
			xmlRpcContestRequest.UserGUID = RemoteServices.Instance.UserGuid.ToString().Replace("-", "");
			xmlRpcContestRequest.PrizeID = new int?(prizeID);
			xmlRpcContestRequest.WorldID = new int?(RemoteServices.Instance.ProfileWorldID);
			this.m_ClaimResponseDel = new PrizeClaimPanel.ResponseDelegate(this.OnClaimResponse);
			xmlRpcContestProvider.ClaimContestPrize(xmlRpcContestRequest, new ContestEndResponseDelegate(this.ClaimPrizeCallback), null);
		}

		// Token: 0x06001D24 RID: 7460 RVA: 0x001C6604 File Offset: 0x001C4804
		private void ClaimPrizeCallback(IContestProvider provider, IContestResponse response)
		{
			this.claimLock.called();
			int? successCode = response.SuccessCode;
			int num = 1;
			if ((successCode.GetValueOrDefault() == num & successCode != null) && ((XmlRpcContestResponse)response).ClaimedPrize != null)
			{
				ContestPrizeDefinition contestPrizeDefinition = new ContestPrizeDefinition();
				contestPrizeDefinition.Content = ((XmlRpcContestResponse)response).ClaimedPrize;
				this.AddPrizeContentToAccount(contestPrizeDefinition.Content);
				this.prizeNameLabel.Text = contestPrizeDefinition.Content.Name;
				this.m_PrizeContent.Visible = true;
				this.m_PrizeContent.init(contestPrizeDefinition, this.prizeContentInset, 20, 10);
				GameEngine.Instance.World.pendingPrizes.RemoveAt(0);
				this.prizeNameLabel.invalidate();
				int count = GameEngine.Instance.World.pendingPrizes.Count;
				if (count > 0)
				{
					this.prizeCountLabel.Text = SK.Text("CONTEST_Prizes_Remaining", "Prizes waiting to be claimed") + ": ";
					CustomSelfDrawPanel.CSDLabel csdlabel = this.prizeCountLabel;
					csdlabel.Text += count.ToString();
					this.claimButton.Text.Text = SK.Text("CONTEST_Next_Prize", "Next Prize");
				}
				else
				{
					this.claimButton.Visible = false;
					this.prizeCountLabel.Text = "";
				}
				this.prizeContentInset.invalidate();
				this.initialBackground.Visible = false;
				this.initialBackground.invalidate();
				this.background.Visible = true;
				this.background.invalidate();
			}
		}

		// Token: 0x06001D25 RID: 7461 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void OnClaimResponse(bool success)
		{
		}

		// Token: 0x06001D26 RID: 7462 RVA: 0x001C6798 File Offset: 0x001C4998
		private void AddPrizeContentToAccount(ContestPrizeContent content)
		{
			if (content.Gold > 0)
			{
				GameEngine.Instance.World.addGold((double)content.Gold);
			}
			if (content.Honour > 0)
			{
				GameEngine.Instance.World.addHonour((double)content.Honour);
			}
			if (content.FaithPoints > 0)
			{
				GameEngine.Instance.World.addFaithPoints((double)content.FaithPoints);
			}
			int repPoints = content.RepPoints;
			for (int i = 0; i < content.WheelSpins.Count; i++)
			{
				GameEngine.Instance.World.addTickets(i, content.WheelSpins[i]);
			}
			foreach (ContestPrizePackDefinition contestPrizePackDefinition in content.Packs)
			{
				CardTypes.CardOffer cardOffer = GameEngine.Instance.cardPackManager.GetCardOffer(contestPrizePackDefinition.OfferID);
				GameEngine.Instance.cardPackManager.addCardPack(cardOffer.ID, contestPrizePackDefinition.Amount);
			}
			foreach (ContestPrizeTokenDefinition contestPrizeTokenDefinition in content.Tokens)
			{
			}
			foreach (ContestPrizeCardDefinition contestPrizeCardDefinition in content.Cards)
			{
			}
		}

		// Token: 0x06001D27 RID: 7463 RVA: 0x0001C67E File Offset: 0x0001A87E
		private void closeClick()
		{
			PrizeClaimWindow.close();
		}

		// Token: 0x04002DEC RID: 11756
		private IContainer components;

		// Token: 0x04002DED RID: 11757
		private CustomSelfDrawPanel.CSDExtendingPanel background = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04002DEE RID: 11758
		private CustomSelfDrawPanel.CSDArea backgroundArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04002DEF RID: 11759
		private CustomSelfDrawPanel.CSDExtendingPanel prizeContentInset = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04002DF0 RID: 11760
		private ContestPrizeList m_PrizeContent = new ContestPrizeList();

		// Token: 0x04002DF1 RID: 11761
		private CustomSelfDrawPanel.CSDLabel prizeNameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002DF2 RID: 11762
		private CustomSelfDrawPanel.CSDLabel headerLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002DF3 RID: 11763
		private CustomSelfDrawPanel.CSDLabel prizeCountLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002DF4 RID: 11764
		private CustomSelfDrawPanel.CSDButton claimButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002DF5 RID: 11765
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002DF6 RID: 11766
		private PrizeClaimPanel.ResponseDelegate m_ClaimResponseDel;

		// Token: 0x04002DF7 RID: 11767
		private PrizeClaimWindow m_parent;

		// Token: 0x04002DF8 RID: 11768
		private ClickLock claimLock = new ClickLock();

		// Token: 0x04002DF9 RID: 11769
		private CustomSelfDrawPanel.CSDExtendingPanel initialBackground = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04002DFA RID: 11770
		private CustomSelfDrawPanel.CSDArea initialBackgroundArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04002DFB RID: 11771
		private CustomSelfDrawPanel.CSDLabel initialHeaderLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002DFC RID: 11772
		private CustomSelfDrawPanel.CSDLabel initialPrizeCountLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002DFD RID: 11773
		private CustomSelfDrawPanel.CSDButton initialClaimButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002DFE RID: 11774
		private CustomSelfDrawPanel.CSDButton initialCloseButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0200028C RID: 652
		// (Invoke) Token: 0x06001D29 RID: 7465
		private delegate void AsyncDelegate();

		// Token: 0x0200028D RID: 653
		// (Invoke) Token: 0x06001D2D RID: 7469
		private delegate void ResponseDelegate(bool success);
	}
}
