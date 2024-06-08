# DataFetchAPI

## Overview
DataFetchAPI is a .NET application designed to retrieve data from a database and expose it via an API. The application follows the Onion Architecture to ensure a clean separation of concerns and high maintainability.

## Table of Contents
- [Overview](#overview)
- [Features](#features)
- [Architecture](#architecture)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Features
- Seamless Data Retrieval: Efficiently fetch data from a databases.
- Onion Architecture: Ensures a clean separation of concerns and high maintainability.
- Scalable and Secure: Designed to handle large volumes of data and ensure data security.
- Comprehensive Documentation: Guides you through setup, configuration, and usage.

## Architecture
The project is built using Onion Architecture, which consists of the following layers:

1. Core Layer:
    - Contains domain entities and interfaces.
    - Includes business logic and domain services.

2. Application Layer:
    - Contains application services.
    - Coordinates between the domain layer and the infrastructure layer.

3. Infrastructure Layer:
    - Contains implementations for data access and external services.
    - Handles database connections and other infrastructure concerns.

4. Presentation Layer:
    - Contains API controllers.
    - Exposes endpoints for data retrieval.

## Getting Started
Follow these steps to set up and run the project locally.

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or any other supported database

### Installation
1. Clone the repository:
   
    git clone https://github.com/yourusername/DataFetchAPI.git
    cd DataFetchAPI
    
2. Set up the database:
    - Update the database connection settings in a new .env file 

3. Restore dependencies:
   
    dotnet restore
    
4. Run the application:
   
    dotnet run
    
## Usage
The API will be accessible at http://***************/api. Below are some example endpoints:

- GET /api/products: Retrieve a list of all products.
- GET /api/products/{id}: Retrieve a specific product by ID.
- GET /api/products/{id}/recommendation: Retrieve a list of similiar category by ID.
