using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;
using static Xamarin.Essentials.AppleSignInAuthenticator;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Deber : ContentPage
	{

        string nombre;
        string apellido;
        string telefono;
        string correo;
        TimeSpan horaTimeSpan;
        DateTime fechaDt;
        
        string tipoDocumento;
        string resenia;
        bool chkMasc;
        bool chkFem;

        string ci;
        string ruc;
        string edadResult;

        int edadCalculada;


        public Deber ()
		{
			InitializeComponent ();
            
        }

        private void btnGuarda_Clicked(object sender, EventArgs e)
        {
            asignarValoresDeVista();

            //calcula edad
            edadCalculada = calcularEdad(fechaDt);
        }

        private void asignarValoresDeVista()
        {
            // asignar valores de la vista a las variables del controlador
            nombre = nombreEntry.Text;
            apellido = apellidoEntry.Text;
            telefono = telefonoEntry.Text;
            correo = correoEntry.Text;
            horaTimeSpan = horaTimePick.Time;
            fechaDt = fechaNacDP.Date;
           
            resenia = reseniaEditor.Text;
            chkMasc = chkMasculino.IsChecked;
            chkFem = chkFemenino.IsChecked;
        }

        private int calcularEdad(DateTime fechaNacimiento)
        {
            // Obtiene la fecha actual:
            DateTime fechaActual = DateTime.Today;

            // Comprueba que la se haya introducido una fecha válida; si 
            // la fecha de nacimiento es mayor a la fecha actual se muestra mensaje 
            // de advertencia:
            if (fechaNacimiento > fechaActual)
            {
                Console.WriteLine("La fecha de nacimiento es mayor que la actual.");
                return -1;
            }
            else
            {
                int edad = fechaActual.Year - fechaNacimiento.Year;

                // Comprueba que el mes de la fecha de nacimiento es mayor 
                // que el mes de la fecha actual:
                if (fechaNacimiento.Month > fechaActual.Month)
                {
                    --edad;
                }

                return edad;
            }
        }


        private void tipoDocumentoPicker_SelectIndCha(object sender, EventArgs e)
        {
            tipoDocumento = tipoDocumentoPicker.SelectedItem.ToString();
            mostrarCedulaORuc();
        }

        private void mostrarCedulaORuc()
        {
            string opcion1 = "Cédula";


            if (tipoDocumento == opcion1)
            {
                ciEntry.IsVisible = true;
                rucEntry.IsVisible = false;
            }
            else
            {
                ciEntry.IsVisible = false;
                rucEntry.IsVisible = true;
            }

        }

        private void btnMostrar_Clicked(object sender, EventArgs e)
        {
            

            lbl_1.Text = $"Nombre: {nombre}";
            lbl_2.Text = $"Apellido: {apellido}";
            lbl_3.Text = $"Telefono: {telefono}";
            lbl_4.Text = $"Correo Electronico: {correo}";
            lbl_5.Text = $"La hora: {horaTimeSpan}";
            lbl_6.Text = $"Su fecha de naciemiento es: {fechaDt} y " + $"Su edad es: {edadCalculada} años";
            
            string valorTipoDcument = "";
            if (ciEntry.IsVisible)
            {
                valorTipoDcument = ciEntry.Text;
            }
            else
            {
                valorTipoDcument = rucEntry.Text;
            }
            lbl_7.Text = $"Tipo de documento: {tipoDocumento} = {valorTipoDcument}";

            string valorTipoGenero = "";
            if (chkMasc)
            {
                valorTipoGenero = "Masculino";
            }
            else{
                valorTipoGenero = "Femenino";
            }

            lbl_8.Text = $"Tipo de genero: {valorTipoGenero}";

            lbl_9.Text = $"Reseña: {resenia}";

        }

    }
}