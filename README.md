# Blatta

```powershell
dotnet add src/Application package Microsoft.Extensions.DependencyInjection.Abstractions
dotnet add src/Application package Microsoft.Extensions.Logging.Abstractions
```

```powershell
dotnet new mstest --framework net10.0 --output tests/Application.UnitTests --name Blatta.Application.UnitTests
dotnet sln add tests/Application.UnitTests
dotnet add tests/Application.UnitTests reference src/Application
dotnet add tests/Application.UnitTests package NSubstitute
dotnet add tests/Application.UnitTests package Shouldly
```

```powershell
dotnet new mstest --framework net10.0 --output tests/Application.FunctionalTests --name Blatta.Application.FunctionalTests
dotnet sln add tests/Application.FunctionalTests
dotnet add tests/Application.FunctionalTests reference src/Infrastructure
dotnet add tests/Application.FunctionalTests package Microsoft.Extensions.Configuration
dotnet add tests/Application.FunctionalTests package Microsoft.Extensions.DependencyInjection
dotnet add tests/Application.FunctionalTests package Microsoft.Extensions.Logging
dotnet add tests/Application.FunctionalTests package Shouldly
```
