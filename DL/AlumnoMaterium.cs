using System;
using System.Collections.Generic;

namespace DL;

public partial class AlumnoMaterium
{
    public int IdAlumnoMateria { get; set; }

    public int? IdAlumno { get; set; }

    public int? IdMateria { get; set; }

    public virtual Alumno? IdAlumnoNavigation { get; set; }

    public virtual Materium? IdMateriaNavigation { get; set; }

    public string Nombre { get; set; }

    public decimal Costo { get; set; }
}
