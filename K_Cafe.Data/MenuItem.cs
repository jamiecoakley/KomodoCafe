
public class MenuItem
{
    public MenuItem(){}
    
    public MenuItem( string mealName, string description, string ingredients, decimal price)
    {
        MealName = mealName;
        Description = description;
        Ingredients = ingredients;
        Price = price;
    }

    public string MealName { get; set; }
    public string Description { get; set; }
    public string Ingredients { get; set; }
    public decimal Price { get; set; }
    public int ID { get; set; }
}
