# 8. mapping private fields from Entity to db using EF core

Date: 2023-04-07

## Status

Accepted

## Context

Private fields has some benifits on using in Entity. That need to persist to DB using EF Core

## Decision

We decided to using mapping as UsePropertyAccessMode(PropertyAccessMode.Field) to map private fields to DB

## Consequences

- PropertyAccessMode.Field is an option in EF Core that can be used to configure how the entity framework accesses and maps the fields of an entity class to database columns. By default, EF Core maps entity properties to database columns, but PropertyAccessMode.Field provides an option to map entity fields to database columns instead.

- When using PropertyAccessMode.Field, EF Core will attempt to map the fields of the entity class to database columns based on the field name. This can be useful in scenarios where the entity class contains fields that should not be exposed as properties, or when there is a performance benefit to using fields instead of properties.

- It's important to note that PropertyAccessMode.Field is not recommended for general use, as it can bypass some of EF Core's built-in conventions and may require additional configuration to ensure correct behavior. 

- Specifically to make it so that EF Core can do its work without forcing you to make your fields public. Otherwise, you would be forced to make it all public just so EF Core could access it, at the cost of you no longer being able to rely on the privacy of your fields.

- In summary, PropertyAccessMode.Field is an option in EF Core that allows fields of an entity class to be mapped to database columns instead of properties. However, it is not recommended for general use and may require additional configuration to ensure correct behavior. Additionally, fields mapped using PropertyAccessMode.Field are treated as read-only, and changes to the fields will not be persisted to the database.




