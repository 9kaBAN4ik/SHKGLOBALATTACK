using System;

namespace Kingdoms
{
	// Token: 0x02000204 RID: 516
	public interface IMailUserInterface
	{
		// Token: 0x0600144C RID: 5196
		void addRecipient(string recipient);

		// Token: 0x0600144D RID: 5197
		void popupClosed(bool ok);
	}
}
