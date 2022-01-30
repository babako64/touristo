#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Src/Services/BookService/BookService.API/BookService.API.csproj", "Src/Services/BookService/BookService.API/"]
COPY ["Src/BuildingBlocks/EventBus.Messages/EventBus.Messages.csproj", "Src/BuildingBlocks/EventBus.Messages/"]
RUN dotnet restore "Src/Services/BookService/BookService.API/BookService.API.csproj"
COPY . .
WORKDIR "/src/Src/Services/BookService/BookService.API"
RUN dotnet build "BookService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookService.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookService.API.dll"]
