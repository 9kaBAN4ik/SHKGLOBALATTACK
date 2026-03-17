using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CommonTypes;
using DXGraphics;
using Gecko;
using StatTracking;
using Stronghold.AuthClient;
using Stronghold.ShieldClient;
using Upgrade;
using Upgrade.Services;

namespace Kingdoms
{
	// Token: 0x0200029C RID: 668
	internal static class Program
	{
		// Token: 0x17000202 RID: 514
		// (get) Token: 0x06001E03 RID: 7683 RVA: 0x0001CDF6 File Offset: 0x0001AFF6
		public static bool ShowSeasonalFX
		{
			get
			{
				return Program.xmas_period && Program.mySettings.SeasonalSpecialFX;
			}
		}

		// Token: 0x17000203 RID: 515
		// (get) Token: 0x06001E04 RID: 7684 RVA: 0x0001CE0B File Offset: 0x0001B00B
		public static bool ShowSeasonalGraphics
		{
			get
			{
				return Program.xmas_period && Program.mySettings.SeasonalWinterLandscape;
			}
		}

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x06001E05 RID: 7685 RVA: 0x0001CE20 File Offset: 0x0001B020
		public static bool ShowSeasonalFXOption
		{
			get
			{
				return Program.xmas_period;
			}
		}

		// Token: 0x06001E06 RID: 7686
		[DllImport("winmm.dll")]
		internal static extern uint timeBeginPeriod(uint period);

		// Token: 0x06001E07 RID: 7687
		[DllImport("winmm.dll")]
		internal static extern uint timeEndPeriod(uint period);

		// Token: 0x06001E08 RID: 7688
		[DllImport("winmm.dll")]
		private static extern int timeGetDevCaps(ref Program.TimerCaps caps, int sizeOfTimerCaps);

		// Token: 0x06001E09 RID: 7689
		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool SetProcessDPIAware();

