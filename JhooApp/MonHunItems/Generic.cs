using System;

namespace JhooApp
{
	public class Generic
	{
		private static int count;
		private bool tmp;
		private readonly int id;
		private string name;
		private int rarity;
		private int buyValue;
		private int sellValue;
		private string desc;
		private string icon;

		public Generic (bool tmp)
		{
			this.tmp = tmp;
			if (!tmp)
			{
				id=count;
				count++;
			}
		}

		public bool isTmp()
		{
			return tmp;
		}

		public int getId()
		{
			return id;
		}

		public void setName(string name)
		{
			this.name = name;
		}

		public string getName()
		{
			return name;
		}

		public void setRarity(int rarity)
		{
			if (1<=rarity<=10)
				this.rarity = rarity;
		}

		public int getRarity()
		{
			return rarity;
		}

		public void setBuyValue(int buyValue)
		{
			if (buyValue>=0)
				this.buyValue = buyValue;
		}

		public int getBuyValue()
		{
			return buyValue;
		}

		public void setSellValue(int sellValue)
		{
			if (sellValue>=0)
				this.sellValue = sellValue;
		}

		public int getSellValue()
		{
			return sellValue;
		}

		public void setDesc(string desc)
		{
			this.desc = desc;
		}

		public string getDesc()
		{
			return desc;
		}

		public void setIcon(string icon)
		{
			this.icon = icon;
		}

		public string getIcon()
		{
			return icon;
		}

	}
}

