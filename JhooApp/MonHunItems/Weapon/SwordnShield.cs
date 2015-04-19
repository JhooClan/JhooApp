using System;

namespace JhooApp
{
	public class SwordnShield : MeleeWeapon
	{
		public SwordnShield (bool tmp, int baseatk, int elematk, Sharpness sharp, int affinity, int chaos) : base (tmp, baseatk, elematk, sharp, affinity, chaos)
		{
			wType = new string[2];
			wType [0] = "Espada y escudo";
			wType [1] = "Sword and Shield";
			mult = 1.4f;
		}

		public int motionValue(SwordnShieldMotionValues mvalue)
		{
			return (int)mvalue;
		}

		public int maxMotionValue()
		{
			int max = 0;
			foreach (var motion in Enum.GetValues(typeof(SwordnShieldMotionValues))){
				if (max < (int)motion)
					max = (int)motion;
			}
			return max;
		}

		public int minMotionValue()
		{
			int min=maxMotionValue();
			foreach (var motion in Enum.GetValues(typeof(SwordnShieldMotionValues))){
				if (min > (int)motion)
					min = (int)motion;
			}
			return min;
		}
	}
}

