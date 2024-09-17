using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Practica : ContentPage
    {
        public class DatosPersona
        {
            public string Nombre { get; set; }
            public string Telefono { get; set; }
            public string Direccion { get; set; }
        }

        public List<DatosPersona> listaDatos = new List<DatosPersona>();

        public Practica()
        {
            InitializeComponent();
        }

        string nombre;
        string telefono;
        string direccion;
        private void btnGuardarDatos_Clicked(object sender, EventArgs e)
        {
            asignarValoresDeVista();
        }

        private void asignarValoresDeVista()
        {
            nombre = nombreEntry.Text;
            telefono = telefonoEntry.Text;
            direccion = direccionEntry.Text;

            DatosPersona nuevaPersona = new DatosPersona
            {
                Nombre = nombre,
                Telefono = telefono,
                Direccion = direccion
            };

            listaDatos.Add(nuevaPersona);

            // Limpiar los campos de entrada después de agregar los datos a la lista
            nombreEntry.Text = string.Empty;
            telefonoEntry.Text = string.Empty;
            direccionEntry.Text = string.Empty;
        }

        private void btnMostrar_Datos_Clicked(object sender, EventArgs e)
        {
            StringBuilder datosUsuarios = new StringBuilder();

            foreach (var usuario in listaDatos)
            {
                datosUsuarios.AppendLine($"Nombre: {usuario.Nombre}");
                datosUsuarios.AppendLine($"Telefono: {usuario.Telefono}");
                datosUsuarios.AppendLine($"Direccion: {usuario.Direccion}");
                datosUsuarios.AppendLine("-----------------------------");
            }


            lblDatosUsuarios.Text = datosUsuarios.ToString();


        }
    }
}
