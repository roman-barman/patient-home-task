# Patient.Api

The `Patient.Api` project is the entry point for the Patient Management System. It provides a RESTful interface to manage patient records.

## Features

- **Minimal API**: Uses the .NET 6 Minimal API approach for lightweight endpoint definitions.
- **Swagger Integration**: Integrated Swagger for API documentation and testing.
- **Health Checks**: Provides a `/healthz` endpoint to monitor the application and its connection to MongoDB.
- **MediatR**: Uses MediatR to decouple the API layer from the application logic.

## Endpoints

- `POST /patients`: Create a new patient.
- `PUT /patients/{id}`: Update or create a patient by ID.
- `GET /patients/{id}`: Get a patient by ID.
- `DELETE /patients/{id}`: Delete a patient by ID.
- `GET /patients?birthDate={search}`: Find patients by birth date using FHIR-like search prefixes (e.g., `eq`, `ne`, `gt`, `lt`, `ge`, `le`, `sa`, `eb`, `ap`).

## Configuration

The API configuration is located in `appsettings.json` (or via environment variables). It includes MongoDB connection settings.
