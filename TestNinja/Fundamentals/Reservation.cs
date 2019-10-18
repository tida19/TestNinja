using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Fundamentals
{
    public class Reservation
    {
        public User Madeby { get; set; }
        public bool CanBeCancelledBy(User user)
        {
            if (user.IsAdmin)
                return true;

            if (Madeby == user)
                return true;
            return false;
        }

        public object CanBeCancellBy(User user)
        {
            throw new NotImplementedException();
        }
    }

    public class User
    {
        public bool IsAdmin { get; set; }
    }
}
