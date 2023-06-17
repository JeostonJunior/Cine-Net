using Cine_Net.Domain.Entities;
using Cine_Net.Infra.Repositories;

internal class Program
{
    private static void Main()
    {
        var unitOfWork = new UnitOfWork();

        var cinemaRepository = unitOfWork.CinemaRepository;

        // Example usage of the cache repositories

        cinemaRepository.Add(new Cinema { Id = 1, Nome = "Cinema ABC", Endereco = "Endereço ABC" });
        cinemaRepository.Add(new Cinema { Id = 2, Nome = "Cinema CBA", Endereco = "Endereço CBA" });
        var cachedCinema = cinemaRepository.GetById(2);

        // Print the retrieved data
        Console.WriteLine("Cinema:");
        Console.WriteLine($"Nome: {cachedCinema.Nome}, Endereço: {cachedCinema.Endereco}");
    }
}