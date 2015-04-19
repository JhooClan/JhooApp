using System;

namespace JhooApp
{
	public class LongSword : MeleeWeapon
	{
		public LongSword (bool tmp, int baseatk, int elematk, Sharpness sharp, int affinity, int chaos) : base (tmp, baseatk, elematk, sharp, affinity, chaos)
		{
			wType = new string[2];
			wType [0] = "Espada Larga";
			wType [1] = "Long Sword";
			mult = 3.3f;
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

