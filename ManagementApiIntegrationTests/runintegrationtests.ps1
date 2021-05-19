docker run -p 1433:1433 -d --name  sql jeffrygonzalez/productstestdb
Start-Sleep 30
dotnet test .\ManagementApiIntegrationTests.csproj
docker stop sql
docker rm sql