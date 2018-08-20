// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace tipcalculator.iOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        UIKit.UIButton Button { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField billTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISlider slider { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel sliderPercentage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel tipLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel totalLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (billTextField != null) {
                billTextField.Dispose ();
                billTextField = null;
            }

            if (slider != null) {
                slider.Dispose ();
                slider = null;
            }

            if (sliderPercentage != null) {
                sliderPercentage.Dispose ();
                sliderPercentage = null;
            }

            if (tipLabel != null) {
                tipLabel.Dispose ();
                tipLabel = null;
            }

            if (totalLabel != null) {
                totalLabel.Dispose ();
                totalLabel = null;
            }
        }
    }
}