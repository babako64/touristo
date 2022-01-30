#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Src/Services/HotelService/HotelService.API/HotelService.API.csproj", "Src/Services/HotelService/HotelService.API/"]
COPY ["Src/Services/HotelService/HotelService.Persistence/HotelService.Persistence.csproj", "Src/Services/HotelService/HotelService.Persistence/"]
COPY ["Src/Services/HotelService/HotelService.Application/HotelService.Application.csproj", "Src/Services/HotelService/HotelService.Application/"]
COPY ["Src/Services/HotelService/HotelService.Domain/HotelService.Domain.csproj", "Src/Services/HotelService/HotelService.Domain/"]
RUN dotnet restore "Src/Services/HotelService/HotelService.API/HotelService.API.csproj"
COPY . .
WORKDIR "/src/Src/Services/HotelService/HotelService.API"
RUN dotnet build "HotelService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HotelService.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HotelService.API.dll"]
