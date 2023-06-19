using Cine_Net.Domain.Entities;
using Cine_Net.Infra.Repositories;
using Cine_Net.Services.Facades;

internal class Program
{
    private static void Main()
    {
        int optionMain;
        int optionMenu;

        var unitOfWork = new UnitOfWork();

        var menu = new MenuFacade(unitOfWork);

        Console.WriteLine("======================================");
        Console.WriteLine("Bem vindo a rede de Cinemas Cine-Net!");
        Console.WriteLine("======================================");

        while (true)
        {


            menu.menuPrincipal();
            optionMain = Convert.ToInt32(Console.ReadLine());

            if (optionMain == 1)
            {
                menu.menuCRUD("Cinema");
                optionMenu = Convert.ToInt32(Console.ReadLine());
                menu.readOptionCinema(optionMenu);
            }
            else if (optionMain == 2)
            {
                menu.menuCRUD("Salas");
                optionMenu = Convert.ToInt32(Console.ReadLine());
                menu.readOptionSala(optionMenu);
            }
            else if (optionMain == 3)
            {
                menu.menuCRUD("Filmes");
                optionMenu = Convert.ToInt32(Console.ReadLine());
                menu.readOptionFilme(optionMenu);

            }
            else if (optionMain == 4)
            {
                menu.menuCRUD("Sessões");
                optionMenu = Convert.ToInt32(Console.ReadLine());
                menu.readOptionSessao(optionMenu);
            }

            else if (optionMain == 5)
            {

            }

            else if (optionMain == 6)
            {

            }
            else
            {
                Console.WriteLine("Opção inválida");
            }


        }


        /*
        var cinemaRepository = unitOfWork.CinemaRepository;

        // Example usage of the cache repositories

        cinemaRepository.Add(new Cinema { Id = 1, Nome = "CinemaSSA", Endereco = "Endereço ABC" });
        cinemaRepository.Add(new Cinema { Id = 2, Nome = "CinemaIguatemi", Endereco = "Endereço CBA" });
        var cachedCinema = cinemaRepository.GetById(2);

        // Print the retrieved data
        Console.WriteLine("Cinema:");
        Console.WriteLine($"Nome: {cachedCinema.Nome}, Endereço: {cachedCinema.Endereco}");
*/
    }
}