using FDCommonTools.SqlTools;
using RollingBudget.Models.Contracts;
using RollingBudget.Models.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;

namespace RollingBudget.DAL.Repositories
{
    public class PaymentTypesRepository : IPaymentType
    {
        private DataLoadHelper _helper = new DataLoadHelper(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public List<PaymentType> GetPaymentTypes()
        {
            List<PaymentType> types = new List<PaymentType>();

            string sql = @"
                            SELECT
	                            paytypes.PaymentTypeId
	                            ,paytypes.PaymentType
                            FROM PaymentTypes paytypes";
            
            var result = _helper.ExecSqlPullDataTable(sql);

            if (result != null)
                types = (from DataRow row in result.Rows select Maps.PaymentTypeMaps.MapPaymentType(row)).ToList();

            return types;
        }
    }
}
