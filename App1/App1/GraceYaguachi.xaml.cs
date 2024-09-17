using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GraceYaguachi : ContentPage
    {
        List<Contacto> contactos = new List<Contacto>();

        public GraceYaguachi()
        {
            InitializeComponent();
        }

        public class Contacto
        {
            public string Nombre { get; set; }
            public string Empresa { get; set; }
            public string Telefono { get; set; }
        }

        List<Contacto> contactos1 = new List<Contacto>();

        private void Guardar_Clicked(object sender, EventArgs e)
        {
            string nombre = nombreEntry.Text;
            string empresa = empresaEntry.Text;
            string telefono = telefonoEntry.Text;

            contactos.Add(new Contacto { Nombre = nombre, Empresa = empresa, Telefono = telefono });

            nombreEntry.Text = "";
            empresaEntry.Text = "";
            telefonoEntry.Text = "";

            MostrarContactos(); // Llamar al método para mostrar los contactos después de guardar uno nuevo
        }
        private void BusquedaEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            string busqueda = e.NewTextValue.ToLower(); // Convertir la búsqueda a minúsculas para una comparación sin distinción entre mayúsculas y minúsculas

            var resultados = contactos.Where(c =>
                c.Nombre.ToLower().Contains(busqueda) || // Buscar por nombre
                c.Telefono.Contains(busqueda) // Buscar por teléfono (no es necesario convertir a minúsculas)
            ).ToList();

            listaNombres.ItemsSource = resultados;
        }


        private void MostrarContactos()
        {
            listaNombres.ItemsSource = null;
            listaNombres.ItemsSource = contactos;
        }

        private void ListaNombres_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var contactoSeleccionado = (Contacto)e.SelectedItem;
                DisplayAlert("Detalles", $"Nombre: {contactoSeleccionado.Nombre}\nEmpresa: {contactoSeleccionado.Empresa}\nTeléfono: {contactoSeleccionado.Telefono}", "OK");
                ((ListView)sender).SelectedItem = null;
            }
        }

        private void Buscar_Clicked(object sender, EventArgs e)
        {
            string busqueda = busquedaEntry.Text.ToLower(); // Convertir la búsqueda a minúsculas para una comparación sin distinción entre mayúsculas y minúsculas

            var resultados = contactos.Where(c =>
                c.Nombre.ToLower().Contains(busqueda) || // Buscar por nombre
                c.Telefono.Contains(busqueda) // Buscar por teléfono (no es necesario convertir a minúsculas)
            ).ToList();

            listaNombres.ItemsSource = resultados;
        }

        private void Btn_lista_Clicked(object sender, EventArgs e)
        {
            
                // Obtener los datos de las Entry
                string nombre = nombreEntry.Text;
                string empresa = empresaEntry.Text;
                string telefono = telefonoEntry.Text;

                // Crear un nuevo formulario para mostrar los datos
                var nuevoFormulario = new ContentPage();

                // Crear un StackLayout para organizar los elementos
                var stackLayout = new StackLayout();

                // Agregar etiquetas y entradas para mostrar los datos
                stackLayout.Children.Add(new Label { Text = "Nombre: " + nombre });
                stackLayout.Children.Add(new Label { Text = "Empresa: " + empresa });
                stackLayout.Children.Add(new Label { Text = "Teléfono: " + telefono });

                // Agregar el StackLayout al formulario
                nuevoFormulario.Content = stackLayout;

                // Mostrar el nuevo formulario
                Navigation.PushAsync(nuevoFormulario);
            }

        private void agregar_Clicked(object sender, EventArgs e)
        {

        }
    }
        
    }
