using System;

namespace RollingBudget.Models.Models
{
    public class Bill
    {
        public Bill()
        {
            PaymentType = new PaymentType();
        }

        public Guid Id { get; set; }

        public PaymentType PaymentType { get; set; }

        public string Description { get; set; }

        public int DueDay { get; set; }

        public float AmountDue { get; set; }

        public bool EnteredInCheckbook { get; set; }

        public bool ClearedInCheckbook { get; set; }
    }
}
