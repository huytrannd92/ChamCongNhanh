# 7. using Private fields on entity for read-only / one-time create data

Date: 2023-04-07

## Status

Accepted

## Context

On Entity defination, That can have Fields and Properties defined for data/column
Fields and Columns can have differents behaviors for EF core Handling.

## Decision

We decide to define one time setting data in Entity as private fields. 

## Consequences

- Private set is a C# feature that allows you to declare a property with a private setter, which means that the property can only be set from within the same class or struct. This can be useful for encapsulating the state of an object and ensuring that it can only be modified by code that has been explicitly granted access.

- Using a private set in an EF Core entity class can provide similar benefits to using private fields. By making the setter private, you can control access to the property and ensure that it is only set in a controlled and validated manner. This can help to prevent invalid data from being assigned to the entity's properties.

- One key difference between private fields and private set properties in EF Core is that private fields are not mapped to the database, whereas private set properties are. This means that if you need to persist the property's value to the database, you will need to use a private set property rather than a private field.

- Another difference is that private set properties can still be accessed through reflection or other advanced techniques, whereas private fields are generally more difficult to access from outside the class. Therefore, if you need to ensure complete encapsulation, using a private set property may not be sufficient.

- In summary, private set properties in EF Core provide a way to control access to an entity's properties and ensure that they are only set in a controlled and validated manner. However, they are mapped to the database and can still be accessed through reflection, so they may not provide complete encapsulation.
