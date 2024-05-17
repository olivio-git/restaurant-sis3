using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace restaurant_sis3.Modelos;

public partial class Producto
{
    [Key]
    [Column("ProductoID")]
    public int ProductoId { get; set; }

    [StringLength(100)]
    public string? Nombre { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Precio { get; set; }

    [Column("CategoriaID")]
    public int? CategoriaId { get; set; }

    [Column("ProveedorID")]
    public int? ProveedorId { get; set; }

    [Column("InventarioID")]
    public int? InventarioId { get; set; }

    [ForeignKey("CategoriaId")]
    [InverseProperty("Productos")]
    public virtual Categoria? Categoria { get; set; }

    [InverseProperty("Producto")]
    public virtual ICollection<DetallesPedido> DetallesPedidos { get; set; } = new List<DetallesPedido>();

    [InverseProperty("Producto")]
    public virtual ICollection<Ingrediente> Ingredientes { get; set; } = new List<Ingrediente>();

    [ForeignKey("InventarioId")]
    [InverseProperty("Productos")]
    public virtual Inventario? Inventario { get; set; }

    [ForeignKey("ProveedorId")]
    [InverseProperty("Productos")]
    public virtual Proveedores? Proveedor { get; set; }
}
