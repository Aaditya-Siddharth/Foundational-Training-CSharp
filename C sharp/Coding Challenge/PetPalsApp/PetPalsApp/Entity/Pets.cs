using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PetPalsApp.Entity
{
    public class Pets
    {
        public int PetID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Breed { get; set; }
        public string Type { get; set; }
        public bool AvailableForAdoption { get; set; }
        public int? OwnerID { get; set; }
        public int? ShelterID { get; set; }
        
    }
}
