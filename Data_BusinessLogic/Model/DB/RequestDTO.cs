using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_BusinessLogic.Model.DB
{
    public class RequestDTO
    {
        public int RequestID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string TechnicType { get; set; }
        public string TechnicModel { get; set; }
        public string ProblemDescription { get; set; }
        public string ClientFio { get; set; }
        public string ManagerFio { get; set; }
        public string MasterFio { get; set; }
        public string PartName { get; set; }
        public string TypeOfRequest { get; set; }
        public string Status { get; set; }
    }
}
