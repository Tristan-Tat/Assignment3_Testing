using Npgsql;
using Assignment3_Connection.Models;

namespace Assignment3_Connection
{
    public class DatabaseConnection
    {

        private static NpgsqlConnection connect()
        {
            String connectionString = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=081892;";
            return new NpgsqlConnection(connectionString);
        }

        // insert
        public static Response insertProduct(Product product)
        { 
            Response res = new Response();
            try 
            { 
                NpgsqlConnection con = connect();
                string statement = "INSERT INTO products (name, id, amount, price) VALUES (@name, @id, @amount, @price);";
                NpgsqlCommand cmd = new NpgsqlCommand(statement, con);
                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@id", product.Id);
                cmd.Parameters.AddWithValue("@amount", product.Weight);
                cmd.Parameters.AddWithValue("@price", product.Price);

                con.Open();
                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                {
                    res.statusCode = 200;
                    res.message = "Successfully inserted product.";
                }
                else
                {
                    res.statusCode = 100;
                    res.message = "Failed to insert product.";
                }
            } 
            catch (NpgsqlException e) 
            {
                res.statusCode = 100;
                res.message = e.StackTrace;
            }

            return res;
        }

        // update
        public static Response updateProduct(Product product)
        {
            Response res = new Response();
            try
            {
                NpgsqlConnection con = connect();
                string statement = "UPDATE products SET name = @name, amount = @amount, price = @price WHERE id = @id";
                NpgsqlCommand cmd = new NpgsqlCommand(statement, con);
                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@id", product.Id);
                cmd.Parameters.AddWithValue("@amount", product.Weight);
                cmd.Parameters.AddWithValue("@price", product.Price);

                con.Open();
                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                {
                    res.statusCode = 200;
                    res.message = "Successfully updated product.";
                }
                else
                {
                    res.statusCode = 100;
                    res.message = "Failed to update product.";
                }
            }
            catch (NpgsqlException e)
            {
                res.statusCode = 100;
                res.message = e.StackTrace;
            }

            return res;
        }

        // delete
        public static Response deleteProduct(int id)
        {
            Response res = new Response();
            try
            {
                NpgsqlConnection con = connect();
                string statement = "DELETE FROM products WHERE id = @id";
                NpgsqlCommand cmd = new NpgsqlCommand(statement, con);
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                {
                    res.statusCode = 200;
                    res.message = "Successfully deleted product.";
                }
                else
                {
                    res.statusCode = 100;
                    res.message = "Failed to delete product.";
                }
            }
            catch (NpgsqlException e)
            {
                res.statusCode = 100;
                res.message = e.StackTrace;
            }

            return res;
        }

        public static Response getProduct(Product product) 
        {
            Response res = new Response();
            try
            {
                NpgsqlConnection con = connect();
                string statement = "SELECT * FROM products WHERE id = @id AND name = @name AND amount = @amount AND price = @price";
                NpgsqlCommand cmd = new NpgsqlCommand(statement, con);
                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@id", product.Id);
                cmd.Parameters.AddWithValue("@amount", product.Weight);
                cmd.Parameters.AddWithValue("@price", product.Price);

                con.Open();
                NpgsqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    res.statusCode = 200;
                    res.message = "Successfully queried product.";
                }
                else
                {
                    res.statusCode = 100;
                    res.message = "Failed to query product.";
                }
            }
            catch (NpgsqlException e)
            {
                res.statusCode = 100;
                res.message = e.StackTrace;
            }
            return res;

        }


    }
}
