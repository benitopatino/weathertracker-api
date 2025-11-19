# =========
# BASE RUNTIME IMAGE
# =========
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app

# ASP.NET will listen on port 8080 inside the container
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# =========
# BUILD IMAGE
# =========
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# copy everything and restore
COPY . .
# 👇 update path/project name to match your .csproj
RUN dotnet restore "weatherapp-api.csproj"

# build
RUN dotnet build "weatherapp-api.csproj" -c Release -o /app/build

# =========
# PUBLISH IMAGE
# =========
FROM build AS publish
RUN dotnet publish "weatherapp-api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# =========
# FINAL RUNTIME IMAGE
# =========
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "weatherapp-api.dll"]
