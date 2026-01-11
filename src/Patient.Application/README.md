# Patient.Application

The `Patient.Application` project implements the application layer, which coordinates the business logic and data flow.

## Architecture

It uses the **CQRS (Command Query Responsibility Segregation)** pattern with the **MediatR** library:

- **Commands**: Requests that change the state of the system (e.g., `AddPatientCommand`).
- **Queries**: Requests that retrieve data without changing the state (e.g., `GetPatientQuery`).
- **Handlers**: Logic to process commands and queries.
- **DTOs**: Data Transfer Objects used for communication with the API layer.

## Responsibilities

- Orchestrating domain entities to fulfill application use cases.
- Defining repository interfaces used by the application logic.
- Mapping between domain entities and DTOs.
