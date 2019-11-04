using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using motor.core.Models;
using motor.infrastructure.Database;
using motor.infrastructure.Repositories;
using motor.infrastructure.Repositories.Implementation;
using motor.infrastructure.Util;

namespace motor.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleRepository _service;

        public VehiclesController(IVehicleRepository repository)
        {
            _service = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Vehicle>> Get()
        {
            return _service.List();
        }

        [HttpGet("{id}")]
        public ActionResult<Vehicle> Find([FromRoute(Name ="id")] int id)
        {
            return _service.Find(id);
        }

        [HttpPost]
        public void Post([FromBody] Vehicle vehicle)
        {
            _service.Add(vehicle);
        }

        [HttpPut("{id}")]
        public void Put([FromRoute(Name ="id")] int id,[FromBody] Vehicle vehicle)
        {
            _service.Update(id, vehicle);
        }

        [HttpDelete("{id}")]
        public void Delete([FromRoute(Name ="id")] int id)
        {
            _service.Delete(id);
        }
    }
}