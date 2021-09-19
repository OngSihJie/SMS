using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Android.Telephony;
using Android.Content;

namespace SMS_try_again1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            
            var sendSMSIntent = FindViewById<Button>(Resource.Id.sendSMSIntent);
            sendSMSIntent.Click += (sender, e) => {
                var smsUri = Android.Net.Uri.Parse("smsto:8015275711");
                var smsIntent = new Intent(Intent.ActionSendto, smsUri);
                smsIntent.PutExtra("sms_body", "Hi, I am interested in the house at <ADDRESS>you have posted for rent. Could I please have more details?");
                StartActivity(smsIntent);
            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}