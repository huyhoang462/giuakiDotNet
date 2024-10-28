using System;
using System.Collections.Generic;

namespace giuakiDotNet.Models;

public partial class ComboItem
{
    public int ComboItemId { get; set; }

    public int? ComboId { get; set; }

    public int? MenuItemId { get; set; }

    public virtual Combo? Combo { get; set; }

    public virtual MenuItem? MenuItem { get; set; }
}
