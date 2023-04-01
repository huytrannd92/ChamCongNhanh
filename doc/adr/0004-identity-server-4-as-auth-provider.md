# 4. Identity Server 4 as Auth provider

Date: 2023-03-30

## Status

Accepted

## Context

Need the IDP for all services supporting OIDC protocal with high customization.

## Decision

We decided to use Identity Server 4 for IDP.

## Consequences

No cost for customize and hosting an Identity Server 4, a highly customizable and feature-rich OIDC framework for .NET, then IdentityServer4 is a great choice. It provides a rich set of features and is highly customizable, allowing you to tailor the framework to your specific needs.

IdentityServer4 offers a wide range of features, including:

1. Support for various authentication protocols, including OIDC, OAuth2, and SAML2.

2. Built-in support for popular identity providers, such as Google, Facebook, and Microsoft.

3. Support for custom user stores, allowing you to use your own user management system.

4. Customizable login and consent screens, allowing you to tailor the user experience.

5. Support for token validation, token revocation, and token renewal.

6. Integration with ASP.NET Core, making it easy to integrate with your existing web applications.

There are also several third-party libraries and tools available that can help you extend and customize the framework further.