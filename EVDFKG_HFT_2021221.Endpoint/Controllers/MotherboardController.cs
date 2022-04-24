using Microsoft.AspNetCore.Mvc;
using EVDFKG_HFT_2021221.Logic;
using EVDFKG_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVDFKG_HFT_2021221.Endpoint.Services;
using Microsoft.AspNetCore.SignalR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EVDFKG_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MotherboardController : ControllerBase
    {
        IMotherboardLogic iml;
        IHubContext<SignalRHub> hub;

        public MotherboardController(IMotherboardLogic iml, IHubContext<SignalRHub> hub)
        {
            this.iml = iml;
            this.hub=hub;
        }

        [HttpGet]
        public IEnumerable<Motherboard> Get()
        {
            return iml.ReadAll();
        }

        [HttpGet("{id}")]
        public Motherboard Get(int id)
        {
            return iml.ReadOne(id);
        }

        [HttpPost]
        public void Post([FromBody] Motherboard value)
        {
            iml.Create(value);
            hub.Clients.All.SendAsync("MotherboardCreated", value);
        }

        [HttpPut]
        public void Put([FromBody] Motherboard value)
        {
            iml.Update(value);
            hub.Clients.All.SendAsync("MotherboardUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var motherboardToDelete = this.iml.ReadOne(id);
            iml.Delete(id);
            hub.Clients.All.SendAsync("DeletedMotherboard", motherboardToDelete);
        }
    }
}
