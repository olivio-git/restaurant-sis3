using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace restaurant_sis3.Modelos;

public partial class Categoria
{
    [Key]
    [Column("CategoriaID")]
    public int CategoriaId { get; set; }

    [StringLength(50)]
    public string? Nombre { get; set; }

    [InverseProperty("Categoria")]
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
