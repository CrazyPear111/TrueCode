# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/CurrencyService/Presentation/TrueCode.CurrencyService.CurrencyUpdater/TrueCode.CurrencyService.CurrencyUpdater.csproj", "src/CurrencyService/Presentation/TrueCode.CurrencyService.CurrencyUpdater/"]
COPY ["src/CurrencyService/Application/TrueCode.CurrencyService.UseCases/TrueCode.CurrencyService.UseCases.csproj", "src/CurrencyService/Application/TrueCode.CurrencyService.UseCases/"]
COPY ["src/CurrencyService/Domain/TrueCode.CurrencyService.Currencies/TrueCode.CurrencyService.Currencies.csproj", "src/CurrencyService/Domain/TrueCode.CurrencyService.Currencies/"]
COPY ["src/CurrencyService/Application/TrueCode.CurrencyService.Models/TrueCode.CurrencyService.Models.csproj", "src/CurrencyService/Application/TrueCode.CurrencyService.Models/"]
COPY ["src/CurrencyService/Infrastructure/TrueCode.CurrencyService.Data/TrueCode.CurrencyService.Data.csproj", "src/CurrencyService/Infrastructure/TrueCode.CurrencyService.Data/"]
COPY ["src/CurrencyService/Infrastructure/TrueCode.CurrencyService.Configuration/TrueCode.CurrencyService.Configuration.csproj", "src/CurrencyService/Infrastructure/TrueCode.CurrencyService.Configuration/"]
COPY ["src/CurrencyService/Infrastructure/TrueCode.CurrencyService.RateClient/TrueCode.CurrencyService.RateClient.csproj", "src/CurrencyService/Infrastructure/TrueCode.CurrencyService.RateClient/"]
RUN dotnet restore "./src/CurrencyService/Presentation/TrueCode.CurrencyService.CurrencyUpdater/TrueCode.CurrencyService.CurrencyUpdater.csproj"
COPY . .
WORKDIR "/src/src/CurrencyService/Presentation/TrueCode.CurrencyService.CurrencyUpdater"
RUN dotnet build "./TrueCode.CurrencyService.CurrencyUpdater.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TrueCode.CurrencyService.CurrencyUpdater.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TrueCode.CurrencyService.CurrencyUpdater.dll"]