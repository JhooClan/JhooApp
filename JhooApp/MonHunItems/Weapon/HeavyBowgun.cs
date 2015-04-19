using System;

namespace JhooApp
{
	public class HeavyBowgun : RangedWeapon
	{
		public HeavyBowgun (bool tmp, int baseatk, int affinity) : base(tmp, baseatk, affinity)
		{
			wType = new string[2];
			wType [0] = "Ballesta pesada";
			wType [1] = "Heavy Bowgun";
			mult = 1.5f;
		}

		public int motionValue(HeavyBowgunMotionValues mvalue)
		{
			return (int)mvalue;
		}

		public int maxMotionValue()
		{
			int max = 0;
			foreach (var motion in Enum.GetValues(typeof(HeavyBowgunMotionValues))){
				if (max < (int)motion)
					max = (int)motion;
			}
			return max;
		}

		public int minMotionValue()
		{
			int min=maxMotionValue();
			foreach (var motion in Enum.GetValues(typeof(HeavyBowgunMotionValues))){
				if (min > (int)motion)
					min = (int)motion;
			}
			return min;
		}
	}
}

