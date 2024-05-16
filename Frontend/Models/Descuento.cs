using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace restaurant_sis3.Modelos;

public partial class Descuento
{
    [Key]
    [Column("DescuentoID")]
    public int DescuentoId { get; set; }

    [StringLength(50)]
    public string? Nombre { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? Porcentaje { get; set; }

    [InverseProperty("Descuento")]
    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    [InverseProperty("Descuento")]
    public virtual ICollection<Promocione> Promociones { get; set; } = new List<Promocione>();
}
