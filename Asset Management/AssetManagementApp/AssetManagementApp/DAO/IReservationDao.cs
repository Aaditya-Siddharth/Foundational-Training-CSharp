using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementApp.DAO
{
    public interface IReservationDao<T>
    {
        T CreateReservation(T reservation);
        bool CancelReservation(int reservation_id);
        T UpdateReservation(T reservation);
        T GetReservationById(int reservation_id);
        List<T> GetAllReservations();
    }
}
