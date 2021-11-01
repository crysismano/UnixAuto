using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnixAuto.Models
{
    public class CarManufacturer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<CarModel> CarModels { get; set; }
    }
}
