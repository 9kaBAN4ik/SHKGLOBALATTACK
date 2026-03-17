using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using CommonTypes;
using DXGraphics;

namespace Kingdoms
{
	// Token: 0x0200021F RID: 543
	public class MailManager
	{
		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x060016E8 RID: 5864 RVA: 0x00018251 File Offset: 0x00016451
		public static MailManager Instance
		{
			get
			{
				if (MailManager.m_instance == null)
				{
					MailManager.m_instance = new MailManager();
				}
				return MailManager.m_instance;
			}
		}

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x060016E9 RID: 5865 RVA: 0x00018269 File Offset: 0x00016469
		public DraftMail CurrentDraft
		{
			get
			{
				return MailManager.currentDraft;
			}
		}

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x060016EA RID: 5866 RVA: 0x00018270 File Offset: 0x00016470
		// (set) Token: 0x060016EB RID: 5867 RVA: 0x00018278 File Offset: 0x00016478
		public SparseArray storedThreadHeaders
		{
			get
			{
				return this.m_storedThreadHeaders;
			}
			set
			{
				this.m_storedThreadHeaders = value;
			}
		}

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x060016EC RID: 5868 RVA: 0x00018281 File Offset: 0x00016481
		// (set) Token: 0x060016ED RID: 5869 RVA: 0x00018289 File Offset: 0x00016489
		public SparseArray storedThreads
		{
			get
			{
				return this.m_storedThreads;
			}
			set
			{
				this.m_storedThreads = value;
			}
		}

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x060016EE RID: 5870 RVA: 0x00018292 File Offset: 0x00016492
		// (set) Token: 0x060016EF RID: 5871 RVA: 0x0001829A File Offset: 0x0001649A
		public List<MailFolderItem> mailFolders
		{
			get
			{
				return this.m_mailFolders;
			}
			set
			{
				this.m_mailFolders = value;
			}
		}

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x060016F0 RID: 5872 RVA: 0x000182A3 File Offset: 0x000164A3
		// (set) Token: 0x060016F1 RID: 5873 RVA: 0x000182AB File Offset: 0x000164AB
		public List<MailThreadListItem> preSortedHeaders
		{
			get
			{
				return this.m_preSortedHeaders;
			}
			set
			{
				this.m_preSortedHeaders = value;
			}
		}

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x060016F2 RID: 5874 RVA: 0x000182B4 File Offset: 0x000164B4
		// (set) Token: 0x060016F3 RID: 5875 RVA: 0x000182BC File Offset: 0x000164BC
		public List<MailThreadListItem> preSortedAllHeader
		{
			get
			{
				return this.m_preSortedALLHeader;
			}
			set
			{
				this.m_preSortedALLHeader = value;
			}
		}

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x060016F4 RID: 5876 RVA: 0x000182C5 File Offset: 0x000164C5
		// (set) Token: 0x060016F5 RID: 5877 RVA: 0x000182CD File Offset: 0x000164CD
		public bool AggressiveBlocking
		{
			get
			{
				return this.aggressiveBlocking;
			}
			set
			{
				this.aggressiveBlocking = value;
				this.blockListChanged = true;
			}
		}

		// Token: 0x060016F6 RID: 5878 RVA: 0x0016B240 File Offset: 0x00169440
		public MailManager()
		{
			UniversalDebugLog.Log("Created new mail manager");
		}

		// Token: 0x060016F7 RID: 5879 RVA: 0x000182DD File Offset: 0x000164DD
		public void getRecipientHistory()
		{
			RemoteServices.Instance.set_GetMailRecipientsHistory_UserCallBack(new RemoteServices.GetMailRecipientsHistory_UserCallBack(this.mailRecipientsCallback));
			RemoteServices.Instance.GetMailRecipientsHistory();
		}

		// Token: 0x060016F8 RID: 5880 RVA: 0x000182FF File Offset: 0x000164FF
		private void mailRecipientsCallback(GetMailRecipientsHistory_ReturnType returnData)
		{
			if (returnData.Success)
			{
				this.mailFavourites = returnData.mailFavourites;
				this.mailUsersHistory = returnData.mailUsersHistory;
			}
		}

		// Token: 0x060016F9 RID: 5881 RVA: 0x00018321 File Offset: 0x00016521
		public void getFolders(MailManager.GenericUIDelegate callback)
		{
			this.getFolderCallback = callback;
			RemoteServices.Instance.set_GetMailFolders_UserCallBack(new RemoteServices.GetMailFolders_UserCallBack(this.mailFoldersCallback));
			RemoteServices.Instance.GetMailFolders();
		}

		// Token: 0x060016FA RID: 5882 RVA: 0x0001834A File Offset: 0x0001654A
		public void mailFoldersCallback(GetMailFolders_ReturnType returnData)
		{
			if (returnData.Success)
			{
				this.mailFolders.Clear();
				this.mailFolders.AddRange(returnData.folders);
				this.getFolderCallback();
			}
		}

		// Token: 0x060016FB RID: 5883 RVA: 0x0016B308 File Offset: 0x00169508
		public void getMailThread(long threadID, MailManager.GetMailThreadUIDelegate callback)
		{
			long num = -1L;
			int localCount = 0;
			if (this.storedThreads[threadID] != null)
			{
				MailThreadItem[] array = (MailThreadItem[])this.storedThreads[threadID];
				localCount = array.Length;
				MailThreadItem[] array2 = array;
				foreach (MailThreadItem mailThreadItem in array2)
				{
					if (mailThreadItem.mailID > num)
					{
						num = mailThreadItem.mailID;
					}
				}
			}
			this.getMailThreadCallback = callback;
			RemoteServices.Instance.set_GetMailThread_UserCallBack(new RemoteServices.GetMailThread_UserCallBack(this.mailThreadCallback));
			RemoteServices.Instance.GetMailThread(threadID, localCount, num);
		}

		// Token: 0x060016FC RID: 5884 RVA: 0x0016B39C File Offset: 0x0016959C
		private void mailThreadCallback(GetMailThread_ReturnType returnData)
		{
			if (returnData.Success && returnData.items != null)
			{
				if (returnData.items.Count > 0 && RemoteServices.Instance.UserOptions.profanityFilter)
				{
					foreach (MailThreadItem mailThreadItem in returnData.items)
					{
						mailThreadItem.body = GameEngine.Instance.censorString(mailThreadItem.body);
					}
				}
				if (this.storedThreads[returnData.threadID] == null)
				{
					List<MailThreadItem> list = new List<MailThreadItem>();
					list.AddRange(returnData.items);
					list.Sort(this.mailThreadComparer);
					this.storedThreads[returnData.threadID] = list.ToArray();
				}
				else
				{
					List<MailThreadItem> list2 = new List<MailThreadItem>();
					MailThreadItem[] collection = (MailThreadItem[])this.storedThreads[returnData.threadID];
					list2.AddRange(collection);
					list2.AddRange(returnData.items);
					list2.Sort(this.mailThreadComparer);
					this.storedThreads[returnData.threadID] = list2.ToArray();
				}
				this.saveMail();
			}
			this.getMailThreadCallback(returnData.threadID);
		}

		// Token: 0x060016FD RID: 5885 RVA: 0x0016B4EC File Offset: 0x001696EC
		public string getGroupString(long group)
		{
			if (group <= 5L && group >= 1L)
			{
				long num = group - 1L;
				long num2 = num;
				if (num2 <= 4L)
				{
					switch ((uint)num2)
					{
					case 0U:
						return SK.Text("MailScreen_Date_Yesterday", "Date: Yesterday");
					case 1U:
						return SK.Text("MailScreen_Date_Last_3_Days", "Date: Last 3 Days");
					case 2U:
						return SK.Text("MailScreen_Date_Last_7_Days", "Date: Last 7 Days");
					case 3U:
						return SK.Text("MailScreen_Date_Last_30_Days", "Date: Last 30 Days");
					case 4U:
						return SK.Text("MailScreen_Date_All", "Date: All");
					}
				}
			}
			return "";
		}

		// Token: 0x060016FE RID: 5886 RVA: 0x0016B584 File Offset: 0x00169784
		private void addBreakBars()
		{
			DateTime currentServerTime = VillageMap.getCurrentServerTime();
			MailThreadListItem mailThreadListItem = new MailThreadListItem();
			mailThreadListItem.mailThreadID = -1L;
			mailThreadListItem.mailTime = new DateTime(currentServerTime.Year, currentServerTime.Month, currentServerTime.Day, 0, 0, 1);
			this.storedThreadHeaders[-1] = mailThreadListItem;
			MailThreadListItem mailThreadListItem2 = new MailThreadListItem();
			mailThreadListItem2.mailThreadID = -2L;
			mailThreadListItem2.mailTime = new DateTime(currentServerTime.Year, currentServerTime.Month, currentServerTime.Day, 0, 0, 1).AddDays(-1.0);
			this.storedThreadHeaders[-2] = mailThreadListItem2;
			MailThreadListItem mailThreadListItem3 = new MailThreadListItem();
			mailThreadListItem3.mailThreadID = -3L;
			mailThreadListItem3.mailTime = new DateTime(currentServerTime.Year, currentServerTime.Month, currentServerTime.Day, 0, 0, 1).AddDays(-3.0);
			this.storedThreadHeaders[-3] = mailThreadListItem3;
			MailThreadListItem mailThreadListItem4 = new MailThreadListItem();
			mailThreadListItem4.mailThreadID = -4L;
			mailThreadListItem4.mailTime = new DateTime(currentServerTime.Year, currentServerTime.Month, currentServerTime.Day, 0, 0, 1).AddDays(-7.0);
			this.storedThreadHeaders[-4] = mailThreadListItem4;
		}

		// Token: 0x060016FF RID: 5887 RVA: 0x0016B6D0 File Offset: 0x001698D0
		public void mailThreadListCallback(GetMailThreadList_ReturnType returnData)
		{
			if (!returnData.Success)
			{
				return;
			}
			this.lastTimeThreadsReceived = returnData.currentSystemTime;
			if (returnData.items != null)
			{
				if (returnData.items.Count > 0 && RemoteServices.Instance.UserOptions.profanityFilter)
				{
					foreach (MailThreadListItem mailThreadListItem in returnData.items)
					{
						mailThreadListItem.subject = GameEngine.Instance.censorString(mailThreadListItem.subject);
					}
				}
				int count = returnData.items.Count;
				for (int i = 0; i < count; i++)
				{
					this.storedThreadHeaders[returnData.items[i].mailThreadID] = returnData.items[i];
				}
			}
			this.addBreakBars();
			this.preSortThreadHeaders();
			if (this.getMailThreadListDelegate != null)
			{
				this.getMailThreadListDelegate();
			}
			if (returnData.items != null)
			{
				this.saveMail();
			}
		}

