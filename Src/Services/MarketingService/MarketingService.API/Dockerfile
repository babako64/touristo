#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Src/Services/MarketingService/MarketingService.API/MarketingService.API.csproj", "Src/Services/MarketingService/MarketingService.API/"]
RUN dotnet restore "Src/Services/MarketingService/MarketingService.API/MarketingService.API.csproj"
COPY . .
WORKDIR "/src/Src/Services/MarketingService/MarketingService.API"
RUN dotnet build "MarketingService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MarketingService.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MarketingService.API.dll"]