		// Token: 0x06001E0A RID: 7690
		[DllImport("ArcWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Arc_Init(IntPtr handle);

		// Token: 0x06001E0B RID: 7691
		[DllImport("ArcWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Arc_Exit();

		// Token: 0x06001E0C RID: 7692
		[DllImport("ArcWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr Arc_GetAuthToken(IntPtr username);

		// Token: 0x06001E0D RID: 7693
		[DllImport("ArcWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Arc_Overlay(int state);

		// Token: 0x06001E0E RID: 7694
		[DllImport("ArcWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Arc_OpenURL(IntPtr url);

		// Token: 0x06001E0F RID: 7695
		[DllImport("ArcWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Arc_LaunchClient();

		// Token: 0x06001E10 RID: 7696
		[DllImport("SteamWrap3.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Steam_Init();

		// Token: 0x06001E11 RID: 7697
		[DllImport("SteamWrap3.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr Steam_GetAuthTicket();

		// Token: 0x06001E12 RID: 7698
		[DllImport("SteamWrap3.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Steam_GetAuthTicketLength();

		// Token: 0x06001E13 RID: 7699
		[DllImport("SteamWrap3.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Steam_RunCallBacks();

		// Token: 0x06001E14 RID: 7700
		[DllImport("SteamWrap3.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern IntPtr Steam_User_GetPersonaName();

		// Token: 0x06001E15 RID: 7701
		[DllImport("SteamWrap3.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong Steam_User_GetLocalUserSteamID();

		// Token: 0x06001E16 RID: 7702
		[DllImport("SteamWrap3.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Steam_OverlayActive();

		// Token: 0x06001E17 RID: 7703
		[DllImport("SteamWrap3.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Steam_OpenOverlay();

		// Token: 0x06001E18 RID: 7704
		[DllImport("SteamWrap3.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Steam_IsOverlayEnabled();

		// Token: 0x06001E19 RID: 7705
		[DllImport("SteamWrap3.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Steam_MT_Clear_Response();

		// Token: 0x06001E1A RID: 7706
		[DllImport("SteamWrap3.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Steam_MT_Authorised();

		// Token: 0x06001E1B RID: 7707
		[DllImport("SteamWrap3.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong Steam_MT_OrderID();

		// Token: 0x06001E1C RID: 7708
		[DllImport("SteamWrap3.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint Steam_MT_AppID();

		// Token: 0x06001E1D RID: 7709
		[DllImport("SteamWrap3.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Steam_MT_Got_Response();

		// Token: 0x06001E1E RID: 7710 RVA: 0x001D18E4 File Offset: 0x001CFAE4
		public static bool testMutex()
		{
			try
			{
				IpcClientChannel chnl = new IpcClientChannel();
				ChannelServices.RegisterChannel(chnl, false);
				SHKMutex shkmutex = (SHKMutex)Activator.GetObject(typeof(SHKMutex), "ipc://SHKMutex/KingdomsRemoteObj");
				try
				{
					if (shkmutex.HelloWorld() == "Hello World")
					{
						return true;
					}
				}
				catch (Exception)
				{
				}
				ChannelServices.UnregisterChannel(chnl);
				IpcServerChannel chnl2 = new IpcServerChannel("SHKMutex");
				ChannelServices.RegisterChannel(chnl2, false);
				RemotingConfiguration.RegisterWellKnownServiceType(typeof(SHKMutexObject), "KingdomsRemoteObj", WellKnownObjectMode.SingleCall);
			}
			catch (Exception)
			{
			}
			return false;
		}

		// Token: 0x06001E1F RID: 7711 RVA: 0x001D1984 File Offset: 0x001CFB84
		[STAThread]
		private static void Main(string[] args)
		{
			bool flag = false;
			bool flag2 = false;
			string text = "en";
			AutoUpdates.ProcessUpdater();
			if (AutoUpdates.ProcessGame())
			{
				Environment.Exit(0);
			}
			if (args == null || args.Length < 1)
			{
				args = ControlForm.GetMainMethodArgs();
			}
			if (args == null || args.Length < 1)
			{
				flag = true;
			}
			if (args != null && args.Length > 1)
			{
				if (args[0].ToLowerInvariant() == "-installerversion")
				{
					int num = Convert.ToInt32(args[1]);
					if (num < Program.CurrentInstallerBuild)
					{
						flag2 = true;
					}
				}
				else if (!(args[0].ToLowerInvariant() == "-installer"))
				{
					flag = true;
				}
				if (args.Length > 2)
				{
					if (args[2].Length > 0)
					{
						text = args[2];
						if (text == "sc")
						{
							text = "zh";
						}
						else if (text == "tc")
						{
							text = "zhhk";
						}
					}
					if (args.Length > 3 && args[3].Length > 0)
					{
						if (args[3] == "st")
						{
							Program.steamInstall = true;
						}
						if (args[3] == "bp")
						{
							Program.bigpointInstall = true;
						}
						if (args[3] == "bp2")
						{
							Program.bigpointPartnerInstall = true;
						}
						if (args[3] == "ws")
						{
							Program.winStore = true;
						}
						if (args[3] == "ae")
						{
							Program.aeriaInstall = true;
						}
						if (args[3] == "gf")
						{
							Program.gamersFirstInstall = true;
							if (args.Length > 4 && args[4].Length > 0)
							{
								Program.gamersFirstTokenMD5 = args[4];
							}
						}
						if (args[3] == "arc")
						{
							if (args.Length > 4)
							{
								Program.arcUsername = args[4];
								Program.arcInstall = true;
								if (Program.arcUsername.Length <= 0)
								{
									Program.arcLauncherStart = true;
								}
							}
							else
							{
								Program.arcLauncherStart = true;
							}
						}
					}
				}
			}
			else
			{
				flag2 = true;
			}
			DateTime now = DateTime.Now;
			Program.xmas_period = HolidayPeriods.xmas(now);
			if (Program.arcLauncherStart)
			{
				Program.arc_launchClient(text);
			}
			else if (flag)
			{
				MessageBox.Show(SK.Text("ProgramMain_Launch_Failure1", "This is not the game exe!") + Environment.NewLine + Environment.NewLine + SK.Text("ProgramMain_Launch_Failure2", "Please run Stronghold Kingdoms in the normal manner."), SK.Text("ProgramMain_Launch_Failure", "Stronghold Kingdoms Error"), MessageBoxButtons.OK);
			}
			else if (flag2 && !Program.steamInstall)
			{
				MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
				DialogResult dialogResult = MessageBox.Show(string.Concat(new string[]
				{
					SK.Text("ProgramMain_New_nInstaller", "A new version of the Updater/Installer is needed"),
					Environment.NewLine,
					SK.Text("ProgramMain_Must_Install", "You cannot Launch Stronghold Kingdoms until this is installed"),
					Environment.NewLine,
					Environment.NewLine,
					SK.Text("ProgramMain_Install_Now", "Do you wish to install this now?")
				}), SK.Text("ProgramMain_Installer_Update", "Stronghold Kingdoms Installer Update"), buttons);
				if (dialogResult == DialogResult.OK)
				{
					string uriString = "http://static.strongholdkingdoms.com/Kingdoms/kingdoms-setup-update-" + Program.CurrentInstallerBuild.ToString() + ".exe";
					string text2 = InstallerUpdater.downloadSelfUpdater(new Uri(uriString));
					if (text2 != null && text2.Length > 0)
					{
						InstallerUpdater.runInstaller(text2);
					}
				}
			}
			else
			{
				string name = "Global\\StrongholdKingdoms";
				bool flag3 = false;
				using (new Mutex(true, name, out flag3))
				{
					try
					{
						OperatingSystem osversion = Environment.OSVersion;
						PlatformID platform = osversion.Platform;
						if (platform == PlatformID.Win32NT && osversion.Version.Major >= 6)
						{
							Program.SetProcessDPIAware();
						}
					}
					catch (Exception)
					{
					}
					AppDomain.CurrentDomain.UnhandledException += Program.CurrentDomain_UnhandledException;
					Application.ThreadException += Program.CurrentDomain_ThreadException;
					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault(false);
					string langsPath = GameEngine.getLangsPath();
					Program.communityLangs = SKLocalization.scanForLanguages(langsPath);
					Program.installedLangCode = text;
					Program.mySettings = MySettings.load();
					if (Program.mySettings.LanguageIdent.Length == 0)
					{
						Program.mySettings.LanguageIdent = text;
					}
					else if (Program.mySettings.InstalledLanguageIdent != text)
					{
						Program.mySettings.LanguageIdent = text;
						Program.mySettings.InstalledLanguageIdent = text;
					}
					Program.syslang = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName.ToLower();
					if (!Program.mySettings.OwnLanguageAvailableAndChecked)
					{
						string text3 = Program.syslang;
						if (text3 == "ja")
						{
							text3 = "jp";
						}
						if (text3 != Program.mySettings.LanguageIdent)
						{
							if (text3 != null)
							{
								uint num2 = PrivateImplementationDetails.ComputeStringHash(text3);
								if (num2 <= 1194886160U)
								{
									if (num2 <= 1162757945U)
									{
										if (num2 != 1092248970U)
										{
											if (num2 != 1111292255U)
											{
												if (num2 != 1162757945U)
												{
													goto IL_946;
												}
												if (!(text3 == "pl"))
												{
													goto IL_946;
												}
											}
											else if (!(text3 == "ko"))
											{
												goto IL_946;
											}
										}
										else
										{
											if (!(text3 == "en"))
											{
												goto IL_946;
											}
											Program.mySettings.OwnLanguageAvailableAndChecked = true;
											goto IL_946;
										}
									}
									else if (num2 != 1164435231U)
									{
										if (num2 != 1176137065U)
										{
											if (num2 != 1194886160U)
											{
												goto IL_946;
											}
											if (!(text3 == "it"))
											{
												goto IL_946;
											}
										}
										else if (!(text3 == "es"))
										{
											goto IL_946;
										}
									}
									else if (!(text3 == "zh"))
									{
										goto IL_946;
									}
								}
								else if (num2 <= 1241987482U)
								{
									if (num2 != 1195724803U)
									{
										if (num2 != 1213488160U)
										{
											if (num2 != 1241987482U)
											{
												goto IL_946;
											}
											if (!(text3 == "zhhk"))
											{
												goto IL_946;
											}
										}
										else if (!(text3 == "ru"))
										{
											goto IL_946;
										}
									}
									else if (!(text3 == "tr"))
									{
										goto IL_946;
									}
								}
								else if (num2 <= 1545391778U)
								{
									if (num2 != 1461901041U)
									{
										if (num2 != 1545391778U)
										{
											goto IL_946;
										}
										if (!(text3 == "de"))
										{
											goto IL_946;
										}
									}
									else if (!(text3 == "fr"))
									{
										goto IL_946;
									}
								}
								else if (num2 != 1564435063U)
								{
									if (num2 != 1565420801U)
									{
										goto IL_946;
									}
									if (!(text3 == "pt"))
									{
										goto IL_946;
									}
								}
								else if (!(text3 == "jp"))
								{
									goto IL_946;
								}
								string text4 = SK.Text("ProgramMain_A_New_Language", "A New Language is available : ");
								if (text3 != null)
								{
									num2 = PrivateImplementationDetails.ComputeStringHash(text3);
									if (num2 <= 1195724803U)
									{
										if (num2 <= 1164435231U)
										{
											if (num2 != 1111292255U)
											{
												if (num2 != 1162757945U)
												{
													if (num2 == 1164435231U)
													{
														if (text3 == "zh")
														{
															text4 += "????";
														}
													}
												}
												else if (text3 == "pl")
												{
													text4 += "Polski";
												}
											}
											else if (text3 == "ko")
											{
												text4 += "???";
											}
										}
										else if (num2 != 1176137065U)
										{
											if (num2 != 1194886160U)
											{
												if (num2 == 1195724803U)
												{
													if (text3 == "tr")
													{
														text4 += "Turkce";
													}
												}
											}
											else if (text3 == "it")
											{
												text4 += "Italiano";
											}
										}
										else if (text3 == "es")
										{
											text4 += "Espanol";
										}
									}
									else if (num2 <= 1461901041U)
									{
										if (num2 != 1213488160U)
										{
											if (num2 != 1241987482U)
											{
												if (num2 == 1461901041U)
												{
													if (text3 == "fr")
													{
														text4 += "Francais";
													}
												}
											}
											else if (text3 == "zhhk")
											{
												text4 += "????";
											}
										}
										else if (text3 == "ru")
										{
											text4 += "�������";
										}
									}
									else if (num2 != 1545391778U)
									{
										if (num2 != 1564435063U)
										{
											if (num2 == 1565420801U)
											{
												if (text3 == "pt")
												{
													text4 += "Portugues do Brasil";
												}
											}
										}
										else if (text3 == "jp")
										{
											text4 += "???";
										}
									}
									else if (text3 == "de")
									{
										text4 += "Deutsch";
									}
								}
								text4 += Environment.NewLine;
								text4 += SK.Text("ProgramMain_Use_New_Language", "Your system settings indicate you are using this language, do you wish to play Stronghold Kingdoms in this language?");
								DialogResult dialogResult2 = MessageBox.Show(text4, SK.Text("ProgramMain_NewLanguageAvailable", "New Language Available"), MessageBoxButtons.YesNo);
								if (dialogResult2 == DialogResult.Yes)
								{
									Program.mySettings.LanguageIdent = text3;
								}
								Program.mySettings.OwnLanguageAvailableAndChecked = true;
							}
						}
						else
						{
							Program.mySettings.OwnLanguageAvailableAndChecked = true;
						}
					}
					IL_946:
					string languageIdent = Program.mySettings.LanguageIdent;
					if (languageIdent != null)
					{
						uint num2 = PrivateImplementationDetails.ComputeStringHash(languageIdent);
						if (num2 <= 1194886160U)
						{
							if (num2 <= 1162757945U)
							{
								if (num2 != 1092248970U)
								{
									if (num2 != 1111292255U)
									{
										if (num2 != 1162757945U)
										{
											goto IL_B4A;
										}
										if (!(languageIdent == "pl"))
										{
											goto IL_B4A;
										}
									}
									else if (!(languageIdent == "ko"))
									{
										goto IL_B4A;
									}
								}
								else if (!(languageIdent == "en"))
								{
									goto IL_B4A;
								}
							}
							else if (num2 != 1164435231U)
							{
								if (num2 != 1176137065U)
								{
									if (num2 != 1194886160U)
									{
										goto IL_B4A;
									}
									if (!(languageIdent == "it"))
									{
										goto IL_B4A;
									}
								}
								else if (!(languageIdent == "es"))
								{
									goto IL_B4A;
								}
							}
							else if (!(languageIdent == "zh"))
							{
								goto IL_B4A;
							}
						}
						else if (num2 <= 1241987482U)
						{
							if (num2 != 1195724803U)
							{
								if (num2 != 1213488160U)
								{
									if (num2 != 1241987482U)
									{
										goto IL_B4A;
									}
									if (!(languageIdent == "zhhk"))
									{
										goto IL_B4A;
									}
								}
								else if (!(languageIdent == "ru"))
								{
									goto IL_B4A;
								}
							}
							else if (!(languageIdent == "tr"))
							{
								goto IL_B4A;
							}
						}
						else if (num2 <= 1545391778U)
						{
							if (num2 != 1461901041U)
							{
								if (num2 != 1545391778U)
								{
									goto IL_B4A;
								}
								if (!(languageIdent == "de"))
								{
									goto IL_B4A;
								}
							}
							else if (!(languageIdent == "fr"))
							{
								goto IL_B4A;
							}
						}
						else if (num2 != 1564435063U)
						{
							if (num2 != 1565420801U)
							{
								goto IL_B4A;
							}
							if (!(languageIdent == "pt"))
							{
								goto IL_B4A;
							}
						}
						else if (!(languageIdent == "jp"))
						{
							goto IL_B4A;
						}
						SKLocalization.LoadLocalization(Application.StartupPath + "\\Localization\\", Program.mySettings.LanguageIdent);
						goto IL_BF6;
					}
					IL_B4A:
					bool flag4 = false;
					foreach (SKLang sklang in Program.communityLangs)
					{
						if (sklang.id == Program.mySettings.LanguageIdent)
						{
							string langsPath2 = GameEngine.getLangsPath();
							SKLocalization.LoadLocalization(langsPath2, sklang.id);
							flag4 = (SKLocalization.Instance != null && SKLocalization.Instance.valid);
							break;
						}
					}
					if (!flag4)
					{
						Program.mySettings.LanguageIdent = "en";
						SKLocalization.LoadLocalization(Application.StartupPath + "\\Localization\\", Program.mySettings.LanguageIdent);
					}
					IL_BF6:
					if (Program.steamInstall)
					{
						bool flag5 = false;
						try
						{
							int num3 = Program.Steam_Init();
							if (num3 > 0)
							{
								Program.steamActive = true;
								Program.Steam_getTicket();
								string text5 = BitConverter.ToString(Program.steam_SessionTicket);
								text5 = text5.Replace("-", "");
								XmlRpcAuthRequest req = new XmlRpcAuthRequest("", "", "", "", text5, "", "", "");
								XmlRpcAuthProvider xmlRpcAuthProvider = XmlRpcAuthProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressLogin, URLs.ProfileServerPort, URLs.ProfilePath);
								XmlRpcAuthResponse xmlRpcAuthResponse = xmlRpcAuthProvider.AuthenticateSteamAccount(req, null, null, 15000);
								int? successCode = xmlRpcAuthResponse.SuccessCode;
								int num4 = 1;
								if (successCode.GetValueOrDefault() == num4 & successCode != null)
								{
									flag5 = true;
									Program.steamID = xmlRpcAuthResponse.Message;
									Program.steamEmail = xmlRpcAuthResponse.UserGUID;
									Program.mySettings.AutoLogin = false;
									if (Program.steamEmail.Trim().Length > 0)
									{
										Program.kingdomsAccountFound = true;
									}
									else
									{
										Program.kingdomsAccountFound = false;
									}
								}
							}
						}
						catch (Exception)
						{
							Program.steamActive = false;
						}
						if (!flag5)
						{
							MessageBox.Show(SK.Text("Steam_steam_required", "Stronghold Kingdoms requires the Steam Client to be running in Online mode."), SK.Text("Steam_error", "Steam Error"));
							Application.Exit();
							goto IL_15C8;
						}
					}
					if (!Program.arcInstall || Program.arc_login(Program.arcUsername))
					{
						if (Program.gamersFirstInstall && Program.gamersFirstTokenMD5.Length == 0)
						{
							MessageBox.Show(SK.Text("GF_token_error", "Unable to verify your GamersFirst identity. Please try again. If this issue persists, please contact support."), SK.Text("GF_Error", "GamersFirst Error"));
							Application.Exit();
						}
						else
						{
							LoadingPanel loadingPanel = new LoadingPanel();
							loadingPanel.init();
							loadingPanel.Show();
							loadingPanel.TopMost = true;
							loadingPanel.BringToFront();
							loadingPanel.Focus();
							loadingPanel.BringToFront();
							loadingPanel.TopMost = false;
							string binDirectory = Application.StartupPath + "\\geckofx\\xulrunner33";
							Xpcom.Initialize(binDirectory);
							bool flag6 = Program.testMutex();
							if (!flag3 || flag6)
							{
								MessageBox.Show("2+ worlds from 1 account = ban!", "Bot's warning :)");
							}
							bool flag7 = true;
							Program.TimerCaps timerCaps = default(Program.TimerCaps);
							Program.timeGetDevCaps(ref timerCaps, Marshal.SizeOf(timerCaps));
							Program.timerPeriod = Math.Max(timerCaps.periodMin, 1U);
							Program.timeBeginPeriod(Program.timerPeriod);
							DXTimer.Init();
							GameEngine gameEngine = null;
							try
							{
								gameEngine = new GameEngine();
							}
							catch (FileNotFoundException ex)
							{
								if (ex.FileName.Contains("irectX"))
								{
									GameEngine.displayDirectXError();
								}
								Program.timeEndPeriod(Program.timerPeriod);
								loadingPanel.Close();
								return;
							}
							GraphicsMgr mgr = new GraphicsMgr();
							int maxRes = 2;
							System.Windows.Forms.Screen primaryScreen = System.Windows.Forms.Screen.PrimaryScreen;
							int width = primaryScreen.Bounds.Width;
							int height = primaryScreen.Bounds.Height;
							if (width < 1024 || height < 768)
							{
								MessageBoxButtons buttons2 = MessageBoxButtons.YesNo;
								loadingPanel.Close();
								loadingPanel = null;
								DialogResult dialogResult3 = MessageBox.Show(SK.Text("ProgramMain_Screen_Too_Small", "Your screen resolution is too small to run Stronghold Kingdoms") + Environment.NewLine + Environment.NewLine + SK.Text("ProgramMain_Try_Anyway", "Try to anyway?"), SK.Text("ProgramMain_Error", "Error"), buttons2);
								if (dialogResult3 != DialogResult.Yes)
								{
									Program.timeEndPeriod(Program.timerPeriod);
									goto IL_15BA;
								}
							}
							int num5 = width - 80;
							int num6 = height - 100;
							if (num5 < 944)
							{
								num5 = 944;
							}
							if (num6 < 668)
							{
								num6 = 668;
							}
							Program.mySettings.Save();
							CastleMap.displayCollapsed = Program.mySettings.CastleWalls;
							Form form = new MainWindow();
							form.Visible = false;
							if (Program.arcInstall)
							{
								Program.arc_init(form);
							}
							((MainWindow)form).allowResizing(false);
							int num7 = num5;
							int num8 = num6;
							if (Program.mySettings.ScreenWidth > 0)
							{
								num7 = Program.mySettings.ScreenWidth;
							}
							if (Program.mySettings.ScreenHeight > 0)
							{
								num8 = Program.mySettings.ScreenHeight;
							}
							if (num7 > width)
							{
								num7 = width;
							}
							if (num8 > height)
							{
								num8 = height;
							}
							if (flag7)
							{
								form.MaximumSize = new Size(3840, 2160);
								form.ClientSize = new Size(num7, num8);
							}
							else
							{
								form.ClientSize = new Size(1000, 720);
								form.MaximumSize = new Size(1050, 760);
							}
							if (Program.mySettings.Maximize)
							{
								form.WindowState = FormWindowState.Maximized;
							}
							form.Text = "Stronghold Kingdoms";
							((MainWindow)form).allowResizing(true);
							MainWindow mainWindow = (MainWindow)form;
							InterfaceMgr.Instance.registerForm(form, mainWindow);
							if (!gameEngine.Initialise(mgr, maxRes, 2))
							{
								if (loadingPanel != null)
								{
									loadingPanel.Close();
									loadingPanel = null;
								}
							}
							else
							{
								SVG_Source instance = SVG_Source.Instance;
								Sound.setMusicState(Program.mySettings.Music);
								GameEngine.Instance.AudioEngine.setMP3MasterVolume((float)Program.mySettings.MusicVolume / 100f, 0);
								Sound.setSFXState(Program.mySettings.SFX);
								Sound.setBattleSFXState(Program.mySettings.BattleSFX);
								GameEngine.Instance.AudioEngine.setSFXMasterVolume((float)Program.mySettings.SFXVolume / 100f);
								Sound.setEnvironmentalState(Program.mySettings.Environmentals);
								GameEngine.Instance.AudioEngine.setEnvironmentalMasterVolume((float)Program.mySettings.EnvironmentalVolume / 100f);
								bool flag8 = true;
								if (loadingPanel != null)
								{
									loadingPanel.Close();
									loadingPanel = null;
								}
								RemoteServices.Instance.initChannel();
								while (flag8)
								{
									gameEngine.reLogin();
									flag8 = false;
									RemoteServices.Instance.UserID = -1;
									RemoteServices.Instance.set_CommonData_UserCallBack(null);
									while (RemoteServices.Instance.UserID < 0)
									{
										gameEngine.installKeyboardHook();
										GameEngine.Instance.reLogin();
										GameEngine.Instance.clearServerDowntime();
										Program.profileLogin = gameEngine.getLoginWindow();
										if (Program.profileLogin == null)
										{
											Program.profileLogin = new ProfileLoginWindow();
											GameEngine.Instance.setProfileLogin(Program.profileLogin);
											Program.profileLogin.Show();
											Program.profileLogin.init();
										}
										else
										{
											Program.profileLogin.openAfterCancel();
										}
										RemoteServices.Instance.clearQueues();
										while (Program.profileLogin.Created && Program.profileLogin.UserEntryMode)
										{
											RemoteServices.Instance.processData();
											Thread.Sleep(1);
											Program.DoEvents();
											Program.profileLogin.update();
											StatTrackingClient.Instance().Update(0.01);
										}
										GameEngine.Instance.reLogin();
										form.Text = "Stronghold Kingdoms";
										if (Program.WorldName != string.Empty)
										{
											form.Text = form.Text + " - " + Program.WorldName;
										}
										if (RemoteServices.Instance.UserID == -1)
										{
											GameEngine.Instance.killLoadThread();
											Program.mySettings.Maximize = (form.WindowState == FormWindowState.Maximized);
											form.Close();
											Program.shutdown();
											return;
										}
									}
									gameEngine.showConnectingPopup();
									gameEngine.World.loadLocalWorldData();
									gameEngine.World.updateWorldMapOwnership();
									bool flag9 = true;
									while (flag9)
									{
										flag9 = false;
										VillageMap.loadVillageBuildingsGFX();
										while (gameEngine.isStillLoading())
										{
											Thread.Sleep(10);
											Program.DoEvents();
											RemoteServices.Instance.processData();
											GameEngine.Instance.updateConnectingPopup();
										}
										GameEngine.Instance.World.initSprites(GameEngine.Instance.GFX);
										GameEngine.Instance.resumeCommonRemote();
										gameEngine.enableConnectingPopup();
										DX.ControlForm = new ControlForm(true);
										while (!GameEngine.Instance.World.isDownloadComplete())
										{
											Thread.Sleep(10);
											Application.DoEvents();
											RemoteServices.Instance.processData();
											GameEngine.Instance.updateConnectingPopup();
											if (gameEngine.loginCancelled())
											{
												break;
											}
										}
										DX.ControlForm.Show();
										DX.ControlForm.AutomaticActions();
										if (gameEngine.pendingError())
										{
											gameEngine.updateConnectingPopup();
											gameEngine.forceRelogin();
										}
										if (!gameEngine.loginCancelled())
										{
											gameEngine.World.saveFactionData();
											gameEngine.World.saveNamesData();
											gameEngine.enableConnectingPopup2();
											while (gameEngine.waitForConnectingPopupToClose())
											{
												Thread.Sleep(10);
												Program.DoEvents();
												RemoteServices.Instance.processData();
												if (gameEngine.loginCancelled())
												{
													break;
												}
											}
										}
										if (RemoteServices.Instance.UserID == -1)
										{
											GameEngine.Instance.killLoadThread();
											Program.mySettings.Maximize = (form.WindowState == FormWindowState.Maximized);
											form.Close();
											Program.shutdown();
											return;
										}
										Sound.playMusic();
										bool flag10 = false;
										if (!gameEngine.reLogin())
										{
											InterfaceMgr.Instance.setupVillageName();
											form.Show();
											form.Visible = true;
											mainWindow.MainWindowLarge_SizeChanged(null, null);
											GameEngine.Instance.lateStart();
											if (GameEngine.Instance.World.numVillagesOwned() > 0 && RemoteServices.Instance.ShowAdminMessage)
											{
												AdminInfoPopup.showMessage();
											}
											while (form.Created)
											{
												gameEngine.run();
												if (gameEngine.reLogin())
												{
													form.Hide();
													form.Visible = false;
													gameEngine.windowClosing();
													if (!gameEngine.quitting())
													{
														flag8 = true;
													}
													flag10 = true;
													break;
												}
												StatTrackingClient.Instance().Update(0.01);
												RemoteServices.Instance.processData();
												if (form.Created)
												{
													Thread.Sleep(1);
												}
											}
										}
										else
										{
											flag8 = true;
											flag10 = true;
										}
										if (!flag10)
										{
											form.Hide();
											form.Visible = false;
											form = null;
											mainWindow = null;
										}
										gameEngine.World.saveFactionData();
										gameEngine.World.saveNamesData();
										Sound.stopMusic();
									}
								}
								try
								{
									if (form != null)
									{
										Program.mySettings.Maximize = (form.WindowState == FormWindowState.Maximized);
									}
								}
								catch (Exception)
								{
								}
								Program.shutdown();
							}
						}
					}
					IL_15BA:;
				}
			}
			IL_15C8:
			DX.CloseBotWindow();
		}

		// Token: 0x06001E20 RID: 7712 RVA: 0x0001CE27 File Offset: 0x0001B027
		public static void DoEvents()
		{
			Application.DoEvents();
			CustomSelfDrawPanel.processInvalidRectCache();
		}

		// Token: 0x06001E21 RID: 7713 RVA: 0x001D2FF4 File Offset: 0x001D11F4
		private static void shutdown()
		{
			Program.mySettings.CastleWalls = CastleMap.displayCollapsed;
			StatTrackingClient.Instance().Terminate();
			Program.mySettings.Save();
			RemoteServices.Instance.LogOut(false, false, false, false, false, false, false, 0, 100, false, false, false, false, false, false, 500, 500, 500, 500, 250);
			GameEngine.Instance.uninstallKeyboardHook();
			Thread.Sleep(1000);
			Program.unloadGeckoDLLs();
			Program.timeEndPeriod(Program.timerPeriod);
			if (GameEngine.Instance.AudioEngine != null)
			{
				GameEngine.Instance.AudioEngine.closeAudio();
			}
			if (Program.arcInstall)
			{
				Program.Arc_Exit();
			}
		}

		// Token: 0x06001E22 RID: 7714 RVA: 0x001D30A4 File Offset: 0x001D12A4
		private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			Exception ex = e.ExceptionObject as Exception;
			MessageBox.Show(string.Concat(new string[]
			{
				SK.Text("ProgramMain_Unexpected_Error", "There has been an unexpected error. Please forward a copy of this report to Support."),
				"\n\n",
				ex.Message,
				"\n\n",
				ex.ToString()
			}), SK.Text("ProgramMain_SK_Error", "Stronghold Kingdoms Error"));
			Application.Exit();
		}

		// Token: 0x06001E23 RID: 7715 RVA: 0x001D3118 File Offset: 0x001D1318
		private static void CurrentDomain_ThreadException(object sender, ThreadExceptionEventArgs e)
		{
			Exception exception = e.Exception;
			MessageBox.Show(string.Concat(new string[]
			{
				SK.Text("ProgramMain_Unexpected_Error", "There has been an unexpected error. Please forward a copy of this report to Support."),
				"\n\n",
				exception.Message,
				"\n\n",
				exception.ToString()
			}), SK.Text("ProgramMain_SK_Error", "Stronghold Kingdoms Error"));
			Application.Exit();
		}

		// Token: 0x06001E24 RID: 7716
		[DllImport("kernel32.dll")]
		private static extern IntPtr LoadLibraryEx(string dllFilePath, IntPtr hFile, uint dwFlags);

		// Token: 0x06001E25 RID: 7717
		[DllImport("kernel32.dll")]
		public static extern bool FreeLibrary(IntPtr dllPointer);

		// Token: 0x06001E26 RID: 7718 RVA: 0x001D3188 File Offset: 0x001D1388
		private static void loadGeckoDLLs(string basePath)
		{
			string[] array = Program.geckoFXDlls;
			foreach (string str in array)
			{
				IntPtr intPtr = Program.LoadWin32Library(basePath + "\\" + str);
				if (intPtr != IntPtr.Zero)
				{
					Program.loadedDLLs.Add(intPtr);
				}
			}
		}

		// Token: 0x06001E27 RID: 7719 RVA: 0x001D31DC File Offset: 0x001D13DC
		private static void unloadGeckoDLLs()
		{
			foreach (IntPtr dllPointer in Program.loadedDLLs)
			{
				Program.FreeLibrary(dllPointer);
			}
		}

		// Token: 0x06001E28 RID: 7720 RVA: 0x001D3230 File Offset: 0x001D1430
		public static IntPtr LoadWin32Library(string dllFilePath)
		{
			try
			{
				IntPtr intPtr = Program.LoadLibraryEx(dllFilePath, IntPtr.Zero, Program.LOAD_WITH_ALTERED_SEARCH_PATH);
				bool isZero = intPtr == IntPtr.Zero;
				return intPtr;
			}
			catch (Exception)
			{
			}
			return IntPtr.Zero;
		}

		// Token: 0x06001E29 RID: 7721 RVA: 0x0001CE33 File Offset: 0x0001B033
		public static void OLActive()
		{
			Program.steamOverlayActive = true;
			InterfaceMgr.Instance.closeAllPopups();
			InterfaceMgr.Instance.ParentMainWindow.makeFullDX();
		}

		// Token: 0x06001E2A RID: 7722 RVA: 0x0001CE54 File Offset: 0x0001B054
		public static void OLInactive()
		{
			Program.steamOverlayActive = false;
			InterfaceMgr.Instance.ParentMainWindow.restoreDXSize();
		}

		// Token: 0x06001E2B RID: 7723 RVA: 0x001D3278 File Offset: 0x001D1478
		public unsafe static void Steam_getTicket()
		{
			IntPtr intPtr = Program.Steam_GetAuthTicket();
			int num = Program.Steam_GetAuthTicketLength();
			if (num != -1)
			{
				byte* ptr = (byte*)intPtr.ToPointer();
				Program.steam_SessionTicket = new byte[num];
				for (int i = 0; i < num; i++)
				{
					Program.steam_SessionTicket[i] = ptr[i];
				}
			}
		}

		// Token: 0x06001E2C RID: 7724 RVA: 0x001D32C0 File Offset: 0x001D14C0
		public unsafe static string GetLocalUserName()
		{
			if (Program.steamActive)
			{
				byte* ptr = (byte*)Program.Steam_User_GetPersonaName().ToPointer();
				int num = 0;
				while (ptr[num] != 0)
				{
					num++;
				}
				byte[] array = new byte[num];
				int num2 = 0;
				while (ptr[num2] != 0)
				{
					array[num2] = ptr[num2];
					num2++;
				}
				return Encoding.UTF8.GetString(array, 0, num);
			}
			return "";
		}

		// Token: 0x06001E2D RID: 7725 RVA: 0x0001CE6B File Offset: 0x0001B06B
		public static ulong Steam_GetSteamUserID()
		{
			if (Program.steamActive)
			{
				return Program.Steam_User_GetLocalUserSteamID();
			}
			return 0UL;
		}

		// Token: 0x06001E2E RID: 7726 RVA: 0x0001CE7C File Offset: 0x0001B07C
		public static bool Steam_PollOverlayStatus()
		{
			return Program.steamActive && Program.Steam_OverlayActive() > 0;
		}

		// Token: 0x06001E2F RID: 7727 RVA: 0x0001CE8F File Offset: 0x0001B08F
		public static void forceSteamDXOverlay()
		{
			if (!InterfaceMgr.Instance.isDXVisible())
			{
				InterfaceMgr.Instance.changeTab(9);
				InterfaceMgr.Instance.changeTab(0);
				Program.lastOverlayState = true;
				Program.OLActive();
			}
		}

		// Token: 0x06001E30 RID: 7728 RVA: 0x001D3328 File Offset: 0x001D1528
		public static void steam_run()
		{
			if (!Program.steamActive)
			{
				return;
			}
			Program.Steam_RunCallBacks();
			bool flag = Program.lastOverlayState;
			if (Program.Steam_OverlayActive() > 0)
			{
				if (!Program.lastOverlayState)
				{
					Program.lastOverlayState = true;
					Program.OLActive();
				}
			}
			else if (Program.lastOverlayState)
			{
				Program.lastOverlayState = false;
				Program.OLInactive();
			}
			if (!Program.lastOverlayState && !flag && GameEngine.tabPressed && GameEngine.shiftPressed && Program.Steam_IsOverlayEnabled() > 0 && !InterfaceMgr.Instance.isDXVisible())
			{
				InterfaceMgr.Instance.changeTab(9);
				InterfaceMgr.Instance.changeTab(0);
				Program.Steam_OpenOverlay();
			}
			if (Program.Steam_MT_Got_Response() <= 0)
			{
				return;
			}
			bool flag2 = Program.Steam_MT_Authorised() == 1;
			ulong num = Program.Steam_MT_OrderID();
			Program.Steam_MT_AppID();
			Program.Steam_MT_Clear_Response();
			if (flag2)
			{
				XmlRpcAuthProvider xmlRpcAuthProvider = XmlRpcAuthProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressLogin, URLs.ProfileServerPort, URLs.ProfilePath);
				XmlRpcAuthResponse xmlRpcAuthResponse = xmlRpcAuthProvider.SteamPaymentFinal(new XmlRpcAuthRequest(RemoteServices.Instance.UserGuid.ToString().Replace("-", ""), "", "", "", RemoteServices.Instance.SessionGuid.ToString().Replace("-", ""), null, null, null)
				{
					OrderID = num.ToString()
				}, null, null, 15000);
				int? successCode = xmlRpcAuthResponse.SuccessCode;
				int num2 = 1;
				if (successCode.GetValueOrDefault() == num2 & successCode != null)
				{
					MyMessageBox.Show(SK.Text("STEAM_AUTHORIZED_OK", "Your payment was received and your crowns have been credited - Thank You!"));
					return;
				}
				MyMessageBox.Show(SK.Text("STEAM_AUTHORIZED_BAD", "There was a problem processing your payment through Steam, please contact support."));
			}
		}

		// Token: 0x06001E31 RID: 7729 RVA: 0x001D34D8 File Offset: 0x001D16D8
		private static string readLocalTxt()
		{
			string text = "en";
			StreamReader streamReader = null;
			try
			{
				streamReader = File.OpenText(Application.StartupPath + "\\local.txt");
				text = streamReader.ReadLine();
				streamReader.Close();
			}
			catch (Exception)
			{
				try
				{
					if (streamReader != null)
					{
						streamReader.Close();
					}
				}
				catch (Exception)
				{
				}
			}
			text = text.Substring(0, 2);
			if (text != "en" && text != "fr" && text != "de" && text != "ru" && text != "es")
			{
				text = "en";
			}
			return text;
		}

		// Token: 0x06001E32 RID: 7730 RVA: 0x001D3590 File Offset: 0x001D1790
		public static bool arc_login(string username)
		{
			if (Program.arcInstall)
			{
				Program.arcUsername = username;
				IntPtr zero = IntPtr.Zero;
				if (Program.Arc_Init(zero) == 0)
				{
					MessageBox.Show(SK.Text("ARC_Init_Error", "Unable to initialize Arc"), SK.Text("ARC_Error", "Arc Error"));
					return false;
				}
				Program.arc_initialised = true;
				Program.arcToken = Program.arc_getTicket(username);
				if (Program.arcToken == "")
				{
					MessageBox.Show(SK.Text("ARC_Login_Error", "Unable to login with user") + " : " + username, SK.Text("ARC_Error", "Arc Error"));
					return false;
				}
				Program.Arc_Exit();
			}
			return true;
		}

		// Token: 0x06001E33 RID: 7731 RVA: 0x001D363C File Offset: 0x001D183C
		public static string getNewArcToken()
		{
			if (Program.arc_initialised)
			{
				return Program.arc_getTicket(Program.arcUsername);
			}
			IntPtr zero = IntPtr.Zero;
			if (Program.Arc_Init(zero) != 0)
			{
				string result = Program.arc_getTicket(Program.arcUsername);
				Program.Arc_Exit();
				return result;
			}
			return "";
		}

		// Token: 0x06001E34 RID: 7732 RVA: 0x0001CEBF File Offset: 0x0001B0BF
		public static void arc_exit()
		{
			if (Program.arcInstall)
			{
				if (Program.arc_initialised)
				{
					Program.Arc_Exit();
				}
				Program.arc_initialised = false;
			}
		}

		// Token: 0x06001E35 RID: 7733 RVA: 0x0001CEDA File Offset: 0x0001B0DA
		public static void arc_init(Form form)
		{
			if (Program.arcInstall && Program.Arc_Init(form.Handle) != 0)
			{
				Program.arc_form = form;
				Program.arc_initialised = true;
				Program.arc_overlay_open = false;
				Program.last_arc_overlay_open = false;
				Program.arc_overlay_delay = 0;
			}
		}

		// Token: 0x06001E36 RID: 7734 RVA: 0x001D3680 File Offset: 0x001D1880
		private unsafe static string arc_getTicket(string username)
		{
			List<char> list = new List<char>();
			foreach (char item in username)
			{
				list.Add(item);
			}
			char[] arr = list.ToArray();
			IntPtr username2 = Marshal.UnsafeAddrOfPinnedArrayElement(arr, 0);
			IntPtr value = Program.Arc_GetAuthToken(username2);
			if (value != (IntPtr)0)
			{
				char* ptr = (char*)value.ToPointer();
				List<char> list2 = new List<char>();
				int num = 0;
				while (num < 99 && ptr[num] != '\0')
				{
					list2.Add(ptr[num]);
					num++;
				}
				return new string(list2.ToArray());
			}
			return "";
		}

		// Token: 0x06001E37 RID: 7735 RVA: 0x001D3734 File Offset: 0x001D1934
		public static void arc_openURL(string url)
		{
			List<char> list = new List<char>();
			foreach (char item in url)
			{
				list.Add(item);
			}
			char[] arr = list.ToArray();
			IntPtr url2 = Marshal.UnsafeAddrOfPinnedArrayElement(arr, 0);
			if (!InterfaceMgr.Instance.isDXVisible())
			{
				InterfaceMgr.Instance.changeTab(9);
				InterfaceMgr.Instance.changeTab(0);
			}
			Program.Arc_OpenURL(url2);
		}

		// Token: 0x06001E38 RID: 7736 RVA: 0x0001CF0E File Offset: 0x0001B10E
		public static void arc_launchClient(string lang)
		{
			Program.Arc_LaunchClient();
		}

		// Token: 0x06001E39 RID: 7737 RVA: 0x001D37A8 File Offset: 0x001D19A8
		public static void arc_forceoverlay()
		{
			if (!InterfaceMgr.Instance.isDXVisible())
			{
				InterfaceMgr.Instance.changeTab(9);
				InterfaceMgr.Instance.changeTab(0);
			}
			InterfaceMgr.Instance.closeAllPopups();
			Program.arc_overlay_open = (Program.last_arc_overlay_open = true);
			Program.arc_delayedManualOpening = 6;
			Program.arc_delayedNextState = true;
		}

		// Token: 0x06001E3A RID: 7738 RVA: 0x001D37FC File Offset: 0x001D19FC
		public static void arc_run()
		{
			if (!Program.arcInstall || !Program.arc_initialised || Program.arc_form == null || !Program.arc_form.Visible)
			{
				return;
			}
			if (Program.arc_delayedManualOpening > 0)
			{
				Program.arc_delayedManualOpening--;
				if (Program.arc_delayedManualOpening != 0)
				{
					return;
				}
				if (Program.arc_delayedNextState)
				{
					if (!Program.arc_overlay_open)
					{
						Program.Arc_Overlay(1);
						return;
					}
				}
				else if (Program.arc_overlay_open)
				{
					Program.Arc_Overlay(0);
					return;
				}
			}
			else
			{
				if (Program.arc_overlay_delay > 0)
				{
					Program.arc_overlay_delay--;
					GameEngine.tabPressed = false;
					return;
				}
				if (Program.arc_overlay_open && !InterfaceMgr.Instance.isDXVisible())
				{
					Program.arc_overlay_open = (Program.last_arc_overlay_open = false);
					Program.Arc_Overlay(0);
				}
			}
		}

		// Token: 0x04002EBD RID: 11965
		public static int CurrentInstallerBuild = 116;

		// Token: 0x04002EBE RID: 11966
		public static int steam_SessionTicketUserID = 0;

		// Token: 0x04002EBF RID: 11967
		public static byte[] steam_SessionTicket = null;

		// Token: 0x04002EC0 RID: 11968
		public static bool steamActive = false;

		// Token: 0x04002EC1 RID: 11969
		public static string steamID = string.Empty;

		// Token: 0x04002EC2 RID: 11970
		public static string steamEmail = string.Empty;

		// Token: 0x04002EC3 RID: 11971
		public static bool kingdomsAccountFound = false;

		// Token: 0x04002EC4 RID: 11972
		public static string installedLangCode = "";

		// Token: 0x04002EC5 RID: 11973
		public static bool steamInstall = false;

		// Token: 0x04002EC6 RID: 11974
		public static bool bigpointInstall = false;

		// Token: 0x04002EC7 RID: 11975
		public static bool bigpointPartnerInstall = false;

		// Token: 0x04002EC8 RID: 11976
		public static bool aeriaInstall = false;

		// Token: 0x04002EC9 RID: 11977
		public static bool gamersFirstInstall = false;

		// Token: 0x04002ECA RID: 11978
		public static bool gamersFirstError = false;

		// Token: 0x04002ECB RID: 11979
		public static bool arcInstall = false;

		// Token: 0x04002ECC RID: 11980
		public static bool arc_overlay_open = false;

		// Token: 0x04002ECD RID: 11981
		public static int arc_overlay_delay = 0;

		// Token: 0x04002ECE RID: 11982
		public static string arcToken = "";

		// Token: 0x04002ECF RID: 11983
		public static string arcUsername = "";

		// Token: 0x04002ED0 RID: 11984
		public static bool arcLauncherStart = false;

		// Token: 0x04002ED1 RID: 11985
		public static bool winStore = false;

		// Token: 0x04002ED2 RID: 11986
		private static bool xmas_period = false;

		// Token: 0x04002ED3 RID: 11987
		public static List<SKLang> communityLangs = new List<SKLang>();

		// Token: 0x04002ED4 RID: 11988
		public static ProfileLoginWindow profileLogin = null;

		// Token: 0x04002ED5 RID: 11989
		private static uint timerPeriod = 1U;

		// Token: 0x04002ED6 RID: 11990
		public static MySettings mySettings = null;

		// Token: 0x04002ED7 RID: 11991
		public static string WorldName = string.Empty;

		// Token: 0x04002ED8 RID: 11992
		public static string syslang = "";

		// Token: 0x04002ED9 RID: 11993
		public static string gamersFirstTokenMD5 = "";

		// Token: 0x04002EDA RID: 11994
		private static uint LOAD_WITH_ALTERED_SEARCH_PATH = 8U;

		// Token: 0x04002EDB RID: 11995
		private static string[] geckoFXDlls = new string[]
		{
			"sqlite3.dll",
			"nspr4.dll",
			"softokn3.dll",
			"AccessibleMarshal.dll",
			"freebl3.dll",
			"IA2Marshal.dll",
			"ssl3.dll",
			"js3250.dll",
			"javaxpcomglue.dll",
			"nss3.dll",
			"mozctl.dll",
			"mozcrt19.dll",
			"mozctlx.dll",
			"nssdbm3.dll",
			"nssckbi.dll",
			"smime3.dll",
			"nssutil3.dll",
			"plc4.dll",
			"plds4.dll",
			"xpcom.dll",
			"xul.dll",
			"plugins\\npnul32.dll"
		};

		// Token: 0x04002EDC RID: 11996
		private static List<IntPtr> loadedDLLs = new List<IntPtr>();

		// Token: 0x04002EDD RID: 11997
		public static bool steamOverlayActive = false;

		// Token: 0x04002EDE RID: 11998
		private static bool lastOverlayState = false;

		// Token: 0x04002EDF RID: 11999
		private static bool arc_initialised = false;

		// Token: 0x04002EE0 RID: 12000
		private static Form arc_form = null;

		// Token: 0x04002EE1 RID: 12001
		private static bool last_arc_overlay_open = false;

		// Token: 0x04002EE2 RID: 12002
		private static bool arc_delayedNextState = false;

		// Token: 0x04002EE3 RID: 12003
		public static int arc_delayedManualOpening = -1;

		// Token: 0x0200029D RID: 669
		public struct TimerCaps
		{
			// Token: 0x04002EE4 RID: 12004
			public uint periodMin;

			// Token: 0x04002EE5 RID: 12005
			public uint periodMax;
		}
	}
}
