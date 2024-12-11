using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_BusinessLogic.Model.DB.Interface
{
    public interface IMasters
    {
         int masterID { get; }
         int specialization { get; set; }
         int userID { get; set; }
    }
}
