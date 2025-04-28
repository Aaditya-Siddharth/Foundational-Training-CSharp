using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPalsApp.Exceptions
{
    public class ParticipantNotFoundException : Exception
    {
        public ParticipantNotFoundException(int participantId)
            : base($"Participant with ID {participantId} was not found.") { }
    }
}
