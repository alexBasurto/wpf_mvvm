using System;
using System.Collections.Generic;

namespace WpfAppMiBiblioteca.Models;

public partial class Editoriales
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Libros> Libros { get; set; } = new List<Libros>();
}
