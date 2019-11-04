using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace motor.core.Models
{
    [Table("vehicles")]
    public class Vehicle
    {
        [Key]
        public long Id { get; set; }

        [Required,Column("name",TypeName ="varchar(50)")]
        public string Name { get; set; }
    }
}
