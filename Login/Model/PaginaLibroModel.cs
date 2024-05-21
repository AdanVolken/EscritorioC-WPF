using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Model
{
    internal class PaginaLibroModel
    {
        public static void AgregarNuevoLibro(string nombreLibro, string autor, string genero, LoginBibliotecaDataContext miDataContext)
        {
            Libro nuevoLibro = new Libro();
            nuevoLibro.NombreLibro = nombreLibro;
            nuevoLibro.Autor = autor;
            nuevoLibro.Genero = genero;

            miDataContext.Libro.InsertOnSubmit(nuevoLibro);
            miDataContext.SubmitChanges();

        }

        public static void ActualizarLibro(Libro libro, string nombreLibro ,string autor, string genero, LoginBibliotecaDataContext miDataContext)
        {
            var libroExistente = miDataContext.Libro.FirstOrDefault(c => c.IdLibro == libro.IdLibro);
            if (libroExistente != null)
            {
                libroExistente.NombreLibro = nombreLibro;
                libroExistente.Autor = autor;
                libroExistente.Genero = genero;
                miDataContext.SubmitChanges();
            }
        }

        public static void EliminarLibro( Libro libro, LoginBibliotecaDataContext miDataContext)
        {
            var libroExistente = miDataContext.Libro.FirstOrDefault(c => c.IdLibro == libro.IdLibro);
            if (libroExistente != null)
            {
                miDataContext.Libro.DeleteOnSubmit(libroExistente);
                miDataContext.SubmitChanges();
            }

        }
    }
}