		// Token: 0x06001700 RID: 5888 RVA: 0x0016B7E0 File Offset: 0x001699E0
		public void GetMailThreadList(bool initialRequest, int mode, MailManager.GenericUIDelegate uiDelegate)
		{
			this.getMailThreadListDelegate = uiDelegate;
			RemoteServices.Instance.set_GetMailThreadList_UserCallBack(new RemoteServices.GetMailThreadList_UserCallBack(this.mailThreadListCallback));
			RemoteServices.Instance.GetMailThreadList(initialRequest, mode, this.lastTimeThreadsReceived);
			if (mode >= 1)
			{
				this.downloadedYesterday = true;
			}
			if (mode >= 2)
			{
				this.downloaded3Days = true;
			}
			if (mode >= 3)
			{
				this.downloadedThisWeek = true;
			}
			if (mode >= 4)
			{
				this.downloadedThisMonth = true;
			}
			if (mode >= 5)
			{
				this.downloadedAll = true;
			}
		}

		// Token: 0x06001701 RID: 5889 RVA: 0x0001837B File Offset: 0x0001657B
		public void SetMailRead(long mailID)
		{
			RemoteServices.Instance.set_FlagMailRead_UserCallBack(new RemoteServices.FlagMailRead_UserCallBack(this.flagMailCallback));
			RemoteServices.Instance.FlagMailRead(mailID);
			this.saveMail();
		}

		// Token: 0x06001702 RID: 5890 RVA: 0x000183A4 File Offset: 0x000165A4
		public void SetThreadReadStatus(long threadID, bool read)
		{
			RemoteServices.Instance.set_FlagMailRead_UserCallBack(new RemoteServices.FlagMailRead_UserCallBack(this.flagMailCallback));
			if (read)
			{
				RemoteServices.Instance.FlagThreadRead(threadID);
				return;
			}
			RemoteServices.Instance.FlagThreadUnread(threadID);
		}

		// Token: 0x06001703 RID: 5891 RVA: 0x0016B854 File Offset: 0x00169A54
		private void flagMailCallback(FlagMailRead_ReturnType returnData)
		{
			if (!returnData.Success)
			{
				UniversalDebugLog.Log(string.Concat(new object[]
				{
					"Failed to mark mail read status error_code: ",
					returnData.m_errorCode,
					", error_id: ",
					returnData.m_errorID
				}));
			}
		}

		// Token: 0x06001704 RID: 5892 RVA: 0x0016B8A8 File Offset: 0x00169AA8
		public void updateSearch(string searchText, RemoteServices.GetMailUserSearch_UserCallBack getMailUserSearchCallback)
		{
			if (this.lastUpdateTime == 0.0)
			{
				return;
			}
			double currentMilliseconds = DXTimer.GetCurrentMilliseconds();
			if (currentMilliseconds - this.lastUpdateTime > 1000.0)
			{
				if (searchText.Length == 0)
				{
					this.lastUpdateTime = 0.0;
					return;
				}
				if (searchText.Length <= 4 && "lord".Contains(searchText.ToLower()))
				{
					this.lastUpdateTime = 0.0;
					return;
				}
				if (((searchText.Length == 1 || searchText.Length == 2) && currentMilliseconds - this.lastUpdateTime > 2000.0) || searchText.Length > 2)
				{
					this.lastUpdateTime = 0.0;
					RemoteServices.Instance.set_GetMailUserSearch_UserCallBack(getMailUserSearchCallback);
					RemoteServices.Instance.GetMailUserSearch(searchText);
				}
			}
		}

		// Token: 0x06001705 RID: 5893 RVA: 0x000183D6 File Offset: 0x000165D6
		public void resetUpdateTimer()
		{
			this.lastUpdateTime = DXTimer.GetCurrentMilliseconds();
		}

		// Token: 0x06001706 RID: 5894 RVA: 0x0016B97C File Offset: 0x00169B7C
		public void SendDraft(bool sendAsForward, RemoteServices.SendMail_UserCallBack onMailSentCallback)
		{
			UniversalDebugLog.Log("mail subject: " + this.CurrentDraft.Subject + " body: " + this.CurrentDraft.Body);
			UniversalDebugLog.Log("Thread: " + this.CurrentDraft.threadID.ToString() + " forward: " + sendAsForward.ToString());
			this.OnMailSent = onMailSentCallback;
			List<MailLink> targets = this.CurrentDraft.GetTargets();
			string subject = this.CurrentDraft.Subject;
			string body = this.CurrentDraft.Body + this.generateAttachmentsString(targets);
			string[] recipients = this.CurrentDraft.Recipients.GetRecipients();
			string[] array = recipients;
			foreach (string name in array)
			{
				this.AddNameToRecent(name);
			}
			RemoteServices.Instance.set_SendMail_UserCallBack(new RemoteServices.SendMail_UserCallBack(this.internalMailSentCallback));
			RemoteServices.Instance.SendMail(subject, body, recipients, this.CurrentDraft.threadID, sendAsForward);
			this.CurrentDraft.Sent = true;
		}

		// Token: 0x06001707 RID: 5895 RVA: 0x0016BA8C File Offset: 0x00169C8C
		public void SendMail(string subject, string body, string[] recipients, long threadID, bool sendAsForward, RemoteServices.SendMail_UserCallBack onMailSentCallback)
		{
			UniversalDebugLog.Log("mail subject: " + subject + " body: " + body);
			UniversalDebugLog.Log("Thread: " + threadID.ToString() + " forward: " + sendAsForward.ToString());
			this.OnMailSent = onMailSentCallback;
			RemoteServices.Instance.set_SendMail_UserCallBack(new RemoteServices.SendMail_UserCallBack(this.internalMailSentCallback));
			RemoteServices.Instance.SendMail(subject, body, recipients, threadID, sendAsForward);
		}

		// Token: 0x06001708 RID: 5896 RVA: 0x000183E3 File Offset: 0x000165E3
		public void SendProclamation(string subject, string body, int mailType, int area, RemoteServices.SendSpecialMail_UserCallBack onMailSentCallback)
		{
			this.OnSpecialMailSent = onMailSentCallback;
			RemoteServices.Instance.set_SendSpecialMail_UserCallBack(new RemoteServices.SendSpecialMail_UserCallBack(this.internalSpecialMailSentCallback));
			RemoteServices.Instance.SendSpecialMail(mailType, area, subject, body);
		}

		// Token: 0x06001709 RID: 5897 RVA: 0x00018412 File Offset: 0x00016612
		private void internalMailSentCallback(SendMail_ReturnType returnData)
		{
			if (returnData.Success)
			{
				this.CurrentDraft.ClearDraftMail();
				this.OnMailSent(returnData);
			}
		}

		// Token: 0x0600170A RID: 5898 RVA: 0x00018433 File Offset: 0x00016633
		private void internalSpecialMailSentCallback(SendSpecialMail_ReturnType returnData)
		{
			if (returnData.Success)
			{
				this.CurrentDraft.ClearDraftMail();
				this.OnSpecialMailSent(returnData);
			}
		}

		// Token: 0x0600170B RID: 5899 RVA: 0x00018454 File Offset: 0x00016654
		public void RemoveFolder(long folderID, MailManager.GenericUIDelegate uiCallback)
		{
			this.removeFolderUICallback = uiCallback;
			RemoteServices.Instance.set_RemoveMailFolder_UserCallBack(new RemoteServices.RemoveMailFolder_UserCallBack(this.removeMailFolderCallback));
			RemoteServices.Instance.RemoveMailFolder(folderID);
		}

		// Token: 0x0600170C RID: 5900 RVA: 0x0016BB00 File Offset: 0x00169D00
		private void removeMailFolderCallback(RemoveMailFolder_ReturnType returnData)
		{
			if (returnData.Success)
			{
				this.mailFolders.Clear();
				this.mailFolders.AddRange(returnData.folders);
				foreach (object obj in this.storedThreadHeaders)
				{
					MailThreadListItem mailThreadListItem = (MailThreadListItem)obj;
					if (mailThreadListItem.folderID == returnData.deletedFolderID)
					{
						mailThreadListItem.folderID = -1L;
					}
				}
				this.selectedFolderID = -1L;
				this.preSortThreadHeaders();
				if (this.removeFolderUICallback != null)
				{
					this.removeFolderUICallback();
				}
			}
		}

		// Token: 0x0600170D RID: 5901 RVA: 0x0001847E File Offset: 0x0001667E
		public void CreateFolder(string folderName, MailManager.GenericUIDelegate uiCallback)
		{
			this.createFolderUICallback = uiCallback;
			if (!this.DoesFolderAlreadyExist(folderName))
			{
				RemoteServices.Instance.set_CreateMailFolder_UserCallBack(new RemoteServices.CreateMailFolder_UserCallBack(this.createMailFolderCallback));
				RemoteServices.Instance.CreateMailFolder(folderName);
			}
		}

		// Token: 0x0600170E RID: 5902 RVA: 0x000184B1 File Offset: 0x000166B1
		private void createMailFolderCallback(CreateMailFolder_ReturnType returnData)
		{
			if (returnData.Success)
			{
				this.mailFolders.Clear();
				this.mailFolders.AddRange(returnData.folders);
				this.createFolderUICallback();
			}
		}

		// Token: 0x0600170F RID: 5903 RVA: 0x0016BBB0 File Offset: 0x00169DB0
		public void DeleteThreads(List<long> selectedMailThreadIDList)
		{
			foreach (long num in selectedMailThreadIDList)
			{
				RemoteServices.Instance.DeleteMailThread(num);
				Thread.Sleep(200);
				this.storedThreads[num] = null;
				this.storedThreadHeaders[num] = null;
			}
			this.saveMail();
			this.preSortThreadHeaders();
		}

		// Token: 0x06001710 RID: 5904 RVA: 0x0016BC34 File Offset: 0x00169E34
		public void MoveThreadsToFolder(List<long> threadIDs, long targetFolderID)
		{
			foreach (long num in threadIDs)
			{
				RemoteServices.Instance.MoveToMailFolder(num, targetFolderID);
				Thread.Sleep(200);
				MailThreadListItem mailThreadListItem = (MailThreadListItem)this.storedThreadHeaders[num];
				mailThreadListItem.folderID = targetFolderID;
			}
			this.saveMail();
		}

		// Token: 0x06001711 RID: 5905 RVA: 0x0016BCB0 File Offset: 0x00169EB0
		public void AddNameToFavourites(string name)
		{
			List<string> list = new List<string>();
			if (this.mailFavourites != null)
			{
				string[] array = this.mailFavourites;
				foreach (string text in array)
				{
					if (text == name)
					{
						return;
					}
					list.Add(text);
				}
			}
			list.Add(name);
			this.mailFavourites = list.ToArray();
			RemoteServices.Instance.AddUserToFavourites(name);
		}

		// Token: 0x06001712 RID: 5906 RVA: 0x0016BD18 File Offset: 0x00169F18
		public void RemoveNameFromFavourites(string name)
		{
			if (this.mailFavourites != null)
			{
				List<string> list = new List<string>(this.mailFavourites);
				if (list.Contains(name))
				{
					list.Remove(name);
					RemoteServices.Instance.RemoveUserFromFavourites(name);
				}
				this.mailFavourites = list.ToArray();
			}
		}

