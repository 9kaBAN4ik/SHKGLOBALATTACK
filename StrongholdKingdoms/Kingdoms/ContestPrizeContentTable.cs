using System;
using System.Collections.Generic;
using System.Drawing;
using CommonTypes;
using Stronghold.AuthClient;

namespace Kingdoms
{
	// Token: 0x02000141 RID: 321
	public class ContestPrizeContentTable : CustomSelfDrawPanel.CSDControl
	{
		// Token: 0x06000BE7 RID: 3047 RVA: 0x0000EE08 File Offset: 0x0000D008
		public void init(ContestPrizeDefinition def, CustomSelfDrawPanel.CSDControl parentControl)
		{
			this.init(def.Content, parentControl, 30, 30);
		}

		// Token: 0x06000BE8 RID: 3048 RVA: 0x000E7B5C File Offset: 0x000E5D5C
		public void init(ContestPrizeContent content, CustomSelfDrawPanel.CSDControl parentControl, int marginX, int marginY)
		{
			this.clearControls();
			List<ContestPrizeCell> list = new List<ContestPrizeCell>();
			this.Size = new Size(parentControl.Width - marginX * 2, parentControl.Height * 3 / 4 - 50);
			this.Position = new Point(marginX, parentControl.Height / 4 + 10);
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
			if (content.Cards.Count > 0 && content.Cards[0].Amount > 0)
			{
				CardPrizeCell cardPrizeCell = new CardPrizeCell();
				cardPrizeCell.Icon.Image = GFXLibrary.prizeBlank;
				cardPrizeCell.init();
				cardPrizeCell.Quantity.Text = content.Cards[0].Amount.ToString();
				cardPrizeCell.SetCardImage(content.Cards[0]);
				list.Add(cardPrizeCell);
			}
			if (content.Tokens.Count > 0)
			{
				ContestPrizeCell contestPrizeCell5 = new ContestPrizeCell();
				contestPrizeCell5.Icon.Image = GFXLibrary.prizeTokens;
				int num = 0;
				foreach (ContestPrizeTokenDefinition contestPrizeTokenDefinition in content.Tokens)
				{
					num += contestPrizeTokenDefinition.Amount;
				}
				if (num > 0)
				{
					contestPrizeCell5.Quantity.Text = num.ToString();
					contestPrizeCell5.init();
					list.Add(contestPrizeCell5);
				}
			}
			if (content.WheelSpins.Count > 0)
			{
				ContestPrizeCell contestPrizeCell6 = new ContestPrizeCell();
				contestPrizeCell6.Icon.Image = GFXLibrary.prizeWheelspins;
				int num2 = 0;
				foreach (int num3 in content.WheelSpins)
				{
					num2 += num3;
				}
				if (num2 > 0)
				{
					contestPrizeCell6.Quantity.Text = num2.ToString();
					contestPrizeCell6.init();
					list.Add(contestPrizeCell6);
				}
			}
			if (content.ShieldCharges.Count > 0)
			{
				ContestPrizeCell contestPrizeCell7 = new ContestPrizeCell();
				contestPrizeCell7.Icon.Image = GFXLibrary.prizeShield;
				int num4 = 0;
				foreach (int num5 in content.ShieldCharges)
				{
					num4 += num5;
				}
				if (num4 > 0)
				{
					contestPrizeCell7.Quantity.Text = content.ShieldCharges.Count.ToString();
					contestPrizeCell7.init();
					list.Add(contestPrizeCell7);
				}
			}
			if (content.Packs.Count > 0)
			{
				ContestPrizeCell contestPrizeCell8 = new ContestPrizeCell();
				contestPrizeCell8.Icon.Image = GFXLibrary.prizeCardPack;
				int num6 = 0;
				foreach (ContestPrizePackDefinition contestPrizePackDefinition in content.Packs)
				{
					num6 += contestPrizePackDefinition.Amount;
				}
				if (num6 > 0)
				{
					contestPrizeCell8.Quantity.Text = num6.ToString();
					contestPrizeCell8.init();
					list.Add(contestPrizeCell8);
				}
			}
			int count = list.Count;
			int num7 = 1;
			if (count > 6)
			{
				num7 = 3;
			}
			else if (count > 3)
			{
				num7 = 2;
			}
			int[] array = new int[3];
			switch (count)
			{
			case 1:
				array[0] = 1;
				array[1] = 0;
				array[2] = 0;
				break;
			case 2:
				array[0] = 2;
				array[1] = 0;
				array[2] = 0;
				break;
			case 3:
				array[0] = 3;
				array[1] = 0;
				array[2] = 0;
				break;
			case 4:
				array[0] = 2;
				array[1] = 2;
				array[2] = 0;
				break;
			case 5:
				array[0] = 3;
				array[1] = 2;
				array[2] = 0;
				break;
			case 6:
				array[0] = 3;
				array[1] = 3;
				array[2] = 0;
				break;
			case 7:
				array[0] = 3;
				array[1] = 2;
				array[2] = 2;
				break;
			case 8:
				array[0] = 3;
				array[1] = 3;
				array[2] = 2;
				break;
			case 9:
				array[0] = 3;
				array[1] = 3;
				array[2] = 3;
				break;
			}
			int num8 = 0;
			for (int i = 0; i < num7; i++)
			{
				for (int j = 0; j < array[i]; j++)
				{
					list[num8].Width = base.Width / array[i];
					list[num8].Height = base.Height / num7;
					list[num8].Position = new Point(base.Width / array[i] * j, base.Height / num7 * i);
					list[num8].resize();
					base.addControl(list[num8]);
					list[num8].invalidate();
					num8++;
				}
			}
			base.invalidate();
		}

		// Token: 0x06000BE9 RID: 3049 RVA: 0x000E8170 File Offset: 0x000E6370
		public void init(int gold, int faith, int honour, int rep, int cardID, int cardCount, int packCount, int tokenCount, int spinCount, int shieldCount, CustomSelfDrawPanel.CSDControl parentControl)
		{
			ContestPrizeContent contestPrizeContent = new ContestPrizeContent();
			contestPrizeContent.Gold = gold;
			contestPrizeContent.FaithPoints = faith;
			contestPrizeContent.Honour = honour;
			contestPrizeContent.RepPoints = rep;
			ContestPrizeCardDefinition contestPrizeCardDefinition = new ContestPrizeCardDefinition();
			contestPrizeCardDefinition.Amount = cardCount;
			contestPrizeCardDefinition.Name = CardTypes.getDescriptionFromCard(cardID);
			contestPrizeCardDefinition.ID = cardID;
			contestPrizeContent.Cards.Add(contestPrizeCardDefinition);
			ContestPrizePackDefinition contestPrizePackDefinition = new ContestPrizePackDefinition();
			contestPrizePackDefinition.Amount = packCount;
			contestPrizeContent.Packs.Add(contestPrizePackDefinition);
			ContestPrizeTokenDefinition contestPrizeTokenDefinition = new ContestPrizeTokenDefinition();
			contestPrizeTokenDefinition.Amount = tokenCount;
			contestPrizeContent.Tokens.Add(contestPrizeTokenDefinition);
			contestPrizeContent.WheelSpins.Add(spinCount);
			contestPrizeContent.ShieldCharges.Add(shieldCount);
			this.init(contestPrizeContent, parentControl, 15, 25);
		}
	}
}
