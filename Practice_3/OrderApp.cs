using System;
using System.Data.SqlClient;

class OrderApp
{
    static void Main()
    {
        Console.Write("Enter Order ID: ");
        string input = Console.ReadLine();
        if (int.TryParse(input, out int orderId))
        {
            GetOrderSummary(orderId);
        }
        else
        {
            Console.WriteLine("Invalid Order ID.");
        }
    }

    static void GetOrderSummary(int orderId)
    {
        string connStr = @"Server=PRODUCT-TECH\SQLEXPRESS;Database=ShopDB;Trusted_Connection=True;";
        string query = @"SELECT ProductName, Quantity, UnitPrice, Discount 
                         FROM Orders WHERE OrderId = @OrderId";

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@OrderId", orderId);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            decimal total = 0;
            Console.WriteLine("\nOrder Summary:");
            while (reader.Read())
            {
                decimal price = Convert.ToDecimal(reader["UnitPrice"]);
                int qty = Convert.ToInt32(reader["Quantity"]);
                decimal discount = Convert.ToDecimal(reader["Discount"]);
                decimal lineTotal = (price * qty) - discount;

                total += lineTotal;
                Console.WriteLine($"{reader["ProductName"]} - Qty: {qty}, Price: {price}, Line Total: {lineTotal}");
            }

            Console.WriteLine($"\nTotal Amount: {total}");
            reader.Close();
        }
    }
}
