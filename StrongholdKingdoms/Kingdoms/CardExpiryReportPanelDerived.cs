using System;
using System.Drawing;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x0200010E RID: 270
	internal class CardExpiryReportPanelDerived : GenericReportPanelBasic
	{
		// Token: 0x06000898 RID: 2200 RVA: 0x000B59E4 File Offset: 0x000B3BE4
		public override void init(IDockableControl parent, Size size, object back)
		{
			base.init(parent, size, back);
			this.btnReplay.ImageNorm = GFXLibrary.button_132_normal_gold;
			this.btnReplay.ImageOver = GFXLibrary.button_132_over_gold;
			this.btnReplay.ImageClick = GFXLibrary.button_132_in_gold;
			this.btnReplay.setSizeToImage();
			this.btnReplay.Position = new Point(base.Width / 2 - this.btnReplay.Width / 2, this.btnClose.Y);
			this.btnReplay.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.btnReplay.TextYOffset = -2;
			this.btnReplay.Text.Color = global::ARGBColors.Black;
			this.btnReplay.Enabled = true;
			this.btnReplay.Visible = false;
			this.btnReplay.Text.Text = SK.Text("Reports_Replay_Card", "Replay Card");
			this.btnReplay.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.showCardClick), "Reports_Replay_Card");
			if (base.hasBackground())
			{
				this.imgBackground.addControl(this.btnReplay);
				return;
			}
			base.addControl(this.btnReplay);
		}

		// Token: 0x06000899 RID: 2201 RVA: 0x000B5B30 File Offset: 0x000B3D30
		public override void setData(GetReport_ReturnType returnData)
		{
			base.setData(returnData);
			this.cardText = CardTypes.getDescriptionFromCard(returnData.genericData1);
			short reportType = returnData.reportType;
			if (reportType != 76)
			{
				if (reportType != 77)
				{
					if (reportType == 99)
					{
						this.lblSecondaryText.Text = this.cardText;
						this.lblSubTitle.Text = SK.Text("ReportsPanel_Card_Used", "Card Used and Expired");
					}
				}
				else
				{
					this.lblSubTitle.Text = SK.Text("Reports_Instant_Card_Played", "Instant Card Played");
					this.lblSecondaryText.Text = this.cardText;
					switch (CardTypes.getCardType(returnData.genericData1))
					{
					case 3077:
					case 3078:
					case 3079:
						this.lblFurther.Text = returnData.genericData2.ToString();
						this.imgFurther.Image = GFXLibrary.com_32_honour;
						this.setResources(-1, -1);
						break;
					case 3080:
					case 3081:
					case 3082:
					case 3083:
					case 3084:
						this.lblFurther.Text = returnData.genericData2.ToString();
						this.imgFurther.Image = GFXLibrary.com_32_money;
						this.setResources(-1, -1);
						break;
					case 3085:
					case 3086:
					case 3087:
					case 3088:
						this.setResources(13, returnData.genericData2);
						break;
					case 3089:
					case 3090:
					case 3091:
					case 3092:
						this.setResources(17, returnData.genericData2);
						break;
					case 3093:
					case 3094:
					case 3095:
					case 3096:
						this.setResources(16, returnData.genericData2);
						break;
					case 3097:
					case 3098:
					case 3099:
					case 3100:
						this.setResources(14, returnData.genericData2);
						break;
					case 3101:
					case 3102:
					case 3103:
					case 3104:
						this.setResources(15, returnData.genericData2);
						break;
					case 3105:
					case 3106:
					case 3107:
					case 3108:
						this.setResources(18, returnData.genericData2);
						break;
					case 3109:
					case 3110:
					case 3111:
					case 3112:
						this.setResources(12, returnData.genericData2);
						break;
					case 3113:
					case 3114:
					case 3115:
					case 3116:
						this.setResources(6, returnData.genericData2);
						break;
					case 3117:
					case 3118:
					case 3119:
					case 3120:
						this.setResources(7, returnData.genericData2);
						break;
					case 3121:
					case 3122:
					case 3123:
					case 3124:
						this.setResources(8, returnData.genericData2);
						break;
					case 3125:
					case 3126:
					case 3127:
					case 3128:
						this.setResources(9, returnData.genericData2);
						break;
					case 3129:
					case 3130:
					case 3131:
					case 3132:
						this.setResources(22, returnData.genericData2);
						break;
					case 3133:
					case 3134:
					case 3135:
					case 3136:
						this.setResources(21, returnData.genericData2);
						break;
					case 3137:
					case 3138:
					case 3139:
					case 3140:
						this.setResources(26, returnData.genericData2);
						break;
					case 3141:
					case 3142:
					case 3143:
					case 3144:
						this.setResources(19, returnData.genericData2);
						break;
					case 3145:
					case 3146:
					case 3147:
					case 3148:
						this.setResources(33, returnData.genericData2);
						break;
					case 3149:
					case 3150:
					case 3151:
					case 3152:
						this.setResources(23, returnData.genericData2);
						break;
					case 3153:
					case 3154:
					case 3155:
					case 3156:
						this.setResources(24, returnData.genericData2);
						break;
					case 3157:
					case 3158:
					case 3159:
					case 3160:
						this.setResources(25, returnData.genericData2);
						break;
					case 3161:
					case 3162:
					case 3163:
					case 3164:
						this.setResources(29, returnData.genericData2);
						break;
					case 3165:
					case 3166:
					case 3167:
					case 3168:
						this.setResources(28, returnData.genericData2);
						break;
					case 3169:
					case 3170:
					case 3171:
					case 3172:
						this.setResources(31, returnData.genericData2);
						break;
					case 3173:
					case 3174:
					case 3175:
					case 3176:
						this.setResources(30, returnData.genericData2);
						break;
					case 3177:
					case 3178:
					case 3179:
					case 3180:
						this.setResources(32, returnData.genericData2);
						break;
					case 3264:
					case 3265:
					case 3266:
					case 3267:
						this.lblFurther.Text = returnData.genericData2.ToString();
						this.imgFurther.Image = GFXLibrary.r_building_miltary_peasent;
						this.setResources(-1, -1);
						break;
					case 3268:
					case 3269:
					case 3270:
					case 3271:
						this.lblFurther.Text = returnData.genericData2.ToString();
						this.imgFurther.Image = GFXLibrary.r_building_miltary_archer;
						this.setResources(-1, -1);
						break;
					case 3272:
					case 3273:
					case 3274:
					case 3275:
						this.lblFurther.Text = returnData.genericData2.ToString();
						this.imgFurther.Image = GFXLibrary.r_building_miltary_pikemen;
						this.setResources(-1, -1);
						break;
					case 3276:
					case 3277:
					case 3278:
					case 3279:
						this.lblFurther.Text = returnData.genericData2.ToString();
						this.imgFurther.Image = GFXLibrary.r_building_miltary_swordsman;
						this.setResources(-1, -1);
						break;
					case 3280:
					case 3281:
					case 3282:
					case 3283:
						this.lblFurther.Text = returnData.genericData2.ToString();
						this.imgFurther.Image = GFXLibrary.r_building_miltary_catapult;
						this.setResources(-1, -1);
						break;
					case 3287:
					case 3288:
					case 3289:
						this.lblFurther.Text = returnData.genericData2.ToString();
						this.imgFurther.Image = GFXLibrary.r_building_miltary_scout;
						this.setResources(-1, -1);
						break;
					case 3290:
					case 3291:
					case 3292:
						this.lblFurther.Text = returnData.genericData2.ToString();
						this.imgFurther.Image = GFXLibrary.monk_icon;
						this.setResources(-1, -1);
						break;
					case 3293:
					case 3294:
					case 3295:
						this.lblFurther.Text = returnData.genericData2.ToString();
						this.imgFurther.Image = GFXLibrary.merchant_icon;
						this.setResources(-1, -1);
						break;
					}
				}
			}
			else
			{
				this.lblSecondaryText.Text = this.cardText;
				this.lblSubTitle.Text = SK.Text("Reports_Card_Expires", "Card Expires");
			}
			CardTypes.CardDefinition cardDefinition = new CardTypes.CardDefinition();
			cardDefinition.cardCategory = CardTypes.getCardCategory(returnData.genericData1);
			GameEngine.Instance.cardsManager.searchProfileCards(cardDefinition, "meta", this.cardText);
			foreach (int key in GameEngine.Instance.cardsManager.ProfileCardsSearch)
			{
				if (GameEngine.Instance.cardsManager.ProfileCards[key].id == CardTypes.getCardType(returnData.genericData1))
				{
					this.btnReplay.Visible = true;
					break;
				}
			}
			this.btnUtility.Text.Text = SK.Text("GENERIC_Cards", "Cards");
			this.btnUtility.Visible = true;
		}

		// Token: 0x0600089A RID: 2202 RVA: 0x000B644C File Offset: 0x000B464C
		public void setResources(int resourceType, int amount)
		{
			if (resourceType != -1)
			{
				this.lblFurther.Text = amount.ToString();
				this.imgFurther.Image = GFXLibrary.getCommodity32Image(resourceType);
			}
			this.lblDate.Y = this.lblDate.Position.Y - 20;
			this.imgFurther.setSizeToImage();
			this.imgFurther.Position = new Point(base.Width / 2 - this.imgFurther.Width, this.btnDelete.Rectangle.Bottom - 80);
			this.lblFurther.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.lblFurther.Size = new Size(base.Width, Math.Max(this.imgFurther.Height, 30));
			this.lblFurther.Position = new Point(this.imgFurther.Rectangle.Right + 10, this.imgFurther.Position.Y);
			base.showFurtherInfo();
		}

		// Token: 0x0600089B RID: 2203 RVA: 0x0000D0C9 File Offset: 0x0000B2C9
		protected override void utilityClick()
		{
			GameEngine.Instance.playInterfaceSound("CardExpiryReportPanel_cards");
			InterfaceMgr.Instance.openPlayCardsWindow(0);
			this.m_parent.closeControl(true);
			InterfaceMgr.Instance.reactiveMainWindow();
		}

		// Token: 0x0600089C RID: 2204 RVA: 0x0000D0FC File Offset: 0x0000B2FC
		private void showCardClick()
		{
			GameEngine.Instance.playInterfaceSound("CardExpiryReportPanel_cards");
			InterfaceMgr.Instance.openPlayCardsWindowSearch(0, this.cardText);
			this.m_parent.closeControl(true);
			InterfaceMgr.Instance.reactiveMainWindow();
		}

		// Token: 0x04000C2F RID: 3119
		private CustomSelfDrawPanel.CSDButton btnReplay = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000C30 RID: 3120
		private string cardText = "";
	}
}
