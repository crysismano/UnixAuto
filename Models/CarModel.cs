using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnixAuto.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public int ModelDetailId { get; set; }
        public ModelDetail ModelDetail { get; set; }
        [Required]
        public int CarManufacturerId { get; set; }
        public CarManufacturer CarManufacturer { get; set; }
    }
}
