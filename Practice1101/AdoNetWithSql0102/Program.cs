using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AdoNetWithSql0102
{
    class Program
    {
        static void Main(string[] args)
        {
            //DESKTOP-7QBD7T4
            string nortwindConnectionString = ConfigurationManager.ConnectionStrings["NortwindConnection"].ConnectionString;
            string usersdbConnectionString = ConfigurationManager.ConnectionStrings["UserDBConnection"].ConnectionString;

            FirstTask(nortwindConnectionString);
            //SecondTask(nortwindConnectionString);
            //ThirdTask(nortwindConnectionString);
            //FourthTask(nortwindConnectionString);

            //CreateUserAndAddToDb(usersdbConnectionString);
            //ReadAllUsers(usersdbConnectionString);
            //UpdateUser(1, usersdbConnectionString);
            //DeleteUser(3, usersdbConnectionString);



            Console.ReadLine();
        }

        static void FirstTask(string connectionString)
        {
            string sqlExpression = "SELECT [EmployeeID],[LastName],[FirstName] " +
                "FROM[Northwind].[dbo].[Employees] " +
                "WHERE[City] = @City";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                //Create parametr
                string city = "London";
                SqlParameter parametr = new SqlParameter("@City", city);
                command.Parameters.Add(parametr);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string firstName = reader.GetString(1);
                        string lastName = reader.GetString(2);

                        Console.WriteLine("{0}\t{1}\t{2}", id, firstName, lastName);
                    }
                }

                reader.Close();
            }
        }

        static void SecondTask(string connectionString)
        {
            string sqlExpression = "SELECT TOP 1 COUNT(Distinct [Orders].[CustomerID]) as Count_Customers" +
                " FROM[Employees]" +
                " JOIN [Orders]" +
                " ON[Employees].[EmployeeID] = [Orders].[EmployeeID]" +
                " GROUP BY[Employees].[EmployeeID]" +
                " ORDER BY Count_Customers DESC ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                object count = command.ExecuteScalar();
                Console.WriteLine(count);
            }
        }

        static void ThirdTask(string connectionString)
        {
            string sqlExpression = "SELECT  [ShipCity]" +
                ", [ShipCountry]" +
                " FROM[Northwind].[dbo].[Orders]" +
                " GROUP BY[ShipCity], [ShipCountry]" +
                " HAVING COUNT([OrderID])> 2";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) 
                { 
                    Console.WriteLine("{0}\t{1}", reader.GetName(0), reader.GetName(1));

                    while (reader.Read())
                    {
                        string shopCity = reader.GetString(0);
                        string shopCountry = reader.GetString(1);

                        Console.WriteLine("{0}\t{1}", shopCity, shopCountry);
                    }
                }

                reader.Close();
            }
        }

        static void FourthTask(string connectionString)
        {
            string sqlExpression = "Select Distinct [ProductName]" +
                "FROM[Northwind].[dbo].[Products], [Northwind].[dbo].[Categories] " +
                "Where[UnitPrice] = " +
                "(SELECT MAX([UnitPrice]) " +
                "FROM[Northwind].[dbo].[Products], [Northwind].[dbo].[Categories] " +
                "Where[CategoryName] = @Seafood); ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                //Create parametr
                string categoryName = "Seafood";
                SqlParameter parametr = new SqlParameter("@Seafood", categoryName);
                command.Parameters.Add(parametr);
                object maxPrice = command.ExecuteScalar();
                Console.WriteLine(maxPrice);
            }
        }

        static void CreateUserAndAddToDb(string connectionString)
        {
            Console.WriteLine("Введите имя:");
            string name = Console.ReadLine();
            Console.WriteLine("Введите возраст:");
            int age = Int32.Parse(Console.ReadLine());
            string sqlExpression = String.Format("INSERT INTO Users (Name, Age) VALUES (@name, @age)");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                //name parametr
                SqlParameter nameParam = new SqlParameter("@name", name);
                command.Parameters.Add(nameParam);
                //age parametr
                SqlParameter ageParam = new SqlParameter("@age", age);
                command.Parameters.Add(ageParam);

                command.ExecuteNonQuery();
                Console.WriteLine("Добавлен объект");
            }
        }

        static void ReadAllUsers(string connectionString)
        {
            string sqlExpression = "SELECT * FROM[usersdb].[dbo].[Users]";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        int age = reader.GetInt32(2);

                        Console.WriteLine("{0}\t{1}\t{2}", id, name, age);
                    }
                }

                reader.Close();
            }
        }

        static void UpdateUser(int id, string connectionString)
        {
            Console.WriteLine("Введите новое имя:");
            string name = Console.ReadLine();
            Console.WriteLine("Введите возраст:");
            int age = Int32.Parse(Console.ReadLine());
            string sqlExpression = $"UPDATE Users SET Name=@name, Age=@age WHERE Id=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                //name parametr
                SqlParameter nameParam = new SqlParameter("@name", name);
                command.Parameters.Add(nameParam);
                //age parametr
                SqlParameter ageParam = new SqlParameter("@age", age);
                command.Parameters.Add(ageParam);
                //id parametr
                SqlParameter idParam = new SqlParameter("@id", id);
                command.Parameters.Add(idParam);

                command.ExecuteNonQuery();
                Console.WriteLine("Обновлен объект");
            }
        }

        static void DeleteUser(int id, string connectionString)
        {
            string sqlExpression = $"DELETE  FROM Users WHERE Id=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection); 
                SqlParameter idParam = new SqlParameter("@id", id);
                command.Parameters.Add(idParam);

                command.ExecuteNonQuery();
                Console.WriteLine("Удален объект");
            }
        }
    }
}
