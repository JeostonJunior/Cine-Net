using Cine_Net.Domain.Entities;
using Cine_Net.Infra.Context;
using Cine_Net.Infra.Interfaces;
using Cine_Net.Infra.Repositories;
using Cine_Net.Services.Facades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main()
    {
        var serviceCollection = new ServiceCollection();

        IConfiguration configuration;

        ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

        configuration = configurationBuilder
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(GetAppSettingsPath())
            .AddUserSecrets<Program>()
            .Build();

        serviceCollection.AddSingleton<IConfiguration>(configuration);

        var connectionString = configuration["Settings:ConnectionString:Cine-Net"];
        serviceCollection.AddDbContext<DataBase>(options =>
            options.UseSqlServer(connectionString)
                .EnableSensitiveDataLogging(),
            ServiceLifetime.Transient);

        serviceCollection.AddScoped<DataBase>();
        serviceCollection.AddScoped<IRepository<Cinema>, Repository<Cinema>>();
        serviceCollection.AddScoped<IRepository<Sala>, Repository<Sala>>();
        serviceCollection.AddScoped<IRepository<Filme>, Repository<Filme>>();
        serviceCollection.AddScoped<IRepository<Sessao>, Repository<Sessao>>();
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
        serviceCollection.AddScoped<GerenciamentoCinemaFacade>();

        var serviceProvider = serviceCollection.BuildServiceProvider();
        var dbContext = serviceProvider.GetRequiredService<DataBase>();

        var unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>() as UnitOfWork;
        unitOfWork.SetContext(dbContext);

        var cinemaFacade = serviceProvider.GetService<GerenciamentoCinemaFacade>();

        cinemaFacade.CadastrarCinema("Cinema ABC", "Endereço ABC");

        // Resto do código...
    }

    private static string GetAppSettingsPath()
    {
        var config = new ConfigurationBuilder()
            .AddUserSecrets<Program>()
            .Build();

        return config["AppSettingsPath"];
    }
}
