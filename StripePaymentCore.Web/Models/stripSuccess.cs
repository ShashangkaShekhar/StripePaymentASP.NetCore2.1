using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StripePaymentCore.Web.Models
{
    public class stripSuccess
    {
        public string stripeEmail { get; set; }
        public string stripeToken { get; set; }
        public float stripeAmount { get; set; }
    }
}
