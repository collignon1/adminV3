using System;
using System.Collections.Generic;

namespace adminV3.smart_displayDB;

public partial class Temperature
{
    public int IdTemp { get; set; }

    public string Valeur { get; set; } = null!;

    public DateOnly Date { get; set; }

    public int AfficheurIdcapteur { get; set; }

    public virtual Afficheur AfficheurIdcapteurNavigation { get; set; } = null!;
}
