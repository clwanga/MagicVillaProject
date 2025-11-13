using MagicVillaAPI.Models.Dtos;

namespace MagicVillaAPI.Data
{
    public static class VillaStore
    {
        public static List<VillaDto> villas = new List<VillaDto>
        {
            new VillaDto{ Id = 1, Name= "Pool view"},
            new VillaDto{ Id = 2, Name= "Beach view"}
        };
    }
}
