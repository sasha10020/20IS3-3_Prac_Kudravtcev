using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace prac_kudravtcev.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{index}")]
        public string Get1(int index)
        {
            if (index < 0 || index >= Summaries.Count())
            {
                return "Нет такого индекса";
            }
            return Summaries[index];
        }
        [HttpGet]
        public List<string> Get(int? sortSrategy)
        {
            if (sortSrategy == null)
            return Summaries;
            if (sortSrategy == 1)
            {
                Summaries.Sort();
                return Summaries;
            }
            if (sortSrategy == -1)
            {
                Summaries.Sort();
                Summaries.Reverse();
                return Summaries;
            }
            List<string> ls = new List<string>() ;
            ls.Add("Некорректное значение параметра sortStrategy");
            return ls ;
        }
        [HttpGet("find-by-name")]
        public int Get(string name)
        {
            int j = 0;
            for (int i = 0; i<Summaries.Count-1; i++)
            { 
                if (Summaries[i] == name)
                    j++;
            }
            return j;
        }


        [HttpPost]
        public IActionResult Add(string name)
        {
            if (name == null)
            {
                return BadRequest("Вы ввели пустую строку");
            }
            Summaries.Add(name);
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(int index,string name)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Такой индекс неверный (");
            }
                
            Summaries[index]= name;
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int index)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Такого индекса нет (((");
            }
            Summaries.RemoveAt(index);
            return Ok();
        }
    }
}