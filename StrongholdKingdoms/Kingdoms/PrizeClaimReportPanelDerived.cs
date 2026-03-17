using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using Stronghold.AuthClient;

namespace Kingdoms
{
	// Token: 0x0200028E RID: 654
	internal class PrizeClaimReportPanelDerived : GenericReportPanelBasic
	{
		// Token: 0x06001D30 RID: 7472 RVA: 0x001C6928 File Offset: 0x001C4B28
		public PrizeClaimReportPanelDerived()
		{
			base.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.Size = new Size(580, 500);
		}

		// Token: 0x06001D31 RID: 7473 RVA: 0x001C6978 File Offset: 0x001C4B78
		public override void setData(GetReport_ReturnType returnData)
		{
			base.setData(returnData);
			this.m_prizeID = returnData.genericData1;
			this.m_contestID = returnData.genericData2;
			this.lblDate.Position = new Point(0, this.lblSubTitle.Rectangle.Bottom);
			this.prizeArea.Position = new Point(base.Width / 6, this.lblDate.Rectangle.Bottom);
			this.prizeArea.Size = new Size(base.Width * 2 / 3, this.btnDelete.Y - this.lblDate.Rectangle.Bottom - 10);
			if (base.hasBackground())
			{
				this.imgBackground.addControl(this.prizeArea);
			}
			else
			{
				base.addControl(this.prizeArea);
			}
			this.prizeArea.addControl(this.m_PrizeContent);
			this.lblMainText.Text = SK.Text("Reports_Prize_Claimed", "Prize Claimed");
			ContestPrizeDefinition contestPrizeDefinition = new ContestPrizeDefinition();
			contestPrizeDefinition.Content.Gold = returnData.genericData3;
			contestPrizeDefinition.Content.FaithPoints = returnData.genericData4;
			contestPrizeDefinition.Content.Honour = returnData.genericData5;
			contestPrizeDefinition.Content.RepPoints = returnData.genericData6;
			contestPrizeDefinition.Content.ShieldCharges = new List<int>();
			for (int i = 0; i < returnData.genericData7; i++)
			{
				contestPrizeDefinition.Content.ShieldCharges.Add(1);
			}
			contestPrizeDefinition.Content.WheelSpins = new List<int>();
			for (int j = 0; j < 6; j++)
			{
				contestPrizeDefinition.Content.WheelSpins.Add(0);
			}
			if (returnData.genericData8 > 0)
			{
				this.addCompoundPrize((ContestCompoundPrize)returnData.genericData8, returnData.genericData9, returnData.genericData10, ref contestPrizeDefinition.Content);
			}
			if (returnData.genericData11 > 0)
			{
				this.addCompoundPrize((ContestCompoundPrize)returnData.genericData11, returnData.genericData12, returnData.genericData13, ref contestPrizeDefinition.Content);
			}
			if (returnData.genericData14 > 0)
			{
				this.addCompoundPrize((ContestCompoundPrize)returnData.genericData14, returnData.genericData15, returnData.genericData16, ref contestPrizeDefinition.Content);
			}
			if (returnData.genericData17 > 0)
			{
				this.addCompoundPrize((ContestCompoundPrize)returnData.genericData17, returnData.genericData18, returnData.genericData19, ref contestPrizeDefinition.Content);
			}
			if (returnData.genericData20 > 0)
			{
				this.addCompoundPrize((ContestCompoundPrize)returnData.genericData20, returnData.genericData21, returnData.genericData22, ref contestPrizeDefinition.Content);
			}
			if (returnData.genericData23 > 0)
			{
				this.addCompoundPrize((ContestCompoundPrize)returnData.genericData23, returnData.genericData24, returnData.genericData25, ref contestPrizeDefinition.Content);
			}
			if (returnData.genericData26 > 0)
			{
				this.addCompoundPrize((ContestCompoundPrize)returnData.genericData26, returnData.genericData27, returnData.genericData28, ref contestPrizeDefinition.Content);
			}
			if (returnData.genericData29 > 0)
			{
				this.addCompoundPrize((ContestCompoundPrize)returnData.genericData29, returnData.genericData30, returnData.genericData31, ref contestPrizeDefinition.Content);
			}
			if (returnData.genericData32 > 0)
			{
				this.addCompoundPrize((ContestCompoundPrize)returnData.genericData32, returnData.genericData33, returnData.genericData34, ref contestPrizeDefinition.Content);
			}
			this.m_PrizeContent.init(contestPrizeDefinition, this.prizeArea, 10, 0);
			this.m_PrizeContent.Visible = (returnData.reportType == 141);
			this.m_PrizeContent.invalidate();
			this.prizeArea.invalidate();
		}

