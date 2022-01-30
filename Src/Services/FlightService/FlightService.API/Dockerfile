#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Src/Services/FlightService/FlightService.API/FlightService.API.csproj", "Src/Services/FlightService/FlightService.API/"]
COPY ["Src/Services/FlightService/FlightService.Infrastructure/FlightService.Infrastructure.csproj", "Src/Services/FlightService/FlightService.Infrastructure/"]
COPY ["Src/Services/FlightService/FlightService.Application/FlightService.Application.csproj", "Src/Services/FlightService/FlightService.Application/"]
COPY ["Src/Services/FlightService/FlightService.Domain/FlightService.Domain.csproj", "Src/Services/FlightService/FlightService.Domain/"]
COPY ["Src/Services/FlightService/FlightService.Persistence/FlightService.Persistence.csproj", "Src/Services/FlightService/FlightService.Persistence/"]
COPY ["Src/BuildingBlocks/EventBus.Messages/EventBus.Messages.csproj", "Src/BuildingBlocks/EventBus.Messages/"]
RUN dotnet restore "Src/Services/FlightService/FlightService.API/FlightService.API.csproj"
COPY . .
WORKDIR "/src/Src/Services/FlightService/FlightService.API"
RUN dotnet build "FlightService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FlightService.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FlightService.API.dll"]
