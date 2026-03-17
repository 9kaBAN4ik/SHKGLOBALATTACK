using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Kingdoms;
using Properties;
using Upgrade.Services;

namespace Upgrade
{
	// Token: 0x02000025 RID: 37
	internal class LNG
	{
		// Token: 0x0600017E RID: 382 RVA: 0x0003FEEC File Offset: 0x0003E0EC
		static LNG()
		{
			LNG.LogPhrases = new Dictionary<string, string>();
			LNG.DiscludeControls = new string[]
			{
				"button7",
				"Village",
				"CastleVillageName",
				"CastleRestoreCastle",
				"CastleSelectLayout",
				"CastleRestoreTroops",
				"CastleSelectTroops",
				"button_FixCastles",
				"button_UpdateCloud",
				"comboBox_Language",
				"comboBox_testInderdict",
				"button_TradePreviousVillage",
				"button_TradeNextVillage",
				"label_TotalMarkets",
				"comboBox_TradeVillages",
				"groupBox_TradingVillage",
				"button_ScoutingPreviousVillage",
				"button_ScoutingNextVillage",
				"comboBox_ScoutingVillages",
				"groupBox_ScoutingVillage",
				"button_previousLayout",
				"button_nextLayout",
				"contextMenuStrip1",
				"comboBox_villageLayouts",
				"dataGridView_RepairCastle",
				"label_RadarAltAccounts",
				"dataGridView_Banquets",
				"button_InvertSelection",
				"comboBox_command",
				"label_ExtraParameter",
				"comboBox_VillageTemplate",
				"label_AutoID"
			};
		}

		// Token: 0x0600017F RID: 383 RVA: 0x0004005C File Offset: 0x0003E25C
		public static void InitLanguagesBox(ControlForm botForm, ComboBox languagesBox)
		{
			try
			{
				string text = Path.Combine(ControlForm.SettingsFolder, "Languages");
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
				string text2 = Path.Combine(text, "English.csv");
				if (!File.Exists(text2))
				{
					string[] contents = LNG.ParseControl(botForm).ToArray();
					File.WriteAllLines(text2, contents);
				}
				LNG._currentLanguageFile = text2;
				LNG.EnglishFileName = text2;
				string[] files = Directory.GetFiles(text, "*.csv");
				foreach (string path in files)
				{
					languagesBox.Items.Add(Path.GetFileNameWithoutExtension(path));
				}
				LNG.InitUserLanguage(botForm, languagesBox, text);
			}
			catch (Exception ex)
			{
				ABaseService.ReportError(ex, ControlForm.Tab.Main);
			}
		}

