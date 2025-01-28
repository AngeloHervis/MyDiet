namespace Domain.Food.Models;

public class MealItem
{
    public int Id { get; set; }
    public int MealId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Calories { get; set; }
    public decimal Protein { get; set; }
    public decimal Carbs { get; set; }
    public decimal Fat { get; set; }
    public decimal Quantity { get; set; }
    public string Unit { get; set; } = "g";
    public Meal Meal { get; set; } = null!;
}