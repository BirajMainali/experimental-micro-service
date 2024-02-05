FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_ENVIRONMENT Development

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
ARG configuration=Release
COPY ["Booking.RideLoggingService/Booking.RideLoggingService.csproj", "Booking.RideLoggingService/"]
RUN dotnet restore "Booking.RideLoggingService/Booking.RideLoggingService.csproj"
COPY . .
WORKDIR "/src/Booking.RideLoggingService"
RUN dotnet build "Booking.RideLoggingService.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Booking.RideLoggingService.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Booking.RideLoggingService.dll"]
