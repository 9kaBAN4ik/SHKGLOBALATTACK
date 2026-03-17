using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms.Properties;
using StatTracking;
using Stronghold.AuthClient;

namespace Kingdoms
{
	// Token: 0x02000277 RID: 631
	public partial class PlayCardsWindow : Form
	{
		// Token: 0x170001DF RID: 479
		// (get) Token: 0x06001C47 RID: 7239 RVA: 0x0001BCDB File Offset: 0x00019EDB
		public ManageCardsPanel CardPanelManage
		{
			get
			{
				return this.cardPanelManage;
			}
		}

		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x06001C48 RID: 7240 RVA: 0x0001BCE3 File Offset: 0x00019EE3
		public int CurrentPanelID
		{
			get
			{
				return this.currentPanelID;
			}
		}

		// Token: 0x06001C49 RID: 7241 RVA: 0x001BB20C File Offset: 0x001B940C
		public void SwitchPanel(int panel)
		{
			this.cardPanelPlay.clearControls();
			this.cardPanelBuy.clearControls();
			this.cardPanelManage.clearControls();
			this.cardPanelPremium.clearControls();
			this.cardPanelViewAll.clearControls();
			this.cardPanelOffers.clearControls();
			this.crownsBuyPanel.clearControls();
			if (panel == this.currentPanelID)
			{
				panel = 1;
			}
			switch (panel)
			{
			case 1:
				this.currentPanel = this.cardPanelPlay;
				goto IL_F5;
			case 2:
				this.currentPanel = this.cardPanelBuy;
				goto IL_F5;
			case 4:
				this.currentPanel = this.cardPanelPremium;
				goto IL_F5;
			case 6:
				this.currentPanel = this.cardPanelManage;
				goto IL_F5;
			case 7:
				this.currentPanel = this.crownsBuyPanel;
				goto IL_F5;
			case 8:
				this.currentPanel = this.cardPanelViewAll;
				goto IL_F5;
			case 9:
				this.currentPanel = this.cardPanelOffers;
				goto IL_F5;
			}
			this.currentPanel = this.cardPanelPlay;
			IL_F5:
			this.tbSearchBox.Parent.Controls.Remove(this.tbSearchBox);
			this.currentPanel.Controls.Add(this.tbSearchBox);
			this.processTextChanged = false;
			this.tbSearchBox.Text = "";
			this.processTextChanged = true;
			this.tbSearchBox.Visible = false;
			this.currentPanelID = panel;
			new ComponentResourceManager(this.currentPanel.GetType());
			base.SuspendLayout();
			this.currentPanel.Location = new Point(0, 0);
			this.currentPanel.Name = "cardPanel";
			this.currentPanel.Size = new Size(1000, 600);
			this.currentPanel.StoredGraphics = null;
			this.currentPanel.TabIndex = 0;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.None;
			base.ClientSize = new Size(1000, 600);
			base.ControlBox = false;
			base.Controls.Clear();
			base.Controls.Add(this.currentPanel);
			base.FormBorderStyle = FormBorderStyle.None;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "PlayCardsWindow";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.Manual;
			this.Text = "PlayCardsWindow";
			base.ResumeLayout(false);
			this.init(this.currentCardSection, false);
		}

		// Token: 0x06001C4A RID: 7242 RVA: 0x0001BCEB File Offset: 0x00019EEB
		public void SwitchToManageAndFilter(int filter, int cardType)
		{
			this.SwitchPanel(6);
			this.cardPanelManage.setFilter(filter);
			this.cardPanelManage.SwitchToBuy();
			this.cardPanelManage.addCardToCard(cardType, false);
		}

