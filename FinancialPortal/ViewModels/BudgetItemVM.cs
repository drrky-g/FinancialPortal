namespace FinancialPortal.ViewModels
{
    using FinancialPortal.Helpers;
    using FinancialPortal.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;

    public class CreateBudgetItemVM
    {
        [Required]
        [Display (Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display (Name = "Budget")]
        public int SelectedBudgetId { get; set; } 
        public IEnumerable<SelectListItem> BudgetSelectList { get; set; }

    }

    public class BudgetItemHelper : InstanceHelper
    {
        /// <summary>
        /// Populate a SelectList with a particular Household's Budgets.
        /// </summary>
        /// <param name="houseId"></param>
        /// <returns></returns>
        public IEnumerable<SelectListItem> GetBudgetSelectList(int houseId)
        {
            List<Budget> myBudgets = db.Budgets.Where(b => b.HouseholdId == houseId).ToList();
            List<SelectListItem> select = myBudgets.Select(b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = b.Name
            }).ToList();
            var first = new SelectListItem()
            {
                Value = null,
                Text = "-- Budget --"
            };
            select.Insert(0, first);
            return new SelectList(select, "Value", "Text");
        }

        /// <summary>
        /// Add a BudgetItem entry to the database
        /// </summary>
        /// <param name="model"></param>
        public void CreateBudgetItem(CreateBudgetItemVM model)
        {
            var newItem = new BudgetItem
            {
                Name = model.Name,
                BudgetId = model.SelectedBudgetId
            };
            db.BudgetItems.Add(newItem);
        }
    }
}