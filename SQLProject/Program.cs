namespace SQLProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Menu();
            menu.StartMenu();
        }

        //Asks and checks for name in database, project in database and then asks for hours to input, this is then fed into the dataaccess file to allow for the database to update
        internal static void ClockHours()
        {
            List<PersonModel> persons = DataAccess.Persons();
            List<ProjectModel> projects = DataAccess.Projects();
            Console.Write("What is your name: ");
            string? name = Console.ReadLine();
            for (int i = 0; i < persons.Count; i++)
            {

                if (persons[i].person_name.Equals(name))
                {
                    int x = persons[i].id;
                    Console.ReadLine();
                    i = persons.Count;
                    Console.Write("Project: ");
                    string? project = Console.ReadLine();
                    for (int j = 0; j < projects.Count; j++)
                    {

                        int y = projects[j].id;
                        if (projects[j].project_name.Equals(project))
                        {
                            Console.ReadLine();
                            j = projects.Count;
                            Console.WriteLine("How many Hours:");
                            int hours = int.Parse(Console.ReadLine());
                            DataAccess.ProjectPerson(y, x, hours);
                        }
                    }
                }
                else if (i == persons.Count - 1)
                {
                    Console.WriteLine("User Not found");
                }
            }
            Console.WriteLine($"Done");
            Console.ReadLine();
            menu.StartMenu();
        }

        //Grants access and prints all users that exist in the database
        internal static void Users()
        {
            Console.Clear();
            List<PersonModel> persons = DataAccess.Persons();
            Console.WriteLine("USERS");
            foreach (PersonModel person in persons)
            {
                Console.WriteLine(person.person_name);
            }
            Console.ReadLine();
            menu.StartMenu();
        }
        //Grants access and prints all projects that exist in the database
        internal static void Projects()
        {
            Console.Clear();
            List<ProjectModel> projects = DataAccess.Projects();
            Console.WriteLine("PROJECTS");
            foreach (ProjectModel project in projects)
            {
                Console.WriteLine(project.project_name);
            }
            Console.ReadLine();
            menu.StartMenu();
        }

        //Allows you to insert a new user to the database
        internal static void NewPerson()
        {
            Console.Clear();
            Console.Write("Name: ");
            string? input = Console.ReadLine();
            DataAccess.NewPerson(input);
            Console.WriteLine("Name has been added!");
            Console.ReadLine();
            menu.StartMenu();
        }
        //updates users name from an existing one in the database
        internal static void UpdatePerson()
        {
            Console.Clear();
            List<PersonModel> persons = DataAccess.Persons();
            Console.WriteLine("What Name Would You Like To Change:");
            string? old_name = Console.ReadLine();
            for (int i = 0; i < persons.Count; i++)
            {
                if (persons[i].person_name.Equals(old_name))
                {
                    int x = persons[i].id;
                    Console.WriteLine($"Name you want to change: {old_name} ID:{x}");
                    Console.Write($"New Name:");
                    string? new_name = Console.ReadLine();
                    Console.WriteLine($"old:{old_name} new:{new_name}");
                    DataAccess.UpdatePerson(x, new_name);
                    i = persons.Count;
                    Console.WriteLine("Done");
                    Console.ReadLine();
                    menu.StartMenu();
                }
                else if (i == persons.Count - 1)
                {
                    Console.WriteLine("User Not found");
                }
            }

        }
        //updates project name from an existing one in the database
        internal static void UpdateProject()
        {
            Console.Clear();
            List<ProjectModel> projects = DataAccess.Projects();
            Console.WriteLine("What Project Would You Like To Change:");
            string? old_project_name = Console.ReadLine();
            for (int i = 0; i < projects.Count; i++)
            {
                if (projects[i].project_name.Equals(old_project_name))
                {
                    int x = projects[i].id;
                    Console.Write($"Project name you want to change: {old_project_name} ID:{x}");
                    Console.Write($"New Project Name:");
                    string? new_project_name = Console.ReadLine();
                    Console.WriteLine($"old:{old_project_name} new:{new_project_name}");
                    DataAccess.UpdateProject(x, new_project_name);
                    i = projects.Count;
                    Console.WriteLine("Done");
                    Console.ReadLine();
                    menu.StartMenu();
                }
                else if (i == projects.Count - 1)
                {
                    Console.WriteLine("User Not found");
                }
            }

        }

        //Allows you to insert a new project to the database
        internal static void NewProject()
        {
            Console.Clear();
            Console.Write("New Projectname: ");
            string? input = Console.ReadLine();
            DataAccess.NewProject(input);
            Console.WriteLine("Project has been added!");
            Console.ReadLine();
            menu.StartMenu();
        }

        //Allows you to modify the hours you worked from example:(5hours => 8hours)
        internal static void ChangeTime()
        {

            List<PersonModel> users = DataAccess.Persons();
            List<ProjectModel> projects = DataAccess.Projects();

            string[] strings = users.Select(user =>
            {
                return user.person_name;
            }).ToArray();

            int index = Helper.MenuIndexer(strings, true);
            int who = users[index].id;
            List<ProjectPersonModel> userproject = DataAccess.ProjectPeople(who);
            string[] userpArr = userproject.Select(userp =>
            {
                return userp.project_name + " " + userp.hours + " hours";

            }).ToArray();


            if (index == strings.Length) { menu.StartMenu(); }
            else
            {
                string wohin = ($"{strings[index]}");
            }
            int projectIndex = Helper.MenuIndexer(userpArr, true);
            if (projectIndex == userpArr.Length)
            {
                menu.StartMenu();
            }
            Console.Write("Adjust Hours clocked to: ");
            int input = int.Parse(Console.ReadLine());
            int type = userproject[projectIndex].id;
            DataAccess.UpdateHours(type, input);
            Console.WriteLine($"Done,hours have been adjusted");
            menu.StartMenu();

        }
    }
}
