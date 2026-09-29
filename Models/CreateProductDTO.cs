using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apispnet.Models;

public partial class CreateProductDTO
{
    public string Title { get; set; } = null!;

    public decimal Cost { get; set; }

    public int CategoryId { get; set; }
}
