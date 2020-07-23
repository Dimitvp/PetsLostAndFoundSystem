#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["PetsLostAndFoundSystem.Watchdog/PetsLostAndFoundSystem.Watchdog.csproj", "PetsLostAndFoundSystem.Watchdog/"]
RUN dotnet restore "PetsLostAndFoundSystem.Watchdog/PetsLostAndFoundSystem.Watchdog.csproj"
COPY . .
WORKDIR "/src/PetsLostAndFoundSystem.Watchdog"
RUN dotnet build "PetsLostAndFoundSystem.Watchdog.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PetsLostAndFoundSystem.Watchdog.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PetsLostAndFoundSystem.Watchdog.dll"]