using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DDStore.MVC.Models
{
    public class mvcProductModel
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        public Nullable<int> Quantity { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        public Nullable<int> Price { get; set; }

        internal static object where(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}