using System.Collections.Generic;

namespace MedProject.DataAccess.DataStores.Models
{
    public class GetMedicationsInfoSPResult
    {
        public class ItemOrderSPResult
        {
            public int Id { get; set; }

            public string UserName { get; set; }

            public double OrderedQuantity { get; set; }
        }

        public string Pharmacy { get; set; }

        public string Medication { get; set; }

        public double TotalQuantity { get; set; }

        public IEnumerable<ItemOrderSPResult> ItemOrders { get; set; }
    }
}
