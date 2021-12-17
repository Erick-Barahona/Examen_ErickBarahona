using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Examen_ErickBarahona.Models;
using Xamarin.Forms;

namespace Examen_ErickBarahona.ViewModels
{
    class PagoViewModel:Pagos
    {
        public ICommand Guardar { get; private set; }
        public ICommand Modificar { get; private set; }
        public ICommand Eliminar { get; private set; }
        public ICommand Nuevo { get; private set; }

        public PagoViewModel()
        {
            Nuevo = new Command(() => {

                Descripcion = "";
                Monto = 0.0;
                Fecha = DateTime.Now;
            }
          );


            Guardar = new Command(() => {
                Pagos modelo = new Pagos()
                {
                    Descripcion = Descripcion,
                    Monto = Monto,
                    Fecha = Fecha
                };

                using (var contexto = new CRUD())
                {
                    contexto.Insertar(modelo);
                }
            }
             );
            Modificar = new Command(() => {
                Pagos modelo = new Pagos()
                {
                    Descripcion = Descripcion,
                    Monto = Monto,
                    Fecha = Fecha,
                    Id_pago = Id_pago

                };

                using (var contexto = new CRUD())
                {
                    contexto.Actualizar(modelo);
                }
            }
            );

            Eliminar = new Command(() => {
                Pagos modelo = new Pagos()
                {
                    Id_pago = Id_pago
                };

                using (var contexto = new CRUD())
                {
                    contexto.Eliminar(modelo);
                }
            }

           );


        }
    }
}
