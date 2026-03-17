using System;
using System.Collections.Generic;
using System.Linq;
using Kingdoms;
using Upgrade.Services;

namespace Upgrade
{
	// Token: 0x02000023 RID: 35
	public static class ExtensionMethods
	{
		// Token: 0x06000173 RID: 371 RVA: 0x0003F750 File Offset: 0x0003D950
		public static int[] PresetTroopsCount(CastleMapPreset preset)
		{
			List<CastleMap.RestoreCastleElement> list = new List<CastleMap.RestoreCastleElement>();
			string[] array = preset.Data.Split(new char[]
			{
				' '
			});
			int num = 0;
			int i = 0;
			while (i < preset.ElementCount)
			{
				CastleMap.RestoreCastleElement restoreCastleElement = new CastleMap.RestoreCastleElement();
				restoreCastleElement.xPos = Convert.ToByte(array[num++]);
				restoreCastleElement.yPos = Convert.ToByte(array[num++]);
				restoreCastleElement.elementType = Convert.ToByte(array[num++]);
				if (restoreCastleElement.elementType == 94)
				{
					restoreCastleElement.targXPos = Convert.ToByte(array[num++]);
					restoreCastleElement.targYPos = Convert.ToByte(array[num++]);
				}
				if (restoreCastleElement.elementType < 100 || restoreCastleElement.elementType >= 109)
				{
					goto IL_173;
				}
				restoreCastleElement.delay = Convert.ToByte(array[num++]);
				if (restoreCastleElement.elementType == 102 || restoreCastleElement.elementType == 103)
				{
					restoreCastleElement.targXPos = Convert.ToByte(array[num++]);
					restoreCastleElement.targYPos = Convert.ToByte(array[num++]);
				}
				bool flag = false;
				int research_Tactics = (int)GameEngine.Instance.World.UserResearchData.Research_Tactics;
				switch (restoreCastleElement.elementType)
				{
				case 100:
					flag = true;
					break;
				case 101:
					if (research_Tactics > 0)
					{
						flag = true;
					}
					break;
				case 102:
					if (research_Tactics > 1)
					{
						flag = true;
					}
					break;
				case 103:
					if (research_Tactics > 3)
					{
						flag = true;
					}
					break;
				case 104:
					if (research_Tactics > 2)
					{
						flag = true;
					}
					break;
				}
				if (flag)
				{
					goto IL_173;
				}
				IL_17B:
				i++;
				continue;
				IL_173:
				list.Add(restoreCastleElement);
				goto IL_17B;
			}
			return ExtensionMethods.GetTroopsCountArray12(list);
		}

		// Token: 0x06000174 RID: 372 RVA: 0x0003F8F0 File Offset: 0x0003DAF0
		public static int[] GetTroopsCountArray12(List<CastleMap.RestoreCastleElement> list)
		{
			int[] array = new int[12];
			foreach (CastleMap.RestoreCastleElement restoreCastleElement in list)
			{
				byte elementType = restoreCastleElement.elementType;
				switch (elementType)
				{
				case 70:
					break;
				case 71:
					goto IL_D1;
				case 72:
					goto IL_B5;
				case 73:
					goto IL_C3;
				case 74:
					goto IL_DF;
				default:
					switch (elementType)
					{
					case 85:
					case 100:
					case 101:
					case 102:
					case 103:
					case 104:
					case 105:
					case 106:
					case 107:
						array[5]++;
						continue;
					case 86:
					case 87:
					case 88:
					case 89:
					case 95:
					case 96:
					case 97:
					case 98:
					case 99:
						continue;
					case 90:
						break;
					case 91:
						goto IL_D1;
					case 92:
						goto IL_B5;
					case 93:
						goto IL_C3;
					case 94:
						goto IL_DF;
					default:
						continue;
					}
					break;
				}
				array[0]++;
				continue;
				IL_B5:
				array[1]++;
				continue;
				IL_C3:
				array[2]++;
				continue;
				IL_D1:
				array[3]++;
				continue;
				IL_DF:
				array[4]++;
			}
			return array;
		}

		// Token: 0x06000175 RID: 373 RVA: 0x0003FA24 File Offset: 0x0003DC24
		public static IList<T> Shuffle<T>(this IList<T> list)
		{
			int i = list.Count;
			while (i > 1)
			{
				i--;
				int index = ASubscribed._random.Next(i + 1);
				T value = list[index];
				list[index] = list[i];
				list[i] = value;
			}
			return list;
		}

		// Token: 0x06000176 RID: 374 RVA: 0x0003FA70 File Offset: 0x0003DC70
		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> ienum)
		{
			List<T> list = ienum.ToList<T>();
			int i = list.Count;
			while (i > 1)
			{
				i--;
				int index = ASubscribed._random.Next(i + 1);
				T value = list[index];
				list[index] = list[i];
				list[i] = value;
			}
			return list;
		}
	}
}
