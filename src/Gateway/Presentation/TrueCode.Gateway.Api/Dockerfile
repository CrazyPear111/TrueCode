# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Gateway/Presentation/TrueCode.Gateway.Api/TrueCode.Gateway.Api.csproj", "src/Gateway/Presentation/TrueCode.Gateway.Api/"]
COPY ["src/Gateway/Application/TrueCode.Gateway.UseCases/TrueCode.Gateway.UseCases.csproj", "src/Gateway/Application/TrueCode.Gateway.UseCases/"]
COPY ["src/Gateway/Infrastructure/TrueCode.Gateway.Configuration/TrueCode.Gateway.Configuration.csproj", "src/Gateway/Infrastructure/TrueCode.Gateway.Configuration/"]
COPY ["src/Gateway/Infrastructure/TrueCode.Gateway.CurrencyClient/TrueCode.Gateway.CurrencyClient.csproj", "src/Gateway/Infrastructure/TrueCode.Gateway.CurrencyClient/"]
RUN dotnet restore "./src/Gateway/Presentation/TrueCode.Gateway.Api/TrueCode.Gateway.Api.csproj"
COPY . .
WORKDIR "/src/src/Gateway/Presentation/TrueCode.Gateway.Api"
RUN dotnet build "./TrueCode.Gateway.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TrueCode.Gateway.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TrueCode.Gateway.Api.dll"]