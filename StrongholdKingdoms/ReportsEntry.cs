using System;
using System.Drawing;
using CommonTypes;
using Kingdoms;

// Token: 0x02000003 RID: 3
public class ReportsEntry : CustomSelfDrawPanel.CSDControl
{
	// Token: 0x06000003 RID: 3 RVA: 0x000259C0 File Offset: 0x00023BC0
	public void init(ReportListItem entry, string text, string forwardedString, int lineID, ReportsPanel parent)
	{
		int num = -1;
		this.m_entry = entry;
		this.m_parent = parent;
		this.ClipVisible = true;
		this.clearControls();
		if (forwardedString.Length == 0)
		{
			if ((lineID & 1) == 0)
			{
				this.backgroundImage.Image = GFXLibrary.lineitem_strip_02_light;
			}
			else
			{
				this.backgroundImage.Image = GFXLibrary.lineitem_strip_02_dark;
			}
		}
		else if ((lineID & 1) == 0)
		{
			this.backgroundImage.Image = GFXLibrary.lineitem_strip_01_light;
		}
		else
		{
			this.backgroundImage.Image = GFXLibrary.lineitem_strip_01_dark;
		}
		this.backgroundImage.Position = new Point(0, 0);
		this.backgroundImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
		base.addControl(this.backgroundImage);
		this.Size = this.backgroundImage.Size;
		if (entry != null)
		{
			text += "   |";
		}
		this.descriptionLabel.Text = text;
		this.descriptionLabel.Color = global::ARGBColors.Black;
		this.descriptionLabel.Position = new Point(85, 1);
		this.descriptionLabel.Size = new Size(830 * InterfaceMgr.UIScale, this.backgroundImage.Height);
		float pointSize = 12f;
		if (entry != null)
		{
			if (entry.readStatus)
			{
				this.descriptionLabel.Font = FontManager.GetFont("Arial", pointSize, FontStyle.Regular);
			}
			else
			{
				this.descriptionLabel.Font = FontManager.GetFont("Arial", pointSize, FontStyle.Bold);
			}
		}
		else
		{
			this.descriptionLabel.Font = FontManager.GetFont("Arial", pointSize, FontStyle.Bold);
			num = 0;
		}
		this.descriptionLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
		this.descriptionLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
		this.backgroundImage.addControl(this.descriptionLabel);
		if (entry != null)
		{
			Graphics graphics = parent.CreateGraphics();
			Size size = graphics.MeasureString(text, this.descriptionLabel.Font, 830).ToSize();
			graphics.Dispose();
			DateTime currentServerTime = VillageMap.getCurrentServerTime();
			DateTime reportTime = entry.reportTime;
			TimeSpan timeSpan = currentServerTime - reportTime;
			string str = "";
			if (Program.mySettings.LanguageIdent == "de")
			{
				str = "vor ";
			}
			if (timeSpan.TotalMinutes < 1.0)
			{
				int num2 = (int)timeSpan.TotalSeconds;
				if (num2 <= 0)
				{
					num2 = 1;
				}
				if (num2 != 1)
				{
					this.dateLabel.Text = str + num2.ToString() + " " + SK.Text("ReportsPanel_seconds_ago", "seconds ago");
				}
				else
				{
					this.dateLabel.Text = str + num2.ToString() + " " + SK.Text("ReportsPanel_second_ago", "second ago");
				}
			}
			else if (timeSpan.TotalHours < 1.0)
			{
				int num3 = (int)timeSpan.TotalMinutes;
				if (num3 <= 0)
				{
					num3 = 1;
				}
				if (num3 != 1)
				{
					this.dateLabel.Text = str + num3.ToString() + " " + SK.Text("ReportsPanel_minutes_ago", "minutes ago");
				}
				else
				{
					this.dateLabel.Text = str + num3.ToString() + " " + SK.Text("ReportsPanel_minute_ago", "minute ago");
				}
			}
			else if (timeSpan.TotalHours < 24.0)
			{
				int num4 = (int)timeSpan.TotalHours;
				if (num4 <= 0)
				{
					num4 = 1;
				}
				if (num4 != 1)
				{
					this.dateLabel.Text = str + num4.ToString() + " " + SK.Text("ReportsPanel_hours_ago", "hours ago");
				}
				else
				{
					this.dateLabel.Text = str + num4.ToString() + " " + SK.Text("ReportsPanel_hour_ago", "hour ago");
				}
			}
			else
			{
				int num5 = (int)timeSpan.TotalDays;
				if (num5 <= 0)
				{
					num5 = 1;
				}
				if (num5 != 1)
				{
					this.dateLabel.Text = str + num5.ToString() + " " + SK.Text("ReportsPanel_days_ago", "days ago");
				}
				else
				{
					this.dateLabel.Text = str + num5.ToString() + " " + SK.Text("ReportsPanel_day_ago", "day ago");
				}
			}
			switch (entry.reportType)
			{
			case 1:
			case 2:
			case 24:
			case 25:
			case 58:
			case 59:
			case 60:
			case 61:
			case 123:
			case 124:
			case 125:
			case 132:
				num = ((!entry.readStatus) ? 1 : ((!entry.successStatus) ? 3 : 2));
				if (entry.reportID < 0L)
				{
					num += 30;
				}
				break;
			case 3:
			case 4:
			case 62:
			case 63:
			case 64:
			case 65:
			case 79:
			case 86:
			case 87:
			case 88:
			case 89:
			case 90:
				num = ((!entry.readStatus) ? 4 : ((!entry.successStatus) ? 6 : 5));
				if (entry.reportID < 0L)
				{
					num += 30;
				}
				break;
			case 13:
			case 14:
			case 15:
			case 16:
			case 46:
			case 47:
			case 48:
			case 49:
				num = 7;
				break;
			case 17:
			case 18:
			case 19:
				num = 8;
				break;
			case 20:
				num = 9;
				break;
			case 21:
			case 22:
			case 26:
			case 27:
			case 54:
			case 55:
			case 56:
			case 57:
			case 121:
			case 122:
			case 126:
			case 133:
				num = 10;
				break;
			case 23:
				num = 11;
				break;
			case 28:
			case 51:
			case 52:
			case 53:
			case 74:
			case 75:
				num = 12;
				break;
			case 50:
			case 107:
			case 108:
			case 109:
			case 110:
			case 111:
			case 112:
			case 113:
			case 114:
			case 115:
			case 116:
			case 117:
			case 118:
			case 120:
			case 134:
			case 135:
				num = 13;
				break;
			case 66:
			case 67:
			case 68:
			case 69:
			case 70:
			case 71:
			case 72:
			case 106:
				num = 14;
				break;
			case 73:
			case 78:
				num = 15;
				break;
			case 76:
			case 77:
			case 99:
				num = 16;
				break;
			case 80:
			case 81:
			case 82:
			case 83:
			case 84:
			case 85:
				num = 17;
				break;
			case 91:
			case 103:
			case 104:
			case 105:
				num = 18;
				break;
			case 92:
				num = 19;
				break;
			case 93:
				num = 20;
				break;
			case 94:
			case 95:
			case 96:
				num = 21;
				break;
			case 100:
				num = 22;
				break;
			case 101:
				num = 23;
				break;
			case 102:
			case 129:
			case 130:
			case 131:
			case 136:
			case 140:
			case 141:
				num = 24;
				break;
			case 127:
			case 128:
				num = 25;
				break;
			}
			this.dateLabel.Color = Color.FromArgb(50, 50, 50);
			this.dateLabel.Position = new Point(85 + size.Width, 1);
			this.dateLabel.Size = new Size(this.backgroundImage.Width - this.dateLabel.Position.X, this.backgroundImage.Height);
			float pointSize2 = 9f;
			if (entry.readStatus)
			{
				this.dateLabel.Font = FontManager.GetFont("Arial", pointSize2, FontStyle.Regular);
			}
			else
			{
				this.dateLabel.Font = FontManager.GetFont("Arial", pointSize2, FontStyle.Bold);
			}
			this.dateLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.dateLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
			this.backgroundImage.addControl(this.dateLabel);
			if (forwardedString.Length > 0)
			{
				this.forwardedLabel.Text = forwardedString;
				this.forwardedLabel.Color = Color.FromArgb(50, 50, 50);
				this.forwardedLabel.Position = new Point(100, 16);
				this.forwardedLabel.Size = new Size(830, this.backgroundImage.Height);
				this.forwardedLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.forwardedLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.forwardedLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
				this.backgroundImage.addControl(this.forwardedLabel);
			}
		}
		if (this.m_entry != null)
		{
			if (forwardedString.Length == 0)
			{
				this.markedImage.Position = new Point(60, 0);
			}
			else
			{
				this.markedImage.Position = new Point(60, 5);
			}
			this.markedImage.CheckedImage = GFXLibrary.checkbox_checked;
			this.markedImage.UncheckedImage = GFXLibrary.checkbox_unchecked;
			this.markedImage.Checked = false;
			this.markedImage.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.markedToggled));
			this.backgroundImage.addControl(this.markedImage);
		}
		if (num >= 0)
		{
			switch (num)
			{
			case 0:
				this.symbolImage.Image = GFXLibrary.icon_arrow_down;
				this.symbolImage.Position = new Point(15, 3);
				break;
			case 1:
				this.symbolImage.Image = GFXLibrary.wl_moving_unit_icons[39];
				this.symbolImage.Position = new Point(15, -5);
				break;
			case 2:
				this.symbolImage.Image = GFXLibrary.wl_moving_unit_icons[41];
				this.symbolImage.Position = new Point(15, -5);
				break;
			case 3:
				this.symbolImage.Image = GFXLibrary.wl_moving_unit_icons[43];
				this.symbolImage.Position = new Point(15, -5);
				break;
			case 4:
				this.symbolImage.Image = GFXLibrary.wl_moving_unit_icons[38];
				this.symbolImage.Position = new Point(15, -5);
				break;
			case 5:
				this.symbolImage.Image = GFXLibrary.wl_moving_unit_icons[40];
				this.symbolImage.Position = new Point(15, -5);
				break;
			case 6:
				this.symbolImage.Image = GFXLibrary.wl_moving_unit_icons[42];
				this.symbolImage.Position = new Point(15, -5);
				break;
			case 7:
				this.symbolImage.Image = GFXLibrary.wl_moving_unit_icons[35];
				this.symbolImage.Position = new Point(15, -5);
				break;
			case 8:
				this.symbolImage.Image = GFXLibrary.wl_moving_unit_icons[12];
				this.symbolImage.Position = new Point(15, -5);
				break;
			case 9:
				this.symbolImage.Image = GFXLibrary.wl_moving_unit_icons[36];
				this.symbolImage.Position = new Point(15, -5);
				break;
			case 10:
				this.symbolImage.Image = GFXLibrary.wl_moving_unit_icons[8];
				this.symbolImage.Position = new Point(15, -5);
				break;
			case 11:
				this.symbolImage.Image = GFXLibrary.wl_moving_unit_icons[2];
				this.symbolImage.Position = new Point(15, -5);
				break;
			case 12:
				this.symbolImage.Image = GFXLibrary.wl_moving_unit_icons[5];
				this.symbolImage.Position = new Point(15, -5);
				break;
			case 13:
				this.symbolImage.Image = GFXLibrary.wl_moving_unit_icons[37];
				this.symbolImage.Position = new Point(15, -5);
				break;
			case 14:
				this.symbolImage.Image = GFXLibrary.wl_moving_unit_icons[3];
				this.symbolImage.Position = new Point(15, -5);
				break;
			case 15:
				this.symbolImage.Image = GFXLibrary.wl_moving_unit_icons[1];
				this.symbolImage.Position = new Point(15, -5);
				break;
			case 16:
				this.symbolImage.Image = GFXLibrary.wl_moving_unit_icons[34];
				this.symbolImage.Position = new Point(15, -5);
				break;
			case 17:
				this.symbolImage.Image = GFXLibrary.wl_moving_unit_icons[4];
				this.symbolImage.Position = new Point(15, -5);
				break;
			case 18:
				this.symbolImage.Image = GFXLibrary.wl_moving_unit_icons[9];
				this.symbolImage.Position = new Point(15, -5);
				break;
			case 19:
				this.symbolImage.Image = GFXLibrary.wl_moving_unit_icons[46];
				this.symbolImage.Position = new Point(15, -5);
				break;
			case 20:
				this.symbolImage.Image = GFXLibrary.wl_moving_unit_icons[47];
				this.symbolImage.Position = new Point(15, -5);
				break;
			case 21:
				this.symbolImage.Image = GFXLibrary.wl_moving_unit_icons[48];
				this.symbolImage.Position = new Point(15, -5);
				break;
			case 22:
				this.symbolImage.Image = GFXLibrary.wl_moving_unit_icons[49];
				this.symbolImage.Position = new Point(15, -5);
				break;
			case 23:
				this.symbolImage.Image = GFXLibrary.wl_moving_unit_icons[50];
				this.symbolImage.Position = new Point(15, -5);
				break;
			case 24:
				this.symbolImage.Image = GFXLibrary.wl_moving_unit_icons[51];
				this.symbolImage.Position = new Point(15, -5);
				break;
			case 25:
				this.symbolImage.Image = GFXLibrary.wl_moving_unit_icons[58];
				this.symbolImage.Position = new Point(15, -5);
				break;
			case 31:
				this.symbolImage.Image = GFXLibrary.wl_moving_unit_icons[53];
				this.symbolImage.Position = new Point(15, -5);
				break;
			case 32:
				this.symbolImage.Image = GFXLibrary.wl_moving_unit_icons[55];
				this.symbolImage.Position = new Point(15, -5);
				break;
			case 33:
				this.symbolImage.Image = GFXLibrary.wl_moving_unit_icons[57];
				this.symbolImage.Position = new Point(15, -5);
				break;
			case 34:
				this.symbolImage.Image = GFXLibrary.wl_moving_unit_icons[52];
				this.symbolImage.Position = new Point(15, -5);
				break;
			case 35:
				this.symbolImage.Image = GFXLibrary.wl_moving_unit_icons[54];
				this.symbolImage.Position = new Point(15, -5);
				break;
			case 36:
				this.symbolImage.Image = GFXLibrary.wl_moving_unit_icons[56];
				this.symbolImage.Position = new Point(15, -5);
				break;
			}
			this.backgroundImage.addControl(this.symbolImage);
		}
	}

	// Token: 0x06000004 RID: 4 RVA: 0x00007CE0 File Offset: 0x00005EE0
	public void update()
	{
	}

	// Token: 0x06000005 RID: 5 RVA: 0x00026A08 File Offset: 0x00024C08
	public void lineClicked()
	{
		if (this.m_parent != null)
		{
			if (this.m_entry != null)
			{
				GameEngine.Instance.playInterfaceSound("ReportsPanel_report");
				this.m_parent.getReport(this.m_entry);
				this.descriptionLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
				this.dateLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.backgroundImage.invalidate();
				return;
			}
			GameEngine.Instance.playInterfaceSound("ReportsPanel_more");
			this.m_parent.showMoreReports();
		}
	}

	// Token: 0x06000006 RID: 6 RVA: 0x00026AA4 File Offset: 0x00024CA4
	public void deleteReport()
	{
		UniversalDebugLog.Log("hit del button");
		if (this.m_parent != null && this.m_entry != null)
		{
			this.m_parent.reportsManager.deleteReport(this.m_entry.reportID);
			this.m_parent.repopulateTable(this.m_parent.reportsManager.readFilterTypeDownloaded);
		}
	}

	// Token: 0x06000007 RID: 7 RVA: 0x00007CE2 File Offset: 0x00005EE2
	public void markedToggled()
	{
		if (this.markedImage.Checked)
		{
			this.backgroundImage.Colorise = global::ARGBColors.Green;
			return;
		}
		this.backgroundImage.Colorise = global::ARGBColors.White;
	}

	// Token: 0x0400002D RID: 45
	private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

	// Token: 0x0400002E RID: 46
	private CustomSelfDrawPanel.CSDLabel descriptionLabel = new CustomSelfDrawPanel.CSDLabel();

	// Token: 0x0400002F RID: 47
	private CustomSelfDrawPanel.CSDLabel forwardedLabel = new CustomSelfDrawPanel.CSDLabel();

	// Token: 0x04000030 RID: 48
	private CustomSelfDrawPanel.CSDLabel dateLabel = new CustomSelfDrawPanel.CSDLabel();

	// Token: 0x04000031 RID: 49
	private CustomSelfDrawPanel.CSDImage symbolImage = new CustomSelfDrawPanel.CSDImage();

	// Token: 0x04000032 RID: 50
	public CustomSelfDrawPanel.CSDCheckBox markedImage = new CustomSelfDrawPanel.CSDCheckBox();

	// Token: 0x04000033 RID: 51
	public ReportListItem m_entry;

	// Token: 0x04000034 RID: 52
	private ReportsPanel m_parent;
}
