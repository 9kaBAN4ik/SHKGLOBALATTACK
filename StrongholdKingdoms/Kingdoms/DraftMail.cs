using System;
using System.Collections.Generic;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020001A1 RID: 417
	public class DraftMail
	{
		// Token: 0x06000FF2 RID: 4082 RVA: 0x001174CC File Offset: 0x001156CC
		public DraftMail()
		{
			DraftMail.count++;
			UniversalDebugLog.Log("Created new draft mail " + DraftMail.count.ToString());
		}

		// Token: 0x06000FF3 RID: 4083 RVA: 0x00011A88 File Offset: 0x0000FC88
		public void ClearDraftMail()
		{
			UniversalDebugLog.Log("Cleared draft");
			this.Sent = false;
			this.Subject = "";
			this.Body = "";
			this.draftTargets.Clear();
			this.Recipients.ClearRecipients();
		}

		// Token: 0x06000FF4 RID: 4084 RVA: 0x00011AC7 File Offset: 0x0000FCC7
		public List<MailLink> GetTargets()
		{
			return this.draftTargets;
		}

		// Token: 0x06000FF5 RID: 4085 RVA: 0x00011ACF File Offset: 0x0000FCCF
		public void ToggleTarget(MailLink target)
		{
			if (this.draftTargets.Contains(target))
			{
				this.draftTargets.Remove(target);
				return;
			}
			this.draftTargets.Add(target);
		}

		// Token: 0x06000FF6 RID: 4086 RVA: 0x00011AF9 File Offset: 0x0000FCF9
		public int TargetCount()
		{
			return this.draftTargets.Count;
		}

		// Token: 0x06000FF7 RID: 4087 RVA: 0x00011B06 File Offset: 0x0000FD06
		public bool CanSendDraft()
		{
			return this.Recipients.RecipientCount() > 0 && this.Body != "" && this.Subject != "";
		}

		// Token: 0x06000FF8 RID: 4088 RVA: 0x00011B3A File Offset: 0x0000FD3A
		public bool InProgress()
		{
			return this.Recipients.RecipientCount() > 0 || this.Body != "" || this.Subject != "";
		}

		// Token: 0x06000FF9 RID: 4089 RVA: 0x00117538 File Offset: 0x00115738
		public void AttachVideo(string url)
		{
			this.DetatchVideos();
			MailLink mailLink = new MailLink();
			mailLink.linkType = 4;
			mailLink.objectID = -1;
			mailLink.objectName = url;
			this.draftTargets.Add(mailLink);
		}

		// Token: 0x06000FFA RID: 4090 RVA: 0x00117574 File Offset: 0x00115774
		public void DetatchVideos()
		{
			foreach (MailLink mailLink in this.draftTargets)
			{
				if (mailLink.linkType == 4)
				{
					this.draftTargets.Remove(mailLink);
					break;
				}
			}
		}

		// Token: 0x0400160D RID: 5645
		public long threadID = -1L;

		// Token: 0x0400160E RID: 5646
		public string Subject = "";

		// Token: 0x0400160F RID: 5647
		public string Body = "";

		// Token: 0x04001610 RID: 5648
		private List<MailLink> draftTargets = new List<MailLink>();

		// Token: 0x04001611 RID: 5649
		public RecipientList Recipients = new RecipientList();

		// Token: 0x04001612 RID: 5650
		public bool Sent;

		// Token: 0x04001613 RID: 5651
		private static int count;
	}
}
