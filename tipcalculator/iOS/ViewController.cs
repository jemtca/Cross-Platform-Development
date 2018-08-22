using System;

using UIKit;

namespace tipcalculator.iOS
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TipCalculator tc = new TipCalculator();

            // Perform any additional setup after loading the view, typically from a nib.

            billTextField.BecomeFirstResponder();

            // updating tip and total text label when the user type an amount
            billTextField.AddTarget((object sender, EventArgs e) =>
            {
               if (string.IsNullOrEmpty(billTextField.Text))
               {
                    tipLabel.Text = tc.DefaultValues();
                    totalLabel.Text = tc.DefaultValues();
                }
                else
                {
                    tipLabel.Text = tc.CalculatingTip(billTextField.Text, slider.Value);
                    totalLabel.Text = tc.CalculatingTotal(tipLabel.Text, billTextField.Text);
                }
            }, UIControlEvent.EditingChanged);

            // updating tip and total text label when the user make use of the slider
            slider.ValueChanged += (object sender, EventArgs e) =>
            {
                sliderPercentage.Text = tc.ChangingPercentageNumber(slider.Value);

                if (string.IsNullOrEmpty(billTextField.Text))
                {
                    tipLabel.Text = tc.DefaultValues();
                    totalLabel.Text = tc.DefaultValues();
                }
                else{
                    tipLabel.Text = tc.CalculatingTip(billTextField.Text, slider.Value);
                    totalLabel.Text = tc.CalculatingTotal(tipLabel.Text, billTextField.Text); // !
                }

            };
        }
    }
}
