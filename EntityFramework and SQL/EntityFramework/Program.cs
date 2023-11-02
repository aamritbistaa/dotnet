using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EntityFramework
{

    //code first

    public class Post
    {
        public int Id { get; set; }
        public DateTime DataPublished { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

    }
    public class testData
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    //public class BlogDbContext : DbContext
    //{
    //    public DbSet<Post> Posts { get; set; }
    //    public DbSet<testData> testDatas { get; set; }
    //}

    internal class Program
    {

        public void Add(string connectionDetail)
        {
            SqlConnection connection = new SqlConnection(connectionDetail);
            try
            {
                connection.Open();
                Console.WriteLine("Title: ");
                string title = Console.ReadLine();
                Console.WriteLine("Body: ");
                string body = Console.ReadLine();
                string query = "INSERT INTO [dbo].[Posts] ([DataPublished],[Title],[Body]) VALUES('" + DateTime.Now + "','" + title + "','" + body + "');";
                Console.WriteLine(query);
                SqlCommand commandinsert = new SqlCommand(query, connection);
                commandinsert.ExecuteNonQuery();
                Console.WriteLine("Item inserted");
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Update(string connectionDetail)
        {
            SqlConnection connection = new SqlConnection(connectionDetail);
            try
            {
                connection.Open();
                DisplayAll(connectionDetail);
                Console.WriteLine("\r\n Enter the detail of the record you want to ipload");
                Console.WriteLine("ID to be changed: ");
                int id = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Title: ");
                string title = Console.ReadLine();
                Console.WriteLine("Body: ");
                string body = Console.ReadLine();
                string query = "update Posts set title='" + title + "',body='" + body + "' where ID ='" + id + "'";
                SqlCommand commandupdate = new SqlCommand(query, connection);
                commandupdate.ExecuteNonQuery();
                Console.WriteLine("Updating query id: " + id);
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(string connectionDetail)
        {
            SqlConnection connection = new SqlConnection(connectionDetail);
            try
            {

                connection.Open();
                DisplayAll(connectionDetail);
                Console.WriteLine("Enter id of the record you want to delete");
                int id = Int32.Parse(Console.ReadLine());
                string query = "Delete from Posts where ID = '" + id + "'";
                SqlCommand commandupdate = new SqlCommand(query, connection);
                commandupdate.ExecuteNonQuery();
                Console.WriteLine("Delete query: id " + id);
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DisplayAll(string connectionDetail)
        {
            SqlConnection connection = new SqlConnection(connectionDetail);

            try
            {
                string query = @"select * from Posts";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    //Console.WriteLine(dr);
                    Console.WriteLine(dr.GetInt32(0));
                    Console.WriteLine(dr.GetDateTime(1));
                    Console.WriteLine(dr.GetString(2));
                    Console.WriteLine(dr.GetString(3));
                }
                dr.Close();

                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void Main(string[] args)
        {
            #region Entity Framework
            /*
            using (var context = new BlogDbContext())
            {
                bool exit = false;
                try
                {
                    int a = 10;
                    context.testDatas.Add(new testData{ Id = 1, Name = "ram" });
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                while (exit == false)
                {
                    Console.WriteLine("\r\n-----------\r\n" +
                        "Enter your choice: \r\n" +
                    "1. Add item\r\n" +
                    "2. Delete item\r\n" +
                    "3. Update item\r\n" +
                    "4. Display All\r\n" +
                    "5. Exit\r\n" +
                    "-----------\r\n");
                    string choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        //add
                        Console.WriteLine("enter title");
                        string title = Console.ReadLine();
                        Console.WriteLine("Enter body");
                        string body = Console.ReadLine();
                        context.Posts.Add(new Post { Title = title, Body = body, DataPublished = DateTime.Now });
                        context.SaveChanges();
                        Console.WriteLine("New item Added");
                    }

                    else if (choice == "2")
                    {
                        //remove element by id
                        foreach (var item in context.Posts)
                        {
                            Console.WriteLine("ID: " + item.Id + item.Title);
                        }
                        Console.WriteLine("Give user id to be deleted");
                        int id = Convert.ToInt32(Console.ReadLine()); 
                        var entity = context.Posts.Find(id);
                        context.Posts.Remove(entity);
                        context.SaveChanges();
                        Console.WriteLine("Item deleted");
                    }

                    else if (choice == "3")
                    {
                        //Update specific item by id
                        foreach (var item in context.Posts)
                        {
                            Console.WriteLine("ID: " + item.Id + item.Title + item.Body);
                        }
                        Console.WriteLine("Enter Id to be updated");
                        try
                        {
                            int id = Convert.ToInt32(Console.ReadLine());
                            var post = context.Posts.First(a => a.Id == id);

                            Console.WriteLine("enter title");
                            string title = Console.ReadLine();
                            post.Title = title;
                            Console.WriteLine("Enter body");
                            string body = Console.ReadLine();
                            post.Body = body;
                            context.SaveChanges();
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        
                    }

                    else if (choice == "4")
                    {   //display all
                        foreach (var item in context.Posts)
                        {
                            Console.WriteLine("Id: " + item.Id);
                            Console.WriteLine("Title: " + item.Title);
                            Console.WriteLine("Body: " + item.Body);
                            Console.WriteLine("Date Created: " + item.DataPublished);
                            Console.WriteLine("\r\n");
                        }
                    }

                    else if (choice == "5")
                    {
                        //exit
                        exit = true;
                    }
                    else
                    {
                        Console.WriteLine("Error choice \r\n");
                    }
                    Console.WriteLine("\r\n\r\n\r\n");
                }
            }
            */
            #endregion

            string connectionDetail = "data source=DESKTOP-F8B89L4; initial catalog=EntityFramework; integrated security=SSPI; persist security info=True";


            bool quitprogram = false;
            Program obj = new Program();
            while (quitprogram == false)
            {
                Console.WriteLine("-------" +
                "\r\nEnter your choice \r\n" +
                "1. Add Item\r\n" +
                "2. Update Item\r\n" +
                "3. Delete Item\r\n" +
                "4. Display All\r\n" +
                "5. Exit\r\n" +
                "\"-------\"");
                try
                {
                    int choice = Int32.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            obj.Add(connectionDetail);
                            break;
                        case 2:
                            obj.Update(connectionDetail);
                            break;
                        case 3:
                            obj.Delete(connectionDetail);
                            break;
                        case 4:
                            obj.DisplayAll(connectionDetail);
                            break;
                        case 5:
                            quitprogram = true;
                            break;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
