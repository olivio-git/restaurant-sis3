using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace restaurant_sis3.Modelos;

public partial class Comentario
{
    [Key]
    [Column("ComentarioID")]
    public int ComentarioId { get; set; }

    [Column("ClienteID")]
    public int? ClienteId { get; set; }

    [Column("Comentario")]
    public string? Comentario1 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaComentario { get; set; }

    [ForeignKey("ClienteId")]
    [InverseProperty("Comentarios")]
    public virtual Cliente? Cliente { get; set; }
}
