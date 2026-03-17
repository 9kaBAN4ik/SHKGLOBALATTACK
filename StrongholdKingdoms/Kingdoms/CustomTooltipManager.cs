using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000191 RID: 401
	public class CustomTooltipManager
	{
		// Token: 0x06000F85 RID: 3973 RVA: 0x0001148D File Offset: 0x0000F68D
		public static void MouseEnterTooltipArea(int ID)
		{
			if (Program.mySettings.SETTINGS_showTooltips)
			{
				if (ID == 0)
				{
					CustomTooltipManager.MouseLeaveTooltipArea();
					return;
				}
				CustomTooltipManager.currentOverTooltip = ID;
				CustomTooltipManager.storedCurrentOverTooltip = ID;
				CustomTooltipManager.storedCurrentOverData = (CustomTooltipManager.currentOverData = 0);
				CustomTooltipManager.storedCurrentParentWindow = (CustomTooltipManager.currentParentWindow = null);
			}
		}

		// Token: 0x06000F86 RID: 3974 RVA: 0x000114C8 File Offset: 0x0000F6C8
		public static void MouseEnterTooltipArea(int ID, int data)
		{
			if (Program.mySettings.SETTINGS_showTooltips)
			{
				if (ID == 0)
				{
					CustomTooltipManager.MouseLeaveTooltipArea();
					return;
				}
				CustomTooltipManager.currentOverTooltip = ID;
				CustomTooltipManager.storedCurrentOverTooltip = ID;
				CustomTooltipManager.currentOverData = data;
				CustomTooltipManager.storedCurrentOverData = data;
				CustomTooltipManager.storedCurrentParentWindow = (CustomTooltipManager.currentParentWindow = null);
			}
		}

		// Token: 0x06000F87 RID: 3975 RVA: 0x00011503 File Offset: 0x0000F703
		public static void MouseEnterTooltipArea(int ID, int data, Form parentWindow)
		{
			if (Program.mySettings.SETTINGS_showTooltips)
			{
				if (ID == 0)
				{
					CustomTooltipManager.MouseLeaveTooltipArea();
					return;
				}
				CustomTooltipManager.currentOverTooltip = ID;
				CustomTooltipManager.storedCurrentOverTooltip = ID;
				CustomTooltipManager.currentOverData = data;
				CustomTooltipManager.storedCurrentOverData = data;
				CustomTooltipManager.currentParentWindow = parentWindow;
				CustomTooltipManager.storedCurrentParentWindow = parentWindow;
			}
		}

		// Token: 0x06000F88 RID: 3976 RVA: 0x0001153E File Offset: 0x0000F73E
		public static void MouseEnterTooltipAreaStored()
		{
			CustomTooltipManager.MouseEnterTooltipArea(CustomTooltipManager.storedCurrentOverTooltip, CustomTooltipManager.storedCurrentOverData, CustomTooltipManager.storedCurrentParentWindow);
			CustomTooltipManager.overTooltip = true;
		}

		// Token: 0x06000F89 RID: 3977 RVA: 0x0001155A File Offset: 0x0000F75A
		public static void MouseLeaveTooltipAreaStored()
		{
			CustomTooltipManager.overTooltip = false;
		}

		// Token: 0x06000F8A RID: 3978 RVA: 0x00011562 File Offset: 0x0000F762
		public static void MouseLeaveTooltipArea()
		{
			if (CustomTooltipManager.currentOverTooltip != 0 && !CustomTooltipManager.overTooltip)
			{
				CustomTooltipManager.lastOverTooltip = CustomTooltipManager.currentOverTooltip;
				CustomTooltipManager.lastLeaveTime = DateTime.Now;
				CustomTooltipManager.currentOverTooltip = 0;
			}
		}

		// Token: 0x06000F8B RID: 3979 RVA: 0x0001158C File Offset: 0x0000F78C
		public static void MouseLeaveTooltipAreaMapSpecial()
		{
			if (CustomTooltipManager.currentOverTooltip != 0 && !CustomTooltipManager.inSystemControl && !CustomTooltipManager.overTooltip)
			{
				CustomTooltipManager.lastOverTooltip = CustomTooltipManager.currentOverTooltip;
				CustomTooltipManager.lastLeaveTime = DateTime.Now;
				CustomTooltipManager.currentOverTooltip = 0;
			}
		}

		// Token: 0x06000F8C RID: 3980 RVA: 0x000115BD File Offset: 0x0000F7BD
		public static void addTooltipToSystemControl(Control control, int ID)
		{
			control.MouseLeave += CustomTooltipManager.systemToolTipLeave;
			control.MouseEnter += CustomTooltipManager.systemToolTipEnter;
			control.Name = ID.ToString();
		}

		// Token: 0x06000F8D RID: 3981 RVA: 0x000115F0 File Offset: 0x0000F7F0
		public static void updateTooltipForSystemControl(Control control, int ID)
		{
			control.Name = ID.ToString();
		}

		// Token: 0x06000F8E RID: 3982 RVA: 0x00109584 File Offset: 0x00107784
		private static void systemToolTipEnter(object sender, EventArgs e)
		{
			Control control = (Control)sender;
			int id = Convert.ToInt32(control.Name);
			CustomTooltipManager.MouseEnterTooltipArea(id, 0, control.FindForm());
			CustomTooltipManager.inSystemControl = true;
		}

		// Token: 0x06000F8F RID: 3983 RVA: 0x000115FF File Offset: 0x0000F7FF
		private static void systemToolTipLeave(object sender, EventArgs e)
		{
			CustomTooltipManager.inSystemControl = false;
			CustomTooltipManager.MouseLeaveTooltipArea();
		}

		// Token: 0x06000F90 RID: 3984 RVA: 0x001095B8 File Offset: 0x001077B8
		public static void addTooltipZonesToSystemControl(Control control, CustomTooltipManager.ToolTipZone[] zones)
		{
			CustomTooltipManager.ToolTipZoneControlChild toolTipZoneControlChild = CustomTooltipManager.findZoneControl(control);
			if (toolTipZoneControlChild != null)
			{
				control.Controls.Remove(toolTipZoneControlChild);
			}
			else
			{
				control.MouseLeave += CustomTooltipManager.systemToolTipZoneLeave;
				control.MouseEnter += CustomTooltipManager.systemToolTipZoneEnter;
				control.MouseMove += CustomTooltipManager.systemToolTipZoneMove;
			}
			CustomTooltipManager.ToolTipZoneControlChild toolTipZoneControlChild2 = new CustomTooltipManager.ToolTipZoneControlChild();
			toolTipZoneControlChild2.Visible = false;
			toolTipZoneControlChild2.zones = zones;
			control.Controls.Add(toolTipZoneControlChild2);
		}

		// Token: 0x06000F91 RID: 3985 RVA: 0x0001160C File Offset: 0x0000F80C
		private static void systemToolTipZoneMove(object sender, MouseEventArgs e)
		{
			CustomTooltipManager.systemToolTipZoneEnter(sender, e);
		}

		// Token: 0x06000F92 RID: 3986 RVA: 0x00109634 File Offset: 0x00107834
		private static void systemToolTipZoneEnter(object sender, EventArgs e)
		{
			CustomTooltipManager.ToolTipZoneControlChild toolTipZoneControlChild = CustomTooltipManager.findZoneControl(sender);
			if (toolTipZoneControlChild != null)
			{
				Point point = new Point(Cursor.Position.X, Cursor.Position.Y);
				Point point2 = toolTipZoneControlChild.PointToScreen(((Control)sender).Location);
				Point pt = new Point(point.X - point2.X, point.Y - point2.Y);
				CustomTooltipManager.ToolTipZone[] zones = toolTipZoneControlChild.zones;
				CustomTooltipManager.ToolTipZone[] array = zones;
				int i = 0;
				while (i < array.Length)
				{
					CustomTooltipManager.ToolTipZone toolTipZone = array[i];
					if (toolTipZone.rect.Contains(pt))
					{
						if ((toolTipZone.relatedControl == null || toolTipZone.relatedControl.Visible) && (toolTipZone.relatedCSDControl == null || toolTipZone.relatedCSDControl.Visible))
						{
							CustomTooltipManager.MouseEnterTooltipArea(toolTipZone.ID, 0, toolTipZoneControlChild.FindForm());
							return;
						}
						break;
					}
					else
					{
						i++;
					}
				}
			}
			CustomTooltipManager.MouseLeaveTooltipArea();
		}

		// Token: 0x06000F93 RID: 3987 RVA: 0x00011615 File Offset: 0x0000F815
		private static void systemToolTipZoneLeave(object sender, EventArgs e)
		{
			CustomTooltipManager.MouseLeaveTooltipArea();
		}

		// Token: 0x06000F94 RID: 3988 RVA: 0x00109724 File Offset: 0x00107924
		private static CustomTooltipManager.ToolTipZoneControlChild findZoneControl(object parent)
		{
			Control control = (Control)parent;
			if (control != null)
			{
				foreach (object obj in control.Controls)
				{
					Control control2 = (Control)obj;
					if (control2.GetType() == typeof(CustomTooltipManager.ToolTipZoneControlChild))
					{
						return (CustomTooltipManager.ToolTipZoneControlChild)control2;
					}
				}
			}
			return null;
		}

		// Token: 0x06000F95 RID: 3989 RVA: 0x001097A4 File Offset: 0x001079A4
		public static void addTooltipZonesToTabControl(TabControl control, CustomTooltipManager.ToolTipZone[] zones)
		{
			CustomTooltipManager.ToolTipZoneTabChild toolTipZoneTabChild = CustomTooltipManager.findZoneControlInTab(control);
			if (toolTipZoneTabChild != null)
			{
				control.Controls.Remove(toolTipZoneTabChild);
			}
			else
			{
				control.MouseLeave += CustomTooltipManager.systemToolTipZoneTabLeave;
				control.MouseEnter += CustomTooltipManager.systemToolTipZoneTabEnter;
				control.MouseMove += CustomTooltipManager.systemToolTipZoneTabMove;
			}
			CustomTooltipManager.ToolTipZoneTabChild toolTipZoneTabChild2 = new CustomTooltipManager.ToolTipZoneTabChild();
			toolTipZoneTabChild2.Visible = false;
			toolTipZoneTabChild2.zones = zones;
			control.Controls.Add(toolTipZoneTabChild2);
		}

		// Token: 0x06000F96 RID: 3990 RVA: 0x0001161C File Offset: 0x0000F81C
		private static void systemToolTipZoneTabMove(object sender, MouseEventArgs e)
		{
			CustomTooltipManager.systemToolTipZoneTabEnter(sender, e);
		}

		// Token: 0x06000F97 RID: 3991 RVA: 0x00109820 File Offset: 0x00107A20
		private static void systemToolTipZoneTabEnter(object sender, EventArgs e)
		{
			CustomTooltipManager.ToolTipZoneTabChild toolTipZoneTabChild = CustomTooltipManager.findZoneControlInTab(sender);
			if (toolTipZoneTabChild != null)
			{
				Point point = new Point(Cursor.Position.X, Cursor.Position.Y);
				Point point2 = toolTipZoneTabChild.PointToScreen(((Control)sender).Location);
				Point pt = new Point(point.X - point2.X, point.Y - point2.Y);
				CustomTooltipManager.ToolTipZone[] zones = toolTipZoneTabChild.zones;
				CustomTooltipManager.ToolTipZone[] array = zones;
				int i = 0;
				while (i < array.Length)
				{
					CustomTooltipManager.ToolTipZone toolTipZone = array[i];
					if (toolTipZone.rect.Contains(pt))
					{
						if ((toolTipZone.relatedControl == null || toolTipZone.relatedControl.Visible) && (toolTipZone.relatedCSDControl == null || toolTipZone.relatedCSDControl.Visible))
						{
							CustomTooltipManager.MouseEnterTooltipArea(toolTipZone.ID);
							return;
						}
						break;
					}
					else
					{
						i++;
					}
				}
			}
			CustomTooltipManager.MouseLeaveTooltipArea();
		}

		// Token: 0x06000F98 RID: 3992 RVA: 0x00011615 File Offset: 0x0000F815
		private static void systemToolTipZoneTabLeave(object sender, EventArgs e)
		{
			CustomTooltipManager.MouseLeaveTooltipArea();
		}

		// Token: 0x06000F99 RID: 3993 RVA: 0x0010990C File Offset: 0x00107B0C
		private static CustomTooltipManager.ToolTipZoneTabChild findZoneControlInTab(object parent)
		{
			Control control = (Control)parent;
			if (control != null)
			{
				foreach (object obj in control.Controls)
				{
					Control control2 = (Control)obj;
					if (control2.GetType() == typeof(CustomTooltipManager.ToolTipZoneTabChild))
					{
						return (CustomTooltipManager.ToolTipZoneTabChild)control2;
					}
				}
			}
			return null;
		}

		// Token: 0x06000F9A RID: 3994 RVA: 0x0010998C File Offset: 0x00107B8C
		public static void runTooltips()
		{
			DateTime now = DateTime.Now;
			bool flag = false;
			if (CustomTooltipManager.currentOverTooltip >= 4300 && CustomTooltipManager.currentOverTooltip <= 4309)
			{
				flag = true;
				CustomTooltipManager.staticMouse = true;
			}
			if (!Program.mySettings.SETTINGS_instantTooltips && !flag)
			{
				Point point = new Point(Cursor.Position.X, Cursor.Position.Y);
				if (!point.Equals(CustomTooltipManager.lastMousePosition))
				{
					CustomTooltipManager.lastMousePosition = point;
					CustomTooltipManager.staticMouse = false;
					CustomTooltipManager.lastMouseMoveTime = now;
				}
				else if (!CustomTooltipManager.staticMouse && (now - CustomTooltipManager.lastMouseMoveTime).TotalMilliseconds > (double)Program.mySettings.SETTINGS_staticMouseTime)
				{
					CustomTooltipManager.staticMouse = true;
				}
			}
			int num = 0;
			if (CustomTooltipManager.currentOverTooltip != 0)
			{
				num = CustomTooltipManager.currentOverTooltip;
			}
			else if (CustomTooltipManager.lastOverTooltip != 0 && (now - CustomTooltipManager.lastLeaveTime).TotalMilliseconds > 100.0)
			{
				CustomTooltipManager.lastOverTooltip = 0;
			}
			if (num != 0)
			{
				CustomTooltipManager.lastOverTooltip = num;
				CustomTooltipManager.showToolTip(num);
				return;
			}
			if (CustomTooltipManager.showingTooltip != 0 && CustomTooltipManager.showingTooltip != CustomTooltipManager.lastOverTooltip)
			{
				CustomTooltipManager.showingTooltip = 0;
				InterfaceMgr.Instance.closeCustomTooltip();
			}
		}

		// Token: 0x06000F9B RID: 3995 RVA: 0x00109AC4 File Offset: 0x00107CC4
		private static void showToolTip(int ID)
		{
			if (((!Program.mySettings.SETTINGS_instantTooltips && !CustomTooltipManager.staticMouse) || CustomTooltipManager.showingTooltip != 0) && ((ID == CustomTooltipManager.showingTooltip && CustomTooltipManager.currentOverData == CustomTooltipManager.currentOverLastData && !CustomTooltipManager.dynamicUpdateTooltips(ID)) || CustomTooltipManager.showingTooltip == 0))
			{
				return;
			}
			Form parentWindow = CustomTooltipManager.currentParentWindow;
			CustomTooltipManager.currentOverLastData = CustomTooltipManager.currentOverData;
			CustomTooltipManager.showingTooltip = ID;
			string text = SK.Text("TOOLIPS_UNDEFINED", "Undefined Tooltip");
			if (ID <= 2107)
			{
				if (ID <= 1200)
				{
					if (ID <= 708)
					{
						if (ID <= 400)
						{
							switch (ID)
							{
							case 1:
								text = SK.Text("TOOLTIPS_MAINWINDOW_CARDS_SHOW_ALL_CARDS", "Show All Cards");
								if (GameEngine.Instance.cardsManager.UserCardData.premiumCard > 0)
								{
									double totalSeconds = GameEngine.Instance.cardsManager.UserCardData.premiumCardExpiry.Subtract(VillageMap.getCurrentServerTime()).TotalSeconds;
									double d = totalSeconds / 86400.0;
									double d2 = totalSeconds % 86400.0 / 3600.0;
									double d3 = totalSeconds % 3600.0 / 60.0;
									text = text + Environment.NewLine + Environment.NewLine;
									string text2 = text;
									text = string.Concat(new string[]
									{
										text2,
										SK.Text("TOOLTIPS_LOGOUT_PREMIUM", "Your Premium Token expires in : "),
										Math.Floor(d).ToString().PadLeft(2, '0'),
										":",
										Math.Floor(d2).ToString().PadLeft(2, '0'),
										":",
										Math.Floor(d3).ToString().PadLeft(2, '0'),
										" (dd:hh:mm)"
									});
								}
								break;
							case 2:
								text = SK.Text("TOOLTIPS_MAINWINDOW_TOP_LEFT_USERNAME", "Your Username");
								break;
							case 3:
								text = SK.Text("TOOLTIPS_MAINWINDOW_TOP_LEFT_RANKING", "Your Current Rank");
								break;
							case 4:
								text = SK.Text("TOOLTIPS_MAINWINDOW_TOP_LEFT_HONOUR", "Your Current Honour Level");
								break;
							case 5:
								text = SK.Text("TOOLTIPS_MAINWINDOW_TOP_LEFT_GOLD", "Your Current Gold Level");
								break;
							case 6:
								if (GameEngine.Instance.LocalWorldData.EraWorld)
								{
									NumberFormatInfo nfi = GameEngine.NFI;
									int num = GameEngine.Instance.World.getRank();
									if (num < 0)
									{
										num = 0;
									}
									else if (num >= VillageBuildingsData.faithPointCap_EraWorlds.Length)
									{
										num = VillageBuildingsData.faithPointCap_EraWorlds.Length - 1;
									}
									int num2 = VillageBuildingsData.faithPointCap_EraWorlds[num];
									text = SK.Text("TOOLTIPS_MAINWINDOW_TOP_LEFT_FAITHPOINTS_CAP", "Your Current Faith Point Cap") + " : " + num2.ToString("N", nfi);
								}
								else
								{
									text = SK.Text("TOOLTIPS_MAINWINDOW_TOP_LEFT_FAITHPOINTS", "Your Current Faith Points");
								}
								break;
							case 7:
								text = SK.Text("TOOLTIPS_MAINWINDOW_TOP_LEFT_POINTS", "Your Current Points");
								break;
							case 8:
								text = (GameEngine.Instance.LocalWorldData.EraWorld ? SK.Text("TOOLTIPS_MAINWINDOW_TOP_LEFT_SECOND_ERA", "This World is in its Second Era. Click here for more details") : SK.Text("TOOLTIPS_MAINWINDOW_TOP_LEFT_SECOND_AGE", "This World is in its Second Age. Click here for more details"));
								break;
							case 9:
								text = (GameEngine.Instance.LocalWorldData.EraWorld ? SK.Text("TOOLTIPS_MAINWINDOW_TOP_LEFT_THIRD_ERA", "This World is in its Third Era. Click here for more details") : SK.Text("TOOLTIPS_MAINWINDOW_TOP_LEFT_THIRD_AGE", "This World is in its Third Age. Click here for more details"));
								break;
							case 10:
								text = SK.Text("TOOLTIPS_MAINWINDOW_TOP_LEFT_DOMINATION_WORLD", "This World uses the Domination World Rules. Click here for more details");
								break;
							case 11:
								if (GameEngine.Instance.LocalWorldData.Alternate_Ruleset == 1)
								{
									TimeSpan dominationTimeLeft = GameEngine.Instance.getDominationTimeLeft();
									int num3 = (int)dominationTimeLeft.TotalSeconds;
									int num4 = num3 % 60;
									int num5 = num3 / 60 % 60;
									int num6 = num3 / 3600 % 24;
									int num7 = num3 / 86400;
									if (dominationTimeLeft.TotalHours >= 24.0)
									{
										string str = num7.ToString() + SK.Text("VillageMap_Day_Abbrev", "d") + ":";
										str = ((num6 == 0) ? (str + "00:") : ((num6 >= 10) ? (str + num6.ToString() + ":") : (str + "0" + num6.ToString() + ":")));
										str = ((num5 == 0) ? (str + "00:") : ((num5 >= 10) ? (str + num5.ToString() + ":") : (str + "0" + num5.ToString() + ":")));
										string text3 = (num4 == 0) ? (str + "00") : ((num4 >= 10) ? (str + num4.ToString()) : (str + "0" + num4.ToString()));
										text = SK.Text("Dom_Time_Left", "Time Remaining") + " " + text3;
									}
									else
									{
										string str2 = "";
										str2 = ((num6 == 0) ? (str2 + "00:") : ((num6 >= 10) ? (str2 + num6.ToString() + ":") : (str2 + "0" + num6.ToString() + ":")));
										str2 = ((num5 == 0) ? (str2 + "00:") : ((num5 >= 10) ? (str2 + num5.ToString() + ":") : (str2 + "0" + num5.ToString() + ":")));
										string text3 = (num4 == 0) ? (str2 + "00") : ((num4 >= 10) ? (str2 + num4.ToString()) : (str2 + "0" + num4.ToString()));
										text = SK.Text("Dom_Time_Left", "Time Remaining") + " " + text3;
									}
								}
								break;
							case 12:
								text = (GameEngine.Instance.LocalWorldData.EraWorld ? SK.Text("TOOLTIPS_MAINWINDOW_TOP_LEFT_FOURTH_ERA", "This World is in its Fourth Era. Click here for more details") : SK.Text("TOOLTIPS_MAINWINDOW_TOP_LEFT_FOURTH_AGE", "This World is in its Fourth Age. Click here for more details"));
								break;
							case 13:
								text = (GameEngine.Instance.LocalWorldData.EraWorld ? SK.Text("TOOLTIPS_MAINWINDOW_TOP_LEFT_FIFTH_ERA", "This World is in its Fifth Era. Click here for more details") : SK.Text("TOOLTIPS_MAINWINDOW_TOP_LEFT_FIFTH_AGE", "This World is in its Fifth Age. Click here for more details"));
								break;
							case 14:
								text = (GameEngine.Instance.LocalWorldData.EraWorld ? SK.Text("TOOLTIPS_MAINWINDOW_TOP_LEFT_SIXTH_ERA", "This World is in its Sixth Era. Click here for more details") : SK.Text("TOOLTIPS_MAINWINDOW_TOP_LEFT_SIXTH_AGE", "This World is in its Sixth Age. Click here for more details"));
								break;
							case 15:
								text = (GameEngine.Instance.LocalWorldData.EraWorld ? SK.Text("TOOLTIPS_MAINWINDOW_TOP_LEFT_FINAL_ERA", "This World is in its Final Era. Click here for more details") : SK.Text("TOOLTIPS_MAINWINDOW_TOP_LEFT_SEVENTH_AGE", "This World is in its Final Age. Click here for more details"));
								break;
							case 16:
							case 17:
							case 18:
							case 19:
							case 35:
							case 36:
							case 37:
							case 38:
							case 39:
							case 54:
							case 55:
							case 56:
							case 57:
							case 58:
							case 59:
							case 60:
							case 61:
							case 62:
							case 63:
							case 64:
							case 65:
							case 66:
							case 67:
							case 68:
							case 69:
							case 70:
							case 71:
							case 72:
							case 73:
							case 74:
							case 75:
							case 76:
							case 77:
							case 78:
							case 79:
							case 80:
							case 81:
							case 82:
							case 83:
							case 84:
							case 85:
							case 86:
							case 87:
							case 88:
							case 89:
							case 95:
							case 96:
							case 97:
							case 98:
							case 99:
							case 135:
							case 136:
							case 137:
							case 138:
							case 139:
							case 152:
							case 153:
							case 154:
							case 155:
							case 156:
							case 157:
							case 158:
							case 159:
							case 160:
							case 161:
							case 162:
							case 163:
							case 164:
							case 165:
							case 166:
							case 167:
							case 168:
							case 169:
							case 170:
							case 171:
							case 172:
							case 173:
							case 174:
							case 175:
							case 176:
							case 177:
							case 178:
							case 179:
							case 180:
							case 181:
							case 182:
							case 183:
							case 184:
							case 185:
							case 186:
							case 187:
							case 188:
							case 189:
							case 190:
							case 191:
							case 192:
							case 193:
							case 194:
							case 195:
							case 196:
							case 197:
							case 198:
							case 199:
							case 239:
								break;
							case 20:
								text = SK.Text("TOOLTIPS_MAINWINDOW_TOP_RIGHT_VILLAGE_SCROLL", "Click to Scroll Through Your Villages");
								break;
							case 21:
								text = SK.Text("TOOLTIPS_MAINWINDOW_TOP_RIGHT_VILLAGE_LIST", "Click to View a List of Your Villages");
								break;
							case 22:
								text = SK.Text("TOOLTIPS_MAINWINDOW_TOP_RIGHT_MAIN_TAB_WORLDMAP", "Click to View the Map");
								break;
							case 23:
								text = SK.Text("TOOLTIPS_MAINWINDOW_TOP_RIGHT_MAIN_TAB_VILLAGEMAP", "Click to View Your Village");
								break;
							case 24:
								text = SK.Text("TOOLTIPS_MAINWINDOW_TOP_RIGHT_MAIN_TAB_RESEARCH", "Click for Research");
								break;
							case 25:
								text = SK.Text("TOOLTIPS_MAINWINDOW_TOP_RIGHT_MAIN_TAB_RANKING", "Click to Upgrade Your Rank");
								break;
							case 26:
								text = SK.Text("TOOLTIPS_MAINWINDOW_TOP_RIGHT_MAIN_TAB_ATTACKS", "Click to View Attacks");
								break;
							case 27:
								text = SK.Text("TOOLTIPS_MAINWINDOW_TOP_RIGHT_MAIN_TAB_REPORTS", "Click to View Reports");
								break;
							case 28:
								text = SK.Text("TOOLTIPS_MAINWINDOW_TOP_RIGHT_MAIN_TAB_MAIL", "Click to View your Mail");
								break;
							case 29:
								text = SK.Text("TOOLTIPS_MAINWINDOW_TOP_RIGHT_MAIN_TAB_LEADERBOARD", "Click to View the Leaderboards");
								break;
							case 30:
								text = SK.Text("TOOLTIPS_MAINWINDOW_TOP_RIGHT_MAIN_TAB_FACTIONS", "Click to View your Faction and House");
								break;
							case 31:
								text = SK.Text("TOOLTIPS_MAINWINDOW_TOP_RIGHT_MAIN_TAB_QUESTS", "Click to View your Current Quests");
								break;
							case 32:
								text = SK.Text("TOOLTIPS_MAINWINDOW_TOP_RIGHT_MAIN_TAB_CAPITAL", "Click to View the Parish Capital");
								break;
							case 33:
								text = SK.Text("TOOLTIPS_MAINWINDOW_TOP_RIGHT_MAIN_TAB_PREMIUM_VO", "Click to View the Premium Village Overview Screen");
								break;
							case 34:
								text = SK.Text("TOOLTIPS_MAINWINDOW_TOP_RIGHT_MAIN_TAB_TOURNEY", "Click to View the Active Tourney");
								break;
							case 40:
								text = SK.Text("TOOLTIPS_MAINWINDOW_TOP_RIGHT_VILLAGE_TAB_VILLAGE", "Click to View Your Village Map");
								break;
							case 41:
								text = SK.Text("TOOLTIPS_MAINWINDOW_TOP_RIGHT_VILLAGE_TAB_CASTLE", "Click to View Your Castle Map");
								break;
							case 42:
								text = SK.Text("TOOLTIPS_MAINWINDOW_TOP_RIGHT_VILLAGE_TAB_RESOURCES", "Click to View Your Resources");
								break;
							case 43:
								text = SK.Text("TOOLTIPS_MAINWINDOW_TOP_RIGHT_VILLAGE_TAB_TRADING", "Click to Trade");
								break;
							case 44:
								text = SK.Text("TOOLTIPS_MAINWINDOW_TOP_RIGHT_VILLAGE_TAB_TROOPS", "Click to Make Troops");
								break;
							case 45:
								text = SK.Text("TOOLTIPS_MAINWINDOW_TOP_RIGHT_VILLAGE_TAB_UNITS", "Click to Make Units");
								break;
							case 46:
								text = "Coming Soon";
								break;
							case 47:
								text = SK.Text("TOOLTIPS_MAINWINDOW_TOP_RIGHT_VILLAGE_TAB_BANQUETING", "Click to Hold a Banquet");
								break;
							case 48:
								text = SK.Text("TOOLTIPS_MAINWINDOW_TOP_RIGHT_VILLAGE_TAB_VASSALS", "Click to View Manage Your Vassals");
								break;
							case 49:
								text = SK.Text("TOOLTIPS_MAINWINDOW_TOP_RIGHT_VILLAGE_TAB_CAPITAL_INFO", "Click to View the Capital Info");
								break;
							case 50:
								text = SK.Text("TOOLTIPS_MAINWINDOW_TOP_RIGHT_VILLAGE_TAB_CAPITAL_VOTE", "Click to Vote");
								break;
							case 51:
								text = SK.Text("TOOLTIPS_MAINWINDOW_TOP_RIGHT_VILLAGE_TAB_CAPITAL_FORUM", "Click to View the Capital's Forum");
								break;
							case 52:
								text = SK.Text("TOOLTIPS_MAINWINDOW_TOP_RIGHT_VILLAGE_TAB_NOT_IMPLEMENTED_YET", "Not Implemented Yet");
								break;
							case 53:
								text = SK.Text("TOOLTIPS_MAINWINDOW_TOP_RIGHT_MAIN_TAB_CHAT", "Click to Chat");
								break;
							case 90:
								text = GameEngine.Instance.World.getVillageNameOrType(CustomTooltipManager.currentOverData);
								break;
							case 91:
								text = SK.Text("MapFilterSelectPanel_Map_Filtering", "Map Filtering");
								break;
							case 92:
								text = SK.Text("GENERIC_Close", "Close");
								break;
							case 93:
								text = SK.Text("MapFilterSelectPanel_Filter_Active", "Filter Active");
								break;
							case 94:
								text = SK.Text("Attack_Targets", "Attack Targets");
								break;
							case 100:
								if (CustomTooltipManager.currentOverData < 1000)
								{
									int num8 = 0;
									bool flag = true;
									if (GameEngine.Instance.Village != null && GameEngine.Instance.World.isCapital(GameEngine.Instance.Village.VillageID))
									{
										VillageMap village = GameEngine.Instance.Village;
										if (village.m_parishCapitalResearchData != null)
										{
											num8 = village.m_parishCapitalResearchData.getCapitalResourceFromBuildingType(CustomTooltipManager.currentOverData);
											if (num8 > 0)
											{
												flag = false;
											}
										}
									}
									text = ((!flag) ? string.Concat(new string[]
									{
										SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_BUILDING_ROLLOVER", "Click to Place"),
										" : ",
										VillageBuildingsData.getBuildingName(CustomTooltipManager.currentOverData),
										" - ",
										SK.Text("VillageMapPanel_Current_Level", "Current Level"),
										" ",
										num8.ToString()
									}) : (SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_BUILDING_ROLLOVER", "Click to Place") + " : " + VillageBuildingsData.getBuildingName(CustomTooltipManager.currentOverData)));
								}
								else
								{
									int num9 = CustomTooltipManager.currentOverData;
									switch (num9)
									{
									case 1000:
										text = SK.Text("TOOLTIPS_SUBMENU_RELIGIOUS", "Click to Open Religious Sub Menu");
										break;
									case 1001:
										text = SK.Text("TOOLTIPS_SUBMENU_DECORATIVE", "Click to Open Decorative Sub Menu");
										break;
									case 1002:
										text = SK.Text("TOOLTIPS_SUBMENU_JUSTICE", "Click to Open Justice Sub Menu");
										break;
									case 1003:
										text = SK.Text("TOOLTIPS_SUBMENU_ENTERTAINMENT", "Click to Open Entertainment Sub Menu");
										break;
									case 1004:
										text = SK.Text("TOOLTIPS_SUBMENU_SMALL_SHRINE", "Click to Open Small Shrine Sub Menu");
										break;
									case 1005:
										text = SK.Text("TOOLTIPS_SUBMENU_LARGE_SHRINE", "Click to Open Large Shrine Sub Menu");
										break;
									case 1006:
										text = SK.Text("TOOLTIPS_SUBMENU_SMALL_GARDEN", "Click to Open Formal Garden Sub Menu");
										break;
									case 1007:
										text = "";
										break;
									case 1008:
										text = SK.Text("TOOLTIPS_SUBMENU_LARGE_GARDEN", "Click to Open Flower Bed Sub Menu");
										break;
									case 1009:
										text = "";
										break;
									case 1010:
										text = SK.Text("TOOLTIPS_SUBMENU_SMALL_STATUE", "Click to Open Gilded Statue Sub Menu");
										break;
									default:
										switch (num9)
										{
										case 1111:
											text = SK.Text("TOOLTIPS_SUBMENU_LARGE_STATUE", "Click to Open Stone Statue Sub Menu");
											break;
										case 1112:
											text = SK.Text("TOOLTIPS_SUBMENU_CAPITAL_RESOURCE", "Click to Open Resources Sub Menu");
											break;
										case 1113:
											text = SK.Text("TOOLTIPS_SUBMENU_CAPITAL_FOOD", "Click to Open Food Sub Menu");
											break;
										case 1114:
											text = SK.Text("TOOLTIPS_SUBMENU_CAPITAL_BANQUET", "Click to Open Banquet Sub Menu");
											break;
										case 1115:
											text = SK.Text("TOOLTIPS_SUBMENU_CAPITAL_WEAPONS", "Click to Open Weapons Sub Menu");
											break;
										case 1116:
											text = SK.Text("TOOLTIPS_SUBMENU_CAPITAL_BANQUET_FOOD", "Click to Open Banquet Sub Menu");
											break;
										default:
											if (num9 == 2000)
											{
												text = SK.Text("TOOLTIPS_SUBMENU_BACK", "Click to go Back");
											}
											break;
										}
										break;
									}
								}
								break;
							case 101:
								text = ((CustomTooltipManager.currentOverData != 0) ? SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_BUILDING_TAB_1_CLOSE", "Click to Close Town Buildings Tab") : SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_BUILDING_TAB_1_OPEN", "Click to Open Town Buildings Tab"));
								break;
							case 102:
								text = ((CustomTooltipManager.currentOverData != 0) ? SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_BUILDING_TAB_2_CLOSE", "Click to Close Industry Buildings Tab") : SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_BUILDING_TAB_2_OPEN", "Click to Open Industry Buildings Tab"));
								break;
							case 103:
								text = ((CustomTooltipManager.currentOverData != 0) ? SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_BUILDING_TAB_3_CLOSE", "Click to Close Farm Buildings Tab") : SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_BUILDING_TAB_3_OPEN", "Click to Open Farm Buildings Tab"));
								break;
							case 104:
								text = ((CustomTooltipManager.currentOverData != 0) ? SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_BUILDING_TAB_4_CLOSE", "Click to Close Weapon Production Buildings Tab") : SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_BUILDING_TAB_4_OPEN", "Click to Open Weapon Production Buildings Tab"));
								break;
							case 105:
								text = ((CustomTooltipManager.currentOverData != 0) ? SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_BUILDING_TAB_5_CLOSE", "Click to Close Banqueting Resource Buildings Tab") : SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_BUILDING_TAB_5_OPEN", "Click to Open Banqueting Resource Buildings Tab"));
								break;
							case 106:
								text = ((CustomTooltipManager.currentOverData != 0) ? SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_CAPITAL_BUILDING_TAB_1_CLOSE", "Click to Close Castle Buildings Tab") : SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_CAPITAL_BUILDING_TAB_1_OPEN", "Click to Open Castle Buildings Tab"));
								break;
							case 107:
								text = ((CustomTooltipManager.currentOverData != 0) ? SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_CAPITAL_BUILDING_TAB_2_CLOSE", "Click to Close Army Buildings Tab") : SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_CAPITAL_BUILDING_TAB_2_OPEN", "Click to Open Army Buildings Tab"));
								break;
							case 108:
								text = ((CustomTooltipManager.currentOverData != 0) ? SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_CAPITAL_BUILDING_TAB_3_CLOSE", "Click to Close Civil Buildings Tab") : SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_CAPITAL_BUILDING_TAB_3_OPEN", "Click to Open Civil Buildings Tab"));
								break;
							case 109:
								text = ((CustomTooltipManager.currentOverData != 0) ? SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_CAPITAL_BUILDING_TAB_4_CLOSE", "Click to Close Guild Buildings Tab") : SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_CAPITAL_BUILDING_TAB_4_OPEN", "Click to Open Guild Buildings Tab"));
								break;
							case 110:
								text = SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_EXTRAS_BAR", "Click to View Extra Info Bars");
								break;
							case 111:
								text = SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_HONOUR_BAR", "Click to View Popularity To Honour Information");
								break;
							case 112:
								text = SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_HONOUR_BAR_CLOSE", "Click to Close Popularity To Honour Information");
								break;
							case 113:
								text = "";
								if (CustomTooltipManager.currentOverData >= 0)
								{
									text = VillageBuildingsData.getBuildingName(CustomTooltipManager.currentOverData) + Environment.NewLine + Environment.NewLine;
								}
								text += SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_IN_BUILDING_CLOSE", "Click to Close the Selected Building Information");
								break;
							case 114:
								text = SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_MOVE_BUILDING", "Click to Move the Selected Building");
								break;
							case 115:
								text = SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_TAX_INC", "Click to Increase Your Tax Rate");
								break;
							case 116:
								text = SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_TAX_DEC", "Click to Decrease Your Tax Rate");
								break;
							case 117:
								text = SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_RATIONS_INC", "Click to Increase Your Rations");
								break;
							case 118:
								text = SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_RATIONS_DEC", "Click to Decrease Your Rations");
								break;
							case 119:
								text = SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_ALE_INC", "Click to Increase Your Ale Rations");
								break;
							case 120:
								text = SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_ALE_DEC", "Click to Decrease Your Ale Rations");
								break;
							case 121:
								text = SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_POPULARITY_BAR", "Click to View Popularity Information");
								break;
							case 122:
								text = SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_POPULARITY_BAR_CLOSE", "Click to Close Popularity Information");
								break;
							case 123:
								text = SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_DETAILED_TAX_OPEN", "Click to View Detailed Tax Information");
								break;
							case 124:
								text = SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_DETAILED_TAX_CLOSE", "Click to Close Detailed Tax Information");
								break;
							case 125:
								text = SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_DETAILED_RATIONS_OPEN", "Click to View Detailed Rations Information");
								break;
							case 126:
								text = SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_DETAILED_RATIONS_CLOSE", "Click to Close Detailed Rations Information");
								break;
							case 127:
								text = SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_DETAILED_ALE_OPEN", "Click to View Detailed Ale Rations Information");
								break;
							case 128:
								text = SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_DETAILED_ALE_CLOSE", "Click to Close Detailed Ale Rations Information");
								break;
							case 129:
								text = SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_DETAILED_HOUSING_OPEN", "Click to View Detailed Housing Information");
								break;
							case 130:
								text = SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_DETAILED_HOUSING_CLOSE", "Click to Close Detailed Housing Information");
								break;
							case 131:
								text = SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_DETAILED_ENTERTAINMENT_OPEN", "Click to View Detailed Buildings Information");
								break;
							case 132:
								text = SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_DETAILED_ENTERTAINMENT_CLOSE", "Click to Close Detailed Buildings Information");
								break;
							case 133:
								text = SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_DETAILED_EVENTS_OPEN", "Click to View Detailed Events Information");
								break;
							case 134:
								text = SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_DETAILED_EVENTS_CLOSE", "Click to Close Detailed Events Information");
								break;
							case 140:
								text = SK.Text("TOOLTIPS_VILLAGEMAP_RIGHT_PANEL_BUILD_INFO", "Time and Cost to Build");
								break;
							case 141:
								text = "";
								break;
							case 142:
								text = SK.Text("TOOLTIPS_VILLAGEMAP_INFO_BAR_WOOD", "Current Wood Level");
								break;
							case 143:
								text = SK.Text("TOOLTIPS_VILLAGEMAP_INFO_BAR_STONE", "Current Stone Level");
								break;
							case 144:
								text = SK.Text("TOOLTIPS_VILLAGEMAP_INFO_BAR_FOOD", "Current Food Level");
								break;
							case 145:
								text = SK.Text("TOOLTIPS_VILLAGEMAP_INFO_BAR_CAPITAL_GOLD", "Current Capital Gold Level");
								break;
							case 146:
								text = SK.Text("TOOLTIPS_VILLAGEMAP_INFO_BAR_CAPITAL_FLAGS", "Current Flags");
								break;
							case 147:
								text = SK.Text("VILLAGEMAP_INFO_BAR_DONATION_TYPE", "Type of Goods Needed to Upgrade");
								break;
							case 148:
								text = SK.Text("TOOLTIPS_VO_Pitch", "Current Pitch Level");
								break;
							case 149:
								text = SK.Text("TOOLTIPS_VO_Iron", "Current Iron Level");
								break;
							case 150:
								text = VillageBuildingsData.getBuildingName(CustomTooltipManager.currentOverData) + " : " + SK.Text("VILLAGEMAP_CAPITAL_OVER_COMPLETED", "Fully Upgraded");
								break;
							case 151:
								text = VillageBuildingsData.getBuildingName(CustomTooltipManager.currentOverData) + " : " + SK.Text("VILLAGEMAP_CAPITAL_OVER_NOTCOMPLETED", "Upgrades available");
								break;
							case 200:
								if (CustomTooltipManager.currentOverData < 1000)
								{
									text = SK.Text("TOOLTIPS_CASTLEMAP_RIGHT_PANEL_BUILDING_ROLLOVER", "Click to Place : ") + CastlesCommon.getPieceName(CustomTooltipManager.currentOverData);
									if (CustomTooltipManager.currentOverData == 38 || CustomTooltipManager.currentOverData == 37 || CustomTooltipManager.currentOverData == 40 || CustomTooltipManager.currentOverData == 39)
									{
										text = text + Environment.NewLine + Environment.NewLine + SK.Text("TOOLTIPS_CASTLEMAP_RIGHT_PANEL_BUILDING_ROLLOVER_HELP", "Use Mouse Wheel or Spacebar to rotate.");
									}
								}
								break;
							case 201:
								text = ((CustomTooltipManager.currentOverData != 0) ? SK.Text("TOOLTIPS_CASTLEMAP_RIGHT_PANEL_BUILDING_TAB_1_CLOSE", "Click to Close Troops Tab") : SK.Text("TOOLTIPS_CASTLEMAP_RIGHT_PANEL_BUILDING_TAB_1_OPEN", "Click to Open Troops Tab"));
								break;
							case 202:
								text = ((CustomTooltipManager.currentOverData != 0) ? SK.Text("TOOLTIPS_CASTLEMAP_RIGHT_PANEL_BUILDING_TAB_2_CLOSE", "Click to Close Wood Tab") : SK.Text("TOOLTIPS_CASTLEMAP_RIGHT_PANEL_BUILDING_TAB_2_OPEN", "Click to Open Wood Tab"));
								break;
							case 203:
								text = ((CustomTooltipManager.currentOverData != 0) ? SK.Text("TOOLTIPS_CASTLEMAP_RIGHT_PANEL_BUILDING_TAB_3_CLOSE", "Click to Close Stone Tab") : SK.Text("TOOLTIPS_CASTLEMAP_RIGHT_PANEL_BUILDING_TAB_3_OPEN", "Click to Open Stone Tab"));
								break;
							case 204:
								text = ((CustomTooltipManager.currentOverData != 0) ? SK.Text("TOOLTIPS_CASTLEMAP_RIGHT_PANEL_BUILDING_TAB_4_CLOSE", "Click to Close Buildings Tab") : SK.Text("TOOLTIPS_CASTLEMAP_RIGHT_PANEL_BUILDING_TAB_4_OPEN", "Click to Open Buildings Tab"));
								break;
							case 205:
								text = SK.Text("TOOLTIPS_CASTLEMAP_RIGHT_PANEL_TOGGLE_REINFORCEMENTS_ON", "Click to Place Reinforcements");
								break;
							case 206:
								text = SK.Text("TOOLTIPS_CASTLEMAP_RIGHT_PANEL_TOGGLE_REINFORCEMENTS_OFF", "Click to Place Your Troops");
								break;
							case 207:
								text = SK.Text("TOOLTIPS_CASTLEMAP_RIGHT_PANEL_1X1", "Click to Change Placement Pattern : 1x1");
								break;
							case 208:
								text = SK.Text("TOOLTIPS_CASTLEMAP_RIGHT_PANEL_3X3", "Click to Change Placement Pattern : 3x3");
								break;
							case 209:
								text = SK.Text("TOOLTIPS_CASTLEMAP_RIGHT_PANEL_5X5", "Click to Change Placement Pattern : 5x5");
								break;
							case 210:
								text = SK.Text("TOOLTIPS_CASTLEMAP_RIGHT_PANEL_1X5", "Click to Change Placement Pattern : 1x5");
								break;
							case 211:
								text = SK.Text("TOOLTIPS_CASTLEMAP_RIGHT_PANEL_TOGGLE_VIEWMODE_HIGH", "Click to View Castle in Full Mode");
								break;
							case 212:
								text = SK.Text("TOOLTIPS_CASTLEMAP_RIGHT_PANEL_TOGGLE_VIEWMODE_LOW", "Click to View Castle in Collapsed Mode");
								break;
							case 213:
								text = SK.Text("TOOLTIPS_CASTLEMAP_RIGHT_PANEL_TOGGLE_DELETE_ON", "Click to Start Delete Mode");
								break;
							case 214:
								text = SK.Text("TOOLTIPS_CASTLEMAP_RIGHT_PANEL_TOGGLE_DELETE_OFF", "Click to Stop Delete Mode");
								break;
							case 215:
								text = SK.Text("TOOLTIPS_CASTLEMAP_RIGHT_PANEL_CASTLE_CONSTRUCTION_OPTIONS_OPEN", "Click to View Castle Construction Options");
								break;
							case 216:
								text = SK.Text("TOOLTIPS_CASTLEMAP_RIGHT_PANEL_CASTLE_CONSTRUCTION_OPTIONS_CLOSE", "Click to Close Castle Construction Options");
								break;
							case 217:
								text = SK.Text("TOOLTIPS_CASTLEMAP_RIGHT_PANEL_REPAIR", "Click to Repair all damaged castle infrastructure.");
								break;
							case 218:
								text = SK.Text("TOOLTIPS_CASTLEMAP_RIGHT_PANEL_DELETE_CONSTRUCTING", "Click to Delete all castle structures currently under construction");
								break;
							case 219:
								text = SK.Text("TOOLTIPS_CASTLEMAP_RIGHT_PANEL_CONFIRM", "Click to Upload your castle changes to the server");
								break;
							case 220:
								text = SK.Text("TOOLTIPS_CASTLEMAP_RIGHT_PANEL_CANCEL", "Click to Cancel all unconfirmed changes");
								break;
							case 221:
							{
								text = SK.Text("TOOLTIPS_CASTLEMAP_RIGHT_PANEL_DELETE_TROOPS", "Remove Placed Troops") + " : ";
								int num10 = CustomTooltipManager.currentOverData;
								switch (num10)
								{
								case 70:
									text += SK.Text("GENERIC_Peasants", "Peasants");
									break;
								case 71:
									text += SK.Text("GENERIC_Swordsmen", "Swordsmen");
									break;
								case 72:
									text += SK.Text("GENERIC_Archers", "Archers");
									break;
								case 73:
									text += SK.Text("GENERIC_Pikemen", "Pikemen");
									break;
								default:
									if (num10 == 85)
									{
										text += SK.Text("GENERIC_Captains", "Captains");
									}
									break;
								}
								break;
							}
							case 222:
								text = SK.Text("TOOLTIPS_CASTLEMAP_RIGHT_PANEL_TOGGLE_AGGRESSIVE", "Toggle Aggressive Defender State");
								break;
							case 223:
								text = ((CustomTooltipManager.currentOverData != 0) ? SK.Text("TOOLTIPS_CASTLEMAP_RIGHT_PANEL_BUILDING_TAB_5_CLOSE", "Click to Close Parish Unlocked Structures Tab") : SK.Text("TOOLTIPS_CASTLEMAP_RIGHT_PANEL_BUILDING_TAB_5_OPEN", "Click to Open Parish Unlocked Structures Tab"));
								break;
							case 224:
								text = SK.Text("TOOLTIPS_CASTLEMAP_PRESET_MEMORISE", "Memorise Preset");
								break;
							case 225:
								text = SK.Text("TOOLTIPS_CASTLEMAP_PRESET_DEPLOY", "Deploy Preset");
								break;
							case 226:
								text = SK.Text("TOOLTIPS_CASTLEMAP_PRESET_RENAME", "Rename Preset");
								break;
							case 227:
								text = SK.Text("TOOLTIPS_CASTLEMAP_PRESET_DELETE", "Delete Preset");
								break;
							case 228:
								text = SK.Text("TOOLTIPS_CASTLEMAP_PRESET_DETAILS", "View Details");
								break;
							case 229:
								text = SK.Text("TOOLTIPS_CASTLEMAP_PRESET_RETURN", "Return to Presets");
								break;
							case 230:
								text = SK.Text("TOOLTIPS_CASTLEMAP_PRESET_DEFENCE_REQ", "Required Defence Research Level");
								if (CustomTooltipManager.currentOverData == 0)
								{
									text = text + " " + SK.Text("TOOLTIPS_CASTLEMAP_PRESET_REQ_NOT_MET", "(Not Met)");
								}
								break;
							case 231:
								text = SK.Text("TOOLTIPS_CASTLEMAP_PRESET_FORTIFICATION_REQ", "Required Fortification Research Level");
								if (CustomTooltipManager.currentOverData == 0)
								{
									text = text + " " + SK.Text("TOOLTIPS_CASTLEMAP_PRESET_REQ_NOT_MET", "(Not Met)");
								}
								break;
							case 232:
								text = SK.Text("TOOLTIPS_CASTLEMAP_PRESET_PARISH_REQ", "Parish Buildings Required");
								if (CustomTooltipManager.currentOverData == 0)
								{
									text = text + " " + SK.Text("TOOLTIPS_CASTLEMAP_PRESET_REQ_NOT_MET", "(Not Met)");
								}
								break;
							case 233:
								text = SK.Text("TOOLTIPS_CASTLEMAP_PRESET_WOOD", "Wood Required");
								if (CustomTooltipManager.currentOverData == 0)
								{
									text = text + " " + SK.Text("TOOLTIPS_CASTLEMAP_PRESET_REQ_NOT_MET", "(Not Met)");
								}
								break;
							case 234:
								text = SK.Text("TOOLTIPS_CASTLEMAP_PRESET_STONE", "Stone Required");
								if (CustomTooltipManager.currentOverData == 0)
								{
									text = text + " " + SK.Text("TOOLTIPS_CASTLEMAP_PRESET_REQ_NOT_MET", "(Not Met)");
								}
								break;
							case 235:
								text = SK.Text("TOOLTIPS_CASTLEMAP_PRESET_IRON", "Iron Required");
								if (CustomTooltipManager.currentOverData == 0)
								{
									text = text + " " + SK.Text("TOOLTIPS_CASTLEMAP_PRESET_REQ_NOT_MET", "(Not Met)");
								}
								break;
							case 236:
								text = SK.Text("TOOLTIPS_CASTLEMAP_PRESET_PITCH", "Pitch Required");
								if (CustomTooltipManager.currentOverData == 0)
								{
									text = text + " " + SK.Text("TOOLTIPS_CASTLEMAP_PRESET_REQ_NOT_MET", "(Not Met)");
								}
								break;
							case 237:
								text = SK.Text("TOOLTIPS_CASTLEMAP_PRESET_GOLD", "Gold Required");
								if (CustomTooltipManager.currentOverData == 0)
								{
									text = text + " " + SK.Text("TOOLTIPS_CASTLEMAP_PRESET_REQ_NOT_MET", "(Not Met)");
								}
								break;
							case 238:
								text = SK.Text("TOOLTIPS_CASTLEMAP_PRESET_TIME", "Total Construction Time");
								break;
							case 240:
								text = SK.Text("TOOLTIPS_CASTLEMAP_PRESET_PREVIEW", "Toggle Preview");
								break;
							default:
								switch (ID)
								{
								case 300:
									text = SK.Text("TOOLTIPS_RESEARCHTREE_LIST_MODE", "Click to View a List of Available Researches");
									break;
								case 301:
									text = SK.Text("TOOLTIPS_RESEARCHTREE_TREE_MODE", "Click to View the Research Tree");
									break;
								case 302:
								{
									ResearchData userResearchData = GameEngine.Instance.World.UserResearchData;
									if (userResearchData != null && userResearchData.research_queueEntries != null && CustomTooltipManager.currentOverData < userResearchData.research_queueEntries.Length)
									{
										int researchType = userResearchData.research_queueEntries[CustomTooltipManager.currentOverData];
										text = ResearchData.getResearchName(researchType) + Environment.NewLine + Environment.NewLine;
										DateTime currentServerTime = VillageMap.getCurrentServerTime();
										TimeSpan t = userResearchData.research_completionTime - currentServerTime;
										int num11;
										for (int i = 0; i < CustomTooltipManager.currentOverData + 1; i = num11 + 1)
										{
											TimeSpan t2 = userResearchData.calcResearchTime(userResearchData.research_pointCount + i, GameEngine.Instance.cardsManager.UserCardData, GameEngine.Instance.LocalWorldData);
											if (GameEngine.Instance.LocalWorldData.Alternate_Ruleset == 1)
											{
												t2 = new TimeSpan(t2.Ticks / 2L);
											}
											t += t2;
											num11 = i;
										}
										text = text + SK.Text("Research_Completed_In", "Completed In") + " : " + VillageMap.createBuildTimeString((int)t.TotalSeconds);
									}
									break;
								}
								default:
									if (ID == 400)
									{
										text = SK.Text("TOOLTIPS_RANKING_UPGRADE", "Click to Upgrade your Rank");
									}
									break;
								}
								break;
							}
						}
						else if (ID <= 518)
						{
							if (ID != 401)
							{
								switch (ID)
								{
								case 500:
									text = SK.Text("TOOLTIPS_MAILSCREEN_FLOAT", "Click to Detach Mail Screen");
									break;
								case 501:
									text = SK.Text("TOOLTIPS_MAILSCREEN_DOCK", "Click to Dock the Mail Screen");
									break;
								case 502:
									text = SK.Text("TOOLTIPS_MAILSCREEN_CLOSE", "Click to Close");
									break;
								case 503:
									text = SK.Text("TOOLTIPS_MAILSCREEN_REPORT", "This is for reporting offensive language or personal abuse only");
									break;
								case 504:
									text = SK.Text("TOOLTIPS_MAILSCREEN_AGGRESSIVE_BLOCK", "Aggressive Mail Block, blocks from view any mail thread that contains someone on your block list. Normal mail block only removes threads that only contain users that are in your block list.");
									break;
								case 505:
									text = SK.Text("TOOLTIPS_MAIL_SEARCH", "Search For User");
									break;
								case 506:
									text = SK.Text("TOOLTIPS_MAIL_RECENT", "Recent Recipients");
									break;
								case 507:
									text = SK.Text("TOOLTIPS_MAIL_FAVOURITES", "Favourites");
									break;
								case 508:
									text = SK.Text("TOOLTIPS_MAIL_OTHERS_KNOWN", "Faction Members and Personal Allies");
									break;
								case 511:
									text = SK.Text("TOOLTIPS_MAIL_SELECT_VILLAGE", "Select Village");
									break;
								case 512:
									text = SK.Text("TOOLTIPS_MAIL_SEARCH_REGION", "Search for Parish");
									break;
								case 513:
									text = SK.Text("TOOLTIPS_MAIL_CURRENT_ATTACHMENTS", "Attached Targets");
									break;
								case 514:
									text = SK.Text("TOOLTIPS_MAIL_OPEN_ATTACHMENTS", "Open Targets");
									break;
								case 515:
									text = SK.Text("TOOLTIPS_MAIL_PLAYER_LINK", "Link to Player");
									break;
								case 516:
									text = SK.Text("TOOLTIPS_MAIL_VILLAGE_LINK", "Link to Village");
									break;
								case 517:
									text = SK.Text("TOOLTIPS_MAIL_PARISH_LINK", "Link to Parish");
									break;
								case 518:
									text = SK.Text("TOOLTIPS_VILLAGE_SEARCH_DISABLED", "Select a player by searching to view their villages");
									break;
								}
							}
							else
							{
								text = Rankings.getRankingName(CustomTooltipManager.currentOverData, RemoteServices.Instance.UserAvatar.male) + " (" + (CustomTooltipManager.currentOverData + 1).ToString() + ")";
							}
						}
						else
						{
							switch (ID)
							{
							case 600:
								text = SK.Text("TOOLTIPS_BARRACKS_DISBAND", "Click for Disband Options");
								break;
							case 601:
								text = SK.Text("TOOLTIPS_BARRACKS_CLOSE", "Click to Close");
								break;
							case 602:
								text = SK.Text("GENERIC_Armed_Peasants", "Armed Peasants");
								break;
							case 603:
								text = SK.Text("GENERIC_Archers", "Archers");
								break;
							case 604:
								text = SK.Text("GENERIC_Pikemen", "Pikemen");
								break;
							case 605:
								text = SK.Text("GENERIC_Swordsmen", "Swordsmen");
								break;
							case 606:
								text = SK.Text("GENERIC_Catapults", "Catapults");
								break;
							case 607:
								text = SK.Text("GENERIC_Captains", "Captains");
								break;
							case 608:
								text = SK.Text("TOOLTIPS_BARRACKS_ARCHERS_NOT_RESEARCHED", "To recruit Archers you must be Rank 6 and research 'Long Bows'.");
								break;
							case 609:
								text = SK.Text("TOOLTIPS_BARRACKS_PIKEMEN_NOT_RESEARCHED", "To recruit Pikemen you must be Rank 11 and research 'Pike'.");
								break;
							case 610:
								text = SK.Text("TOOLTIPS_BARRACKS_SWORDSMEN_NOT_RESEARCHED", "To recruit Swordsmen you must be Rank 13 and research 'Sword'.");
								break;
							case 611:
								text = SK.Text("TOOLTIPS_BARRACKS_CATAPULTS_NOT_RESEARCHED", "To recruit Catapults you must be Rank 15 and research 'Catapult'.");
								break;
							case 612:
								text = SK.Text("TOOLTIPS_BARRACKS_CAPTAINS_NOT_RESEARCHED", "To recruit Captains you must be Rank 12 and research 'Leadership' and 'Captains'.");
								break;
							default:
								switch (ID)
								{
								case 700:
									text = SK.Text("TOOLTIPS_UNITS_DISBAND", "Click for Disband Options");
									break;
								case 701:
									text = SK.Text("TOOLTIPS_UNITS_CLOSE", "Click to Close");
									break;
								case 702:
									text = SK.Text("TOOLTIPS_UNITS_SPACE_REQUIRED", "Unit Space Required") + " : " + CustomTooltipManager.currentOverData.ToString();
									break;
								case 703:
									text = SK.Text("GENERIC_Merchants", "Merchants");
									break;
								case 704:
									text = SK.Text("GENERIC_Monks", "Monks");
									break;
								case 705:
									text = SK.Text("GENERIC_Scouts", "Scouts");
									break;
								case 706:
									text = SK.Text("TOOLTIPS_UNITS_MERCHANTS_NOT_RESEARCHED", "To recruit Merchants you must be Rank 5, research 'Merchant Guilds' and build a Market.");
									break;
								case 707:
									text = SK.Text("TOOLTIPS_UNITS_MONKS_NOT_RESEARCHED", "To recruit Monks you must be Rank 8 and research 'Ordination'.");
									break;
								case 708:
									text = SK.Text("TOOLTIPS_UNITS_SCOUTS_NOT_RESEARCHED", "To recruit Scouts you must research 'Scouts'.");
									break;
								}
								break;
							}
						}
					}
					else if (ID <= 901)
					{
						switch (ID)
						{
						case 800:
							text = SK.Text("TOOLTIPS_STOCKEXCHANGE_CLOSE", "Click to Close");
							break;
						case 801:
							text = SK.Text("TOOLTIPS_TRADE_CLOSE", "Click to Close");
							break;
						case 802:
							text = SK.Text("TOOLTIPS_TRADE_RESOURCES", "Click to Trade Resources");
							break;
						case 803:
							text = SK.Text("TOOLTIPS_TRADE_FOOD", "Click to Trade Food");
							break;
						case 804:
							text = SK.Text("TOOLTIPS_TRADE_WEAPONS", "Click to Trade Weapons");
							break;
						case 805:
							text = SK.Text("TOOLTIPS_TRADE_BANQUETING", "Click to Trade Banqueting Goods");
							break;
						case 806:
							text = SK.Text("TOOLTIPS_TOGGLE_TO_STOCKEXCHANGE", "Click for Stock Exchange Trading");
							break;
						case 807:
							text = SK.Text("TOOLTIPS_TOGGLE_TO_TRADING", "Click for Village to Village Trading");
							break;
						case 808:
							text = SK.Text("TOOLTIPS_REMOVE_FAVOURITE", "Click here to remove this Stock Exchange from your Favourites");
							break;
						case 809:
							text = SK.Text("TOOLTIPS_ADD_FAVOURITE", "Click here to add this Stock Exchange to your Favourites");
							break;
						case 810:
							text = SK.Text("TOOLTIPS_REMOVE_RECENT", "Click here to remove this Stock Exchange from your recent Stock Exchanges");
							break;
						case 811:
							text = SK.Text("TOOLTIPS_REMOVE_FAVOURITE_MARKET", "Click here to remove this Village from your Favourites");
							break;
						case 812:
							text = SK.Text("TOOLTIPS_ADD_FAVOURITE_MARKET", "Click here to add this Village to your Favourites");
							break;
						case 813:
							text = SK.Text("TOOLTIPS_REMOVE_RECENT_MARKET", "Click here to remove this Village from your Recent List");
							break;
						case 814:
							text = SK.Text("TOOLTIPS_FIND_HIGHEST_PRICE", "Find the highest price for this item in the 20 closest Stock Exchanges. (Premium Token in play Required)");
							break;
						case 815:
							text = SK.Text("TOOLTIPS_FIND_LOWEST_PRICE", "Find the lowest price for this item in the 20 closest Stock Exchanges. (Premium Token in play Required)");
							break;
						default:
							if (ID != 900)
							{
								if (ID == 901)
								{
									text = SK.Text("TOOLTIPS_RESOURCES_PRODUCTION_INFO", "Click for Production Information");
								}
							}
							else
							{
								text = SK.Text("TOOLTIPS_RESOURCES_CLOSE", "Click to Close");
							}
							break;
						}
					}
					else if (ID <= 1100)
					{
						if (ID != 1000)
						{
							if (ID == 1100)
							{
								text = SK.Text("TOOLTIPS_AREASELECT_OVER_TAG", "Click to Select this county as your starting area");
							}
						}
						else
						{
							text = SK.Text("TOOLTIPS_BANQUET_CLOSE", "Click to Close");
						}
					}
					else if (ID != 1101)
					{
						if (ID == 1200)
						{
							text = SK.Text("TOOLTIPS_MENUBAR_CONVERT", "This allows you to change your village type to another, all buildings are lost but all resources, units and your castle are kept.");
						}
					}
					else
					{
						text = SK.Text("TOOLTIPS_AREASELECT_OVER_TAG_FULL", "This County is Full");
					}
				}
				else if (ID <= 1719)
				{
					if (ID <= 1421)
					{
						if (ID != 1201)
						{
							if (ID != 1300)
							{
								switch (ID)
								{
								case 1400:
									text = SK.Text("TOOLTIPS_LOGOUT_CLOSE", "Close logout window without logging out");
									break;
								case 1401:
									text = SK.Text("TOOLTIPS_LOGOUT_AUTO_TRADE", "Toggle Auto-Trade On/Off");
									break;
								case 1402:
									text = SK.Text("TOOLTIPS_LOGOUT_AUTO_SCOUT", "Toggle Auto-Scouting On/Off");
									break;
								case 1403:
									text = SK.Text("TOOLTIPS_LOGOUT_AUTO_ATTACK", "Toggle Auto-Attack On/Off");
									break;
								case 1404:
									text = SK.Text("TOOLTIPS_LOGOUT_AUTO_RECRUIT", "Toggle Auto-Recruit On/Off");
									break;
								case 1405:
									text = SK.Text("TOOLTIPS_LOGOUT_AUTO_REBUILD", "Toggle Auto-Rebuild On/Off");
									break;
								case 1406:
									text = SK.Text("TOOLTIPS_LOGOUT_AUTO_TRANSFER", "Toggle Auto-Transfer On/Off");
									break;
								case 1407:
									text = string.Concat(new string[]
									{
										SK.Text("TOOLTIPS_LOGOUT_SELECT_TRADE_RESOURCE", "Select Auto-Trade Resource"),
										". ",
										SK.Text("TOOLTIPS_LOGOUT_SELECT_TRADE_RESOURCE_currently", "Currently"),
										" : ",
										VillageBuildingsData.getResourceNames(CustomTooltipManager.currentOverData)
									});
									break;
								case 1408:
									text = SK.Text("TOOLTIPS_LOGOUT_SELECT_TRADE_PERCENT", "Adjust % at which Auto-Trade starts trading ");
									break;
								case 1409:
									text = SK.Text("TOOLTIPS_LOGOUT_ATTACK_BANDITS", "Toggle Auto-Attack Bandit Camps");
									break;
								case 1410:
									text = SK.Text("TOOLTIPS_LOGOUT_ATTACK_WOLVES", "Toggle Auto-Attack Wolf Lairs");
									break;
								case 1411:
									text = SK.Text("TOOLTIPS_LOGOUT_ATTACK_AI", "Toggle Auto-Attack AI Castles");
									break;
								case 1412:
									text = SK.Text("TOOLTIPS_LOGOUT_RECRUIT_PEASANT", "Toggle Auto-Recruit Peasants");
									break;
								case 1413:
									text = SK.Text("TOOLTIPS_LOGOUT_RECRUIT_ARCHER", "Toggle Auto-Recruit Archers");
									break;
								case 1414:
									text = SK.Text("TOOLTIPS_LOGOUT_RECRUIT_PIKEMAN", "Toggle Auto-Recruit Pikemen");
									break;
								case 1415:
									text = SK.Text("TOOLTIPS_LOGOUT_RECRUIT_SWORDSMAN", "Toggle Auto-Recruit Swordsmen");
									break;
								case 1416:
									text = SK.Text("TOOLTIPS_LOGOUT_RECRUIT_CATAPULT", "Toggle Auto-Recruit Catapults");
									break;
								case 1417:
									text = SK.Text("TOOLTIPS_LOGOUT_RESOURCES", "Select Auto-Trade Resource : " + VillageBuildingsData.getResourceNames(CustomTooltipManager.currentOverData));
									break;
								case 1418:
									text = SK.Text("TOOLTIPS_LOGOUT_EXIT", "Exit Stronghold Kingdoms");
									break;
								case 1419:
									text = SK.Text("TOOLTIPS_LOGOUT_CANCEL", "Close logout window without logging out");
									break;
								case 1420:
									text = SK.Text("TOOLTIPS_LOGOUT_SWAP_WORLDS", "Log out of this Game World and return to the World Selection Screen");
									break;
								case 1421:
								{
									int premiumCard = GameEngine.Instance.cardsManager.UserCardData.premiumCard;
									double totalSeconds2 = GameEngine.Instance.cardsManager.UserCardData.premiumCardExpiry.Subtract(VillageMap.getCurrentServerTime()).TotalSeconds;
									double d4 = totalSeconds2 / 86400.0;
									double d5 = totalSeconds2 % 86400.0 / 3600.0;
									double d6 = totalSeconds2 % 3600.0 / 60.0;
									text = string.Concat(new string[]
									{
										SK.Text("TOOLTIPS_LOGOUT_PREMIUM", "Your Premium Token expires in : "),
										Math.Floor(d4).ToString().PadLeft(2, '0'),
										":",
										Math.Floor(d5).ToString().PadLeft(2, '0'),
										":",
										Math.Floor(d6).ToString().PadLeft(2, '0'),
										" (dd:hh:mm)"
									});
									break;
								}
								}
							}
							else
							{
								text = StatsPanel.getCategoryTitle(CustomTooltipManager.currentOverData) + " : " + StatsPanel.getCategoryDescription(CustomTooltipManager.currentOverData);
							}
						}
						else
						{
							text = SK.Text("TOOLTIPS_MENUBAR_ABANDON", "This allows you to disown the selected village, allowing you to make a new village elsewhere, all buildings, resources, units and your castle are lost.");
						}
					}
					else if (ID <= 1600)
					{
						switch (ID)
						{
						case 1500:
							text = SK.Text("TOOLTIPS_REPORTS_FILTER", "Change Report Filtering");
							break;
						case 1501:
							text = SK.Text("TOOLTIPS_REPORTS_CAPTURE", "Change Report Capturing");
							break;
						case 1502:
							text = SK.Text("TOOLTIPS_REPORTS_DELETE", "Report Marking and Deleting options");
							break;
						default:
							if (ID == 1600)
							{
								text = SK.Text("TOOLTIPS_TUTORIAL_REOPEN", "Show Adviser");
							}
							break;
						}
					}
					else if (ID != 1601)
					{
						if (ID - 1700 <= 19)
						{
							int num12 = ID - 1700 + 1;
							NumberFormatInfo nfi2 = GameEngine.NFI;
							text = SK.Text("TOOLTIPS_GLORY_HOUSE", "House") + " " + num12.ToString() + " - ";
							text = text + SK.Text("TOOLTIPS_GLORY_POINTS", "Glory") + " " + CustomTooltipManager.currentOverData.ToString("N", nfi2);
						}
					}
					else
					{
						text = SK.Text("Options_Player_Guide", "Player Guide");
					}
				}
				else if (ID <= 1751)
				{
					if (ID != 1730)
					{
						if (ID != 1750)
						{
							if (ID == 1751)
							{
								int num13 = CustomTooltipManager.currentOverData;
								text = string.Concat(new string[]
								{
									SK.Text("TOOLTIPS_GLORY_HOUSE", "House"),
									" ",
									num13.ToString(),
									" : ",
									SK.Text("TOOLTIPS_EOW_ACTIVE", "House Marshall, you may push the button")
								});
							}
						}
						else
						{
							text = SK.Text("TOOLTIPS_EOW_INACTIVE", "Only a House Marshall, in possession of all the Royal towers, can press this button");
						}
					}
					else
					{
						text = SK.Text("TOOLTIPS_ERA_GLORY_STAR", "A Maximum of 5 Stars are given out each Glory Round");
					}
				}
				else if (ID <= 1900)
				{
					switch (ID)
					{
					case 1800:
						text = SK.Text("TOOLTIPS_NEW_VILLAGE_ENTER", "Choose a starting location for me");
						break;
					case 1801:
						text = SK.Text("TOOLTIPS_NEW_VILLAGE_ADVANCED", "Try and join the game in a particular part of the kingdom");
						break;
					case 1802:
						text = SK.Text("TOOLTIPS_NEW_VILLAGE_LOGOUT", "Log out");
						break;
					default:
						if (ID == 1900)
						{
							text = CapitalDonateResourcesPanel2.capitalTooltipText;
						}
						break;
					}
				}
				else
				{
					switch (ID)
					{
					case 2000:
						text = SK.Text("SendMonksPanel_Influence", "Influence");
						break;
					case 2001:
						text = SK.Text("VillageMapPanel_Blessing", "Blessing");
						break;
					case 2002:
						text = SK.Text("VillageMapPanel_Inquisition", "Inquisition");
						break;
					case 2003:
						text = SK.Text("SendMonksPanel_Interdiction", "Interdiction");
						break;
					case 2004:
						text = SK.Text("SendMonksPanel_Restoration", "Restoration");
						break;
					case 2005:
						text = SK.Text("SendMonksPanel_Absolution", "Absolution");
						break;
					case 2006:
						text = SK.Text("SendMonksPanel_Excommnunication", "Excommunication");
						break;
					case 2007:
						text = SK.Text("SendMonksPanel_Positive_Influence", "Positive Influence");
						break;
					case 2008:
						text = SK.Text("SendMonksPanel_Negative_Influence", "Negative Influence");
						break;
					case 2009:
					case 2010:
					case 2011:
					case 2012:
					case 2013:
					case 2014:
					case 2015:
					case 2016:
					case 2017:
						break;
					case 2018:
						text = SK.Text("TOOLTIPS_FAVOURITE_ATTACK_TARGET_MAKE", "Mark this village as a Favourite");
						break;
					default:
						switch (ID)
						{
						case 2100:
							text = SK.Text("LaunchAttackPopup_Vandalise", "Vandalise");
							break;
						case 2101:
							text = SK.Text("GENERIC_Capture", "Capture");
							break;
						case 2102:
							text = SK.Text("GENERIC_Pillage", "Pillage");
							break;
						case 2103:
							text = SK.Text("GENERIC_Ransack", "Ransack");
							break;
						case 2104:
							text = SK.Text("GENERIC_Raze", "Raze");
							break;
						case 2105:
							text = SK.Text("GENERIC_Gold_Raid", "Gold Raid");
							break;
						case 2106:
							text = SK.Text("GENERIC_Attack", "Attack");
							break;
						case 2107:
							text = SK.Text("TOOLTIPS_FAVOURITE_ATTACK_TARGET_CLEAR", "Remove this village from your Favourites");
							break;
						}
						break;
					}
				}
			}
			else
			{
				if (ID <= 10005)
				{
					if (ID <= 3004)
					{
						if (ID <= 2506)
						{
							switch (ID)
							{
							case 2300:
								text = SK.Text("TOOLTIPS_FACTIONTAB_GLORY", "Click to View the Glory Screen");
								goto IL_5E78;
							case 2301:
								text = SK.Text("TOOLTIPS_FACTIONTAB_FACTIONS", "Click to View the Faction Screens");
								goto IL_5E78;
							case 2302:
								text = SK.Text("TOOLTIPS_FACTIONTAB_HOUSE", "Click to View the House Screens");
								goto IL_5E78;
							case 2303:
								text = SK.Text("GENERIC_Ally", "Ally");
								goto IL_5E78;
							case 2304:
								text = SK.Text("GENERIC_Enemy", "Enemy");
								goto IL_5E78;
							case 2305:
								text = SK.Text("TOOLTIPS_FACTION_LEADER", "Faction Leader");
								goto IL_5E78;
							case 2306:
								text = SK.Text("TOOLTIPS_FACTION_OFFICER", "Faction Officer");
								goto IL_5E78;
							case 2307:
								text = SK.Text("STATS_CATEGORY_TITLE_HOUSE", "House") + " " + CustomTooltipManager.currentOverData.ToString();
								goto IL_5E78;
							case 2308:
							{
								HouseData houseData = null;
								try
								{
									houseData = GameEngine.Instance.World.HouseInfo[CustomTooltipManager.currentOverData];
								}
								catch (Exception)
								{
								}
								int gloryRank = GameEngine.Instance.World.getGloryRank(CustomTooltipManager.currentOverData);
								text = string.Concat(new string[]
								{
									SK.Text("STATS_CATEGORY_TITLE_HOUSE", "House"),
									" ",
									CustomTooltipManager.currentOverData.ToString(),
									Environment.NewLine,
									"\"",
									CustomTooltipManager.getHouseMotto(CustomTooltipManager.currentOverData),
									"\"",
									Environment.NewLine,
									Environment.NewLine
								});
								if (gloryRank < 0)
								{
									text += SK.Text("FactionInvites_Glory_Eliminatated", "Eliminated From Glory Race");
									goto IL_5E78;
								}
								NumberFormatInfo nfi3 = GameEngine.NFI;
								string text4 = text;
								text = string.Concat(new string[]
								{
									text4,
									SK.Text("FactionInvites_Glory_Rank", "Glory Rank"),
									" : ",
									(gloryRank + 1).ToString(),
									Environment.NewLine
								});
								text = text + SK.Text("FactionInvites_Glory_Points", "Glory Points") + " : " + GameEngine.Instance.World.getGloryPoints(CustomTooltipManager.currentOverData).ToString("N", nfi3);
								if (houseData != null && houseData.numVictories > 0)
								{
									text4 = text;
									text = string.Concat(new string[]
									{
										text4,
										Environment.NewLine,
										Environment.NewLine,
										SK.Text("FactionInvites_Glory Victories", "Glory Victories"),
										" : ",
										houseData.numVictories.ToString()
									});
									goto IL_5E78;
								}
								goto IL_5E78;
							}
							default:
								switch (ID)
								{
								case 2350:
									text = SK.Text("FACTION_SIDEBAR_SHOW_ALL", "A List of All Factions in the Game World");
									goto IL_5E78;
								case 2351:
									text = SK.Text("FACTION_SIDEBAR_MY_FACTION", "Details of Your Faction");
									goto IL_5E78;
								case 2352:
									text = SK.Text("FACTION_SIDEBAR_DIPLOMACY", "Your Faction's Relationship to Other Factions");
									goto IL_5E78;
								case 2353:
									text = SK.Text("FACTION_SIDEBAR_OFFICERS", "Manage Your Faction and View the List of Officers");
									goto IL_5E78;
								case 2354:
									text = SK.Text("FACTION_SIDEBAR_FORUM", "Your Faction's Forum");
									goto IL_5E78;
								case 2355:
									text = SK.Text("FACTION_SIDEBAR_MAIL", "Send a Mail to Everyone in Your Faction");
									goto IL_5E78;
								case 2356:
									text = SK.Text("FACTION_SIDEBAR_INVITES", "Details of Your Faction Invites and Applications");
									goto IL_5E78;
								case 2357:
									text = SK.Text("FACTION_SIDEBAR_CHAT", "Your Faction's Chat Channel");
									goto IL_5E78;
								case 2358:
									text = SK.Text("FACTION_SIDEBAR_START", "Start a New Faction");
									goto IL_5E78;
								case 2359:
									text = SK.Text("FACTION_SIDEBAR_LEAVE", "Leave your current Faction");
									goto IL_5E78;
								case 2360:
								case 2361:
								case 2362:
								case 2363:
								case 2364:
								case 2365:
								case 2366:
								case 2367:
								case 2368:
								case 2369:
								case 2370:
								case 2371:
								case 2372:
								case 2373:
								case 2374:
								case 2375:
								case 2376:
								case 2377:
								case 2378:
								case 2379:
								case 2380:
								case 2381:
								case 2382:
								case 2383:
								case 2384:
								case 2385:
								case 2386:
								case 2387:
								case 2388:
								case 2389:
								case 2390:
								case 2391:
								case 2392:
								case 2393:
								case 2394:
								case 2395:
								case 2396:
								case 2397:
								case 2398:
								case 2399:
								case 2408:
								case 2409:
								case 2415:
								case 2416:
								case 2417:
								case 2418:
								case 2419:
									goto IL_5E78;
								case 2400:
									text = SK.Text("GENERIC_Cancel", "Cancel");
									goto IL_5E78;
								case 2401:
									text = SK.Text("GENERIC_Select_Target", "Select Target");
									goto IL_5E78;
								case 2402:
									text = SK.Text("GENERIC_Select_Target", "Select Target");
									goto IL_5E78;
								case 2403:
									text = SK.Text("TradeWithPanel_Trade_With", "Trade With");
									goto IL_5E78;
								case 2404:
									text = SK.Text("StockExchangeSidePanel_Select_Exchange", "Select Exchange");
									goto IL_5E78;
								case 2405:
									text = SK.Text("MonkTargetSidePanel_Select_Target", "Select Target");
									goto IL_5E78;
								case 2406:
									text = SK.Text("MonkTargetSidePanel_Select_Target", "Select Target");
									goto IL_5E78;
								case 2407:
									text = SK.Text("VassalSelectSidePanel_Select_Vassal", "Select Vassal");
									goto IL_5E78;
								case 2410:
									text = SK.Text("TradeWithPanel_Trade_With", "Trade With");
									goto IL_5E78;
								case 2411:
									text = SK.Text("GENERIC_Attack", "Attack");
									goto IL_5E78;
								case 2412:
									text = SK.Text("GENERIC_Scout_Out_Village", "Scout Out Village");
									goto IL_5E78;
								case 2413:
									text = SK.Text("GENERIC_Send_Troops", "Send Troops");
									goto IL_5E78;
								case 2414:
									text = SK.Text("GENERIC_Send_Monks", "Send Monks");
									goto IL_5E78;
								case 2420:
									text = SK.Text("GENERIC_Parish", "Parish");
									goto IL_5E78;
								case 2421:
									text = SK.Text("GENERIC_County", "County");
									goto IL_5E78;
								case 2422:
									text = SK.Text("GENERIC_Province", "Province");
									goto IL_5E78;
								case 2423:
									text = SK.Text("GENERIC_Country", "Country");
									goto IL_5E78;
								case 2424:
									text = SK.Text("GENERIC_Bandit_Camp", "Bandit Camp");
									goto IL_5E78;
								case 2425:
									text = SK.Text("GENERIC_Wolf_Camp", "Wolf Lair");
									goto IL_5E78;
								case 2426:
									text = SK.Text("GENERIC_Rats_Castle", "Rat's Castle");
									goto IL_5E78;
								case 2427:
									text = SK.Text("GENERIC_Snakes_Castle", "Snake's Castle");
									goto IL_5E78;
								case 2428:
									text = SK.Text("GENERIC_Pigs_Castle", "Pig's Castle");
									goto IL_5E78;
								case 2429:
									text = SK.Text("GENERIC_Wolfs_Castle", "Wolf's Castle");
									goto IL_5E78;
								case 2430:
									text = SpecialVillageTypes.getName(CustomTooltipManager.currentOverData, "");
									goto IL_5E78;
								case 2431:
									text = SK.Text("OwnVillagePanel_Send_Out_Resources", "Send Out Resources");
									goto IL_5E78;
								case 2432:
									text = SK.Text("OwnVillagePanel_Send_Out_Troops", "Send Out Troops");
									goto IL_5E78;
								case 2433:
									text = SK.Text("OwnVillagePanel_Send_Out_Scouts", "Send Out Scouts");
									goto IL_5E78;
								case 2434:
									text = SK.Text("OwnVillagePanel_Send_Out_Reinforcements", "Send Out Reinforcements");
									goto IL_5E78;
								case 2435:
									text = SK.Text("OwnVillagePanel_Send_Out_Monks", "Send Out Monks");
									goto IL_5E78;
								case 2436:
									switch (CustomTooltipManager.currentOverData)
									{
									case 0:
										text = SK.Text("MapTypes_Lowland", "Lowland");
										goto IL_5E78;
									case 1:
										text = SK.Text("MapTypes_Highland", "Highland");
										goto IL_5E78;
									case 2:
										text = SK.Text("MapTypes_River", "River") + " 1";
										goto IL_5E78;
									case 3:
										text = SK.Text("MapTypes_River", "River") + " 2";
										goto IL_5E78;
									case 4:
										text = SK.Text("MapTypes_Mountain_Peak", "Mountain Peak");
										goto IL_5E78;
									case 5:
										text = SK.Text("MapTypes_Salt_Flat", "Salt Flat");
										goto IL_5E78;
									case 6:
										text = SK.Text("MapTypes_Marsh", "Marsh");
										goto IL_5E78;
									case 7:
										text = SK.Text("MapTypes_Plains", "Plains");
										goto IL_5E78;
									case 8:
										text = SK.Text("MapTypes_Valley_Side", "Valley Side");
										goto IL_5E78;
									case 9:
										text = SK.Text("MapTypes_Forest", "Forest");
										goto IL_5E78;
									default:
										goto IL_5E78;
									}
									break;
								case 2437:
									text = SK.Text("TOOLTIPS_View_Village", "View Village");
									goto IL_5E78;
								case 2438:
									text = SK.Text("TOOLTIPS_View_Castle", "View Castle");
									goto IL_5E78;
								case 2439:
									text = SK.Text("TOOLTIPS_View_Resources", "View Resources");
									goto IL_5E78;
								case 2440:
									text = SK.Text("TOOLTIPS_Make_Troops", "Make Troops");
									goto IL_5E78;
								case 2441:
									text = SK.Text("CapitalTradePanel_", "Purchase Goods");
									goto IL_5E78;
								case 2442:
									text = SK.Text("CapitalBarracksPanel_Mercenaries", "Mercenaries");
									goto IL_5E78;
								case 2443:
									text = SK.Text("TOOLTIPS_Scout_Stash", "Scout Stash");
									goto IL_5E78;
								case 2444:
									text = SK.Text("EmptyVillagePanel_Available_Village", "New Village Charter");
									goto IL_5E78;
								case 2445:
									text = SK.Text("TOOLTIPS_View_Castle_Report", "View most recent report of this Castle");
									goto IL_5E78;
								case 2446:
									text = SK.Text("OtherVillagePanel_Make_Vassal", "Make Vassal");
									goto IL_5E78;
								case 2447:
									text = SK.Text("GENERIC_Paladin_Castle", "Paladin's Castle");
									goto IL_5E78;
								case 2448:
									text = SK.Text("GENERIC_Paladin_Castle", "Paladin's Castle");
									goto IL_5E78;
								case 2449:
									text = SpecialVillageTypes.getName(CustomTooltipManager.currentOverData, "");
									goto IL_5E78;
								case 2450:
									text = string.Concat(new string[]
									{
										SK.Text("GENERIC_Parish_Plague", "Disease Infested Parish"),
										" : ",
										InterfaceMgr.Instance.getPlagueText(CustomTooltipManager.currentOverData),
										"  (",
										CustomTooltipManager.currentOverData.ToString(),
										")"
									});
									goto IL_5E78;
								case 2451:
									text = SK.Text("VassalVillagePanel_Manage_Vassal_Troops", "Manage Vassal's Troops");
									goto IL_5E78;
								case 2452:
									text = SK.Text("VassalVillagePanel_Manage_Vassal", "Manage Vassal");
									goto IL_5E78;
								case 2453:
									text = SK.Text("VassalVillagePanel_Attack_From_Here", "Attack From Here");
									goto IL_5E78;
								case 2454:
									text = SK.Text("TOOLTIPS_Filter_Traders", "Show only Traders");
									goto IL_5E78;
								case 2455:
									text = SK.Text("TOOLTIPS_Filter_Attacks", "Show only Attacking Troops");
									goto IL_5E78;
								case 2456:
									text = SK.Text("TOOLTIPS_Filter_Foraging", "Show only Foraging Scouts");
									goto IL_5E78;
								case 2457:
									text = SK.Text("TOOLTIPS_Filter_House", "Show only villages in your House");
									goto IL_5E78;
								case 2458:
									text = SK.Text("TOOLTIPS_Filter_Faction", "Show only villages in your Faction");
									goto IL_5E78;
								case 2459:
									text = SK.Text("TOOLTIPS_Clear_Filter", "Clear Filter");
									goto IL_5E78;
								case 2460:
									text = SK.Text("TOOLTIPS_village_search", "Search For Villages");
									goto IL_5E78;
								case 2461:
									text = SK.Text("TOOLTIPS_Filter_Faction_Open", "Show only villages in Factions accepting Invitations");
									goto IL_5E78;
								case 2462:
									text = SK.Text("TOOLTIPS_Filter_AI", "Show only attackable Wolf Camps, Bandit Camps and AI Castles");
									goto IL_5E78;
								default:
									switch (ID)
									{
									case 2501:
										text = GameEngine.Instance.World.getFactionName(CustomTooltipManager.currentOverData);
										goto IL_5E78;
									case 2502:
										text = SK.Text("MailScreen_Send_Mail", "Send Mail");
										goto IL_5E78;
									case 2503:
									{
										if (CustomTooltipManager.UserInfo == null)
										{
											text = "";
											goto IL_5E78;
										}
										NumberFormatInfo nfi4 = GameEngine.NFI;
										text = SK.Text("STATS_CATEGORY_TITLE_RANK", "Rank") + " : ";
										text = ((CustomTooltipManager.UserInfo.avatarData == null) ? (text + Rankings.getRankingName(CustomTooltipManager.UserInfo.rank)) : (text + Rankings.getRankingName(CustomTooltipManager.UserInfo.rank, CustomTooltipManager.UserInfo.avatarData.male)));
										text += Environment.NewLine;
										string text5 = text;
										text = string.Concat(new string[]
										{
											text5,
											SK.Text("GENERIC_Villages", "Villages"),
											" : ",
											CustomTooltipManager.UserInfo.numVillages.ToString("N", nfi4),
											Environment.NewLine
										});
										text5 = text;
										text = string.Concat(new string[]
										{
											text5,
											SK.Text("UserInfoPanel_Points", "Points"),
											" : ",
											CustomTooltipManager.UserInfo.points.ToString("N", nfi4),
											Environment.NewLine
										});
										if (CustomTooltipManager.UserInfo.standing >= 0)
										{
											text = text + SK.Text("UserInfoPanel_Position", "Position") + " : " + CustomTooltipManager.UserInfo.standing.ToString("N", nfi4);
											goto IL_5E78;
										}
										goto IL_5E78;
									}
									case 2504:
										text = SK.Text("TOOLTIPS_MAPSIDE_BUY_CHARTER_RANK_TOO_LOW", "You can't own more villages at this time due your current Rank or your Leadership Research level.");
										goto IL_5E78;
									case 2505:
										text = SK.Text("TOOLTIPS_MAPSIDE_CANT_BUY_FROM_HERE", "You cannot purchase other villages from your currently selected village.");
										goto IL_5E78;
									case 2506:
										text = SK.Text("TOOLTIPS_MAPSIDE_BUY_CHARTER_RANK_TOO_LOW12", "You need to be rank 12 to own more villages.");
										goto IL_5E78;
									default:
										goto IL_5E78;
									}
									break;
								}
								break;
							}
						}
						else if (ID <= 2800)
						{
							if (ID != 2700)
							{
								if (ID != 2800)
								{
									goto IL_5E78;
								}
								text = SK.Text("TOOLTIPS_VASSAL_AVAILABLE_TROOPS", "Available Troops");
								goto IL_5E78;
							}
							else
							{
								text = "";
								bool flag2 = false;
								if ((CustomTooltipManager.currentOverData & 1) != 0)
								{
									if (flag2)
									{
										text += Environment.NewLine;
									}
									text += SK.Text("TOOLTIPS_UNIT_MAKE_ERROR_PEASANTS", "- No Peasants Available");
									flag2 = true;
								}
								if ((CustomTooltipManager.currentOverData & 2) != 0)
								{
									if (flag2)
									{
										text += Environment.NewLine;
									}
									text += SK.Text("TOOLTIPS_UNIT_MAKE_ERROR_GOLD", "- Not enough Gold");
									flag2 = true;
								}
								if ((CustomTooltipManager.currentOverData & 32) != 0)
								{
									if (flag2)
									{
										text += Environment.NewLine;
									}
									text += SK.Text("TOOLTIPS_UNIT_MAKE_ERROR_TROOP_SPACE", "- Not enough Army Space");
									flag2 = true;
								}
								else if ((CustomTooltipManager.currentOverData & 4) != 0)
								{
									if (flag2)
									{
										text += Environment.NewLine;
									}
									text += SK.Text("TOOLTIPS_UNIT_MAKE_ERROR_SPACE", "- Not enough Unit Space");
									flag2 = true;
								}
								if ((CustomTooltipManager.currentOverData & 8) != 0)
								{
									if (flag2)
									{
										text += Environment.NewLine;
									}
									text += SK.Text("TOOLTIPS_UNIT_MAKE_ERROR_FULL", "- You have made the Maximum amount");
									flag2 = true;
								}
								if ((CustomTooltipManager.currentOverData & 16) != 0)
								{
									if (flag2)
									{
										text += Environment.NewLine;
									}
									text += SK.Text("TOOLTIPS_UNIT_MAKE_ERROR_WEAPON", "- No Weapons Available");
									goto IL_5E78;
								}
								goto IL_5E78;
							}
						}
						else
						{
							switch (ID)
							{
							case 2900:
								text = SK.Text("TOOLTIPS_ARMIES_ATTACKS", "View All Attacks");
								goto IL_5E78;
							case 2901:
								text = SK.Text("TOOLTIPS_ARMIES_SCOUTS", "View All Scouts");
								goto IL_5E78;
							case 2902:
								text = SK.Text("TOOLTIPS_ARMIES_REINFORCEMENTS", "View All Reinforcements");
								goto IL_5E78;
							case 2903:
								text = SK.Text("TOOLTIPS_ARMIES_MERCHANTS", "View All Merchants");
								goto IL_5E78;
							case 2904:
								text = SK.Text("TOOLTIPS_ARMIES_MONKS", "View All Monks");
								goto IL_5E78;
							case 2905:
								switch (CustomTooltipManager.currentOverData)
								{
								case 1:
									text = SK.Text("TOOLTIPS_ARMIES_SORTING_FROM", "Sort By Target Village");
									goto IL_5E78;
								case 2:
									text = SK.Text("TOOLTIPS_ARMIES_SORTING_HOME", "Sort By Source Village");
									goto IL_5E78;
								case 3:
									text = SK.Text("TOOLTIPS_ARMIES_SORTING_PEASANTS", "Sort By Number of Peasants");
									goto IL_5E78;
								case 4:
									text = SK.Text("TOOLTIPS_ARMIES_SORTING_ARCHERS", "Sort By Number of Archers");
									goto IL_5E78;
								case 5:
									text = SK.Text("TOOLTIPS_ARMIES_SORTING_PIKEMEN", "Sort By Number of Pikemen");
									goto IL_5E78;
								case 6:
									text = SK.Text("TOOLTIPS_ARMIES_SORTING_SWORDSMEN", "Sort By Number of Swordsmen");
									goto IL_5E78;
								case 7:
									text = SK.Text("TOOLTIPS_ARMIES_SORTING_CATAPULTS", "Sort By Number of Catapults");
									goto IL_5E78;
								case 8:
									text = SK.Text("TOOLTIPS_ARMIES_SORTING_TIME", "Sort By Arrival Time");
									goto IL_5E78;
								case 9:
									text = SK.Text("TOOLTIPS_ARMIES_SORTING_SCOUTS", "Sort By Scouts");
									goto IL_5E78;
								case 10:
									text = SK.Text("TOOLTIPS_ARMIES_SORTING_TRADE_AMOUNT", "Sort By Trade Size");
									goto IL_5E78;
								case 11:
									text = SK.Text("TOOLTIPS_ARMIES_SORTING_TRADE_COMMAND", "Sort By Trade Status");
									goto IL_5E78;
								case 12:
									text = SK.Text("TOOLTIPS_ARMIES_SORTING_MONKS", "Sort By Number of Monks");
									goto IL_5E78;
								case 13:
									text = SK.Text("TOOLTIPS_ARMIES_SORTING_MONKS_COMMAND", "Sort By Monk Command");
									goto IL_5E78;
								case 14:
								case 15:
								case 16:
								case 17:
								case 18:
								case 19:
									goto IL_5E78;
								case 20:
									text = SK.Text("TOOLTIPS_ARMIES_SORTING_CAPTAINS", "Sort By Number of Captains");
									goto IL_5E78;
								default:
									goto IL_5E78;
								}
								break;
							default:
							{
								if (ID - 3001 > 3)
								{
									goto IL_5E78;
								}
								int achievement = CustomTooltipManager.currentOverData & 4095;
								string achievementRank = CustomTooltipManager.getAchievementRank(CustomTooltipManager.currentOverData);
								int num14 = CustomTooltipManager.currentOverData & 1879048192;
								int num15;
								if (num14 <= 1073741824)
								{
									if (num14 == 268435456)
									{
										num15 = 1;
										goto IL_42AA;
									}
									if (num14 == 536870912)
									{
										num15 = 2;
										goto IL_42AA;
									}
									if (num14 == 1073741824)
									{
										num15 = 3;
										goto IL_42AA;
									}
								}
								else
								{
									if (num14 == 1342177280)
									{
										num15 = 4;
										goto IL_42AA;
									}
									if (num14 == 1610612736)
									{
										num15 = 5;
										goto IL_42AA;
									}
									if (num14 == 1879048192)
									{
										num15 = 6;
										goto IL_42AA;
									}
								}
								num15 = 0;
								IL_42AA:
								if (ID == 3001)
								{
									num15 = -1;
								}
								string achievementTitle = CustomTooltipManager.getAchievementTitle(achievement);
								string achievementRequirement = CustomTooltipManager.getAchievementRequirement(achievement, num15);
								string achievementRequirement2 = CustomTooltipManager.getAchievementRequirement(achievement, num15 + 1);
								int num16 = 1;
								bool flag3 = true;
								if (ID == 3001 || ID == 3002)
								{
									flag3 = false;
								}
								else
								{
									num16 = RankingsPanel.getProgressValue(achievement);
								}
								NumberFormatInfo nfi5 = GameEngine.NFI;
								if (num15 >= 0 && num15 <= 5 && achievementRequirement2.Length > 0)
								{
									text = string.Concat(new string[]
									{
										achievementTitle,
										Environment.NewLine,
										achievementRank,
										Environment.NewLine,
										achievementRequirement,
										Environment.NewLine,
										Environment.NewLine,
										SK.Text("Achievements_NextLevel", "Next Level"),
										Environment.NewLine,
										achievementRequirement2
									});
									if (flag3 && num16 > 0)
									{
										string text6 = text;
										text = string.Concat(new string[]
										{
											text6,
											Environment.NewLine,
											Environment.NewLine,
											SK.Text("Achievements_CurrentProgress", "Current Progress"),
											" : ",
											num16.ToString("N", nfi5)
										});
										goto IL_5E78;
									}
									goto IL_5E78;
								}
								else if (num15 < 0)
								{
									text = string.Concat(new string[]
									{
										achievementTitle,
										Environment.NewLine,
										SK.Text("Achievements_NoLevel", "No Achievements Earned"),
										Environment.NewLine,
										achievementRequirement2
									});
									if (flag3 && num16 > 0)
									{
										string text7 = text;
										text = string.Concat(new string[]
										{
											text7,
											Environment.NewLine,
											Environment.NewLine,
											SK.Text("Achievements_CurrentProgress", "Current Progress"),
											" : ",
											num16.ToString("N", nfi5)
										});
										goto IL_5E78;
									}
									goto IL_5E78;
								}
								else
								{
									if (num15 >= 3 && achievementRequirement2.Length == 0)
									{
										text = string.Concat(new string[]
										{
											achievementTitle,
											Environment.NewLine,
											achievementRank,
											Environment.NewLine,
											achievementRequirement
										});
										goto IL_5E78;
									}
									goto IL_5E78;
								}
								break;
							}
							}
						}
					}
					else if (ID <= 4140)
					{
						switch (ID)
						{
						case 3101:
							text = "Admin Functions";
							goto IL_5E78;
						case 3102:
							text = SK.Text("TOOLTIPS_USER_CLEAR_DIPLOMACY", "Remove Diplomatic Status for this Player");
							goto IL_5E78;
						case 3103:
							text = SK.Text("TOOLTIPS_USER_CLEAR_DIPLOMACY_NOTES", "Edit Notes for this Player");
							goto IL_5E78;
						default:
							switch (ID)
							{
							case 3201:
								text = SK.Text("TOOLTIPS_START_QUEST", "Start this quest");
								goto IL_5E78;
							case 3202:
								text = SK.Text("TOOLTIPS_ABANDON_QUEST", "Abandon this quest and remove it from the list.");
								goto IL_5E78;
							case 3203:
								text = SK.Text("TOOLTIPS_QUEST_REWARD_HONOUR", "Honour");
								goto IL_5E78;
							case 3204:
								text = SK.Text("TOOLTIPS_QUEST_REWARD_GOLD", "Gold");
								goto IL_5E78;
							case 3205:
								text = SK.Text("TOOLTIPS_QUEST_REWARD_WOOD", "Wood");
								goto IL_5E78;
							case 3206:
								text = SK.Text("TOOLTIPS_QUEST_REWARD_STONE", "Stone");
								goto IL_5E78;
							case 3207:
								text = SK.Text("TOOLTIPS_QUEST_REWARD_APPLES", "Apples");
								goto IL_5E78;
							case 3208:
								text = SK.Text("TOOLTIPS_QUEST_REWARD_CARD_PACKS", "Card Packs");
								goto IL_5E78;
							case 3209:
								text = SK.Text("TOOLTIPS_QUEST_REWARD_PREMIUM_CARD", "2 Day Premium Token");
								goto IL_5E78;
							case 3210:
								text = SK.Text("TOOLTIPS_QUEST_REWARD_FAITHPOINTS", "Faith Points");
								goto IL_5E78;
							case 3211:
								text = SK.Text("TOOLTIPS_QUEST_REWARD_GLORY", "Glory");
								goto IL_5E78;
							case 3212:
								text = SK.Text("TOOLTIPS_QUEST_REWARD_SHIELD_CHARGES", "A new Charge for your Shield");
								goto IL_5E78;
							case 3213:
								text = SK.Text("TOOLTIPS_QUEST_REWARD_TICKETS", "Quest Wheel Spins");
								goto IL_5E78;
							case 3214:
								text = SK.Text("ResourceType_Fish", "Fish");
								goto IL_5E78;
							default:
								switch (ID)
								{
								case 4001:
									text = SK.Text("TOOLTIPS_LOGIN_ENGLISH_SUPPORT", "Customer Support for this world is in English");
									goto IL_5E78;
								case 4002:
									text = SK.Text("TOOLTIPS_LOGIN_GERMAN_SUPPORT", "Customer Support for this world is in German");
									goto IL_5E78;
								case 4003:
									text = SK.Text("TOOLTIPS_LOGIN_FRENCH_SUPPORT", "Customer Support for this world is in French");
									goto IL_5E78;
								case 4004:
									text = SK.Text("TOOLTIPS_LOGIN_RUSSIAN_SUPPORT", "Customer Support for this world is in Russian");
									goto IL_5E78;
								case 4005:
									text = SK.Text("TOOLTIPS_LOGIN_MAP_OF_ENGLAND", "The map of this world is centred around Great Britain");
									goto IL_5E78;
								case 4006:
									text = SK.Text("TOOLTIPS_LOGIN_MAP_OF_GERMANY", "The map of this world is centred around Germany");
									goto IL_5E78;
								case 4007:
									text = SK.Text("TOOLTIPS_LOGIN_MAP_OF_FRANCE", "The map of this world is centred around France");
									goto IL_5E78;
								case 4008:
									text = SK.Text("TOOLTIPS_LOGIN_MAP_OF_RUSSIA", "The map of this world is centred around Russia");
									goto IL_5E78;
								case 4009:
									text = SK.Text("TOOLTIPS_LOGIN_OFFLINE", "This world is currently Offline, most likely due to server maintenance and should be back Online soon.");
									goto IL_5E78;
								case 4010:
									text = SK.Text("TOOLTIPS_LOGIN_ONLINE", "This world is currently Online");
									goto IL_5E78;
								case 4011:
									text = SK.Text("TOOLTIPS_LOGIN_ENGLISH_FLAG", "View available worlds with English Support");
									goto IL_5E78;
								case 4012:
									text = SK.Text("TOOLTIPS_LOGIN_GERMAN_FLAG", "View available worlds with German Support");
									goto IL_5E78;
								case 4013:
									text = SK.Text("TOOLTIPS_LOGIN_FRENCH_FLAG", "View available worlds with French Support");
									goto IL_5E78;
								case 4014:
									text = SK.Text("TOOLTIPS_LOGIN_RUSSIAN_FLAG", "View available worlds with Russian Support");
									goto IL_5E78;
								case 4015:
									text = SK.Text("TOOLTIPS_LOGIN_EDIT_SHIELD", "Click to Edit Your Coat of Arms");
									goto IL_5E78;
								case 4016:
									text = SK.Text("TOOLTIPS_LOGIN_SPANISH_SUPPORT", "Customer Support for this world is in Spanish");
									goto IL_5E78;
								case 4017:
									text = SK.Text("TOOLTIPS_LOGIN_MAP_OF_SPAIN", "The map of this world is centred around Spain");
									goto IL_5E78;
								case 4018:
									text = SK.Text("TOOLTIPS_LOGIN_SPANISH_FLAG", "View available worlds with Spanish Support");
									goto IL_5E78;
								case 4019:
									text = SK.Text("TOOLTIPS_LOGIN_SECOND_AGE", "This World is in its Second Age.");
									goto IL_5E78;
								case 4020:
									text = SK.Text("TOOLTIPS_LOGIN_POLISH_SUPPORT", "Customer Support for this world is in Polish");
									goto IL_5E78;
								case 4021:
									text = SK.Text("TOOLTIPS_LOGIN_MAP_OF_POLAND", "The map of this world is Poland");
									goto IL_5E78;
								case 4022:
									text = SK.Text("LOGIN_POLISH_FLAG", "View available worlds with Polish Support");
									goto IL_5E78;
								case 4023:
									text = SK.Text("TOOLTIPS_LOGIN_TURKISH_SUPPORT", "Customer Support for this world is in Turkish");
									goto IL_5E78;
								case 4024:
									text = SK.Text("TOOLTIPS_LOGIN_MAP_OF_TURKEY", "The map of this world is Turkey");
									goto IL_5E78;
								case 4025:
									text = SK.Text("TOOLTIP_LOGIN_TURKISH_FLAG", "View available worlds with Turkish Support");
									goto IL_5E78;
								case 4026:
									text = SK.Text("TOOLTIPS_LOGIN_THIRD_AGE", "This World is in its Third Age.");
									goto IL_5E78;
								case 4027:
									text = SK.Text("TOOLTIPS_LOGIN_ITALIAN_SUPPORT", "Customer Support for this world is in Italian");
									goto IL_5E78;
								case 4028:
									text = SK.Text("TOOLTIPS_LOGIN_MAP_OF_ITALY", "The map of this world is centred around Italy and the Adriatic");
									goto IL_5E78;
								case 4029:
									text = SK.Text("TOOLTIP_LOGIN_ITALIAN_FLAG", "View available worlds with Italian Support");
									goto IL_5E78;
								case 4030:
									text = SK.Text("TOOLTIPS_LOGIN_MAP_OF_USA", "The map of this world is the USA");
									goto IL_5E78;
								case 4031:
								case 4041:
									text = SK.Text("TOOLTIPS_LOGIN_EUROPE_SUPPORT", "Customer Support for this world is available in all currently supported languages");
									goto IL_5E78;
								case 4032:
									text = SK.Text("TOOLTIPS_LOGIN_MAP_OF_EUROPE", "The map of this world is Europe");
									goto IL_5E78;
								case 4033:
									text = SK.Text("TOOLTIP_LOGIN_EUROPEAN_FLAG", "View available worlds with the European Map");
									goto IL_5E78;
								case 4034:
									text = SK.Text("TOOLTIPS_LOGIN_FOURTH_AGE", "This World is in its Fourth Age.");
									goto IL_5E78;
								case 4035:
									text = SK.Text("TOOLTIPS_LOGIN_PORTUGUESE_SUPPORT", "Customer Support for this world is in Brazilian Portuguese and Spanish");
									goto IL_5E78;
								case 4036:
									text = SK.Text("TOOLTIPS_LOGIN_MAP_OF_SOUTH_AMERICA", "The map of this world is Central and South America");
									goto IL_5E78;
								case 4037:
									text = SK.Text("TOOLTIP_LOGIN_PORTUGUESE_FLAG", "View available worlds with Brazilian-Portuguese Support");
									goto IL_5E78;
								case 4038:
									text = SK.Text("TOOLTIPS_LOGIN_FIRST_AGE", "This World is in its First Age. It is recommended that new players join a world that in its First Age.");
									goto IL_5E78;
								case 4039:
									text = SK.Text("TOOLTIPS_LOGIN_FIFTH_AGE", "This World is in its Fifth Age.");
									goto IL_5E78;
								case 4040:
									text = SK.Text("TOOLTIP_LOGIN_WORLD_FLAG", "View available worlds with the Global Conflict Map");
									goto IL_5E78;
								case 4042:
									text = SK.Text("TOOLTIPS_LOGIN_MAP_OF_WORLD", "The map of this world is Global Conflict");
									goto IL_5E78;
								case 4043:
									text = SK.Text("TOOLTIPS_LOGIN_MAP_OF_PHILIPPINES", "The map of this world is Island Warfare: Philippines");
									goto IL_5E78;
								case 4044:
									text = SK.Text("TOOLTIPS_LOGIN_SIXTH_AGE", "This World is in its Sixth Age.");
									goto IL_5E78;
								case 4045:
									text = SK.Text("TOOLTIPS_LOGIN_SEVENTH_AGE", "This World is in its Final Age.");
									goto IL_5E78;
								case 4046:
									text = SK.Text("TOOLTIPS_LOGIN_CHINESE_SUPPORT", "Customer Support for this world is in Chinese");
									goto IL_5E78;
								case 4047:
									text = SK.Text("TOOLTIPS_LOGIN_MAP_OF_CHINA", "The map of this world is centred around China");
									goto IL_5E78;
								case 4048:
									text = SK.Text("TOOLTIP_LOGIN_CHINESE_FLAG", "View available worlds with Chinese Support");
									goto IL_5E78;
								case 4049:
									text = SK.Text("TOOLTIPS_LOGIN_MAP_OF_KINGMAKER", "The map of this world is Medieval Europe");
									goto IL_5E78;
								case 4050:
								case 4051:
								case 4052:
								case 4053:
								case 4054:
								case 4055:
								case 4056:
								case 4057:
								case 4058:
								case 4059:
								case 4060:
								case 4061:
								case 4062:
								case 4063:
								case 4064:
								case 4065:
								case 4066:
								case 4067:
								case 4068:
								case 4069:
								case 4070:
								case 4071:
								case 4072:
								case 4073:
								case 4074:
								case 4075:
								case 4076:
								case 4077:
								case 4078:
								case 4079:
								case 4080:
								case 4081:
								case 4082:
								case 4083:
								case 4084:
								case 4085:
								case 4086:
								case 4087:
								case 4088:
								case 4089:
								case 4090:
								case 4091:
								case 4092:
								case 4093:
								case 4094:
								case 4095:
								case 4096:
								case 4097:
								case 4098:
								case 4099:
								case 4129:
								case 4130:
								case 4131:
								case 4132:
								case 4133:
								case 4134:
								case 4135:
								case 4136:
								case 4137:
								case 4138:
								case 4139:
									goto IL_5E78;
								case 4100:
									text = SK.Text("BARRACKS_Troops", "Troops");
									goto IL_5E78;
								case 4101:
									text = SK.Text("GENERIC_Scouts", "Scouts");
									goto IL_5E78;
								case 4102:
									text = SK.Text("GENERIC_Merchants", "Merchants");
									goto IL_5E78;
								case 4103:
									text = SK.Text("GENERIC_Monks", "Monks");
									goto IL_5E78;
								case 4104:
									text = SK.Text("TOOLTIPS_VO_POPULARITY", "Popularity");
									goto IL_5E78;
								case 4105:
									text = SK.Text("TOOLTIPS_VO_NUM_BUILDINGS", "Number of Placed Buildings");
									goto IL_5E78;
								case 4106:
									text = SK.Text("TOOLTIPS_VO_KEEP_ENCLOSED", "Keep Enclosed");
									goto IL_5E78;
								case 4107:
									text = SK.Text("TOOLTIPS_VO_KEEP_NOT_ENCLOSED", "Keep Not Enclosed");
									goto IL_5E78;
								case 4108:
									text = SK.Text("GENERIC_Peasants", "Peasants");
									goto IL_5E78;
								case 4109:
									text = SK.Text("GENERIC_Archers", "Archers");
									goto IL_5E78;
								case 4110:
									text = SK.Text("GENERIC_Pikemen", "Pikemen");
									goto IL_5E78;
								case 4111:
									text = SK.Text("GENERIC_Swordsmen", "Swordsmen");
									goto IL_5E78;
								case 4112:
									text = SK.Text("GENERIC_Catapults", "Catapults");
									goto IL_5E78;
								case 4113:
									text = SK.Text("GENERIC_Captains", "Captains");
									goto IL_5E78;
								case 4114:
									text = SK.Text("TOOLTIPS_VO_TROOPS_EXPAND", "Expand for Detailed Troop Information");
									goto IL_5E78;
								case 4115:
									text = SK.Text("TOOLTIPS_VO_TROOPS_COLLAPSE", "Close Detailed Troop Information");
									goto IL_5E78;
								case 4116:
									text = SK.Text("TOOLTIPS_VO_SCOUTS_EXTRA", "Total Scouts (Active Scouts)");
									goto IL_5E78;
								case 4117:
									text = SK.Text("TOOLTIPS_VO_MERCHANTS_EXTRA", "Total Merchants (Active Merchants)");
									goto IL_5E78;
								case 4118:
									text = SK.Text("TOOLTIPS_VO_MONKS_EXTRA", "Total Monks (Active Monks)");
									goto IL_5E78;
								case 4119:
									text = SK.Text("VillageMapPanel_Tax_Income", "Tax Income");
									goto IL_5E78;
								case 4120:
									text = SK.Text("TOOLTIPS_VO_RATIONS", "Rations");
									goto IL_5E78;
								case 4121:
									text = SK.Text("TOOLTIPS_VO_ALE_RATIONS", "Ale Rations");
									goto IL_5E78;
								case 4122:
									text = SK.Text("TOOLTIPS_VO_PEOPLE", "Workers / Housing Capacity - Spare Workers");
									goto IL_5E78;
								case 4123:
									text = SK.Text("TOOLTIPS_VO_INTERDICTION", "This village is Interdicted.") + AllVillagesPanel.getTooltipDate(CustomTooltipManager.currentOverData);
									goto IL_5E78;
								case 4124:
									text = SK.Text("TOOLTIPS_VO_EXCOMMUNICATION", "This village is Excommunicated.") + AllVillagesPanel.getTooltipDate(CustomTooltipManager.currentOverData);
									goto IL_5E78;
								case 4125:
									text = SK.Text("TOOLTIPS_VO_PEACETIME", "This village is in Peacetime.") + AllVillagesPanel.getTooltipDate(CustomTooltipManager.currentOverData);
									goto IL_5E78;
								case 4126:
									text = SK.Text("TOOLTIPS_VO_NOT_PREMIUM", "A Premium Token is required to view this information.");
									goto IL_5E78;
								case 4127:
									text = SK.Text("TOOLTIPS_VO_Iron", "Current Iron Level");
									goto IL_5E78;
								case 4128:
									text = SK.Text("TOOLTIPS_VO_Pitch", "Current Pitch Level");
									goto IL_5E78;
								case 4140:
									text = SK.Text("TOOLTIPS_VO_Damaged", "Castle Requires Repair");
									goto IL_5E78;
								default:
									goto IL_5E78;
								}
								break;
							}
							break;
						}
					}
					else if (ID <= 4309)
					{
						switch (ID)
						{
						case 4200:
							text = SK.Text("TOOLTIPS_PROCLAMATION_HELP_PARISH", "As Parish Steward, you can click here to send a mail to all your Parish members. This feature can only be used once every 7 days.");
							goto IL_5E78;
						case 4201:
							text = SK.Text("TOOLTIPS_PROCLAMATION_HELP_COUNTY", "As County Sheriff, you can click here to send a mail to all your County members. This feature can only be used once every 7 days.");
							goto IL_5E78;
						case 4202:
							text = SK.Text("TOOLTIPS_PROCLAMATION_HELP_PROVINCE", "As Province Governor, you can click here to send a mail to all Parish Stewards within your Province. This feature can only be used once every 3 days.");
							goto IL_5E78;
						case 4203:
							text = SK.Text("TOOLTIPS_PROCLAMATION_HELP_COUNTRY", "As Monarch, you can click here to send a mail to all County Sheriffs within your Country. This feature can only be used once every 3 days.");
							goto IL_5E78;
						default:
							switch (ID)
							{
							case 4300:
								text = SK.Text("GENERIC_Research", "Research") + Environment.NewLine + Environment.NewLine + SK.Text("TOOLTIPS_PT_RESEARCH", "Research new technology and boost productivity on the tech tree");
								goto IL_5E78;
							case 4301:
								text = SK.Text("STATS_CATEGORY_TITLE_RANK", "Rank") + Environment.NewLine + Environment.NewLine + SK.Text("TOOLTIPS_PT_RANK", "Rank up to unlock new research, villages and abilities");
								goto IL_5E78;
							case 4302:
								text = SK.Text("GENERIC_Achievements", "Achievements") + Environment.NewLine + Environment.NewLine + SK.Text("TOOLTIPS_PT_ACHIEVEMENTS", "Master the game by unlocking every achievement");
								goto IL_5E78;
							case 4303:
								text = SK.Text("GENERIC_Quests", "Quests") + Environment.NewLine + Environment.NewLine + SK.Text("TOOLTIPS_PT_QUESTS", "Complete Quests for gold, honour, resources, cards and more");
								goto IL_5E78;
							case 4304:
								text = SK.Text("Reports_Reports", "Reports") + Environment.NewLine + Environment.NewLine + SK.Text("TOOLTIPS_PT_REPORTS", "Check the reports screen for incoming attacks and local news");
								goto IL_5E78;
							case 4305:
								text = SK.Text("GENERIC_CoatOfArms", "Coat of Arms") + Environment.NewLine + Environment.NewLine + SK.Text("TOOLTIPS_PT_COAT_OF_ARMS", "Create a unique shield design and display it on the World Map");
								goto IL_5E78;
							case 4306:
								text = SK.Text("AvatarEditor_Avatar", "Avatar") + Environment.NewLine + Environment.NewLine + SK.Text("TOOLTIPS_PT_AVATAR", "Design your Avatar and display it on the World Map");
								goto IL_5E78;
							case 4307:
								text = SK.Text("MENU_Invite_A_Friend", "Invite a Friend") + Environment.NewLine + Environment.NewLine + SK.Text("TOOLTIPS_PT_INVITE_A_FRIEND", "Earn up to 1500 Crowns when you Invite a Friend");
								goto IL_5E78;
							case 4308:
								text = SK.Text("GENERIC_ParishWall", "Parish Wall") + Environment.NewLine + Environment.NewLine + SK.Text("TOOLTIPS_PT_PARISH_WALL", "Introduce yourself on the Parish Wall");
								goto IL_5E78;
							case 4309:
								text = SK.Text("MailScreen_Mail", "Mail") + Environment.NewLine + Environment.NewLine + SK.Text("TOOLTIPS_PT_MAIL", "Check your mail and communicate with other players");
								goto IL_5E78;
							default:
								goto IL_5E78;
							}
							break;
						}
					}
					else
					{
						switch (ID)
						{
						case 4400:
							text = SK.Text("TOOLTIPS_WIKI_HELP_LINK", "Wiki Help Link");
							switch (CustomTooltipManager.currentOverData)
							{
							case 0:
								text = SK.Text("TOOLTIP_WIKI_WORLD_MAP", "What is the World Map?");
								goto IL_5E78;
							case 1:
								text = SK.Text("TOOLTIP_WIKI_VILLAGE_VILLAGE_MAP", "What are Villages?");
								goto IL_5E78;
							case 2:
								text = SK.Text("TOOLTIP_WIKI_VILLAGE_CASTLE_MAP", "What are Castles?");
								goto IL_5E78;
							case 3:
								text = SK.Text("TOOLTIP_WIKI_VILLAGE_RESOURCES", "What are Resources?");
								goto IL_5E78;
							case 4:
								text = SK.Text("TOOLTIP_WIKI_VILLAGE_TRADE", "How To: Trade");
								goto IL_5E78;
							case 5:
								text = SK.Text("TOOLTIP_WIKI_VILLAGE_TROOPS", "How To: Recruit Troops");
								goto IL_5E78;
							case 6:
								text = SK.Text("TOOLTIP_WIKI_VILLAGE_UNITS", "How To: Recruit Units");
								goto IL_5E78;
							case 7:
								text = SK.Text("TOOLTIP_WIKI_VILLAGE_HOLD_A_BANQUET", "What are Banquets?");
								goto IL_5E78;
							case 8:
								text = SK.Text("TOOLTIP_WIKI_VILLAGE_VASSALS", "What are Vassals & Liege Lords?").Replace("&amp;", "&");
								goto IL_5E78;
							case 9:
								text = SK.Text("TOOLTIP_WIKI_PARISH_CAPITAL_VILLAGE_MAP", "What is the Capital Town?");
								goto IL_5E78;
							case 10:
								text = SK.Text("TOOLTIP_WIKI_PARISH_CAPITAL_CASTLE_MAP", "What is the Capital Castle?");
								goto IL_5E78;
							case 11:
								text = SK.Text("TOOLTIP_WIKI_PARISH_CAPITAL_RESOURCES", "What are Resources?");
								goto IL_5E78;
							case 12:
								text = SK.Text("TOOLTIP_WIKI_PARISH_CAPITAL_TRADE", "What are Parishes & Capitals").Replace("&amp;", "&");
								goto IL_5E78;
							case 13:
								text = SK.Text("TOOLTIP_WIKI_PARISH_CAPITAL_TROOPS", "What are Capital Troops");
								goto IL_5E78;
							case 14:
								text = SK.Text("TOOLTIP_WIKI_PARISH_CAPITAL_TRADE", "What are Parishes & Capitals").Replace("&amp;", "&");
								goto IL_5E78;
							case 15:
								text = SK.Text("TOOLTIP_WIKI_PARISH_CAPITAL_VOTE", "How To: Vote");
								goto IL_5E78;
							case 16:
								text = SK.Text("TOOLTIP_WIKI_PARISH_CAPITAL_PARISH_FORUM", "What is the Parish Forum?");
								goto IL_5E78;
							case 17:
								text = SK.Text("TOOLTIP_WIKI_RESEARCH", "What is Research?");
								goto IL_5E78;
							case 18:
								text = SK.Text("TOOLTIP_WIKI_RANK", "What are Ranks?");
								goto IL_5E78;
							case 19:
								text = SK.Text("TOOLTIP_WIKI_QUESTS", "What are Quests?");
								goto IL_5E78;
							case 20:
								text = SK.Text("TOOLTIP_WIKI_ATTACKS", "How To: Attack");
								goto IL_5E78;
							case 21:
								text = SK.Text("TOOLTIP_WIKI_REPORTS", "What are Reports?");
								goto IL_5E78;
							case 22:
								text = SK.Text("TOOLTIP_WIKI_FACTIONS_HOUSES_GLORY", "What is Glory?");
								goto IL_5E78;
							case 23:
								text = SK.Text("TOOLTIP_WIKI_FACTIONS_HOUSES_FACTION", "What are Factions?");
								goto IL_5E78;
							case 24:
								text = SK.Text("TOOLTIP_WIKI_FACTIONS_HOUSES_HOUSE", "What are Houses?");
								goto IL_5E78;
							case 25:
								text = SK.Text("TOOLTIP_WIKI_CARDS", "What are Strategy Cards?");
								goto IL_5E78;
							case 26:
								text = SK.Text("TOOLTIP_WIKI_MAIL", "How To: Use Mail");
								goto IL_5E78;
							case 27:
								text = SK.Text("TOOLTIP_WIKI_CHAT", "How To: Use Chat");
								goto IL_5E78;
							case 28:
								text = SK.Text("TOOLTIP_WIKI_LEADERBOARD", "What is the Leaderboard?");
								goto IL_5E78;
							case 29:
							case 31:
							case 36:
								goto IL_5E78;
							case 30:
								text = SK.Text("TOOLTIP_WIKI_SETTINGS", "How To: View Options & Settings").Replace("&amp;", "&");
								goto IL_5E78;
							case 32:
								text = SK.Text("TOOLTIP_WIKI_QUEST_WHEEL", "What is the Quest Wheel?");
								goto IL_5E78;
							case 33:
								text = SK.Text("TOOLTIP_WIKI_SEND_ATTACK", "How To: Send Attacks");
								goto IL_5E78;
							case 34:
								text = SK.Text("TOOLTIP_WIKI_SEND_SCOUTS", "How To: Send Scouts");
								goto IL_5E78;
							case 35:
								text = SK.Text("TOOLTIP_WIKI_SEND_MONKS", "How To: Send Monks");
								goto IL_5E78;
							case 37:
								text = SK.Text("TOOLTIP_WIKI_BUY_PREMIUM_TOKENS", "What are Premium Tokens?");
								goto IL_5E78;
							case 38:
								text = SK.Text("TOOLTIP_WIKI_BUY_CROWNS", "What are Crowns?");
								goto IL_5E78;
							case 39:
								text = SK.Text("TOOLTIP_WIKI_BUY_CARDS", "What are Strategy Cards?");
								goto IL_5E78;
							case 40:
								text = SK.Text("TOOLTIP_WIKI_SWAP_CARDS", "How To: Swap Cards");
								goto IL_5E78;
							case 41:
								text = SK.Text("TOOLTIP_WIKI_LOGOUT", "What are Premium Tokens?");
								goto IL_5E78;
							case 42:
								text = SK.Text("TOOLTIP_WIKI_DONATE_TO_PARISH", "How To: Donate to Parish");
								goto IL_5E78;
							case 43:
								text = SK.Text("TOOLTIP_WIKI_VILLAGES_OVERVIEW", "What is the Village Overview?");
								goto IL_5E78;
							case 44:
								text = SK.Text("TOOLTIP_WIKI_ACHIEVEMENTS", "What are Achievements?");
								goto IL_5E78;
							case 45:
								text = (GameEngine.Instance.LocalWorldData.EraWorld ? SK.Text("TOOLTIP_WIKI_SECONDERA", "What is the Second Era?") : SK.Text("TOOLTIP_WIKI_SECONDAGE", "What is the Second Age?"));
								goto IL_5E78;
							case 46:
								text = (GameEngine.Instance.LocalWorldData.EraWorld ? SK.Text("TOOLTIP_WIKI_THIRDERA", "What is the Third Era?") : SK.Text("TOOLTIP_WIKI_THIRDAGE", "What is the Third Age?"));
								goto IL_5E78;
							case 47:
								text = SK.Text("TOOLTIP_WIKI_DOMINATION_RULES", "Domination World Explained?");
								goto IL_5E78;
							case 48:
								text = (GameEngine.Instance.LocalWorldData.EraWorld ? SK.Text("TOOLTIP_WIKI_FOURTHERA", "What is the Fourth Era?") : SK.Text("TOOLTIP_WIKI_FOURTHAGE", "What is the Fourth Age?"));
								goto IL_5E78;
							case 49:
								text = SK.Text("TOOLTIP_WIKI_TREASURE_CASTLES", "What is a Treasure Castle?");
								goto IL_5E78;
							case 50:
								text = SK.Text("TOOLTIP_WIKI_PALADIN_CASTLES", "What is a Paladin Castle?");
								goto IL_5E78;
							case 51:
								text = (GameEngine.Instance.LocalWorldData.EraWorld ? SK.Text("TOOLTIP_WIKI_FIFTHERA", "What is the Fifth Era?") : SK.Text("TOOLTIP_WIKI_FIFTHAGE", "What is the Fifth Age?"));
								goto IL_5E78;
							case 52:
								text = (GameEngine.Instance.LocalWorldData.EraWorld ? SK.Text("TOOLTIP_WIKI_SIXTHERA", "What is the Sixth Era?") : SK.Text("TOOLTIP_WIKI_SIXTHAGE", "What is the Sixth Age?"));
								goto IL_5E78;
							case 53:
								text = (GameEngine.Instance.LocalWorldData.EraWorld ? SK.Text("TOOLTIP_WIKI_FINAL_ERA", "What is the Final Era?") : SK.Text("TOOLTIP_WIKI_FINAL_AGE", "What is the Final Age?"));
								goto IL_5E78;
							default:
								goto IL_5E78;
							}
							break;
						case 4401:
							text = SK.Text("TOOLTIP_WIKI_CHAT", "How To: Use Chat");
							goto IL_5E78;
						case 4402:
							text = SK.Text("TOOLTIP_WIKI_SETTINGS", "How To: View Options & Settings").Replace("&amp;", "&");
							goto IL_5E78;
						default:
							switch (ID)
							{
							case 10000:
								break;
							case 10001:
								text = SK.Text("TOOLTIPS_CARD_BAR_PLAY_CARDS", "Click to Play Cards");
								goto IL_5E78;
							case 10002:
								text = SK.Text("TOOLTIPS_CARD_BAR_EXPAND", "Show Available Cards");
								goto IL_5E78;
							case 10003:
								text = SK.Text("TOOLTIPS_CARD_BAR_COLLAPSE", "Hide Available Cards");
								goto IL_5E78;
							case 10004:
								text = SK.Text("TOOLTIPS_CARD_BAR_NEXT", "Show Next Set");
								goto IL_5E78;
							case 10005:
								text = SK.Text("TOOLTIPS_CARD_BAR_PREV", "Show Previous Set");
								goto IL_5E78;
							default:
								goto IL_5E78;
							}
							break;
						}
					}
				}
				else if (ID <= 21000)
				{
					if (ID <= 10350)
					{
						switch (ID)
						{
						case 10100:
							text = SK.Text("TOOLTIPS_CARD_WINDOW_CLOSE", "Close Window");
							goto IL_5E78;
						case 10101:
							break;
						case 10102:
							text = SK.Text("TOOLTIPS_CARD_WINDOW_FILTER", "Filter Cards: ") + CardFilters.getName(CustomTooltipManager.currentOverData);
							goto IL_5E78;
						case 10103:
							text = SK.Text("ManageCandsPanel_Cash_In", "Cash In");
							goto IL_5E78;
						case 10104:
							text = SK.Text("ManageCandsPanel_Get_Cards", "Get Cards");
							goto IL_5E78;
						case 10105:
							text = string.Concat(new string[]
							{
								SK.Text("TOOLTIPS_CARD_WINDOW_FILTER", "Filter Cards: "),
								CardFilters.getName2(CustomTooltipManager.currentOverData),
								" (",
								GameEngine.Instance.cardsManager.countCardsInCategory(CustomTooltipManager.currentOverData).ToString(),
								")"
							});
							goto IL_5E78;
						default:
							switch (ID)
							{
							case 10301:
								text = SK.Text("CARD_OFFERS_Food_Pack", "Food Pack");
								goto IL_5E78;
							case 10302:
								text = SK.Text("CARD_OFFERS_Castle_Pack", "Castle Pack");
								goto IL_5E78;
							case 10303:
								text = SK.Text("CARD_OFFERS_Defense_Pack", "Defence Pack");
								goto IL_5E78;
							case 10304:
								text = SK.Text("CARD_OFFERS_Army_Pack", "Army Pack");
								goto IL_5E78;
							case 10305:
								text = SK.Text("CARD_OFFERS_Random_Pack", "Random Pack");
								goto IL_5E78;
							case 10306:
								text = SK.Text("CARD_OFFERS_Industry_Pack", "Industry Pack");
								goto IL_5E78;
							case 10307:
								text = SK.Text("CARD_OFFERS_Research_Pack", "Research Pack");
								goto IL_5E78;
							case 10308:
								text = SK.Text("CARD_OFFERS_Exclusive_Pack", "Exclusive Pack");
								goto IL_5E78;
							case 10309:
								text = SK.Text("CARD_OFFERS_Super_Food_Pack", "Super Food Pack");
								goto IL_5E78;
							case 10310:
								text = SK.Text("CARD_OFFERS_Super_Defense_Pack", "Super Defence Pack");
								goto IL_5E78;
							case 10311:
								text = SK.Text("CARD_OFFERS_Super_Army_Pack", "Super Army Pack");
								goto IL_5E78;
							case 10312:
								text = SK.Text("CARD_OFFERS_Super_Random_Pack", "Super Random Pack");
								goto IL_5E78;
							case 10313:
								text = SK.Text("CARD_OFFERS_Super_Industry_Pack", "Super Industry Pack");
								goto IL_5E78;
							case 10314:
								text = SK.Text("CARD_OFFERS_Ultimate_Food_Pack", "Ultimate Food Pack");
								goto IL_5E78;
							case 10315:
								text = SK.Text("CARD_OFFERS_Ultimate_Defense_Pack", "Ultimate Defence Pack");
								goto IL_5E78;
							case 10316:
								text = SK.Text("CARD_OFFERS_Ultimate_Army_Pack", "Ultimate Army Pack");
								goto IL_5E78;
							case 10317:
								text = SK.Text("CARD_OFFERS_Ultimate_Random_Pack", "Ultimate Random Pack");
								goto IL_5E78;
							case 10318:
								text = SK.Text("CARD_OFFERS_Ultimate_Industry_Pack", "Ultimate Industry Pack");
								goto IL_5E78;
							case 10319:
								text = SK.Text("CARDS_SEARCH_CARDS", "Search for Cards by Name");
								goto IL_5E78;
							case 10320:
								text = SK.Text("CARDS_CLEAR_SEARCH_CARDS", "Close Search");
								goto IL_5E78;
							case 10321:
								text = SK.Text("CARD_OFFERS_Platinum_Pack", "Platinum Pack");
								goto IL_5E78;
							default:
								if (ID != 10350)
								{
									goto IL_5E78;
								}
								text = SK.Text("TOOLTIPS_Aeria_Points", "Click to Purchase AP");
								goto IL_5E78;
							}
							break;
						}
					}
					else if (ID <= 10502)
					{
						if (ID == 10390)
						{
							text = SK.Text("TOOLTIPS_MAPSIDE_RENAME", "Mod Command : Reset Village Name to Default");
							goto IL_5E78;
						}
						switch (ID)
						{
						case 10500:
							text = SK.Text("TOOLTIPS_FREE_CARDS_MAIN", "Click to collect your Free Cards");
							goto IL_5E78;
						case 10501:
							text = SK.Text("TOOLTIPS_ROYAL_TICKETS_MAIN", "Click to spin the Quest Wheel");
							goto IL_5E78;
						case 10502:
							text = string.Concat(new string[]
							{
								SK.Text("AI_WolfsRevenge", "Wolf's Revenge"),
								Environment.NewLine,
								SK.Text("AI_EndsIn", "Ends In"),
								" : ",
								VillageMap.createBuildTimeString(CustomTooltipManager.currentOverData)
							});
							goto IL_5E78;
						default:
							goto IL_5E78;
						}
					}
					else
					{
						if (ID == 20000)
						{
							text = VillageMap.createBuildTimeString(CustomTooltipManager.currentOverData);
							goto IL_5E78;
						}
						if (ID != 21000)
						{
							goto IL_5E78;
						}
						text = SK.Text("TOOLTIPS_TRACK_BAR_HINT", "Double-click to enter amount");
						goto IL_5E78;
					}
				}
				else if (ID <= 24000)
				{
					switch (ID)
					{
					case 22000:
						text = SK.Text("TOOLTIP_PLAYBACK_STOP", "Stop");
						goto IL_5E78;
					case 22001:
						text = SK.Text("TOOLTIP_PLAYBACK_PAUSE", "Pause");
						goto IL_5E78;
					case 22002:
						text = SK.Text("TOOLTIP_PLAYBACK_PLAY", "Play");
						goto IL_5E78;
					case 22003:
						text = SK.Text("TOOLTIP_PLAYBACK_SPEED1", "Normal speed");
						goto IL_5E78;
					case 22004:
						text = SK.Text("TOOLTIP_PLAYBACK_SPEED2", "Double speed");
						goto IL_5E78;
					case 22005:
						text = SK.Text("TOOLTIP_PLAYBACK_SPEED4", "Quadruple speed");
						goto IL_5E78;
					case 22006:
						text = SK.Text("TOOLTIP_PLAYBACK_EXPAND", "Show time-line");
						goto IL_5E78;
					case 22007:
						text = SK.Text("TOOLTIP_PLAYBACK_COLLAPSE", "Hide time-line");
						goto IL_5E78;
					default:
						switch (ID)
						{
						case 23000:
							text = SK.Text("TOOLTIP_SEA_CONDITIONS_TRAVEL_PANELS_MINUS_5", "A Hurricane at sea means the journey will take 5 times longer than usual.");
							goto IL_5E78;
						case 23001:
							text = SK.Text("TOOLTIP_SEA_CONDITIONS_TRAVEL_PANELS_MINUS_4", "Violent storms mean the journey will take 4 times longer than usual.");
							goto IL_5E78;
						case 23002:
							text = SK.Text("TOOLTIP_SEA_CONDITIONS_TRAVEL_PANELS_MINUS_3", "Stormy seas mean the journey will take 3 times longer than usual.");
							goto IL_5E78;
						case 23003:
							text = SK.Text("TOOLTIP_SEA_CONDITIONS_TRAVEL_PANELS_MINUS_2", "Rough seas mean the journey will take twice as long as usual.");
							goto IL_5E78;
						case 23004:
							text = SK.Text("TOOLTIP_SEA_CONDITIONS_TRAVEL_PANELS_NEUTRAL", "Calm seas mean the journey will take the standard journey time.");
							goto IL_5E78;
						case 23005:
							text = SK.Text("TOOLTIP_SEA_CONDITIONS_TRAVEL_PANELS_PLUS_2", "A Fresh Breeze means the journey will take half as long as usual.");
							goto IL_5E78;
						case 23006:
							text = SK.Text("TOOLTIP_SEA_CONDITIONS_TRAVEL_PANELS_PLUS_3", "Fair winds means the journey will take one third of the usual time.");
							goto IL_5E78;
						case 23007:
							text = SK.Text("TOOLTIP_SEA_CONDITIONS_TRAVEL_PANELS_PLUS_4", "Strong winds mean the journey will take a quarter of the usual time.");
							goto IL_5E78;
						case 23008:
							text = SK.Text("TOOLTIP_SEA_CONDITIONS_TRAVEL_PANELS_PLUS_5", "Tail winds mean the journey will take one fifth of the usual time.");
							goto IL_5E78;
						case 23009:
							goto IL_5E78;
						case 23010:
							text = SK.Text("TOOLTIP_SEA_CONDITIONS_MAP_MINUS_5", "A Hurricane at sea means that inter-island journeys will take 5 times longer than usual.");
							goto IL_5E78;
						case 23011:
							text = SK.Text("TOOLTIP_SEA_CONDITIONS_MAP_MINUS_4", "Violent storms mean that inter-island journeys will take 4 times longer than usual.");
							goto IL_5E78;
						case 23012:
							text = SK.Text("TOOLTIP_SEA_CONDITIONS_MAP_MINUS_3", "Stormy seas mean that inter-island journeys will take 3 times longer than usual.");
							goto IL_5E78;
						case 23013:
							text = SK.Text("TOOLTIP_SEA_CONDITIONS_MAP_MINUS_2", "Rough seas mean that inter-island journeys will take twice as long as usual.");
							goto IL_5E78;
						case 23014:
							text = SK.Text("TOOLTIP_SEA_CONDITIONS_MAP_NEUTRAL", "Calm seas mean that inter-island journeys will take the standard journey time.");
							goto IL_5E78;
						case 23015:
							text = SK.Text("TOOLTIP_SEA_CONDITIONS_MAP_PLUS_2", "A Fresh Breeze means that inter-island journeys will take half as long as usual.");
							goto IL_5E78;
						case 23016:
							text = SK.Text("TOOLTIP_SEA_CONDITIONS_MAP_PLUS_3", "Fair winds means that inter-island journeys will take one third of the usual time.");
							goto IL_5E78;
						case 23017:
							text = SK.Text("TOOLTIP_SEA_CONDITIONS_MAP_PLUS_4", "Strong winds mean that inter-island journeys will take a quarter of the usual time.");
							goto IL_5E78;
						case 23018:
							text = SK.Text("TOOLTIP_SEA_CONDITIONS_MAP_PLUS_5", "Tail winds mean that inter-island journeys will take one fifth of the usual time.");
							goto IL_5E78;
						default:
						{
							if (ID != 24000)
							{
								goto IL_5E78;
							}
							int num17 = 0;
							string text3 = GameEngine.Instance.World.countRemainingRoyalTowers(ref num17).ToString();
							text = SK.Text("TOOLTIP_ROYAL_TOWER_ICON", "Royal Towers to be Captured Before a House Marshall can push the Button : ") + text3 + "/" + num17.ToString();
							goto IL_5E78;
						}
						}
						break;
					}
				}
				else if (ID <= 25003)
				{
					if (ID != 24100)
					{
						switch (ID)
						{
						case 25001:
							text = SK.Text("TOOLTIP_TOURNEY_PRIZE_AVAILABLE", "Collect Tourney Prize");
							if (CustomTooltipManager.currentOverData > 1)
							{
								text = SK.Text("TOOLTIP_TOURNEY_PRIZE_AVAILABLE_PLURAL", "Collect Tourney Prizes");
								text = text + " (" + CustomTooltipManager.currentOverData.ToString() + ")";
								goto IL_5E78;
							}
							text = SK.Text("TOOLTIP_TOURNEY_PRIZE_AVAILABLE", "Collect Tourney Prize");
							goto IL_5E78;
						case 25002:
							text = SK.Text("TOOLTIP_TOURNEY_ONGOING", "Ongoing Tourney: ");
							text = text + GameEngine.Instance.World.contestName + Environment.NewLine;
							text += SK.Text("TOOLTIP_TOURNEY_REMAINING_TIME", "Time Remaining: ");
							text += VillageMap.createBuildTimeString(CustomTooltipManager.currentOverData);
							goto IL_5E78;
						case 25003:
							text = SK.Text("STATS_CATEGORY_TITLE_RANK", "Rank");
							switch (CustomTooltipManager.currentOverData)
							{
							case 1:
								text += " 1 - 11";
								goto IL_5E78;
							case 2:
								text += " 12 - 17";
								goto IL_5E78;
							case 3:
								text += " 18 - 23";
								goto IL_5E78;
							default:
								goto IL_5E78;
							}
							break;
						default:
							goto IL_5E78;
						}
					}
					else
					{
						int num18 = (int)(GameEngine.Instance.World.KillStreakTimer - VillageMap.getCurrentServerTime()).TotalSeconds;
						if (num18 < 0)
						{
							text = SK.Text("TOOLTIP_NO_KILL_STREAK", "You have no Kill Streak");
							goto IL_5E78;
						}
						string text8 = VillageMap.createBuildTimeString(num18);
						int num19 = GameEngine.Instance.World.KillStreakCount - 1;
						int num20;
						int num21;
						double num22;
						if (num19 < 100)
						{
							num20 = Wheel.killstreak_honour[num19];
							num21 = Wheel.killstreak_fpcap[num19];
							num22 = (double)Wheel.killstreak_spinbonus[num19] / 100.0;
						}
						else
						{
							num20 = num19 - 100 + 251;
							num21 = (num19 - 100) * 2 + 202;
							num22 = 35.0;
						}
						NumberFormatInfo nfi6 = GameEngine.NFI;
						text = string.Concat(new string[]
						{
							SK.Text("TOOLTIP_KILL_STREAK_1", "Current Kill Streak"),
							" : ",
							(num19 + 1).ToString("N", nfi6),
							Environment.NewLine,
							SK.Text("TOOLTIP_KILL_STREAK_2", "Kill Streak Expires in"),
							" : ",
							text8,
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("TOOLTIP_KILL_STREAK_3", "Bonuses While Attacking the AI"),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("TOOLTIP_KILL_STREAK_4", "Honour Boost"),
							" : ",
							num20.ToString(),
							"%",
							Environment.NewLine,
							SK.Text("TOOLTIP_KILL_STREAK_5", "Faith Points Cap Increment Boost"),
							" : ",
							num21.ToString(),
							"%",
							Environment.NewLine
						});
						if (num22 > 0.0)
						{
							string text9 = text;
							text = string.Concat(new string[]
							{
								text9,
								SK.Text("TOOLTIP_KILL_STREAK_6", "Bonus Wheel Spin Chance"),
								" : ",
								num22.ToString("N", GameEngine.NFI_D2),
								"%",
								Environment.NewLine
							});
							goto IL_5E78;
						}
						goto IL_5E78;
					}
				}
				else
				{
					if (ID == 25100)
					{
						text = SK.Text("TOOLTIP_SALE_ENDS", "Sale Ends In");
						text = text + " " + VillageMap.createBuildTimeString(CustomTooltipManager.currentOverData);
						goto IL_5E78;
					}
					if (ID != 25101)
					{
						goto IL_5E78;
					}
					text = SK.Text("TOUCH_Z_PurchaseSpecialOffer", "Purchase Special Offer");
					goto IL_5E78;
				}
				text = "";
			}
			IL_5E78:
			CustomTooltip.CreateToolTip(text, ID, CustomTooltipManager.currentOverData, parentWindow);
		}

		// Token: 0x06000F9C RID: 3996 RVA: 0x0010F968 File Offset: 0x0010DB68
		public static string getAchievementRank(int achievement)
		{
			int num = achievement & 1879048192;
			if (num <= 1073741824)
			{
				if (num == 268435456)
				{
					return SK.Text("Achievements_Silver", "Silver");
				}
				if (num == 536870912)
				{
					return SK.Text("Achievements_Gold", "Gold");
				}
				if (num == 1073741824)
				{
					return SK.Text("Achievements_Diamond", "Diamond");
				}
			}
			else
			{
				if (num == 1342177280)
				{
					return SK.Text("Achievements_Diamond2", "Double Diamond");
				}
				if (num == 1610612736)
				{
					return SK.Text("Achievements_Diamond3", "Triple Diamond");
				}
				if (num == 1879048192)
				{
					return SK.Text("Achievements_Sapphire", "Sapphire");
				}
			}
			return SK.Text("Achievements_Iron", "Iron");
		}

		// Token: 0x06000F9D RID: 3997 RVA: 0x0010FA28 File Offset: 0x0010DC28
		public static string getAchievementTitle(int achievement)
		{
			int num = achievement & 268435455;
			if (num <= 225)
			{
				if (num <= 101)
				{
					switch (num)
					{
					case 1:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_PROTECTOR", "Protector");
					case 2:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_LAW_BRINGER", "Law Bringer");
					case 3:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_WARRIOR", "Warrior");
					case 4:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_WOLF_HUNTER", "Wolf Hunter");
					case 5:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_WEREGILD", "Weregild");
					case 6:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_RATTY_LOST_AGAIN", "Ratty lost again!");
					case 7:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_SNAKES_DOWNFALL", "Snakes Downfall");
					case 8:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_SQUEALPIGGY", "Squeal Piggy!");
					case 9:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_WOLFBANE", "Wolf Bane");
					case 10:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_FLAG_RAIDER", "Flag Raider");
					case 11:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_FIRESTARTER", "Firestarter");
					case 12:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_CONQUEROR", "Conqueror");
					case 13:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_VIKING", "Viking");
					case 14:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_VANDAL", "Vandal");
					case 15:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_EVILLORD", "Evil Lord");
					case 16:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_TREASURE_HUNTER", "Treasure Hunter");
					case 17:
					case 18:
					case 19:
					case 20:
					case 21:
					case 22:
					case 23:
					case 24:
					case 25:
					case 26:
					case 27:
					case 28:
					case 29:
					case 30:
					case 31:
					case 32:
						break;
					case 33:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_CANT_TOUCH_ME", "Can't touch me");
					case 34:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_DEFENSIVE_MASTER", "Defensive master");
					case 35:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_HELPING_HAND", "Helping Hand");
					case 36:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_ROCKHARD", "Rock hard");
					case 37:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_VANQUISHER", "Vanquisher");
					default:
						switch (num)
						{
						case 65:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_BALLISTA_CRAZY", "Ballista Crazy");
						case 66:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_FEEL_THE_HEAT", "Feel the Heat");
						case 67:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_DEATHTRAP", "Deathtrap");
						default:
							switch (num)
							{
							case 97:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_HEAVY_DRINKER", "Heavy Drinker");
							case 98:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_GLUTTON", "Glutton");
							case 99:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_GARDENER", "Gardener");
							case 100:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_MISER", "Miser");
							case 101:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_CHARITY", "Charity");
							}
							break;
						}
						break;
					}
				}
				else if (num <= 163)
				{
					switch (num)
					{
					case 129:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_HEALER", "Healer");
					case 130:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_PEACEBRINGER", "Peacebringer");
					case 131:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_DIPLOMAT", "Diplomat");
					default:
						switch (num)
						{
						case 161:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_HORSE_MASTER", "Horse Master");
						case 162:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_LIGHTNING_SPEED", "Lightning Speed");
						case 163:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_MASTER_FORAGER", "Master Forager");
						}
						break;
					}
				}
				else
				{
					switch (num)
					{
					case 193:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_GLORY_STAR", "Glory Star");
					case 194:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_KINGS_KIN", "King's Kin");
					case 195:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_LOYAL_MEMBER", "Loyal Member");
					default:
						if (num == 225)
						{
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_GENIUS", "Genius");
						}
						break;
					}
				}
			}
			else if (num <= 290)
			{
				if (num <= 257)
				{
					if (num == 226)
					{
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_LEARNED_SCHOLAR", "Learned Scholar");
					}
					if (num == 257)
					{
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_STOCKBROKER", "Stockbroker");
					}
				}
				else
				{
					if (num == 289)
					{
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_FINE_DINING", "Fine Dining");
					}
					if (num == 290)
					{
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_BANQUET_KING", "Banquet King");
					}
				}
			}
			else if (num <= 353)
			{
				if (num == 321)
				{
					return SK.Text("TOOLTIPS_ACHIEVEMENTS_FAME", "Fame");
				}
				if (num == 353)
				{
					return SK.Text("TOOLTIPS_ACHIEVEMENTS_TEAM_PLAYER", "Team player");
				}
			}
			else
			{
				if (num == 354)
				{
					return SK.Text("TOOLTIPS_ACHIEVEMENTS_SKILLED_RULER", "Skilled ruler");
				}
				switch (num)
				{
				case 385:
					return SK.Text("TOOLTIPS_ACHIEVEMENTS_OFFICER", "Officer");
				case 386:
					return SK.Text("TOOLTIPS_ACHIEVEMENTS_HIGH_OFFICER", "High Office");
				case 387:
					return SK.Text("TOOLTIPS_ACHIEVEMENTS_MIGHTY_RULER", "Mighty Ruler");
				case 388:
					return SK.Text("TOOLTIPS_ACHIEVEMENTS_LIONHEART", "Lionheart");
				}
			}
			return "";
		}

		// Token: 0x06000F9E RID: 3998 RVA: 0x0010FF44 File Offset: 0x0010E144
		public static string getAchievementRequirement(int achievement, int rankLevel)
		{
			if (rankLevel < 0 || rankLevel > 6)
			{
				return "";
			}
			if (achievement <= 225)
			{
				if (achievement <= 101)
				{
					switch (achievement)
					{
					case 1:
						switch (rankLevel)
						{
						case 0:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_PROTECTOR_1", "Kill 20 wolves");
						case 1:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_PROTECTOR_2", "Kill 200 wolves ");
						case 2:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_PROTECTOR_3", "Kill 1,000 wolves");
						case 3:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_PROTECTOR_4", "Kill 10,000 wolves");
						case 4:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_PROTECTOR_5", "Kill 50,000 wolves");
						case 5:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_PROTECTOR_6", "Kill 100,000 wolves");
						case 6:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_PROTECTOR_7", "Kill 250,000 wolves");
						}
						break;
					case 2:
						switch (rankLevel)
						{
						case 0:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_LAW_BRINGER1", "Kill 10 bandits");
						case 1:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_LAW_BRINGER2", "Kill 100 bandits");
						case 2:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_LAW_BRINGER3", "Kill 500 bandits");
						case 3:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_LAW_BRINGER4", "Kill 5,000 bandits");
						case 4:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_LAW_BRINGER5", "Kill 10,000 bandits");
						case 5:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_LAW_BRINGER6", "Kill 20,000 bandits");
						case 6:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_LAW_BRINGER7", "Kill 50,000 bandits");
						}
						break;
					case 3:
						switch (rankLevel)
						{
						case 0:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_WARRIOR1", "Kill 50 troops as an attacker");
						case 1:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_WARRIOR2", "Kill 1,000 troops as an attacker");
						case 2:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_WARRIOR3", "Kill 20,000 troops as an attacker");
						case 3:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_WARRIOR5", "Kill 50,000 troops as an attacker");
						case 4:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_WARRIOR6", "Kill 75,000 troops as an attacker");
						case 5:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_WARRIOR7", "Kill 100,000 troops as an attacker");
						case 6:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_WARRIOR4", "Kill 250,000 troops as an attacker");
						}
						break;
					case 4:
						switch (rankLevel)
						{
						case 0:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_WOLF_HUNTER1", "Destroy 3 Wolf Lairs");
						case 1:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_WOLF_HUNTER2", "Destroy 20 Wolf Lairs");
						case 2:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_WOLF_HUNTER3", "Destroy 100 Wolf Lairs");
						case 3:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_WOLF_HUNTER4", "Destroy 300 Wolf Lairs");
						case 4:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_WOLF_HUNTER5", "Destroy 1,000 Wolf Lairs");
						case 5:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_WOLF_HUNTER6", "Destroy 5,000 Wolf Lairs");
						case 6:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_WOLF_HUNTER7", "Destroy 15,000 Wolf Lairs");
						}
						break;
					case 5:
						switch (rankLevel)
						{
						case 0:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_WEREGILD1", "Destroy 2 Bandit Camps");
						case 1:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_WEREGILD2", "Destroy 10 Bandit Camps");
						case 2:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_WEREGILD3", "Destroy 50 Bandit Camps");
						case 3:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_WEREGILD4", "Destroy 200 Bandit Camps");
						case 4:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_WEREGILD5", "Destroy 400 Bandit Camps");
						case 5:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_WEREGILD6", "Destroy 700 Bandit Camps");
						case 6:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_WEREGILD7", "Destroy 1,000 Bandit Camps");
						}
						break;
					case 6:
						switch (rankLevel)
						{
						case 0:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_RATTY_LOST_AGAIN1", "Destroy 1 Rat's Castle");
						case 1:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_RATTY_LOST_AGAIN2", "Destroy 3 Rat's Castles");
						case 2:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_RATTY_LOST_AGAIN3", "Destroy 10 Rat's Castles");
						case 3:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_RATTY_LOST_AGAIN4", "Destroy 25 Rat's Castles");
						case 4:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_RATTY_LOST_AGAIN5", "Destroy 50 Rat's Castles");
						case 5:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_RATTY_LOST_AGAIN6", "Destroy 75 Rat's Castles");
						case 6:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_RATTY_LOST_AGAIN7", "Destroy 100 Rat's Castles");
						}
						break;
					case 7:
						switch (rankLevel)
						{
						case 0:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_SNAKES_DOWNFALL1", "Destroy 1 Snakes Castle");
						case 1:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_SNAKES_DOWNFALL2", "Destroy 3 Snakes Castles");
						case 2:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_SNAKES_DOWNFALL3", "Destroy 10 Snakes Castles");
						case 3:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_SNAKES_DOWNFALL4", "Destroy 25 Snakes Castles");
						case 4:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_SNAKES_DOWNFALL5", "Destroy 50 Snakes Castles");
						case 5:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_SNAKES_DOWNFALL6", "Destroy 75 Snakes Castles");
						case 6:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_SNAKES_DOWNFALL7", "Destroy 100 Snakes Castles");
						}
						break;
					case 8:
						switch (rankLevel)
						{
						case 0:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_SQUEALPIGGY1", "Destroy 1 Pig's Castle");
						case 1:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_SQUEALPIGGY2", "Destroy 3 Pig's Castles");
						case 2:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_SQUEALPIGGY3", "Destroy 10 Pig's Castles");
						case 3:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_SQUEALPIGGY4", "Destroy 25 Pig's Castles");
						case 4:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_SQUEALPIGGY5", "Destroy 50 Pig's Castles");
						case 5:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_SQUEALPIGGY6", "Destroy 75 Pig's Castles");
						case 6:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_SQUEALPIGGY7", "Destroy 100 Pig's Castles");
						}
						break;
					case 9:
						switch (rankLevel)
						{
						case 0:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_WOLFBANE1", "Destroy 1 Wolf's Castles");
						case 1:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_WOLFBANE2", "Destroy 3 Wolf's Castles");
						case 2:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_WOLFBANE3", "Destroy 10 Wolf's Castles");
						case 3:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_WOLFBANE4", "Destroy 25 Wolf's Castles");
						case 4:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_WOLFBANE5", "Destroy 50 Wolf's Castles");
						case 5:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_WOLFBANE6", "Destroy 75 Wolf's Castles");
						case 6:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_WOLFBANE7", "Destroy 100 Wolf's Castles");
						}
						break;
					case 10:
						switch (rankLevel)
						{
						case 0:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_FLAG_RAIDER1", "Capture 2 Flags for your parish");
						case 1:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_FLAG_RAIDER2", "Capture 10 Flags for your parish");
						case 2:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_FLAG_RAIDER3", "Capture 50 Flags for your parish");
						case 3:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_FLAG_RAIDER4", "Capture 250 Flags for your parish");
						case 4:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_FLAG_RAIDER5", "Capture 500 Flags for your parish");
						case 5:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_FLAG_RAIDER6", "Capture 750 Flags for your parish");
						case 6:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_FLAG_RAIDER7", "Capture 1,000 Flags for your parish");
						}
						break;
					case 11:
						switch (rankLevel)
						{
						case 0:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_FIRESTARTER1", "Raze 1 village");
						case 1:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_FIRESTARTER2", "Raze 3 villages");
						case 2:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_FIRESTARTER3", "Raze 10 villages");
						case 3:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_FIRESTARTER4", "Raze 50 villages");
						case 4:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_FIRESTARTER5", "Raze 100 villages");
						case 5:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_FIRESTARTER6", "Raze 150 villages");
						case 6:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_FIRESTARTER7", "Raze 250 villages");
						}
						break;
					case 12:
						switch (rankLevel)
						{
						case 0:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_CONQUEROR1", "Capture 1 village");
						case 1:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_CONQUEROR2", "Capture 3 villages");
						case 2:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_CONQUEROR3", "Capture 7 villages");
						case 3:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_CONQUEROR4", "Capture 20 villages");
						case 4:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_CONQUEROR5", "Capture 40 villages");
						case 5:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_CONQUEROR6", "Capture 60 villages");
						case 6:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_CONQUEROR7", "Capture 100 villages");
						}
						break;
					case 13:
						switch (rankLevel)
						{
						case 0:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_VIKING1", "Pillage a total of 10 packets of goods from another player");
						case 1:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_VIKING2", "Pillage a total of 100 packets of goods from another player");
						case 2:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_VIKING3", "Pillage a total of 2,000 packets of goods from another player");
						case 3:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_VIKING4a", "Pillage a total of 10,000 packets of goods from another player");
						case 4:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_VIKING5", "Pillage a total of 20,000 packets of goods from another player");
						case 5:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_VIKING6", "Pillage a total of 40,000 packets of goods from another player");
						case 6:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_VIKING7", "Pillage a total of 75,000 packets of goods from another player");
						}
						break;
					case 14:
						switch (rankLevel)
						{
						case 0:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_VANDAL1", "Destroy 2 buildings through ransacking a village");
						case 1:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_VANDAL2", "Destroy 20 buildings through ransacking a village");
						case 2:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_VANDAL3", "Destroy 200 buildings through ransacking a village");
						case 3:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_VANDAL4", "Destroy 2,000 buildings through ransacking a village");
						case 4:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_VANDAL5", "Destroy 3,000 buildings through ransacking a village");
						case 5:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_VANDAL6", "Destroy 4,000 buildings through ransacking a village");
						case 6:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_VANDAL7", "Destroy 5,000 buildings through ransacking a village");
						}
						break;
					case 15:
						switch (rankLevel)
						{
						case 0:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_EVILLORD1", "Destroy 1 Paladin's Castle");
						case 1:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_EVILLORD2", "Destroy 3 Paladin's Castles");
						case 2:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_EVILLORD3", "Destroy 10 Paladin's Castles");
						case 3:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_EVILLORD4", "Destroy 25 Paladin's Castles");
						case 4:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_EVILLORD5", "Destroy 50 Paladin's Castles");
						case 5:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_EVILLORD6", "Destroy 75 Paladin's Castles");
						case 6:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_EVILLORD7", "Destroy 100 Paladin's Castles");
						}
						break;
					case 16:
						switch (rankLevel)
						{
						case 0:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_TREASUREHUNTER1", "Capture 1 Treasure Chest from Treasure Castles");
						case 1:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_TREASUREHUNTER2", "Capture 3 Treasure Chests from Treasure Castles");
						case 2:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_TREASUREHUNTER3", "Capture 10 Treasure Chests from Treasure Castles");
						case 3:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_TREASUREHUNTER4", "Capture 25 Treasure Chests from Treasure Castles");
						case 4:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_TREASUREHUNTER5", "Capture 50 Treasure Chests from Treasure Castles");
						case 5:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_TREASUREHUNTER6", "Capture 75 Treasure Chests from Treasure Castles");
						case 6:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_TREASUREHUNTER7", "Capture 100 Treasure Chests from Treasure Castles");
						}
						break;
					case 17:
					case 18:
					case 19:
					case 20:
					case 21:
					case 22:
					case 23:
					case 24:
					case 25:
					case 26:
					case 27:
					case 28:
					case 29:
					case 30:
					case 31:
					case 32:
						break;
					case 33:
						switch (rankLevel)
						{
						case 0:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_CANT_TOUCH_ME1", "Survive attacks 3 consecutive enemy attacks");
						case 1:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_CANT_TOUCH_ME2", "Survive attacks 12 consecutive enemy attacks");
						case 2:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_CANT_TOUCH_ME3", "Survive attacks 50 consecutive enemy attacks");
						case 3:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_CANT_TOUCH_ME4", "Survive attacks 250 consecutive enemy attacks");
						}
						break;
					case 34:
						switch (rankLevel)
						{
						case 0:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_DEFENSIVE_MASTER1", "Survive an attack from an army of over 20 troops");
						case 1:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_DEFENSIVE_MASTER2", "Survive an attack from an army of over 100 troops");
						case 2:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_DEFENSIVE_MASTER3", "Survive an attack from an army of over 250 troops");
						case 3:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_DEFENSIVE_MASTER4", "Survive an attack from an army of over 400 troops");
						}
						break;
					case 35:
						switch (rankLevel)
						{
						case 0:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_HELPING_HAND1", "Your reinforcements have helped defend 1 castle");
						case 1:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_HELPING_HAND2", "Your reinforcements have helped defend 5 castles");
						case 2:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_HELPING_HAND3", "Your reinforcements have helped defend 25 castles");
						case 3:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_HELPING_HAND4", "Your reinforcements have helped defend 200 castles");
						}
						break;
					case 36:
						switch (rankLevel)
						{
						case 0:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_ROCKHARD1", "A castle survives - killing over 500 troops in a server day");
						case 1:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_ROCKHARD2", "A castle survives - killing over 1,000 troops in a server day");
						case 2:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_ROCKHARD3", "A castle survives - killing over 4,000 troops in a server day");
						case 3:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_ROCKHARD4", "A castle survives - killing over 10,000 troops in a server day");
						}
						break;
					case 37:
						switch (rankLevel)
						{
						case 0:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_VANQUISHER1", "Kill 100 troops defending your castles");
						case 1:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_VANQUISHER2", "Kill 1,000 troops defending your castles");
						case 2:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_VANQUISHER3", "Kill 10,000 troops defending your castles");
						case 3:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_VANQUISHER4", "Kill 100,000 troops defending your castles");
						case 4:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_VANQUISHER5", "Kill 250,000 troops defending your castles");
						case 5:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_VANQUISHER6", "Kill 500,000 troops defending your castles");
						case 6:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_VANQUISHER7", "Kill 1,000,000 troops defending your castles");
						}
						break;
					default:
						switch (achievement)
						{
						case 65:
							switch (rankLevel)
							{
							case 0:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_BALLISTA_CRAZY1", "Fire over 50 ballistae bolts in your castles");
							case 1:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_BALLISTA_CRAZY2", "Fire over 250 ballistae bolts in your castles");
							case 2:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_BALLISTA_CRAZY3", "Fire over 4,000 ballistae bolts in your castles");
							case 3:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_BALLISTA_CRAZY4", "Fire over 25,000 ballistae bolts in your castles");
							case 4:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_BALLISTA_CRAZY5", "Fire over 100,000 ballistae bolts in your castles");
							case 5:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_BALLISTA_CRAZY6", "Fire over 500,000 ballistae bolts in your castles");
							case 6:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_BALLISTA_CRAZY7", "Fire over 1,000,000 ballistae bolts in your castles");
							}
							break;
						case 66:
							switch (rankLevel)
							{
							case 0:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_FEEL_THE_HEAT1", "Pour over 3 oil pots in your castles");
							case 1:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_FEEL_THE_HEAT2", "Pour over 25 oil pots in your castles");
							case 2:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_FEEL_THE_HEAT3", "Pour over 200 oil pots in your castles");
							case 3:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_FEEL_THE_HEAT4", "Pour over 3,000 oil pots in your castles");
							case 4:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_FEEL_THE_HEAT5", "Pour over 10,000 oil pots in your castles");
							case 5:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_FEEL_THE_HEAT6", "Pour over 50,000 oil pots in your castles");
							case 6:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_FEEL_THE_HEAT7", "Pour over 100,000 oil pots in your castles");
							}
							break;
						case 67:
							switch (rankLevel)
							{
							case 0:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_DEATHTRAP1", "Over 20 killing pits triggered in your castles");
							case 1:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_DEATHTRAP2", "Over 200 killing pits triggered in your castles");
							case 2:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_DEATHTRAP3", "Over 2,000 killing pits triggered in your castles");
							case 3:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_DEATHTRAP4", "Over 10,000 killing pits triggered in your castles");
							case 4:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_DEATHTRAP5", "Over 25,000 killing pits triggered in your castles");
							case 5:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_DEATHTRAP6", "Over 50,000 killing pits triggered in your castles");
							case 6:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_DEATHTRAP7", "Over 100,000 killing pits triggered in your castles");
							}
							break;
						default:
							switch (achievement)
							{
							case 97:
								switch (rankLevel)
								{
								case 0:
									return SK.Text("TOOLTIPS_ACHIEVEMENTS_HEAVY_DRINKER1", "Place 5 hop farms in your villages");
								case 1:
									return SK.Text("TOOLTIPS_ACHIEVEMENTS_HEAVY_DRINKER2", "Place 10 hop farms in your villages");
								case 2:
									return SK.Text("TOOLTIPS_ACHIEVEMENTS_HEAVY_DRINKER3", "Place 30 hop farms in your villages");
								case 3:
									return SK.Text("TOOLTIPS_ACHIEVEMENTS_HEAVY_DRINKER4", "Place 60 hop farms in your villages");
								}
								break;
							case 98:
								switch (rankLevel)
								{
								case 0:
									return SK.Text("TOOLTIPS_ACHIEVEMENTS_GLUTTON1", "Place 20 food farms in your villages");
								case 1:
									return SK.Text("TOOLTIPS_ACHIEVEMENTS_GLUTTON2", "Place 50 food farms in your villages");
								case 2:
									return SK.Text("TOOLTIPS_ACHIEVEMENTS_GLUTTON3", "Place 120 food farms in your villages");
								case 3:
									return SK.Text("TOOLTIPS_ACHIEVEMENTS_GLUTTON4", "Place 250 food farms in your villages");
								}
								break;
							case 99:
								switch (rankLevel)
								{
								case 0:
									return SK.Text("TOOLTIPS_ACHIEVEMENTS_GARDENER1", "Place 5 gardens in your villages");
								case 1:
									return SK.Text("TOOLTIPS_ACHIEVEMENTS_GARDENER2", "Place 15 gardens in your villages");
								case 2:
									return SK.Text("TOOLTIPS_ACHIEVEMENTS_GARDENER3", "Place 30 gardens in your villages");
								case 3:
									return SK.Text("TOOLTIPS_ACHIEVEMENTS_GARDENER4", "Place 60 gardens in your villages");
								}
								break;
							case 100:
								switch (rankLevel)
								{
								case 0:
									return SK.Text("TOOLTIPS_ACHIEVEMENTS_MISER1", "Store over 20,000 gold");
								case 1:
									return SK.Text("TOOLTIPS_ACHIEVEMENTS_MISER2", "Store over 200,000 gold");
								case 2:
									return SK.Text("TOOLTIPS_ACHIEVEMENTS_MISER3", "Store over 1,000,000 gold");
								case 3:
									return SK.Text("TOOLTIPS_ACHIEVEMENTS_MISER4", "Store over 5,000,000 gold");
								case 4:
									return SK.Text("TOOLTIPS_ACHIEVEMENTS_MISER5", "Store over 10,000,000 gold");
								case 5:
									return SK.Text("TOOLTIPS_ACHIEVEMENTS_MISER6", "Store over 20,000,000 gold");
								case 6:
									return SK.Text("TOOLTIPS_ACHIEVEMENTS_MISER7", "Store over 50,000,000 gold");
								}
								break;
							case 101:
								switch (rankLevel)
								{
								case 0:
									return SK.Text("TOOLTIPS_ACHIEVEMENTS_CHARITY1", "Send another player over 10 packets of goods");
								case 1:
									return SK.Text("TOOLTIPS_ACHIEVEMENTS_CHARITY2", "Send another player over 500 packets of goods");
								case 2:
									return SK.Text("TOOLTIPS_ACHIEVEMENTS_CHARITY3", "Send another player over 2,000 packets of goods");
								case 3:
									return SK.Text("TOOLTIPS_ACHIEVEMENTS_CHARITY4", "Send another player over 10,000 packets of goods");
								case 4:
									return SK.Text("TOOLTIPS_ACHIEVEMENTS_CHARITY5", "Send another player over 20,000 packets of goods");
								case 5:
									return SK.Text("TOOLTIPS_ACHIEVEMENTS_CHARITY6", "Send another player over 40,000 packets of goods");
								case 6:
									return SK.Text("TOOLTIPS_ACHIEVEMENTS_CHARITY7", "Send another player over 60,000 packets of goods");
								}
								break;
							}
							break;
						}
						break;
					}
				}
				else if (achievement <= 163)
				{
					switch (achievement)
					{
					case 129:
						switch (rankLevel)
						{
						case 0:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_HEALER1", "Cure over 10 points of disease");
						case 1:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_HEALER2", "Cure over 100 points of disease");
						case 2:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_HEALER3", "Cure over 1,000 points of disease");
						case 3:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_HEALER4", "Cure over 10,000 points of disease");
						case 4:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_HEALER5", "Cure over 20,000 points of disease");
						case 5:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_HEALER6", "Cure over 35,000 points of disease");
						case 6:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_HEALER7", "Cure over 50,000 points of disease");
						}
						break;
					case 130:
						switch (rankLevel)
						{
						case 0:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_PEACEBRINGER1", "Interdict 2 villages that you do not own");
						case 1:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_PEACEBRINGER2", "Interdict 10 villages that you do not own");
						case 2:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_PEACEBRINGER3", "Interdict 50 villages that you do not own");
						case 3:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_PEACEBRINGER4", "Interdict 200 villages that you do not own");
						case 4:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_PEACEBRINGER5", "Interdict 400 villages that you do not own");
						case 5:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_PEACEBRINGER6", "Interdict 600 villages that you do not own");
						case 6:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_PEACEBRINGER7", "Interdict 1,000 villages that you do not own");
						}
						break;
					case 131:
						switch (rankLevel)
						{
						case 0:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_DIPLOMAT1", "Influence an election by 10 votes ");
						case 1:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_DIPLOMAT2", "Influence an election by 100 votes ");
						case 2:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_DIPLOMAT3", "Influence an election by 500 votes ");
						case 3:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_DIPLOMAT4", "Influence an election by 2,000 votes ");
						case 4:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_DIPLOMAT5", "Influence an election by 5,000 votes ");
						case 5:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_DIPLOMAT6", "Influence an election by 10,000 votes ");
						case 6:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_DIPLOMAT7", "Influence an election by 25,000 votes ");
						}
						break;
					default:
						switch (achievement)
						{
						case 161:
							switch (rankLevel)
							{
							case 0:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_HORSE_MASTER1", "Scout 10 resource stashes");
							case 1:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_HORSE_MASTER2", "Scout 50 resource stashes");
							case 2:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_HORSE_MASTER3", "Scout 250 resource stashes");
							case 3:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_HORSE_MASTER4", "Scout 1,000 resource stashes");
							case 4:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_HORSE_MASTER5", "Scout 10,000 resource stashes");
							case 5:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_HORSE_MASTER6", "Scout 50,000 resource stashes");
							case 6:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_HORSE_MASTER7", "Scout 100,000 resource stashes");
							}
							break;
						case 162:
							switch (rankLevel)
							{
							case 0:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_LIGHTNING_SPEED1", "Uncover 2 resource stashes");
							case 1:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_LIGHTNING_SPEED2", "Uncover 20 resource stashes");
							case 2:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_LIGHTNING_SPEED3", "Uncover 200 resource stashes");
							case 3:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_LIGHTNING_SPEED4", "Uncover 2,000 resource stashes");
							case 4:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_LIGHTNING_SPEED5", "Uncover 5,000 resource stashes");
							case 5:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_LIGHTNING_SPEED6", "Uncover 10,000 resource stashes");
							case 6:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_LIGHTNING_SPEED7", "Uncover 25,000 resource stashes");
							}
							break;
						case 163:
							switch (rankLevel)
							{
							case 0:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_MASTER_FORAGER1", "Bring back over 20 packets of goods");
							case 1:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_MASTER_FORAGER2", "Bring back over 200 packets of goods");
							case 2:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_MASTER_FORAGER3", "Bring back over 2,000 packets of goods");
							case 3:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_MASTER_FORAGER4", "Bring back over 20,000 packets of goods");
							case 4:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_MASTER_FORAGER5", "Bring back over 50,000 packets of goods");
							case 5:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_MASTER_FORAGER6", "Bring back over 75,000 packets of goods");
							case 6:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_MASTER_FORAGER7", "Bring back over 150,000 packets of goods");
							}
							break;
						}
						break;
					}
				}
				else
				{
					switch (achievement)
					{
					case 193:
						switch (rankLevel)
						{
						case 0:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_GLORY_STAR1", "Be a member of a house that wins 1 glory round");
						case 1:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_GLORY_STAR2", "Be a member of a house that wins 2 glory rounds");
						case 2:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_GLORY_STAR3", "Be a member of a house that wins 3 glory rounds");
						case 3:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_GLORY_STAR4", "Be a member of a house that wins 4 glory rounds");
						}
						break;
					case 194:
						switch (rankLevel)
						{
						case 0:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_KINGS_KIN1", "Be a member of a house that controls a county");
						case 1:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_KINGS_KIN2", "Be a member of a house that controls a province");
						case 2:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_KINGS_KIN3", "Be a member of a house that controls a country");
						case 3:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_KINGS_KIN4", "Be a member of a house that controls more than 1 country");
						}
						break;
					case 195:
						switch (rankLevel)
						{
						case 0:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_LOYAL_MEMBER1", "Spend 2 weeks in the same faction");
						case 1:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_LOYAL_MEMBER2", "Spend 10 weeks in the same faction");
						case 2:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_LOYAL_MEMBER3", "Spend 26 weeks in the same faction");
						case 3:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_LOYAL_MEMBER4", "Spend 52 weeks in the same faction");
						}
						break;
					default:
						if (achievement == 225)
						{
							switch (rankLevel)
							{
							case 0:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_GENIUS1", "Research everything in 1 branch of the tree");
							case 1:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_GENIUS2", "Research everything in 2 branches of the tree");
							case 2:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_GENIUS3", "Research everything in 3 branches of the tree");
							case 3:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_GENIUS4", "Research everything in the research tree");
							}
						}
						break;
					}
				}
			}
			else if (achievement <= 290)
			{
				if (achievement <= 257)
				{
					if (achievement != 226)
					{
						if (achievement == 257)
						{
							switch (rankLevel)
							{
							case 0:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_STOCKBROKER1", "Make over 1,000 gold from selling goods");
							case 1:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_STOCKBROKER2", "Make over 10,000 gold from selling goods");
							case 2:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_STOCKBROKER3", "Make over 100,000 gold from selling goods");
							case 3:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_STOCKBROKER4", "Make over 1,000,000 gold from selling goods");
							case 4:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_STOCKBROKER5", "Make over 10,000,000 gold from selling goods");
							case 5:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_STOCKBROKER6", "Make over 25,000,000 gold from selling goods");
							case 6:
								return SK.Text("TOOLTIPS_ACHIEVEMENTS_STOCKBROKER7", "Make over 50,000,000 gold from selling goods");
							}
						}
					}
					else
					{
						switch (rankLevel)
						{
						case 0:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_LEARNED_SCHOLAR1", "Complete 20 researches");
						case 1:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_LEARNED_SCHOLAR2", "Complete 80 researches");
						case 2:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_LEARNED_SCHOLAR3", "Complete 150 researches");
						case 3:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_LEARNED_SCHOLAR4", "Complete 500 researches");
						}
					}
				}
				else if (achievement != 289)
				{
					if (achievement == 290)
					{
						switch (rankLevel)
						{
						case 0:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_BANQUET_KING1", "Raise over 1,000 honour from banqueting");
						case 1:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_BANQUET_KING2", "Raise over 10,000 honour from banqueting");
						case 2:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_BANQUET_KING3", "Raise over 100,000 honour from banqueting");
						case 3:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_BANQUET_KING4", "Raise over 1,000,000 honour from banqueting");
						case 4:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_BANQUET_KING5", "Raise over 10,000,000 honour from banqueting");
						case 5:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_BANQUET_KING6", "Raise over 100,000,000 honour from banqueting");
						case 6:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_BANQUET_KING7", "Raise over 250,000,000 honour from banqueting");
						}
					}
				}
				else
				{
					switch (rankLevel)
					{
					case 0:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_FINE_DINING1", "Hold a banquet with at least 3 goods types");
					case 1:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_FINE_DINING2", "Hold a banquet with at least 5 goods types");
					case 2:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_FINE_DINING3", "Hold a banquet with at least 7 goods types");
					case 3:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_FINE_DINING4", "Hold a banquet with all 8 goods types");
					}
				}
			}
			else if (achievement <= 353)
			{
				if (achievement != 321)
				{
					if (achievement == 353)
					{
						switch (rankLevel)
						{
						case 0:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_TEAM_PLAYER1", "Donate 10 packets to capital buildings");
						case 1:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_TEAM_PLAYER2", "Donate 100 packets to capital buildings");
						case 2:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_TEAM_PLAYER3", "Donate 1,000 packets to capital buildings");
						case 3:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_TEAM_PLAYER4", "Donate 10,000 packets to capital buildings");
						case 4:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_TEAM_PLAYER5", "Donate 100,000 packets to capital buildings");
						case 5:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_TEAM_PLAYER6", "Donate 250,000 packets to capital buildings");
						case 6:
							return SK.Text("TOOLTIPS_ACHIEVEMENTS_TEAM_PLAYER7", "Donate 500,000 packets to capital buildings");
						}
					}
				}
				else
				{
					switch (rankLevel)
					{
					case 0:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_FAME1", "Reach the top 100 in any of the leaderboards");
					case 1:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_FAME2", "Reach the top 20 in any of the leaderboards");
					case 2:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_FAME3", "Reach the top 5 in any of the leaderboards");
					case 3:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_FAME4", "Reach the top position in any of the leaderboards");
					}
				}
			}
			else if (achievement != 354)
			{
				switch (achievement)
				{
				case 385:
					switch (rankLevel)
					{
					case 0:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_OFFICER1", "Become a Parish Steward");
					case 1:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_OFFICER2", "Hold the office of Steward in 2 parishes");
					case 2:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_OFFICER3", "Hold the office of Steward in 3 parishes");
					case 3:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_OFFICER4", "Hold the office of Steward in 4 parishes");
					}
					break;
				case 386:
					switch (rankLevel)
					{
					case 0:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_HIGH_OFFICER1", "Become a Sheriff of a County");
					case 1:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_HIGH_OFFICER2", "Hold the office of Sheriff in 2 Counties");
					case 2:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_HIGH_OFFICER3", "Hold the office of Sheriff in 3 Counties");
					case 3:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_HIGH_OFFICER4", "Hold the office of Sheriff in 4 Counties");
					}
					break;
				case 387:
					switch (rankLevel)
					{
					case 0:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_MIGHTY_RULER1", "Become a Governor of a Province ");
					case 1:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_MIGHTY_RULER2", "Hold the office of Governor in 2 Provinces");
					case 2:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_MIGHTY_RULER3", "Hold the office of Governor in 3 Provinces");
					case 3:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_MIGHTY_RULER4", "Hold the office of Governor in 4 Provinces");
					}
					break;
				case 388:
					switch (rankLevel)
					{
					case 0:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_LIONHEART1_Monarch", "Become the Monarch of a Country");
					case 1:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_LIONHEART2_Monarch", "Be the Monarch of 2 Countries");
					case 2:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_LIONHEART3_Monarch", "Be the Monarch of 3 Countries");
					case 3:
						return SK.Text("TOOLTIPS_ACHIEVEMENTS_LIONHEART4_Monarch", "Be the Monarch of 4 Countries");
					}
					break;
				}
			}
			else
			{
				switch (rankLevel)
				{
				case 0:
					return SK.Text("TOOLTIPS_ACHIEVEMENTS_SKILLED_RULER1", "Place 3 buildings in any capital town");
				case 1:
					return SK.Text("TOOLTIPS_ACHIEVEMENTS_SKILLED_RULER2", "Place 15 buildings in any capital town");
				case 2:
					return SK.Text("TOOLTIPS_ACHIEVEMENTS_SKILLED_RULER3", "Place 50 buildings in any capital town");
				case 3:
					return SK.Text("TOOLTIPS_ACHIEVEMENTS_SKILLED_RULER4", "Place 250 buildings in any capital town");
				}
			}
			return "";
		}

		// Token: 0x06000F9F RID: 3999 RVA: 0x00011625 File Offset: 0x0000F825
		private static bool dynamicUpdateTooltips(int ID)
		{
			return ID == 10000 || ID == 24100;
		}

		// Token: 0x06000FA0 RID: 4000 RVA: 0x00111A4C File Offset: 0x0010FC4C
		public static string getHouseMotto(int houseID)
		{
			switch (houseID)
			{
			case 0:
				return SK.Text("House_Motto_0", "The Dispossessed");
			case 1:
				return SK.Text("House_Motto_1", "The Heavenly Ones");
			case 2:
				return SK.Text("House_Motto_2", "High Castle");
			case 3:
				return SK.Text("House_Motto_3", "The Dragons");
			case 4:
				return SK.Text("House_Motto_4", "The Farmers");
			case 5:
				return SK.Text("House_Motto_5", "The Navigators");
			case 6:
				return SK.Text("House_Motto_6", "The Free Folk");
			case 7:
				return SK.Text("House_Motto_7", "The Royals");
			case 8:
				return SK.Text("House_Motto_8", "The Roses");
			case 9:
				return SK.Text("House_Motto_9", "The Rams");
			case 10:
				return SK.Text("House_Motto_10", "Fighters");
			case 11:
				return SK.Text("House_Motto_11", "Heroes");
			case 12:
				return SK.Text("House_Motto_12", "Stags");
			case 13:
				return SK.Text("House_Motto_13", "Oak");
			case 14:
				return SK.Text("House_Motto_14", "Beasts");
			case 15:
				return SK.Text("House_Motto_15", "The Pure");
			case 16:
				return SK.Text("House_Motto_16", "Lionheart");
			case 17:
				return SK.Text("House_Motto_17", "The Insane");
			case 18:
				return SK.Text("House_Motto_18", "Sinners");
			case 19:
				return SK.Text("House_Motto_19", "The Double-Eagles");
			case 20:
				return SK.Text("House_Motto_20", "Maidens");
			default:
				return "";
			}
		}

		// Token: 0x04001372 RID: 4978
		private static int showingTooltip = 0;

		// Token: 0x04001373 RID: 4979
		private static int currentOverTooltip = 0;

		// Token: 0x04001374 RID: 4980
		private static int lastOverTooltip = 0;

		// Token: 0x04001375 RID: 4981
		private static DateTime lastLeaveTime = DateTime.MinValue;

		// Token: 0x04001376 RID: 4982
		private static int currentOverData = 0;

		// Token: 0x04001377 RID: 4983
		private static int currentOverLastData = 0;

		// Token: 0x04001378 RID: 4984
		private static Form currentParentWindow = null;

		// Token: 0x04001379 RID: 4985
		public static int storedCurrentOverData = 0;

		// Token: 0x0400137A RID: 4986
		public static int storedCurrentOverTooltip = 0;

		// Token: 0x0400137B RID: 4987
		public static Form storedCurrentParentWindow = null;

		// Token: 0x0400137C RID: 4988
		private static bool overTooltip = false;

		// Token: 0x0400137D RID: 4989
		public static WorldMap.CachedUserInfo UserInfo = null;

		// Token: 0x0400137E RID: 4990
		private static bool inSystemControl = false;

		// Token: 0x0400137F RID: 4991
		private static Point lastMousePosition = default(Point);

		// Token: 0x04001380 RID: 4992
		private static DateTime lastMouseMoveTime = DateTime.MinValue;

		// Token: 0x04001381 RID: 4993
		private static bool staticMouse = false;

		// Token: 0x02000192 RID: 402
		public class TooltipID
		{
			// Token: 0x04001382 RID: 4994
			public const int NO_TOOLTIP = 0;

			// Token: 0x04001383 RID: 4995
			public const int MAINWINDOW_CARDS_SHOW_ALL_CARDS = 1;

			// Token: 0x04001384 RID: 4996
			public const int MAINWINDOW_TOP_LEFT_USERNAME = 2;

			// Token: 0x04001385 RID: 4997
			public const int MAINWINDOW_TOP_LEFT_RANKING = 3;

			// Token: 0x04001386 RID: 4998
			public const int MAINWINDOW_TOP_LEFT_HONOUR = 4;

			// Token: 0x04001387 RID: 4999
			public const int MAINWINDOW_TOP_LEFT_GOLD = 5;

			// Token: 0x04001388 RID: 5000
			public const int MAINWINDOW_TOP_LEFT_FAITHPOINTS = 6;

			// Token: 0x04001389 RID: 5001
			public const int MAINWINDOW_TOP_LEFT_POINTS = 7;

			// Token: 0x0400138A RID: 5002
			public const int MAINWINDOW_TOP_LEFT_SECOND_AGE = 8;

			// Token: 0x0400138B RID: 5003
			public const int MAINWINDOW_TOP_LEFT_THIRD_AGE = 9;

			// Token: 0x0400138C RID: 5004
			public const int MAINWINDOW_TOP_LEFT_DOMINATION_WORLD = 10;

			// Token: 0x0400138D RID: 5005
			public const int MAINWINDOW_TOP_LEFT_HC_TIME_LEFT = 11;

			// Token: 0x0400138E RID: 5006
			public const int MAINWINDOW_TOP_LEFT_FOURTH_AGE = 12;

			// Token: 0x0400138F RID: 5007
			public const int MAINWINDOW_TOP_LEFT_FIFTH_AGE = 13;

			// Token: 0x04001390 RID: 5008
			public const int MAINWINDOW_TOP_LEFT_SIXTH_AGE = 14;

			// Token: 0x04001391 RID: 5009
			public const int MAINWINDOW_TOP_LEFT_SEVENTH_AGE = 15;

			// Token: 0x04001392 RID: 5010
			public const int MAINWINDOW_TOP_RIGHT_VILLAGE_SCROLL = 20;

			// Token: 0x04001393 RID: 5011
			public const int MAINWINDOW_TOP_RIGHT_VILLAGE_LIST = 21;

			// Token: 0x04001394 RID: 5012
			public const int MAINWINDOW_TOP_RIGHT_MAIN_TAB_WORLDMAP = 22;

			// Token: 0x04001395 RID: 5013
			public const int MAINWINDOW_TOP_RIGHT_MAIN_TAB_VILLAGEMAP = 23;

			// Token: 0x04001396 RID: 5014
			public const int MAINWINDOW_TOP_RIGHT_MAIN_TAB_RESEARCH = 24;

			// Token: 0x04001397 RID: 5015
			public const int MAINWINDOW_TOP_RIGHT_MAIN_TAB_RANKING = 25;

			// Token: 0x04001398 RID: 5016
			public const int MAINWINDOW_TOP_RIGHT_MAIN_TAB_ATTACKS = 26;

			// Token: 0x04001399 RID: 5017
			public const int MAINWINDOW_TOP_RIGHT_MAIN_TAB_REPORTS = 27;

			// Token: 0x0400139A RID: 5018
			public const int MAINWINDOW_TOP_RIGHT_MAIN_TAB_MAIL = 28;

			// Token: 0x0400139B RID: 5019
			public const int MAINWINDOW_TOP_RIGHT_MAIN_TAB_LEADERBOARD = 29;

			// Token: 0x0400139C RID: 5020
			public const int MAINWINDOW_TOP_RIGHT_MAIN_TAB_FACTIONS = 30;

			// Token: 0x0400139D RID: 5021
			public const int MAINWINDOW_TOP_RIGHT_MAIN_TAB_QUESTS = 31;

			// Token: 0x0400139E RID: 5022
			public const int MAINWINDOW_TOP_RIGHT_MAIN_TAB_CAPITAL = 32;

			// Token: 0x0400139F RID: 5023
			public const int MAINWINDOW_TOP_RIGHT_MAIN_TAB_PREMIUM_VO = 33;

			// Token: 0x040013A0 RID: 5024
			public const int MAINWINDOW_TOP_RIGHT_MAIN_TAB_CONTEST = 34;

			// Token: 0x040013A1 RID: 5025
			public const int MAINWINDOW_TOP_RIGHT_VILLAGE_TAB_VILLAGE = 40;

			// Token: 0x040013A2 RID: 5026
			public const int MAINWINDOW_TOP_RIGHT_VILLAGE_TAB_CASTLE = 41;

			// Token: 0x040013A3 RID: 5027
			public const int MAINWINDOW_TOP_RIGHT_VILLAGE_TAB_RESOURCES = 42;

			// Token: 0x040013A4 RID: 5028
			public const int MAINWINDOW_TOP_RIGHT_VILLAGE_TAB_TRADING = 43;

			// Token: 0x040013A5 RID: 5029
			public const int MAINWINDOW_TOP_RIGHT_VILLAGE_TAB_TROOPS = 44;

			// Token: 0x040013A6 RID: 5030
			public const int MAINWINDOW_TOP_RIGHT_VILLAGE_TAB_UNITS = 45;

			// Token: 0x040013A7 RID: 5031
			public const int MAINWINDOW_TOP_RIGHT_VILLAGE_TAB_UNKNOWN = 46;

			// Token: 0x040013A8 RID: 5032
			public const int MAINWINDOW_TOP_RIGHT_VILLAGE_TAB_BANQUETING = 47;

			// Token: 0x040013A9 RID: 5033
			public const int MAINWINDOW_TOP_RIGHT_VILLAGE_TAB_VASSALS = 48;

			// Token: 0x040013AA RID: 5034
			public const int MAINWINDOW_TOP_RIGHT_VILLAGE_TAB_CAPITAL_INFO = 49;

			// Token: 0x040013AB RID: 5035
			public const int MAINWINDOW_TOP_RIGHT_VILLAGE_TAB_CAPITAL_VOTE = 50;

			// Token: 0x040013AC RID: 5036
			public const int MAINWINDOW_TOP_RIGHT_VILLAGE_TAB_CAPITAL_FORUM = 51;

			// Token: 0x040013AD RID: 5037
			public const int MAINWINDOW_TOP_RIGHT_VILLAGE_TAB_NOT_IMPLEMENTED_YET = 52;

			// Token: 0x040013AE RID: 5038
			public const int MAINWINDOW_TOP_RIGHT_MAIN_TAB_CHAT = 53;

			// Token: 0x040013AF RID: 5039
			public const int MAINWINDOW_VILLAGE_NAME_TEST = 90;

			// Token: 0x040013B0 RID: 5040
			public const int MAINWINDOW_MAP_FILTERING = 91;

			// Token: 0x040013B1 RID: 5041
			public const int MAINWINDOW_MAP_FILTERING_CLOSE = 92;

			// Token: 0x040013B2 RID: 5042
			public const int MAINWINDOW_MAP_FILTERING_ACTIVE = 93;

			// Token: 0x040013B3 RID: 5043
			public const int MAINWINDOW_ATTACK_TARGETS = 94;

			// Token: 0x040013B4 RID: 5044
			public const int VILLAGEMAP_RIGHT_PANEL_BUILDING_ROLLOVER = 100;

			// Token: 0x040013B5 RID: 5045
			public const int VILLAGEMAP_RIGHT_PANEL_BUILDING_TAB_1 = 101;

			// Token: 0x040013B6 RID: 5046
			public const int VILLAGEMAP_RIGHT_PANEL_BUILDING_TAB_2 = 102;

			// Token: 0x040013B7 RID: 5047
			public const int VILLAGEMAP_RIGHT_PANEL_BUILDING_TAB_3 = 103;

			// Token: 0x040013B8 RID: 5048
			public const int VILLAGEMAP_RIGHT_PANEL_BUILDING_TAB_4 = 104;

			// Token: 0x040013B9 RID: 5049
			public const int VILLAGEMAP_RIGHT_PANEL_BUILDING_TAB_5 = 105;

			// Token: 0x040013BA RID: 5050
			public const int VILLAGEMAP_RIGHT_PANEL_CAPITAL_BUILDING_TAB_1 = 106;

			// Token: 0x040013BB RID: 5051
			public const int VILLAGEMAP_RIGHT_PANEL_CAPITAL_BUILDING_TAB_2 = 107;

			// Token: 0x040013BC RID: 5052
			public const int VILLAGEMAP_RIGHT_PANEL_CAPITAL_BUILDING_TAB_3 = 108;

			// Token: 0x040013BD RID: 5053
			public const int VILLAGEMAP_RIGHT_PANEL_CAPITAL_BUILDING_TAB_4 = 109;

			// Token: 0x040013BE RID: 5054
			public const int VILLAGEMAP_RIGHT_PANEL_EXTRAS_BAR = 110;

			// Token: 0x040013BF RID: 5055
			public const int VILLAGEMAP_RIGHT_PANEL_HONOUR_BAR = 111;

			// Token: 0x040013C0 RID: 5056
			public const int VILLAGEMAP_RIGHT_PANEL_HONOUR_BAR_CLOSE = 112;

			// Token: 0x040013C1 RID: 5057
			public const int VILLAGEMAP_RIGHT_PANEL_IN_BUILDING_CLOSE = 113;

			// Token: 0x040013C2 RID: 5058
			public const int VILLAGEMAP_RIGHT_PANEL_MOVE_BUILDING = 114;

			// Token: 0x040013C3 RID: 5059
			public const int VILLAGEMAP_RIGHT_PANEL_TAX_INC = 115;

			// Token: 0x040013C4 RID: 5060
			public const int VILLAGEMAP_RIGHT_PANEL_TAX_DEC = 116;

			// Token: 0x040013C5 RID: 5061
			public const int VILLAGEMAP_RIGHT_PANEL_RATIONS_INC = 117;

			// Token: 0x040013C6 RID: 5062
			public const int VILLAGEMAP_RIGHT_PANEL_RATIONS_DEC = 118;

			// Token: 0x040013C7 RID: 5063
			public const int VILLAGEMAP_RIGHT_PANEL_ALE_INC = 119;

			// Token: 0x040013C8 RID: 5064
			public const int VILLAGEMAP_RIGHT_PANEL_ALE_DEC = 120;

			// Token: 0x040013C9 RID: 5065
			public const int VILLAGEMAP_RIGHT_PANEL_POPULARITY_BAR = 121;

			// Token: 0x040013CA RID: 5066
			public const int VILLAGEMAP_RIGHT_PANEL_POPULARITY_BAR_CLOSE = 122;

			// Token: 0x040013CB RID: 5067
			public const int VILLAGEMAP_RIGHT_PANEL_DETAILED_TAX_OPEN = 123;

			// Token: 0x040013CC RID: 5068
			public const int VILLAGEMAP_RIGHT_PANEL_DETAILED_TAX_CLOSE = 124;

			// Token: 0x040013CD RID: 5069
			public const int VILLAGEMAP_RIGHT_PANEL_DETAILED_RATIONS_OPEN = 125;

			// Token: 0x040013CE RID: 5070
			public const int VILLAGEMAP_RIGHT_PANEL_DETAILED_RATIONS_CLOSE = 126;

			// Token: 0x040013CF RID: 5071
			public const int VILLAGEMAP_RIGHT_PANEL_DETAILED_ALE_OPEN = 127;

			// Token: 0x040013D0 RID: 5072
			public const int VILLAGEMAP_RIGHT_PANEL_DETAILED_ALE_CLOSE = 128;

			// Token: 0x040013D1 RID: 5073
			public const int VILLAGEMAP_RIGHT_PANEL_DETAILED_HOUSING_OPEN = 129;

			// Token: 0x040013D2 RID: 5074
			public const int VILLAGEMAP_RIGHT_PANEL_DETAILED_HOUSING_CLOSE = 130;

			// Token: 0x040013D3 RID: 5075
			public const int VILLAGEMAP_RIGHT_PANEL_DETAILED_ENTERTAINMENT_OPEN = 131;

			// Token: 0x040013D4 RID: 5076
			public const int VILLAGEMAP_RIGHT_PANEL_DETAILED_ENTERTAINMENT_CLOSE = 132;

			// Token: 0x040013D5 RID: 5077
			public const int VILLAGEMAP_RIGHT_PANEL_DETAILED_EVENTS_OPEN = 133;

			// Token: 0x040013D6 RID: 5078
			public const int VILLAGEMAP_RIGHT_PANEL_DETAILED_EVENTS_CLOSE = 134;

			// Token: 0x040013D7 RID: 5079
			public const int VILLAGEMAP_RIGHT_PANEL_BUILD_INFO = 140;

			// Token: 0x040013D8 RID: 5080
			public const int VILLAGEMAP_INFO_BAR_PEOPLE = 141;

			// Token: 0x040013D9 RID: 5081
			public const int VILLAGEMAP_INFO_BAR_WOOD = 142;

			// Token: 0x040013DA RID: 5082
			public const int VILLAGEMAP_INFO_BAR_STONE = 143;

			// Token: 0x040013DB RID: 5083
			public const int VILLAGEMAP_INFO_BAR_FOOD = 144;

			// Token: 0x040013DC RID: 5084
			public const int VILLAGEMAP_INFO_BAR_CAPITAL_GOLD = 145;

			// Token: 0x040013DD RID: 5085
			public const int VILLAGEMAP_INFO_BAR_CAPITAL_FLAGS = 146;

			// Token: 0x040013DE RID: 5086
			public const int VILLAGEMAP_INFO_BAR_DONATION_TYPE = 147;

			// Token: 0x040013DF RID: 5087
			public const int VILLAGEMAP_INFO_BAR_PITCH = 148;

			// Token: 0x040013E0 RID: 5088
			public const int VILLAGEMAP_INFO_BAR_IRON = 149;

			// Token: 0x040013E1 RID: 5089
			public const int VILLAGEMAP_CAPITAL_OVER_COMPLETED = 150;

			// Token: 0x040013E2 RID: 5090
			public const int VILLAGEMAP_CAPITAL_OVER_NOTCOMPLETED = 151;

			// Token: 0x040013E3 RID: 5091
			public const int CASTLEMAP_RIGHT_PANEL_BUILDING_ROLLOVER = 200;

			// Token: 0x040013E4 RID: 5092
			public const int CASTLEMAP_RIGHT_PANEL_BUILDING_TAB_1 = 201;

			// Token: 0x040013E5 RID: 5093
			public const int CASTLEMAP_RIGHT_PANEL_BUILDING_TAB_2 = 202;

			// Token: 0x040013E6 RID: 5094
			public const int CASTLEMAP_RIGHT_PANEL_BUILDING_TAB_3 = 203;

			// Token: 0x040013E7 RID: 5095
			public const int CASTLEMAP_RIGHT_PANEL_BUILDING_TAB_4 = 204;

			// Token: 0x040013E8 RID: 5096
			public const int CASTLEMAP_RIGHT_PANEL_TOGGLE_REINFORCEMENTS_ON = 205;

			// Token: 0x040013E9 RID: 5097
			public const int CASTLEMAP_RIGHT_PANEL_TOGGLE_REINFORCEMENTS_OFF = 206;

			// Token: 0x040013EA RID: 5098
			public const int CASTLEMAP_RIGHT_PANEL_1X1 = 207;

			// Token: 0x040013EB RID: 5099
			public const int CASTLEMAP_RIGHT_PANEL_3X3 = 208;

			// Token: 0x040013EC RID: 5100
			public const int CASTLEMAP_RIGHT_PANEL_5X5 = 209;

			// Token: 0x040013ED RID: 5101
			public const int CASTLEMAP_RIGHT_PANEL_1X5 = 210;

			// Token: 0x040013EE RID: 5102
			public const int CASTLEMAP_RIGHT_PANEL_TOGGLE_VIEWMODE_HIGH = 211;

			// Token: 0x040013EF RID: 5103
			public const int CASTLEMAP_RIGHT_PANEL_TOGGLE_VIEWMODE_LOW = 212;

			// Token: 0x040013F0 RID: 5104
			public const int CASTLEMAP_RIGHT_PANEL_TOGGLE_DELETE_ON = 213;

			// Token: 0x040013F1 RID: 5105
			public const int CASTLEMAP_RIGHT_PANEL_TOGGLE_DELETE_OFF = 214;

			// Token: 0x040013F2 RID: 5106
			public const int CASTLEMAP_RIGHT_PANEL_CASTLE_CONSTRUCTION_OPTIONS_OPEN = 215;

			// Token: 0x040013F3 RID: 5107
			public const int CASTLEMAP_RIGHT_PANEL_CASTLE_CONSTRUCTION_OPTIONS_CLOSE = 216;

			// Token: 0x040013F4 RID: 5108
			public const int CASTLEMAP_RIGHT_PANEL_REPAIR = 217;

			// Token: 0x040013F5 RID: 5109
			public const int CASTLEMAP_RIGHT_PANEL_DELETE_CONSTRUCTING = 218;

			// Token: 0x040013F6 RID: 5110
			public const int CASTLEMAP_RIGHT_PANEL_CONFIRM = 219;

			// Token: 0x040013F7 RID: 5111
			public const int CASTLEMAP_RIGHT_PANEL_CANCEL = 220;

			// Token: 0x040013F8 RID: 5112
			public const int CASTLEMAP_RIGHT_PANEL_DELETE_TROOPS = 221;

			// Token: 0x040013F9 RID: 5113
			public const int CASTLEMAP_RIGHT_PANEL_TOGGLE_AGGRESSIVE = 222;

			// Token: 0x040013FA RID: 5114
			public const int CASTLEMAP_RIGHT_PANEL_BUILDING_TAB_5 = 223;

			// Token: 0x040013FB RID: 5115
			public const int CASTLEMAP_PRESET_MEMORISE = 224;

			// Token: 0x040013FC RID: 5116
			public const int CASTLEMAP_PRESET_DEPLOY = 225;

			// Token: 0x040013FD RID: 5117
			public const int CASTLEMAP_PRESET_RENAME = 226;

			// Token: 0x040013FE RID: 5118
			public const int CASTLEMAP_PRESET_DELETE = 227;

			// Token: 0x040013FF RID: 5119
			public const int CASTLEMAP_PRESET_DETAILS = 228;

			// Token: 0x04001400 RID: 5120
			public const int CASTLEMAP_PRESET_RETURN = 229;

			// Token: 0x04001401 RID: 5121
			public const int CASTLEMAP_PRESET_DEFENCE_REQ = 230;

			// Token: 0x04001402 RID: 5122
			public const int CASTLEMAP_PRESET_FORTIFICATION_REQ = 231;

			// Token: 0x04001403 RID: 5123
			public const int CASTLEMAP_PRESET_PARISH_REQ = 232;

			// Token: 0x04001404 RID: 5124
			public const int CASTLEMAP_PRESET_WOOD = 233;

			// Token: 0x04001405 RID: 5125
			public const int CASTLEMAP_PRESET_STONE = 234;

			// Token: 0x04001406 RID: 5126
			public const int CASTLEMAP_PRESET_IRON = 235;

			// Token: 0x04001407 RID: 5127
			public const int CASTLEMAP_PRESET_PITCH = 236;

			// Token: 0x04001408 RID: 5128
			public const int CASTLEMAP_PRESET_GOLD = 237;

			// Token: 0x04001409 RID: 5129
			public const int CASTLEMAP_PRESET_TIME = 238;

			// Token: 0x0400140A RID: 5130
			public const int CASTLEMAP_PRESET_REQ_NOT_MET = 239;

			// Token: 0x0400140B RID: 5131
			public const int CASTLEMAP_PRESET_PREVIEW = 240;

			// Token: 0x0400140C RID: 5132
			public const int RESEARCHTREE_LIST_MODE = 300;

			// Token: 0x0400140D RID: 5133
			public const int RESEARCHTREE_TREE_MODE = 301;

			// Token: 0x0400140E RID: 5134
			public const int RESEARCH_QUEUE = 302;

			// Token: 0x0400140F RID: 5135
			public const int RANKING_UPGRADE = 400;

			// Token: 0x04001410 RID: 5136
			public const int RANKING_IMAGE = 401;

			// Token: 0x04001411 RID: 5137
			public const int MAILSCREEN_FLOAT = 500;

			// Token: 0x04001412 RID: 5138
			public const int MAILSCREEN_DOCK = 501;

			// Token: 0x04001413 RID: 5139
			public const int MAILSCREEN_CLOSE = 502;

			// Token: 0x04001414 RID: 5140
			public const int MAILSCREEN_REPORT = 503;

			// Token: 0x04001415 RID: 5141
			public const int MAILSCREEN_AGGRESSIVE_BLOCK = 504;

			// Token: 0x04001416 RID: 5142
			public const int MAIL_SEARCH = 505;

			// Token: 0x04001417 RID: 5143
			public const int MAIL_RECENT = 506;

			// Token: 0x04001418 RID: 5144
			public const int MAIL_FAVOURITES = 507;

			// Token: 0x04001419 RID: 5145
			public const int MAIL_OTHERS_KNOWN = 508;

			// Token: 0x0400141A RID: 5146
			public const int MAIL_SEARCH_USER = 510;

			// Token: 0x0400141B RID: 5147
			public const int MAIL_SELECT_VILLAGE = 511;

			// Token: 0x0400141C RID: 5148
			public const int MAIL_SEARCH_REGION = 512;

			// Token: 0x0400141D RID: 5149
			public const int MAIL_CURRENT_ATTACHMENTS = 513;

			// Token: 0x0400141E RID: 5150
			public const int MAIL_OPEN_ATTACHMENTS = 514;

			// Token: 0x0400141F RID: 5151
			public const int MAIL_LINK_PLAYER = 515;

			// Token: 0x04001420 RID: 5152
			public const int MAIL_LINK_VILLAGE = 516;

			// Token: 0x04001421 RID: 5153
			public const int MAIL_LINK_PARISH = 517;

			// Token: 0x04001422 RID: 5154
			public const int MAIL_VILLAGE_SEARCH_DISABLED = 518;

			// Token: 0x04001423 RID: 5155
			public const int BARRACKS_DISBAND = 600;

			// Token: 0x04001424 RID: 5156
			public const int BARRACKS_CLOSE = 601;

			// Token: 0x04001425 RID: 5157
			public const int BARRACKS_PEASANTS = 602;

			// Token: 0x04001426 RID: 5158
			public const int BARRACKS_ARCHERS = 603;

			// Token: 0x04001427 RID: 5159
			public const int BARRACKS_PIKEMEN = 604;

			// Token: 0x04001428 RID: 5160
			public const int BARRACKS_SWORDSMEN = 605;

			// Token: 0x04001429 RID: 5161
			public const int BARRACKS_CATAPULTS = 606;

			// Token: 0x0400142A RID: 5162
			public const int BARRACKS_CAPTAINS = 607;

			// Token: 0x0400142B RID: 5163
			public const int BARRACKS_ARCHERS_NOT_RESEARCHED = 608;

			// Token: 0x0400142C RID: 5164
			public const int BARRACKS_PIKEMEN_NOT_RESEARCHED = 609;

			// Token: 0x0400142D RID: 5165
			public const int BARRACKS_SWORDSMEN_NOT_RESEARCHED = 610;

			// Token: 0x0400142E RID: 5166
			public const int BARRACKS_CATAPULTS_NOT_RESEARCHED = 611;

			// Token: 0x0400142F RID: 5167
			public const int BARRACKS_CAPTAINS_NOT_RESEARCHED = 612;

			// Token: 0x04001430 RID: 5168
			public const int UNITS_DISBAND = 700;

			// Token: 0x04001431 RID: 5169
			public const int UNITS_CLOSE = 701;

			// Token: 0x04001432 RID: 5170
			public const int UNITS_SPACE_REQUIRED = 702;

			// Token: 0x04001433 RID: 5171
			public const int UNITS_MERCHANTS = 703;

			// Token: 0x04001434 RID: 5172
			public const int UNITS_MONKS = 704;

			// Token: 0x04001435 RID: 5173
			public const int UNITS_SCOUTS = 705;

			// Token: 0x04001436 RID: 5174
			public const int UNITS_MERCHANTS_NOT_RESEARCHED = 706;

			// Token: 0x04001437 RID: 5175
			public const int UNITS_MONKS_NOT_RESEARCHED = 707;

			// Token: 0x04001438 RID: 5176
			public const int UNITS_SCOUTS_NOT_RESEARCHED = 708;

			// Token: 0x04001439 RID: 5177
			public const int STOCKEXCHANGE_CLOSE = 800;

			// Token: 0x0400143A RID: 5178
			public const int TRADE_CLOSE = 801;

			// Token: 0x0400143B RID: 5179
			public const int TRADE_RESOURCES = 802;

			// Token: 0x0400143C RID: 5180
			public const int TRADE_FOOD = 803;

			// Token: 0x0400143D RID: 5181
			public const int TRADE_WEAPONS = 804;

			// Token: 0x0400143E RID: 5182
			public const int TRADE_BANQUETING = 805;

			// Token: 0x0400143F RID: 5183
			public const int TOGGLE_TO_STOCKEXCHANGE = 806;

			// Token: 0x04001440 RID: 5184
			public const int TOGGLE_TO_TRADING = 807;

			// Token: 0x04001441 RID: 5185
			public const int REMOVE_FAVOURITE = 808;

			// Token: 0x04001442 RID: 5186
			public const int ADD_FAVOURITE = 809;

			// Token: 0x04001443 RID: 5187
			public const int REMOVE_RECENT = 810;

			// Token: 0x04001444 RID: 5188
			public const int REMOVE_FAVOURITE_MARKET = 811;

			// Token: 0x04001445 RID: 5189
			public const int ADD_FAVOURITE_MARKET = 812;

			// Token: 0x04001446 RID: 5190
			public const int REMOVE_RECENT_MARKET = 813;

			// Token: 0x04001447 RID: 5191
			public const int FIND_HIGHEST_PRICE = 814;

			// Token: 0x04001448 RID: 5192
			public const int FIND_LOWEST_PRICE = 815;

			// Token: 0x04001449 RID: 5193
			public const int RESOURCES_CLOSE = 900;

			// Token: 0x0400144A RID: 5194
			public const int RESOURCES_INFO = 901;

			// Token: 0x0400144B RID: 5195
			public const int BANQUET_CLOSE = 1000;

			// Token: 0x0400144C RID: 5196
			public const int AREASELECT_OVER_TAG = 1100;

			// Token: 0x0400144D RID: 5197
			public const int AREASELECT_OVER_TAG_FULL = 1101;

			// Token: 0x0400144E RID: 5198
			public const int MENUBAR_CONVERT = 1200;

			// Token: 0x0400144F RID: 5199
			public const int MENUBAR_ABANDON = 1201;

			// Token: 0x04001450 RID: 5200
			public const int STATS_CATEGORY_ICONS = 1300;

			// Token: 0x04001451 RID: 5201
			public const int LOGOUT_CLOSE = 1400;

			// Token: 0x04001452 RID: 5202
			public const int LOGOUT_AUTO_TRADE = 1401;

			// Token: 0x04001453 RID: 5203
			public const int LOGOUT_AUTO_SCOUT = 1402;

			// Token: 0x04001454 RID: 5204
			public const int LOGOUT_AUTO_ATTACK = 1403;

			// Token: 0x04001455 RID: 5205
			public const int LOGOUT_AUTO_RECRUIT = 1404;

			// Token: 0x04001456 RID: 5206
			public const int LOGOUT_AUTO_REBUILD = 1405;

			// Token: 0x04001457 RID: 5207
			public const int LOGOUT_AUTO_TRANSFER = 1406;

			// Token: 0x04001458 RID: 5208
			public const int LOGOUT_SELECT_TRADE_RESOURCE = 1407;

			// Token: 0x04001459 RID: 5209
			public const int LOGOUT_SELECT_TRADE_PERCENT = 1408;

			// Token: 0x0400145A RID: 5210
			public const int LOGOUT_ATTACK_BANDITS = 1409;

			// Token: 0x0400145B RID: 5211
			public const int LOGOUT_ATTACK_WOLVES = 1410;

			// Token: 0x0400145C RID: 5212
			public const int LOGOUT_ATTACK_AI = 1411;

			// Token: 0x0400145D RID: 5213
			public const int LOGOUT_RECRUIT_PEASANT = 1412;

			// Token: 0x0400145E RID: 5214
			public const int LOGOUT_RECRUIT_ARCHER = 1413;

			// Token: 0x0400145F RID: 5215
			public const int LOGOUT_RECRUIT_PIKEMAN = 1414;

			// Token: 0x04001460 RID: 5216
			public const int LOGOUT_RECRUIT_SWORDSMAN = 1415;

			// Token: 0x04001461 RID: 5217
			public const int LOGOUT_RECRUIT_CATAPULT = 1416;

			// Token: 0x04001462 RID: 5218
			public const int LOGOUT_RESOURCES = 1417;

			// Token: 0x04001463 RID: 5219
			public const int LOGOUT_EXIT = 1418;

			// Token: 0x04001464 RID: 5220
			public const int LOGOUT_CANCEL = 1419;

			// Token: 0x04001465 RID: 5221
			public const int LOGOUT_SWAP_WORLDS = 1420;

			// Token: 0x04001466 RID: 5222
			public const int LOGOUT_PREMIUM = 1421;

			// Token: 0x04001467 RID: 5223
			public const int REPORTS_FILTER = 1500;

			// Token: 0x04001468 RID: 5224
			public const int REPORTS_CAPTURE = 1501;

			// Token: 0x04001469 RID: 5225
			public const int REPORTS_DELETE = 1502;

			// Token: 0x0400146A RID: 5226
			public const int TUTORIAL_REOPEN = 1600;

			// Token: 0x0400146B RID: 5227
			public const int TUTORIAL_PLAYER_GUILD = 1601;

			// Token: 0x0400146C RID: 5228
			public const int GLORY_HOUSE = 1700;

			// Token: 0x0400146D RID: 5229
			public const int GLORY_HOUSE_1 = 1700;

			// Token: 0x0400146E RID: 5230
			public const int GLORY_HOUSE_2 = 1701;

			// Token: 0x0400146F RID: 5231
			public const int GLORY_HOUSE_3 = 1702;

			// Token: 0x04001470 RID: 5232
			public const int GLORY_HOUSE_4 = 1703;

			// Token: 0x04001471 RID: 5233
			public const int GLORY_HOUSE_5 = 1704;

			// Token: 0x04001472 RID: 5234
			public const int GLORY_HOUSE_6 = 1705;

			// Token: 0x04001473 RID: 5235
			public const int GLORY_HOUSE_7 = 1706;

			// Token: 0x04001474 RID: 5236
			public const int GLORY_HOUSE_8 = 1707;

			// Token: 0x04001475 RID: 5237
			public const int GLORY_HOUSE_9 = 1708;

			// Token: 0x04001476 RID: 5238
			public const int GLORY_HOUSE_10 = 1709;

			// Token: 0x04001477 RID: 5239
			public const int GLORY_HOUSE_11 = 1710;

			// Token: 0x04001478 RID: 5240
			public const int GLORY_HOUSE_12 = 1711;

			// Token: 0x04001479 RID: 5241
			public const int GLORY_HOUSE_13 = 1712;

			// Token: 0x0400147A RID: 5242
			public const int GLORY_HOUSE_14 = 1713;

			// Token: 0x0400147B RID: 5243
			public const int GLORY_HOUSE_15 = 1714;

			// Token: 0x0400147C RID: 5244
			public const int GLORY_HOUSE_16 = 1715;

			// Token: 0x0400147D RID: 5245
			public const int GLORY_HOUSE_17 = 1716;

			// Token: 0x0400147E RID: 5246
			public const int GLORY_HOUSE_18 = 1717;

			// Token: 0x0400147F RID: 5247
			public const int GLORY_HOUSE_19 = 1718;

			// Token: 0x04001480 RID: 5248
			public const int GLORY_HOUSE_20 = 1719;

			// Token: 0x04001481 RID: 5249
			public const int ERA_GLORY_STAR = 1730;

			// Token: 0x04001482 RID: 5250
			public const int EOW_INACTIVE = 1750;

			// Token: 0x04001483 RID: 5251
			public const int EOW_ACTIVE = 1751;

			// Token: 0x04001484 RID: 5252
			public const int NEW_VILLAGE_ENTER = 1800;

			// Token: 0x04001485 RID: 5253
			public const int NEW_VILLAGE_ADVANCED = 1801;

			// Token: 0x04001486 RID: 5254
			public const int NEW_VILLAGE_LOGOUT = 1802;

			// Token: 0x04001487 RID: 5255
			public const int CAPITAL_DONATE_DESCRIPTION = 1900;

			// Token: 0x04001488 RID: 5256
			public const int MONK_INFLUENCE = 2000;

			// Token: 0x04001489 RID: 5257
			public const int MONK_BLESSING = 2001;

			// Token: 0x0400148A RID: 5258
			public const int MONK_INQUISITION = 2002;

			// Token: 0x0400148B RID: 5259
			public const int MONK_INTERDICTS = 2003;

			// Token: 0x0400148C RID: 5260
			public const int MONK_RESTORATION = 2004;

			// Token: 0x0400148D RID: 5261
			public const int MONK_ABSOLUTION = 2005;

			// Token: 0x0400148E RID: 5262
			public const int MONK_EXCOMMUNICATION = 2006;

			// Token: 0x0400148F RID: 5263
			public const int MONK_POSITIVE_INFLUENCE = 2007;

			// Token: 0x04001490 RID: 5264
			public const int MONK_NEGATIVE_INFLUENCE = 2008;

			// Token: 0x04001491 RID: 5265
			public const int ARMY_VANDALISE = 2100;

			// Token: 0x04001492 RID: 5266
			public const int ARMY_CAPTURE = 2101;

			// Token: 0x04001493 RID: 5267
			public const int ARMY_PILLAGE = 2102;

			// Token: 0x04001494 RID: 5268
			public const int ARMY_RANSACK = 2103;

			// Token: 0x04001495 RID: 5269
			public const int ARMY_RAZE = 2104;

			// Token: 0x04001496 RID: 5270
			public const int ARMY_GOLD_RAID = 2105;

			// Token: 0x04001497 RID: 5271
			public const int ARMY_ATTACK = 2106;

			// Token: 0x04001498 RID: 5272
			public const int FAVOURITE_ATTACK_TARGET_CLEAR = 2107;

			// Token: 0x04001499 RID: 5273
			public const int FAVOURITE_ATTACK_TARGET_MAKE = 2018;

			// Token: 0x0400149A RID: 5274
			public const int FACTIONTAB_GLORY = 2300;

			// Token: 0x0400149B RID: 5275
			public const int FACTIONTAB_FACTIONS = 2301;

			// Token: 0x0400149C RID: 5276
			public const int FACTIONTAB_HOUSE = 2302;

			// Token: 0x0400149D RID: 5277
			public const int FACTION_ALLY = 2303;

			// Token: 0x0400149E RID: 5278
			public const int FACTION_ENEMY = 2304;

			// Token: 0x0400149F RID: 5279
			public const int FACTION_LEADER = 2305;

			// Token: 0x040014A0 RID: 5280
			public const int FACTION_OFFICER = 2306;

			// Token: 0x040014A1 RID: 5281
			public const int HOUSE_ROLLOVER = 2307;

			// Token: 0x040014A2 RID: 5282
			public const int HOUSE_GLORY_ROLLOVER = 2308;

			// Token: 0x040014A3 RID: 5283
			public const int FACTION_SIDEBAR_SHOW_ALL = 2350;

			// Token: 0x040014A4 RID: 5284
			public const int FACTION_SIDEBAR_MY_FACTION = 2351;

			// Token: 0x040014A5 RID: 5285
			public const int FACTION_SIDEBAR_DIPLOMACY = 2352;

			// Token: 0x040014A6 RID: 5286
			public const int FACTION_SIDEBAR_OFFICERS = 2353;

			// Token: 0x040014A7 RID: 5287
			public const int FACTION_SIDEBAR_FORUM = 2354;

			// Token: 0x040014A8 RID: 5288
			public const int FACTION_SIDEBAR_MAIL = 2355;

			// Token: 0x040014A9 RID: 5289
			public const int FACTION_SIDEBAR_INVITES = 2356;

			// Token: 0x040014AA RID: 5290
			public const int FACTION_SIDEBAR_CHAT = 2357;

			// Token: 0x040014AB RID: 5291
			public const int FACTION_SIDEBAR_START = 2358;

			// Token: 0x040014AC RID: 5292
			public const int FACTION_SIDEBAR_LEAVE = 2359;

			// Token: 0x040014AD RID: 5293
			public const int MAPSIDE_CANCEL = 2400;

			// Token: 0x040014AE RID: 5294
			public const int MAPSIDE_ATTACK = 2401;

			// Token: 0x040014AF RID: 5295
			public const int MAPSIDE_REINFORCE = 2402;

			// Token: 0x040014B0 RID: 5296
			public const int MAPSIDE_TRADE = 2403;

			// Token: 0x040014B1 RID: 5297
			public const int MAPSIDE_MARKET = 2404;

			// Token: 0x040014B2 RID: 5298
			public const int MAPSIDE_SCOUT = 2405;

			// Token: 0x040014B3 RID: 5299
			public const int MAPSIDE_MONK = 2406;

			// Token: 0x040014B4 RID: 5300
			public const int MAPSIDE_VASSAL = 2407;

			// Token: 0x040014B5 RID: 5301
			public const int MAPSIDE_CAPITAL_TRADE = 2410;

			// Token: 0x040014B6 RID: 5302
			public const int MAPSIDE_CAPITAL_ATTACK = 2411;

			// Token: 0x040014B7 RID: 5303
			public const int MAPSIDE_CAPITAL_SCOUT = 2412;

			// Token: 0x040014B8 RID: 5304
			public const int MAPSIDE_CAPITAL_REINFORCE = 2413;

			// Token: 0x040014B9 RID: 5305
			public const int MAPSIDE_CAPITAL_MONK = 2414;

			// Token: 0x040014BA RID: 5306
			public const int MAPSIDE_PARISH = 2420;

			// Token: 0x040014BB RID: 5307
			public const int MAPSIDE_COUNTY = 2421;

			// Token: 0x040014BC RID: 5308
			public const int MAPSIDE_PROVINCE = 2422;

			// Token: 0x040014BD RID: 5309
			public const int MAPSIDE_COUNTRY = 2423;

			// Token: 0x040014BE RID: 5310
			public const int MAPSIDE_BANDIT_CAMP = 2424;

			// Token: 0x040014BF RID: 5311
			public const int MAPSIDE_WOLF_LAIR = 2425;

			// Token: 0x040014C0 RID: 5312
			public const int MAPSIDE_RATS_CASTLE = 2426;

			// Token: 0x040014C1 RID: 5313
			public const int MAPSIDE_SNAKES_CASTLE = 2427;

			// Token: 0x040014C2 RID: 5314
			public const int MAPSIDE_PIGS_CASTLE = 2428;

			// Token: 0x040014C3 RID: 5315
			public const int MAPSIDE_WOLFS_CASTLE = 2429;

			// Token: 0x040014C4 RID: 5316
			public const int MAPSIDE_STASH = 2430;

			// Token: 0x040014C5 RID: 5317
			public const int MAPSIDE_OWN_TRADE = 2431;

			// Token: 0x040014C6 RID: 5318
			public const int MAPSIDE_OWN_ATTACK = 2432;

			// Token: 0x040014C7 RID: 5319
			public const int MAPSIDE_OWN_SCOUT = 2433;

			// Token: 0x040014C8 RID: 5320
			public const int MAPSIDE_OWN_REINFORCE = 2434;

			// Token: 0x040014C9 RID: 5321
			public const int MAPSIDE_OWN_MONK = 2435;

			// Token: 0x040014CA RID: 5322
			public const int MAPSIDE_TERRAIN_TYPE = 2436;

			// Token: 0x040014CB RID: 5323
			public const int MAPSIDE_VIEW_VILLAGE = 2437;

			// Token: 0x040014CC RID: 5324
			public const int MAPSIDE_VIEW_CASTLE = 2438;

			// Token: 0x040014CD RID: 5325
			public const int MAPSIDE_VIEW_RESOURCES = 2439;

			// Token: 0x040014CE RID: 5326
			public const int MAPSIDE_MAKE_TROOPS = 2440;

			// Token: 0x040014CF RID: 5327
			public const int MAPSIDE_PARISH_TRADE = 2441;

			// Token: 0x040014D0 RID: 5328
			public const int MAPSIDE_MAKE_MERCENARIES = 2442;

			// Token: 0x040014D1 RID: 5329
			public const int MAPSIDE_SCOUT_STASH = 2443;

			// Token: 0x040014D2 RID: 5330
			public const int MAPSIDE_VILLAGE_CHARTER = 2444;

			// Token: 0x040014D3 RID: 5331
			public const int MAPSIDE_VIEW_CASTLE_REPORT = 2445;

			// Token: 0x040014D4 RID: 5332
			public const int MAPSIDE_MAKE_VASSAL = 2446;

			// Token: 0x040014D5 RID: 5333
			public const int MAPSIDE_SMALL_PALADIN_CASTLE = 2447;

			// Token: 0x040014D6 RID: 5334
			public const int MAPSIDE_MEDIUM_PALADIN_CASTLE = 2448;

			// Token: 0x040014D7 RID: 5335
			public const int MAPSIDE_TREASURE_CASTLE = 2449;

			// Token: 0x040014D8 RID: 5336
			public const int MAPSIDE_PARISH_PLAGUE = 2450;

			// Token: 0x040014D9 RID: 5337
			public const int MAPSIDE_VASSAL_MANAGE_TROOPS = 2451;

			// Token: 0x040014DA RID: 5338
			public const int MAPSIDE_VASSAL_MANAGE_VASSAL = 2452;

			// Token: 0x040014DB RID: 5339
			public const int MAPSIDE_VASSAL_ATTACK_FROM = 2453;

			// Token: 0x040014DC RID: 5340
			public const int MAPSIDE_FILTER_TRADE = 2454;

			// Token: 0x040014DD RID: 5341
			public const int MAPSIDE_FILTER_ATTACK = 2455;

			// Token: 0x040014DE RID: 5342
			public const int MAPSIDE_FILTER_SCOUT = 2456;

			// Token: 0x040014DF RID: 5343
			public const int MAPSIDE_FILTER_HOUSE = 2457;

			// Token: 0x040014E0 RID: 5344
			public const int MAPSIDE_FILTER_FACTION = 2458;

			// Token: 0x040014E1 RID: 5345
			public const int MAPSIDE_FILTER_CLEAR = 2459;

			// Token: 0x040014E2 RID: 5346
			public const int MAPSIDE_FILTER_SEARCH = 2460;

			// Token: 0x040014E3 RID: 5347
			public const int MAPSIDE_FILTER_OPEN_FACTION = 2461;

			// Token: 0x040014E4 RID: 5348
			public const int MAPSIDE_FILTER_AI = 2462;

			// Token: 0x040014E5 RID: 5349
			public const int MAPSIDE_FACTIONNAME = 2501;

			// Token: 0x040014E6 RID: 5350
			public const int MAPSIDE_SENDMAIL = 2502;

			// Token: 0x040014E7 RID: 5351
			public const int MAPSIDE_USERINFO = 2503;

			// Token: 0x040014E8 RID: 5352
			public const int MAPSIDE_BUY_CHARTER_RANK_TOO_LOW = 2504;

			// Token: 0x040014E9 RID: 5353
			public const int MAPSIDE_CANT_BUY_FROM_HERE = 2505;

			// Token: 0x040014EA RID: 5354
			public const int MAPSIDE_BUY_CHARTER_RANK_TOO_LOW12 = 2506;

			// Token: 0x040014EB RID: 5355
			public const int UNIT_MAKE_ERROR = 2700;

			// Token: 0x040014EC RID: 5356
			public const int UNIT_MAKE_ERROR_PEASANTS = 1;

			// Token: 0x040014ED RID: 5357
			public const int UNIT_MAKE_ERROR_GOLD = 2;

			// Token: 0x040014EE RID: 5358
			public const int UNIT_MAKE_ERROR_SPACE = 4;

			// Token: 0x040014EF RID: 5359
			public const int UNIT_MAKE_ERROR_FULL = 8;

			// Token: 0x040014F0 RID: 5360
			public const int UNIT_MAKE_ERROR_WEAPON = 16;

			// Token: 0x040014F1 RID: 5361
			public const int UNIT_MAKE_ERROR_TROOP_SPACE = 32;

			// Token: 0x040014F2 RID: 5362
			public const int VASSAL_AVAILABLE_TROOPS = 2800;

			// Token: 0x040014F3 RID: 5363
			public const int ARMIES_ATTACKS = 2900;

			// Token: 0x040014F4 RID: 5364
			public const int ARMIES_SCOUTS = 2901;

			// Token: 0x040014F5 RID: 5365
			public const int ARMIES_REINFORCEMENTS = 2902;

			// Token: 0x040014F6 RID: 5366
			public const int ARMIES_MERCHANTS = 2903;

			// Token: 0x040014F7 RID: 5367
			public const int ARMIES_MONKS = 2904;

			// Token: 0x040014F8 RID: 5368
			public const int ARMIES_SORTING = 2905;

			// Token: 0x040014F9 RID: 5369
			public const int ACHIEVEMENT_NOT_STARTED = 3001;

			// Token: 0x040014FA RID: 5370
			public const int ACHIEVEMENT_INPROGRESS = 3002;

			// Token: 0x040014FB RID: 5371
			public const int ACHIEVEMENT_NOT_STARTED_OWN = 3003;

			// Token: 0x040014FC RID: 5372
			public const int ACHIEVEMENT_INPROGRESS_OWN = 3004;

			// Token: 0x040014FD RID: 5373
			public const int ADMIN = 3101;

			// Token: 0x040014FE RID: 5374
			public const int USER_CLEAR_DIPLOMACY = 3102;

			// Token: 0x040014FF RID: 5375
			public const int USER_CLEAR_DIPLOMACY_NOTES = 3103;

			// Token: 0x04001500 RID: 5376
			public const int START_QUEST = 3201;

			// Token: 0x04001501 RID: 5377
			public const int ABANDON_QUEST = 3202;

			// Token: 0x04001502 RID: 5378
			public const int QUEST_REWARD_HONOUR = 3203;

			// Token: 0x04001503 RID: 5379
			public const int QUEST_REWARD_GOLD = 3204;

			// Token: 0x04001504 RID: 5380
			public const int QUEST_REWARD_WOOD = 3205;

			// Token: 0x04001505 RID: 5381
			public const int QUEST_REWARD_STONE = 3206;

			// Token: 0x04001506 RID: 5382
			public const int QUEST_REWARD_APPLES = 3207;

			// Token: 0x04001507 RID: 5383
			public const int QUEST_REWARD_CARD_PACKS = 3208;

			// Token: 0x04001508 RID: 5384
			public const int QUEST_REWARD_PREMIUM_CARD = 3209;

			// Token: 0x04001509 RID: 5385
			public const int QUEST_REWARD_FAITHPOINTS = 3210;

			// Token: 0x0400150A RID: 5386
			public const int QUEST_REWARD_GLORY = 3211;

			// Token: 0x0400150B RID: 5387
			public const int QUEST_REWARD_SHIELD_CHARGES = 3212;

			// Token: 0x0400150C RID: 5388
			public const int QUEST_REWARD_TICKETS = 3213;

			// Token: 0x0400150D RID: 5389
			public const int QUEST_REWARD_FISH = 3214;

			// Token: 0x0400150E RID: 5390
			public const int LOGIN_ENGLISH_SUPPORT = 4001;

			// Token: 0x0400150F RID: 5391
			public const int LOGIN_GERMAN_SUPPORT = 4002;

			// Token: 0x04001510 RID: 5392
			public const int LOGIN_FRENCH_SUPPORT = 4003;

			// Token: 0x04001511 RID: 5393
			public const int LOGIN_RUSSIAN_SUPPORT = 4004;

			// Token: 0x04001512 RID: 5394
			public const int LOGIN_MAP_OF_ENGLAND = 4005;

			// Token: 0x04001513 RID: 5395
			public const int LOGIN_MAP_OF_GERMANY = 4006;

			// Token: 0x04001514 RID: 5396
			public const int LOGIN_MAP_OF_FRANCE = 4007;

			// Token: 0x04001515 RID: 5397
			public const int LOGIN_MAP_OF_RUSSIA = 4008;

			// Token: 0x04001516 RID: 5398
			public const int LOGIN_OFFLINE = 4009;

			// Token: 0x04001517 RID: 5399
			public const int LOGIN_ONLINE = 4010;

			// Token: 0x04001518 RID: 5400
			public const int LOGIN_ENGLISH_FLAG = 4011;

			// Token: 0x04001519 RID: 5401
			public const int LOGIN_GERMAN_FLAG = 4012;

			// Token: 0x0400151A RID: 5402
			public const int LOGIN_FRENCH_FLAG = 4013;

			// Token: 0x0400151B RID: 5403
			public const int LOGIN_RUSSIAN_FLAG = 4014;

			// Token: 0x0400151C RID: 5404
			public const int LOGIN_EDIT_SHIELD = 4015;

			// Token: 0x0400151D RID: 5405
			public const int LOGIN_SPANISH_SUPPORT = 4016;

			// Token: 0x0400151E RID: 5406
			public const int LOGIN_MAP_OF_SPAIN = 4017;

			// Token: 0x0400151F RID: 5407
			public const int LOGIN_SPANISH_FLAG = 4018;

			// Token: 0x04001520 RID: 5408
			public const int LOGIN_SECOND_AGE = 4019;

			// Token: 0x04001521 RID: 5409
			public const int LOGIN_POLISH_SUPPORT = 4020;

			// Token: 0x04001522 RID: 5410
			public const int LOGIN_MAP_OF_POLAND = 4021;

			// Token: 0x04001523 RID: 5411
			public const int LOGIN_POLISH_FLAG = 4022;

			// Token: 0x04001524 RID: 5412
			public const int LOGIN_TURKISH_SUPPORT = 4023;

			// Token: 0x04001525 RID: 5413
			public const int LOGIN_MAP_OF_TURKEY = 4024;

			// Token: 0x04001526 RID: 5414
			public const int LOGIN_TURKISH_FLAG = 4025;

			// Token: 0x04001527 RID: 5415
			public const int LOGIN_THIRD_AGE = 4026;

			// Token: 0x04001528 RID: 5416
			public const int LOGIN_ITALIAN_SUPPORT = 4027;

			// Token: 0x04001529 RID: 5417
			public const int LOGIN_MAP_OF_ITALY = 4028;

			// Token: 0x0400152A RID: 5418
			public const int LOGIN_ITALIAN_FLAG = 4029;

			// Token: 0x0400152B RID: 5419
			public const int LOGIN_MAP_OF_USA = 4030;

			// Token: 0x0400152C RID: 5420
			public const int LOGIN_EUROPE_SUPPORT = 4031;

			// Token: 0x0400152D RID: 5421
			public const int LOGIN_MAP_OF_EUROPE = 4032;

			// Token: 0x0400152E RID: 5422
			public const int LOGIN_EUROPEAN_FLAG = 4033;

			// Token: 0x0400152F RID: 5423
			public const int LOGIN_FOURTH_AGE = 4034;

			// Token: 0x04001530 RID: 5424
			public const int LOGIN_PORTUGUESE_SUPPORT = 4035;

			// Token: 0x04001531 RID: 5425
			public const int LOGIN_MAP_OF_SOUTH_AMERICA = 4036;

			// Token: 0x04001532 RID: 5426
			public const int LOGIN_PORTUGUESE_FLAG = 4037;

			// Token: 0x04001533 RID: 5427
			public const int LOGIN_FIRST_AGE = 4038;

			// Token: 0x04001534 RID: 5428
			public const int LOGIN_FIFTH_AGE = 4039;

			// Token: 0x04001535 RID: 5429
			public const int LOGIN_WORLD_FLAG = 4040;

			// Token: 0x04001536 RID: 5430
			public const int LOGIN_WORLD_SUPPORT = 4041;

			// Token: 0x04001537 RID: 5431
			public const int LOGIN_MAP_OF_WORLD = 4042;

			// Token: 0x04001538 RID: 5432
			public const int LOGIN_MAP_OF_PHILIPPINES = 4043;

			// Token: 0x04001539 RID: 5433
			public const int LOGIN_SIXTH_AGE = 4044;

			// Token: 0x0400153A RID: 5434
			public const int LOGIN_SEVENTH_AGE = 4045;

			// Token: 0x0400153B RID: 5435
			public const int LOGIN_CHINESE_SUPPORT = 4046;

			// Token: 0x0400153C RID: 5436
			public const int LOGIN_MAP_OF_CHINA = 4047;

			// Token: 0x0400153D RID: 5437
			public const int LOGIN_CHINESE_FLAG = 4048;

			// Token: 0x0400153E RID: 5438
			public const int LOGIN_MAP_OF_KINGMAKER = 4049;

			// Token: 0x0400153F RID: 5439
			public const int VO_TROOPS = 4100;

			// Token: 0x04001540 RID: 5440
			public const int VO_SCOUTS = 4101;

			// Token: 0x04001541 RID: 5441
			public const int VO_MERCHANTS = 4102;

			// Token: 0x04001542 RID: 5442
			public const int VO_MONKS = 4103;

			// Token: 0x04001543 RID: 5443
			public const int VO_POPULARITY = 4104;

			// Token: 0x04001544 RID: 5444
			public const int VO_NUM_BUILDINGS = 4105;

			// Token: 0x04001545 RID: 5445
			public const int VO_KEEP_ENCLOSED = 4106;

			// Token: 0x04001546 RID: 5446
			public const int VO_KEEP_NOT_ENCLOSED = 4107;

			// Token: 0x04001547 RID: 5447
			public const int VO_TROOPS_PEASANTS = 4108;

			// Token: 0x04001548 RID: 5448
			public const int VO_TROOPS_ARCHERS = 4109;

			// Token: 0x04001549 RID: 5449
			public const int VO_TROOPS_PIKEMEN = 4110;

			// Token: 0x0400154A RID: 5450
			public const int VO_TROOPS_SWORDSMEN = 4111;

			// Token: 0x0400154B RID: 5451
			public const int VO_TROOPS_CATAPULTS = 4112;

			// Token: 0x0400154C RID: 5452
			public const int VO_TROOPS_CAPTAINS = 4113;

			// Token: 0x0400154D RID: 5453
			public const int VO_TROOPS_EXPAND = 4114;

			// Token: 0x0400154E RID: 5454
			public const int VO_TROOPS_COLLAPSE = 4115;

			// Token: 0x0400154F RID: 5455
			public const int VO_SCOUTS_EXTRA = 4116;

			// Token: 0x04001550 RID: 5456
			public const int VO_MERCHANTS_EXTRA = 4117;

			// Token: 0x04001551 RID: 5457
			public const int VO_MONKS_EXTRA = 4118;

			// Token: 0x04001552 RID: 5458
			public const int VO_TAX_INCOME = 4119;

			// Token: 0x04001553 RID: 5459
			public const int VO_RATIONS = 4120;

			// Token: 0x04001554 RID: 5460
			public const int VO_ALE_RATIONS = 4121;

			// Token: 0x04001555 RID: 5461
			public const int VO_PEOPLE = 4122;

			// Token: 0x04001556 RID: 5462
			public const int VO_INTERDICTION = 4123;

			// Token: 0x04001557 RID: 5463
			public const int VO_EXCOMMUNICATION = 4124;

			// Token: 0x04001558 RID: 5464
			public const int VO_PEACETIME = 4125;

			// Token: 0x04001559 RID: 5465
			public const int VO_NOT_PREMIUM = 4126;

			// Token: 0x0400155A RID: 5466
			public const int VO_IRON = 4127;

			// Token: 0x0400155B RID: 5467
			public const int VO_PITCH = 4128;

			// Token: 0x0400155C RID: 5468
			public const int VO_DAMAGED = 4140;

			// Token: 0x0400155D RID: 5469
			public const int PROCLAMATION_HELP_PARISH = 4200;

			// Token: 0x0400155E RID: 5470
			public const int PROCLAMATION_HELP_COUNTY = 4201;

			// Token: 0x0400155F RID: 5471
			public const int PROCLAMATION_HELP_PROVINCE = 4202;

			// Token: 0x04001560 RID: 5472
			public const int PROCLAMATION_HELP_COUNTRY = 4203;

			// Token: 0x04001561 RID: 5473
			public const int PT_RESEARCH = 4300;

			// Token: 0x04001562 RID: 5474
			public const int PT_RANK = 4301;

			// Token: 0x04001563 RID: 5475
			public const int PT_ACHIEVEMENTS = 4302;

			// Token: 0x04001564 RID: 5476
			public const int PT_QUESTS = 4303;

			// Token: 0x04001565 RID: 5477
			public const int PT_REPORTS = 4304;

			// Token: 0x04001566 RID: 5478
			public const int PT_COAT_OF_ARMS = 4305;

			// Token: 0x04001567 RID: 5479
			public const int PT_AVATAR = 4306;

			// Token: 0x04001568 RID: 5480
			public const int PT_INVITE_A_FRIEND = 4307;

			// Token: 0x04001569 RID: 5481
			public const int PT_PARISH_WALL = 4308;

			// Token: 0x0400156A RID: 5482
			public const int PT_MAIL = 4309;

			// Token: 0x0400156B RID: 5483
			public const int WIKI_HELP_LINK = 4400;

			// Token: 0x0400156C RID: 5484
			public const int WIKI_HELP_LINK_CHAT_SPECIAL = 4401;

			// Token: 0x0400156D RID: 5485
			public const int WIKI_HELP_LINK_SETTINGS_SPECIAL = 4402;

			// Token: 0x0400156E RID: 5486
			public const int CARD_BAR_CIRCLES = 10000;

			// Token: 0x0400156F RID: 5487
			public const int CARD_BAR_PLAY_CARDS = 10001;

			// Token: 0x04001570 RID: 5488
			public const int CARD_BAR_EXPAND = 10002;

			// Token: 0x04001571 RID: 5489
			public const int CARD_BAR_COLLAPSE = 10003;

			// Token: 0x04001572 RID: 5490
			public const int CARD_BAR_NEXT = 10004;

			// Token: 0x04001573 RID: 5491
			public const int CARD_BAR_PREV = 10005;

			// Token: 0x04001574 RID: 5492
			public const int CARD_WINDOW_CLOSE = 10100;

			// Token: 0x04001575 RID: 5493
			public const int CARD_WINDOW_CARDS = 10101;

			// Token: 0x04001576 RID: 5494
			public const int CARD_WINDOW_FILTER = 10102;

			// Token: 0x04001577 RID: 5495
			public const int CARD_WINDOW_CASH_IN = 10103;

			// Token: 0x04001578 RID: 5496
			public const int CARD_WINDOW_GET_CARDS = 10104;

			// Token: 0x04001579 RID: 5497
			public const int CARD_WINDOW_FILTER2 = 10105;

			// Token: 0x0400157A RID: 5498
			public const int CARDS_FARMING_PACK = 10301;

			// Token: 0x0400157B RID: 5499
			public const int CARDS_CASTLE_PACK = 10302;

			// Token: 0x0400157C RID: 5500
			public const int CARDS_DEFENSE_PACK = 10303;

			// Token: 0x0400157D RID: 5501
			public const int CARDS_ARMY_PACK = 10304;

			// Token: 0x0400157E RID: 5502
			public const int CARDS_RANDOM_PACK = 10305;

			// Token: 0x0400157F RID: 5503
			public const int CARDS_INDUSTRY_PACK = 10306;

			// Token: 0x04001580 RID: 5504
			public const int CARDS_RESEARCH_PACK = 10307;

			// Token: 0x04001581 RID: 5505
			public const int CARDS_EXCLUSIVE_PACK = 10308;

			// Token: 0x04001582 RID: 5506
			public const int CARDS_SUPER_FARMING_PACK = 10309;

			// Token: 0x04001583 RID: 5507
			public const int CARDS_SUPER_DEFENSE_PACK = 10310;

			// Token: 0x04001584 RID: 5508
			public const int CARDS_SUPER_ARMY_PACK = 10311;

			// Token: 0x04001585 RID: 5509
			public const int CARDS_SUPER_RANDOM_PACK = 10312;

			// Token: 0x04001586 RID: 5510
			public const int CARDS_SUPER_INDUSTRY_PACK = 10313;

			// Token: 0x04001587 RID: 5511
			public const int CARDS_ULTIMATE_FARMING_PACK = 10314;

			// Token: 0x04001588 RID: 5512
			public const int CARDS_ULTIMATE_DEFENSE_PACK = 10315;

			// Token: 0x04001589 RID: 5513
			public const int CARDS_ULTIMATE_ARMY_PACK = 10316;

			// Token: 0x0400158A RID: 5514
			public const int CARDS_ULTIMATE_RANDOM_PACK = 10317;

			// Token: 0x0400158B RID: 5515
			public const int CARDS_ULTIMATE_INDUSTRY_PACK = 10318;

			// Token: 0x0400158C RID: 5516
			public const int CARDS_SEARCH_CARDS = 10319;

			// Token: 0x0400158D RID: 5517
			public const int CARDS_CLEAR_SEARCH_CARDS = 10320;

			// Token: 0x0400158E RID: 5518
			public const int CARDS_PLATINUM_PACK = 10321;

			// Token: 0x0400158F RID: 5519
			public const int BUY_AERIA_POINTS = 10350;

			// Token: 0x04001590 RID: 5520
			public const int MAPSIDE_RENAME = 10390;

			// Token: 0x04001591 RID: 5521
			public const int FREE_CARDS_MAIN = 10500;

			// Token: 0x04001592 RID: 5522
			public const int ROYAL_TICKETS_MAIN = 10501;

			// Token: 0x04001593 RID: 5523
			public const int WOLFS_REVENGE = 10502;

			// Token: 0x04001594 RID: 5524
			public const int GENERIC_TIME = 20000;

			// Token: 0x04001595 RID: 5525
			public const int TRACK_BAR_HINT = 21000;

			// Token: 0x04001596 RID: 5526
			public const int PLAYBACK_STOP = 22000;

			// Token: 0x04001597 RID: 5527
			public const int PLAYBACK_PAUSE = 22001;

			// Token: 0x04001598 RID: 5528
			public const int PLAYBACK_PLAY = 22002;

			// Token: 0x04001599 RID: 5529
			public const int PLAYBACK_SPEED1 = 22003;

			// Token: 0x0400159A RID: 5530
			public const int PLAYBACK_SPEED2 = 22004;

			// Token: 0x0400159B RID: 5531
			public const int PLAYBACK_SPEED4 = 22005;

			// Token: 0x0400159C RID: 5532
			public const int PLAYBACK_EXPAND = 22006;

			// Token: 0x0400159D RID: 5533
			public const int PLAYBACK_COLLAPSE = 22007;

			// Token: 0x0400159E RID: 5534
			public const int SEA_CONDITIONS_TRAVEL_PANELS_MINUS_5 = 23000;

			// Token: 0x0400159F RID: 5535
			public const int SEA_CONDITIONS_TRAVEL_PANELS_MINUS_4 = 23001;

			// Token: 0x040015A0 RID: 5536
			public const int SEA_CONDITIONS_TRAVEL_PANELS_MINUS_3 = 23002;

			// Token: 0x040015A1 RID: 5537
			public const int SEA_CONDITIONS_TRAVEL_PANELS_MINUS_2 = 23003;

			// Token: 0x040015A2 RID: 5538
			public const int SEA_CONDITIONS_TRAVEL_PANELS_NEUTRAL = 23004;

			// Token: 0x040015A3 RID: 5539
			public const int SEA_CONDITIONS_TRAVEL_PANELS_PLUS_2 = 23005;

			// Token: 0x040015A4 RID: 5540
			public const int SEA_CONDITIONS_TRAVEL_PANELS_PLUS_3 = 23006;

			// Token: 0x040015A5 RID: 5541
			public const int SEA_CONDITIONS_TRAVEL_PANELS_PLUS_4 = 23007;

			// Token: 0x040015A6 RID: 5542
			public const int SEA_CONDITIONS_TRAVEL_PANELS_PLUS_5 = 23008;

			// Token: 0x040015A7 RID: 5543
			public const int SEA_CONDITIONS_MAP_MINUS_5 = 23010;

			// Token: 0x040015A8 RID: 5544
			public const int SEA_CONDITIONS_MAP_MINUS_4 = 23011;

			// Token: 0x040015A9 RID: 5545
			public const int SEA_CONDITIONS_MAP_MINUS_3 = 23012;

			// Token: 0x040015AA RID: 5546
			public const int SEA_CONDITIONS_MAP_MINUS_2 = 23013;

			// Token: 0x040015AB RID: 5547
			public const int SEA_CONDITIONS_MAP_NEUTRAL = 23014;

			// Token: 0x040015AC RID: 5548
			public const int SEA_CONDITIONS_MAP_PLUS_2 = 23015;

			// Token: 0x040015AD RID: 5549
			public const int SEA_CONDITIONS_MAP_PLUS_3 = 23016;

			// Token: 0x040015AE RID: 5550
			public const int SEA_CONDITIONS_MAP_PLUS_4 = 23017;

			// Token: 0x040015AF RID: 5551
			public const int SEA_CONDITIONS_MAP_PLUS_5 = 23018;

			// Token: 0x040015B0 RID: 5552
			public const int ROYAL_TOWER_ICON = 24000;

			// Token: 0x040015B1 RID: 5553
			public const int KILL_STREAK_ICON = 24100;

			// Token: 0x040015B2 RID: 5554
			public const int CONTEST_PRIZE_AVAILABLE = 25001;

			// Token: 0x040015B3 RID: 5555
			public const int CONTEST_ONGOING = 25002;

			// Token: 0x040015B4 RID: 5556
			public const int CONTEST_RANKBAND = 25003;

			// Token: 0x040015B5 RID: 5557
			public const int SALE_ONGOING = 25100;

			// Token: 0x040015B6 RID: 5558
			public const int SPECIAL_OFFER_AVAILABLE = 25101;
		}

		// Token: 0x02000193 RID: 403
		public class ToolTipZone
		{
			// Token: 0x06000FA4 RID: 4004 RVA: 0x0001163A File Offset: 0x0000F83A
			public ToolTipZone(int x, int y, int width, int height, int tooltipID)
			{
				this.rect = new Rectangle(x, y, width, height);
				this.ID = tooltipID;
			}

			// Token: 0x06000FA5 RID: 4005 RVA: 0x0001165A File Offset: 0x0000F85A
			public ToolTipZone(int x, int y, int width, int height, int tooltipID, Control relative)
			{
				this.rect = new Rectangle(x, y, width, height);
				this.ID = tooltipID;
				this.relatedControl = relative;
			}

			// Token: 0x06000FA6 RID: 4006 RVA: 0x00011682 File Offset: 0x0000F882
			public ToolTipZone(int x, int y, int width, int height, int tooltipID, CustomSelfDrawPanel.CSDControl relative)
			{
				this.rect = new Rectangle(x, y, width, height);
				this.ID = tooltipID;
				this.relatedCSDControl = relative;
			}

			// Token: 0x040015B7 RID: 5559
			public Rectangle rect;

			// Token: 0x040015B8 RID: 5560
			public int ID;

			// Token: 0x040015B9 RID: 5561
			public Control relatedControl;

			// Token: 0x040015BA RID: 5562
			public CustomSelfDrawPanel.CSDControl relatedCSDControl;
		}

		// Token: 0x02000194 RID: 404
		public class ToolTipZoneControlChild : Control
		{
			// Token: 0x040015BB RID: 5563
			public CustomTooltipManager.ToolTipZone[] zones;
		}

		// Token: 0x02000195 RID: 405
		public class ToolTipZoneTabChild : TabPage
		{
			// Token: 0x040015BC RID: 5564
			public CustomTooltipManager.ToolTipZone[] zones;
		}
	}
}
