using PetPalsApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPalsApp.DAO
{
    public interface IPetsDao<T>
    {
        T SavePetInfo(T pet);
        bool DeletePetInfo(int petID);
        T UpdatePetInfo(T pet);
        T GetPetInfoByID(int petID);
        List<T> GetAllPets();
    }
}
