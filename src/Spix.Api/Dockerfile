#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/Spix.Api/Spix.Api.csproj", "src/Spix.Api/"]
COPY ["src/Spix.Application/Spix.Application.csproj", "src/Spix.Application/"]
COPY ["src/Spix.Domain/Spix.Domain.csproj", "src/Spix.Domain/"]
COPY ["src/Spix.Infra/Spix.Infra.csproj", "src/Spix.Infra/"]

RUN dotnet restore "src/Spix.Api/Spix.Api.csproj"
 

 
COPY . .
WORKDIR "/src/src/Spix.Api"
RUN dotnet build "Spix.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Spix.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Spix.Api.dll"]