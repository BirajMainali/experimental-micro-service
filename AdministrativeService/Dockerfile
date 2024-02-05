FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8081
EXPOSE 9091

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["AdministrativeService/AdministrativeService.csproj", "AdministrativeService/"]
RUN dotnet restore "AdministrativeService/AdministrativeService.csproj"
COPY . .
WORKDIR "/src/AdministrativeService"
RUN dotnet build "AdministrativeService.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "AdministrativeService.csproj" -c Debug -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_ENVIRONMENT=Development
ENTRYPOINT ["dotnet", "AdministrativeService.dll"]