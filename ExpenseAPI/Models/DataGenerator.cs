using System;
using System.Collections.Generic;

namespace ExpenseAPI.Models
{
    public class DataGenerator
    {
        public static void Initialize(ExpenseContext context)
        {
            context.Database.EnsureCreated();

            // Look for any expenses.
            if (context.ExpenseItems.Any())
            {
                return;   // DB has been seeded
            }

            //產生5資料，要包含 id, date, description, amount, catergory
            // category 只能有 食、衣、住、行 4 類
            var expenses = new Expense[]
            {
                new Expense{Id=1, Date=DateTime.Parse("2021-01-01"), Description="吃飯", Amount=100, Category="食"},
                new Expense{Id=2, Date=DateTime.Parse("2021-01-02"), Description="買衣服", Amount=300, Category="衣"},
                new Expense{Id=3, Date=DateTime.Parse("2021-01-03"), Description="租房子", Amount=1000, Category="住"},
                new Expense{Id=4, Date=DateTime.Parse("2021-01-04"), Description="搭捷運", Amount=50, Category="行"},
                new Expense{Id=5, Date=DateTime.Parse("2021-01-05"), Description="買飲料", Amount=30, Category="食"}
            };


            foreach (Expense e in expenses)
            {
                context.ExpenseItems.Add(e);
            }
            context.SaveChanges();
        }
    }
}