		// Token: 0x06001D32 RID: 7474 RVA: 0x001C6CCC File Offset: 0x001C4ECC
		private void addCompoundPrize(ContestCompoundPrize type, int id, int amount, ref ContestPrizeContent content)
		{
			switch (type)
			{
			case ContestCompoundPrize.CARD:
			{
				ContestPrizeCardDefinition contestPrizeCardDefinition = new ContestPrizeCardDefinition();
				contestPrizeCardDefinition.Amount = amount;
				contestPrizeCardDefinition.ID = id;
				contestPrizeCardDefinition.Name = CardTypes.getDescriptionFromCard(id);
				content.Cards.Add(contestPrizeCardDefinition);
				return;
			}
			case ContestCompoundPrize.PACK:
			{
				ContestPrizePackDefinition contestPrizePackDefinition = new ContestPrizePackDefinition();
				contestPrizePackDefinition.Amount = amount;
				contestPrizePackDefinition.OfferID = id;
				contestPrizePackDefinition.Name = GameEngine.Instance.cardPackManager.GetCardOffer(id).Name;
				content.Packs.Add(contestPrizePackDefinition);
				return;
			}
			case ContestCompoundPrize.TOKEN:
			{
				ContestPrizeTokenDefinition contestPrizeTokenDefinition = new ContestPrizeTokenDefinition();
				contestPrizeTokenDefinition.Amount = amount;
				contestPrizeTokenDefinition.TokenType = id;
				contestPrizeTokenDefinition.Name = CardTypes.GetTokenName(id);
				content.Tokens.Add(contestPrizeTokenDefinition);
				return;
			}
			case ContestCompoundPrize.SPIN:
			{
				List<int> wheelSpins = content.WheelSpins;
				wheelSpins[id] += amount;
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x06001D33 RID: 7475 RVA: 0x0001C685 File Offset: 0x0001A885
		protected override void utilityClick()
		{
			this.RetrievePrizeData();
		}

		// Token: 0x06001D34 RID: 7476 RVA: 0x001C6DAC File Offset: 0x001C4FAC
		private void RetrievePrizeData()
		{
			XmlRpcContestProvider xmlRpcContestProvider = XmlRpcContestProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressLogin, URLs.ProfileServerPort, URLs.ProfilePath);
			XmlRpcContestRequest xmlRpcContestRequest = new XmlRpcContestRequest();
			xmlRpcContestRequest.SessionID = RemoteServices.Instance.SessionGuid.ToString().Replace("-", "");
			xmlRpcContestRequest.UserGUID = RemoteServices.Instance.UserGuid.ToString().Replace("-", "");
			xmlRpcContestRequest.EventID = new int?(this.m_contestID);
			this.m_PrizeResponseDel = new PrizeClaimReportPanelDerived.ResponseDelegate(this.OnPrizeDataReceived);
			xmlRpcContestProvider.RetrieveContestMetaData(xmlRpcContestRequest, new ContestEndResponseDelegate(this.RetrievePrizeDataCallback), null);
		}

		// Token: 0x06001D35 RID: 7477 RVA: 0x001C6E6C File Offset: 0x001C506C
		private void RetrievePrizeDataCallback(IContestProvider provider, IContestResponse response)
		{
			int? successCode = response.SuccessCode;
			int num = 1;
			if (successCode.GetValueOrDefault() == num & successCode != null)
			{
				List<ContestPrizeDefinition> prizes = ((XmlRpcContestResponse)response).Prizes;
				if (prizes.Count > 0)
				{
					foreach (ContestPrizeDefinition contestPrizeDefinition in prizes)
					{
						if (contestPrizeDefinition.Content.ID == this.m_prizeID)
						{
							this.m_PrizeContent.init(contestPrizeDefinition, this.prizeArea, 5, 5);
							this.lblMainText.Text = contestPrizeDefinition.Content.Name;
							this.prizeArea.invalidate();
							break;
						}
					}
				}
			}
		}

		// Token: 0x06001D36 RID: 7478 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void OnPrizeDataReceived(bool success)
		{
		}

		// Token: 0x04002DFF RID: 11775
		private int m_prizeID;

		// Token: 0x04002E00 RID: 11776
		private int m_contestID;

		// Token: 0x04002E01 RID: 11777
		private CustomSelfDrawPanel.CSDArea prizeArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04002E02 RID: 11778
		private PrizeClaimReportPanelDerived.ResponseDelegate m_PrizeResponseDel;

		// Token: 0x04002E03 RID: 11779
		private ContestPrizeList m_PrizeContent = new ContestPrizeList();

		// Token: 0x0200028F RID: 655
		// (Invoke) Token: 0x06001D38 RID: 7480
		private delegate void ResponseDelegate(bool success);
	}
}
