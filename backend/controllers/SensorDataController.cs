using Microsoft.AspNetCore.Mvc;

namespace iJerkPro.Controllers{
    [ApiController]
    [Route("[Controller]")]
    public class SensorDataController : ControllerBase
    {
        private readonly SensorDataCache _cache;

        public SensorDataController(SensorDataCache cache)
        {
            this._cache = cache;
        }
        
        [HttpPost]
        public IActionResult CreateSensorData([FromBody] JerkModel jerks)
        {
            if(jerks == null){
                return BadRequest();
            }

            _cache.AddSensorData(jerks);
            return Ok(jerks);
        }

        [HttpGet]

        public IActionResult GetSensorData(){
            var allData = _cache.GetAllSensorData();
                
            return Ok(allData);
        }
    } 
}