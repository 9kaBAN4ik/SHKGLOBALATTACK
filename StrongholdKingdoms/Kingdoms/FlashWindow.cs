using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x020001D6 RID: 470
	public static class FlashWindow
	{
		// Token: 0x1700010E RID: 270
		// (get) Token: 0x060011C8 RID: 4552 RVA: 0x0001361C File Offset: 0x0001181C
		private static bool Win2000OrLater
		{
			get
			{
				return Environment.OSVersion.Version.Major >= 5;
			}
		}

		// Token: 0x060011C9 RID: 4553
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool FlashWindowEx(ref FlashWindow.FLASHWINFO pwfi);

		// Token: 0x060011CA RID: 4554 RVA: 0x0012C280 File Offset: 0x0012A480
		public static bool Flash(Form form)
		{
			if (FlashWindow.Win2000OrLater && form != null)
			{
				FlashWindow.FLASHWINFO flashwinfo = FlashWindow.Create_FLASHWINFO(form.Handle, 15U, uint.MaxValue, 0U);
				return FlashWindow.FlashWindowEx(ref flashwinfo);
			}
			return false;
		}

		// Token: 0x060011CB RID: 4555 RVA: 0x0012C2B0 File Offset: 0x0012A4B0
		private static FlashWindow.FLASHWINFO Create_FLASHWINFO(IntPtr handle, uint flags, uint count, uint timeout)
		{
			FlashWindow.FLASHWINFO flashwinfo = default(FlashWindow.FLASHWINFO);
			flashwinfo.cbSize = Convert.ToUInt32(Marshal.SizeOf(flashwinfo));
			flashwinfo.hwnd = handle;
			flashwinfo.dwFlags = flags;
			flashwinfo.uCount = count;
			flashwinfo.dwTimeout = timeout;
			return flashwinfo;
		}

		// Token: 0x060011CC RID: 4556 RVA: 0x0012C300 File Offset: 0x0012A500
		public static bool Flash(Form form, uint count)
		{
			if (FlashWindow.Win2000OrLater && form != null)
			{
				FlashWindow.FLASHWINFO flashwinfo = FlashWindow.Create_FLASHWINFO(form.Handle, 3U, count, 0U);
				return FlashWindow.FlashWindowEx(ref flashwinfo);
			}
			return false;
		}

		// Token: 0x060011CD RID: 4557 RVA: 0x0012C330 File Offset: 0x0012A530
		public static bool Start(Form form)
		{
			if (FlashWindow.Win2000OrLater && form != null)
			{
				FlashWindow.FLASHWINFO flashwinfo = FlashWindow.Create_FLASHWINFO(form.Handle, 3U, uint.MaxValue, 0U);
				return FlashWindow.FlashWindowEx(ref flashwinfo);
			}
			return false;
		}

		// Token: 0x060011CE RID: 4558 RVA: 0x0012C360 File Offset: 0x0012A560
		public static bool Stop(Form form)
		{
			if (FlashWindow.Win2000OrLater && form != null)
			{
				FlashWindow.FLASHWINFO flashwinfo = FlashWindow.Create_FLASHWINFO(form.Handle, 0U, uint.MaxValue, 0U);
				return FlashWindow.FlashWindowEx(ref flashwinfo);
			}
			return false;
		}

		// Token: 0x0400180C RID: 6156
		public const uint FLASHW_STOP = 0U;

		// Token: 0x0400180D RID: 6157
		public const uint FLASHW_CAPTION = 1U;

		// Token: 0x0400180E RID: 6158
		public const uint FLASHW_TRAY = 2U;

		// Token: 0x0400180F RID: 6159
		public const uint FLASHW_ALL = 3U;

		// Token: 0x04001810 RID: 6160
		public const uint FLASHW_TIMER = 4U;

		// Token: 0x04001811 RID: 6161
		public const uint FLASHW_TIMERNOFG = 12U;

		// Token: 0x020001D7 RID: 471
		private struct FLASHWINFO
		{
			// Token: 0x04001812 RID: 6162
			public uint cbSize;

			// Token: 0x04001813 RID: 6163
			public IntPtr hwnd;

			// Token: 0x04001814 RID: 6164
			public uint dwFlags;

			// Token: 0x04001815 RID: 6165
			public uint uCount;

			// Token: 0x04001816 RID: 6166
			public uint dwTimeout;
		}
	}
}
