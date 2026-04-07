# GameStore REST API

A fully functional, database-driven REST API built from scratch to learn modern .NET architecture, Entity Framework Core, and security concepts. 

**Note: This project was developed as a hands-on learning initiative during my internship at SMS group.**

## 🚀 Features

- **Robust Architecture:** Structured cleanly with Controllers, Models, Data Transfer Objects (DTOs), and custom Extension Methods.
- **Entity Framework Core (EF Core):** Fully integrated with a local SQLite database for persistent data storage using Code-First Migrations.
- **JWT Authentication:** Implements stateless JSON Web Token (JWT) architecture for secure login and registration.
- **Role-Based Access Control (RBAC):** Endpoints are protected and paired with specific user roles (e.g., `Admin` has full CRUD access, `User` has read-only access).
- **Interactive Documentation:** Configured with Swagger UI for instant browser-based API testing and documentation.
- **Custom Middleware:** Implements global error handling and robust HTTP request logging pipelines.

## 🛠️ Technology Stack

- **Framework:** .NET 10 (ASP.NET Core Web API)
- **Database:** SQLite
- **ORM:** Entity Framework Core (EF Core)
- **Security:** Microsoft.AspNetCore.Authentication.JwtBearer
- **Tooling:** Swagger (Swashbuckle), dotnet-ef

## 📚 Learning Outcomes

Throughout this project, I successfully mastered:
1. **The Request Pipeline:** Understanding how HTTP requests flow through ASP.NET Core Middleware.
2. **Data Persistence:** Moving from hardcoded memory lists to establishing `DbContext` connections, analyzing tables, and using Data Seeding.
3. **Security Standards:** Understanding the difference between Authentication (verifying identity via JWT) and Authorization (verifying permissions via RBAC).
4. **API Design:** Designing clean RESTful CRUD (Create, Read, Update, Delete) endpoints separating internal Models from client-facing DTOs.
