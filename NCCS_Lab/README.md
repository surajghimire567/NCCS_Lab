# NET Centric Computing (CSC367) — Lab Practice Set (20 Questions)
NCCS College, Paknajol — BSc CSIT 6th Sem

## Structure

### PartA_CSharp/  — Questions 1-10 (standalone C# console projects)
Each folder is a self-contained .NET console project (its own .csproj + Program.cs).
Run any one with:
```
cd PartA_CSharp/Q01_StudentClass
dotnet run
```

| Folder | Question |
|---|---|
| Q01_StudentClass | Student class, auto-properties, constructor |
| Q02_ShapePolymorphism | Shape/Circle/Rectangle, virtual Area(), runtime polymorphism |
| Q03_WeekIndexer | Indexer: week[0] = "Sunday" |
| Q04_GenericStack | Generic Stack<T>: Push/Pop/Peek with int and string |
| Q05_AbstractEmployee | Abstract class Employee, Manager/Clerk override CalculateSalary() |
| Q06_InterfaceIPayable | Interface IPayable, Invoice/Salary, List<IPayable> polymorphism |
| Q07_DelegatesEvents | Delegate + event, temperature threshold notification |
| Q08_LinqLambda | LINQ + lambda: even numbers > 10, descending |
| Q09_FileIO | StreamReader/StreamWriter, try-catch-finally |
| Q10_AsyncAwait | async/await, Task.WhenAll, concurrent "downloads" |

### PartB_AspNetCoreMVC/NCCS_Lab_MVC/  — Questions 11-20 (one ASP.NET Core MVC project)
A single combined MVC project (see its own README.md inside) covering project
structure, controllers, Razor views, validation, routing, Web API, EF Core CRUD,
session state, Identity/authorization, and SQL injection prevention.

```
cd PartB_AspNetCoreMVC/NCCS_Lab_MVC
dotnet restore
dotnet run
```

## Requirements to run
- .NET 8 SDK installed (`dotnet --version` should print 8.x).
- For Part B: `dotnet-ef` CLI tool for the database migration (`dotnet tool install --global dotnet-ef`).

## Note
These files were generated without a local .NET SDK available in this session
(so they have not been compiled/run here) — the code follows standard,
well-tested ASP.NET Core / C# patterns, but do a `dotnet build` pass yourself
before your lab submission/demo to catch any environment-specific issues.
