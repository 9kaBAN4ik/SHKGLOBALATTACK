using System;
using System.Drawing;
using CommonTypes;
using Stronghold.AuthClient;

namespace Kingdoms
{
	// Token: 0x02000142 RID: 322
	public class ContestPrizeLine : CustomSelfDrawPanel.CSDControl
	{
		// Token: 0x06000BEB RID: 3051 RVA: 0x000E822C File Offset: 0x000E642C
		public void init(ContestPrizeDefinition def, CustomSelfDrawPanel.CSDControl parentControl, ContestsPanel parentPanel)
		{
			this.clearControls();
			this.Size = new Size(parentControl.Width - 4, parentControl.Height / 3 - 2);
			this.backgroundInset.Size = new Size(parentControl.Width - 4, parentControl.Height / 3 - 2);
			this.backgroundInset.Position = new Point(0, 0);
			this.backgroundInset.Create(GFXLibrary.quest_9sclice_grey_inset_top_left, GFXLibrary.quest_9sclice_grey_inset_top_mid, GFXLibrary.quest_9sclice_grey_inset_top_right, GFXLibrary.quest_9sclice_grey_inset_mid_left, GFXLibrary.quest_9sclice_grey_inset_mid_mid, GFXLibrary.quest_9sclice_grey_inset_mid_right, GFXLibrary.quest_9sclice_grey_inset_bottom_left, GFXLibrary.quest_9sclice_grey_inset_bottom_mid, GFXLibrary.quest_9sclice_grey_inset_bottom_right);
			int tier = def.Tier;
			if (tier != 1)
			{
				if (tier != 2)
				{
					this.titleLabel.Text = SK.Text("GENERIC_Gold", "Gold");
				}
				else
				{
					this.titleLabel.Text = SK.Text("GENERIC_Bronze", "Bronze");
				}
			}
			else
			{
				this.titleLabel.Text = SK.Text("GENERIC_Silver", "Silver");
			}
			this.titleLabel.Color = global::ARGBColors.Black;
			this.titleLabel.Position = new Point(base.Width / 5, 3);
			this.titleLabel.Size = new Size(base.Width * 4 / 5, this.backgroundInset.Height / 2);
			this.titleLabel.Font = FontManager.GetFont("Arial", 16f, FontStyle.Bold);
			this.titleLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			base.addControl(this.titleLabel);
			this.rewardPositionsHeaderLabel.Text = "";
			if (def.TierWidth > 0)
			{
				this.rewardPositionsHeaderLabel.Text = SK.Text("Event_Prize_Positions", "Positions") + " ";
				CustomSelfDrawPanel.CSDLabel csdlabel = this.rewardPositionsHeaderLabel;
				csdlabel.Text = csdlabel.Text + def.MaxPosition.ToString() + " - " + def.MinPosition.ToString();
			}
			if (def.QualifyingScore > 0)
			{
				this.rewardPositionsHeaderLabel.Text = SK.Text("Event_Required_Score", "Score required") + " ";
				CustomSelfDrawPanel.CSDLabel csdlabel2 = this.rewardPositionsHeaderLabel;
				csdlabel2.Text += def.QualifyingScore.ToString();
			}
			this.rewardPositionsHeaderLabel.Color = global::ARGBColors.Black;
			this.rewardPositionsHeaderLabel.Position = new Point(base.Width / 5, this.backgroundInset.Height / 2);
			this.rewardPositionsHeaderLabel.Size = new Size(base.Width * 4 / 5, this.backgroundInset.Height / 2);
			this.rewardPositionsHeaderLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.rewardPositionsHeaderLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			base.addControl(this.rewardPositionsHeaderLabel);
			this.infoButton.ImageNorm = GFXLibrary.help_normal;
			this.infoButton.ImageOver = GFXLibrary.help_over;
			this.infoButton.ImageClick = GFXLibrary.help_pushed;
			this.infoButton.setSizeToImage();
			this.infoButton.Position = new Point(this.backgroundInset.Width / 5 - this.infoButton.Width - 3, this.titleLabel.Y + this.titleLabel.Height / 2 - this.infoButton.Height / 2);
			this.infoButton.Data = def.Content.ID;
			this.infoButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(parentPanel.OnPrizeInfoClicked));
			base.addControl(this.infoButton);
		}

		// Token: 0x04000FE7 RID: 4071
		private CustomSelfDrawPanel.CSDLabel titleLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000FE8 RID: 4072
		private CustomSelfDrawPanel.CSDLabel rewardPositionsHeaderLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000FE9 RID: 4073
		private CustomSelfDrawPanel.CSDLabel rewardPositionsValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000FEA RID: 4074
		private CustomSelfDrawPanel.CSDLabel ranksNeededLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000FEB RID: 4075
		private CustomSelfDrawPanel.CSDLabel ranksNeededValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000FEC RID: 4076
		private CustomSelfDrawPanel.CSDButton infoButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000FED RID: 4077
		private CustomSelfDrawPanel.CSDExtendingPanel backgroundInset = new CustomSelfDrawPanel.CSDExtendingPanel();
	}
}
