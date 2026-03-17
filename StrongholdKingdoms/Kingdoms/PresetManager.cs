using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Stronghold.AuthClient;
using Upgrade;
using Upgrade.Services;

namespace Kingdoms
{
	// Token: 0x02000283 RID: 643
	public class PresetManager
	{
		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x06001CDA RID: 7386 RVA: 0x0001C3ED File Offset: 0x0001A5ED
		public static PresetManager Instance
		{
			get
			{
				if (PresetManager.instance == null)
				{
					PresetManager.instance = new PresetManager();
				}
				return PresetManager.instance;
			}
		}

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x06001CDB RID: 7387 RVA: 0x0001C405 File Offset: 0x0001A605
		public bool IsDataReady
		{
			get
			{
				return this.isPresetDataLoaded && !this.isPresetDataLoading;
			}
		}

		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x06001CDC RID: 7388 RVA: 0x0001C41A File Offset: 0x0001A61A
		public bool IsDownloading
		{
			get
			{
				return this.isPresetDataLoading;
			}
		}

		// Token: 0x06001CDD RID: 7389 RVA: 0x001C392C File Offset: 0x001C1B2C
		private PresetManager()
		{
			this.SlotLimits.Add(PresetType.TROOP_ATTACK, 40);
			this.SlotLimits.Add(PresetType.TROOP_DEFEND, 20);
			this.SlotLimits.Add(PresetType.INFRASTRUCTURE, 20);
			this.SlotCounts.Add(PresetType.TROOP_ATTACK, 0);
			this.SlotCounts.Add(PresetType.TROOP_DEFEND, 0);
			this.SlotCounts.Add(PresetType.INFRASTRUCTURE, 0);
		}

		// Token: 0x06001CDE RID: 7390 RVA: 0x0001C422 File Offset: 0x0001A622
		public void SetPresetURL(string url)
		{
			this.m_presetURL = url;
		}

		// Token: 0x06001CDF RID: 7391 RVA: 0x001C39BC File Offset: 0x001C1BBC
		public bool ParseXMLString(string source)
		{
			source = source.Replace("True", "1").Replace("False", "0");
			XmlDocument xmlDocument = new XmlDocument();
			try
			{
				xmlDocument.LoadXml(source);
			}
			catch (Exception ex)
			{
				string message = ex.Message;
				return false;
			}
			this.m_presets.Clear();
			this.ResetSlotCounts();
			foreach (object obj in xmlDocument.ChildNodes[0].ChildNodes)
			{
				XmlElement element = (XmlElement)obj;
				CastleMapPreset castleMapPreset = new CastleMapPreset();
				castleMapPreset.ParseXML(element);
				Dictionary<PresetType, int> slotCounts = this.SlotCounts;
				PresetType type = castleMapPreset.Type;
				int num = slotCounts[type];
				slotCounts[type] = num + 1;
				this.m_presets.Add(castleMapPreset);
			}
			return true;
		}

		// Token: 0x06001CE0 RID: 7392 RVA: 0x001C3AC0 File Offset: 0x001C1CC0
		public string GenerateXMLString()
		{
			XmlDocument xmlDocument = new XmlDocument();
			XmlElement xmlElement = xmlDocument.CreateElement("presets");
			foreach (CastleMapPreset castleMapPreset in this.m_presets)
			{
				xmlElement.AppendChild(castleMapPreset.GenerateXML(xmlDocument));
			}
			return xmlElement.OuterXml;
		}

		// Token: 0x06001CE1 RID: 7393 RVA: 0x001C3B34 File Offset: 0x001C1D34
		public bool ParseXMLFile(string filename)
		{
			XmlDocument xmlDocument = new XmlDocument();
			try
			{
				xmlDocument.Load(filename);
			}
			catch (Exception)
			{
				return false;
			}
			return this.ParseXMLString(xmlDocument.OuterXml);
		}

		// Token: 0x06001CE2 RID: 7394 RVA: 0x0001C42B File Offset: 0x0001A62B
		public void GenerateXMLFile(string filename)
		{
			File.WriteAllText(filename, this.GenerateXMLString());
		}

		// Token: 0x06001CE3 RID: 7395 RVA: 0x0001C439 File Offset: 0x0001A639
		public int GetSlotCount(PresetType type)
		{
			return this.SlotCounts[type];
		}

