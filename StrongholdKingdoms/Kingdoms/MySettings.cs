using System;
using System.IO;
using System.Xml.Serialization;
using DXGraphics;

namespace Kingdoms
{
	// Token: 0x0200024D RID: 589
	[Serializable]
	public class MySettings
	{
		// Token: 0x170001DD RID: 477
		// (get) Token: 0x06001A18 RID: 6680 RVA: 0x0001A2B0 File Offset: 0x000184B0
		// (set) Token: 0x06001A19 RID: 6681 RVA: 0x0001A2B8 File Offset: 0x000184B8
		public string LanguageIdent
		{
			get
			{
				return this.languageIdent;
			}
			set
			{
				this.languageIdent = value;
				BaseImage.currentLangSetting = this.languageIdent;
			}
		}

		// Token: 0x06001A1A RID: 6682 RVA: 0x0001A2CC File Offset: 0x000184CC
		public bool hasLoggedIn()
		{
			return this.HasLoggedIn || this.Username.Length > 0;
		}

		// Token: 0x06001A1B RID: 6683 RVA: 0x0019CB68 File Offset: 0x0019AD68
		public static MySettings load()
		{
			MySettings result;
			try
			{
				MySettings mySettings = null;
				string settingsPath = GameEngine.getSettingsPath(false);
				FileStream fileStream = null;
				BinaryReader binaryReader = null;
				try
				{
					fileStream = new FileStream(settingsPath + "\\config.dat", FileMode.Open, FileAccess.Read);
					binaryReader = new BinaryReader(fileStream);
					mySettings = new MySettings();
					mySettings.MusicVolume = 13;
					mySettings.SFXVolume = 100;
					mySettings.EnvironmentalVolume = 34;
					mySettings.Username = binaryReader.ReadString();
					mySettings.Password = binaryReader.ReadString();
					mySettings.ScreenWidth = binaryReader.ReadInt32();
					mySettings.ScreenHeight = binaryReader.ReadInt32();
					mySettings.LicenseViewed = binaryReader.ReadBoolean();
					mySettings.LicenseAlpha3Viewed = binaryReader.ReadBoolean();
					mySettings.CastleWalls = binaryReader.ReadBoolean();
					mySettings.NotifyChatUpdate = binaryReader.ReadBoolean();
					try
					{
						mySettings.ConfirmPlayCard = binaryReader.ReadBoolean();
						mySettings.SETTINGS_instantTooltips = binaryReader.ReadBoolean();
						mySettings.SETTINGS_staticMouseTime = binaryReader.ReadInt32();
						mySettings.SETTINGS_showTooltips = binaryReader.ReadBoolean();
						mySettings.LanguageIdent = binaryReader.ReadString();
						mySettings.OwnLanguageAvailableAndChecked = binaryReader.ReadBoolean();
						mySettings.BuyMultipleCardPacks = binaryReader.ReadBoolean();
						mySettings.OpenMultipleCardPacks = binaryReader.ReadBoolean();
						mySettings.Music = binaryReader.ReadBoolean();
						mySettings.MusicVolume = binaryReader.ReadInt32();
						mySettings.AAMode = binaryReader.ReadInt32();
						mySettings.LastWorldID = binaryReader.ReadInt32();
						mySettings.AutoLogin = binaryReader.ReadBoolean();
						mySettings.NumWorldsCount = binaryReader.ReadInt32();
						mySettings.NumWorldsLastChanged = new DateTime(binaryReader.ReadInt64());
						mySettings.HasLoggedIn = binaryReader.ReadBoolean();
						mySettings.fastCashIn = binaryReader.ReadBoolean();
						mySettings.SFX = binaryReader.ReadBoolean();
						mySettings.SFXVolume = binaryReader.ReadInt32();
						mySettings.Environmentals = binaryReader.ReadBoolean();
						mySettings.EnvironmentalVolume = binaryReader.ReadInt32();
						mySettings.Maximize = binaryReader.ReadBoolean();
						if (mySettings.MusicVolume < 0)
						{
							mySettings.MusicVolume = binaryReader.ReadInt32();
							mySettings.SFXVolume = binaryReader.ReadInt32();
							mySettings.EnvironmentalVolume = binaryReader.ReadInt32();
						}
						else
						{
							if (mySettings.MusicVolume > 13)
							{
								mySettings.MusicVolume = 13;
							}
							mySettings.SFXVolume = 100;
							mySettings.EnvironmentalVolume = 34;
						}
						mySettings.BattleSFX = binaryReader.ReadBoolean();
						mySettings.viewVillageIDs = binaryReader.ReadBoolean();
						mySettings.showGameFeaturesScreenIcon = binaryReader.ReadBoolean();
						mySettings.SeasonalSpecialFX = binaryReader.ReadBoolean();
						try
						{
							mySettings.InstalledLanguageIdent = binaryReader.ReadString();
						}
						catch (Exception)
						{
							mySettings.InstalledLanguageIdent = Program.installedLangCode;
						}
						try
						{
							mySettings.FlashingTaskbarAttack = binaryReader.ReadBoolean();
						}
						catch
						{
							mySettings.FlashingTaskbarAttack = true;
						}
						try
						{
							mySettings.ShowProductionInfo = binaryReader.ReadBoolean();
						}
						catch
						{
							mySettings.ShowProductionInfo = true;
						}
						try
						{
							mySettings.AdvancedTrading = binaryReader.ReadBoolean();
						}
						catch
						{
							mySettings.AdvancedTrading = false;
						}
						try
						{
							mySettings.AdvertShown = binaryReader.ReadBoolean();
						}
						catch
						{
							mySettings.AdvertShown = false;
						}
						try
						{
							mySettings.viewCapitalIDs = binaryReader.ReadBoolean();
						}
						catch
						{
							mySettings.viewCapitalIDs = false;
						}
						try
						{
							mySettings.AttackSetupsUpdated = binaryReader.ReadBoolean();
						}
						catch
						{
							mySettings.AttackSetupsUpdated = false;
						}
						try
						{
							mySettings.SeasonalWinterLandscape = binaryReader.ReadBoolean();
						}
						catch
						{
							mySettings.SeasonalWinterLandscape = true;
						}
						try
						{
							mySettings.UseMapTextBorders = binaryReader.ReadBoolean();
						}
						catch
						{
							mySettings.UseMapTextBorders = true;
						}
						try
						{
							mySettings.facebookaccesstoken = binaryReader.ReadString();
						}
						catch
						{
							mySettings.facebookaccesstoken = "";
						}
						try
						{
							mySettings.SendAnalytics = binaryReader.ReadBoolean();
						}
						catch
						{
							mySettings.SendAnalytics = true;
						}
						try
						{
							mySettings.SeenAnalyticsPrompt = binaryReader.ReadBoolean();
						}
						catch
						{
							mySettings.SeenAnalyticsPrompt = false;
						}
						try
						{
							mySettings.GuestID = binaryReader.ReadString();
						}
						catch
						{
							mySettings.GuestID = "";
						}
						try
						{
							mySettings.IsGuestAccount = binaryReader.ReadBoolean();
						}
						catch
						{
							mySettings.IsGuestAccount = false;
						}
						try
						{
							mySettings.NeverLoggedIn = binaryReader.ReadBoolean();
						}
						catch
						{
							mySettings.NeverLoggedIn = true;
						}
						try
						{
							mySettings.GuestUsername = binaryReader.ReadString();
						}
						catch
						{
							mySettings.GuestUsername = string.Empty;
						}
						try
						{
							mySettings.LastContestViewed = binaryReader.ReadInt32();
						}
						catch
						{
							mySettings.LastContestViewed = 0;
						}
						try
						{
							mySettings.advicePanelsViewed = binaryReader.ReadString();
							mySettings.adviceEnabled = binaryReader.ReadBoolean();
						}
						catch
						{
							mySettings.advicePanelsViewed = string.Empty;
							mySettings.adviceEnabled = true;
						}
					}
					catch (Exception)
					{
						mySettings.BattleSFX = mySettings.SFX;
					}
					binaryReader.Close();
					fileStream.Close();
					if ((mySettings.Username != null && mySettings.Username.Length > 0) || (mySettings.Password != null && mySettings.Password.Length > 0))
					{
						mySettings.NeverLoggedIn = false;
					}
					return mySettings;
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
				FileStream fileStream2 = null;
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(MySettings));
				try
				{
					fileStream2 = new FileStream(settingsPath + "\\settings.dat", FileMode.Open, FileAccess.Read);
					mySettings = (MySettings)xmlSerializer.Deserialize(fileStream2);
					fileStream2.Close();
					fileStream2 = null;
					result = mySettings;
				}
				catch (FileNotFoundException)
				{
					result = new MySettings();
				}
				catch (DirectoryNotFoundException)
				{
					result = new MySettings();
				}
				catch (Exception)
				{
					try
					{
						if (fileStream2 != null)
						{
							fileStream2.Close();
						}
					}
					catch (Exception)
					{
					}
					result = new MySettings();
				}
			}
			catch (Exception)
			{
				result = new MySettings();
			}
			return result;
		}

