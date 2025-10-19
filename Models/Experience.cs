namespace filipealmeida.Models;

public record Experience(string Title, DateOnly From, DateOnly? To, string Company, string Location, string Description);
