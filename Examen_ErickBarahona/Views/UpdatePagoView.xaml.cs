using Examen_ErickBarahona.Models;
using Examen_ErickBarahona.ViewModels;
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
    public partial class UpdatePagoView : ContentPage
    {
        public UpdatePagoView()
        {
            InitializeComponent();
            this.BindingContext = new PagoViewModel();
        }

        private void btnguardar_Clicked(object sender, EventArgs e)
        {
            CRUD c = new CRUD();

            Pagos modelo = new Pagos()
            {
                Descripcion = txtDescripcion.Text,
                Monto = Convert.ToDouble(txtMonto.Text),
                Fecha = dtfecha.Date,
                Id_pago = Convert.ToInt32(txtID.Text)

            };

            if (c.Actualizar(modelo) > 0)
            {
                ((NavigationPage)this.Parent).PushAsync(new ListPagoView());
            }
        }
    }
}