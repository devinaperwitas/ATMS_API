using ATMS_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ATMS_API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class JenisAlatController : ControllerBase
    {
        private readonly JenisAlat _jenisalatRepository;
        ResponseModel response = new ResponseModel();

        public JenisAlatController(IConfiguration configuration)
        {
            _jenisalatRepository = new JenisAlat(configuration);
        }

        [HttpGet("/GetAllJenisAlat", Name = "GetAllJenisAlat")]
        public IActionResult GetAllJenisAlat()
        {
            /*  try
              {
                  response.status = 200;
                  response.message = "Success";
                  response.data = _JenisAlatRepository.getAllData();
              }catch (Exception ex)
              {
                  response.status = 500;
                  response.message = "Failed";
              }
              return Ok(response);*/
            return Ok(_jenisalatRepository.getAllData());
        }

        [HttpGet("/GetJenisAlat", Name = "GetJenisAlat")]
        public IActionResult GetJenisAlat(int id)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _jenisalatRepository.getData(id);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed" + ex;
            }
            return Ok(response);
        }

        [HttpPost("/InsertJenisAlat", Name = "InsertJenisAlat")]
        public IActionResult InsertJenisAlat([FromBody] JenisAlatModel jenisalatModel)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                _jenisalatRepository.insertData(jenisalatModel);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed" + ex;
            }
            return Ok(response);
        }

        [HttpPut("/UpdateJenisAlat", Name = "UpdateJenisAlat")]
        public IActionResult UpdateJenisAlat([FromBody] JenisAlatModel JenisAlatModel)
        {

            JenisAlatModel jenisalat = new JenisAlatModel();
            jenisalat.id = JenisAlatModel.id;
            jenisalat.jen_nama = JenisAlatModel.jen_nama;

            try
            {
                response.status = 200;
                response.message = "Success";
                _jenisalatRepository.updateData(jenisalat);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed" + ex;
            }
            return Ok(response);
        }

        [HttpDelete("/DeleteJenisAlat", Name = "DeleteJenisAlat")]
        public IActionResult DeleteJenisAlat(int id)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                _jenisalatRepository.deleteData(id);
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
