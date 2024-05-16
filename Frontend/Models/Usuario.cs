using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace restaurant_sis3.Modelos;

public partial class Usuario
{
    [Key]
    [Column("UsuarioID")]
    public int UsuarioId { get; set; }

    [StringLength(50)]
    public string? Nombre { get; set; }

    [StringLength(50)]
    public string? Password { get; set; }

    [StringLength(50)]
    public string? Email { get; set; }

    [Column("EmpleadoID")]
    public int? EmpleadoId { get; set; }

    [Column("RolID")]
    public int? RolId { get; set; }

    [ForeignKey("EmpleadoId")]
    [InverseProperty("Usuarios")]
    public virtual Empleado? Empleado { get; set; }

    [InverseProperty("Usuario")]
    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    [ForeignKey("RolId")]
    [InverseProperty("Usuarios")]
    public virtual Role? Rol { get; set; }
}
