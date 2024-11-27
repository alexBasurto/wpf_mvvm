using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppMiBiblioteca.Models;

namespace WpfAppMiBiblioteca.Services
{
    class DAL
    {
        private readonly MiBibliotecaContext _context;

        public DAL(MiBibliotecaContext context)
        {
            _context = context;
        }

        #region "Autores"
        public async Task<List<Autores>> ObtenerAutores()
        {
            List<Autores> autores = new List<Autores>();
            try
            {
                autores = await _context.Autores.Include(a => a.Libros).ToListAsync();
                return autores;
            }
            catch (Exception ex)
            {
                // Escribir un log. Pendiente.
                return autores;
            }
        }

        public async Task<Autores?> ObtenerAutor(int idAutor)
        {
            Autores? autor = new Autores();
            try
            {
                autor = await _context.Autores.Where(a => a.Id == idAutor).FirstOrDefaultAsync();
                return autor;
            }
            catch (Exception ex)
            {
                // Escribir un log. Pte.
                return autor;
            }
        }

        #endregion

        #region "Editoriales"

        #endregion

        #region "Libros"

        #endregion

        #region "Operaciones"

        #endregion

        #region "Usuarios"

        #endregion

    }
}
