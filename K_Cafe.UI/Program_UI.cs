using static System.Console;

public class Program_UI
{    
    private readonly MenuItemRepository _menuRepo = new MenuItemRepository();

    public void Run()
    {
        RunApplication();
    }

//    public Program_UI(IConsole Console) {}

    public void RunApplication()
    {
        bool isRunning = true;
        while(isRunning) 
        {
            Clear();
            WriteLine
            (
                "_____Welcome to Komodo Café!_____\n" +
                "Please make a selection:\n" +
                "1. See the menu\n" +
                "2. Add to the menu\n" +
                "3. Delete a menu item\n" +
                "4. Update the menu\n" +                
                "0. Exit the application"
            );

            string selection = ReadLine();
            switch (selection)
            {
                case "1":
                    SeeTheMenu();
                    PressAnyKeyToContinue();
                    break;
                case "2":
                    AddItemToMenu();
                    PressAnyKeyToContinue();
                    break;
                case "3":
                    DeleteMenuItem();
                    break;
                case "4":
                    UpdateMenu();
                    break;
                case "0":
                    isRunning = false;
                    Clear();
                    WriteLine("\n Have a lovely rest of your day! \n");
                    Thread.Sleep(1000);
                    WriteLine("Press enter to leave.");
                    ReadKey();
                    Clear();
                    break;
                default:
                    WriteLine("Invalid selection; please try again!");
                    break;
            }
        }
    }

    private void UpdateMenu()
    {
        Clear();
        SeeTheMenu();
        Write("Choose menu item to update: ");

        int updateInput = int.Parse(ReadLine());
        var menuItem = _menuRepo.GetItemByID(updateInput);

        if (menuItem != null)
        {
            MenuItem updatedItem = AddToMenuQuestions();
            if (_menuRepo.UpdateMenuItem(menuItem.ID, updatedItem))
                WriteLine("Item successfully updated!");
            else
                WriteLine("Item failed to update; try again.");
        }
        PressAnyKeyToContinue();     
    }


    //Future improvements: just update one part of it (i.e. just the title)
    //  Turn the ingredient string into an array and insert or remove bits of array to update ingredients


    private MenuItem GetMenuItemByID(int itemID)
    {
        return _menuRepo.GetItemByID(itemID);
    }

    private void PressAnyKeyToContinue()
    {        
        Thread.Sleep(2000);
        WriteLine("\n\n" + 
                    "Press Enter to Continue");
        ReadKey();
    }
    

    private void SeeTheMenu() 
    {
        Clear();
        if (_menuRepo.SeeMenu().Count > 0)
        {
            foreach (var item in _menuRepo.SeeMenu())
            {
                WriteLine($"#{item.ID}  {item.MealName}  |  ${item.Price}\n" + 
                        $"{item.Description}\n" +
                        $"Ingredients: {item.Ingredients}\n" + 
                        "---------------------------------");
            }
        }
        else
        {
            WriteLine("Time to cook up something new!");
        }
    }
    private void AddItemToMenu() 
    {
        Clear();
        MenuItem item = AddToMenuQuestions();

        if (_menuRepo.AddToMenu(item))
        {
            WriteLine($"\n\nYou've added Item #{item.ID}, {item.MealName}, to your menu!");
        }
        else
        {
            WriteLine($"Item not added; try again.");
        }
    }

    private MenuItem AddToMenuQuestions()
    {
        try
        {
            MenuItem item = new MenuItem();
            WriteLine("Give your new item a snazzy name:");
            item.MealName = ReadLine();
            WriteLine("\nHow much are you charging for your new item?");
            Write("$");
            item.Price = decimal.Parse(ReadLine());
            WriteLine("\nDescribe the new item:");
            item.Description = ReadLine();
            WriteLine("\nList the ingredients:");
            item.Ingredients = ReadLine();

            return item;
        }
        catch
        {
            return null;
        }
    }

    private void DeleteMenuItem() 
    {
        try
        {
            Clear();
            WriteLine("Choose the item you want to delete.\n" + 
                        "To exit without deleting, press enter.\n");
            MenuIdReadout();

            List<MenuItem> menu = _menuRepo.SeeMenu();

            if (menu.Count > 0)
            {
                int count = 0;
                foreach (MenuItem item in menu)
                {
                    count++;
                }
                int deleteItem = int.Parse(ReadLine());
                int deleteTheCorrectItemBecauseListsStartAtZeroNotOne = deleteItem - 1;

                if (deleteTheCorrectItemBecauseListsStartAtZeroNotOne >= 0 && deleteTheCorrectItemBecauseListsStartAtZeroNotOne < menu.Count)
                {
                    MenuItem getting86d = menu[deleteTheCorrectItemBecauseListsStartAtZeroNotOne];
                    if(_menuRepo.DeleteMenuItem(getting86d.ID))
                    {
                        Clear();
                        WriteLine($"{getting86d.MealName} is 86'd!");
                        PressAnyKeyToContinue();
                    }
                    else
                    {
                        WriteLine($"{getting86d.MealName} is determined to see another day.");
                        ReadKey();
                    }
                }
                else
                {
                    WriteLine("That item doesn't exist. Try again.");
                    ReadKey();
                }
            }        
            else
            {
                Console.Clear();
                WriteLine("THERE IS NO MENU, ONLY ZUUL");
                ReadKey();
            }
        }
        catch
        {
            BackOutOfDeleting();
        }
        
    }

    // private void AreYouSure()
    // {
    //     WriteLine("Are you sure you want to delete this? (y/n)");
    //     string yOrN = ReadLine();
    //     if (yOrN== "y".ToLower())
    //     {
    //         WriteLine("Press any key to continue");
    //         ReadKey();
    //     }
    //     else if (yOrN == "n".ToLower())
    //     {
    //         WriteLine("It's okay to change your mind!");
    //         Clear();
    //         return;
    //     }
    //     else 
    //     {
    //         WriteLine("Invalid entry; try again!");
    //         Clear();
    //         return;
    //     }
    // }

    private void BackOutOfDeleting()
    {
        WriteLine("\n\n" + 
                "Press Enter to Continue");
        ReadKey();
    }

    private void MenuIdReadout()
    {
        List<MenuItem> menu = _menuRepo.SeeMenu();
        if (menu.Count > 0)
        {
            foreach (var item in menu)
            {
                WriteLine($"{item.ID}. {item.MealName}\n");
            }
        }
        else
        {
            WriteLine("-------------------------\n"+
                    "THERE IS NO MENU, ONLY ZUUL\n" +
                    "-------------------------");
        }
    }


    
    //Method to see the menu item in the console.
    // private void ExpandMenuItem(MenuItem item)
    // {
    //     WriteLine(item);
    // }

}
