using System;
using System.Collections.Generic;

namespace WpfAppMiBiblioteca.Models;

public partial class Libros
{
    public string Isbn { get; set; } = null!;

    public string Titulo { get; set; } = null!;

    public int Paginas { get; set; }

    public decimal Precio { get; set; }

    public string? FotoPortada { get; set; }

    public bool Descatalogado { get; set; }

    public int AutorId { get; set; }

    public int EditorialId { get; set; }

    public virtual Autores Autor { get; set; } = null!;

    public virtual Editoriales Editorial { get; set; } = null!;
}
