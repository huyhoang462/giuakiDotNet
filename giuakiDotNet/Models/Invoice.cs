using System;
using System.Collections.Generic;

namespace giuakiDotNet.Models;

public partial class Invoice
{
    public int InvoiceId { get; set; }

    public int? TableId { get; set; }

    public decimal? TotalAmount { get; set; }

    public DateTime InvoiceDate { get; set; }

    public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();

    public virtual RestaurantTable? Table { get; set; }
}
