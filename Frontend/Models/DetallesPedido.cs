using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace restaurant_sis3.Modelos;

[Table("DetallesPedido")]
public partial class DetallesPedido
{
    [Key]
    [Column("DetalleID")]
    public int DetalleId { get; set; }

    [Column("PedidoID")]
    public int? PedidoId { get; set; }

    [Column("ProductoID")]
    public int? ProductoId { get; set; }

    public int? Cantidad { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? PrecioUnitario { get; set; }

    [ForeignKey("PedidoId")]
    [InverseProperty("DetallesPedidos")]
    public virtual Pedido? Pedido { get; set; }

    [ForeignKey("ProductoId")]
    [InverseProperty("DetallesPedidos")]
    public virtual Producto? Producto { get; set; }
}
