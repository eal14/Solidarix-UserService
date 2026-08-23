# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar archivos de solución y proyectos
COPY Solidarix.UserService.sln ./
COPY Solidarix.UserService.API/Solidarix.UserService.API.csproj Solidarix.UserService.API/
COPY Solidarix.UserService.Application/Solidarix.UserService.Application.csproj Solidarix.UserService.Application/
COPY Solidarix.UserService.Domain/Solidarix.UserService.Domain.csproj Solidarix.UserService.Domain/
COPY Solidarix.UserService.Infrastructure/Solidarix.UserService.Infrastructure.csproj Solidarix.UserService.Infrastructure/

# Restaurar dependencias
RUN dotnet restore Solidarix.UserService.sln

# Copiar todo el código
COPY . .

# Compilar en Release
RUN dotnet build Solidarix.UserService.sln -c Release --no-restore

# Publicar la API
RUN dotnet publish Solidarix.UserService.API/Solidarix.UserService.API.csproj -c Release -o /app/publish --no-restore

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Solidarix.UserService.API.dll"]
