

## Migrations

Add Migration
```shell
dotnet ef migrations add MigrationName --project Infra --startup-project API --output-dir Data/Migrations
```

Apply Migration
```shell
dotnet ef database update --project Infra --startup-project API
```
