FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8082
EXPOSE 9092

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["CustomerService/CustomerService.csproj", "CustomerService/"]
RUN dotnet restore "CustomerService/CustomerService.csproj"
COPY . .
WORKDIR "/src/CustomerService"
RUN dotnet build "CustomerService.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "CustomerService.csproj" -c Debug -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_ENVIRONMENT=Development
ENTRYPOINT ["dotnet", "CustomerService.dll"]