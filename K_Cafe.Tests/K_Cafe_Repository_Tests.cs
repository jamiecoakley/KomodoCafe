namespace K_Cafe.Tests;

public class K_Cafe_Repository_Tests
{
        private MenuItemRepository _testMenuRepo;
        private MenuItem _itemA;
        private MenuItem _itemB;
        private MenuItem _itemC;
        private MenuItem _itemD;

    public K_Cafe_Repository_Tests()
    {
        _testMenuRepo = new MenuItemRepository();
        _itemA = new MenuItem("Best Mac 'n Cheese You'll Ever Taste", "Three-cheese blend baked mac n' cheese with breadcrumbs; all the unhealthy goodness you'd expect.", "Sharp cheddar, gouda, havarti, noodles, milk, flour, breadcrumbs", 11.00m);
        _itemB = new MenuItem("Truffle Grilled Cheese", "Grilled cheese with a healthy portion of truffle.", "Bread, cheese, truffle", 16.00m);
        _itemC = new MenuItem("Perfectly Chocolate Chocolate Cake", "Chocolate cake with fudge frosting that actually tastes awesome", "Chocolate, more chocolate, flour, vanilla, butter, sugar, chocolate", 8.00m);
        _itemD = new MenuItem("Deep Dish Pizza", "From Lou Malnati's (not illuminati) - the original Chicago", "Crust, cheese, sauce, magic", 8.00m);

//getting the first database for free, so these are 6, 7, 8, and 9.
        _testMenuRepo.AddMenuItemToDb(_itemA); 
        _testMenuRepo.AddMenuItemToDb(_itemB);
        _testMenuRepo.AddMenuItemToDb(_itemC);
        _testMenuRepo.AddMenuItemToDb(_itemD);
    }

    [Fact]
    public void AddMealToMenu()
    {
        //Arrange
        MenuItem testItem  = new MenuItem("Stress-Eating Special", "Peanutbutter brownie", "Brownie, peanutbutter, peanuts, caramel", 5.50m);
        MenuItemRepository _menuRepoTest = new MenuItemRepository();

        //Act
        bool expected = true;
        bool actual = _menuRepoTest.AddMenuItemToDb(testItem);

        //Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DeleteMealFromMenu()
    {
        var deleteItem = _testMenuRepo.GetItemByID(2); //#painful
        
        bool its86d = _testMenuRepo.DeleteMenuItem(deleteItem.ID);

        Assert.True(its86d);
        Assert.Equal(7, _testMenuRepo.SeeMenu().Count); //why did this want a 7? (figured it out. see above)
    }

    [Fact]
    public void GetMealByID()
    {
        MenuItem getMealByID = _testMenuRepo.GetItemByID(8);

        Assert.Equal(getMealByID, _itemC);
    }

    [Fact]
    public void DisplayTheWholeMenu()
    {
        MenuItem item = new MenuItem();
        MenuItemRepository repo = new MenuItemRepository();

        repo.AddMenuItemToDb(item);

        List<MenuItem> items = repo.SeeMenu();
        bool menuHasItems = items.Contains(item);

        Assert.True(menuHasItems);
    }
}