		// Token: 0x06001CE4 RID: 7396 RVA: 0x0001C447 File Offset: 0x0001A647
		public int GetSlotLimit(PresetType type)
		{
			return this.SlotLimits[type];
		}

		// Token: 0x06001CE5 RID: 7397 RVA: 0x001C3B74 File Offset: 0x001C1D74
		public int GetHighestAvailableSlot(PresetType type)
		{
			int num = 0;
			foreach (CastleMapPreset castleMapPreset in this.m_presets)
			{
				if (castleMapPreset.Type == type && castleMapPreset.SlotID > num)
				{
					num = castleMapPreset.SlotID;
				}
			}
			return Math.Min(this.SlotLimits[type], num - num % 5 + 5);
		}

		// Token: 0x06001CE6 RID: 7398 RVA: 0x001C3BF4 File Offset: 0x001C1DF4
		public int GetFreeSlotCount(PresetType type)
		{
			int num = 0;
			foreach (CastleMapPreset castleMapPreset in this.m_presets)
			{
				if (castleMapPreset.Type == type)
				{
					num++;
				}
			}
			return this.GetSlotLimit(type) - num;
		}

		// Token: 0x06001CE7 RID: 7399 RVA: 0x0001C455 File Offset: 0x0001A655
		private void ResetSlotCounts()
		{
			this.SlotCounts[PresetType.TROOP_ATTACK] = 0;
			this.SlotCounts[PresetType.TROOP_DEFEND] = 0;
			this.SlotCounts[PresetType.INFRASTRUCTURE] = 0;
		}

		// Token: 0x06001CE8 RID: 7400 RVA: 0x001C3C58 File Offset: 0x001C1E58
		public CastleMapPreset GetPreset(string name)
		{
			foreach (CastleMapPreset castleMapPreset in this.m_presets)
			{
				if (name.Equals(castleMapPreset.Name))
				{
					return castleMapPreset;
				}
			}
			return null;
		}

		// Token: 0x06001CE9 RID: 7401 RVA: 0x001C3CBC File Offset: 0x001C1EBC
		public CastleMapPreset GetPreset(PresetType type, int slot)
		{
			foreach (CastleMapPreset castleMapPreset in this.m_presets)
			{
				if (type == castleMapPreset.Type && slot == castleMapPreset.SlotID)
				{
					return castleMapPreset;
				}
			}
			return null;
		}

		// Token: 0x06001CEA RID: 7402 RVA: 0x001C3D24 File Offset: 0x001C1F24
		public List<CastleMapPreset> GetPresets(PresetType type)
		{
			List<CastleMapPreset> list = new List<CastleMapPreset>();
			foreach (CastleMapPreset castleMapPreset in this.m_presets)
			{
				if (castleMapPreset.Type == type)
				{
					list.Add(castleMapPreset);
				}
			}
			return list;
		}

		// Token: 0x06001CEB RID: 7403 RVA: 0x001C3D88 File Offset: 0x001C1F88
		public PresetResult AddPreset(CastleMapPreset newPreset)
		{
			foreach (CastleMapPreset castleMapPreset in this.m_presets)
			{
				PresetType type = castleMapPreset.Type;
				PresetType type2 = newPreset.Type;
			}
			this.m_presets.Add(newPreset);
			Dictionary<PresetType, int> slotCounts = this.SlotCounts;
			PresetType type3 = newPreset.Type;
			int num = slotCounts[type3];
			slotCounts[type3] = num + 1;
			return PresetResult.OK;
		}

