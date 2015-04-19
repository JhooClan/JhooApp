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

		public static SharpTypes stringToSharpType(string strong)
		{
			SharpTypes shar = SharpTypes.Red;
			switch (strong) {
			case "Rojo":
			case "Red":
				shar = SharpTypes.Red;
				break;
			case "Naranja":
			case "Orange":
				shar = SharpTypes.Orange;
				break;
			case "Amarillo":
			case "Yellow":
				shar = SharpTypes.Yellow;
				break;
			case "Verde":
			case "Green":
				shar = SharpTypes.Green;
				break;
			case "Azul":
			case "Blue":
				shar = SharpTypes.Blue;
				break;
			case "Blanco":
			case "White":
				shar = SharpTypes.White;
				break;
			case "Morado":
			case "Purple":
				shar = SharpTypes.Purple;
				break;
			}
			return shar;
		}

		public static float atkMult (SharpTypes sharp)
		{
			float attack = 0;
			switch (sharp) {
			case SharpTypes.Red:
				attack = 0.50f;
				break;
			case SharpTypes.Orange:
				attack = 0.75f;
				break;
			case SharpTypes.Yellow:
				attack = 1.00f;
				break;
			case SharpTypes.Green:
				attack = 1.05f;
				break;
			case SharpTypes.Blue:
				attack = 1.20f;
				break;
			case SharpTypes.White:
				attack = 1.32f;
				break;
			case SharpTypes.Purple:
				attack = 1.45f;
				break;
			}
			return attack;
		}

		public static float elmMult (SharpTypes sharp)
		{
			float eattack = 0;
			switch (sharp) {
			case SharpTypes.Red:
				eattack = 0.25f;
				break;
			case SharpTypes.Orange:
				eattack = 0.50f;
				break;
			case SharpTypes.Yellow:
				eattack = 0.75f;
				break;
			case SharpTypes.Green:
				eattack = 1.00f;
				break;
			case SharpTypes.Blue:
				eattack = 1.0625f;
				break;
			case SharpTypes.White:
				eattack = 1.125f;
				break;
			case SharpTypes.Purple:
				eattack = 1.2f;
				break;
			}
			return eattack;
		}
	}
}

