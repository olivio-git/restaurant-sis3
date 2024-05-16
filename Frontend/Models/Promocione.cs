using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace restaurant_sis3.Modelos;

public partial class Promocione
{
    [Key]
    [Column("PromocionID")]
    public int PromocionId { get; set; }

    [StringLength(50)]
    public string? Nombre { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaInicio { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaFin { get; set; }

    [Column("DescuentoID")]
    public int? DescuentoId { get; set; }

    [ForeignKey("DescuentoId")]
    [InverseProperty("Promociones")]
    public virtual Descuento? Descuento { get; set; }

    [InverseProperty("Promocion")]
    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
