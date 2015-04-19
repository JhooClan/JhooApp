using System;

namespace JhooApp
{
	public class Hammer : MeleeWeapon
	{
		public Hammer (bool tmp, int baseatk, int elematk, Sharpness sharp, int affinity, int chaos) : base (tmp, baseatk, elematk, sharp, affinity, chaos)
		{
			wType = new string[2];
			wType [0] = "Martillo";
			wType [1] = "Hammer";
			mult = 5.2f;
		}

		public int motionValue(HammerMotionValues mvalue)
		{
			return (int)mvalue;
		}

		public int maxMotionValue()
		{
			int max = 0;
			foreach (var motion in Enum.GetValues(typeof(HammerMotionValues))){
				if (max < (int)motion)
					max = (int)motion;
			}
			return max;
		}

		public int minMotionValue()
		{
			int min=maxMotionValue();
			foreach (var motion in Enum.GetValues(typeof(HammerMotionValues))){
				if (min > (int)motion)
					min = (int)motion;
			}
			return min;
		}
	}
}

