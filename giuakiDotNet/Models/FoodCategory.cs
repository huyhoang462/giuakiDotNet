﻿using System;
using System.Collections.Generic;

namespace giuakiDotNet.Models;

public partial class FoodCategory
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
}
