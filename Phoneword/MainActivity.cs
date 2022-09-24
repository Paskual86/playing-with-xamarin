using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace Phoneword
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

            // Get our UI controls from the loaded layout
            var phoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
            var translatedPhoneWord = FindViewById<TextView>(Resource.Id.TranslatedPhoneword);
            var translateButton = FindViewById<Button>(Resource.Id.TranslateButton);

            // Add code to translate number
            if (translateButton != null)
                translateButton.Click += (sender, e) =>
                {
                    // Translate user's alphanumeric phone number to numeric
                    if (phoneNumberText != null)
                    {
                        string translatedNumber = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text);
                        if (string.IsNullOrWhiteSpace(translatedNumber))
                        {
                            if (translatedPhoneWord != null) translatedPhoneWord.Text = string.Empty;
                        }
                        else
                        {
                            if (translatedPhoneWord != null) translatedPhoneWord.Text = translatedNumber;
                        }
                    }
                };
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}