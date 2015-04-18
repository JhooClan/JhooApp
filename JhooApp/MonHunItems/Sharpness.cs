using System;

namespace JhooApp
{
	public class Sharpness
	{
		private readonly byte red;
		private readonly byte orange;
		private readonly byte yellow;
		private readonly byte green;
		private readonly byte blue;
		private readonly byte white;
		private readonly byte purple;

		public Sharpness (byte red, byte orange, byte yellow, byte green, byte blue, byte white, byte purple)
		{
			if (red + orange + yellow + green + blue + white + purple <= 100)
			{
				this.red = red;
				this.orange = orange;
				this.yellow = yellow;
				this.green = green;
				this.blue = blue;
				this.white = white;
				this.purple = purple;
			}
		}

		public static float atkMult (SharpTypes sharp, int baseatk)
		{
			float attack = 0;
			switch (sharp) {
			case SharpTypes.Red:
				attack = baseatk * 0.5f;
				break;
			case SharpTypes.Orange:
				attack = baseatk * 0.75f;
				break;
			case SharpTypes.Yellow:
				attack = (float)baseatk;
				break;
			case SharpTypes.Green:
				attack = baseatk * 1.05f;
				break;
			case SharpTypes.Blue:
				attack = baseatk * 1.2f;
				break;
			case SharpTypes.White:
				attack = baseatk * 1.32f;
				break;
			case SharpTypes.Purple:
				attack = baseatk * 1.45f;
				break;
			}
			return attack;
		}

		public static float elmMult (SharpTypes sharp, int elmatk)
		{
			float eattack = 0;
			switch (sharp) {
			case SharpTypes.Red:
				eattack = elmatk * 0.25f;
				break;
			case SharpTypes.Orange:
				eattack = elmatk * 0.50f;
				break;
			case SharpTypes.Yellow:
				eattack = elmatk * 0.75f;
				break;
			case SharpTypes.Green:
				eattack = (float)elmatk;
				break;
			case SharpTypes.Blue:
				eattack = elmatk * 1.0625f;
				break;
			case SharpTypes.White:
				eattack = elmatk * 1.125f;
				break;
			case SharpTypes.Purple:
				eattack = elmatk * 1.2f;
				break;
			}
			return eattack;
		}
	}
}

