# WheelDealAPI

## Overview
WheelDeal is a backend API that provides functionality for calculating the total price of a vehicle at a car auction. It considers various costs associated with the transaction and dynamically computes the total amount based on the vehicle's base price and type.

## Architecture
The backend is built using C# with ASP.NET Core, a powerful and cross-platform framework for building web APIs. The project follows a modular architecture with separation of concerns, adhering to SOLID principles for better maintainability and scalability.

## Technologies Used
- .NET 8.0: The project is developed using .NET 8.0, a modern and versatile framework for building web applications.
- ASP.NET Core: ASP.NET Core is used for building the web API, providing features such as routing, middleware, and dependency injection.
- Docker: Docker is used for containerizing the application, enabling consistent deployment across different environments and platforms.

## How to Run with Docker
To run the WheelDeal backend using Docker, you can use Docker Compose. Follow these steps:

1. Ensure you have Docker installed on your machine. You can download and install Docker from [here](https://www.docker.com/get-started).

2. Clone the WheelDeal repository to your local machine:

### Navigate to the project directory:
cd wheeldealapi/wheeldealapi

### Run the following command to start the Docker containers using Docker Compose:
docker-compose up -d

Access the API at http://localhost:8080/api/vehicle/calculate-price.

## API Endpoints
POST /api/vehicle/calculate-price: Calculate the total price of a vehicle at a car auction based on the vehicle's base price and type.

## Development
To run the project locally for development, you can use Visual Studio or Visual Studio Code with the C# extension. Open the project in your preferred IDE and run it using the built-in debugging tools.

## Testing
Navigate to the 'WheelDealAPI.Test' project to run them.