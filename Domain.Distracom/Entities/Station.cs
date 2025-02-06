using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Distracom.Entities
{
    
        public class Station
        {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StationId { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string Ubication { get; set; }
            public string Type { get; set; }
            public int CompanyId { get; set; }
            public Company Company { get; set; }
        }
    }
