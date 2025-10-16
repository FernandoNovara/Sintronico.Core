using Domain.Enums;

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

    /// <summary>
    /// Color of the bike 
    /// </summary>
    public string Color { get; set; } = string.Empty;

    /// <summary>
    /// state of the bike (Available, Rented, Sold, Reserved, Maintenance, Repaired)
    /// </summary>
    public BikeState State { get; set; } = BikeState.Available;

    /// <summary>
    /// Created date of the bike
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// last update state of the bike 
    /// </summary>
    public DateTime LastUpdatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// observations about the bike
    /// </summary>
    public string Observations { get; set; } = string.Empty;

    /// <summary>
    /// Price of the bike
    /// </summary>
    public double Price { get; set; } = 0.0;

    public Bike(Guid id, string model, string category, string color, double price)
    {
        BikeId = id;
        Model = model;
        Category = category;
        Color = color;
        Price = price;
    }

    public void ChangeState(BikeState newState)
    {
        if (!CanTransitionTo(newState))
            throw new InvalidOperationException($"Invalid state transition: {State} → {newState}");

        State = newState;
        LastUpdatedAt = DateTime.UtcNow;
    }

    public bool CanTransitionTo(BikeState newState)
    {
        return State switch
        {
            BikeState.Available => newState is BikeState.Reserved or BikeState.Rented or BikeState.Sold,
            BikeState.Maintenance => newState == BikeState.Repaired,
            BikeState.Reserved => newState is BikeState.Rented or BikeState.Sold,
            BikeState.Repaired => newState == BikeState.Available,
            BikeState.Rented => newState == BikeState.Available,
            _ => false
        };
    }
}
