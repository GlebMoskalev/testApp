# Используем официальный образ .NET SDK для сборки проекта
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Устанавливаем рабочую директорию в контейнере
WORKDIR /app

# Копируем csproj и восстанавливаем зависимости
COPY *.csproj ./
RUN dotnet restore

# Копируем все остальные файлы и публикуем проект
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Используем официальный образ .NET Runtime для запуска приложения
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

# Устанавливаем рабочую директорию в контейнере
WORKDIR /app

# Копируем скомпилированное приложение из контейнера сборки
COPY --from=build /app/publish .

# Открываем порт 8888
EXPOSE 8888

# Устанавливаем переменную окружения для режима Development
ENV ASPNETCORE_ENVIRONMENT=Development

# Запускаем приложение
ENTRYPOINT ["dotnet", "testApp.dll"]
