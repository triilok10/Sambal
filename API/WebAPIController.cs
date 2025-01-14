using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sambal.Models;

namespace Sambal.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WebAPIController : ControllerBase
    {
        #region "Connection String"
        private readonly string _connectionString;

        public WebAPIController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("CustomConnection");

        }
        #endregion

        [HttpPost]
        public Web AddCategory([FromBody] Web pWeb)
        {
            Web obj = new Web();
            return obj;
        }
    }
}
