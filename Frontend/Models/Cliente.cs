using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace restaurant_sis3.Modelos;

public partial class Cliente
{
    [Key]
    [Column("ClienteID")]
    public int ClienteId { get; set; }

    [StringLength(50)]
    public string? Nombre { get; set; }

    [StringLength(20)]
    public string? Telefono { get; set; }

    [StringLength(50)]
    public string? Email { get; set; }

    [InverseProperty("Cliente")]
    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    [InverseProperty("Cliente")]
    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    [InverseProperty("Cliente")]
    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
