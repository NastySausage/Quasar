cd %~dp0
dotnet publish Quasar.client/Quasar.client.csproj --self-contained -p:PublishSingleFile=true -o bin\Release\Stub -r win-x64 -c Release