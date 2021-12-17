using Examen_ErickBarahona.Models;
using Examen_ErickBarahona.ViewModels;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Examen_ErickBarahona.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPagoView : ContentPage
    {
        public AddPagoView()
        {
            InitializeComponent();
            this.BindingContext = new PagoViewModel();
            dtfecha.Date = DateTime.Now;
        }

        private void Btnver_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new ListPagoView());
            
        }

        private async void btnTomarFoto_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Alerta", "Cámara no disponible", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                //Directory = "Sample",
                //Name = "test.jpg"
                SaveToAlbum = true
            });

            if (file == null)
                return;

            //await DisplayAlert("File Location", file.Path, "OK");

            byte[] fileByte = System.IO.File.ReadAllBytes(file.AlbumPath);

        }
    }
}