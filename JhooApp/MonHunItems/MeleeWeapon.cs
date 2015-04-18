using System;

namespace JhooApp
{
	public class MeleeWeapon : Weapon
	{

		private bool elmIsHidden;
		private Elem element;
		private int elematk;
		private Sharpness sharp;
		private Sharpness sharpExtra;

		public MeleeWeapon (bool tmp, int baseatk, int elematk, Sharpness sharp, int affinity) : base (tmp, baseatk, affinity)
		{
			this.elematk = elematk;
			this.sharp = sharp;
		}

		public void setElmIsHidden (bool elmIsHidden)
		{
			this.elmIsHidden = elmIsHidden;
		}

		public bool getElmIsHidden ()
		{
			return elmIsHidden;
		}

		public void setElement (Elem element)
		{
			this.element = element;
		}

		public Elem getElement ()
		{
			return element;
		}

		public int setElematk (int elematk)
		{
			if (elematk >= 0)
				this.elematk = elematk;
			else
				throw new ArgumentException("Parameter cannot be less than 0", "elematk");
		}

		public int getElematk ()
		{
			return elematk;
		}

		public void setSharp (Sharpness sharp)
		{
			this.sharp = sharp;
		}

		public Sharpness getSharp ()
		{
			return sharp;
		}

		public void setSharpExtra (Sharpness sharpExtra)
		{
			this.sharpExtra = sharpExtra;
		}

		public Sharpness getSharpExtra ()
		{
			return sharpExtra;
		}
	}
}

