using Microsoft.EntityFrameworkCore;
using motor.core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace motor.infrastructure.Database
{
    public class MotorDbContext: DbContext
    {
        public MotorDbContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
