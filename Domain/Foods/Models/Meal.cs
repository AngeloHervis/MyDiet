using Domain._Base.Models;
using Domain.Autentication;

namespace Domain.Foods.Models;

public class Meal : Food
{
    public Guid UserId { get; set; }
    public User UserCreated { get; set; } = null!;
    public List<MealItem> MealItems { get; set; } = [];
}