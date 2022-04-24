using EVDFKG_HFT_2021221.Endpoint.Services;
using EVDFKG_HFT_2021221.Logic;
using EVDFKG_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        IHubContext<SignalRHub> hub;

        public ComboController(IComboLogic icl, IHubContext<SignalRHub> hub)
        {
            this.icl = icl;
            this.hub = hub;
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
            hub.Clients.All.SendAsync("ComboCreated", value);
        }

        // PUT api/<ComboController>/5
        [HttpPut]
        public void Put([FromBody] Combo value)
        {
            icl.Update(value);
            hub.Clients.All.SendAsync("ComboUpdated", value);
        }

        // DELETE api/<ComboController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var comboToDelete = this.icl.ReadOne(id);
            icl.Delete(id);
            hub.Clients.All.SendAsync("ComboDeleted", comboToDelete);
        }

        [Route("crsa")]
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> crsa()
        {
            return icl.CpuRamSpeedAverage();
        }
        [Route("mcca")]
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> mcca()
        {
            return icl.MotherboardCpuCoreAverage();
        }
        [Route("rcsa")]
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> rcsa()
        {
            return icl.RamCpuSpeedAverage();
        }
        [Route("crrsa")]
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> crrsa()
        {
            return icl.CpuRAMSlotAverage();
        }
        [Route("crta")]
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> crta()
        {
            return icl.RamCPUThreadAverage();
        }
    }
}
