using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_BusinessLogic.DB.Interface
{
    public interface IRequest
    {
        int Id { get; }
        DateTime StartDate { get; set; }
        string ProblemDescription { get; set; }
        DateTime? CompletionDate { get; set; }
        int HomeTechTypeId { get; set; }
        int? HomeTechModelId { get; set; }
        int? RepairPartsId { get; set; }
        int ClientId { get; set; }
        int? MasterId { get; set; }
        int StatusId { get; set; }

        bool IsCompleted { get; }
    }
}
