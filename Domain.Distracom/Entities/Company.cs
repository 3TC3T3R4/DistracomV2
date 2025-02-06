using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Domain.Distracom.Entities
{
       
        public class Company
        {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int CompanyId { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public int Tel { get; set; }
            public string Email { get; set; }
            [JsonIgnore]
            public ICollection<Station> Stations { get; set; }
        }
    }

