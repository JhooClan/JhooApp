using System;

namespace JhooApp
{
	public class Lance : MeleeWeapon
	{
		public Lance (bool tmp, int baseatk, int elematk, Sharpness sharp, int affinity, int chaos) : base (tmp, baseatk, elematk, sharp, affinity, chaos)
		{
			wType = new string[2];
			wType [0] = "Lanza";
			wType [1] = "Lance";
			mult = 2.3f;
		}

		public int motionValue(LanceMotionValues mvalue)
		{
			return (int)mvalue;
		}

		public int maxMotionValue()
		{
			int max = 0;
			foreach (var motion in Enum.GetValues(typeof(LanceMotionValues))){
				if (max < (int)motion)
					max = (int)motion;
			}
			return max;
		}

		public int minMotionValue()
		{
			int min=maxMotionValue();
			foreach (var motion in Enum.GetValues(typeof(LanceMotionValues))){
				if (min > (int)motion)
					min = (int)motion;
			}
			return min;
		}
	}
}

