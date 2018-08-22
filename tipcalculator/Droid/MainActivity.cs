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

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            EditText billTextField = FindViewById<EditText>(Resource.Id.billEditText);
            SeekBar slider = FindViewById<SeekBar>(Resource.Id.slider);
            TextView sliderTextView = FindViewById<TextView>(Resource.Id.slideTextView);
            TextView tipTextView = FindViewById<TextView>(Resource.Id.tipTextView);
            TextView totalTextView = FindViewById<TextView>(Resource.Id.totalTextView);

            billTextField.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => 
            {
                if (string.IsNullOrEmpty(billTextField.Text))
                {
                    tipTextView.Text = "0.00";
                    totalTextView.Text = "0.00";
                }
                else{
                    tipTextView.Text = string.Format("{0:N2}", float.Parse(billTextField.Text) * ((float)slider.Progress / 100)); // int to float, otherwise I'll get 0 anytime
                    totalTextView.Text = string.Format("{0:N2}", (float.Parse(tipTextView.Text) + float.Parse(billTextField.Text)));
                }
            };

            slider.ProgressChanged +=(object sender, SeekBar.ProgressChangedEventArgs e) =>
            {
                int percentage = slider.Progress;
                sliderTextView.Text = string.Format("{0}%", percentage);

                if (string.IsNullOrEmpty(billTextField.Text))
                {
                    tipTextView.Text = "0.00";
                    totalTextView.Text = "0.00";
                }
                else
                {
                    float tip = (float.Parse(billTextField.Text) * (slider.Progress)) / 100;
                    tipTextView.Text = string.Format("{0:N2}", tip);

                    float total = float.Parse(billTextField.Text) + float.Parse(tipTextView.Text);
                    totalTextView.Text = string.Format("{0:N2}", total);
                }
                           
            };
        }
    }
}

