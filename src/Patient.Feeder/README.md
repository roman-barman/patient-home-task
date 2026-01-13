# Patient.Feeder

The `Patient.Feeder` is a console application designed to populate the Patient Management System with sample data for testing purposes.

## Functionality

Upon execution, the feeder:
1. Generates 100 random patients with realistic names (Russian names and surnames).
2. Randomly assigns gender, birth date, and active status.
3. Sends each generated patient to the `Patient.Api` via POST requests.

## Usage

In a development environment, ensure the API is running at `http://api:80` (as defined in `docker-compose.yml`) or adjust the base address in `Program.cs`.
