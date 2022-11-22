# EfCoreMigrationsBenchmark

Entity Framework Core 7 is slower than Entity Framework Core 6 when executing migrations. This benchmark, which requires a SQL Server running locally (though it's just a matter of changing the connection string), creates an AdventureWorks like database and applies just 5 migrations to it. Entity Framework Core 7 is up to 3 times slower according to these results:

| Method |  Runtime |       Mean |    Error |   StdDev |
|------- |--------- |-----------:|---------:|---------:|
|   Test | .NET 6.0 |   547.9 ms | 302.9 ms | 200.4 ms |
|   Test | .NET 7.0 | 1,412.9 ms | 421.2 ms | 278.6 ms |
