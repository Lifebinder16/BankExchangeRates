# Загружаю образ с оф сайта
FROM mcr.microsoft.com/dotnet/aspnet:3.1-nanoserver-ltsc2022 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1-nanoserver-ltsc2022 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "BankExchangeRates.dll"]