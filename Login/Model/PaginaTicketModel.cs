using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Model
{
    internal class PaginaTicketModel
    {
        public static void AgregarTicket( int dni , string nombreLibro, int monto, DateTime fecha, int usuario, LoginBibliotecaDataContext miDataContext)
        {
            //Buscamos al cliente por su dni para guardarlo con el id
            Cliente cliente = miDataContext.Cliente.FirstOrDefault(c => c.DNI == dni);

            //Buscamos al libro por su nombre para sacar su Id
            Libro libro = miDataContext.Libro.FirstOrDefault(l => l.NombreLibro == nombreLibro);


            if (cliente != null && libro != null) 
            {
                Ticket ticket = new Ticket()
                {
                    IdCliente = cliente.IdCliente,
                    IdLibro = libro.IdLibro,
                    Monto = monto,
                    FechaCompra = fecha,
                    IdUsuario = usuario,

                };

                miDataContext.Ticket.InsertOnSubmit(ticket);
                miDataContext.SubmitChanges();
            }

        }

        public static void ActualizarTicket()
        {

        }

        public static void EliminarTicket()
        {
            
        }
    }
}
