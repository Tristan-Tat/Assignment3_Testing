using Microsoft.AspNetCore.Mvc;
using Assignment3_Connection.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment3_Connection
{
    [Route("api/[controller]")]
    [ApiController]
    public class RESTController : ControllerBase
    {
        [HttpPost("Insert")]
        public Response insertProduct(Product product)
        {
            return DatabaseConnection.insertProduct(product);
        }

        [HttpPut("Update")]
        public Response updateProduct(Product product)
        {
            return DatabaseConnection.updateProduct(product);
        }

        [HttpPost("Delete")]
        public Response deleteProduct(int id)
        {
            return DatabaseConnection.deleteProduct(id);
        }
    }
}
