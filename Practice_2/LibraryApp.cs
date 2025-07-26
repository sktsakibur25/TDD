using System;
using System.Data.SqlClient;

class LibraryApp
{
    static void Main()
    {
        Console.Write("Enter Book ID: ");
        string input = Console.ReadLine();
        if (int.TryParse(input, out int bookId))
        {
            GetBook(bookId);
        }
        else
        {
            Console.WriteLine("Invalid Book ID.");
        }
    }

    static void GetBook(int bookId)
    {
        string connStr = @"Server=PRODUCT-TECH\SQLEXPRESS;Database=LibraryDB;Trusted_Connection=True;";
        string query = "SELECT Title, Author, Publisher, Year FROM Books WHERE BookId = @BookId";

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@BookId", bookId);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Console.WriteLine("\nBook Details:");
                Console.WriteLine($"Title     : {reader["Title"]}");
                Console.WriteLine($"Author    : {reader["Author"]}");
                Console.WriteLine($"Publisher : {reader["Publisher"]}");
                Console.WriteLine($"Year      : {reader["Year"]}");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
            reader.Close();
        }
    }
}
