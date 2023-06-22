# Powerplant Coding Challenge

This repository contains the solution for the Powerplant Coding Challenge. 


## Architecture

The project follows a simple architecture pattern:

- The models used in the application are located in the `Models` directory.
- The main controller responsible for handling the production plan generation is `ProductionPlanController`, located in the `Controllers` directory.
- All services and business logic can be found in the `Services` directory.

## Getting Started

To run the project, follow the steps below:

1. Navigate to the `source_code_c#` folder.

2. Navigate to the `powerplant-coding-challenge` folder.

3. Double click on either the `powerplant-coding-challenge.sln` file to open the project in Visual Studio 2022.

4. Once the project is opened, run the project.

5. After the application has started, a web browser tab will automatically open at the following URL: `http://localhost:8888/swagger/index.html`.

6. In the Swagger UI, you will find the `/productionplan` endpoint where you can make a POST request and provide the payload.

## API Documentation

The API documentation is provided through Swagger UI, which can be accessed at `http://localhost:8888/swagger/index.html` after starting the application. In Swagger UI, you can explore the available endpoints, including the `/productionplan` endpoint for submitting a payload.

## Requirements

- Visual Studio 2022

## Author

This project was created by Sofiane Azarkan.
