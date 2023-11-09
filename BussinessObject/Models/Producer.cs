using System;
using System.Collections.Generic;

namespace BussinessObject.Models;

public partial class Producer
{
    public string ProducerId { get; set; } = null!;

    public string ProducerName { get; set; } = null!;

    public string ProducerDescription { get; set; } = null!;

    public string? Country { get; set; }

    public virtual ICollection<CartoonFilmInformation> CartoonFilmInformations { get; set; } = new List<CartoonFilmInformation>();
}
