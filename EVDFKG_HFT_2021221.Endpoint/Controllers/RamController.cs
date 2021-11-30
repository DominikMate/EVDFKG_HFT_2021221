using Microsoft.AspNetCore.Mvc;
using EVDFKG_HFT_2021221.Logic;
using EVDFKG_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EVDFKG_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RamController : ControllerBase
    {
        IRamLogic irl;

        public RamController(IRamLogic irl)
        {
            this.irl = irl;
        }

        [HttpGet]
        public IEnumerable<RAM> Get()
        {
            return irl.ReadAll();
        }


        [HttpGet("{id}")]
        public RAM Get(int id)
        {
            return irl.ReadOne(id);
        }


        [HttpPost]
        public void Post([FromBody] RAM value)
        {
            irl.Create(value);
        }


        [HttpPut("{id}")]
        public void Put([FromBody] RAM value)
        {
            irl.Update(value);
        }



        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            irl.Delete(id);
        }
    }
}
