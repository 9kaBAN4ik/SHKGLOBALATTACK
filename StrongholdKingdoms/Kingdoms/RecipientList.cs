using System;
using System.Collections.Generic;

namespace Kingdoms
{
	// Token: 0x020002B2 RID: 690
	public class RecipientList
	{
		// Token: 0x06001EE0 RID: 7904 RVA: 0x0001D68D File Offset: 0x0001B88D
		public string[] GetRecipients()
		{
			return this.draftRecipients.ToArray();
		}

		// Token: 0x06001EE1 RID: 7905 RVA: 0x001DC4E4 File Offset: 0x001DA6E4
		public void AddRecipient(string user)
		{
			if (!this.draftRecipients.Contains(user) && this.draftRecipients.Count < 60)
			{
				this.draftRecipients.Add(user);
				UniversalDebugLog.Log("Recipient added " + user);
				return;
			}
			UniversalDebugLog.Log(user + " already added");
		}

		// Token: 0x06001EE2 RID: 7906 RVA: 0x0001D69A File Offset: 0x0001B89A
		public void ToggleRecipient(string user)
		{
			if (this.draftRecipients.Contains(user))
			{
				this.draftRecipients.Remove(user);
				return;
			}
			this.draftRecipients.Add(user);
		}

		// Token: 0x06001EE3 RID: 7907 RVA: 0x0001D6C4 File Offset: 0x0001B8C4
		public int RecipientCount()
		{
			return this.draftRecipients.Count;
		}

		// Token: 0x06001EE4 RID: 7908 RVA: 0x0001D6D1 File Offset: 0x0001B8D1
		public void ClearRecipients()
		{
			UniversalDebugLog.Log("recipients cleared");
			this.draftRecipients.Clear();
		}

		// Token: 0x04002FC9 RID: 12233
		public const int RECIPIENTS_LIMIT = 60;

		// Token: 0x04002FCA RID: 12234
		private List<string> draftRecipients = new List<string>();
	}
}
