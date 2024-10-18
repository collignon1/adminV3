using System;
using System.Collections.Generic;

namespace adminV3.smart_displayDB;

public partial class Batiment
{
    public int Idbatiment { get; set; }

    public string? Nom { get; set; }

    public virtual ICollection<Salle> Salles { get; set; } = new List<Salle>();
}
