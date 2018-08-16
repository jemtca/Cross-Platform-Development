using System;
using Foundation;
using UIKit;

namespace phoneword.iOS
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            string translatedNumber = "";

            // Perform any additional setup after loading the view, typically from a nib.
            TranslateButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                // Convert the phone number with text to a number
                // using PhoneTranslator.cs
                translatedNumber = PhonewordTranslator.ToNumber(PhoneNumberText.Text);

                // Dismiss the keyboard if text field was tapped
                PhoneNumberText.ResignFirstResponder();

                if (translatedNumber == "")
                {
                    CallButton.SetTitle("Call ", UIControlState.Normal);
                    CallButton.Enabled = false;
                }
                else
                {
                    CallButton.SetTitle("Call " + translatedNumber, UIControlState.Normal);
                    CallButton.Enabled = true;
                }
            };

            CallButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                // Use URL handler with tel: prefic to invoke Apple's phone app...
                var url = new NSUrl("tel:" + translatedNumber);

                // otherwise shows an alert dialog
                if (!UIApplication.SharedApplication.OpenUrl(url)) {
                    var alert = UIAlertController.Create("Not supported", "Scheme 'tel': is not supported on this device", UIAlertControllerStyle.Alert);
                    alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
                    PresentViewController(alert, true, null);
                }
            };

        }
    }
}
