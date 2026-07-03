# BookStoreSolution

# ASP.NET Core Web API

A production-ready ASP.NET Core Web API developed using modern software engineering practices and design patterns. 
This project demonstrates scalable API development with clean architecture, dependency injection, centralized exception handling, and secure authentication mechanisms.

## Features

* ASP.NET Core Web API
* RESTful API Design
* Entity Framework Core
* Dependency Injection (DI)
* Repository Pattern
* Global Exception Handling Middleware
* Structured Logging
* SQL Server Integration
* Swagger/OpenAPI Documentation
* Asynchronous Programming (Async/Await)
* Input Validation

## Technology Stack

* ASP.NET Core
* C#
* Entity Framework Core
* SQL Server
* Scalar/OpenAPI
* LINQ

## Project Goals

This project was created to demonstrate enterprise-level API development practices 
including security, maintainability, performance optimization, exception handling, and clean code principles.


## API Capabilities

* CRUD Operations
* Authentication & Authorization
* Data Validation
* Error Handling
* Database Operations
* API Documentation


## Future Enhancements

* Unit Testing
* Integration Testing
* CI/CD Pipeline
* API Versioning
* Rate Limiting


## Configuring EFCORE:


01. Install required Packages (3)

	Microsoft.EntityFrameworkCore
	
	Microsoft.EntityFrameworkCore.SqlServer
	
	Microsoft.EntityFrameworkCore.Tools
	
02.	Install one more Package for Api Documentation

	Scalar.AspNetCore
	
	Added configuration in Program.cs class
	
	app.MapScalarApiReference("/scalar");
	
03.	Added configuration in appsetting.json file

	"ConnectionStrings": {
			"DefaultConnection": "Server=.;Database=BookStoreAppDB;Trusted_Connection=True;TrustServerCertificate=True;"
	}
	
04.	Added Models Folder and added their classes

05.	Added BookController class in Controllers Folder

06.	Added DTOs Folder and added their classes

07.	Add Data Folder and added their classes
08.	Added DbContext File/class
09.	AppDbContext class and registered in Program.cs class
	
10.	Migration Task/Work/Command

	add-migration "BSSConfigurationMigration"
	
	update-database

11.	How to check our code through OpenAPI
	https://localhost:7156/openapi/v1.json
	
12.	How to check our code through Scalar
	https://localhost:7156/scalar/
	
13.	Added DTOs Folder and added their classes

