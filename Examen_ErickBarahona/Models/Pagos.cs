using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Examen_ErickBarahona.Models
{
    public class Pagos
    {      
        // public Byte[] photo_recibo;
        public int id_pago;
        public string descripcion;
        public double monto;
        public DateTime fecha;


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propiedad)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
            }
        }

        [PrimaryKey, AutoIncrement]
        public int Id_pago
        {
            get
            {
                return id_pago;
            }

            set
            {
                if (id_pago != value)
                {
                    id_pago = value;
                    OnPropertyChanged("id_pago");
                }

            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                if (descripcion != value)
                {
                    descripcion = value;
                    OnPropertyChanged("descripcion");
                }
            }
        }


        public double Monto
        {
            get
            {
                return monto;
            }

            set
            {
                if (monto != value)
                {
                    monto = value;
                    OnPropertyChanged("monto");
                }
            }
        }

        public DateTime Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                if (fecha != value)
                {
                    fecha = value;
                    OnPropertyChanged("fecha");
                }
            }
        }


    }
}
