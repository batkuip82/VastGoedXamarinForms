using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using UXDivers.Gorilla;

namespace VastGoed.Droid
{
    [Activity(Label = "VastGoed", Icon = "@drawable/icon", Theme = "@style/MainTheme",  ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
#if GORILLA
            LoadApplication(UXDivers.Gorilla.Droid.Player.CreateApplication(ApplicationContext,
                new Config("Good Gorilla").RegisterAssembliesFromTypes<
                                                Prism.IActiveAware,
                                                Prism.PrismApplicationBase<App>, 
                                                Prism.Unity.PrismApplication>()));
#endif
            MessagingCenter.Subscribe<string>(this, "Share", Share, null);
        }

        void Share(string url)
        {
            var intent = new Intent(Intent.ActionSend);
            intent.SetType("text/plain");

            intent.PutExtra(Intent.ExtraSubject, "Ik wil dit bericht delen van VastGoed berichten.");
            intent.PutExtra(Intent.ExtraText, url);

            var intentChooser = Intent.CreateChooser(intent, "Share via");

            StartActivityForResult(intentChooser, 1000);
        }
    }
}

