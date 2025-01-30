# Match Project - README

This is the README for the Match Project, which describes how to set up and run the application and the database using Docker Compose.

## Requirements

Make sure you have the following requirements installed on your system:

- [Docker](https://www.docker.com/get-started)
- [Docker Compose](https://docs.docker.com/compose/install/)

## Configuration

1. Clone this repository to your development environment:

    ```bash
    git clone https://github.com/gladsonNunes/Match.git

    cd match
    ```
    ´


2. To build and start the Docker containers, run the following command at the project's root:
    ```bash
    docker-compose up -d
    ```

This will create containers for the API and the Oracle database.

## Accessing the API

The API will be available at [http://localhost:8080](http://localhost:8080).  
You can also access `swagger` at [http://localhost:8080/swagger](http://localhost:8080/swagger).  
You can access it in your browser or use a tool like curl or Postman to make requests.

## Accessing the Database

Accessing the Database

The Oracle database can be accessed using any Oracle database management tool. Use the following connection information:

•	Host: localhost
•	Port: 1521
•	Service Name: XEPDB1
•	User: match
•	Password: match

## Running Database Migrations

To create tables in the database, you can use the following command:

inside the folder
    ```bash
    src > Match.Api
    ```
run the command

  ```bash
  dotnet ef database update
  ```
If so far everything has gone as it should, you can test the api, enjoy ✨


## Running Tests

To run the unit tests, use the following command:

This will execute all the tests in the `Match.Tests` project.

## Project Structure

The project is organized into the following structure:

- **Match.Domain**: Contains the domain models and interfaces.
- **Match.Infrastructure**: Contains the Entity Framework Core configurations and implementations.
- **Match.Api**: Contains the ASP.NET Core web application.
- **Match.Tests**: Contains the unit tests for the application.

### Key Files

- `Match.Domain/Developer/Developer.cs`: Represents the developer entity.
- `Match.Domain/Project/Project.cs`: Represents the project entity.
- `Match.Infrastructure/ConfigurationEF/Developers/DevelopersConfig.cs`: Entity Framework Core configuration for the `Developer` entity.
- `Match.Tests/ServMatchTests.cs`: Unit tests for the `ServMatch` service.
