using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Login.Model;

namespace Login.View
{
    /// <summary>
    /// Lógica de interacción para PaginaCliente.xaml
    /// </summary>
    public partial class PaginaCliente : Page
    {
        private LoginBibliotecaDataContext miDataContext;
        public PaginaCliente(LoginBibliotecaDataContext miDataContext)
        {
            InitializeComponent();
            this.miDataContext = miDataContext;

            ActualizarListaClientes();
        }

        // Actualizar la lista de clientes
        private void ActualizarListaClientes()
        {
            miDataContext.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, miDataContext.Cliente);
            lsbClientes.ItemsSource = miDataContext.Cliente.ToList();
        }

        // Limpiar los textbox
        private void LimpiarTextBoxes()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtDni.Text = string.Empty;
        }

        private void btnBuscarCliente_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAgregarCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                int telefono = int.Parse(txtTelefono.Text);
                string correo = txtCorreo.Text;
                int dni = int.Parse(txtDni.Text);

                PaginaClienteModel.AgregarNuevoCliente(nombre, apellido, correo, telefono, dni, miDataContext);

                // Forzar la actualización de la lista de clientes
                ActualizarListaClientes();

                // Limpiar los TextBox
                LimpiarTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar cliente: {ex.Message}");
            }
        }

        private void btnActualizarCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lsbClientes.SelectedItem is Cliente selectedCliente)
                {
                    string nombre = txtNombre.Text;
                    string apellido = txtApellido.Text;
                    string telefono = txtTelefono.Text;
                    string correo = txtCorreo.Text;
                    string dni = txtDni.Text;

                    PaginaClienteModel.ActualizarCliente(selectedCliente, nombre, apellido, telefono, correo, dni, miDataContext);

                    // Forzar la actualización de la lista de clientes
                    ActualizarListaClientes();

                    // Limpiar los TextBox
                    LimpiarTextBoxes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar cliente: {ex.Message}");
            }
        }

        private void btnEliminarCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lsbClientes.SelectedItem is Cliente selectedCliente)
                {
                    PaginaClienteModel.EliminarCliente(selectedCliente, miDataContext);
                    ActualizarListaClientes();
                    LimpiarTextBoxes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar cliente: {ex.Message}");
            }
        }


        // Metodo para pasar los datos del cliente seleccionado a los texbox de la derecha para editarla
        private void lsbClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lsbClientes.SelectedItem is Cliente selectedCliente)
            {
                txtNombre.Text = selectedCliente.Nombre;
                txtApellido.Text = selectedCliente.Apellido;
                txtTelefono.Text = selectedCliente.Telefono.ToString() ?? string.Empty; // se agrega el ?? por si el dato de la columna es null.
                txtCorreo.Text = selectedCliente.Correo;
                txtDni.Text = selectedCliente.DNI.ToString() ?? string.Empty;
            }
        }
    }
}
