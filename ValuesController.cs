using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TodoList
{
    [Route("api/values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static Dictionary<string, List<string>> Portfolios = new Dictionary<string, List<string>>()
        {
            { "Antonio", new List<string> { "EXSA" } },
            { "Andrei", new List<string> { "VWCE" } }
        };

        [HttpGet]
        public List<string> Portfolio(string id)
        {
            if (Portfolios.ContainsKey(id))
            {
                return Portfolios[id];
            }
            return new List<string>();
        }

        [HttpPost]
        public void UpdatePortfolio(string id) 
        {
            
        }
    }
}
