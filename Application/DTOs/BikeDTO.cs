namespace Application.DTOs
{
    public record BikeDto(
        Guid BikeId,
        string Model,
        string Category,
        string Color,
        BikeState State,
        DateTime CreatedAt,
        DateTime LastUpdatedAt,
        string Observations,
        double Price
    );
}
