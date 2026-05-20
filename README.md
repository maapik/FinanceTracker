# Finance Tracker

Веб-приложение для учета личных финансов и контроля бюджета. Разработано в рамках проекта на платформе **.NET 8** с использованием **Blazor Server** и архитектуры контейнеризации **Docker**.

## 🔗 Ссылки на проект
* **GitHub репозиторий:** [maapik/FinanceTracker](https://github.com/maapik/FinanceTracker)
* **Docker Hub образ:** [maapik/financetracker](https://hub.docker.com/r/maapik/financetracker/tags)

## Стек технологий
* **Язык и платформа:** C#, .NET 8.0, ASP.NET Core
* **Пользовательский интерфейс:** Blazor Server, HTML/CSS, Bootstrap 5 (Interactive Server Mode)
* **База данных:** SQLite
* **ORM:** Entity Framework Core 8.0 (Code First)
* **Инфраструктура:** Docker, Docker Compose

## ⚡Основной функционал
* Добавление, отслеживание и удаление финансовых транзакций (доходы и расходы).
* Создание и управление различными счетами.
* Автоматический пересчет баланса счетов в реальном времени.
* Хранение данных в персистентной базе данных (SQLite через Docker Volumes).

## Запуск проекта (через Docker)

Для запуска приложения на вашем компьютере должен быть установлен **Docker Desktop** (и запущен Docker Engine).

1. Склонируйте репозиторий на свой компьютер:
   ```bash
   git clone https://github.com/maapik/FinanceTracker.git

2. Перейдите в директорию с проектом:

cd FinanceTracker

3.Запустите сборку и старт контейнеров:

docker-compose up -d --build

4. Откройте веб-браузер и перейдите по адресу:

http://localhost:8080
