using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPalsApp.DAO
{
    public interface IDonationsDao<T>
    {
        T SaveDonationInfo(T donation);
        bool DeleteDonationInfo(int donationID);
        T UpdateDonationInfo(T donation);
        T GetDonationInfoByID(int donationID);
        List<T> GetAllDonations();
    }
}
