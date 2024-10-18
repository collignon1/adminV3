using System;
using System.Collections.Generic;

namespace adminV3.smart_displayDB;

public partial class DateImportante
{
    public int IddateImportante { get; set; }

    public DateOnly? Date { get; set; }

    public string? Info { get; set; }

    public string Type { get; set; } = null!;
}
