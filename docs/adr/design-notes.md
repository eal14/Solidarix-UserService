# Design Notes - Solidarix UserService

## Objetivo
Microservicio responsable de autenticación y gestión de usuarios.

## Patrones aplicados
- Clean Architecture con separación en capas.
- Controllers en lugar de minimal APIs.
- Swagger/OpenAPI habilitado para documentación.

## Decisiones técnicas
- .NET 8 como framework principal.
- PostgreSQL para datos transaccionales.
- MongoDB para logs/eventos.

## Convenciones
- `src/` para proyectos principales.
- `tests/` para pruebas unitarias.
- `.sln` en la raíz del repo.

## Pendientes
- Evaluar despliegue en Kubernetes (AKS).
- Confirmar branding definitivo (Solidarix vs ClearChain).
