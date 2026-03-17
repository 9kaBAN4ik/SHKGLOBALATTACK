using System;
using System.Drawing;

namespace Kingdoms
{
	// Token: 0x02000275 RID: 629
	internal class PlaybackBarGDI : CustomSelfDrawPanel.CSDControl
	{
		// Token: 0x06001C01 RID: 7169 RVA: 0x001B3B84 File Offset: 0x001B1D84
		public void init()
		{
			this.clearControls();
			this.Size = new Size(500, 100);
			this.trackLength = 4 * base.Width / 5;
			this.background.Image = GFXLibrary.playbackBackground;
			this.background.Position = new Point(0, base.Height / 2);
			this.background.Data = 0;
			this.background.Visible = true;
			this.background.Enabled = true;
			this.background.Alpha = 0.5f;
			this.background.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickBackground));
			base.addControl(this.background);
			this.playStop.Image = GFXLibrary.playbackStop;
			this.playStop.Position = new Point(base.Width / 10 - this.playStop.Image.Width / 2, this.background.Image.Size.Height / 2 - this.playStop.Image.Height / 2);
			this.playStop.Data = 0;
			this.playStop.Visible = true;
			this.playStop.Enabled = true;
			this.playStop.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickStop));
			this.playStop.CustomTooltipID = 22000;
			this.background.addControl(this.playStop);
			this.playPause.Image = GFXLibrary.playbackPause;
			this.playPause.Position = new Point(base.Width * 2 / 10 - this.playPause.Image.Width / 2, this.background.Image.Height / 2 - this.playPause.Image.Height / 2);
			this.playPause.Data = 0;
			this.playPause.Visible = true;
			this.playPause.Enabled = true;
			this.playPause.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickTogglePause));
			this.playPause.CustomTooltipID = 22001;
			this.background.addControl(this.playPause);
			this.playSpeed1.Image = GFXLibrary.playbackSpeed1;
			this.playSpeed1.Position = new Point(base.Width * 3 / 10 - this.playSpeed1.Image.Width / 2, this.background.Image.Height / 2 - this.playSpeed1.Image.Height / 2);
			this.playSpeed1.Data = 0;
			this.playSpeed1.Visible = true;
			this.playSpeed1.Enabled = true;
			this.playSpeed1.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickNormalSpeed));
			this.playSpeed1.CustomTooltipID = 22003;
			this.playSpeed1.Colorise = global::ARGBColors.White;
			this.background.addControl(this.playSpeed1);
			this.playSpeed2.Image = GFXLibrary.playbackSpeed2;
			this.playSpeed2.Position = new Point(base.Width * 4 / 10 - this.playSpeed2.Image.Width / 2, this.background.Image.Height / 2 - this.playSpeed2.Image.Height / 2);
			this.playSpeed2.Data = 0;
			this.playSpeed2.Visible = true;
			this.playSpeed2.Enabled = true;
			this.playSpeed2.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickDoubleSpeed));
			this.playSpeed2.CustomTooltipID = 22004;
			this.playSpeed2.Colorise = global::ARGBColors.Gray;
			this.background.addControl(this.playSpeed2);
			this.playSpeed4.Image = GFXLibrary.playbackSpeed4;
			this.playSpeed4.Position = new Point(base.Width * 5 / 10 - this.playSpeed2.Image.Width / 2, this.background.Image.Height / 2 - this.playSpeed2.Image.Height / 2);
			this.playSpeed4.Data = 0;
			this.playSpeed4.Visible = true;
			this.playSpeed4.Enabled = true;
			this.playSpeed4.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickQuadSpeed));
			this.playSpeed4.CustomTooltipID = 22005;
			this.playSpeed4.Colorise = global::ARGBColors.Gray;
			this.background.addControl(this.playSpeed4);
			this.trackButton.Image = GFXLibrary.playbackBlank;
			this.trackButton.Position = new Point(base.Width / 2 - this.trackLength / 2, this.background.Image.Height / 2 - this.trackButton.Height / 2);
			this.trackButton.Data = 0;
			this.trackButton.Visible = true;
			this.trackButton.Enabled = true;
			this.trackButton.setMouseDownDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseDownDelegate(this.mouseDownDel), new CustomSelfDrawPanel.CSDControl.CSD_MouseDownDelegate(this.mouseUpDel));
			this.trackLine.Image = GFXLibrary.playbackTrack;
			this.trackLine.Position = new Point(base.Width / 2 - this.trackLength / 2, this.background.Image.Height / 2 - this.trackLine.Height / 2);
			this.trackLine.Data = 0;
			this.trackLine.Visible = true;
			this.trackLine.Enabled = true;
			this.trackLine.setMouseDownDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseDownDelegate(this.mouseDownDel), new CustomSelfDrawPanel.CSDControl.CSD_MouseDownDelegate(this.mouseUpDel));
			this.expandedBackground.addControl(this.trackLine);
			this.expandedBackground.addControl(this.trackButton);
			this.dayNumber.Text = "Day " + GameEngine.Instance.World.getPlaybackDay().ToString();
			this.dayNumber.Color = global::ARGBColors.White;
			this.dayNumber.RolloverColor = global::ARGBColors.White;
			this.dayNumber.Position = new Point(base.Width * 15 / 20, 0);
			this.dayNumber.Size = new Size(base.Width / 10, this.background.Image.Height);
			this.dayNumber.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.dayNumber.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.background.addControl(this.dayNumber);
			this.expandToggle.Image = GFXLibrary.playbackExpand;
			this.expandToggle.Position = new Point(base.Width * 9 / 10 - this.expandToggle.Image.Width / 2, this.background.Image.Height / 2 - this.expandToggle.Image.Height / 2);
			this.expandToggle.Data = 0;
			this.expandToggle.Visible = true;
			this.expandToggle.Enabled = true;
			this.expandToggle.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickExpand));
			this.expandToggle.CustomTooltipID = 22006;
			this.background.addControl(this.expandToggle);
			this.expandedBackground.Image = GFXLibrary.playbackBackground;
			this.expandedBackground.Position = new Point(0, base.Height / 2);
			this.expandedBackground.Data = 0;
			this.expandedBackground.Visible = false;
			this.expandedBackground.Enabled = false;
			this.expandedBackground.Alpha = 0f;
			this.expandedBackground.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickBackground));
			base.addControl(this.expandedBackground);
			base.invalidate();
			this.refresh();
		}

		// Token: 0x06001C02 RID: 7170 RVA: 0x0001BB12 File Offset: 0x00019D12
		public void refresh()
		{
			this.update();
		}

		// Token: 0x06001C03 RID: 7171 RVA: 0x001B43C4 File Offset: 0x001B25C4
		public void update()
		{
			this.dayNumber.Text = "Day " + GameEngine.Instance.World.getPlaybackDay().ToString();
			if (this.trackHeld)
			{
				if (!this.mouseInside)
				{
					this.mouseUpDel();
					return;
				}
				this.trackButton.X = Math.Max(base.Width / 2 - this.trackLength / 2, Math.Min(this.relativeMousePos.X, base.Width / 2 + this.trackLength / 2)) - this.trackButton.Width / 2;
				this.isDirty = true;
				base.invalidate();
				int playbackDay = this.convertPosToDay(this.trackButton.X + this.trackButton.Width / 2);
				GameEngine.Instance.World.setPlaybackDay(playbackDay);
			}
			else
			{
				this.trackButton.X = this.convertDayToPos(GameEngine.Instance.World.playbackDay) - this.trackButton.Width / 2;
				this.isDirty = true;
				base.invalidate();
			}
			if (!this.isAnimating)
			{
				return;
			}
			double num = (DateTime.Now - this.animStartTime).TotalMilliseconds / this.animDuration;
			if (num >= 1.0)
			{
				this.isAnimating = false;
				this.expandedBackground.Visible = this.isExpanded;
				this.expandedBackground.Enabled = this.isExpanded;
				return;
			}
			if (this.isExpanded)
			{
				this.trackLine.Alpha = (float)num;
				this.trackButton.Alpha = (float)num;
				this.expandedBackground.Alpha = 0.5f * (float)num;
				this.expandedBackground.Y = base.Height / 2 - (int)((double)(base.Height / 2) * num);
			}
			else
			{
				this.trackLine.Alpha = 1f - (float)num;
				this.trackButton.Alpha = 1f - (float)num;
				this.expandedBackground.Alpha = 0.5f - 0.5f * (float)num;
				this.expandedBackground.Y = (int)((double)(base.Height / 2) * num);
			}
			base.invalidate();
		}

		// Token: 0x06001C04 RID: 7172 RVA: 0x0001BB1A File Offset: 0x00019D1A
		public void flagAsRendered()
		{
			this.isDirty = false;
		}

		// Token: 0x06001C05 RID: 7173 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void toggleActive(bool value)
		{
		}

		// Token: 0x06001C06 RID: 7174 RVA: 0x001B45F4 File Offset: 0x001B27F4
		public void setMouseRelative(Point pos)
		{
			this.mouseInside = base.Rectangle.Contains(pos);
			this.relativeMousePos.X = Math.Max(0, Math.Min(base.Width, pos.X));
			this.relativeMousePos.Y = Math.Max(0, Math.Min(base.Height, pos.Y));
		}

		// Token: 0x06001C07 RID: 7175 RVA: 0x001B465C File Offset: 0x001B285C
		public void clickBackground()
		{
			int num = 0;
			num++;
		}

		// Token: 0x06001C08 RID: 7176 RVA: 0x0001BB23 File Offset: 0x00019D23
		public void clickStop()
		{
			GameEngine.Instance.World.stopPlayback();
		}

		// Token: 0x06001C09 RID: 7177 RVA: 0x001B4670 File Offset: 0x001B2870
		public void clickTogglePause()
		{
			GameEngine.Instance.World.togglePlaybackPause();
			this.isPaused = !this.isPaused;
			this.playPause.Image = (this.isPaused ? GFXLibrary.playbackPlay : GFXLibrary.playbackPause);
			this.playPause.CustomTooltipID = (this.isPaused ? 22002 : 22001);
		}

		// Token: 0x06001C0A RID: 7178 RVA: 0x001B46E0 File Offset: 0x001B28E0
		public void clickNormalSpeed()
		{
			GameEngine.Instance.World.changePlaybackSpeed(1.0);
			this.playSpeed1.Colorise = global::ARGBColors.White;
			this.playSpeed2.Colorise = global::ARGBColors.Gray;
			this.playSpeed4.Colorise = global::ARGBColors.Gray;
		}

		// Token: 0x06001C0B RID: 7179 RVA: 0x001B4738 File Offset: 0x001B2938
		public void clickDoubleSpeed()
		{
			GameEngine.Instance.World.changePlaybackSpeed(2.0);
			this.playSpeed1.Colorise = global::ARGBColors.Gray;
			this.playSpeed2.Colorise = global::ARGBColors.White;
			this.playSpeed4.Colorise = global::ARGBColors.Gray;
		}

		// Token: 0x06001C0C RID: 7180 RVA: 0x001B4790 File Offset: 0x001B2990
		public void clickQuadSpeed()
		{
			GameEngine.Instance.World.changePlaybackSpeed(4.0);
			this.playSpeed1.Colorise = global::ARGBColors.Gray;
			this.playSpeed2.Colorise = global::ARGBColors.Gray;
			this.playSpeed4.Colorise = global::ARGBColors.White;
		}

		// Token: 0x06001C0D RID: 7181 RVA: 0x001B47E8 File Offset: 0x001B29E8
		public void clickExpand()
		{
			if (!this.isAnimating)
			{
				this.isExpanded = true;
				this.expandToggle.Image = GFXLibrary.playbackContract;
				this.expandToggle.CustomTooltipID = 22007;
				this.expandToggle.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickContract));
				this.isAnimating = true;
				this.animStartTime = DateTime.Now;
				this.expandedBackground.Visible = true;
			}
		}

		// Token: 0x06001C0E RID: 7182 RVA: 0x001B4860 File Offset: 0x001B2A60
		public void clickContract()
		{
			if (!this.isAnimating)
			{
				this.isExpanded = false;
				this.expandToggle.Image = GFXLibrary.playbackExpand;
				this.expandToggle.CustomTooltipID = 22006;
				this.expandToggle.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickExpand));
				this.isAnimating = true;
				this.animStartTime = DateTime.Now;
			}
		}

		// Token: 0x06001C0F RID: 7183 RVA: 0x0001BB34 File Offset: 0x00019D34
		public void mouseDownDel()
		{
			if (!this.trackHeld)
			{
				this.trackHeld = true;
			}
		}

		// Token: 0x06001C10 RID: 7184 RVA: 0x0001BB45 File Offset: 0x00019D45
		public void mouseUpDel()
		{
			if (this.trackHeld)
			{
				this.trackHeld = false;
			}
		}

		// Token: 0x06001C11 RID: 7185 RVA: 0x001B48CC File Offset: 0x001B2ACC
		public int convertDayToPos(int day)
		{
			int playbackBasedDay = GameEngine.Instance.World.playbackBasedDay;
			int playbackTotalDays = GameEngine.Instance.World.playbackTotalDays;
			int num = base.Width / 2 - this.trackLength / 2;
			int num2 = base.Width / 2 + this.trackLength / 2;
			double num3 = (double)day / (double)playbackTotalDays;
			return (int)((double)num + (double)(num2 - num) * num3);
		}

		// Token: 0x06001C12 RID: 7186 RVA: 0x001B4930 File Offset: 0x001B2B30
		public int convertPosToDay(int pos)
		{
			int num = base.Width / 2 - this.trackLength / 2;
			int num2 = base.Width / 2 + this.trackLength / 2;
			int playbackTotalDays = GameEngine.Instance.World.playbackTotalDays;
			double num3 = (double)(pos - num) / (double)(num2 - num);
			return (int)((double)playbackTotalDays * num3);
		}

		// Token: 0x04002CDC RID: 11484
		private CustomSelfDrawPanel.CSDImage background = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002CDD RID: 11485
		private CustomSelfDrawPanel.CSDImage playPause = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002CDE RID: 11486
		private CustomSelfDrawPanel.CSDImage playStop = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002CDF RID: 11487
		private CustomSelfDrawPanel.CSDImage playSpeed1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002CE0 RID: 11488
		private CustomSelfDrawPanel.CSDImage playSpeed2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002CE1 RID: 11489
		private CustomSelfDrawPanel.CSDImage playSpeed4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002CE2 RID: 11490
		private CustomSelfDrawPanel.CSDImage trackButton = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002CE3 RID: 11491
		private CustomSelfDrawPanel.CSDImage trackLine = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002CE4 RID: 11492
		private CustomSelfDrawPanel.CSDImage expandToggle = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002CE5 RID: 11493
		private CustomSelfDrawPanel.CSDLabel dayLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002CE6 RID: 11494
		private CustomSelfDrawPanel.CSDLabel dayNumber = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002CE7 RID: 11495
		private CustomSelfDrawPanel.CSDImage expandedBackground = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002CE8 RID: 11496
		public bool isDirty;

		// Token: 0x04002CE9 RID: 11497
		public bool pauseTimeline;

		// Token: 0x04002CEA RID: 11498
		private bool isPaused;

		// Token: 0x04002CEB RID: 11499
		public bool trackHeld;

		// Token: 0x04002CEC RID: 11500
		private bool mouseInside;

		// Token: 0x04002CED RID: 11501
		private bool isExpanded;

		// Token: 0x04002CEE RID: 11502
		private bool isAnimating;

		// Token: 0x04002CEF RID: 11503
		private DateTime animStartTime = DateTime.Now;

		// Token: 0x04002CF0 RID: 11504
		private double animDuration = 200.0;

		// Token: 0x04002CF1 RID: 11505
		private int trackLength;

		// Token: 0x04002CF2 RID: 11506
		public Point relativeMousePos;
	}
}
