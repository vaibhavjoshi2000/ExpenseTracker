# ExpenseTracker

An ASP.NET Core MVC application to track expenses, categorize them, and generate summaries. This project is designed for learning purposes and can also be used as a basic template for personal expense tracking.

# Features
   1. Add, view, and manage expenses.
   2. Categorize expenses.
   3. Generate expense summaries by category.
   4. Modern and responsive design using Bootstrap.

# Prerequisites
Before setting up this project, ensure you have the following installed on your machine:
1. **NET SDK (6.0 or later)**
[Download .NET](https://dotnet.microsoft.com/download)
2. **SQL Server (Express or Developer Edition recommended)**
[Download SQL Server](https://www.microsoft.com/en-in/sql-server/sql-server-downloads)
3. **Visual Studio 2022 (or later) with ASP.NET and web development workload.**
[Download Visual Studio](https://visualstudio.microsoft.com/)

# Getting Started
Follow these steps to set up and run the project on your machine:
1. **Clone the Repository**
      i. git clone https://github.com/vaibhavjoshi2000/ExpenseTracker.git
      ii. cd expense-tracker
2. **Set Up the Database**
   i. Open **SQL Server Management Studio (SSMS)** or a similar SQL Server client.
   ii. Create a new database named ExpenseTrackerDb.
   iii. Update the **connection string** in **appsettings.json** if necessary:
    "ConnectionStrings": {
       "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=ExpenseTrackerDb;Integrated    
         Security=True;MultipleActiveResultSets=True;"
        }
   iv. Replace YOUR_SERVER_NAME with your SQL Server instance name.
   v. If you are using SQL Authentication, replace Integrated Security=True with User ID=your-username;Password=your-   
       password;.   
3. **Install below Entity Framework from Nuget Package Manager**
   i. Microsoft.EntityFrameworkCore
   ii. Microsoft.EntityFrameworkCore.Tools
   iii. Microsoft.EntityFrameworkCore.SqlServer
4. **Apply Migrations(It will create the necessary tables in the database)**
     i. Add-Migration "InitialCreate"
     ii. Update-database
5. **Build and Run the Application**
   1. Open the project in **Visual Studio**.
   2. Press **F5** to run the application.
   3. Alternatively, use the .NET CLI:
      i. dotnet build
      ii. dotnet run
6.**Usage Instructions**
     i. Expenses: Navigate to the "Expenses" page to view all recorded expenses.
     ii.   Add Expense: Use the "Add Expense" link in the navbar to record a new expense.
     iii.  Summary: Click on the "Summary" link to view expense summaries by category.

7.**Folder Structure**
       i. Controllers: Handles the request and response logic.
       ii. Models: Defines the database schema and business logic.
       iii. Views: Contains Razor pages for the UI.
       iv. wwwroot: Static files like CSS, JavaScript, and images.

8.**Technologies Used**
     i.ASP.NET Core MVC
     ii.Entity Framework Core
     iii.SQL Server
     iv. Bootstrap (for styling)

9.**Contribution**
      i.Feel free to fork this repository, make changes, and submit a pull request. Contributions are welcome!

10.**License**
      i.This project is licensed under the MIT License. You are free to use, modify, and distribute this project as per the          license terms.

11.**Troubleshooting**
       i. Verify your SQL Server instance is running.
       ii. Ensure the database connection string is correctly configured in appsettings.json.
       iii. Check for missing NuGet packages and restore them using Visual Studio or dotnet restore.
       iv. Run dotnet ef database update again if the database tables are missing.
12.**Contact**
   i. **Email**: vaibhavjoshicoer@gmail.com
   ii.**Linkedlin**: [Vaibhav Joshi](https://www.linkedin.com/in/vaibhav-joshi-702287185/)









