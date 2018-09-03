# ReminderApp Microservices
### Author: Gustavo Rodriguez

Microservices is an architecture style, in which complex applications are composed of small, autonomous processes communicate with each other using language agnostic

This app is composed of microservices following common patterns in this architecture style. The main services are named as follow:
  - Reminder
  - Reminder.BackgroundTasks (To run scheduled jobs)
  - User
  - Auth

Internally, each microservice is built following an Data-driven persistence pattern
https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/multi-container-microservice-net-applications/data-driven-crud-microservice

## Background tasks in microservices with IHostedService and the BackgroundService
Since .NET Core 2.0, the framework provides a new interface named IHostedService helping you to easily implement hosted services. The basic idea is that you can register multiple background tasks (hosted services), that run in the background while your web host or host is running: https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/multi-container-microservice-net-applications/background-tasks-with-ihostedservice

This was required to implement the schedule jobs that delivers the reminders to users

## API Gateway
The API Gateway and the Authorization Handling was done using 'Ocelot' library:
Ocelot is aimed at people using .NET running a micro services / service orientated architecture that need a unified point of entry into their system. Ocelot is a bunch of middlewares in a specific order.
https://ocelot.readthedocs.io/en/latest/introduction/bigpicture.html

## Health monitoring

Health Monitoring was done using an ASP.NET Core microservice library (not official as part of ASP.NETCore) named HealthChecks from the ASP.NET team.
This library is easy to use and provides features that let you validate that any specific external resource needed for your application (like a SQL Server database or remote API) is working properly. When you use this library, you can also decide what it means that the resource is healthy.

## Swagger

Each microservice integrates Swagger UI. Swagger UI allows anyone — be it your development team or your end consumers — to visualize and interact with the API’s resources without having any of the implementation logic in place. It’s automatically generated from your OpenAPI (formerly known as Swagger) Specification, with the visual documentation making it easy for back end implementation and client side consumption

## Incomplete Areas
  - Event Bus: It was started by implementing an event-based communication between microservices using integration events (Publish/Subscribe model), this was required to accomplish intercommunication between services, however it is not complete
  - Resilence: The solution is missing key points to handle resilences in the applications including:
    - Strategies for handling partial failure
    - Implementing retries with exponential backoff
    - Implementing resilient Entity Framework Core SQL connections
    - Implement HTTP call retries with exponential backoff with Polly
    - Implement the Circuit Breaker pattern
  - Quality of Service: Quality of service is the ability to provide different priorities to different applications, users, or data flows, or to guarantee a certain level of performance to a data flow. It was meant to be done using 'Ocelot' which uses Polly to achieve this job.

## Debt Tech

* Validation for model fields
* Repository Pattern


### Comments/Conclusions
* Forget DRY principle
* Reduce data integrity