		// Token: 0x06001CEC RID: 7404 RVA: 0x001C3E10 File Offset: 0x001C2010
		public PresetResult UpdatePreset(CastleMapPreset newPreset)
		{
			if (newPreset.SlotID >= 1)
			{
				List<CastleMapPreset.CastleElementInfo> basicData = new List<CastleMapPreset.CastleElementInfo>(newPreset.BasicData);
				foreach (CastleMapPreset castleMapPreset in this.m_presets)
				{
					if (castleMapPreset.SlotID == newPreset.SlotID && castleMapPreset.Type == newPreset.Type)
					{
						castleMapPreset.Name = newPreset.Name;
						castleMapPreset.ModifiedDate = newPreset.ModifiedDate;
						castleMapPreset.ElementCount = newPreset.ElementCount;
						castleMapPreset.Data = newPreset.Data;
						castleMapPreset.BasicData.Clear();
						castleMapPreset.BasicData = basicData;
						this.LocalChangesAvailable = true;
						return PresetResult.OK;
					}
				}
				return this.AddPreset(newPreset);
			}
			if (this.GetFreeSlotCount(newPreset.Type) < 1)
			{
				return PresetResult.NO_SLOT_AVAILABLE;
			}
			for (int i = 1; i <= this.GetSlotLimit(newPreset.Type); i++)
			{
				if (this.GetPreset(newPreset.Type, i) == null)
				{
					newPreset.SlotID = i;
					break;
				}
			}
			this.LocalChangesAvailable = true;
			return this.AddPreset(newPreset);
		}

		// Token: 0x06001CED RID: 7405 RVA: 0x001C3F34 File Offset: 0x001C2134
		public PresetResult DeletePreset(PresetType type, int slot)
		{
			bool flag = false;
			CastleMapPreset castleMapPreset = null;
			foreach (CastleMapPreset castleMapPreset2 in this.m_presets)
			{
				if (castleMapPreset2.Type == type && castleMapPreset2.SlotID == slot)
				{
					castleMapPreset = castleMapPreset2;
					break;
				}
			}
			if (castleMapPreset != null)
			{
				this.m_presets.Remove(castleMapPreset);
				flag = true;
				this.LocalChangesAvailable = true;
			}
			if (!flag)
			{
				return PresetResult.PRESET_NOT_FOUND;
			}
			return PresetResult.OK;
		}

		// Token: 0x06001CEE RID: 7406 RVA: 0x0001C47E File Offset: 0x0001A67E
		public void SavePresetsToFile()
		{
			this.GenerateXMLFile(GameEngine.getSettingsPath(true) + "\\Presets.xml");
		}

		// Token: 0x06001CEF RID: 7407 RVA: 0x0001C496 File Offset: 0x0001A696
		public void LoadPresetsFromFile()
		{
			if (!this.isLoaded)
			{
				this.ParseXMLFile(GameEngine.getSettingsPath(true) + "\\Presets.xml");
				this.isLoaded = true;
			}
		}

		// Token: 0x06001CF0 RID: 7408 RVA: 0x001C3FBC File Offset: 0x001C21BC
		public void SendPresetsToServer(PresetPanel panel)
		{
			this.m_responsePanel = panel;
			XmlRpcPresetProvider xmlRpcPresetProvider = XmlRpcPresetProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressPresets, URLs.ProfileServerPort, URLs.ProfilePresetsPath);
			XmlRpcPresetRequest xmlRpcPresetRequest = new XmlRpcPresetRequest();
			xmlRpcPresetRequest.SessionID = RemoteServices.Instance.SessionGuid.ToString().Replace("-", "");
			xmlRpcPresetRequest.UserGUID = RemoteServices.Instance.UserGuid.ToString().Replace("-", "");
			xmlRpcPresetRequest.FileData = this.GenerateXMLString();
			this.m_responseDel = new PresetManager.ResponseDelegate(panel.onUploadComplete);
			xmlRpcPresetProvider.UploadFileData(xmlRpcPresetRequest, new PresetEndResponseDelegate(this.SendPresetsToServerCallback), null);
		}

		// Token: 0x06001CF1 RID: 7409 RVA: 0x001C407C File Offset: 0x001C227C
		private void SendPresetsToServerCallback(IPresetProvider provider, IPresetResponse response)
		{
			int? successCode = response.SuccessCode;
			int num = 1;
			if ((successCode.GetValueOrDefault() == num & successCode != null) && this.isPresetDataLoaded)
			{
				this.LocalChangesAvailable = false;
				this.ShowPresetImport = false;
				ControlForm controlForm = DX.ControlForm;
				if (controlForm != null)
				{
					CastleRepairService castleRepairService = controlForm.CastleRepairService;
					if (castleRepairService != null)
					{
						castleRepairService.UpdateCastleGridPresets();
					}
				}
			}
			if (this.m_responsePanel != null)
			{
				Control responsePanel = this.m_responsePanel;
				Delegate responseDel = this.m_responseDel;
				object[] array = new object[1];
				int num2 = 0;
				successCode = response.SuccessCode;
				num = 1;
				array[num2] = (successCode.GetValueOrDefault() == num & successCode != null);
				responsePanel.Invoke(responseDel, array);
			}
		}

