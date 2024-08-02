using BibleBLL;
using BibleEnteties;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BibleController : ControllerBase
    {
        [HttpGet]
        [Route("getExcactLocationbyName/{name}")]

        public List<string> GetLocation(string name)
        {
            ClassBLL b = new ClassBLL();
            return b.findExactLocation(name);
        }
        

        [HttpGet]
        [Route("getIndexbyName/{name}")]
         
        public List<int> GetbyName(string name)
        {
            ClassBLL b = new ClassBLL();
            return b.SearchWordIndexes(name);
        }
        [HttpGet]
        [Route("getPopleIntraction/{name}")]
        public List<string> findIntractuon(string name)
        {
            ClassBLL b = new ClassBLL();
            return b.findIntractuon(name);
        }
       
        //[HttpGet("SearchByPrefix")]
        //public List<string> SearchByPrefix(string name)
        //{
        //    ClassBLL b = new ClassBLL();
        //    return b.SearchByPrefix(name);
        //}

       
    }
}
