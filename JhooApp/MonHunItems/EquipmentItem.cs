using System;

namespace JhooApp
{
	public class EquipmentItem : Generic
	{
		private int defense;
		private int slots;
		private CraftObject createFromZero;

		public EquipmentItem (bool tmp) : base(tmp)
		{
			defense = 0;
			slots = 0;
			createFromZero = new CraftObject ();
		}

		public void setDefense (int defense)
		{
			if (defense >= 0)
				this.defense = defense;
			else
				throw new ArgumentException ("Parameter cannot be less than 0", "defense");
		}

		public int getDefense()
		{
			return defense;
		}

		public void setSlots (int slots)
		{
			if (0 <= slots <= 3)
				this.slots = slots;
			else
				throw new ArgumentException ("Parameter must be between 0 and 3", "slots");
		}

		public int getSlots ()
		{
			return slots;
		}

		public void setCreatePrice (int price)
		{
			createFromZero.setPrice (price);
		}

		public int getCreatePrice ()
		{
			return createFromZero.getPrice ();
		}

		public int getCreateIndex ()
		{
			return createFromZero.getIndex ();
		}

		public void addCreateItems (int index, int[] itemIDs, int[]itemQts)
		{
			if (index <= 4)
				for (int i = 0; i < index; i++) {
					createFromZero.addItem (itemIDs [i], itemQts [i]);
				}
			else
				addCreateItems (4, itemIDs, itemQts);
		}

		public void removeCreateItems (int itemID)
		{
			createFromZero.remItem (itemID);
		}

		public void changeCreateItemQt (int itemID, int itemQt)
		{
			createFromZero.changeItemQt (itemID, itemQt);
		}

		public int getCreateItemID (int index)
		{
			return createFromZero.getItemID ();
		}

		public int getCreateItemQt (int index)
		{
			return createFromZero.getItemQt ();
		}
	}
}

