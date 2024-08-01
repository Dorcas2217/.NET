using System;
using System.Collections.Generic;

namespace S3Exercices.Models;

public partial class OrderSubtotal
{
    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
