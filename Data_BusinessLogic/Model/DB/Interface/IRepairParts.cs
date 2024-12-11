using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_BusinessLogic.Model.DB.Interface
{
    public interface IRepairParts
    {
         int sparePartID { get; }
         string partName { get; set; }
         decimal price { get; set; }
         int stockQuantity { get; set; }
    }
}
