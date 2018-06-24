using RollingBudget.Models.Models;
using System.Collections.Generic;

namespace RollingBudget.Models.Contracts
{
    public interface IPaymentType
    {
        List<PaymentType> GetPaymentTypes();
    }
}
