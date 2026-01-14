# Patient.Infrastructure

The `Patient.Infrastructure` project handles external concerns and provides implementations for interfaces defined in the application layer.

## MongoDB Integration

This project contains the implementation of `IPatientRepository` using **MongoDB**.

- **Documents**: MongoDB-specific document models (e.g., `PatientDocument`).
- **Repositories**: Concrete repository implementations using the MongoDB .NET Driver.
- **Settings**: Configuration classes for MongoDB connection strings and database/collection names.
- **Mappers**: Logic to convert between domain entities and MongoDB documents.

## Technology Stack

- MongoDB .NET Driver
- Microsoft.Extensions.Options for configuration management
