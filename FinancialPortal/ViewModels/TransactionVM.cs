namespace FinancialPortal.ViewModels
{
    using FinancialPortal.Helpers;
    using FinancialPortal.Models;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class TransactionVM
    {
        [Required]
        [Display (Name = "Name")]
        public string Name { get; set; }
        [Display (Name = "Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Amount")]
        public float Amount { get; set; }
        [Required]
        [Display (Name = "Bank Account")]
        public int BankAccountId { get; set; }
        //BudgetItem SelectList
        [Display (Name = "Catagory")]
        public int? SelectedBudgetItemId { get; set; }
        public IEnumerable<SelectListItem> BudgetItemSelectList { get; set; }
        //Type SelectList
        [Required]
        [Display (Name = "Type")]
        public int SelectedTypeId { get; set; }
        public IEnumerable<SelectListItem> TypeSelectList { get; set; }
    }

    public class TransactionHelper : InstanceHelper
    {
        /// <summary>
        /// Populate a SelectList with BudgetItems that are a part of the relevant Budget
        /// </summary>
        /// <param name="budgetId"></param>
        /// <returns></returns>
        public IEnumerable<SelectListItem> GetBudgetItemSelectList(int budgetId)
        {
            List<BudgetItem> budgetItems = db.BudgetItems.Where(item => item.BudgetId == budgetId).ToList();
            List<SelectListItem> itemSelect = budgetItems.Select(i => new SelectListItem
            {
                Value = i.Id.ToString(),
                Text = i.Name
            }).ToList();
            var first = new SelectListItem()
            {
                Value = null,
                Text = "-- Catagory --"
            };
            itemSelect.Insert(0, first);
            return new SelectList(itemSelect, "Value", "Text");
        }

        /// <summary>
        /// Populate a SelectList with possible TransactionTypes
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SelectListItem> GetTransactionTypeSelectList()
        {
            List<SelectListItem> types = db.TransactionTypes.Select(transType => new SelectListItem
            {
                Value = transType.Id.ToString(),
                Text = transType.Name
            }).ToList();

            var first = new SelectListItem()
            {
                Value = null,
                Text = "-- Transaction Type --"
            };
            types.Insert(0, first);
            return new SelectList(types, "Value", "Text");
        }

        /// <summary>
        /// Add a Transaction entry to the database
        /// </summary>
        /// <param name="model"></param>
        public void CreateTransaction(TransactionVM model)
        {
            var me = HttpContext.Current.User.Identity.GetUserId();
            var newTransaction = new Transaction
            {
                Name = model.Name,
                Description = model.Description,
                Amount = model.Amount,
                Date = DateTime.Now,
                TypeId = model.SelectedTypeId,
                AccountId = model.BankAccountId,
                UserId = me,
                BudgetItemId = model.SelectedBudgetItemId,
            };
            db.Transactions.Add(newTransaction);
        }
    }
    
}