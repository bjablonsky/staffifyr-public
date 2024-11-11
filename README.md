# Staffifyr

Staffifyr is a personnel management system built using Domain-Driven Design (DDD) principles. It includes a core domain model, a web API service, and a web UI for managing personnel information.

## Project Structure

- **Staffifyr.Core**: Contains the core domain model, including entities, value objects, and repositories.
- **Staffifyr.Application**: Contains the application layer.
- **Staffifyr.Infrastructure**: Contains the infrastructure layer, including repository implementations.
- **Staffifyr.Web.ApiService**: Contains the web API service for managing personnel.
- **Staffifyr.Web.UI**: Contains the web UI for managing personnel.
- **Staffifyr.Core.UnitTests**: Contains unit tests for the core domain model.

## Getting Started

### Prerequisites

- .NET 9.0-rc2 SDK or later
- Visual Studio 2022 Preview or later

### Building and running the Project

1. Clone the repository:  
``git clone https://github.com/bjablonsky/staffifyr-public.git``

1. Open the Staffifyr.sln solution in Visual Studio from the src directory.

1. Set Staffifyr.AppHost as the startup project.

1. Build the solution.

1. Run to start the .NET Aspire dashboard.

1. Find the webfrontend project in the dashboard and navigate to the endpoint.

## Project Considerations

- Better logging
- More units tests for all layers of the project
- A more robust core domain model that have better validations
- As project expands, move to aggregates for domain model
- Expand domain model to use specifications
- Implement infrastructure/persistence layer using real DB
- Refactor Blazor components so they can be reused and moved to the SharedComponents project
- Add integration and E2E testing
- Add authentication and rethink about using traditional web API instead of minimal API
- Add more error handling
- Consider using CQRS as the project grows and becomes more complex
- Consider vertical slice architecture to help define context bounds
- Consider event sourcing if it makes sense when scaling
- Use some type of caching as the project grows
- Scale out with containers and load balancers
- Add performance metric logging
- Add better error handling
- Add create feature to frontend
- Add CI/CD
