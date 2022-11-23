
public class MenuItemRepository
{
    private readonly List<MenuItem>_menuItemDb = new List<MenuItem>();
    private int _count;


//construct and add to the database (CREATE)
    public MenuItemRepository()
    {
        SeedMenuData();
    }

    public bool AddMenuItemToDb(MenuItem item)
    {
        return (item is null) ? false : AddToMenu(item);
    }

    public bool AddToMenu(MenuItem item)
    {
        AssignMenuNumber(item);
        _menuItemDb.Add(item);
        return true;
    }

    private void AssignMenuNumber(MenuItem item)
    {
        _count++;
        item.ID = _count;
    }

//READ
    //See whole menu
    public List<MenuItem> SeeMenu()
    {
        return _menuItemDb;
    }

    public MenuItem GetItemByID(int ID)
    {
        return _menuItemDb.SingleOrDefault(item => item.ID == ID);
    }

//UPDATE
public bool UpdateMenuItem(int ID, MenuItem update)
{
    MenuItem originalItem = GetItemByID(ID);
    
    if (originalItem != null)
    {
        originalItem.MealName = update.MealName;
        originalItem.Description = update.Description;
        originalItem.Ingredients = update.Ingredients;
        originalItem.Price = update.Price;
        return true;
    }
    else
    {
        return false;
    }  
}

public bool UpdateMealName(int ID, MenuItem update)
{
    MenuItem original = GetItemByID(ID);

    if (original != null)
    {
        original.MealName = update.MealName;
        return true;
    }
    else
    {
        return false;
    }
}

//DELETE
public bool DeleteMenuItem (int ID)
{
    MenuItem menuItem = GetItemByID(ID);
    return _menuItemDb.Remove(menuItem);
}

//fake database
    private void SeedMenuData()
    {
        var item1 = new MenuItem("Turkey Sandwich", "Ovengold coldcut turkey on multigrain bread, served with kettle chips and a bottle of water.", "Multigrain bread, turkey, lettuce, mayonnaise, spinach, tomato, provolone cheese, and Italian seasoning", 10.00m);
        var item2 = new MenuItem("Reuben Sandwich", "Classic Reuben sandwich, stinky and piled high with corned beef; served with kettle chips and a bottle of water.", "Rye bread, corned beef, Swiss cheese, sauerkraut, Thousand Island dressing", 12.50m);
        var item3 = new MenuItem("Truffle Grilled Cheese", "White cheddar, mozzerella, and truffle between sourdough bread, coated with parmesan cheese; served with kettle chips and a water bottle.", "Sourdough bread, white cheddar cheese, mozzerella cheese, parmesan cheese, truffle, butter", 12.00m);
        var item4 = new MenuItem("College Special", "Creamy peanutbutter and grape jelly on a toasted chocolate chip bagel. served with kettle chips and a water bottle.", "Peanutbutter, jelly, chocolate chip bagel", 7.50m);
        var item5 = new MenuItem("Chicken Sandwich", "Pan-fried chicken on a brioche bun - a healthier fried chicken sandwich, served with kettle chips and a water bottle.", "Olive oil, panko bread crumbs, ground chicken, skim milk, brioche bun, lettuce, tomato, mayonnaise", 15.00m);

        AddMenuItemToDb(item1);
        AddMenuItemToDb(item2);
        AddMenuItemToDb(item3);
        AddMenuItemToDb(item4);
        AddMenuItemToDb(item5);
    }
}