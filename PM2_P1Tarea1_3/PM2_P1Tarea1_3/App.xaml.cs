using PM2_P1Tarea1_3.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2_P1Tarea1_3
{
    public partial class App : Application
    {
        static Controllers.Personas databasePersona;

        public static Controllers.Personas DatabasePerson
        {
            get 
            { 
                if(databasePersona == null)
                {
                    databasePersona =
                        new Controllers.Personas(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Person.db3"));
                }
                return databasePersona; 
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ListPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
