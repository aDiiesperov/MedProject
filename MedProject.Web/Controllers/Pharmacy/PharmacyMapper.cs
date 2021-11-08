using MedProject.Web.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedProject.Web.Controllers.Pharmacy
{
    public static class PharmacyMapper
    {
        // TODO: Add AutoMapper
        public static PharmacyRes MapToPharmacyRes(this DataAccess.Models.Pharmacy pharmacy)
        {
            return new PharmacyRes() {
                Id = pharmacy.Id,
                Address = pharmacy.Address,
                Email = pharmacy.Email,
                Name = pharmacy.Name,
                Phone = pharmacy.Phone,
                StateCode = pharmacy.StateCode,
            };
        }
    }
}