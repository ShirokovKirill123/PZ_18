using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_BusinessLogic.Model.DB.Interface
{
    public interface IRepairParts
    {
        int SparePartID { get; }
        string PartName { get; set; }
        decimal Price { get; set; }
        int StockQuantity { get; set; }
    }
}
