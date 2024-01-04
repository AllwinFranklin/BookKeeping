# .NET Core MVC BookKeeping API

This project is a .NET Core MVC solution for a bookKeeping API, addressing a set of requirements outlined in an interview task. The application provides RESTful APIs for managing books, including sorting, calculating total prices, and generating citations in MLA and Chicago styles.

## Table of Contents

- [Problem](#problem)
- [Solution Overview](#solution-overview)
- [Project Structure](#project-structure)
- [Database Design](#database-design)
- [Stored Procedures](#stored-procedures)
- [API Endpoints](#api-endpoints)

### Problem

1. Create a REST API using .NET Core MVC to:
    - [x] Return a sorted list of books by Publisher, Author (last, first), then title.
    - [x] Return a sorted list by Author (last, first) then title.
    - [x] Return the total price of all books in the database.
    - [ ] Update list of Books from memory with single call to the database.
    - [x] Return a sorted list of books by Publisher, Author (last, first), then title using Stored Procedure.
    - [x] Return a sorted list by Author (last, first) then title using Stored Procedure.
  
### Solution Overview

The solution follows clean coding practices, utilizing .NET Core MVC, design patterns, and asynchronous methodologies. It integrates Dependency Injection and Inversion of Control for enhanced flexibility. Used EntityFramework to ensure single source of truth with SQL scripts.

### Project Structure:

As a conventional MVC API, I have organised the project source code in a standard way.
- `Model` - Contains the Business domain entity.
- `Controller` - Contains controller.
- `Contracts` - Contains Interface needed for implementing repositories.
- `Repository` - Contains Repository files which will act as DataAccess.
- `Data` - Contians DBContext of EntityFramework and the Seed data needed initially eg(UserRoles, Departments these kind of datas can we seeded).
- `Extension` - Contains IHost extension methods which will handle the Migration of SeedData before running the app.
- `Migration` - Will contain SQL changes done thoughtout the application. Changes will be captured as snapshops and can be version controlled.

### Database Design:

### Book Entity

| Field            | Type      | Description                |
|------------------|-----------|----------------------------|
| Id               | int       | Unique identifier          |
| Publisher        | string    | Publisher of the book      |
| PublishedDate    | DateTime  | Date when the book was published |
| Title            | string    | Title of the book          |
| AuthorLastName   | string    | Last name of the author    |
| AuthorFirstName  | string    | First name of the author   |
| Price            | decimal   | Price of the book          |

### Citation Entity

| Field            | Type      | Description                     |
|------------------|-----------|---------------------------------|
| Id               | int       | Unique identifier               |
| Book             | Book      | Reference to the associated book |
| SourceTitle      | string    | Title of the source             |
| StartPageNo      | int       | Starting page number            |
| EndPageNo        | int       | Ending page number              |
| VolumeNo         | int       | Volume number                   |
| URL              | string    | URL for the source (if applicable) |

### Stored Procedures

1. `GetAllBooksSortByAurthorTitleSP` - [Link](BookKeeping.API/Migrations/20240104195648_GetAllBooksSortByAurthorTitleSP.cs)
2. `GetAllBooksSortByPublisherAurthorTitleSP` - [Link](BookKeeping.API/Migrations/20240104205706_GetAllBooksSortByPublisherAurthorTitleSP.cs)

I have created the stored procedure in a code first approch. You can find the procedure inside Migration file with appropriate Stored procedure name. With this approch we can do version control with SQL Scripts

### API Endpoints

1. `GET /api/v1/book/BooksSortByPublisher`
2. `GET /api/v1/book/BooksSortByPublisherSP`
3. `GET /api/v1/book/BooksSortByAuthor`
4. `POST /api/v1/book/BooksSortByAuthorSP`
5. `POST /api/v1/book/TotalBookPrice`
6. `POST /api/v1/citation/getAllBooksMLACitation`
7. `POST /api/v1/citation/getAllBooksChicagoCitation`
