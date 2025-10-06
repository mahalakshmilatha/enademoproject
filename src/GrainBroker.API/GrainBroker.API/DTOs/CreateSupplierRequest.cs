namespace GrainBroker.API.DTOs
{
    public class CreateSupplierRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string ContactInformation { get; set; } = string.Empty;
    }
}