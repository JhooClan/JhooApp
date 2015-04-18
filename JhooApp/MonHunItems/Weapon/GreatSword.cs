using System;

namespace JhooApp
{
	public class GreatSword : MeleeWeapon
	{
		private readonly string[] wType;
		private int chaos;

		public GreatSword (bool tmp, int baseatk, int elematk, Sharpness sharp, int affinity, int chaos) : base (tmp, baseatk, elematk, sharp, affinity)
		{
			wType = new string[2];
			wType [0] = "Gran Espada";
			wType [1] = "Great Sword";
			this.chaos = chaos;
		}
	}
}

