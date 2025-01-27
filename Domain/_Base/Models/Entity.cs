using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain._Base.Models;

public abstract class Entity
{
    protected Entity() => Id = Guid.NewGuid();
    
    public Guid Id { get; }
    
    [Column("description", TypeName = "varchar(250)"), Required]
    public string Description { get; set; }
    
    [Column("data_registered", TypeName = "datetime(6)"), Required]
    public DateTime DateRegistered { get; set; } = DateTime.Now;
    
    public override bool Equals(object obj)
    {
        var compareTo = obj as Entity;

        if (ReferenceEquals(this, compareTo)) return true;

        return compareTo is not null && Id.Equals(compareTo.Id);
    }
    
    public override int GetHashCode() => (GetType().GetHashCode() * 907) + Id.GetHashCode();
}