# UI

- In your settings.json of Visual Studio Code, be sure that you have this disabled:
```
"editor.formatOnSave": false,
```
- And add eslint configuration to use eslint as formatter:

```
"editor.codeActionsOnSave":
{
  "source.fixAll.eslint": true
},
```

- Install the dependencies:
```
npm i -D eslint @rocketseat/eslint-config
```
- Run the project:
```
npm run dev
```

# Onion Architecture / Clean Architecture

- Onion architecture can solve problem of separation of concern and tightly coupled components from N-layered architecture.
- All layers are depended on inner layer.
- The core of the application is the domain layer.
- Provide more testability than N-layered architecture.

<p align="center">
<img src="https://raw.githubusercontent.com/NilavPatel/dotnet-onion-architecture/main/docs/dotnet-onion-architecture.png">
</p>

## Layers

### Domain Layer:

This layer does not depend on any other layer. This layer contains entities, enums, specifications etc.  
Add repository and unit of work contracts in this layer.

### Application Layer:

This layer contains business logic, services, service interfaces, request and response models.  
Third party service interfaces are also defined in this layer.  
This layer depends on domain layer.  

### Infrastructure Layer:

This layer contains database related logic (Repositories and DbContext), and third party library implementation (like a logger and email service).  
This implementation is based on domain and infrastructure layer.

### Presentation Layer:

This layer contains Webapi or UI.

## Domain model

Domain model are of 2 types

1. Domain entity (data only)
	- This model contains only fields
    - This is an anti pattern used widely. Read blog from Martin Fowler (<a href="https://martinfowler.com/bliki/AnemicDomainModel.html">here</a>)

2. Domain model (data + behaviour)
	- This model has fields and behaviours. Fields can be modify only within behaviours.
	- Follow Aggregate pattern with Aggregate root, Value object, Entity, Bounded context, Ubiqutous language

# Technologies Used:
- [React](https://react.dev/learn/)
- [Vite](https://vitejs.dev/guide/)
- [shadcn-ui](https://ui.shadcn.com/docs/components/accordion)
- [.Net 7](https://dotnet.microsoft.com/pt-br/learn)
- [ASP.Net](https://dotnet.microsoft.com/pt-br/apps/aspnet)
- [Entity Framework](https://learn.microsoft.com/pt-br/ef/)
