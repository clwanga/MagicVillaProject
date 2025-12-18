using MagicVillaAPI.Data;
using MagicVillaAPI.Models;
using MagicVillaAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MagicVillaAPI.Repository
{
    public class VillaRepository : Repository<Villa>, IVillaRepository
    {
        private readonly ApplicationDbContext _db;

        //the Repository<Villa> also requires a db context in it's constructor, so we pass db to the base
        public VillaRepository(ApplicationDbContext db): base(db) 
        {
            this._db = db;
        }


        public async Task<Villa> Update(Villa entity)
        {
            //time update function took place
            entity.UpdatedDate = DateTime.Now;

            _db.Villas.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
