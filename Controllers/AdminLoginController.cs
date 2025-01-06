using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Sambal.Models;

namespace Sambal.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminLoginController : ControllerBase
    {


        #region "Connection String"
        private readonly string _connectionString;

        public AdminLoginController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("CustomConnection");

        }
        #endregion

        [HttpPost]
        public IActionResult AdminLoginAPI([FromBody] Login pLogin)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("usp_AdminLogin", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                }
            }
            catch (Exception ex) { }
            return Ok();

        }
    }
}
