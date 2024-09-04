@echo off
set /p "name=Enter MigrationName: "
dotnet ef migrations --startup-project ../TestTask/ add %name% --verbose  --context TestTaskContext
 set /p "name=Migration Done:"