		// Token: 0x06000180 RID: 384 RVA: 0x00040120 File Offset: 0x0003E320
		private static string GetLanguageFromSettings()
		{
			try
			{
				return Settings.Default.Language;
			}
			catch (ConfigurationErrorsException ex)
			{
				ABaseService.ProcessOldSettings(ex);
			}
			catch (Exception ex2)
			{
				ABaseService.ReportError(ex2, ControlForm.Tab.Main);
			}
			return string.Empty;
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00040170 File Offset: 0x0003E370
		public static void InitUserLanguage(ControlForm botForm, ComboBox languagesBox, string languagesDirectory)
		{
			string text = LNG.GetLanguageFromSettings();
			bool flag = false;
			if (text == string.Empty)
			{
				CultureInfo cultureInfo = new CultureInfo(Program.mySettings.languageIdent);
				text = cultureInfo.EnglishName;
				flag = true;
			}
			int num = languagesBox.Items.IndexOf(text);
			if (num == -1)
			{
				string str = Path.Combine(languagesDirectory, text + ".csv");
				if (flag)
				{
					botForm.Log("Bot translation: I can see that you play Stronghold Kingdoms in " + text + ". To translate the Bot, make translation file " + str, ControlForm.Tab.Main, false);
				}
				else
				{
					botForm.Log("Bot translation: Language " + text + " is missing. Check file and restart game: " + str, ControlForm.Tab.Main, false);
				}
				num = languagesBox.Items.IndexOf("English");
			}
			else if (text != "English")
			{
				LNG.ApplyLNG(text, botForm);
			}
			languagesBox.SelectedIndex = num;
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00008E29 File Offset: 0x00007029
		internal static void TranslateSecondaryForms(Form form)
		{
			if (!LNG._isEnglishSelected)
			{
				LNG.TranslateControl(form, false);
			}
		}

		// Token: 0x06000183 RID: 387 RVA: 0x00040238 File Offset: 0x0003E438
		public static void ApplyLNG(string selectedItem, ControlForm botForm)
		{
			LNG._isEnglishSelected = (selectedItem == "English");
			string path = Path.Combine(ControlForm.SettingsFolder, "Languages");
			string text = Path.Combine(path, selectedItem + ".csv");
			try
			{
				if (!File.Exists(text))
				{
					botForm.Log("Can't apply selected language: " + selectedItem + ". File doesn't exist: " + text, ControlForm.Tab.Main, false);
				}
				else
				{
					LNG._currentLanguageFile = text;
					if (LNG.LastCultureName != "English")
					{
						LNG.ReadLanguageFile(LNG.EnglishFileName, new Log(botForm.Log));
						LNG.TranslateControl(botForm, true);
					}
					if (!LNG._isEnglishSelected)
					{
						LNG.ReadLanguageFile(text, new Log(botForm.Log));
						LNG.TranslateControl(botForm, false);
						LNG.LastCultureName = selectedItem;
					}
					botForm.CastleRepairService.TranslateUI();
					foreach (ABaseService abaseService in botForm.Services)
					{
						abaseService.TranslateUI();
					}
				}
			}
			catch (Exception ex)
			{
				ABaseService.ReportError(ex, ControlForm.Tab.Main);
			}
		}

		// Token: 0x06000184 RID: 388 RVA: 0x00040364 File Offset: 0x0003E564
		private static void ReadLanguageFile(string filePath, Log printError)
		{
			try
			{
				string[] array = File.ReadAllLines(filePath);
				LNG._allowAddPhrases = false;
				LNG.LogPhrases.Clear();
				foreach (string text in array)
				{
					string[] array3 = text.Split(LNG.Separator, StringSplitOptions.None);
					if (LNG.LogPhrases.ContainsKey(array3[0]))
					{
						printError("Duplicate translation: " + text, ControlForm.Tab.Main, false);
					}
					else
					{
						LNG.LogPhrases.Add(array3[0], array3[1]);
					}
				}
				LNG._allowAddPhrases = true;
			}
			catch (Exception ex)
			{
				ABaseService.ReportError(ex, ControlForm.Tab.Main);
			}
		}

		// Token: 0x06000185 RID: 389 RVA: 0x00040408 File Offset: 0x0003E608
		private static void TranslateControl(Control control, bool toEnglish)
		{
			try
			{
				if (!LNG.DiscludeControls.Contains(control.Name))
				{
					if (!control.Enabled)
					{
						return;
					}
					string empty = string.Empty;
					if (control is TabPage || control is Label || control is Button || control is CheckBox || control is GroupBox || control is RadioButton)
					{
						if (!string.IsNullOrEmpty(control.Text))
						{
							control.Text = (toEnglish ? LNG.ResetControl(control.Name) : LNG.Print(control.Text));
						}
					}
					else
					{
						DataGridView dataGridView = control as DataGridView;
						if (dataGridView != null)
						{
							for (int i = 0; i < dataGridView.Columns.Count; i++)
							{
								if (dataGridView.Columns[i].Visible)
								{
									object tag = dataGridView.Tag;
									if (((tag != null) ? tag.ToString() : null) == "troops" && i > 1)
									{
										break;
									}
									dataGridView.Columns[i].HeaderText = (toEnglish ? LNG.ResetControl(dataGridView.Columns[i].Name) : LNG.Print(dataGridView.Columns[i].HeaderText));
								}
							}
						}
						else
						{
							ComboBox comboBox = control as ComboBox;
							if (comboBox != null)
							{
								for (int j = 0; j < comboBox.Items.Count; j++)
								{
									comboBox.Items[j] = (toEnglish ? LNG.ResetControl(comboBox.Name + j.ToString()) : LNG.Print(comboBox.Items[j].ToString()));
								}
							}
						}
					}
				}
				if (control.HasChildren)
				{
					foreach (object obj in control.Controls)
					{
						Control control2 = (Control)obj;
						LNG.TranslateControl(control2, toEnglish);
					}
				}
			}
			catch (Exception ex)
			{
				ABaseService.ReportError(ex, ControlForm.Tab.Main);
			}
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00040638 File Offset: 0x0003E838
		public static string Print(string key)
		{
			if (LNG._isEnglishSelected)
			{
				return key;
			}
			if (!LNG.LogPhrases.ContainsKey(key))
			{
				if (LNG._allowAddPhrases)
				{
					LNG.LogPhrases.Add(key, key);
					object @lock = LNG._lock;
					lock (@lock)
					{
						File.AppendAllText(LNG._currentLanguageFile, key + "=>" + key + Environment.NewLine);
					}
				}
				return key;
			}
			if (string.IsNullOrEmpty(LNG.LogPhrases[key]))
			{
				LNG.LogPhrases[key] = key;
				return key;
			}
			return LNG.LogPhrases[key];
		}

		// Token: 0x06000187 RID: 391 RVA: 0x000406DC File Offset: 0x0003E8DC
		private static string ResetControl(string key)
		{
			if (!LNG.LogPhrases.ContainsKey(key))
			{
				LNG.LogPhrases.Add(key, key);
				File.AppendAllText(LNG.EnglishFileName, key + "=>" + key + Environment.NewLine);
				return key;
			}
			if (string.IsNullOrEmpty(LNG.LogPhrases[key]))
			{
				LNG.LogPhrases[key] = key;
				return key;
			}
			return LNG.LogPhrases[key];
		}

		// Token: 0x06000188 RID: 392 RVA: 0x0004074C File Offset: 0x0003E94C
		private static List<string> ParseControl(Control control)
		{
			List<string> list = new List<string>();
			if (!control.Enabled)
			{
				return list;
			}
			try
			{
				if (!LNG.DiscludeControls.Contains(control.Name))
				{
					if (control is TabPage || control is Label || control is Button || control is CheckBox || control is GroupBox || control is RadioButton)
					{
						list.Add(control.Name + "=>" + control.Text);
					}
					else
					{
						DataGridView dataGridView = control as DataGridView;
						if (dataGridView != null)
						{
							int num = 0;
							IEnumerator enumerator = dataGridView.Columns.GetEnumerator();
							while (enumerator.MoveNext())
								{
									object obj = enumerator.Current;
									DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj;
									if (dataGridViewColumn.Visible)
									{
										object tag = dataGridView.Tag;
										if (((tag != null) ? tag.ToString() : null) == "troops" && num > 1)
										{
											break;
										}
										list.Add(dataGridViewColumn.Name + "=>" + dataGridViewColumn.HeaderText);
										num++;
									}
							}
							goto IL_164;
						}
						ComboBox comboBox = control as ComboBox;
						if (comboBox != null)
						{
							for (int i = 0; i < comboBox.Items.Count; i++)
							{
								list.Add(string.Format("{0}=>{1}", comboBox.Name + i.ToString(), comboBox.Items[i]));
							}
						}
					}
				}
				IL_164:
				if (control.HasChildren)
				{
					foreach (object obj2 in control.Controls)
					{
						Control control2 = (Control)obj2;
						list.AddRange(LNG.ParseControl(control2));
					}
				}
			}
			catch (Exception ex)
			{
				ABaseService.ReportError(ex, ControlForm.Tab.Main);
			}
			return list;
		}

		// Token: 0x040002CD RID: 717
		private static Dictionary<string, string> LogPhrases;

		// Token: 0x040002CE RID: 718
		private static string[] DiscludeControls;

		// Token: 0x040002CF RID: 719
		private static string _currentLanguageFile;

		// Token: 0x040002D0 RID: 720
		internal static bool _isEnglishSelected = true;

		// Token: 0x040002D1 RID: 721
		private const string LanguagesDirectoryName = "Languages";

		// Token: 0x040002D2 RID: 722
		private static string EnglishFileName;

		// Token: 0x040002D3 RID: 723
		private const string EnglishCultureName = "English";

		// Token: 0x040002D4 RID: 724
		private static string LastCultureName = "English";

		// Token: 0x040002D5 RID: 725
		private static string[] Separator = new string[]
		{
			"=>"
		};

		// Token: 0x040002D6 RID: 726
		private static bool _allowAddPhrases = true;

		// Token: 0x040002D7 RID: 727
		private static object _lock = new object();
	}
}
