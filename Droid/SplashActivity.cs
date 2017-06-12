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
using Android.Support.V7.App;
using Android.Util;
using Android.Content.PM;

namespace LesPitonneuxCommunityApp.Droid
{
	[Activity(Label = "Les-Pitonneux-Community-App.Droid", NoHistory = true, Icon = "@drawable/icon", Theme = "@style/Theme.Splash", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

			System.Threading.Thread.Sleep(5000);

			var scale = Resources.DisplayMetrics.Density;

			var pixels = Resources.DisplayMetrics.WidthPixels; // dip pixels 
			int dps = (int)((pixels - 0.5f) / scale);
			Login.SaveScreenWidth(dps);

			pixels = Resources.DisplayMetrics.HeightPixels; // dip pixels 
			dps = (int)((pixels - 0.5f) / scale);
			Login.SaveScreenHeight(dps); // dip pixels 

			this.StartActivity(typeof(MainActivity));
		}
    }
}
