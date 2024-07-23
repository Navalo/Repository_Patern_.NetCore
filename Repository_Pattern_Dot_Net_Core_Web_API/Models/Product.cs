namespace Repository_Pattern_Dot_Net_Core_Web_API.Models
{
    public class Product        
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
    }
}
