
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

			sWeapType.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs> (sWeapType_ItemSelected);
			var adapter = ArrayAdapter.CreateFromResource (
				this, Resource.Array.weapons_array, Android.Resource.Layout.SimpleSpinnerItem);

			adapter.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);
			sWeapType.Adapter = adapter;
		}

		private void sWeapType_ItemSelected (object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner = (Spinner)sender;

			string toast = string.Format ("The planet is {0}", spinner.GetItemAtPosition (e.Position));
			Toast.MakeText (this, toast, ToastLength.Long).Show ();
		}
	}
}

