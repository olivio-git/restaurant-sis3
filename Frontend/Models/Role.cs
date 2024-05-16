using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace restaurant_sis3.Modelos;

public partial class Role
{
    [Key]
    [Column("RolID")]
    public int RolId { get; set; }

    [StringLength(50)]
    public string? Nombre { get; set; }

    [InverseProperty("Rol")]
    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    [InverseProperty("Rol")]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
