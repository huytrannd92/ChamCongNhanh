# 3. single transaction aggreegate in Schedule service

Date: 2023-03-30

## Status

Accepted

## Context

Need the content to manage transaction in many table and actions in Domain

## Decision

We decided to apply Aggreegate root with Repository Pattern, All changes to DB should place in Repository and UnitOfWork. Define one repository per aggregate

## Consequences

- Independenced to Implementation of DAL methods
- The Repository pattern makes it easier to test your application logic
