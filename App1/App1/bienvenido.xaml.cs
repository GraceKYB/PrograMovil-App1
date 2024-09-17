using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class bienvenido : ContentPage
    {
        public bienvenido()
        {
            InitializeComponent();
        }

        string currentInput = "";
        bool resultDisplayed = false;


        private void OnSelectNumber(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (resultDisplayed)  // Si el resultado está mostrado y el usuario presiona un número
            {
                currentInput = "";  // Comienza una nueva operación
                resultDisplayed = false;
            }
            currentInput += button.Text;
            operationDisplay.Text = currentInput;
        }

        private void OnSelectOperator(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (resultDisplayed)
            {
                // Continúa desde el resultado
                currentInput = resultDisplay.Text;
                resultDisplayed = false;
            }
            if (!currentInput.EndsWith(" "))
            {
                currentInput += " " + button.Text + " ";
                operationDisplay.Text = currentInput;
            }
        }

        private void OnCalculate(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(currentInput))
                {
                    var result = new System.Data.DataTable().Compute(currentInput, null).ToString();
                    resultDisplay.Text = result;
                    operationDisplay.Text = currentInput + " = " + result;
                    currentInput = result;  // Guarda el resultado como la entrada actual
                    resultDisplayed = true;  // Marca que el resultado ha sido mostrado
                }
            }
            catch (Exception)
            {
                resultDisplay.Text = "Error";
                currentInput = "";
                resultDisplayed = false;
            }
        }

        private void OnClear(object sender, EventArgs e)
        {
            currentInput = "";
            operationDisplay.Text = "0";
            resultDisplay.Text = "0";
            resultDisplayed = false;
        }
    }
}
