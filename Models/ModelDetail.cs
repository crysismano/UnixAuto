using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnixAuto.Models
{
    public class ModelDetail
    {
        public int Id { get; set; }
        [Required]
        public int YearOfManufacture { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Seats { get; set; }
        public CarModel CarModel { get; set; }

    }
}
