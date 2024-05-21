using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Login.Model
{
    internal class PaginaClienteModel
    {
        public static void AgregarNuevoCliente(string nombre, string apellido, string correo , int telefono, int dni , LoginBibliotecaDataContext miDataContext)
        {
            try
            {
                Cliente nuevoCliente = new Cliente();
                nuevoCliente.Nombre = nombre;
                nuevoCliente.Apellido = apellido;
                nuevoCliente.Telefono = telefono;
                nuevoCliente.Correo = correo;
                nuevoCliente.DNI = dni;
                miDataContext.Cliente.InsertOnSubmit(nuevoCliente);
                miDataContext.SubmitChanges();
            }
            catch 
            {
                MessageBox.Show("Datos Ingresados no son correctos");
            }

        }

        public static void ActualizarCliente(Cliente cliente, string nombre, string apellido, string telefono, string correo, string dni, LoginBibliotecaDataContext miDataContext)
        {
            var clienteExistente = miDataContext.Cliente.FirstOrDefault(c => c.IdCliente == cliente.IdCliente);
            if (clienteExistente != null)
            {
                clienteExistente.Nombre = nombre;
                clienteExistente.Apellido = apellido;
                clienteExistente.Telefono = int.Parse(telefono);
                clienteExistente.Correo = correo;
                clienteExistente.DNI = int.Parse(dni);
                miDataContext.SubmitChanges();
            }
        }

        public static void EliminarCliente(Cliente cliente, LoginBibliotecaDataContext miDataContext)
        {
            var clienteExistente = miDataContext.Cliente.FirstOrDefault(c => c.IdCliente == cliente.IdCliente);
            if (clienteExistente != null)
            {
                miDataContext.Cliente.DeleteOnSubmit(clienteExistente);
                miDataContext.SubmitChanges();
            }

        }
    }


}
