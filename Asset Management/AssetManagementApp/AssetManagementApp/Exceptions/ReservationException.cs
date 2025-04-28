using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementApp.Exceptions
{
    public class ReservationException : Exception
    {
        public ReservationException() : base("An error occurred during reservation.") { }

        public ReservationException(string message) : base(message) { }
    }
}
