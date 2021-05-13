using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Double result = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;
        Double MemoryStore = 0;
        


        private void button_click(object sender, EventArgs e)
        {
            if ((textBox_Result.Text == "0") || (isOperationPerformed))
                textBox_Result.Clear();

            isOperationPerformed = false;
            Button button = (Button)sender;

            if (button.Text == ".")
            {
                if (!textBox_Result.Text.Contains("."))
                    textBox_Result.Text = textBox_Result.Text + button.Text;
            }
            else
                textBox_Result.Text = textBox_Result.Text + button.Text;
        }

        private void operation_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (result != 0)
            {
                if (button.Text == "sqrt")
                    textBox_Result.Text = Math.Sqrt(Double.Parse(textBox_Result.Text)).ToString();
                buttonEqual.PerformClick();
                operationPerformed = button.Text;
                labelOperations.Text = result + " " + operationPerformed;
                isOperationPerformed = true;
            }
            else if (button.Text == "sqrt")
            {
                textBox_Result.Text = Math.Sqrt(Double.Parse(textBox_Result.Text)).ToString();
                result = Math.Sqrt(Double.Parse(textBox_Result.Text));
            }
            else
            {
                operationPerformed = button.Text;
                result = double.Parse(textBox_Result.Text);
                labelOperations.Text = result + " " + operationPerformed;
                isOperationPerformed = true;
            }

        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
           
           textBox_Result.Text = "0";
           result = 0;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
            
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            isOperationPerformed = false;

            switch (operationPerformed)
            {
                case "+":
                    textBox_Result.Text = (result + Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "-":
                    textBox_Result.Text = (result - Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "*":
                    textBox_Result.Text = (result * Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "/":
                    textBox_Result.Text = (result/ Double.Parse(textBox_Result.Text)).ToString();
                    break;
                default:
                    break;
            }

            result = Double.Parse(textBox_Result.Text);
            labelOperations.Text = "";
        }
        private void digitCalculate_Click(object sender, EventArgs e)
        {
            Button ButtonThatWasPushed = (Button)sender;
            string ButtonText = ButtonThatWasPushed.Text;

            if (ButtonText == "MC")
            {
                //Memory Clear
                textBox_Result.Text = "0";
                this.MemoryStore = 0;
                return;
            }

            if (ButtonText == "MR")
            {
                //Memory Recall
                textBox_Result.Text = this.MemoryStore.ToString();
                return;
            }
            if (ButtonText == "M-")
            {
                // Memory subtract
                this.MemoryStore -= Double.Parse(textBox_Result.Text);
                return;
            }

            if (ButtonText == "M+")
            {
                // Memory add 

                this.MemoryStore += Double.Parse(textBox_Result.Text);
                return;
            }

            if (ButtonText == "MS")
            {
                MemoryStore = Double.Parse(textBox_Result.Text);
                return;
            }

        }

        private void buttonBackspace_click(object sender, EventArgs e)
        {
            int index = textBox_Result.Text.Length;
            index--;
            textBox_Result.Text = textBox_Result.Text.Remove(index);
            if (textBox_Result.Text== "")
            {
                textBox_Result.Text = "0";
            }
        }

        private void buttonPlusMinus_click(object sender, EventArgs e)
        {
            result = double.Parse(textBox_Result.Text);
            result = result * -1;
            textBox_Result.Text = result.ToString();
        }

        private void buttonPercentage_click(object sender, EventArgs e)
        {
            result = double.Parse(textBox_Result.Text);
            result = result / 100;
            textBox_Result.Text = result.ToString();
        }

        private void sqrt_click(object sender, EventArgs e)
        {

        }
    }
}
