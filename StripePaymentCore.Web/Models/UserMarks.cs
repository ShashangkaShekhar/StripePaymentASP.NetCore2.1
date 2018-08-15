using System;
using System.Collections.Generic;

namespace StripePaymentCore.Web.Models
{
    public partial class UserMarks
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public decimal? Mark { get; set; }
    }
}
