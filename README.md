# asp-mvc-hello-bookrental

---

### Technical Assignment: Web Application

**Objective**: Create a simple web application using **ASP.NET Core** to mock interaction between a reader and a library. 

### Components:
1. **Library**: Manages the books catalog and their status (rented or available).
2. **Book**: Contains ID, title, author, genre, year, and status (available or rented).
3. **Reader**: A abstract user who uses the web application and can rent and return books.

### Requirements:

1. **Webpage**:
   - Table with books. Each row displays: title, author, genre, year of publication, and status.
   - First Table contains a list of books available for rent and "Rent Book" button for each book.
   - Second Table contains a list of books currently rented by the user and "Return Book" button for each rented book.

2. **Logic**:
   - The user can rent a book by clicking the "Rent Book" button in the first table. The book moves to the second table (rented books) after the page reloads.
   - The user can return a book by clicking the "Return Book" button in the second table. The book moves back to the first table (available books) after the page reloads.

3. **Database**:
   - **SQL Server Express 2019 LocalDB** is used to store book data. 
   - Each book is identified by a ID, stored in the database and used for rental and return operations.
   - A table must be created by using a migration function to alter database schema
   - The table holds the following fields: ID, title, author, genre, year of publication, and status.

4. **Data update requirements**:
   - All on a single static page for simplicity. Data should be updated after every action by the page reload.
   - When a user clicks "Rent Book" or "Return Book," a request is sent to the server, the book's status is updated, and the page fully reloads to reflect the updated data.

### Tools:
- **ASP.NET Core** for server-side logic and interactions.
- **C#** as the development language.
- **Entity Framework Core** for implementing SQL integration and data access.
- **SQL Server Express 2019 LocalDB** for storing book data.

---

### Steps to build:

tbd

dotnet nuget
sqllocaldb 
dotnet ef migrations 
dotnet ef database 