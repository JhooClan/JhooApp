
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

namespace JhooApp
{
	[Activity (Label = "DmcCalcActivity")]			
	public class DmcCalcActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView (Resource.Layout.DmgCalc);

			Spinner sWeapType = FindViewById<Spinner> (Resource.Id.wType);
			Button createWeapon = FindViewById<Button> (Resource.Id.start);

			var adapter = ArrayAdapter.CreateFromResource (
				this, Resource.Array.weapons_array, Android.Resource.Layout.SimpleSpinnerItem);

			sWeapType.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs> (spinner_ItemSelected);
			adapter.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);
			sWeapType.Adapter = adapter;

			createWeapon.Click += delegate {
				calculateFunc();
			};
		}

		public string aux;

		public void calculateFunc()
		{
			EditText baseAttack = FindViewById<EditText> (Resource.Id.baseattack);
			EditText elemAttack = FindViewById<EditText> (Resource.Id.elemattack);
			EditText affinity = FindViewById<EditText> (Resource.Id.affinity);
			EditText chaos = FindViewById<EditText> (Resource.Id.chaos);
			CheckBox redSharp = FindViewById<CheckBox> (Resource.Id.redSharp);
			CheckBox orangeSharp = FindViewById<CheckBox> (Resource.Id.orangeSharp);
			CheckBox yellowSharp = FindViewById<CheckBox> (Resource.Id.yellowSharp);
			CheckBox greenSharp = FindViewById<CheckBox> (Resource.Id.greenSharp);
			CheckBox blueSharp = FindViewById<CheckBox> (Resource.Id.blueSharp);
			CheckBox whiteSharp = FindViewById<CheckBox> (Resource.Id.whiteSharp);
			CheckBox purpleSharp = FindViewById<CheckBox> (Resource.Id.purpleSharp);
			TextView wPower = FindViewById<EditText> (Resource.Id.wPower);
			TextView wEfPow = FindViewById<EditText> (Resource.Id.wEfPow);
			TextView wElem = FindViewById<EditText> (Resource.Id.wElem);
			TextView wEfPowS = FindViewById<EditText> (Resource.Id.wEfPowS);
			TextView wElemS = FindViewById<EditText> (Resource.Id.wElemS);
			int atk = int.Parse (baseAttack.Text);
			double power = powerCalc(atk, aux);
			int elem = int.Parse (elemAttack.Text);
			int aff = int.Parse (affinity.Text);
			float aMult;
			if (aff >= 0)
				aMult = 1.25f;
			else
				aMult = 0.75f;
			float sBMult = 0, sEMult = 0;

			if (purpleSharp.Checked){
				sBMult=1.44f;
				sEMult=1.2f;
			}
			else if (whiteSharp.Checked){
				sBMult=1.32f;
				sEMult=1.12f;
			}
			else if (blueSharp.Checked){
				sBMult=1.20f;
				sEMult=1.06f;
			}
			else if (greenSharp.Checked){
				sBMult=1.05f;
				sEMult=1.00f;
			}
			else if (yellowSharp.Checked){
				sBMult=1.00f;
				sEMult=0.75f;
			}
			else if (orangeSharp.Checked){
				sBMult=0.75f;
				sEMult=0.50f;
			}
			else if (redSharp.Checked){
				sBMult=0.50f;
				sEMult=0.25f;
			}

			wPower.Text = string.Format ("Poder: {0}", power);
			wEfPow.Text = string.Format ("Poder efectivo: {0}", ((power*aMult)*aff+power*(100-aff))/100);
			wElem.Text = string.Format ("Poder elemental: {0}", elem/10);
			wEfPowS.Text = string.Format ("P. ef. + Filo Max: {0}", sBMult*((power*aMult)*aff+power*(100-aff))/100);
			wElemS.Text = string.Format ("P. el. + Filo Max: {0}", sEMult*elem/10);
		}

		public void spinner_ItemSelected (Object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner = (Spinner)sender;
			aux = string.Format ("{0}", spinner.GetItemAtPosition (e.Position));

		}

		public double powerCalc (int bAtk, string wType)
		{
			float wMult = 1;
			switch (wType) {
			case "Gran espada":
				wMult = 4.8f;
				break;
			case "Espada larga":
				wMult = 3.3f;
				break;
			case "Espada y escudo":
			case "Espadas dobles":
				wMult = 1.4f;
				break;
			case "Martillo":
			case "Cornamusa":
				wMult = 5.2f;
				break;
			case "Lanza":
			case "Lanza pistola":
				wMult = 2.3f;
				break;
			case "Hacha espada":
				wMult = 5.4f;
				break;
			case "Hacha cargada":
				wMult = 3.6f;
				break;
			case "Glaive insecto":
				wMult = 3.1f;
				break;
			case "Ballesta ligera":
				wMult = 1.3f;
				break;
			case "Ballesta pesada":
				wMult = 1.5f;
				break;
			case "Arco":
				wMult = 1.2f;
				break;
			}
			return bAtk / wMult;
		}
	}
}

