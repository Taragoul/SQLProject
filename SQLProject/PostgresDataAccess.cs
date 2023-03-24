using Dapper;
using Npgsql;
using System.Configuration;
using System.Data;
namespace SQLProject
{
    internal class DataAccess
    {
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        //Selects users from rjo_person table in db
        public static List<PersonModel> Persons()
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<PersonModel>("SELECT * FROM rjo_person", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<ProjectModel> Projects()
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ProjectModel>("SELECT * FROM rjo_project", new DynamicParameters());
                return output.ToList();
            }
        }
        internal static void ProjectPerson(int project_id, int person_id, int hours)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Execute($@"INSERT INTO rjo_project_person (project_id,person_id,hours) VALUES({project_id},{person_id},{hours})", new DynamicParameters());
            }
        }

        internal static void NewPerson(string person_name)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Execute($@"INSERT INTO rjo_person (person_name) VALUES('{person_name}')", new DynamicParameters());
            }
        }
        internal static void UpdatePerson(int old_person_id, string new_person_name)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Execute($@"UPDATE rjo_person SET person_name ='{new_person_name}' WHERE id ={old_person_id}", new DynamicParameters());
            }
        }
        internal static void NewProject(string project_name)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Execute($@"INSERT INTO rjo_project (project_name) VALUES('{project_name}')", new DynamicParameters());
            }
        }
        internal static void UpdateProject(int old_person_id, string new_person_name)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Execute($@"UPDATE rjo_project SET project_name ='{new_person_name}' WHERE id ={old_person_id}", new DynamicParameters());
            }
        }
        internal static void UpdatePerson(int hourClocked, int input)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Execute($@"UPDATE rjo_project_person SET hours ={hourClocked} WHERE id ={input}", new DynamicParameters());
            }
        }

        internal static void UpdateHours(int id, int hours)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                cnn.Execute($@"UPDATE rjo_project_person SET hours ={hours} WHERE id ={id}", new DynamicParameters());
            }
        }
        internal static List<ProjectPersonModel> ProjectPeople(int who)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ProjectPersonModel>($"SELECT rjo_project_person.id, rjo_project_person.project_id, rjo_project_person.person_id,rjo_person.person_name,rjo_project_person.person_id,rjo_project.project_name,rjo_project_person.hours FROM rjo_project_person JOIN rjo_project ON rjo_project_person.project_id = rjo_project.id JOIN rjo_person ON rjo_project_person.person_id = rjo_person.id WHERE person_id = {who}", new DynamicParameters());
                return output.ToList();
            }
        }
    }
}