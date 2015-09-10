using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularBudget.Models
{
   
    public class HouseholdViewModel
    {
        public string Name { get; set; }

        public string Code { get; set; }
    }

    public class TransByCatViewModel
    {
        public ICollection<Category> Categories { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }

    public class TransByTypeViewModel
    {
        public ICollection<CategoryType> Types { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}