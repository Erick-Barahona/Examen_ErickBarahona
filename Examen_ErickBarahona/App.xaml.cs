using Examen_ErickBarahona.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Examen_ErickBarahona
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new AddPagoView());

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
