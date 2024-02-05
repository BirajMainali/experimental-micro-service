FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 9090

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["RiderService/RiderService.csproj", "RiderService/"]
RUN dotnet restore "RiderService/RiderService.csproj"
COPY . .
WORKDIR "/src/RiderService"
RUN dotnet build "RiderService.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "RiderService.csproj" -c Debug -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_ENVIRONMENT=Development
ENTRYPOINT ["dotnet", "RiderService.dll"]