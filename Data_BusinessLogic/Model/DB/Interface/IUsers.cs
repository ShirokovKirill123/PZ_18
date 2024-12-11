using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_BusinessLogic.DB.Interface
{
    public interface IUsers
    {
         int userID { get; }
         string fio { get; set; }
         string phone { get; set; }
         string C_login { get; set; }
         string C_password { get; set; }
         int C_type { get; set; }
    }
}
