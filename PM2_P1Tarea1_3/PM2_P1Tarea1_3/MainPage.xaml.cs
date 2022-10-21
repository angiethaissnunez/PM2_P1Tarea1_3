using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PM2_P1Tarea1_3
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void btnsalvar_Clicked(object sender, EventArgs e)
        {
            var person = new Models.Persona
            {
                Id = Convert.ToInt32(txtid.Text),
                nombre = txtnombre.Text,
                apellidos = txtapellido.Text,
                edad = Int32.Parse(txtedad.Text),
                correo = txtcorreo.Text,
                direccion = txtdireccion.Text
            };

            var result = await App.DatabasePerson.StorePersonas(person); ;

            if (result > 0)
                await DisplayAlert("Empleado Ingresado", "Correctamente", "OK");
            else
                await DisplayAlert("Error", "No Ingresado", "OK");

        }

        
    }
}