		// Token: 0x06001713 RID: 5907 RVA: 0x0016BD64 File Offset: 0x00169F64
		public void AddNameToRecent(string name)
		{
			List<string> list = new List<string>();
			if (this.mailUsersHistory != null)
			{
				string[] array = this.mailUsersHistory;
				foreach (string text in array)
				{
					if (text == name)
					{
						return;
					}
					list.Add(text);
				}
			}
			list.Add(name);
			this.mailUsersHistory = list.ToArray();
		}

		// Token: 0x06001714 RID: 5908 RVA: 0x0016BDC4 File Offset: 0x00169FC4
		public void clearStoredMail()
		{
			this.m_storedThreadHeaders = new SparseArray();
			this.m_storedThreads = new SparseArray();
			this.initialRequest = true;
			this.gotFolders = false;
			this.downloadedYesterday = false;
			this.downloaded3Days = false;
			this.downloadedThisWeek = false;
			this.downloadedThisMonth = false;
			this.downloadedAll = false;
			this.lastTimeThreadsReceived = DateTime.Now.AddYears(-50);
		}

		// Token: 0x06001715 RID: 5909 RVA: 0x000184E2 File Offset: 0x000166E2
		public void logout()
		{
			this.gotFolders = false;
			this.initialRequest = true;
		}

		// Token: 0x06001716 RID: 5910 RVA: 0x0016BE30 File Offset: 0x0016A030
		public void preSortThreadHeaders()
		{
			this.m_preSortedHeaders.Clear();
			foreach (object obj in this.m_storedThreadHeaders)
			{
				MailThreadListItem mailThreadListItem = (MailThreadListItem)obj;
				if (mailThreadListItem.folderID == this.selectedFolderID || mailThreadListItem.mailThreadID < 0L)
				{
					this.m_preSortedHeaders.Add(mailThreadListItem);
				}
			}
			this.m_preSortedHeaders.Sort(this.mailThreadHeaderComparer);
			this.m_preSortedALLHeader.Clear();
			foreach (MailThreadListItem item in this.m_preSortedHeaders)
			{
				this.m_preSortedALLHeader.Add(item);
			}
			DateTime currentServerTime = VillageMap.getCurrentServerTime();
			DateTime t = new DateTime(currentServerTime.Year, currentServerTime.Month, currentServerTime.Day, 0, 0, 1);
			DateTime t2 = new DateTime(currentServerTime.Year, currentServerTime.Month, currentServerTime.Day, 0, 0, 1).AddDays(-1.0);
			DateTime t3 = new DateTime(currentServerTime.Year, currentServerTime.Month, currentServerTime.Day, 0, 0, 1).AddDays(-3.0);
			DateTime t4 = new DateTime(currentServerTime.Year, currentServerTime.Month, currentServerTime.Day, 0, 0, 1).AddDays(-7.0);
			DateTime t5 = new DateTime(currentServerTime.Year, currentServerTime.Month, currentServerTime.Day, 0, 0, 1).AddYears(-50);
			List<MailThreadListItem> list = new List<MailThreadListItem>();
			if (!this.openYesterday)
			{
				foreach (MailThreadListItem mailThreadListItem2 in this.m_preSortedHeaders)
				{
					if (mailThreadListItem2.mailThreadID >= 0L && mailThreadListItem2.mailTime < t && mailThreadListItem2.mailTime > t2)
					{
						list.Add(mailThreadListItem2);
					}
				}
			}
			if (!this.open3Days)
			{
				foreach (MailThreadListItem mailThreadListItem3 in this.m_preSortedHeaders)
				{
					if (mailThreadListItem3.mailThreadID >= 0L && mailThreadListItem3.mailTime < t2 && mailThreadListItem3.mailTime > t3)
					{
						list.Add(mailThreadListItem3);
					}
				}
			}
			if (!this.openThisWeek)
			{
				foreach (MailThreadListItem mailThreadListItem4 in this.m_preSortedHeaders)
				{
					if (mailThreadListItem4.mailThreadID >= 0L && mailThreadListItem4.mailTime < t3 && mailThreadListItem4.mailTime > t4)
					{
						list.Add(mailThreadListItem4);
					}
				}
			}
			if (!this.openThisMonth)
			{
				foreach (MailThreadListItem mailThreadListItem5 in this.m_preSortedHeaders)
				{
					if (mailThreadListItem5.mailThreadID >= 0L && mailThreadListItem5.mailTime < t4 && mailThreadListItem5.mailTime > t5)
					{
						list.Add(mailThreadListItem5);
					}
				}
			}
			foreach (MailThreadListItem item2 in list)
			{
				this.m_preSortedHeaders.Remove(item2);
			}
		}

		// Token: 0x06001717 RID: 5911 RVA: 0x0016C230 File Offset: 0x0016A430
		public static string getDateRangeDescription(int groupID)
		{
			switch (groupID)
			{
			case 1:
				return "Yesterday";
			case 2:
				return "3 days";
			case 3:
				return "7 days";
			case 4:
				return "30 days";
			case 5:
				return "All";
			default:
				return "None";
			}
		}