		// Token: 0x06001CF2 RID: 7410 RVA: 0x001C411C File Offset: 0x001C231C
		public void LoadPresetsFromServer(PresetPanel panel)
		{
			if (!this.isPresetDataLoaded && !this.isPresetDataLoading)
			{
				this.isPresetDataLoading = true;
				try
				{
					PresetManager.RequestState requestState = new PresetManager.RequestState();
					RequestCachePolicy cachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
					WebRequest webRequest = WebRequest.Create(this.m_presetURL);
					webRequest.CachePolicy = cachePolicy;
					requestState.req = webRequest;
					requestState.asyncCallback = new PresetManager.AsyncDelegate(this.onLoadComplete);
					webRequest.BeginGetResponse(new AsyncCallback(this.LoadPresetsFromServerCallback), requestState);
					this.m_responsePanel = panel;
					this.m_responseDel = new PresetManager.ResponseDelegate(panel.onServerResponse);
				}
				catch (Exception)
				{
					this.onLoadComplete();
				}
			}
		}

		// Token: 0x06001CF3 RID: 7411 RVA: 0x001C41C4 File Offset: 0x001C23C4
		private void LoadPresetsFromServerCallback(IAsyncResult ar)
		{
			PresetManager.AsyncDelegate asyncDelegate = null;
			try
			{
				PresetManager.RequestState requestState = (PresetManager.RequestState)ar.AsyncState;
				WebRequest req = requestState.req;
				asyncDelegate = requestState.asyncCallback;
				WebResponse webResponse = req.EndGetResponse(ar);
				Stream responseStream = webResponse.GetResponseStream();
				using (MemoryStream memoryStream = new MemoryStream())
				{
					byte[] array = new byte[4096];
					int num;
					do
					{
						num = responseStream.Read(array, 0, array.Length);
						memoryStream.Write(array, 0, num);
					}
					while (num != 0);
					if (this.ParseXMLString(Encoding.ASCII.GetString(memoryStream.ToArray())))
					{
						this.isPresetDataLoaded = true;
						CastleRepairService castleRepairService = DX.ControlForm.CastleRepairService;
						if (castleRepairService != null)
						{
							castleRepairService.UpdateCastleGridPresets();
						}
						DX.ControlForm.GetService<PredatorService>().InitPredatorFormations();
					}
				}
			}
			catch (Exception ex)
			{
				MyMessageBox.Show(ex.Message);
			}
			if (asyncDelegate != null)
			{
				asyncDelegate();
			}
		}

		// Token: 0x06001CF4 RID: 7412 RVA: 0x0001C4BE File Offset: 0x0001A6BE
		private void onLoadComplete()
		{
			this.isPresetDataLoading = false;
			if (this.m_responsePanel != null)
			{
				this.m_responsePanel.Invoke(this.m_responseDel, new object[]
				{
					this.isPresetDataLoaded
				});
			}
		}

		// Token: 0x06001CF5 RID: 7413 RVA: 0x0001C4F5 File Offset: 0x0001A6F5
		public void LogOut()
		{
			this.m_presets.Clear();
			this.ImportComplete = false;
			this.isPresetDataLoaded = false;
			this.isPresetDataLoading = false;
			this.LocalChangesAvailable = false;
		}

		// Token: 0x06001CF6 RID: 7414 RVA: 0x0001C51E File Offset: 0x0001A71E
		public bool CopyCurrentToPreset(CastleMapPreset preset)
		{
			if (this.m_currentMapPreset == null || this.m_currentMapType != preset.Type)
			{
				return false;
			}
			preset.CopyData(this.m_currentMapPreset);
			return true;
		}

		// Token: 0x06001CF7 RID: 7415 RVA: 0x0001C545 File Offset: 0x0001A745
		public int CurrentElementCount()
		{
			if (this.m_currentMapPreset == null)
			{
				return 0;
			}
			return this.m_currentMapPreset.ElementCount;
		}

