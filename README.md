# PaymentAPI

ASP.NET Core Web API for managing payment details, built with .NET 10 and Entity Framework Core (SQL Server).

## Prerequisites

- .NET SDK 10.0+
- SQL Server (LocalDB or full SQL Server)

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

## Run

```bash
dotnet restore PaymentAPI/PaymentAPI.csproj
dotnet run --project PaymentAPI/PaymentAPI.csproj
```

Swagger UI is available in Development at:

- `https://localhost:<port>/swagger`

## API Endpoints

Base route: `api/PaymentDetail`

- `GET /api/PaymentDetail` - list all payment details
- `GET /api/PaymentDetail/{paymentdetailid}` - get by id
- `POST /api/PaymentDetail` - create
- `PUT /api/PaymentDetail/{paymentdetailid}` - update
- `DELETE /api/PaymentDetail/{paymentdetailid}` - delete

## Notes

- CORS currently allows `http://localhost:4200`.
- Keep production secrets in environment variables or a secret manager (for example Azure Key Vault).
