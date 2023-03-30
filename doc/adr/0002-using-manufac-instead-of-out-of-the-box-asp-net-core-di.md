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
