namespace Models.Entities
{
    /// <summary>
    /// Implements representation of database entity 'Route'.
    /// </summary>
    public partial class Route
    {
        public int RouteId { get; set; }

        public int OutcomeCityId { get; set; }

        public int DestinationCityId { get; set; }

        public virtual City OutcomeCity { get; set; }

        public virtual City DestinationCity { get; set; }

    }
}
