using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forest.Models
{
    public class CartMusic : Forest.Data.Music
    {
        public int Quantity { get; set; }
    }
}