using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPalsApp.Exceptions
{
    public class ShelterNotFoundException : Exception
    {
        public ShelterNotFoundException(int shelterId)
            : base($"Shelter with ID {shelterId} was not found.") { }
    }
}
