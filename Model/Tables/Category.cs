
using HenriqueV5.Models.Registration;
using System;
using System.Collections.Generic;

namespace HenriqueV5.Models.Tables
{
    public class Category
    {
    


        public long? CategoryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }




    }
}