# 5. using dapper for query instead of EF Core and Generic Repository

Date: 2023-04-01

## Status

Accepted

## Context

Handle Queried for getting data and return to FE as DTO

## Decision

We decided to use Dapper and execute query directly in QueryHandlers without Generic Repository Interface

## Consequences

Pros:
- Do not define anemia entity flow through DTO, Handler, Repository, DBContext
- Directly Mapping result from DB to DTO, dynamic return fields
- Lightweight DAL to execute Scripts

Cons: 
- Do not have general entry for all query and handling
- Need to re-write code using DBContext If needed to track and handle Entities in the future/
- Need to write SQL script and stick to particular SQL Engine.
