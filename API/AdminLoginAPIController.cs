using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Sambal.Models;

namespace Sambal.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminLoginAPIController : ControllerBase
    {


        #region "Connection String"
        private readonly string _connectionString;

        public AdminLoginAPIController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("CustomConnection");

        }
        #endregion

        [HttpPost]
        public IActionResult AdminLogin([FromBody] Login pLogin)
        {
            Login obj = new Login();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("usp_AdminLogin", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Mode", 1);
                    cmd.Parameters.AddWithValue("@Username", pLogin.Username);
                    cmd.Parameters.AddWithValue("@Password", pLogin.Password);

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            obj.Status = Convert.ToBoolean(rdr["Status"]);

                            if (obj.Status == false)
                            {
                                obj.ErrMsg = Convert.ToString(rdr["ErrMsg"]);
                            }
                            else
                            {
                                obj.AdminDetailID = Convert.ToInt32(rdr["AdminDetailID"]);
                                obj.Username = Convert.ToString(rdr["Username"]);
                                obj.IsSystemUser = Convert.ToBoolean(rdr["IsSystemUser"]);
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                obj.Status = false;
                obj.ErrMsg = ex.Message;
            }
            return Ok(obj);

        }
    }
}
