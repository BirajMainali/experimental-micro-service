FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Booking.RideLoggingService/Booking.RideLoggingService.csproj", "Booking.RideLoggingService/"]
COPY ["Booking.RebbitMqEvents/Booking.RebbitMqEvents.csproj", "Booking.RebbitMqEvents/"]
RUN dotnet restore "Booking.RideLoggingService/Booking.RideLoggingService.csproj"
COPY . .
WORKDIR "/src/Booking.RideLoggingService"
RUN dotnet build "Booking.RideLoggingService.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "Booking.RideLoggingService.csproj" -c Debug -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Booking.RideLoggingService.dll"]
