using System;

using Android.App;
using Android.Widget;
using Android.OS;

namespace tipcalculator.Droid
{
    [Activity(Label = "Tip Calculator", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            TipCalculator tc = new TipCalculator();

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            EditText billTextField = FindViewById<EditText>(Resource.Id.billEditText);
            SeekBar slider = FindViewById<SeekBar>(Resource.Id.slider);
            TextView sliderTextView = FindViewById<TextView>(Resource.Id.slideTextView);
            TextView tipTextView = FindViewById<TextView>(Resource.Id.tipTextView);
            TextView totalTextView = FindViewById<TextView>(Resource.Id.totalTextView);

            // updating tip and total text view when the user type an amount
            billTextField.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => 
            {
                if (string.IsNullOrEmpty(billTextField.Text))
                {
                    tipTextView.Text = tc.DefaultValues();
                    totalTextView.Text=  tc.DefaultValues();
                }
                else{
                    tipTextView.Text = tc.CalculatingTip(billTextField.Text, slider.Progress); // !
                    totalTextView.Text = tc.CalculatingTotal(tipTextView.Text, billTextField.Text);
                }
            };

            // updating tip and total text view when the user make use of the slider
            slider.ProgressChanged +=(object sender, SeekBar.ProgressChangedEventArgs e) =>
            {
                sliderTextView.Text = tc.ChangingPercentageNumber(slider.Progress);

                if (string.IsNullOrEmpty(billTextField.Text))
                {
                    tipTextView.Text = tc.DefaultValues();
                    totalTextView.Text = tc.DefaultValues();
                }
                else
                {
                    tipTextView.Text = tc.CalculatingTip(billTextField.Text, slider.Progress); // !
                    totalTextView.Text = tc.CalculatingTotal(tipTextView.Text, billTextField.Text);
                }
                           
            };
        }
    }
}
