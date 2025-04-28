using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPalsApp.DAO
{
    
    public interface ISheltersDao<T>
    {
        T SaveShelterInfo(T shelter);
        bool DeleteShelterInfo(int shelterID);
        T UpdateShelterInfo(T shelter);
        T GetShelterInfoByID(int shelterID);
        List<T> GetAllShelters();
    }
}
