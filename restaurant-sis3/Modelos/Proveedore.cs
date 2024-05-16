using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace restaurant_sis3.Modelos;

public partial class Proveedore
{
    [Key]
    [Column("ProveedorID")]
    public int ProveedorId { get; set; }

    [StringLength(100)]
    public string? Nombre { get; set; }

    [StringLength(20)]
    public string? Telefono { get; set; }

    [StringLength(50)]
    public string? Email { get; set; }

    [InverseProperty("Proveedor")]
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
