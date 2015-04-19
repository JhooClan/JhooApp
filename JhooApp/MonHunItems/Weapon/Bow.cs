using System;

namespace JhooApp
{
	public class Bow : RangedWeapon
	{
		public Bow (bool tmp, int baseatk, int affinity) : base(tmp, baseatk, affinity)
		{
			wType = new string[2];
			wType [0] = "Arco";
			wType [1] = "Bow";
			mult = 1.2f;
		}

		public int motionValue(BowMotionValues mvalue)
		{
			return (int)mvalue;
		}

		public int maxMotionValue()
		{
			int max = 0;
			foreach (var motion in Enum.GetValues(typeof(BowMotionValues))){
				if (max < (int)motion)
					max = (int)motion;
			}
			return max;
		}

		public int minMotionValue()
		{
			int min=maxMotionValue();
			foreach (var motion in Enum.GetValues(typeof(BowMotionValues))){
				if (min > (int)motion)
					min = (int)motion;
			}
			return min;
		}
	}
}

