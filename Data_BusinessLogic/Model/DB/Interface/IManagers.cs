using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_BusinessLogic.Model.DB.Interface
{
    public interface IManagers
    {
         int managerID { get; }
         int userID { get; set; }

    }
}
