using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain._Base.Models;

public abstract class Entity
{
    protected Entity() => Id = Guid.NewGuid();
    
    public Guid Id { get; }
    
    [Column("created_at", TypeName = "datetime(6)"), Required]
    public DateTime CreatedAt { get; set; }
    
    [Column("created_by", TypeName = "varchar(250)")]
    public string CreatedBy { get; private set; }
    
    [Column("updated_at", TypeName = "datetime(6)")]
    public DateTime? UpdatedAt { get; set; }
    
    [Column("updated_by", TypeName = "varchar(250)")]
    public string UpdatedBy { get; protected set; }
}