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
        private readonly MotorDbContext _context;

        public VehiclesController(MotorDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Vehicle>> Get()
        {
            var vehicles = _context.Vehicles.ToList();
            return vehicles;
        }

        [HttpPost]
        public void Post([FromBody] Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put([FromRoute(Name ="id")] long id,[FromBody] Vehicle vehicle)
        {
            var current = _context.Vehicles.Find(id);
            ReflectionHelper.CopyPropertiesTo(vehicle, current, false);
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete([FromRoute(Name ="id")] long id)
        {
            var current = _context.Vehicles.Find(id);
            _context.Vehicles.Remove(current);
            _context.SaveChanges();
        }
    }
}