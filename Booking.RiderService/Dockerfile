FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Booking.RiderService/Booking.RiderService.csproj", "Booking.RiderService/"]
COPY ["Booking.RebbitMqEvents/Booking.RebbitMqEvents.csproj", "Booking.RebbitMqEvents/"]
RUN dotnet restore "Booking.RiderService/Booking.RiderService.csproj"
COPY . .
WORKDIR "/src/Booking.RiderService"
RUN dotnet build "Booking.RiderService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Booking.RiderService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Booking.RiderService.dll"]
