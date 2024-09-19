namespace MenuSystem;

class Program
{
    static void Main(string[] args)
    {
        Menu mainMenu = new Menu();

        mainMenu.Title = "Vælg om du er en medarbejder";
        mainMenu.menuItems = new MenuItem[10];

        // First menu item
        MenuItem mi = new MenuItem();
        mi.Title = "1. Medarbejder";
        mainMenu.menuItems[0] = mi;
        mainMenu.ItemCount++; // Increment with one; same as: ItemCount = ItemCount + 1

        // Second menu item
        mi = new MenuItem();
        mi.Title = "2. Gæst";
        mainMenu.menuItems[1] = mi;
        mainMenu.ItemCount++;

        int menuvalg = 1;
        bool quit = false;
        int valg = -1;
        while (quit == false)
        {
            switch (menuvalg)
            {
                case 1:
                    valg = mainMenu.Show(1);
                    if (valg == 0)
                    {
                        quit = true;
                    }
                    if (valg == 1)
                    {
                        Console.WriteLine("hej");
                        Console.ReadLine();
                    }
                    break;
            }
        }
    }

}

