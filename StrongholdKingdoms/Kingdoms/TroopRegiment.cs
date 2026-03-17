using System;
using System.Collections.Generic;
using System.Drawing;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020004A1 RID: 1185
	public class TroopRegiment
	{
		// Token: 0x17000238 RID: 568
		// (get) Token: 0x06002B6A RID: 11114 RVA: 0x0001FE3E File Offset: 0x0001E03E
		public Point CenterPoint
		{
			get
			{
				return this.m_centerPoint;
			}
		}

		// Token: 0x06002B6B RID: 11115 RVA: 0x00223D7C File Offset: 0x00221F7C
		public TroopRegiment.Stance GetStance()
		{
			int num = 0;
			int num2 = 0;
			foreach (CastleElement castleElement in this.m_troops)
			{
				if (castleElement.aggressiveDefender)
				{
					num++;
				}
				else
				{
					num2++;
				}
			}
			if (num > 0 && num2 == 0)
			{
				return TroopRegiment.Stance.AGGRESSIVE;
			}
			if (num2 > 0 && num == 0)
			{
				return TroopRegiment.Stance.DEFENSIVE;
			}
			return TroopRegiment.Stance.MIXED;
		}

		// Token: 0x06002B6C RID: 11116 RVA: 0x0001FE46 File Offset: 0x0001E046
		public TroopRegiment(int RegimentID)
		{
			this.regimentID = RegimentID;
			this.m_troops = new List<CastleElement>();
		}

		// Token: 0x06002B6D RID: 11117 RVA: 0x0001FE60 File Offset: 0x0001E060
		public void AddTroop(CastleElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			this.m_troops.Add(element);
			this.TroopType = (int)element.elementType;
			this.onChange();
		}

		// Token: 0x06002B6E RID: 11118 RVA: 0x0001FE8E File Offset: 0x0001E08E
		public void RemoveOne()
		{
			this.m_troops.RemoveAt(this.m_troops.Count - 1);
			this.onChange();
		}

		// Token: 0x06002B6F RID: 11119 RVA: 0x0001FEAE File Offset: 0x0001E0AE
		public CastleElement[] GetTroops()
		{
			if (this.m_troops == null)
			{
				return null;
			}
			return this.m_troops.ToArray();
		}

		// Token: 0x06002B70 RID: 11120 RVA: 0x0001FEC5 File Offset: 0x0001E0C5
		public void onChange()
		{
			this.m_centerPoint = this.calculateCenterPoint(this.m_troops);
		}

		// Token: 0x06002B71 RID: 11121 RVA: 0x00223DF4 File Offset: 0x00221FF4
		public Point calculateCenterPoint(List<CastleElement> elements)
		{
			Point result = default(Point);
			foreach (CastleElement castleElement in elements)
			{
				result.X += (int)castleElement.xPos;
				result.Y += (int)castleElement.yPos;
			}
			result.X /= this.m_troops.Count;
			result.Y /= this.m_troops.Count;
			return result;
		}

		// Token: 0x06002B72 RID: 11122 RVA: 0x00223EA0 File Offset: 0x002220A0
		public List<TroopRegiment> divideByTowers(CastleMap map)
		{
			Dictionary<long, TroopRegiment> dictionary = new Dictionary<long, TroopRegiment>();
			int num = 0;
			CastleElement[] troops = this.GetTroops();
			foreach (CastleElement castleElement in troops)
			{
				long num2 = map.getTowerIDAtPosition((int)castleElement.xPos, (int)castleElement.yPos);
				if (num2 < 0L)
				{
					num2 = 0L;
				}
				if (!dictionary.ContainsKey(num2))
				{
					dictionary.Add(num2, new TroopRegiment(num++));
				}
				dictionary[num2].AddTroop(castleElement);
			}
			List<TroopRegiment> list = new List<TroopRegiment>();
			foreach (KeyValuePair<long, TroopRegiment> keyValuePair in dictionary)
			{
				list.Add(keyValuePair.Value);
			}
			return list;
		}

		// Token: 0x06002B73 RID: 11123 RVA: 0x00223F74 File Offset: 0x00222174
		public List<TroopRegiment> divideByAdjacency()
		{
			List<TroopRegiment> list = new List<TroopRegiment>();
			List<CastleElement> list2 = new List<CastleElement>();
			List<CastleElement> list3 = new List<CastleElement>(this.GetTroops());
			while (list3.Count > 0)
			{
				TroopRegiment troopRegiment = new TroopRegiment(0);
				troopRegiment.AddTroop(list3[0]);
				list2.Add(list3[0]);
				list3.RemoveAt(0);
				while (list2.Count > 0)
				{
					List<CastleElement> adjacent = this.getAdjacent(list2, list3);
					list2.Clear();
					foreach (CastleElement castleElement in adjacent)
					{
						list2.Add(castleElement);
						troopRegiment.AddTroop(castleElement);
						list3.Remove(castleElement);
					}
				}
				list.Add(troopRegiment);
			}
			return list;
		}

		// Token: 0x06002B74 RID: 11124 RVA: 0x0022404C File Offset: 0x0022224C
		private List<CastleElement> getAdjacent(List<CastleElement> open, List<CastleElement> troops)
		{
			Point a = default(Point);
			Point b = default(Point);
			List<CastleElement> list = new List<CastleElement>();
			foreach (CastleElement castleElement in open)
			{
				CastleElement[] array = troops.ToArray();
				foreach (CastleElement castleElement2 in array)
				{
					a.X = (int)castleElement.xPos;
					a.Y = (int)castleElement.yPos;
					b.X = (int)castleElement2.xPos;
					b.Y = (int)castleElement2.yPos;
					if (this.isAdjacent(a, b))
					{
						list.Add(castleElement2);
						troops.Remove(castleElement2);
					}
				}
			}
			return list;
		}

		// Token: 0x06002B75 RID: 11125 RVA: 0x0022412C File Offset: 0x0022232C
		private bool isAdjacent(Point a, Point b)
		{
			return a.X >= b.X - 1 && a.X <= b.X + 1 && a.Y >= b.Y - 1 && a.Y <= b.Y + 1;
		}

		// Token: 0x04003609 RID: 13833
		public int regimentID;

		// Token: 0x0400360A RID: 13834
		private List<CastleElement> m_troops;

		// Token: 0x0400360B RID: 13835
		public int TroopType;

		// Token: 0x0400360C RID: 13836
		private Point m_centerPoint;

		// Token: 0x020004A2 RID: 1186
		public enum Stance
		{
			// Token: 0x0400360E RID: 13838
			AGGRESSIVE,
			// Token: 0x0400360F RID: 13839
			DEFENSIVE,
			// Token: 0x04003610 RID: 13840
			MIXED
		}
	}
}
