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

            // Perform any additional setup after loading the view, typically from a nib.

            billTextField.BecomeFirstResponder();

            // updating tip and total text field when the user type an amount
            billTextField.AddTarget((object sender, EventArgs e) =>
            {
               if (string.IsNullOrEmpty(billTextField.Text))
               {
                    tipLabel.Text = "0.00";
                    totalLabel.Text = "0.00";
                }
                else
                {
                    tipLabel.Text = string.Format("{0:N2}", float.Parse(billTextField.Text) * (slider.Value / 100));
                    totalLabel.Text = string.Format("{0:N2}", (float.Parse(tipLabel.Text) + float.Parse(billTextField.Text)));
                }
            }, UIControlEvent.EditingChanged);

            // updating tip and total text field when the user make use of the slider
            slider.ValueChanged += (object sender, EventArgs e) =>
            {
                int percentage = (int)(slider.Value);
                sliderPercentage.Text = string.Format("{0}%", percentage);

                if (string.IsNullOrEmpty(billTextField.Text))
                {
                    tipLabel.Text = "0.00";
                    totalLabel.Text = "0.00";
                }
                else{
                    float tip = (float.Parse(billTextField.Text) * (int)(slider.Value)) / 100;
                    tipLabel.Text = string.Format("{0:N2}", tip);

                    float total = float.Parse(billTextField.Text) + float.Parse(tipLabel.Text);
                    totalLabel.Text = string.Format("{0:N2}", total);
                }

            };
        }
    }
}
