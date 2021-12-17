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
    public partial class ListPagoView : ContentPage
    {
        public int id = 0;
        public string monto = null;
        public string descripcion = null;
        Pagos obj;
        public ListPagoView()
        {
            InitializeComponent();
            lista.ItemsSource = new ListViewModel().ListaPagos1;
            this.BindingContext = new PagoViewModel();
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            CRUD c = new CRUD();
            Pagos obj = new Pagos()
            {
                Id_pago = id
            };

            if (c.Eliminar(obj) > 0)
            {
               
                lista.ItemsSource = new ListViewModel().ListaPagos1;
            }

        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (Models.Pagos)e.SelectedItem;
            id = item.Id_pago;

            obj = new Pagos
            {
                Id_pago = item.Id_pago,
                monto = Convert.ToDouble(item.Monto),
                descripcion = item.Descripcion,
                fecha = item.Fecha
            };
        }

        private void btnModificar_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new UpdatePagoView());

            var view = new UpdatePagoView();
            view.BindingContext = obj;
            Navigation.PushAsync(view);
        }
    }
}