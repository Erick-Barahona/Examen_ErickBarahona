using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using System.IO;
using Examen_ErickBarahona.Models;


namespace Examen_ErickBarahona
{
    public class CRUD : IDisposable
    {
        private SQLiteConnection con;

        public CRUD()
        {
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string dbPath = Path.Combine(folderPath, "pago.db3");
            con = new SQLiteConnection(dbPath,true);
            con.CreateTable<Pagos>();

        }

        public void Dispose()
        {
            con.Dispose();
        }

        public void Insertar(Pagos modelo)
        {
            con.Insert(modelo);
            if (con.IsInTransaction)
            {
                Console.WriteLine("ok");
            }
        }
        public int Actualizar(Pagos modelo)
        {
           return con.Update(modelo);
        }
        public int Eliminar(Pagos modelo)
        {
             return con.Delete(modelo);

        }
        public Pagos Consultar(int id)
        {
            return con.Table<Pagos>().FirstOrDefault(p => p.Id_pago == id);
        }

        public List<Pagos> Consultar()
        {
            return con.Table<Pagos>().OrderByDescending(xx => xx.Id_pago).ToList();
        }
    }
}
