using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x020004ED RID: 1261
	public class VillageReportBackgroundPanel : UserControl, IDockableControl, IDockWindow
	{
		// Token: 0x06002FA1 RID: 12193 RVA: 0x00022919 File Offset: 0x00020B19
		public void AddControl(UserControl control, int x, int y)
		{
			this.dockWindow.AddControl(control, x, y);
		}

		// Token: 0x06002FA2 RID: 12194 RVA: 0x00022929 File Offset: 0x00020B29
		public void RemoveControl(UserControl control)
		{
			this.dockWindow.RemoveControl(control);
		}

		// Token: 0x06002FA3 RID: 12195 RVA: 0x002701D0 File Offset: 0x0026E3D0
		public VillageReportBackgroundPanel()
		{
			this.dockableControl = new DockableControl(this);
			this.dockWindow = new DockWindow(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint, true);
		}

		// Token: 0x06002FA4 RID: 12196 RVA: 0x00270450 File Offset: 0x0026E650
		public void showPanel(int panelID)
		{
			if (panelID != -1)
			{
				GFXLibrary.getPanelDescFromID(panelID);
			}
			if (this.lastPanelType == 1008)
			{
				this.parishFrontPagePanel.leaving();
			}
			this.lastVillageVisited = InterfaceMgr.Instance.getSelectedMenuVillage();
			this.lastPanelType = panelID;
			this.closeSubControls();
			if (panelID < 0)
			{
				return;
			}
			if (panelID <= 1009)
			{
				if (panelID <= 99)
				{
					switch (panelID)
					{
					case 1:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.holdBanquetPanel.initProperties(true, "Hold Banquet", this);
						this.holdBanquetPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.holdBanquetPanel.display(this, (base.Size.Width - this.holdBanquetPanel.Size.Width) / 2, (base.Size.Height - this.holdBanquetPanel.Size.Height) / 2);
						this.holdBanquetPanel.BringToFront();
						this.holdBanquetPanel.init();
						this.currentPanelWidth = this.holdBanquetPanel.Size.Width;
						this.currentPanelHeight = this.holdBanquetPanel.Size.Height;
						break;
					case 2:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.marketTransferPanel.initProperties(true, "Market Transfer", this);
						this.marketTransferPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.marketTransferPanel.display(this, (base.Size.Width - this.marketTransferPanel.Size.Width) / 2, (base.Size.Height - this.marketTransferPanel.Size.Height) / 2);
						this.marketTransferPanel.BringToFront();
						this.marketTransferPanel.init();
						this.currentPanelWidth = this.marketTransferPanel.Size.Width;
						this.currentPanelHeight = this.marketTransferPanel.Size.Height;
						break;
					case 3:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.stockExchangePanel.initProperties(true, "Stock Exchange", this);
						this.stockExchangePanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.stockExchangePanel.display(this, (base.Size.Width - this.stockExchangePanel.Size.Width) / 2, (base.Size.Height - this.stockExchangePanel.Size.Height) / 2);
						this.stockExchangePanel.BringToFront();
						this.stockExchangePanel.init();
						this.currentPanelWidth = this.stockExchangePanel.Size.Width;
						this.currentPanelHeight = this.stockExchangePanel.Size.Height;
						break;
					case 4:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.barracksPanel.initProperties(true, "Barracks", this);
						this.barracksPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.barracksPanel.display(this, (base.Size.Width - this.barracksPanel.Size.Width) / 2, (base.Size.Height - this.barracksPanel.Size.Height) / 2);
						this.barracksPanel.BringToFront();
						this.barracksPanel.init();
						this.currentPanelWidth = this.barracksPanel.Size.Width;
						this.currentPanelHeight = this.barracksPanel.Size.Height;
						break;
					case 5:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.resourcesPanel.initProperties(true, "Resources", this);
						this.resourcesPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.resourcesPanel.display(this, (base.Size.Width - this.resourcesPanel.Size.Width) / 2, (base.Size.Height - this.resourcesPanel.Size.Height) / 2);
						this.resourcesPanel.BringToFront();
						this.resourcesPanel.init();
						this.currentPanelWidth = this.resourcesPanel.Size.Width;
						this.currentPanelHeight = this.resourcesPanel.Size.Height;
						break;
					case 6:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.villageReinforcementsPanel.initProperties(true, "Reinforcements", this);
						this.villageReinforcementsPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.villageReinforcementsPanel.Size = new Size(this.villageReinforcementsPanel.Size.Width, base.Height);
						this.villageReinforcementsPanel.display(this, (base.Size.Width - this.villageReinforcementsPanel.Size.Width) / 2, 0);
						this.villageReinforcementsPanel.BringToFront();
						this.villageReinforcementsPanel.setReinforcementVillage(-1);
						this.villageReinforcementsPanel.init(false);
						this.currentPanelWidth = this.villageReinforcementsPanel.Size.Width;
						this.currentPanelHeight = this.villageReinforcementsPanel.Size.Height;
						break;
					case 7:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.villageArmiesPanel.initProperties(true, "Armies", this);
						this.villageArmiesPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.villageArmiesPanel.Size = new Size(this.villageArmiesPanel.Size.Width, base.Height);
						this.villageArmiesPanel.display(this, (base.Size.Width - this.villageArmiesPanel.Size.Width) / 2, 0);
						this.villageArmiesPanel.BringToFront();
						this.villageArmiesPanel.init(false);
						this.currentPanelWidth = this.villageArmiesPanel.Size.Width;
						this.currentPanelHeight = this.villageArmiesPanel.Size.Height;
						break;
					case 8:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.vassalControlPanel.initProperties(true, "Vassals", this);
						this.vassalControlPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.vassalControlPanel.Size = new Size(this.vassalControlPanel.Size.Width, base.Height);
						this.vassalControlPanel.display(this, (base.Size.Width - this.vassalControlPanel.Size.Width) / 2, 0);
						this.vassalControlPanel.BringToFront();
						this.vassalControlPanel.init(false);
						this.currentPanelWidth = this.vassalControlPanel.Size.Width;
						this.currentPanelHeight = this.vassalControlPanel.Size.Height;
						break;
					case 9:
					case 14:
					case 16:
					case 27:
					case 28:
					case 29:
					case 32:
					case 33:
					case 34:
					case 35:
					case 36:
					case 37:
					case 38:
					case 39:
					case 40:
					case 49:
					case 50:
					case 53:
					case 54:
					case 55:
					case 56:
					case 57:
					case 58:
					case 59:
					case 61:
					case 62:
					case 63:
					case 64:
						break;
					case 10:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.avatarEditorPanel.initProperties(true, "Avatar", this);
						this.avatarEditorPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.avatarEditorPanel.display(this, (base.Size.Width - this.avatarEditorPanel.Size.Width) / 2, (base.Size.Height - this.avatarEditorPanel.Size.Height) / 2);
						this.avatarEditorPanel.BringToFront();
						this.avatarEditorPanel.init();
						this.currentPanelWidth = this.avatarEditorPanel.Size.Width;
						this.currentPanelHeight = this.avatarEditorPanel.Size.Height;
						break;
					case 11:
					case 12:
					case 13:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.unknownPanel.initProperties(true, "Unknown", this);
						this.unknownPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.unknownPanel.display(this, (base.Size.Width - this.unknownPanel.Size.Width) / 2, (base.Size.Height - this.unknownPanel.Size.Height) / 2);
						this.unknownPanel.BringToFront();
						this.unknownPanel.init();
						this.currentPanelWidth = this.unknownPanel.Size.Width;
						this.currentPanelHeight = this.unknownPanel.Size.Height;
						break;
					case 15:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.vassalArmiesPanel.initProperties(true, "Vassal Troops", this);
						this.vassalArmiesPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.vassalArmiesPanel.display(this, (base.Size.Width - this.vassalArmiesPanel.Size.Width) / 2, (base.Size.Height - this.vassalArmiesPanel.Size.Height) / 2);
						this.vassalArmiesPanel.BringToFront();
						this.vassalArmiesPanel.init(false);
						this.currentPanelWidth = this.vassalArmiesPanel.Size.Width;
						this.currentPanelHeight = this.vassalArmiesPanel.Size.Height;
						break;
					case 17:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.capitalSendTroopsPanel.initProperties(true, "Vassal Attacks", this);
						this.capitalSendTroopsPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.capitalSendTroopsPanel.display(this, (base.Size.Width - this.capitalSendTroopsPanel.Size.Width) / 2, (base.Size.Height - this.capitalSendTroopsPanel.Size.Height) / 2);
						this.capitalSendTroopsPanel.BringToFront();
						this.capitalSendTroopsPanel.init(false);
						this.currentPanelWidth = this.capitalSendTroopsPanel.Size.Width;
						this.currentPanelHeight = this.capitalSendTroopsPanel.Size.Height;
						break;
					case 18:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.unitsPanel.initProperties(true, "Units", this);
						this.unitsPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.unitsPanel.display(this, (base.Size.Width - this.unitsPanel.Size.Width) / 2, (base.Size.Height - this.unitsPanel.Size.Height) / 2);
						this.unitsPanel.BringToFront();
						this.unitsPanel.init();
						this.currentPanelWidth = this.unitsPanel.Size.Width;
						this.currentPanelHeight = this.unitsPanel.Size.Height;
						break;
					case 19:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.rankingsPanel.initProperties(true, "Rankings", this);
						this.rankingsPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.rankingsPanel.display(this, (base.Size.Width - this.rankingsPanel.Size.Width) / 2, (base.Size.Height - this.rankingsPanel.Size.Height) / 2);
						this.rankingsPanel.BringToFront();
						this.rankingsPanel.init(true);
						this.currentPanelWidth = this.rankingsPanel.Size.Width;
						this.currentPanelHeight = this.rankingsPanel.Size.Height;
						break;
					case 20:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.statsPanel.initProperties(true, "Stats", this);
						this.statsPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.statsPanel.Size = new Size(this.statsPanel.Size.Width, base.Height);
						this.statsPanel.display(this, (base.Size.Width - this.statsPanel.Size.Width) / 2, 0);
						this.statsPanel.BringToFront();
						this.statsPanel.init(false);
						this.currentPanelWidth = this.statsPanel.Size.Width;
						this.currentPanelHeight = this.statsPanel.Size.Height;
						break;
					case 21:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.reportsPanel.initProperties(true, "Reports", this);
						this.reportsPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.reportsPanel.Size = new Size(this.reportsPanel.Size.Width, base.Height);
						this.reportsPanel.display(this, (base.Size.Width - this.reportsPanel.Size.Width) / 2, 0);
						this.reportsPanel.BringToFront();
						this.reportsPanel.init(false);
						this.currentPanelWidth = this.reportsPanel.Size.Width;
						this.currentPanelHeight = this.reportsPanel.Size.Height;
						break;
					case 22:
					{
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.gloryPanel.initProperties(true, "Glory", this);
						this.gloryPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						int num = base.Width;
						int num2 = base.Height;
						if (num > 1600)
						{
							num = 1600;
						}
						if (num2 > 1024)
						{
							num2 = 1024;
						}
						this.gloryPanel.Size = new Size(num, num2);
						this.gloryPanel.display(this, (base.Size.Width - this.gloryPanel.Size.Width) / 2, (base.Size.Height - this.gloryPanel.Size.Height) / 2);
						this.gloryPanel.BringToFront();
						this.gloryPanel.init();
						this.currentPanelWidth = num;
						this.currentPanelHeight = num2;
						break;
					}
					case 23:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.allArmiesPanel.initProperties(true, "Armies", this);
						this.allArmiesPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.allArmiesPanel.Size = new Size(this.allArmiesPanel.Size.Width, base.Height);
						this.allArmiesPanel.display(this, (base.Size.Width - this.allArmiesPanel.Size.Width) / 2, 0);
						this.allArmiesPanel.BringToFront();
						this.allArmiesPanel.preInit();
						this.allArmiesPanel.init(false, 0);
						this.currentPanelWidth = this.allArmiesPanel.Size.Width;
						this.currentPanelHeight = this.allArmiesPanel.Size.Height;
						break;
					case 24:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.allVassalsPanel.initProperties(true, "All Vassals", this);
						this.allVassalsPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.allVassalsPanel.Size = new Size(this.allVassalsPanel.Size.Width, base.Height);
						this.allVassalsPanel.display(this, (base.Size.Width - this.allVassalsPanel.Size.Width) / 2, 0);
						this.allVassalsPanel.BringToFront();
						this.allVassalsPanel.init(false);
						this.currentPanelWidth = this.allVassalsPanel.Size.Width;
						this.currentPanelHeight = this.allVassalsPanel.Size.Height;
						break;
					case 25:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.questsPanel.initProperties(true, "Quests", this);
						this.questsPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.questsPanel.Size = new Size(this.questsPanel.Size.Width, base.Height);
						this.questsPanel.display(this, (base.Size.Width - this.questsPanel.Size.Width) / 2, 0);
						this.questsPanel.BringToFront();
						this.questsPanel.init(false);
						this.currentPanelWidth = this.questsPanel.Size.Width;
						this.currentPanelHeight = this.questsPanel.Size.Height;
						break;
					case 26:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.newQuestsPanel.initProperties(true, "New Quests", this);
						this.newQuestsPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.newQuestsPanel.Size = new Size(this.questsPanel.Size.Width, base.Height);
						this.newQuestsPanel.display(this, (base.Size.Width - this.newQuestsPanel.Size.Width) / 2, 0);
						this.newQuestsPanel.BringToFront();
						this.newQuestsPanel.init(false);
						this.currentPanelWidth = this.newQuestsPanel.Size.Width;
						this.currentPanelHeight = this.newQuestsPanel.Size.Height;
						break;
					case 30:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.contestsPanel.initProperties(true, "Events", this);
						this.contestsPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.contestsPanel.Size = new Size(this.contestsPanel.Size.Width, base.Height);
						this.contestsPanel.display(this, (base.Size.Width - this.contestsPanel.Size.Width) / 2, 0);
						this.contestsPanel.BringToFront();
						this.contestsPanel.init(false);
						this.currentPanelWidth = this.contestsPanel.Size.Width;
						this.currentPanelHeight = this.contestsPanel.Size.Height;
						break;
					case 31:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.contestHistoryPanel.initProperties(true, "Events", this);
						this.contestHistoryPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.contestHistoryPanel.Size = new Size(this.contestHistoryPanel.Size.Width, base.Height);
						this.contestHistoryPanel.display(this, (base.Size.Width - this.contestHistoryPanel.Size.Width) / 2, 0);
						this.contestHistoryPanel.BringToFront();
						this.contestHistoryPanel.init(false);
						this.currentPanelWidth = this.contestHistoryPanel.Size.Width;
						this.currentPanelHeight = this.contestHistoryPanel.Size.Height;
						break;
					case 41:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.factionInvitePanel.initProperties(true, "Faction Invites", this);
						this.factionInvitePanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.factionInvitePanel.Size = new Size(this.factionInvitePanel.Size.Width, base.Height);
						this.factionInvitePanel.display(this, (base.Size.Width - this.factionInvitePanel.Size.Width) / 2, 0);
						this.factionInvitePanel.BringToFront();
						this.factionInvitePanel.init(false);
						this.currentPanelWidth = this.factionInvitePanel.Size.Width;
						this.currentPanelHeight = this.factionInvitePanel.Size.Height;
						break;
					case 42:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.factionMyFactionPanel.initProperties(true, "Faction my Faction", this);
						this.factionMyFactionPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.factionMyFactionPanel.Size = new Size(this.factionMyFactionPanel.Size.Width, base.Height);
						this.factionMyFactionPanel.display(this, (base.Size.Width - this.factionMyFactionPanel.Size.Width) / 2, 0);
						this.factionMyFactionPanel.BringToFront();
						this.factionMyFactionPanel.init(false);
						this.currentPanelWidth = this.factionMyFactionPanel.Size.Width;
						this.currentPanelHeight = this.factionMyFactionPanel.Size.Height;
						break;
					case 43:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.factionAllFactionsPanel.initProperties(true, "Faction All Factions", this);
						this.factionAllFactionsPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.factionAllFactionsPanel.Size = new Size(this.factionAllFactionsPanel.Size.Width, base.Height);
						this.factionAllFactionsPanel.display(this, (base.Size.Width - this.factionAllFactionsPanel.Size.Width) / 2, 0);
						this.factionAllFactionsPanel.BringToFront();
						this.factionAllFactionsPanel.init(false);
						this.currentPanelWidth = this.factionAllFactionsPanel.Size.Width;
						this.currentPanelHeight = this.factionAllFactionsPanel.Size.Height;
						break;
					case 44:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.factionDiplomacyPanel.initProperties(true, "Faction Diplomacy", this);
						this.factionDiplomacyPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.factionDiplomacyPanel.Size = new Size(this.factionDiplomacyPanel.Size.Width, base.Height);
						this.factionDiplomacyPanel.display(this, (base.Size.Width - this.factionDiplomacyPanel.Size.Width) / 2, 0);
						this.factionDiplomacyPanel.BringToFront();
						this.factionDiplomacyPanel.init(false);
						this.currentPanelWidth = this.factionDiplomacyPanel.Size.Width;
						this.currentPanelHeight = this.factionDiplomacyPanel.Size.Height;
						break;
					case 45:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.factionNewForumPanel.initProperties(true, "Faction Forum", this);
						this.factionNewForumPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.factionNewForumPanel.Size = new Size(this.factionNewForumPanel.Size.Width, base.Height);
						this.factionNewForumPanel.display(this, (base.Size.Width - this.factionNewForumPanel.Size.Width) / 2, 0);
						this.factionNewForumPanel.BringToFront();
						this.factionNewForumPanel.init(false);
						this.currentPanelWidth = this.factionNewForumPanel.Size.Width;
						this.currentPanelHeight = this.factionNewForumPanel.Size.Height;
						break;
					case 46:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.factionOfficersPanel.initProperties(true, "Faction Officers", this);
						this.factionOfficersPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.factionOfficersPanel.Size = new Size(this.factionOfficersPanel.Size.Width, base.Height);
						this.factionOfficersPanel.display(this, (base.Size.Width - this.factionOfficersPanel.Size.Width) / 2, 0);
						this.factionOfficersPanel.BringToFront();
						this.factionOfficersPanel.init(false);
						this.currentPanelWidth = this.factionOfficersPanel.Size.Width;
						this.currentPanelHeight = this.factionOfficersPanel.Size.Height;
						break;
					case 47:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.factionStartFactionPanel.initProperties(true, "Faction Start Faction", this);
						this.factionStartFactionPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.factionStartFactionPanel.Size = new Size(this.factionStartFactionPanel.Size.Width, base.Height);
						this.factionStartFactionPanel.display(this, (base.Size.Width - this.factionStartFactionPanel.Size.Width) / 2, 0);
						this.factionStartFactionPanel.BringToFront();
						this.factionStartFactionPanel.init(false);
						this.currentPanelWidth = this.factionStartFactionPanel.Size.Width;
						this.currentPanelHeight = this.factionStartFactionPanel.Size.Height;
						break;
					case 48:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.factionNewForumPostsPanel.initProperties(true, "Faction All Factions", this);
						this.factionNewForumPostsPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.factionNewForumPostsPanel.Size = new Size(this.factionNewForumPostsPanel.Size.Width, base.Height);
						this.factionNewForumPostsPanel.display(this, (base.Size.Width - this.factionNewForumPostsPanel.Size.Width) / 2, 0);
						this.factionNewForumPostsPanel.BringToFront();
						this.factionNewForumPostsPanel.init(false);
						this.currentPanelWidth = this.factionNewForumPostsPanel.Size.Width;
						this.currentPanelHeight = this.factionNewForumPostsPanel.Size.Height;
						break;
					case 51:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.houseListPanel.initProperties(true, "House list panel", this);
						this.houseListPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.houseListPanel.Size = new Size(this.houseListPanel.Size.Width, base.Height);
						this.houseListPanel.display(this, (base.Size.Width - this.houseListPanel.Size.Width) / 2, 0);
						this.houseListPanel.BringToFront();
						this.houseListPanel.init(false);
						this.currentPanelWidth = this.houseListPanel.Size.Width;
						this.currentPanelHeight = this.houseListPanel.Size.Height;
						break;
					case 52:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.houseInfoPanel.initProperties(true, "House info panel", this);
						this.houseInfoPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.houseInfoPanel.Size = new Size(this.houseInfoPanel.Size.Width, base.Height);
						this.houseInfoPanel.display(this, (base.Size.Width - this.houseInfoPanel.Size.Width) / 2, 0);
						this.houseInfoPanel.BringToFront();
						this.houseInfoPanel.Refresh();
						this.currentPanelWidth = this.houseInfoPanel.Size.Width;
						this.currentPanelHeight = this.houseInfoPanel.Size.Height;
						break;
					case 60:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.userDiplomacyPanel.initProperties(true, "User Diplomacy", this);
						this.userDiplomacyPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.userDiplomacyPanel.Size = new Size(this.userDiplomacyPanel.Size.Width, base.Height);
						this.userDiplomacyPanel.display(this, (base.Size.Width - this.userDiplomacyPanel.Size.Width) / 2, 0);
						this.userDiplomacyPanel.BringToFront();
						this.userDiplomacyPanel.init(false);
						this.currentPanelWidth = this.userDiplomacyPanel.Size.Width;
						this.currentPanelHeight = this.userDiplomacyPanel.Size.Height;
						break;
					case 65:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.endOfWorldPanel.initProperties(true, "end of the  panel", this);
						this.endOfWorldPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.endOfWorldPanel.display(this, (base.Size.Width - this.endOfWorldPanel.Size.Width) / 2, (base.Size.Height - this.endOfWorldPanel.Size.Height) / 2);
						this.endOfWorldPanel.BringToFront();
						this.endOfWorldPanel.init(false);
						this.currentPanelWidth = this.endOfWorldPanel.Size.Width;
						this.currentPanelHeight = this.endOfWorldPanel.Size.Height;
						break;
					default:
						if (panelID == 99)
						{
							this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
							this.userInfoScreen.initProperties(true, "User Info", this);
							this.userInfoScreen.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
							this.userInfoScreen.display(this, (base.Size.Width - this.userInfoScreen.Size.Width) / 2, (base.Size.Height - this.userInfoScreen.Size.Height) / 2);
							this.userInfoScreen.BringToFront();
							this.currentPanelWidth = this.userInfoScreen.Size.Width;
							this.currentPanelHeight = this.userInfoScreen.Size.Height;
						}
						break;
					}
				}
				else if (panelID != 100)
				{
					switch (panelID)
					{
					case 1003:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.capitalTradePanel.initProperties(true, "Capital Trade", this);
						this.capitalTradePanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.capitalTradePanel.display(this, (base.Size.Width - this.capitalTradePanel.Size.Width) / 2, (base.Size.Height - this.capitalTradePanel.Size.Height) / 2);
						this.capitalTradePanel.BringToFront();
						this.capitalTradePanel.selectStockExchange(-1);
						this.capitalTradePanel.init();
						this.currentPanelWidth = this.capitalTradePanel.Size.Width;
						this.currentPanelHeight = this.capitalTradePanel.Size.Height;
						InterfaceMgr.Instance.updateVillageInfoBar();
						break;
					case 1004:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.capitalBarracksPanel.initProperties(true, "Mercenaries", this);
						this.capitalBarracksPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.capitalBarracksPanel.display(this, (base.Size.Width - this.capitalBarracksPanel.Size.Width) / 2, (base.Size.Height - this.capitalBarracksPanel.Size.Height) / 2);
						this.capitalBarracksPanel.BringToFront();
						this.capitalBarracksPanel.init();
						this.currentPanelWidth = this.capitalBarracksPanel.Size.Width;
						this.currentPanelHeight = this.capitalBarracksPanel.Size.Height;
						break;
					case 1005:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.capitalResourcesPanel.initProperties(true, "Resources", this);
						this.capitalResourcesPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.capitalResourcesPanel.display(this, (base.Size.Width - this.capitalResourcesPanel.Size.Width) / 2, (base.Size.Height - this.capitalResourcesPanel.Size.Height) / 2);
						this.capitalResourcesPanel.BringToFront();
						this.capitalResourcesPanel.init();
						this.currentPanelWidth = this.capitalResourcesPanel.Size.Width;
						this.currentPanelHeight = this.capitalResourcesPanel.Size.Height;
						break;
					case 1006:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.parishPanel.initProperties(true, "Parish Vote", this);
						this.parishPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.parishPanel.Size = new Size(this.parishPanel.Size.Width, base.Height);
						this.parishPanel.display(this, (base.Size.Width - this.parishPanel.Size.Width) / 2, 0);
						this.parishPanel.BringToFront();
						this.parishPanel.init(false);
						this.currentPanelWidth = this.parishPanel.Size.Width;
						this.currentPanelHeight = base.Height;
						break;
					case 1007:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.parishForumPanel.initProperties(true, "Parish Forum", this);
						this.parishForumPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.parishForumPanel.Size = new Size(this.parishForumPanel.Size.Width, base.Height);
						this.parishForumPanel.display(this, (base.Size.Width - this.parishForumPanel.Size.Width) / 2, 0);
						this.parishForumPanel.BringToFront();
						this.parishForumPanel.setArea(GameEngine.Instance.World.getParishFromVillageID(InterfaceMgr.Instance.getSelectedMenuVillage()), 3);
						this.parishForumPanel.init(false);
						this.currentPanelWidth = this.parishForumPanel.Size.Width;
						this.currentPanelHeight = this.parishForumPanel.Size.Height;
						break;
					case 1008:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.parishFrontPagePanel.initProperties(true, "Parish Info", this);
						this.parishFrontPagePanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.parishFrontPagePanel.Size = new Size(this.parishFrontPagePanel.Size.Width, base.Height);
						this.parishFrontPagePanel.display(this, (base.Size.Width - this.parishFrontPagePanel.Size.Width) / 2, 0);
						this.parishFrontPagePanel.BringToFront();
						this.parishFrontPagePanel.init(false);
						this.currentPanelWidth = this.parishFrontPagePanel.Size.Width;
						this.currentPanelHeight = base.Height;
						break;
					case 1009:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.capitalForumPostsPanel.initProperties(true, "Forum Post Info", this);
						this.capitalForumPostsPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.capitalForumPostsPanel.Size = new Size(this.capitalForumPostsPanel.Size.Width, base.Height);
						this.capitalForumPostsPanel.display(this, (base.Size.Width - this.capitalForumPostsPanel.Size.Width) / 2, 0);
						this.capitalForumPostsPanel.BringToFront();
						this.capitalForumPostsPanel.init(false);
						this.currentPanelWidth = this.capitalForumPostsPanel.Size.Width;
						this.currentPanelHeight = base.Height;
						break;
					}
				}
				else
				{
					this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
					this.allVillagesPanel.initProperties(true, "All Villages", this);
					this.allVillagesPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
					this.allVillagesPanel.Size = new Size(this.allVillagesPanel.Size.Width, base.Height);
					this.allVillagesPanel.display(this, (base.Size.Width - this.allVillagesPanel.Size.Width) / 2, 0);
					this.allVillagesPanel.BringToFront();
					this.allVillagesPanel.init(false);
					this.currentPanelWidth = this.allVillagesPanel.Size.Width;
					this.currentPanelHeight = this.allVillagesPanel.Size.Height;
				}
			}
			else if (panelID <= 1108)
			{
				if (panelID != 1021)
				{
					switch (panelID)
					{
					case 1106:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.countyPanel.initProperties(true, "County Vote", this);
						this.countyPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.countyPanel.Size = new Size(this.countyPanel.Size.Width, base.Height);
						this.countyPanel.display(this, (base.Size.Width - this.countyPanel.Size.Width) / 2, 0);
						this.countyPanel.BringToFront();
						this.countyPanel.init(false);
						this.currentPanelWidth = this.countyPanel.Size.Width;
						this.currentPanelHeight = base.Height;
						break;
					case 1107:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.parishForumPanel.initProperties(true, "County Forum", this);
						this.parishForumPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.parishForumPanel.Size = new Size(this.parishForumPanel.Size.Width, base.Height);
						this.parishForumPanel.display(this, (base.Size.Width - this.parishForumPanel.Size.Width) / 2, 0);
						this.parishForumPanel.BringToFront();
						this.parishForumPanel.setArea(GameEngine.Instance.World.getCountyFromVillageID(InterfaceMgr.Instance.getSelectedMenuVillage()), 2);
						this.parishForumPanel.init(false);
						this.currentPanelWidth = this.parishForumPanel.Size.Width;
						this.currentPanelHeight = this.parishForumPanel.Size.Height;
						break;
					case 1108:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.countyFrontPagePanel.initProperties(true, "County Info", this);
						this.countyFrontPagePanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.countyFrontPagePanel.display(this, (base.Size.Width - this.countyFrontPagePanel.Size.Width) / 2, (base.Size.Height - this.countyFrontPagePanel.Size.Height) / 2);
						this.countyFrontPagePanel.BringToFront();
						this.countyFrontPagePanel.init();
						this.currentPanelWidth = this.countyFrontPagePanel.Size.Width;
						this.currentPanelHeight = this.countyFrontPagePanel.Size.Height;
						break;
					}
				}
				else
				{
					this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
					this.capitalDonateResourcesPanel.initProperties(true, "Parish Donate Resources", this);
					this.capitalDonateResourcesPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
					this.capitalDonateResourcesPanel.display(this, (base.Size.Width - this.capitalDonateResourcesPanel.Size.Width) / 2, (base.Size.Height - this.capitalDonateResourcesPanel.Size.Height) / 2);
					this.capitalDonateResourcesPanel.BringToFront();
					this.capitalDonateResourcesPanel.init();
					this.currentPanelWidth = this.capitalDonateResourcesPanel.Size.Width;
					this.currentPanelHeight = this.capitalDonateResourcesPanel.Size.Height;
				}
			}
			else
			{
				switch (panelID)
				{
				case 1206:
					this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
					this.provincePanel.initProperties(true, "Province Vote", this);
					this.provincePanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
					this.provincePanel.Size = new Size(this.countyPanel.Size.Width, base.Height);
					this.provincePanel.display(this, (base.Size.Width - this.provincePanel.Size.Width) / 2, 0);
					this.provincePanel.BringToFront();
					this.provincePanel.init(false);
					this.currentPanelWidth = this.provincePanel.Size.Width;
					this.currentPanelHeight = base.Height;
					break;
				case 1207:
					this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
					this.parishForumPanel.initProperties(true, "Province Forum", this);
					this.parishForumPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
					this.parishForumPanel.Size = new Size(this.parishForumPanel.Size.Width, base.Height);
					this.parishForumPanel.display(this, (base.Size.Width - this.parishForumPanel.Size.Width) / 2, 0);
					this.parishForumPanel.BringToFront();
					this.parishForumPanel.setArea(GameEngine.Instance.World.getProvinceFromVillageID(InterfaceMgr.Instance.getSelectedMenuVillage()), 1);
					this.parishForumPanel.init(false);
					this.currentPanelWidth = this.parishForumPanel.Size.Width;
					this.currentPanelHeight = this.parishForumPanel.Size.Height;
					break;
				case 1208:
					this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
					this.provinceFrontPagePanel.initProperties(true, "Province Info", this);
					this.provinceFrontPagePanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
					this.provinceFrontPagePanel.display(this, (base.Size.Width - this.provinceFrontPagePanel.Size.Width) / 2, (base.Size.Height - this.provinceFrontPagePanel.Size.Height) / 2);
					this.provinceFrontPagePanel.BringToFront();
					this.provinceFrontPagePanel.init();
					this.currentPanelWidth = this.provinceFrontPagePanel.Size.Width;
					this.currentPanelHeight = this.provinceFrontPagePanel.Size.Height;
					break;
				default:
					switch (panelID)
					{
					case 1306:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.countryPanel.initProperties(true, "Country Vote", this);
						this.countryPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.countryPanel.Size = new Size(this.countyPanel.Size.Width, base.Height);
						this.countryPanel.display(this, (base.Size.Width - this.countryPanel.Size.Width) / 2, 0);
						this.countryPanel.BringToFront();
						this.countryPanel.init(false);
						this.currentPanelWidth = this.countryPanel.Size.Width;
						this.currentPanelHeight = base.Height;
						break;
					case 1307:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.parishForumPanel.initProperties(true, "Country Forum", this);
						this.parishForumPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.parishForumPanel.Size = new Size(this.parishForumPanel.Size.Width, base.Height);
						this.parishForumPanel.display(this, (base.Size.Width - this.parishForumPanel.Size.Width) / 2, 0);
						this.parishForumPanel.BringToFront();
						this.parishForumPanel.setArea(GameEngine.Instance.World.getCountryFromVillageID(InterfaceMgr.Instance.getSelectedMenuVillage()), 0);
						this.parishForumPanel.init(false);
						this.currentPanelWidth = this.parishForumPanel.Size.Width;
						this.currentPanelHeight = this.parishForumPanel.Size.Height;
						break;
					case 1308:
						this.setBackgroundImage(GFXLibrary.int_banquette_background_tile);
						this.countryFrontPagePanel.initProperties(true, "Country Info", this);
						this.countryFrontPagePanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
						this.countryFrontPagePanel.display(this, (base.Size.Width - this.countryFrontPagePanel.Size.Width) / 2, (base.Size.Height - this.countryFrontPagePanel.Size.Height) / 2);
						this.countryFrontPagePanel.BringToFront();
						this.countryFrontPagePanel.init();
						this.currentPanelWidth = this.countryFrontPagePanel.Size.Width;
						this.currentPanelHeight = this.countryFrontPagePanel.Size.Height;
						break;
					}
					break;
				}
			}
			this.currentPanelWidth -= 168;
			this.currentPanelHeight -= 168;
			this.forceBackgroundRedraw = true;
			this.OnPaint(null);
		}

		// Token: 0x06002FA5 RID: 12197 RVA: 0x002733E0 File Offset: 0x002715E0
		public void update(int panelID)
		{
			if (panelID <= 1009)
			{
				if (panelID <= 99)
				{
					switch (panelID)
					{
					case 1:
						this.holdBanquetPanel.update();
						return;
					case 2:
						this.marketTransferPanel.update();
						return;
					case 3:
						this.stockExchangePanel.update();
						return;
					case 4:
						this.barracksPanel.update();
						return;
					case 5:
						this.resourcesPanel.update();
						return;
					case 6:
						this.villageReinforcementsPanel.update();
						return;
					case 7:
						this.villageArmiesPanel.update();
						return;
					case 8:
						this.vassalControlPanel.update();
						return;
					case 9:
					case 14:
					case 16:
					case 27:
					case 28:
					case 29:
					case 31:
					case 32:
					case 33:
					case 34:
					case 35:
					case 36:
					case 37:
					case 38:
					case 39:
					case 40:
					case 49:
					case 50:
					case 53:
					case 54:
					case 55:
					case 56:
					case 57:
					case 58:
					case 59:
					case 61:
					case 62:
					case 63:
					case 64:
						return;
					case 10:
						this.avatarEditorPanel.update();
						return;
					case 11:
					case 12:
					case 13:
						this.unknownPanel.update();
						return;
					case 15:
						this.vassalArmiesPanel.update();
						return;
					case 17:
						this.capitalSendTroopsPanel.update();
						return;
					case 18:
						this.unitsPanel.update();
						return;
					case 19:
						this.rankingsPanel.update();
						return;
					case 20:
						this.statsPanel.update();
						return;
					case 21:
						this.reportsPanel.update();
						return;
					case 22:
						this.gloryPanel.update();
						return;
					case 23:
						this.allArmiesPanel.update();
						return;
					case 24:
						this.allVassalsPanel.update();
						return;
					case 25:
						this.questsPanel.update();
						return;
					case 26:
						this.newQuestsPanel.update();
						return;
					case 30:
						this.contestsPanel.update();
						return;
					case 41:
						this.factionInvitePanel.update();
						return;
					case 42:
						this.factionMyFactionPanel.update();
						return;
					case 43:
						this.factionAllFactionsPanel.update();
						return;
					case 44:
						this.factionDiplomacyPanel.update();
						return;
					case 45:
						this.factionNewForumPanel.update();
						return;
					case 46:
						this.factionOfficersPanel.update();
						return;
					case 47:
						this.factionStartFactionPanel.update();
						return;
					case 48:
						this.factionNewForumPostsPanel.update();
						return;
					case 51:
						this.houseListPanel.update();
						return;
					case 52:
						this.houseInfoPanel.update();
						return;
					case 60:
						this.userDiplomacyPanel.update();
						return;
					case 65:
						this.endOfWorldPanel.update();
						return;
					default:
						if (panelID != 99)
						{
							return;
						}
						this.userInfoScreen.update();
						return;
					}
				}
				else
				{
					if (panelID == 100)
					{
						this.allVillagesPanel.update();
						return;
					}
					switch (panelID)
					{
					case 1003:
						this.capitalTradePanel.update();
						return;
					case 1004:
						this.capitalBarracksPanel.update();
						return;
					case 1005:
						this.capitalResourcesPanel.update();
						return;
					case 1006:
						this.parishPanel.update();
						return;
					case 1007:
						break;
					case 1008:
						this.parishFrontPagePanel.update();
						return;
					case 1009:
						this.capitalForumPostsPanel.update();
						return;
					default:
						return;
					}
				}
			}
			else if (panelID <= 1108)
			{
				if (panelID == 1021)
				{
					this.capitalDonateResourcesPanel.update();
					return;
				}
				switch (panelID)
				{
				case 1106:
					this.countyPanel.update();
					return;
				case 1107:
					break;
				case 1108:
					this.countyFrontPagePanel.update();
					return;
				default:
					return;
				}
			}
			else
			{
				switch (panelID)
				{
				case 1206:
					this.provincePanel.update();
					return;
				case 1207:
					break;
				case 1208:
					this.provinceFrontPagePanel.update();
					return;
				default:
					switch (panelID)
					{
					case 1306:
						this.countryPanel.update();
						return;
					case 1307:
						break;
					case 1308:
						this.countryFrontPagePanel.update();
						return;
					default:
						return;
					}
					break;
				}
			}
			this.parishForumPanel.update();
		}

		// Token: 0x06002FA6 RID: 12198 RVA: 0x00022937 File Offset: 0x00020B37
		public bool isTab0OverLayActive()
		{
			return this.capitalDonateResourcesPanel.isVisible();
		}

		// Token: 0x06002FA7 RID: 12199 RVA: 0x002737FC File Offset: 0x002719FC
		public void newVillageLoaded()
		{
			bool flag = true;
			if (this.lastPanelType == 6 || this.lastPanelType == 10)
			{
				flag = false;
			}
			if (flag)
			{
				if (this.lastPanelType < 1000)
				{
					if (this.lastPanelType >= 0 && InterfaceMgr.Instance.isSelectedVillageACapital())
					{
						switch (this.lastPanelType)
						{
						case 2:
						case 3:
							InterfaceMgr.Instance.setVillageTabSubMode(1003);
							return;
						case 4:
							InterfaceMgr.Instance.setVillageTabSubMode(1004);
							return;
						case 5:
							InterfaceMgr.Instance.setVillageTabSubMode(1005);
							return;
						case 9:
							InterfaceMgr.Instance.setVillageTabSubMode(1009);
							return;
						}
						InterfaceMgr.Instance.getVillageTabBar().changeTab(6);
						return;
					}
				}
				else if (!InterfaceMgr.Instance.isSelectedVillageACapital())
				{
					switch (this.lastPanelType)
					{
					case 1002:
					case 1003:
						InterfaceMgr.Instance.setVillageTabSubMode(3);
						return;
					case 1004:
						InterfaceMgr.Instance.setVillageTabSubMode(4);
						return;
					case 1005:
						InterfaceMgr.Instance.setVillageTabSubMode(5);
						return;
					default:
						InterfaceMgr.Instance.getVillageTabBar().changeTab(9);
						InterfaceMgr.Instance.getVillageTabBar().changeTab(0);
						return;
					}
				}
			}
			int num = this.lastPanelType;
			if (num <= 1021)
			{
				switch (num)
				{
				case 1:
					this.holdBanquetPanel.init();
					return;
				case 2:
					this.marketTransferPanel.backupData();
					this.marketTransferPanel.resume(this.marketTransferPanel.SelectedTargetVillage, true);
					return;
				case 3:
				case 5:
				case 9:
				case 10:
				case 14:
				case 16:
					break;
				case 4:
					this.barracksPanel.init();
					return;
				case 6:
					this.villageReinforcementsPanel.resume();
					this.villageReinforcementsPanel.init(true);
					return;
				case 7:
					this.villageArmiesPanel.init(false);
					return;
				case 8:
					this.vassalControlPanel.reinit();
					return;
				case 11:
				case 12:
				case 13:
					this.unknownPanel.init();
					return;
				case 15:
					this.vassalArmiesPanel.init(false);
					return;
				case 17:
					this.capitalSendTroopsPanel.init(true);
					return;
				case 18:
					this.unitsPanel.init();
					return;
				default:
					switch (num)
					{
					case 1003:
						this.capitalTradePanel.selectStockExchange(-1);
						this.capitalTradePanel.init();
						return;
					case 1004:
					case 1005:
						break;
					case 1006:
						InterfaceMgr.Instance.getVillageTabBar().forceChangeTab(6);
						return;
					case 1007:
						InterfaceMgr.Instance.getVillageTabBar().forceChangeTab(7);
						return;
					case 1008:
						if (this.lastVillageVisited != InterfaceMgr.Instance.getSelectedMenuVillage())
						{
							InterfaceMgr.Instance.getVillageTabBar().forceChangeTab(5);
							return;
						}
						this.parishFrontPagePanel.init(false);
						return;
					case 1009:
						InterfaceMgr.Instance.getVillageTabBar().forceChangeTab(7);
						return;
					default:
						if (num != 1021)
						{
							return;
						}
						InterfaceMgr.Instance.getVillageTabBar().forceChangeTab(0);
						return;
					}
					break;
				}
			}
			else
			{
				switch (num)
				{
				case 1106:
					break;
				case 1107:
					goto IL_35B;
				case 1108:
					goto IL_36C;
				default:
					switch (num)
					{
					case 1206:
						break;
					case 1207:
						goto IL_35B;
					case 1208:
						goto IL_36C;
					default:
						switch (num)
						{
						case 1306:
							break;
						case 1307:
							goto IL_35B;
						case 1308:
							goto IL_36C;
						default:
							return;
						}
						break;
					}
					break;
				}
				InterfaceMgr.Instance.getVillageTabBar().forceChangeTab(6);
				return;
				IL_35B:
				InterfaceMgr.Instance.getVillageTabBar().forceChangeTab(7);
				return;
				IL_36C:
				InterfaceMgr.Instance.getVillageTabBar().forceChangeTab(5);
			}
		}

		// Token: 0x06002FA8 RID: 12200 RVA: 0x00273B88 File Offset: 0x00271D88
		public void closeSubControls()
		{
			this.holdBanquetPanel.closeControl(true);
			this.marketTransferPanel.closeControl(true);
			this.stockExchangePanel.closeControl(true);
			this.barracksPanel.closeControl(true);
			this.resourcesPanel.closeControl(true);
			this.villageReinforcementsPanel.closeControl(true);
			this.villageArmiesPanel.closeControl(true);
			this.vassalControlPanel.closeControl(true);
			this.avatarEditorPanel.closeControl(true);
			this.rankingsPanel.closeControl(true);
			this.userInfoScreen.closeControl(true);
			this.gloryPanel.closeControl(true);
			this.statsPanel.closeControl(true);
			this.contestsPanel.closeControl(true);
			this.contestHistoryPanel.closeControl(true);
			this.reportsPanel.closeControl(true);
			this.unknownPanel.closeControl(true);
			this.vassalArmiesPanel.closeControl(true);
			this.capitalSendTroopsPanel.closeControl(true);
			this.unitsPanel.closeControl(true);
			this.allArmiesPanel.closeControl(true);
			this.allVassalsPanel.closeControl(true);
			this.questsPanel.closeControl(true);
			this.newQuestsPanel.closeControl(true);
			this.factionInvitePanel.closeControl(true);
			this.factionMyFactionPanel.closeControl(true);
			this.factionStartFactionPanel.closeControl(true);
			this.factionAllFactionsPanel.closeControl(true);
			this.factionNewForumPostsPanel.closeControl(true);
			this.factionOfficersPanel.closeControl(true);
			this.factionDiplomacyPanel.closeControl(true);
			this.factionNewForumPanel.closeControl(true);
			this.houseInfoPanel.closeControl(true);
			this.houseListPanel.closeControl(true);
			this.endOfWorldPanel.closeControl(true);
			this.allVillagesPanel.closeControl(true);
			this.userDiplomacyPanel.closeControl(true);
			this.capitalResourcesPanel.closeControl(true);
			this.capitalTradePanel.closeControl(true);
			this.capitalBarracksPanel.closeControl(true);
			this.parishPanel.closeControl(true);
			this.parishForumPanel.closeControl(true);
			this.parishFrontPagePanel.closeControl(true);
			this.capitalForumPostsPanel.closeControl(true);
			this.countyPanel.closeControl(true);
			this.countyFrontPagePanel.closeControl(true);
			this.provincePanel.closeControl(true);
			this.provinceFrontPagePanel.closeControl(true);
			this.countryPanel.closeControl(true);
			this.countryFrontPagePanel.closeControl(true);
			this.capitalDonateResourcesPanel.closeControl(true);
		}

		// Token: 0x06002FA9 RID: 12201 RVA: 0x00273DFC File Offset: 0x00271FFC
		public void logout()
		{
			this.parishPanel.logout();
			this.parishFrontPagePanel.logout();
			this.countyPanel.logout();
			this.countyFrontPagePanel.logout();
			this.provincePanel.logout();
			this.provinceFrontPagePanel.logout();
			this.countryPanel.logout();
			this.countryFrontPagePanel.logout();
			this.marketTransferPanel.logout();
			this.stockExchangePanel.logout();
			this.factionNewForumPanel.clearForum();
			this.factionNewForumPostsPanel.logout();
			this.parishForumPanel.clearForum();
			this.capitalForumPostsPanel.logout();
			this.houseInfoPanel.logout();
			this.factionAllFactionsPanel.logout();
			this.allVillagesPanel.logout();
			this.houseListPanel.logout();
			this.rankingsPanel.logout();
			this.contestsPanel.logout();
			this.contestHistoryPanel.logout();
		}

		// Token: 0x06002FAA RID: 12202 RVA: 0x00022949 File Offset: 0x00020B49
		public void tradeWithResume(int villageID, bool keepInfo)
		{
			this.marketTransferPanel.resume(villageID, keepInfo);
		}

		// Token: 0x06002FAB RID: 12203 RVA: 0x00022958 File Offset: 0x00020B58
		public void selectExchange(int villageID)
		{
			this.stockExchangePanel.selectStockExchange(villageID);
		}

		// Token: 0x06002FAC RID: 12204 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void selectAttackTarget(int villageID)
		{
		}

		// Token: 0x06002FAD RID: 12205 RVA: 0x00022966 File Offset: 0x00020B66
		public void selectVassalVillage(int villageID)
		{
			this.vassalControlPanel.setVassalVillage(villageID);
		}

		// Token: 0x06002FAE RID: 12206 RVA: 0x00022974 File Offset: 0x00020B74
		public void setVassalArmiesVillage(int villageID)
		{
			this.vassalArmiesPanel.setVassalArmiesVillage(villageID);
		}

		// Token: 0x06002FAF RID: 12207 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void setVassalTargetVillage(int villageID, int targetVillage)
		{
		}

		// Token: 0x06002FB0 RID: 12208 RVA: 0x00022982 File Offset: 0x00020B82
		public void setCapitalSendTargetVillage(int villageID)
		{
			this.capitalSendTroopsPanel.setTargetVillage(villageID);
		}

		// Token: 0x06002FB1 RID: 12209 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void selectScoutsTarget(int villageID)
		{
		}

		// Token: 0x06002FB2 RID: 12210 RVA: 0x00022990 File Offset: 0x00020B90
		public void setReinforcementVillage(int villageID)
		{
			this.villageReinforcementsPanel.setReinforcementVillage(villageID);
		}

		// Token: 0x06002FB3 RID: 12211 RVA: 0x0002299E File Offset: 0x00020B9E
		public void flushParishFrontPageInfo(int parishID)
		{
			this.parishFrontPagePanel.flushData(parishID);
		}

		// Token: 0x06002FB4 RID: 12212 RVA: 0x000229AC File Offset: 0x00020BAC
		public void capitalDonateResourcesInit(int villageID, VillageMapBuilding selectedBuilding)
		{
			this.capitalDonateResourcesPanel.init(villageID, selectedBuilding);
		}

		// Token: 0x06002FB5 RID: 12213 RVA: 0x00273EF0 File Offset: 0x002720F0
		public void screenResize()
		{
			this.holdBanquetPanel.Location = new Point((base.Size.Width - this.holdBanquetPanel.Size.Width) / 2, (base.Size.Height - this.holdBanquetPanel.Size.Height) / 2);
			this.marketTransferPanel.Location = new Point((base.Size.Width - this.marketTransferPanel.Size.Width) / 2, (base.Size.Height - this.marketTransferPanel.Size.Height) / 2);
			this.stockExchangePanel.Location = new Point((base.Size.Width - this.stockExchangePanel.Size.Width) / 2, (base.Size.Height - this.stockExchangePanel.Size.Height) / 2);
			this.barracksPanel.Location = new Point((base.Size.Width - this.barracksPanel.Size.Width) / 2, (base.Size.Height - this.barracksPanel.Size.Height) / 2);
			this.unitsPanel.Location = new Point((base.Size.Width - this.barracksPanel.Size.Width) / 2, (base.Size.Height - this.unitsPanel.Size.Height) / 2);
			this.resourcesPanel.Location = new Point((base.Size.Width - this.resourcesPanel.Size.Width) / 2, (base.Size.Height - this.resourcesPanel.Size.Height) / 2);
			this.avatarEditorPanel.Location = new Point((base.Size.Width - this.avatarEditorPanel.Size.Width) / 2, (base.Size.Height - this.avatarEditorPanel.Size.Height) / 2);
			this.rankingsPanel.Location = new Point((base.Size.Width - this.rankingsPanel.Size.Width) / 2, (base.Size.Height - this.rankingsPanel.Size.Height) / 2);
			this.userInfoScreen.Location = new Point((base.Size.Width - this.userInfoScreen.Size.Width) / 2, (base.Size.Height - this.userInfoScreen.Size.Height) / 2);
			this.unknownPanel.Location = new Point((base.Size.Width - this.unknownPanel.Size.Width) / 2, (base.Size.Height - this.unknownPanel.Size.Height) / 2);
			this.vassalArmiesPanel.Location = new Point((base.Size.Width - this.vassalArmiesPanel.Size.Width) / 2, (base.Size.Height - this.vassalArmiesPanel.Size.Height) / 2);
			this.villageReinforcementsPanel.Location = new Point((base.Size.Width - this.villageReinforcementsPanel.Size.Width) / 2, 0);
			if (this.lastPanelType == 6)
			{
				this.currentPanelHeight = base.Height;
				this.villageReinforcementsPanel.init(true);
				this.villageReinforcementsPanel.Invalidate();
			}
			this.capitalResourcesPanel.Location = new Point((base.Size.Width - this.capitalResourcesPanel.Size.Width) / 2, (base.Size.Height - this.capitalResourcesPanel.Size.Height) / 2);
			this.capitalTradePanel.Location = new Point((base.Size.Width - this.capitalTradePanel.Size.Width) / 2, (base.Size.Height - this.capitalTradePanel.Size.Height) / 2);
			this.capitalBarracksPanel.Location = new Point((base.Size.Width - this.capitalBarracksPanel.Size.Width) / 2, (base.Size.Height - this.capitalBarracksPanel.Size.Height) / 2);
			this.parishPanel.Location = new Point((base.Size.Width - this.parishPanel.Size.Width) / 2, 0);
			this.parishPanel.Size = new Size(992, base.Height);
			if (this.lastPanelType == 1006)
			{
				this.currentPanelHeight = base.Height;
				this.parishPanel.init(true);
				this.parishPanel.Invalidate();
			}
			this.parishForumPanel.Location = new Point((base.Size.Width - this.parishForumPanel.Size.Width) / 2, 0);
			this.parishForumPanel.Size = new Size(992, base.Height);
			if (this.lastPanelType == 1007 || this.lastPanelType == 1107 || this.lastPanelType == 1207 || this.lastPanelType == 1307)
			{
				this.currentPanelHeight = base.Height;
				this.parishForumPanel.init(true);
				this.parishForumPanel.Invalidate();
			}
			this.parishFrontPagePanel.Location = new Point((base.Size.Width - this.parishFrontPagePanel.Size.Width) / 2, 0);
			this.parishFrontPagePanel.Size = new Size(992, base.Height);
			if (this.lastPanelType == 1008)
			{
				this.currentPanelHeight = base.Height;
				this.parishFrontPagePanel.init(true);
				this.parishFrontPagePanel.Invalidate();
			}
			this.capitalForumPostsPanel.Location = new Point((base.Size.Width - this.capitalForumPostsPanel.Size.Width) / 2, 0);
			this.capitalForumPostsPanel.Size = new Size(992, base.Height);
			if (this.lastPanelType == 1009)
			{
				this.currentPanelHeight = base.Height;
				this.capitalForumPostsPanel.init(true);
				this.capitalForumPostsPanel.Invalidate();
			}
			this.statsPanel.Location = new Point((base.Size.Width - this.statsPanel.Size.Width) / 2, 0);
			this.statsPanel.Size = new Size(this.statsPanel.Width, base.Height);
			if (this.lastPanelType == 20)
			{
				this.currentPanelHeight = base.Height;
				this.statsPanel.init(true);
				this.statsPanel.Invalidate();
			}
			this.contestsPanel.Location = new Point((base.Size.Width - this.contestsPanel.Size.Width) / 2, 0);
			this.contestsPanel.Size = new Size(this.contestsPanel.Width, base.Height);
			if (this.lastPanelType == 30)
			{
				this.currentPanelHeight = base.Height;
				this.contestsPanel.init(true);
				this.contestsPanel.Invalidate();
			}
			this.contestHistoryPanel.Location = new Point((base.Size.Width - this.contestHistoryPanel.Size.Width) / 2, 0);
			this.contestHistoryPanel.Size = new Size(this.contestHistoryPanel.Width, base.Height);
			if (this.lastPanelType == 31)
			{
				this.currentPanelHeight = base.Height;
				this.contestHistoryPanel.init(true);
				this.contestHistoryPanel.Invalidate();
			}
			this.reportsPanel.Location = new Point((base.Size.Width - this.reportsPanel.Size.Width) / 2, 0);
			this.reportsPanel.Size = new Size(this.reportsPanel.Width, base.Height);
			if (this.lastPanelType == 21)
			{
				this.currentPanelHeight = base.Height;
				this.reportsPanel.init(true);
				this.reportsPanel.Invalidate();
			}
			this.villageArmiesPanel.Location = new Point((base.Size.Width - this.villageArmiesPanel.Size.Width) / 2, 0);
			this.villageArmiesPanel.Size = new Size(this.villageArmiesPanel.Width, base.Height);
			if (this.lastPanelType == 7)
			{
				this.currentPanelHeight = base.Height;
				this.villageArmiesPanel.init(true);
				this.villageArmiesPanel.Invalidate();
			}
			this.vassalControlPanel.Location = new Point((base.Size.Width - this.vassalControlPanel.Size.Width) / 2, 0);
			this.vassalControlPanel.Size = new Size(this.vassalControlPanel.Width, base.Height);
			if (this.lastPanelType == 8)
			{
				this.currentPanelHeight = base.Height;
				this.vassalControlPanel.init(true);
				this.vassalControlPanel.Invalidate();
			}
			this.allArmiesPanel.Location = new Point((base.Size.Width - this.allArmiesPanel.Size.Width) / 2, 0);
			this.allArmiesPanel.Size = new Size(this.allArmiesPanel.Width, base.Height);
			if (this.lastPanelType == 23)
			{
				this.currentPanelHeight = base.Height;
				this.allArmiesPanel.init(true, -1);
				this.allArmiesPanel.Invalidate();
			}
			this.allVassalsPanel.Location = new Point((base.Size.Width - this.allVassalsPanel.Size.Width) / 2, 0);
			this.allVassalsPanel.Size = new Size(this.allVassalsPanel.Width, base.Height);
			if (this.lastPanelType == 24)
			{
				this.currentPanelHeight = base.Height;
				this.allVassalsPanel.init(true);
				this.allVassalsPanel.Invalidate();
			}
			this.questsPanel.Location = new Point((base.Size.Width - this.questsPanel.Size.Width) / 2, 0);
			this.questsPanel.Size = new Size(this.questsPanel.Width, base.Height);
			if (this.lastPanelType == 25)
			{
				this.currentPanelHeight = base.Height;
				this.questsPanel.init(true);
				this.questsPanel.Invalidate();
			}
			this.newQuestsPanel.Location = new Point((base.Size.Width - this.newQuestsPanel.Size.Width) / 2, 0);
			this.newQuestsPanel.Size = new Size(this.newQuestsPanel.Width, base.Height);
			if (this.lastPanelType == 26)
			{
				this.currentPanelHeight = base.Height;
				this.newQuestsPanel.init(true);
				this.newQuestsPanel.Invalidate();
			}
			this.factionInvitePanel.Location = new Point((base.Size.Width - this.factionInvitePanel.Size.Width) / 2, 0);
			this.factionInvitePanel.Size = new Size(this.factionInvitePanel.Width, base.Height);
			if (this.lastPanelType == 41)
			{
				this.currentPanelHeight = base.Height;
				this.factionInvitePanel.init(true);
				this.factionInvitePanel.Invalidate();
			}
			this.factionMyFactionPanel.Location = new Point((base.Size.Width - this.factionMyFactionPanel.Size.Width) / 2, 0);
			this.factionMyFactionPanel.Size = new Size(this.factionMyFactionPanel.Width, base.Height);
			if (this.lastPanelType == 42)
			{
				this.currentPanelHeight = base.Height;
				this.factionMyFactionPanel.init(true);
				this.factionMyFactionPanel.Invalidate();
			}
			this.factionStartFactionPanel.Location = new Point((base.Size.Width - this.factionStartFactionPanel.Size.Width) / 2, 0);
			this.factionStartFactionPanel.Size = new Size(this.factionStartFactionPanel.Width, base.Height);
			if (this.lastPanelType == 47)
			{
				this.currentPanelHeight = base.Height;
				this.factionStartFactionPanel.init(true);
				this.factionStartFactionPanel.Invalidate();
			}
			this.factionAllFactionsPanel.Location = new Point((base.Size.Width - this.factionAllFactionsPanel.Size.Width) / 2, 0);
			this.factionAllFactionsPanel.Size = new Size(this.factionAllFactionsPanel.Width, base.Height);
			if (this.lastPanelType == 43)
			{
				this.currentPanelHeight = base.Height;
				this.factionAllFactionsPanel.init(true);
				this.factionAllFactionsPanel.Invalidate();
			}
			this.allVillagesPanel.Location = new Point((base.Size.Width - this.allVillagesPanel.Size.Width) / 2, 0);
			this.allVillagesPanel.Size = new Size(this.allVillagesPanel.Width, base.Height);
			if (this.lastPanelType == 100)
			{
				this.currentPanelHeight = base.Height;
				this.allVillagesPanel.init(true);
				this.allVillagesPanel.Invalidate();
			}
			this.factionNewForumPostsPanel.Location = new Point((base.Size.Width - this.factionNewForumPostsPanel.Size.Width) / 2, 0);
			this.factionNewForumPostsPanel.Size = new Size(this.factionNewForumPostsPanel.Width, base.Height);
			if (this.lastPanelType == 48)
			{
				this.currentPanelHeight = base.Height;
				this.factionNewForumPostsPanel.init(true);
				this.factionNewForumPostsPanel.Invalidate();
			}
			this.factionOfficersPanel.Location = new Point((base.Size.Width - this.factionOfficersPanel.Size.Width) / 2, 0);
			this.factionOfficersPanel.Size = new Size(this.factionOfficersPanel.Width, base.Height);
			if (this.lastPanelType == 46)
			{
				this.currentPanelHeight = base.Height;
				this.factionOfficersPanel.init(true);
				this.factionOfficersPanel.Invalidate();
			}
			this.factionDiplomacyPanel.Location = new Point((base.Size.Width - this.factionDiplomacyPanel.Size.Width) / 2, 0);
			this.factionDiplomacyPanel.Size = new Size(this.factionDiplomacyPanel.Width, base.Height);
			if (this.lastPanelType == 44)
			{
				this.currentPanelHeight = base.Height;
				this.factionDiplomacyPanel.init(true);
				this.factionDiplomacyPanel.Invalidate();
			}
			this.factionNewForumPanel.Location = new Point((base.Size.Width - this.factionNewForumPanel.Size.Width) / 2, 0);
			this.factionNewForumPanel.Size = new Size(this.factionNewForumPanel.Width, base.Height);
			if (this.lastPanelType == 45)
			{
				this.currentPanelHeight = base.Height;
				this.factionNewForumPanel.init(true);
				this.factionNewForumPanel.Invalidate();
			}
			this.houseInfoPanel.Location = new Point((base.Size.Width - this.houseInfoPanel.Size.Width) / 2, 0);
			this.houseInfoPanel.Size = new Size(this.houseInfoPanel.Width, base.Height);
			if (this.lastPanelType == 52)
			{
				this.currentPanelHeight = base.Height;
				this.houseInfoPanel.init(true);
				this.houseInfoPanel.Invalidate();
			}
			this.houseListPanel.Location = new Point((base.Size.Width - this.houseListPanel.Size.Width) / 2, 0);
			this.houseListPanel.Size = new Size(this.houseListPanel.Width, base.Height);
			if (this.lastPanelType == 51)
			{
				this.currentPanelHeight = base.Height;
				this.houseListPanel.init(true);
				this.houseListPanel.Invalidate();
			}
			this.endOfWorldPanel.Location = new Point((base.Size.Width - this.endOfWorldPanel.Size.Width) / 2, (base.Size.Height - this.endOfWorldPanel.Size.Height) / 2);
			this.countyPanel.Location = new Point((base.Size.Width - this.countyPanel.Size.Width) / 2, 0);
			this.countyPanel.Size = new Size(this.countyPanel.Width, base.Height);
			if (this.lastPanelType == 1106)
			{
				this.currentPanelHeight = base.Height;
				this.countyPanel.init(true);
				this.countyPanel.Invalidate();
			}
			this.countyFrontPagePanel.Location = new Point((base.Size.Width - this.countyFrontPagePanel.Size.Width) / 2, (base.Size.Height - this.countyFrontPagePanel.Size.Height) / 2);
			this.provincePanel.Location = new Point((base.Size.Width - this.provincePanel.Size.Width) / 2, 0);
			this.provincePanel.Size = new Size(this.provincePanel.Width, base.Height);
			if (this.lastPanelType == 1206)
			{
				this.currentPanelHeight = base.Height;
				this.provincePanel.init(true);
				this.provincePanel.Invalidate();
			}
			this.provinceFrontPagePanel.Location = new Point((base.Size.Width - this.provinceFrontPagePanel.Size.Width) / 2, (base.Size.Height - this.provinceFrontPagePanel.Size.Height) / 2);
			this.countryPanel.Location = new Point((base.Size.Width - this.countryPanel.Size.Width) / 2, 0);
			this.countryPanel.Size = new Size(this.countryPanel.Width, base.Height);
			if (this.lastPanelType == 1306)
			{
				this.currentPanelHeight = base.Height;
				this.countryPanel.init(true);
				this.countryPanel.Invalidate();
			}
			this.countryFrontPagePanel.Location = new Point((base.Size.Width - this.countryFrontPagePanel.Size.Width) / 2, (base.Size.Height - this.countryFrontPagePanel.Size.Height) / 2);
			this.capitalDonateResourcesPanel.Location = new Point((base.Size.Width - this.capitalDonateResourcesPanel.Size.Width) / 2, (base.Size.Height - this.capitalDonateResourcesPanel.Size.Height) / 2);
			this.userDiplomacyPanel.Location = new Point((base.Size.Width - this.userDiplomacyPanel.Size.Width) / 2, 0);
			this.userDiplomacyPanel.Size = new Size(this.userDiplomacyPanel.Width, base.Height);
			if (this.lastPanelType == 60)
			{
				this.currentPanelHeight = base.Height;
				this.userDiplomacyPanel.init(true);
				this.userDiplomacyPanel.Invalidate();
			}
			if (this.lastPanelType == 22)
			{
				int num = base.Width;
				int num2 = base.Height;
				if (num > 1600)
				{
					num = 1600;
				}
				if (num2 > 1024)
				{
					num2 = 1024;
				}
				this.gloryPanel.Size = new Size(num, num2);
				this.currentPanelWidth = num;
				this.currentPanelHeight = num2;
				this.currentPanelWidth -= 168;
				this.currentPanelHeight -= 168;
				this.gloryPanel.Location = new Point((base.Size.Width - this.gloryPanel.Size.Width) / 2, (base.Size.Height - this.gloryPanel.Size.Height) / 2);
				this.gloryPanel.init();
			}
		}

		// Token: 0x06002FB6 RID: 12214 RVA: 0x002755C0 File Offset: 0x002737C0
		public Point getLocation()
		{
			int num = this.lastPanelType;
			if (num == 19)
			{
				return this.rankingsPanel.Location;
			}
			return default(Point);
		}

		// Token: 0x06002FB7 RID: 12215 RVA: 0x000229BB File Offset: 0x00020BBB
		public void resetData()
		{
			this.stockExchangePanel.resetBackupData();
			this.marketTransferPanel.resetBackupData();
		}

		// Token: 0x06002FB8 RID: 12216 RVA: 0x002755F0 File Offset: 0x002737F0
		protected override void OnPaint(PaintEventArgs e)
		{
			if (this._backBuffer == null || this.forceBackgroundRedraw)
			{
				if (this._backBuffer == null)
				{
					if (base.ClientSize.Width == 0 || base.ClientSize.Height == 0)
					{
						return;
					}
					this._backBuffer = new Bitmap(base.ClientSize.Width, base.ClientSize.Height);
				}
				this.forceBackgroundRedraw = false;
				Graphics graphics = Graphics.FromImage(this._backBuffer);
				if (this.backgroundImage != null)
				{
					for (int i = 0; i < base.ClientSize.Height; i += 512)
					{
						for (int j = 0; j < base.ClientSize.Width; j += 512)
						{
							graphics.DrawImageUnscaledAndClipped(this.backgroundImage, new Rectangle(j, i, 512, 512));
						}
					}
				}
				graphics.DrawImage(GFXLibrary.interface_inner_shadow_128_topleft, 0, 0, 128, 128);
				graphics.DrawImage(GFXLibrary.interface_inner_shadow_128_topright, base.ClientSize.Width - 128, 0, 128, 128);
				graphics.DrawImage(GFXLibrary.interface_inner_shadow_128_bottomleft, 0, base.ClientSize.Height - 128, 128, 128);
				graphics.DrawImage(GFXLibrary.interface_inner_shadow_128_bottomright, base.ClientSize.Width - 128, base.ClientSize.Height - 128, 128, 128);
				this.drawImageStretched(graphics, GFXLibrary.interface_inner_shadow_128_top, 128f, 0f, (float)(base.ClientSize.Width - 256), 128f);
				this.drawImageStretched(graphics, GFXLibrary.interface_inner_shadow_128_bottom, 128f, (float)(base.ClientSize.Height - 128), (float)(base.ClientSize.Width - 256), 128f);
				this.drawImageStretched(graphics, GFXLibrary.interface_inner_shadow_128_left, 0f, 128f, 128f, (float)(base.ClientSize.Height - 256));
				this.drawImageStretched(graphics, GFXLibrary.interface_inner_shadow_128_right, (float)(base.ClientSize.Width - 128), 128f, 128f, (float)(base.ClientSize.Height - 256));
				int num = (base.ClientSize.Width - this.currentPanelWidth) / 2 + 8;
				int num2 = (base.ClientSize.Height - this.currentPanelHeight) / 2 + 8;
				if (num > 0 || num2 > 0)
				{
					graphics.DrawImage(GFXLibrary.interface_under_shadow_128_topleft, num - 128, num2 - 128, 128, 128);
					graphics.DrawImage(GFXLibrary.interface_under_shadow_128_topright, num + this.currentPanelWidth, num2 - 128, 128, 128);
					graphics.DrawImage(GFXLibrary.interface_under_shadow_128_bottomleft, num - 128, num2 + this.currentPanelHeight, 128, 128);
					graphics.DrawImage(GFXLibrary.interface_under_shadow_128_bottomright, num + this.currentPanelWidth, num2 + this.currentPanelHeight, 128, 128);
					if (num > 0)
					{
						this.drawImageStretched(graphics, GFXLibrary.interface_under_shadow_128_top, (float)num, (float)(num2 - 128), (float)this.currentPanelWidth, 128f);
						this.drawImageStretched(graphics, GFXLibrary.interface_under_shadow_128_bottom, (float)num, (float)(num2 + this.currentPanelHeight), (float)this.currentPanelWidth, 128f);
					}
					if (num2 > 0)
					{
						this.drawImageStretched(graphics, GFXLibrary.interface_under_shadow_128_left, (float)(num - 128), (float)num2, 128f, (float)this.currentPanelHeight);
						this.drawImageStretched(graphics, GFXLibrary.interface_under_shadow_128_right, (float)(num + this.currentPanelWidth), (float)num2, 128f, (float)this.currentPanelHeight);
					}
				}
				graphics.Dispose();
			}
			if (e != null)
			{
				e.Graphics.DrawImageUnscaled(this._backBuffer, 0, 0);
			}
		}

		// Token: 0x06002FB9 RID: 12217 RVA: 0x000E3950 File Offset: 0x000E1B50
		private void drawImageStretched(Graphics g, Image image, float x, float y, float width, float height)
		{
			RectangleF srcRect = (image.Width == 1) ? new RectangleF(0f, 0f, 1E-05f, (float)image.Height) : new RectangleF(0f, 0f, (float)image.Width, 1E-05f);
			RectangleF destRect = new RectangleF(x, y, width, height);
			g.DrawImage(image, destRect, srcRect, GraphicsUnit.Pixel);
		}

		// Token: 0x06002FBA RID: 12218 RVA: 0x00007CE0 File Offset: 0x00005EE0
		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
		}

		// Token: 0x06002FBB RID: 12219 RVA: 0x000229D3 File Offset: 0x00020BD3
		protected override void OnSizeChanged(EventArgs e)
		{
			if (this._backBuffer != null)
			{
				this._backBuffer.Dispose();
				this._backBuffer = null;
				base.Invalidate();
			}
			base.OnSizeChanged(e);
		}

		// Token: 0x06002FBC RID: 12220 RVA: 0x000229FC File Offset: 0x00020BFC
		public void setBackgroundImage(Image image)
		{
			if (this.backgroundImage != image)
			{
				this.backgroundImage = image;
				this.forceBackgroundRedraw = true;
			}
		}

		// Token: 0x06002FBD RID: 12221 RVA: 0x00022A15 File Offset: 0x00020C15
		public bool isTextInputScreenActive()
		{
			return this.parishFrontPagePanel.isVisible() || this.statsPanel.isVisible();
		}

		// Token: 0x06002FBE RID: 12222 RVA: 0x00022A36 File Offset: 0x00020C36
		public void forceUpdateParishFrontPage()
		{
			this.parishFrontPagePanel.forceUpdateParish();
		}

		// Token: 0x06002FBF RID: 12223 RVA: 0x00022A43 File Offset: 0x00020C43
		public void leaderboardSearchComplete(LeaderBoardSearchResults results)
		{
			this.statsPanel.searchComplete(results);
		}

		// Token: 0x06002FC0 RID: 12224 RVA: 0x00022A51 File Offset: 0x00020C51
		public void clearAllReports()
		{
			this.reportsPanel.clearAllReports();
		}

		// Token: 0x06002FC1 RID: 12225 RVA: 0x00022A5E File Offset: 0x00020C5E
		public bool queryDeleteReport(long reportID)
		{
			return this.reportsPanel.queryDeleteReport(reportID);
		}

		// Token: 0x06002FC2 RID: 12226 RVA: 0x00022A6C File Offset: 0x00020C6C
		public void moveReports(string folderName)
		{
			ReportsManager.instance.moveReports(folderName);
		}

		// Token: 0x06002FC3 RID: 12227 RVA: 0x00022A79 File Offset: 0x00020C79
		public void deleteReportFolder(string folderName, int mode)
		{
			ReportsManager.instance.deleteReportFolder(folderName, mode);
		}

		// Token: 0x06002FC4 RID: 12228 RVA: 0x00022A87 File Offset: 0x00020C87
		public object getReportData(long reportID)
		{
			return ReportsManager.instance.getReportData(reportID);
		}

		// Token: 0x06002FC5 RID: 12229 RVA: 0x00022A94 File Offset: 0x00020C94
		public void setReportData(object reportData, long reportID)
		{
			ReportsManager.instance.setReportData(reportData, reportID);
		}

		// Token: 0x06002FC6 RID: 12230 RVA: 0x00022AA2 File Offset: 0x00020CA2
		public void setReportAlreadyRead(long reportID)
		{
			ReportsManager.instance.setReportAlreadyRead(reportID);
		}

		// Token: 0x06002FC7 RID: 12231 RVA: 0x00022AAF File Offset: 0x00020CAF
		public void questPanelInit()
		{
			this.questsPanel.init(false);
		}

		// Token: 0x06002FC8 RID: 12232 RVA: 0x00022ABD File Offset: 0x00020CBD
		public void questPanelCompleteQuest(int quest)
		{
			this.questsPanel.completeQuest(quest);
		}

		// Token: 0x06002FC9 RID: 12233 RVA: 0x00022ACB File Offset: 0x00020CCB
		public void inviteToFaction(string username)
		{
			this.factionOfficersPanel.inviteToFaction(username);
		}

		// Token: 0x06002FCA RID: 12234 RVA: 0x00022AD9 File Offset: 0x00020CD9
		public bool wasShowingVassalSendScreen()
		{
			return this.lastPanelType == 15;
		}

		// Token: 0x06002FCB RID: 12235 RVA: 0x00022AE8 File Offset: 0x00020CE8
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06002FCC RID: 12236 RVA: 0x00022AF8 File Offset: 0x00020CF8
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06002FCD RID: 12237 RVA: 0x00022B08 File Offset: 0x00020D08
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06002FCE RID: 12238 RVA: 0x00022B1A File Offset: 0x00020D1A
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06002FCF RID: 12239 RVA: 0x00022B27 File Offset: 0x00020D27
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x06002FD0 RID: 12240 RVA: 0x00022B35 File Offset: 0x00020D35
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06002FD1 RID: 12241 RVA: 0x00022B42 File Offset: 0x00020D42
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06002FD2 RID: 12242 RVA: 0x00022B4F File Offset: 0x00020D4F
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002FD3 RID: 12243 RVA: 0x00275A34 File Offset: 0x00273C34
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Black;
			base.Name = "VillageReportBackgroundPanel";
			base.Size = new Size(630, 458);
			base.ResumeLayout(false);
		}

		// Token: 0x04003C0C RID: 15372
		private DockWindow dockWindow;

		// Token: 0x04003C0D RID: 15373
		private HoldBanquetPanel holdBanquetPanel = new HoldBanquetPanel();

		// Token: 0x04003C0E RID: 15374
		private MarketTransferPanel marketTransferPanel = new MarketTransferPanel();

		// Token: 0x04003C0F RID: 15375
		private StockExchangePanel stockExchangePanel = new StockExchangePanel();

		// Token: 0x04003C10 RID: 15376
		private BarracksPanel barracksPanel = new BarracksPanel();

		// Token: 0x04003C11 RID: 15377
		private ResourcesPanel2 resourcesPanel = new ResourcesPanel2();

		// Token: 0x04003C12 RID: 15378
		private RankingsPanel rankingsPanel = new RankingsPanel();

		// Token: 0x04003C13 RID: 15379
		private GloryPanel gloryPanel = new GloryPanel();

		// Token: 0x04003C14 RID: 15380
		private StatsPanel statsPanel = new StatsPanel();

		// Token: 0x04003C15 RID: 15381
		private ContestsPanel contestsPanel = new ContestsPanel();

		// Token: 0x04003C16 RID: 15382
		private ContestHistoryPanel contestHistoryPanel = new ContestHistoryPanel();

		// Token: 0x04003C17 RID: 15383
		private ReportsPanel reportsPanel = new ReportsPanel();

		// Token: 0x04003C18 RID: 15384
		private VillageReinforcementsPanel2 villageReinforcementsPanel = new VillageReinforcementsPanel2();

		// Token: 0x04003C19 RID: 15385
		private VillageArmiesPanel2 villageArmiesPanel = new VillageArmiesPanel2();

		// Token: 0x04003C1A RID: 15386
		private VillageVassalsPanel vassalControlPanel = new VillageVassalsPanel();

		// Token: 0x04003C1B RID: 15387
		private QuestsPanel2 questsPanel = new QuestsPanel2();

		// Token: 0x04003C1C RID: 15388
		private NewQuestsPanel newQuestsPanel = new NewQuestsPanel();

		// Token: 0x04003C1D RID: 15389
		private AvatarEditorPanel avatarEditorPanel = new AvatarEditorPanel();

		// Token: 0x04003C1E RID: 15390
		private UnknownPanel unknownPanel = new UnknownPanel();

		// Token: 0x04003C1F RID: 15391
		private VassalArmiesPanel2 vassalArmiesPanel = new VassalArmiesPanel2();

		// Token: 0x04003C20 RID: 15392
		private UnitsPanel2 unitsPanel = new UnitsPanel2();

		// Token: 0x04003C21 RID: 15393
		private AllArmiesPanel2 allArmiesPanel = new AllArmiesPanel2();

		// Token: 0x04003C22 RID: 15394
		private AllVassalsPanel allVassalsPanel = new AllVassalsPanel();

		// Token: 0x04003C23 RID: 15395
		private CapitalResourcesPanel2 capitalResourcesPanel = new CapitalResourcesPanel2();

		// Token: 0x04003C24 RID: 15396
		private CapitalTradePanel capitalTradePanel = new CapitalTradePanel();

		// Token: 0x04003C25 RID: 15397
		private CapitalBarracksPanel capitalBarracksPanel = new CapitalBarracksPanel();

		// Token: 0x04003C26 RID: 15398
		private CapitalSendTroopsPanel2 capitalSendTroopsPanel = new CapitalSendTroopsPanel2();

		// Token: 0x04003C27 RID: 15399
		private ParishWallPanel parishFrontPagePanel = new ParishWallPanel();

		// Token: 0x04003C28 RID: 15400
		private ParishVotePanel parishPanel = new ParishVotePanel();

		// Token: 0x04003C29 RID: 15401
		private CapitalForumPanel parishForumPanel = new CapitalForumPanel();

		// Token: 0x04003C2A RID: 15402
		private CapitalForumPostsPanel capitalForumPostsPanel = new CapitalForumPostsPanel();

		// Token: 0x04003C2B RID: 15403
		private CountyFrontPagePanel2 countyFrontPagePanel = new CountyFrontPagePanel2();

		// Token: 0x04003C2C RID: 15404
		private CountyVotePanel countyPanel = new CountyVotePanel();

		// Token: 0x04003C2D RID: 15405
		private ProvinceFrontPagePanel2 provinceFrontPagePanel = new ProvinceFrontPagePanel2();

		// Token: 0x04003C2E RID: 15406
		private ProvinceVotePanel provincePanel = new ProvinceVotePanel();

		// Token: 0x04003C2F RID: 15407
		private CountryFrontPagePanel2 countryFrontPagePanel = new CountryFrontPagePanel2();

		// Token: 0x04003C30 RID: 15408
		private CountryVotePanel countryPanel = new CountryVotePanel();

		// Token: 0x04003C31 RID: 15409
		private CapitalDonateResourcesPanel2 capitalDonateResourcesPanel = new CapitalDonateResourcesPanel2();

		// Token: 0x04003C32 RID: 15410
		private FactionInvitePanel factionInvitePanel = new FactionInvitePanel();

		// Token: 0x04003C33 RID: 15411
		private FactionMyFactionPanel factionMyFactionPanel = new FactionMyFactionPanel();

		// Token: 0x04003C34 RID: 15412
		private FactionStartFactionPanel factionStartFactionPanel = new FactionStartFactionPanel();

		// Token: 0x04003C35 RID: 15413
		private FactionDiplomacyPanel factionDiplomacyPanel = new FactionDiplomacyPanel();

		// Token: 0x04003C36 RID: 15414
		private FactionOfficersPanel factionOfficersPanel = new FactionOfficersPanel();

		// Token: 0x04003C37 RID: 15415
		private FactionNewForumPanel factionNewForumPanel = new FactionNewForumPanel();

		// Token: 0x04003C38 RID: 15416
		private FactionAllFactionsPanel factionAllFactionsPanel = new FactionAllFactionsPanel();

		// Token: 0x04003C39 RID: 15417
		private FactionNewForumPostsPanel factionNewForumPostsPanel = new FactionNewForumPostsPanel();

		// Token: 0x04003C3A RID: 15418
		private UserDiplomacyPanel userDiplomacyPanel = new UserDiplomacyPanel();

		// Token: 0x04003C3B RID: 15419
		private HouseInfoPanel houseInfoPanel = new HouseInfoPanel();

		// Token: 0x04003C3C RID: 15420
		private HouseListPanel houseListPanel = new HouseListPanel();

		// Token: 0x04003C3D RID: 15421
		private EndofTheWorldPanel endOfWorldPanel = new EndofTheWorldPanel();

		// Token: 0x04003C3E RID: 15422
		private AllVillagesPanel allVillagesPanel = new AllVillagesPanel();

		// Token: 0x04003C3F RID: 15423
		public UserInfoScreen3 userInfoScreen = new UserInfoScreen3();

		// Token: 0x04003C40 RID: 15424
		private int lastPanelType = -1;

		// Token: 0x04003C41 RID: 15425
		private int lastVillageVisited = -1;

		// Token: 0x04003C42 RID: 15426
		private Bitmap _backBuffer;

		// Token: 0x04003C43 RID: 15427
		private int currentPanelWidth;

		// Token: 0x04003C44 RID: 15428
		private int currentPanelHeight;

		// Token: 0x04003C45 RID: 15429
		public bool forceBackgroundRedraw = true;

		// Token: 0x04003C46 RID: 15430
		private Image backgroundImage;

		// Token: 0x04003C47 RID: 15431
		private DockableControl dockableControl;

		// Token: 0x04003C48 RID: 15432
		private IContainer components;
	}
}
