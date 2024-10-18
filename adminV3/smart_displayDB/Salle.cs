using System;
using System.Collections.Generic;

namespace adminV3.smart_displayDB;

public partial class Salle
{
    public int Idsalle { get; set; }

    public string? NumeroSalle { get; set; }

    public int BatimentIdbatiment { get; set; }

    public virtual ICollection<Afficheur> Afficheurs { get; set; } = new List<Afficheur>();

    public virtual Batiment BatimentIdbatimentNavigation { get; set; } = null!;
}
