using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FinancialPortal.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    { 
        //Main extended properties
        [Required]
        [StringLength(15, ErrorMessage = "Must be less than 15 characters.")]
        public string FirstName { get; set; }
        [Required]
        [StringLength (20, ErrorMessage = "Must be less than 20 characters.")]
        public string LastName { get; set; }
        [StringLength (15, ErrorMessage = "Must be less than 15 characters.")]
        public string Alias { get; set; }
        public string AvatarPath { get; set; }
        //
        //Virtual
        public int HouseholdId { get; set; }
        //------------------------------------------
        public virtual Household Household { get; set; }
        //
        //collections
        public virtual ICollection<Transaction> Transactions { get; set; }
        //
        //Non-mapped properties
        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        [NotMapped]
        public string FirstNamePlusEmail
        {
            get
            {
                return $"{Email} ({FirstName})";
            }
        }
        [NotMapped]
        public HttpPostedFileBase AvatarFile { get; set; }
        //
        //constructor
        public ApplicationUser()
        {
            this.Transactions = new HashSet<Transaction>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<BankAccount> Accounts { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<BudgetItem> BudgetItems { get; set; }
        public DbSet<Household> Households { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
    }
}