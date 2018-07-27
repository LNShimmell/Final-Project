using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PrSserver.Models;

namespace PrSserver.Utility
{
    public class VendorOrder
    {
        public List<PurchaseRequestLineItem> Prlis { get; set; }
        public decimal Total { get; set; }
        public List<string> productName { get; set; }
        public List<decimal> Quant { get; set; }
        public List<decimal> Cost { get; set; }



       
        public VendorOrder()
        {

        }

    

    }
}