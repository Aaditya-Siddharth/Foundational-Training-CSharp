using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPalsApp.DAO
{

    public interface IAdoptionEventsDao<T>
    {
        T SaveAdoptionEventInfo(T adoptionEvent);
        bool DeleteAdoptionEventInfo(int eventID);
        T UpdateAdoptionEventInfo(T adoptionEvent);
        T GetAdoptionEventInfoByID(int eventID);
        List<T> GetAllAdoptionEvents();
    }
}
