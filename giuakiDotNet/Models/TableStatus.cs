using System;
using System.Collections.Generic;

namespace giuakiDotNet.Models;

public partial class TableStatus
{
    public int StatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<RestaurantTable> RestaurantTables { get; set; } = new List<RestaurantTable>();
}
