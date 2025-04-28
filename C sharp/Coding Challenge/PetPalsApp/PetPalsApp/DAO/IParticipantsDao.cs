using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPalsApp.DAO
{
    public interface IParticipantsDao<T>
    {
        T SaveParticipantInfo(T participant);
        bool DeleteParticipantInfo(int participantID);
        T UpdateParticipantInfo(T participant);
        T GetParticipantInfoByID(int participantID);
        List<T> GetAllParticipants();
    }
}
