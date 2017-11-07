﻿namespace CarDealer.Web.Services.Models.Collections
{
    using System.Collections.Generic;

    public class ListingSuppliersModel
    {
        public ICollection<SupplierModel> Suppliers { get; set; } = new List<SupplierModel>();
    }
}