		// Token: 0x06001C4B RID: 7243 RVA: 0x001BB484 File Offset: 0x001B9684
		public PlayCardsWindow()
		{
			this.cardPanelPlay = new PlayCardsPanel();
			this.cardPanelBuy = new BuyCardsPanel();
			this.cardPanelManage = new ManageCardsPanel();
			this.cardPanelPremium = new PremiumCardsPanel();
			this.cardPanelViewAll = new ViewAllCardsPanel();
			this.crownsBuyPanel = new BuyCrownsPanel();
			this.cardPanelOffers = new PremiumOffersPanel();
			this.currentPanel = this.cardPanelPlay;
			this.currentPanelID = 1;
			this.InitializeComponent();
			this.tbSearchBox.Font = FontManager.GetFont("Arial", 9.75f, FontStyle.Regular);
			this.tbSearchBox.Parent.Controls.Remove(this.tbSearchBox);
			this.currentPanel.Controls.Add(this.tbSearchBox);
			this.processTextChanged = false;
			this.tbSearchBox.Text = "";
			this.processTextChanged = true;
			this.tbSearchBox.Visible = false;
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			base.TransparencyKey = Color.FromArgb(255, 255, 0, 255);
			this.BackColor = base.TransparencyKey;
			if (!GameEngine.Instance.World.TutorialIsAdvancing())
			{
				if (GameEngine.Instance.World.getTutorialStage() == 8)
				{
					GameEngine.Instance.World.checkQuestObjectiveComplete(7);
				}
				if (GameEngine.Instance.World.getTutorialStage() == 12)
				{
					GameEngine.Instance.World.checkQuestObjectiveComplete(11);
				}
				if (GameEngine.Instance.World.getTutorialStage() == 102)
				{
					GameEngine.Instance.World.checkQuestObjectiveComplete(13);
				}
			}
		}

		// Token: 0x06001C4C RID: 7244 RVA: 0x0001BD18 File Offset: 0x00019F18
		public static void resetRewardCardTimer()
		{
			PlayCardsWindow.m_lastRewardCardsCall = DateTime.MinValue;
		}

		// Token: 0x06001C4D RID: 7245 RVA: 0x0001BD24 File Offset: 0x00019F24
		public static void logout()
		{
			PlayCardsWindow.CrownsOpened = false;
			PlayCardsWindow.resetRewardCardTimer();
		}

		// Token: 0x06001C4E RID: 7246 RVA: 0x001BB634 File Offset: 0x001B9834
		public void init(int cardSection, bool fromOpen)
		{
			this.m_fromOpen = fromOpen;
			this.currentCardSection = cardSection;
			int num = 180;
			if (PlayCardsWindow.CrownsOpened)
			{
				num = 30;
			}
			if (DateTime.Now.Subtract(GameEngine.Instance.World.LastUpdatedCrowns).TotalSeconds > (double)num)
			{
				this.UpdateCrowns();
			}
			if (this.m_fromOpen && GameEngine.Instance.World.isTutorialActive() && DateTime.Now.Subtract(PlayCardsWindow.m_lastRewardCardsCall).TotalSeconds > 600.0)
			{
				this.UpdateRewardCards();
			}
			((CustomSelfDrawPanel.ICardsPanel)this.currentPanel).init(cardSection);
		}

		// Token: 0x06001C4F RID: 7247 RVA: 0x0001BD31 File Offset: 0x00019F31
		public void SetCardSection(int cardSection)
		{
			this.currentCardSection = cardSection;
		}

		// Token: 0x06001C50 RID: 7248 RVA: 0x0001BD3A File Offset: 0x00019F3A
		public void update()
		{
			((CustomSelfDrawPanel.ICardsPanel)this.currentPanel).update();
		}

		// Token: 0x06001C51 RID: 7249 RVA: 0x001BB6E4 File Offset: 0x001B98E4
		public void UpdateRewardCards()
		{
			ICardsProvider cardsProvider = XmlRpcCardsProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressCards, URLs.ProfileServerPort, URLs.ProfileCardPath);
			ICardsRequest cardsRequest = new XmlRpcCardsRequest();
			cardsRequest.UserGUID = RemoteServices.Instance.UserGuid.ToString("N");
			cardsRequest.SessionGUID = RemoteServices.Instance.SessionGuid.ToString().Replace("-", "");
			cardsRequest.WorldID = RemoteServices.Instance.ProfileWorldID.ToString();
			((XmlRpcCardsProvider)cardsProvider).getRewardCards(cardsRequest, new CardsEndResponseDelegate(this.getRewardcardsCallback), this);
		}

