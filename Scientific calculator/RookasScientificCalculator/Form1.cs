using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_ScientificCalculator
{
    public partial class Form1 : Form
    {
        Double results = 0;
        String operation = "";
        bool enter_value = false;
        float fCelsius, fFahrenheit, fKelvin;
        char tempOperation;
        int sk = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void standardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // apsirasom kokio dydzio bus standart
            this.Width = 360;
            this.Height = 580;
            txtDisplay.Width = 315;
        }

        private void scientificToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // apsirasom kokio dydzio bus scientific
            this.Width = 720;
            this.Height = 580;
            txtDisplay.Width = 675;
        }

        private void temperatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // apsirasom kokio dydzio bus temperature
            this.Width = 1190;
            this.Height = 580;
            txtDisplay.Width = 675;
        }


        private void button_Click(object sender, EventArgs e)
        {
            // tiktina kas yra textDisplay
            if ((txtDisplay.Text == "0")|| (enter_value))
            {
                txtDisplay.Text = "";
            }
            enter_value = false;
            Button num = (Button)sender;// Say you have multiple buttons on a form. These buttons could contain a Tag describing what clicking them should do.You could handle all the Click events with the same handler, and depending on the sender do something different
            if (num.Text == ".")
            {
                if (!txtDisplay.Text.Contains("."))
                {
                    txtDisplay.Text = txtDisplay.Text + num.Text;
                }
            }
            else
            {
                txtDisplay.Text = txtDisplay.Text + num.Text;
            }
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            lblShowOp.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 360;
            this.Height = 580;
            txtDisplay.Width = 315;
            
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            lblShowOp.Text = "";
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text.Length > 0)
            {
                txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1, 1);
            }
            if (txtDisplay.Text == "")
            {
                txtDisplay.Text = "0";
            }
        }

        private void Arithmetic_Operator(object sender, EventArgs e)
        {
            Button num = (Button)sender;
            operation = num.Text;
            results = Double.Parse(txtDisplay.Text);//Converts the string representation of a number in a specified style and culture-specific format to its double-precision floating-point number equivalent.
            txtDisplay.Text = "";
            lblShowOp.Text = System.Convert.ToString(results) + " " + operation;
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            lblShowOp.Text = "";
            switch (operation) {
                case "+":
                    txtDisplay.Text = (results + Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "-":
                    txtDisplay.Text = (results - Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "*":
                    txtDisplay.Text = (results * Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "/":
                    txtDisplay.Text = (results / Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "Mod":
                    txtDisplay.Text = (results % Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "Exp":
                    double i = Double.Parse(txtDisplay.Text);
                    double q;
                    q = (results);
                    txtDisplay.Text = Math.Exp(i * Math.Log(q * 4)).ToString();
                    break;

            }
        }

        private void btnPi_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "3.1415926535899";
        }


        private void btnSqrt_Click(object sender, EventArgs e)
        {

            // saknis
            double value = Double.Parse(txtDisplay.Text);
            lblShowOp.Text = System.Convert.ToString("Sqrt" + "(" + (txtDisplay.Text) + ")");
            value = Math.Sqrt(value);
            txtDisplay.Text = System.Convert.ToString(value);
        }

        private void btnSin_Click(object sender, EventArgs e)
        {
            //is laipsniu sinusas
            double value = Double.Parse(txtDisplay.Text);
            lblShowOp.Text = System.Convert.ToString("Sin" + "(" + (txtDisplay.Text) + ")");
            value = Math.Sin(value);
            txtDisplay.Text = System.Convert.ToString(value);
        }



        private void btnCos_Click(object sender, EventArgs e)
        {
            // is laipsniu cosinusas
            double value = Double.Parse(txtDisplay.Text);
            lblShowOp.Text = System.Convert.ToString("Cos" + "(" + (txtDisplay.Text) + ")");
            value = Math.Cos(value);
            txtDisplay.Text = System.Convert.ToString(value);
        }

        private void btnTan_Click(object sender, EventArgs e)
        {
            //is laipsniu i tangenta
            double value = Double.Parse(txtDisplay.Text);
            lblShowOp.Text = System.Convert.ToString("Tan" + "(" + (txtDisplay.Text) + ")");
            value = Math.Tan(value);
            txtDisplay.Text = System.Convert.ToString(value);
        }

        private void btnBin_Click(object sender, EventArgs e)
        {
            int value = int.Parse(txtDisplay.Text);
            txtDisplay.Text = System.Convert.ToString(value, 2);
        }

        private void btnHex_Click(object sender, EventArgs e)
        {
            int value = int.Parse(txtDisplay.Text);
            txtDisplay.Text = System.Convert.ToString(value, 16);
        }

     

        private void btnSquared_Click(object sender, EventArgs e)
        {
            double value = double.Parse(txtDisplay.Text);
            value *= value;
            txtDisplay.Text = System.Convert.ToString(value);
        }

        private void btnCubed_Click(object sender, EventArgs e)
        {
            double value = double.Parse(txtDisplay.Text);
            value = value * value* value;
            txtDisplay.Text = System.Convert.ToString(value);
        }

      

        private void rbCtoF_CheckedChanged(object sender, EventArgs e)
        {
            tempOperation = 'F';
        }

        private void rbFtoC_CheckedChanged(object sender, EventArgs e)
        {
            tempOperation = 'C';
        }

        private void rbKelvin_CheckedChanged(object sender, EventArgs e)
        {
            tempOperation = 'K';
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            switch (tempOperation)
            {
                case 'F':
                    //Celsius to Fahrenheit
                    fCelsius = float.Parse(txtTemperature.Text);
                    lblConvertResult.Text = ((((9 * fCelsius) / 5) + 32).ToString());
                    break;
                case 'C':
                    //Fahrenheit to Celsius
                    fFahrenheit = float.Parse(txtTemperature.Text);
                    lblConvertResult.Text = ((((fFahrenheit - 32) * 5) / 9).ToString());
                    break;
                case 'K':
                    //Convert Fahrenheit to Kelvin
                    fKelvin = float.Parse(txtTemperature.Text);
                    lblConvertResult.Text = (((((9 * fKelvin) / 5) + 32) + 273.15).ToString());
                    break;

            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lblConvertResult.Text = "          ";
            txtTemperature.Clear();
            rbCtoF.Checked = false;
            rbFtoC.Checked = false;
            rbKelvin.Checked = false;
        }

      

        private void btnPercent_Click(object sender, EventArgs e)
        {
            //%
            double value = double.Parse(txtDisplay.Text);
            value = value / 100;
            txtDisplay.Text = System.Convert.ToString(value);
        }
    }
}
