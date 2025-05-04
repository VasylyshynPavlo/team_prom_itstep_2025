# Team project. Clone Prom.ua
### Structure
Structure:
```
/MyApp
 ├── MyApp.Api       // Web API (controllers, auth)
 ├── MyApp.Core      // objects, DTO, interfaces
 ├── MyApp.Services  // services
 ├── MyApp.Data      // `DbContext`, repositories
 ```

### How to create
Creating projects
```
mkdir MyApp
cd MyApp
dotnet new sln -n MyApp
dotnet new webapi -n MyApp.Api
dotnet new classlib -n MyApp.Core
dotnet new classlib -n MyApp.Services
dotnet new classlib -n MyApp.Data
```
Links
```
dotnet add MyApp.Api reference MyApp.Services
dotnet add MyApp.Services reference MyApp.Core
dotnet add MyApp.Services reference MyApp.Data
dotnet add MyApp.Data reference MyApp.Core
dotnet sln add MyApp.Api MyApp.Core MyApp.Services MyApp.Data
```
Run
```
dotnet run
dotnet watch
```
