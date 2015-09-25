using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularBudget.Models
{
    public class Household
    {
        public Household()
        {
            this.Users = new HashSet<ApplicationUser>();
            this.Accounts = new HashSet<Account>();
            this.BudgetItems = new HashSet<BudgetItem>();
            this.Invitations = new HashSet<Invitation>();
            this.Categories = new HashSet<Category>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset? RemovedDate { get; set; }
        //public bool IsDeleted { get; set; }

        [JsonIgnore]
        public virtual ICollection<ApplicationUser> Users { get; set; }
        [JsonIgnore]
        public virtual ICollection<Account> Accounts { get; set; }
        [JsonIgnore]
        public virtual ICollection<BudgetItem> BudgetItems { get; set; }
        [JsonIgnore]
        public virtual ICollection<Invitation> Invitations { get; set; }
        [JsonIgnore]
        public virtual ICollection<Category> Categories { get; set; }
    }
}