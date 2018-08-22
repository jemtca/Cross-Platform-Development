using System;

namespace tipcalculator
{
    public class TipCalculator
    {
        const string zeros = "0.00";

        public string DefaultValues ()
        {
            return zeros;
        }

        public string ChangingPercentageNumber(float sliderValue)
        {
            return string.Format("{0}%", (int)(sliderValue));
        }

        public string CalculatingTip (string bill, float percentage)
        {
            return string.Format("{0:N2}", (float.Parse(bill) * (int)(percentage)) / 100);
        }

        public string CalculatingTotal(string tip, string bill)
        {
            return string.Format("{0:N2}", float.Parse(tip) + float.Parse(bill));
        }
    }
}
