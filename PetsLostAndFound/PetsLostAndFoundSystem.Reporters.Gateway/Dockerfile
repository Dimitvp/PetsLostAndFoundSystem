#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["PetsLostAndFoundSystem.Reporters.Gateway/PetsLostAndFoundSystem.Reporters.Gateway.csproj", "PetsLostAndFoundSystem.Reporters.Gateway/"]
COPY ["PetsLostAndFoundSystem/PetsLostAndFoundSystem.csproj", "PetsLostAndFoundSystem/"]
RUN dotnet restore "PetsLostAndFoundSystem.Reporters.Gateway/PetsLostAndFoundSystem.Reporters.Gateway.csproj"
COPY . .
WORKDIR "/src/PetsLostAndFoundSystem.Reporters.Gateway"
RUN dotnet build "PetsLostAndFoundSystem.Reporters.Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PetsLostAndFoundSystem.Reporters.Gateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PetsLostAndFoundSystem.Reporters.Gateway.dll"]