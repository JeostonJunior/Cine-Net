using Cine_Net.Infra.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main()
    {
        var serviceCollection = new ServiceCollection();

        IConfiguration configuration;
        //ajuste para o seu diretorio raiz, Directory.GetCurrentDirectory() talvez resolva no seu caso
        string appSettingsPath = Path.Combine(@"C:\Users\Jack\Desktop\Java\Cine-Net\Cine-Net\", "appsettings.json");

        configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(appSettingsPath)
            .Build();

        serviceCollection.AddSingleton<IConfiguration>(configuration);

        //build da coleção de lifeTime da aplicação, aqui se pah ja tem um pattern
        var serviceProvider = serviceCollection.BuildServiceProvider();

        serviceProvider.GetService<IConfiguration>();

        //aqui eu pego a string de conexão dentro do arquivo appsettings
        //usei o user-secrets do C# para guardar a string de conexão
        var connectionString = configuration.GetSection("Settings:ConnectionString")["Cine-Net"];


        // instancia do dataBase, é aqui que iniciamos o BD
        var dataBase = new DataBase(connectionString);
    }
}
