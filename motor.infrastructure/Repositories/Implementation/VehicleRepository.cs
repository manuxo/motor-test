using System;
using System.Collections.Generic;
using System.Text;
using motor.core.Models;
using motor.infrastructure.Database;

namespace motor.infrastructure.Repositories.Implementation
{
    public class VehicleRepository : Repository<Vehicle,int>,IVehicleRepository
    {
        public VehicleRepository(MotorDbContext _context): base(_context)
        {

        }
    }
}
