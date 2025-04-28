using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPalsApp.Entity
{
    public class Donation
    {
        public int DonationID { get; set; }
        public string DonorName { get; set; }
        public string DonationType { get; set; }
        public decimal? DonationAmount { get; set; }
        public string? DonationItem { get; set; }
        public DateTime DonationDate { get; set; }
        public int? ShelterID { get; set; }
    }
}
