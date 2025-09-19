using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Bike
{
    /// <summary>
    /// Identifier for the bike
    /// </summary>
    public Guid BikeId { get; set; }

    /// <summary>
    /// Model of the bike
    /// </summary>
    public string Model { get; set; } = string.Empty;

    /// <summary>
    /// Category of the bike (MTB, Ruta, Gravel, Urbana, Plegable)
    /// </summary>
    public string Category { get; set; } = string.Empty;
}
