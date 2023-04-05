namespace SQLProject
{
    internal class menu
    {
        private readonly string[] _menuItems;
        private int _selectedIndex;
        private string _headerText;

        public menu(string[] menuItems)
        {
            _menuItems = menuItems;
            _selectedIndex = 0;
        }
        //Prints the menu in the console
        public void PrintMenu(string headerText = "")
        {
            Console.Clear();
            if (!string.IsNullOrEmpty(headerText))
            {
                Console.WriteLine($"{_headerText}\n");
            }
            for (int i = 0; i < _menuItems.Length; i++)
            {
                Console.WriteLine(i == _selectedIndex ? $"-> {_menuItems[i]}" : $"  {_menuItems[i]}  ");
                Console.WriteLine();
            }
        }
        public int SelectIndex
        {
            get => _selectedIndex;
            set => _selectedIndex = (value % _menuItems.Length + _menuItems.Length) % _menuItems.Length;
        }
        //Allows the user to use arrow inputs and enter inputs when the menu is printed, This method is reusable
        public int UseMenu(string headerText = "")
        {
            ConsoleKey userInput;
            do
            {
                userInput = Console.ReadKey(true).Key;
                switch (userInput)
                {
                    case ConsoleKey.UpArrow:
                        _selectedIndex--;
                        _selectedIndex = (_selectedIndex % _menuItems.Length + _menuItems.Length) % _menuItems.Length;
                        break;
                    case ConsoleKey.DownArrow:
                        _selectedIndex++;
                        _selectedIndex = (_selectedIndex % _menuItems.Length + _menuItems.Length) % _menuItems.Length;
                        break;
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        var index = _selectedIndex;
                        PrintMenu(headerText);
                        return index;
                }
                PrintMenu(headerText);
            } while (true);
        }

        //The startmenu, Allows you to navigate using printmenu, and gives access to other methods in the program
        internal static void StartMenu()
        {
            menu mainMenu = new menu(new string[] { "Report Hours", "Users", "Projects", "New User", "New Project", "Update Existing User", "Update Existing Project", "Adjust Existing hours Worked", "Exit" });

            mainMenu.PrintMenu();
            bool showMenu = true;

            while (showMenu)
            {
                int index = mainMenu.UseMenu();
                switch (index)
                {
                    case 0:
                        Program.ClockHours();
                        break;
                    case 1:
                        Program.Users();
                        break;
                    case 2:
                        Program.Projects();
                        break;
                    case 3:
                        Program.NewPerson();
                        break;
                    case 4:
                        Program.NewProject();
                        break;
                    case 5:
                        Program.UpdatePerson();
                        break;
                    case 6:
                        Program.UpdateProject();
                        break;
                    case 7:
                        Program.ChangeTime();
                        break;
                    case 8:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}