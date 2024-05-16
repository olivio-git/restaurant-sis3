using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace restaurant_sis3.Modelos;

public partial class Ingrediente
{
    [Key]
    [Column("IngredienteID")]
    public int IngredienteId { get; set; }

    [StringLength(100)]
    public string? Nombre { get; set; }

    public int? StockActual { get; set; }

    [StringLength(20)]
    public string? UnidadMedida { get; set; }

    [Column("ProductoID")]
    public int? ProductoId { get; set; }

    [InverseProperty("Ingrediente")]
    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    [ForeignKey("ProductoId")]
    [InverseProperty("Ingredientes")]
    public virtual Producto? Producto { get; set; }
}
