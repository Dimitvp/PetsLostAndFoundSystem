#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["PetsLostAndFoundSystem.MVC/PetsLostAndFoundSystem.MVC.csproj", "PetsLostAndFoundSystem.MVC/"]
COPY ["PetsLostAndFoundSystem/PetsLostAndFoundSystem.csproj", "PetsLostAndFoundSystem/"]
RUN dotnet restore "PetsLostAndFoundSystem.MVC/PetsLostAndFoundSystem.MVC.csproj"
COPY . .
WORKDIR "/src/PetsLostAndFoundSystem.MVC"
RUN dotnet build "PetsLostAndFoundSystem.MVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PetsLostAndFoundSystem.MVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PetsLostAndFoundSystem.MVC.dll"]