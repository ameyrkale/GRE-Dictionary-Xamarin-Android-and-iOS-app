using Android.App;
using Android.Content.PM;
using Android.OS;
using SQLite.Net.Platform.XamarinAndroid;
using System.Threading.Tasks;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Plugin.Geolocator;
using Google.Ads;
using Android.Gms.Ads;


namespace Vocab.Droid
{
	[Activity(Label = "Vocab", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);

            global::Xamarin.FormsMaps.Init(this, bundle);

			string dbPath = FileAccessHelper.GetLocalFilePath("people");

            // Location();
		
			LoadApplication(new App(dbPath, new SQLitePlatformAndroid()));
		}

        public async Task<double> Location()
        {
			var locator = CrossGeolocator.Current;
			locator.DesiredAccuracy = 20;
			var position = await locator.GetLastKnownLocationAsync();

            return position.Latitude;

		}

		/*

		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
			{
				base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
			} 
		*/

	}
}