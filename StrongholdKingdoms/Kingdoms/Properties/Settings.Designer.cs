using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Kingdoms.Properties
{
	// Token: 0x02000528 RID: 1320
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "8.0.0.0")]
	[CompilerGenerated]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x170002D6 RID: 726
		// (get) Token: 0x060033EA RID: 13290 RVA: 0x00025289 File Offset: 0x00023489
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x170002D7 RID: 727
		// (get) Token: 0x060033EB RID: 13291 RVA: 0x00025290 File Offset: 0x00023490
		// (set) Token: 0x060033EC RID: 13292 RVA: 0x000252A2 File Offset: 0x000234A2
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		[UserScopedSetting]
		public string Username
		{
			get
			{
				return (string)this["Username"];
			}
			set
			{
				this["Username"] = value;
			}
		}

		// Token: 0x170002D8 RID: 728
		// (get) Token: 0x060033ED RID: 13293 RVA: 0x000252B0 File Offset: 0x000234B0
		// (set) Token: 0x060033EE RID: 13294 RVA: 0x000252C2 File Offset: 0x000234C2
		[UserScopedSetting]
		[DefaultSettingValue("")]
		[DebuggerNonUserCode]
		public string Password
		{
			get
			{
				return (string)this["Password"];
			}
			set
			{
				this["Password"] = value;
			}
		}

		// Token: 0x170002D9 RID: 729
		// (get) Token: 0x060033EF RID: 13295 RVA: 0x000252D0 File Offset: 0x000234D0
		// (set) Token: 0x060033F0 RID: 13296 RVA: 0x000252E2 File Offset: 0x000234E2
		[DefaultSettingValue("-1")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public int ScreenWidth
		{
			get
			{
				return (int)this["ScreenWidth"];
			}
			set
			{
				this["ScreenWidth"] = value;
			}
		}

		// Token: 0x170002DA RID: 730
		// (get) Token: 0x060033F1 RID: 13297 RVA: 0x000252F5 File Offset: 0x000234F5
		// (set) Token: 0x060033F2 RID: 13298 RVA: 0x00025307 File Offset: 0x00023507
		[UserScopedSetting]
		[DefaultSettingValue("-1")]
		[DebuggerNonUserCode]
		public int ScreenHeight
		{
			get
			{
				return (int)this["ScreenHeight"];
			}
			set
			{
				this["ScreenHeight"] = value;
			}
		}

		// Token: 0x170002DB RID: 731
		// (get) Token: 0x060033F3 RID: 13299 RVA: 0x0002531A File Offset: 0x0002351A
		// (set) Token: 0x060033F4 RID: 13300 RVA: 0x0002532C File Offset: 0x0002352C
		[DefaultSettingValue("False")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public bool LicenseViewed
		{
			get
			{
				return (bool)this["LicenseViewed"];
			}
			set
			{
				this["LicenseViewed"] = value;
			}
		}

		// Token: 0x170002DC RID: 732
		// (get) Token: 0x060033F5 RID: 13301 RVA: 0x0002533F File Offset: 0x0002353F
		// (set) Token: 0x060033F6 RID: 13302 RVA: 0x00025351 File Offset: 0x00023551
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		[UserScopedSetting]
		public bool CastleWalls
		{
			get
			{
				return (bool)this["CastleWalls"];
			}
			set
			{
				this["CastleWalls"] = value;
			}
		}

		// Token: 0x170002DD RID: 733
		// (get) Token: 0x060033F7 RID: 13303 RVA: 0x00025364 File Offset: 0x00023564
		// (set) Token: 0x060033F8 RID: 13304 RVA: 0x00025376 File Offset: 0x00023576
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool LicenseAlpha3Viewed
		{
			get
			{
				return (bool)this["LicenseAlpha3Viewed"];
			}
			set
			{
				this["LicenseAlpha3Viewed"] = value;
			}
		}

		// Token: 0x040040FE RID: 16638
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
