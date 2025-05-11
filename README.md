# Library Management System

## 🛠 Setup & Run Instructions

This application is a simple library management system using a multi-layered architecture. It supports book CRUD operations, borrowing/returning logic, late fee handling, and a basic file-based storage using JSON.

---

## Requirements

- [.NET SDK 6 or later]

---

## Project Structure

LibraryManagementSystem/
- Library.Core/ # Domain models and interfaces
- Library.Data/ # JSON repository implementation
- Library.Services/ # Business logic layer
- Library.ConsoleApp/Program.cs # Console 

---

## How to Run

- Open Visual Studio.
- Click on "Open a project or solution".
- Navigate to the root folder of the project and open the .sln file (if available), or open the folder directly.
- In the Solution Explorer, right-click on the project that contains Program.cs (the console app) and select "Set as Startup Project".
- Press F5 (or click the green ► Run button) to start the application.
- The console window will open and display a menu for interacting with the system.



   

## Extra Functionality – Late Fee Charging
An additional feature has been implemented to charge late fees for overdue books:

- When borrowing a book, the date is recorded.

- If a book is not returned on time, a $1 per day late fee is applied.
 
- The fee is displayed to the user when returning the book and reset after payment.

This functionality ensures that users are charged for overdue books, simulating a real-world library system.
