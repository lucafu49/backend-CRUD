using System;
using System.Collections.Generic;

namespace backend_CRUD.Models;

public partial class Tarea
{
    public int IdTarea { get; set; }

    public string Nombre { get; set; } = null!;
}
