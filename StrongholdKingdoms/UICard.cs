using System;
using System.Collections.Generic;
using System.Drawing;
using CommonTypes;
using DXGraphics;
using Kingdoms;

// Token: 0x02000004 RID: 4
public class UICard : CustomSelfDrawPanel.CSDControl
{
	// Token: 0x06000009 RID: 9 RVA: 0x00007D12 File Offset: 0x00005F12
	public UICard()
	{
		base.setMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.MouseOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.MouseOut));
		this.ClipVisible = true;
	}

	// Token: 0x0600000A RID: 10 RVA: 0x00007D51 File Offset: 0x00005F51
	public void MouseOver()
	{
		if (this.bigFrameImage != null && this.bigFrame != null && this.bigFrameOver != null)
		{
			this.bigFrameImage.Image = this.bigFrameOver;
		}
	}

	// Token: 0x0600000B RID: 11 RVA: 0x00007D81 File Offset: 0x00005F81
	public void MouseOut()
	{
		if (this.bigFrameImage != null && this.bigFrame != null && this.bigFrameOver != null)
		{
			this.bigFrameImage.Image = this.bigFrame;
		}
	}

	// Token: 0x0600000C RID: 12 RVA: 0x00026B5C File Offset: 0x00024D5C
	public void Hilight(Color c)
	{
		if (this.bigBaseImage != null)
		{
			this.bigBaseImage.Colorise = c;
		}
		if (this.bigFrameImage != null)
		{
			this.bigFrameImage.Colorise = c;
		}
		if (this.bigFrameExtraImage != null)
		{
			this.bigFrameExtraImage.Colorise = c;
		}
		base.invalidate();
	}

	// Token: 0x0600000D RID: 13 RVA: 0x00026BAC File Offset: 0x00024DAC
	public void ScaleAll(double factor)
	{
		this.Size = new Size(Convert.ToInt32(Math.Floor((double)this.bigFrame.Width * factor)), Convert.ToInt32(Math.Floor((double)this.bigFrame.Height * factor)));
		this.bigBaseImage.Scale = factor;
		this.bigFrameImage.Scale = factor;
		this.bigGradeImage.Scale = factor;
		this.bigEffect.Scale = factor;
		this.bigTitle.Scale = factor;
		this.rankLabel.Scale = factor;
		this.countLabel.Scale = factor;
		if (this.bigFrameExtraImage != null)
		{
			this.bigFrameExtraImage.Scale = factor;
		}
	}

	// Token: 0x0600000E RID: 14 RVA: 0x00007DB1 File Offset: 0x00005FB1
	public void setAlpha(float factor)
	{
		this.bigBaseImage.Alpha = factor;
	}

	// Token: 0x0600000F RID: 15 RVA: 0x00026C5C File Offset: 0x00024E5C
	public void setProgress(double secondspassed)
	{
		this.RemainingTime -= secondspassed;
		double num = this.RemainingTime / this.TotalTime;
		int width = Convert.ToInt32(Math.Floor(num * (double)this.progressBar.ClipRect.Width));
		this.progressBar.ClipRect = new Rectangle(0, 0, width, this.progressBar.ClipRect.Height);
	}

	// Token: 0x06000010 RID: 16 RVA: 0x00007DBF File Offset: 0x00005FBF
	public override void clearControls()
	{
		base.clearControls();
		this.bigFrame = null;
		this.bigFrameImage = null;
		this.bigFrameOver = null;
	}

	// Token: 0x04000035 RID: 53
	public CustomSelfDrawPanel.CSDImage bigBaseImage;

	// Token: 0x04000036 RID: 54
	public CustomSelfDrawPanel.CSDImage bigFrameImage;

	// Token: 0x04000037 RID: 55
	public CustomSelfDrawPanel.CSDImage bigFrameExtraImage;

	// Token: 0x04000038 RID: 56
	public CustomSelfDrawPanel.CSDImage bigGradeImage;

	// Token: 0x04000039 RID: 57
	public CustomSelfDrawPanel.CSDLabel bigEffect;

	// Token: 0x0400003A RID: 58
	public CustomSelfDrawPanel.CSDLabel bigTitle;

	// Token: 0x0400003B RID: 59
	public CustomSelfDrawPanel.CSDLabel rankLabel;

	// Token: 0x0400003C RID: 60
	public CustomSelfDrawPanel.CSDLabel buyCardsLabel;

	// Token: 0x0400003D RID: 61
	public int cardCount = 1;

	// Token: 0x0400003E RID: 62
	public int SearchIndex;

	// Token: 0x0400003F RID: 63
	public int SetIndex;

	// Token: 0x04000040 RID: 64
	public int UserID;

	// Token: 0x04000041 RID: 65
	public List<int> UserIDList = new List<int>();

	// Token: 0x04000042 RID: 66
	public CardTypes.CardDefinition Definition;

	// Token: 0x04000043 RID: 67
	public BaseImage bigImage;

	// Token: 0x04000044 RID: 68
	public BaseImage bigFrame;

	// Token: 0x04000045 RID: 69
	public BaseImage bigFrameOver;

	// Token: 0x04000046 RID: 70
	public CustomSelfDrawPanel.CSDImage smallBase;

	// Token: 0x04000047 RID: 71
	public CustomSelfDrawPanel.CSDImage smallFrame;

	// Token: 0x04000048 RID: 72
	public CustomSelfDrawPanel.CSDLabel countLabel;

	// Token: 0x04000049 RID: 73
	public CustomSelfDrawPanel.CSDImage progressBar;

	// Token: 0x0400004A RID: 74
	public double TotalTime;

	// Token: 0x0400004B RID: 75
	public double RemainingTime;

	// Token: 0x0400004C RID: 76
	public static UICard.CardsNameComparer cardsNameComparer = new UICard.CardsNameComparer();

	// Token: 0x0400004D RID: 77
	public static UICard.TUTCardsNameComparer TUTcardsNameComparer = new UICard.TUTCardsNameComparer();

	// Token: 0x0400004E RID: 78
	public static UICard.TUT2CardsNameComparer TUT2cardsNameComparer = new UICard.TUT2CardsNameComparer();

	// Token: 0x0400004F RID: 79
	public static UICard.CardsNameComparerReverse cardsNameComparerReverse = new UICard.CardsNameComparerReverse();

	// Token: 0x04000050 RID: 80
	public static UICard.CardsIDComparer cardsIDComparer = new UICard.CardsIDComparer();

	// Token: 0x04000051 RID: 81
	public static UICard.CardsIDComparerReverse cardsIDComparerReverse = new UICard.CardsIDComparerReverse();

	// Token: 0x04000052 RID: 82
	public static UICard.CardsQuantityComparer cardsQuantityComparer = new UICard.CardsQuantityComparer();

	// Token: 0x04000053 RID: 83
	public static UICard.CardsQuantityComparerReverse cardsQuantityComparerReverse = new UICard.CardsQuantityComparerReverse();

	// Token: 0x04000054 RID: 84
	public static UICard.CardsPriceComparer cardsPriceComparer = new UICard.CardsPriceComparer();

	// Token: 0x04000055 RID: 85
	public static UICard.CardsPriceComparerReverse cardsPriceComparerReverse = new UICard.CardsPriceComparerReverse();

	// Token: 0x02000005 RID: 5
	public class CardsNameComparer : IComparer<UICard>
	{
		// Token: 0x06000012 RID: 18 RVA: 0x00026D40 File Offset: 0x00024F40
		public int Compare(UICard x, UICard y)
		{
			if (x == null || x.Definition == null)
			{
				if (y == null || y.Definition == null)
				{
					return 0;
				}
				return -1;
			}
			else
			{
				if (y == null || y.Definition == null)
				{
					return 1;
				}
				string text = CardTypes.getDescriptionFromCard(x.Definition.id).ToLower();
				string strB = CardTypes.getDescriptionFromCard(y.Definition.id).ToLower();
				return text.CompareTo(strB);
			}
		}
	}

	// Token: 0x02000006 RID: 6
	public class TUTCardsNameComparer : IComparer<UICard>
	{
		// Token: 0x06000014 RID: 20 RVA: 0x00026DA8 File Offset: 0x00024FA8
		public int Compare(UICard x, UICard y)
		{
			if (x == null || x.Definition == null)
			{
				if (y == null || y.Definition == null)
				{
					return 0;
				}
				return -1;
			}
			else
			{
				if (y == null || y.Definition == null)
				{
					return 1;
				}
				string text = CardTypes.getDescriptionFromCard(x.Definition.id).ToLower();
				string strB = CardTypes.getDescriptionFromCard(y.Definition.id).ToLower();
				if (CardTypes.getCardType(x.Definition.id) == 3201)
				{
					text = "00000";
				}
				if (CardTypes.getCardType(y.Definition.id) == 3201)
				{
					strB = "00000";
				}
				return text.CompareTo(strB);
			}
		}
	}

	// Token: 0x02000007 RID: 7
	public class TUT2CardsNameComparer : IComparer<UICard>
	{
		// Token: 0x06000016 RID: 22 RVA: 0x00026E4C File Offset: 0x0002504C
		public int Compare(UICard x, UICard y)
		{
			if (x == null || x.Definition == null)
			{
				if (y == null || y.Definition == null)
				{
					return 0;
				}
				return -1;
			}
			else
			{
				if (y == null || y.Definition == null)
				{
					return 1;
				}
				string text = CardTypes.getDescriptionFromCard(x.Definition.id).ToLower();
				string strB = CardTypes.getDescriptionFromCard(y.Definition.id).ToLower();
				if (CardTypes.getCardType(x.Definition.id) == 769)
				{
					text = "00000";
				}
				if (CardTypes.getCardType(y.Definition.id) == 769)
				{
					strB = "00000";
				}
				return text.CompareTo(strB);
			}
		}
	}

	// Token: 0x02000008 RID: 8
	public class CardsNameComparerReverse : IComparer<UICard>
	{
		// Token: 0x06000018 RID: 24 RVA: 0x00026EF0 File Offset: 0x000250F0
		public int Compare(UICard y, UICard x)
		{
			if (x == null || x.Definition == null)
			{
				if (y == null || y.Definition == null)
				{
					return 0;
				}
				return -1;
			}
			else
			{
				if (y == null || y.Definition == null)
				{
					return 1;
				}
				string text = CardTypes.getDescriptionFromCard(x.Definition.id).ToLower();
				string strB = CardTypes.getDescriptionFromCard(y.Definition.id).ToLower();
				return text.CompareTo(strB);
			}
		}
	}

	// Token: 0x02000009 RID: 9
	public class CardsIDComparer : IComparer<UICard>
	{
		// Token: 0x0600001A RID: 26 RVA: 0x00026F58 File Offset: 0x00025158
		public int Compare(UICard x, UICard y)
		{
			if (x == null || x.Definition == null)
			{
				if (y == null || y.Definition == null)
				{
					return 0;
				}
				return -1;
			}
			else
			{
				if (y == null || y.Definition == null)
				{
					return 1;
				}
				int id = x.Definition.id;
				int id2 = y.Definition.id;
				int num = CardTypes.getCardType(id);
				int num2 = CardTypes.getCardType(id2);
				if (num <= 272)
				{
					num += 2656;
				}
				if (num2 <= 272)
				{
					num2 += 2656;
				}
				if (num < num2)
				{
					return -1;
				}
				if (num > num2)
				{
					return 1;
				}
				if (id < id2)
				{
					return -1;
				}
				if (id > id2)
				{
					return 1;
				}
				return 0;
			}
		}
	}

	// Token: 0x0200000A RID: 10
	public class CardsIDComparerReverse : IComparer<UICard>
	{
		// Token: 0x0600001C RID: 28 RVA: 0x00026FEC File Offset: 0x000251EC
		public int Compare(UICard y, UICard x)
		{
			if (x == null || x.Definition == null)
			{
				if (y == null || y.Definition == null)
				{
					return 0;
				}
				return -1;
			}
			else
			{
				if (y == null || y.Definition == null)
				{
					return 1;
				}
				int id = x.Definition.id;
				int id2 = y.Definition.id;
				int num = CardTypes.getCardType(id);
				int num2 = CardTypes.getCardType(id2);
				if (num <= 272)
				{
					num += 2656;
				}
				if (num2 <= 272)
				{
					num2 += 2656;
				}
				if (num < num2)
				{
					return -1;
				}
				if (num > num2)
				{
					return 1;
				}
				if (id < id2)
				{
					return -1;
				}
				if (id > id2)
				{
					return 1;
				}
				return 0;
			}
		}
	}

	// Token: 0x0200000B RID: 11
	public class CardsQuantityComparer : IComparer<UICard>
	{
		// Token: 0x0600001E RID: 30 RVA: 0x00027080 File Offset: 0x00025280
		public int Compare(UICard x, UICard y)
		{
			if (x == null || x.Definition == null)
			{
				if (y == null || y.Definition == null)
				{
					return 0;
				}
				return -1;
			}
			else
			{
				if (y == null || y.Definition == null)
				{
					return 1;
				}
				if (x.cardCount > y.cardCount)
				{
					return -1;
				}
				if (x.cardCount < y.cardCount)
				{
					return 0;
				}
				int id = x.Definition.id;
				int id2 = y.Definition.id;
				int num = CardTypes.getCardType(id);
				int num2 = CardTypes.getCardType(id2);
				if (num <= 272)
				{
					num += 2656;
				}
				if (num2 <= 272)
				{
					num2 += 2656;
				}
				if (num < num2)
				{
					return -1;
				}
				if (num > num2)
				{
					return 1;
				}
				if (id < id2)
				{
					return -1;
				}
				if (id > id2)
				{
					return 1;
				}
				return 0;
			}
		}
	}

	// Token: 0x0200000C RID: 12
	public class CardsQuantityComparerReverse : IComparer<UICard>
	{
		// Token: 0x06000020 RID: 32 RVA: 0x00027134 File Offset: 0x00025334
		public int Compare(UICard y, UICard x)
		{
			if (x == null || x.Definition == null)
			{
				if (y == null || y.Definition == null)
				{
					return 0;
				}
				return -1;
			}
			else
			{
				if (y == null || y.Definition == null)
				{
					return 1;
				}
				if (x.cardCount > y.cardCount)
				{
					return -1;
				}
				if (x.cardCount < y.cardCount)
				{
					return 0;
				}
				int id = x.Definition.id;
				int id2 = y.Definition.id;
				int num = CardTypes.getCardType(id);
				int num2 = CardTypes.getCardType(id2);
				if (num <= 272)
				{
					num += 2656;
				}
				if (num2 <= 272)
				{
					num2 += 2656;
				}
				if (num < num2)
				{
					return -1;
				}
				if (num > num2)
				{
					return 1;
				}
				if (id < id2)
				{
					return -1;
				}
				if (id > id2)
				{
					return 1;
				}
				return 0;
			}
		}
	}

	// Token: 0x0200000D RID: 13
	public class CardsPriceComparer : IComparer<UICard>
	{
		// Token: 0x06000022 RID: 34 RVA: 0x000271E8 File Offset: 0x000253E8
		public int Compare(UICard x, UICard y)
		{
			if (x == null || x.Definition == null)
			{
				if (y == null || y.Definition == null)
				{
					return 0;
				}
				return -1;
			}
			else
			{
				if (y == null || y.Definition == null)
				{
					return 1;
				}
				if (x.Definition.cardPoints > y.Definition.cardPoints)
				{
					return -1;
				}
				if (x.Definition.cardPoints < y.Definition.cardPoints)
				{
					return 0;
				}
				int id = x.Definition.id;
				int id2 = y.Definition.id;
				int num = CardTypes.getCardType(id);
				int num2 = CardTypes.getCardType(id2);
				if (num <= 272)
				{
					num += 2656;
				}
				if (num2 <= 272)
				{
					num2 += 2656;
				}
				if (num < num2)
				{
					return -1;
				}
				if (num > num2)
				{
					return 1;
				}
				if (id < id2)
				{
					return -1;
				}
				if (id > id2)
				{
					return 1;
				}
				return 0;
			}
		}
	}

	// Token: 0x0200000E RID: 14
	public class CardsPriceComparerReverse : IComparer<UICard>
	{
		// Token: 0x06000024 RID: 36 RVA: 0x000272B0 File Offset: 0x000254B0
		public int Compare(UICard y, UICard x)
		{
			if (x == null || x.Definition == null)
			{
				if (y == null || y.Definition == null)
				{
					return 0;
				}
				return -1;
			}
			else
			{
				if (y == null || y.Definition == null)
				{
					return 1;
				}
				if (x.Definition.cardPoints > y.Definition.cardPoints)
				{
					return -1;
				}
				if (x.Definition.cardPoints < y.Definition.cardPoints)
				{
					return 0;
				}
				int id = x.Definition.id;
				int id2 = y.Definition.id;
				int num = CardTypes.getCardType(id);
				int num2 = CardTypes.getCardType(id2);
				if (num <= 272)
				{
					num += 2656;
				}
				if (num2 <= 272)
				{
					num2 += 2656;
				}
				if (num < num2)
				{
					return -1;
				}
				if (num > num2)
				{
					return 1;
				}
				if (id < id2)
				{
					return -1;
				}
				if (id > id2)
				{
					return 1;
				}
				return 0;
			}
		}
	}
}
