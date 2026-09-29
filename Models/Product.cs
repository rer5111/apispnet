using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apispnet.Models;

public partial class Product
{
    public int IdProduct { get; set; }

    public string Title { get; set; } = null!;

    public decimal Cost { get; set; }

    public int CategoryId { get; set; }

    public string? Img { get; set; }

    [NotMapped]
    public IFormFile? imgfile { get; set; }
}
