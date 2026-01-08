# Patient Home Task

This repository contains a sample patient management system built with .NET 6, following Clean Architecture principles.

## Project Structure

The solution consists of several projects:

- **Patient.Api**: A Minimal API that serves as the entry point for the system.
- **Patient.Feeder**: A console application that populates the system with sample data.
- **Patient.Core**: Contains domain entities, value objects, and core business logic.
- **Patient.Application**: Implements application logic using the CQRS pattern with MediatR.
- **Patient.Infrastructure**: Handles external concerns, specifically MongoDB integration.

## How to Run

The easiest way to run the entire system is using Docker Compose.

### Prerequisites

- Docker
- Docker Compose

### Starting the system

Run the following command in the root directory:

```bash
docker-compose up
```

This will start three services:
1. `mongodb`: The database.
2. `api`: The REST API (available at `http://localhost:5000`).
3. `feeder`: A service that generates and sends 100 sample patients to the API.

### Swagger UI

Once the API is running, you can access the Swagger UI at:
`http://localhost:5000/swagger/index.html`

## Postman Collection

A Postman collection is provided in the root directory: `Patient.postman_collection.json`.
