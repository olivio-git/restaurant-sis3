using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace restaurant_sis3.Modelos;

public partial class Reserva
{
    [Key]
    [Column("ReservaID")]
    public int ReservaId { get; set; }

    [Column("ClienteID")]
    public int? ClienteId { get; set; }

    [Column("MesaID")]
    public int? MesaId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaInicio { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaFin { get; set; }

    [ForeignKey("ClienteId")]
    [InverseProperty("Reservas")]
    public virtual Cliente? Cliente { get; set; }

    [ForeignKey("MesaId")]
    [InverseProperty("Reservas")]
    public virtual Mesa? Mesa { get; set; }
}