		// Token: 0x06001C52 RID: 7250 RVA: 0x001BB78C File Offset: 0x001B998C
		private void getRewardcardsCallback(ICardsProvider sender, ICardsResponse response)
		{
			PlayCardsWindow.m_lastRewardCardsCall = DateTime.Now;
			foreach (int num in response.Cards.Keys)
			{
				if (!GameEngine.Instance.cardsManager.ProfileCards.ContainsKey(num))
				{
					GameEngine.Instance.cardsManager.addProfileCard(num, response.Cards[num]);
					GameEngine.Instance.cardsManager.ProfileCards[num].rewardcard = true;
					GameEngine.Instance.cardsManager.ProfileCards[num].worldID = RemoteServices.Instance.ProfileWorldID;
				}
			}
			if (response.Cardpoints != null)
			{
				GameEngine.Instance.World.FakeCardPoints = response.Cardpoints.Value;
			}
			((CustomSelfDrawPanel.ICardsPanel)this.currentPanel).init(this.currentCardSection);
		}

		// Token: 0x06001C53 RID: 7251 RVA: 0x001BB8A0 File Offset: 0x001B9AA0
		public void UpdateCrowns()
		{
			XmlRpcCardsProvider xmlRpcCardsProvider = XmlRpcCardsProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressCards, URLs.ProfileServerPort, URLs.ProfileCardPath);
			xmlRpcCardsProvider.getCrowns(new XmlRpcCardsRequest(RemoteServices.Instance.UserGuid.ToString().Replace("-", ""))
			{
				SessionGUID = RemoteServices.Instance.SessionGuid.ToString().Replace("-", "")
			}, new CardsEndResponseDelegate(this.UpdateCrownsCallback), this);
		}

		// Token: 0x06001C54 RID: 7252 RVA: 0x001BB938 File Offset: 0x001B9B38
		public void UpdateCrownsCallback(ICardsProvider provider, ICardsResponse response)
		{
			if (response.SuccessCode.Value == 1)
			{
				GameEngine.Instance.World.ProfileCrowns = response.Crowns.Value;
				GameEngine.Instance.World.LastUpdatedCrowns = DateTime.Now;
				GameEngine.Instance.cardPackManager.ProfileUserCardPacks = response.UserCardPacks;
			}
		}

		// Token: 0x06001C55 RID: 7253 RVA: 0x001BB99C File Offset: 0x001B9B9C
		public void InviteAFriend()
		{
			string text = URLs.InviteAFriendURL + "?webtoken=" + RemoteServices.Instance.WebToken;
			text = text + "&lang=" + Program.mySettings.LanguageIdent.ToLower();
			try
			{
				Process.Start(text);
			}
			catch (Exception)
			{
				MyMessageBox.Show(SK.Text("ERROR_Browser1", "Stronghold Kingdoms encountered an error when trying to open your system's Default Web Browser. Please check that your web browser is working correctly and there are no unresponsive copies showing in task manager->Processes and then try again.") + Environment.NewLine + Environment.NewLine + SK.Text("ERROR_Browser2", "If this problem persists, please contact support."), SK.Text("ERROR_Browser3", "Error opening Web Browser"));
			}
		}

		// Token: 0x06001C56 RID: 7254 RVA: 0x001BBA3C File Offset: 0x001B9C3C
		public void GetBigpointURL()
		{
			XmlRpcBPProvider xmlRpcBPProvider = XmlRpcBPProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressBigpoint, URLs.ProfileServerPort, URLs.ProfileBPPath);
			xmlRpcBPProvider.GetPaymentURL(new XmlRpcBPRequest
			{
				SessionID = RemoteServices.Instance.SessionGuid.ToString().Replace("-", ""),
				UserGUID = RemoteServices.Instance.UserGuid.ToString().Replace("-", "")
			}, new BPEndResponseDelegate(this.GetbigpointURLCallback), this);
		}

		// Token: 0x06001C57 RID: 7255 RVA: 0x001BBAD8 File Offset: 0x001B9CD8
		public void GetbigpointURLCallback(IBPProvider provider, IBPResponse response)
		{
			int? successCode = response.SuccessCode;
			int num = 1;
			if (!(successCode.GetValueOrDefault() == num & successCode != null))
			{
				MyMessageBox.Show("");
				return;
			}
			PlayCardsWindow.lastUpdatedBPURL = DateTime.Now;
			PlayCardsWindow.bigpointURL = response.URL;
			try
			{
				if (PlayCardsWindow.bigpointURL.Length > 0)
				{
					Process.Start(PlayCardsWindow.bigpointURL);
				}
			}
			catch (Exception)
			{
				this.fireURLError();
			}
		}

		// Token: 0x06001C58 RID: 7256 RVA: 0x001BBB58 File Offset: 0x001B9D58
		public void fireURLError()
		{
			MyMessageBox.Show(string.Concat(new string[]
			{
				"Stronghold Kingdoms encountered an error when trying to ",
				Environment.NewLine,
				"open your system's Default Web Browser. Please check that ",
				Environment.NewLine,
				"your web browser is working correctly and there are no unresponsive ",
				Environment.NewLine,
				"copies showing in task manager->Processes and then try again.",
				Environment.NewLine,
				"If this problem persists, please contact support."
			}), "Error opening Web Browser");
		}

		// Token: 0x06001C59 RID: 7257 RVA: 0x0001BD4C File Offset: 0x00019F4C
		public void GetCrowns()
		{
			this.GetCrowns("");
		}

		// Token: 0x06001C5A RID: 7258 RVA: 0x001BBBC4 File Offset: 0x001B9DC4
		public void GetCrowns(string urlExtra)
		{
			PlayCardsWindow.CrownsOpened = true;
			if (Program.steamActive || Program.aeriaInstall)
			{
				this.SwitchPanel(7);
				return;
			}
			if ((DateTime.Now - PlayCardsWindow.lastCrownsOpened).TotalSeconds < 5.0)
			{
				return;
			}
			PlayCardsWindow.lastCrownsOpened = DateTime.Now;
			if (GameEngine.Instance.World.isBigpointAccount || Program.bigpointPartnerInstall)
			{
				TimeSpan timeSpan = DateTime.Now - PlayCardsWindow.lastUpdatedBPURL;
				if (PlayCardsWindow.bigpointURL != string.Empty && timeSpan.TotalMinutes < 2.0)
				{
					try
					{
						Process.Start(PlayCardsWindow.bigpointURL);
						return;
					}
					catch (Exception)
					{
						this.fireURLError();
						return;
					}
				}
				this.GetBigpointURL();
				return;
			}
			string text = string.Concat(new string[]
			{
				URLs.ProfilePaymentURL,
				"?u=",
				RemoteServices.Instance.UserGuid.ToString().Replace("-", ""),
				"&s=",
				RemoteServices.Instance.SessionGuid.ToString().Replace("-", "")
			});
			text = text + "&lang=" + Program.mySettings.LanguageIdent.ToLower();
			if (Program.arcInstall)
			{
				text = "https://billing.arcgames.com/" + Program.mySettings.languageIdent;
				Program.arc_openURL(text);
				InterfaceMgr.Instance.closePlayCardsWindow();
				TutorialPanel.minimizeTutorial();
				return;
			}
			try
			{
				if (urlExtra.Length >= 0)
				{
					text += urlExtra;
				}
				Process.Start(text);
			}
			catch (Exception)
			{
				this.fireURLError();
			}
		}

		// Token: 0x06001C5B RID: 7259 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void GetCrownsCallback(ICardsProvider provider, ICardsResponse response)
		{
		}

		// Token: 0x06001C5C RID: 7260 RVA: 0x001BBD88 File Offset: 0x001B9F88
		private void PlayCardsWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			CloseReason closeReason = e.CloseReason;
			if (closeReason == CloseReason.UserClosing && !this.closing)
			{
				this.closing = true;
				StatTrackingClient.Instance().ActivateTrigger(21, null);
				InterfaceMgr.Instance.closePlayCardsWindow();
			}
		}

		// Token: 0x06001C5D RID: 7261 RVA: 0x001BBDC8 File Offset: 0x001B9FC8
		private void tbSearchBox_TextChanged(object sender, EventArgs e)
		{
			if (this.processTextChanged && this.tbSearchBox.Visible)
			{
				try
				{
					if (this.currentPanelID == 1)
					{
						((PlayCardsPanel)this.currentPanel).handleSearchTextChanged();
					}
					if (this.currentPanelID == 6)
					{
						((ManageCardsPanel)this.currentPanel).handleSearchTextChanged();
					}
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x06001C5E RID: 7262 RVA: 0x001BBE34 File Offset: 0x001BA034
		public void performSearch()
		{
			try
			{
				if (this.currentPanelID == 1)
				{
					((PlayCardsPanel)this.currentPanel).forceSearch();
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06001C5F RID: 7263 RVA: 0x0001BD59 File Offset: 0x00019F59
		public string getNameSearchText()
		{
			if (this.tbSearchBox.Visible)
			{
				return this.tbSearchBox.Text;
			}
			return "";
		}

		// Token: 0x06001C60 RID: 7264 RVA: 0x0001BD79 File Offset: 0x00019F79
		public void reactivatePanel()
		{
			this.currentPanel.PanelActive = true;
		}

		// Token: 0x06001C61 RID: 7265 RVA: 0x0001BD87 File Offset: 0x00019F87
		public bool isCardWindowOnManage()
		{
			return this.currentPanel == this.cardPanelManage;
		}

		// Token: 0x06001C62 RID: 7266 RVA: 0x0001BD9A File Offset: 0x00019F9A
		public bool isCardWindowOnPremium()
		{
			return this.currentPanel == this.cardPanelPremium;
		}

		// Token: 0x06001C63 RID: 7267 RVA: 0x0001BDAD File Offset: 0x00019FAD
		public bool isCardWindowOnOffers()
		{
			return this.currentPanel == this.cardPanelOffers;
		}

		// Token: 0x06001C64 RID: 7268 RVA: 0x0001BDC0 File Offset: 0x00019FC0
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (Program.arcInstall && keyData == (Keys.LButton | Keys.Back | Keys.Shift))
			{
				Program.arc_forceoverlay();
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		// Token: 0x04002D22 RID: 11554
		private PlayCardsPanel cardPanelPlay;

		// Token: 0x04002D23 RID: 11555
		private BuyCardsPanel cardPanelBuy;

		// Token: 0x04002D24 RID: 11556
		public ManageCardsPanel cardPanelManage;

		// Token: 0x04002D25 RID: 11557
		private PremiumCardsPanel cardPanelPremium;

		// Token: 0x04002D26 RID: 11558
		private ViewAllCardsPanel cardPanelViewAll;

		// Token: 0x04002D27 RID: 11559
		private PremiumOffersPanel cardPanelOffers;

		// Token: 0x04002D28 RID: 11560
		private BuyCrownsPanel crownsBuyPanel;

		// Token: 0x04002D29 RID: 11561
		private int currentPanelID;

		// Token: 0x04002D2A RID: 11562
		private int currentCardSection;

		// Token: 0x04002D2B RID: 11563
		private bool processTextChanged = true;

		// Token: 0x04002D2C RID: 11564
		public static bool CrownsOpened = false;

		// Token: 0x04002D2D RID: 11565
		private static DateTime m_lastRewardCardsCall = DateTime.MinValue;

		// Token: 0x04002D2E RID: 11566
		private bool m_fromOpen;

		// Token: 0x04002D2F RID: 11567
		private static DateTime lastUpdatedBPURL = DateTime.MinValue;

		// Token: 0x04002D30 RID: 11568
		private static string bigpointURL = string.Empty;

		// Token: 0x04002D31 RID: 11569
		private static DateTime lastCrownsOpened = DateTime.MinValue;

		// Token: 0x04002D32 RID: 11570
		private bool closing;
	}
}
