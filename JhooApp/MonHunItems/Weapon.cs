using System;

namespace JhooApp
{
	public class Weapon : EquipmentItem
	{
		protected int baseatk;
		protected int affinity;
		protected float mult;
		protected bool sergio;
		protected int upgradedFromID;
		protected CraftObject createFromUpgrade;
		protected int upgradedToID;

		public Weapon (bool tmp, int baseatk, int affinity) : base (tmp)
		{
			setBaseatk (baseatk);
			setAffinity(affinity);
		}

		public void setBaseatk (int baseatk)
		{
			if (baseatk >= 0)
				this.baseatk = baseatk;
			else
				throw new ArgumentException("Parameter cannot be less than 0", "baseatk");
		}

		public int getBaseatk ()
		{
			return baseatk;
		}

		public void setAffinity (int affinity)
		{
			if (-100 <= affinity && affinity <= 100)
				this.affinity = affinity;
			else
				throw new ArgumentException ("Parameter must be between -100 and 100", "affinity");
		}

		public int getAffinity ()
		{
			return affinity;
		}

		public void setSergio (bool sergio)
		{
			this.sergio = sergio;
		}

		public bool getSergio ()
		{
			return sergio;
		}

		public float getMult ()
		{
			return mult;
		}

		public virtual double power()
		{
			return 0;
		}

		public virtual double effectivePower()
		{
			return 0;
		}

		public virtual float elementalPower()
		{
			return 0;
		}

		public virtual double sharpPower(SharpTypes maxSharp)
		{
			return 0;
		}

		public virtual double sharpEffectivePower(SharpTypes maxSharp)
		{
			return 0;
		}

		public virtual float sharpElementalPower(SharpTypes maxSharp)
		{
			return 0;
		}
	}
}

