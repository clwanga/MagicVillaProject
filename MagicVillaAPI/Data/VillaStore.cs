using MagicVillaAPI.Models.Dtos;

namespace MagicVillaAPI.Data
{
    public static class VillaStore
    {
        public static List<VillaDto> villas = new List<VillaDto>
        {
            new VillaDto{ Id = 1, Name= "Pool view", Occupancy=4, Sqft=100},
            new VillaDto{ Id = 2, Name= "Beach view", Occupancy=3, Sqft=200}
        };
    }
}
