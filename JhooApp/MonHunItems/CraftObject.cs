using System;

namespace JhooApp
{
	public class CraftObject
	{
		private int price;
		private int[] itemIDs;
		private int[] itemQts;
		private int index;

		public CraftObject ()
		{
			price = 0;
			index = 0;
			itemIDs = new int[4];
			itemQts = new int[4];
			for (int i = 0; i < 4; i++) {
				itemIDs [i] = -1;
				itemQts [i] = 0;
			}
		}

		public void setPrice(int price)
		{
			if (price >= 0)
				this.price = price;
			else
				throw new ArgumentException ("Parameter cannot be less than 0", "price");
		}

		public int getPrice()
		{
			return price;
		}

		public int getIndex()
		{
			return index;
		}

		public void addItem(int itemID, int itemQt)
		{
			if (0 <= index < 4) {
				itemIDs [index] = itemID;
				itemQts [index] = itemQt;
				index++;
			}
		}

		public void remItem(int itemID)
		{
			int aux, i=0;
			bool found = false;
			while (!found && i < index) {
				if (itemID == itemIDs [i]){
					found = true;
					aux = i;
				}
				i++;
			}
			if (found) {
				while (aux < 3) {
					itemIDs [aux] = itemIDs [aux + 1];
					itemQts [aux] = itemQts [aux + 1];
				}
				itemIDs [3] = -1;
				itemQts [3] = -1;
				index--;
			}
		}

		public void changeItemQt (int itemID, int itemQt)
		{
			if (itemQt > 0) {
				int aux, i = 0;
				bool found = false;
				while (!found && i < index) {
					if (itemID == itemIDs [i]) {
						found = true;
						itemQts [i] = itemQt;
					}
					i++;
				}
				if (!found)
					throw new ArgumentException ("Parameter cannot be found", "itemID");
			} else
				remItem(itemID);
		}

		public int getItemID (int index)
		{
			return itemIDs [index];
		}

		public int getItemQt (int index)
		{
			return itemQts [index];
		}
	}
}

