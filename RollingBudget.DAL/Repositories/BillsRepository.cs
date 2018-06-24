using FDCommonTools.SqlTools;
using RollingBudget.Models.Contracts;
using RollingBudget.Models.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;

namespace RollingBudget.DAL.Repositories
{
    public class BillsRepository : IBills
    {
        private DataLoadHelper _helper = new DataLoadHelper(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public List<Bill> GetBills()
        {
            List<Bill> bills = new List<Bill>();

            string sql = @"
                            SELECT 
	                            bills.[BillId]
                                ,paytypes.[PaymentTypeId]
	                            ,paytypes.PaymentType
                                ,bills.[BillDescription]
                                ,bills.[DueDayOfTheMonth]
                                ,bills.[AmountDue]
                                ,bills.[EnteredInCheckbook]
                                ,bills.[ClearedCheckbook]
                            FROM [RollingBalance].[dbo].[Bills] bills
	                            INNER JOIN PaymentTypes paytypes
		                            ON bills.PaymentTypeId = paytypes.PaymentTypeId
                            ORDER BY DueDayOfTheMonth";
            
            var result = _helper.ExecSqlPullDataTable(sql);

            if (result != null)
                bills = (from DataRow row in result.Rows select Maps.BillsMaps.MapBill(row)).ToList();

            return bills;
        }
    }
}
