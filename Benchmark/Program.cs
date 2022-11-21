using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using Domain;
using Microsoft.EntityFrameworkCore;

var summary = BenchmarkRunner.Run<MigrationTests>();

[SimpleJob(RunStrategy.ColdStart, RuntimeMoniker.Net60, launchCount: 1, targetCount: 10)]
[SimpleJob(RunStrategy.ColdStart, RuntimeMoniker.Net70, launchCount: 1, targetCount: 10)]
public class MigrationTests
{
    [IterationSetup]
    public void RemoveDatabase()
    {
        using var dbContext = new AdventureWorks2019Context();
        dbContext.Database.EnsureDeleted();
    }

    [Benchmark]
    public async Task Test()
    {
        using var dbContext = new AdventureWorks2019Context();
        await dbContext.Database.MigrateAsync();
    }
}