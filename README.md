# Sales Management

API para gerenciamento de vendas desenvolvida com .NET 8, seguindo os princípios de Clean Architecture.

## Tecnologias

- .NET 8
- Entity Framework Core
- FluentValidation
- Swagger / OpenAPI
- Docker

## Arquitetura

O projeto segue Clean Architecture com as seguintes camadas:

```
src/
├── Sales.API              # Camada de apresentação (Controllers, configuração)
├── Sales.Application      # Casos de uso, DTOs, interfaces, validações
├── Sales.Domain           # Entidades e regras de negócio
└── Sales.Infrastructure   # Acesso a dados, repositórios, serviços externos
```

## Como executar

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server (ou Docker)

### Rodando localmente

```bash
cd src/Sales.API
dotnet run
```

A API estará disponível em `https://localhost:5001` com Swagger UI em `/swagger`.

### Rodando com Docker

```bash
docker-compose up
```

## Endpoints

A documentação completa dos endpoints está disponível via Swagger ao executar a aplicação.
