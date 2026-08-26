# CHABA.DayCare 🏫

A daycare management system built to help streamline the management of children, classrooms, staff, and day-to-day daycare operations.

> 🚧 **Project Status: In Development**

## 📌 About the Project

CHABA.DayCare is a web-based daycare management system developed to provide a more organised way of managing daycare information and administrative tasks.

The system is being developed for **Lehlogonolo DayCare Centre** to reduce reliance on paper-based processes and spreadsheets and provide a centralised system for managing daycare operations.

The project is designed around the needs of a real daycare environment, including child management, classroom management, staff information, and administrative processes.

## 🎯 Problem

Many daycare activities can become difficult to manage when information is spread across paper records, spreadsheets, and manual processes.

CHABA.DayCare aims to provide a centralised system where important daycare information can be managed more efficiently and consistently.

## ✨ Features

### 👧🏽 Child Management

* Manage child information
* View enrolled children
* Organise children according to their classroom

### 🏫 Classroom Management

* Manage daycare classrooms
* Organise children by age group
* View classroom information

### 👩🏽‍🏫 Staff Management

* Manage daycare staff information
* Organise staff records

### 📊 Dashboard

* Centralised dashboard for accessing important daycare information
* Overview of key daycare information

### 🔐 User Authentication
- Authentication and role-based access are currently being developed.
- The authentication functionality is not yet fully implemented.

> **Note:** Features are continuously being developed and improved as the project progresses.

## 🛠️ Technologies Used

* **C#**
* **ASP.NET Core**
* **Razor Pages**
* **Entity Framework Core**
* **SQL Server**
* **.NET 8**
* **Bootstrap**
* **HTML**
* **CSS**
* **JavaScript**
* **Git & GitHub**
* **Visual Studio**

## 🏗️ Project Structure

The application follows a structured architecture that separates different responsibilities within the system.

Key areas include:

* **Pages** — Razor Pages used for the application's user interface
* **Services** — Business logic and application operations
* **Repositories** — Data access and repository interfaces
* **ViewModels** — Models used to transfer and display data
* **Data** — Database and Entity Framework Core configuration
* **Models** — Application entities

This structure helps keep the application organised and makes it easier to maintain and extend.

## 🗄️ Database

The system uses **Microsoft SQL Server** as its database.

**Entity Framework Core** is used to:

* Define relationships between entities
* Manage database interactions
* Perform database migrations
* Retrieve and update application data

## 💻 Getting Started

### Prerequisites

Before running the project, make sure you have:

* .NET 8 SDK
* Microsoft SQL Server
* Visual Studio
* Git

### Clone the Repository

```bash
git clone https://github.com/Mmasetshaba28/CHABA-DayCare.git
```

Navigate into the project directory:

```bash
cd CHABA-DayCare
```

### Database Configuration

Update the database connection string in the application's configuration file to match your local SQL Server setup.

### Apply Database Migrations

Run the following command from the project directory:

```bash
dotnet ef database update
```

### Run the Application

Start the application using:

```bash
dotnet run
```

Alternatively, open the solution in **Visual Studio** and run the project from there.

## 📚 What I Am Learning

Through this project, I am gaining practical experience in:

* Developing applications using ASP.NET Core
* Building web applications with Razor Pages
* Designing and working with relational databases
* Using Entity Framework Core
* Applying repository and service-based architecture
* Working with dependency injection
* Managing application data
* Building software around real-world requirements
* Using Git and GitHub for version control

## 🚧 Current Development

CHABA.DayCare is an ongoing project.

Current development focuses on completing authentication and role-based access, expanding system functionality, improving the user experience, and adding features based on the operational requirements of the daycare centre.

## 🔮 Future Improvements

Planned improvements may include:

* Parent management
* Attendance management
* Fee/payment management
* Improved reporting
* Parent communication features
* Additional dashboard statistics
* Further user-role improvements

## 👩🏽‍💻 Author

**Mmasetshaba Wendy Rakgalakane**

IT Graduate | Software Developer

* GitHub: [Mmasetshaba28](https://github.com/Mmasetshaba28)
* LinkedIn: [Mmasetshaba Wendy Rakgalakane](https://www.linkedin.com/in/mmasetshaba-rakgalakane-982156299/)

---

⭐ This project is actively being developed and improved.
