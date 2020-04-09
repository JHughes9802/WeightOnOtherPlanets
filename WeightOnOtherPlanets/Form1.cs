using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeightOnOtherPlanets
{
    public partial class Form1 : Form
    {
        SortedList<String, Double> WeightConversionFactors = new SortedList<string, double>();

        public Form1()
        {
            InitializeComponent();

            WeightConversionFactors.Add("Mercury", 0.3772);
            WeightConversionFactors.Add("Venus", 0.9042);
            WeightConversionFactors.Add("Mars", 0.3783);
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (isValid(txtEarthWeight.Text, out string exceptionMessage))
            {
                double earthWeight = Convert.ToDouble(txtEarthWeight.Text);

                double mercuryWeight = earthWeight * WeightConversionFactors["Mercury"];
                txtMercuryWeight.Text = mercuryWeight.ToString();

                double venusWeight = earthWeight * WeightConversionFactors["Venus"];
                txtVenusWeight.Text = venusWeight.ToString();

                double marsWeight = earthWeight * WeightConversionFactors["Mars"];
                txtMarsWeight.Text = marsWeight.ToString();
            }
            else
            {
                MessageBox.Show(exceptionMessage, "Error");
                txtEarthWeight.Focus();
            }
        }

        private bool isValid(string textEarthWeight, out string error)
        {
            error = null;
            double numberEarthWeight = 0;

            if (String.IsNullOrWhiteSpace(textEarthWeight))
            {
                error = "Please enter a weight";
                return false;
            }

            try
            {
                numberEarthWeight = Convert.ToDouble(textEarthWeight);
            }

            catch (FormatException)
            {
                error = "Please enter only numbers";
                return false;
            }

            catch (OverflowException)
            {
                error = "Please enter a smaller number";
                return false;
            }

            if (numberEarthWeight < 0)
            {
                error = "Please enter a positive number";
                return false;
            }

            return true;
        }
    }
}
