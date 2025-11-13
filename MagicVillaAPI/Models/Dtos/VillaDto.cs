using System.ComponentModel.DataAnnotations;

namespace MagicVillaAPI.Models.Dtos
{
    public class VillaDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public required string Name { get; set; }
    }
}
