namespace Infrastructure.Logging
{
    public class LoggerConfig
    {
        public static void ConfigureLogging() // Configuración de Serilog
        {
            Log.Logger = new LoggerConfiguration() // Configuración del logger
                .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning) // Ignora logs de Microsoft por debajo de Warning
                .MinimumLevel.Override("System", Serilog.Events.LogEventLevel.Warning) // Ignora logs de System por debajo de Warning
                .MinimumLevel.Debug() // Nivel mínimo para tu aplicación
                .Enrich.FromLogContext() // Enrichers para logs de ASP.NET Core (HttpContext, etc), se encarga de añadir información adicional a los logs
                .WriteTo.Console() // Escribe los logs en la consola
                .WriteTo.File("../SuperStock.Infrastructure/LogFile/Log-.txt", rollingInterval: RollingInterval.Day) // Escribe los logs en un archivo de texto con el formato Log-yyyyMMdd.txt
                .CreateLogger(); // Crea el logger
        }
    }
}
