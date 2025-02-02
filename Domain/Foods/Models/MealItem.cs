using Domain._Base.Models;

namespace Domain.Foods.Models;

public class MealItem : Food
{
    public Guid MealId { get; set; }
    public Meal Meal { get; set; } = null!;
}