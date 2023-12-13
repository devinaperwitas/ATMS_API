using ATMS_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ATMS_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlatController : ControllerBase
    {
        private readonly Alat _alatRepository;
        ResponseModel response = new ResponseModel();

        public AlatController(IConfiguration configuration)
        {
            _alatRepository = new Alat(configuration);
        }

        [HttpGet("/GetAllAlat", Name = "GetAllAlat")]
        public IActionResult GetAllAlat()
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _alatRepository.GetAllData();
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed" + ex;
            }
            return Ok(response);
        }

        [HttpGet("/GetAlat", Name = "GetAlat")]
        public IActionResult GetAlat(int id)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _alatRepository.GetData(id);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed" + ex;
            }
            return Ok(response);
        }

        [HttpPost("/InsertAlat", Name = "InsertAlat")]
        public IActionResult InsertAlat([FromBody] AlatModel alatModel)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                _alatRepository.InsertData(alatModel);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed" + ex;
            }
            return Ok(response);
        }

        [HttpPut("/UpdateAlat", Name = "UpdateAlat")]
        public IActionResult UpdateAlat([FromBody] AlatModel alatModel)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                _alatRepository.UpdateData(alatModel);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed" + ex;
            }
            return Ok(response);
        }

        [HttpDelete("/DeleteAlat", Name = "DeleteAlat")]
        public IActionResult DeleteAlat(int id)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                _alatRepository.DeleteData(id);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed" + ex;
            }
            return Ok(response);
        }
    }
}
