using System;
using System.Collections.Generic;

namespace Apispnet.Models;

public partial class OrderItem
{
    public int IdItems { get; set; }

    public int Amount { get; set; }

    public int ProductId { get; set; }
}
