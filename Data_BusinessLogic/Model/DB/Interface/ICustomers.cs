using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_BusinessLogic.Model.DB.Interface
{
    public interface ICustomers
    {
         int customerID { get; }
         System.DateTime registrationDate { get; set; }
         int userID { get; set; }
    }
}
