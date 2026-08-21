<!--
SUGERENCIAS COPILOT:
Breve descripción del microservicio.
Endpoints planeados (/register, /login, /refresh).
Cómo correrlo localmente (dotnet run, docker-compose up).
Estado del build (badge de GitHub Actions).-->

<!--
# Solidarix-UserService
Microservicio .NET para usuarios y autenticación.

# Descripción del servicio
# Endpoints planeados
# Diagrama de arquitectura-->

# ClearChain / Solidarix

Aplicación basada en microservicios para la gestión de proyectos solidarios.  
Este repositorio contiene los servicios principales y la configuración necesaria para levantar el stack con Docker.

---

## 📋 Requisitos previos

- [Git](https://git-scm.com/downloads)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- [Node.js](https://nodejs.org/) (si se requiere para frontend o scripts)
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) (para servicios en .NET)
- [MongoDB](https://www.mongodb.com/try/download/community) (si no se usa contenedor)

---

## 🚀 Instalación

1. **Clonar el repositorio**
    ```bash
    git clone https://github.com/tu-org/clearchain.git
    cd clearchain
    ```

2. **Configurar variables de entorno**
    Copia el archivo .env.example a .env y ajusta las credenciales según tu entorno:

    ```bash
        cp .env.example .env
    ```
3. **Construir los contenedores con Docker**
    ```bash
    docker-compose build
    ```

## ▶️ Ejecución

1. **Levantar el stack**
    ```bash
    docker-compose up
    ```

2. **Verificar que los servicios estén corriendo**
    * API AuthService: http://localhost:5000
    * API ProjectService: http://localhost:5001
    * MongoDB: mongodb://localhost:27017

3. **Probar endpoints**
    Usar curl o Postman:

    ```bash
    curl http://localhost:5000/api/auth/login
    ```
## 🧪 Testing
1. **Ejecutar pruebas unitarias**
    ```bash
    dotnet test
    ```
2. **Ejecutar pruebas de integración (si están configuradas)**
    ```bash
    docker-compose -f docker-compose.test.yml up --build
    ```

## 📌 Notas
* En Windows puedes usar CMD o PowerShell para los comandos.

* Si prefieres Visual Studio, abre la solución .sln y ejecuta desde allí, pero los pasos de consola son universales.

* Para detener los servicios:

    ```bash
    docker-compose down
    ```

## 🤝 Contribución

1. **Haz un fork del repositorio.**

2. **Crea una rama para tu feature:**

    ```bash
    git checkout -b feature/nueva-funcionalidad
    ```
3. **Haz commit de tus cambios y abre un Pull Request.**