using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using SQLite.Net.Platform.XamarinIOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Vocabulary;

namespace Vocabulary.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

			// Code for starting up the Xamarin Test Cloud Agent
#if DEBUG
			Xamarin.Calabash.Start();
#endif

			//LoadApplication(new App());

			string dbPath = FileAccessHelper.GetLocalFilePath("people.db3");

			LoadApplication(new App(dbPath, new SQLitePlatformIOS()));


			return base.FinishedLaunching(app, options);
        }
    }
}

/*
 using Foundation;
using SQLite.Net.Platform.XamarinIOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using People;

 namespace People.iOS
{
[Register ("AppDelegate")]
public partial class AppDelegate : FormsApplicationDelegate
{
    public override bool FinishedLaunching (UIApplication app, NSDictionary options)
    {
        Forms.Init ();

        string dbPath = FileAccessHelper.GetLocalFilePath ("people.db3");

        LoadApplication (new App (dbPath, new SQLitePlatformIOS ()));

        return base.FinishedLaunching (app, options);
    }
}
}
 */
