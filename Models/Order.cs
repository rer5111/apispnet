using System;
using System.Collections.Generic;

namespace Apispnet.Models;

public partial class Order
{
    public int IdOrder { get; set; }

    public int OwnerId { get; set; }

    public int ItemsId { get; set; }

}
