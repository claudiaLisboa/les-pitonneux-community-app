using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace LesPitonneuxCommunityApp.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            try
            {
                global::Xamarin.Forms.Forms.Init();

                Login.SaveScreenWidth(UIScreen.MainScreen.Bounds.Width);
                Login.SaveScreenHeight(UIScreen.MainScreen.Bounds.Height);

                LoadApplication(new App());

                return base.FinishedLaunching(app, options);
            }
            catch (Exception exception)
            {
                Console.WriteLine("App.Main: YYY ");
                Console.WriteLine(exception.StackTrace);
                throw;
            }
        }
    }
}
