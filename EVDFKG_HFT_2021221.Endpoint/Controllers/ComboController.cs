using EVDFKG_HFT_2021221.Logic;
using EVDFKG_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EVDFKG_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ComboController : ControllerBase
    {
        IComboLogic icl;

        public ComboController(IComboLogic icl)
        {
            this.icl = icl;
        }

        // GET: api/<ComboController>
        [HttpGet]
        public IEnumerable<Combo> Get()
        {
            return icl.ReadAll();
        }

        // GET api/<ComboController>/5
        [HttpGet("{id}")]
        public Combo Get(int id)
        {
            return icl.ReadOne(id);
        }

        // POST api/<ComboController>
        [HttpPost]
        public void Post([FromBody] Combo value)
        {
            icl.Create(value);
        }

        // PUT api/<ComboController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Combo value)
        {
            icl.Update(value);
        }

        // DELETE api/<ComboController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            icl.Delete(id);
        }

        [Route("crsa")]
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> crsa()
        {
            return icl.CpuRamSpeedAverage();
        }
        [Route("ids")]
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> ids()
        {
            return icl.LastIds();
        }
    }
}
