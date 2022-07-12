using DatabaseRecordCreationAPI.Common;
using DatabaseRecordCreationBLL.BLLInterfaces;
using DatabaseRecordCreationModels.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace DatabaseRecordCreationAPI.Controllers
{
   
    [ApiController]
    [Route("[controller]")]
    public class RecordCreationController : ControllerBase
    {
        public readonly IRecordCreationBLL _recordCreationBLL;
        public RecordCreationController(IRecordCreationBLL recordCreationBLL)
        {
            _recordCreationBLL = recordCreationBLL;
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllRecords()
        {

            string msg  = null;
            List<ConfigurationData> configurationData = new List<ConfigurationData>();
            configurationData = _recordCreationBLL.GetAllConfiguration(out msg);
            if (msg == null)
            {
                return Ok(configurationData);
            }
            else
            {
                return BadRequest(msg);
            }
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult InsertOrUpdateRecord(APIServiceRequest request)
        {
            try
            {
                APIServiceRequest objRequest = new APIServiceRequest();

                var reqList = JObject.Parse(request.BusinessData.ToString());
                var objConfigurationData = JsonConvert.DeserializeObject<ConfigurationData>(request.BusinessData.ToString());
                var result = _recordCreationBLL.InsertOrUpdateRecord(objConfigurationData);
                if (result == "save successfully" || result == "update successfully")
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
