
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
	[Activity (Label = "UtilsActivity", ScreenOrientation = ScreenOrientation.Portrait)]			
	public class UtilsActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView (Resource.Layout.Utils);

			Button bCalc = FindViewById<Button> (Resource.Id.buttonCalc);

			bCalc.Click += delegate {
				var intent = new Intent(this, typeof(DmcCalcActivity));
				StartActivity(intent);
			};
		}
	}
}

