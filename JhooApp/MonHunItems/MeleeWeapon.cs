using System;

namespace JhooApp
{
	public class MeleeWeapon : Weapon
	{

		protected bool elmIsHidden;
		protected Elem element;
		protected int elematk;
		protected Sharpness sharp;
		protected Sharpness sharpExtra;
		protected int chaos;

		public MeleeWeapon (bool tmp, int baseatk, int elematk, Sharpness sharp, int affinity, int chaos) : base (tmp, baseatk, affinity)
		{
			this.elematk = elematk;
			this.sharp = sharp;
			this.chaos = chaos;
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

		public void setElematk (int elematk)
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

		public override double power()
		{
			return baseatk/mult;
		}

		public override double effectivePower()
		{
			float aMult, cMult;

			if (affinity >= 0)
				aMult = 1.25f;
			else
				aMult = 0.75f;

			if (chaos >= 0)
				cMult = 1.25f;
			else
				cMult = 0.75f;

			return ((power() * aMult) * Math.Abs(affinity) + (power() * cMult) * Math.Abs(chaos) + power() * (100 - Math.Abs(affinity - Math.Abs(chaos)))) / 100;
		}

		public override float elementalPower()
		{
			return elematk / 10;
		}

		public override double sharpPower(SharpTypes maxSharp)
		{
			return power()*Sharpness.atkMult(maxSharp);
		}

		public override double sharpEffectivePower(SharpTypes maxSharp)
		{
			return effectivePower()*Sharpness.atkMult(maxSharp);
		}

		public override float sharpElementalPower(SharpTypes maxSharp)
		{
			return elementalPower()*Sharpness.elmMult(maxSharp);
		}
	}
}

