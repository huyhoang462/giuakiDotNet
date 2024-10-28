using System;
using System.Collections.Generic;

namespace giuakiDotNet.Models;

public partial class Combo
{
    public int ComboId { get; set; }

    public string? Image { get; set; }

    public string ComboName { get; set; } = null!;

    public decimal ComboPrice { get; set; }

    public virtual ICollection<ComboItem> ComboItems { get; set; } = new List<ComboItem>();
}
