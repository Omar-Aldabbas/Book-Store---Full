# BookStore Fullstack Application

This repository contains a fullstack Bookstore application with **Angular frontend** and **ASP.NET Core Web API backend**. The project is structured to separate the client and server, making it maintainable and scalable.

---

- **Client**: Angular project that consumes the API.  
- **Server**: ASP.NET Core Web API with EF Core, handling CRUD, authentication, and business logic.  
- **Dtos**: Data Transfer Objects used to expose specific fields to the frontend.  

---


## Features

### Backend
- CRUD operations for `Books` and `BookDetails`  
- Lookup tables for `BookTypes` and `Genres`  
- Many-to-many relationships handled via junction tables (`BookDetailGenres`)  
- Entity Framework Core for database access  
- Swagger/OpenAPI documentation  

### Frontend
- Angular SPA consuming the Web API  
- Components for listing, creating, and updating books  
- Supports multiple genres and book types  

---

## Getting Started

### Prerequisites
- .NET 8 SDK (or compatible version)
- SQL Server (Express or full)
- Node.js and Angular CLI
