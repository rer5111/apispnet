using System;
using System.Collections.Generic;

namespace Apispnet.Models;

public partial class Cart
{
    public int IdCart { get; set; }

    public int OwnerId { get; set; }

    public int ItemsId { get; set; }
}
