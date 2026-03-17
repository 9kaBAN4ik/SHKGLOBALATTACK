namespace Kingdoms
{
	// Token: 0x020000E0 RID: 224
	public partial class BattleResultPopup : global::Kingdoms.MyFormBase
	{
		// Token: 0x06000695 RID: 1685 RVA: 0x0000B7B0 File Offset: 0x000099B0
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000696 RID: 1686 RVA: 0x0008C8BC File Offset: 0x0008AABC
		private void InitializeComponent()
		{
			this.lblVillageName = new global::System.Windows.Forms.Label();
			this.lblAttackType = new global::System.Windows.Forms.Label();
			this.btnClose = new global::Kingdoms.BitmapButton();
			this.btnMinimise = new global::Kingdoms.BitmapButton();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.lblAttackersSwordsmen = new global::System.Windows.Forms.Label();
			this.lblAttackersPikemen = new global::System.Windows.Forms.Label();
			this.lblAttackersArchers = new global::System.Windows.Forms.Label();
			this.lblAttackersPeasants = new global::System.Windows.Forms.Label();
			this.label11 = new global::System.Windows.Forms.Label();
			this.label12 = new global::System.Windows.Forms.Label();
			this.lblDefendersSwordsmen = new global::System.Windows.Forms.Label();
			this.lblDefendersPikemen = new global::System.Windows.Forms.Label();
			this.lblDefendersArchers = new global::System.Windows.Forms.Label();
			this.lblDefendersPeasants = new global::System.Windows.Forms.Label();
			this.lblDefendersCaptains = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.lblAttackersCaptains = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.lblAttackersCatapults = new global::System.Windows.Forms.Label();
			this.lblWolves = new global::System.Windows.Forms.Label();
			this.btnShowResources = new global::Kingdoms.BitmapButton();
			this.lblHonour = new global::System.Windows.Forms.Label();
			this.lblSpoils = new global::System.Windows.Forms.Label();
			this.lblTargetVillageNameAndInfo = new global::System.Windows.Forms.Label();
			this.lblDate = new global::System.Windows.Forms.Label();
			this.lblResult = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.lblVillageName.AutoSize = true;
			this.lblVillageName.BackColor = global::ARGBColors.Transparent;
			this.lblVillageName.ForeColor = global::ARGBColors.White;
			this.lblVillageName.Location = new global::System.Drawing.Point(25, 40);
			this.lblVillageName.Name = "lblVillageName";
			this.lblVillageName.Size = new global::System.Drawing.Size(this.sizeAddition + 69, 13);
			this.lblVillageName.TabIndex = 0;
			this.lblVillageName.Text = "Village Name";
			this.lblAttackType.AutoSize = true;
			this.lblAttackType.BackColor = global::ARGBColors.Transparent;
			this.lblAttackType.ForeColor = global::ARGBColors.White;
			this.lblAttackType.Location = new global::System.Drawing.Point(25, 73);
			this.lblAttackType.Name = "lblAttackType";
			this.lblAttackType.Size = new global::System.Drawing.Size(this.sizeAddition + 65, 13);
			this.lblAttackType.TabIndex = 1;
			this.lblAttackType.Text = "Attack Type";
			this.btnClose.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.btnClose.BackColor = global::ARGBColors.Transparent;
			this.btnClose.BorderColor = global::ARGBColors.DarkBlue;
			this.btnClose.BorderDrawing = true;
			this.btnClose.FocusRectangleEnabled = false;
			this.btnClose.Image = null;
			this.btnClose.ImageBorderColor = global::ARGBColors.Chocolate;
			this.btnClose.ImageBorderEnabled = true;
			this.btnClose.ImageDropShadow = true;
			this.btnClose.ImageFocused = null;
			this.btnClose.ImageInactive = null;
			this.btnClose.ImageMouseOver = null;
			this.btnClose.ImageNormal = null;
			this.btnClose.ImagePressed = null;
			this.btnClose.InnerBorderColor = global::ARGBColors.LightGray;
			this.btnClose.InnerBorderColor_Focus = global::ARGBColors.LightBlue;
			this.btnClose.InnerBorderColor_MouseOver = global::ARGBColors.Gold;
			this.btnClose.Location = new global::System.Drawing.Point(414, 459);
			this.btnClose.Name = "btnClose";
			this.btnClose.OffsetPressedContent = true;
			this.btnClose.Padding2 = 5;
			this.btnClose.Size = new global::System.Drawing.Size(75, 23);
			this.btnClose.StretchImage = false;
			this.btnClose.TabIndex = 2;
			this.btnClose.Text = "Close";
			this.btnClose.TextDropShadow = false;
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new global::System.EventHandler(this.btnClose_Click);
			this.btnMinimise.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.btnMinimise.BackColor = global::ARGBColors.Transparent;
			this.btnMinimise.BorderColor = global::ARGBColors.DarkBlue;
			this.btnMinimise.BorderDrawing = true;
			this.btnMinimise.FocusRectangleEnabled = false;
			this.btnMinimise.Image = null;
			this.btnMinimise.ImageBorderColor = global::ARGBColors.Chocolate;
			this.btnMinimise.ImageBorderEnabled = true;
			this.btnMinimise.ImageDropShadow = true;
			this.btnMinimise.ImageFocused = null;
			this.btnMinimise.ImageInactive = null;
			this.btnMinimise.ImageMouseOver = null;
			this.btnMinimise.ImageNormal = null;
			this.btnMinimise.ImagePressed = null;
			this.btnMinimise.InnerBorderColor = global::ARGBColors.LightGray;
			this.btnMinimise.InnerBorderColor_Focus = global::ARGBColors.LightBlue;
			this.btnMinimise.InnerBorderColor_MouseOver = global::ARGBColors.Gold;
			this.btnMinimise.Location = new global::System.Drawing.Point(333, 459);
			this.btnMinimise.Name = "btnMinimise";
			this.btnMinimise.OffsetPressedContent = true;
			this.btnMinimise.Padding2 = 5;
			this.btnMinimise.Size = new global::System.Drawing.Size(75, 23);
			this.btnMinimise.StretchImage = false;
			this.btnMinimise.TabIndex = 3;
			this.btnMinimise.Text = "Minimise";
			this.btnMinimise.TextDropShadow = false;
			this.btnMinimise.UseVisualStyleBackColor = false;
			this.btnMinimise.Click += new global::System.EventHandler(this.btnMinimise_Click);
			this.label1.AutoSize = true;
			this.label1.BackColor = global::ARGBColors.Transparent;
			this.label1.ForeColor = global::ARGBColors.White;
			this.label1.Location = new global::System.Drawing.Point(25, 128);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(this.sizeAddition + 51, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Peasants";
			this.label2.AutoSize = true;
			this.label2.BackColor = global::ARGBColors.Transparent;
			this.label2.ForeColor = global::ARGBColors.White;
			this.label2.Location = new global::System.Drawing.Point(25, 158);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(this.sizeAddition + 43, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Archers";
			this.label3.AutoSize = true;
			this.label3.BackColor = global::ARGBColors.Transparent;
			this.label3.ForeColor = global::ARGBColors.White;
			this.label3.Location = new global::System.Drawing.Point(25, 188);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(this.sizeAddition + 48, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Pikemen";
			this.label4.AutoSize = true;
			this.label4.BackColor = global::ARGBColors.Transparent;
			this.label4.ForeColor = global::ARGBColors.White;
			this.label4.Location = new global::System.Drawing.Point(25, 218);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(this.sizeAddition + 62, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Swordsmen";
			this.lblAttackersSwordsmen.BackColor = global::ARGBColors.Transparent;
			this.lblAttackersSwordsmen.ForeColor = global::ARGBColors.White;
			this.lblAttackersSwordsmen.Location = new global::System.Drawing.Point(135, 218);
			this.lblAttackersSwordsmen.Name = "lblAttackersSwordsmen";
			this.lblAttackersSwordsmen.Size = new global::System.Drawing.Size(this.sizeAddition + 74, 13);
			this.lblAttackersSwordsmen.TabIndex = 12;
			this.lblAttackersSwordsmen.Text = "0";
			this.lblAttackersSwordsmen.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.lblAttackersPikemen.BackColor = global::ARGBColors.Transparent;
			this.lblAttackersPikemen.ForeColor = global::ARGBColors.White;
			this.lblAttackersPikemen.Location = new global::System.Drawing.Point(135, 188);
			this.lblAttackersPikemen.Name = "lblAttackersPikemen";
			this.lblAttackersPikemen.Size = new global::System.Drawing.Size(this.sizeAddition + 74, 13);
			this.lblAttackersPikemen.TabIndex = 11;
			this.lblAttackersPikemen.Text = "0";
			this.lblAttackersPikemen.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.lblAttackersArchers.BackColor = global::ARGBColors.Transparent;
			this.lblAttackersArchers.ForeColor = global::ARGBColors.White;
			this.lblAttackersArchers.Location = new global::System.Drawing.Point(135, 158);
			this.lblAttackersArchers.Name = "lblAttackersArchers";
			this.lblAttackersArchers.Size = new global::System.Drawing.Size(this.sizeAddition + 74, 13);
			this.lblAttackersArchers.TabIndex = 10;
			this.lblAttackersArchers.Text = "0";
			this.lblAttackersArchers.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.lblAttackersPeasants.BackColor = global::ARGBColors.Transparent;
			this.lblAttackersPeasants.ForeColor = global::ARGBColors.White;
			this.lblAttackersPeasants.Location = new global::System.Drawing.Point(135, 128);
			this.lblAttackersPeasants.Name = "lblAttackersPeasants";
			this.lblAttackersPeasants.Size = new global::System.Drawing.Size(this.sizeAddition + 74, 13);
			this.lblAttackersPeasants.TabIndex = 9;
			this.lblAttackersPeasants.Text = "0";
			this.lblAttackersPeasants.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label11.AutoSize = true;
			this.label11.BackColor = global::ARGBColors.Transparent;
			this.label11.ForeColor = global::ARGBColors.White;
			this.label11.Location = new global::System.Drawing.Point(158, 103);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(this.sizeAddition + 52, 13);
			this.label11.TabIndex = 14;
			this.label11.Text = "Attackers";
			this.label12.AutoSize = true;
			this.label12.BackColor = global::ARGBColors.Transparent;
			this.label12.ForeColor = global::ARGBColors.White;
			this.label12.Location = new global::System.Drawing.Point(330, 103);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(this.sizeAddition + 56, 13);
			this.label12.TabIndex = 20;
			this.label12.Text = "Defenders";
			this.lblDefendersSwordsmen.BackColor = global::ARGBColors.Transparent;
			this.lblDefendersSwordsmen.ForeColor = global::ARGBColors.White;
			this.lblDefendersSwordsmen.Location = new global::System.Drawing.Point(307, 218);
			this.lblDefendersSwordsmen.Name = "lblDefendersSwordsmen";
			this.lblDefendersSwordsmen.Size = new global::System.Drawing.Size(this.sizeAddition + 74, 13);
			this.lblDefendersSwordsmen.TabIndex = 18;
			this.lblDefendersSwordsmen.Text = "0";
			this.lblDefendersSwordsmen.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.lblDefendersPikemen.BackColor = global::ARGBColors.Transparent;
			this.lblDefendersPikemen.ForeColor = global::ARGBColors.White;
			this.lblDefendersPikemen.Location = new global::System.Drawing.Point(307, 188);
			this.lblDefendersPikemen.Name = "lblDefendersPikemen";
			this.lblDefendersPikemen.Size = new global::System.Drawing.Size(this.sizeAddition + 74, 13);
			this.lblDefendersPikemen.TabIndex = 17;
			this.lblDefendersPikemen.Text = "0";
			this.lblDefendersPikemen.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.lblDefendersArchers.BackColor = global::ARGBColors.Transparent;
			this.lblDefendersArchers.ForeColor = global::ARGBColors.White;
			this.lblDefendersArchers.Location = new global::System.Drawing.Point(307, 158);
			this.lblDefendersArchers.Name = "lblDefendersArchers";
			this.lblDefendersArchers.Size = new global::System.Drawing.Size(this.sizeAddition + 74, 13);
			this.lblDefendersArchers.TabIndex = 16;
			this.lblDefendersArchers.Text = "0";
			this.lblDefendersArchers.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.lblDefendersPeasants.BackColor = global::ARGBColors.Transparent;
			this.lblDefendersPeasants.ForeColor = global::ARGBColors.White;
			this.lblDefendersPeasants.Location = new global::System.Drawing.Point(307, 128);
			this.lblDefendersPeasants.Name = "lblDefendersPeasants";
			this.lblDefendersPeasants.Size = new global::System.Drawing.Size(this.sizeAddition + 74, 13);
			this.lblDefendersPeasants.TabIndex = 15;
			this.lblDefendersPeasants.Text = "0";
			this.lblDefendersPeasants.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.lblDefendersCaptains.BackColor = global::ARGBColors.Transparent;
			this.lblDefendersCaptains.ForeColor = global::ARGBColors.White;
			this.lblDefendersCaptains.Location = new global::System.Drawing.Point(307, 277);
			this.lblDefendersCaptains.Name = "lblDefendersCaptains";
			this.lblDefendersCaptains.Size = new global::System.Drawing.Size(this.sizeAddition + 74, 13);
			this.lblDefendersCaptains.TabIndex = 44;
			this.lblDefendersCaptains.Text = "0";
			this.lblDefendersCaptains.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label5.AutoSize = true;
			this.label5.BackColor = global::ARGBColors.Transparent;
			this.label5.ForeColor = global::ARGBColors.White;
			this.label5.Location = new global::System.Drawing.Point(25, 277);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(this.sizeAddition + 48, 13);
			this.label5.TabIndex = 42;
			this.label5.Text = "Captains";
			this.lblAttackersCaptains.BackColor = global::ARGBColors.Transparent;
			this.lblAttackersCaptains.ForeColor = global::ARGBColors.White;
			this.lblAttackersCaptains.Location = new global::System.Drawing.Point(135, 277);
			this.lblAttackersCaptains.Name = "lblAttackersCaptains";
			this.lblAttackersCaptains.Size = new global::System.Drawing.Size(this.sizeAddition + 74, 13);
			this.lblAttackersCaptains.TabIndex = 43;
			this.lblAttackersCaptains.Text = "0";
			this.lblAttackersCaptains.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.label6.AutoSize = true;
			this.label6.BackColor = global::ARGBColors.Transparent;
			this.label6.ForeColor = global::ARGBColors.White;
			this.label6.Location = new global::System.Drawing.Point(25, 248);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(this.sizeAddition + 51, 13);
			this.label6.TabIndex = 40;
			this.label6.Text = "Catapults";
			this.lblAttackersCatapults.BackColor = global::ARGBColors.Transparent;
			this.lblAttackersCatapults.ForeColor = global::ARGBColors.White;
			this.lblAttackersCatapults.Location = new global::System.Drawing.Point(135, 248);
			this.lblAttackersCatapults.Name = "lblAttackersCatapults";
			this.lblAttackersCatapults.Size = new global::System.Drawing.Size(this.sizeAddition + 74, 13);
			this.lblAttackersCatapults.TabIndex = 41;
			this.lblAttackersCatapults.Text = "0";
			this.lblAttackersCatapults.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.lblWolves.AutoSize = true;
			this.lblWolves.BackColor = global::ARGBColors.Transparent;
			this.lblWolves.ForeColor = global::ARGBColors.White;
			this.lblWolves.Location = new global::System.Drawing.Point(266, 128);
			this.lblWolves.Name = "lblWolves";
			this.lblWolves.Size = new global::System.Drawing.Size(this.sizeAddition + 43, 13);
			this.lblWolves.TabIndex = 39;
			this.lblWolves.Text = "Wolves";
			this.lblWolves.Visible = false;
			this.btnShowResources.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.btnShowResources.BackColor = global::ARGBColors.Transparent;
			this.btnShowResources.BorderColor = global::ARGBColors.DarkBlue;
			this.btnShowResources.BorderDrawing = true;
			this.btnShowResources.FocusRectangleEnabled = false;
			this.btnShowResources.Image = null;
			this.btnShowResources.ImageBorderColor = global::ARGBColors.Chocolate;
			this.btnShowResources.ImageBorderEnabled = true;
			this.btnShowResources.ImageDropShadow = true;
			this.btnShowResources.ImageFocused = null;
			this.btnShowResources.ImageInactive = null;
			this.btnShowResources.ImageMouseOver = null;
			this.btnShowResources.ImageNormal = null;
			this.btnShowResources.ImagePressed = null;
			this.btnShowResources.InnerBorderColor = global::ARGBColors.LightGray;
			this.btnShowResources.InnerBorderColor_Focus = global::ARGBColors.LightBlue;
			this.btnShowResources.InnerBorderColor_MouseOver = global::ARGBColors.Gold;
			this.btnShowResources.Location = new global::System.Drawing.Point(333, 373);
			this.btnShowResources.Name = "btnShowResources";
			this.btnShowResources.OffsetPressedContent = true;
			this.btnShowResources.Padding2 = 5;
			this.btnShowResources.Size = new global::System.Drawing.Size(this.sizeAddition + 157, 23);
			this.btnShowResources.StretchImage = false;
			this.btnShowResources.TabIndex = 38;
			this.btnShowResources.Text = "Show Resources";
			this.btnShowResources.TextDropShadow = false;
			this.btnShowResources.UseVisualStyleBackColor = false;
			this.btnShowResources.Click += new global::System.EventHandler(this.btnShowResources_Click);
			this.lblHonour.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.lblHonour.BackColor = global::ARGBColors.Transparent;
			this.lblHonour.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblHonour.ForeColor = global::ARGBColors.White;
			this.lblHonour.Location = new global::System.Drawing.Point(18, 437);
			this.lblHonour.Name = "lblHonour";
			this.lblHonour.Size = new global::System.Drawing.Size(this.sizeAddition + 472, 20);
			this.lblHonour.TabIndex = 37;
			this.lblHonour.Text = "Honour";
			this.lblHonour.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.lblSpoils.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.lblSpoils.BackColor = global::ARGBColors.Transparent;
			this.lblSpoils.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblSpoils.ForeColor = global::ARGBColors.White;
			this.lblSpoils.Location = new global::System.Drawing.Point(18, 397);
			this.lblSpoils.Name = "lblSpoils";
			this.lblSpoils.Size = new global::System.Drawing.Size(this.sizeAddition + 472, 20);
			this.lblSpoils.TabIndex = 36;
			this.lblSpoils.Text = "Honour";
			this.lblSpoils.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.lblTargetVillageNameAndInfo.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.lblTargetVillageNameAndInfo.BackColor = global::ARGBColors.Transparent;
			this.lblTargetVillageNameAndInfo.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblTargetVillageNameAndInfo.ForeColor = global::ARGBColors.White;
			this.lblTargetVillageNameAndInfo.Location = new global::System.Drawing.Point(18, 417);
			this.lblTargetVillageNameAndInfo.Name = "lblTargetVillageNameAndInfo";
			this.lblTargetVillageNameAndInfo.Size = new global::System.Drawing.Size(this.sizeAddition + 472, 20);
			this.lblTargetVillageNameAndInfo.TabIndex = 35;
			this.lblTargetVillageNameAndInfo.Text = "Lordwibble took 0 villages";
			this.lblTargetVillageNameAndInfo.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.lblDate.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.lblDate.BackColor = global::ARGBColors.Transparent;
			this.lblDate.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblDate.ForeColor = global::ARGBColors.White;
			this.lblDate.Location = new global::System.Drawing.Point(17, 320);
			this.lblDate.Name = "lblDate";
			this.lblDate.Size = new global::System.Drawing.Size(this.sizeAddition + 472, 20);
			this.lblDate.TabIndex = 34;
			this.lblDate.Text = "06/12/2004 15:00";
			this.lblDate.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.lblResult.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.lblResult.BackColor = global::ARGBColors.Transparent;
			this.lblResult.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblResult.ForeColor = global::ARGBColors.White;
			this.lblResult.Location = new global::System.Drawing.Point(17, 349);
			this.lblResult.Name = "lblResult";
			this.lblResult.Size = new global::System.Drawing.Size(this.sizeAddition + 472, 20);
			this.lblResult.TabIndex = 33;
			this.lblResult.Text = "The Defender Won";
			this.lblResult.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::System.Drawing.Color.FromArgb(159, 180, 193);
			base.ClientSize = new global::System.Drawing.Size(this.sizeAddition + 503, 496);
			base.Controls.Add(this.lblDefendersCaptains);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.lblAttackersCaptains);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.lblAttackersCatapults);
			base.Controls.Add(this.lblWolves);
			base.Controls.Add(this.btnShowResources);
			base.Controls.Add(this.lblHonour);
			base.Controls.Add(this.lblSpoils);
			base.Controls.Add(this.lblTargetVillageNameAndInfo);
			base.Controls.Add(this.lblDate);
			base.Controls.Add(this.lblResult);
			base.Controls.Add(this.lblVillageName);
			base.Controls.Add(this.btnClose);
			base.Controls.Add(this.btnMinimise);
			base.Controls.Add(this.label12);
			base.Controls.Add(this.lblAttackType);
			base.Controls.Add(this.lblDefendersSwordsmen);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.lblDefendersPikemen);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.lblDefendersArchers);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.lblDefendersPeasants);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label11);
			base.Controls.Add(this.lblAttackersPeasants);
			base.Controls.Add(this.lblAttackersSwordsmen);
			base.Controls.Add(this.lblAttackersArchers);
			base.Controls.Add(this.lblAttackersPikemen);
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			base.Name = "BattleResultPopup";
			base.ShowClose = true;
			this.Text = "Battle Results";
			base.Load += new global::System.EventHandler(this.BattleResultPopup_Load);
			base.Controls.SetChildIndex(this.lblAttackersPikemen, 0);
			base.Controls.SetChildIndex(this.lblAttackersArchers, 0);
			base.Controls.SetChildIndex(this.lblAttackersSwordsmen, 0);
			base.Controls.SetChildIndex(this.lblAttackersPeasants, 0);
			base.Controls.SetChildIndex(this.label11, 0);
			base.Controls.SetChildIndex(this.label4, 0);
			base.Controls.SetChildIndex(this.lblDefendersPeasants, 0);
			base.Controls.SetChildIndex(this.label3, 0);
			base.Controls.SetChildIndex(this.lblDefendersArchers, 0);
			base.Controls.SetChildIndex(this.label2, 0);
			base.Controls.SetChildIndex(this.lblDefendersPikemen, 0);
			base.Controls.SetChildIndex(this.label1, 0);
			base.Controls.SetChildIndex(this.lblDefendersSwordsmen, 0);
			base.Controls.SetChildIndex(this.lblAttackType, 0);
			base.Controls.SetChildIndex(this.label12, 0);
			base.Controls.SetChildIndex(this.btnMinimise, 0);
			base.Controls.SetChildIndex(this.btnClose, 0);
			base.Controls.SetChildIndex(this.lblVillageName, 0);
			base.Controls.SetChildIndex(this.lblResult, 0);
			base.Controls.SetChildIndex(this.lblDate, 0);
			base.Controls.SetChildIndex(this.lblTargetVillageNameAndInfo, 0);
			base.Controls.SetChildIndex(this.lblSpoils, 0);
			base.Controls.SetChildIndex(this.lblHonour, 0);
			base.Controls.SetChildIndex(this.btnShowResources, 0);
			base.Controls.SetChildIndex(this.lblWolves, 0);
			base.Controls.SetChildIndex(this.lblAttackersCatapults, 0);
			base.Controls.SetChildIndex(this.label6, 0);
			base.Controls.SetChildIndex(this.lblAttackersCaptains, 0);
			base.Controls.SetChildIndex(this.label5, 0);
			base.Controls.SetChildIndex(this.lblDefendersCaptains, 0);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040008E4 RID: 2276
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040008E5 RID: 2277
		private global::System.Windows.Forms.Label lblVillageName;

		// Token: 0x040008E6 RID: 2278
		private global::System.Windows.Forms.Label lblAttackType;

		// Token: 0x040008E7 RID: 2279
		private global::Kingdoms.BitmapButton btnClose;

		// Token: 0x040008E8 RID: 2280
		private global::Kingdoms.BitmapButton btnMinimise;

		// Token: 0x040008E9 RID: 2281
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040008EA RID: 2282
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040008EB RID: 2283
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040008EC RID: 2284
		private global::System.Windows.Forms.Label label4;

		// Token: 0x040008ED RID: 2285
		private global::System.Windows.Forms.Label lblAttackersSwordsmen;

		// Token: 0x040008EE RID: 2286
		private global::System.Windows.Forms.Label lblAttackersPikemen;

		// Token: 0x040008EF RID: 2287
		private global::System.Windows.Forms.Label lblAttackersArchers;

		// Token: 0x040008F0 RID: 2288
		private global::System.Windows.Forms.Label lblAttackersPeasants;

		// Token: 0x040008F1 RID: 2289
		private global::System.Windows.Forms.Label label11;

		// Token: 0x040008F2 RID: 2290
		private global::System.Windows.Forms.Label label12;

		// Token: 0x040008F3 RID: 2291
		private global::System.Windows.Forms.Label lblDefendersSwordsmen;

		// Token: 0x040008F4 RID: 2292
		private global::System.Windows.Forms.Label lblDefendersPikemen;

		// Token: 0x040008F5 RID: 2293
		private global::System.Windows.Forms.Label lblDefendersArchers;

		// Token: 0x040008F6 RID: 2294
		private global::System.Windows.Forms.Label lblDefendersPeasants;

		// Token: 0x040008F7 RID: 2295
		private global::Kingdoms.BitmapButton btnShowResources;

		// Token: 0x040008F8 RID: 2296
		private global::System.Windows.Forms.Label lblHonour;

		// Token: 0x040008F9 RID: 2297
		private global::System.Windows.Forms.Label lblSpoils;

		// Token: 0x040008FA RID: 2298
		private global::System.Windows.Forms.Label lblTargetVillageNameAndInfo;

		// Token: 0x040008FB RID: 2299
		private global::System.Windows.Forms.Label lblDate;

		// Token: 0x040008FC RID: 2300
		private global::System.Windows.Forms.Label lblResult;

		// Token: 0x040008FD RID: 2301
		private global::System.Windows.Forms.Label lblWolves;

		// Token: 0x040008FE RID: 2302
		private global::System.Windows.Forms.Label label6;

		// Token: 0x040008FF RID: 2303
		private global::System.Windows.Forms.Label lblAttackersCatapults;

		// Token: 0x04000900 RID: 2304
		private global::System.Windows.Forms.Label lblDefendersCaptains;

		// Token: 0x04000901 RID: 2305
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000902 RID: 2306
		private global::System.Windows.Forms.Label lblAttackersCaptains;

		// Token: 0x04000903 RID: 2307
		private int sizeAddition;
	}
}
