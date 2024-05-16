using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace restaurant_sis3.Modelos;

public partial class Empleado
{
    [Key]
    [Column("EmpleadoID")]
    public int EmpleadoId { get; set; }

    [StringLength(50)]
    public string? Nombre { get; set; }

    [Column("RolID")]
    public int? RolId { get; set; }

    public DateOnly? FechaContrato { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Salario { get; set; }

    [ForeignKey("RolId")]
    [InverseProperty("Empleados")]
    public virtual Role? Rol { get; set; }

    [InverseProperty("Empleado")]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
