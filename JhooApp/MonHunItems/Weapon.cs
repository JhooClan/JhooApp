using System;

namespace JhooApp
{
	public class Weapon : EquipmentItem
	{
		private int baseatk;
		private int affinity;
		private bool sergio;
		private int upgradedFromID;
		private CraftObject createFromUpgrade;
		private int upgradedToID;
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
			if (-100<=affinity<=100)
				this.affinity = affinity;
			else
				throw new ArgumentException("Parameter must be between -100 and 100", "affinity");
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
	}
}

