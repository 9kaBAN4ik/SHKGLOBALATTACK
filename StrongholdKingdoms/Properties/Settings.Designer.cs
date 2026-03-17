using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Properties
{
	// Token: 0x020000B1 RID: 177
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.5.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000485 RID: 1157 RVA: 0x0000A24A File Offset: 0x0000844A
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000486 RID: 1158 RVA: 0x0000A251 File Offset: 0x00008451
		// (set) Token: 0x06000487 RID: 1159 RVA: 0x0000A263 File Offset: 0x00008463
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool StopTradeOnCardsExpiry
		{
			get
			{
				return (bool)this["StopTradeOnCardsExpiry"];
			}
			set
			{
				this["StopTradeOnCardsExpiry"] = value;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000488 RID: 1160 RVA: 0x0000A276 File Offset: 0x00008476
		// (set) Token: 0x06000489 RID: 1161 RVA: 0x0000A288 File Offset: 0x00008488
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool ShowPopupOnTradeExpiry
		{
			get
			{
				return (bool)this["ShowPopupOnTradeExpiry"];
			}
			set
			{
				this["ShowPopupOnTradeExpiry"] = value;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600048A RID: 1162 RVA: 0x0000A29B File Offset: 0x0000849B
		// (set) Token: 0x0600048B RID: 1163 RVA: 0x0000A2AD File Offset: 0x000084AD
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool StopScoutOnCardsExpiry
		{
			get
			{
				return (bool)this["StopScoutOnCardsExpiry"];
			}
			set
			{
				this["StopScoutOnCardsExpiry"] = value;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600048C RID: 1164 RVA: 0x0000A2C0 File Offset: 0x000084C0
		// (set) Token: 0x0600048D RID: 1165 RVA: 0x0000A2D2 File Offset: 0x000084D2
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool ShowPopupOnScoutsExpiry
		{
			get
			{
				return (bool)this["ShowPopupOnScoutsExpiry"];
			}
			set
			{
				this["ShowPopupOnScoutsExpiry"] = value;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600048E RID: 1166 RVA: 0x0000A2E5 File Offset: 0x000084E5
		// (set) Token: 0x0600048F RID: 1167 RVA: 0x0000A2F7 File Offset: 0x000084F7
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("580")]
		public int FormWidth
		{
			get
			{
				return (int)this["FormWidth"];
			}
			set
			{
				this["FormWidth"] = value;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000490 RID: 1168 RVA: 0x0000A30A File Offset: 0x0000850A
		// (set) Token: 0x06000491 RID: 1169 RVA: 0x0000A31C File Offset: 0x0000851C
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("742")]
		public int FormHeight
		{
			get
			{
				return (int)this["FormHeight"];
			}
			set
			{
				this["FormHeight"] = value;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000492 RID: 1170 RVA: 0x0000A32F File Offset: 0x0000852F
		// (set) Token: 0x06000493 RID: 1171 RVA: 0x0000A341 File Offset: 0x00008541
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("114")]
		public int TradeSlider1Distance
		{
			get
			{
				return (int)this["TradeSlider1Distance"];
			}
			set
			{
				this["TradeSlider1Distance"] = value;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000494 RID: 1172 RVA: 0x0000A354 File Offset: 0x00008554
		// (set) Token: 0x06000495 RID: 1173 RVA: 0x0000A366 File Offset: 0x00008566
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("343")]
		public int TradeSlider2Distance
		{
			get
			{
				return (int)this["TradeSlider2Distance"];
			}
			set
			{
				this["TradeSlider2Distance"] = value;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000496 RID: 1174 RVA: 0x0000A379 File Offset: 0x00008579
		// (set) Token: 0x06000497 RID: 1175 RVA: 0x0000A38B File Offset: 0x0000858B
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool RepairOnAIAttacks
		{
			get
			{
				return (bool)this["RepairOnAIAttacks"];
			}
			set
			{
				this["RepairOnAIAttacks"] = value;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000498 RID: 1176 RVA: 0x0000A39E File Offset: 0x0000859E
		// (set) Token: 0x06000499 RID: 1177 RVA: 0x0000A3B0 File Offset: 0x000085B0
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string UserContactEmail
		{
			get
			{
				return (string)this["UserContactEmail"];
			}
			set
			{
				this["UserContactEmail"] = value;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600049A RID: 1178 RVA: 0x0000A3BE File Offset: 0x000085BE
		// (set) Token: 0x0600049B RID: 1179 RVA: 0x0000A3D0 File Offset: 0x000085D0
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool RefreshEnabled
		{
			get
			{
				return (bool)this["RefreshEnabled"];
			}
			set
			{
				this["RefreshEnabled"] = value;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600049C RID: 1180 RVA: 0x0000A3E3 File Offset: 0x000085E3
		// (set) Token: 0x0600049D RID: 1181 RVA: 0x0000A3F5 File Offset: 0x000085F5
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool FullRefreshEnabled
		{
			get
			{
				return (bool)this["FullRefreshEnabled"];
			}
			set
			{
				this["FullRefreshEnabled"] = value;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600049E RID: 1182 RVA: 0x0000A408 File Offset: 0x00008608
		// (set) Token: 0x0600049F RID: 1183 RVA: 0x0000A41A File Offset: 0x0000861A
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool LoadMonksSettings
		{
			get
			{
				return (bool)this["LoadMonksSettings"];
			}
			set
			{
				this["LoadMonksSettings"] = value;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060004A0 RID: 1184 RVA: 0x0000A42D File Offset: 0x0000862D
		// (set) Token: 0x060004A1 RID: 1185 RVA: 0x0000A43F File Offset: 0x0000863F
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool StartMonks
		{
			get
			{
				return (bool)this["StartMonks"];
			}
			set
			{
				this["StartMonks"] = value;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060004A2 RID: 1186 RVA: 0x0000A452 File Offset: 0x00008652
		// (set) Token: 0x060004A3 RID: 1187 RVA: 0x0000A464 File Offset: 0x00008664
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("45")]
		public int BotWorkPeriod
		{
			get
			{
				return (int)this["BotWorkPeriod"];
			}
			set
			{
				this["BotWorkPeriod"] = value;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060004A4 RID: 1188 RVA: 0x0000A477 File Offset: 0x00008677
		// (set) Token: 0x060004A5 RID: 1189 RVA: 0x0000A489 File Offset: 0x00008689
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("15")]
		public int BotSleepPeriod
		{
			get
			{
				return (int)this["BotSleepPeriod"];
			}
			set
			{
				this["BotSleepPeriod"] = value;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060004A6 RID: 1190 RVA: 0x0000A49C File Offset: 0x0000869C
		// (set) Token: 0x060004A7 RID: 1191 RVA: 0x0000A4AE File Offset: 0x000086AE
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("50")]
		public int MerchantsTradeLimit
		{
			get
			{
				return (int)this["MerchantsTradeLimit"];
			}
			set
			{
				this["MerchantsTradeLimit"] = value;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060004A8 RID: 1192 RVA: 0x0000A4C1 File Offset: 0x000086C1
		// (set) Token: 0x060004A9 RID: 1193 RVA: 0x0000A4D3 File Offset: 0x000086D3
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("50")]
		public int MerchantsExchangeLimit
		{
			get
			{
				return (int)this["MerchantsExchangeLimit"];
			}
			set
			{
				this["MerchantsExchangeLimit"] = value;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060004AA RID: 1194 RVA: 0x0000A4E6 File Offset: 0x000086E6
		// (set) Token: 0x060004AB RID: 1195 RVA: 0x0000A4F8 File Offset: 0x000086F8
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("1")]
		public int MonksToKeep
		{
			get
			{
				return (int)this["MonksToKeep"];
			}
			set
			{
				this["MonksToKeep"] = value;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060004AC RID: 1196 RVA: 0x0000A50B File Offset: 0x0000870B
		// (set) Token: 0x060004AD RID: 1197 RVA: 0x0000A51D File Offset: 0x0000871D
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("1")]
		public int VassalTroopsMinimum
		{
			get
			{
				return (int)this["VassalTroopsMinimum"];
			}
			set
			{
				this["VassalTroopsMinimum"] = value;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060004AE RID: 1198 RVA: 0x0000A530 File Offset: 0x00008730
		// (set) Token: 0x060004AF RID: 1199 RVA: 0x0000A542 File Offset: 0x00008742
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool FeedShouldNotify
		{
			get
			{
				return (bool)this["FeedShouldNotify"];
			}
			set
			{
				this["FeedShouldNotify"] = value;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060004B0 RID: 1200 RVA: 0x0000A555 File Offset: 0x00008755
		// (set) Token: 0x060004B1 RID: 1201 RVA: 0x0000A567 File Offset: 0x00008767
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool RandomWorkPeriodsEnabled
		{
			get
			{
				return (bool)this["RandomWorkPeriodsEnabled"];
			}
			set
			{
				this["RandomWorkPeriodsEnabled"] = value;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060004B2 RID: 1202 RVA: 0x0000A57A File Offset: 0x0000877A
		// (set) Token: 0x060004B3 RID: 1203 RVA: 0x0000A58C File Offset: 0x0000878C
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string DiscordWebhook
		{
			get
			{
				return (string)this["DiscordWebhook"];
			}
			set
			{
				this["DiscordWebhook"] = value;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060004B4 RID: 1204 RVA: 0x0000A59A File Offset: 0x0000879A
		// (set) Token: 0x060004B5 RID: 1205 RVA: 0x0000A5AC File Offset: 0x000087AC
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string TelegramBotToken
		{
			get
			{
				return (string)this["TelegramBotToken"];
			}
			set
			{
				this["TelegramBotToken"] = value;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060004B6 RID: 1206 RVA: 0x0000A5BA File Offset: 0x000087BA
		// (set) Token: 0x060004B7 RID: 1207 RVA: 0x0000A5CC File Offset: 0x000087CC
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string TelegramChatID
		{
			get
			{
				return (string)this["TelegramChatID"];
			}
			set
			{
				this["TelegramChatID"] = value;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060004B8 RID: 1208 RVA: 0x0000A5DA File Offset: 0x000087DA
		// (set) Token: 0x060004B9 RID: 1209 RVA: 0x0000A5EC File Offset: 0x000087EC
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool StayOnTop
		{
			get
			{
				return (bool)this["StayOnTop"];
			}
			set
			{
				this["StayOnTop"] = value;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060004BA RID: 1210 RVA: 0x0000A5FF File Offset: 0x000087FF
		// (set) Token: 0x060004BB RID: 1211 RVA: 0x0000A611 File Offset: 0x00008811
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool ScoutingIgnoreType
		{
			get
			{
				return (bool)this["ScoutingIgnoreType"];
			}
			set
			{
				this["ScoutingIgnoreType"] = value;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060004BC RID: 1212 RVA: 0x0000A624 File Offset: 0x00008824
		// (set) Token: 0x060004BD RID: 1213 RVA: 0x0000A636 File Offset: 0x00008836
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool TelegramUseProxy
		{
			get
			{
				return (bool)this["TelegramUseProxy"];
			}
			set
			{
				this["TelegramUseProxy"] = value;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060004BE RID: 1214 RVA: 0x0000A649 File Offset: 0x00008849
		// (set) Token: 0x060004BF RID: 1215 RVA: 0x0000A65B File Offset: 0x0000885B
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string ProxyAddress
		{
			get
			{
				return (string)this["ProxyAddress"];
			}
			set
			{
				this["ProxyAddress"] = value;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060004C0 RID: 1216 RVA: 0x0000A669 File Offset: 0x00008869
		// (set) Token: 0x060004C1 RID: 1217 RVA: 0x0000A67B File Offset: 0x0000887B
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("0")]
		public int ProxyPort
		{
			get
			{
				return (int)this["ProxyPort"];
			}
			set
			{
				this["ProxyPort"] = value;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060004C2 RID: 1218 RVA: 0x0000A68E File Offset: 0x0000888E
		// (set) Token: 0x060004C3 RID: 1219 RVA: 0x0000A6A0 File Offset: 0x000088A0
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool ProxyUseCredential
		{
			get
			{
				return (bool)this["ProxyUseCredential"];
			}
			set
			{
				this["ProxyUseCredential"] = value;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060004C4 RID: 1220 RVA: 0x0000A6B3 File Offset: 0x000088B3
		// (set) Token: 0x060004C5 RID: 1221 RVA: 0x0000A6C5 File Offset: 0x000088C5
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string ProxyUsername
		{
			get
			{
				return (string)this["ProxyUsername"];
			}
			set
			{
				this["ProxyUsername"] = value;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060004C6 RID: 1222 RVA: 0x0000A6D3 File Offset: 0x000088D3
		// (set) Token: 0x060004C7 RID: 1223 RVA: 0x0000A6E5 File Offset: 0x000088E5
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string ProxyPassword
		{
			get
			{
				return (string)this["ProxyPassword"];
			}
			set
			{
				this["ProxyPassword"] = value;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060004C8 RID: 1224 RVA: 0x0000A6F3 File Offset: 0x000088F3
		// (set) Token: 0x060004C9 RID: 1225 RVA: 0x0000A705 File Offset: 0x00008905
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string TabsOrder
		{
			get
			{
				return (string)this["TabsOrder"];
			}
			set
			{
				this["TabsOrder"] = value;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060004CA RID: 1226 RVA: 0x0000A713 File Offset: 0x00008913
		// (set) Token: 0x060004CB RID: 1227 RVA: 0x0000A725 File Offset: 0x00008925
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string Language
		{
			get
			{
				return (string)this["Language"];
			}
			set
			{
				this["Language"] = value;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060004CC RID: 1228 RVA: 0x0000A733 File Offset: 0x00008933
		// (set) Token: 0x060004CD RID: 1229 RVA: 0x0000A745 File Offset: 0x00008945
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("2")]
		public int MinimumScouts
		{
			get
			{
				return (int)this["MinimumScouts"];
			}
			set
			{
				this["MinimumScouts"] = value;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060004CE RID: 1230 RVA: 0x0000A758 File Offset: 0x00008958
		// (set) Token: 0x060004CF RID: 1231 RVA: 0x0000A76A File Offset: 0x0000896A
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool DoScoutsNeedFreeSpace
		{
			get
			{
				return (bool)this["DoScoutsNeedFreeSpace"];
			}
			set
			{
				this["DoScoutsNeedFreeSpace"] = value;
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060004D0 RID: 1232 RVA: 0x0000A77D File Offset: 0x0000897D
		// (set) Token: 0x060004D1 RID: 1233 RVA: 0x0000A78F File Offset: 0x0000898F
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("1000")]
		public int MaxLogsToKeep
		{
			get
			{
				return (int)this["MaxLogsToKeep"];
			}
			set
			{
				this["MaxLogsToKeep"] = value;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060004D2 RID: 1234 RVA: 0x0000A7A2 File Offset: 0x000089A2
		// (set) Token: 0x060004D3 RID: 1235 RVA: 0x0000A7B4 File Offset: 0x000089B4
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("0")]
		public int AutoIDExtraDelay
		{
			get
			{
				return (int)this["AutoIDExtraDelay"];
			}
			set
			{
				this["AutoIDExtraDelay"] = value;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060004D4 RID: 1236 RVA: 0x0000A7C7 File Offset: 0x000089C7
		// (set) Token: 0x060004D5 RID: 1237 RVA: 0x0000A7D9 File Offset: 0x000089D9
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string LastLoadedAdvancedLogin
		{
			get
			{
				return (string)this["LastLoadedAdvancedLogin"];
			}
			set
			{
				this["LastLoadedAdvancedLogin"] = value;
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060004D6 RID: 1238 RVA: 0x0000A7E7 File Offset: 0x000089E7
		// (set) Token: 0x060004D7 RID: 1239 RVA: 0x0000A7F9 File Offset: 0x000089F9
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("True")]
		public bool ShowAdvancedLoginOptions
		{
			get
			{
				return (bool)this["ShowAdvancedLoginOptions"];
			}
			set
			{
				this["ShowAdvancedLoginOptions"] = value;
			}
		}

		// Token: 0x040005A0 RID: 1440
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
