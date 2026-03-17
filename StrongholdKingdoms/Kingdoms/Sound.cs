using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x02000490 RID: 1168
	public class Sound
	{
		// Token: 0x17000234 RID: 564
		// (get) Token: 0x06002A62 RID: 10850 RVA: 0x0001F281 File Offset: 0x0001D481
		public static bool SFXActive
		{
			get
			{
				if (GameEngine.Instance.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_CASTLE && GameEngine.Instance.GameDisplayModeSubMode == GameEngine.GameDisplaySubModes.SUBMODE_BATTLE)
				{
					return Sound.BattleSFXActive;
				}
				return Sound.sfxActive;
			}
		}

		// Token: 0x17000235 RID: 565
		// (get) Token: 0x06002A63 RID: 10851 RVA: 0x0001F2A8 File Offset: 0x0001D4A8
		public static bool EnvironmentActive
		{
			get
			{
				return Sound.envActive;
			}
		}

		// Token: 0x06002A64 RID: 10852 RVA: 0x0001F2AF File Offset: 0x0001D4AF
		public static void setMusicState(bool active)
		{
			if (active == Sound.musicActive)
			{
				return;
			}
			Sound.musicActive = active;
			if (!active)
			{
				Sound.stopMusic();
				return;
			}
			if (GameEngine.Instance.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_CASTLE && GameEngine.Instance.GameDisplayModeSubMode == GameEngine.GameDisplaySubModes.SUBMODE_BATTLE)
			{
				Sound.playBattleMusic();
				return;
			}
			Sound.playMusic();
		}

		// Token: 0x06002A65 RID: 10853 RVA: 0x0001F2EE File Offset: 0x0001D4EE
		public static void setSFXState(bool active)
		{
			if (active != Sound.sfxActive)
			{
				Sound.sfxActive = active;
				if (!active)
				{
					Sound.stopVillageEnvironmentalSFXOnly();
				}
			}
		}

		// Token: 0x06002A66 RID: 10854 RVA: 0x0001F306 File Offset: 0x0001D506
		public static void setBattleSFXState(bool active)
		{
			if (active != Sound.BattleSFXActive)
			{
				Sound.BattleSFXActive = active;
				if (!active)
				{
					Sound.stopVillageEnvironmentalSFXOnly();
				}
			}
		}

		// Token: 0x06002A67 RID: 10855 RVA: 0x0001F31E File Offset: 0x0001D51E
		public static void setEnvironmentalState(bool active)
		{
			if (active != Sound.envActive)
			{
				Sound.envActive = active;
				if (!active)
				{
					Sound.stopVillageEnvironmentalOnly();
				}
			}
		}

		// Token: 0x06002A68 RID: 10856 RVA: 0x0020F914 File Offset: 0x0020DB14
		public static void createPlayLists()
		{
			Sound.defaultMusicPlayList.addEntry(new Sound.PlayListEntry(Application.StartupPath + "\\assets\\music\\monks1.mp3", 0.5f, 30, 4));
			Sound.defaultMusicPlayList.addEntry(new Sound.PlayListEntry(Application.StartupPath + "\\assets\\music\\mandloop1.mp3", 0.5f, 30));
			Sound.defaultMusicPlayList.addEntry(new Sound.PlayListEntry(Application.StartupPath + "\\assets\\music\\sadtimesb.mp3", 0.5f, 30));
			Sound.defaultMusicPlayList.addEntry(new Sound.PlayListEntry(Application.StartupPath + "\\assets\\music\\stainedglass-All.mp3", 0.5f, 30));
			Sound.defaultMusicPlayList.addEntry(new Sound.PlayListEntry(Application.StartupPath + "\\assets\\music\\the maidenA.mp3", 0.5f, 30));
			Sound.defaultMusicPlayList.addEntry(new Sound.PlayListEntry(Application.StartupPath + "\\assets\\music\\underanoldtree.mp3", 0.5f, 30));
			Sound.defaultMusicPlayList.addEntry(new Sound.PlayListEntry(Application.StartupPath + "\\assets\\music\\journeys.mp3", 0.5f, 30));
			Sound.defaultMusicPlayList.random = true;
			Sound.battleMusicPlayList.addEntry(new Sound.PlayListEntry(Application.StartupPath + "\\assets\\music\\Battle.mp3", 0.5f, 15));
			Sound.battleMusicPlayList.addEntry(new Sound.PlayListEntry(Application.StartupPath + "\\assets\\music\\glory_03.mp3", 0.5f, 15));
			Sound.battleMusicPlayList.addEntry(new Sound.PlayListEntry(Application.StartupPath + "\\assets\\music\\honor_04.mp3", 0.5f, 15));
			Sound.battleMusicPlayList.random = true;
			Sound.battleEndDefeatMusicPlayList.addEntry(new Sound.PlayListEntry(Application.StartupPath + "\\assets\\music\\battle end defeat.mp3", 0.5f, 86400));
			Sound.battleEndVictoryMusicPlayList.addEntry(new Sound.PlayListEntry(Application.StartupPath + "\\assets\\music\\battle end.mp3", 0.5f, 86400));
			Sound.loadInterfaceSounds();
		}

		// Token: 0x06002A69 RID: 10857 RVA: 0x0001F336 File Offset: 0x0001D536
		public static void playMusic()
		{
			Sound.playPlayList(Sound.defaultMusicPlayList);
			Sound.playingBattleMusic = false;
		}

		// Token: 0x06002A6A RID: 10858 RVA: 0x0001F348 File Offset: 0x0001D548
		public static void playBattleMusic()
		{
			Sound.playPlayList(Sound.battleMusicPlayList);
			Sound.playingBattleMusic = true;
		}

		// Token: 0x06002A6B RID: 10859 RVA: 0x0001F35A File Offset: 0x0001D55A
		public static void playBattleEndVictoryMusic()
		{
			Sound.playPlayList(Sound.battleEndVictoryMusicPlayList);
			Sound.playingBattleMusic = true;
		}

		// Token: 0x06002A6C RID: 10860 RVA: 0x0001F36C File Offset: 0x0001D56C
		public static void playBattleEndDefeatMusic()
		{
			Sound.playPlayList(Sound.battleEndDefeatMusicPlayList);
			Sound.playingBattleMusic = true;
		}

		// Token: 0x06002A6D RID: 10861 RVA: 0x0001F37E File Offset: 0x0001D57E
		private static void playPlayList(Sound.PlayList pl)
		{
			Sound.stopMusic();
			if (Sound.musicActive)
			{
				Sound.currentPlayingPlayList = pl;
				Sound.currentPlayingPlayList.play();
				Sound.musicPaused = false;
			}
		}

		// Token: 0x06002A6E RID: 10862 RVA: 0x0001F3A2 File Offset: 0x0001D5A2
		public static void stopMusic()
		{
			Sound.playingBattleMusic = false;
			if (Sound.currentPlayingPlayList != null)
			{
				Sound.currentPlayingPlayList.stop();
				Sound.currentPlayingPlayList = null;
			}
		}

		// Token: 0x06002A6F RID: 10863 RVA: 0x0001F3C1 File Offset: 0x0001D5C1
		public static void pauseMusic()
		{
			if (Sound.musicActive && !Sound.musicPaused)
			{
				Sound.musicPaused = true;
				GameEngine.Instance.AudioEngine.pauseMp3(0);
			}
		}

		// Token: 0x06002A70 RID: 10864 RVA: 0x0001F3E7 File Offset: 0x0001D5E7
		public static void resumeMusic()
		{
			if (Sound.musicActive && Sound.musicPaused)
			{
				Sound.musicPaused = false;
				GameEngine.Instance.AudioEngine.resumeMp3(0);
			}
		}

		// Token: 0x06002A71 RID: 10865 RVA: 0x0020FB00 File Offset: 0x0020DD00
		public static void monitorMusic()
		{
			if (Sound.musicActive)
			{
				if (Sound.currentPlayingPlayList != null)
				{
					Sound.currentPlayingPlayList.update();
				}
				if (InterfaceMgr.Instance.ParentForm != null)
				{
					if (!InterfaceMgr.Instance.ParentForm.Visible || InterfaceMgr.Instance.ParentForm.WindowState == FormWindowState.Minimized)
					{
						Sound.pauseMusic();
					}
					else
					{
						Sound.resumeMusic();
					}
				}
				if (Sound.playingBattleMusic && (GameEngine.Instance.GameDisplayMode != GameEngine.GameDisplays.DISPLAY_CASTLE || GameEngine.Instance.GameDisplayModeSubMode != GameEngine.GameDisplaySubModes.SUBMODE_BATTLE))
				{
					Sound.playMusic();
				}
			}
			if (Sound.EnvironmentActive && InterfaceMgr.Instance.ParentForm != null)
			{
				if (!InterfaceMgr.Instance.ParentForm.Visible || InterfaceMgr.Instance.ParentForm.WindowState == FormWindowState.Minimized)
				{
					Sound.pauseEnv();
				}
				else
				{
					Sound.resumeEnv();
				}
			}
			Sound.monitorEnvironmentals();
			Sound.processDelayedSounds();
		}

		// Token: 0x06002A72 RID: 10866 RVA: 0x0001F40D File Offset: 0x0001D60D
		public static void pauseEnv()
		{
			if (Sound.EnvironmentActive && !Sound.envPaused)
			{
				Sound.envPaused = true;
				GameEngine.Instance.AudioEngine.pauseMp3(2);
				GameEngine.Instance.AudioEngine.pauseMp3(1);
			}
		}

		// Token: 0x06002A73 RID: 10867 RVA: 0x0001F443 File Offset: 0x0001D643
		public static void resumeEnv()
		{
			if (Sound.EnvironmentActive && Sound.envPaused)
			{
				Sound.envPaused = false;
				GameEngine.Instance.AudioEngine.resumeMp3(2);
				GameEngine.Instance.AudioEngine.resumeMp3(1);
			}
		}

		// Token: 0x06002A74 RID: 10868 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public static void loadInterfaceSounds()
		{
		}

		// Token: 0x06002A75 RID: 10869 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public static void playInterfaceSound(int sfx)
		{
		}

		// Token: 0x06002A76 RID: 10870 RVA: 0x0020FBD4 File Offset: 0x0020DDD4
		public static void playDelayedInterfaceSound(string tag, int delayMS)
		{
			Sound.DelayedSound delayedSound = new Sound.DelayedSound();
			delayedSound.tag = tag;
			delayedSound.playTime = DateTime.Now.AddMilliseconds((double)delayMS);
			Sound.delayedSounds.Add(delayedSound);
		}

		// Token: 0x06002A77 RID: 10871 RVA: 0x0020FC10 File Offset: 0x0020DE10
		public static void processDelayedSounds()
		{
			if (Sound.delayedSounds.Count > 0)
			{
				List<Sound.DelayedSound> list = new List<Sound.DelayedSound>();
				foreach (Sound.DelayedSound delayedSound in Sound.delayedSounds)
				{
					if (delayedSound.playTime < DateTime.Now)
					{
						GameEngine.Instance.playInterfaceSound(delayedSound.tag);
						list.Add(delayedSound);
					}
				}
				if (list.Count > 0)
				{
					foreach (Sound.DelayedSound item in list)
					{
						Sound.delayedSounds.Remove(item);
					}
				}
			}
		}

		// Token: 0x06002A78 RID: 10872 RVA: 0x0001F479 File Offset: 0x0001D679
		public static void forceFullPlayOfNextEnvironmental()
		{
			Sound.s_blockEnvWhilePlaying = true;
		}

		// Token: 0x06002A79 RID: 10873 RVA: 0x0001F481 File Offset: 0x0001D681
		public static void playVillageEnvironmental(int villageType)
		{
			Sound.playVillageEnvironmental(villageType, true, false, false);
		}

		// Token: 0x06002A7A RID: 10874 RVA: 0x0001F48C File Offset: 0x0001D68C
		public static void fadeInVillageEnvironmental(int villageType)
		{
			Sound.playVillageEnvironmental(villageType, true, false, true);
		}

		// Token: 0x06002A7B RID: 10875 RVA: 0x0001F497 File Offset: 0x0001D697
		public static void playVillageEnvironmental(int villageType, bool loop, bool silenceMusic)
		{
			Sound.playVillageEnvironmental(villageType, loop, silenceMusic, false);
		}

		// Token: 0x06002A7C RID: 10876 RVA: 0x0020FCE8 File Offset: 0x0020DEE8
		public static void playVillageEnvironmental(int villageType, bool loop, bool silenceMusic, bool fadeIn)
		{
			if (villageType == Sound.s_currentVillageEnvironmental)
			{
				return;
			}
			if (Sound.s_blockEnvWhilePlaying)
			{
				int channel = 1;
				if (Sound.isEnvAnSFX(Sound.s_currentVillageEnvironmental))
				{
					channel = 2;
				}
				if (GameEngine.Instance.AudioEngine.isMP3Playing(channel))
				{
					return;
				}
				Sound.s_blockEnvWhilePlaying = false;
			}
			Sound.stopVillageEnvironmental();
			if (Sound.isEnvAnSFX(villageType) || (villageType >= 42 && villageType <= 45))
			{
				if (!Sound.SFXActive)
				{
					return;
				}
			}
			else if (!Sound.envActive)
			{
				return;
			}
			Sound.s_currentVillageEnvironmental = villageType;
			Sound.s_loop = loop;
			Sound.s_silencedMusic = silenceMusic;
			if (silenceMusic)
			{
				Sound.s_storedMusicVolume = GameEngine.Instance.AudioEngine.getMP3Volume(0);
				GameEngine.Instance.AudioEngine.setMP3MasterVolume(0.001f, 0);
			}
			string str = Application.StartupPath + "\\assets\\SFX\\";
			if (fadeIn)
			{
				Sound.s_fading = true;
				Sound.s_startFadeDT = DateTime.Now;
				Sound.s_currentFadeVolume = (Sound.s_startFadeVolume = 0f);
				Sound.FADE_DURATION = GameEngine.Instance.AudioEngine.getVolumeFromTag("BattleFadeLength") * 100f;
			}
			float num;
			if (Sound.isEnvAnSFX(Sound.s_currentVillageEnvironmental))
			{
				num = GameEngine.Instance.AudioEngine.getVolumeFromTag("VolumeOnly_rank");
				if (fadeIn)
				{
					Sound.s_targetFadeVolume = num * GameEngine.Instance.AudioEngine.getMP3Volume(2);
					num = 0f;
				}
				GameEngine.Instance.AudioEngine.playMp3(str + Sound.environmentalSounds[Sound.s_currentVillageEnvironmental], num, 2);
				return;
			}
			if (Sound.s_currentVillageEnvironmental >= 42 && Sound.s_currentVillageEnvironmental <= 45)
			{
				num = GameEngine.Instance.AudioEngine.getVolumeFromTag("VolumeOnly_battle");
				if (fadeIn)
				{
					Sound.s_targetFadeVolume = num * GameEngine.Instance.AudioEngine.getMP3Volume(2);
					num = 0f;
				}
				GameEngine.Instance.AudioEngine.playMp3(str + Sound.environmentalSounds[Sound.s_currentVillageEnvironmental], num, 2);
				return;
			}
			num = GameEngine.Instance.AudioEngine.getVolumeFromTag("VolumeOnly_environment");
			if (fadeIn)
			{
				Sound.s_targetFadeVolume = num * GameEngine.Instance.AudioEngine.getMP3Volume(1);
				num = 0f;
			}
			GameEngine.Instance.AudioEngine.playMp3(str + Sound.environmentalSounds[Sound.s_currentVillageEnvironmental], num, 1);
		}

		// Token: 0x06002A7D RID: 10877 RVA: 0x0020FF14 File Offset: 0x0020E114
		public static void stopVillageEnvironmental()
		{
			if (Sound.s_currentVillageEnvironmental >= 0)
			{
				Sound.s_blockEnvWhilePlaying = false;
				Sound.s_currentVillageEnvironmental = -1;
				Sound.s_fading = false;
				Sound.restoreSilencedMusic();
				GameEngine.Instance.AudioEngine.stopMp3(1);
				GameEngine.Instance.AudioEngine.stopMp3(2);
			}
		}

		// Token: 0x06002A7E RID: 10878 RVA: 0x0001F4A2 File Offset: 0x0001D6A2
		public static void stopVillageEnvironmentalOnly()
		{
			if (Sound.s_currentVillageEnvironmental >= 0)
			{
				Sound.s_blockEnvWhilePlaying = false;
				Sound.s_currentVillageEnvironmental = -1;
				Sound.s_fading = false;
				Sound.restoreSilencedMusic();
				GameEngine.Instance.AudioEngine.stopMp3(1);
			}
		}

		// Token: 0x06002A7F RID: 10879 RVA: 0x0001F4D3 File Offset: 0x0001D6D3
		public static void stopVillageEnvironmentalSFXOnly()
		{
			if (Sound.s_currentVillageEnvironmental >= 0)
			{
				Sound.s_blockEnvWhilePlaying = false;
				Sound.s_currentVillageEnvironmental = -1;
				Sound.s_fading = false;
				Sound.restoreSilencedMusic();
				GameEngine.Instance.AudioEngine.stopMp3(2);
			}
		}

		// Token: 0x06002A80 RID: 10880 RVA: 0x0020FF60 File Offset: 0x0020E160
		public static void stopVillageEnvironmentalExceptWorld()
		{
			if (Sound.s_currentVillageEnvironmental >= 0 && Sound.s_currentVillageEnvironmental != 19)
			{
				Sound.s_blockEnvWhilePlaying = false;
				Sound.s_currentVillageEnvironmental = -1;
				Sound.s_fading = false;
				Sound.restoreSilencedMusic();
				GameEngine.Instance.AudioEngine.stopMp3(1);
				GameEngine.Instance.AudioEngine.stopMp3(2);
			}
		}

		// Token: 0x06002A81 RID: 10881 RVA: 0x0001F504 File Offset: 0x0001D704
		public static void restoreSilencedMusic()
		{
			if (Sound.s_silencedMusic)
			{
				Sound.s_silencedMusic = false;
				GameEngine.Instance.AudioEngine.setMP3MasterVolume(Sound.s_storedMusicVolume, 0);
			}
		}

		// Token: 0x06002A82 RID: 10882 RVA: 0x0001F528 File Offset: 0x0001D728
		public static bool isEnvAnSFX(int env)
		{
			return (env >= 20 && env <= 41) || env == 46;
		}

		// Token: 0x06002A83 RID: 10883 RVA: 0x0001F53C File Offset: 0x0001D73C
		public static bool isPlayingEnvironmental(int soundID)
		{
			return soundID == Sound.s_currentVillageEnvironmental;
		}

		// Token: 0x06002A84 RID: 10884 RVA: 0x0020FFB8 File Offset: 0x0020E1B8
		public static void monitorEnvironmentals()
		{
			if (Sound.s_currentVillageEnvironmental < 0)
			{
				return;
			}
			int channel = 1;
			if (Sound.isEnvAnSFX(Sound.s_currentVillageEnvironmental))
			{
				channel = 2;
			}
			if (Sound.s_currentVillageEnvironmental >= 42 && Sound.s_currentVillageEnvironmental <= 45)
			{
				channel = 2;
				if (GameEngine.Instance.GameDisplayMode != GameEngine.GameDisplays.DISPLAY_CASTLE || GameEngine.Instance.GameDisplayModeSubMode != GameEngine.GameDisplaySubModes.SUBMODE_BATTLE)
				{
					Sound.stopVillageEnvironmental();
					return;
				}
			}
			if (!GameEngine.Instance.AudioEngine.isMP3Playing(channel) && !GameEngine.Instance.AudioEngine.isMP3Paused(channel))
			{
				if (Sound.s_loop)
				{
					string str = Application.StartupPath + "\\assets\\SFX\\";
					if (Sound.isEnvAnSFX(Sound.s_currentVillageEnvironmental))
					{
						float volumeFromTag = GameEngine.Instance.AudioEngine.getVolumeFromTag("VolumeOnly_rank");
						GameEngine.Instance.AudioEngine.playMp3(str + Sound.environmentalSounds[Sound.s_currentVillageEnvironmental], volumeFromTag, 2);
					}
					else if (Sound.s_currentVillageEnvironmental >= 42 && Sound.s_currentVillageEnvironmental <= 45)
					{
						float volumeFromTag = GameEngine.Instance.AudioEngine.getVolumeFromTag("VolumeOnly_battle");
						GameEngine.Instance.AudioEngine.playMp3(str + Sound.environmentalSounds[Sound.s_currentVillageEnvironmental], volumeFromTag, 2);
					}
					else
					{
						float volumeFromTag = GameEngine.Instance.AudioEngine.getVolumeFromTag("VolumeOnly_environment");
						GameEngine.Instance.AudioEngine.playMp3(str + Sound.environmentalSounds[Sound.s_currentVillageEnvironmental], volumeFromTag, 1);
					}
				}
				else
				{
					Sound.stopVillageEnvironmental();
					Sound.s_fading = false;
					Sound.restoreSilencedMusic();
				}
			}
			if (!Sound.s_fading)
			{
				return;
			}
			TimeSpan timeSpan = DateTime.Now - Sound.s_startFadeDT;
			if (timeSpan.TotalSeconds > (double)Sound.FADE_DURATION)
			{
				if (Sound.s_targetFadeVolume == 0f)
				{
					Sound.stopVillageEnvironmental();
					return;
				}
				Sound.s_fading = false;
				Sound.s_currentFadeVolume = Sound.s_targetFadeVolume;
				if (Sound.isEnvAnSFX(Sound.s_currentVillageEnvironmental) || (Sound.s_currentVillageEnvironmental >= 42 && Sound.s_currentVillageEnvironmental <= 45))
				{
					GameEngine.Instance.AudioEngine.setCurrentMP3Volume(Sound.s_currentFadeVolume, 2);
					return;
				}
				GameEngine.Instance.AudioEngine.setCurrentMP3Volume(Sound.s_currentFadeVolume, 1);
				return;
			}
			else
			{
				float num = (float)timeSpan.TotalSeconds / Sound.FADE_DURATION;
				Sound.s_currentFadeVolume = (Sound.s_targetFadeVolume - Sound.s_startFadeVolume) * num + Sound.s_startFadeVolume;
				if (Sound.isEnvAnSFX(Sound.s_currentVillageEnvironmental) || (Sound.s_currentVillageEnvironmental >= 42 && Sound.s_currentVillageEnvironmental <= 45))
				{
					GameEngine.Instance.AudioEngine.setCurrentMP3Volume(Sound.s_currentFadeVolume, 2);
					return;
				}
				GameEngine.Instance.AudioEngine.setCurrentMP3Volume(Sound.s_currentFadeVolume, 1);
				return;
			}
		}

		// Token: 0x06002A85 RID: 10885 RVA: 0x00210240 File Offset: 0x0020E440
		public static void pauseEnvironmental(bool pause)
		{
			if (Sound.s_currentVillageEnvironmental < 0)
			{
				return;
			}
			if (Sound.isEnvAnSFX(Sound.s_currentVillageEnvironmental) || (Sound.s_currentVillageEnvironmental >= 42 && Sound.s_currentVillageEnvironmental <= 45))
			{
				if (pause)
				{
					GameEngine.Instance.AudioEngine.pauseMp3(2);
					return;
				}
				GameEngine.Instance.AudioEngine.resumeMp3(2);
				return;
			}
			else
			{
				if (pause)
				{
					GameEngine.Instance.AudioEngine.pauseMp3(1);
					return;
				}
				GameEngine.Instance.AudioEngine.resumeMp3(1);
				return;
			}
		}

		// Token: 0x06002A86 RID: 10886 RVA: 0x0001F549 File Offset: 0x0001D749
		public static int getCurrentEnvironmental()
		{
			return Sound.s_currentVillageEnvironmental;
		}

		// Token: 0x06002A87 RID: 10887 RVA: 0x0001F550 File Offset: 0x0001D750
		public static bool isFading()
		{
			return Sound.s_fading;
		}

		// Token: 0x06002A88 RID: 10888 RVA: 0x002102C0 File Offset: 0x0020E4C0
		public static void fadeOutCurrentPlaying()
		{
			if (!Sound.s_fading)
			{
				Sound.s_fading = true;
				Sound.s_targetFadeVolume = 0f;
				Sound.s_startFadeDT = DateTime.Now;
				Sound.FADE_DURATION = GameEngine.Instance.AudioEngine.getVolumeFromTag("BattleFadeLength") * 100f;
				if (Sound.isEnvAnSFX(Sound.s_currentVillageEnvironmental) || (Sound.s_currentVillageEnvironmental >= 42 && Sound.s_currentVillageEnvironmental <= 45))
				{
					Sound.s_currentFadeVolume = (Sound.s_startFadeVolume = GameEngine.Instance.AudioEngine.getCurrentMP3Volume(2));
					return;
				}
				Sound.s_currentFadeVolume = (Sound.s_startFadeVolume = GameEngine.Instance.AudioEngine.getCurrentMP3Volume(1));
			}
		}

		// Token: 0x0400342D RID: 13357
		public const int SFX_PLACE_BUILDING = 10001;

		// Token: 0x0400342E RID: 13358
		public const int WORLD_AREA_TYPE_LOWLAND = 0;

		// Token: 0x0400342F RID: 13359
		public const int WORLD_AREA_TYPE_UPLAND = 1;

		// Token: 0x04003430 RID: 13360
		public const int WORLD_AREA_TYPE_RIVER1 = 2;

		// Token: 0x04003431 RID: 13361
		public const int WORLD_AREA_TYPE_RIVER2 = 3;

		// Token: 0x04003432 RID: 13362
		public const int WORLD_AREA_TYPE_MOUNTAIN_PEAK = 4;

		// Token: 0x04003433 RID: 13363
		public const int WORLD_AREA_TYPE_SALTFLAT = 5;

		// Token: 0x04003434 RID: 13364
		public const int WORLD_AREA_TYPE_MARSH = 6;

		// Token: 0x04003435 RID: 13365
		public const int WORLD_AREA_TYPE_PLAINS = 7;

		// Token: 0x04003436 RID: 13366
		public const int WORLD_AREA_TYPE_VALLEYSIDE = 8;

		// Token: 0x04003437 RID: 13367
		public const int WORLD_AREA_TYPE_FOREST = 9;

		// Token: 0x04003438 RID: 13368
		public const int WORLD_AREA_TYPE_PARISH_CAPITAL = 10;

		// Token: 0x04003439 RID: 13369
		public const int WORLD_AREA_TYPE_COUNTY_CAPITAL = 11;

		// Token: 0x0400343A RID: 13370
		public const int WORLD_AREA_TYPE_PROVINCE_CAPITAL = 12;

		// Token: 0x0400343B RID: 13371
		public const int WORLD_AREA_TYPE_COUNTRY_CAPITAL = 13;

		// Token: 0x0400343C RID: 13372
		public const int WORLD_AREA_TYPE_CAPITAL_QUIET = 14;

		// Token: 0x0400343D RID: 13373
		public const int WORLD_AREA_TYPE_CAPITAL_NORMAL = 15;

		// Token: 0x0400343E RID: 13374
		public const int WORLD_AREA_TYPE_CAPITAL_BUSY = 16;

		// Token: 0x0400343F RID: 13375
		public const int WORLD_AREA_TYPE_CASTLE = 17;

		// Token: 0x04003440 RID: 13376
		public const int WORLD_AREA_TYPE_CASTLE_CONSTRUCTION = 18;

		// Token: 0x04003441 RID: 13377
		public const int WORLD_AREA_TYPE_WORLD = 19;

		// Token: 0x04003442 RID: 13378
		public const int RANK_SOUND_2 = 20;

		// Token: 0x04003443 RID: 13379
		public const int RANK_SOUND_3 = 21;

		// Token: 0x04003444 RID: 13380
		public const int RANK_SOUND_4 = 22;

		// Token: 0x04003445 RID: 13381
		public const int RANK_SOUND_5 = 23;

		// Token: 0x04003446 RID: 13382
		public const int RANK_SOUND_6 = 24;

		// Token: 0x04003447 RID: 13383
		public const int RANK_SOUND_7 = 25;

		// Token: 0x04003448 RID: 13384
		public const int RANK_SOUND_8 = 26;

		// Token: 0x04003449 RID: 13385
		public const int RANK_SOUND_9 = 27;

		// Token: 0x0400344A RID: 13386
		public const int RANK_SOUND_10 = 28;

		// Token: 0x0400344B RID: 13387
		public const int RANK_SOUND_11 = 29;

		// Token: 0x0400344C RID: 13388
		public const int RANK_SOUND_12 = 30;

		// Token: 0x0400344D RID: 13389
		public const int RANK_SOUND_13 = 31;

		// Token: 0x0400344E RID: 13390
		public const int RANK_SOUND_14 = 32;

		// Token: 0x0400344F RID: 13391
		public const int RANK_SOUND_15 = 33;

		// Token: 0x04003450 RID: 13392
		public const int RANK_SOUND_16 = 34;

		// Token: 0x04003451 RID: 13393
		public const int RANK_SOUND_17 = 35;

		// Token: 0x04003452 RID: 13394
		public const int RANK_SOUND_18 = 36;

		// Token: 0x04003453 RID: 13395
		public const int RANK_SOUND_19 = 37;

		// Token: 0x04003454 RID: 13396
		public const int RANK_SOUND_20 = 38;

		// Token: 0x04003455 RID: 13397
		public const int RANK_SOUND_21 = 39;

		// Token: 0x04003456 RID: 13398
		public const int RANK_SOUND_22 = 40;

		// Token: 0x04003457 RID: 13399
		public const int RANK_SOUND_23 = 41;

		// Token: 0x04003458 RID: 13400
		public const int WORLD_AREA_TYPE_BATTLE_1 = 42;

		// Token: 0x04003459 RID: 13401
		public const int WORLD_AREA_TYPE_BATTLE_2 = 43;

		// Token: 0x0400345A RID: 13402
		public const int WORLD_AREA_TYPE_BATTLE_3 = 44;

		// Token: 0x0400345B RID: 13403
		public const int WORLD_AREA_TYPE_BATTLE_4 = 45;

		// Token: 0x0400345C RID: 13404
		public const int REWARD_JINGLE = 46;

		// Token: 0x0400345D RID: 13405
		private static bool musicActive = true;

		// Token: 0x0400345E RID: 13406
		private static bool sfxActive = true;

		// Token: 0x0400345F RID: 13407
		private static bool BattleSFXActive = true;

		// Token: 0x04003460 RID: 13408
		private static bool envActive = true;

		// Token: 0x04003461 RID: 13409
		private static Sound.PlayList defaultMusicPlayList = new Sound.PlayList();

		// Token: 0x04003462 RID: 13410
		private static Sound.PlayList battleMusicPlayList = new Sound.PlayList();

		// Token: 0x04003463 RID: 13411
		private static Sound.PlayList battleEndVictoryMusicPlayList = new Sound.PlayList();

		// Token: 0x04003464 RID: 13412
		private static Sound.PlayList battleEndDefeatMusicPlayList = new Sound.PlayList();

		// Token: 0x04003465 RID: 13413
		private static Sound.PlayList currentPlayingPlayList = null;

		// Token: 0x04003466 RID: 13414
		private static bool playingBattleMusic = false;

		// Token: 0x04003467 RID: 13415
		public static bool musicPaused = false;

		// Token: 0x04003468 RID: 13416
		public static bool envPaused = false;

		// Token: 0x04003469 RID: 13417
		private static List<Sound.DelayedSound> delayedSounds = new List<Sound.DelayedSound>();

		// Token: 0x0400346A RID: 13418
		private static string[] environmentalSounds = new string[]
		{
			"environment_lowland.mp3",
			"environment_highland.mp3",
			"environment_river1.mp3",
			"environment_river2.mp3",
			"environment_mountainpeak.mp3",
			"environment_saltflat.mp3",
			"environment_marsh.mp3",
			"environment_plains.mp3",
			"environment_valleyside.mp3",
			"environment_forest.mp3",
			"environment_parish.mp3",
			"environment_county.mp3",
			"environment_province.mp3",
			"environment_country.mp3",
			"environment_capital_quiet.mp3",
			"environment_capital_normal.mp3",
			"environment_capital_busy.mp3",
			"environment_castle.mp3",
			"environment_castle_construction.mp3",
			"environment_world.mp3",
			"environment_rank_2.mp3",
			"environment_rank_3.mp3",
			"environment_rank_4.mp3",
			"environment_rank_5.mp3",
			"environment_rank_6.mp3",
			"environment_rank_7.mp3",
			"environment_rank_8.mp3",
			"environment_rank_9.mp3",
			"environment_rank_10.mp3",
			"environment_rank_11.mp3",
			"environment_rank_12.mp3",
			"environment_rank_13.mp3",
			"environment_rank_14.mp3",
			"environment_rank_15.mp3",
			"environment_rank_16.mp3",
			"environment_rank_17.mp3",
			"environment_rank_18.mp3",
			"environment_rank_19.mp3",
			"environment_rank_20.mp3",
			"environment_rank_21.mp3",
			"environment_rank_22.mp3",
			"environment_rank_23.mp3",
			"environment_battle_1.mp3",
			"environment_battle_2.mp3",
			"environment_battle_3.mp3",
			"environment_battle_4.mp3",
			"environment_rank_18_short_4.mp3"
		};

		// Token: 0x0400346B RID: 13419
		private static int s_currentVillageEnvironmental = -1;

		// Token: 0x0400346C RID: 13420
		private static bool s_loop = true;

		// Token: 0x0400346D RID: 13421
		private static bool s_silencedMusic = true;

		// Token: 0x0400346E RID: 13422
		private static float s_storedMusicVolume = 1f;

		// Token: 0x0400346F RID: 13423
		private static bool s_blockEnvWhilePlaying = false;

		// Token: 0x04003470 RID: 13424
		private static bool s_fading = false;

		// Token: 0x04003471 RID: 13425
		private static float s_targetFadeVolume = 1f;

		// Token: 0x04003472 RID: 13426
		private static float s_currentFadeVolume = 1f;

		// Token: 0x04003473 RID: 13427
		private static float s_startFadeVolume = 1f;

		// Token: 0x04003474 RID: 13428
		private static DateTime s_startFadeDT = DateTime.MinValue;

		// Token: 0x04003475 RID: 13429
		private static float FADE_DURATION = 1f;

		// Token: 0x02000491 RID: 1169
		public class PlayListEntry
		{
			// Token: 0x06002A8B RID: 10891 RVA: 0x0001F557 File Offset: 0x0001D757
			public PlayListEntry(string fn, float v, int silence)
			{
				this.filename = fn;
				this.volume = v;
				this.trailingSilenceSeconds = silence;
				this.numLoops = 0;
			}

			// Token: 0x06002A8C RID: 10892 RVA: 0x0001F591 File Offset: 0x0001D791
			public PlayListEntry(string fn, float v, int silence, int loops)
			{
				this.filename = fn;
				this.volume = v;
				this.trailingSilenceSeconds = silence;
				this.numLoops = loops;
			}

			// Token: 0x04003476 RID: 13430
			public string filename = "";

			// Token: 0x04003477 RID: 13431
			public float volume = 1f;

			// Token: 0x04003478 RID: 13432
			public int trailingSilenceSeconds;

			// Token: 0x04003479 RID: 13433
			public int numLoops;
		}

		// Token: 0x02000492 RID: 1170
		public class PlayList
		{
			// Token: 0x06002A8D RID: 10893 RVA: 0x0001F5CC File Offset: 0x0001D7CC
			public void restart()
			{
				this.currentStep = -1;
				this.nextStep = 0;
				this.inSilence = false;
				this.silenceEnd = DateTime.MinValue;
				this.currentLoop = 0;
			}

			// Token: 0x06002A8E RID: 10894 RVA: 0x0001F5F5 File Offset: 0x0001D7F5
			public void play()
			{
				this.restart();
				this.advance();
			}

			// Token: 0x06002A8F RID: 10895 RVA: 0x0001F603 File Offset: 0x0001D803
			public void stop()
			{
				GameEngine.Instance.AudioEngine.stopMp3(0);
			}

			// Token: 0x06002A90 RID: 10896 RVA: 0x002105DC File Offset: 0x0020E7DC
			public void update()
			{
				if (this.inSilence)
				{
					if (DateTime.Now > this.silenceEnd && !Sound.musicPaused)
					{
						this.inSilence = false;
						this.advance();
						return;
					}
				}
				else
				{
					if (GameEngine.Instance.AudioEngine.isMP3Playing(0))
					{
						return;
					}
					if (this.entries[this.currentStep].numLoops <= this.currentLoop)
					{
						if (this.entries[this.currentStep].trailingSilenceSeconds > 0)
						{
							this.inSilence = true;
							this.silenceEnd = DateTime.Now.AddSeconds((double)this.entries[this.currentStep].trailingSilenceSeconds);
							return;
						}
						this.advance();
						return;
					}
					else
					{
						this.currentLoop++;
						GameEngine.Instance.AudioEngine.playMp3(this.entries[this.currentStep].filename, this.entries[this.currentStep].volume, 0);
					}
				}
			}

			// Token: 0x06002A91 RID: 10897 RVA: 0x002106EC File Offset: 0x0020E8EC
			public void advance()
			{
				if (!this.random)
				{
					GameEngine.Instance.AudioEngine.playMp3(this.entries[this.nextStep].filename, this.entries[this.nextStep].volume, 0);
					this.currentStep = this.nextStep;
					this.nextStep++;
					if (this.nextStep >= this.entries.Count)
					{
						this.nextStep = 0;
					}
				}
				else
				{
					this.nextStep = (this.currentStep = new Random().Next(this.entries.Count));
					GameEngine.Instance.AudioEngine.playMp3(this.entries[this.nextStep].filename, this.entries[this.nextStep].volume, 0);
				}
				this.currentLoop = 0;
			}

			// Token: 0x06002A92 RID: 10898 RVA: 0x0001F615 File Offset: 0x0001D815
			public void addEntry(Sound.PlayListEntry entry)
			{
				if (entry != null)
				{
					this.entries.Add(entry);
				}
			}

			// Token: 0x0400347A RID: 13434
			public bool playing;

			// Token: 0x0400347B RID: 13435
			public List<Sound.PlayListEntry> entries = new List<Sound.PlayListEntry>();

			// Token: 0x0400347C RID: 13436
			public int nextStep;

			// Token: 0x0400347D RID: 13437
			public int currentStep = -1;

			// Token: 0x0400347E RID: 13438
			public bool inSilence;

			// Token: 0x0400347F RID: 13439
			public DateTime silenceEnd = DateTime.MinValue;

			// Token: 0x04003480 RID: 13440
			public bool random;

			// Token: 0x04003481 RID: 13441
			public int currentLoop;
		}

		// Token: 0x02000493 RID: 1171
		private class DelayedSound
		{
			// Token: 0x04003482 RID: 13442
			public string tag;

			// Token: 0x04003483 RID: 13443
			public DateTime playTime = DateTime.MaxValue;
		}
	}
}
