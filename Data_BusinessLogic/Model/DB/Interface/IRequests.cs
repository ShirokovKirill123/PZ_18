using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_BusinessLogic.Model.DB.Interface
{
    public interface IRequests
    {
        int requestID { get; set; }
        DateTime startDate { get; set; }
        DateTime? completionDate { get; set; }
        string typeOfRequest { get; set; }
        string technicType { get; set; }
        string technicModel { get; set; }
        string problemDescription { get; set; }
        string C_status { get; set; }
        int? sparePartID { get; set; }
        int customerID { get; set; }
        int masterID { get; set; }
        int managerID { get; set; }
    }
}
