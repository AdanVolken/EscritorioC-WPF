using System;
using System.Collections.Generic;
using System.Data.Linq;
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
    /// Lógica de interacción para PaginaLibro.xaml
    /// </summary>
    public partial class PaginaLibro : Page
    {
        private LoginBibliotecaDataContext miDataContext;
        public PaginaLibro(LoginBibliotecaDataContext miDataContext)
        {
            InitializeComponent();
            this.miDataContext = miDataContext;

            ActualizarListaLibro();
        }


        // Actualiza la lista de Libros
        private void ActualizarListaLibro()
        {
            miDataContext.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, miDataContext.Libro);
            lsbLibro.ItemsSource = miDataContext.Libro.ToList();
        }

        // Limpiar los textbox
        private void LimpiarTextBoxes()
        {
            txtNombreLibro.Text = string.Empty;
            txtAutor.Text = string.Empty;
            txtGenero.Text = string.Empty;

        }
        private void btnBuscarLibro_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAgregarLibro_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nombreLibro = txtNombreLibro.Text;
                string autor = txtAutor.Text;
                string genero = txtGenero.Text;

                PaginaLibroModel.AgregarNuevoLibro(nombreLibro, autor, genero, miDataContext);

                ActualizarListaLibro();
                LimpiarTextBoxes();

            }catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminarLibro_Click(object sender, RoutedEventArgs e)
        {
            if (lsbLibro.SelectedItem is Libro libroSeleccionado)
            {
                PaginaLibroModel.EliminarLibro(libroSeleccionado, miDataContext);
                ActualizarListaLibro();
                LimpiarTextBoxes();
            }

        }

        private void btnActualizarLibro_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lsbLibro.SelectedItem is Libro seleccionarLibro) 
                {
                    string nombre = txtNombreLibro.Text;
                    string autor = txtAutor.Text;
                    string genero = txtGenero.Text;

                    PaginaLibroModel.ActualizarLibro(seleccionarLibro, nombre, autor, genero, miDataContext);

                    ActualizarListaLibro();
                    LimpiarTextBoxes();
                }

            } catch(Exception ex)
            { 
                MessageBox.Show(ex.Message);
            }

        }

        private void lsbLibro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lsbLibro.SelectedItem is Libro selecionarLibro)
            {
                txtNombreLibro.Text = selecionarLibro.NombreLibro;
                txtAutor.Text = selecionarLibro.Autor;
                txtGenero.Text = selecionarLibro.Genero;
            }
        }
    }
}
