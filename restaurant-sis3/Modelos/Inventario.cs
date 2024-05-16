using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace restaurant_sis3.Modelos;

[Table("Inventario")]
public partial class Inventario
{
    [Key]
    [Column("InventarioID")]
    public int InventarioId { get; set; }

    [Column("IngredienteID")]
    public int? IngredienteId { get; set; }

    public int? Cantidad { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaEntrada { get; set; }

    [ForeignKey("IngredienteId")]
    [InverseProperty("Inventarios")]
    public virtual Ingrediente? Ingrediente { get; set; }

    [InverseProperty("Inventario")]
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
