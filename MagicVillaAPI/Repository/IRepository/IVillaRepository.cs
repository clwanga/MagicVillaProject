using MagicVillaAPI.Models;
using System.Linq.Expressions;

namespace MagicVillaAPI.Repository.IRepository
{
    public class IVillaRepository
    {
        //if you want to filter out based on some conditions eg linq statements,
        //pass "Expression" which will be function(func) of type villa
        Task<List<Villa>> GetAll(Expression<Func<Villa>> filter = null);
        Task<Villa> Get(Expression<Func<Villa>> filter = null, bool tracked = true);
        Task Create(Villa entity);
        Task Remove(Villa entity);
        Task Save();
    }
}
