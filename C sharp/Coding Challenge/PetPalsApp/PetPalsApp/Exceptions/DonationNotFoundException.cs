using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPalsApp.Exceptions
{
    public class DonationNotFoundException : Exception
    {
        public DonationNotFoundException(int donationId)
            : base($"Donation with ID {donationId} was not found.") { }
    }
}
