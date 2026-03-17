using System;
using System.Collections.Generic;
using System.Drawing;
using CommonTypes;
using Stronghold.AuthClient;

namespace Kingdoms
{
	// Token: 0x02000143 RID: 323
	public class ContestPrizeList : CustomSelfDrawPanel.CSDControl
	{
		// Token: 0x06000BED RID: 3053 RVA: 0x0000EE1B File Offset: 0x0000D01B
		public void init(ContestPrizeDefinition prize, CustomSelfDrawPanel.CSDControl parentControl, int marginX, int marginY)
		{
			this.init(prize, parentControl, marginX, marginY, 0);
		}

		// Token: 0x06000BEE RID: 3054 RVA: 0x000E8660 File Offset: 0x000E6860
		public void init(ContestPrizeDefinition prize, CustomSelfDrawPanel.CSDControl parentControl, int marginX, int marginY, int header)
		{
			ContestPrizeContent content = prize.Content;
			this.clearControls();
			List<ContestPrizeCell> list = new List<ContestPrizeCell>();
			this.Size = new Size(parentControl.Width - marginX * 2, parentControl.Height - marginY * 2);
			this.Position = new Point(marginX, marginY);
			this.headerHeight = header;
			if (content.Gold > 0)
			{
				ContestPrizeCell contestPrizeCell = new ContestPrizeCell();
				contestPrizeCell.Icon.Image = GFXLibrary.prizeGold;
				contestPrizeCell.Quantity.Text = content.Gold.ToString();
				contestPrizeCell.init();
				list.Add(contestPrizeCell);
			}
			if (content.Honour > 0)
			{
				ContestPrizeCell contestPrizeCell2 = new ContestPrizeCell();
				contestPrizeCell2.Icon.Image = GFXLibrary.prizeHonour;
				contestPrizeCell2.Quantity.Text = content.Honour.ToString();
				contestPrizeCell2.init();
				list.Add(contestPrizeCell2);
			}
			if (content.FaithPoints > 0)
			{
				ContestPrizeCell contestPrizeCell3 = new ContestPrizeCell();
				contestPrizeCell3.Icon.Image = GFXLibrary.prizeFaith;
				contestPrizeCell3.Quantity.Text = content.FaithPoints.ToString();
				contestPrizeCell3.init();
				list.Add(contestPrizeCell3);
			}
			if (content.RepPoints > 0)
			{
				ContestPrizeCell contestPrizeCell4 = new ContestPrizeCell();
				contestPrizeCell4.Icon.Image = GFXLibrary.prizeReputation;
				contestPrizeCell4.Quantity.Text = content.RepPoints.ToString();
				contestPrizeCell4.init();
				list.Add(contestPrizeCell4);
			}
			foreach (ContestPrizeCardDefinition contestPrizeCardDefinition in content.Cards)
			{
				CardPrizeCell cardPrizeCell = new CardPrizeCell();
				cardPrizeCell.Icon.Image = GFXLibrary.prizeBlank;
				cardPrizeCell.init();
				cardPrizeCell.Quantity.Text = contestPrizeCardDefinition.Amount.ToString();
				cardPrizeCell.SetCardImage(contestPrizeCardDefinition);
				list.Add(cardPrizeCell);
			}
			foreach (ContestPrizeTokenDefinition contestPrizeTokenDefinition in content.Tokens)
			{
				ContestPrizeCell contestPrizeCell5 = new ContestPrizeCell();
				switch (contestPrizeTokenDefinition.TokenType)
				{
				case 4112:
					contestPrizeCell5.Icon.Image = GFXLibrary.prizePremium7;
					break;
				case 4113:
					contestPrizeCell5.Icon.Image = GFXLibrary.prizePremium2;
					break;
				case 4114:
					contestPrizeCell5.Icon.Image = GFXLibrary.prizePremium30;
					break;
				default:
					contestPrizeCell5.Icon.Image = GFXLibrary.prizePremium;
					break;
				}
				contestPrizeCell5.init();
				contestPrizeCell5.Quantity.Text = contestPrizeTokenDefinition.Amount.ToString();
				list.Add(contestPrizeCell5);
			}
			for (int i = 0; i < content.WheelSpins.Count; i++)
			{
				if (content.WheelSpins[i] > 0)
				{
					ContestPrizeCell contestPrizeCell6 = new ContestPrizeCell();
					switch (i)
					{
					case 1:
						contestPrizeCell6.Icon.Image = GFXLibrary.prizeSpin2;
						break;
					case 2:
						contestPrizeCell6.Icon.Image = GFXLibrary.prizeSpin3;
						break;
					case 3:
						contestPrizeCell6.Icon.Image = GFXLibrary.prizeSpin4;
						break;
					case 4:
						contestPrizeCell6.Icon.Image = GFXLibrary.prizeSpin5;
						break;
					default:
						contestPrizeCell6.Icon.Image = GFXLibrary.prizeSpin1;
						break;
					}
					contestPrizeCell6.init();
					contestPrizeCell6.Quantity.Text = content.WheelSpins[i].ToString();
					list.Add(contestPrizeCell6);
				}
			}
			if (content.ShieldCharges.Count > 0)
			{
				ContestPrizeCell contestPrizeCell7 = new ContestPrizeCell();
				contestPrizeCell7.Icon.Image = GFXLibrary.prizeShield;
				int num = 0;
				foreach (int num2 in content.ShieldCharges)
				{
					num += num2;
				}
				if (num > 0)
				{
					contestPrizeCell7.Quantity.Text = content.ShieldCharges.Count.ToString();
					contestPrizeCell7.init();
					list.Add(contestPrizeCell7);
				}
			}
			foreach (ContestPrizePackDefinition contestPrizePackDefinition in content.Packs)
			{
				CustomPrizeCell customPrizeCell = new CustomPrizeCell();
				CardTypes.CardOffer cardOffer = GameEngine.Instance.cardPackManager.GetCardOffer(contestPrizePackDefinition.OfferID);
				customPrizeCell.init();
				customPrizeCell.SetImage(GameEngine.Instance.cardPackManager.getCardPackOverImage(cardOffer.Category), 0.7);
				customPrizeCell.Quantity.Text = contestPrizePackDefinition.Amount.ToString();
				list.Add(customPrizeCell);
			}
			int count = list.Count;
			if (count > 0)
			{
				this.prizesScrollArea.Position = new Point(0, this.headerHeight);
				this.prizesScrollArea.Size = new Size(base.Width - 24, base.Height - marginY - this.headerHeight);
				this.prizesScrollArea.ClipRect = new Rectangle(Point.Empty, this.prizesScrollArea.Size);
				base.addControl(this.prizesScrollArea);
				this.prizesInset.Size = this.prizesScrollArea.Size;
				this.prizesInset.Create(GFXLibrary.quest_9sclice_grey_inset_top_left, GFXLibrary.quest_9sclice_grey_inset_top_mid, GFXLibrary.quest_9sclice_grey_inset_top_right, GFXLibrary.quest_9sclice_grey_inset_mid_left, GFXLibrary.quest_9sclice_grey_inset_mid_mid, GFXLibrary.quest_9sclice_grey_inset_mid_right, GFXLibrary.quest_9sclice_grey_inset_bottom_left, GFXLibrary.quest_9sclice_grey_inset_bottom_mid, GFXLibrary.quest_9sclice_grey_inset_bottom_right);
				this.prizesInset.Position = new Point(0, this.headerHeight);
				base.addControl(this.prizesInset);
				int num3 = 0;
				for (int j = 0; j < count; j++)
				{
					list[j].Width = this.prizesScrollArea.Width * 2 / 3;
					list[j].Height = this.prizesScrollArea.Width * 2 / 9;
					list[j].resize();
					list[j].Position = new Point(this.prizesScrollArea.Width / 2 - list[j].Width / 2, num3);
					this.prizesScrollArea.addControl(list[j]);
					list[j].invalidate();
					num3 += list[j].Height + 3;
				}
				if (num3 > base.Height - 3 - header)
				{
					this.prizesScrollArea.Height = num3 - 3;
					this.prizesScrollBar.Position = new Point(this.prizesScrollArea.Width - 24, this.headerHeight);
					this.prizesScrollBar.Size = new Size(24, this.prizesScrollArea.ClipRect.Height);
					base.addControl(this.prizesScrollBar);
					this.prizesScrollBar.Value = 0;
					this.prizesScrollBar.NumVisibleLines = this.prizesScrollArea.ClipRect.Height;
					this.prizesScrollBar.Max = num3 - this.prizesScrollArea.ClipRect.Height;
					this.prizesScrollBar.Create(null, null, null, GFXLibrary.brown_24wide_thumb_top, GFXLibrary.brown_24wide_thumb_middle, GFXLibrary.brown_24wide_thumb_bottom);
					this.prizesScrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.prizesScrollBarMoved));
					this.prizesScrollArea.invalidate();
					this.prizesScrollBar.invalidate();
				}
			}
		}

		// Token: 0x06000BEF RID: 3055 RVA: 0x000E8EA8 File Offset: 0x000E70A8
		private void prizesScrollBarMoved()
		{
			int value = this.prizesScrollBar.Value;
			this.prizesScrollArea.Position = new Point(this.prizesScrollArea.X, -value + this.headerHeight);
			this.prizesScrollArea.ClipRect = new Rectangle(this.prizesScrollArea.ClipRect.X, value, this.prizesScrollArea.ClipRect.Width, this.prizesScrollArea.ClipRect.Height);
			this.prizesScrollArea.invalidate();
			this.prizesScrollBar.invalidate();
			this.prizesInset.invalidate();
			base.invalidate();
		}

		// Token: 0x04000FEE RID: 4078
		private CustomSelfDrawPanel.CSDVertScrollBar prizesScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x04000FEF RID: 4079
		private CustomSelfDrawPanel.CSDArea prizesScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04000FF0 RID: 4080
		private CustomSelfDrawPanel.CSDControl prizesWheelOverlay = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x04000FF1 RID: 4081
		private CustomSelfDrawPanel.CSDExtendingPanel prizesInset = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04000FF2 RID: 4082
		private int headerHeight;
	}
}
