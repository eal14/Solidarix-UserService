# Objetivo del microservicio

    UserService → autenticación, registro, login.

# Patrones aplicados

* Clean Architecture: separación en capas (API, Application, Domain, Infrastructure).

* Naming conventions: sufijo .API, .Domain, etc.

# Decisiones técnicas

<!-- Por qué elegiste .NET 8.

Uso de controllers en lugar de minimal APIs.

Swagger/OpenAPI habilitado desde el inicio.-->

# Convenciones de proyecto

* Carpeta src/ para código principal, tests/ para pruebas.

* .sln en la raíz del repo.

* ADRs en docs/adr/.

# Pendientes o dudas abiertas

* Corregir design-notes.md

<!--Ejemplo: “Evaluar si migrar a Kubernetes en el futuro.”

“Revisar si el nombre Solidarix debe cambiar por temas de branding.”-->