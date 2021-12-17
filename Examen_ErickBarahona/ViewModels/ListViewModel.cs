using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Examen_ErickBarahona.Models;

namespace Examen_ErickBarahona.ViewModels
{
    class ListViewModel:Pagos
    {
        private ObservableCollection<Pagos> ListaPagos;

        public ListViewModel()
        {

        }

        public ObservableCollection<Pagos> ListaPagos1
        {
            get
            {
                if (ListaPagos == null)
                {
                    ObtenerPagos();
                }

                return ListaPagos;
            }

            set
            {
                ListaPagos = value;
            }
        }

        public void ObtenerPagos()
        {
            using (var contexto = new CRUD())
            {
                ObservableCollection<Pagos> modelo = new ObservableCollection<Pagos>(contexto.Consultar());
                ListaPagos = modelo;
            }



        }

    }
}
