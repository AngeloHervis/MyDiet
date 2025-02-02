using Domain.Foods.Models;
using Microsoft.AspNetCore.Identity;

namespace Domain.Autentication;

public class User : IdentityUser<Guid>
{
    public User()
    {
        Id = Guid.NewGuid();
    }
    
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public List<Meal> Meals { get; set; } = [];
}