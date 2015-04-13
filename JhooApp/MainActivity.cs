using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace JhooApp
{
	[Activity (Label = "JhooApp", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button bMonsters = FindViewById<Button> (Resource.Id.buttonMonsters);
			Button bQuests = FindViewById<Button> (Resource.Id.buttonQuests);
			Button bItems = FindViewById<Button> (Resource.Id.buttonItems);
			Button bLocations = FindViewById<Button> (Resource.Id.buttonLocations);
			Button bEquipment = FindViewById<Button> (Resource.Id.buttonEquipment);
			Button bSkills = FindViewById<Button> (Resource.Id.buttonSkills);
			Button bUtils = FindViewById<Button> (Resource.Id.buttonUtils);

			bMonsters.Click += delegate {
				var intent = new Intent(this, typeof(MonstersActivity));
				StartActivity(intent);
			};

			bQuests.Click += delegate {
				var intent = new Intent(this, typeof(QuestsActivity));
				StartActivity(intent);
			};

			bItems.Click += delegate {
				var intent = new Intent(this, typeof(ItemsActivity));
				StartActivity(intent);
			};

			bLocations.Click += delegate {
				var intent = new Intent(this, typeof(LocationsActivity));
				StartActivity(intent);
			};

			bEquipment.Click += delegate {
				var intent = new Intent(this, typeof(EquipmentActivity));
				StartActivity(intent);
			};

			bSkills.Click += delegate {
				var intent = new Intent(this, typeof(SkillsActivity));
				StartActivity(intent);
			};

			bUtils.Click += delegate {
				var intent = new Intent(this, typeof(UtilsActivity));
				StartActivity(intent);
			};
		}
	}
}


