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
    public class CpuController : ControllerBase
    {
        ICpuLogic icl;

        public CpuController(ICpuLogic icl)
        {
            this.icl = icl;
        }

        // GET: /cpu
        [HttpGet]
        public IEnumerable<CPU> Get()
        {
            return icl.ReadAll();
        }

        // GET /cpu/1
        [HttpGet("{id}")]
        public CPU Get(int id)
        {
            return icl.ReadOne(id);
        }

        // POST /cpu
        [HttpPost]
        public void Post([FromBody] CPU value)
        {
            icl.Create(value);
        }

        // PUT /cpu
        [HttpPut]
        public void Put([FromBody] CPU value)
        {
            icl.Update(value);
        }

        // DELETE /car/1
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            icl.Delete(id);
        }
    }
}
