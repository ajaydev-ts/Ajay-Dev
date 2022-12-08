using System;
using System.Collections.Generic;

namespace Assignment.Models
{
    public partial class Category
    {
        public Category()
        {
            Subcategories = new HashSet<Subcategory>();
        }

        public int Catid { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Subcategory> Subcategories { get; set; }
    }
}
