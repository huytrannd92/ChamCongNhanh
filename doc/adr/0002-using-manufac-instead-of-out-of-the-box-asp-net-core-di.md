# 2. using manufac instead of out-of-the-box asp.net core DI

Date: 2023-03-30

## Status

Accepted

## Context

We need a tool with handle DI for global supporting common lifetime 

## Decision

We decided to use AutoFac as IOC container

## Consequences

- The most common pattern when registering types in an IoC container is to register a pair of types—an interface and its related implementation class. Then when you request an object from the IoC container through any constructor, you request an object of a certain type of interface
- Need implement abit different with Out of the box ASP.NET DI
- Do not depend on Framework and patterns.
- When using Autofac you typically register the types via modules, which allow you to split the registration types between multiple files depending on where your types are, just as you could have the application types distributed across multiple class libraries

There are several reasons why you might consider using Autofac instead of the built-in Dependency Injection (DI) in ASP.NET Core:

1. Flexible Configuration: Autofac provides more configuration options than the built-in DI in ASP.NET Core, including support for advanced scenarios such as property injection and instance per lifetime scope.

2. Extensibility: Autofac is designed to be extensible and customizable, allowing you to add your own customizations and features to the DI container.

3. Interoperability: Autofac is designed to work well with other DI containers, which means you can use it alongside other frameworks or libraries that use DI.

4. Advanced Scenarios: Autofac provides support for advanced scenarios such as multi-tenancy, dynamic component registration, and modular design.

5. Performance: While both Autofac and the built-in DI in ASP.NET Core are performant, Autofac is known for its speed and memory efficiency.

Ultimately, the choice between Autofac and the built-in DI in ASP.NET Core will depend on your specific needs and requirements. If you have advanced scenarios or require more flexibility and extensibility, Autofac may be the better choice for you. However, if you have simpler requirements and are looking for a straightforward, out-of-the-box solution, the built-in DI may be sufficient.