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
    public partial class Controles : ContentPage
    {
        public Controles()
        {
            InitializeComponent();
        }
        private void GuardarControles_clicked(object sender, EventArgs e)
        {
            TimeSpan h = hora.Time;
            DateTime f = fecha.Date;
            bool ch = check.IsChecked;
            String ct= edit.Text;
            String selector = picker.SelectedItem.ToString();

            lblResultado.Text = $"la hora es:{h}"
                + $" la fecha es: {f},"
                + $",esta chekeado: {ch}"
                + $", el texto es: {ct}"
                + $", la opcion seleccionada es: {selector}";

        }
    }
}