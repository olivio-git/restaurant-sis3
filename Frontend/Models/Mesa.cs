using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace restaurant_sis3.Modelos;

public partial class Mesa
{
    [Key]
    [Column("MesaID")]
    public int MesaId { get; set; }

    [StringLength(50)]
    public string? Nombre { get; set; }

    public int? Capacidad { get; set; }

    [InverseProperty("Mesa")]
    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
