using System;
using System.Collections.Generic;

namespace adminV3.smart_displayDB;

public partial class Afficheur
{
    public int Idcapteur { get; set; }

    public int SalleIdsalle { get; set; }

    public DateOnly? DateInstall { get; set; }

    public virtual ICollection<Co2> Co2s { get; set; } = new List<Co2>();

    public virtual ICollection<Luminosite> Luminosites { get; set; } = new List<Luminosite>();

    public virtual Salle SalleIdsalleNavigation { get; set; } = null!;

    public virtual ICollection<Temperature> Temperatures { get; set; } = new List<Temperature>();
}
