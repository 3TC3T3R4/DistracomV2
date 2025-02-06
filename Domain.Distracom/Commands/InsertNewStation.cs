using Domain.Distracom.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Distracom.Commands
{
    public class InsertNewStation
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Ubication { get; set; }
        public string Type { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
