using System;
using System.Drawing;
using CommonTypes;
using DXGraphics;

namespace Kingdoms
{
	// Token: 0x020004E8 RID: 1256
	public class VillageMapPerson
	{
		// Token: 0x17000272 RID: 626
		// (set) Token: 0x06002F67 RID: 12135 RVA: 0x000226F4 File Offset: 0x000208F4
		public bool Visible
		{
			set
			{
				if (this.workerSprite != null)
				{
					this.workerSprite.Visible = value;
				}
			}
		}

		// Token: 0x06002F68 RID: 12136 RVA: 0x0002270A File Offset: 0x0002090A
		public VillageMapPerson(GraphicsMgr newGfx)
		{
			this.gfx = newGfx;
		}

		// Token: 0x06002F69 RID: 12137 RVA: 0x0002272F File Offset: 0x0002092F
		public void dispose()
		{
			if (this.workerSprite != null)
			{
				this.workerSprite.RemoveSelfFromParent();
			}
		}

		// Token: 0x06002F6A RID: 12138 RVA: 0x0026CC64 File Offset: 0x0026AE64
		public void setPos(Point pos)
		{
			Point p = new Point(pos.X, pos.Y);
			p.X *= 32;
			p.Y *= 16;
			p.Y += 8;
			this.currentPos = p;
		}

		// Token: 0x06002F6B RID: 12139 RVA: 0x00022744 File Offset: 0x00020944
		public void setPixelPos(Point pos)
		{
			this.currentPos = pos;
		}

		// Token: 0x06002F6C RID: 12140 RVA: 0x00022752 File Offset: 0x00020952
		public PointF getPos()
		{
			return this.currentPos;
		}

		// Token: 0x06002F6D RID: 12141 RVA: 0x0002275A File Offset: 0x0002095A
		public void fadeToSolid()
		{
			this.fadeDir = 10;
		}

		// Token: 0x06002F6E RID: 12142 RVA: 0x00022764 File Offset: 0x00020964
		public void fadeToTransparent()
		{
			this.fadeDir = -10;
		}

		// Token: 0x06002F6F RID: 12143 RVA: 0x0002276E File Offset: 0x0002096E
		public void initWorkerSprite()
		{
			if (this.workerSprite == null)
			{
				this.workerSprite = new SpriteWrapper();
				if (GameEngine.Instance.Village != null)
				{
					GameEngine.Instance.Village.addChildSprite(this.workerSprite, 15);
				}
			}
		}

		// Token: 0x06002F70 RID: 12144 RVA: 0x000227A6 File Offset: 0x000209A6
		public void initWorkerSpriteInBuilding(SpriteWrapper buildingSprite)
		{
			if (this.workerSprite == null)
			{
				this.workerSprite = new SpriteWrapper();
				buildingSprite.AddChild(this.workerSprite, 1);
			}
		}

		// Token: 0x06002F71 RID: 12145 RVA: 0x0026CCC4 File Offset: 0x0026AEC4
		public void initAnim(int texID, int baseFrame, short[] animarray, int animTime)
		{
			this.initWorkerSprite();
			this.workerSprite.Initialize(this.gfx, texID, baseFrame);
			this.workerSprite.clearDirectionality();
			this.workerSprite.initAnim(baseFrame, animarray, animTime);
			Point p = new Point(50, 66);
			this.workerSprite.Center = p;
			this.workerSprite.Visible = true;
		}

		// Token: 0x06002F72 RID: 12146 RVA: 0x000227C8 File Offset: 0x000209C8
		public void initAnim(int texID, int baseID, int numFrames, int animTime)
		{
			this.initAnim(texID, 0, baseID, numFrames, 1, animTime, true);
		}

		// Token: 0x06002F73 RID: 12147 RVA: 0x0026CD2C File Offset: 0x0026AF2C
		public void initAnim(int texID, int upDir, int baseID, int numFrames, int frameSkip, int animTime, bool clockwise)
		{
			this.initWorkerSprite();
			this.workerSprite.Initialize(this.gfx, texID, baseID);
			if (frameSkip == 1)
			{
				this.workerSprite.clearDirectionality();
				this.workerSprite.initAnim(baseID, numFrames, frameSkip, animTime);
			}
			else
			{
				this.workerSprite.initDirectionality(8, upDir, !clockwise);
				this.workerSprite.initAnim(baseID, numFrames, frameSkip, animTime);
			}
			Point p = new Point(50, 66);
			this.workerSprite.Center = p;
			this.workerSprite.Visible = true;
		}

