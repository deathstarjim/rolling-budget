using FDCommonTools.SqlTools;
using RollingBudget.Models.Models;
using System.Data;

namespace RollingBudget.DAL.Maps
{
    public class BillsMaps
    {
        public static Bill MapBill(DataRow row)
        {
            Bill bill = new Bill();

            if(row != null)
            {
                bill.Id = DataFieldHelper.GetUniqueIdentifier(row, "BillId");
                bill.PaymentType = PaymentTypeMaps.MapPaymentType(row);
                bill.Description = DataFieldHelper.GetString(row, "BillDescription");
                bill.DueDay = DataFieldHelper.GetInt(row, "DueDayOfTheMonth");
                bill.AmountDue = DataFieldHelper.GetFloat(row, "AmountDue");
                bill.EnteredInCheckbook = DataFieldHelper.GetBit(row, "EnteredInCheckbook");
                bill.ClearedInCheckbook = DataFieldHelper.GetBit(row, "ClearedCheckbook");
            }

            return bill;
        }
    }
}
