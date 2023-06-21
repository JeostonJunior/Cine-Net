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
        Console.WriteLine("======================================\n");

        // Fax os pré cadastros
        menu.MenuInit();

        Console.Clear();

        while (true)
        {
            MenuFacade.MenuPrincipal();
            optionMain = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            switch (optionMain)
            {
                case 1:
                    MenuFacade.MenuCRUD("Cinema");

                    Console.Write("Escolha uma opção: ");
                    optionMenu = int.Parse(Console.ReadLine());

                    menu.ReadOptionCinema(optionMenu);
                    break;

                case 2:
                    MenuFacade.MenuCRUD("Salas");

                    Console.Write("Escolha uma opção: ");
                    optionMenu = int.Parse(Console.ReadLine());

                    menu.ReadOptionSala(optionMenu);
                    break;

                case 3:
                    MenuFacade.MenuCRUD("Filmes");

                    Console.Write("Escolha uma opção: ");
                    optionMenu = int.Parse(Console.ReadLine());

                    menu.ReadOptionFilme(optionMenu);
                    break;

                case 4:
                    MenuFacade.MenuCRUD("Sessões");

                    Console.Write("Escolha uma opção: ");
                    optionMenu = int.Parse(Console.ReadLine());

                    menu.ReadOptionSessao(optionMenu);
                    break;

                case 5:
                    // Lógica para a opção 5
                    break;

                case 6:
                    // Lógica para a opção 6
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }
    }
}