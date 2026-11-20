# FinanceTracker

<p>
  <img src="https://img.shields.io/badge/C%23-.NET_8-27272a?style=for-the-badge&logo=dotnet&logoColor=d4d4d8&labelColor=090a0c" alt=".NET 8" />
  <img src="https://img.shields.io/badge/Blazor-Interactive_Server-1f2228?style=for-the-badge&logo=blazor&logoColor=d4d4d8&labelColor=090a0c" alt="Blazor Server" />
  <img src="https://img.shields.io/badge/EF_Core-8.0-27272a?style=for-the-badge&labelColor=090a0c" alt="EF Core 8" />
  <img src="https://img.shields.io/badge/SQLite-Persistent_Volume-1f2228?style=for-the-badge&logo=sqlite&logoColor=d4d4d8&labelColor=090a0c" alt="SQLite" />
  <img src="https://img.shields.io/badge/Docker-Compose-27272a?style=for-the-badge&logo=docker&logoColor=d4d4d8&labelColor=090a0c" alt="Docker" />
</p>

Веб-приложение для учёта личных финансов и контроля бюджета, построенное на **ASP.NET Core (.NET 8) Blazor Server** с использованием **Entity Framework Core**, **SQLite** и контейнеризации **Docker**.

---

## Основной функционал

- **Управление счетами:** создание, редактирование и удаление финансовых счетов.
- **Учёт транзакций:** добавление и отслеживание доходов (`Income`) и расходов (`Expense`) с привязкой к категориям и счетам.
- **Автоматический расчёт баланса:** пересчёт баланса при добавлении операций в реальном времени.
- **Персистентное хранение:** автоматическое применение EF Core миграций при старте и сохранение базы данных SQLite через Docker Volume.

---

## Стек технологий

| Слой | Технологии |
| :--- | :--- |
| **Backend & UI** | C#, .NET 8.0, ASP.NET Core Blazor Server (Interactive Server Components), Bootstrap 5 |
| **База данных и ORM** | SQLite, Entity Framework Core 8.0 (Code First Migrations) |
| **Инфраструктура** | Docker (multi-stage build), Docker Compose, Docker Hub |

---

## Структура проекта

```text
FinanceTracker/
├── docker-compose.yml
├── FinanceTracker.slnx
└── FinanceTracker/
    ├── Components/        # Blazor-страницы и layout
    ├── Data/              # AppDbContext (EF Core)
    ├── Migrations/        # Миграции SQLite
    ├── Models/            # Модели Account и Transaction
    ├── Services/          # Бизнес-логика (FinanceService)
    ├── Dockerfile         # Multi-stage сборка (.NET 8 SDK -> ASP.NET Runtime)
    └── Program.cs         # Конфигурация DI, миграций и pipeline
```

---

## Запуск проекта

### 1. Через Docker Compose (рекомендуется)

Требуется установленный **Docker Desktop** / **Docker Engine**:

1. Клонируйте репозиторий и перейдите в директорию:
   ```bash
   git clone https://github.com/maapik/FinanceTracker.git
   cd FinanceTracker
   ```
2. Запустите сборку и старт контейнера:
   ```bash
   docker-compose up -d --build
   ```
3. Откройте приложение в браузере: `http://localhost:8080`

### 2. Локальный запуск через .NET SDK

Требуется установленный **.NET 8 SDK**:

```bash
cd FinanceTracker
dotnet restore
dotnet run
```

---

## Ссылки

- **Репозиторий:** [github.com/maapik/FinanceTracker](https://github.com/maapik/FinanceTracker)
- **Образ на Docker Hub:** [hub.docker.com/r/maapik/financetracker](https://hub.docker.com/r/maapik/financetracker/tags)
