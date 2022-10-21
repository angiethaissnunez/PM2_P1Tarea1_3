using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2_P1Tarea1_3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listemple.ItemsSource = await App.DatabasePerson.ListaPersonas();
        }

        private async void tooladd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());

        }

        private async void listemple_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Models.Persona person = (Models.Persona)e.CurrentSelection.FirstOrDefault();

            Modificar pag = new Modificar();
            pag.BindingContext =person;
            await Navigation.PushAsync(pag);
        }
    }
}