# Student Management Application MVC

This project is a Student Management System built using ASP.NET Core MVC, demonstrating a clean architecture with separation of concerns using Models, Services, Controllers, and Views.

## Features

* Full CRUD operations for managing student records
* Implementation of MVC design pattern
* Service layer abstraction using `IStudentService` and `StudentService`
* In-memory data storage (no database dependency)
* Data validation using Data Annotations
* Configuration management using `appsettings.json`
* Logging using `ILogger`

## Student Model

The application manages the following student details:

* Id
* Name
* Age
* Department
* Email

## Application Structure

* Models → Defines the `Student` entity with validation
* Services → Contains business logic (`IStudentService`, `StudentService`)
* Controllers → Handles user requests and interacts with service layer
* Views → Razor UI pages for:

  * Index
  * Create
  * Edit
  * Details
  * Delete

## Configuration (appsettings.json)

The application uses configuration values:

* `CollegeName` → Displayed in the UI
* `MaxStudentLimit` → Restricts student creation when limit is reached

## Business Rules

* Prevents adding new students when maximum limit is reached
* Displays appropriate messages to users

## Logging

Implemented using `ILogger` to track:

* Fetching all students
* Adding a student
* Updating a student
* Deleting a student
* Invalid ID access
* Exceptions
* Limit reached scenarios

## Navigation

* After Create/Edit/Delete → Redirects to Index page

## Highlights

* Clean and maintainable architecture
* Demonstrates real-world practices like configuration handling and logging
*  It is the project to practice and understand ASP.NET Core MVC concepts which i have learnt.
