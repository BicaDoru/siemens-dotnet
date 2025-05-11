# Library Management System

## 🛠 Setup & Run Instructions

This application is a simple library management system using a multi-layered architecture. It supports book CRUD operations, borrowing/returning logic, late fee handling, and a basic file-based storage using JSON.

---

## Requirements

- [.NET SDK 6 or later]
- Any IDE (e.g., Visual Studio, VS Code) or simply run via CLI

---

## Project Structure

LibraryManagementSystem/
│
├── Library.Core/ # Domain models and interfaces
├── Library.Data/ # JSON repository implementation
├── Library.Services/ # Business logic layer
├── Library.ConsoleApp/Program.cs # Console 

---

## How to Run

1. **Clone the repository** (or download the folder).
2. Open a terminal in the root directory.
3. Run the project:
   ```bash
   dotnet run

   

## Extra Functionality – Late Fee Charging
An additional feature has been implemented to charge late fees for overdue books:

- When borrowing a book, the date is recorded.

- If a book is not returned on time, a $1 per day late fee is applied.
 
- The fee is displayed to the user when returning the book and reset after payment.

This functionality ensures that users are charged for overdue books, simulating a real-world library system.
