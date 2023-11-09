using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BussinessObject.Models;

public partial class CartoonFilmInformation
{
    public int CartoonFilmId { get; set; }

    [MinLength(15)]
    [MaxLength(120)]
    public string CartoonFilmName { get; set; } = null!;

    public string? CartoonFilmDescription { get; set; }

    [Range(1, Int32.MaxValue)]
    public int? Duration { get; set; }

    [Range(1900, 2023)]
    public int? ReleaseYear { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? ProducerId { get; set; }

    public virtual Producer? Producer { get; set; }
}
