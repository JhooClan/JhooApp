
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Content.PM;

namespace JhooApp
{
	[Activity (Label = "DmcCalcActivity", ScreenOrientation = ScreenOrientation.Portrait)]			
	public class DmcCalcActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView (Resource.Layout.DmgCalc);

			Spinner sWeapType = FindViewById<Spinner> (Resource.Id.wType);
			Spinner sSharpType = FindViewById<Spinner> (Resource.Id.sharpSelect);
			Button createWeapon = FindViewById<Button> (Resource.Id.start);
			CheckBox cbDualElem = FindViewById<CheckBox> (Resource.Id.cbDoubleElem);
			CheckBox cbDualAff = FindViewById<CheckBox> (Resource.Id.cbDoubleAff);
			EditText chaos = FindViewById<EditText> (Resource.Id.chaos);
			EditText dualElem = FindViewById<EditText> (Resource.Id.elemattack2);

			var adapter = ArrayAdapter.CreateFromResource (
				this, Resource.Array.weapons_array, Android.Resource.Layout.SimpleSpinnerItem);
			string weaponType = String.Empty;
			SharpTypes sharpType = SharpTypes.Red;
			sWeapType.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs> ((sender, e) => weaponType=spinner_ItemSelected (sender, e));
			adapter.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);
			sWeapType.Adapter = adapter;

			adapter = ArrayAdapter.CreateFromResource (
				this, Resource.Array.sharpTypes_array, Android.Resource.Layout.SimpleSpinnerItem);

			sSharpType.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs> ((sender, e) => sharpType=Sharpness.stringToSharpType(spinner_ItemSelected (sender, e)));
			adapter.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);
			sSharpType.Adapter = adapter;

			cbDualAff.Click += (o, e) => {
				if (cbDualAff.Checked)
					chaos.Enabled = true;
				else {
					chaos.Enabled = false;
					chaos.Text = "0";
				}
			};
			cbDualElem.Click += (o, e) => {
				if (cbDualElem.Checked)
					dualElem.Enabled = true;
				else {
					dualElem.Enabled = false;
					dualElem.Text = "0";
				}
			};

			createWeapon.Click += delegate {
				calculateFunc(weaponType, sharpType);
			};
		}

		public void calculateFunc(string wType, SharpTypes sharp)
		{
			EditText baseAttack = FindViewById<EditText> (Resource.Id.baseattack);
			EditText elemAttack = FindViewById<EditText> (Resource.Id.elemattack);
			EditText affinity = FindViewById<EditText> (Resource.Id.affinity);
			EditText chaos = FindViewById<EditText> (Resource.Id.chaos);
			TextView wPower = FindViewById<TextView> (Resource.Id.wPower);
			TextView wEfPow = FindViewById<TextView> (Resource.Id.wEfPow);
			TextView wElem = FindViewById<TextView> (Resource.Id.wElem);
			TextView wEfPowS = FindViewById<TextView> (Resource.Id.wEfPowS);
			TextView wElemS = FindViewById<TextView> (Resource.Id.wElemS);

			int atk, elem, aff, affc;
			if (baseAttack.Text == String.Empty)
				baseAttack.Text = "0";
			atk = int.Parse (baseAttack.Text);

			if (elemAttack.Text == String.Empty)
				elemAttack.Text = "0";
			elem = int.Parse (elemAttack.Text);

			if (affinity.Text == String.Empty)
				affinity.Text = "0";
			aff = int.Parse (affinity.Text);

			if (chaos.Text == String.Empty)
				chaos.Text = "0";
			affc = int.Parse (chaos.Text);

			Sharpness sh = new Sharpness (14, 14, 14, 14, 14, 14, 14);
			Weapon weap = null;
			switch (wType) {
			case "Gran espada":
				weap = new GreatSword (true, atk, elem, sh, aff, affc);
				break;
			case "Espada larga":
				weap = new LongSword (true, atk, elem, sh, aff, affc);
				break;
			case "Espada y escudo":
				weap = new SwordnShield (true, atk, elem, sh, aff, affc);
				break;
			case "Espadas dobles":
				weap=new DualBlades(true, atk, elem, sh, aff, affc);
				break;
			case "Martillo":
				weap = new Hammer (true, atk, elem, sh, aff, affc);
				break;
			case "Cornamusa":
				weap = new HuntingHorn (true, atk, elem, sh, aff, affc);
				break;
			case "Lanza":
				weap = new Lance (true, atk, elem, sh, aff, affc);
				break;
			case "Lanza pistola":
				weap = new Gunlance (true, atk, elem, sh, aff, affc);
				break;
			case "Hacha espada":
				weap = new SwitchAxe (true, atk, elem, sh, aff, affc);
				break;
			case "Hacha cargada":
				weap = new ChargeBlade (true, atk, elem, sh, aff, affc);
				break;
			case "Glaive insecto":
				weap = new InsectGlaive (true, atk, elem, sh, aff, affc);
				break;
//			case "Ballesta ligera":
//				weap = new LightBowgun (true, atk, aff);
//				break;
//			case "Ballesta pesada":
//				weap = new HeavyBowgun (true, atk, aff);
//				break;
//			case "Arco":
//				weap = new Bow (true, atk, aff);
//				break;
			}

			wPower.Text = string.Format ("Poder: {0}", (float)weap.power ());
			wEfPow.Text = string.Format ("Poder efectivo: {0}", (float)weap.effectivePower ());
			wElem.Text = string.Format ("Poder elemental: {0}", (float)weap.elementalPower ());
			wEfPowS.Text = string.Format ("P. ef. + Filo Max: {0}", (float)weap.sharpEffectivePower (sharp));
			wElemS.Text = string.Format ("P. el. + Filo Max: {0}", (float)weap.sharpElementalPower (sharp));
		}

		public string spinner_ItemSelected (Object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner = (Spinner)sender;
			CheckBox cbDualElement = FindViewById<CheckBox> (Resource.Id.cbDoubleElem);
			if ((string)spinner.GetItemAtPosition (0) == "Gran espada")
				cbDualElement.Enabled = (string)spinner.GetItemAtPosition (e.Position) == "Espadas dobles";
			return string.Format ("{0}", spinner.GetItemAtPosition (e.Position));
		}

//		public void weaponInit (Weapon weapon, string wType)
//		{
//			switch (wType) {
//			case "Gran espada":
//				wMult = 4.8f;
//				break;
//			case "Espada larga":
//				wMult = 3.3f;
//				break;
//			case "Espada y escudo":
//			case "Espadas dobles":
//				wMult = 1.4f;
//				break;
//			case "Martillo":
//			case "Cornamusa":
//				wMult = 5.2f;
//				break;
//			case "Lanza":
//			case "Lanza pistola":
//				wMult = 2.3f;
//				break;
//			case "Hacha espada":
//				wMult = 5.4f;
//				break;
//			case "Hacha cargada":
//				wMult = 3.6f;
//				break;
//			case "Glaive insecto":
//				wMult = 3.1f;
//				break;
//			case "Ballesta ligera":
//				wMult = 1.3f;
//				break;
//			case "Ballesta pesada":
//				wMult = 1.5f;
//				break;
//			case "Arco":
//				wMult = 1.2f;
//				break;
//			}
//			return bAtk / wMult;
//		}
	}
}

