using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using NUnit.Framework.Internal;
using NUnit.Framework;
using System.Buffers.Text;
using System.Diagnostics.Metrics;
using System.Runtime.Intrinsics.X86;
using Assignment3_Connection;
using Assignment3_Connection.Models;

namespace Assignment3_Testing
{
    public class Tests
    {

        Product product1 = new Product(111, "TestProduct1", 20, 20.0M);
        Product product2 = new Product(222, "TestProduct2", 30, 30.0M);
        RESTClient client = new RESTClient();

        // 1. You need to develop test methods for testing the database insertion properties.The method will
        //    first try to add the data using ADO connection and will verify whether the data is inserted properly
        //    (you can retrieve the entry from the table using SELECT queries and perform assert operation).
        //    After that, you have to insert another data using REST API in the database.You can perform assert
        //    testing again for this operation in one of two ways: i.use SELECT queries followed by assert
        //    operation, ii.Extract the response message code and use assert method to test the response
        //    message code.

        [Test, Order(1)]
        public void InsertADO_Test() 
        {
            DatabaseConnection.insertProduct(product1);

            Response res = DatabaseConnection.getProduct(product1);
            Assert.That(res.message, Is.EqualTo("Successfully queried product."));
        }

        [Test, Order(2)]
        public void InsertREST_Test() 
        { 
            RESTClient client = new RESTClient();
            client.insertProduct(product2).GetAwaiter().GetResult();

            Response res = DatabaseConnection.getProduct(product2);
            Assert.That(res.message, Is.EqualTo("Successfully queried product."));
        }

        // 2. You need to develop test methods for testing database update properties. The method will first
        //    update the table using ADO connection and will verify the updated information using SELECT
        //    queries followed by assertion testing.After that, you have to update the table with another value.
        //    But instead of ADO connection, this time you are going to update the table with REST API.After
        //    update operation, you have to verify the update operation by performing assertion testing on the
        //    updated data.Like ADO based database connection, for testing the REST API based update
        //    operation you can use the SELECT query-based assertion test.

        [Test, Order(3)]
        public void UpdateADO_Test() 
        {
            product1.Name = "TestProduct1_Updated";
            product1.Weight = 19;
            product1.Price = 10.0M;

            DatabaseConnection.updateProduct(product1);

            Response res = DatabaseConnection.getProduct(product1);
            Assert.That(res.message, Is.EqualTo("Successfully queried product."));
        }

        [Test, Order(4)]
        public void UpdateREST_Test() 
        {
            product2.Name = "TestProduct2_Updated";
            product2.Weight = 29;
            product2.Price = 20.0M;

            
            client.updateProduct(product2).GetAwaiter().GetResult();

            Response res = DatabaseConnection.getProduct(product2);
            Assert.That(res.message, Is.EqualTo("Successfully queried product."));
        }

        // 3. You need to develop test methods for DELETE operation, for both ADO based database operation
        //    and REST API based database operation.For this, like previous steps, you can use SELECT query to
        //    verify the non-existence of the deleted data in the table.

        [Test, Order(5)]
        public void DeleteADO_Test() 
        {
            DatabaseConnection.deleteProduct(product1.Id);

            Response res = DatabaseConnection.getProduct(product1);
            Assert.That(res.message, Is.EqualTo("Failed to query product."));
        }

        [Test, Order(6)]
        public void DeleteREST_Test() 
        {
            
            client.deleteProduct(product2.Id).GetAwaiter().GetResult();

            Response res = DatabaseConnection.getProduct(product2);
            Assert.That(res.message, Is.EqualTo("Failed to query product."));
        }
    }
}