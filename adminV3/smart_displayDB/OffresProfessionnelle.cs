using System;
using System.Collections.Generic;

namespace adminV3.smart_displayDB;

public partial class OffresProfessionnelle
{
    public int IdoffresProfessionnelles { get; set; }

    public string? Entreprise { get; set; }

    public DateOnly? DatePoste { get; set; }
}
