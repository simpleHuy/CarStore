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
    private string FindEnvFile()
    {
        // Get the directory containing the current source file
        var currentDirectory = Path.GetDirectoryName(new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName());

        // Go up to the CarStore.Core project root
        var projectRootPath = Directory.GetParent(currentDirectory).FullName;

        // Combine with .env file
        var envFilePath = Path.Combine(projectRootPath, ".env");

        // Verify file exists
        if (!File.Exists(envFilePath))
        {
            throw new FileNotFoundException($"Could not find .env file at: {envFilePath}");
        }

        return envFilePath;
    }




    public ApplicationDbContext CreateDbContext(string[] args)
    {
        //var basePath = AppContext.BaseDirectory;
        //var curDir = new DirectoryInfo(basePath);
        //var corePath = curDir.Parent.Parent.Parent.Parent.Parent;
        //var envFile = "D:\\DEV\\WindowsDev\\Project\\CarStore\\CarStore.Core\\.env";
    
       
        var envFile = FindEnvFile();
        DotNetEnv.Env.Load(envFile);
        var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

        if (connectionString == null)
        {
            Console.WriteLine("CONNECTION_STRING environment variable is not set.");
        }
        else
        {
            Console.WriteLine("CONNECTION_STRING found: " + connectionString);
        }


        if (string.IsNullOrEmpty(connectionString))
        {
            throw new Exception("Connection string not found");
        }

        var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionBuilder.UseNpgsql(connectionString);
        return new ApplicationDbContext(optionBuilder.Options);
    }
}
