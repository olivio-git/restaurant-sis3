using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace restaurant_sis3.Modelos;

public partial class Pedido
{
    [Key]
    [Column("PedidoID")]
    public int PedidoId { get; set; }

    [Column("ClienteID")]
    public int? ClienteId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaPedido { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Total { get; set; }

    [StringLength(50)]
    public string? Estado { get; set; }

    [Column("PromocionID")]
    public int? PromocionId { get; set; }

    [Column("DescuentoID")]
    public int? DescuentoId { get; set; }

    [Column("UsuarioID")]
    public int? UsuarioId { get; set; }

    [ForeignKey("ClienteId")]
    [InverseProperty("Pedidos")]
    public virtual Cliente? Cliente { get; set; }

    [ForeignKey("DescuentoId")]
    [InverseProperty("Pedidos")]
    public virtual Descuento? Descuento { get; set; }

    [InverseProperty("Pedido")]
    public virtual ICollection<DetallesPedido> DetallesPedidos { get; set; } = new List<DetallesPedido>();

    [ForeignKey("PromocionId")]
    [InverseProperty("Pedidos")]
    public virtual Promociones? Promocion { get; set; }

    [ForeignKey("UsuarioId")]
    [InverseProperty("Pedidos")]
    public virtual Usuario? Usuario { get; set; }
}
