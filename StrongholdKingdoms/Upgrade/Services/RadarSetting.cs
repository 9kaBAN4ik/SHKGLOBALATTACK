using System;

namespace Upgrade.Services
{
	// Token: 0x02000086 RID: 134
	internal class RadarSetting
	{
		// Token: 0x0600039B RID: 923 RVA: 0x00009C4C File Offset: 0x00007E4C
		public RadarSetting(string name)
		{
			this.Name = name;
		}

		// Token: 0x040004DF RID: 1247
		public string Name;

		// Token: 0x040004E0 RID: 1248
		public bool MonitorIt;

		// Token: 0x040004E1 RID: 1249
		public bool PopupMessage;

		// Token: 0x040004E2 RID: 1250
		public string Sound;

		// Token: 0x040004E3 RID: 1251
		public bool Email;

		// Token: 0x040004E4 RID: 1252
		public byte Interdict;

		// Token: 0x040004E5 RID: 1253
		public bool NotifyIcon;

		// Token: 0x040004E6 RID: 1254
		public bool SendDiscordMessage;

		// Token: 0x040004E7 RID: 1255
		public string CustomWebhook;

		// Token: 0x040004E8 RID: 1256
		public bool SendTelegramMessage;
	}
}
