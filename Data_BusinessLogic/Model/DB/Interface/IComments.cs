using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_BusinessLogic.DB.Interface
{
    public interface IComments
    {
        int Id { get; }
        string Message { get; set; }
        int RequestId { get; set; }
        int MasterId { get; set; }
    }
}
