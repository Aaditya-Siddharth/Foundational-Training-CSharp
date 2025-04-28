using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPalsApp.Exceptions
{
    public class AdoptionEventNotFoundException : Exception
    {
        public AdoptionEventNotFoundException(int eventId)
            : base($"Adoption event with ID {eventId} was not found.") { }
    }
}
