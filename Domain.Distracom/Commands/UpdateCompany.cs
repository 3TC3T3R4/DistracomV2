using Domain.Distracom.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Distracom.Commands
{
    public class UpdateCompany
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Tel { get; set; }
        public string Email { get; set; }
        public List<Station> Stations { get; set; }
    }
}
