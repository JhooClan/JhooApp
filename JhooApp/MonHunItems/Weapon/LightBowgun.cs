using System;

namespace JhooApp
{
	public class LightBowgun : RangedWeapon
	{
		public LightBowgun (bool tmp, int baseatk, int affinity) : base(tmp, baseatk, affinity)
		{
			wType = new string[2];
			wType [0] = "Ballesta ligera";
			wType [1] = "Light Bowgun";
			mult = 1.3f;
		}

		public int motionValue(LightBowgunMotionValues mvalue)
		{
			return (int)mvalue;
		}

		public int maxMotionValue()
		{
			int max = 0;
			foreach (var motion in Enum.GetValues(typeof(LightBowgunMotionValues))){
				if (max < (int)motion)
					max = (int)motion;
			}
			return max;
		}

		public int minMotionValue()
		{
			int min=maxMotionValue();
			foreach (var motion in Enum.GetValues(typeof(LightBowgunMotionValues))){
				if (min > (int)motion)
					min = (int)motion;
			}
			return min;
		}
	}
}

