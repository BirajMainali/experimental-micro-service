FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_ENVIRONMENT Development

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Booking.RiderService/Booking.RiderService.csproj", "Booking.RiderService/"]
RUN dotnet restore "Booking.RiderService/Booking.RiderService.csproj"
COPY . .
WORKDIR "/src/Booking.RiderService"
RUN dotnet build "Booking.RiderService.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Booking.RiderService.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Booking.RiderService.dll"]
