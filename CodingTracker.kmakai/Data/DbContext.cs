using System.Configuration;
namespace CodingTracker.kmakai.Data;


public class DbContext
{
    static string? ConnectionString = ConfigurationManager.AppSettings.Get("connectionString");


}
