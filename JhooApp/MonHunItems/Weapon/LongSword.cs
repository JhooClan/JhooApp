using System;

namespace JhooApp
{
	public class LongSword : MeleeWeapon
	{
		protected readonly string[] wType;
		protected int chaos;

		public LongSword (bool tmp, int baseatk, int elematk, Sharpness sharp, int affinity, int chaos) : base (tmp, baseatk, elematk, sharp, affinity)
		{
			wType = new string[2];
			wType [0] = "Espada Larga";
			wType [1] = "Long Sword";
			this.chaos = chaos;
			mult = 3.3f;
		}

		public void setChaos(int chaos)
		{
			if (-100 <= chaos && chaos <= 100)
				this.chaos = chaos;
			else
				throw new ArgumentException("Parameter must be between -100 and 100", "chaos");
		}

		public int getChaos()
		{
			return chaos;
		}

		public int motionValue(LongSwordMotionValues mvalue)
		{
			return (int)mvalue;
		}

		public int maxMotionValue()
		{
			int max = 0;
			foreach (var motion in Enum.GetValues(typeof(LongSwordMotionValues))){
				if (max < (int)motion)
					max = (int)motion;
			}
			return max;
		}

		public int minMotionValue()
		{
			int min=maxMotionValue();
			foreach (var motion in Enum.GetValues(typeof(LongSwordMotionValues))){
				if (min > (int)motion)
					min = (int)motion;
			}
			return min;
		}
	}
}