		// Token: 0x06001CF8 RID: 7416 RVA: 0x001C42C0 File Offset: 0x001C24C0
		public void DeployToMap(CastleMapPreset preset)
		{
			this.m_currentMapType = preset.Type;
			switch (this.m_currentMapType)
			{
			case PresetType.TROOP_ATTACK:
				GameEngine.Instance.CastleAttackerSetup.restoreAttackPreset(preset);
				break;
			case PresetType.TROOP_DEFEND:
				GameEngine.Instance.Castle.restoreTroopsPreset(preset);
				break;
			case PresetType.INFRASTRUCTURE:
				GameEngine.Instance.Castle.restoreInfrastructurePreset(preset);
				break;
			}
			this.GenerateFromMap(this.m_currentMapType);
		}

		// Token: 0x06001CF9 RID: 7417 RVA: 0x001C433C File Offset: 0x001C253C
		public void GenerateFromMap(PresetType type)
		{
			this.m_currentMapType = type;
			switch (this.m_currentMapType)
			{
			case PresetType.TROOP_ATTACK:
				this.m_currentMapPreset = GameEngine.Instance.CastleAttackerSetup.generateAttackPreset("current");
				return;
			case PresetType.TROOP_DEFEND:
				this.m_currentMapPreset = GameEngine.Instance.Castle.generateTroopsPreset("current");
				return;
			case PresetType.INFRASTRUCTURE:
				this.m_currentMapPreset = GameEngine.Instance.Castle.generateInfrastructurePreset("current");
				return;
			default:
				return;
			}
		}

