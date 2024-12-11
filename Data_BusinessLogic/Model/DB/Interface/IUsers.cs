using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_BusinessLogic.DB.Interface
{
    public interface IUsers
    {
        int UserID { get; }
        string Fio { get; set; }
        string Phone { get; set; }
        string C_Login { get; set; }
        string C_Password { get; set; }
        int C_Type { get; set; }
    }
}
