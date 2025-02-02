namespace Domain._Base.Models;

public abstract class Food : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Calories { get; set; }
    public decimal Protein { get; set; }
    public decimal Carbs { get; set; }
    public decimal Fat { get; set; }
    public decimal Quantity { get; set; }
}