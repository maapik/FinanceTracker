# Базовый образ для запуска (Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Образ для сборки (SDK)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["FinanceTracker.csproj", "./"]
RUN dotnet restore "FinanceTracker.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "FinanceTracker.csproj" -c Release -o /app/build

# Публикация проекта
FROM build AS publish
RUN dotnet publish "FinanceTracker.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Финальный образ (копируем только готовое)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Запуск приложения
ENTRYPOINT ["dotnet", "FinanceTracker.dll"]