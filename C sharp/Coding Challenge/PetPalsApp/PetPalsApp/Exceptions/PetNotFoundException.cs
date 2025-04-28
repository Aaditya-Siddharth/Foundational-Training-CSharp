using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPalsApp.Exceptions
{
    public class PetNotFoundException : Exception
    {
        public PetNotFoundException(int petId)
            : base($"Pet with ID {petId} was not found.") { }
    }
}
