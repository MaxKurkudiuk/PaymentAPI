# PaymentAPI

ASP.NET Core Web API for managing payment details, built with .NET 10 and Entity Framework Core (SQL Server).

## Prerequisites

For local non-Docker run
- .NET SDK 10.0+
- SQL Server (LocalDB or full SQL Server)

Docker run
- Docker Desktop (Linux containers mode)
- Docker Compose v2

## Configuration

This repository keeps connection strings empty in `PaymentAPI/appsettings.json` on purpose.
Set real values locally with **User Secrets**.

### 1) Initialize secrets (if needed)

```bash
dotnet user-secrets init --project PaymentAPI/PaymentAPI.csproj
```

### 2) Set connection strings

```bash
dotnet user-secrets set "ConnectionStrings:DevConnection" "Server=YOUR_SERVER;Database=YOUR_DB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;" --project PaymentAPI/PaymentAPI.csproj

dotnet user-secrets set "ConnectionStrings:PaymentDetailContext" "Server=YOUR_SERVER;Database=YOUR_DB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;" --project PaymentAPI/PaymentAPI.csproj
```

> `UserSecretsId` in the project file is safe to commit. Secret values are stored outside the repository.

### 3) Get connection strings

```bash
dotnet user-secrets list --project PaymentAPI/PaymentAPI.csproj
```

or just inside the project:

```bash
dotnet user-secrets list
```

## Run with Docker (recommended)

### 1) Configure `.env`

Set values in the root `.env` file.

Required:

- `API_PORT` (example: `5264`)
- `MSSQL_SA_PASSWORD` (must satisfy SQL Server password policy)
- `DEV_CONNECTION_STRING` with Docker SQL host:

```text
Server=sqlserver,1433;Database=PaymentDetailDB;User Id=sa;Password=<same as MSSQL_SA_PASSWORD>;TrustServerCertificate=True;Encrypt=True;MultipleActiveResultSets=true
```

> Do not use `(localdb)` or machine hostnames for container-to-container DB connection.

### 2) Build and start containers

```bash
docker compose up --build
```

### 3) Access API

- API base URL: `http://localhost:<API_PORT>`
- Swagger UI: `http://localhost:<API_PORT>/swagger`

### 4) Stop containers

```bash
docker compose down
```

To also remove DB volume/data:

```bash
docker compose down -v
```

## Run without Docker

```bash
dotnet restore PaymentAPI/PaymentAPI.csproj
dotnet run --project PaymentAPI/PaymentAPI.csproj
```

Swagger UI is available in Development at `https://localhost:<port>/swagger`.

## API Endpoints

Base route: `api/PaymentDetail`

- `GET /api/PaymentDetail` - list all payment details
- `GET /api/PaymentDetail/{paymentdetailid}` - get by id
- `POST /api/PaymentDetail` - create
- `PUT /api/PaymentDetail/{paymentdetailid}` - update
- `DELETE /api/PaymentDetail/{paymentdetailid}` - delete

## Notes

- CORS currently allows `http://localhost:4200`.
- The API is configured to apply EF Core migrations at startup.
- Keep production secrets in environment variables or a secret manager (for example Azure Key Vault).
