using System;
using System.Collections.Generic;

namespace giuakiDotNet.Models;

public partial class SubCategory
{
    public int SubCategoryId { get; set; }

    public int? CategoryId { get; set; }

    public string SubCategoryName { get; set; } = null!;

    public virtual FoodCategory? Category { get; set; }

    public virtual ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
}
