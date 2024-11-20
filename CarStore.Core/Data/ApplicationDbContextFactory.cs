using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CarStore.Core.Data;
public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var basePath = AppContext.BaseDirectory;
        var curDir = new DirectoryInfo(basePath);
        var envFile = Path.Combine(curDir.FullName, ".env");
        DotNetEnv.Env.Load(envFile);
        var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new Exception("Connection string not found");
        }

        var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionBuilder.UseNpgsql(connectionString);
        return new ApplicationDbContext(optionBuilder.Options);
    }
}
