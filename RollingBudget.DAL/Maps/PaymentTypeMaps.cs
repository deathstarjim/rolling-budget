using FDCommonTools.SqlTools;
using RollingBudget.Models.Models;
using System.Data;

namespace RollingBudget.DAL.Maps
{
    public class PaymentTypeMaps
    {
        public static PaymentType MapPaymentType(DataRow row)
        {
            PaymentType type = new PaymentType();

            if(row != null)
            {
                type.Id = DataFieldHelper.GetUniqueIdentifier(row, "PaymentTypeId");
                type.Name = DataFieldHelper.GetString(row, "PaymentType");
            }

            return type;
        }
    }
}
