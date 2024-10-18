using System;
using System.Collections.Generic;

namespace adminV3.smart_displayDB;

public partial class User
{
    public int Iduser { get; set; }

    public string? Nom { get; set; }

    public string? Email { get; set; }

    public string? Statut { get; set; }

    public DateOnly? DateDeNaissance { get; set; }
}
