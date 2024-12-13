using ExpenseTracker1.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker1.Models

{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Expense> TransactionsExpenses { get; set; }//During Migration Tables corresponding with Expense name as Expenses Table created inside Database
                                                                // public DbSet<Category> Categories { get; set; }//During Migration Tables corresponding with Category name as Categories Table inside Database
    }
}

//We are creating ApplicationDbContext class here because it is only class that can convert the Transaction & Category entity model into tables inside the database
//After adding the migration
