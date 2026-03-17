using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000474 RID: 1140
	public class ReportsPanel : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x17000233 RID: 563
		// (get) Token: 0x0600292B RID: 10539 RVA: 0x0001E566 File Offset: 0x0001C766
		public ReportsManager reportsManager
		{
			get
			{
				return this.m_reportsManager;
			}
		}

		// Token: 0x0600292C RID: 10540 RVA: 0x001F6180 File Offset: 0x001F4380
		public ReportsPanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.NoDrawBackground = true;
			this.m_reportsManager = ReportsManager.instance;
		}

		// Token: 0x0600292D RID: 10541 RVA: 0x001F6278 File Offset: 0x001F4478
		public void init(bool resized)
		{
			if (this.initialLoad)
			{
				this.reportsManager.loadReports();
				this.initialLoad = false;
				ReportsPanel.inDownloadReports = false;
			}
			ReportsPanel.Instance = this;
			base.clearControls();
			this.mainBackgroundImage.FillColor = Color.FromArgb(134, 153, 165);
			this.mainBackgroundImage.Position = new Point(0, 0);
			this.mainBackgroundImage.Size = base.Size;
			base.addControl(this.mainBackgroundImage);
			this.backgroundFade.Image = GFXLibrary.background_top;
			this.backgroundFade.Size = new Size(base.Width, this.backgroundFade.Image.Height);
			this.backgroundFade.Position = new Point(0, 0);
			this.mainBackgroundImage.addControl(this.backgroundFade);
			this.headingLabel.Text = SK.Text("Reports_Reports", "Reports");
			this.headingLabel.Color = global::ARGBColors.White;
			this.headingLabel.DropShadowColor = global::ARGBColors.Black;
			this.headingLabel.Position = new Point(15, 8);
			this.headingLabel.Size = new Size(830, 35);
			this.headingLabel.Font = FontManager.GetFont("Arial", 24f, FontStyle.Regular);
			this.headingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mainBackgroundImage.addControl(this.headingLabel);
			this.downloadingLabel.Text = SK.Text("Reports_Downloading_Reports", "Download Reports....");
			this.downloadingLabel.Color = global::ARGBColors.White;
			this.downloadingLabel.DropShadowColor = global::ARGBColors.Black;
			this.downloadingLabel.Size = new Size(830, 30);
			this.downloadingLabel.Position = new Point(15, 60);
			this.downloadingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.downloadingLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.downloadingLabel.Visible = false;
			this.mainBackgroundImage.addControl(this.downloadingLabel);
			this.iconBar.Image = GFXLibrary.iconband;
			this.iconBar.Position = new Point(752, 13);
			this.mainBackgroundImage.addControl(this.iconBar);
			this.reportCaptureButton.ImageNorm = GFXLibrary.icon_capture;
			this.reportCaptureButton.ImageOver = GFXLibrary.icon_capture_over;
			this.reportCaptureButton.Position = new Point(10, -15);
			this.reportCaptureButton.setClickDelegate(delegate()
			{
				InterfaceMgr.Instance.openReportCaptureWindow(0);
			}, "ReportsPanel_capture");
			this.reportCaptureButton.CustomTooltipID = 1501;
			this.iconBar.addControl(this.reportCaptureButton);
			if (this.reportsManager.areFiltersClear())
			{
				this.reportFilterButton.ImageNorm = GFXLibrary.icon_filter;
				this.reportFilterButton.ImageOver = GFXLibrary.icon_filter_over;
			}
			else
			{
				this.reportFilterButton.ImageNorm = GFXLibrary.icon_filter_selected;
				this.reportFilterButton.ImageOver = GFXLibrary.icon_filter_selected_over;
			}
			this.reportFilterButton.Position = new Point(68, -15);
			this.reportFilterButton.setClickDelegate(delegate()
			{
				InterfaceMgr.Instance.openReportCaptureWindow(1);
			}, "ReportsPanel_filter");
			this.reportFilterButton.CustomTooltipID = 1500;
			this.iconBar.addControl(this.reportFilterButton);
			this.reportDeleteButton.ImageNorm = GFXLibrary.icon_trash;
			this.reportDeleteButton.ImageOver = GFXLibrary.icon_trash_over;
			this.reportDeleteButton.Position = new Point(126, -15);
			this.reportDeleteButton.setClickDelegate(delegate()
			{
				InterfaceMgr.Instance.openReportCaptureWindow(2);
			}, "ReportsPanel_delete");
			this.reportDeleteButton.CustomTooltipID = 1502;
			this.iconBar.addControl(this.reportDeleteButton);
			CustomSelfDrawPanel.WikiLinkControl.init(this.mainBackgroundImage, 21, new Point(base.Width - 38, 10));
			int height = base.Height;
			this.scrollArea.Position = new Point(20, 60);
			this.scrollArea.Size = new Size(930, height - 60);
			this.scrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(930, height - 60));
			this.mainBackgroundImage.addControl(this.scrollArea);
			this.mouseWheelOverlay.Position = this.scrollArea.Position;
			this.mouseWheelOverlay.Size = this.scrollArea.Size;
			this.mouseWheelOverlay.setMouseWheelDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate(this.mouseWheelMoved));
			this.mainBackgroundImage.addControl(this.mouseWheelOverlay);
			this.originalScrollPos = this.scrollBar.Value;
			this.scrollBar.Visible = false;
			this.scrollBar.Position = new Point(950, 60);
			this.scrollBar.Size = new Size(24, height - 60);
			this.mainBackgroundImage.addControl(this.scrollBar);
			this.scrollBar.Value = 0;
			this.scrollBar.Max = 100;
			this.scrollBar.NumVisibleLines = 25;
			this.scrollBar.Create(null, null, null, GFXLibrary._24wide_thumb_top, GFXLibrary._24wide_thumb_middle, GFXLibrary._24wide_thumb_bottom);
			this.scrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.scrollBarMoved));
			if (!resized)
			{
				this.reportsManager.init(new RemoteServices.GetReportsList_UserCallBack(this.reportListCallback));
				RemoteServices.Instance.set_GetReport_UserCallBack(new RemoteServices.GetReport_UserCallBack(this.reportCallback));
				RemoteServices.Instance.set_DeleteOrMoveReports_UserCallBack(new RemoteServices.DeleteReports_UserCallBack(this.deleteOrMoveReportsCallback));
				RemoteServices.Instance.set_ManageReportFolders_UserCallBack(new RemoteServices.ManageReportFolders_UserCallBack(this.reportsManager.manageReportFoldersCallback));
				if (ReportsPanel.inDownloadReports)
				{
					DateTime now = DateTime.Now;
					if ((now - ReportsPanel.InDownloadReportsTime).TotalSeconds > 30.0)
					{
						ReportsPanel.inDownloadReports = false;
					}
				}
				if (!ReportsPanel.inDownloadReports)
				{
					ReportsPanel.inDownloadReports = true;
					long clientHighest = this.reportsManager.findHighestReportID();
					RemoteServices.Instance.GetReportsList(this.reportsManager.readFilterTypeDownloaded, clientHighest);
				}
				this.downloadingLabel.Visible = true;
			}
			else
			{
				this.repopulateTable(this.reportsManager.readFilterTypeDownloaded);
				if (this.originalScrollPos > this.scrollBar.Max)
				{
					this.originalScrollPos = this.scrollBar.Max;
				}
				this.scrollBar.Value = this.originalScrollPos;
				this.scrollBarMoved();
			}
			base.Focus();
		}

		// Token: 0x0600292E RID: 10542 RVA: 0x001F6988 File Offset: 0x001F4B88
		private void scrollBarMoved()
		{
			int value = this.scrollBar.Value;
			this.scrollArea.Position = new Point(this.scrollArea.X, 60 - value);
			this.scrollArea.ClipRect = new Rectangle(this.scrollArea.ClipRect.X, value, this.scrollArea.ClipRect.Width, this.scrollArea.ClipRect.Height);
			this.scrollArea.invalidate();
			this.scrollBar.invalidate();
		}

		// Token: 0x0600292F RID: 10543 RVA: 0x001F6A20 File Offset: 0x001F4C20
		private void windowDragged()
		{
			int num = -this.dragOverlay.YDiff;
			if (this.scrollArea.ClipRect.Y + num < 0)
			{
				num = -this.scrollArea.ClipRect.Y;
			}
			int width = this.scrollArea.Size.Width;
			int num2 = (int)((double)this.scrollArea.Size.Height);
			if (this.scrollArea.ClipRect.Y + num > num2 - this.scrollArea.ClipRect.Height)
			{
				num -= this.scrollArea.ClipRect.Y + num - (num2 - this.scrollArea.ClipRect.Height);
			}
			this.scrollArea.Position = new Point(this.scrollArea.Position.X, this.scrollArea.Position.Y - num);
			this.scrollArea.ClipRect = new Rectangle(this.scrollArea.ClipRect.X, this.scrollArea.ClipRect.Y + num, this.scrollArea.ClipRect.Width, this.scrollArea.ClipRect.Height);
			this.scrollArea.invalidate();
		}

		// Token: 0x06002930 RID: 10544 RVA: 0x0001E56E File Offset: 0x0001C76E
		private void mouseWheelMoved(int delta)
		{
			if (delta < 0)
			{
				this.scrollBar.scrollDown(40);
				return;
			}
			if (delta > 0)
			{
				this.scrollBar.scrollUp(40);
			}
		}

		// Token: 0x06002931 RID: 10545 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void update()
		{
		}

		// Token: 0x06002932 RID: 10546 RVA: 0x0001E593 File Offset: 0x0001C793
		public void clearAllReports()
		{
			this.numToShow = 25;
			this.originalScrollPos = 0;
			this.scrollBar.Value = 0;
			this.reportsManager.ClearAllReports();
			GenericReportPanelBasic.MailFavourites = null;
			GenericReportPanelBasic.MailUsersHistory = null;
			GenericReportPanelBasic.ForceHistoryRefresh();
		}

		// Token: 0x06002933 RID: 10547 RVA: 0x001F6B90 File Offset: 0x001F4D90
		public void reportListCallback(GetReportsList_ReturnType returnData)
		{
			this.downloadingLabel.Visible = false;
			ReportsPanel.inDownloadReports = false;
			if (returnData.Success)
			{
				this.repopulateTable(returnData.readFilter);
				if (this.originalScrollPos > this.scrollBar.Max)
				{
					this.originalScrollPos = this.scrollBar.Max;
				}
				this.scrollBar.Value = this.originalScrollPos;
				this.scrollBarMoved();
			}
		}

		// Token: 0x06002934 RID: 10548 RVA: 0x001F6C00 File Offset: 0x001F4E00
		public void repopulateTable(int readFilter)
		{
			DateTime currentServerTime = VillageMap.getCurrentServerTime();
			this.reportEntries = this.reportsManager.getReportEntries(currentServerTime);
			this.recalcDisplayedGrid();
		}

		// Token: 0x06002935 RID: 10549 RVA: 0x001F6C2C File Offset: 0x001F4E2C
		public void recalcDisplayedGrid()
		{
			int num = this.scrollBar.Value;
			this.reportEntries.Sort(this.reportsManager.reportsMainComparer);
			this.scrollArea.clearControls();
			int num2 = 0;
			this.lineList.Clear();
			int count = this.reportEntries.Count;
			int num3 = 0;
			while (num3 < count && num3 < this.numToShow)
			{
				ReportListItem reportListItem = this.reportEntries[num3];
				int reportType = (int)reportListItem.reportType;
				string text = (reportListItem.reportAboutUser == null || reportListItem.reportAboutUser.Length <= 0) ? RemoteServices.Instance.UserName : reportListItem.reportAboutUser;
				int targetVillage = reportListItem.targetVillage;
				int sourceVillage = reportListItem.sourceVillage;
				string text2 = "";
				string str = text;
				if (text != RemoteServices.Instance.UserName)
				{
					text2 = SK.Text("Reports_Forwarded_By", "Forwarded by") + " : ";
				}
				bool flag = false;
				bool flag2 = false;
				if (reportType <= 61)
				{
					if (reportType <= 3)
					{
						if (reportType == 1)
						{
							goto IL_148;
						}
						if (reportType == 3)
						{
							goto IL_178;
						}
					}
					else if (reportType - 24 <= 1 || reportType - 58 <= 3)
					{
						goto IL_148;
					}
				}
				else if (reportType <= 79)
				{
					if (reportType - 62 <= 3 || reportType == 79)
					{
						goto IL_178;
					}
				}
				else if (reportType - 123 <= 2 || reportType == 132)
				{
					goto IL_148;
				}
				IL_1A6:
				string reportTitle = ReportsManager.getReportTitle(reportListItem);
				if (text != RemoteServices.Instance.UserName && !flag && !flag2)
				{
					text2 += text;
				}
				else if ((flag || flag2) && text2.Length > 0)
				{
					text2 += str;
				}
				ReportsEntry reportsEntry = new ReportsEntry();
				if (num2 != 0)
				{
					num2 += 5;
				}
				reportsEntry.Position = new Point(0, num2);
				reportsEntry.init(reportListItem, reportTitle, text2, num3, this);
				this.scrollArea.addControl(reportsEntry);
				num2 += reportsEntry.Height;
				this.lineList.Add(reportsEntry);
				num3++;
				continue;
				IL_148:
				if (sourceVillage >= 0 && GameEngine.Instance.World.isRegionCapital(sourceVillage))
				{
					text = GameEngine.Instance.World.getParishNameFromVillageID(sourceVillage);
					flag = true;
					goto IL_1A6;
				}
				goto IL_1A6;
				IL_178:
				if (targetVillage >= 0 && GameEngine.Instance.World.isRegionCapital(targetVillage))
				{
					text = GameEngine.Instance.World.getParishNameFromVillageID(targetVillage);
					flag2 = true;
					goto IL_1A6;
				}
				goto IL_1A6;
			}
			if (count > this.numToShow)
			{
				ReportsEntry reportsEntry2 = new ReportsEntry();
				if (num2 != 0)
				{
					num2 += 5;
				}
				reportsEntry2.Position = new Point(0, num2);
				reportsEntry2.init(null, SK.Text("ReportsPanel_Show_More_Reports", "Show More Reports"), "", num3, this);
				this.scrollArea.addControl(reportsEntry2);
				num2 += reportsEntry2.Height;
				this.lineList.Add(reportsEntry2);
			}
			this.scrollArea.Size = new Size(this.scrollArea.Width, num2);
			if (num2 < this.scrollBar.Height)
			{
				this.scrollBar.Visible = false;
				this.scrollBar.Max = 0;
			}
			else
			{
				this.scrollBar.Visible = true;
				this.scrollBar.NumVisibleLines = this.scrollBar.Height;
				this.scrollBar.Max = num2 - this.scrollBar.Height;
			}
			if (num > this.scrollBar.Max)
			{
				num = this.scrollBar.Max;
			}
			this.scrollBar.Value = num;
			this.scrollBarMoved();
			this.scrollArea.invalidate();
			this.scrollBar.invalidate();
			base.Invalidate();
		}

		// Token: 0x06002936 RID: 10550 RVA: 0x001F6FBC File Offset: 0x001F51BC
		public void showMoreReports()
		{
			if (this.numToShow < 100)
			{
				this.numToShow += 50;
			}
			else if (this.numToShow < 300)
			{
				this.numToShow += 100;
			}
			else if (this.numToShow < 1000)
			{
				this.numToShow += 200;
			}
			else
			{
				this.numToShow += 500;
			}
			this.repopulateTable(0);
		}

		// Token: 0x06002937 RID: 10551 RVA: 0x001F703C File Offset: 0x001F523C
		public void getReport(ReportListItem item)
		{
			long num = Math.Abs(item.reportID);
			item.readStatus = true;
			if (this.reportsManager.storedReportHeaders[num] != null)
			{
				ReportListItem reportListItem = (ReportListItem)this.reportsManager.storedReportHeaders[num];
				reportListItem.readStatus = true;
				this.reportsManager.storedReportHeaders[num] = reportListItem;
			}
			if (this.reportsManager.storedReportBodies[num] != null)
			{
				this.showReport((GetReport_ReturnType)this.reportsManager.storedReportBodies[num]);
				return;
			}
			DateTime now = DateTime.Now;
			if ((now - this.lastReportOpenedTime).TotalSeconds > 2.0)
			{
				this.lastReportOpenedTime = now;
				RemoteServices.Instance.GetReport(num);
			}
		}

		// Token: 0x06002938 RID: 10552 RVA: 0x001F7108 File Offset: 0x001F5308
		public void reportCallback(GetReport_ReturnType returnData)
		{
			if (returnData.Success)
			{
				this.reportsManager.storedReportBodies[returnData.reportID] = returnData;
				this.showReport(returnData);
				return;
			}
			if (returnData.m_errorCode == ErrorCodes.ErrorCode.REPORTS_NO_REPORT)
			{
				MyMessageBox.Show(SK.Text("ReportsPanel_Been_Deleted", "This Report has been deleted"), SK.Text("ReportsPanel_Report_Error", "Report Error"));
			}
		}

		// Token: 0x06002939 RID: 10553 RVA: 0x001F716C File Offset: 0x001F536C
		public void showReport(GetReport_ReturnType returnData)
		{
			if (this.popupWindow != null && this.popupWindow.isVisible())
			{
				this.popupWindow.closeControl(true);
				this.popupWindow = null;
			}
			GenericReportPanelBasic genericReportPanelBasic = null;
			switch (returnData.reportType)
			{
			case 1:
			case 2:
			case 3:
			case 4:
			case 24:
			case 25:
			case 58:
			case 59:
			case 60:
			case 61:
			case 62:
			case 63:
			case 64:
			case 65:
			case 79:
			case 123:
			case 124:
			case 125:
			case 132:
				genericReportPanelBasic = new AttackReportPanelDerived();
				break;
			case 15:
			case 16:
			case 46:
			case 47:
			case 48:
			case 49:
				genericReportPanelBasic = new VassalReportPanelDerived();
				break;
			case 17:
			case 18:
			case 19:
				genericReportPanelBasic = new ReinforcementsReportPanelDerived();
				break;
			case 20:
				genericReportPanelBasic = new ResearchCompleteReportPanelDerived();
				break;
			case 21:
			case 22:
			case 23:
			case 26:
			case 27:
			case 31:
			case 32:
			case 34:
			case 36:
			case 38:
			case 39:
			case 40:
			case 54:
			case 55:
			case 56:
			case 57:
			case 121:
			case 122:
			case 126:
			case 133:
				genericReportPanelBasic = new ScoutReportPanelDerived();
				break;
			case 28:
			case 53:
			case 74:
			case 75:
				genericReportPanelBasic = new ParishElectionReportPanelDerived();
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
				genericReportPanelBasic = new FactionReportPanelDerived();
				break;
			case 66:
			case 67:
			case 68:
			case 69:
			case 70:
			case 71:
			case 72:
			case 91:
			case 103:
			case 104:
			case 105:
			case 106:
				genericReportPanelBasic = new ReligiousReportPanelDerived();
				break;
			case 73:
			case 78:
				genericReportPanelBasic = new TradeReportPanelDerived();
				break;
			case 76:
			case 77:
			case 99:
				genericReportPanelBasic = new CardExpiryReportPanelDerived();
				break;
			case 80:
			case 81:
			case 82:
			case 83:
			case 84:
			case 85:
			case 86:
			case 87:
			case 88:
			case 89:
			case 90:
				genericReportPanelBasic = new EnemyAttackWarningReportPanelDerived();
				break;
			case 92:
				genericReportPanelBasic = new AchievementReportPanelDerived();
				break;
			case 93:
			case 94:
			case 95:
			case 96:
				genericReportPanelBasic = new VillageCharterReportPanelDerived();
				break;
			case 100:
			case 101:
				genericReportPanelBasic = new QuestReportPanelDerived();
				break;
			case 102:
			case 129:
			case 130:
			case 131:
			case 136:
				genericReportPanelBasic = new QuestReportPanelDerived();
				break;
			case 127:
			case 128:
				genericReportPanelBasic = new VillageLostReportPanelDerived();
				break;
			case 140:
				genericReportPanelBasic = new PrizeWonReportPanelDerived();
				break;
			case 141:
				genericReportPanelBasic = new PrizeClaimReportPanelDerived();
				break;
			}
			if (genericReportPanelBasic != null)
			{
				GenericReportPopup genericReportPopup = new GenericReportPopup(genericReportPanelBasic);
				genericReportPopup.initProperties(false, SK.Text("ReportsPanel_Report", "Report"), null);
				genericReportPopup.setData(returnData);
				genericReportPopup.display(true, null, 0, 0);
				this.popupWindow = genericReportPopup;
			}
		}

		// Token: 0x0600293A RID: 10554 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void deleteOrMoveReportsCallback(DeleteReports_ReturnType returnData)
		{
		}

		// Token: 0x0600293B RID: 10555 RVA: 0x001F74B8 File Offset: 0x001F56B8
		public bool queryDeleteReport(long reportID)
		{
			MessageBoxButtons buts = MessageBoxButtons.YesNo;
			MyMessageBox.setCustomSounds("Reports_single_delete_clicked", "");
			DialogResult dialogResult = MyMessageBox.Show(SK.Text("SendMonksPanel_Delete_This_Report", "Delete this report?"), SK.Text("SendMonksPanel_Delete_Report", "Delete Report"), buts);
			MyMessageBox.resetCustomSounds();
			if (dialogResult == DialogResult.Yes)
			{
				this.reportsManager.deleteReport(reportID);
				this.repopulateTable(this.reportsManager.readFilterTypeDownloaded);
				return true;
			}
			return false;
		}

		// Token: 0x0600293C RID: 10556 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void closing()
		{
		}

		// Token: 0x0600293D RID: 10557 RVA: 0x001F7524 File Offset: 0x001F5724
		public void updateFilters()
		{
			this.repopulateTable(this.reportsManager.readFilterTypeDownloaded);
			if (this.reportsManager.areFiltersClear())
			{
				this.reportFilterButton.ImageNorm = GFXLibrary.icon_filter;
				this.reportFilterButton.ImageOver = GFXLibrary.icon_filter_over;
				return;
			}
			this.reportFilterButton.ImageNorm = GFXLibrary.icon_filter_selected;
			this.reportFilterButton.ImageOver = GFXLibrary.icon_filter_selected_over;
		}

		// Token: 0x0600293E RID: 10558 RVA: 0x001F75A4 File Offset: 0x001F57A4
		private void deleteAllReportsTrue()
		{
			if (this.idListRef.Count > 0)
			{
				long[] array = this.idListRef.ToArray();
				RemoteServices.Instance.DeleteReports(array);
				long[] array2 = array;
				foreach (long index in array2)
				{
					this.reportsManager.storedReportHeaders[index] = null;
				}
				this.repopulateTable(0);
			}
		}

		// Token: 0x0600293F RID: 10559 RVA: 0x001F75A4 File Offset: 0x001F57A4
		private void deleteShownReportsTrue()
		{
			if (this.idListRef.Count > 0)
			{
				long[] array = this.idListRef.ToArray();
				RemoteServices.Instance.DeleteReports(array);
				long[] array2 = array;
				foreach (long index in array2)
				{
					this.reportsManager.storedReportHeaders[index] = null;
				}
				this.repopulateTable(0);
			}
		}

		// Token: 0x06002940 RID: 10560 RVA: 0x001F75A4 File Offset: 0x001F57A4
		private void deleteMarkedReportsTrue()
		{
			if (this.idListRef.Count > 0)
			{
				long[] array = this.idListRef.ToArray();
				RemoteServices.Instance.DeleteReports(array);
				long[] array2 = array;
				foreach (long index in array2)
				{
					this.reportsManager.storedReportHeaders[index] = null;
				}
				this.repopulateTable(0);
			}
		}

		// Token: 0x06002941 RID: 10561 RVA: 0x001F7608 File Offset: 0x001F5808
		public void deleteAllReports()
		{
			MessageBoxButtons buts = MessageBoxButtons.YesNo;
			List<long> list = new List<long>();
			foreach (object obj in this.reportsManager.storedReportHeaders)
			{
				ReportListItem reportListItem = (ReportListItem)obj;
				list.Add(Math.Abs(reportListItem.reportID));
			}
			this.idListRef = list;
			if (list.Count > 0)
			{
				MyMessageBox.setCustomSounds("ReportDeletePanel_delete_all_Deleting", "");
			}
			else
			{
				MyMessageBox.setCustomSounds("ReportDeletePanel_delete_all_Nothing_To_delete", "");
			}
			DialogResult dialogResult = MyMessageBox.Show(SK.Text("ReportsPanel_DeleteAllReports", "Delete All Reports?"), SK.Text("ReportsPanel_ConfirmDelete", "Confirm Delete?"), buts, MessageBoxIcon.None, MessageBoxDefaultButton.Button2, 0);
			if (dialogResult != DialogResult.No && dialogResult == DialogResult.Yes)
			{
				this.deleteAllReportsTrue();
			}
		}

		// Token: 0x06002942 RID: 10562 RVA: 0x001F76E8 File Offset: 0x001F58E8
		public void deleteShownReports()
		{
			MessageBoxButtons buts = MessageBoxButtons.YesNo;
			List<long> list = new List<long>();
			foreach (ReportsEntry reportsEntry in this.lineList)
			{
				if (reportsEntry != null && reportsEntry.m_entry != null)
				{
					list.Add(Math.Abs(reportsEntry.m_entry.reportID));
				}
			}
			this.idListRef = list;
			if (list.Count > 0)
			{
				MyMessageBox.setCustomSounds("ReportDeletePanel_delete_shown_Deleting", "");
			}
			else
			{
				MyMessageBox.setCustomSounds("ReportDeletePanel_delete_shown_Nothing_To_delete", "");
			}
			DialogResult dialogResult = MyMessageBox.Show(SK.Text("ReportsPanel_Delete_All_Shown_Reports", "Delete All Shown Reports?"), SK.Text("ReportsPanel_ConfirmDelete", "Confirm Delete?"), buts, MessageBoxIcon.None, MessageBoxDefaultButton.Button2, 0);
			if (dialogResult != DialogResult.No && dialogResult == DialogResult.Yes)
			{
				this.deleteShownReportsTrue();
			}
		}

		// Token: 0x06002943 RID: 10563 RVA: 0x001F77CC File Offset: 0x001F59CC
		public void deleteMarkedReports()
		{
			List<long> list = new List<long>();
			foreach (ReportsEntry reportsEntry in this.lineList)
			{
				if (reportsEntry != null && reportsEntry.m_entry != null && reportsEntry.markedImage.Checked)
				{
					list.Add(Math.Abs(reportsEntry.m_entry.reportID));
				}
			}
			this.idListRef = list;
			MessageBoxButtons buts = MessageBoxButtons.YesNo;
			if (list.Count > 0)
			{
				MyMessageBox.setCustomSounds("ReportDeletePanel_delete_marked_Deleting", "");
			}
			else
			{
				MyMessageBox.setCustomSounds("ReportDeletePanel_delete_marked_Nothing_To_delete", "");
			}
			DialogResult dialogResult = MyMessageBox.Show(SK.Text("ReportsPanel_DeleteMarkedReports", "Delete Marked Reports?"), SK.Text("ReportsPanel_ConfirmDelete", "Confirm Delete?"), buts, MessageBoxIcon.None, MessageBoxDefaultButton.Button2, 0);
			MyMessageBox.resetCustomSounds();
			if (dialogResult != DialogResult.No && dialogResult == DialogResult.Yes)
			{
				this.deleteMarkedReportsTrue();
			}
		}

		// Token: 0x06002944 RID: 10564 RVA: 0x001F78C4 File Offset: 0x001F5AC4
		public void deleteUnmarkedReports()
		{
			List<long> list = new List<long>();
			foreach (ReportsEntry reportsEntry in this.lineList)
			{
				if (reportsEntry != null && reportsEntry.m_entry != null && !reportsEntry.markedImage.Checked)
				{
					list.Add(Math.Abs(reportsEntry.m_entry.reportID));
				}
			}
			this.idListRef = list;
			MessageBoxButtons buts = MessageBoxButtons.YesNo;
			if (list.Count > 0)
			{
				MyMessageBox.setCustomSounds("ReportDeletePanel_delete_marked_Deleting", "");
			}
			else
			{
				MyMessageBox.setCustomSounds("ReportDeletePanel_delete_marked_Nothing_To_delete", "");
			}
			DialogResult dialogResult = MyMessageBox.Show(SK.Text("ReportsPanel_DeleteUnmarkedReports", "Delete Unmarked Reports?"), SK.Text("ReportsPanel_ConfirmDelete", "Confirm Delete?"), buts, MessageBoxIcon.None, MessageBoxDefaultButton.Button2, 0);
			MyMessageBox.resetCustomSounds();
			if (dialogResult != DialogResult.No && dialogResult == DialogResult.Yes)
			{
				this.deleteMarkedReportsTrue();
			}
		}

		// Token: 0x06002945 RID: 10565 RVA: 0x001F79BC File Offset: 0x001F5BBC
		public void markAsReadAllReports()
		{
			List<long> list = new List<long>();
			foreach (object obj in this.reportsManager.storedReportHeaders)
			{
				ReportListItem reportListItem = (ReportListItem)obj;
				if (!reportListItem.readStatus)
				{
					list.Add(Math.Abs(reportListItem.reportID));
				}
			}
			if (list.Count <= 0)
			{
				return;
			}
			long[] array = list.ToArray();
			RemoteServices.Instance.MarkReportsRead(array);
			long[] array2 = array;
			foreach (long index in array2)
			{
				ReportListItem reportListItem2 = (ReportListItem)this.reportsManager.storedReportHeaders[index];
				if (reportListItem2 != null)
				{
					reportListItem2.readStatus = true;
				}
			}
			this.repopulateTable(0);
		}

		// Token: 0x06002946 RID: 10566 RVA: 0x001F7AA0 File Offset: 0x001F5CA0
		public void markAsReadShownReports()
		{
			List<long> list = new List<long>();
			foreach (ReportsEntry reportsEntry in this.lineList)
			{
				if (reportsEntry != null && reportsEntry.m_entry != null)
				{
					list.Add(Math.Abs(reportsEntry.m_entry.reportID));
				}
			}
			if (list.Count > 0)
			{
				List<long> list2 = new List<long>();
				foreach (long num in list)
				{
					ReportListItem reportListItem = (ReportListItem)this.reportsManager.storedReportHeaders[num];
					if (reportListItem != null && !reportListItem.readStatus)
					{
						list2.Add(num);
					}
				}
				list = list2;
			}
			if (list.Count <= 0)
			{
				return;
			}
			long[] array = list.ToArray();
			RemoteServices.Instance.MarkReportsRead(array);
			long[] array2 = array;
			foreach (long index in array2)
			{
				ReportListItem reportListItem2 = (ReportListItem)this.reportsManager.storedReportHeaders[index];
				if (reportListItem2 != null)
				{
					reportListItem2.readStatus = true;
				}
			}
			this.repopulateTable(0);
		}

		// Token: 0x06002947 RID: 10567 RVA: 0x001F7BF8 File Offset: 0x001F5DF8
		public void markAsReadMarkedReports()
		{
			List<long> list = new List<long>();
			foreach (ReportsEntry reportsEntry in this.lineList)
			{
				if (reportsEntry != null && reportsEntry.m_entry != null && reportsEntry.markedImage.Checked)
				{
					list.Add(Math.Abs(reportsEntry.m_entry.reportID));
				}
			}
			if (list.Count <= 0)
			{
				return;
			}
			long[] array = list.ToArray();
			RemoteServices.Instance.MarkReportsRead(array);
			long[] array2 = array;
			foreach (long index in array2)
			{
				ReportListItem reportListItem = (ReportListItem)this.reportsManager.storedReportHeaders[index];
				if (reportListItem != null)
				{
					reportListItem.readStatus = true;
				}
			}
			this.repopulateTable(0);
		}

		// Token: 0x06002948 RID: 10568 RVA: 0x0001E5CC File Offset: 0x0001C7CC
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06002949 RID: 10569 RVA: 0x0001E5DC File Offset: 0x0001C7DC
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x0600294A RID: 10570 RVA: 0x0001E5EC File Offset: 0x0001C7EC
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x0600294B RID: 10571 RVA: 0x0001E5FE File Offset: 0x0001C7FE
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x0600294C RID: 10572 RVA: 0x0001E60B File Offset: 0x0001C80B
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
			this.closing();
		}

		// Token: 0x0600294D RID: 10573 RVA: 0x0001E625 File Offset: 0x0001C825
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x0600294E RID: 10574 RVA: 0x0001E632 File Offset: 0x0001C832
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x0600294F RID: 10575 RVA: 0x0001E63F File Offset: 0x0001C83F
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002950 RID: 10576 RVA: 0x001F7CE4 File Offset: 0x001F5EE4
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.MaximumSize = new Size(992, 10000);
			this.MinimumSize = new Size(992, 566);
			base.Size = new Size(992, 566);
			base.Name = "ReportsPanel";
			base.ResumeLayout(false);
		}

		// Token: 0x04003244 RID: 12868
		public static ReportsPanel Instance = null;

		// Token: 0x04003245 RID: 12869
		private CustomSelfDrawPanel.CSDFill mainBackgroundImage = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x04003246 RID: 12870
		private CustomSelfDrawPanel.CSDImage backgroundFade = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003247 RID: 12871
		private CustomSelfDrawPanel.CSDLabel headingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003248 RID: 12872
		private CustomSelfDrawPanel.CSDLabel downloadingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003249 RID: 12873
		private CustomSelfDrawPanel.CSDImage iconBar = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400324A RID: 12874
		private CustomSelfDrawPanel.CSDButton reportCaptureButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400324B RID: 12875
		private CustomSelfDrawPanel.CSDButton reportFilterButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400324C RID: 12876
		private CustomSelfDrawPanel.CSDButton reportDeleteButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400324D RID: 12877
		private CustomSelfDrawPanel.CSDVertScrollBar scrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x0400324E RID: 12878
		private CustomSelfDrawPanel.CSDArea scrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400324F RID: 12879
		private CustomSelfDrawPanel.CSDDragPanel dragOverlay = new CustomSelfDrawPanel.CSDDragPanel();

		// Token: 0x04003250 RID: 12880
		private CustomSelfDrawPanel.CSDControl mouseWheelOverlay = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x04003251 RID: 12881
		private bool initialLoad = true;

		// Token: 0x04003252 RID: 12882
		private int numToShow = 25;

		// Token: 0x04003253 RID: 12883
		private int originalScrollPos;

		// Token: 0x04003254 RID: 12884
		private static bool inDownloadReports = false;

		// Token: 0x04003255 RID: 12885
		private static DateTime InDownloadReportsTime = DateTime.MinValue;

		// Token: 0x04003256 RID: 12886
		private List<ReportListItem> reportEntries = new List<ReportListItem>();

		// Token: 0x04003257 RID: 12887
		private List<ReportsEntry> lineList = new List<ReportsEntry>();

		// Token: 0x04003258 RID: 12888
		private DateTime lastReportOpenedTime = DateTime.MinValue;

		// Token: 0x04003259 RID: 12889
		private IDockableControl popupWindow;

		// Token: 0x0400325A RID: 12890
		private List<long> idListRef;

		// Token: 0x0400325B RID: 12891
		private readonly ReportsManager m_reportsManager;

		// Token: 0x0400325C RID: 12892
		private DockableControl dockableControl;

		// Token: 0x0400325D RID: 12893
		private IContainer components;

		// Token: 0x0400325E RID: 12894
		[CompilerGenerated]
		private static CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate _003C_003E9__CachedAnonymousMethodDelegate3;

		// Token: 0x0400325F RID: 12895
		[CompilerGenerated]
		private static CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate _003C_003E9__CachedAnonymousMethodDelegate4;

		// Token: 0x04003260 RID: 12896
		[CompilerGenerated]
		private static CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate _003C_003E9__CachedAnonymousMethodDelegate5;
	}
}
