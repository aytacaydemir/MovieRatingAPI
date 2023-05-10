# MovieRatingApi

MovieRatingApi is a RESTful API for managing movie ratings and comments. The API allows users to create movie ratings and comments for movies.

## Features

- Create movies for evaluation by users
- Create movie ratings
- Create movie comments

## Technologies Used

- ASP.NET Core
- Entity Framework Core
- SQL Server
- Swagger UI

## Getting Started

To get started with the project, follow these steps:

1. Clone the repository: `git clone https://github.com/aytacaydemir/MovieRatingApi.git`
3. Update the connection string in `appsettings.json` to point to your SQL Server instance
4. Run [script.sql](https://github.com/aytacaydemir/MovieRatingApi/blob/master/script.sql) file in your local SQL Server database.
6. Run the application: `dotnet run`

## API Endpoints

The following endpoints are available:

- `POST /api/Rating`: Create/Update a new rating on a movie
- `POST /api/Movie`: Create a new movie
- `POST /api/Comment`: Create a new comment on a movie
- `GET /api/Movie`: Get all movies 
- `POST /api/Auth`: Generate JWT Token for User

## SQL Server

This project built with SQL Server locally. 
This [script.sql](https://github.com/aytacaydemir/MovieRatingApi/blob/master/script.sql) file can be used to create tables and insert sample data to SQL Server Database.

## Swagger UI

To access the API documentation, navigate to the root URL of the application. Swagger UI will start automatically. 
The UI provides documentation for the API endpoints and allows you to try out the API directly in your browser.
