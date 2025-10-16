namespace Application.Mappers
{
    public static class BikeMapper
    {
        public static BikeDto ToDto(Bike bike) =>
            new(
                bike.BikeId,
                bike.Model,
                bike.Category,
                bike.Color,
                bike.State,
                bike.CreatedAt,
                bike.LastUpdatedAt,
                bike.Observations,
                bike.Price
            );

        public static Bike ToDomain(BikeDto dto) =>
            new(
                dto.BikeId,
                dto.Model,
                dto.Category,
                dto.Color,
                dto.Price
            )
            {
                Observations = dto.Observations,
                State = dto.State,
                CreatedAt = dto.CreatedAt,
                LastUpdatedAt = dto.LastUpdatedAt
            };
    }
}
