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
    public partial class Calculadora : ContentPage

    {
        private Calculadora calculadora = new Calculadora();

        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Subtract(double a, double b)
        {
            return a - b;
        }

        public double Multiply(double a, double b)
        {
            return a * b;
        }

        public double Divide(double a, double b)
        {
            if (b != 0)
            {
                return a / b;
            }
            else
            {
                // Manejo de división por cero
                return double.NaN; // NaN representa "Not a Number"
            }
        }

        private double currentNumber = 0;
        private string currentOperation = "";
        public Calculadora()
        {
            InitializeComponent();
        }
        private void NumberButton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string number = button.Text;

            if (displayEntry.Text == "0")
            {
                displayEntry.Text = number;
            }
            else
            {
                displayEntry.Text += number;
            }
        }

        // Método para manejar el clic en un botón de operación
        private void OperationButton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string operation = button.Text;

            // Guarda el número actual y la operación actual
            currentNumber = double.Parse(displayEntry.Text);
            currentOperation = operation;

            // Limpia el campo de texto para el próximo número
            displayEntry.Text = "0";
        }

        // Método para manejar el clic en el botón de limpiar (C)
        private void ClearButton_Clicked(object sender, EventArgs e)
        {
            displayEntry.Text = "0";
            currentNumber = 0;
            currentOperation = "";
        }

        // Método para manejar el clic en el botón de igual (=)
        private void EqualsButton_Clicked(object sender, EventArgs e)
        {
            double secondNumber = double.Parse(displayEntry.Text);
            double result = 0;

            // Realiza la operación correspondiente según la operación actual
            switch (currentOperation)
            {
                case "+":
                    result = calculadora.Add(currentNumber, secondNumber);
                    break;
                case "-":
                    result = calculadora.Subtract(currentNumber, secondNumber);
                    break;
                case "*":
                    result = calculadora.Multiply(currentNumber, secondNumber);
                    break;
                case "/":
                    result = calculadora.Divide(currentNumber, secondNumber);
                    break;
                default:
                    break;
            }

            // Muestra el resultado en el campo de texto
            displayEntry.Text = result.ToString();
        }
    }

   
}