		// Token: 0x06002F74 RID: 12148 RVA: 0x0026CDC4 File Offset: 0x0026AFC4
		public void startJourneyTileBased(Point newStartPos, Point newEndPos, double distThroughJourney)
		{
			Point realStart = VillageBuildingsData.tileToPixel(newStartPos);
			Point realEnd = VillageBuildingsData.tileToPixel(newEndPos);
			this.startJourney(realStart, realEnd, distThroughJourney);
		}

		// Token: 0x06002F75 RID: 12149 RVA: 0x0026CDE8 File Offset: 0x0026AFE8
		public void startJourney(Point realStart, Point realEnd, double distThroughJourney)
		{
			this.startPos = realStart;
			this.endPos = realEnd;
			if (distThroughJourney >= 1.0)
			{
				this.currentPos = this.endPos;
				this.state = VillageMapPerson.VillagePeopleStates.STATIONARY;
				return;
			}
			TimeSpan value = VillageBuildingsData.calcTravelTime(GameEngine.Instance.LocalWorldData, realStart, realEnd);
			this.startTime = DateTime.Now;
			this.endTime = DateTime.Now.Add(value);
			if (distThroughJourney != 0.0)
			{
				double num = value.TotalSeconds * distThroughJourney;
				this.startTime = this.startTime.AddSeconds(0.0 - num);
				this.endTime = this.endTime.AddSeconds(0.0 - num);
			}
			this.state = VillageMapPerson.VillagePeopleStates.MOVING;
			this.facing = SpriteWrapper.getFacing(this.startPos, this.endPos, 8);
			this.updateJourney();
		}

		// Token: 0x06002F76 RID: 12150 RVA: 0x0026CED4 File Offset: 0x0026B0D4
		public void updateJourney()
		{
			if (this.state == VillageMapPerson.VillagePeopleStates.MOVING)
			{
				DateTime now = DateTime.Now;
				if (now >= this.endTime)
				{
					this.currentPos = this.endPos;
					this.state = VillageMapPerson.VillagePeopleStates.STATIONARY;
					return;
				}
				TimeSpan timeSpan = this.endTime - this.startTime;
				double num = (now - this.startTime).TotalSeconds / timeSpan.TotalSeconds;
				double num2 = (double)(this.endPos.X - this.startPos.X) * num + (double)this.startPos.X;
				double num3 = (double)(this.endPos.Y - this.startPos.Y) * num + (double)this.startPos.Y;
				this.currentPos = new PointF((float)num2, (float)num3);
			}
		}

		// Token: 0x06002F77 RID: 12151 RVA: 0x00022752 File Offset: 0x00020952
		public PointF getCurrentPos()
		{
			return this.currentPos;
		}

		// Token: 0x06002F78 RID: 12152 RVA: 0x000227D8 File Offset: 0x000209D8
		public bool isJourneyOver()
		{
			return this.state != VillageMapPerson.VillagePeopleStates.MOVING;
		}

		// Token: 0x06002F79 RID: 12153 RVA: 0x0026CFA8 File Offset: 0x0026B1A8
		public void update()
		{
			this.updateJourney();
			if (this.workerSprite != null)
			{
				this.workerSprite.PosX = this.currentPos.X;
				this.workerSprite.PosY = this.currentPos.Y;
				this.workerSprite.Facing = this.facing;
				int num = (int)this.workerSprite.ColorToUse.A;
				num += this.fadeDir;
				if (num < 160)
				{
					num = 160;
				}
				else if (num > 255)
				{
					num = 255;
				}
				this.workerSprite.ColorToUse = Color.FromArgb((int)((byte)num), 255, 255, 255);
			}
		}

		// Token: 0x04003BA4 RID: 15268
		private GraphicsMgr gfx;

		// Token: 0x04003BA5 RID: 15269
		public SpriteWrapper workerSprite;

		// Token: 0x04003BA6 RID: 15270
		public VillageMapPerson.VillagePeopleStates state;

		// Token: 0x04003BA7 RID: 15271
		public PointF startPos;

		// Token: 0x04003BA8 RID: 15272
		public PointF endPos;

		// Token: 0x04003BA9 RID: 15273
		public PointF currentPos;

		// Token: 0x04003BAA RID: 15274
		public DateTime startTime = DateTime.Now;

		// Token: 0x04003BAB RID: 15275
		public DateTime endTime = DateTime.Now;

		// Token: 0x04003BAC RID: 15276
		public int facing;

		// Token: 0x04003BAD RID: 15277
		public bool idling;

		// Token: 0x04003BAE RID: 15278
		public bool working;

		// Token: 0x04003BAF RID: 15279
		public int fadeDir;

		// Token: 0x020004E9 RID: 1257
		public enum VillagePeopleStates
		{
			// Token: 0x04003BB1 RID: 15281
			STATIONARY,
			// Token: 0x04003BB2 RID: 15282
			MOVING
		}
	}
}
