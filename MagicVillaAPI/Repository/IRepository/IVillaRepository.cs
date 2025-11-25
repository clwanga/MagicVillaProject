using MagicVillaAPI.Models;
using System.Linq.Expressions;

namespace MagicVillaAPI.Repository.IRepository
{
    public interface IVillaRepository
    {
        //if you want to filter out based on some conditions eg linq statements,
        //pass "Expression" which will be function(func) of type villa
        Task<List<Villa>> GetAll(Expression<Func<Villa, bool>> filter = null);
        Task<Villa> Get(Expression<Func<Villa, bool>> filter = null, bool tracked = true);
        Task Create(Villa entity);
        Task Update(Villa entity);
        Task Remove(Villa entity);
        Task Save();
    }
}
