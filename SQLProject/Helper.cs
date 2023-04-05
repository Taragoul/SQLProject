namespace SQLProject
{
    internal class Helper
    {
        // put in method to print different menu options based on the parameters, also prints a "go back" option if hasback = true
        internal static int MenuIndexer(string[] array, bool hasBack = false, string headerText = "")
        {
            if (hasBack)
            {
                Array.Resize(ref array, array.Length + 1);
                array[array.Length - 1] = "Go Back";
            }
            menu menu = new menu(array);
            if (!string.IsNullOrEmpty(headerText))
            {
                menu.PrintMenu(headerText);
            }
            else
            {
                menu.PrintMenu();
            }
            int index = menu.UseMenu();
            return index;
        }
    }
}