		// Token: 0x06001718 RID: 5912 RVA: 0x0016C280 File Offset: 0x0016A480
		public void loadMail()
		{
			int userID = RemoteServices.Instance.UserID;
			string settingsPath = GameEngine.getSettingsPath(false);
			FileStream fileStream = null;
			BinaryReader binaryReader = null;
			try
			{
				fileStream = new FileStream(string.Concat(new string[]
				{
					settingsPath,
					"\\MailData-",
					userID.ToString(),
					"-",
					GameEngine.Instance.World.GetGlobalWorldID().ToString(),
					".dat"
				}), FileMode.Open, FileAccess.Read);
				binaryReader = new BinaryReader(fileStream);
				SparseArray sparseArray = new SparseArray();
				SparseArray sparseArray2 = new SparseArray();
				long ticks = binaryReader.ReadInt64();
				int num = binaryReader.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					long num2 = binaryReader.ReadInt64();
					if (num2 >= 0L)
					{
						MailThreadListItem mailThreadListItem = new MailThreadListItem();
						mailThreadListItem.mailThreadID = num2;
						mailThreadListItem.folderID = binaryReader.ReadInt64();
						long ticks2 = binaryReader.ReadInt64();
						mailThreadListItem.mailTime = new DateTime(ticks2);
						mailThreadListItem.mailTimeAsDouble = binaryReader.ReadDouble();
						int num3 = binaryReader.ReadInt32();
						if (num3 > 0)
						{
							List<string> list = new List<string>();
							for (int j = 0; j < num3; j++)
							{
								string item = binaryReader.ReadString();
								list.Add(item);
							}
							mailThreadListItem.otherUser = list.ToArray();
						}
						else
						{
							mailThreadListItem.otherUser = new string[0];
						}
						mailThreadListItem.readStatus = binaryReader.ReadBoolean();
						mailThreadListItem.subject = binaryReader.ReadString();
						int num4 = binaryReader.ReadInt32();
						if (num4 == -5)
						{
							mailThreadListItem.readOnly = binaryReader.ReadBoolean();
							mailThreadListItem.specialType = binaryReader.ReadInt32();
							mailThreadListItem.specialArea = binaryReader.ReadInt32();
							num4 = binaryReader.ReadInt32();
						}
						List<MailThreadItem> list2 = new List<MailThreadItem>();
						bool flag = false;
						DateTime t = DateTime.MaxValue;
						for (int k = 0; k < num4; k++)
						{
							MailThreadItem mailThreadItem = new MailThreadItem();
							mailThreadItem.body = binaryReader.ReadString();
							mailThreadItem.mailID = binaryReader.ReadInt64();
							long ticks3 = binaryReader.ReadInt64();
							mailThreadItem.mailTime = new DateTime(ticks3);
							mailThreadItem.mailTimeAsDouble = binaryReader.ReadDouble();
							mailThreadItem.otherUser = binaryReader.ReadString();
							mailThreadItem.otherUserID = binaryReader.ReadInt32();
							mailThreadItem.readStatus = binaryReader.ReadBoolean();
							list2.Add(mailThreadItem);
							if (mailThreadItem.mailTime > t)
							{
								flag = true;
							}
							else
							{
								t = mailThreadItem.mailTime;
							}
						}
						if (num4 > 0)
						{
							if (flag)
							{
								list2.Sort(this.mailThreadComparer);
							}
							sparseArray[mailThreadListItem.mailThreadID] = list2.ToArray();
						}
						sparseArray2[mailThreadListItem.mailThreadID] = mailThreadListItem;
					}
				}
				binaryReader.Close();
				fileStream.Close();
				this.m_storedThreadHeaders = sparseArray2;
				this.m_storedThreads = sparseArray;
				this.lastTimeThreadsReceived = new DateTime(ticks);
			}
			catch (Exception)
			{
				try
				{
					if (binaryReader != null)
					{
						binaryReader.Close();
					}
				}
				catch (Exception)
				{
				}
				try
				{
					if (fileStream != null)
					{
						fileStream.Close();
					}
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x06001719 RID: 5913 RVA: 0x0016C5BC File Offset: 0x0016A7BC
		public void saveMail()
		{
			int userID = RemoteServices.Instance.UserID;
			string settingsPath = GameEngine.getSettingsPath(true);
			try
			{
				FileInfo fileInfo = new FileInfo(string.Concat(new string[]
				{
					settingsPath,
					"\\MailData-",
					userID.ToString(),
					"-",
					GameEngine.Instance.World.GetGlobalWorldID().ToString(),
					".dat"
				}));
				fileInfo.IsReadOnly = false;
			}
			catch (Exception)
			{
			}
			FileStream fileStream = null;
			BinaryWriter binaryWriter = null;
			try
			{
				fileStream = new FileStream(string.Concat(new string[]
				{
					settingsPath,
					"\\MailData-",
					userID.ToString(),
					"-",
					GameEngine.Instance.World.GetGlobalWorldID().ToString(),
					".dat"
				}), FileMode.Create);
				binaryWriter = new BinaryWriter(fileStream);
				binaryWriter.Write(this.lastTimeThreadsReceived.Ticks);
				int count = this.m_storedThreadHeaders.Count;
				binaryWriter.Write(count);
				foreach (object obj in this.m_storedThreadHeaders)
				{
					MailThreadListItem mailThreadListItem = (MailThreadListItem)obj;
					binaryWriter.Write(mailThreadListItem.mailThreadID);
					if (mailThreadListItem.mailThreadID >= 0L)
					{
						binaryWriter.Write(mailThreadListItem.folderID);
						binaryWriter.Write(mailThreadListItem.mailTime.Ticks);
						binaryWriter.Write(mailThreadListItem.mailTimeAsDouble);
						int value = 0;
						if (mailThreadListItem.otherUser != null)
						{
							value = mailThreadListItem.otherUser.Length;
						}
						binaryWriter.Write(value);
						if (mailThreadListItem.otherUser != null)
						{
							string[] otherUser = mailThreadListItem.otherUser;
							foreach (string value2 in otherUser)
							{
								binaryWriter.Write(value2);
							}
						}
						binaryWriter.Write(mailThreadListItem.readStatus);
						binaryWriter.Write(mailThreadListItem.subject);
						int value3 = -5;
						binaryWriter.Write(value3);
						binaryWriter.Write(mailThreadListItem.readOnly);
						binaryWriter.Write(mailThreadListItem.specialType);
						binaryWriter.Write(mailThreadListItem.specialArea);
						MailThreadItem[] array2 = (MailThreadItem[])this.m_storedThreads[mailThreadListItem.mailThreadID];
						if (array2 == null)
						{
							int value4 = 0;
							binaryWriter.Write(value4);
						}
						else
						{
							int value5 = array2.Length;
							binaryWriter.Write(value5);
							MailThreadItem[] array3 = array2;
							foreach (MailThreadItem mailThreadItem in array3)
							{
								binaryWriter.Write(mailThreadItem.body);
								binaryWriter.Write(mailThreadItem.mailID);
								binaryWriter.Write(mailThreadItem.mailTime.Ticks);
								binaryWriter.Write(mailThreadItem.mailTimeAsDouble);
								binaryWriter.Write(mailThreadItem.otherUser);
								binaryWriter.Write(mailThreadItem.otherUserID);
								binaryWriter.Write(mailThreadItem.readStatus);
							}
						}
					}
				}
				binaryWriter.Close();
				fileStream.Close();
			}
			catch (Exception ex)
			{
				try
				{
					if (binaryWriter != null)
					{
						binaryWriter.Close();
					}
				}
				catch (Exception)
				{
				}
				try
				{
					if (fileStream != null)
					{
						fileStream.Close();
					}
				}
				catch (Exception)
				{
				}
				MyMessageBox.Show(SK.Text("MailScreen_Saving_Problem", "A problem occurred saving 'MailData.data'") + "\n\n" + ex.ToString(), SK.Text("WorldMapLoader_DataSaveError_Header", "Data Save Error"));
			}
		}

		// Token: 0x0600171A RID: 5914 RVA: 0x000184F2 File Offset: 0x000166F2
		public bool IsBlocked(string user)
		{
			return this.blockedList != null && this.blockedList.Contains(user);
		}

		// Token: 0x0600171B RID: 5915 RVA: 0x0016C98C File Offset: 0x0016AB8C
		public List<string> getBlockedList()
		{
			List<string> list = new List<string>();
			list.AddRange(this.blockedList);
			return list;
		}

		// Token: 0x0600171C RID: 5916 RVA: 0x0001850A File Offset: 0x0001670A
		public void updateBlockedList(List<string> newList)
		{
			this.blockedList.Clear();
			this.blockedList.AddRange(newList);
			this.blockListChanged = true;
			this.saveBlockedList();
		}

		// Token: 0x0600171D RID: 5917 RVA: 0x0016C9AC File Offset: 0x0016ABAC
		public void loadBlockedList()
		{
			int userID = RemoteServices.Instance.UserID;
			string settingsPath = GameEngine.getSettingsPath(false);
			FileStream fileStream = null;
			BinaryReader binaryReader = null;
			this.blockedList.Clear();
			this.aggressiveBlocking = false;
			try
			{
				fileStream = new FileStream(settingsPath + "\\MailBlockList-" + userID.ToString() + ".dat", FileMode.Open, FileAccess.Read);
				binaryReader = new BinaryReader(fileStream);
				new SparseArray();
				new SparseArray();
				int num = binaryReader.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					string item = binaryReader.ReadString();
					this.blockedList.Add(item);
				}
				try
				{
					this.aggressiveBlocking = binaryReader.ReadBoolean();
				}
				catch (Exception)
				{
				}
				binaryReader.Close();
				fileStream.Close();
			}
			catch (Exception)
			{
				try
				{
					if (binaryReader != null)
					{
						binaryReader.Close();
					}
				}
				catch (Exception)
				{
				}
				try
				{
					if (fileStream != null)
					{
						fileStream.Close();
					}
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x0600171E RID: 5918 RVA: 0x0016CAB8 File Offset: 0x0016ACB8
		public void saveBlockedList()
		{
			int userID = RemoteServices.Instance.UserID;
			string settingsPath = GameEngine.getSettingsPath(true);
			try
			{
				FileInfo fileInfo = new FileInfo(settingsPath + "\\MailBlockList-" + userID.ToString() + ".dat");
				fileInfo.IsReadOnly = false;
			}
			catch (Exception)
			{
			}
			FileStream fileStream = null;
			BinaryWriter binaryWriter = null;
			try
			{
				fileStream = new FileStream(settingsPath + "\\MailBlockList-" + userID.ToString() + ".dat", FileMode.Create);
				binaryWriter = new BinaryWriter(fileStream);
				int count = this.blockedList.Count;
				binaryWriter.Write(count);
				foreach (string value in this.blockedList)
				{
					binaryWriter.Write(value);
				}
				binaryWriter.Write(this.aggressiveBlocking);
				binaryWriter.Close();
				fileStream.Close();
			}
			catch (Exception)
			{
				try
				{
					if (binaryWriter != null)
					{
						binaryWriter.Close();
					}
				}
				catch (Exception)
				{
				}
				try
				{
					if (fileStream != null)
					{
						fileStream.Close();
					}
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x0600171F RID: 5919 RVA: 0x0016CBF4 File Offset: 0x0016ADF4
		public bool DoesFolderAlreadyExist(string folderName)
		{
			if (folderName.Length == 0)
			{
				return true;
			}
			foreach (MailFolderItem mailFolderItem in this.mailFolders)
			{
				if (string.Compare(mailFolderItem.title, folderName, true) == 0)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06001720 RID: 5920 RVA: 0x0016CC60 File Offset: 0x0016AE60
		public string GetFolderName(long folderID)
		{
			if (folderID == -1L)
			{
				return SK.Text("MailScreen_Inbox", "Inbox");
			}
			foreach (MailFolderItem mailFolderItem in this.mailFolders)
			{
				if (mailFolderItem.mailFolderID == folderID)
				{
					return mailFolderItem.title;
				}
			}
			return "?";
		}

		// Token: 0x06001721 RID: 5921 RVA: 0x0016CCDC File Offset: 0x0016AEDC
		public string generateAttachmentsString(List<MailLink> linkList)
		{
			if (linkList.Count == 0)
			{
				return "";
			}
			string text = "<!attch!>";
			foreach (MailLink mailLink in linkList)
			{
				text = text + mailLink.linkType.ToString() + "#";
				text = text + mailLink.objectName + "#";
				text += mailLink.objectID.ToString();
				text += "%";
			}
			return text;
		}

		// Token: 0x06001722 RID: 5922 RVA: 0x0016CD80 File Offset: 0x0016AF80
		public List<MailLink> parseAttachmentString(string bodyText)
		{
			string[] array = new string[]
			{
				"<!attch!>"
			};
			string[] array2 = bodyText.Split(array, StringSplitOptions.RemoveEmptyEntries);
			List<MailLink> list = new List<MailLink>();
			if (array2.Length > 1 || bodyText.IndexOf(array[0]) == 0)
			{
				try
				{
					char[] separator = new char[]
					{
						'%'
					};
					string[] array3 = array2[array2.Length - 1].Split(separator);
					string[] array4 = array3;
					foreach (string text in array4)
					{
						if (!(text == ""))
						{
							MailLink mailLink = this.parseAttachment(text);
							if (mailLink.linkType != 4 && mailLink != null)
							{
								list.Add(mailLink);
							}
						}
					}
					return list;
				}
				catch
				{
					return list;
				}
				return list;
			}
			return list;
		}

		// Token: 0x06001723 RID: 5923 RVA: 0x0016CE48 File Offset: 0x0016B048
		private string getSpecialSubjectLine(MailThreadListItem item, string subject)
		{
			switch (item.specialType)
			{
			case 1:
				subject = MailManager.languageSplitString(item.subject);
				break;
			case 2:
				subject = SK.Text("MailScreen_House_Proclamation", "House Proclamation");
				break;
			case 3:
				subject = "";
				break;
			case 4:
				subject = SK.Text("MailScreen_Parish_Proclamation", "Parish Proclamation") + " : " + GameEngine.Instance.World.getParishName(item.specialArea);
				break;
			case 5:
				subject = SK.Text("MailScreen_County_Proclamation", "County Proclamation") + " : " + GameEngine.Instance.World.getCountyName(item.specialArea);
				break;
			case 6:
				subject = SK.Text("MailScreen_Province_Proclamation", "Province Proclamation") + " : " + GameEngine.Instance.World.getProvinceName(item.specialArea);
				break;
			case 7:
				subject = SK.Text("MailScreen_Country_Proclamation", "Country Proclamation") + " : " + GameEngine.Instance.World.getCountryName(item.specialArea);
				break;
			}
			return subject;
		}

		// Token: 0x06001724 RID: 5924 RVA: 0x0016CF84 File Offset: 0x0016B184
		public string GetSubject(MailThreadListItem item)
		{
			string text = item.subject;
			if (item.readOnly)
			{
				text = this.getSpecialSubjectLine(item, text);
			}
			return GameEngine.Instance.censorString(text);
		}

		// Token: 0x06001725 RID: 5925 RVA: 0x0016CFB4 File Offset: 0x0016B1B4
		public string getBodyTextFromString(string bodyText)
		{
			string[] array = new string[]
			{
				"<!attch!>"
			};
			string[] array2 = bodyText.Split(array, StringSplitOptions.RemoveEmptyEntries);
			if (array2.Length > 1)
			{
				return array2[0];
			}
			if (bodyText.IndexOf(array[0]) == 0)
			{
				return "";
			}
			return bodyText;
		}

		// Token: 0x06001726 RID: 5926 RVA: 0x0016CFF8 File Offset: 0x0016B1F8
		public bool stringContainsAttachments(string bodyText)
		{
			List<MailLink> list = this.parseAttachmentString(bodyText);
			return list.Count > 0;
		}

		// Token: 0x06001727 RID: 5927 RVA: 0x0016D018 File Offset: 0x0016B218
		private MailLink parseAttachment(string attString)
		{
			char[] separator = new char[]
			{
				'#'
			};
			string[] array = attString.Split(separator);
			if (array.Length != 0)
			{
				try
				{
					MailLink mailLink = new MailLink();
					mailLink.linkType = Convert.ToInt32(array[0]);
					mailLink.objectName = array[1];
					if (array.Length > 2)
					{
						mailLink.objectID = Convert.ToInt32(array[2]);
					}
					return mailLink;
				}
				catch (Exception)
				{
				}
			}
			return null;
		}

		// Token: 0x06001728 RID: 5928 RVA: 0x0016D088 File Offset: 0x0016B288
		public static string languageSplitString(string str)
		{
			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
			string[] array = str.Split(new char[]
			{
				'§'
			});
			Thread.CurrentThread.CurrentCulture = CultureInfo.InstalledUICulture;
			if (array.Length == 0)
			{
				return str;
			}
			string text = Program.mySettings.LanguageIdent.ToLower();
			string text2 = "";
			if (text != null)
			{
				uint num = PrivateImplementationDetails.ComputeStringHash(text);
				if (num <= 1195724803U)
				{
					if (num <= 1164435231U)
					{
						if (num != 1111292255U)
						{
							if (num != 1162757945U)
							{
								if (num == 1164435231U)
								{
									if (text == "zh")
									{
										if (array.Length >= 11)
										{
											text2 = array[10];
											goto IL_2A6;
										}
										goto IL_2A6;
									}
								}
							}
							else if (text == "pl")
							{
								if (array.Length >= 6)
								{
									text2 = array[5];
									goto IL_2A6;
								}
								goto IL_2A6;
							}
						}
						else if (text == "ko")
						{
							if (array.Length >= 12)
							{
								text2 = array[11];
								goto IL_2A6;
							}
							goto IL_2A6;
						}
					}
					else if (num != 1176137065U)
					{
						if (num != 1194886160U)
						{
							if (num == 1195724803U)
							{
								if (text == "tr")
								{
									if (array.Length >= 9)
									{
										text2 = array[8];
										goto IL_2A6;
									}
									goto IL_2A6;
								}
							}
						}
						else if (text == "it")
						{
							if (array.Length >= 8)
							{
								text2 = array[7];
								goto IL_2A6;
							}
							goto IL_2A6;
						}
					}
					else if (text == "es")
					{
						if (array.Length >= 5)
						{
							text2 = array[4];
							goto IL_2A6;
						}
						goto IL_2A6;
					}
				}
				else if (num <= 1461901041U)
				{
					if (num != 1213488160U)
					{
						if (num != 1241987482U)
						{
							if (num == 1461901041U)
							{
								if (text == "fr")
								{
									if (array.Length >= 3)
									{
										text2 = array[2];
										goto IL_2A6;
									}
									goto IL_2A6;
								}
							}
						}
						else if (text == "zhhk")
						{
							if (array.Length >= 10)
							{
								text2 = array[9];
								goto IL_2A6;
							}
							goto IL_2A6;
						}
					}
					else if (text == "ru")
					{
						if (array.Length >= 4)
						{
							text2 = array[3];
							goto IL_2A6;
						}
						goto IL_2A6;
					}
				}
				else if (num != 1545391778U)
				{
					if (num != 1564435063U)
					{
						if (num == 1565420801U)
						{
							if (text == "pt")
							{
								if (array.Length >= 7)
								{
									text2 = array[6];
									goto IL_2A6;
								}
								goto IL_2A6;
							}
						}
					}
					else if (text == "jp")
					{
						if (array.Length >= 13)
						{
							text2 = array[12];
							goto IL_2A6;
						}
						if (array.Length >= 1)
						{
							text2 = array[0];
							goto IL_2A6;
						}
						goto IL_2A6;
					}
				}
				else if (text == "de")
				{
					if (array.Length >= 2)
					{
						text2 = array[1];
						goto IL_2A6;
					}
					goto IL_2A6;
				}
			}
			if (array.Length >= 1)
			{
				text2 = array[0];
			}
			IL_2A6:
			if (text2.Length > 30 && array.Length > 1 && text == "jp")
			{
				if (text2.Substring(0, 24) == "Settled in nicely, Sire?")
				{
					return string.Concat(new string[]
					{
						"?????????????????????????????????????????????????????????!",
						Environment.NewLine,
						Environment.NewLine,
						"???????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????!????????????…",
						Environment.NewLine,
						Environment.NewLine,
						"?????????????????????????????????????????????????????????????????????????????????!",
						Environment.NewLine,
						Environment.NewLine,
						"?????????????????????????????????????????????????????????????????????????????????????????????????????????",
						Environment.NewLine,
						Environment.NewLine,
						"??????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????!??????????????????????????????!",
						Environment.NewLine,
						Environment.NewLine,
						"????????????????????????????????????????????!???????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????",
						Environment.NewLine,
						Environment.NewLine,
						"?????????????????????????????????????????????????????????????????????????????????????????????",
						Environment.NewLine,
						Environment.NewLine,
						"????????…??????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????",
						Environment.NewLine,
						Environment.NewLine,
						"???????????????????????????????????????????????????????????????????????????????????????????????",
						Environment.NewLine,
						Environment.NewLine,
						"???????????",
						Environment.NewLine,
						"The Kingdoms Team"
					});
				}
				if (text2.Substring(0, 17) == "Good day My Lord,")
				{
					return string.Concat(new string[]
					{
						"????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????10????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????…",
						Environment.NewLine,
						Environment.NewLine,
						"Domination ??????????????????????????????????????:",
						Environment.NewLine,
						Environment.NewLine,
						"1. ???????/????",
						Environment.NewLine,
						"2. ?????????????????4?",
						Environment.NewLine,
						"3. ??????????",
						Environment.NewLine,
						"4. ?????91???????????",
						Environment.NewLine,
						"5. ??????????????????????????????????????????????? ",
						Environment.NewLine,
						"6. ????????3????????????????????????????????????",
						Environment.NewLine,
						"7. ??????2??????????",
						Environment.NewLine,
						"8. ??????????2?",
						Environment.NewLine,
						"9. ???????????????????(12)??? ",
						Environment.NewLine,
						"10. ????????????5???3????",
						Environment.NewLine,
						"11. ???????????????????????????(?????????)",
						Environment.NewLine,
						"12. ?????????????????",
						Environment.NewLine,
						"13. ???????????",
						Environment.NewLine,
						"14. ????????3?????????????9??50??????????????????2?",
						Environment.NewLine,
						"15. ??????????????????????????????????????????????100?????????",
						Environment.NewLine,
						"16. ?????????2??????24????????12?????????",
						Environment.NewLine,
						"17. ????????????????",
						Environment.NewLine,
						"18. 15?????????????????30?????????????????",
						Environment.NewLine,
						Environment.NewLine,
						"???????????Domination ???????????????????????????????????????????????",
						Environment.NewLine,
						Environment.NewLine,
						"???????!"
					});
				}
				if (text2.Substring(0, 26) == "Here are a few suggestions")
				{
					return string.Concat(new string[]
					{
						"???????????????",
						Environment.NewLine,
						Environment.NewLine,
						"?????????????????150??????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????",
						Environment.NewLine,
						Environment.NewLine,
						Environment.NewLine,
						"??????",
						Environment.NewLine,
						Environment.NewLine,
						"??????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????200???????????????????????????????????????????????32???????????????????????!?????????????????????????????????????????",
						Environment.NewLine,
						Environment.NewLine,
						Environment.NewLine,
						"?????????????",
						Environment.NewLine,
						Environment.NewLine,
						"??????????????????????????????????????????????????$80?????????????????????1????????1500??????????????????????????? ?????????????",
						Environment.NewLine,
						Environment.NewLine,
						Environment.NewLine,
						"?????",
						Environment.NewLine,
						Environment.NewLine,
						"????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????",
						Environment.NewLine,
						Environment.NewLine,
						Environment.NewLine,
						"?????????",
						Environment.NewLine,
						Environment.NewLine,
						"?????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????",
						Environment.NewLine,
						Environment.NewLine,
						Environment.NewLine,
						"????????????",
						Environment.NewLine,
						Environment.NewLine,
						"????????????2??",
						Environment.NewLine,
						Environment.NewLine,
						"??????????????????????????????????????????????????????????????????????????????????????2?? ???????????????????????????????????????????????????????????????",
						Environment.NewLine,
						Environment.NewLine,
						Environment.NewLine,
						"?????????",
						Environment.NewLine,
						Environment.NewLine,
						"???????????????????????????????????????????????????????????????????????????????????????????????????????????????????-????????????????????????????????????????????????????????????????????????????????????????????????????",
						Environment.NewLine,
						Environment.NewLine,
						Environment.NewLine,
						"??????????????????",
						Environment.NewLine,
						Environment.NewLine,
						"The Kingdoms Team"
					});
				}
			}
			if (text2.Length == 4 && array.Length > 1 && text2[0] == '<' && text2[3] == '>')
			{
				char c = text2[1];
				char c2 = text2[2];
				switch (c)
				{
				case '2':
					return string.Concat(new string[]
					{
						SK.Text("WorldSelect_2ndEra_Mail_01", "I must congratulate you Sire, for you have made it to the end of the First Era still standing! My Lord has faced great adversity, but now the air about you is positively regal! Your intelligence, beauty and strength remain intact and you will need all these things for the road ahead..."),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("WorldSelect_2ndEra_Mail_02", "The Second Era of Stronghold Kingdoms is upon us with new challenges. Prepare yourself for added layers of strategy and complexity, testing the skills of even the most veteran players!"),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("WorldSelect_2ndEra_Mail_03", "These changes are now in effect:"),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("WorldSelect_2ndEra_Mail_04", "1. Armies, scouts, and monks move at increased speed."),
						Environment.NewLine,
						SK.Text("WorldSelect_2ndEra_Mail_05", "2. Goods have been cleared from all Markets, with prices reset to their starting levels."),
						Environment.NewLine,
						SK.Text("WorldSelect_2ndEra_Mail_06", "3. The Faith Point cost for Interdiction and Excommunication has increased."),
						Environment.NewLine,
						SK.Text("WorldSelect_2ndEra_Mail_07", "4. Votes and officers in all capitals have been cleared and the Glory Race has restarted."),
						Environment.NewLine,
						SK.Text("WorldSelect_2ndEra_Mail_08", "5. More Glory is earned for holding territory."),
						Environment.NewLine,
						SK.Text("WorldSelect_2ndEra_Mail_09", "6. Monks can influence voting at the county level."),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("WorldSelect_2ndEra_Mail_10", "For the skilled strategist there is much to gain, all members of the house to win this Era will be rewarded with five wheel spins!"),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("WorldSelect_Era_Mail_Good_Luck", "Good luck!")
					});
				case '3':
					return string.Concat(new string[]
					{
						SK.Text("WorldSelect_3rdEra_Mail_01", "Sire, the Third Era awaits! This exciting Era is designed to increase the pace of gameplay and give players more freedom to extend their power and influence within the world..."),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("WorldSelect_3rdEra_Mail_02", "These changes are now in effect:"),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("WorldSelect_3rdEra_Mail_03", "1. Armies, scouts, and monks move at increased speed."),
						Environment.NewLine,
						SK.Text("WorldSelect_3rdEra_Mail_04", "2. Goods have been cleared from all Markets, with prices reset to their starting levels."),
						Environment.NewLine,
						SK.Text("WorldSelect_3rdEra_Mail_05", "3. The Faith Point cost for Interdiction and Excommunication has increased."),
						Environment.NewLine,
						SK.Text("WorldSelect_3rdEra_Mail_06", "4. Votes and officers in all capitals have been cleared and the Glory Race has restarted."),
						Environment.NewLine,
						SK.Text("WorldSelect_3rdEra_Mail_07", "5. More Glory is earned for holding territory."),
						Environment.NewLine,
						SK.Text("WorldSelect_3rdEra_Mail_08", "6. Crown Princes may now access up to 30 villages."),
						Environment.NewLine,
						SK.Text("WorldSelect_3rdEra_Mail_09", "7. Honour production has been increased for Banqueting and for Popularity."),
						Environment.NewLine,
						SK.Text("WorldSelect_3rdEra_Mail_00", "8. Honor received from destroying hostile AI castles has been increased."),
						Environment.NewLine,
						SK.Text("WorldSelect_3rdEra_Mail_11", "9. Certain upgradeable parish buildings can now gain additional levels."),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("WorldSelect_3rdEra_Mail_12", "For the skilled strategist there is much to gain, all members of the house to win this Era will be rewarded with five wheel spins!"),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("WorldSelect_Era_Mail_Good_Luck", "Good luck!")
					});
				case '4':
					return string.Concat(new string[]
					{
						SK.Text("WorldSelect_4thEra_Mail_01", "My Liege! How glad I am to see you in one piece. The brutal Third Era brought with it higher caps for villages, increased Honour production and more, however my spies tell me the Fourth Era is not quite what we were expecting… Although there are similarities, such as an increased village cap, there is also much to learn. "),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("WorldSelect_4thEra_Mail_02", "These changes are now in effect:"),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("WorldSelect_4thEra_Mail_03", "1. Armies, scouts, and monks move at increased speed."),
						Environment.NewLine,
						SK.Text("WorldSelect_4thEra_Mail_04", "2. Goods have been cleared from all Markets, with prices reset to their starting levels."),
						Environment.NewLine,
						SK.Text("WorldSelect_4thEra_Mail_05", "3. The Faith Point cost for Interdiction and Excommunication has increased."),
						Environment.NewLine,
						SK.Text("WorldSelect_4thEra_Mail_06", "4. Votes and officers in all capitals have been cleared and the Glory Race has restarted."),
						Environment.NewLine,
						SK.Text("WorldSelect_4thEra_Mail_07", "5. Crown Princes may now own up to 40 villages."),
						Environment.NewLine,
						SK.Text("WorldSelect_4thEra_Mail_08", "6. A Military School can be built in a parish, which gives access to Bombards."),
						Environment.NewLine,
						SK.Text("WorldSelect_4thEra_Mail_09", "7. Certain upgradable Parish buildings can now gain 5 additional levels."),
						Environment.NewLine,
						SK.Text("WorldSelect_4thEra_Mail_10", "8. Players who own more than 10 villages will no longer have to pay the extra honour cost to regain a village, if one of their villages is lost."),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("WorldSelect_4thEra_Mail_11", "As you can see my Lord, the Fourth Era may prove challenging. However, I believe there is much to gain and this new weapon is quite intriguing!"),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("WorldSelect_4thEra_Mail_12", "For the skilled strategist there is much to gain, all members of the house to win this Era will be rewarded with five wheel spins!"),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("WorldSelect_Era_Mail_Good_Luck", "Good luck!")
					});
				case '5':
					return string.Concat(new string[]
					{
						SK.Text("WorldSelect_5thEra_Mail_01", "Greetings Sire!  It is good to see you have made it through the trials of the Fourth Era and ready to face the challenges that the Fifth Era brings!  Hopefully you have brought many loyal friends and staunch allies along with you in to this new era as well, for you will need them if you are to succeed!"),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("WorldSelect_5thEra_Mail_02", "These changes are now in effect:"),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("WorldSelect_5thEra_Mail_03", "1. Armies, scouts, and monks move at increased speed."),
						Environment.NewLine,
						SK.Text("WorldSelect_5thEra_Mail_04", "2. Goods have been cleared from all Markets, with prices reset to their starting levels."),
						Environment.NewLine,
						SK.Text("WorldSelect_5thEra_Mail_05", "3. The Faith Point cost for Interdiction and Excommunication has increased."),
						Environment.NewLine,
						SK.Text("WorldSelect_5thEra_Mail_06", "4. Votes and officers in all capitals have been cleared and the Glory Race has restarted."),
						Environment.NewLine,
						SK.Text("WorldSelect_5thEra_Mail_07", "5. Military Schools can be upgraded to level 5."),
						Environment.NewLine,
						SK.Text("WorldSelect_5thEra_Mail_08", "6. Treasure Castles are twice as likely to appear."),
						Environment.NewLine,
						SK.Text("WorldSelect_5thEra_Mail_09", "7. Only members of a House can be candidates for County elections."),
						Environment.NewLine,
						SK.Text("WorldSelect_5thEra_Mail_10", "8. To be eligible for the office of sheriff, a candidate must belong to a House which controls at least 30% of the parishes in the county."),
						Environment.NewLine,
						SK.Text("WorldSelect_5thEra_Mail_11", "9. Large Houses gain Glory more slowly than small Houses.  A House with 60 members will gain one-third the amount of Glory that would be normally gained."),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("WorldSelect_5thEra_Mail_12", "As you can see Sire, you will need to maneuver skillfully in this new political arena and spread your villages and influence all over the realm in order to assure victory for you and your chosen comrades in arms."),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("WorldSelect_5thEra_Mail_13", "For the skilled strategist there is much to gain, all members of the house to win this Era will be rewarded with five wheel spins!"),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("WorldSelect_Era_Mail_Good_Luck", "Good luck!")
					});
				case '6':
					return string.Concat(new string[]
					{
						SK.Text("WorldSelect_6thEra_Mail_01", "Exciting times are upon us, Sire! Your strength, tenacity and cunning are sure to serve you well as you confront the challenges ahead.  The Sixth Era is here and the changes it brings add yet another layer of strategy and complexity to the world!"),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("WorldSelect_6thEra_Mail_02", "These changes are now in effect:"),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("WorldSelect_6thEra_Mail_03", "1. Armies, scouts, and monks move at increased speed."),
						Environment.NewLine,
						SK.Text("WorldSelect_6thEra_Mail_04", "2. Goods have been cleared from all Markets, with prices reset to their starting levels."),
						Environment.NewLine,
						SK.Text("WorldSelect_6thEra_Mail_05", "3. The Faith Point cost for Interdiction and Excommunication has increased."),
						Environment.NewLine,
						SK.Text("WorldSelect_6thEra_Mail_06", "4. Votes and officers in all capitals have been cleared and the Glory Race has restarted."),
						Environment.NewLine,
						SK.Text("WorldSelect_6thEra_Mail_07", "5. The cost to recruit troops in capitals has been halved."),
						Environment.NewLine,
						SK.Text("WorldSelect_6thEra_Mail_08", "6. Weapons can now be found in stashes."),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("WorldSelect_6thEra_Mail_09", "For the skilled strategist there is much to gain, all members of the house to win this Era will be rewarded with five wheel spins!"),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("WorldSelect_6thEra_Mail_10", "You will need to keep your allies close and eyes open as you carve out a path for your medieval empire in this new age. This world is now a place where weapons are plentiful, diplomacy is limited and attacks are swift, so be vigilant! Old enemies and new rivals may emerge as the world prepares for The Final Era..."),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("WorldSelect_Era_Mail_Good_Luck", "Good luck!")
					});
				case '7':
					return string.Concat(new string[]
					{
						SK.Text("WorldSelect_7thEra_Mail_01", "The end times are upon us, my liege! This world has now entered its Final Era and while you have made it this far, the road ahead will prove the ultimate test of your courage, character and ingenuity!"),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("WorldSelect_7thEra_Mail_02", "These changes are now in effect:"),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("WorldSelect_7thEra_Mail_03", "1. Armies, scouts, and monks move at increased speed."),
						Environment.NewLine,
						SK.Text("WorldSelect_7thEra_Mail_04", "2. Goods have been cleared from all Markets, with prices reset to their starting levels."),
						Environment.NewLine,
						SK.Text("WorldSelect_7thEra_Mail_05", "3. The Faith Point cost for Interdiction and Excommunication has increased."),
						Environment.NewLine,
						SK.Text("WorldSelect_7thEra_Mail_06", "4. Votes and officers in all capitals have been cleared and the Glory Race has restarted."),
						Environment.NewLine,
						SK.Text("WorldSelect_7thEra_Mail_07", "5. Capital guilds can now be upgraded an additional five levels."),
						Environment.NewLine,
						SK.Text("WorldSelect_7thEra_Mail_08", "6. No new players may join this game world. Only those who previously had a village on this world may enter it."),
						Environment.NewLine,
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("WorldSelect_7thEra_Mail_09", "Please also note the unique gameplay mechanics that the Final Era brings with it:"),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("WorldSelect_7thEra_Mail_10", "1. The Final Era begins with 150 'Royal Towers' on the map."),
						Environment.NewLine,
						SK.Text("WorldSelect_7thEra_Mail_11", "2. 'The Button' can be pressed by the Marshall of the House that controls all towers."),
						Environment.NewLine,
						SK.Text("WorldSelect_7thEra_Mail_12", "3. Pressing 'The Button' ends the world, determining which players claim each reward tier."),
						Environment.NewLine,
						SK.Text("WorldSelect_7thEra_Mail_13", "4. The Glory Race has no end and Houses are no longer eliminated."),
						Environment.NewLine,
						SK.Text("WorldSelect_7thEra_Mail_15", "5. After each Glory Round towers respawn and tower control is reset."),
						Environment.NewLine,
						SK.Text("WorldSelect_7thEra_Mail_16", "6. Each Round brings the number of towers down by 10, with a minimum of 20."),
						Environment.NewLine,
						SK.Text("WorldSelect_7thEra_Mail_17", "7. A new 'Royal Towers' tab has been added to the Glory screen."),
						Environment.NewLine,
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("WorldSelect_7thEra_Mail_18", "'Royal Towers' are the key to obtaining Final Victory and the ability for one player to end the game world. Once a single House controls all Royal Towers in a game world the House Marshall may choose to achieve Final Victory by pressing 'The Button', which will no longer be greyed out. Doing so will allow all House members to claim wondrous prizes and end the game world forever. "),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("WorldSelect_7thEra_Mail_19", "Here are the most important things to note about Royal Towers:"),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("WorldSelect_7thEra_Mail_20", "1. A captain is needed to attack a Royal Tower and only capture-type attacks may be launched against them."),
						Environment.NewLine,
						SK.Text("WorldSelect_7thEra_Mail_21", "2. Attacking a Royal Tower will remove any interdiction from the source village."),
						Environment.NewLine,
						SK.Text("WorldSelect_7thEra_Mail_22", "3. Royal Towers cannot be repaired, rebuilt or reinforced by players."),
						Environment.NewLine,
						SK.Text("WorldSelect_7thEra_Mail_23", "4. Royal Towers cannot be interdicted."),
						Environment.NewLine,
						SK.Text("WorldSelect_7thEra_Mail_24", "5. If a player captures a Royal Tower their House gains control of that tower."),
						Environment.NewLine,
						SK.Text("WorldSelect_7thEra_Mail_25", "6. After they are captured Royal Towers are immediately rebuilt and repaired."),
						Environment.NewLine,
						SK.Text("WorldSelect_7thEra_Mail_26", "7. The Final Era begins with 150 Royal Towers spawning across the map in random locations."),
						Environment.NewLine,
						SK.Text("WorldSelect_7thEra_Mail_27", "8. After each Glory Round all towers disappear, with new towers appearing in random locations."),
						Environment.NewLine,
						SK.Text("WorldSelect_7thEra_Mail_28", "9. The total number of towers is reduced by 10 at the end of each Round and control of all towers is reset."),
						Environment.NewLine,
						SK.Text("WorldSelect_7thEra_Mail_29", "10. The minimum number of Royal Towers in a world is 20."),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("WorldSelect_7thEra_Mail_30", "The final struggle for this realm has begun! The time has come to claim your rightful place amongst the true legends, not just of this world but of all Stronghold Kingdoms worlds. You have come far and achieved much, it is only right that you should now be justly rewarded for your noble efforts.")
					});
				case 'A':
					if (text == "jp")
					{
						return "???????????????????????";
					}
					switch (c2)
					{
					case 'A':
						return "Welcome to Stronghold Kingdoms!";
					case 'B':
						return "Willkommen bei Stronghold Kingdoms!";
					case 'C':
						return "Bienvenue dans Stronghold Kingdoms !";
					case 'D':
						return "Äîáðî ïîæàëîâàòü â Stronghold Kingdoms!";
					case 'E':
						return "?Bienvenido a Stronghold Kingdoms!";
					case 'F':
						return "Witaj w grze Twierdza: Krolestwa!";
					case 'G':
						return "Boas-vindas ao Stronghold Kingdoms!";
					case 'H':
						return "Ti do il benvenuto a Stronghold Kingdoms!";
					case 'I':
						return "Stronghold Kingdoms’a hos geldiniz!";
					case 'J':
						return "???????:???";
					case 'K':
						return "??????????";
					case 'L':
						return "????? ???? ?? ?? ?????!";
					}
					break;
				case 'B':
					if (text == "jp")
					{
						return "???!???????????????????????????????????";
					}
					switch (c2)
					{
					case 'A':
						return "Congratulations! You have completed the Stronghold Kingdoms Tutorial.";
					case 'B':
						return "Herzlichen Gluckwunsch! Sie haben das Stronghold Kingdoms Tutorial abgeschlossen.";
					case 'C':
						return "Felicitations ! Vous venez de completer le tutoriel de Stronghold Kingdoms.";
					case 'D':
						return "Ïîçäðàâëÿåì! Âû ïðîøëè îáó÷åíèå Stronghold Kingdoms. ";
					case 'E':
						return "?Felicidades! Has completado el Tutorial de Stronghold Kingdoms";
					case 'F':
						return "Gratulacje! Udalo Ci sie ukonczyc samouczek Twierdza: Krolestwa.";
					case 'G':
						return "Parabens! Voce completou o tutorial do Stronghold Kingdoms.";
					case 'H':
						return "Congratulazioni! Hai completato il tutorial di Stronghold Kingdoms.";
					case 'I':
						return "Tebrikler! Stronghold Kingdoms Egitim Bolumu’nu tamamlad?n?z.";
					case 'J':
						return "???!????????:??????";
					case 'K':
						return "???!??????????????";
					case 'L':
						return "?????! ????? ??? ????? ??????.";
					}
					break;
				case 'C':
					switch (c2)
					{
					case 'A':
						return "Welcome to the Second Age";
					case 'B':
						return "Willkommen in der zweiten Epoche!";
					case 'C':
						return "Bienvenue dans la Deuxieme Ere";
					case 'D':
						return "Äîáðî ïîæàëîâàòü âî Âòîðóþ Ýïîõó!";
					case 'E':
						return "Bienvenido a la Segunda Edad";
					case 'F':
						return "Witaj w Drugiej Epoce";
					case 'G':
						return "Boas-vindas a Segunda Era";
					case 'H':
						return "Un caloroso benvenuto alla Seconda Epoca";
					case 'I':
						return "Ikinci Cag’a hos geldiniz!";
					case 'J':
						return "????????";
					case 'K':
						return "????????";
					case 'L':
						return "? ?? ??? ?? ?? ?????";
					}
					break;
				case 'D':
					switch (c2)
					{
					case 'A':
						return "Welcome to the Third Age";
					case 'B':
						return "Willkommen in der dritten Epoche!";
					case 'C':
						return "Bienvenue dans la Troisieme Ere";
					case 'D':
						return "Äîáðî ïîæàëîâàòü â Òðåòüþ Ýïîõó";
					case 'E':
						return "Tercera Edad Correo In-Game:";
					case 'F':
						return "Witaj w Trzeciej Epoce";
					case 'G':
						return "Boas-vindas a Terceira Era";
					case 'H':
						return "Un caloroso benvenuto alla Terza Epoca";
					case 'I':
						return "Ucuncu Cag’a Hosgeldiniz!";
					case 'J':
						return "????????!";
					case 'K':
						return "????????!";
					case 'L':
						return "? ?? ??? ?? ?? ?????!";
					}
					break;
				case 'E':
					if (text == "jp")
					{
						return "Domination ???????";
					}
					switch (c2)
					{
					case 'A':
						return "Welcome to Domination World";
					case 'B':
						return "Willkommen auf der Domination Welt";
					case 'C':
						return "Bienvenue sur le Monde de Domination !";
					case 'D':
						return "Äîáðî ïîæàëîâàòü â Ìèð Domination!";
					case 'E':
						return "Bienvenido al Mundo Domination.";
					case 'F':
						return "Witaj w Swiecie Domination!";
					case 'G':
						return "Boas vindas ao Mundo de Domination";
					case 'H':
						return "Benvenuto nel Mondo Domination";
					case 'I':
						return "Domination Dunyasina Hosgeldiniz";
					case 'J':
						return "????????";
					case 'K':
						return "????????";
					case 'L':
						return "??? ??? ?? ?? ?????.";
					}
					break;
				case 'F':
					return SK.Text("WorldSelect_4thAge_Header", "Welcome to the Fourth Age!");
				case 'G':
					return string.Concat(new string[]
					{
						SK.Text("FourthAge_Mail_01", "My Liege! How glad I am to see you in one piece. The brutal Third Age brought with it higher caps for villages, increased Honour production and more, however my spies tell me the Fourth Age is not quite what we were expecting… Although there are similarities, such as an increased village cap, there is also much to learn. Your forces move faster than ever before, Houses and Factions have adopted a new structure to encourage combat and the cost of Interdiction has been raised. I’ve also heard word of a new Military School and Bombard, both of which could help us crush our enemies and take the crown."),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("FourthAge_Mail_02", "Core to the Fourth Age is the new rule set, which is now in effect:"),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("FourthAge_Mail_03", "1. Crown Princes may now own up to 40 villages."),
						Environment.NewLine,
						SK.Text("FourthAge_Mail_04", "2. Army and Scout movement speeds are three times faster than in the First Age."),
						Environment.NewLine,
						SK.Text("FourthAge_Mail_05", "3. Weapons can no longer be sold or purchased at Markets."),
						Environment.NewLine,
						SK.Text("FourthAge_Mail_06", "4. Goods have been cleared from all Markets, with prices reset to their starting level."),
						Environment.NewLine,
						SK.Text("FourthAge_Mail_07", "5. The Faith Point cost for Interdiction has been increased."),
						Environment.NewLine,
						SK.Text("FourthAge_Mail_08", "6. A Military School can be built in a parish, which gives access to Bombards."),
						Environment.NewLine,
						SK.Text("FourthAge_Mail_09", "7. All in-game Factions and Houses have been disbanded."),
						Environment.NewLine,
						SK.Text("FourthAge_Mail_10", "8. All capital forums and walls will be cleared."),
						Environment.NewLine,
						SK.Text("FourthAge_Mail_11", "9. Houses are limited to 3 Factions, with the first Faction to apply accepted automatically and all other factions voted in."),
						Environment.NewLine,
						SK.Text("FourthAge_Mail_12", "10. Certain upgradable Parish buildings can now gain 5 additional levels."),
						Environment.NewLine,
						SK.Text("FourthAge_Mail_13", "11. Players who own more than 10 villages will no longer have to pay the extra honour cost to regain a village, if one of their villages is captured."),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("FourthAge_Mail_14", "As you can see my Lord, the Fourth Age may prove challenging. However I believe there is much to gain, whether we fight or trade our way to victory."),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("FourthAge_Mail_15", "Good luck Sire")
					});
				case 'I':
					return SK.Text("WorldSelect_5thAge_Header", "Welcome to the Fifth Age!");
				case 'J':
					return string.Concat(new string[]
					{
						SK.Text("FifthAge_Mail_01", "Greetings Sire!  It is good to see you have made it through the trials of the Fourth Age and ready to face the challenges that the Fifth Age brings!  Hopefully you have brought many loyal friends and staunch allies along with you in to this new era as well, for you will need them if you are to succeed!"),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("FifthAge_Mail_02", "Core to the Fifth Age is the new rule set, which is now in effect."),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("FifthAge_Mail_03", "1. Military Schools can be upgraded to level 5."),
						Environment.NewLine,
						SK.Text("FifthAge_Mail_04", "2. Treasure Castles are twice as likely to appear."),
						Environment.NewLine,
						SK.Text("FifthAge_Mail_05", "3. All factions and houses have been disbanded."),
						Environment.NewLine,
						SK.Text("FifthAge_Mail_06", "4. All capital forums and walls have been cleared."),
						Environment.NewLine,
						SK.Text("FifthAge_Mail_07", "5. Only members of a House can be candidates for County elections."),
						Environment.NewLine,
						SK.Text("FifthAge_Mail_08", "6. To be eligible for the office of sheriff, a candidate must belong to a House which controls at least 30% of the parishes in the county."),
						Environment.NewLine,
						SK.Text("FifthAge_Mail_09", "7. Glory gained overall is increased by one-third."),
						Environment.NewLine,
						SK.Text("FifthAge_Mail_10", "8. Large Houses gain Glory more slowly than small Houses.  A House with 60 members will gain one-third the amount of Glory that would be normally gained."),
						Environment.NewLine,
						SK.Text("FifthAge_Mail_11", "As you can see Sire, you will need to maneuver skillfully in this new political arena and spread your villages and influence all over the realm in order to assure victory for you and your chosen comrades in arms."),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("FourthAge_Mail_15", "Good luck Sire")
					});
				case 'K':
					return SK.Text("WorldSelect_6thAge_Header", "Welcome to the Sixth Age!");
				case 'L':
					return string.Concat(new string[]
					{
						SK.Text("SixthAge_Mail_01", "Exciting times are upon us, Sire! Your strength, tenacity and cunning are sure to serve you well as you confront the challenges ahead.  The Sixth Age is here and the changes it brings add yet another layer of strategy and complexity to the world!"),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("SixthAge_Mail_02", "Please be aware of the following changes:"),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("SixthAge_Mail_03", "1. The cost to recruit troops in capitals has been halved."),
						Environment.NewLine,
						SK.Text("SixthAge_Mail_04", "2. Movement speed has increased for armies and scouts, they now move at four times the speed of the First Age."),
						Environment.NewLine,
						SK.Text("SixthAge_Mail_05", "3. Monk movement speed has been doubled."),
						Environment.NewLine,
						SK.Text("SixthAge_Mail_06", "4. Weapons can now be found in stashes."),
						Environment.NewLine,
						SK.Text("SixthAge_Mail_07", "5. Weapons can once again be bought and sold at markets."),
						Environment.NewLine,
						SK.Text("SixthAge_Mail_08", "6. The maximum faction size is now 10 players."),
						Environment.NewLine,
						SK.Text("SixthAge_Mail_09", "7. 1 million Glory Points are required to win each Glory Round."),
						Environment.NewLine,
						SK.Text("SixthAge_Mail_11", "You will need to keep your allies close and eyes open as you carve out a path for your medieval empire in this new age. This world is now a place where weapons are plentiful, diplomacy is limited and attacks are swift, so be vigilant! Old enemies and new rivals may emerge as the world prepares for The Final Age..."),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("FourthAge_Mail_15", "Good luck Sire")
					});
				case 'M':
					return SK.Text("WorldSelect_7thAge_Header", "Welcome to the Final Age!");
				case 'N':
					return string.Concat(new string[]
					{
						SK.Text("SeventhAge_Mail_01", "The end times are upon us, my liege! This world has now entered its Final Age and, while you have made it this far, the road ahead will prove the ultimate test of your courage, character and ingenuity! Please be aware of the changes that this final age brings with it:"),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("SeventhAge_Mail_02", "1. The Final Age begins with 150 'Royal Towers' on the map."),
						Environment.NewLine,
						SK.Text("SeventhAge_Mail_03", "2. 'The Button' can be pressed by the Marshall of the House that controls all towers."),
						Environment.NewLine,
						SK.Text("SeventhAge_Mail_04", "3. Pressing 'The Button' ends the world, determining which players claim each reward tier!"),
						Environment.NewLine,
						SK.Text("SeventhAge_Mail_05", "4. The Glory Race has no end and Houses are no longer eliminated."),
						Environment.NewLine,
						SK.Text("SeventhAge_Mail_07", "5. After each Glory Round towers respawn and tower control is reset."),
						Environment.NewLine,
						SK.Text("SeventhAge_Mail_08", "6. Each Round brings the number of towers down by 10, with a minimum of 20."),
						Environment.NewLine,
						SK.Text("SeventhAge_Mail_09", "7. A new 'Royal Towers' tab has been added to the Glory screen."),
						Environment.NewLine,
						SK.Text("SeventhAge_Mail_10", "8. Capital guilds can now be upgraded an additional five levels."),
						Environment.NewLine,
						SK.Text("SeventhAge_Mail_11", "9. No new players may join this game world. Only those who previously had a village on this world may enter it."),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("WorldSelect_7thEra_Mail_18", "'Royal Towers' are the key to obtaining Final Victory and the ability for one player to end the game world. Once a single House controls all Royal Towers in a game world the House Marshall may choose to achieve Final Victory by pressing 'The Button', which will no longer be greyed out. Doing so will allow all House members to claim wondrous prizes and end the game world forever. "),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("SeventhAge_Mail_13", "Here are the most important things to note about Royal Towers:"),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("SeventhAge_Mail_14", "1. A captain is needed to attack a Royal Tower and only capture-type attacks may be launched against them."),
						Environment.NewLine,
						SK.Text("SeventhAge_Mail_15", "2. Attacking a Royal Tower will remove any interdiction from the source village."),
						Environment.NewLine,
						SK.Text("SeventhAge_Mail_16", "3. Royal Towers cannot be repaired, rebuilt or reinforced by players."),
						Environment.NewLine,
						SK.Text("SeventhAge_Mail_17", "4. Royal Towers cannot be interdicted."),
						Environment.NewLine,
						SK.Text("SeventhAge_Mail_18", "5. If a player captures a Royal Tower their House gains control of that tower."),
						Environment.NewLine,
						SK.Text("SeventhAge_Mail_19", "6. After they are captured Royal Towers are immediately rebuilt and repaired."),
						Environment.NewLine,
						SK.Text("SeventhAge_Mail_20", "7. The Final Age begins with 150 Royal Towers spawning across the map in random locations."),
						Environment.NewLine,
						SK.Text("SeventhAge_Mail_21", "8. After each Glory Round all towers disappear, with new towers appearing in random locations."),
						Environment.NewLine,
						SK.Text("SeventhAge_Mail_22", "9. The total number of towers is reduced by 10 at the end of each Round and control of all towers is reset."),
						Environment.NewLine,
						SK.Text("SeventhAge_Mail_23", "10. The minimum number of Royal Towers in a world is 20."),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("SeventhAge_Mail_24", "The final struggle for this realm has begun! The time has come to claim your rightful place amongst the true legends, not just of this world but of all Stronghold Kingdoms worlds. You have come far and achieved much, it is only right that you should now be justly rewarded for your noble efforts.")
					});
				case 'U':
					return SK.Text("WorldSelect_2ndEra_Header", "Welcome to the Second Era!");
				case 'V':
					return SK.Text("WorldSelect_3rdEra_Header", "Welcome to the Third Era!");
				case 'W':
					return SK.Text("WorldSelect_4thEra_Header", "Welcome to the Fourth Era!");
				case 'X':
					return SK.Text("WorldSelect_5thEra_Header", "Welcome to the Fifth Era!");
				case 'Y':
					return SK.Text("WorldSelect_6thEra_Header", "Welcome to the Sixth Era!");
				case 'Z':
					return SK.Text("WorldSelect_FinalEra_Header", "Welcome to the Final Era!");
				}
			}
			return text2;
		}

		// Token: 0x04002731 RID: 10033
		public const int GROUP_YESTERDAY = 1;

		// Token: 0x04002732 RID: 10034
		public const int GROUP_3DAYS = 2;

		// Token: 0x04002733 RID: 10035
		public const int GROUP_THISWEEK = 3;

		// Token: 0x04002734 RID: 10036
		public const int GROUP_THISMONTH = 4;

		// Token: 0x04002735 RID: 10037
		public const int GROUP_ALLTIME = 5;

		// Token: 0x04002736 RID: 10038
		public const int GROUP_SINCE_LAST = 6;

		// Token: 0x04002737 RID: 10039
		private static MailManager m_instance;

		// Token: 0x04002738 RID: 10040
		private SparseArray m_storedThreadHeaders = new SparseArray();

		// Token: 0x04002739 RID: 10041
		private SparseArray m_storedThreads = new SparseArray();

		// Token: 0x0400273A RID: 10042
		public bool downloadedYesterday = true;

		// Token: 0x0400273B RID: 10043
		public bool downloaded3Days = true;

		// Token: 0x0400273C RID: 10044
		public bool downloadedThisWeek = true;

		// Token: 0x0400273D RID: 10045
		public bool downloadedThisMonth = true;

		// Token: 0x0400273E RID: 10046
		public bool downloadedAll = true;

		// Token: 0x0400273F RID: 10047
		public bool openYesterday = true;

		// Token: 0x04002740 RID: 10048
		public bool open3Days = true;

		// Token: 0x04002741 RID: 10049
		public bool openThisWeek = true;

		// Token: 0x04002742 RID: 10050
		public bool openThisMonth;

		// Token: 0x04002743 RID: 10051
		public bool openAll;

		// Token: 0x04002744 RID: 10052
		private List<MailFolderItem> m_mailFolders = new List<MailFolderItem>();

		// Token: 0x04002745 RID: 10053
		public DateTime lastTimeThreadsReceived = DateTime.MinValue;

		// Token: 0x04002746 RID: 10054
		public bool initialRequest = true;

		// Token: 0x04002747 RID: 10055
		public bool gotFolders;

		// Token: 0x04002748 RID: 10056
		private List<MailThreadListItem> m_preSortedHeaders = new List<MailThreadListItem>();

		// Token: 0x04002749 RID: 10057
		private List<MailThreadListItem> m_preSortedALLHeader = new List<MailThreadListItem>();

		// Token: 0x0400274A RID: 10058
		private MailManager.MailThreadHeaderComparer mailThreadHeaderComparer = new MailManager.MailThreadHeaderComparer();

		// Token: 0x0400274B RID: 10059
		public MailManager.MailThreadComparer mailThreadComparer = new MailManager.MailThreadComparer();

		// Token: 0x0400274C RID: 10060
		private bool aggressiveBlocking;

		// Token: 0x0400274D RID: 10061
		public bool blockListChanged;

		// Token: 0x0400274E RID: 10062
		public List<string> blockedList = new List<string>();

		// Token: 0x0400274F RID: 10063
		private static DraftMail currentDraft = new DraftMail();

		// Token: 0x04002750 RID: 10064
		public string[] mailUsersHistory;

		// Token: 0x04002751 RID: 10065
		public string[] mailFavourites;

		// Token: 0x04002752 RID: 10066
		private MailManager.GenericUIDelegate getFolderCallback;

		// Token: 0x04002753 RID: 10067
		private MailManager.GetMailThreadUIDelegate getMailThreadCallback;

		// Token: 0x04002754 RID: 10068
		private MailManager.GenericUIDelegate getMailThreadListDelegate;

		// Token: 0x04002755 RID: 10069
		private double lastUpdateTime;

		// Token: 0x04002756 RID: 10070
		private RemoteServices.SendMail_UserCallBack OnMailSent;

		// Token: 0x04002757 RID: 10071
		private RemoteServices.SendSpecialMail_UserCallBack OnSpecialMailSent;

		// Token: 0x04002758 RID: 10072
		private MailManager.GenericUIDelegate removeFolderUICallback;

		// Token: 0x04002759 RID: 10073
		private MailManager.GenericUIDelegate createFolderUICallback;

		// Token: 0x0400275A RID: 10074
		public long selectedFolderID = -1L;

		// Token: 0x0400275B RID: 10075
		public static bool HasUnreadMail = false;

		// Token: 0x02000220 RID: 544
		public enum MailType
		{
			// Token: 0x0400275D RID: 10077
			SENDTO,
			// Token: 0x0400275E RID: 10078
			NORMAL,
			// Token: 0x0400275F RID: 10079
			REPLY,
			// Token: 0x04002760 RID: 10080
			FORWARD,
			// Token: 0x04002761 RID: 10081
			PROCLAMATION,
			// Token: 0x04002762 RID: 10082
			VIDEO
		}

		// Token: 0x02000221 RID: 545
		// (Invoke) Token: 0x0600172B RID: 5931
		public delegate void GenericUIDelegate();

		// Token: 0x02000222 RID: 546
		// (Invoke) Token: 0x0600172F RID: 5935
		public delegate void GetMailThreadUIDelegate(long threadID);

		// Token: 0x02000223 RID: 547
		public class MailThreadHeaderComparer : IComparer<MailThreadListItem>
		{
			// Token: 0x06001732 RID: 5938 RVA: 0x00018542 File Offset: 0x00016742
			public int Compare(MailThreadListItem x, MailThreadListItem y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return 0;
					}
					return -1;
				}
				else
				{
					if (y == null)
					{
						return 1;
					}
					return y.mailTime.CompareTo(x.mailTime);
				}
			}
		}

		// Token: 0x02000224 RID: 548
		public class MailThreadComparer : IComparer<MailThreadItem>
		{
			// Token: 0x06001734 RID: 5940 RVA: 0x00018564 File Offset: 0x00016764
			public int Compare(MailThreadItem x, MailThreadItem y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return 0;
					}
					return -1;
				}
				else
				{
					if (y == null)
					{
						return 1;
					}
					return y.mailTime.CompareTo(x.mailTime);
				}
			}
		}
	}
}
