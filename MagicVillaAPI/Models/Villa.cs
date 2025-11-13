namespace MagicVillaAPI.Models
{
    public class Villa
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
