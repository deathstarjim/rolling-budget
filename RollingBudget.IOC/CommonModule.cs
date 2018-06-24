using Ninject.Modules;
using RollingBudget.DAL.Repositories;
using RollingBudget.Models.Contracts;

namespace RollingBudget.IOC
{
    public class CommonModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IBills>().To<BillsRepository>();
            Bind<IPaymentType>().To<PaymentTypesRepository>();
        }
    }
}
