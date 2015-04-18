﻿using System;

namespace JhooApp
{
	public class GreatSword : MeleeWeapon
	{
		protected readonly string[] wType;
		protected int chaos;

		public GreatSword (bool tmp, int baseatk, int elematk, Sharpness sharp, int affinity, int chaos) : base (tmp, baseatk, elematk, sharp, affinity)
		{
			wType = new string[2];
			wType [0] = "Gran Espada";
			wType [1] = "Great Sword";
			this.chaos = chaos;
			mult = 4.8f;
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

		public int motionValue(GreatSwordMotionValues mvalue)
		{
			return (int)mvalue;
		}

		public int maxMotionValue()
		{
			int max = 0;
			foreach (var motion in Enum.GetValues(typeof(GreatSwordMotionValues))){
				if (max < (int)motion)
					max = (int)motion;
			}
			return max;
		}

		public int minMotionValue()
		{
			int min=maxMotionValue();
			foreach (var motion in Enum.GetValues(typeof(GreatSwordMotionValues))){
				if (min > (int)motion)
					min = (int)motion;
			}
			return min;
		}
	}
}