		// Token: 0x06001A1C RID: 6684 RVA: 0x0019D314 File Offset: 0x0019B514
		public static void Reset()
		{
			string settingsPath = GameEngine.getSettingsPath(true);
			try
			{
				string path = settingsPath + "\\config.dat";
				if (File.Exists(path))
				{
					File.Delete(path);
				}
			}
			catch (Exception ex)
			{
				UniversalDebugLog.Log("Exception when resetting " + ex.ToString());
			}
		}

		// Token: 0x06001A1D RID: 6685 RVA: 0x0019D374 File Offset: 0x0019B574
		public void Save()
		{
			string settingsPath = GameEngine.getSettingsPath(true);
			try
			{
				FileInfo fileInfo = new FileInfo(settingsPath + "\\config.dat");
				fileInfo.IsReadOnly = false;
			}
			catch (Exception)
			{
			}
			int value = -1;
			FileStream fileStream = null;
			BinaryWriter binaryWriter = null;
			try
			{
				fileStream = new FileStream(settingsPath + "\\config.dat", FileMode.Create);
				binaryWriter = new BinaryWriter(fileStream);
				binaryWriter.Write(this.Username);
				binaryWriter.Write(this.Password);
				binaryWriter.Write(this.ScreenWidth);
				binaryWriter.Write(this.ScreenHeight);
				binaryWriter.Write(this.LicenseViewed);
				binaryWriter.Write(this.LicenseAlpha3Viewed);
				binaryWriter.Write(this.CastleWalls);
				binaryWriter.Write(this.NotifyChatUpdate);
				binaryWriter.Write(this.ConfirmPlayCard);
				binaryWriter.Write(this.SETTINGS_instantTooltips);
				binaryWriter.Write(this.SETTINGS_staticMouseTime);
				binaryWriter.Write(this.SETTINGS_showTooltips);
				binaryWriter.Write(this.LanguageIdent);
				binaryWriter.Write(this.OwnLanguageAvailableAndChecked);
				binaryWriter.Write(this.BuyMultipleCardPacks);
				binaryWriter.Write(this.OpenMultipleCardPacks);
				binaryWriter.Write(this.Music);
				binaryWriter.Write(value);
				binaryWriter.Write(this.AAMode);
				binaryWriter.Write(this.LastWorldID);
				binaryWriter.Write(this.AutoLogin);
				binaryWriter.Write(this.NumWorldsCount);
				binaryWriter.Write(this.NumWorldsLastChanged.Ticks);
				binaryWriter.Write(this.HasLoggedIn);
				binaryWriter.Write(this.fastCashIn);
				binaryWriter.Write(this.SFX);
				binaryWriter.Write(value);
				binaryWriter.Write(this.Environmentals);
				binaryWriter.Write(value);
				binaryWriter.Write(this.Maximize);
				binaryWriter.Write(this.MusicVolume);
				binaryWriter.Write(this.SFXVolume);
				binaryWriter.Write(this.EnvironmentalVolume);
				binaryWriter.Write(this.BattleSFX);
				binaryWriter.Write(this.viewVillageIDs);
				binaryWriter.Write(this.showGameFeaturesScreenIcon);
				binaryWriter.Write(this.SeasonalSpecialFX);
				binaryWriter.Write(this.InstalledLanguageIdent);
				binaryWriter.Write(this.FlashingTaskbarAttack);
				binaryWriter.Write(this.ShowProductionInfo);
				binaryWriter.Write(this.AdvancedTrading);
				binaryWriter.Write(this.AdvertShown);
				binaryWriter.Write(this.viewCapitalIDs);
				binaryWriter.Write(this.AttackSetupsUpdated);
				binaryWriter.Write(this.SeasonalWinterLandscape);
				binaryWriter.Write(this.UseMapTextBorders);
				binaryWriter.Write(this.facebookaccesstoken);
				binaryWriter.Write(this.SendAnalytics);
				binaryWriter.Write(this.SeenAnalyticsPrompt);
				binaryWriter.Write(this.GuestID);
				binaryWriter.Write(this.IsGuestAccount);
				binaryWriter.Write(this.NeverLoggedIn);
				binaryWriter.Write(this.GuestUsername);
				binaryWriter.Write(this.LastContestViewed);
				binaryWriter.Write(this.advicePanelsViewed);
				binaryWriter.Write(this.adviceEnabled);
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

		// Token: 0x04002A8F RID: 10895
		public const int LOGINS_UNTILL_POPUP = 3;

		// Token: 0x04002A90 RID: 10896
		public bool usingPlayerPrefs;

		// Token: 0x04002A91 RID: 10897
		public bool NeverLoggedIn = true;

		// Token: 0x04002A92 RID: 10898
		public bool IsGuestAccount;

		// Token: 0x04002A93 RID: 10899
		public string GuestID = string.Empty;

		// Token: 0x04002A94 RID: 10900
		public string GuestUsername = string.Empty;

		// Token: 0x04002A95 RID: 10901
		public string Username = "";

		// Token: 0x04002A96 RID: 10902
		public string Password = "";

		// Token: 0x04002A97 RID: 10903
		public int ScreenWidth = -1;

		// Token: 0x04002A98 RID: 10904
		public int ScreenHeight = -1;

		// Token: 0x04002A99 RID: 10905
		public bool LicenseViewed;

		// Token: 0x04002A9A RID: 10906
		public bool LicenseAlpha3Viewed;

		// Token: 0x04002A9B RID: 10907
		public bool CastleWalls = true;

		// Token: 0x04002A9C RID: 10908
		public bool NotifyChatUpdate = true;

		// Token: 0x04002A9D RID: 10909
		public bool ConfirmPlayCard = true;

		// Token: 0x04002A9E RID: 10910
		public bool BuyMultipleCardPacks = true;

		// Token: 0x04002A9F RID: 10911
		public bool OpenMultipleCardPacks = true;

		// Token: 0x04002AA0 RID: 10912
		public bool SETTINGS_instantTooltips;

		// Token: 0x04002AA1 RID: 10913
		public int SETTINGS_staticMouseTime = 400;

		// Token: 0x04002AA2 RID: 10914
		public bool SETTINGS_showTooltips = true;

		// Token: 0x04002AA3 RID: 10915
		public string languageIdent = "";

		// Token: 0x04002AA4 RID: 10916
		public string InstalledLanguageIdent = "";

		// Token: 0x04002AA5 RID: 10917
		public bool OwnLanguageAvailableAndChecked;

		// Token: 0x04002AA6 RID: 10918
		public bool Music = true;

		// Token: 0x04002AA7 RID: 10919
		public int MusicVolume = 13;

		// Token: 0x04002AA8 RID: 10920
		public int AAMode;

		// Token: 0x04002AA9 RID: 10921
		public int LastWorldID = -1;

		// Token: 0x04002AAA RID: 10922
		public bool IsAutomatedBuild;

		// Token: 0x04002AAB RID: 10923
		public bool AutoLogin;

		// Token: 0x04002AAC RID: 10924
		public int NumWorldsCount = -1;

		// Token: 0x04002AAD RID: 10925
		public DateTime NumWorldsLastChanged = DateTime.MinValue;

		// Token: 0x04002AAE RID: 10926
		public bool HasLoggedIn;

		// Token: 0x04002AAF RID: 10927
		public bool fastCashIn;

		// Token: 0x04002AB0 RID: 10928
		public bool SFX = true;

		// Token: 0x04002AB1 RID: 10929
		public bool BattleSFX = true;

		// Token: 0x04002AB2 RID: 10930
		public int SFXVolume = 100;

		// Token: 0x04002AB3 RID: 10931
		public bool Environmentals = true;

		// Token: 0x04002AB4 RID: 10932
		public int EnvironmentalVolume = 34;

		// Token: 0x04002AB5 RID: 10933
		public bool Maximize;

		// Token: 0x04002AB6 RID: 10934
		public bool viewVillageIDs;

		// Token: 0x04002AB7 RID: 10935
		public bool viewCapitalIDs;

		// Token: 0x04002AB8 RID: 10936
		public bool showGameFeaturesScreenIcon = true;

		// Token: 0x04002AB9 RID: 10937
		public bool SeasonalSpecialFX = true;

		// Token: 0x04002ABA RID: 10938
		public bool SeasonalWinterLandscape = true;

		// Token: 0x04002ABB RID: 10939
		public bool FlashingTaskbarAttack = true;

		// Token: 0x04002ABC RID: 10940
		public bool ShowProductionInfo = true;

		// Token: 0x04002ABD RID: 10941
		public bool AdvancedTrading;

		// Token: 0x04002ABE RID: 10942
		public bool AdvertShown;

		// Token: 0x04002ABF RID: 10943
		public bool AttackSetupsUpdated;

		// Token: 0x04002AC0 RID: 10944
		public bool UseMapTextBorders = true;

		// Token: 0x04002AC1 RID: 10945
		public bool SendAnalytics = true;

		// Token: 0x04002AC2 RID: 10946
		public bool SeenAnalyticsPrompt;

		// Token: 0x04002AC3 RID: 10947
		public bool DirectMapRendering;

		// Token: 0x04002AC4 RID: 10948
		public bool MapScreenNoUpdate;

		// Token: 0x04002AC5 RID: 10949
		public bool MapScreenNoArmyDraw;

		// Token: 0x04002AC6 RID: 10950
		public bool MapScreenNoArmyUpdate;

		// Token: 0x04002AC7 RID: 10951
		public bool MapScreenNoVillageDraw;

		// Token: 0x04002AC8 RID: 10952
		public bool MapScreenNoVillageUpdate;

		// Token: 0x04002AC9 RID: 10953
		public bool MapScreenNoTiles;

		// Token: 0x04002ACA RID: 10954
		public bool MapScreenNoText = true;

		// Token: 0x04002ACB RID: 10955
		public bool OldSprites;

		// Token: 0x04002ACC RID: 10956
		public bool NoSprites;

		// Token: 0x04002ACD RID: 10957
		public int LoginCount;

		// Token: 0x04002ACE RID: 10958
		public bool HasShownFreshSignupInvitation;

		// Token: 0x04002ACF RID: 10959
		public bool FTUECompleted;

		// Token: 0x04002AD0 RID: 10960
		public bool AdvisorsCompleted;

		// Token: 0x04002AD1 RID: 10961
		public bool DisableParishFTUE;

		// Token: 0x04002AD2 RID: 10962
		public bool DisableAge4Warning;

		// Token: 0x04002AD3 RID: 10963
		public bool DisableAge5Warning;

		// Token: 0x04002AD4 RID: 10964
		public bool DisableAge6Warning;

		// Token: 0x04002AD5 RID: 10965
		public bool DisableAge7Warning;

		// Token: 0x04002AD6 RID: 10966
		public int palette;

		// Token: 0x04002AD7 RID: 10967
		public string facebookaccesstoken = "";

		// Token: 0x04002AD8 RID: 10968
		public int LastContestViewed;

		// Token: 0x04002AD9 RID: 10969
		public string advicePanelsViewed = "";

		// Token: 0x04002ADA RID: 10970
		public bool adviceEnabled = true;
	}
}