		// Token: 0x06001CFA RID: 7418 RVA: 0x001C43BC File Offset: 0x001C25BC
		public int getLegacyCount(PresetType type)
		{
			char[] separator = new char[]
			{
				'_'
			};
			int num = 0;
			string[] files = Directory.GetFiles(GameEngine.getSettingsPath(true), "*.cas");
			string[] array = files;
			foreach (string text in array)
			{
				string fileName = Path.GetFileName(text.Remove(text.LastIndexOf('.')));
				string[] array3 = fileName.Split(separator);
				if (array3.Length >= 2 && !(array3[0].ToLowerInvariant() != "attacksetup"))
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06001CFB RID: 7419 RVA: 0x001C444C File Offset: 0x001C264C
		public bool transferLegacy(PresetType type)
		{
			if (!Program.mySettings.AttackSetupsUpdated)
			{
				GameEngine.Instance.CastleAttackerSetup.cleanUpAttackSaveNames();
				Program.mySettings.AttackSetupsUpdated = true;
			}
			char[] separator = new char[]
			{
				'_'
			};
			string[] files = Directory.GetFiles(GameEngine.getSettingsPath(true), "*.cas");
			List<string> list = new List<string>();
			string text = "";
			switch (type)
			{
			case PresetType.TROOP_ATTACK:
				text = "AttackSetup";
				break;
			case PresetType.TROOP_DEFEND:
				text = "CasTroop";
				break;
			case PresetType.INFRASTRUCTURE:
				text = "CasInfra";
				break;
			}
			string[] array = files;
			foreach (string path in array)
			{
				string fileName = Path.GetFileName(path);
				string[] array3 = fileName.Split(separator);
				if (array3.Length >= 2 && !(array3[0].ToLowerInvariant() != text.ToLowerInvariant()))
				{
					list.Add(fileName);
				}
			}
			if (list.Count > this.GetFreeSlotCount(type))
			{
				return false;
			}
			List<CastleMapPreset> list2 = new List<CastleMapPreset>();
			foreach (string text2 in list)
			{
				string displayName = text2.Remove(text2.LastIndexOf('.')).Replace(text + "_", "");
				CastleMapPreset castleMapPreset = this.convertLegacyToPreset(text2, displayName, type);
				if (castleMapPreset == null)
				{
					return false;
				}
				list2.Add(castleMapPreset);
			}
			foreach (CastleMapPreset newPreset in list2)
			{
				this.UpdatePreset(newPreset);
			}
			return true;
		}

		// Token: 0x06001CFC RID: 7420 RVA: 0x0000A849 File Offset: 0x00008A49
		public bool deleteLegacy(PresetType type)
		{
			return true;
		}

		// Token: 0x06001CFD RID: 7421 RVA: 0x001C4610 File Offset: 0x001C2810
		private CastleMapPreset convertLegacyToPreset(string filename, string displayName, PresetType type)
		{
			if (type != PresetType.TROOP_ATTACK)
			{
				return null;
			}
			CastleMapPreset castleMapPreset = new CastleMapPreset(displayName, DateTime.Now, type, 0);
			CastleMapPreset result;
			try
			{
				string settingsPath = GameEngine.getSettingsPath(true);
				FileStream input = new FileStream(settingsPath + "\\" + filename, FileMode.Open);
				BinaryReader binaryReader = new BinaryReader(input);
				castleMapPreset.ElementCount = binaryReader.ReadInt32();
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < castleMapPreset.ElementCount; i++)
				{
					CastleMapPreset.CastleElementInfo castleElementInfo = new CastleMapPreset.CastleElementInfo();
					castleElementInfo.xPos = binaryReader.ReadByte();
					castleElementInfo.yPos = binaryReader.ReadByte();
					castleElementInfo.elementType = binaryReader.ReadByte();
					castleElementInfo.reinforcement = false;
					castleMapPreset.BasicData.Add(castleElementInfo);
					stringBuilder.Append(castleElementInfo.xPos.ToString() + " ");
					stringBuilder.Append(castleElementInfo.yPos.ToString() + " ");
					stringBuilder.Append(castleElementInfo.elementType.ToString() + " ");
					if (castleElementInfo.elementType == 94)
					{
						stringBuilder.Append(binaryReader.ReadByte().ToString() + " ");
						stringBuilder.Append(binaryReader.ReadByte().ToString() + " ");
					}
					if (castleElementInfo.elementType >= 100 && castleElementInfo.elementType < 109)
					{
						stringBuilder.Append(binaryReader.ReadByte().ToString() + " ");
						if (castleElementInfo.elementType == 102 || castleElementInfo.elementType == 103)
						{
							stringBuilder.Append(binaryReader.ReadByte().ToString() + " ");
							stringBuilder.Append(binaryReader.ReadByte().ToString() + " ");
						}
					}
				}
				castleMapPreset.Data = stringBuilder.ToString();
				result = castleMapPreset;
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x04002DBF RID: 11711
		private static PresetManager instance;

		// Token: 0x04002DC0 RID: 11712
		private string m_presetURL = "";

		// Token: 0x04002DC1 RID: 11713
		public bool ShowPresetImport;

		// Token: 0x04002DC2 RID: 11714
		public bool ImportComplete;

		// Token: 0x04002DC3 RID: 11715
		public bool LocalChangesAvailable;

		// Token: 0x04002DC4 RID: 11716
		public List<CastleMapPreset> m_presets = new List<CastleMapPreset>();

		// Token: 0x04002DC5 RID: 11717
		private Dictionary<PresetType, int> SlotLimits = new Dictionary<PresetType, int>();

		// Token: 0x04002DC6 RID: 11718
		private Dictionary<PresetType, int> SlotCounts = new Dictionary<PresetType, int>();

		// Token: 0x04002DC7 RID: 11719
		private PresetManager.AsyncDelegate m_loadDel;

		// Token: 0x04002DC8 RID: 11720
		private PresetManager.ResponseDelegate m_responseDel;

		// Token: 0x04002DC9 RID: 11721
		private bool isPresetDataLoaded;

		// Token: 0x04002DCA RID: 11722
		private bool isPresetDataLoading;

		// Token: 0x04002DCB RID: 11723
		private PresetPanel m_responsePanel;

		// Token: 0x04002DCC RID: 11724
		private bool isLoaded;

		// Token: 0x04002DCD RID: 11725
		private CastleMapPreset m_currentMapPreset;

		// Token: 0x04002DCE RID: 11726
		private PresetType m_currentMapType;

		// Token: 0x02000284 RID: 644
		// (Invoke) Token: 0x06001CFF RID: 7423
		private delegate void AsyncDelegate();

		// Token: 0x02000285 RID: 645
		// (Invoke) Token: 0x06001D03 RID: 7427
		public delegate void ResponseDelegate(bool success);

		// Token: 0x02000286 RID: 646
		private class RequestState
		{
			// Token: 0x04002DCF RID: 11727
			public WebRequest req;

			// Token: 0x04002DD0 RID: 11728
			public PresetManager.AsyncDelegate asyncCallback;
		}
	}
}
