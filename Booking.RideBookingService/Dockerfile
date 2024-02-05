FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Booking.RideBookingService/Booking.RideBookingService.csproj", "Booking.RideBookingService/"]
COPY ["Booking.RebbitMqEvents/Booking.RebbitMqEvents.csproj", "Booking.RebbitMqEvents/"]
RUN dotnet restore "Booking.RideBookingService/Booking.RideBookingService.csproj"
COPY . .
WORKDIR "/src/Booking.RideBookingService"
RUN dotnet build "Booking.RideBookingService.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "Booking.RideBookingService.csproj" -c Debug -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Booking.RideBookingService.dll"]
