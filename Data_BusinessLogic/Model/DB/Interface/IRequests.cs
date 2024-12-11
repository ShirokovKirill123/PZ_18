using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_BusinessLogic.Model.DB.Interface
{
    public interface IRequests
    {
        int RequestID { get; }
        DateTime StartDate { get; set; }
        DateTime? CompletionDate { get; set; }
        string TypeOfRequest { get; set; }
        string TechnicType { get; set; }
        string TechnicModel { get; set; }
        string ProblemDescription { get; set; }
        string C_Status { get; set; }
        int? SparePartID { get; set; }
        int CustomerID { get; set; }
        int MasterID { get; set; }
        int ManagerID { get; set; }
    }
}
