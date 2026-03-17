using System;

namespace Kingdoms
{
	// Token: 0x0200048F RID: 1167
	public class SHKMutexObject : MarshalByRefObject, SHKMutex
	{
		// Token: 0x06002A60 RID: 10848 RVA: 0x0001F272 File Offset: 0x0001D472
		public string HelloWorld()
		{
			return "Hello World";
		}
	}
}
